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
and Mut5 = {mutable l0 : int32}
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
    let v51 : (string -> US5) = method5()
    let v52 : US5 option = v47 |> Option.map v51 
    let v65 : US5 = US5_1
    let v66 : US5 = v52 |> Option.defaultValue v65 
    let v73 : string =
        match v66 with
        | US5_1 -> (* None *)
            let v71 : string = ""
            v71
        | US5_0(v70) -> (* Some *)
            v70
    let _run_target_args'_v5 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v74 : US3 = US3_1
    let v75 : US4 = US4_1(v74)
    let v76 : string = $"env.get_environment_variable / target: {v75} / var: {v0}"
    let v77 : string = failwith<string> v76
    let _run_target_args'_v5 = v77 
    #endif
#else
    let v78 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v79 : string = v78 v0
    let mutable _v79 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v81 : (string -> string option) = Option.ofObj
    let v82 : string option = v81 v79
    v82 
    #else
    Some v79 
    #endif
    |> fun x -> _v79 <- Some x
    let v83 : string option = match _v79 with Some x -> x | None -> failwith "optionm'.of_obj / _v79=None"
    let v87 : (string -> US5) = method5()
    let v88 : US5 option = v83 |> Option.map v87 
    let v101 : US5 = US5_1
    let v102 : US5 = v88 |> Option.defaultValue v101 
    let v109 : string =
        match v102 with
        | US5_1 -> (* None *)
            let v107 : string = ""
            v107
        | US5_0(v106) -> (* Some *)
            v106
    let _run_target_args'_v5 = v109 
    #endif
    let v110 : string = _run_target_args'_v5 
    v110
and method1 () : struct (US1 * US2) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method2(v0)
    
    
    
    
    
    let v2 : bool = "Verbose" = v1
    let v6 : US1 =
        if v2 then
            let v3 : US0 = US0_0
            US1_0(v3)
        else
            US1_1
    let v47 : US1 =
        match v6 with
        | US1_1 -> (* None *)
            let v9 : bool = "Debug" = v1
            let v13 : US1 =
                if v9 then
                    let v10 : US0 = US0_1
                    US1_0(v10)
                else
                    US1_1
            match v13 with
            | US1_1 -> (* None *)
                let v16 : bool = "Info" = v1
                let v20 : US1 =
                    if v16 then
                        let v17 : US0 = US0_2
                        US1_0(v17)
                    else
                        US1_1
                match v20 with
                | US1_1 -> (* None *)
                    let v23 : bool = "Warning" = v1
                    let v27 : US1 =
                        if v23 then
                            let v24 : US0 = US0_3
                            US1_0(v24)
                        else
                            US1_1
                    match v27 with
                    | US1_1 -> (* None *)
                        let v30 : bool = "Critical" = v1
                        let v34 : US1 =
                            if v30 then
                                let v31 : US0 = US0_4
                                US1_0(v31)
                            else
                                US1_1
                        match v34 with
                        | US1_1 -> (* None *)
                            US1_1
                        | US1_0(v35) -> (* Some *)
                            US1_0(v35)
                    | US1_0(v28) -> (* Some *)
                        US1_0(v28)
                | US1_0(v21) -> (* Some *)
                    US1_0(v21)
            | US1_0(v14) -> (* Some *)
                US1_0(v14)
        | US1_0(v7) -> (* Some *)
            US1_0(v7)
    let v48 : string = "AUTOMATION"
    let v49 : string = method2(v48)
    let v52 : string = "True"
    let v53 : bool = v49 <> v52 
    let v120 : US2 =
        if v53 then
            US2_1
        else
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v66 
            #endif
#if FABLE_COMPILER_PYTHON
            let v67 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v67 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v68 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v68 
            #endif
#else
            let v69 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v69 
            #endif
            let v70 : System.DateTime = _run_target_args'_v59 
            (* run_target_args'
            let v78 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v79 : (System.DateTime -> int64) = _.Ticks
            let v80 : int64 = v79 v70
            let _run_target_args'_v78 = v80 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v81 : (System.DateTime -> int64) = _.Ticks
            let v82 : int64 = v81 v70
            let _run_target_args'_v78 = v82 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v84 : int64 = null |> unbox<int64>
            let _run_target_args'_v78 = v84 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v87 : (System.DateTime -> int64) = _.Ticks
            let v88 : int64 = v87 v70
            let _run_target_args'_v78 = v88 
            #endif
#if FABLE_COMPILER_PYTHON
            let v89 : (System.DateTime -> int64) = _.Ticks
            let v90 : int64 = v89 v70
            let _run_target_args'_v78 = v90 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v91 : (System.DateTime -> int64) = _.Ticks
            let v92 : int64 = v91 v70
            let _run_target_args'_v78 = v92 
            #endif
#else
            let v93 : (System.DateTime -> int64) = _.Ticks
            let v94 : int64 = v93 v70
            let _run_target_args'_v78 = v94 
            #endif
            let v95 : int64 = _run_target_args'_v78 
            let v116 : int64 = v95 |> int64 
            US2_0(v116)
    struct (v47, v120)
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
    let v195 : int64 option =
        match v173 with
        | US2_1 -> (* None *)
            let v193 : int64 option = None
            v193
        | US2_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v195)
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
    let v165 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v167 : (int64 -> US2) = method9()
    let v168 : US2 option = v5 |> Option.map v167 
    let v181 : US2 = US2_1
    let v182 : US2 = v168 |> Option.defaultValue v181 
    let v300 : System.DateTime =
        match v182 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v283 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v284 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v284 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v285 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v285 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v287 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v283 = v287 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v290 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v290 
            #endif
#if FABLE_COMPILER_PYTHON
            let v291 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v291 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v292 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v292 
            #endif
