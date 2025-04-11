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
    | US6_0 of f0_0 : Mut0 * f0_1 : Mut1 * f0_2 : Mut2 * f0_3 : Mut3 * f0_4 : Mut4 * f0_5 : int64 option
    | US6_1
and [<Struct>] US7 =
    | US7_0 of f0_0 : string * f0_1 : US5
    | US7_1 of f1_0 : string
and [<Struct>] US8 =
    | US8_0 of f0_0 : char * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US8_1 of f1_0 : string
and UH0 =
    | UH0_0
    | UH0_1 of char * UH0
and UH1 =
    | UH1_0
    | UH1_1 of (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) * UH1
and [<Struct>] US9 =
    | US9_0 of f0_0 : string * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US9_1 of f1_0 : string
and [<Struct>] US10 =
    | US10_0 of f0_0 : char
    | US10_1
and [<Struct>] US11 =
    | US11_0 of f0_0 : string * f0_1 : System.Text.StringBuilder * f0_2 : int32 * f0_3 : int32
    | US11_1 of f1_0 : string
and [<Struct>] US12 =
    | US12_0 of f0_0 : string * f0_1 : US5 * f0_2 : string * f0_3 : System.Text.StringBuilder * f0_4 : int32 * f0_5 : int32
    | US12_1 of f1_0 : string
and [<Struct>] US13 =
    | US13_0 of f0_0 : US10 * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US13_1 of f1_0 : string
and [<Struct>] US14 =
    | US14_0 of f0_0 : US5 * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US14_1 of f1_0 : string
and Mut5 = {mutable l0 : int32}
and [<Struct>] US15 =
    | US15_0 of f0_0 : (struct (int32 * string * bool) -> Async<unit>)
    | US15_1
and [<Struct>] US16 =
    | US16_0 of f0_0 : System.Threading.CancellationToken
    | US16_1
and Heap0 = {l0 : string; l1 : System.Threading.CancellationToken option; l2 : (struct (string * string) []); l3 : (struct (int32 * string * bool) -> Async<unit>) option; l4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option; l5 : bool; l6 : string option}
and [<Struct>] US17 =
    | US17_0 of f0_0 : (string [])
    | US17_1 of f1_0 : string
and UH2 =
    | UH2_0
    | UH2_1 of string * UH2
and [<Struct>] US18 =
    | US18_0 of f0_0 : UH2 * f0_1 : string * f0_2 : System.Text.StringBuilder * f0_3 : int32 * f0_4 : int32
    | US18_1 of f1_0 : string
and UH3 =
    | UH3_0
    | UH3_1 of (struct (string * System.Text.StringBuilder * int32 * int32) -> US9) * UH3
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
and method8 () : (int64 -> US2) =
    closure6()