#else
            let v293 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v283 = v293 
            #endif
            let v294 : System.DateTime = _run_target_args'_v283 
            v294
        | US2_0(v186) -> (* Some *)
            (* run_target_args'
            let v189 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v190 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v190 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v191 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v191 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v189 = v193 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v196 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v196 
            #endif
#if FABLE_COMPILER_PYTHON
            let v197 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v197 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v198 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v198 
            #endif
#else
            let v199 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v189 = v199 
            #endif
            let v200 : System.DateTime = _run_target_args'_v189 
            (* run_target_args'
            let v208 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v209 : (System.DateTime -> int64) = _.Ticks
            let v210 : int64 = v209 v200
            let _run_target_args'_v208 = v210 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v211 : (System.DateTime -> int64) = _.Ticks
            let v212 : int64 = v211 v200
            let _run_target_args'_v208 = v212 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v214 : int64 = null |> unbox<int64>
            let _run_target_args'_v208 = v214 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v217 : (System.DateTime -> int64) = _.Ticks
            let v218 : int64 = v217 v200
            let _run_target_args'_v208 = v218 
            #endif
#if FABLE_COMPILER_PYTHON
            let v219 : (System.DateTime -> int64) = _.Ticks
            let v220 : int64 = v219 v200
            let _run_target_args'_v208 = v220 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v221 : (System.DateTime -> int64) = _.Ticks
            let v222 : int64 = v221 v200
            let _run_target_args'_v208 = v222 
            #endif
#else
            let v223 : (System.DateTime -> int64) = _.Ticks
            let v224 : int64 = v223 v200
            let _run_target_args'_v208 = v224 
            #endif
            let v225 : int64 = _run_target_args'_v208 
            let v246 : int64 = v225 |> int64 
            let v249 : int64 = v246 - v186
            let v252 : System.TimeSpan = v249 |> System.TimeSpan 
            let v258 : (System.TimeSpan -> int32) = _.Hours
            let v259 : int32 = v258 v252
            let v263 : (System.TimeSpan -> int32) = _.Minutes
            let v264 : int32 = v263 v252
            let v268 : (System.TimeSpan -> int32) = _.Seconds
            let v269 : int32 = v268 v252
            let v273 : (System.TimeSpan -> int32) = _.Milliseconds
            let v274 : int32 = v273 v252
            let v278 : System.DateTime = System.DateTime (1, 1, 1, v259, v264, v269, v274)
            v278
    let v302 : string = method10()
    let v306 : bool = v302 = ""
    let v308 : string =
        if v306 then
            let v307 : string = "M-d-y hh:mm:ss tt"
            v307
        else
            v302
    let v309 : (string -> string) = v300.ToString
    let v310 : string = v309 v308
    let _run_target_args'_v165 = v310 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v326 : (int64 -> US2) = method9()
    let v327 : US2 option = v5 |> Option.map v326 
    let v340 : US2 = US2_1
    let v341 : US2 = v327 |> Option.defaultValue v340 
    let v459 : System.DateTime =
        match v341 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v442 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v443 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v443 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v444 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v444 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v446 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v442 = v446 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v449 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v449 
            #endif
#if FABLE_COMPILER_PYTHON
            let v450 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v450 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v451 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v451 
            #endif
#else
            let v452 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v442 = v452 
            #endif
            let v453 : System.DateTime = _run_target_args'_v442 
            v453
        | US2_0(v345) -> (* Some *)
            (* run_target_args'
            let v348 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v349 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v349 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v350 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v350 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v352 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v348 = v352 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v355 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v355 
            #endif
#if FABLE_COMPILER_PYTHON
            let v356 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v356 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v357 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v357 
            #endif
#else
            let v358 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v348 = v358 
            #endif
            let v359 : System.DateTime = _run_target_args'_v348 
            (* run_target_args'
            let v367 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v368 : (System.DateTime -> int64) = _.Ticks
            let v369 : int64 = v368 v359
            let _run_target_args'_v367 = v369 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v370 : (System.DateTime -> int64) = _.Ticks
            let v371 : int64 = v370 v359
            let _run_target_args'_v367 = v371 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v373 : int64 = null |> unbox<int64>
            let _run_target_args'_v367 = v373 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v376 : (System.DateTime -> int64) = _.Ticks
            let v377 : int64 = v376 v359
            let _run_target_args'_v367 = v377 
            #endif
#if FABLE_COMPILER_PYTHON
            let v378 : (System.DateTime -> int64) = _.Ticks
            let v379 : int64 = v378 v359
            let _run_target_args'_v367 = v379 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v380 : (System.DateTime -> int64) = _.Ticks
            let v381 : int64 = v380 v359
            let _run_target_args'_v367 = v381 
            #endif
#else
            let v382 : (System.DateTime -> int64) = _.Ticks
            let v383 : int64 = v382 v359
            let _run_target_args'_v367 = v383 
            #endif
            let v384 : int64 = _run_target_args'_v367 
            let v405 : int64 = v384 |> int64 
            let v408 : int64 = v405 - v345
            let v411 : System.TimeSpan = v408 |> System.TimeSpan 
            let v417 : (System.TimeSpan -> int32) = _.Hours
            let v418 : int32 = v417 v411
            let v422 : (System.TimeSpan -> int32) = _.Minutes
            let v423 : int32 = v422 v411
            let v427 : (System.TimeSpan -> int32) = _.Seconds
            let v428 : int32 = v427 v411
            let v432 : (System.TimeSpan -> int32) = _.Milliseconds
            let v433 : int32 = v432 v411
            let v437 : System.DateTime = System.DateTime (1, 1, 1, v418, v423, v428, v433)
            v437
    let v461 : string = method10()
    let v465 : bool = v461 = ""
    let v467 : string =
        if v465 then
            let v466 : string = "M-d-y hh:mm:ss tt"
            v466
        else
            v461
    let v468 : (string -> string) = v459.ToString
    let v469 : string = v468 v467
    let _run_target_args'_v165 = v469 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v484 : string = $"near_sdk::env::block_timestamp()"
    let v485 : uint64 = Fable.Core.RustInterop.emitRustExpr () v484 
    let v487 : (int64 -> US2) = method9()
    let v488 : US2 option = v5 |> Option.map v487 
    let v501 : US2 = US2_1
    let v502 : US2 = v488 |> Option.defaultValue v501 
    let v514 : uint64 =
        match v502 with
        | US2_1 -> (* None *)
            v485
        | US2_0(v506) -> (* Some *)
            let v508 : (int64 -> uint64) = uint64
            let v509 : uint64 = v508 v506
            let v512 : uint64 = v485 - v509
            v512
    let v515 : uint64 = v514 / 1000000000UL
    let v516 : uint64 = v515 % 60UL
    let v517 : uint64 = v515 / 60UL
    let v518 : uint64 = v517 % 60UL
    let v519 : uint64 = v515 / 3600UL
    let v520 : uint64 = v519 % 24UL
    let v521 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v522 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v520, v518, v516) v521 
    let v523 : string = "fable_library_rust::String_::fromString($0)"
    let v524 : string = Fable.Core.RustInterop.emitRustExpr v522 v523 
    let _run_target_args'_v165 = v524 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v526 : (int64 -> US2) = method9()
    let v527 : US2 option = v5 |> Option.map v526 
    let v540 : US2 = US2_1
    let v541 : US2 = v527 |> Option.defaultValue v540 
    let v659 : System.DateTime =
        match v541 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v642 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v643 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v643 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v644 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v644 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v646 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v642 = v646 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v649 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v649 
            #endif
#if FABLE_COMPILER_PYTHON
            let v650 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v650 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v651 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v651 
            #endif
#else
            let v652 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v642 = v652 
            #endif
            let v653 : System.DateTime = _run_target_args'_v642 
            v653
        | US2_0(v545) -> (* Some *)
            (* run_target_args'
            let v548 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v549 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v549 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v550 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v550 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v552 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v548 = v552 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v555 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v555 
            #endif
#if FABLE_COMPILER_PYTHON
            let v556 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v556 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v557 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v557 
            #endif
#else
            let v558 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v548 = v558 
            #endif
            let v559 : System.DateTime = _run_target_args'_v548 
            (* run_target_args'
            let v567 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v568 : (System.DateTime -> int64) = _.Ticks
            let v569 : int64 = v568 v559
            let _run_target_args'_v567 = v569 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v570 : (System.DateTime -> int64) = _.Ticks
            let v571 : int64 = v570 v559
            let _run_target_args'_v567 = v571 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v573 : int64 = null |> unbox<int64>
            let _run_target_args'_v567 = v573 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v576 : (System.DateTime -> int64) = _.Ticks
            let v577 : int64 = v576 v559
            let _run_target_args'_v567 = v577 
            #endif
#if FABLE_COMPILER_PYTHON
            let v578 : (System.DateTime -> int64) = _.Ticks
            let v579 : int64 = v578 v559
            let _run_target_args'_v567 = v579 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v580 : (System.DateTime -> int64) = _.Ticks
            let v581 : int64 = v580 v559
            let _run_target_args'_v567 = v581 
            #endif
#else
            let v582 : (System.DateTime -> int64) = _.Ticks
            let v583 : int64 = v582 v559
            let _run_target_args'_v567 = v583 
            #endif
            let v584 : int64 = _run_target_args'_v567 
            let v605 : int64 = v584 |> int64 
            let v608 : int64 = v605 - v545
            let v611 : System.TimeSpan = v608 |> System.TimeSpan 
            let v617 : (System.TimeSpan -> int32) = _.Hours
            let v618 : int32 = v617 v611
            let v622 : (System.TimeSpan -> int32) = _.Minutes
            let v623 : int32 = v622 v611
            let v627 : (System.TimeSpan -> int32) = _.Seconds
            let v628 : int32 = v627 v611
            let v632 : (System.TimeSpan -> int32) = _.Milliseconds
            let v633 : int32 = v632 v611
            let v637 : System.DateTime = System.DateTime (1, 1, 1, v618, v623, v628, v633)
            v637
    let v661 : string = method11()
    let v665 : bool = v661 = ""
    let v667 : string =
        if v665 then
            let v666 : string = "M-d-y hh:mm:ss tt"
            v666
        else
            v661
    let v668 : (string -> string) = v659.ToString
    let v669 : string = v668 v667
    let _run_target_args'_v165 = v669 
    #endif
#if FABLE_COMPILER_PYTHON
    let v685 : (int64 -> US2) = method9()
    let v686 : US2 option = v5 |> Option.map v685 
    let v699 : US2 = US2_1
    let v700 : US2 = v686 |> Option.defaultValue v699 
    let v818 : System.DateTime =
        match v700 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v801 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v802 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v802 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v803 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v803 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v805 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v801 = v805 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v808 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v808 
            #endif
#if FABLE_COMPILER_PYTHON
            let v809 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v809 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v810 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v810 
            #endif
#else
            let v811 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v801 = v811 
            #endif
            let v812 : System.DateTime = _run_target_args'_v801 
            v812
        | US2_0(v704) -> (* Some *)
            (* run_target_args'
            let v707 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v708 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v708 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v709 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v709 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v711 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v707 = v711 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v714 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v714 
            #endif
#if FABLE_COMPILER_PYTHON
            let v715 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v715 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v716 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v716 
            #endif
#else
            let v717 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v707 = v717 
            #endif
            let v718 : System.DateTime = _run_target_args'_v707 
            (* run_target_args'
            let v726 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v727 : (System.DateTime -> int64) = _.Ticks
            let v728 : int64 = v727 v718
            let _run_target_args'_v726 = v728 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v729 : (System.DateTime -> int64) = _.Ticks
            let v730 : int64 = v729 v718
            let _run_target_args'_v726 = v730 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v732 : int64 = null |> unbox<int64>
            let _run_target_args'_v726 = v732 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v735 : (System.DateTime -> int64) = _.Ticks
            let v736 : int64 = v735 v718
            let _run_target_args'_v726 = v736 
            #endif
#if FABLE_COMPILER_PYTHON
            let v737 : (System.DateTime -> int64) = _.Ticks
            let v738 : int64 = v737 v718
            let _run_target_args'_v726 = v738 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v739 : (System.DateTime -> int64) = _.Ticks
            let v740 : int64 = v739 v718
            let _run_target_args'_v726 = v740 
            #endif
#else
            let v741 : (System.DateTime -> int64) = _.Ticks
            let v742 : int64 = v741 v718
            let _run_target_args'_v726 = v742 
            #endif
            let v743 : int64 = _run_target_args'_v726 
            let v764 : int64 = v743 |> int64 
            let v767 : int64 = v764 - v704
            let v770 : System.TimeSpan = v767 |> System.TimeSpan 
            let v776 : (System.TimeSpan -> int32) = _.Hours
            let v777 : int32 = v776 v770
            let v781 : (System.TimeSpan -> int32) = _.Minutes
            let v782 : int32 = v781 v770
            let v786 : (System.TimeSpan -> int32) = _.Seconds
            let v787 : int32 = v786 v770
            let v791 : (System.TimeSpan -> int32) = _.Milliseconds
            let v792 : int32 = v791 v770
            let v796 : System.DateTime = System.DateTime (1, 1, 1, v777, v782, v787, v792)
            v796
    let v820 : string = method11()
    let v824 : bool = v820 = ""
    let v826 : string =
        if v824 then
            let v825 : string = "M-d-y hh:mm:ss tt"
            v825
        else
            v820
    let v827 : (string -> string) = v818.ToString
    let v828 : string = v827 v826
    let _run_target_args'_v165 = v828 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v844 : (int64 -> US2) = method9()
    let v845 : US2 option = v5 |> Option.map v844 
    let v858 : US2 = US2_1
    let v859 : US2 = v845 |> Option.defaultValue v858 
    let v977 : System.DateTime =
        match v859 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v960 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v961 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v961 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v962 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v962 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v964 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v960 = v964 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v967 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v967 
            #endif
#if FABLE_COMPILER_PYTHON
            let v968 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v968 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v969 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v969 
            #endif
#else
            let v970 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v960 = v970 
            #endif
            let v971 : System.DateTime = _run_target_args'_v960 
            v971
        | US2_0(v863) -> (* Some *)
            (* run_target_args'
            let v866 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v867 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v867 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v868 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v868 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v870 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v866 = v870 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v873 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v873 
            #endif
#if FABLE_COMPILER_PYTHON
            let v874 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v874 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v875 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v875 
            #endif
#else
            let v876 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v866 = v876 
            #endif
            let v877 : System.DateTime = _run_target_args'_v866 
            (* run_target_args'
            let v885 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v886 : (System.DateTime -> int64) = _.Ticks
            let v887 : int64 = v886 v877
            let _run_target_args'_v885 = v887 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v888 : (System.DateTime -> int64) = _.Ticks
            let v889 : int64 = v888 v877
            let _run_target_args'_v885 = v889 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v891 : int64 = null |> unbox<int64>
            let _run_target_args'_v885 = v891 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v894 : (System.DateTime -> int64) = _.Ticks
            let v895 : int64 = v894 v877
            let _run_target_args'_v885 = v895 
            #endif
#if FABLE_COMPILER_PYTHON
            let v896 : (System.DateTime -> int64) = _.Ticks
            let v897 : int64 = v896 v877
            let _run_target_args'_v885 = v897 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v898 : (System.DateTime -> int64) = _.Ticks
            let v899 : int64 = v898 v877
            let _run_target_args'_v885 = v899 
            #endif
#else
            let v900 : (System.DateTime -> int64) = _.Ticks
            let v901 : int64 = v900 v877
            let _run_target_args'_v885 = v901 
            #endif
            let v902 : int64 = _run_target_args'_v885 
            let v923 : int64 = v902 |> int64 
            let v926 : int64 = v923 - v863
            let v929 : System.TimeSpan = v926 |> System.TimeSpan 
            let v935 : (System.TimeSpan -> int32) = _.Hours
            let v936 : int32 = v935 v929
            let v940 : (System.TimeSpan -> int32) = _.Minutes
            let v941 : int32 = v940 v929
            let v945 : (System.TimeSpan -> int32) = _.Seconds
            let v946 : int32 = v945 v929
            let v950 : (System.TimeSpan -> int32) = _.Milliseconds
            let v951 : int32 = v950 v929
            let v955 : System.DateTime = System.DateTime (1, 1, 1, v936, v941, v946, v951)
            v955
    let v979 : string = method11()
    let v983 : bool = v979 = ""
    let v985 : string =
        if v983 then
            let v984 : string = "M-d-y hh:mm:ss tt"
            v984
        else
            v979
    let v986 : (string -> string) = v977.ToString
    let v987 : string = v986 v985
    let _run_target_args'_v165 = v987 
    #endif
#else
    let v1003 : (int64 -> US2) = method9()
    let v1004 : US2 option = v5 |> Option.map v1003 
    let v1017 : US2 = US2_1
    let v1018 : US2 = v1004 |> Option.defaultValue v1017 
    let v1136 : System.DateTime =
        match v1018 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1119 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1120 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1120 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1121 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1121 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1123 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1119 = v1123 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1126 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1126 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1127 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1127 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1128 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1128 
            #endif
#else
            let v1129 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1119 = v1129 
            #endif
            let v1130 : System.DateTime = _run_target_args'_v1119 
            v1130
        | US2_0(v1022) -> (* Some *)
            (* run_target_args'
            let v1025 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1026 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1026 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1027 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1027 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1029 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1025 = v1029 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1032 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1032 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1033 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1033 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1034 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1034 
            #endif
#else
            let v1035 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1025 = v1035 
            #endif
            let v1036 : System.DateTime = _run_target_args'_v1025 
            (* run_target_args'
            let v1044 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1045 : (System.DateTime -> int64) = _.Ticks
            let v1046 : int64 = v1045 v1036
            let _run_target_args'_v1044 = v1046 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1047 : (System.DateTime -> int64) = _.Ticks
            let v1048 : int64 = v1047 v1036
            let _run_target_args'_v1044 = v1048 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1050 : int64 = null |> unbox<int64>
            let _run_target_args'_v1044 = v1050 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1053 : (System.DateTime -> int64) = _.Ticks
            let v1054 : int64 = v1053 v1036
            let _run_target_args'_v1044 = v1054 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1055 : (System.DateTime -> int64) = _.Ticks
            let v1056 : int64 = v1055 v1036
            let _run_target_args'_v1044 = v1056 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1057 : (System.DateTime -> int64) = _.Ticks
            let v1058 : int64 = v1057 v1036
            let _run_target_args'_v1044 = v1058 
            #endif
#else
            let v1059 : (System.DateTime -> int64) = _.Ticks
            let v1060 : int64 = v1059 v1036
            let _run_target_args'_v1044 = v1060 
            #endif
            let v1061 : int64 = _run_target_args'_v1044 
            let v1082 : int64 = v1061 |> int64 
            let v1085 : int64 = v1082 - v1022
            let v1088 : System.TimeSpan = v1085 |> System.TimeSpan 
            let v1094 : (System.TimeSpan -> int32) = _.Hours
            let v1095 : int32 = v1094 v1088
            let v1099 : (System.TimeSpan -> int32) = _.Minutes
            let v1100 : int32 = v1099 v1088
            let v1104 : (System.TimeSpan -> int32) = _.Seconds
            let v1105 : int32 = v1104 v1088
            let v1109 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1110 : int32 = v1109 v1088
            let v1114 : System.DateTime = System.DateTime (1, 1, 1, v1095, v1100, v1105, v1110)
            v1114
    let v1138 : string = method11()
    let v1142 : bool = v1138 = ""
    let v1144 : string =
        if v1142 then
            let v1143 : string = "M-d-y hh:mm:ss tt"
            v1143
        else
            v1138
    let v1145 : (string -> string) = v1136.ToString
    let v1146 : string = v1145 v1144
    let _run_target_args'_v165 = v1146 
    #endif
    let v1161 : string = _run_target_args'_v165 
    v1161
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
    
    
    
    
    
    let v1 : string = "Warning"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method13(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_yellow"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
    (* run_target_args'
    let v19 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v20 : string = "&*$0"
    let v21 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v20 
    let _run_target_args'_v19 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : string = "&*$0"
    let v23 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v22 
    let _run_target_args'_v19 = v23 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v24 : string = "&*$0"
    let v25 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v24 
    let _run_target_args'_v19 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v27 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_yellow"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_yellow"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[93m"
    let v137 : string = method15()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[93m"
    let v141 : string = method15()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[93m"
    let v145 : string = method15()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[93m"
    let v149 : string = method15()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
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
    let v37 : char list = []
    let v39 : char list = '/' :: v37 
    let v43 : char list = ' ' :: v39 
    let v48 : (char list -> (char [])) = List.toArray
    let v49 : (char []) = v48 v43
    let v52 : string = v8.TrimEnd v49 
    v52
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
and method27 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and closure16 (v0 : char) (v1 : UH0) : UH0 =
    UH0_1(v0, v1)
and closure15 () (v0 : char) : (UH0 -> UH0) =
    closure16(v0)
and method28 () : (char -> (UH0 -> UH0)) =
    closure15()
and method29 (v0 : UH0, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : struct (System.Text.StringBuilder * int32 * int32) =
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
        method29(v5, v27, v9, v10)
    | UH0_0 -> (* Nil *)
        struct (v1, v2, v3)
and closure17 (v0 : int32, v1 : int32) (v2 : string) : string =
    let v3 : bool = v1 >= v0
    if v3 then
        v2
    else
        let v4 : int32 = v1 + 1
        let v5 : (string -> string) = method30(v0, v4)
        let v6 : string = " "
        let v7 : string = v2 + v6 
        v5 v7
and method30 (v0 : int32, v1 : int32) : (string -> string) =
    closure17(v0, v1)
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
            let v54 : int32 = v51.Length
            let v55 : (char []) = Array.zeroCreate<char> (v54)
            let v56 : Mut5 = {l0 = 0} : Mut5
            while method27(v54, v56) do
                let v58 : int32 = v56.l0
                let v59 : char = v51.[int v58]
                v55.[int v58] <- v59
                let v60 : int32 = v58 + 1
                v56.l0 <- v60
                ()
            let v62 : char list = v55 |> Array.toList
            let v66 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
            let v67 : (char -> (UH0 -> UH0)) = method28()
            let v68 : (char list -> (UH0 -> UH0)) = v66 v67
            let v69 : (UH0 -> UH0) = v68 v62
            let v70 : UH0 = UH0_0
            let v71 : UH0 = v69 v70
            let struct (v96 : System.Text.StringBuilder, v97 : int32, v98 : int32) = method29(v71, v1, v2, v3)
            US7_0(v10, v45, v96, v97, v98)
        else
            let v101 : string = "\n"
            let v102 : int32 = v0.IndexOf v101 
            let v105 : int32 = v102 - 1
            let v106 : bool = -2 = v105
            let v114 : int32 =
                if v106 then
                    let v108 : (string -> int32) = String.length
                    let v109 : int32 = v108 v0
                    let v112 : int32 = v109 + 1
                    v112
                else
                    let v113 : int32 = v105 + 1
                    v113
            let v120 : int32 = 0 |> int32 
            let v133 : int32 = v114 |> int32 
            let v141 : int32 = v133 - 1
            let v143 : string = v0.[int v120..int v141]
            let v148 : string = $"parsing.p_char / expected: '{'"'}' / line: {v2} / col: {v3}
{v1}{v143}"
            let v151 : int32 = v3 - 1
            let v152 : int32 = 0
            let v153 : (string -> string) = method30(v151, v152)
            let v154 : string = ""
            let v155 : string = v153 v154
            let v156 : string = "^"
            let v157 : string = v155 + v156 
            let v159 : string = $"{v148}
{v157}
"
            US7_1(v159)
and closure18 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US7 =
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
            let v54 : int32 = v51.Length
            let v55 : (char []) = Array.zeroCreate<char> (v54)
            let v56 : Mut5 = {l0 = 0} : Mut5
            while method27(v54, v56) do
                let v58 : int32 = v56.l0
                let v59 : char = v51.[int v58]
                v55.[int v58] <- v59
                let v60 : int32 = v58 + 1
                v56.l0 <- v60
                ()
            let v62 : char list = v55 |> Array.toList
            let v66 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
            let v67 : (char -> (UH0 -> UH0)) = method28()
            let v68 : (char list -> (UH0 -> UH0)) = v66 v67
            let v69 : (UH0 -> UH0) = v68 v62
            let v70 : UH0 = UH0_0
            let v71 : UH0 = v69 v70
            let struct (v96 : System.Text.StringBuilder, v97 : int32, v98 : int32) = method29(v71, v1, v2, v3)
            US7_0(v10, v45, v96, v97, v98)
        else
            let v101 : string = "\n"
            let v102 : int32 = v0.IndexOf v101 
            let v105 : int32 = v102 - 1
            let v106 : bool = -2 = v105
            let v114 : int32 =
                if v106 then
                    let v108 : (string -> int32) = String.length
                    let v109 : int32 = v108 v0
                    let v112 : int32 = v109 + 1
                    v112
                else
                    let v113 : int32 = v105 + 1
                    v113
            let v120 : int32 = 0 |> int32 
            let v133 : int32 = v114 |> int32 
            let v141 : int32 = v133 - 1
            let v143 : string = v0.[int v120..int v141]
            let v148 : string = $"parsing.p_char / expected: '{'''}' / line: {v2} / col: {v3}
{v1}{v143}"
            let v151 : int32 = v3 - 1
            let v152 : int32 = 0
            let v153 : (string -> string) = method30(v151, v152)
            let v154 : string = ""
            let v155 : string = v153 v154
            let v156 : string = "^"
            let v157 : string = v155 + v156 
            let v159 : string = $"{v148}
{v157}
"
            US7_1(v159)
and method31 (v0 : string, v1 : System.Text.StringBuilder, v2 : UH1) : US7 =
    match v2 with
    | UH1_1(v5, v6) -> (* Cons *)
        let v7 : US7 = v5 struct (v0, v1, 1, 1)
        match v7 with
        | US7_1(v13) -> (* Error *)
            method31(v0, v1, v6)
        | US7_0(v8, v9, v10, v11, v12) -> (* Ok *)
            v7
    | UH1_0 -> (* Nil *)
        let v3 : string = "parsing.choice / no parsers succeeded"
        US7_1(v3)
and method32 (v0 : char, v1 : int64) : bool =
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
            method32(v0, v17)
and method33 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v137 : US7 =
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
            let v27 : bool = method32(v25, v26)
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
                let v71 : int32 = v68.Length
                let v72 : (char []) = Array.zeroCreate<char> (v71)
                let v73 : Mut5 = {l0 = 0} : Mut5
                while method27(v71, v73) do
                    let v75 : int32 = v73.l0
                    let v76 : char = v68.[int v75]
                    v72.[int v75] <- v76
                    let v77 : int32 = v75 + 1
                    v73.l0 <- v77
                    ()
                let v79 : char list = v72 |> Array.toList
                let v83 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v84 : (char -> (UH0 -> UH0)) = method28()
                let v85 : (char list -> (UH0 -> UH0)) = v83 v84
                let v86 : (UH0 -> UH0) = v85 v79
                let v87 : UH0 = UH0_0
                let v88 : UH0 = v86 v87
                let struct (v113 : System.Text.StringBuilder, v114 : int32, v115 : int32) = method29(v88, v2, v3, v4)
                US7_0(v25, v62, v113, v114, v115)
            else
                let v117 : char list = []
                let v119 : char list = ''' :: v117 
                let v123 : char list = '"' :: v119 
                let v127 : (char list -> (char [])) = List.toArray
                let v128 : (char []) = v127 v123
                let v132 : string = $"parsing.none_of / unexpected char: '{v25}' / chars: %A{v128} / s: %A{struct (v2, v3, v4)}"
                US7_1(v132)
    let v149 : US7 =
        match v137 with
        | US7_1(v146) -> (* Error *)
            US7_1(v146)
        | US7_0(v138, v139, v140, v141, v142) -> (* Ok *)
            let v143 : bool = '\\' = v138
            let v144 : char =
                if v143 then
                    '/'
                else
                    v138
            US7_0(v144, v139, v140, v141, v142)
    match v149 with
    | US7_1(v166) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v150, v151, v152, v153, v154) -> (* Ok *)
        let v156 : (char -> string) = _.ToString()
        let v157 : string = v156 v150
        let v160 : string = v0 + v157 
        method33(v160, v151, v152, v153, v154)
and method34 (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32, v4 : UH1) : US7 =
    match v4 with
    | UH1_1(v7, v8) -> (* Cons *)
        let v9 : US7 = v7 struct (v0, v1, v2, v3)
        match v9 with
        | US7_1(v15) -> (* Error *)
            method34(v0, v1, v2, v3, v8)
        | US7_0(v10, v11, v12, v13, v14) -> (* Ok *)
            v9
    | UH1_0 -> (* Nil *)
        let v5 : string = "parsing.choice / no parsers succeeded"
        US7_1(v5)
and method35 (v0 : char, v1 : int64) : bool =
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
            method35(v0, v21)
and method36 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v145 : US7 =
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
            let v31 : bool = method35(v29, v30)
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
                let v75 : int32 = v72.Length
                let v76 : (char []) = Array.zeroCreate<char> (v75)
                let v77 : Mut5 = {l0 = 0} : Mut5
                while method27(v75, v77) do
                    let v79 : int32 = v77.l0
                    let v80 : char = v72.[int v79]
                    v76.[int v79] <- v80
                    let v81 : int32 = v79 + 1
                    v77.l0 <- v81
                    ()
                let v83 : char list = v76 |> Array.toList
                let v87 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v88 : (char -> (UH0 -> UH0)) = method28()
                let v89 : (char list -> (UH0 -> UH0)) = v87 v88
                let v90 : (UH0 -> UH0) = v89 v83
                let v91 : UH0 = UH0_0
                let v92 : UH0 = v90 v91
                let struct (v117 : System.Text.StringBuilder, v118 : int32, v119 : int32) = method29(v92, v2, v3, v4)
                US7_0(v29, v66, v117, v118, v119)
            else
                let v121 : char list = []
                let v123 : char list = ' ' :: v121 
                let v127 : char list = ''' :: v123 
                let v131 : char list = '"' :: v127 
                let v135 : (char list -> (char [])) = List.toArray
                let v136 : (char []) = v135 v131
                let v140 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v136} / s: %A{struct (v2, v3, v4)}"
                US7_1(v140)
    let v157 : US7 =
        match v145 with
        | US7_1(v154) -> (* Error *)
            US7_1(v154)
        | US7_0(v146, v147, v148, v149, v150) -> (* Ok *)
            let v151 : bool = '\\' = v146
            let v152 : char =
                if v151 then
                    '/'
                else
                    v146
            US7_0(v152, v147, v148, v149, v150)
    match v157 with
    | US7_1(v174) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v158, v159, v160, v161, v162) -> (* Ok *)
        let v164 : (char -> string) = _.ToString()
        let v165 : string = v164 v158
        let v168 : string = v0 + v165 
        method36(v168, v159, v160, v161, v162)
and method37 (v0 : string, v1 : int32) : int32 =
    let v2 : int32 = v0.Length
    let v3 : bool = v1 >= v2
    if v3 then
        v1
    else
        let v4 : char = v0.[int v1]
        let v5 : bool = ' ' = v4
        if v5 then
            let v6 : int32 = v1 + 1
            method37(v0, v6)
        else
            v1
and method38 (v0 : string, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : struct (string * string * System.Text.StringBuilder * int32 * int32) =
    let v5 : bool = "" = v1
    let v100 : US7 =
        if v5 then
            let v7 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v2, v3, v4)}"
            US7_1(v7)
        else
            let v11 : char = v1.[int 0]
            let v13 : (string -> int32) = String.length
            let v14 : int32 = v13 v1
            let v22 : int32 = 1 |> int32 
            let v35 : int32 = v14 |> int32 
            let v43 : int32 = v35 - 1
            let v45 : string = v1.[int v22..int v43]
            let v50 : (char -> string) = _.ToString()
            let v51 : string = v50 v11
            let v54 : int32 = v51.Length
            let v55 : (char []) = Array.zeroCreate<char> (v54)
            let v56 : Mut5 = {l0 = 0} : Mut5
            while method27(v54, v56) do
                let v58 : int32 = v56.l0
                let v59 : char = v51.[int v58]
                v55.[int v58] <- v59
                let v60 : int32 = v58 + 1
                v56.l0 <- v60
                ()
            let v62 : char list = v55 |> Array.toList
            let v66 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
            let v67 : (char -> (UH0 -> UH0)) = method28()
            let v68 : (char list -> (UH0 -> UH0)) = v66 v67
            let v69 : (UH0 -> UH0) = v68 v62
            let v70 : UH0 = UH0_0
            let v71 : UH0 = v69 v70
            let struct (v96 : System.Text.StringBuilder, v97 : int32, v98 : int32) = method29(v71, v2, v3, v4)
            US7_0(v11, v45, v96, v97, v98)
    match v100 with
    | US7_1(v117) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v101, v102, v103, v104, v105) -> (* Ok *)
        let v107 : (char -> string) = _.ToString()
        let v108 : string = v107 v101
        let v111 : string = v0 + v108 
        method38(v111, v102, v103, v104, v105)
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
    let v8 : string = ""
    let v9 : string = v4 |> Option.defaultValue v8 
    let v12 : string = method26()
    let v14 : (string -> System.Text.StringBuilder) = System.Text.StringBuilder 
    let v15 : System.Text.StringBuilder = v14 v12
    let v18 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure14()
    let v19 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure18()
    let v20 : UH1 = UH1_0
    let v21 : UH1 = UH1_1(v19, v20)
    let v22 : UH1 = UH1_1(v18, v21)
    let v23 : US7 = method31(v9, v15, v22)
    let v235 : US8 =
        match v23 with
        | US7_1(v232) -> (* Error *)
            US8_1(v232)
        | US7_0(v24, v25, v26, v27, v28) -> (* Ok *)
            let v29 : bool = "" = v25
            let v161 : US7 =
                if v29 then
                    let v30 : char list = []
                    let v32 : char list = ''' :: v30 
                    let v36 : char list = '"' :: v32 
                    let v40 : (char list -> (char [])) = List.toArray
                    let v41 : (char []) = v40 v36
                    let v45 : string = $"parsing.none_of / unexpected end of input / chars: %A{v41} / s: %A{struct (v26, v27, v28)}"
                    US7_1(v45)
                else
                    let v49 : char = v25.[int 0]
                    let v50 : int64 = 0L
                    let v51 : bool = method32(v49, v50)
                    let v52 : bool = v51 = false
                    if v52 then
                        let v54 : (string -> int32) = String.length
                        let v55 : int32 = v54 v25
                        let v63 : int32 = 1 |> int32 
                        let v76 : int32 = v55 |> int32 
                        let v84 : int32 = v76 - 1
                        let v86 : string = v25.[int v63..int v84]
                        let v91 : (char -> string) = _.ToString()
                        let v92 : string = v91 v49
                        let v95 : int32 = v92.Length
                        let v96 : (char []) = Array.zeroCreate<char> (v95)
                        let v97 : Mut5 = {l0 = 0} : Mut5
                        while method27(v95, v97) do
                            let v99 : int32 = v97.l0
                            let v100 : char = v92.[int v99]
                            v96.[int v99] <- v100
                            let v101 : int32 = v99 + 1
                            v97.l0 <- v101
                            ()
                        let v103 : char list = v96 |> Array.toList
                        let v107 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v108 : (char -> (UH0 -> UH0)) = method28()
                        let v109 : (char list -> (UH0 -> UH0)) = v107 v108
                        let v110 : (UH0 -> UH0) = v109 v103
                        let v111 : UH0 = UH0_0
                        let v112 : UH0 = v110 v111
                        let struct (v137 : System.Text.StringBuilder, v138 : int32, v139 : int32) = method29(v112, v26, v27, v28)
                        US7_0(v49, v86, v137, v138, v139)
                    else
                        let v141 : char list = []
                        let v143 : char list = ''' :: v141 
                        let v147 : char list = '"' :: v143 
                        let v151 : (char list -> (char [])) = List.toArray
                        let v152 : (char []) = v151 v147
                        let v156 : string = $"parsing.none_of / unexpected char: '{v49}' / chars: %A{v152} / s: %A{struct (v26, v27, v28)}"
                        US7_1(v156)
            let v173 : US7 =
                match v161 with
                | US7_1(v170) -> (* Error *)
                    US7_1(v170)
                | US7_0(v162, v163, v164, v165, v166) -> (* Ok *)
                    let v167 : bool = '\\' = v162
                    let v168 : char =
                        if v167 then
                            '/'
                        else
                            v162
                    US7_0(v168, v163, v164, v165, v166)
            let v193 : US8 =
                match v173 with
                | US7_1(v190) -> (* Error *)
                    US8_1(v190)
                | US7_0(v174, v175, v176, v177, v178) -> (* Ok *)
                    let v180 : (char -> string) = _.ToString()
                    let v181 : string = v180 v174
                    let struct (v184 : string, v185 : string, v186 : System.Text.StringBuilder, v187 : int32, v188 : int32) = method33(v181, v175, v176, v177, v178)
                    US8_0(v184, v185, v186, v187, v188)
            let v203 : US8 =
                match v193 with
                | US8_1(v200) -> (* Error *)
                    US8_0(v8, v25, v26, v27, v28)
                | US8_0(v194, v195, v196, v197, v198) -> (* Ok *)
                    US8_0(v194, v195, v196, v197, v198)
            match v203 with
            | US8_1(v227) -> (* Error *)
                let v228 : string = "parsing.between / expected content"
                US8_1(v228)
            | US8_0(v204, v205, v206, v207, v208) -> (* Ok *)
                let v209 : UH1 = UH1_0
                let v210 : UH1 = UH1_1(v19, v209)
                let v211 : UH1 = UH1_1(v18, v210)
                let v212 : US7 = method34(v205, v206, v207, v208, v211)
                match v212 with
                | US7_1(v219) -> (* Error *)
                    let v221 : string = $"parsing.between / expected closing delimiter / e: %A{v219} / input: %A{struct (v9, v15, 1, 1)} / rest1: %A{struct (v25, v26, v27, v28)} / rest2: %A{struct (v205, v206, v207, v208)}"
                    US8_1(v221)
                | US7_0(v213, v214, v215, v216, v217) -> (* Ok *)
                    US8_0(v204, v214, v215, v216, v217)
    let v493 : US8 =
        match v235 with
        | US8_1(v241) -> (* Error *)
            let v242 : bool = "" = v9
            let v384 : US7 =
                if v242 then
                    let v243 : char list = []
                    let v245 : char list = ' ' :: v243 
                    let v249 : char list = ''' :: v245 
                    let v253 : char list = '"' :: v249 
                    let v257 : (char list -> (char [])) = List.toArray
                    let v258 : (char []) = v257 v253
                    let v262 : string = $"parsing.none_of / unexpected end of input / chars: %A{v258} / s: %A{struct (v15, 1, 1)}"
                    US7_1(v262)
                else
                    let v266 : char = v9.[int 0]
                    let v267 : int64 = 0L
                    let v268 : bool = method35(v266, v267)
                    let v269 : bool = v268 = false
                    if v269 then
                        let v271 : (string -> int32) = String.length
                        let v272 : int32 = v271 v9
                        let v280 : int32 = 1 |> int32 
                        let v293 : int32 = v272 |> int32 
                        let v301 : int32 = v293 - 1
                        let v303 : string = v9.[int v280..int v301]
                        let v308 : (char -> string) = _.ToString()
                        let v309 : string = v308 v266
                        let v312 : int32 = v309.Length
                        let v313 : (char []) = Array.zeroCreate<char> (v312)
                        let v314 : Mut5 = {l0 = 0} : Mut5
                        while method27(v312, v314) do
                            let v316 : int32 = v314.l0
                            let v317 : char = v309.[int v316]
                            v313.[int v316] <- v317
                            let v318 : int32 = v316 + 1
                            v314.l0 <- v318
                            ()
                        let v320 : char list = v313 |> Array.toList
                        let v324 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v325 : (char -> (UH0 -> UH0)) = method28()
                        let v326 : (char list -> (UH0 -> UH0)) = v324 v325
                        let v327 : (UH0 -> UH0) = v326 v320
                        let v328 : UH0 = UH0_0
                        let v329 : UH0 = v327 v328
                        let v354 : int32 = 1
                        let v355 : int32 = 1
                        let struct (v356 : System.Text.StringBuilder, v357 : int32, v358 : int32) = method29(v329, v15, v354, v355)
                        US7_0(v266, v303, v356, v357, v358)
                    else
                        let v360 : char list = []
                        let v362 : char list = ' ' :: v360 
                        let v366 : char list = ''' :: v362 
                        let v370 : char list = '"' :: v366 
                        let v374 : (char list -> (char [])) = List.toArray
                        let v375 : (char []) = v374 v370
                        let v379 : string = $"parsing.none_of / unexpected char: '{v266}' / chars: %A{v375} / s: %A{struct (v15, 1, 1)}"
                        US7_1(v379)
            let v396 : US7 =
                match v384 with
                | US7_1(v393) -> (* Error *)
                    US7_1(v393)
                | US7_0(v385, v386, v387, v388, v389) -> (* Ok *)
                    let v390 : bool = '\\' = v385
                    let v391 : char =
                        if v390 then
                            '/'
                        else
                            v385
                    US7_0(v391, v386, v387, v388, v389)
            let v416 : US8 =
                match v396 with
                | US7_1(v413) -> (* Error *)
                    US8_1(v413)
                | US7_0(v397, v398, v399, v400, v401) -> (* Ok *)
                    let v403 : (char -> string) = _.ToString()
                    let v404 : string = v403 v397
                    let struct (v407 : string, v408 : string, v409 : System.Text.StringBuilder, v410 : int32, v411 : int32) = method36(v404, v398, v399, v400, v401)
                    US8_0(v407, v408, v409, v410, v411)
            match v416 with
            | US8_1(v422) -> (* Error *)
                let v423 : int32 = v9.Length
                let v424 : bool = v423 = 0
                let v431 : US10 =
                    if v424 then
                        US10_0(v9, v15, 1, 1)
                    else
                        let v427 : string = $"parsing.eof / expected end of input / input: %A{v9}"
                        US10_1(v427)
                let v440 : US8 =
                    match v431 with
                    | US10_1(v437) -> (* Error *)
                        US8_1(v437)
                    | US10_0(v432, v433, v434, v435) -> (* Ok *)
                        US8_0(v8, v432, v433, v434, v435)
                match v440 with
                | US8_1(v486) -> (* Error *)
                    US8_1(v486)
                | US8_0(v441, v442, v443, v444, v445) -> (* Ok *)
                    let v446 : int32 = 0
                    let v447 : int32 = method37(v442, v446)
                    let v449 : (string -> int32) = String.length
                    let v450 : int32 = v449 v442
                    let v458 : int32 = v447 |> int32 
                    let v471 : int32 = v450 |> int32 
                    let v479 : int32 = v471 - 1
                    let v481 : string = v442.[int v458..int v479]
                    US8_0(v441, v481, v443, v444, v445)
            | US8_0(v417, v418, v419, v420, v421) -> (* Ok *)
                v416
        | US8_0(v236, v237, v238, v239, v240) -> (* Ok *)
            v235
    let v821 : US11 =
        match v493 with
        | US8_1(v818) -> (* Error *)
            US11_1(v818)
        | US8_0(v494, v495, v496, v497, v498) -> (* Ok *)
            let v499 : bool = "" = v495
            let v658 : US7 =
                if v499 then
                    let v501 : string = $"parsing.p_char / unexpected end of input / c: '{' '}' / s: %A{struct (v496, v497, v498)}"
                    US7_1(v501)
                else
                    let v505 : char = v495.[int 0]
                    let v506 : bool = v505 = ' '
                    if v506 then
                        let v508 : (string -> int32) = String.length
                        let v509 : int32 = v508 v495
                        let v517 : int32 = 1 |> int32 
                        let v530 : int32 = v509 |> int32 
                        let v538 : int32 = v530 - 1
                        let v540 : string = v495.[int v517..int v538]
                        let v545 : (char -> string) = _.ToString()
                        let v546 : string = v545 v505
                        let v549 : int32 = v546.Length
                        let v550 : (char []) = Array.zeroCreate<char> (v549)
                        let v551 : Mut5 = {l0 = 0} : Mut5
                        while method27(v549, v551) do
                            let v553 : int32 = v551.l0
                            let v554 : char = v546.[int v553]
                            v550.[int v553] <- v554
                            let v555 : int32 = v553 + 1
                            v551.l0 <- v555
                            ()
                        let v557 : char list = v550 |> Array.toList
                        let v561 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v562 : (char -> (UH0 -> UH0)) = method28()
                        let v563 : (char list -> (UH0 -> UH0)) = v561 v562
                        let v564 : (UH0 -> UH0) = v563 v557
                        let v565 : UH0 = UH0_0
                        let v566 : UH0 = v564 v565
                        let struct (v591 : System.Text.StringBuilder, v592 : int32, v593 : int32) = method29(v566, v496, v497, v498)
                        US7_0(v505, v540, v591, v592, v593)
                    else
                        let v596 : string = "\n"
                        let v597 : int32 = v495.IndexOf v596 
                        let v600 : int32 = v597 - 1
                        let v601 : bool = -2 = v600
                        let v609 : int32 =
                            if v601 then
                                let v603 : (string -> int32) = String.length
                                let v604 : int32 = v603 v495
                                let v607 : int32 = v604 + 1
                                v607
                            else
                                let v608 : int32 = v600 + 1
                                v608
                        let v615 : int32 = 0 |> int32 
                        let v628 : int32 = v609 |> int32 
                        let v636 : int32 = v628 - 1
                        let v638 : string = v495.[int v615..int v636]
                        let v643 : string = $"parsing.p_char / expected: '{' '}' / line: {v497} / col: {v498}
{v496}{v638}"
                        let v646 : int32 = v498 - 1
                        let v647 : int32 = 0
                        let v648 : (string -> string) = method30(v646, v647)
                        let v649 : string = v648 v8
                        let v650 : string = "^"
                        let v651 : string = v649 + v650 
                        let v653 : string = $"{v643}
{v651}
"
                        US7_1(v653)
            let v670 : US12 =
                match v658 with
                | US7_1(v666) -> (* Error *)
                    let v667 : US9 = US9_1
                    US12_0(v667, v495, v496, v497, v498)
                | US7_0(v659, v660, v661, v662, v663) -> (* Ok *)
                    let v664 : US9 = US9_0(v659)
                    US12_0(v664, v660, v661, v662, v663)
            let v795 : US8 =
                match v670 with
                | US12_1(v792) -> (* Error *)
                    US8_1(v792)
                | US12_0(v671, v672, v673, v674, v675) -> (* Ok *)
                    let v676 : bool = "" = v672
                    let v771 : US7 =
                        if v676 then
                            let v678 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v673, v674, v675)}"
                            US7_1(v678)
                        else
                            let v682 : char = v672.[int 0]
                            let v684 : (string -> int32) = String.length
                            let v685 : int32 = v684 v672
                            let v693 : int32 = 1 |> int32 
                            let v706 : int32 = v685 |> int32 
                            let v714 : int32 = v706 - 1
                            let v716 : string = v672.[int v693..int v714]
                            let v721 : (char -> string) = _.ToString()
                            let v722 : string = v721 v682
                            let v725 : int32 = v722.Length
                            let v726 : (char []) = Array.zeroCreate<char> (v725)
                            let v727 : Mut5 = {l0 = 0} : Mut5
                            while method27(v725, v727) do
                                let v729 : int32 = v727.l0
                                let v730 : char = v722.[int v729]
                                v726.[int v729] <- v730
                                let v731 : int32 = v729 + 1
                                v727.l0 <- v731
                                ()
                            let v733 : char list = v726 |> Array.toList
                            let v737 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                            let v738 : (char -> (UH0 -> UH0)) = method28()
                            let v739 : (char list -> (UH0 -> UH0)) = v737 v738
                            let v740 : (UH0 -> UH0) = v739 v733
                            let v741 : UH0 = UH0_0
                            let v742 : UH0 = v740 v741
                            let struct (v767 : System.Text.StringBuilder, v768 : int32, v769 : int32) = method29(v742, v673, v674, v675)
                            US7_0(v682, v716, v767, v768, v769)
                    match v771 with
                    | US7_1(v788) -> (* Error *)
                        US8_1(v788)
                    | US7_0(v772, v773, v774, v775, v776) -> (* Ok *)
                        let v778 : (char -> string) = _.ToString()
                        let v779 : string = v778 v772
                        let struct (v782 : string, v783 : string, v784 : System.Text.StringBuilder, v785 : int32, v786 : int32) = method38(v779, v773, v774, v775, v776)
                        US8_0(v782, v783, v784, v785, v786)
            let v807 : US13 =
                match v795 with
                | US8_1(v803) -> (* Error *)
                    let v804 : US5 = US5_1
                    US13_0(v804, v495, v496, v497, v498)
                | US8_0(v796, v797, v798, v799, v800) -> (* Ok *)
                    let v801 : US5 = US5_0(v796)
                    US13_0(v801, v797, v798, v799, v800)
            match v807 with
            | US13_1(v814) -> (* Error *)
                US11_1(v814)
            | US13_0(v808, v809, v810, v811, v812) -> (* Ok *)
                US11_0(v494, v808, v809, v810, v811, v812)
    match v821 with
    | US11_1(v829) -> (* Error *)
        US6_1(v829)
    | US11_0(v822, v823, v824, v825, v826, v827) -> (* Ok *)
        US6_0(v822, v823)
and method39 () : string =
    
    
    
    
    
    let v1 : string = "Debug"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method13(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_blue"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
    (* run_target_args'
    let v19 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v20 : string = "&*$0"
    let v21 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v20 
    let _run_target_args'_v19 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : string = "&*$0"
    let v23 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v22 
    let _run_target_args'_v19 = v23 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v24 : string = "&*$0"
    let v25 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v24 
    let _run_target_args'_v19 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v27 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_bright_blue"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_bright_blue"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[94m"
    let v137 : string = method15()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[94m"
    let v141 : string = method15()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[94m"
    let v145 : string = method15()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[94m"
    let v149 : string = method15()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method41 (v0 : string, v1 : US5, v2 : string, v3 : System.Threading.CancellationToken option, v4 : (struct (string * string) []), v5 : (struct (int32 * string * bool) -> Async<unit>) option, v6 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v7 : bool, v8 : string option) : string =
    let v9 : string = method14()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v12 : string = "{ "
    let v13 : string = $"{v12}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure7(v10, v13)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v22 : string = "file_name"
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure7(v10, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v32 : string = " = "
    let v33 : string = $"{v32}"
    let v36 : unit = ()
    let v37 : (unit -> unit) = closure7(v10, v33)
    let v38 : unit = (fun () -> v37 (); v36) ()
    let v42 : string = $"{v0}"
    let v45 : unit = ()
    let v46 : (unit -> unit) = closure7(v10, v42)
    let v47 : unit = (fun () -> v46 (); v45) ()
    let v51 : string = "; "
    let v52 : string = $"{v51}"
    let v55 : unit = ()
    let v56 : (unit -> unit) = closure7(v10, v52)
    let v57 : unit = (fun () -> v56 (); v55) ()
    let v61 : string = "arguments"
    let v62 : string = $"{v61}"
    let v65 : unit = ()
    let v66 : (unit -> unit) = closure7(v10, v62)
    let v67 : unit = (fun () -> v66 (); v65) ()
    let v71 : string = $"{v32}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure7(v10, v71)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v80 : string = $"%A{v1}"
    let v84 : string = $"{v80}"
    let v87 : unit = ()
    let v88 : (unit -> unit) = closure7(v10, v84)
    let v89 : unit = (fun () -> v88 (); v87) ()
    let v93 : string = $"{v51}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure7(v10, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = "options"
    let v103 : string = $"{v102}"
    let v106 : unit = ()
    let v107 : (unit -> unit) = closure7(v10, v103)
    let v108 : unit = (fun () -> v107 (); v106) ()
    let v112 : string = $"{v32}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure7(v10, v112)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v121 : string = $"{v12}"
    let v124 : unit = ()
    let v125 : (unit -> unit) = closure7(v10, v121)
    let v126 : unit = (fun () -> v125 (); v124) ()
    let v130 : string = "command"
    let v131 : string = $"{v130}"
    let v134 : unit = ()
    let v135 : (unit -> unit) = closure7(v10, v131)
    let v136 : unit = (fun () -> v135 (); v134) ()
    let v140 : string = $"{v32}"
    let v143 : unit = ()
    let v144 : (unit -> unit) = closure7(v10, v140)
    let v145 : unit = (fun () -> v144 (); v143) ()
    let v149 : string = $"{v2}"
    let v152 : unit = ()
    let v153 : (unit -> unit) = closure7(v10, v149)
    let v154 : unit = (fun () -> v153 (); v152) ()
    let v158 : string = $"{v51}"
    let v161 : unit = ()
    let v162 : (unit -> unit) = closure7(v10, v158)
    let v163 : unit = (fun () -> v162 (); v161) ()
    let v167 : string = "cancellation_token"
    let v168 : string = $"{v167}"
    let v171 : unit = ()
    let v172 : (unit -> unit) = closure7(v10, v168)
    let v173 : unit = (fun () -> v172 (); v171) ()
    let v177 : string = $"{v32}"
    let v180 : unit = ()
    let v181 : (unit -> unit) = closure7(v10, v177)
    let v182 : unit = (fun () -> v181 (); v180) ()
    (* run_target_args'
    let v189 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v190 : string = "format!(\"{:#?}\", $0)"
    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v190 
    let v192 : string = "fable_library_rust::String_::fromString($0)"
    let v193 : string = Fable.Core.RustInterop.emitRustExpr v191 v192 
    let _run_target_args'_v189 = v193 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v194 : string = "format!(\"{:#?}\", $0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v194 
    let v196 : string = "fable_library_rust::String_::fromString($0)"
    let v197 : string = Fable.Core.RustInterop.emitRustExpr v195 v196 
    let _run_target_args'_v189 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : string = "format!(\"{:#?}\", $0)"
    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v198 
    let v200 : string = "fable_library_rust::String_::fromString($0)"
    let v201 : string = Fable.Core.RustInterop.emitRustExpr v199 v200 
    let _run_target_args'_v189 = v201 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v203 : string = $"%A{v3}"
    let _run_target_args'_v189 = v203 
    #endif
#if FABLE_COMPILER_PYTHON
    let v207 : string = $"%A{v3}"
    let _run_target_args'_v189 = v207 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v211 : string = $"%A{v3}"
    let _run_target_args'_v189 = v211 
    #endif
#else
    let v215 : string = $"%A{v3}"
    let _run_target_args'_v189 = v215 
    #endif
    let v218 : string = _run_target_args'_v189 
    let v225 : string = $"{v218}"
    let v228 : unit = ()
    let v229 : (unit -> unit) = closure7(v10, v225)
    let v230 : unit = (fun () -> v229 (); v228) ()
    let v234 : string = $"{v51}"
    let v237 : unit = ()
    let v238 : (unit -> unit) = closure7(v10, v234)
    let v239 : unit = (fun () -> v238 (); v237) ()
    let v243 : string = "environment_variables"
    let v244 : string = $"{v243}"
    let v247 : unit = ()
    let v248 : (unit -> unit) = closure7(v10, v244)
    let v249 : unit = (fun () -> v248 (); v247) ()
    let v253 : string = $"{v32}"
    let v256 : unit = ()
    let v257 : (unit -> unit) = closure7(v10, v253)
    let v258 : unit = (fun () -> v257 (); v256) ()
    let v262 : string = $"%A{v4}"
    let v266 : string = $"{v262}"
    let v269 : unit = ()
    let v270 : (unit -> unit) = closure7(v10, v266)
    let v271 : unit = (fun () -> v270 (); v269) ()
    let v275 : string = $"{v51}"
    let v278 : unit = ()
    let v279 : (unit -> unit) = closure7(v10, v275)
    let v280 : unit = (fun () -> v279 (); v278) ()
    let v284 : string = "on_line"
    let v285 : string = $"{v284}"
    let v288 : unit = ()
    let v289 : (unit -> unit) = closure7(v10, v285)
    let v290 : unit = (fun () -> v289 (); v288) ()
    let v294 : string = $"{v32}"
    let v297 : unit = ()
    let v298 : (unit -> unit) = closure7(v10, v294)
    let v299 : unit = (fun () -> v298 (); v297) ()
    (* run_target_args'
    let v306 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v307 : string = "format!(\"{:#?}\", $0)"
    let v308 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v307 
    let v309 : string = "fable_library_rust::String_::fromString($0)"
    let v310 : string = Fable.Core.RustInterop.emitRustExpr v308 v309 
    let _run_target_args'_v306 = v310 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v311 : string = "format!(\"{:#?}\", $0)"
    let v312 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v311 
    let v313 : string = "fable_library_rust::String_::fromString($0)"
    let v314 : string = Fable.Core.RustInterop.emitRustExpr v312 v313 
    let _run_target_args'_v306 = v314 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v315 : string = "format!(\"{:#?}\", $0)"
    let v316 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v315 
    let v317 : string = "fable_library_rust::String_::fromString($0)"
    let v318 : string = Fable.Core.RustInterop.emitRustExpr v316 v317 
    let _run_target_args'_v306 = v318 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v320 : string = $"%A{v5}"
    let _run_target_args'_v306 = v320 
    #endif
#if FABLE_COMPILER_PYTHON
    let v324 : string = $"%A{v5}"
    let _run_target_args'_v306 = v324 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v328 : string = $"%A{v5}"
    let _run_target_args'_v306 = v328 
    #endif
#else
    let v332 : string = $"%A{v5}"
    let _run_target_args'_v306 = v332 
    #endif
    let v335 : string = _run_target_args'_v306 
    let v342 : string = $"{v335}"
    let v345 : unit = ()
    let v346 : (unit -> unit) = closure7(v10, v342)
    let v347 : unit = (fun () -> v346 (); v345) ()
    let v351 : string = $"{v51}"
    let v354 : unit = ()
    let v355 : (unit -> unit) = closure7(v10, v351)
    let v356 : unit = (fun () -> v355 (); v354) ()
    let v360 : string = "stdin"
    let v361 : string = $"{v360}"
    let v364 : unit = ()
    let v365 : (unit -> unit) = closure7(v10, v361)
    let v366 : unit = (fun () -> v365 (); v364) ()
    let v370 : string = $"{v32}"
    let v373 : unit = ()
    let v374 : (unit -> unit) = closure7(v10, v370)
    let v375 : unit = (fun () -> v374 (); v373) ()
    (* run_target_args'
    let v382 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v383 : string = "format!(\"{:#?}\", $0)"
    let v384 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v383 
    let v385 : string = "fable_library_rust::String_::fromString($0)"
    let v386 : string = Fable.Core.RustInterop.emitRustExpr v384 v385 
    let _run_target_args'_v382 = v386 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v387 : string = "format!(\"{:#?}\", $0)"
    let v388 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v387 
    let v389 : string = "fable_library_rust::String_::fromString($0)"
    let v390 : string = Fable.Core.RustInterop.emitRustExpr v388 v389 
    let _run_target_args'_v382 = v390 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v391 : string = "format!(\"{:#?}\", $0)"
    let v392 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v391 
    let v393 : string = "fable_library_rust::String_::fromString($0)"
    let v394 : string = Fable.Core.RustInterop.emitRustExpr v392 v393 
    let _run_target_args'_v382 = v394 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v396 : string = $"%A{v6}"
    let _run_target_args'_v382 = v396 
    #endif
#if FABLE_COMPILER_PYTHON
    let v400 : string = $"%A{v6}"
    let _run_target_args'_v382 = v400 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v404 : string = $"%A{v6}"
    let _run_target_args'_v382 = v404 
    #endif
#else
    let v408 : string = $"%A{v6}"
    let _run_target_args'_v382 = v408 
    #endif
    let v411 : string = _run_target_args'_v382 
    let v418 : string = $"{v411}"
    let v421 : unit = ()
    let v422 : (unit -> unit) = closure7(v10, v418)
    let v423 : unit = (fun () -> v422 (); v421) ()
    let v427 : string = $"{v51}"
    let v430 : unit = ()
    let v431 : (unit -> unit) = closure7(v10, v427)
    let v432 : unit = (fun () -> v431 (); v430) ()
    let v436 : string = "trace"
    let v437 : string = $"{v436}"
    let v440 : unit = ()
    let v441 : (unit -> unit) = closure7(v10, v437)
    let v442 : unit = (fun () -> v441 (); v440) ()
    let v446 : string = $"{v32}"
    let v449 : unit = ()
    let v450 : (unit -> unit) = closure7(v10, v446)
    let v451 : unit = (fun () -> v450 (); v449) ()
    let v456 : string =
        if v7 then
            let v454 : string = "true"
            v454
        else
            let v455 : string = "false"
            v455
    let v458 : string = $"{v456}"
    let v461 : unit = ()
    let v462 : (unit -> unit) = closure7(v10, v458)
    let v463 : unit = (fun () -> v462 (); v461) ()
    let v467 : string = $"{v51}"
    let v470 : unit = ()
    let v471 : (unit -> unit) = closure7(v10, v467)
    let v472 : unit = (fun () -> v471 (); v470) ()
    let v476 : string = "working_directory"
    let v477 : string = $"{v476}"
    let v480 : unit = ()
    let v481 : (unit -> unit) = closure7(v10, v477)
    let v482 : unit = (fun () -> v481 (); v480) ()
    let v486 : string = $"{v32}"
    let v489 : unit = ()
    let v490 : (unit -> unit) = closure7(v10, v486)
    let v491 : unit = (fun () -> v490 (); v489) ()
    (* run_target_args'
    let v498 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v499 : string = "format!(\"{:#?}\", $0)"
    let v500 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v499 
    let v501 : string = "fable_library_rust::String_::fromString($0)"
    let v502 : string = Fable.Core.RustInterop.emitRustExpr v500 v501 
    let _run_target_args'_v498 = v502 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v503 : string = "format!(\"{:#?}\", $0)"
    let v504 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v503 
    let v505 : string = "fable_library_rust::String_::fromString($0)"
    let v506 : string = Fable.Core.RustInterop.emitRustExpr v504 v505 
    let _run_target_args'_v498 = v506 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v507 : string = "format!(\"{:#?}\", $0)"
    let v508 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v507 
    let v509 : string = "fable_library_rust::String_::fromString($0)"
    let v510 : string = Fable.Core.RustInterop.emitRustExpr v508 v509 
    let _run_target_args'_v498 = v510 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v512 : string = $"%A{v8}"
    let _run_target_args'_v498 = v512 
    #endif
#if FABLE_COMPILER_PYTHON
    let v516 : string = $"%A{v8}"
    let _run_target_args'_v498 = v516 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v520 : string = $"%A{v8}"
    let _run_target_args'_v498 = v520 
    #endif
#else
    let v524 : string = $"%A{v8}"
    let _run_target_args'_v498 = v524 
    #endif
    let v527 : string = _run_target_args'_v498 
    let v534 : string = $"{v527}"
    let v537 : unit = ()
    let v538 : (unit -> unit) = closure7(v10, v534)
    let v539 : unit = (fun () -> v538 (); v537) ()
    let v543 : string = " }"
    let v544 : string = $"{v543}"
    let v547 : unit = ()
    let v548 : (unit -> unit) = closure7(v10, v544)
    let v549 : unit = (fun () -> v548 (); v547) ()
    let v553 : string = $"{v543}"
    let v556 : unit = ()
    let v557 : (unit -> unit) = closure7(v10, v553)
    let v558 : unit = (fun () -> v557 (); v556) ()
    let v561 : string = v10.l0
    v561
and method40 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : US5, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method41(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    let v18 : int64 = v0.l0
    let v20 : string = "runtime.execute_with_options_async"
    let v21 : string = $"{v6} {v7} #{v18} %s{v20} / {v17}"
    method18(v21)
and closure19 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : US5, v8 : string) () : unit =
    let v9 : US0 = US0_1
    let v10 : bool = method7(v9)
    if v10 then
        let v11 : unit = ()
        let v12 : (unit -> unit) = closure0()
        let v13 : unit = (fun () -> v12 (); v11) ()
        let struct (v34 : Mut0, v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : int64 option) = TraceState.trace_state.Value
        let v52 : string = method8(v34, v35, v36, v37, v38, v39)
        let v53 : string = method39()
        let v54 : string = method40(v34, v35, v36, v37, v38, v39, v52, v53, v8, v7, v0, v1, v2, v3, v4, v5, v6)
        method19(v54)
and method42 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : (struct (string * string) []) =
    v2
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
and closure21 () (v0 : (struct (int32 * string * bool) -> Async<unit>)) : US14 =
    US14_0(v0)
and method46 () : ((struct (int32 * string * bool) -> Async<unit>) -> US14) =
    closure21()
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
    
    
    
    
    
    let v1 : string = "Verbose"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method13(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_black"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
    (* run_target_args'
    let v19 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v20 : string = "&*$0"
    let v21 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v20 
    let _run_target_args'_v19 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : string = "&*$0"
    let v23 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v22 
    let _run_target_args'_v19 = v23 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v24 : string = "&*$0"
    let v25 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v24 
    let _run_target_args'_v19 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v27 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_bright_black"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_bright_black"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[90m"
    let v137 : string = method15()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[90m"
    let v141 : string = method15()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[90m"
    let v145 : string = method15()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[90m"
    let v149 : string = method15()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method49 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method17()
    let v10 : int64 = v0.l0
    let v12 : string = $"{v6} {v7} #{v10} %s{v8} / {v9}"
    method18(v12)
and closure22 (v0 : string) () : unit =
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
                let v40 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v41 : US14 option = v3 |> Option.map v40 
                let v54 : US14 = US14_1
                let v55 : US14 = v41 |> Option.defaultValue v54 
                match v55 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v59) -> (* Some *)
                    let v60 : int32 = method47(v7)
                    let v61 : Async<unit> = v59 struct (v60, v32, v9)
                    do! v61 
                    ()
                let v64 : string =
                    if v9 then
                        let v62 : string = $"! {v32}"
                        v62
                    else
                        let v63 : string = $"> {v32}"
                        v63
                if v5 then
                    let v65 : unit = ()
                    let v66 : (unit -> unit) = closure22(v64)
                    let v67 : unit = (fun () -> v66 (); v65) ()
                    ()
                else
                    let v117 : unit = ()
                    let v118 : (unit -> unit) = closure10(v64)
                    let v119 : unit = (fun () -> v118 (); v117) ()
                    ()
                let v123 : string =
                    if v9 then
                        let v121 : string = "\u001b[7;4m"
                        v121
                    else
                        let v122 : string = ""
                        v122
                let v126 : string =
                    if v9 then
                        let v124 : string = "\u001b[0m"
                        v124
                    else
                        let v125 : string = ""
                        v125
                let v127 : string = $"{v123}{v32}{v126}"
                (* run_target_args'
                let v128 : unit = ()
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
                let v129 : (string -> unit) = v8.Push
                v129 v127
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
    let v816 : Async<unit> = _let'_v29 
    let _run_target_args'_v15 = v816 
    #endif
#if FABLE_COMPILER_PYTHON
    let v818 : unit = ()
    let _let'_v818 =
        async {
            let v821 : string = method45(v10)
            let v823 : string = null |> unbox<string>
            let v826 : bool = v821 = v823
            let v827 : bool = v826 <> true
            if v827 then
                let v829 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v830 : US14 option = v3 |> Option.map v829 
                let v843 : US14 = US14_1
                let v844 : US14 = v830 |> Option.defaultValue v843 
                match v844 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v848) -> (* Some *)
                    let v849 : int32 = method47(v7)
                    let v850 : Async<unit> = v848 struct (v849, v821, v9)
                    do! v850 
                    ()
                let v853 : string =
                    if v9 then
                        let v851 : string = $"! {v821}"
                        v851
                    else
                        let v852 : string = $"> {v821}"
                        v852
                if v5 then
                    let v854 : unit = ()
                    let v855 : (unit -> unit) = closure22(v853)
                    let v856 : unit = (fun () -> v855 (); v854) ()
                    ()
                else
                    let v906 : unit = ()
                    let v907 : (unit -> unit) = closure10(v853)
                    let v908 : unit = (fun () -> v907 (); v906) ()
                    ()
                let v912 : string =
                    if v9 then
                        let v910 : string = "\u001b[7;4m"
                        v910
                    else
                        let v911 : string = ""
                        v911
                let v915 : string =
                    if v9 then
                        let v913 : string = "\u001b[0m"
                        v913
                    else
                        let v914 : string = ""
                        v914
                let v916 : string = $"{v912}{v821}{v915}"
                (* run_target_args'
                let v917 : unit = ()
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
                let v918 : (string -> unit) = v8.Push
                v918 v916
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
    let v1605 : Async<unit> = _let'_v818 
    let _run_target_args'_v15 = v1605 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1607 : unit = ()
    let _let'_v1607 =
        async {
            let v1610 : string = method45(v10)
            let v1612 : string = null |> unbox<string>
            let v1615 : bool = v1610 = v1612
            let v1616 : bool = v1615 <> true
            if v1616 then
                let v1618 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v1619 : US14 option = v3 |> Option.map v1618 
                let v1632 : US14 = US14_1
                let v1633 : US14 = v1619 |> Option.defaultValue v1632 
                match v1633 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v1637) -> (* Some *)
                    let v1638 : int32 = method47(v7)
                    let v1639 : Async<unit> = v1637 struct (v1638, v1610, v9)
                    do! v1639 
                    ()
                let v1642 : string =
                    if v9 then
                        let v1640 : string = $"! {v1610}"
                        v1640
                    else
                        let v1641 : string = $"> {v1610}"
                        v1641
                if v5 then
                    let v1643 : unit = ()
                    let v1644 : (unit -> unit) = closure22(v1642)
                    let v1645 : unit = (fun () -> v1644 (); v1643) ()
                    ()
                else
                    let v1695 : unit = ()
                    let v1696 : (unit -> unit) = closure10(v1642)
                    let v1697 : unit = (fun () -> v1696 (); v1695) ()
                    ()
                let v1701 : string =
                    if v9 then
                        let v1699 : string = "\u001b[7;4m"
                        v1699
                    else
                        let v1700 : string = ""
                        v1700
                let v1704 : string =
                    if v9 then
                        let v1702 : string = "\u001b[0m"
                        v1702
                    else
                        let v1703 : string = ""
                        v1703
                let v1705 : string = $"{v1701}{v1610}{v1704}"
                (* run_target_args'
                let v1706 : unit = ()
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
                let v1707 : (string -> unit) = v8.Push
                v1707 v1705
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
    let v2394 : Async<unit> = _let'_v1607 
    let _run_target_args'_v15 = v2394 
    #endif
#else
    let v2396 : unit = ()
    let _let'_v2396 =
        async {
            let v2399 : string = method45(v10)
            let v2401 : string = null |> unbox<string>
            let v2404 : bool = v2399 = v2401
            let v2405 : bool = v2404 <> true
            if v2405 then
                let v2407 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v2408 : US14 option = v3 |> Option.map v2407 
                let v2421 : US14 = US14_1
                let v2422 : US14 = v2408 |> Option.defaultValue v2421 
                match v2422 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v2426) -> (* Some *)
                    let v2427 : int32 = method47(v7)
                    let v2428 : Async<unit> = v2426 struct (v2427, v2399, v9)
                    do! v2428 
                    ()
                let v2431 : string =
                    if v9 then
                        let v2429 : string = $"! {v2399}"
                        v2429
                    else
                        let v2430 : string = $"> {v2399}"
                        v2430
                if v5 then
                    let v2432 : unit = ()
                    let v2433 : (unit -> unit) = closure22(v2431)
                    let v2434 : unit = (fun () -> v2433 (); v2432) ()
                    ()
                else
                    let v2484 : unit = ()
                    let v2485 : (unit -> unit) = closure10(v2431)
                    let v2486 : unit = (fun () -> v2485 (); v2484) ()
                    ()
                let v2490 : string =
                    if v9 then
                        let v2488 : string = "\u001b[7;4m"
                        v2488
                    else
                        let v2489 : string = ""
                        v2489
                let v2493 : string =
                    if v9 then
                        let v2491 : string = "\u001b[0m"
                        v2491
                    else
                        let v2492 : string = ""
                        v2492
                let v2494 : string = $"{v2490}{v2399}{v2493}"
                (* run_target_args'
                let v2495 : unit = ()
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
                let v2496 : (string -> unit) = v8.Push
                v2496 v2494
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
    let v3183 : Async<unit> = _let'_v2396 
    let _run_target_args'_v15 = v3183 
    #endif
    let v3184 : Async<unit> = _run_target_args'_v15 
    v3184
and method43 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool, v10 : System.Diagnostics.DataReceivedEventArgs) : Async<unit> =
    method44(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
and closure20 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : System.Diagnostics.Process, v8 : System.Collections.Concurrent.ConcurrentStack<string>, v9 : bool) (v10 : System.Diagnostics.DataReceivedEventArgs) : unit =
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
and closure23 () (v0 : System.Threading.CancellationToken) : US15 =
    US15_0(v0)
and method50 () : (System.Threading.CancellationToken -> US15) =
    closure23()
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
and closure24 (v0 : System.Diagnostics.Process) () : unit =
    let v1 : bool = method52(v0)
    let v2 : bool = v1 = false
    if v2 then
        method53(v0)
and method56 (v0 : System.Threading.Tasks.TaskCanceledException) : string =
    let v1 : string = method14()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure7(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "ex"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure7(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure7(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    (* run_target_args'
    let v37 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v38 : string = "format!(\"{:#?}\", $0)"
    let v39 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v38 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v39 v40 
    let _run_target_args'_v37 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "format!(\"{:#?}\", $0)"
    let v43 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v42 
    let v44 : string = "fable_library_rust::String_::fromString($0)"
    let v45 : string = Fable.Core.RustInterop.emitRustExpr v43 v44 
    let _run_target_args'_v37 = v45 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v46 : string = "format!(\"{:#?}\", $0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v46 
    let v48 : string = "fable_library_rust::String_::fromString($0)"
    let v49 : string = Fable.Core.RustInterop.emitRustExpr v47 v48 
    let _run_target_args'_v37 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : string = $"%A{v0}"
    let _run_target_args'_v37 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : string = $"%A{v0}"
    let _run_target_args'_v37 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : string = $"%A{v0}"
    let _run_target_args'_v37 = v59 
    #endif
#else
    let v63 : string = $"%A{v0}"
    let _run_target_args'_v37 = v63 
    #endif
    let v66 : string = _run_target_args'_v37 
    let v73 : string = $"{v66}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure7(v2, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure7(v2, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v2.l0
    v91
and method55 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : System.Threading.Tasks.TaskCanceledException) : string =
    let v9 : string = method56(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "runtime.execute_with_options_async / WaitForExitAsync"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method18(v13)
and closure25 (v0 : System.Threading.Tasks.TaskCanceledException) () : unit =
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
                let v274 : (unit -> unit) = closure25(v270)
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
                let v3399 : (unit -> unit) = closure25(v3395)
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
                let v6524 : (unit -> unit) = closure25(v6520)
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
                let v9649 : (unit -> unit) = closure25(v9645)
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
    let v12 : string = "{ "
    let v13 : string = $"{v12}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure7(v10, v13)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v22 : string = "exit_code"
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure7(v10, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v32 : string = " = "
    let v33 : string = $"{v32}"
    let v36 : unit = ()
    let v37 : (unit -> unit) = closure7(v10, v33)
    let v38 : unit = (fun () -> v37 (); v36) ()
    let v42 : string = $"{v0}"
    let v45 : unit = ()
    let v46 : (unit -> unit) = closure7(v10, v42)
    let v47 : unit = (fun () -> v46 (); v45) ()
    let v51 : string = "; "
    let v52 : string = $"{v51}"
    let v55 : unit = ()
    let v56 : (unit -> unit) = closure7(v10, v52)
    let v57 : unit = (fun () -> v56 (); v55) ()
    let v61 : string = "output_length"
    let v62 : string = $"{v61}"
    let v65 : unit = ()
    let v66 : (unit -> unit) = closure7(v10, v62)
    let v67 : unit = (fun () -> v66 (); v65) ()
    let v71 : string = $"{v32}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure7(v10, v71)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v80 : string = $"{v1}"
    let v83 : unit = ()
    let v84 : (unit -> unit) = closure7(v10, v80)
    let v85 : unit = (fun () -> v84 (); v83) ()
    let v89 : string = $"{v51}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure7(v10, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v98 : string = "options"
    let v99 : string = $"{v98}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure7(v10, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v108 : string = $"{v32}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure7(v10, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v117 : string = $"{v12}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure7(v10, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v126 : string = "command"
    let v127 : string = $"{v126}"
    let v130 : unit = ()
    let v131 : (unit -> unit) = closure7(v10, v127)
    let v132 : unit = (fun () -> v131 (); v130) ()
    let v136 : string = $"{v32}"
    let v139 : unit = ()
    let v140 : (unit -> unit) = closure7(v10, v136)
    let v141 : unit = (fun () -> v140 (); v139) ()
    let v145 : string = $"{v2}"
    let v148 : unit = ()
    let v149 : (unit -> unit) = closure7(v10, v145)
    let v150 : unit = (fun () -> v149 (); v148) ()
    let v154 : string = $"{v51}"
    let v157 : unit = ()
    let v158 : (unit -> unit) = closure7(v10, v154)
    let v159 : unit = (fun () -> v158 (); v157) ()
    let v163 : string = "cancellation_token"
    let v164 : string = $"{v163}"
    let v167 : unit = ()
    let v168 : (unit -> unit) = closure7(v10, v164)
    let v169 : unit = (fun () -> v168 (); v167) ()
    let v173 : string = $"{v32}"
    let v176 : unit = ()
    let v177 : (unit -> unit) = closure7(v10, v173)
    let v178 : unit = (fun () -> v177 (); v176) ()
    (* run_target_args'
    let v185 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v186 : string = "format!(\"{:#?}\", $0)"
    let v187 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v186 
    let v188 : string = "fable_library_rust::String_::fromString($0)"
    let v189 : string = Fable.Core.RustInterop.emitRustExpr v187 v188 
    let _run_target_args'_v185 = v189 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v190 : string = "format!(\"{:#?}\", $0)"
    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v190 
    let v192 : string = "fable_library_rust::String_::fromString($0)"
    let v193 : string = Fable.Core.RustInterop.emitRustExpr v191 v192 
    let _run_target_args'_v185 = v193 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v194 : string = "format!(\"{:#?}\", $0)"
    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v194 
    let v196 : string = "fable_library_rust::String_::fromString($0)"
    let v197 : string = Fable.Core.RustInterop.emitRustExpr v195 v196 
    let _run_target_args'_v185 = v197 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v199 : string = $"%A{v3}"
    let _run_target_args'_v185 = v199 
    #endif
#if FABLE_COMPILER_PYTHON
    let v203 : string = $"%A{v3}"
    let _run_target_args'_v185 = v203 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v207 : string = $"%A{v3}"
    let _run_target_args'_v185 = v207 
    #endif
#else
    let v211 : string = $"%A{v3}"
    let _run_target_args'_v185 = v211 
    #endif
    let v214 : string = _run_target_args'_v185 
    let v221 : string = $"{v214}"
    let v224 : unit = ()
    let v225 : (unit -> unit) = closure7(v10, v221)
    let v226 : unit = (fun () -> v225 (); v224) ()
    let v230 : string = $"{v51}"
    let v233 : unit = ()
    let v234 : (unit -> unit) = closure7(v10, v230)
    let v235 : unit = (fun () -> v234 (); v233) ()
    let v239 : string = "environment_variables"
    let v240 : string = $"{v239}"
    let v243 : unit = ()
    let v244 : (unit -> unit) = closure7(v10, v240)
    let v245 : unit = (fun () -> v244 (); v243) ()
    let v249 : string = $"{v32}"
    let v252 : unit = ()
    let v253 : (unit -> unit) = closure7(v10, v249)
    let v254 : unit = (fun () -> v253 (); v252) ()
    let v258 : string = $"%A{v4}"
    let v262 : string = $"{v258}"
    let v265 : unit = ()
    let v266 : (unit -> unit) = closure7(v10, v262)
    let v267 : unit = (fun () -> v266 (); v265) ()
    let v271 : string = $"{v51}"
    let v274 : unit = ()
    let v275 : (unit -> unit) = closure7(v10, v271)
    let v276 : unit = (fun () -> v275 (); v274) ()
    let v280 : string = "on_line"
    let v281 : string = $"{v280}"
    let v284 : unit = ()
    let v285 : (unit -> unit) = closure7(v10, v281)
    let v286 : unit = (fun () -> v285 (); v284) ()
    let v290 : string = $"{v32}"
    let v293 : unit = ()
    let v294 : (unit -> unit) = closure7(v10, v290)
    let v295 : unit = (fun () -> v294 (); v293) ()
    (* run_target_args'
    let v302 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v303 : string = "format!(\"{:#?}\", $0)"
    let v304 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v303 
    let v305 : string = "fable_library_rust::String_::fromString($0)"
    let v306 : string = Fable.Core.RustInterop.emitRustExpr v304 v305 
    let _run_target_args'_v302 = v306 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v307 : string = "format!(\"{:#?}\", $0)"
    let v308 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v307 
    let v309 : string = "fable_library_rust::String_::fromString($0)"
    let v310 : string = Fable.Core.RustInterop.emitRustExpr v308 v309 
    let _run_target_args'_v302 = v310 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v311 : string = "format!(\"{:#?}\", $0)"
    let v312 : std_string_String = Fable.Core.RustInterop.emitRustExpr v5 v311 
    let v313 : string = "fable_library_rust::String_::fromString($0)"
    let v314 : string = Fable.Core.RustInterop.emitRustExpr v312 v313 
    let _run_target_args'_v302 = v314 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v316 : string = $"%A{v5}"
    let _run_target_args'_v302 = v316 
    #endif
#if FABLE_COMPILER_PYTHON
    let v320 : string = $"%A{v5}"
    let _run_target_args'_v302 = v320 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v324 : string = $"%A{v5}"
    let _run_target_args'_v302 = v324 
    #endif
#else
    let v328 : string = $"%A{v5}"
    let _run_target_args'_v302 = v328 
    #endif
    let v331 : string = _run_target_args'_v302 
    let v338 : string = $"{v331}"
    let v341 : unit = ()
    let v342 : (unit -> unit) = closure7(v10, v338)
    let v343 : unit = (fun () -> v342 (); v341) ()
    let v347 : string = $"{v51}"
    let v350 : unit = ()
    let v351 : (unit -> unit) = closure7(v10, v347)
    let v352 : unit = (fun () -> v351 (); v350) ()
    let v356 : string = "stdin"
    let v357 : string = $"{v356}"
    let v360 : unit = ()
    let v361 : (unit -> unit) = closure7(v10, v357)
    let v362 : unit = (fun () -> v361 (); v360) ()
    let v366 : string = $"{v32}"
    let v369 : unit = ()
    let v370 : (unit -> unit) = closure7(v10, v366)
    let v371 : unit = (fun () -> v370 (); v369) ()
    (* run_target_args'
    let v378 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v379 : string = "format!(\"{:#?}\", $0)"
    let v380 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v379 
    let v381 : string = "fable_library_rust::String_::fromString($0)"
    let v382 : string = Fable.Core.RustInterop.emitRustExpr v380 v381 
    let _run_target_args'_v378 = v382 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v383 : string = "format!(\"{:#?}\", $0)"
    let v384 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v383 
    let v385 : string = "fable_library_rust::String_::fromString($0)"
    let v386 : string = Fable.Core.RustInterop.emitRustExpr v384 v385 
    let _run_target_args'_v378 = v386 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v387 : string = "format!(\"{:#?}\", $0)"
    let v388 : std_string_String = Fable.Core.RustInterop.emitRustExpr v6 v387 
    let v389 : string = "fable_library_rust::String_::fromString($0)"
    let v390 : string = Fable.Core.RustInterop.emitRustExpr v388 v389 
    let _run_target_args'_v378 = v390 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v392 : string = $"%A{v6}"
    let _run_target_args'_v378 = v392 
    #endif
#if FABLE_COMPILER_PYTHON
    let v396 : string = $"%A{v6}"
    let _run_target_args'_v378 = v396 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v400 : string = $"%A{v6}"
    let _run_target_args'_v378 = v400 
    #endif
#else
    let v404 : string = $"%A{v6}"
    let _run_target_args'_v378 = v404 
    #endif
    let v407 : string = _run_target_args'_v378 
    let v414 : string = $"{v407}"
    let v417 : unit = ()
    let v418 : (unit -> unit) = closure7(v10, v414)
    let v419 : unit = (fun () -> v418 (); v417) ()
    let v423 : string = $"{v51}"
    let v426 : unit = ()
    let v427 : (unit -> unit) = closure7(v10, v423)
    let v428 : unit = (fun () -> v427 (); v426) ()
    let v432 : string = "trace"
    let v433 : string = $"{v432}"
    let v436 : unit = ()
    let v437 : (unit -> unit) = closure7(v10, v433)
    let v438 : unit = (fun () -> v437 (); v436) ()
    let v442 : string = $"{v32}"
    let v445 : unit = ()
    let v446 : (unit -> unit) = closure7(v10, v442)
    let v447 : unit = (fun () -> v446 (); v445) ()
    let v452 : string =
        if v7 then
            let v450 : string = "true"
            v450
        else
            let v451 : string = "false"
            v451
    let v454 : string = $"{v452}"
    let v457 : unit = ()
    let v458 : (unit -> unit) = closure7(v10, v454)
    let v459 : unit = (fun () -> v458 (); v457) ()
    let v463 : string = $"{v51}"
    let v466 : unit = ()
    let v467 : (unit -> unit) = closure7(v10, v463)
    let v468 : unit = (fun () -> v467 (); v466) ()
    let v472 : string = "working_directory"
    let v473 : string = $"{v472}"
    let v476 : unit = ()
    let v477 : (unit -> unit) = closure7(v10, v473)
    let v478 : unit = (fun () -> v477 (); v476) ()
    let v482 : string = $"{v32}"
    let v485 : unit = ()
    let v486 : (unit -> unit) = closure7(v10, v482)
    let v487 : unit = (fun () -> v486 (); v485) ()
    (* run_target_args'
    let v494 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v495 : string = "format!(\"{:#?}\", $0)"
    let v496 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v495 
    let v497 : string = "fable_library_rust::String_::fromString($0)"
    let v498 : string = Fable.Core.RustInterop.emitRustExpr v496 v497 
    let _run_target_args'_v494 = v498 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : string = "format!(\"{:#?}\", $0)"
    let v500 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v499 
    let v501 : string = "fable_library_rust::String_::fromString($0)"
    let v502 : string = Fable.Core.RustInterop.emitRustExpr v500 v501 
    let _run_target_args'_v494 = v502 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v503 : string = "format!(\"{:#?}\", $0)"
    let v504 : std_string_String = Fable.Core.RustInterop.emitRustExpr v8 v503 
    let v505 : string = "fable_library_rust::String_::fromString($0)"
    let v506 : string = Fable.Core.RustInterop.emitRustExpr v504 v505 
    let _run_target_args'_v494 = v506 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v508 : string = $"%A{v8}"
    let _run_target_args'_v494 = v508 
    #endif
#if FABLE_COMPILER_PYTHON
    let v512 : string = $"%A{v8}"
    let _run_target_args'_v494 = v512 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v516 : string = $"%A{v8}"
    let _run_target_args'_v494 = v516 
    #endif
#else
    let v520 : string = $"%A{v8}"
    let _run_target_args'_v494 = v520 
    #endif
    let v523 : string = _run_target_args'_v494 
    let v530 : string = $"{v523}"
    let v533 : unit = ()
    let v534 : (unit -> unit) = closure7(v10, v530)
    let v535 : unit = (fun () -> v534 (); v533) ()
    let v539 : string = " }"
    let v540 : string = $"{v539}"
    let v543 : unit = ()
    let v544 : (unit -> unit) = closure7(v10, v540)
    let v545 : unit = (fun () -> v544 (); v543) ()
    let v549 : string = $"{v539}"
    let v552 : unit = ()
    let v553 : (unit -> unit) = closure7(v10, v549)
    let v554 : unit = (fun () -> v553 (); v552) ()
    let v557 : string = v10.l0
    v557
and method58 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : int32, v10 : string, v11 : System.Threading.CancellationToken option, v12 : (struct (string * string) []), v13 : (struct (int32 * string * bool) -> Async<unit>) option, v14 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v15 : bool, v16 : string option) : string =
    let v17 : string = method59(v8, v9, v10, v11, v12, v13, v14, v15, v16)
    let v18 : int64 = v0.l0
    let v20 : string = "runtime.execute_with_options_async"
    let v21 : string = $"{v6} {v7} #{v18} %s{v20} / {v17}"
    method18(v21)
and closure26 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option, v7 : int32, v8 : string) () : unit =
    let v9 : US0 = US0_1
    let v10 : bool = method7(v9)
    if v10 then
        let v11 : unit = ()
        let v12 : (unit -> unit) = closure0()
        let v13 : unit = (fun () -> v12 (); v11) ()
        let struct (v34 : Mut0, v35 : Mut1, v36 : Mut2, v37 : Mut3, v38 : Mut4, v39 : int64 option) = TraceState.trace_state.Value
        let v52 : string = method8(v34, v35, v36, v37, v38, v39)
        let v53 : string = method39()
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
            let v100 : (string -> US5) = method5()
            let v101 : US5 option = v6 |> Option.map v100 
            let v114 : US5 = US5_1
            let v115 : US5 = v101 |> Option.defaultValue v114 
            let v122 : string =
                match v115 with
                | US5_1 -> (* None *)
                    let v120 : string = ""
                    v120
                | US5_0(v119) -> (* Some *)
                    v119
            let v123 : unit = ()
            let v124 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v98, v97)
            let v125 : unit = (fun () -> v124 (); v123) ()
            let v172 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v176 : string =
                match v98 with
                | US5_1 -> (* None *)
                    let v174 : string = ""
                    v174
                | US5_0(v173) -> (* Some *)
                    v173
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v176,
              StandardOutputEncoding = v172,
              WorkingDirectory = v122,
              FileName = v97,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v177 : System.Diagnostics.ProcessStartInfo = start_info
            let v178 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v179 : int32 = v178.Length
            let v180 : Mut5 = {l0 = 0} : Mut5
            while method27(v179, v180) do
                let v182 : int32 = v180.l0
                let struct (v183 : string, v184 : string) = v178.[int v182]
                v177.EnvironmentVariables.[v183] <- v184 
                let v185 : int32 = v182 + 1
                v180.l0 <- v185
                ()
            let v186 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v177)
            use v186 = v186 
            let v187 : System.Diagnostics.Process = v186 
            let v188 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v189 : System.Collections.Concurrent.ConcurrentStack<string> = v188 ()
            let v190 : bool = false
            let v191 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v187, v189, v190)
            v187.OutputDataReceived.Add v191 
            let v192 : bool = true
            let v193 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v187, v189, v192)
            v187.ErrorDataReceived.Add v193 
            let v194 : (unit -> bool) = v187.Start
            let v195 : bool = v194 ()
            let v196 : bool = v195 = false
            if v196 then
                let v197 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v197
            let v198 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v198 v187
            let v199 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v199 v187
            let v201 : (System.Threading.CancellationToken -> US15) = method50()
            let v202 : US15 option = v1 |> Option.map v201 
            let v215 : US15 = US15_1
            let v216 : US15 = v202 |> Option.defaultValue v215 
            let v223 : System.Threading.CancellationToken =
                match v216 with
                | US15_1 -> (* None *)
                    let v221 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v221
                | US15_0(v220) -> (* Some *)
                    v220
            let v224 : Async<System.Threading.CancellationToken> = method51(v223)
            let! v224 = v224 
            let v225 : System.Threading.CancellationToken = v224 
            let v226 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v225.Register
            let v227 : (unit -> unit) = closure24(v187)
            let v228 : System.Threading.CancellationTokenRegistration = v226 v227
            use v228 = v228 
            let v229 : System.Threading.CancellationTokenRegistration = v228 
            let v230 : Async<int32> = method54(v187, v189, v225)
            let! v230 = v230 
            let v231 : int32 = v230 
            let v233 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v234 : string seq = v233 v189
            let v238 : (string seq -> string seq) = Seq.rev
            let v239 : string seq = v238 v234
            let v243 : string = method57()
            let v244 : (string -> (string seq -> string)) = String.concat
            let v245 : (string seq -> string) = v244 v243
            let v246 : string = v245 v239
            let v250 : unit = ()
            let v251 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v231, v246)
            let v252 : unit = (fun () -> v251 (); v250) ()
            return struct (v231, v246) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2268 : Async<struct (int32 * string)> = _let'_v25 
    let _run_target_args'_v11 = v2268 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2270 : unit = ()
    let _let'_v2270 =
        async {
            (* run_target_args'
            let v2281 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v2284 : int32, v2285 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2284, v2285) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v2292 : int32, v2293 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2292, v2293) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v2300 : int32, v2301 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2300, v2301) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v2308 : int32, v2309 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2308, v2309) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v2316 : int32, v2317 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2316, v2317) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v2324 : int32, v2325 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2324, v2325) 
            #endif
#else
            let v2330 : US6 = method25(v0)
            let struct (v2342 : string, v2343 : US5) =
                match v2330 with
                | US6_1(v2333) -> (* Error *)
                    let v2335 : string = $"resultm.get / Result value was Error: {v2333}"
                    failwith<struct (string * US5)> v2335
                | US6_0(v2331, v2332) -> (* Ok *)
                    struct (v2331, v2332)
            let v2345 : (string -> US5) = method5()
            let v2346 : US5 option = v6 |> Option.map v2345 
            let v2359 : US5 = US5_1
            let v2360 : US5 = v2346 |> Option.defaultValue v2359 
            let v2367 : string =
                match v2360 with
                | US5_1 -> (* None *)
                    let v2365 : string = ""
                    v2365
                | US5_0(v2364) -> (* Some *)
                    v2364
            let v2368 : unit = ()
            let v2369 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v2343, v2342)
            let v2370 : unit = (fun () -> v2369 (); v2368) ()
            let v2417 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v2421 : string =
                match v2343 with
                | US5_1 -> (* None *)
                    let v2419 : string = ""
                    v2419
                | US5_0(v2418) -> (* Some *)
                    v2418
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v2421,
              StandardOutputEncoding = v2417,
              WorkingDirectory = v2367,
              FileName = v2342,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v2422 : System.Diagnostics.ProcessStartInfo = start_info
            let v2423 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v2424 : int32 = v2423.Length
            let v2425 : Mut5 = {l0 = 0} : Mut5
            while method27(v2424, v2425) do
                let v2427 : int32 = v2425.l0
                let struct (v2428 : string, v2429 : string) = v2423.[int v2427]
                v2422.EnvironmentVariables.[v2428] <- v2429 
                let v2430 : int32 = v2427 + 1
                v2425.l0 <- v2430
                ()
            let v2431 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v2422)
            use v2431 = v2431 
            let v2432 : System.Diagnostics.Process = v2431 
            let v2433 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v2434 : System.Collections.Concurrent.ConcurrentStack<string> = v2433 ()
            let v2435 : bool = false
            let v2436 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v2432, v2434, v2435)
            v2432.OutputDataReceived.Add v2436 
            let v2437 : bool = true
            let v2438 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v2432, v2434, v2437)
            v2432.ErrorDataReceived.Add v2438 
            let v2439 : (unit -> bool) = v2432.Start
            let v2440 : bool = v2439 ()
            let v2441 : bool = v2440 = false
            if v2441 then
                let v2442 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v2442
            let v2443 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v2443 v2432
            let v2444 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v2444 v2432
            let v2446 : (System.Threading.CancellationToken -> US15) = method50()
            let v2447 : US15 option = v1 |> Option.map v2446 
            let v2460 : US15 = US15_1
            let v2461 : US15 = v2447 |> Option.defaultValue v2460 
            let v2468 : System.Threading.CancellationToken =
                match v2461 with
                | US15_1 -> (* None *)
                    let v2466 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v2466
                | US15_0(v2465) -> (* Some *)
                    v2465
            let v2469 : Async<System.Threading.CancellationToken> = method51(v2468)
            let! v2469 = v2469 
            let v2470 : System.Threading.CancellationToken = v2469 
            let v2471 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v2470.Register
            let v2472 : (unit -> unit) = closure24(v2432)
            let v2473 : System.Threading.CancellationTokenRegistration = v2471 v2472
            use v2473 = v2473 
            let v2474 : System.Threading.CancellationTokenRegistration = v2473 
            let v2475 : Async<int32> = method54(v2432, v2434, v2470)
            let! v2475 = v2475 
            let v2476 : int32 = v2475 
            let v2478 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v2479 : string seq = v2478 v2434
            let v2483 : (string seq -> string seq) = Seq.rev
            let v2484 : string seq = v2483 v2479
            let v2488 : string = method57()
            let v2489 : (string -> (string seq -> string)) = String.concat
            let v2490 : (string seq -> string) = v2489 v2488
            let v2491 : string = v2490 v2484
            let v2495 : unit = ()
            let v2496 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v2476, v2491)
            let v2497 : unit = (fun () -> v2496 (); v2495) ()
            return struct (v2476, v2491) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4513 : Async<struct (int32 * string)> = _let'_v2270 
    let _run_target_args'_v11 = v4513 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4515 : unit = ()
    let _let'_v4515 =
        async {
            (* run_target_args'
            let v4526 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v4529 : int32, v4530 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4529, v4530) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v4537 : int32, v4538 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4537, v4538) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v4545 : int32, v4546 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4545, v4546) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v4553 : int32, v4554 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4553, v4554) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v4561 : int32, v4562 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4561, v4562) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v4569 : int32, v4570 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4569, v4570) 
            #endif
#else
            let v4575 : US6 = method25(v0)
            let struct (v4587 : string, v4588 : US5) =
                match v4575 with
                | US6_1(v4578) -> (* Error *)
                    let v4580 : string = $"resultm.get / Result value was Error: {v4578}"
                    failwith<struct (string * US5)> v4580
                | US6_0(v4576, v4577) -> (* Ok *)
                    struct (v4576, v4577)
            let v4590 : (string -> US5) = method5()
            let v4591 : US5 option = v6 |> Option.map v4590 
            let v4604 : US5 = US5_1
            let v4605 : US5 = v4591 |> Option.defaultValue v4604 
            let v4612 : string =
                match v4605 with
                | US5_1 -> (* None *)
                    let v4610 : string = ""
                    v4610
                | US5_0(v4609) -> (* Some *)
                    v4609
            let v4613 : unit = ()
            let v4614 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v4588, v4587)
            let v4615 : unit = (fun () -> v4614 (); v4613) ()
            let v4662 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v4666 : string =
                match v4588 with
                | US5_1 -> (* None *)
                    let v4664 : string = ""
                    v4664
                | US5_0(v4663) -> (* Some *)
                    v4663
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v4666,
              StandardOutputEncoding = v4662,
              WorkingDirectory = v4612,
              FileName = v4587,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v4667 : System.Diagnostics.ProcessStartInfo = start_info
            let v4668 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v4669 : int32 = v4668.Length
            let v4670 : Mut5 = {l0 = 0} : Mut5
            while method27(v4669, v4670) do
                let v4672 : int32 = v4670.l0
                let struct (v4673 : string, v4674 : string) = v4668.[int v4672]
                v4667.EnvironmentVariables.[v4673] <- v4674 
                let v4675 : int32 = v4672 + 1
                v4670.l0 <- v4675
                ()
            let v4676 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v4667)
            use v4676 = v4676 
            let v4677 : System.Diagnostics.Process = v4676 
            let v4678 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v4679 : System.Collections.Concurrent.ConcurrentStack<string> = v4678 ()
            let v4680 : bool = false
            let v4681 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v4677, v4679, v4680)
            v4677.OutputDataReceived.Add v4681 
            let v4682 : bool = true
            let v4683 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v4677, v4679, v4682)
            v4677.ErrorDataReceived.Add v4683 
            let v4684 : (unit -> bool) = v4677.Start
            let v4685 : bool = v4684 ()
            let v4686 : bool = v4685 = false
            if v4686 then
                let v4687 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v4687
            let v4688 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v4688 v4677
            let v4689 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v4689 v4677
            let v4691 : (System.Threading.CancellationToken -> US15) = method50()
            let v4692 : US15 option = v1 |> Option.map v4691 
            let v4705 : US15 = US15_1
            let v4706 : US15 = v4692 |> Option.defaultValue v4705 
            let v4713 : System.Threading.CancellationToken =
                match v4706 with
                | US15_1 -> (* None *)
                    let v4711 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v4711
                | US15_0(v4710) -> (* Some *)
                    v4710
            let v4714 : Async<System.Threading.CancellationToken> = method51(v4713)
            let! v4714 = v4714 
            let v4715 : System.Threading.CancellationToken = v4714 
            let v4716 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v4715.Register
            let v4717 : (unit -> unit) = closure24(v4677)
            let v4718 : System.Threading.CancellationTokenRegistration = v4716 v4717
            use v4718 = v4718 
            let v4719 : System.Threading.CancellationTokenRegistration = v4718 
            let v4720 : Async<int32> = method54(v4677, v4679, v4715)
            let! v4720 = v4720 
            let v4721 : int32 = v4720 
            let v4723 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v4724 : string seq = v4723 v4679
            let v4728 : (string seq -> string seq) = Seq.rev
            let v4729 : string seq = v4728 v4724
            let v4733 : string = method57()
            let v4734 : (string -> (string seq -> string)) = String.concat
            let v4735 : (string seq -> string) = v4734 v4733
            let v4736 : string = v4735 v4729
            let v4740 : unit = ()
            let v4741 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v4721, v4736)
            let v4742 : unit = (fun () -> v4741 (); v4740) ()
            return struct (v4721, v4736) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6758 : Async<struct (int32 * string)> = _let'_v4515 
    let _run_target_args'_v11 = v6758 
    #endif
#else
    let v6760 : unit = ()
    let _let'_v6760 =
        async {
            (* run_target_args'
            let v6771 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v6774 : int32, v6775 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6774, v6775) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v6782 : int32, v6783 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6782, v6783) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v6790 : int32, v6791 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6790, v6791) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v6798 : int32, v6799 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6798, v6799) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v6806 : int32, v6807 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6806, v6807) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v6814 : int32, v6815 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6814, v6815) 
            #endif
#else
            let v6820 : US6 = method25(v0)
            let struct (v6832 : string, v6833 : US5) =
                match v6820 with
                | US6_1(v6823) -> (* Error *)
                    let v6825 : string = $"resultm.get / Result value was Error: {v6823}"
                    failwith<struct (string * US5)> v6825
                | US6_0(v6821, v6822) -> (* Ok *)
                    struct (v6821, v6822)
            let v6835 : (string -> US5) = method5()
            let v6836 : US5 option = v6 |> Option.map v6835 
            let v6849 : US5 = US5_1
            let v6850 : US5 = v6836 |> Option.defaultValue v6849 
            let v6857 : string =
                match v6850 with
                | US5_1 -> (* None *)
                    let v6855 : string = ""
                    v6855
                | US5_0(v6854) -> (* Some *)
                    v6854
            let v6858 : unit = ()
            let v6859 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v6833, v6832)
            let v6860 : unit = (fun () -> v6859 (); v6858) ()
            let v6907 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v6911 : string =
                match v6833 with
                | US5_1 -> (* None *)
                    let v6909 : string = ""
                    v6909
                | US5_0(v6908) -> (* Some *)
                    v6908
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v6911,
              StandardOutputEncoding = v6907,
              WorkingDirectory = v6857,
              FileName = v6832,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v6912 : System.Diagnostics.ProcessStartInfo = start_info
            let v6913 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v6914 : int32 = v6913.Length
            let v6915 : Mut5 = {l0 = 0} : Mut5
            while method27(v6914, v6915) do
                let v6917 : int32 = v6915.l0
                let struct (v6918 : string, v6919 : string) = v6913.[int v6917]
                v6912.EnvironmentVariables.[v6918] <- v6919 
                let v6920 : int32 = v6917 + 1
                v6915.l0 <- v6920
                ()
            let v6921 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v6912)
            use v6921 = v6921 
            let v6922 : System.Diagnostics.Process = v6921 
            let v6923 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v6924 : System.Collections.Concurrent.ConcurrentStack<string> = v6923 ()
            let v6925 : bool = false
            let v6926 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v6922, v6924, v6925)
            v6922.OutputDataReceived.Add v6926 
            let v6927 : bool = true
            let v6928 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v6922, v6924, v6927)
            v6922.ErrorDataReceived.Add v6928 
            let v6929 : (unit -> bool) = v6922.Start
            let v6930 : bool = v6929 ()
            let v6931 : bool = v6930 = false
            if v6931 then
                let v6932 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v6932
            let v6933 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v6933 v6922
            let v6934 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v6934 v6922
            let v6936 : (System.Threading.CancellationToken -> US15) = method50()
            let v6937 : US15 option = v1 |> Option.map v6936 
            let v6950 : US15 = US15_1
            let v6951 : US15 = v6937 |> Option.defaultValue v6950 
            let v6958 : System.Threading.CancellationToken =
                match v6951 with
                | US15_1 -> (* None *)
                    let v6956 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v6956
                | US15_0(v6955) -> (* Some *)
                    v6955
            let v6959 : Async<System.Threading.CancellationToken> = method51(v6958)
            let! v6959 = v6959 
            let v6960 : System.Threading.CancellationToken = v6959 
            let v6961 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v6960.Register
            let v6962 : (unit -> unit) = closure24(v6922)
            let v6963 : System.Threading.CancellationTokenRegistration = v6961 v6962
            use v6963 = v6963 
            let v6964 : System.Threading.CancellationTokenRegistration = v6963 
            let v6965 : Async<int32> = method54(v6922, v6924, v6960)
            let! v6965 = v6965 
            let v6966 : int32 = v6965 
            let v6968 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v6969 : string seq = v6968 v6924
            let v6973 : (string seq -> string seq) = Seq.rev
            let v6974 : string seq = v6973 v6969
            let v6978 : string = method57()
            let v6979 : (string -> (string seq -> string)) = String.concat
            let v6980 : (string seq -> string) = v6979 v6978
            let v6981 : string = v6980 v6974
            let v6985 : unit = ()
            let v6986 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v6966, v6981)
            let v6987 : unit = (fun () -> v6986 (); v6985) ()
            return struct (v6966, v6981) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9003 : Async<struct (int32 * string)> = _let'_v6760 
    let _run_target_args'_v11 = v9003 
    #endif
    let v9004 : Async<struct (int32 * string)> = _run_target_args'_v11 
    v9004
and method23 (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    method24(v0, v1, v2, v3, v4, v5, v6)
and method22 (v0 : string) : Async<struct (int32 * string)> =
    let v1 : System.Threading.CancellationToken option = None
    let v2 : (struct (string * string) []) = [||]
    let v3 : (struct (int32 * string * bool) -> Async<unit>) option = None
    let v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = None
    let v5 : string option = None
    let v6 : bool = true
    method23(v0, v1, v2, v3, v4, v6, v5)
and closure13 () (v0 : string) : Async<struct (int32 * string)> =
    method22(v0)
and closure27 () struct (v0 : string, v1 : System.Threading.CancellationToken option, v2 : (struct (string * string) []), v3 : (struct (int32 * string * bool) -> Async<unit>) option, v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option, v5 : bool, v6 : string option) : Async<struct (int32 * string)> =
    method23(v0, v1, v2, v3, v4, v5, v6)
and closure28 () (v0 : (Heap0 -> Heap0)) : struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option) =
    let v1 : System.Threading.CancellationToken option = None
    let v2 : (struct (string * string) []) = [||]
    let v3 : (struct (int32 * string * bool) -> Async<unit>) option = None
    let v4 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = None
    let v5 : string option = None
    let v6 : string = ""
    let v7 : Heap0 = {l0 = v6; l1 = v1; l2 = v2; l3 = v3; l4 = v4; l5 = true; l6 = v5} : Heap0
    let v8 : Heap0 = v0 v7
    let v9 : string = v8.l0
    let v10 : System.Threading.CancellationToken option = v8.l1
    let v11 : (struct (string * string) []) = v8.l2
    let v12 : (struct (int32 * string * bool) -> Async<unit>) option = v8.l3
    let v13 : (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option = v8.l4
    let v14 : bool = v8.l5
    let v15 : string option = v8.l6
    struct (v9, v10, v11, v12, v13, v14, v15)
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
    let v153 : US7 =
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
                let v79 : int32 = v76.Length
                let v80 : (char []) = Array.zeroCreate<char> (v79)
                let v81 : Mut5 = {l0 = 0} : Mut5
                while method27(v79, v81) do
                    let v83 : int32 = v81.l0
                    let v84 : char = v76.[int v83]
                    v80.[int v83] <- v84
                    let v85 : int32 = v83 + 1
                    v81.l0 <- v85
                    ()
                let v87 : char list = v80 |> Array.toList
                let v91 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v92 : (char -> (UH0 -> UH0)) = method28()
                let v93 : (char list -> (UH0 -> UH0)) = v91 v92
                let v94 : (UH0 -> UH0) = v93 v87
                let v95 : UH0 = UH0_0
                let v96 : UH0 = v94 v95
                let struct (v121 : System.Text.StringBuilder, v122 : int32, v123 : int32) = method29(v96, v2, v3, v4)
                US7_0(v33, v70, v121, v122, v123)
            else
                let v125 : char list = []
                let v127 : char list = ' ' :: v125 
                let v131 : char list = '"' :: v127 
                let v135 : char list = '`' :: v131 
                let v139 : char list = '\\' :: v135 
                let v143 : (char list -> (char [])) = List.toArray
                let v144 : (char []) = v143 v139
                let v148 : string = $"parsing.none_of / unexpected char: '{v33}' / chars: %A{v144} / s: %A{struct (v2, v3, v4)}"
                US7_1(v148)
    match v153 with
    | US7_1(v170) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v154, v155, v156, v157, v158) -> (* Ok *)
        let v160 : (char -> string) = _.ToString()
        let v161 : string = v160 v154
        let v164 : string = v0 + v161 
        method63(v164, v155, v156, v157, v158)
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
and closure30 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    let v164 : US7 =
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
                let v54 : int32 = v51.Length
                let v55 : (char []) = Array.zeroCreate<char> (v54)
                let v56 : Mut5 = {l0 = 0} : Mut5
                while method27(v54, v56) do
                    let v58 : int32 = v56.l0
                    let v59 : char = v51.[int v58]
                    v55.[int v58] <- v59
                    let v60 : int32 = v58 + 1
                    v56.l0 <- v60
                    ()
                let v62 : char list = v55 |> Array.toList
                let v66 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v67 : (char -> (UH0 -> UH0)) = method28()
                let v68 : (char list -> (UH0 -> UH0)) = v66 v67
                let v69 : (UH0 -> UH0) = v68 v62
                let v70 : UH0 = UH0_0
                let v71 : UH0 = v69 v70
                let struct (v96 : System.Text.StringBuilder, v97 : int32, v98 : int32) = method29(v71, v1, v2, v3)
                US7_0(v10, v45, v96, v97, v98)
            else
                let v101 : string = "\n"
                let v102 : int32 = v0.IndexOf v101 
                let v105 : int32 = v102 - 1
                let v106 : bool = -2 = v105
                let v114 : int32 =
                    if v106 then
                        let v108 : (string -> int32) = String.length
                        let v109 : int32 = v108 v0
                        let v112 : int32 = v109 + 1
                        v112
                    else
                        let v113 : int32 = v105 + 1
                        v113
                let v120 : int32 = 0 |> int32 
                let v133 : int32 = v114 |> int32 
                let v141 : int32 = v133 - 1
                let v143 : string = v0.[int v120..int v141]
                let v148 : string = $"parsing.p_char / expected: '{'\\'}' / line: {v2} / col: {v3}
{v1}{v143}"
                let v151 : int32 = v3 - 1
                let v152 : int32 = 0
                let v153 : (string -> string) = method30(v151, v152)
                let v154 : string = ""
                let v155 : string = v153 v154
                let v156 : string = "^"
                let v157 : string = v155 + v156 
                let v159 : string = $"{v148}
{v157}
"
                US7_1(v159)
    let v269 : US7 =
        match v164 with
        | US7_1(v266) -> (* Error *)
            US7_1(v266)
        | US7_0(v165, v166, v167, v168, v169) -> (* Ok *)
            let v170 : bool = "" = v166
            if v170 then
                let v172 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v167, v168, v169)}"
                US7_1(v172)
            else
                let v176 : char = v166.[int 0]
                let v178 : (string -> int32) = String.length
                let v179 : int32 = v178 v166
                let v187 : int32 = 1 |> int32 
                let v200 : int32 = v179 |> int32 
                let v208 : int32 = v200 - 1
                let v210 : string = v166.[int v187..int v208]
                let v215 : (char -> string) = _.ToString()
                let v216 : string = v215 v176
                let v219 : int32 = v216.Length
                let v220 : (char []) = Array.zeroCreate<char> (v219)
                let v221 : Mut5 = {l0 = 0} : Mut5
                while method27(v219, v221) do
                    let v223 : int32 = v221.l0
                    let v224 : char = v216.[int v223]
                    v220.[int v223] <- v224
                    let v225 : int32 = v223 + 1
                    v221.l0 <- v225
                    ()
                let v227 : char list = v220 |> Array.toList
                let v231 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v232 : (char -> (UH0 -> UH0)) = method28()
                let v233 : (char list -> (UH0 -> UH0)) = v231 v232
                let v234 : (UH0 -> UH0) = v233 v227
                let v235 : UH0 = UH0_0
                let v236 : UH0 = v234 v235
                let struct (v261 : System.Text.StringBuilder, v262 : int32, v263 : int32) = method29(v236, v167, v168, v169)
                US7_0(v176, v210, v261, v262, v263)
    match v269 with
    | US7_1(v287) -> (* Error *)
        US8_1(v287)
    | US7_0(v270, v271, v272, v273, v274) -> (* Ok *)
        let v276 : (char -> string) = _.ToString()
        let v277 : string = v276 '\\'
        let v281 : (char -> string) = _.ToString()
        let v282 : string = v281 v270
        let v285 : string = v277 + v282 
        US8_0(v285, v271, v272, v273, v274)
and closure31 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    let v164 : US7 =
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
                let v54 : int32 = v51.Length
                let v55 : (char []) = Array.zeroCreate<char> (v54)
                let v56 : Mut5 = {l0 = 0} : Mut5
                while method27(v54, v56) do
                    let v58 : int32 = v56.l0
                    let v59 : char = v51.[int v58]
                    v55.[int v58] <- v59
                    let v60 : int32 = v58 + 1
                    v56.l0 <- v60
                    ()
                let v62 : char list = v55 |> Array.toList
                let v66 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v67 : (char -> (UH0 -> UH0)) = method28()
                let v68 : (char list -> (UH0 -> UH0)) = v66 v67
                let v69 : (UH0 -> UH0) = v68 v62
                let v70 : UH0 = UH0_0
                let v71 : UH0 = v69 v70
                let struct (v96 : System.Text.StringBuilder, v97 : int32, v98 : int32) = method29(v71, v1, v2, v3)
                US7_0(v10, v45, v96, v97, v98)
            else
                let v101 : string = "\n"
                let v102 : int32 = v0.IndexOf v101 
                let v105 : int32 = v102 - 1
                let v106 : bool = -2 = v105
                let v114 : int32 =
                    if v106 then
                        let v108 : (string -> int32) = String.length
                        let v109 : int32 = v108 v0
                        let v112 : int32 = v109 + 1
                        v112
                    else
                        let v113 : int32 = v105 + 1
                        v113
                let v120 : int32 = 0 |> int32 
                let v133 : int32 = v114 |> int32 
                let v141 : int32 = v133 - 1
                let v143 : string = v0.[int v120..int v141]
                let v148 : string = $"parsing.p_char / expected: '{'`'}' / line: {v2} / col: {v3}
{v1}{v143}"
                let v151 : int32 = v3 - 1
                let v152 : int32 = 0
                let v153 : (string -> string) = method30(v151, v152)
                let v154 : string = ""
                let v155 : string = v153 v154
                let v156 : string = "^"
                let v157 : string = v155 + v156 
                let v159 : string = $"{v148}
{v157}
"
                US7_1(v159)
    let v269 : US7 =
        match v164 with
        | US7_1(v266) -> (* Error *)
            US7_1(v266)
        | US7_0(v165, v166, v167, v168, v169) -> (* Ok *)
            let v170 : bool = "" = v166
            if v170 then
                let v172 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v167, v168, v169)}"
                US7_1(v172)
            else
                let v176 : char = v166.[int 0]
                let v178 : (string -> int32) = String.length
                let v179 : int32 = v178 v166
                let v187 : int32 = 1 |> int32 
                let v200 : int32 = v179 |> int32 
                let v208 : int32 = v200 - 1
                let v210 : string = v166.[int v187..int v208]
                let v215 : (char -> string) = _.ToString()
                let v216 : string = v215 v176
                let v219 : int32 = v216.Length
                let v220 : (char []) = Array.zeroCreate<char> (v219)
                let v221 : Mut5 = {l0 = 0} : Mut5
                while method27(v219, v221) do
                    let v223 : int32 = v221.l0
                    let v224 : char = v216.[int v223]
                    v220.[int v223] <- v224
                    let v225 : int32 = v223 + 1
                    v221.l0 <- v225
                    ()
                let v227 : char list = v220 |> Array.toList
                let v231 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v232 : (char -> (UH0 -> UH0)) = method28()
                let v233 : (char list -> (UH0 -> UH0)) = v231 v232
                let v234 : (UH0 -> UH0) = v233 v227
                let v235 : UH0 = UH0_0
                let v236 : UH0 = v234 v235
                let struct (v261 : System.Text.StringBuilder, v262 : int32, v263 : int32) = method29(v236, v167, v168, v169)
                US7_0(v176, v210, v261, v262, v263)
    match v269 with
    | US7_1(v287) -> (* Error *)
        US8_1(v287)
    | US7_0(v270, v271, v272, v273, v274) -> (* Ok *)
        let v276 : (char -> string) = _.ToString()
        let v277 : string = v276 '`'
        let v281 : (char -> string) = _.ToString()
        let v282 : string = v281 v270
        let v285 : string = v277 + v282 
        US8_0(v285, v271, v272, v273, v274)
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
    let v145 : US7 =
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
                let v75 : int32 = v72.Length
                let v76 : (char []) = Array.zeroCreate<char> (v75)
                let v77 : Mut5 = {l0 = 0} : Mut5
                while method27(v75, v77) do
                    let v79 : int32 = v77.l0
                    let v80 : char = v72.[int v79]
                    v76.[int v79] <- v80
                    let v81 : int32 = v79 + 1
                    v77.l0 <- v81
                    ()
                let v83 : char list = v76 |> Array.toList
                let v87 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v88 : (char -> (UH0 -> UH0)) = method28()
                let v89 : (char list -> (UH0 -> UH0)) = v87 v88
                let v90 : (UH0 -> UH0) = v89 v83
                let v91 : UH0 = UH0_0
                let v92 : UH0 = v90 v91
                let struct (v117 : System.Text.StringBuilder, v118 : int32, v119 : int32) = method29(v92, v2, v3, v4)
                US7_0(v29, v66, v117, v118, v119)
            else
                let v121 : char list = []
                let v123 : char list = '"' :: v121 
                let v127 : char list = '`' :: v123 
                let v131 : char list = '\\' :: v127 
                let v135 : (char list -> (char [])) = List.toArray
                let v136 : (char []) = v135 v131
                let v140 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v136} / s: %A{struct (v2, v3, v4)}"
                US7_1(v140)
    let v160 : US8 =
        match v145 with
        | US7_1(v157) -> (* Error *)
            US8_1(v157)
        | US7_0(v146, v147, v148, v149, v150) -> (* Ok *)
            let v152 : (char -> string) = _.ToString()
            let v153 : string = v152 v146
            US8_0(v153, v147, v148, v149, v150)
    let v174 : US8 =
        match v160 with
        | US8_1(v166) -> (* Error *)
            let v167 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure30()
            let v168 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure31()
            let v169 : UH3 = UH3_0
            let v170 : UH3 = UH3_1(v168, v169)
            let v171 : UH3 = UH3_1(v167, v170)
            method66(v1, v2, v3, v4, v171)
        | US8_0(v161, v162, v163, v164, v165) -> (* Ok *)
            v160
    match v174 with
    | US8_1(v182) -> (* Error *)
        let v183 : UH2 = UH2_0
        let v184 : UH2 = method67(v0, v183)
        US17_0(v184, v1, v2, v3, v4)
    | US8_0(v175, v176, v177, v178, v179) -> (* Ok *)
        let v180 : UH2 = UH2_1(v175, v0)
        method64(v180, v176, v177, v178, v179)
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
    let v145 : US7 =
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
                let v75 : int32 = v72.Length
                let v76 : (char []) = Array.zeroCreate<char> (v75)
                let v77 : Mut5 = {l0 = 0} : Mut5
                while method27(v75, v77) do
                    let v79 : int32 = v77.l0
                    let v80 : char = v72.[int v79]
                    v76.[int v79] <- v80
                    let v81 : int32 = v79 + 1
                    v77.l0 <- v81
                    ()
                let v83 : char list = v76 |> Array.toList
                let v87 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v88 : (char -> (UH0 -> UH0)) = method28()
                let v89 : (char list -> (UH0 -> UH0)) = v87 v88
                let v90 : (UH0 -> UH0) = v89 v83
                let v91 : UH0 = UH0_0
                let v92 : UH0 = v90 v91
                let struct (v117 : System.Text.StringBuilder, v118 : int32, v119 : int32) = method29(v92, v2, v3, v4)
                US7_0(v29, v66, v117, v118, v119)
            else
                let v121 : char list = []
                let v123 : char list = '"' :: v121 
                let v127 : char list = '`' :: v123 
                let v131 : char list = '\\' :: v127 
                let v135 : (char list -> (char [])) = List.toArray
                let v136 : (char []) = v135 v131
                let v140 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v136} / s: %A{struct (v2, v3, v4)}"
                US7_1(v140)
    let v160 : US8 =
        match v145 with
        | US7_1(v157) -> (* Error *)
            US8_1(v157)
        | US7_0(v146, v147, v148, v149, v150) -> (* Ok *)
            let v152 : (char -> string) = _.ToString()
            let v153 : string = v152 v146
            US8_0(v153, v147, v148, v149, v150)
    match v160 with
    | US8_1(v168) -> (* Error *)
        let v169 : UH2 = UH2_0
        let v170 : UH2 = method67(v0, v169)
        US17_0(v170, v1, v2, v3, v4)
    | US8_0(v161, v162, v163, v164, v165) -> (* Ok *)
        let v166 : UH2 = UH2_1(v161, v0)
        method69(v166, v162, v163, v164, v165)