and method9 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method10 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method7 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US2) = method8()
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
    let v361 : string = method9()
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
    let v384 : (int64 -> US2) = method8()
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
    let v547 : string = method9()
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
    let v572 : (int64 -> US2) = method8()
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
    let v619 : (int64 -> US2) = method8()
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
    let v782 : string = method10()
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
    let v805 : (int64 -> US2) = method8()
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
    let v968 : string = method10()
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
    let v991 : (int64 -> US2) = method8()
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
    let v1154 : string = method10()
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
    let v1177 : (int64 -> US2) = method8()
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
    let v1340 : string = method10()
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
and method12 (v0 : char) : string =
    let v1 : string = method13()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure7(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method14 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method11 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method12(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_yellow"
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
    let v70 : string = "inline_colorization::color_yellow"
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
    let v114 : string = "inline_colorization::color_yellow"
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
    let v159 : string = "\u001b[93m"
    let v163 : string = method14()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[93m"
    let v179 : string = method14()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[93m"
    let v195 : string = method14()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[93m"
    let v211 : string = method14()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method16 () : string =
    let v0 : string = method13()
    let v1 : Mut3 = {l0 = v0} : Mut3
    let v2 : string = v1.l0
    v2
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
and method15 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method16()
    let v9 : int64 = v0.l0
    let v12 : string = " "
    let v13 : string = v6 + v12 
    let v17 : string = v13 + v7 
    let v22 : string = " #"
    let v23 : string = v17 + v22 
    let v27 : (int64 -> string) = _.ToString()
    let v28 : string = v27 v9
    let v32 : string = v23 + v28 
    let v36 : string = v32 + v12 
    let v41 : string = "runtime.current_process_kill / exiting... 3"
    let v42 : string = v36 + v41 
    let v47 : string = " / "
    let v48 : string = v42 + v47 
    let v52 : string = v48 + v8 
    method17(v52)
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
and closure5 () () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure0()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
    let v57 : US0 = v43.l0
    let v58 : bool = v41.l0
    let v59 : bool = v58 = false
    let v62 : bool =
        if v59 then
            false
        else
            let v60 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v57
            let v61 : bool = 3 >= v60
            v61
    let v63 : bool = v62 = false
    let v297 : US6 =
        if v63 then
            US6_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v121 : string = method7(v103, v104, v105, v106, v107, v108)
            let v122 : string = method11()
            let v123 : string = method15(v103, v104, v105, v106, v107, v108, v121, v122)
            let v138 : unit = ()
            let v139 : unit = (fun () -> v15 (); v138) ()
            let struct (v162 : Mut0, v163 : Mut1, v164 : Mut2, v165 : Mut3, v166 : Mut4, v167 : int64 option) = TraceState.trace_state.Value
            let v182 : unit = ()
            let v183 : (unit -> unit) = closure8(v162)
            let v184 : unit = (fun () -> v183 (); v182) ()
            let v187 : (string -> unit) = closure9()
            (* run_target_args'
            let v188 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v189 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v123 v189 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v123 v190 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v191 : string = v165.l0
            let v192 : bool = v191 = ""
            let v207 : string =
                if v192 then
                    v123
                else
                    let v193 : bool = v123 = ""
                    if v193 then
                        let v194 : string = v165.l0
                        v194
                    else
                        let v195 : string = v165.l0
                        let v198 : string = "\n"
                        let v199 : string = v195 + v198 
                        let v203 : string = v199 + v123 
                        v203
            (* run_target_args'
            let v212 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v213 : string = "&*$0"
            let v214 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v213 
            let _run_target_args'_v212 = v214 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v215 
            let _run_target_args'_v212 = v216 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v217 
            let _run_target_args'_v212 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v220 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v220 
            #endif
#if FABLE_COMPILER_PYTHON
            let v224 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v224 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v228 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v228 
            #endif
#else
            let v232 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v232 
            #endif
            let v235 : Ref<Str> = _run_target_args'_v212 
            let v244 : string = $"$0.chars()"
            let v245 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v235 v244 
            let v246 : string = "$0"
            let v247 : _ = Fable.Core.RustInterop.emitRustExpr v245 v246 
            let v248 : string = "$0.collect::<Vec<_>>()"
            let v249 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v251 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v253 : bool = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "x"
            let v255 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v254 
            let v256 : string = "String::from_iter($0)"
            let v257 : std_string_String = Fable.Core.RustInterop.emitRustExpr v255 v256 
            let v258 : string = "true; $0 }).collect::<Vec<_>>()"
            let v259 : bool = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "_vec_map"
            let v261 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v260 
            let v262 : string = "$0.len()"
            let v263 : unativeint = Fable.Core.RustInterop.emitRustExpr v261 v262 
            let v269 : int32 = v263 |> int32 
            let v279 : string = ""
            let v280 : bool = v123 <> v279 
            let v284 : bool =
                if v280 then
                    let v283 : bool = v269 <= 1
                    v283
                else
                    false
            if v284 then
                v165.l0 <- v207
                ()
            else
                v165.l0 <- v279
                let v285 : string = "true; $0.into_iter().for_each(|x| { //"
                let v286 : bool = Fable.Core.RustInterop.emitRustExpr v261 v285 
                let v287 : string = "x"
                let v288 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v287 
                let v289 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v290 : bool = Fable.Core.RustInterop.emitRustExpr v288 v289 
                let v291 : string = $"true"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr () v291 
                let v293 : string = "true; }); //"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v187 v123
            #endif
#if FABLE_COMPILER_PYTHON
            v187 v123
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v187 v123
            #endif
#else
            v187 v123
            #endif
            // run_target_args' is_unit
            let v295 : (string -> unit) = v163.l0
            v295 v123
            US6_0(v162, v163, v164, v165, v166, v167)
    
    ()
and method18 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method16()
    let v9 : int64 = v0.l0
    let v12 : string = " "
    let v13 : string = v6 + v12 
    let v17 : string = v13 + v7 
    let v22 : string = " #"
    let v23 : string = v17 + v22 
    let v27 : (int64 -> string) = _.ToString()
    let v28 : string = v27 v9
    let v32 : string = v23 + v28 
    let v36 : string = v32 + v12 
    let v41 : string = "runtime.current_process_kill / exiting... 2"
    let v42 : string = v36 + v41 
    let v47 : string = " / "
    let v48 : string = v42 + v47 
    let v52 : string = v48 + v8 
    method17(v52)
and closure11 () () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure0()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
    let v57 : US0 = v43.l0
    let v58 : bool = v41.l0
    let v59 : bool = v58 = false
    let v62 : bool =
        if v59 then
            false
        else
            let v60 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v57
            let v61 : bool = 3 >= v60
            v61
    let v63 : bool = v62 = false
    let v297 : US6 =
        if v63 then
            US6_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v121 : string = method7(v103, v104, v105, v106, v107, v108)
            let v122 : string = method11()
            let v123 : string = method18(v103, v104, v105, v106, v107, v108, v121, v122)
            let v138 : unit = ()
            let v139 : unit = (fun () -> v15 (); v138) ()
            let struct (v162 : Mut0, v163 : Mut1, v164 : Mut2, v165 : Mut3, v166 : Mut4, v167 : int64 option) = TraceState.trace_state.Value
            let v182 : unit = ()
            let v183 : (unit -> unit) = closure8(v162)
            let v184 : unit = (fun () -> v183 (); v182) ()
            let v187 : (string -> unit) = closure9()
            (* run_target_args'
            let v188 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v189 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v123 v189 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v123 v190 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v191 : string = v165.l0
            let v192 : bool = v191 = ""
            let v207 : string =
                if v192 then
                    v123
                else
                    let v193 : bool = v123 = ""
                    if v193 then
                        let v194 : string = v165.l0
                        v194
                    else
                        let v195 : string = v165.l0
                        let v198 : string = "\n"
                        let v199 : string = v195 + v198 
                        let v203 : string = v199 + v123 
                        v203
            (* run_target_args'
            let v212 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v213 : string = "&*$0"
            let v214 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v213 
            let _run_target_args'_v212 = v214 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v215 
            let _run_target_args'_v212 = v216 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v217 
            let _run_target_args'_v212 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v220 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v220 
            #endif
#if FABLE_COMPILER_PYTHON
            let v224 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v224 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v228 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v228 
            #endif
#else
            let v232 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v232 
            #endif
            let v235 : Ref<Str> = _run_target_args'_v212 
            let v244 : string = $"$0.chars()"
            let v245 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v235 v244 
            let v246 : string = "$0"
            let v247 : _ = Fable.Core.RustInterop.emitRustExpr v245 v246 
            let v248 : string = "$0.collect::<Vec<_>>()"
            let v249 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v251 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v253 : bool = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "x"
            let v255 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v254 
            let v256 : string = "String::from_iter($0)"
            let v257 : std_string_String = Fable.Core.RustInterop.emitRustExpr v255 v256 
            let v258 : string = "true; $0 }).collect::<Vec<_>>()"
            let v259 : bool = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "_vec_map"
            let v261 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v260 
            let v262 : string = "$0.len()"
            let v263 : unativeint = Fable.Core.RustInterop.emitRustExpr v261 v262 
            let v269 : int32 = v263 |> int32 
            let v279 : string = ""
            let v280 : bool = v123 <> v279 
            let v284 : bool =
                if v280 then
                    let v283 : bool = v269 <= 1
                    v283
                else
                    false
            if v284 then
                v165.l0 <- v207
                ()
            else
                v165.l0 <- v279
                let v285 : string = "true; $0.into_iter().for_each(|x| { //"
                let v286 : bool = Fable.Core.RustInterop.emitRustExpr v261 v285 
                let v287 : string = "x"
                let v288 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v287 
                let v289 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v290 : bool = Fable.Core.RustInterop.emitRustExpr v288 v289 
                let v291 : string = $"true"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr () v291 
                let v293 : string = "true; }); //"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v187 v123
            #endif
#if FABLE_COMPILER_PYTHON
            v187 v123
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v187 v123
            #endif
#else
            v187 v123
            #endif
            // run_target_args' is_unit
            let v295 : (string -> unit) = v163.l0
            v295 v123
            US6_0(v162, v163, v164, v165, v166, v167)
    
    ()
and method19 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string) : string =
    let v8 : string = method16()
    let v9 : int64 = v0.l0
    let v12 : string = " "
    let v13 : string = v6 + v12 
    let v17 : string = v13 + v7 
    let v22 : string = " #"
    let v23 : string = v17 + v22 
    let v27 : (int64 -> string) = _.ToString()
    let v28 : string = v27 v9
    let v32 : string = v23 + v28 
    let v36 : string = v32 + v12 
    let v41 : string = "runtime.current_process_kill / exiting... 1"
    let v42 : string = v36 + v41 
    let v47 : string = " / "
    let v48 : string = v42 + v47 
    let v52 : string = v48 + v8 
    method17(v52)
and closure12 () () : unit =
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure0()
    let v16 : unit = (fun () -> v15 (); v14) ()
    let struct (v39 : Mut0, v40 : Mut1, v41 : Mut2, v42 : Mut3, v43 : Mut4, v44 : int64 option) = TraceState.trace_state.Value
    let v57 : US0 = v43.l0
    let v58 : bool = v41.l0
    let v59 : bool = v58 = false
    let v62 : bool =
        if v59 then
            false
        else
            let v60 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v57
            let v61 : bool = 3 >= v60
            v61
    let v63 : bool = v62 = false
    let v297 : US6 =
        if v63 then
            US6_1
        else
            let v79 : unit = ()
            let v80 : unit = (fun () -> v15 (); v79) ()
            let struct (v103 : Mut0, v104 : Mut1, v105 : Mut2, v106 : Mut3, v107 : Mut4, v108 : int64 option) = TraceState.trace_state.Value
            let v121 : string = method7(v103, v104, v105, v106, v107, v108)
            let v122 : string = method11()
            let v123 : string = method19(v103, v104, v105, v106, v107, v108, v121, v122)
            let v138 : unit = ()
            let v139 : unit = (fun () -> v15 (); v138) ()
            let struct (v162 : Mut0, v163 : Mut1, v164 : Mut2, v165 : Mut3, v166 : Mut4, v167 : int64 option) = TraceState.trace_state.Value
            let v182 : unit = ()
            let v183 : (unit -> unit) = closure8(v162)
            let v184 : unit = (fun () -> v183 (); v182) ()
            let v187 : (string -> unit) = closure9()
            (* run_target_args'
            let v188 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v189 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v123 v189 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v190 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v123 v190 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v191 : string = v165.l0
            let v192 : bool = v191 = ""
            let v207 : string =
                if v192 then
                    v123
                else
                    let v193 : bool = v123 = ""
                    if v193 then
                        let v194 : string = v165.l0
                        v194
                    else
                        let v195 : string = v165.l0
                        let v198 : string = "\n"
                        let v199 : string = v195 + v198 
                        let v203 : string = v199 + v123 
                        v203
            (* run_target_args'
            let v212 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v213 : string = "&*$0"
            let v214 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v213 
            let _run_target_args'_v212 = v214 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v215 
            let _run_target_args'_v212 = v216 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v207 v217 
            let _run_target_args'_v212 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v220 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v220 
            #endif
#if FABLE_COMPILER_PYTHON
            let v224 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v224 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v228 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v228 
            #endif
#else
            let v232 : Ref<Str> = v207 |> unbox<Ref<Str>>
            let _run_target_args'_v212 = v232 
            #endif
            let v235 : Ref<Str> = _run_target_args'_v212 
            let v244 : string = $"$0.chars()"
            let v245 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v235 v244 
            let v246 : string = "$0"
            let v247 : _ = Fable.Core.RustInterop.emitRustExpr v245 v246 
            let v248 : string = "$0.collect::<Vec<_>>()"
            let v249 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v251 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v253 : bool = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "x"
            let v255 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v254 
            let v256 : string = "String::from_iter($0)"
            let v257 : std_string_String = Fable.Core.RustInterop.emitRustExpr v255 v256 
            let v258 : string = "true; $0 }).collect::<Vec<_>>()"
            let v259 : bool = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "_vec_map"
            let v261 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v260 
            let v262 : string = "$0.len()"
            let v263 : unativeint = Fable.Core.RustInterop.emitRustExpr v261 v262 
            let v269 : int32 = v263 |> int32 
            let v279 : string = ""
            let v280 : bool = v123 <> v279 
            let v284 : bool =
                if v280 then
                    let v283 : bool = v269 <= 1
                    v283
                else
                    false
            if v284 then
                v165.l0 <- v207
                ()
            else
                v165.l0 <- v279
                let v285 : string = "true; $0.into_iter().for_each(|x| { //"
                let v286 : bool = Fable.Core.RustInterop.emitRustExpr v261 v285 
                let v287 : string = "x"
                let v288 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v287 
                let v289 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v290 : bool = Fable.Core.RustInterop.emitRustExpr v288 v289 
                let v291 : string = $"true"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr () v291 
                let v293 : string = "true; }); //"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v187 v123
            #endif
#if FABLE_COMPILER_PYTHON
            v187 v123
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v187 v123
            #endif
#else
            v187 v123
            #endif
            // run_target_args' is_unit
            let v295 : (string -> unit) = v163.l0
            v295 v123
            US6_0(v162, v163, v164, v165, v166, v167)
    
    ()
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
    let v312 : unit = ()
    let v313 : (unit -> unit) = closure5()
    let v314 : unit = (fun () -> v313 (); v312) ()
    System.Threading.Thread.Sleep 300
    let v940 : unit = ()
    let v941 : (unit -> unit) = closure11()
    let v942 : unit = (fun () -> v941 (); v940) ()
    System.Console.Out.Flush ()
    System.Threading.Thread.Sleep 60
    let v1568 : unit = ()
    let v1569 : (unit -> unit) = closure12()
    let v1570 : unit = (fun () -> v1569 (); v1568) ()
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
and method25 (v0 : char, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : string =
    let v4 : string = method13()
    let v5 : Mut3 = {l0 = v4} : Mut3
    let v8 : string = "{ "
    let v9 : string = $"{v8}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure7(v5, v9)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v27 : string = "c"
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
    let v104 : string = "s"
    let v105 : string = $"{v104}"
    let v113 : unit = ()
    let v114 : (unit -> unit) = closure7(v5, v105)
    let v115 : unit = (fun () -> v114 (); v113) ()
    let v122 : string = $"{v46}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure7(v5, v122)
    let v132 : unit = (fun () -> v131 (); v130) ()
    (* run_target_args'
    let v142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v143 : string = "format!(\"{:#?}\", $0)"
    let v144 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1, v2, v3) v143 
    let v145 : string = "fable_library_rust::String_::fromString($0)"
    let v146 : string = Fable.Core.RustInterop.emitRustExpr v144 v145 
    let _run_target_args'_v142 = v146 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v147 : string = "format!(\"{:#?}\", $0)"
    let v148 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1, v2, v3) v147 
    let v149 : string = "fable_library_rust::String_::fromString($0)"
    let v150 : string = Fable.Core.RustInterop.emitRustExpr v148 v149 
    let _run_target_args'_v142 = v150 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v151 : string = "format!(\"{:#?}\", $0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1, v2, v3) v151 
    let v153 : string = "fable_library_rust::String_::fromString($0)"
    let v154 : string = Fable.Core.RustInterop.emitRustExpr v152 v153 
    let _run_target_args'_v142 = v154 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v156 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v142 = v156 
    #endif
#if FABLE_COMPILER_PYTHON
    let v160 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v142 = v160 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v164 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v142 = v164 
    #endif
#else
    let v168 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v142 = v168 
    #endif
    let v171 : string = _run_target_args'_v142 
    let v181 : string = $"{v171}"
    let v189 : unit = ()
    let v190 : (unit -> unit) = closure7(v5, v181)
    let v191 : unit = (fun () -> v190 (); v189) ()
    let v199 : string = " }"
    let v200 : string = $"{v199}"
    let v208 : unit = ()
    let v209 : (unit -> unit) = closure7(v5, v200)
    let v210 : unit = (fun () -> v209 (); v208) ()
    let v216 : string = v5.l0
    v216
and method26 (v0 : int64, v1 : string, v2 : int64) : UH0 =
    let v3 : bool = v2 < v0
    if v3 then
        let v4 : char = v1.[int v2]
        let v5 : int64 = v2 + 1L
        let v6 : UH0 = method26(v0, v1, v5)
        UH0_1(v4, v6)
    else
        UH0_0
and method27 (v0 : UH0, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : struct (System.Text.StringBuilder * int32 * int32) =
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
        let v26 : System.Text.StringBuilder =
            if v6 then
                let v11 : (unit -> System.Text.StringBuilder) = v1.Clear
                let v12 : System.Text.StringBuilder = v11 ()
                v1
            else
                let v17 : (char -> string) = _.ToString()
                let v18 : string = v17 v4
                let v22 : (string -> System.Text.StringBuilder) = v1.Append
                let v23 : System.Text.StringBuilder = v22 v18
                v1
        method27(v5, v26, v9, v10)
    | UH0_0 -> (* Nil *)
        struct (v1, v2, v3)
and method28 (v0 : char, v1 : int32, v2 : int32) : string =
    let v3 : string = method13()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure7(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "expected"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure7(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure7(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v66 : string = $"{v0}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure7(v4, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure7(v4, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "line"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure7(v4, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v45}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure7(v4, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v141 : string = $"{v1}"
    let v149 : unit = ()
    let v150 : (unit -> unit) = closure7(v4, v141)
    let v151 : unit = (fun () -> v150 (); v149) ()
    let v158 : string = $"{v84}"
    let v166 : unit = ()
    let v167 : (unit -> unit) = closure7(v4, v158)
    let v168 : unit = (fun () -> v167 (); v166) ()
    let v176 : string = "col"
    let v177 : string = $"{v176}"
    let v185 : unit = ()
    let v186 : (unit -> unit) = closure7(v4, v177)
    let v187 : unit = (fun () -> v186 (); v185) ()
    let v194 : string = $"{v45}"
    let v202 : unit = ()
    let v203 : (unit -> unit) = closure7(v4, v194)
    let v204 : unit = (fun () -> v203 (); v202) ()
    let v214 : string = $"{v2}"
    let v222 : unit = ()
    let v223 : (unit -> unit) = closure7(v4, v214)
    let v224 : unit = (fun () -> v223 (); v222) ()
    let v232 : string = " }"
    let v233 : string = $"{v232}"
    let v241 : unit = ()
    let v242 : (unit -> unit) = closure7(v4, v233)
    let v243 : unit = (fun () -> v242 (); v241) ()
    let v249 : string = v4.l0
    v249
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
and closure14 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    if v4 then
        let v5 : char = '"'
        let v6 : string = method25(v5, v1, v2, v3)
        let v9 : string = "parsing.p_char / unexpected end of input / "
        let v10 : string = v9 + v6 
        US8_1(v10)
    else
        let v14 : char = v0.[int 0]
        let v15 : bool = v14 = '"'
        if v15 then
            let v17 : (string -> int32) = String.length
            let v18 : int32 = v17 v0
            let v26 : int32 = 1 |> int32 
            let v39 : int32 = v18 |> int32 
            let v47 : int32 = v39 - 1
            let v49 : string = v0.[int v26..int v47]
            let v54 : (char -> string) = _.ToString()
            let v55 : string = v54 v14
            let v58 : int64 = System.Convert.ToInt64 v55.Length
            let v59 : int64 = 0L
            let v60 : UH0 = method26(v58, v55, v59)
            let struct (v61 : System.Text.StringBuilder, v62 : int32, v63 : int32) = method27(v60, v1, v2, v3)
            US8_0(v14, v49, v61, v62, v63)
        else
            let v68 : string = "\n"
            let v69 : int32 = v0.IndexOf v68 
            let v72 : int32 = v69 - 1
            let v73 : bool = -2 = v72
            let v81 : int32 =
                if v73 then
                    let v75 : (string -> int32) = String.length
                    let v76 : int32 = v75 v0
                    let v79 : int32 = v76 + 1
                    v79
                else
                    let v80 : int32 = v72 + 1
                    v80
            let v87 : int32 = 0 |> int32 
            let v100 : int32 = v81 |> int32 
            let v108 : int32 = v100 - 1
            let v110 : string = v0.[int v87..int v108]
            let v114 : char = '"'
            let v115 : string = method28(v114, v2, v3)
            let v118 : string = "parsing.p_char / "
            let v119 : string = v118 + v115 
            let v123 : string = v119 + v68 
            let v127 : (System.Text.StringBuilder -> string) = _.ToString()
            let v128 : string = v127 v1
            let v132 : string = v123 + v128 
            let v136 : string = v132 + v110 
            let v139 : int32 = v3 - 1
            let v140 : int32 = 0
            let v141 : (string -> string) = method29(v139, v140)
            let v142 : string = ""
            let v143 : string = v141 v142
            let v146 : string = "^"
            let v147 : string = v143 + v146 
            let v151 : string = v136 + v68 
            let v155 : string = v151 + v147 
            let v159 : string = v155 + v68 
            US8_1(v159)
and closure16 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    if v4 then
        let v5 : char = '''
        let v6 : string = method25(v5, v1, v2, v3)
        let v9 : string = "parsing.p_char / unexpected end of input / "
        let v10 : string = v9 + v6 
        US8_1(v10)
    else
        let v14 : char = v0.[int 0]
        let v15 : bool = v14 = '''
        if v15 then
            let v17 : (string -> int32) = String.length
            let v18 : int32 = v17 v0
            let v26 : int32 = 1 |> int32 
            let v39 : int32 = v18 |> int32 
            let v47 : int32 = v39 - 1
            let v49 : string = v0.[int v26..int v47]
            let v54 : (char -> string) = _.ToString()
            let v55 : string = v54 v14
            let v58 : int64 = System.Convert.ToInt64 v55.Length
            let v59 : int64 = 0L
            let v60 : UH0 = method26(v58, v55, v59)
            let struct (v61 : System.Text.StringBuilder, v62 : int32, v63 : int32) = method27(v60, v1, v2, v3)
            US8_0(v14, v49, v61, v62, v63)
        else
            let v68 : string = "\n"
            let v69 : int32 = v0.IndexOf v68 
            let v72 : int32 = v69 - 1
            let v73 : bool = -2 = v72
            let v81 : int32 =
                if v73 then
                    let v75 : (string -> int32) = String.length
                    let v76 : int32 = v75 v0
                    let v79 : int32 = v76 + 1
                    v79
                else
                    let v80 : int32 = v72 + 1
                    v80
            let v87 : int32 = 0 |> int32 
            let v100 : int32 = v81 |> int32 
            let v108 : int32 = v100 - 1
            let v110 : string = v0.[int v87..int v108]
            let v114 : char = '''
            let v115 : string = method28(v114, v2, v3)
            let v118 : string = "parsing.p_char / "
            let v119 : string = v118 + v115 
            let v123 : string = v119 + v68 
            let v127 : (System.Text.StringBuilder -> string) = _.ToString()
            let v128 : string = v127 v1
            let v132 : string = v123 + v128 
            let v136 : string = v132 + v110 
            let v139 : int32 = v3 - 1
            let v140 : int32 = 0
            let v141 : (string -> string) = method29(v139, v140)
            let v142 : string = ""
            let v143 : string = v141 v142
            let v146 : string = "^"
            let v147 : string = v143 + v146 
            let v151 : string = v136 + v68 
            let v155 : string = v151 + v147 
            let v159 : string = v155 + v68 
            US8_1(v159)
and method30 (v0 : string, v1 : System.Text.StringBuilder, v2 : UH1) : US8 =
    match v2 with
    | UH1_1(v5, v6) -> (* Cons *)
        let v7 : US8 = v5 struct (v0, v1, 1, 1)
        match v7 with
        | US8_1(v13) -> (* Error *)
            method30(v0, v1, v6)
        | US8_0(v8, v9, v10, v11, v12) -> (* Ok *)
            v7
    | UH1_0 -> (* Nil *)
        let v3 : string = "parsing.choice / no parsers succeeded"
        US8_1(v3)
and method31 (v0 : (char []), v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : string =
    let v4 : string = method13()
    let v5 : Mut3 = {l0 = v4} : Mut3
    let v8 : string = "{ "
    let v9 : string = $"{v8}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure7(v5, v9)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v27 : string = "chars"
    let v28 : string = $"{v27}"
    let v36 : unit = ()
    let v37 : (unit -> unit) = closure7(v5, v28)
    let v38 : unit = (fun () -> v37 (); v36) ()
    let v46 : string = " = "
    let v47 : string = $"{v46}"
    let v55 : unit = ()
    let v56 : (unit -> unit) = closure7(v5, v47)
    let v57 : unit = (fun () -> v56 (); v55) ()
    let v64 : string = $"%A{v0}"
    let v68 : string = $"{v64}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure7(v5, v68)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v86 : string = "; "
    let v87 : string = $"{v86}"
    let v95 : unit = ()
    let v96 : (unit -> unit) = closure7(v5, v87)
    let v97 : unit = (fun () -> v96 (); v95) ()
    let v105 : string = "s"
    let v106 : string = $"{v105}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure7(v5, v106)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v123 : string = $"{v46}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure7(v5, v123)
    let v133 : unit = (fun () -> v132 (); v131) ()
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "format!(\"{:#?}\", $0)"
    let v145 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1, v2, v3) v144 
    let v146 : string = "fable_library_rust::String_::fromString($0)"
    let v147 : string = Fable.Core.RustInterop.emitRustExpr v145 v146 
    let _run_target_args'_v143 = v147 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v148 : string = "format!(\"{:#?}\", $0)"
    let v149 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1, v2, v3) v148 
    let v150 : string = "fable_library_rust::String_::fromString($0)"
    let v151 : string = Fable.Core.RustInterop.emitRustExpr v149 v150 
    let _run_target_args'_v143 = v151 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v152 : string = "format!(\"{:#?}\", $0)"
    let v153 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1, v2, v3) v152 
    let v154 : string = "fable_library_rust::String_::fromString($0)"
    let v155 : string = Fable.Core.RustInterop.emitRustExpr v153 v154 
    let _run_target_args'_v143 = v155 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v157 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v143 = v157 
    #endif
#if FABLE_COMPILER_PYTHON
    let v161 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v143 = v161 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v165 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v143 = v165 
    #endif
#else
    let v169 : string = $"%A{struct (v1, v2, v3)}"
    let _run_target_args'_v143 = v169 
    #endif
    let v172 : string = _run_target_args'_v143 
    let v182 : string = $"{v172}"
    let v190 : unit = ()
    let v191 : (unit -> unit) = closure7(v5, v182)
    let v192 : unit = (fun () -> v191 (); v190) ()
    let v200 : string = " }"
    let v201 : string = $"{v200}"
    let v209 : unit = ()
    let v210 : (unit -> unit) = closure7(v5, v201)
    let v211 : unit = (fun () -> v210 (); v209) ()
    let v217 : string = v5.l0
    v217
and method32 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 2L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v11 : US10 =
            if v3 then
                US10_0('"')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US10_0(''')
                else
                    let v8 : int64 = v5 - 1L
                    US10_1
        let v15 : char =
            match v11 with
            | US10_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US10_0(v12) -> (* Some *)
                v12
        let v16 : bool = v0 = v15
        if v16 then
            true
        else
            let v17 : int64 = v1 + 1L
            method32(v0, v17)
and method33 (v0 : char, v1 : (char []), v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : string =
    let v5 : string = method13()
    let v6 : Mut3 = {l0 = v5} : Mut3
    let v9 : string = "{ "
    let v10 : string = $"{v9}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure7(v6, v10)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v28 : string = "first_char"
    let v29 : string = $"{v28}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure7(v6, v29)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v47 : string = " = "
    let v48 : string = $"{v47}"
    let v56 : unit = ()
    let v57 : (unit -> unit) = closure7(v6, v48)
    let v58 : unit = (fun () -> v57 (); v56) ()
    let v68 : string = $"{v0}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure7(v6, v68)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v86 : string = "; "
    let v87 : string = $"{v86}"
    let v95 : unit = ()
    let v96 : (unit -> unit) = closure7(v6, v87)
    let v97 : unit = (fun () -> v96 (); v95) ()
    let v105 : string = "chars"
    let v106 : string = $"{v105}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure7(v6, v106)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v123 : string = $"{v47}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure7(v6, v123)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v140 : string = $"%A{v1}"
    let v144 : string = $"{v140}"
    let v152 : unit = ()
    let v153 : (unit -> unit) = closure7(v6, v144)
    let v154 : unit = (fun () -> v153 (); v152) ()
    let v161 : string = $"{v86}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure7(v6, v161)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v179 : string = "s"
    let v180 : string = $"{v179}"
    let v188 : unit = ()
    let v189 : (unit -> unit) = closure7(v6, v180)
    let v190 : unit = (fun () -> v189 (); v188) ()
    let v197 : string = $"{v47}"
    let v205 : unit = ()
    let v206 : (unit -> unit) = closure7(v6, v197)
    let v207 : unit = (fun () -> v206 (); v205) ()
    (* run_target_args'
    let v217 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v218 : string = "format!(\"{:#?}\", $0)"
    let v219 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v2, v3, v4) v218 
    let v220 : string = "fable_library_rust::String_::fromString($0)"
    let v221 : string = Fable.Core.RustInterop.emitRustExpr v219 v220 
    let _run_target_args'_v217 = v221 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v222 : string = "format!(\"{:#?}\", $0)"
    let v223 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v2, v3, v4) v222 
    let v224 : string = "fable_library_rust::String_::fromString($0)"
    let v225 : string = Fable.Core.RustInterop.emitRustExpr v223 v224 
    let _run_target_args'_v217 = v225 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v226 : string = "format!(\"{:#?}\", $0)"
    let v227 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v2, v3, v4) v226 
    let v228 : string = "fable_library_rust::String_::fromString($0)"
    let v229 : string = Fable.Core.RustInterop.emitRustExpr v227 v228 
    let _run_target_args'_v217 = v229 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v231 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v217 = v231 
    #endif
#if FABLE_COMPILER_PYTHON
    let v235 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v217 = v235 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v239 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v217 = v239 
    #endif
#else
    let v243 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v217 = v243 
    #endif
    let v246 : string = _run_target_args'_v217 
    let v256 : string = $"{v246}"
    let v264 : unit = ()
    let v265 : (unit -> unit) = closure7(v6, v256)
    let v266 : unit = (fun () -> v265 (); v264) ()
    let v274 : string = " }"
    let v275 : string = $"{v274}"
    let v283 : unit = ()
    let v284 : (unit -> unit) = closure7(v6, v275)
    let v285 : unit = (fun () -> v284 (); v283) ()
    let v291 : string = v6.l0
    v291
and method34 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v104 : US8 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ''' :: v6 
            let v12 : char list = '"' :: v8 
            let v16 : (char list -> (char [])) = List.toArray
            let v17 : (char []) = v16 v12
            let v20 : string = method31(v17, v2, v3, v4)
            let v23 : string = "parsing.none_of / unexpected end of input / "
            let v24 : string = v23 + v20 
            US8_1(v24)
        else
            let v28 : char = v1.[int 0]
            let v29 : int64 = 0L
            let v30 : bool = method32(v28, v29)
            let v31 : bool = v30 = false
            if v31 then
                let v33 : (string -> int32) = String.length
                let v34 : int32 = v33 v1
                let v42 : int32 = 1 |> int32 
                let v55 : int32 = v34 |> int32 
                let v63 : int32 = v55 - 1
                let v65 : string = v1.[int v42..int v63]
                let v70 : (char -> string) = _.ToString()
                let v71 : string = v70 v28
                let v74 : int64 = System.Convert.ToInt64 v71.Length
                let v75 : int64 = 0L
                let v76 : UH0 = method26(v74, v71, v75)
                let struct (v77 : System.Text.StringBuilder, v78 : int32, v79 : int32) = method27(v76, v2, v3, v4)
                US8_0(v28, v65, v77, v78, v79)
            else
                let v81 : char list = []
                let v83 : char list = ''' :: v81 
                let v87 : char list = '"' :: v83 
                let v91 : (char list -> (char [])) = List.toArray
                let v92 : (char []) = v91 v87
                let v95 : string = method33(v28, v92, v2, v3, v4)
                let v98 : string = "parsing.none_of / unexpected char / "
                let v99 : string = v98 + v95 
                US8_1(v99)
    let v116 : US8 =
        match v104 with
        | US8_1(v113) -> (* Error *)
            US8_1(v113)
        | US8_0(v105, v106, v107, v108, v109) -> (* Ok *)
            let v110 : bool = '\\' = v105
            let v111 : char =
                if v110 then
                    '/'
                else
                    v105
            US8_0(v111, v106, v107, v108, v109)
    match v116 with
    | US8_1(v133) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US8_0(v117, v118, v119, v120, v121) -> (* Ok *)
        let v123 : (char -> string) = _.ToString()
        let v124 : string = v123 v117
        let v127 : string = v0 + v124 
        method34(v127, v118, v119, v120, v121)
and method35 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH1) : US8 =
    match v4 with
    | UH1_1(v7, v8) -> (* Cons *)
        let v9 : US8 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US8_1(v15) -> (* Error *)
            method35(v0, v1, v2, v3, v8)
        | US8_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH1_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US8_1(v5)
and method36 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32, v5 : string, v6 : System.Text.StringBuilder, v7 : int32, v8 : int32, v9 : string, v10 : System.Text.StringBuilder, v11 : int32, v12 : int32) : string =
    let v13 : string = method13()
    let v14 : Mut3 = {l0 = v13} : Mut3
    let v17 : string = "{ "
    let v18 : string = $"{v17}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure7(v14, v18)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v36 : string = "e"
    let v37 : string = $"{v36}"
    let v45 : unit = ()
    let v46 : (unit -> unit) = closure7(v14, v37)
    let v47 : unit = (fun () -> v46 (); v45) ()
    let v55 : string = " = "
    let v56 : string = $"{v55}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure7(v14, v56)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v73 : string = $"{v0}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure7(v14, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure7(v14, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "input"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure7(v14, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v55}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure7(v14, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    let v145 : string = $"{v1}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure7(v14, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v163 : string = ", "
    let v164 : string = $"{v163}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure7(v14, v164)
    let v174 : unit = (fun () -> v173 (); v172) ()
    (* run_target_args'
    let v184 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v185 : string = "format!(\"{:#?}\", $0)"
    let v186 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v2, v3, v4) v185 
    let v187 : string = "fable_library_rust::String_::fromString($0)"
    let v188 : string = Fable.Core.RustInterop.emitRustExpr v186 v187 
    let _run_target_args'_v184 = v188 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v189 : string = "format!(\"{:#?}\", $0)"
    let v190 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v2, v3, v4) v189 
    let v191 : string = "fable_library_rust::String_::fromString($0)"
    let v192 : string = Fable.Core.RustInterop.emitRustExpr v190 v191 
    let _run_target_args'_v184 = v192 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v193 : string = "format!(\"{:#?}\", $0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v2, v3, v4) v193 
    let v195 : string = "fable_library_rust::String_::fromString($0)"
    let v196 : string = Fable.Core.RustInterop.emitRustExpr v194 v195 
    let _run_target_args'_v184 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v184 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v184 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v184 = v206 
    #endif
#else
    let v210 : string = $"%A{struct (v2, v3, v4)}"
    let _run_target_args'_v184 = v210 
    #endif
    let v213 : string = _run_target_args'_v184 
    let v223 : string = $"{v213}"
    let v231 : unit = ()
    let v232 : (unit -> unit) = closure7(v14, v223)
    let v233 : unit = (fun () -> v232 (); v231) ()
    let v240 : string = $"{v91}"
    let v248 : unit = ()
    let v249 : (unit -> unit) = closure7(v14, v240)
    let v250 : unit = (fun () -> v249 (); v248) ()
    let v258 : string = "rest1"
    let v259 : string = $"{v258}"
    let v267 : unit = ()
    let v268 : (unit -> unit) = closure7(v14, v259)
    let v269 : unit = (fun () -> v268 (); v267) ()
    let v276 : string = $"{v55}"
    let v284 : unit = ()
    let v285 : (unit -> unit) = closure7(v14, v276)
    let v286 : unit = (fun () -> v285 (); v284) ()
    let v293 : string = $"{v5}"
    let v301 : unit = ()
    let v302 : (unit -> unit) = closure7(v14, v293)
    let v303 : unit = (fun () -> v302 (); v301) ()
    let v310 : string = $"{v163}"
    let v318 : unit = ()
    let v319 : (unit -> unit) = closure7(v14, v310)
    let v320 : unit = (fun () -> v319 (); v318) ()
    (* run_target_args'
    let v330 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v331 : string = "format!(\"{:#?}\", $0)"
    let v332 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v6, v7, v8) v331 
    let v333 : string = "fable_library_rust::String_::fromString($0)"
    let v334 : string = Fable.Core.RustInterop.emitRustExpr v332 v333 
    let _run_target_args'_v330 = v334 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v335 : string = "format!(\"{:#?}\", $0)"
    let v336 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v6, v7, v8) v335 
    let v337 : string = "fable_library_rust::String_::fromString($0)"
    let v338 : string = Fable.Core.RustInterop.emitRustExpr v336 v337 
    let _run_target_args'_v330 = v338 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v339 : string = "format!(\"{:#?}\", $0)"
    let v340 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v6, v7, v8) v339 
    let v341 : string = "fable_library_rust::String_::fromString($0)"
    let v342 : string = Fable.Core.RustInterop.emitRustExpr v340 v341 
    let _run_target_args'_v330 = v342 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v344 : string = $"%A{struct (v6, v7, v8)}"
    let _run_target_args'_v330 = v344 
    #endif
#if FABLE_COMPILER_PYTHON
    let v348 : string = $"%A{struct (v6, v7, v8)}"
    let _run_target_args'_v330 = v348 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v352 : string = $"%A{struct (v6, v7, v8)}"
    let _run_target_args'_v330 = v352 
    #endif
#else
    let v356 : string = $"%A{struct (v6, v7, v8)}"
    let _run_target_args'_v330 = v356 
    #endif
    let v359 : string = _run_target_args'_v330 
    let v369 : string = $"{v359}"
    let v377 : unit = ()
    let v378 : (unit -> unit) = closure7(v14, v369)
    let v379 : unit = (fun () -> v378 (); v377) ()
    let v386 : string = $"{v91}"
    let v394 : unit = ()
    let v395 : (unit -> unit) = closure7(v14, v386)
    let v396 : unit = (fun () -> v395 (); v394) ()
    let v404 : string = "rest2"
    let v405 : string = $"{v404}"
    let v413 : unit = ()
    let v414 : (unit -> unit) = closure7(v14, v405)
    let v415 : unit = (fun () -> v414 (); v413) ()
    let v422 : string = $"{v55}"
    let v430 : unit = ()
    let v431 : (unit -> unit) = closure7(v14, v422)
    let v432 : unit = (fun () -> v431 (); v430) ()
    let v439 : string = $"{v9}"
    let v447 : unit = ()
    let v448 : (unit -> unit) = closure7(v14, v439)
    let v449 : unit = (fun () -> v448 (); v447) ()
    let v456 : string = $"{v163}"
    let v464 : unit = ()
    let v465 : (unit -> unit) = closure7(v14, v456)
    let v466 : unit = (fun () -> v465 (); v464) ()
    (* run_target_args'
    let v476 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v477 : string = "format!(\"{:#?}\", $0)"
    let v478 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v10, v11, v12) v477 
    let v479 : string = "fable_library_rust::String_::fromString($0)"
    let v480 : string = Fable.Core.RustInterop.emitRustExpr v478 v479 
    let _run_target_args'_v476 = v480 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v481 : string = "format!(\"{:#?}\", $0)"
    let v482 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v10, v11, v12) v481 
    let v483 : string = "fable_library_rust::String_::fromString($0)"
    let v484 : string = Fable.Core.RustInterop.emitRustExpr v482 v483 
    let _run_target_args'_v476 = v484 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v485 : string = "format!(\"{:#?}\", $0)"
    let v486 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v10, v11, v12) v485 
    let v487 : string = "fable_library_rust::String_::fromString($0)"
    let v488 : string = Fable.Core.RustInterop.emitRustExpr v486 v487 
    let _run_target_args'_v476 = v488 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v490 : string = $"%A{struct (v10, v11, v12)}"
    let _run_target_args'_v476 = v490 
    #endif
#if FABLE_COMPILER_PYTHON
    let v494 : string = $"%A{struct (v10, v11, v12)}"
    let _run_target_args'_v476 = v494 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v498 : string = $"%A{struct (v10, v11, v12)}"
    let _run_target_args'_v476 = v498 
    #endif
#else
    let v502 : string = $"%A{struct (v10, v11, v12)}"
    let _run_target_args'_v476 = v502 
    #endif
    let v505 : string = _run_target_args'_v476 
    let v515 : string = $"{v505}"
    let v523 : unit = ()
    let v524 : (unit -> unit) = closure7(v14, v515)
    let v525 : unit = (fun () -> v524 (); v523) ()
    let v533 : string = " }"
    let v534 : string = $"{v533}"
    let v542 : unit = ()
    let v543 : (unit -> unit) = closure7(v14, v534)
    let v544 : unit = (fun () -> v543 (); v542) ()
    let v550 : string = v14.l0
    v550
and method37 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 3L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v15 : US10 =
            if v3 then
                US10_0('"')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US10_0(''')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US10_0(' ')
                    else
                        let v11 : int64 = v8 - 1L
                        US10_1
        let v19 : char =
            match v15 with
            | US10_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US10_0(v16) -> (* Some *)
                v16
        let v20 : bool = v0 = v19
        if v20 then
            true
        else
            let v21 : int64 = v1 + 1L
            method37(v0, v21)
and method38 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v112 : US8 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ' ' :: v6 
            let v12 : char list = ''' :: v8 
            let v16 : char list = '"' :: v12 
            let v20 : (char list -> (char [])) = List.toArray
            let v21 : (char []) = v20 v16
            let v24 : string = method31(v21, v2, v3, v4)
            let v27 : string = "parsing.none_of / unexpected end of input / "
            let v28 : string = v27 + v24 
            US8_1(v28)
        else
            let v32 : char = v1.[int 0]
            let v33 : int64 = 0L
            let v34 : bool = method37(v32, v33)
            let v35 : bool = v34 = false
            if v35 then
                let v37 : (string -> int32) = String.length
                let v38 : int32 = v37 v1
                let v46 : int32 = 1 |> int32 
                let v59 : int32 = v38 |> int32 
                let v67 : int32 = v59 - 1
                let v69 : string = v1.[int v46..int v67]
                let v74 : (char -> string) = _.ToString()
                let v75 : string = v74 v32
                let v78 : int64 = System.Convert.ToInt64 v75.Length
                let v79 : int64 = 0L
                let v80 : UH0 = method26(v78, v75, v79)
                let struct (v81 : System.Text.StringBuilder, v82 : int32, v83 : int32) = method27(v80, v2, v3, v4)
                US8_0(v32, v69, v81, v82, v83)
            else
                let v85 : char list = []
                let v87 : char list = ' ' :: v85 
                let v91 : char list = ''' :: v87 
                let v95 : char list = '"' :: v91 
                let v99 : (char list -> (char [])) = List.toArray
                let v100 : (char []) = v99 v95
                let v103 : string = method33(v32, v100, v2, v3, v4)
                let v106 : string = "parsing.none_of / unexpected char / "
                let v107 : string = v106 + v103 
                US8_1(v107)
    let v124 : US8 =
        match v112 with
        | US8_1(v121) -> (* Error *)
            US8_1(v121)
        | US8_0(v113, v114, v115, v116, v117) -> (* Ok *)
            let v118 : bool = '\\' = v113
            let v119 : char =
                if v118 then
                    '/'
                else
                    v113
            US8_0(v119, v114, v115, v116, v117)
    match v124 with
    | US8_1(v141) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US8_0(v125, v126, v127, v128, v129) -> (* Ok *)
        let v131 : (char -> string) = _.ToString()
        let v132 : string = v131 v125
        let v135 : string = v0 + v132 
        method38(v135, v126, v127, v128, v129)
and method39 (v0 : string) : string =
    let v1 : string = method13()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure7(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "input"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure7(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure7(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v61 : string = $"{v0}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure7(v2, v61)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v79 : string = " }"
    let v80 : string = $"{v79}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure7(v2, v80)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v96 : string = v2.l0
    v96
and method40 (v0 : string, v1 : int32) : int32 =
    let v2 : int32 = v0.Length
    let v3 : bool = v1 >= v2
    if v3 then
        v1
    else
        let v4 : char = v0.[int v1]
        let v5 : bool = ' ' = v4
        if v5 then
            let v6 : int32 = v1 + 1
            method40(v0, v6)
        else
            v1
and method41 (v0 : System.Text.StringBuilder, v1 : int32, v2 : int32) : string =
    let v3 : string = method13()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure7(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "s"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure7(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure7(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    (* run_target_args'
    let v66 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v67 : string = "format!(\"{:#?}\", $0)"
    let v68 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v0, v1, v2) v67 
    let v69 : string = "fable_library_rust::String_::fromString($0)"
    let v70 : string = Fable.Core.RustInterop.emitRustExpr v68 v69 
    let _run_target_args'_v66 = v70 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v71 : string = "format!(\"{:#?}\", $0)"
    let v72 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v0, v1, v2) v71 
    let v73 : string = "fable_library_rust::String_::fromString($0)"
    let v74 : string = Fable.Core.RustInterop.emitRustExpr v72 v73 
    let _run_target_args'_v66 = v74 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v75 : string = "format!(\"{:#?}\", $0)"
    let v76 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v0, v1, v2) v75 
    let v77 : string = "fable_library_rust::String_::fromString($0)"
    let v78 : string = Fable.Core.RustInterop.emitRustExpr v76 v77 
    let _run_target_args'_v66 = v78 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v80 : string = $"%A{struct (v0, v1, v2)}"
    let _run_target_args'_v66 = v80 
    #endif
#if FABLE_COMPILER_PYTHON
    let v84 : string = $"%A{struct (v0, v1, v2)}"
    let _run_target_args'_v66 = v84 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v88 : string = $"%A{struct (v0, v1, v2)}"
    let _run_target_args'_v66 = v88 
    #endif
#else
    let v92 : string = $"%A{struct (v0, v1, v2)}"
    let _run_target_args'_v66 = v92 
    #endif
    let v95 : string = _run_target_args'_v66 
    let v105 : string = $"{v95}"
    let v113 : unit = ()
    let v114 : (unit -> unit) = closure7(v4, v105)
    let v115 : unit = (fun () -> v114 (); v113) ()
    let v123 : string = " }"
    let v124 : string = $"{v123}"
    let v132 : unit = ()
    let v133 : (unit -> unit) = closure7(v4, v124)
    let v134 : unit = (fun () -> v133 (); v132) ()
    let v140 : string = v4.l0
    v140
and method42 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v64 : US8 =
        if v5 then
            let v6 : string = method41(v2, v3, v4)
            let v9 : string = "parsing.any_char / unexpected end of input / "
            let v10 : string = v9 + v6 
            US8_1(v10)
        else
            let v14 : char = v1.[int 0]
            let v16 : (string -> int32) = String.length
            let v17 : int32 = v16 v1
            let v25 : int32 = 1 |> int32 
            let v38 : int32 = v17 |> int32 
            let v46 : int32 = v38 - 1
            let v48 : string = v1.[int v25..int v46]
            let v53 : (char -> string) = _.ToString()
            let v54 : string = v53 v14
            let v57 : int64 = System.Convert.ToInt64 v54.Length
            let v58 : int64 = 0L
            let v59 : UH0 = method26(v57, v54, v58)
            let struct (v60 : System.Text.StringBuilder, v61 : int32, v62 : int32) = method27(v59, v2, v3, v4)
            US8_0(v14, v48, v60, v61, v62)
    match v64 with
    | US8_1(v81) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US8_0(v65, v66, v67, v68, v69) -> (* Ok *)
        let v71 : (char -> string) = _.ToString()
        let v72 : string = v71 v65
        let v75 : string = v0 + v72 
        method42(v75, v66, v67, v68, v69)
and method23 (v0 : string) : US7 =
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
    let v19 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure14()
    let v20 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure16()
    let v21 : UH1 = UH1_0
    let v22 : UH1 = UH1_1(v20, v21)
    let v23 : UH1 = UH1_1(v19, v22)
    let v24 : US8 = method30(v10, v16, v23)
    let v208 : US9 =
        match v24 with
        | US8_1(v205) -> (* Error *)
            US9_1(v205)
        | US8_0(v25, v26, v27, v28, v29) -> (* Ok *)
            let v30 : bool = "" = v26
            let v129 : US8 =
                if v30 then
                    let v31 : char list = []
                    let v33 : char list = ''' :: v31 
                    let v37 : char list = '"' :: v33 
                    let v41 : (char list -> (char [])) = List.toArray
                    let v42 : (char []) = v41 v37
                    let v45 : string = method31(v42, v27, v28, v29)
                    let v48 : string = "parsing.none_of / unexpected end of input / "
                    let v49 : string = v48 + v45 
                    US8_1(v49)
                else
                    let v53 : char = v26.[int 0]
                    let v54 : int64 = 0L
                    let v55 : bool = method32(v53, v54)
                    let v56 : bool = v55 = false
                    if v56 then
                        let v58 : (string -> int32) = String.length
                        let v59 : int32 = v58 v26
                        let v67 : int32 = 1 |> int32 
                        let v80 : int32 = v59 |> int32 
                        let v88 : int32 = v80 - 1
                        let v90 : string = v26.[int v67..int v88]
                        let v95 : (char -> string) = _.ToString()
                        let v96 : string = v95 v53
                        let v99 : int64 = System.Convert.ToInt64 v96.Length
                        let v100 : int64 = 0L
                        let v101 : UH0 = method26(v99, v96, v100)
                        let struct (v102 : System.Text.StringBuilder, v103 : int32, v104 : int32) = method27(v101, v27, v28, v29)
                        US8_0(v53, v90, v102, v103, v104)
                    else
                        let v106 : char list = []
                        let v108 : char list = ''' :: v106 
                        let v112 : char list = '"' :: v108 
                        let v116 : (char list -> (char [])) = List.toArray
                        let v117 : (char []) = v116 v112
                        let v120 : string = method33(v53, v117, v27, v28, v29)
                        let v123 : string = "parsing.none_of / unexpected char / "
                        let v124 : string = v123 + v120 
                        US8_1(v124)
            let v141 : US8 =
                match v129 with
                | US8_1(v138) -> (* Error *)
                    US8_1(v138)
                | US8_0(v130, v131, v132, v133, v134) -> (* Ok *)
                    let v135 : bool = '\\' = v130
                    let v136 : char =
                        if v135 then
                            '/'
                        else
                            v130
                    US8_0(v136, v131, v132, v133, v134)
            let v161 : US9 =
                match v141 with
                | US8_1(v158) -> (* Error *)
                    US9_1(v158)
                | US8_0(v142, v143, v144, v145, v146) -> (* Ok *)
                    let v148 : (char -> string) = _.ToString()
                    let v149 : string = v148 v142
                    let struct (v152 : string, v153 : string, v154 : System.Text.StringBuilder, v155 : int32, v156 : int32) = method34(v149, v143, v144, v145, v146)
                    US9_0(v152, v153, v154, v155, v156)
            let v171 : US9 =
                match v161 with
                | US9_1(v168) -> (* Error *)
                    US9_0(v9, v26, v27, v28, v29)
                | US9_0(v162, v163, v164, v165, v166) -> (* Ok *)
                    US9_0(v162, v163, v164, v165, v166)
            match v171 with
            | US9_1(v200) -> (* Error *)
                let v201 : string = "parsing.between / expected content"
                US9_1(v201)
            | US9_0(v172, v173, v174, v175, v176) -> (* Ok *)
                let v177 : UH1 = UH1_0
                let v178 : UH1 = UH1_1(v20, v177)
                let v179 : UH1 = UH1_1(v19, v178)
                let v180 : US8 = method35(v173, v174, v175, v176, v179)
                match v180 with
                | US8_1(v187) -> (* Error *)
                    let v188 : int32 = 1
                    let v189 : int32 = 1
                    let v190 : string = method36(v187, v10, v16, v188, v189, v26, v27, v28, v29, v173, v174, v175, v176)
                    let v193 : string = "parsing.between / expected closing delimiter / "
                    let v194 : string = v193 + v190 
                    US9_1(v194)
                | US8_0(v181, v182, v183, v184, v185) -> (* Ok *)
                    US9_0(v172, v182, v183, v184, v185)
    let v440 : US9 =
        match v208 with
        | US9_1(v214) -> (* Error *)
            let v215 : bool = "" = v10
            let v328 : US8 =
                if v215 then
                    let v216 : char list = []
                    let v218 : char list = ' ' :: v216 
                    let v222 : char list = ''' :: v218 
                    let v226 : char list = '"' :: v222 
                    let v230 : (char list -> (char [])) = List.toArray
                    let v231 : (char []) = v230 v226
                    let v234 : int32 = 1
                    let v235 : int32 = 1
                    let v236 : string = method31(v231, v16, v234, v235)
                    let v239 : string = "parsing.none_of / unexpected end of input / "
                    let v240 : string = v239 + v236 
                    US8_1(v240)
                else
                    let v244 : char = v10.[int 0]
                    let v245 : int64 = 0L
                    let v246 : bool = method37(v244, v245)
                    let v247 : bool = v246 = false
                    if v247 then
                        let v249 : (string -> int32) = String.length
                        let v250 : int32 = v249 v10
                        let v258 : int32 = 1 |> int32 
                        let v271 : int32 = v250 |> int32 
                        let v279 : int32 = v271 - 1
                        let v281 : string = v10.[int v258..int v279]
                        let v286 : (char -> string) = _.ToString()
                        let v287 : string = v286 v244
                        let v290 : int64 = System.Convert.ToInt64 v287.Length
                        let v291 : int64 = 0L
                        let v292 : UH0 = method26(v290, v287, v291)
                        let v293 : int32 = 1
                        let v294 : int32 = 1
                        let struct (v295 : System.Text.StringBuilder, v296 : int32, v297 : int32) = method27(v292, v16, v293, v294)
                        US8_0(v244, v281, v295, v296, v297)
                    else
                        let v299 : char list = []
                        let v301 : char list = ' ' :: v299 
                        let v305 : char list = ''' :: v301 
                        let v309 : char list = '"' :: v305 
                        let v313 : (char list -> (char [])) = List.toArray
                        let v314 : (char []) = v313 v309
                        let v317 : int32 = 1
                        let v318 : int32 = 1
                        let v319 : string = method33(v244, v314, v16, v317, v318)
                        let v322 : string = "parsing.none_of / unexpected char / "
                        let v323 : string = v322 + v319 
                        US8_1(v323)
            let v340 : US8 =
                match v328 with
                | US8_1(v337) -> (* Error *)
                    US8_1(v337)
                | US8_0(v329, v330, v331, v332, v333) -> (* Ok *)
                    let v334 : bool = '\\' = v329
                    let v335 : char =
                        if v334 then
                            '/'
                        else
                            v329
                    US8_0(v335, v330, v331, v332, v333)
            let v360 : US9 =
                match v340 with
                | US8_1(v357) -> (* Error *)
                    US9_1(v357)
                | US8_0(v341, v342, v343, v344, v345) -> (* Ok *)
                    let v347 : (char -> string) = _.ToString()
                    let v348 : string = v347 v341
                    let struct (v351 : string, v352 : string, v353 : System.Text.StringBuilder, v354 : int32, v355 : int32) = method38(v348, v342, v343, v344, v345)
                    US9_0(v351, v352, v353, v354, v355)
            match v360 with
            | US9_1(v366) -> (* Error *)
                let v367 : int32 = v10.Length
                let v368 : bool = v367 = 0
                let v378 : US11 =
                    if v368 then
                        US11_0(v10, v16, 1, 1)
                    else
                        let v370 : string = method39(v10)
                        let v373 : string = "parsing.eof / expected end of input / "
                        let v374 : string = v373 + v370 
                        US11_1(v374)
                let v387 : US9 =
                    match v378 with
                    | US11_1(v384) -> (* Error *)
                        US9_1(v384)
                    | US11_0(v379, v380, v381, v382) -> (* Ok *)
                        US9_0(v9, v379, v380, v381, v382)
                match v387 with
                | US9_1(v433) -> (* Error *)
                    US9_1(v433)
                | US9_0(v388, v389, v390, v391, v392) -> (* Ok *)
                    let v393 : int32 = 0
                    let v394 : int32 = method40(v389, v393)
                    let v396 : (string -> int32) = String.length
                    let v397 : int32 = v396 v389
                    let v405 : int32 = v394 |> int32 
                    let v418 : int32 = v397 |> int32 
                    let v426 : int32 = v418 - 1
                    let v428 : string = v389.[int v405..int v426]
                    US9_0(v388, v428, v390, v391, v392)
            | US9_0(v361, v362, v363, v364, v365) -> (* Ok *)
                v360
        | US9_0(v209, v210, v211, v212, v213) -> (* Ok *)
            v208
    let v732 : US12 =
        match v440 with
        | US9_1(v729) -> (* Error *)
            US12_1(v729)
        | US9_0(v441, v442, v443, v444, v445) -> (* Ok *)
            let v446 : bool = "" = v442
            let v605 : US8 =
                if v446 then
                    let v447 : char = ' '
                    let v448 : string = method25(v447, v443, v444, v445)
                    let v451 : string = "parsing.p_char / unexpected end of input / "
                    let v452 : string = v451 + v448 
                    US8_1(v452)
                else
                    let v456 : char = v442.[int 0]
                    let v457 : bool = v456 = ' '
                    if v457 then
                        let v459 : (string -> int32) = String.length
                        let v460 : int32 = v459 v442
                        let v468 : int32 = 1 |> int32 
                        let v481 : int32 = v460 |> int32 
                        let v489 : int32 = v481 - 1
                        let v491 : string = v442.[int v468..int v489]
                        let v496 : (char -> string) = _.ToString()
                        let v497 : string = v496 v456
                        let v500 : int64 = System.Convert.ToInt64 v497.Length
                        let v501 : int64 = 0L
                        let v502 : UH0 = method26(v500, v497, v501)
                        let struct (v503 : System.Text.StringBuilder, v504 : int32, v505 : int32) = method27(v502, v443, v444, v445)
                        US8_0(v456, v491, v503, v504, v505)
                    else
                        let v510 : string = "\n"
                        let v511 : int32 = v442.IndexOf v510 
                        let v514 : int32 = v511 - 1
                        let v515 : bool = -2 = v514
                        let v523 : int32 =
                            if v515 then
                                let v517 : (string -> int32) = String.length
                                let v518 : int32 = v517 v442
                                let v521 : int32 = v518 + 1
                                v521
                            else
                                let v522 : int32 = v514 + 1
                                v522
                        let v529 : int32 = 0 |> int32 
                        let v542 : int32 = v523 |> int32 
                        let v550 : int32 = v542 - 1
                        let v552 : string = v442.[int v529..int v550]
                        let v556 : char = ' '
                        let v557 : string = method28(v556, v444, v445)
                        let v560 : string = "parsing.p_char / "
                        let v561 : string = v560 + v557 
                        let v565 : string = v561 + v510 
                        let v569 : (System.Text.StringBuilder -> string) = _.ToString()
                        let v570 : string = v569 v443
                        let v574 : string = v565 + v570 
                        let v578 : string = v574 + v552 
                        let v581 : int32 = v445 - 1
                        let v582 : int32 = 0
                        let v583 : (string -> string) = method29(v581, v582)
                        let v584 : string = v583 v9
                        let v587 : string = "^"
                        let v588 : string = v584 + v587 
                        let v592 : string = v578 + v510 
                        let v596 : string = v592 + v588 
                        let v600 : string = v596 + v510 
                        US8_1(v600)
            let v617 : US13 =
                match v605 with
                | US8_1(v613) -> (* Error *)
                    let v614 : US10 = US10_1
                    US13_0(v614, v442, v443, v444, v445)
                | US8_0(v606, v607, v608, v609, v610) -> (* Ok *)
                    let v611 : US10 = US10_0(v606)
                    US13_0(v611, v607, v608, v609, v610)
            let v706 : US9 =
                match v617 with
                | US13_1(v703) -> (* Error *)
                    US9_1(v703)
                | US13_0(v618, v619, v620, v621, v622) -> (* Ok *)
                    let v623 : bool = "" = v619
                    let v682 : US8 =
                        if v623 then
                            let v624 : string = method41(v620, v621, v622)
                            let v627 : string = "parsing.any_char / unexpected end of input / "
                            let v628 : string = v627 + v624 
                            US8_1(v628)
                        else
                            let v632 : char = v619.[int 0]
                            let v634 : (string -> int32) = String.length
                            let v635 : int32 = v634 v619
                            let v643 : int32 = 1 |> int32 
                            let v656 : int32 = v635 |> int32 
                            let v664 : int32 = v656 - 1
                            let v666 : string = v619.[int v643..int v664]
                            let v671 : (char -> string) = _.ToString()
                            let v672 : string = v671 v632
                            let v675 : int64 = System.Convert.ToInt64 v672.Length
                            let v676 : int64 = 0L
                            let v677 : UH0 = method26(v675, v672, v676)
                            let struct (v678 : System.Text.StringBuilder, v679 : int32, v680 : int32) = method27(v677, v620, v621, v622)
                            US8_0(v632, v666, v678, v679, v680)
                    match v682 with
                    | US8_1(v699) -> (* Error *)
                        US9_1(v699)
                    | US8_0(v683, v684, v685, v686, v687) -> (* Ok *)
                        let v689 : (char -> string) = _.ToString()
                        let v690 : string = v689 v683
                        let struct (v693 : string, v694 : string, v695 : System.Text.StringBuilder, v696 : int32, v697 : int32) = method42(v690, v684, v685, v686, v687)
                        US9_0(v693, v694, v695, v696, v697)
            let v718 : US14 =
                match v706 with
                | US9_1(v714) -> (* Error *)
                    let v715 : US5 = US5_1
                    US14_0(v715, v442, v443, v444, v445)
                | US9_0(v707, v708, v709, v710, v711) -> (* Ok *)
                    let v712 : US5 = US5_0(v707)
                    US14_0(v712, v708, v709, v710, v711)
            match v718 with
            | US14_1(v725) -> (* Error *)
                US12_1(v725)
            | US14_0(v719, v720, v721, v722, v723) -> (* Ok *)
                US12_0(v441, v719, v720, v721, v722, v723)
    match v732 with
    | US12_1(v740) -> (* Error *)
        US7_1(v740)
    | US12_0(v733, v734, v735, v736, v737, v738) -> (* Ok *)
        US7_0(v733, v734)
and method43 () : string =
    
    
    
    
    
    let v2 : string = "Debug"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method12(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_blue"
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
    let v70 : string = "inline_colorization::color_bright_blue"
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
    let v114 : string = "inline_colorization::color_bright_blue"
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
    let v159 : string = "\u001b[94m"
    let v163 : string = method14()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[94m"
    let v179 : string = method14()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[94m"
    let v195 : string = method14()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[94m"
    let v211 : string = method14()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method45 (v0 : string, v1 : US5, v2 : string, v3 : System.Threading.CancellationToken option, v4 : (struct (string * string) []), v5 : (struct (int32 * string * bool) -> Async<unit>) option, v6 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v7 : bool, v8 : string option) : string =
    let v9 : string = method13()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "file_name"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure7(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure7(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v69 : string = $"{v0}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure7(v10, v69)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v87 : string = "; "
    let v88 : string = $"{v87}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure7(v10, v88)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v106 : string = "arguments"
    let v107 : string = $"{v106}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure7(v10, v107)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v124 : string = $"{v51}"
    let v132 : unit = ()
    let v133 : (unit -> unit) = closure7(v10, v124)
    let v134 : unit = (fun () -> v133 (); v132) ()
    let v141 : string = $"%A{v1}"
    let v145 : string = $"{v141}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure7(v10, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v162 : string = $"{v87}"
    let v170 : unit = ()
    let v171 : (unit -> unit) = closure7(v10, v162)
    let v172 : unit = (fun () -> v171 (); v170) ()
    let v180 : string = "options"
    let v181 : string = $"{v180}"
    let v189 : unit = ()
    let v190 : (unit -> unit) = closure7(v10, v181)
    let v191 : unit = (fun () -> v190 (); v189) ()
    let v198 : string = $"{v51}"
    let v206 : unit = ()
    let v207 : (unit -> unit) = closure7(v10, v198)
    let v208 : unit = (fun () -> v207 (); v206) ()
    let v215 : string = $"{v13}"
    let v223 : unit = ()
    let v224 : (unit -> unit) = closure7(v10, v215)
    let v225 : unit = (fun () -> v224 (); v223) ()
    let v233 : string = "command"
    let v234 : string = $"{v233}"
    let v242 : unit = ()
    let v243 : (unit -> unit) = closure7(v10, v234)
    let v244 : unit = (fun () -> v243 (); v242) ()
    let v251 : string = $"{v51}"
    let v259 : unit = ()
    let v260 : (unit -> unit) = closure7(v10, v251)
    let v261 : unit = (fun () -> v260 (); v259) ()
    let v268 : string = $"{v2}"
    let v276 : unit = ()
    let v277 : (unit -> unit) = closure7(v10, v268)
    let v278 : unit = (fun () -> v277 (); v276) ()
    let v285 : string = $"{v87}"
    let v293 : unit = ()
    let v294 : (unit -> unit) = closure7(v10, v285)
    let v295 : unit = (fun () -> v294 (); v293) ()
    let v303 : string = "cancellation_token"
    let v304 : string = $"{v303}"
    let v312 : unit = ()
    let v313 : (unit -> unit) = closure7(v10, v304)
    let v314 : unit = (fun () -> v313 (); v312) ()
    let v321 : string = $"{v51}"
    let v329 : unit = ()
    let v330 : (unit -> unit) = closure7(v10, v321)
    let v331 : unit = (fun () -> v330 (); v329) ()
    (* run_target_args'
    let v341 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v342 : string = "format!(\"{:#?}\", $0)"
    let v343 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v342 
    let v344 : string = "fable_library_rust::String_::fromString($0)"
    let v345 : string = Fable.Core.RustInterop.emitRustExpr v343 v344 
    let _run_target_args'_v341 = v345 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v346 : string = "format!(\"{:#?}\", $0)"
    let v347 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v346 
    let v348 : string = "fable_library_rust::String_::fromString($0)"
    let v349 : string = Fable.Core.RustInterop.emitRustExpr v347 v348 
    let _run_target_args'_v341 = v349 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v350 : string = "format!(\"{:#?}\", $0)"
    let v351 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v350 
    let v352 : string = "fable_library_rust::String_::fromString($0)"
    let v353 : string = Fable.Core.RustInterop.emitRustExpr v351 v352 
    let _run_target_args'_v341 = v353 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v355 : string = $"%A{v3}"
    let _run_target_args'_v341 = v355 
    #endif
#if FABLE_COMPILER_PYTHON
    let v359 : string = $"%A{v3}"
    let _run_target_args'_v341 = v359 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v363 : string = $"%A{v3}"
    let _run_target_args'_v341 = v363 
    #endif
#else
    let v367 : string = $"%A{v3}"
    let _run_target_args'_v341 = v367 
    #endif
    let v370 : string = _run_target_args'_v341 
    let v380 : string = $"{v370}"
    let v388 : unit = ()
    let v389 : (unit -> unit) = closure7(v10, v380)
    let v390 : unit = (fun () -> v389 (); v388) ()
    let v397 : string = $"{v87}"
    let v405 : unit = ()
    let v406 : (unit -> unit) = closure7(v10, v397)
    let v407 : unit = (fun () -> v406 (); v405) ()
    let v415 : string = "environment_variables"
    let v416 : string = $"{v415}"
    let v424 : unit = ()
    let v425 : (unit -> unit) = closure7(v10, v416)
    let v426 : unit = (fun () -> v425 (); v424) ()
    let v433 : string = $"{v51}"
    let v441 : unit = ()
    let v442 : (unit -> unit) = closure7(v10, v433)
    let v443 : unit = (fun () -> v442 (); v441) ()
    let v450 : string = $"%A{v4}"
    let v454 : string = $"{v450}"
    let v462 : unit = ()
    let v463 : (unit -> unit) = closure7(v10, v454)
    let v464 : unit = (fun () -> v463 (); v462) ()
    let v471 : string = $"{v87}"
    let v479 : unit = ()
    let v480 : (unit -> unit) = closure7(v10, v471)
    let v481 : unit = (fun () -> v480 (); v479) ()
    let v489 : string = "on_line"
    let v490 : string = $"{v489}"
    let v498 : unit = ()
    let v499 : (unit -> unit) = closure7(v10, v490)
    let v500 : unit = (fun () -> v499 (); v498) ()
    let v507 : string = $"{v51}"
    let v515 : unit = ()
    let v516 : (unit -> unit) = closure7(v10, v507)
    let v517 : unit = (fun () -> v516 (); v515) ()
    (* run_target_args'
    let v527 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v528 : string = "format!(\"{:#?}\", $0)"
    let v529 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v528 
    let v530 : string = "fable_library_rust::String_::fromString($0)"
    let v531 : string = Fable.Core.RustInterop.emitRustExpr v529 v530 
    let _run_target_args'_v527 = v531 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v532 : string = "format!(\"{:#?}\", $0)"
    let v533 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v532 
    let v534 : string = "fable_library_rust::String_::fromString($0)"
    let v535 : string = Fable.Core.RustInterop.emitRustExpr v533 v534 
    let _run_target_args'_v527 = v535 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v536 : string = "format!(\"{:#?}\", $0)"
    let v537 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v536 
    let v538 : string = "fable_library_rust::String_::fromString($0)"
    let v539 : string = Fable.Core.RustInterop.emitRustExpr v537 v538 
    let _run_target_args'_v527 = v539 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v541 : string = $"%A{v5}"
    let _run_target_args'_v527 = v541 
    #endif
#if FABLE_COMPILER_PYTHON
    let v545 : string = $"%A{v5}"
    let _run_target_args'_v527 = v545 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v549 : string = $"%A{v5}"
    let _run_target_args'_v527 = v549 
    #endif
#else
    let v553 : string = $"%A{v5}"
    let _run_target_args'_v527 = v553 
    #endif
    let v556 : string = _run_target_args'_v527 
    let v566 : string = $"{v556}"
    let v574 : unit = ()
    let v575 : (unit -> unit) = closure7(v10, v566)
    let v576 : unit = (fun () -> v575 (); v574) ()
    let v583 : string = $"{v87}"
    let v591 : unit = ()
    let v592 : (unit -> unit) = closure7(v10, v583)
    let v593 : unit = (fun () -> v592 (); v591) ()
    let v601 : string = "stdin"
    let v602 : string = $"{v601}"
    let v610 : unit = ()
    let v611 : (unit -> unit) = closure7(v10, v602)
    let v612 : unit = (fun () -> v611 (); v610) ()
    let v619 : string = $"{v51}"
    let v627 : unit = ()
    let v628 : (unit -> unit) = closure7(v10, v619)
    let v629 : unit = (fun () -> v628 (); v627) ()
    (* run_target_args'
    let v639 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v640 : string = "format!(\"{:#?}\", $0)"
    let v641 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v640 
    let v642 : string = "fable_library_rust::String_::fromString($0)"
    let v643 : string = Fable.Core.RustInterop.emitRustExpr v641 v642 
    let _run_target_args'_v639 = v643 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v644 : string = "format!(\"{:#?}\", $0)"
    let v645 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v644 
    let v646 : string = "fable_library_rust::String_::fromString($0)"
    let v647 : string = Fable.Core.RustInterop.emitRustExpr v645 v646 
    let _run_target_args'_v639 = v647 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v648 : string = "format!(\"{:#?}\", $0)"
    let v649 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v648 
    let v650 : string = "fable_library_rust::String_::fromString($0)"
    let v651 : string = Fable.Core.RustInterop.emitRustExpr v649 v650 
    let _run_target_args'_v639 = v651 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v653 : string = $"%A{v6}"
    let _run_target_args'_v639 = v653 
    #endif
#if FABLE_COMPILER_PYTHON
    let v657 : string = $"%A{v6}"
    let _run_target_args'_v639 = v657 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v661 : string = $"%A{v6}"
    let _run_target_args'_v639 = v661 
    #endif
#else
    let v665 : string = $"%A{v6}"
    let _run_target_args'_v639 = v665 
    #endif
    let v668 : string = _run_target_args'_v639 
    let v678 : string = $"{v668}"
    let v686 : unit = ()
    let v687 : (unit -> unit) = closure7(v10, v678)
    let v688 : unit = (fun () -> v687 (); v686) ()
    let v695 : string = $"{v87}"
    let v703 : unit = ()
    let v704 : (unit -> unit) = closure7(v10, v695)
    let v705 : unit = (fun () -> v704 (); v703) ()
    let v713 : string = "trace"
    let v714 : string = $"{v713}"
    let v722 : unit = ()
    let v723 : (unit -> unit) = closure7(v10, v714)
    let v724 : unit = (fun () -> v723 (); v722) ()
    let v731 : string = $"{v51}"
    let v739 : unit = ()
    let v740 : (unit -> unit) = closure7(v10, v731)
    let v741 : unit = (fun () -> v740 (); v739) ()
    let v749 : string =
        if v7 then
            let v747 : string = "true"
            v747
        else
            let v748 : string = "false"
            v748
    let v751 : string = $"{v749}"
    let v759 : unit = ()
    let v760 : (unit -> unit) = closure7(v10, v751)
    let v761 : unit = (fun () -> v760 (); v759) ()
    let v768 : string = $"{v87}"
    let v776 : unit = ()
    let v777 : (unit -> unit) = closure7(v10, v768)
    let v778 : unit = (fun () -> v777 (); v776) ()
    let v786 : string = "working_directory"
    let v787 : string = $"{v786}"
    let v795 : unit = ()
    let v796 : (unit -> unit) = closure7(v10, v787)
    let v797 : unit = (fun () -> v796 (); v795) ()
    let v804 : string = $"{v51}"
    let v812 : unit = ()
    let v813 : (unit -> unit) = closure7(v10, v804)
    let v814 : unit = (fun () -> v813 (); v812) ()
    (* run_target_args'
    let v824 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v825 : string = "format!(\"{:#?}\", $0)"
    let v826 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v825 
    let v827 : string = "fable_library_rust::String_::fromString($0)"
    let v828 : string = Fable.Core.RustInterop.emitRustExpr v826 v827 
    let _run_target_args'_v824 = v828 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v829 : string = "format!(\"{:#?}\", $0)"
    let v830 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v829 
    let v831 : string = "fable_library_rust::String_::fromString($0)"
    let v832 : string = Fable.Core.RustInterop.emitRustExpr v830 v831 
    let _run_target_args'_v824 = v832 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v833 : string = "format!(\"{:#?}\", $0)"
    let v834 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v833 
    let v835 : string = "fable_library_rust::String_::fromString($0)"
    let v836 : string = Fable.Core.RustInterop.emitRustExpr v834 v835 
    let _run_target_args'_v824 = v836 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v838 : string = $"%A{v8}"
    let _run_target_args'_v824 = v838 
    #endif
#if FABLE_COMPILER_PYTHON
    let v842 : string = $"%A{v8}"
    let _run_target_args'_v824 = v842 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v846 : string = $"%A{v8}"
    let _run_target_args'_v824 = v846 
    #endif
#else
    let v850 : string = $"%A{v8}"
    let _run_target_args'_v824 = v850 
    #endif
    let v853 : string = _run_target_args'_v824 
    let v863 : string = $"{v853}"
    let v871 : unit = ()
    let v872 : (unit -> unit) = closure7(v10, v863)
    let v873 : unit = (fun () -> v872 (); v871) ()
    let v881 : string = " }"
    let v882 : string = $"{v881}"
    let v890 : unit = ()
    let v891 : (unit -> unit) = closure7(v10, v882)
    let v892 : unit = (fun () -> v891 (); v890) ()
    let v899 : string = $"{v881}"
    let v907 : unit = ()
    let v908 : (unit -> unit) = closure7(v10, v899)
    let v909 : unit = (fun () -> v908 (); v907) ()
    let v915 : string = v10.l0
    v915
and method44 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : US5, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method45(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    let v18 : int64 = v0.l0
    let v21 : string = " "
    let v22 : string = v6 + v21 
    let v26 : string = v22 + v7 
    let v31 : string = " #"
    let v32 : string = v26 + v31 
    let v36 : (int64 -> string) = _.ToString()
    let v37 : string = v36 v18
    let v41 : string = v32 + v37 
    let v45 : string = v41 + v21 
    let v50 : string = "runtime.execute_with_options_async"
    let v51 : string = v45 + v50 
    let v56 : string = " / "
    let v57 : string = v51 + v56 
    let v61 : string = v57 + v17 
    method17(v61)
and closure17 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : US5, v8 : string) () : unit =
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure0()
    let v25 : unit = (fun () -> v24 (); v23) ()
    let struct (v48 : Mut0, v49 : Mut1, v50 : Mut2, v51 : Mut3, v52 : Mut4, v53 : int64 option) = TraceState.trace_state.Value
    let v66 : US0 = v52.l0
    let v67 : bool = v50.l0
    let v68 : bool = v67 = false
    let v71 : bool =
        if v68 then
            false
        else
            let v69 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v66
            let v70 : bool = 1 >= v69
            v70
    let v72 : bool = v71 = false
    let v306 : US6 =
        if v72 then
            US6_1
        else
            let v88 : unit = ()
            let v89 : unit = (fun () -> v24 (); v88) ()
            let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
            let v130 : string = method7(v112, v113, v114, v115, v116, v117)
            let v131 : string = method43()
            let v132 : string = method44(v112, v113, v114, v115, v116, v117, v130, v131, v8, v7, v0, v1, v2, v3, v4, v5, v6)
            let v147 : unit = ()
            let v148 : unit = (fun () -> v24 (); v147) ()
            let struct (v171 : Mut0, v172 : Mut1, v173 : Mut2, v174 : Mut3, v175 : Mut4, v176 : int64 option) = TraceState.trace_state.Value
            let v191 : unit = ()
            let v192 : (unit -> unit) = closure8(v171)
            let v193 : unit = (fun () -> v192 (); v191) ()
            let v196 : (string -> unit) = closure9()
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
and method46 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : (struct (string * string) []) =
    v2
and method47 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method50 (v0 : System.Diagnostics.DataReceivedEventArgs) : string =
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
and closure19 () (v0 : (struct (int32 * string * bool) -> Async<unit>)) : US15 =
    US15_0(v0)
and method51 () : ((struct (int32 * string * bool) -> Async<unit>) -> US15) =
    closure19()
and method52 (v0 : System.Diagnostics.Process) : int32 =
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
and method53 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method12(v7)
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
    let v163 : string = method14()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[90m"
    let v179 : string = method14()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[90m"
    let v195 : string = method14()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[90m"
    let v211 : string = method14()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method54 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method16()
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
    let v41 : string = v37 + v8 
    let v46 : string = " / "
    let v47 : string = v41 + v46 
    let v51 : string = v47 + v9 
    method17(v51)
and closure20 (v0 : string) () : unit =
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
    let v301 : US6 =
        if v64 then
            US6_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method7(v104, v105, v106, v107, v108, v109)
            let v123 : string = method53()
            let v124 : bool = v0 = ""
            let v127 : string =
                if v124 then
                    let v125 : string = ""
                    v125
                else
                    method54(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v142 : unit = ()
            let v143 : unit = (fun () -> v16 (); v142) ()
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
and method49 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
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
            let v8959 : string = method50(v10)
            let v8961 : string = null |> unbox<string>
            let v8964 : bool = v8959 = v8961
            let v8965 : bool = v8964 <> true
            if v8965 then
                let v8968 : ((struct (int32 * string * bool) -> Async<unit>) -> US15) = method51()
                let v8969 : US15 option = v3 |> Option.map v8968 
                let v8989 : US15 = US15_1
                let v8990 : US15 = v8969 |> Option.defaultValue v8989 
                match v8990 with
                | US15_1 -> (* None *)
                    ()
                | US15_0(v8994) -> (* Some *)
                    let v8995 : int32 = method52(v7)
                    let v8996 : Async<unit> = v8994 struct (v8995, v8959, v9)
                    do! v8996 
                    ()
                let v8999 : string =
                    if v9 then
                        let v8997 : string = $"! {v8959}"
                        v8997
                    else
                        let v8998 : string = $"> {v8959}"
                        v8998
                if v5 then
                    let v9314 : unit = ()
                    let v9315 : (unit -> unit) = closure20(v8999)
                    let v9316 : unit = (fun () -> v9315 (); v9314) ()
                    ()
                else
                    let v9635 : unit = ()
                    let v9636 : (unit -> unit) = closure10(v8999)
                    let v9637 : unit = (fun () -> v9636 (); v9635) ()
                    ()
                let v9641 : string =
                    if v9 then
                        let v9639 : string = "\u001b[7;4m"
                        v9639
                    else
                        let v9640 : string = ""
                        v9640
                let v9644 : string =
                    if v9 then
                        let v9642 : string = "\u001b[0m"
                        v9642
                    else
                        let v9643 : string = ""
                        v9643
                let v9645 : string = $"{v9641}{v8959}{v9644}"
                (* run_target_args'
                let v9646 : unit = ()
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
                let v9647 : (string -> unit) = v8.Push
                v9647 v9645
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
    let v18581 : Async<unit> = _let'_v29 
    let _run_target_args'_v15 = v18581 
    #endif
#if FABLE_COMPILER_PYTHON
    let v18583 : unit = ()
    let _let'_v18583 =
        async {
            let v27513 : string = method50(v10)
            let v27515 : string = null |> unbox<string>
            let v27518 : bool = v27513 = v27515
            let v27519 : bool = v27518 <> true
            if v27519 then
                let v27522 : ((struct (int32 * string * bool) -> Async<unit>) -> US15) = method51()
                let v27523 : US15 option = v3 |> Option.map v27522 
                let v27543 : US15 = US15_1
                let v27544 : US15 = v27523 |> Option.defaultValue v27543 
                match v27544 with
                | US15_1 -> (* None *)
                    ()
                | US15_0(v27548) -> (* Some *)
                    let v27549 : int32 = method52(v7)
                    let v27550 : Async<unit> = v27548 struct (v27549, v27513, v9)
                    do! v27550 
                    ()
                let v27553 : string =
                    if v9 then
                        let v27551 : string = $"! {v27513}"
                        v27551
                    else
                        let v27552 : string = $"> {v27513}"
                        v27552
                if v5 then
                    let v27868 : unit = ()
                    let v27869 : (unit -> unit) = closure20(v27553)
                    let v27870 : unit = (fun () -> v27869 (); v27868) ()
                    ()
                else
                    let v28189 : unit = ()
                    let v28190 : (unit -> unit) = closure10(v27553)
                    let v28191 : unit = (fun () -> v28190 (); v28189) ()
                    ()
                let v28195 : string =
                    if v9 then
                        let v28193 : string = "\u001b[7;4m"
                        v28193
                    else
                        let v28194 : string = ""
                        v28194
                let v28198 : string =
                    if v9 then
                        let v28196 : string = "\u001b[0m"
                        v28196
                    else
                        let v28197 : string = ""
                        v28197
                let v28199 : string = $"{v28195}{v27513}{v28198}"
                (* run_target_args'
                let v28200 : unit = ()
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
                let v28201 : (string -> unit) = v8.Push
                v28201 v28199
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
    let v37135 : Async<unit> = _let'_v18583 
    let _run_target_args'_v15 = v37135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v37137 : unit = ()
    let _let'_v37137 =
        async {
            let v46067 : string = method50(v10)
            let v46069 : string = null |> unbox<string>
            let v46072 : bool = v46067 = v46069
            let v46073 : bool = v46072 <> true
            if v46073 then
                let v46076 : ((struct (int32 * string * bool) -> Async<unit>) -> US15) = method51()
                let v46077 : US15 option = v3 |> Option.map v46076 
                let v46097 : US15 = US15_1
                let v46098 : US15 = v46077 |> Option.defaultValue v46097 
                match v46098 with
                | US15_1 -> (* None *)
                    ()
                | US15_0(v46102) -> (* Some *)
                    let v46103 : int32 = method52(v7)
                    let v46104 : Async<unit> = v46102 struct (v46103, v46067, v9)
                    do! v46104 
                    ()
                let v46107 : string =
                    if v9 then
                        let v46105 : string = $"! {v46067}"
                        v46105
                    else
                        let v46106 : string = $"> {v46067}"
                        v46106
                if v5 then
                    let v46422 : unit = ()
                    let v46423 : (unit -> unit) = closure20(v46107)
                    let v46424 : unit = (fun () -> v46423 (); v46422) ()
                    ()
                else
                    let v46743 : unit = ()
                    let v46744 : (unit -> unit) = closure10(v46107)
                    let v46745 : unit = (fun () -> v46744 (); v46743) ()
                    ()
                let v46749 : string =
                    if v9 then
                        let v46747 : string = "\u001b[7;4m"
                        v46747
                    else
                        let v46748 : string = ""
                        v46748
                let v46752 : string =
                    if v9 then
                        let v46750 : string = "\u001b[0m"
                        v46750
                    else
                        let v46751 : string = ""
                        v46751
                let v46753 : string = $"{v46749}{v46067}{v46752}"
                (* run_target_args'
                let v46754 : unit = ()
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
                let v46755 : (string -> unit) = v8.Push
                v46755 v46753
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
    let v55689 : Async<unit> = _let'_v37137 
    let _run_target_args'_v15 = v55689 
    #endif
#else
    let v55691 : unit = ()
    let _let'_v55691 =
        async {
            let v64621 : string = method50(v10)
            let v64623 : string = null |> unbox<string>
            let v64626 : bool = v64621 = v64623
            let v64627 : bool = v64626 <> true
            if v64627 then
                let v64630 : ((struct (int32 * string * bool) -> Async<unit>) -> US15) = method51()
                let v64631 : US15 option = v3 |> Option.map v64630 
                let v64651 : US15 = US15_1
                let v64652 : US15 = v64631 |> Option.defaultValue v64651 
                match v64652 with
                | US15_1 -> (* None *)
                    ()
                | US15_0(v64656) -> (* Some *)
                    let v64657 : int32 = method52(v7)
                    let v64658 : Async<unit> = v64656 struct (v64657, v64621, v9)
                    do! v64658 
                    ()
                let v64661 : string =
                    if v9 then
                        let v64659 : string = $"! {v64621}"
                        v64659
                    else
                        let v64660 : string = $"> {v64621}"
                        v64660
                if v5 then
                    let v64976 : unit = ()
                    let v64977 : (unit -> unit) = closure20(v64661)
                    let v64978 : unit = (fun () -> v64977 (); v64976) ()
                    ()
                else
                    let v65297 : unit = ()
                    let v65298 : (unit -> unit) = closure10(v64661)
                    let v65299 : unit = (fun () -> v65298 (); v65297) ()
                    ()
                let v65303 : string =
                    if v9 then
                        let v65301 : string = "\u001b[7;4m"
                        v65301
                    else
                        let v65302 : string = ""
                        v65302
                let v65306 : string =
                    if v9 then
                        let v65304 : string = "\u001b[0m"
                        v65304
                    else
                        let v65305 : string = ""
                        v65305
                let v65307 : string = $"{v65303}{v64621}{v65306}"
                (* run_target_args'
                let v65308 : unit = ()
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
                let v65309 : (string -> unit) = v8.Push
                v65309 v65307
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
    let v74243 : Async<unit> = _let'_v55691 
    let _run_target_args'_v15 = v74243 
    #endif
    let v74244 : Async<unit> = _run_target_args'_v15 
    v74244
and method48 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
    method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
and closure18 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool) (v10 : System.Diagnostics.DataReceivedEventArgs) : unit =
    let v11 : Async<unit> = method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
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
and closure21 () (v0 : System.Threading.CancellationToken) : US16 =
    US16_0(v0)
and method55 () : (System.Threading.CancellationToken -> US16) =
    closure21()
and method56 (v0 : System.Threading.CancellationToken) : Async<System.Threading.CancellationToken> =
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
and method57 (v0 : System.Diagnostics.Process) : bool =
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
and method58 (v0 : System.Diagnostics.Process) : unit =
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
    let v1 : bool = method57(v0)
    let v2 : bool = v1 = false
    if v2 then
        method58(v0)
and method61 (v0 : System.Threading.Tasks.TaskCanceledException) : string =
    let v1 : string = method13()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure7(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "ex"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure7(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure7(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    (* run_target_args'
    let v64 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v65 : string = "format!(\"{:#?}\", $0)"
    let v66 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v65 
    let v67 : string = "fable_library_rust::String_::fromString($0)"
    let v68 : string = Fable.Core.RustInterop.emitRustExpr v66 v67 
    let _run_target_args'_v64 = v68 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v69 : string = "format!(\"{:#?}\", $0)"
    let v70 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v69 
    let v71 : string = "fable_library_rust::String_::fromString($0)"
    let v72 : string = Fable.Core.RustInterop.emitRustExpr v70 v71 
    let _run_target_args'_v64 = v72 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v73 : string = "format!(\"{:#?}\", $0)"
    let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v73 
    let v75 : string = "fable_library_rust::String_::fromString($0)"
    let v76 : string = Fable.Core.RustInterop.emitRustExpr v74 v75 
    let _run_target_args'_v64 = v76 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v78 : string = $"%A{v0}"
    let _run_target_args'_v64 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v82 : string = $"%A{v0}"
    let _run_target_args'_v64 = v82 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v86 : string = $"%A{v0}"
    let _run_target_args'_v64 = v86 
    #endif
#else
    let v90 : string = $"%A{v0}"
    let _run_target_args'_v64 = v90 
    #endif
    let v93 : string = _run_target_args'_v64 
    let v103 : string = $"{v93}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure7(v2, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure7(v2, v122)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v138 : string = v2.l0
    v138
and method60 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : System.Threading.Tasks.TaskCanceledException) : string =
    let v9 : string = method61(v8)
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
    let v42 : string = "runtime.execute_with_options_async / WaitForExitAsync"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method17(v53)
and closure23 (v0 : System.Threading.Tasks.TaskCanceledException) () : unit =
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
            let v62 : bool = 3 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US6 =
        if v64 then
            US6_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method7(v104, v105, v106, v107, v108, v109)
            let v123 : string = method11()
            let v124 : string = method60(v104, v105, v106, v107, v108, v109, v122, v123, v0)
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
and method59 (v0 : System.Diagnostics.Process, v1 : System.Collections.Concurrent.ConcurrentStack<string>, v2 : System.Threading.CancellationToken) : Async<int32> =
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
                let v30716 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30718 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v30716 = v30718 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v30722 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v30716 = v30722 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v30726 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v30716 = v30726 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v30730 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v30716 = v30730 
                #endif
#if FABLE_COMPILER_PYTHON
                let v30734 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v30716 = v30734 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v30738 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v30716 = v30738 
                #endif
#else
                let v30741 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v30716 = v30741 
                #endif
                let v30742 : System.Threading.Tasks.Task = _run_target_args'_v30716 
                (* run_target_args'
                let v30755 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30757 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v30755 = v30757 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v30761 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v30755 = v30761 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v30765 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v30755 = v30765 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v30768 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v30769 : Async<unit> = v30768 v30742
                let _run_target_args'_v30755 = v30769 
                #endif
#if FABLE_COMPILER_PYTHON
                let v30770 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v30771 : Async<unit> = v30770 v30742
                let _run_target_args'_v30755 = v30771 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v30772 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v30773 : Async<unit> = v30772 v30742
                let _run_target_args'_v30755 = v30773 
                #endif
#else
                let v30774 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v30775 : Async<unit> = v30774 v30742
                let _run_target_args'_v30755 = v30775 
                #endif
                let v30776 : Async<unit> = _run_target_args'_v30755 
                do! v30776 
                (* run_target_args'
                let v30789 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30791 : int32 = null |> unbox<int32>
                let _run_target_args'_v30789 = v30791 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v30795 : int32 = null |> unbox<int32>
                let _run_target_args'_v30789 = v30795 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v30799 : int32 = null |> unbox<int32>
                let _run_target_args'_v30789 = v30799 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v30803 : int32 = null |> unbox<int32>
                let _run_target_args'_v30789 = v30803 
                #endif
#if FABLE_COMPILER_PYTHON
                let v30807 : int32 = null |> unbox<int32>
                let _run_target_args'_v30789 = v30807 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v30811 : int32 = null |> unbox<int32>
                let _run_target_args'_v30789 = v30811 
                #endif
#else
                let v30814 : int32 = v0.ExitCode
                let _run_target_args'_v30789 = v30814 
                #endif
                let v30815 : int32 = _run_target_args'_v30789 
                return v30815 
                (* indent
                ()
            indent *)
            with ex ->
                let v31604 : exn = ex
                (* run_target_args'
                let v31609 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v31611 : string = $"%A{v31604}"
                let _run_target_args'_v31609 = v31611 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v31615 : string = $"%A{v31604}"
                let _run_target_args'_v31609 = v31615 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v31619 : string = $"%A{v31604}"
                let _run_target_args'_v31609 = v31619 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v31623 : string = $"%A{v31604}"
                let _run_target_args'_v31609 = v31623 
                #endif
#if FABLE_COMPILER_PYTHON
                let v31627 : string = $"%A{v31604}"
                let _run_target_args'_v31609 = v31627 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v31631 : string = $"%A{v31604}"
                let _run_target_args'_v31609 = v31631 
                #endif
#else
                let v31634 : string = $"{v31604.GetType ()}: {v31604.Message}"
                let _run_target_args'_v31609 = v31634 
                #endif
                let v31635 : string = _run_target_args'_v31609 
                (* run_target_args'
                let v31644 : unit = ()
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
                let v31645 : (string -> unit) = v1.Push
                v31645 v31635
                #endif
                // run_target_args' is_unit
                let v31647 : System.Threading.Tasks.TaskCanceledException = v31604 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v31961 : unit = ()
                let v31962 : (unit -> unit) = closure23(v31647)
                let v31963 : unit = (fun () -> v31962 (); v31961) ()
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
    let v63528 : Async<int32> = _let'_v21 
    let _run_target_args'_v7 = v63528 
    #endif
#if FABLE_COMPILER_PYTHON
    let v63530 : unit = ()
    let _let'_v63530 =
        async {
            try
                (* run_target_args'
                let v94225 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v94227 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v94225 = v94227 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v94231 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v94225 = v94231 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v94235 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v94225 = v94235 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v94239 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v94225 = v94239 
                #endif
#if FABLE_COMPILER_PYTHON
                let v94243 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v94225 = v94243 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v94247 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v94225 = v94247 
                #endif
#else
                let v94250 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v94225 = v94250 
                #endif
                let v94251 : System.Threading.Tasks.Task = _run_target_args'_v94225 
                (* run_target_args'
                let v94264 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v94266 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v94264 = v94266 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v94270 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v94264 = v94270 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v94274 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v94264 = v94274 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v94277 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v94278 : Async<unit> = v94277 v94251
                let _run_target_args'_v94264 = v94278 
                #endif
#if FABLE_COMPILER_PYTHON
                let v94279 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v94280 : Async<unit> = v94279 v94251
                let _run_target_args'_v94264 = v94280 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v94281 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v94282 : Async<unit> = v94281 v94251
                let _run_target_args'_v94264 = v94282 
                #endif
#else
                let v94283 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v94284 : Async<unit> = v94283 v94251
                let _run_target_args'_v94264 = v94284 
                #endif
                let v94285 : Async<unit> = _run_target_args'_v94264 
                do! v94285 
                (* run_target_args'
                let v94298 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v94300 : int32 = null |> unbox<int32>
                let _run_target_args'_v94298 = v94300 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v94304 : int32 = null |> unbox<int32>
                let _run_target_args'_v94298 = v94304 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v94308 : int32 = null |> unbox<int32>
                let _run_target_args'_v94298 = v94308 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v94312 : int32 = null |> unbox<int32>
                let _run_target_args'_v94298 = v94312 
                #endif
#if FABLE_COMPILER_PYTHON
                let v94316 : int32 = null |> unbox<int32>
                let _run_target_args'_v94298 = v94316 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v94320 : int32 = null |> unbox<int32>
                let _run_target_args'_v94298 = v94320 
                #endif
#else
                let v94323 : int32 = v0.ExitCode
                let _run_target_args'_v94298 = v94323 
                #endif
                let v94324 : int32 = _run_target_args'_v94298 
                return v94324 
                (* indent
                ()
            indent *)
            with ex ->
                let v95113 : exn = ex
                (* run_target_args'
                let v95118 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v95120 : string = $"%A{v95113}"
                let _run_target_args'_v95118 = v95120 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v95124 : string = $"%A{v95113}"
                let _run_target_args'_v95118 = v95124 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v95128 : string = $"%A{v95113}"
                let _run_target_args'_v95118 = v95128 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v95132 : string = $"%A{v95113}"
                let _run_target_args'_v95118 = v95132 
                #endif
#if FABLE_COMPILER_PYTHON
                let v95136 : string = $"%A{v95113}"
                let _run_target_args'_v95118 = v95136 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v95140 : string = $"%A{v95113}"
                let _run_target_args'_v95118 = v95140 
                #endif
#else
                let v95143 : string = $"{v95113.GetType ()}: {v95113.Message}"
                let _run_target_args'_v95118 = v95143 
                #endif
                let v95144 : string = _run_target_args'_v95118 
                (* run_target_args'
                let v95153 : unit = ()
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
                let v95154 : (string -> unit) = v1.Push
                v95154 v95144
                #endif
                // run_target_args' is_unit
                let v95156 : System.Threading.Tasks.TaskCanceledException = v95113 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v95470 : unit = ()
                let v95471 : (unit -> unit) = closure23(v95156)
                let v95472 : unit = (fun () -> v95471 (); v95470) ()
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
    let v127037 : Async<int32> = _let'_v63530 
    let _run_target_args'_v7 = v127037 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v127039 : unit = ()
    let _let'_v127039 =
        async {
            try
                (* run_target_args'
                let v157734 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v157736 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v157734 = v157736 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v157740 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v157734 = v157740 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v157744 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v157734 = v157744 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v157748 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v157734 = v157748 
                #endif
#if FABLE_COMPILER_PYTHON
                let v157752 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v157734 = v157752 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v157756 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v157734 = v157756 
                #endif
#else
                let v157759 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v157734 = v157759 
                #endif
                let v157760 : System.Threading.Tasks.Task = _run_target_args'_v157734 
                (* run_target_args'
                let v157773 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v157775 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v157773 = v157775 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v157779 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v157773 = v157779 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v157783 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v157773 = v157783 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v157786 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v157787 : Async<unit> = v157786 v157760
                let _run_target_args'_v157773 = v157787 
                #endif
#if FABLE_COMPILER_PYTHON
                let v157788 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v157789 : Async<unit> = v157788 v157760
                let _run_target_args'_v157773 = v157789 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v157790 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v157791 : Async<unit> = v157790 v157760
                let _run_target_args'_v157773 = v157791 
                #endif
#else
                let v157792 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v157793 : Async<unit> = v157792 v157760
                let _run_target_args'_v157773 = v157793 
                #endif
                let v157794 : Async<unit> = _run_target_args'_v157773 
                do! v157794 
                (* run_target_args'
                let v157807 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v157809 : int32 = null |> unbox<int32>
                let _run_target_args'_v157807 = v157809 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v157813 : int32 = null |> unbox<int32>
                let _run_target_args'_v157807 = v157813 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v157817 : int32 = null |> unbox<int32>
                let _run_target_args'_v157807 = v157817 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v157821 : int32 = null |> unbox<int32>
                let _run_target_args'_v157807 = v157821 
                #endif
#if FABLE_COMPILER_PYTHON
                let v157825 : int32 = null |> unbox<int32>
                let _run_target_args'_v157807 = v157825 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v157829 : int32 = null |> unbox<int32>
                let _run_target_args'_v157807 = v157829 
                #endif
#else
                let v157832 : int32 = v0.ExitCode
                let _run_target_args'_v157807 = v157832 
                #endif
                let v157833 : int32 = _run_target_args'_v157807 
                return v157833 
                (* indent
                ()
            indent *)
            with ex ->
                let v158622 : exn = ex
                (* run_target_args'
                let v158627 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v158629 : string = $"%A{v158622}"
                let _run_target_args'_v158627 = v158629 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v158633 : string = $"%A{v158622}"
                let _run_target_args'_v158627 = v158633 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v158637 : string = $"%A{v158622}"
                let _run_target_args'_v158627 = v158637 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v158641 : string = $"%A{v158622}"
                let _run_target_args'_v158627 = v158641 
                #endif
#if FABLE_COMPILER_PYTHON
                let v158645 : string = $"%A{v158622}"
                let _run_target_args'_v158627 = v158645 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v158649 : string = $"%A{v158622}"
                let _run_target_args'_v158627 = v158649 
                #endif
#else
                let v158652 : string = $"{v158622.GetType ()}: {v158622.Message}"
                let _run_target_args'_v158627 = v158652 
                #endif
                let v158653 : string = _run_target_args'_v158627 
                (* run_target_args'
                let v158662 : unit = ()
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
                let v158663 : (string -> unit) = v1.Push
                v158663 v158653
                #endif
                // run_target_args' is_unit
                let v158665 : System.Threading.Tasks.TaskCanceledException = v158622 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v158979 : unit = ()
                let v158980 : (unit -> unit) = closure23(v158665)
                let v158981 : unit = (fun () -> v158980 (); v158979) ()
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
    let v190546 : Async<int32> = _let'_v127039 
    let _run_target_args'_v7 = v190546 
    #endif
#else
    let v190548 : unit = ()
    let _let'_v190548 =
        async {
            try
                (* run_target_args'
                let v221243 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v221245 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v221243 = v221245 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v221249 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v221243 = v221249 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v221253 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v221243 = v221253 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v221257 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v221243 = v221257 
                #endif
#if FABLE_COMPILER_PYTHON
                let v221261 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v221243 = v221261 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v221265 : System.Threading.Tasks.Task = null |> unbox<System.Threading.Tasks.Task>
                let _run_target_args'_v221243 = v221265 
                #endif
#else
                let v221268 : System.Threading.Tasks.Task = v0.WaitForExitAsync v2 
                let _run_target_args'_v221243 = v221268 
                #endif
                let v221269 : System.Threading.Tasks.Task = _run_target_args'_v221243 
                (* run_target_args'
                let v221282 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v221284 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v221282 = v221284 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v221288 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v221282 = v221288 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v221292 : Async<unit> = null |> unbox<Async<unit>>
                let _run_target_args'_v221282 = v221292 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v221295 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v221296 : Async<unit> = v221295 v221269
                let _run_target_args'_v221282 = v221296 
                #endif
#if FABLE_COMPILER_PYTHON
                let v221297 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v221298 : Async<unit> = v221297 v221269
                let _run_target_args'_v221282 = v221298 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v221299 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v221300 : Async<unit> = v221299 v221269
                let _run_target_args'_v221282 = v221300 
                #endif
#else
                let v221301 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
                let v221302 : Async<unit> = v221301 v221269
                let _run_target_args'_v221282 = v221302 
                #endif
                let v221303 : Async<unit> = _run_target_args'_v221282 
                do! v221303 
                (* run_target_args'
                let v221316 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v221318 : int32 = null |> unbox<int32>
                let _run_target_args'_v221316 = v221318 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v221322 : int32 = null |> unbox<int32>
                let _run_target_args'_v221316 = v221322 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v221326 : int32 = null |> unbox<int32>
                let _run_target_args'_v221316 = v221326 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v221330 : int32 = null |> unbox<int32>
                let _run_target_args'_v221316 = v221330 
                #endif
#if FABLE_COMPILER_PYTHON
                let v221334 : int32 = null |> unbox<int32>
                let _run_target_args'_v221316 = v221334 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v221338 : int32 = null |> unbox<int32>
                let _run_target_args'_v221316 = v221338 
                #endif
#else
                let v221341 : int32 = v0.ExitCode
                let _run_target_args'_v221316 = v221341 
                #endif
                let v221342 : int32 = _run_target_args'_v221316 
                return v221342 
                (* indent
                ()
            indent *)
            with ex ->
                let v222131 : exn = ex
                (* run_target_args'
                let v222136 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v222138 : string = $"%A{v222131}"
                let _run_target_args'_v222136 = v222138 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v222142 : string = $"%A{v222131}"
                let _run_target_args'_v222136 = v222142 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v222146 : string = $"%A{v222131}"
                let _run_target_args'_v222136 = v222146 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v222150 : string = $"%A{v222131}"
                let _run_target_args'_v222136 = v222150 
                #endif
#if FABLE_COMPILER_PYTHON
                let v222154 : string = $"%A{v222131}"
                let _run_target_args'_v222136 = v222154 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v222158 : string = $"%A{v222131}"
                let _run_target_args'_v222136 = v222158 
                #endif
#else
                let v222161 : string = $"{v222131.GetType ()}: {v222131.Message}"
                let _run_target_args'_v222136 = v222161 
                #endif
                let v222162 : string = _run_target_args'_v222136 
                (* run_target_args'
                let v222171 : unit = ()
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
                let v222172 : (string -> unit) = v1.Push
                v222172 v222162
                #endif
                // run_target_args' is_unit
                let v222174 : System.Threading.Tasks.TaskCanceledException = v222131 |> unbox<System.Threading.Tasks.TaskCanceledException>
                let v222488 : unit = ()
                let v222489 : (unit -> unit) = closure23(v222174)
                let v222490 : unit = (fun () -> v222489 (); v222488) ()
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
    let v254055 : Async<int32> = _let'_v190548 
    let _run_target_args'_v7 = v254055 
    #endif
    let v254056 : Async<int32> = _run_target_args'_v7 
    v254056
and method62 () : string =
    let v0 : string = "\n"
    v0
and method64 (v0 : int32, v1 : int32, v2 : string, v3 : System.Threading.CancellationToken option, v4 : (struct (string * string) []), v5 : (struct (int32 * string * bool) -> Async<unit>) option, v6 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v7 : bool, v8 : string option) : string =
    let v9 : string = method13()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "exit_code"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure7(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure7(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v72 : string = $"{v0}"
    let v80 : unit = ()
    let v81 : (unit -> unit) = closure7(v10, v72)
    let v82 : unit = (fun () -> v81 (); v80) ()
    let v90 : string = "; "
    let v91 : string = $"{v90}"
    let v99 : unit = ()
    let v100 : (unit -> unit) = closure7(v10, v91)
    let v101 : unit = (fun () -> v100 (); v99) ()
    let v109 : string = "output_length"
    let v110 : string = $"{v109}"
    let v118 : unit = ()
    let v119 : (unit -> unit) = closure7(v10, v110)
    let v120 : unit = (fun () -> v119 (); v118) ()
    let v127 : string = $"{v51}"
    let v135 : unit = ()
    let v136 : (unit -> unit) = closure7(v10, v127)
    let v137 : unit = (fun () -> v136 (); v135) ()
    let v147 : string = $"{v1}"
    let v155 : unit = ()
    let v156 : (unit -> unit) = closure7(v10, v147)
    let v157 : unit = (fun () -> v156 (); v155) ()
    let v164 : string = $"{v90}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure7(v10, v164)
    let v174 : unit = (fun () -> v173 (); v172) ()
    let v182 : string = "options"
    let v183 : string = $"{v182}"
    let v191 : unit = ()
    let v192 : (unit -> unit) = closure7(v10, v183)
    let v193 : unit = (fun () -> v192 (); v191) ()
    let v200 : string = $"{v51}"
    let v208 : unit = ()
    let v209 : (unit -> unit) = closure7(v10, v200)
    let v210 : unit = (fun () -> v209 (); v208) ()
    let v217 : string = $"{v13}"
    let v225 : unit = ()
    let v226 : (unit -> unit) = closure7(v10, v217)
    let v227 : unit = (fun () -> v226 (); v225) ()
    let v235 : string = "command"
    let v236 : string = $"{v235}"
    let v244 : unit = ()
    let v245 : (unit -> unit) = closure7(v10, v236)
    let v246 : unit = (fun () -> v245 (); v244) ()
    let v253 : string = $"{v51}"
    let v261 : unit = ()
    let v262 : (unit -> unit) = closure7(v10, v253)
    let v263 : unit = (fun () -> v262 (); v261) ()
    let v270 : string = $"{v2}"
    let v278 : unit = ()
    let v279 : (unit -> unit) = closure7(v10, v270)
    let v280 : unit = (fun () -> v279 (); v278) ()
    let v287 : string = $"{v90}"
    let v295 : unit = ()
    let v296 : (unit -> unit) = closure7(v10, v287)
    let v297 : unit = (fun () -> v296 (); v295) ()
    let v305 : string = "cancellation_token"
    let v306 : string = $"{v305}"
    let v314 : unit = ()
    let v315 : (unit -> unit) = closure7(v10, v306)
    let v316 : unit = (fun () -> v315 (); v314) ()
    let v323 : string = $"{v51}"
    let v331 : unit = ()
    let v332 : (unit -> unit) = closure7(v10, v323)
    let v333 : unit = (fun () -> v332 (); v331) ()
    (* run_target_args'
    let v343 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v344 : string = "format!(\"{:#?}\", $0)"
    let v345 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v344 
    let v346 : string = "fable_library_rust::String_::fromString($0)"
    let v347 : string = Fable.Core.RustInterop.emitRustExpr v345 v346 
    let _run_target_args'_v343 = v347 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v348 : string = "format!(\"{:#?}\", $0)"
    let v349 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v348 
    let v350 : string = "fable_library_rust::String_::fromString($0)"
    let v351 : string = Fable.Core.RustInterop.emitRustExpr v349 v350 
    let _run_target_args'_v343 = v351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v352 : string = "format!(\"{:#?}\", $0)"
    let v353 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v352 
    let v354 : string = "fable_library_rust::String_::fromString($0)"
    let v355 : string = Fable.Core.RustInterop.emitRustExpr v353 v354 
    let _run_target_args'_v343 = v355 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v357 : string = $"%A{v3}"
    let _run_target_args'_v343 = v357 
    #endif
#if FABLE_COMPILER_PYTHON
    let v361 : string = $"%A{v3}"
    let _run_target_args'_v343 = v361 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v365 : string = $"%A{v3}"
    let _run_target_args'_v343 = v365 
    #endif
#else
    let v369 : string = $"%A{v3}"
    let _run_target_args'_v343 = v369 
    #endif
    let v372 : string = _run_target_args'_v343 
    let v382 : string = $"{v372}"
    let v390 : unit = ()
    let v391 : (unit -> unit) = closure7(v10, v382)
    let v392 : unit = (fun () -> v391 (); v390) ()
    let v399 : string = $"{v90}"
    let v407 : unit = ()
    let v408 : (unit -> unit) = closure7(v10, v399)
    let v409 : unit = (fun () -> v408 (); v407) ()
    let v417 : string = "environment_variables"
    let v418 : string = $"{v417}"
    let v426 : unit = ()
    let v427 : (unit -> unit) = closure7(v10, v418)
    let v428 : unit = (fun () -> v427 (); v426) ()
    let v435 : string = $"{v51}"
    let v443 : unit = ()
    let v444 : (unit -> unit) = closure7(v10, v435)
    let v445 : unit = (fun () -> v444 (); v443) ()
    let v452 : string = $"%A{v4}"
    let v456 : string = $"{v452}"
    let v464 : unit = ()
    let v465 : (unit -> unit) = closure7(v10, v456)
    let v466 : unit = (fun () -> v465 (); v464) ()
    let v473 : string = $"{v90}"
    let v481 : unit = ()
    let v482 : (unit -> unit) = closure7(v10, v473)
    let v483 : unit = (fun () -> v482 (); v481) ()
    let v491 : string = "on_line"
    let v492 : string = $"{v491}"
    let v500 : unit = ()
    let v501 : (unit -> unit) = closure7(v10, v492)
    let v502 : unit = (fun () -> v501 (); v500) ()
    let v509 : string = $"{v51}"
    let v517 : unit = ()
    let v518 : (unit -> unit) = closure7(v10, v509)
    let v519 : unit = (fun () -> v518 (); v517) ()
    (* run_target_args'
    let v529 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v530 : string = "format!(\"{:#?}\", $0)"
    let v531 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v530 
    let v532 : string = "fable_library_rust::String_::fromString($0)"
    let v533 : string = Fable.Core.RustInterop.emitRustExpr v531 v532 
    let _run_target_args'_v529 = v533 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v534 : string = "format!(\"{:#?}\", $0)"
    let v535 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v534 
    let v536 : string = "fable_library_rust::String_::fromString($0)"
    let v537 : string = Fable.Core.RustInterop.emitRustExpr v535 v536 
    let _run_target_args'_v529 = v537 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v538 : string = "format!(\"{:#?}\", $0)"
    let v539 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v538 
    let v540 : string = "fable_library_rust::String_::fromString($0)"
    let v541 : string = Fable.Core.RustInterop.emitRustExpr v539 v540 
    let _run_target_args'_v529 = v541 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v543 : string = $"%A{v5}"
    let _run_target_args'_v529 = v543 
    #endif
#if FABLE_COMPILER_PYTHON
    let v547 : string = $"%A{v5}"
    let _run_target_args'_v529 = v547 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v551 : string = $"%A{v5}"
    let _run_target_args'_v529 = v551 
    #endif
#else
    let v555 : string = $"%A{v5}"
    let _run_target_args'_v529 = v555 
    #endif
    let v558 : string = _run_target_args'_v529 
    let v568 : string = $"{v558}"
    let v576 : unit = ()
    let v577 : (unit -> unit) = closure7(v10, v568)
    let v578 : unit = (fun () -> v577 (); v576) ()
    let v585 : string = $"{v90}"
    let v593 : unit = ()
    let v594 : (unit -> unit) = closure7(v10, v585)
    let v595 : unit = (fun () -> v594 (); v593) ()
    let v603 : string = "stdin"
    let v604 : string = $"{v603}"
    let v612 : unit = ()
    let v613 : (unit -> unit) = closure7(v10, v604)
    let v614 : unit = (fun () -> v613 (); v612) ()
    let v621 : string = $"{v51}"
    let v629 : unit = ()
    let v630 : (unit -> unit) = closure7(v10, v621)
    let v631 : unit = (fun () -> v630 (); v629) ()
    (* run_target_args'
    let v641 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v642 : string = "format!(\"{:#?}\", $0)"
    let v643 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v642 
    let v644 : string = "fable_library_rust::String_::fromString($0)"
    let v645 : string = Fable.Core.RustInterop.emitRustExpr v643 v644 
    let _run_target_args'_v641 = v645 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v646 : string = "format!(\"{:#?}\", $0)"
    let v647 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v646 
    let v648 : string = "fable_library_rust::String_::fromString($0)"
    let v649 : string = Fable.Core.RustInterop.emitRustExpr v647 v648 
    let _run_target_args'_v641 = v649 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v650 : string = "format!(\"{:#?}\", $0)"
    let v651 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v650 
    let v652 : string = "fable_library_rust::String_::fromString($0)"
    let v653 : string = Fable.Core.RustInterop.emitRustExpr v651 v652 
    let _run_target_args'_v641 = v653 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v655 : string = $"%A{v6}"
    let _run_target_args'_v641 = v655 
    #endif
#if FABLE_COMPILER_PYTHON
    let v659 : string = $"%A{v6}"
    let _run_target_args'_v641 = v659 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v663 : string = $"%A{v6}"
    let _run_target_args'_v641 = v663 
    #endif
#else
    let v667 : string = $"%A{v6}"
    let _run_target_args'_v641 = v667 
    #endif
    let v670 : string = _run_target_args'_v641 
    let v680 : string = $"{v670}"
    let v688 : unit = ()
    let v689 : (unit -> unit) = closure7(v10, v680)
    let v690 : unit = (fun () -> v689 (); v688) ()
    let v697 : string = $"{v90}"
    let v705 : unit = ()
    let v706 : (unit -> unit) = closure7(v10, v697)
    let v707 : unit = (fun () -> v706 (); v705) ()
    let v715 : string = "trace"
    let v716 : string = $"{v715}"
    let v724 : unit = ()
    let v725 : (unit -> unit) = closure7(v10, v716)
    let v726 : unit = (fun () -> v725 (); v724) ()
    let v733 : string = $"{v51}"
    let v741 : unit = ()
    let v742 : (unit -> unit) = closure7(v10, v733)
    let v743 : unit = (fun () -> v742 (); v741) ()
    let v751 : string =
        if v7 then
            let v749 : string = "true"
            v749
        else
            let v750 : string = "false"
            v750
    let v753 : string = $"{v751}"
    let v761 : unit = ()
    let v762 : (unit -> unit) = closure7(v10, v753)
    let v763 : unit = (fun () -> v762 (); v761) ()
    let v770 : string = $"{v90}"
    let v778 : unit = ()
    let v779 : (unit -> unit) = closure7(v10, v770)
    let v780 : unit = (fun () -> v779 (); v778) ()
    let v788 : string = "working_directory"
    let v789 : string = $"{v788}"
    let v797 : unit = ()
    let v798 : (unit -> unit) = closure7(v10, v789)
    let v799 : unit = (fun () -> v798 (); v797) ()
    let v806 : string = $"{v51}"
    let v814 : unit = ()
    let v815 : (unit -> unit) = closure7(v10, v806)
    let v816 : unit = (fun () -> v815 (); v814) ()
    (* run_target_args'
    let v826 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v827 : string = "format!(\"{:#?}\", $0)"
    let v828 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v827 
    let v829 : string = "fable_library_rust::String_::fromString($0)"
    let v830 : string = Fable.Core.RustInterop.emitRustExpr v828 v829 
    let _run_target_args'_v826 = v830 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v831 : string = "format!(\"{:#?}\", $0)"
    let v832 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v831 
    let v833 : string = "fable_library_rust::String_::fromString($0)"
    let v834 : string = Fable.Core.RustInterop.emitRustExpr v832 v833 
    let _run_target_args'_v826 = v834 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v835 : string = "format!(\"{:#?}\", $0)"
    let v836 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v835 
    let v837 : string = "fable_library_rust::String_::fromString($0)"
    let v838 : string = Fable.Core.RustInterop.emitRustExpr v836 v837 
    let _run_target_args'_v826 = v838 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v840 : string = $"%A{v8}"
    let _run_target_args'_v826 = v840 
    #endif
#if FABLE_COMPILER_PYTHON
    let v844 : string = $"%A{v8}"
    let _run_target_args'_v826 = v844 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v848 : string = $"%A{v8}"
    let _run_target_args'_v826 = v848 
    #endif
#else
    let v852 : string = $"%A{v8}"
    let _run_target_args'_v826 = v852 
    #endif
    let v855 : string = _run_target_args'_v826 
    let v865 : string = $"{v855}"
    let v873 : unit = ()
    let v874 : (unit -> unit) = closure7(v10, v865)
    let v875 : unit = (fun () -> v874 (); v873) ()
    let v883 : string = " }"
    let v884 : string = $"{v883}"
    let v892 : unit = ()
    let v893 : (unit -> unit) = closure7(v10, v884)
    let v894 : unit = (fun () -> v893 (); v892) ()
    let v901 : string = $"{v883}"
    let v909 : unit = ()
    let v910 : (unit -> unit) = closure7(v10, v901)
    let v911 : unit = (fun () -> v910 (); v909) ()
    let v917 : string = v10.l0
    v917
and method63 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int32, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method64(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    let v18 : int64 = v0.l0
    let v21 : string = " "
    let v22 : string = v6 + v21 
    let v26 : string = v22 + v7 
    let v31 : string = " #"
    let v32 : string = v26 + v31 
    let v36 : (int64 -> string) = _.ToString()
    let v37 : string = v36 v18
    let v41 : string = v32 + v37 
    let v45 : string = v41 + v21 
    let v50 : string = "runtime.execute_with_options_async"
    let v51 : string = v45 + v50 
    let v56 : string = " / "
    let v57 : string = v51 + v56 
    let v61 : string = v57 + v17 
    method17(v61)
and closure24 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : int32, v8 : string) () : unit =
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure0()
    let v25 : unit = (fun () -> v24 (); v23) ()
    let struct (v48 : Mut0, v49 : Mut1, v50 : Mut2, v51 : Mut3, v52 : Mut4, v53 : int64 option) = TraceState.trace_state.Value
    let v66 : US0 = v52.l0
    let v67 : bool = v50.l0
    let v68 : bool = v67 = false
    let v71 : bool =
        if v68 then
            false
        else
            let v69 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v66
            let v70 : bool = 1 >= v69
            v70
    let v72 : bool = v71 = false
    let v307 : US6 =
        if v72 then
            US6_1
        else
            let v88 : unit = ()
            let v89 : unit = (fun () -> v24 (); v88) ()
            let struct (v112 : Mut0, v113 : Mut1, v114 : Mut2, v115 : Mut3, v116 : Mut4, v117 : int64 option) = TraceState.trace_state.Value
            let v130 : string = method7(v112, v113, v114, v115, v116, v117)
            let v131 : string = method43()
            let v132 : int32 = v8.Length
            let v133 : string = method63(v112, v113, v114, v115, v116, v117, v130, v131, v7, v132, v0, v1, v2, v3, v4, v5, v6)
            let v148 : unit = ()
            let v149 : unit = (fun () -> v24 (); v148) ()
            let struct (v172 : Mut0, v173 : Mut1, v174 : Mut2, v175 : Mut3, v176 : Mut4, v177 : int64 option) = TraceState.trace_state.Value
            let v192 : unit = ()
            let v193 : (unit -> unit) = closure8(v172)
            let v194 : unit = (fun () -> v193 (); v192) ()
            let v197 : (string -> unit) = closure9()
            (* run_target_args'
            let v198 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v199 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v133 v199 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v200 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v133 v200 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v201 : string = v175.l0
            let v202 : bool = v201 = ""
            let v217 : string =
                if v202 then
                    v133
                else
                    let v203 : bool = v133 = ""
                    if v203 then
                        let v204 : string = v175.l0
                        v204
                    else
                        let v205 : string = v175.l0
                        let v208 : string = "\n"
                        let v209 : string = v205 + v208 
                        let v213 : string = v209 + v133 
                        v213
            (* run_target_args'
            let v222 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v223 : string = "&*$0"
            let v224 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v217 v223 
            let _run_target_args'_v222 = v224 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v225 : string = "&*$0"
            let v226 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v217 v225 
            let _run_target_args'_v222 = v226 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v227 : string = "&*$0"
            let v228 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v217 v227 
            let _run_target_args'_v222 = v228 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v230 : Ref<Str> = v217 |> unbox<Ref<Str>>
            let _run_target_args'_v222 = v230 
            #endif
#if FABLE_COMPILER_PYTHON
            let v234 : Ref<Str> = v217 |> unbox<Ref<Str>>
            let _run_target_args'_v222 = v234 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v238 : Ref<Str> = v217 |> unbox<Ref<Str>>
            let _run_target_args'_v222 = v238 
            #endif
#else
            let v242 : Ref<Str> = v217 |> unbox<Ref<Str>>
            let _run_target_args'_v222 = v242 
            #endif
            let v245 : Ref<Str> = _run_target_args'_v222 
            let v254 : string = $"$0.chars()"
            let v255 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v245 v254 
            let v256 : string = "$0"
            let v257 : _ = Fable.Core.RustInterop.emitRustExpr v255 v256 
            let v258 : string = "$0.collect::<Vec<_>>()"
            let v259 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v261 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v263 : bool = Fable.Core.RustInterop.emitRustExpr v261 v262 
            let v264 : string = "x"
            let v265 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v264 
            let v266 : string = "String::from_iter($0)"
            let v267 : std_string_String = Fable.Core.RustInterop.emitRustExpr v265 v266 
            let v268 : string = "true; $0 }).collect::<Vec<_>>()"
            let v269 : bool = Fable.Core.RustInterop.emitRustExpr v267 v268 
            let v270 : string = "_vec_map"
            let v271 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v270 
            let v272 : string = "$0.len()"
            let v273 : unativeint = Fable.Core.RustInterop.emitRustExpr v271 v272 
            let v279 : int32 = v273 |> int32 
            let v289 : string = ""
            let v290 : bool = v133 <> v289 
            let v294 : bool =
                if v290 then
                    let v293 : bool = v279 <= 1
                    v293
                else
                    false
            if v294 then
                v175.l0 <- v217
                ()
            else
                v175.l0 <- v289
                let v295 : string = "true; $0.into_iter().for_each(|x| { //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr v271 v295 
                let v297 : string = "x"
                let v298 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v297 
                let v299 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v300 : bool = Fable.Core.RustInterop.emitRustExpr v298 v299 
                let v301 : string = $"true"
                let v302 : bool = Fable.Core.RustInterop.emitRustExpr () v301 
                let v303 : string = "true; }); //"
                let v304 : bool = Fable.Core.RustInterop.emitRustExpr () v303 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v197 v133
            #endif
#if FABLE_COMPILER_PYTHON
            v197 v133
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v197 v133
            #endif
#else
            v197 v133
            #endif
            // run_target_args' is_unit
            let v305 : (string -> unit) = v173.l0
            v305 v133
            US6_0(v172, v173, v174, v175, v176, v177)
    
    ()
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
            let v19068 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v19071 : int32, v19072 : string) = null |> unbox<struct (int32 * string)>
            return struct (v19071, v19072) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v19079 : int32, v19080 : string) = null |> unbox<struct (int32 * string)>
            return struct (v19079, v19080) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v19087 : int32, v19088 : string) = null |> unbox<struct (int32 * string)>
            return struct (v19087, v19088) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v19095 : int32, v19096 : string) = null |> unbox<struct (int32 * string)>
            return struct (v19095, v19096) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v19103 : int32, v19104 : string) = null |> unbox<struct (int32 * string)>
            return struct (v19103, v19104) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v19111 : int32, v19112 : string) = null |> unbox<struct (int32 * string)>
            return struct (v19111, v19112) 
            #endif
#else
            let v19117 : US7 = method23(v0)
            let struct (v19129 : string, v19130 : US5) =
                match v19117 with
                | US7_1(v19120) -> (* Error *)
                    let v19122 : string = $"resultm.get / Result value was Error: {v19120}"
                    failwith<struct (string * US5)> v19122
                | US7_0(v19118, v19119) -> (* Ok *)
                    struct (v19118, v19119)
            let v19133 : (string -> US5) = method5()
            let v19134 : US5 option = v6 |> Option.map v19133 
            let v19154 : US5 = US5_1
            let v19155 : US5 = v19134 |> Option.defaultValue v19154 
            let v19162 : string =
                match v19155 with
                | US5_1 -> (* None *)
                    let v19160 : string = ""
                    v19160
                | US5_0(v19159) -> (* Some *)
                    v19159
            let v19474 : unit = ()
            let v19475 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v19130, v19129)
            let v19476 : unit = (fun () -> v19475 (); v19474) ()
            let v19791 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v19795 : string =
                match v19130 with
                | US5_1 -> (* None *)
                    let v19793 : string = ""
                    v19793
                | US5_0(v19792) -> (* Some *)
                    v19792
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v19795,
              StandardOutputEncoding = v19791,
              WorkingDirectory = v19162,
              FileName = v19129,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v19796 : System.Diagnostics.ProcessStartInfo = start_info
            let v19797 : (struct (string * string) []) = method46(v0, v1, v2, v3, v4, v5, v6)
            let v19798 : int32 = v19797.Length
            let v19799 : Mut5 = {l0 = 0} : Mut5
            while method47(v19798, v19799) do
                let v19801 : int32 = v19799.l0
                let struct (v19802 : string, v19803 : string) = v19797.[int v19801]
                v19796.EnvironmentVariables.[v19802] <- v19803 
                let v19804 : int32 = v19801 + 1
                v19799.l0 <- v19804
                ()
            let v19805 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v19796)
            use v19805 = v19805 
            let v19806 : System.Diagnostics.Process = v19805 
            let v19807 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v19808 : System.Collections.Concurrent.ConcurrentStack<string> = v19807 ()
            let v19809 : bool = false
            let v19810 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v19806, v19808, v19809)
            v19806.OutputDataReceived.Add v19810 
            let v19811 : bool = true
            let v19812 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v19806, v19808, v19811)
            v19806.ErrorDataReceived.Add v19812 
            let v19813 : (unit -> bool) = v19806.Start
            let v19814 : bool = v19813 ()
            let v19815 : bool = v19814 = false
            if v19815 then
                let v19816 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v19816
            let v19817 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v19817 v19806
            let v19818 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v19818 v19806
            let v19821 : (System.Threading.CancellationToken -> US16) = method55()
            let v19822 : US16 option = v1 |> Option.map v19821 
            let v19842 : US16 = US16_1
            let v19843 : US16 = v19822 |> Option.defaultValue v19842 
            let v19850 : System.Threading.CancellationToken =
                match v19843 with
                | US16_1 -> (* None *)
                    let v19848 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v19848
                | US16_0(v19847) -> (* Some *)
                    v19847
            let v19851 : Async<System.Threading.CancellationToken> = method56(v19850)
            let! v19851 = v19851 
            let v19852 : System.Threading.CancellationToken = v19851 
            let v19853 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v19852.Register
            let v19854 : (unit -> unit) = closure22(v19806)
            let v19855 : System.Threading.CancellationTokenRegistration = v19853 v19854
            use v19855 = v19855 
            let v19856 : System.Threading.CancellationTokenRegistration = v19855 
            let v19857 : Async<int32> = method59(v19806, v19808, v19852)
            let! v19857 = v19857 
            let v19858 : int32 = v19857 
            let v19860 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v19861 : string seq = v19860 v19808
            let v19865 : (string seq -> string seq) = Seq.rev
            let v19866 : string seq = v19865 v19861
            let v19871 : string = method62()
            let v19872 : (string -> (string seq -> string)) = String.concat
            let v19873 : (string seq -> string) = v19872 v19871
            let v19874 : string = v19873 v19866
            let v20190 : unit = ()
            let v20191 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v19858, v19874)
            let v20192 : unit = (fun () -> v20191 (); v20190) ()
            return struct (v19858, v19874) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v39556 : Async<struct (int32 * string)> = _let'_v25 
    let _run_target_args'_v11 = v39556 
    #endif
#if FABLE_COMPILER_PYTHON
    let v39558 : unit = ()
    let _let'_v39558 =
        async {
            (* run_target_args'
            let v58601 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v58604 : int32, v58605 : string) = null |> unbox<struct (int32 * string)>
            return struct (v58604, v58605) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v58612 : int32, v58613 : string) = null |> unbox<struct (int32 * string)>
            return struct (v58612, v58613) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v58620 : int32, v58621 : string) = null |> unbox<struct (int32 * string)>
            return struct (v58620, v58621) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v58628 : int32, v58629 : string) = null |> unbox<struct (int32 * string)>
            return struct (v58628, v58629) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v58636 : int32, v58637 : string) = null |> unbox<struct (int32 * string)>
            return struct (v58636, v58637) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v58644 : int32, v58645 : string) = null |> unbox<struct (int32 * string)>
            return struct (v58644, v58645) 
            #endif
#else
            let v58650 : US7 = method23(v0)
            let struct (v58662 : string, v58663 : US5) =
                match v58650 with
                | US7_1(v58653) -> (* Error *)
                    let v58655 : string = $"resultm.get / Result value was Error: {v58653}"
                    failwith<struct (string * US5)> v58655
                | US7_0(v58651, v58652) -> (* Ok *)
                    struct (v58651, v58652)
            let v58666 : (string -> US5) = method5()
            let v58667 : US5 option = v6 |> Option.map v58666 
            let v58687 : US5 = US5_1
            let v58688 : US5 = v58667 |> Option.defaultValue v58687 
            let v58695 : string =
                match v58688 with
                | US5_1 -> (* None *)
                    let v58693 : string = ""
                    v58693
                | US5_0(v58692) -> (* Some *)
                    v58692
            let v59007 : unit = ()
            let v59008 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v58663, v58662)
            let v59009 : unit = (fun () -> v59008 (); v59007) ()
            let v59324 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v59328 : string =
                match v58663 with
                | US5_1 -> (* None *)
                    let v59326 : string = ""
                    v59326
                | US5_0(v59325) -> (* Some *)
                    v59325
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v59328,
              StandardOutputEncoding = v59324,
              WorkingDirectory = v58695,
              FileName = v58662,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v59329 : System.Diagnostics.ProcessStartInfo = start_info
            let v59330 : (struct (string * string) []) = method46(v0, v1, v2, v3, v4, v5, v6)
            let v59331 : int32 = v59330.Length
            let v59332 : Mut5 = {l0 = 0} : Mut5
            while method47(v59331, v59332) do
                let v59334 : int32 = v59332.l0
                let struct (v59335 : string, v59336 : string) = v59330.[int v59334]
                v59329.EnvironmentVariables.[v59335] <- v59336 
                let v59337 : int32 = v59334 + 1
                v59332.l0 <- v59337
                ()
            let v59338 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v59329)
            use v59338 = v59338 
            let v59339 : System.Diagnostics.Process = v59338 
            let v59340 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v59341 : System.Collections.Concurrent.ConcurrentStack<string> = v59340 ()
            let v59342 : bool = false
            let v59343 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v59339, v59341, v59342)
            v59339.OutputDataReceived.Add v59343 
            let v59344 : bool = true
            let v59345 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v59339, v59341, v59344)
            v59339.ErrorDataReceived.Add v59345 
            let v59346 : (unit -> bool) = v59339.Start
            let v59347 : bool = v59346 ()
            let v59348 : bool = v59347 = false
            if v59348 then
                let v59349 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v59349
            let v59350 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v59350 v59339
            let v59351 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v59351 v59339
            let v59354 : (System.Threading.CancellationToken -> US16) = method55()
            let v59355 : US16 option = v1 |> Option.map v59354 
            let v59375 : US16 = US16_1
            let v59376 : US16 = v59355 |> Option.defaultValue v59375 
            let v59383 : System.Threading.CancellationToken =
                match v59376 with
                | US16_1 -> (* None *)
                    let v59381 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v59381
                | US16_0(v59380) -> (* Some *)
                    v59380
            let v59384 : Async<System.Threading.CancellationToken> = method56(v59383)
            let! v59384 = v59384 
            let v59385 : System.Threading.CancellationToken = v59384 
            let v59386 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v59385.Register
            let v59387 : (unit -> unit) = closure22(v59339)
            let v59388 : System.Threading.CancellationTokenRegistration = v59386 v59387
            use v59388 = v59388 
            let v59389 : System.Threading.CancellationTokenRegistration = v59388 
            let v59390 : Async<int32> = method59(v59339, v59341, v59385)
            let! v59390 = v59390 
            let v59391 : int32 = v59390 
            let v59393 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v59394 : string seq = v59393 v59341
            let v59398 : (string seq -> string seq) = Seq.rev
            let v59399 : string seq = v59398 v59394
            let v59404 : string = method62()
            let v59405 : (string -> (string seq -> string)) = String.concat
            let v59406 : (string seq -> string) = v59405 v59404
            let v59407 : string = v59406 v59399
            let v59723 : unit = ()
            let v59724 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v59391, v59407)
            let v59725 : unit = (fun () -> v59724 (); v59723) ()
            return struct (v59391, v59407) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v79089 : Async<struct (int32 * string)> = _let'_v39558 
    let _run_target_args'_v11 = v79089 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v79091 : unit = ()
    let _let'_v79091 =
        async {
            (* run_target_args'
            let v98134 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v98137 : int32, v98138 : string) = null |> unbox<struct (int32 * string)>
            return struct (v98137, v98138) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v98145 : int32, v98146 : string) = null |> unbox<struct (int32 * string)>
            return struct (v98145, v98146) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v98153 : int32, v98154 : string) = null |> unbox<struct (int32 * string)>
            return struct (v98153, v98154) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v98161 : int32, v98162 : string) = null |> unbox<struct (int32 * string)>
            return struct (v98161, v98162) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v98169 : int32, v98170 : string) = null |> unbox<struct (int32 * string)>
            return struct (v98169, v98170) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v98177 : int32, v98178 : string) = null |> unbox<struct (int32 * string)>
            return struct (v98177, v98178) 
            #endif
#else
            let v98183 : US7 = method23(v0)
            let struct (v98195 : string, v98196 : US5) =
                match v98183 with
                | US7_1(v98186) -> (* Error *)
                    let v98188 : string = $"resultm.get / Result value was Error: {v98186}"
                    failwith<struct (string * US5)> v98188
                | US7_0(v98184, v98185) -> (* Ok *)
                    struct (v98184, v98185)
            let v98199 : (string -> US5) = method5()
            let v98200 : US5 option = v6 |> Option.map v98199 
            let v98220 : US5 = US5_1
            let v98221 : US5 = v98200 |> Option.defaultValue v98220 
            let v98228 : string =
                match v98221 with
                | US5_1 -> (* None *)
                    let v98226 : string = ""
                    v98226
                | US5_0(v98225) -> (* Some *)
                    v98225
            let v98540 : unit = ()
            let v98541 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v98196, v98195)
            let v98542 : unit = (fun () -> v98541 (); v98540) ()
            let v98857 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v98861 : string =
                match v98196 with
                | US5_1 -> (* None *)
                    let v98859 : string = ""
                    v98859
                | US5_0(v98858) -> (* Some *)
                    v98858
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v98861,
              StandardOutputEncoding = v98857,
              WorkingDirectory = v98228,
              FileName = v98195,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v98862 : System.Diagnostics.ProcessStartInfo = start_info
            let v98863 : (struct (string * string) []) = method46(v0, v1, v2, v3, v4, v5, v6)
            let v98864 : int32 = v98863.Length
            let v98865 : Mut5 = {l0 = 0} : Mut5
            while method47(v98864, v98865) do
                let v98867 : int32 = v98865.l0
                let struct (v98868 : string, v98869 : string) = v98863.[int v98867]
                v98862.EnvironmentVariables.[v98868] <- v98869 
                let v98870 : int32 = v98867 + 1
                v98865.l0 <- v98870
                ()
            let v98871 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v98862)
            use v98871 = v98871 
            let v98872 : System.Diagnostics.Process = v98871 
            let v98873 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v98874 : System.Collections.Concurrent.ConcurrentStack<string> = v98873 ()
            let v98875 : bool = false
            let v98876 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v98872, v98874, v98875)
            v98872.OutputDataReceived.Add v98876 
            let v98877 : bool = true
            let v98878 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v98872, v98874, v98877)
            v98872.ErrorDataReceived.Add v98878 
            let v98879 : (unit -> bool) = v98872.Start
            let v98880 : bool = v98879 ()
            let v98881 : bool = v98880 = false
            if v98881 then
                let v98882 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v98882
            let v98883 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v98883 v98872
            let v98884 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v98884 v98872
            let v98887 : (System.Threading.CancellationToken -> US16) = method55()
            let v98888 : US16 option = v1 |> Option.map v98887 
            let v98908 : US16 = US16_1
            let v98909 : US16 = v98888 |> Option.defaultValue v98908 
            let v98916 : System.Threading.CancellationToken =
                match v98909 with
                | US16_1 -> (* None *)
                    let v98914 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v98914
                | US16_0(v98913) -> (* Some *)
                    v98913
            let v98917 : Async<System.Threading.CancellationToken> = method56(v98916)
            let! v98917 = v98917 
            let v98918 : System.Threading.CancellationToken = v98917 
            let v98919 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v98918.Register
            let v98920 : (unit -> unit) = closure22(v98872)
            let v98921 : System.Threading.CancellationTokenRegistration = v98919 v98920
            use v98921 = v98921 
            let v98922 : System.Threading.CancellationTokenRegistration = v98921 
            let v98923 : Async<int32> = method59(v98872, v98874, v98918)
            let! v98923 = v98923 
            let v98924 : int32 = v98923 
            let v98926 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v98927 : string seq = v98926 v98874
            let v98931 : (string seq -> string seq) = Seq.rev
            let v98932 : string seq = v98931 v98927
            let v98937 : string = method62()
            let v98938 : (string -> (string seq -> string)) = String.concat
            let v98939 : (string seq -> string) = v98938 v98937
            let v98940 : string = v98939 v98932
            let v99256 : unit = ()
            let v99257 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v98924, v98940)
            let v99258 : unit = (fun () -> v99257 (); v99256) ()
            return struct (v98924, v98940) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v118622 : Async<struct (int32 * string)> = _let'_v79091 
    let _run_target_args'_v11 = v118622 
    #endif
#else
    let v118624 : unit = ()
    let _let'_v118624 =
        async {
            (* run_target_args'
            let v137667 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v137670 : int32, v137671 : string) = null |> unbox<struct (int32 * string)>
            return struct (v137670, v137671) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v137678 : int32, v137679 : string) = null |> unbox<struct (int32 * string)>
            return struct (v137678, v137679) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v137686 : int32, v137687 : string) = null |> unbox<struct (int32 * string)>
            return struct (v137686, v137687) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v137694 : int32, v137695 : string) = null |> unbox<struct (int32 * string)>
            return struct (v137694, v137695) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v137702 : int32, v137703 : string) = null |> unbox<struct (int32 * string)>
            return struct (v137702, v137703) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v137710 : int32, v137711 : string) = null |> unbox<struct (int32 * string)>
            return struct (v137710, v137711) 
            #endif
#else
            let v137716 : US7 = method23(v0)
            let struct (v137728 : string, v137729 : US5) =
                match v137716 with
                | US7_1(v137719) -> (* Error *)
                    let v137721 : string = $"resultm.get / Result value was Error: {v137719}"
                    failwith<struct (string * US5)> v137721
                | US7_0(v137717, v137718) -> (* Ok *)
                    struct (v137717, v137718)
            let v137732 : (string -> US5) = method5()
            let v137733 : US5 option = v6 |> Option.map v137732 
            let v137753 : US5 = US5_1
            let v137754 : US5 = v137733 |> Option.defaultValue v137753 
            let v137761 : string =
                match v137754 with
                | US5_1 -> (* None *)
                    let v137759 : string = ""
                    v137759
                | US5_0(v137758) -> (* Some *)
                    v137758
            let v138073 : unit = ()
            let v138074 : (unit -> unit) = closure17(v0, v1, v2, v3, v4, v5, v6, v137729, v137728)
            let v138075 : unit = (fun () -> v138074 (); v138073) ()
            let v138390 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v138394 : string =
                match v137729 with
                | US5_1 -> (* None *)
                    let v138392 : string = ""
                    v138392
                | US5_0(v138391) -> (* Some *)
                    v138391
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v138394,
              StandardOutputEncoding = v138390,
              WorkingDirectory = v137761,
              FileName = v137728,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v138395 : System.Diagnostics.ProcessStartInfo = start_info
            let v138396 : (struct (string * string) []) = method46(v0, v1, v2, v3, v4, v5, v6)
            let v138397 : int32 = v138396.Length
            let v138398 : Mut5 = {l0 = 0} : Mut5
            while method47(v138397, v138398) do
                let v138400 : int32 = v138398.l0
                let struct (v138401 : string, v138402 : string) = v138396.[int v138400]
                v138395.EnvironmentVariables.[v138401] <- v138402 
                let v138403 : int32 = v138400 + 1
                v138398.l0 <- v138403
                ()
            let v138404 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v138395)
            use v138404 = v138404 
            let v138405 : System.Diagnostics.Process = v138404 
            let v138406 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v138407 : System.Collections.Concurrent.ConcurrentStack<string> = v138406 ()
            let v138408 : bool = false
            let v138409 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v138405, v138407, v138408)
            v138405.OutputDataReceived.Add v138409 
            let v138410 : bool = true
            let v138411 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure18(v0, v1, v2, v3, v4, v5, v6, v138405, v138407, v138410)
            v138405.ErrorDataReceived.Add v138411 
            let v138412 : (unit -> bool) = v138405.Start
            let v138413 : bool = v138412 ()
            let v138414 : bool = v138413 = false
            if v138414 then
                let v138415 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v138415
            let v138416 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v138416 v138405
            let v138417 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v138417 v138405
            let v138420 : (System.Threading.CancellationToken -> US16) = method55()
            let v138421 : US16 option = v1 |> Option.map v138420 
            let v138441 : US16 = US16_1
            let v138442 : US16 = v138421 |> Option.defaultValue v138441 
            let v138449 : System.Threading.CancellationToken =
                match v138442 with
                | US16_1 -> (* None *)
                    let v138447 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v138447
                | US16_0(v138446) -> (* Some *)
                    v138446
            let v138450 : Async<System.Threading.CancellationToken> = method56(v138449)
            let! v138450 = v138450 
            let v138451 : System.Threading.CancellationToken = v138450 
            let v138452 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v138451.Register
            let v138453 : (unit -> unit) = closure22(v138405)
            let v138454 : System.Threading.CancellationTokenRegistration = v138452 v138453
            use v138454 = v138454 
            let v138455 : System.Threading.CancellationTokenRegistration = v138454 
            let v138456 : Async<int32> = method59(v138405, v138407, v138451)
            let! v138456 = v138456 
            let v138457 : int32 = v138456 
            let v138459 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v138460 : string seq = v138459 v138407
            let v138464 : (string seq -> string seq) = Seq.rev
            let v138465 : string seq = v138464 v138460
            let v138470 : string = method62()
            let v138471 : (string -> (string seq -> string)) = String.concat
            let v138472 : (string seq -> string) = v138471 v138470
            let v138473 : string = v138472 v138465
            let v138789 : unit = ()
            let v138790 : (unit -> unit) = closure24(v0, v1, v2, v3, v4, v5, v6, v138457, v138473)
            let v138791 : unit = (fun () -> v138790 (); v138789) ()
            return struct (v138457, v138473) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v158155 : Async<struct (int32 * string)> = _let'_v118624 
    let _run_target_args'_v11 = v158155 
    #endif
    let v158156 : Async<struct (int32 * string)> = _run_target_args'_v11 
    v158156
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
and method67 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 4L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v19 : US10 =
            if v3 then
                US10_0('\\')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US10_0('`')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US10_0('"')
                    else
                        let v11 : int64 = v8 - 1L
                        let v12 : bool = v11 = 0L
                        if v12 then
                            US10_0(' ')
                        else
                            let v14 : int64 = v11 - 1L
                            US10_1
        let v23 : char =
            match v19 with
            | US10_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US10_0(v20) -> (* Some *)
                v20
        let v24 : bool = v0 = v23
        if v24 then
            true
        else
            let v25 : int64 = v1 + 1L
            method67(v0, v25)
and method68 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v120 : US8 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ' ' :: v6 
            let v12 : char list = '"' :: v8 
            let v16 : char list = '`' :: v12 
            let v20 : char list = '\\' :: v16 
            let v24 : (char list -> (char [])) = List.toArray
            let v25 : (char []) = v24 v20
            let v28 : string = method31(v25, v2, v3, v4)
            let v31 : string = "parsing.none_of / unexpected end of input / "
            let v32 : string = v31 + v28 
            US8_1(v32)
        else
            let v36 : char = v1.[int 0]
            let v37 : int64 = 0L
            let v38 : bool = method67(v36, v37)
            let v39 : bool = v38 = false
            if v39 then
                let v41 : (string -> int32) = String.length
                let v42 : int32 = v41 v1
                let v50 : int32 = 1 |> int32 
                let v63 : int32 = v42 |> int32 
                let v71 : int32 = v63 - 1
                let v73 : string = v1.[int v50..int v71]
                let v78 : (char -> string) = _.ToString()
                let v79 : string = v78 v36
                let v82 : int64 = System.Convert.ToInt64 v79.Length
                let v83 : int64 = 0L
                let v84 : UH0 = method26(v82, v79, v83)
                let struct (v85 : System.Text.StringBuilder, v86 : int32, v87 : int32) = method27(v84, v2, v3, v4)
                US8_0(v36, v73, v85, v86, v87)
            else
                let v89 : char list = []
                let v91 : char list = ' ' :: v89 
                let v95 : char list = '"' :: v91 
                let v99 : char list = '`' :: v95 
                let v103 : char list = '\\' :: v99 
                let v107 : (char list -> (char [])) = List.toArray
                let v108 : (char []) = v107 v103
                let v111 : string = method33(v36, v108, v2, v3, v4)
                let v114 : string = "parsing.none_of / unexpected char / "
                let v115 : string = v114 + v111 
                US8_1(v115)
    match v120 with
    | US8_1(v137) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US8_0(v121, v122, v123, v124, v125) -> (* Ok *)
        let v127 : (char -> string) = _.ToString()
        let v128 : string = v127 v121
        let v131 : string = v0 + v128 
        method68(v131, v122, v123, v124, v125)
and method70 (v0 : char, v1 : int64) : bool =
    let v2 : bool = v1 >= 3L
    if v2 then
        false
    else
        let v3 : bool = v1 = 0L
        let v15 : US10 =
            if v3 then
                US10_0('\\')
            else
                let v5 : int64 = v1 - 1L
                let v6 : bool = v5 = 0L
                if v6 then
                    US10_0('`')
                else
                    let v8 : int64 = v5 - 1L
                    let v9 : bool = v8 = 0L
                    if v9 then
                        US10_0('"')
                    else
                        let v11 : int64 = v8 - 1L
                        US10_1
        let v19 : char =
            match v15 with
            | US10_1 -> (* None *)
                failwith<char> "Option does not have a value."
            | US10_0(v16) -> (* Some *)
                v16
        let v20 : bool = v0 = v19
        if v20 then
            true
        else
            let v21 : int64 = v1 + 1L
            method70(v0, v21)
and closure28 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US9 =
    let v4 : bool = "" = v0
    let v164 : US8 =
        if v4 then
            let v5 : char = '\\'
            let v6 : string = method25(v5, v1, v2, v3)
            let v9 : string = "parsing.p_char / unexpected end of input / "
            let v10 : string = v9 + v6 
            US8_1(v10)
        else
            let v14 : char = v0.[int 0]
            let v15 : bool = v14 = '\\'
            if v15 then
                let v17 : (string -> int32) = String.length
                let v18 : int32 = v17 v0
                let v26 : int32 = 1 |> int32 
                let v39 : int32 = v18 |> int32 
                let v47 : int32 = v39 - 1
                let v49 : string = v0.[int v26..int v47]
                let v54 : (char -> string) = _.ToString()
                let v55 : string = v54 v14
                let v58 : int64 = System.Convert.ToInt64 v55.Length
                let v59 : int64 = 0L
                let v60 : UH0 = method26(v58, v55, v59)
                let struct (v61 : System.Text.StringBuilder, v62 : int32, v63 : int32) = method27(v60, v1, v2, v3)
                US8_0(v14, v49, v61, v62, v63)
            else
                let v68 : string = "\n"
                let v69 : int32 = v0.IndexOf v68 
                let v72 : int32 = v69 - 1
                let v73 : bool = -2 = v72
                let v81 : int32 =
                    if v73 then
                        let v75 : (string -> int32) = String.length
                        let v76 : int32 = v75 v0
                        let v79 : int32 = v76 + 1
                        v79
                    else
                        let v80 : int32 = v72 + 1
                        v80
                let v87 : int32 = 0 |> int32 
                let v100 : int32 = v81 |> int32 
                let v108 : int32 = v100 - 1
                let v110 : string = v0.[int v87..int v108]
                let v114 : char = '\\'
                let v115 : string = method28(v114, v2, v3)
                let v118 : string = "parsing.p_char / "
                let v119 : string = v118 + v115 
                let v123 : string = v119 + v68 
                let v127 : (System.Text.StringBuilder -> string) = _.ToString()
                let v128 : string = v127 v1
                let v132 : string = v123 + v128 
                let v136 : string = v132 + v110 
                let v139 : int32 = v3 - 1
                let v140 : int32 = 0
                let v141 : (string -> string) = method29(v139, v140)
                let v142 : string = ""
                let v143 : string = v141 v142
                let v146 : string = "^"
                let v147 : string = v143 + v146 
                let v151 : string = v136 + v68 
                let v155 : string = v151 + v147 
                let v159 : string = v155 + v68 
                US8_1(v159)
    let v233 : US8 =
        match v164 with
        | US8_1(v230) -> (* Error *)
            US8_1(v230)
        | US8_0(v165, v166, v167, v168, v169) -> (* Ok *)
            let v170 : bool = "" = v166
            if v170 then
                let v171 : string = method41(v167, v168, v169)
                let v174 : string = "parsing.any_char / unexpected end of input / "
                let v175 : string = v174 + v171 
                US8_1(v175)
            else
                let v179 : char = v166.[int 0]
                let v181 : (string -> int32) = String.length
                let v182 : int32 = v181 v166
                let v190 : int32 = 1 |> int32 
                let v203 : int32 = v182 |> int32 
                let v211 : int32 = v203 - 1
                let v213 : string = v166.[int v190..int v211]
                let v218 : (char -> string) = _.ToString()
                let v219 : string = v218 v179
                let v222 : int64 = System.Convert.ToInt64 v219.Length
                let v223 : int64 = 0L
                let v224 : UH0 = method26(v222, v219, v223)
                let struct (v225 : System.Text.StringBuilder, v226 : int32, v227 : int32) = method27(v224, v167, v168, v169)
                US8_0(v179, v213, v225, v226, v227)
    match v233 with
    | US8_1(v251) -> (* Error *)
        US9_1(v251)
    | US8_0(v234, v235, v236, v237, v238) -> (* Ok *)
        let v240 : (char -> string) = _.ToString()
        let v241 : string = v240 '\\'
        let v245 : (char -> string) = _.ToString()
        let v246 : string = v245 v234
        let v249 : string = v241 + v246 
        US9_0(v249, v235, v236, v237, v238)
and closure29 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US9 =
    let v4 : bool = "" = v0
    let v164 : US8 =
        if v4 then
            let v5 : char = '`'
            let v6 : string = method25(v5, v1, v2, v3)
            let v9 : string = "parsing.p_char / unexpected end of input / "
            let v10 : string = v9 + v6 
            US8_1(v10)
        else
            let v14 : char = v0.[int 0]
            let v15 : bool = v14 = '`'
            if v15 then
                let v17 : (string -> int32) = String.length
                let v18 : int32 = v17 v0
                let v26 : int32 = 1 |> int32 
                let v39 : int32 = v18 |> int32 
                let v47 : int32 = v39 - 1
                let v49 : string = v0.[int v26..int v47]
                let v54 : (char -> string) = _.ToString()
                let v55 : string = v54 v14
                let v58 : int64 = System.Convert.ToInt64 v55.Length
                let v59 : int64 = 0L
                let v60 : UH0 = method26(v58, v55, v59)
                let struct (v61 : System.Text.StringBuilder, v62 : int32, v63 : int32) = method27(v60, v1, v2, v3)
                US8_0(v14, v49, v61, v62, v63)
            else
                let v68 : string = "\n"
                let v69 : int32 = v0.IndexOf v68 
                let v72 : int32 = v69 - 1
                let v73 : bool = -2 = v72
                let v81 : int32 =
                    if v73 then
                        let v75 : (string -> int32) = String.length
                        let v76 : int32 = v75 v0
                        let v79 : int32 = v76 + 1
                        v79
                    else
                        let v80 : int32 = v72 + 1
                        v80
                let v87 : int32 = 0 |> int32 
                let v100 : int32 = v81 |> int32 
                let v108 : int32 = v100 - 1
                let v110 : string = v0.[int v87..int v108]
                let v114 : char = '`'
                let v115 : string = method28(v114, v2, v3)
                let v118 : string = "parsing.p_char / "
                let v119 : string = v118 + v115 
                let v123 : string = v119 + v68 
                let v127 : (System.Text.StringBuilder -> string) = _.ToString()
                let v128 : string = v127 v1
                let v132 : string = v123 + v128 
                let v136 : string = v132 + v110 
                let v139 : int32 = v3 - 1
                let v140 : int32 = 0
                let v141 : (string -> string) = method29(v139, v140)
                let v142 : string = ""
                let v143 : string = v141 v142
                let v146 : string = "^"
                let v147 : string = v143 + v146 
                let v151 : string = v136 + v68 
                let v155 : string = v151 + v147 
                let v159 : string = v155 + v68 
                US8_1(v159)
    let v233 : US8 =
        match v164 with
        | US8_1(v230) -> (* Error *)
            US8_1(v230)
        | US8_0(v165, v166, v167, v168, v169) -> (* Ok *)
            let v170 : bool = "" = v166
            if v170 then
                let v171 : string = method41(v167, v168, v169)
                let v174 : string = "parsing.any_char / unexpected end of input / "
                let v175 : string = v174 + v171 
                US8_1(v175)
            else
                let v179 : char = v166.[int 0]
                let v181 : (string -> int32) = String.length
                let v182 : int32 = v181 v166
                let v190 : int32 = 1 |> int32 
                let v203 : int32 = v182 |> int32 
                let v211 : int32 = v203 - 1
                let v213 : string = v166.[int v190..int v211]
                let v218 : (char -> string) = _.ToString()
                let v219 : string = v218 v179
                let v222 : int64 = System.Convert.ToInt64 v219.Length
                let v223 : int64 = 0L
                let v224 : UH0 = method26(v222, v219, v223)
                let struct (v225 : System.Text.StringBuilder, v226 : int32, v227 : int32) = method27(v224, v167, v168, v169)
                US8_0(v179, v213, v225, v226, v227)
    match v233 with
    | US8_1(v251) -> (* Error *)
        US9_1(v251)
    | US8_0(v234, v235, v236, v237, v238) -> (* Ok *)
        let v240 : (char -> string) = _.ToString()
        let v241 : string = v240 '`'
        let v245 : (char -> string) = _.ToString()
        let v246 : string = v245 v234
        let v249 : string = v241 + v246 
        US9_0(v249, v235, v236, v237, v238)
and method71 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH3) : US9 =
    match v4 with
    | UH3_1(v7, v8) -> (* Cons *)
        let v9 : US9 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US9_1(v15) -> (* Error *)
            method71(v0, v1, v2, v3, v8)
        | US9_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH3_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US9_1(v5)
and method72 (v0 : UH2, v1 : UH2) : UH2 =
    match v0 with
    | UH2_1(v2, v3) -> (* Cons *)
        let v4 : UH2 = UH2_1(v2, v1)
        method72(v3, v4)
    | UH2_0 -> (* Nil *)
        v1
and method69 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US18 =
    let v5 : bool = "" = v1
    let v112 : US8 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = '"' :: v6 
            let v12 : char list = '`' :: v8 
            let v16 : char list = '\\' :: v12 
            let v20 : (char list -> (char [])) = List.toArray
            let v21 : (char []) = v20 v16
            let v24 : string = method31(v21, v2, v3, v4)
            let v27 : string = "parsing.none_of / unexpected end of input / "
            let v28 : string = v27 + v24 
            US8_1(v28)
        else
            let v32 : char = v1.[int 0]
            let v33 : int64 = 0L
            let v34 : bool = method70(v32, v33)
            let v35 : bool = v34 = false
            if v35 then
                let v37 : (string -> int32) = String.length
                let v38 : int32 = v37 v1
                let v46 : int32 = 1 |> int32 
                let v59 : int32 = v38 |> int32 
                let v67 : int32 = v59 - 1
                let v69 : string = v1.[int v46..int v67]
                let v74 : (char -> string) = _.ToString()
                let v75 : string = v74 v32
                let v78 : int64 = System.Convert.ToInt64 v75.Length
                let v79 : int64 = 0L
                let v80 : UH0 = method26(v78, v75, v79)
                let struct (v81 : System.Text.StringBuilder, v82 : int32, v83 : int32) = method27(v80, v2, v3, v4)
                US8_0(v32, v69, v81, v82, v83)
            else
                let v85 : char list = []
                let v87 : char list = '"' :: v85 
                let v91 : char list = '`' :: v87 
                let v95 : char list = '\\' :: v91 
                let v99 : (char list -> (char [])) = List.toArray
                let v100 : (char []) = v99 v95
                let v103 : string = method33(v32, v100, v2, v3, v4)
                let v106 : string = "parsing.none_of / unexpected char / "
                let v107 : string = v106 + v103 
                US8_1(v107)
    let v127 : US9 =
        match v112 with
        | US8_1(v124) -> (* Error *)
            US9_1(v124)
        | US8_0(v113, v114, v115, v116, v117) -> (* Ok *)
            let v119 : (char -> string) = _.ToString()
            let v120 : string = v119 v113
            US9_0(v120, v114, v115, v116, v117)
    let v141 : US9 =
        match v127 with
        | US9_1(v133) -> (* Error *)
            let v134 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US9) = closure28()
            let v135 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US9) = closure29()
            let v136 : UH3 = UH3_0
            let v137 : UH3 = UH3_1(v135, v136)
            let v138 : UH3 = UH3_1(v134, v137)
            method71(v1, v2, v3, v4, v138)
        | US9_0(v128, v129, v130, v131, v132) -> (* Ok *)
            v127
    match v141 with
    | US9_1(v149) -> (* Error *)
        let v150 : UH2 = UH2_0
        let v151 : UH2 = method72(v0, v150)
        US18_0(v151, v1, v2, v3, v4)
    | US9_0(v142, v143, v144, v145, v146) -> (* Ok *)
        let v147 : UH2 = UH2_1(v142, v0)
        method69(v147, v143, v144, v145, v146)
and method73 (v0 : UH2, v1 : string list) : string list =
    match v0 with
    | UH2_1(v2, v3) -> (* Cons *)
        let v4 : string list = method73(v3, v1)
        let v6 : string list = v2 :: v4 
        v6
    | UH2_0 -> (* Nil *)
        v1
and method74 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US18 =
    let v5 : bool = "" = v1
    let v112 : US8 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = '"' :: v6 
            let v12 : char list = '`' :: v8 
            let v16 : char list = '\\' :: v12 
            let v20 : (char list -> (char [])) = List.toArray
            let v21 : (char []) = v20 v16
            let v24 : string = method31(v21, v2, v3, v4)
            let v27 : string = "parsing.none_of / unexpected end of input / "
            let v28 : string = v27 + v24 
            US8_1(v28)
        else
            let v32 : char = v1.[int 0]
            let v33 : int64 = 0L
            let v34 : bool = method70(v32, v33)
            let v35 : bool = v34 = false
            if v35 then
                let v37 : (string -> int32) = String.length
                let v38 : int32 = v37 v1
                let v46 : int32 = 1 |> int32 
                let v59 : int32 = v38 |> int32 
                let v67 : int32 = v59 - 1
                let v69 : string = v1.[int v46..int v67]
                let v74 : (char -> string) = _.ToString()
                let v75 : string = v74 v32
                let v78 : int64 = System.Convert.ToInt64 v75.Length
                let v79 : int64 = 0L
                let v80 : UH0 = method26(v78, v75, v79)
                let struct (v81 : System.Text.StringBuilder, v82 : int32, v83 : int32) = method27(v80, v2, v3, v4)
                US8_0(v32, v69, v81, v82, v83)
            else
                let v85 : char list = []
                let v87 : char list = '"' :: v85 
                let v91 : char list = '`' :: v87 
                let v95 : char list = '\\' :: v91 
                let v99 : (char list -> (char [])) = List.toArray
                let v100 : (char []) = v99 v95
                let v103 : string = method33(v32, v100, v2, v3, v4)
                let v106 : string = "parsing.none_of / unexpected char / "
                let v107 : string = v106 + v103 
                US8_1(v107)
    let v127 : US9 =
        match v112 with
        | US8_1(v124) -> (* Error *)
            US9_1(v124)
        | US8_0(v113, v114, v115, v116, v117) -> (* Ok *)
            let v119 : (char -> string) = _.ToString()
            let v120 : string = v119 v113
            US9_0(v120, v114, v115, v116, v117)
    match v127 with
    | US9_1(v135) -> (* Error *)
        let v136 : UH2 = UH2_0
        let v137 : UH2 = method72(v0, v136)
        US18_0(v137, v1, v2, v3, v4)
    | US9_0(v128, v129, v130, v131, v132) -> (* Ok *)
        let v133 : UH2 = UH2_1(v128, v0)
        method74(v133, v129, v130, v131, v132)
and method66 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US18 =
    let v5 : bool = "" = v1
    let v120 : US8 =
        if v5 then
            let v6 : char list = []
            let v8 : char list = ' ' :: v6 
            let v12 : char list = '"' :: v8 
            let v16 : char list = '`' :: v12 
            let v20 : char list = '\\' :: v16 
            let v24 : (char list -> (char [])) = List.toArray
            let v25 : (char []) = v24 v20
            let v28 : string = method31(v25, v2, v3, v4)
            let v31 : string = "parsing.none_of / unexpected end of input / "
            let v32 : string = v31 + v28 
            US8_1(v32)
        else
            let v36 : char = v1.[int 0]
            let v37 : int64 = 0L
            let v38 : bool = method67(v36, v37)
            let v39 : bool = v38 = false
            if v39 then
                let v41 : (string -> int32) = String.length
                let v42 : int32 = v41 v1
                let v50 : int32 = 1 |> int32 
                let v63 : int32 = v42 |> int32 
                let v71 : int32 = v63 - 1
                let v73 : string = v1.[int v50..int v71]
                let v78 : (char -> string) = _.ToString()
                let v79 : string = v78 v36
                let v82 : int64 = System.Convert.ToInt64 v79.Length
                let v83 : int64 = 0L
                let v84 : UH0 = method26(v82, v79, v83)
                let struct (v85 : System.Text.StringBuilder, v86 : int32, v87 : int32) = method27(v84, v2, v3, v4)
                US8_0(v36, v73, v85, v86, v87)
            else
                let v89 : char list = []
                let v91 : char list = ' ' :: v89 
                let v95 : char list = '"' :: v91 
                let v99 : char list = '`' :: v95 
                let v103 : char list = '\\' :: v99 
                let v107 : (char list -> (char [])) = List.toArray
                let v108 : (char []) = v107 v103
                let v111 : string = method33(v36, v108, v2, v3, v4)
                let v114 : string = "parsing.none_of / unexpected char / "
                let v115 : string = v114 + v111 
                US8_1(v115)
    let v140 : US9 =
        match v120 with
        | US8_1(v137) -> (* Error *)
            US9_1(v137)
        | US8_0(v121, v122, v123, v124, v125) -> (* Ok *)
            let v127 : (char -> string) = _.ToString()
            let v128 : string = v127 v121
            let struct (v131 : string, v132 : string, v133 : System.Text.StringBuilder, v134 : int32, v135 : int32) = method68(v128, v122, v123, v124, v125)
            US9_0(v131, v132, v133, v134, v135)
    let v609 : US9 =
        match v140 with
        | US9_1(v146) -> (* Error *)
            let v306 : US8 =
                if v5 then
                    let v147 : char = '"'
                    let v148 : string = method25(v147, v2, v3, v4)
                    let v151 : string = "parsing.p_char / unexpected end of input / "
                    let v152 : string = v151 + v148 
                    US8_1(v152)
                else
                    let v156 : char = v1.[int 0]
                    let v157 : bool = v156 = '"'
                    if v157 then
                        let v159 : (string -> int32) = String.length
                        let v160 : int32 = v159 v1
                        let v168 : int32 = 1 |> int32 
                        let v181 : int32 = v160 |> int32 
                        let v189 : int32 = v181 - 1
                        let v191 : string = v1.[int v168..int v189]
                        let v196 : (char -> string) = _.ToString()
                        let v197 : string = v196 v156
                        let v200 : int64 = System.Convert.ToInt64 v197.Length
                        let v201 : int64 = 0L
                        let v202 : UH0 = method26(v200, v197, v201)
                        let struct (v203 : System.Text.StringBuilder, v204 : int32, v205 : int32) = method27(v202, v2, v3, v4)
                        US8_0(v156, v191, v203, v204, v205)
                    else
                        let v210 : string = "\n"
                        let v211 : int32 = v1.IndexOf v210 
                        let v214 : int32 = v211 - 1
                        let v215 : bool = -2 = v214
                        let v223 : int32 =
                            if v215 then
                                let v217 : (string -> int32) = String.length
                                let v218 : int32 = v217 v1
                                let v221 : int32 = v218 + 1
                                v221
                            else
                                let v222 : int32 = v214 + 1
                                v222
                        let v229 : int32 = 0 |> int32 
                        let v242 : int32 = v223 |> int32 
                        let v250 : int32 = v242 - 1
                        let v252 : string = v1.[int v229..int v250]
                        let v256 : char = '"'
                        let v257 : string = method28(v256, v3, v4)
                        let v260 : string = "parsing.p_char / "
                        let v261 : string = v260 + v257 
                        let v265 : string = v261 + v210 
                        let v269 : (System.Text.StringBuilder -> string) = _.ToString()
                        let v270 : string = v269 v2
                        let v274 : string = v265 + v270 
                        let v278 : string = v274 + v252 
                        let v281 : int32 = v4 - 1
                        let v282 : int32 = 0
                        let v283 : (string -> string) = method29(v281, v282)
                        let v284 : string = ""
                        let v285 : string = v283 v284
                        let v288 : string = "^"
                        let v289 : string = v285 + v288 
                        let v293 : string = v278 + v210 
                        let v297 : string = v293 + v289 
                        let v301 : string = v297 + v210 
                        US8_1(v301)
            let v538 : US9 =
                match v306 with
                | US8_1(v535) -> (* Error *)
                    US9_1(v535)
                | US8_0(v307, v308, v309, v310, v311) -> (* Ok *)
                    let v312 : UH2 = UH2_0
                    let v313 : US18 = method69(v312, v308, v309, v310, v311)
                    let v346 : US9 =
                        match v313 with
                        | US18_1(v343) -> (* Error *)
                            US9_1(v343)
                        | US18_0(v314, v315, v316, v317, v318) -> (* Ok *)
                            let v319 : string list = []
                            let v320 : string list = method73(v314, v319)
                            let v325 : unit = ()
                            let _let'_v325 =
                                seq {
                                    yield! v320 
                                    (* indent
                                    ()
                                indent *)
                                }
                                (* indent
                                ()
                            indent *)
                            let v328 : string seq = _let'_v325 
                            let v336 : (string -> (string seq -> string)) = String.concat
                            let v337 : string = ""
                            let v338 : (string seq -> string) = v336 v337
                            let v339 : string = v338 v328
                            US9_0(v339, v315, v316, v317, v318)
                    match v346 with
                    | US9_1(v530) -> (* Error *)
                        let v531 : string = "parsing.between / expected content"
                        US9_1(v531)
                    | US9_0(v347, v348, v349, v350, v351) -> (* Ok *)
                        let v352 : bool = "" = v348
                        let v512 : US8 =
                            if v352 then
                                let v353 : char = '"'
                                let v354 : string = method25(v353, v349, v350, v351)
                                let v357 : string = "parsing.p_char / unexpected end of input / "
                                let v358 : string = v357 + v354 
                                US8_1(v358)
                            else
                                let v362 : char = v348.[int 0]
                                let v363 : bool = v362 = '"'
                                if v363 then
                                    let v365 : (string -> int32) = String.length
                                    let v366 : int32 = v365 v348
                                    let v374 : int32 = 1 |> int32 
                                    let v387 : int32 = v366 |> int32 
                                    let v395 : int32 = v387 - 1
                                    let v397 : string = v348.[int v374..int v395]
                                    let v402 : (char -> string) = _.ToString()
                                    let v403 : string = v402 v362
                                    let v406 : int64 = System.Convert.ToInt64 v403.Length
                                    let v407 : int64 = 0L
                                    let v408 : UH0 = method26(v406, v403, v407)
                                    let struct (v409 : System.Text.StringBuilder, v410 : int32, v411 : int32) = method27(v408, v349, v350, v351)
                                    US8_0(v362, v397, v409, v410, v411)
                                else
                                    let v416 : string = "\n"
                                    let v417 : int32 = v348.IndexOf v416 
                                    let v420 : int32 = v417 - 1
                                    let v421 : bool = -2 = v420
                                    let v429 : int32 =
                                        if v421 then
                                            let v423 : (string -> int32) = String.length
                                            let v424 : int32 = v423 v348
                                            let v427 : int32 = v424 + 1
                                            v427
                                        else
                                            let v428 : int32 = v420 + 1
                                            v428
                                    let v435 : int32 = 0 |> int32 
                                    let v448 : int32 = v429 |> int32 
                                    let v456 : int32 = v448 - 1
                                    let v458 : string = v348.[int v435..int v456]
                                    let v462 : char = '"'
                                    let v463 : string = method28(v462, v350, v351)
                                    let v466 : string = "parsing.p_char / "
                                    let v467 : string = v466 + v463 
                                    let v471 : string = v467 + v416 
                                    let v475 : (System.Text.StringBuilder -> string) = _.ToString()
                                    let v476 : string = v475 v349
                                    let v480 : string = v471 + v476 
                                    let v484 : string = v480 + v458 
                                    let v487 : int32 = v351 - 1
                                    let v488 : int32 = 0
                                    let v489 : (string -> string) = method29(v487, v488)
                                    let v490 : string = ""
                                    let v491 : string = v489 v490
                                    let v494 : string = "^"
                                    let v495 : string = v491 + v494 
                                    let v499 : string = v484 + v416 
                                    let v503 : string = v499 + v495 
                                    let v507 : string = v503 + v416 
                                    US8_1(v507)
                        match v512 with
                        | US8_1(v519) -> (* Error *)
                            let v520 : string = method36(v519, v1, v2, v3, v4, v308, v309, v310, v311, v348, v349, v350, v351)
                            let v523 : string = "parsing.between / expected closing delimiter / "
                            let v524 : string = v523 + v520 
                            US9_1(v524)
                        | US8_0(v513, v514, v515, v516, v517) -> (* Ok *)
                            US9_0(v347, v514, v515, v516, v517)
            match v538 with
            | US9_1(v544) -> (* Error *)
                let v545 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US9) = closure28()
                let v546 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US9) = closure29()
                let v547 : UH3 = UH3_0
                let v548 : UH3 = UH3_1(v546, v547)
                let v549 : UH3 = UH3_1(v545, v548)
                let v550 : US9 = method71(v1, v2, v3, v4, v549)
                let v561 : US9 =
                    match v550 with
                    | US9_1(v558) -> (* Error *)
                        US9_1(v558)
                    | US9_0(v551, v552, v553, v554, v555) -> (* Ok *)
                        let v556 : string = ""
                        US9_0(v556, v552, v553, v554, v555)
                let v572 : US18 =
                    match v561 with
                    | US9_1(v569) -> (* Error *)
                        US18_1(v569)
                    | US9_0(v562, v563, v564, v565, v566) -> (* Ok *)
                        let v567 : UH2 = UH2_0
                        method74(v567, v563, v564, v565, v566)
                match v572 with
                | US18_1(v602) -> (* Error *)
                    US9_1(v602)
                | US18_0(v573, v574, v575, v576, v577) -> (* Ok *)
                    let v578 : string list = []
                    let v579 : string list = method73(v573, v578)
                    let v584 : unit = ()
                    let _let'_v584 =
                        seq {
                            yield! v579 
                            (* indent
                            ()
                        indent *)
                        }
                        (* indent
                        ()
                    indent *)
                    let v587 : string seq = _let'_v584 
                    let v595 : (string -> (string seq -> string)) = String.concat
                    let v596 : string = ""
                    let v597 : (string seq -> string) = v595 v596
                    let v598 : string = v597 v587
                    US9_0(v598, v574, v575, v576, v577)
            | US9_0(v539, v540, v541, v542, v543) -> (* Ok *)
                v538
        | US9_0(v141, v142, v143, v144, v145) -> (* Ok *)
            v140
    match v609 with
    | US9_1(v672) -> (* Error *)
        let v673 : UH2 = UH2_0
        let v674 : UH2 = method72(v0, v673)
        US18_0(v674, v1, v2, v3, v4)
    | US9_0(v610, v611, v612, v613, v614) -> (* Ok *)
        let v615 : int32 = 0
        let v616 : int32 = method40(v611, v615)
        let v617 : bool = 0 = v616
        let v658 : US11 =
            if v617 then
                let v618 : string = "parsing.spaces1 / expected at least one space"
                US11_1(v618)
            else
                let v621 : (string -> int32) = String.length
                let v622 : int32 = v621 v611
                let v630 : int32 = v616 |> int32 
                let v643 : int32 = v622 |> int32 
                let v651 : int32 = v643 - 1
                let v653 : string = v611.[int v630..int v651]
                US11_0(v653, v612, v613, v614)
        match v658 with
        | US11_1(v665) -> (* Error *)
            let v666 : UH2 = UH2_0
            let v667 : UH2 = UH2_1(v610, v666)
            let v668 : UH2 = method72(v0, v667)
            US18_0(v668, v611, v612, v613, v614)
        | US11_0(v659, v660, v661, v662) -> (* Ok *)
            let v663 : UH2 = UH2_1(v610, v0)
            method66(v663, v659, v660, v661, v662)
and method65 (v0 : string) : US17 =
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
    let v22 : US18 = method66(v19, v10, v16, v20, v21)
    match v22 with
    | US18_1(v36) -> (* Error *)
        US17_1(v36)
    | US18_0(v23, v24, v25, v26, v27) -> (* Ok *)
        let v28 : string list = []
        let v29 : string list = method73(v23, v28)
        let v31 : (string list -> (string [])) = List.toArray
        let v32 : (string []) = v31 v29
        US17_0(v32)
and closure27 () (v0 : string) : Result<(string []), string> =
    let v1 : US17 = method65(v0)
    match v1 with
    | US17_1(v7) -> (* Error *)
        let v9 : Result<(string []), string> = Error v7 
        v9
    | US17_0(v2) -> (* Ok *)
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