and method61 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
    let v5 : bool = "" = v1
    let v153 : US7 =
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
                let v79 : int32 = v76.Length
                let v80 : (char []) = Array.zeroCreate<char> (v79)
                let v81 : Mut5 = {l0 = 0} : Mut5
                while method27(v79, v81) do
                    let v83 : int32 = v81.l0
                    let v84 : char = v76.[int v83]
                    v80.[int v83] <- v84
                    let v85 : int32 = v83 + 1
                    v81.l0 <- v85
                    ()
                let v87 : char list = v80 |> Array.toList
                let v91 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v92 : (char -> (UH0 -> UH0)) = method28()
                let v93 : (char list -> (UH0 -> UH0)) = v91 v92
                let v94 : (UH0 -> UH0) = v93 v87
                let v95 : UH0 = UH0_0
                let v96 : UH0 = v94 v95
                let struct (v121 : System.Text.StringBuilder, v122 : int32, v123 : int32) = method29(v96, v2, v3, v4)
                US7_0(v33, v70, v121, v122, v123)
            else
                let v125 : char list = []
                let v127 : char list = ' ' :: v125 
                let v131 : char list = '"' :: v127 
                let v135 : char list = '`' :: v131 
                let v139 : char list = '\\' :: v135 
                let v143 : (char list -> (char [])) = List.toArray
                let v144 : (char []) = v143 v139
                let v148 : string = $"parsing.none_of / unexpected char: '{v33}' / chars: %A{v144} / s: %A{struct (v2, v3, v4)}"
                US7_1(v148)
    let v173 : US8 =
        match v153 with
        | US7_1(v170) -> (* Error *)
            US8_1(v170)
        | US7_0(v154, v155, v156, v157, v158) -> (* Ok *)
            let v160 : (char -> string) = _.ToString()
            let v161 : string = v160 v154
            let struct (v164 : string, v165 : string, v166 : System.Text.StringBuilder, v167 : int32, v168 : int32) = method63(v161, v155, v156, v157, v158)
            US8_0(v164, v165, v166, v167, v168)
    let v635 : US8 =
        match v173 with
        | US8_1(v179) -> (* Error *)
            let v339 : US7 =
                if v5 then
                    let v181 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v2, v3, v4)}"
                    US7_1(v181)
                else
                    let v185 : char = v1.[int 0]
                    let v186 : bool = v185 = '"'
                    if v186 then
                        let v188 : (string -> int32) = String.length
                        let v189 : int32 = v188 v1
                        let v197 : int32 = 1 |> int32 
                        let v210 : int32 = v189 |> int32 
                        let v218 : int32 = v210 - 1
                        let v220 : string = v1.[int v197..int v218]
                        let v225 : (char -> string) = _.ToString()
                        let v226 : string = v225 v185
                        let v229 : int32 = v226.Length
                        let v230 : (char []) = Array.zeroCreate<char> (v229)
                        let v231 : Mut5 = {l0 = 0} : Mut5
                        while method27(v229, v231) do
                            let v233 : int32 = v231.l0
                            let v234 : char = v226.[int v233]
                            v230.[int v233] <- v234
                            let v235 : int32 = v233 + 1
                            v231.l0 <- v235
                            ()
                        let v237 : char list = v230 |> Array.toList
                        let v241 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v242 : (char -> (UH0 -> UH0)) = method28()
                        let v243 : (char list -> (UH0 -> UH0)) = v241 v242
                        let v244 : (UH0 -> UH0) = v243 v237
                        let v245 : UH0 = UH0_0
                        let v246 : UH0 = v244 v245
                        let struct (v271 : System.Text.StringBuilder, v272 : int32, v273 : int32) = method29(v246, v2, v3, v4)
                        US7_0(v185, v220, v271, v272, v273)
                    else
                        let v276 : string = "\n"
                        let v277 : int32 = v1.IndexOf v276 
                        let v280 : int32 = v277 - 1
                        let v281 : bool = -2 = v280
                        let v289 : int32 =
                            if v281 then
                                let v283 : (string -> int32) = String.length
                                let v284 : int32 = v283 v1
                                let v287 : int32 = v284 + 1
                                v287
                            else
                                let v288 : int32 = v280 + 1
                                v288
                        let v295 : int32 = 0 |> int32 
                        let v308 : int32 = v289 |> int32 
                        let v316 : int32 = v308 - 1
                        let v318 : string = v1.[int v295..int v316]
                        let v323 : string = $"parsing.p_char / expected: '{'"'}' / line: {v3} / col: {v4}
{v2}{v318}"
                        let v326 : int32 = v4 - 1
                        let v327 : int32 = 0
                        let v328 : (string -> string) = method30(v326, v327)
                        let v329 : string = ""
                        let v330 : string = v328 v329
                        let v331 : string = "^"
                        let v332 : string = v330 + v331 
                        let v334 : string = $"{v323}
{v332}
"
                        US7_1(v334)
            let v566 : US8 =
                match v339 with
                | US7_1(v563) -> (* Error *)
                    US8_1(v563)
                | US7_0(v340, v341, v342, v343, v344) -> (* Ok *)
                    let v345 : UH2 = UH2_0
                    let v346 : US17 = method64(v345, v341, v342, v343, v344)
                    let v377 : US8 =
                        match v346 with
                        | US17_1(v374) -> (* Error *)
                            US8_1(v374)
                        | US17_0(v347, v348, v349, v350, v351) -> (* Ok *)
                            let v352 : string list = []
                            let v353 : string list = method68(v347, v352)
                            let v357 : unit = ()
                            let _let'_v357 =
                                seq {
                                    yield! v353 
                                    (* indent
                                    ()
                                indent *)
                                }
                                (* indent
                                ()
                            indent *)
                            let v360 : string seq = _let'_v357 
                            let v367 : (string -> (string seq -> string)) = String.concat
                            let v368 : string = ""
                            let v369 : (string seq -> string) = v367 v368
                            let v370 : string = v369 v360
                            US8_0(v370, v348, v349, v350, v351)
                    match v377 with
                    | US8_1(v558) -> (* Error *)
                        let v559 : string = "parsing.between / expected content"
                        US8_1(v559)
                    | US8_0(v378, v379, v380, v381, v382) -> (* Ok *)
                        let v383 : bool = "" = v379
                        let v543 : US7 =
                            if v383 then
                                let v385 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v380, v381, v382)}"
                                US7_1(v385)
                            else
                                let v389 : char = v379.[int 0]
                                let v390 : bool = v389 = '"'
                                if v390 then
                                    let v392 : (string -> int32) = String.length
                                    let v393 : int32 = v392 v379
                                    let v401 : int32 = 1 |> int32 
                                    let v414 : int32 = v393 |> int32 
                                    let v422 : int32 = v414 - 1
                                    let v424 : string = v379.[int v401..int v422]
                                    let v429 : (char -> string) = _.ToString()
                                    let v430 : string = v429 v389
                                    let v433 : int32 = v430.Length
                                    let v434 : (char []) = Array.zeroCreate<char> (v433)
                                    let v435 : Mut5 = {l0 = 0} : Mut5
                                    while method27(v433, v435) do
                                        let v437 : int32 = v435.l0
                                        let v438 : char = v430.[int v437]
                                        v434.[int v437] <- v438
                                        let v439 : int32 = v437 + 1
                                        v435.l0 <- v439
                                        ()
                                    let v441 : char list = v434 |> Array.toList
                                    let v445 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                                    let v446 : (char -> (UH0 -> UH0)) = method28()
                                    let v447 : (char list -> (UH0 -> UH0)) = v445 v446
                                    let v448 : (UH0 -> UH0) = v447 v441
                                    let v449 : UH0 = UH0_0
                                    let v450 : UH0 = v448 v449
                                    let struct (v475 : System.Text.StringBuilder, v476 : int32, v477 : int32) = method29(v450, v380, v381, v382)
                                    US7_0(v389, v424, v475, v476, v477)
                                else
                                    let v480 : string = "\n"
                                    let v481 : int32 = v379.IndexOf v480 
                                    let v484 : int32 = v481 - 1
                                    let v485 : bool = -2 = v484
                                    let v493 : int32 =
                                        if v485 then
                                            let v487 : (string -> int32) = String.length
                                            let v488 : int32 = v487 v379
                                            let v491 : int32 = v488 + 1
                                            v491
                                        else
                                            let v492 : int32 = v484 + 1
                                            v492
                                    let v499 : int32 = 0 |> int32 
                                    let v512 : int32 = v493 |> int32 
                                    let v520 : int32 = v512 - 1
                                    let v522 : string = v379.[int v499..int v520]
                                    let v527 : string = $"parsing.p_char / expected: '{'"'}' / line: {v381} / col: {v382}
{v380}{v522}"
                                    let v530 : int32 = v382 - 1
                                    let v531 : int32 = 0
                                    let v532 : (string -> string) = method30(v530, v531)
                                    let v533 : string = ""
                                    let v534 : string = v532 v533
                                    let v535 : string = "^"
                                    let v536 : string = v534 + v535 
                                    let v538 : string = $"{v527}
{v536}
"
                                    US7_1(v538)
                        match v543 with
                        | US7_1(v550) -> (* Error *)
                            let v552 : string = $"parsing.between / expected closing delimiter / e: %A{v550} / input: %A{struct (v1, v2, v3, v4)} / rest1: %A{struct (v341, v342, v343, v344)} / rest2: %A{struct (v379, v380, v381, v382)}"
                            US8_1(v552)
                        | US7_0(v544, v545, v546, v547, v548) -> (* Ok *)
                            US8_0(v378, v545, v546, v547, v548)
            match v566 with
            | US8_1(v572) -> (* Error *)
                let v573 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure30()
                let v574 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure31()
                let v575 : UH3 = UH3_0
                let v576 : UH3 = UH3_1(v574, v575)
                let v577 : UH3 = UH3_1(v573, v576)
                let v578 : US8 = method66(v1, v2, v3, v4, v577)
                let v589 : US8 =
                    match v578 with
                    | US8_1(v586) -> (* Error *)
                        US8_1(v586)
                    | US8_0(v579, v580, v581, v582, v583) -> (* Ok *)
                        let v584 : string = ""
                        US8_0(v584, v580, v581, v582, v583)
                let v600 : US17 =
                    match v589 with
                    | US8_1(v597) -> (* Error *)
                        US17_1(v597)
                    | US8_0(v590, v591, v592, v593, v594) -> (* Ok *)
                        let v595 : UH2 = UH2_0
                        method69(v595, v591, v592, v593, v594)
                match v600 with
                | US17_1(v628) -> (* Error *)
                    US8_1(v628)
                | US17_0(v601, v602, v603, v604, v605) -> (* Ok *)
                    let v606 : string list = []
                    let v607 : string list = method68(v601, v606)
                    let v611 : unit = ()
                    let _let'_v611 =
                        seq {
                            yield! v607 
                            (* indent
                            ()
                        indent *)
                        }
                        (* indent
                        ()
                    indent *)
                    let v614 : string seq = _let'_v611 
                    let v621 : (string -> (string seq -> string)) = String.concat
                    let v622 : string = ""
                    let v623 : (string seq -> string) = v621 v622
                    let v624 : string = v623 v614
                    US8_0(v624, v602, v603, v604, v605)
            | US8_0(v567, v568, v569, v570, v571) -> (* Ok *)
                v566
        | US8_0(v174, v175, v176, v177, v178) -> (* Ok *)
            v173
    match v635 with
    | US8_1(v698) -> (* Error *)
        let v699 : UH2 = UH2_0
        let v700 : UH2 = method67(v0, v699)
        US17_0(v700, v1, v2, v3, v4)
    | US8_0(v636, v637, v638, v639, v640) -> (* Ok *)
        let v641 : int32 = 0
        let v642 : int32 = method37(v637, v641)
        let v643 : bool = 0 = v642
        let v684 : US10 =
            if v643 then
                let v644 : string = "parsing.spaces1 / expected at least one space"
                US10_1(v644)
            else
                let v647 : (string -> int32) = String.length
                let v648 : int32 = v647 v637
                let v656 : int32 = v642 |> int32 
                let v669 : int32 = v648 |> int32 
                let v677 : int32 = v669 - 1
                let v679 : string = v637.[int v656..int v677]
                US10_0(v679, v638, v639, v640)
        match v684 with
        | US10_1(v691) -> (* Error *)
            let v692 : UH2 = UH2_0
            let v693 : UH2 = UH2_1(v636, v692)
            let v694 : UH2 = method67(v0, v693)
            US17_0(v694, v637, v638, v639, v640)
        | US10_0(v685, v686, v687, v688) -> (* Ok *)
            let v689 : UH2 = UH2_1(v636, v0)
            method61(v689, v685, v686, v687, v688)
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
    let v8 : string = ""
    let v9 : string = v4 |> Option.defaultValue v8 
    let v12 : string = method26()
    let v14 : (string -> System.Text.StringBuilder) = System.Text.StringBuilder 
    let v15 : System.Text.StringBuilder = v14 v12
    let v18 : UH2 = UH2_0
    let v19 : int32 = 1
    let v20 : int32 = 1
    let v21 : US17 = method61(v18, v9, v15, v19, v20)
    match v21 with
    | US17_1(v35) -> (* Error *)
        US16_1(v35)
    | US17_0(v22, v23, v24, v25, v26) -> (* Ok *)
        let v27 : string list = []
        let v28 : string list = method68(v22, v27)
        let v30 : (string list -> (string [])) = List.toArray
        let v31 : (string []) = v30 v28
        US16_0(v31)
and closure29 () (v0 : string) : Result<(string []), string> =
    let v1 : US16 = method60(v0)
    match v1 with
    | US16_1(v4) -> (* Error *)
        let v5 : Result<(string []), string> = Error v4 
        v5
    | US16_0(v2) -> (* Ok *)
        let v3 : Result<(string []), string> = Ok v2 
        v3
let v0 : unit = ()
let v1 : (unit -> unit) = closure0()
let v2 : unit = (fun () -> v1 (); v0) ()
let v17 : (unit -> unit) = closure3()
let current_process_kill () = v17 ()
let v18 : (string -> Async<struct (int32 * string)>) = closure13()
let execute_async x = v18 x
let v19 : (struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option) -> Async<struct (int32 * string)>) = closure27()
let execute_with_options_async x = v19 x
let v20 : ((Heap0 -> Heap0) -> struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option)) = closure28()
let execution_options x = v20 x
let v21 : (string -> Result<(string []), string>) = closure29()
let split_args x = v21 x
()
