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
    let v52 : (string -> US5) = method5()
    let v53 : US5 option = v47 |> Option.map v52 
    let v67 : US5 = US5_1
    let v68 : US5 = v53 |> Option.defaultValue v67 
    let v75 : string =
        match v68 with
        | US5_1 -> (* None *)
            let v73 : string = ""
            v73
        | US5_0(v72) -> (* Some *)
            v72
    let _run_target_args'_v5 = v75 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : US3 = US3_1
    let v77 : US4 = US4_1(v76)
    let v78 : string = $"env.get_environment_variable / target: {v77} / var: {v0}"
    let v79 : string = failwith<string> v78
    let _run_target_args'_v5 = v79 
    #endif
#else
    let v80 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v81 : string = v80 v0
    let mutable _v81 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v83 : (string -> string option) = Option.ofObj
    let v84 : string option = v83 v81
    v84 
    #else
    Some v81 
    #endif
    |> fun x -> _v81 <- Some x
    let v85 : string option = match _v81 with Some x -> x | None -> failwith "optionm'.of_obj / _v81=None"
    let v90 : (string -> US5) = method5()
    let v91 : US5 option = v85 |> Option.map v90 
    let v105 : US5 = US5_1
    let v106 : US5 = v91 |> Option.defaultValue v105 
    let v113 : string =
        match v106 with
        | US5_1 -> (* None *)
            let v111 : string = ""
            v111
        | US5_0(v110) -> (* Some *)
            v110
    let _run_target_args'_v5 = v113 
    #endif
    let v114 : string = _run_target_args'_v5 
    v114
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
    let v167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v170 : (int64 -> US2) = method9()
    let v171 : US2 option = v5 |> Option.map v170 
    let v185 : US2 = US2_1
    let v186 : US2 = v171 |> Option.defaultValue v185 
    let v304 : System.DateTime =
        match v186 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v287 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v288 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v288 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v289 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v289 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v291 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v287 = v291 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v294 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v294 
            #endif
#if FABLE_COMPILER_PYTHON
            let v295 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v295 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v296 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v296 
            #endif
#else
            let v297 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v297 
            #endif
            let v298 : System.DateTime = _run_target_args'_v287 
            v298
        | US2_0(v190) -> (* Some *)
            (* run_target_args'
            let v193 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v194 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v194 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v195 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v195 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v197 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v193 = v197 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v200 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v200 
            #endif
#if FABLE_COMPILER_PYTHON
            let v201 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v201 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v202 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v202 
            #endif
#else
            let v203 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v203 
            #endif
            let v204 : System.DateTime = _run_target_args'_v193 
            (* run_target_args'
            let v212 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v213 : (System.DateTime -> int64) = _.Ticks
            let v214 : int64 = v213 v204
            let _run_target_args'_v212 = v214 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v215 : (System.DateTime -> int64) = _.Ticks
            let v216 : int64 = v215 v204
            let _run_target_args'_v212 = v216 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : int64 = null |> unbox<int64>
            let _run_target_args'_v212 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : (System.DateTime -> int64) = _.Ticks
            let v222 : int64 = v221 v204
            let _run_target_args'_v212 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v223 : (System.DateTime -> int64) = _.Ticks
            let v224 : int64 = v223 v204
            let _run_target_args'_v212 = v224 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v225 : (System.DateTime -> int64) = _.Ticks
            let v226 : int64 = v225 v204
            let _run_target_args'_v212 = v226 
            #endif
#else
            let v227 : (System.DateTime -> int64) = _.Ticks
            let v228 : int64 = v227 v204
            let _run_target_args'_v212 = v228 
            #endif
            let v229 : int64 = _run_target_args'_v212 
            let v250 : int64 = v229 |> int64 
            let v253 : int64 = v250 - v190
            let v256 : System.TimeSpan = v253 |> System.TimeSpan 
            let v262 : (System.TimeSpan -> int32) = _.Hours
            let v263 : int32 = v262 v256
            let v267 : (System.TimeSpan -> int32) = _.Minutes
            let v268 : int32 = v267 v256
            let v272 : (System.TimeSpan -> int32) = _.Seconds
            let v273 : int32 = v272 v256
            let v277 : (System.TimeSpan -> int32) = _.Milliseconds
            let v278 : int32 = v277 v256
            let v282 : System.DateTime = System.DateTime (1, 1, 1, v263, v268, v273, v278)
            v282
    let v306 : string = method10()
    let v310 : bool = v306 = ""
    let v312 : string =
        if v310 then
            let v311 : string = "M-d-y hh:mm:ss tt"
            v311
        else
            v306
    let v313 : (string -> string) = v304.ToString
    let v314 : string = v313 v312
    let _run_target_args'_v167 = v314 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v331 : (int64 -> US2) = method9()
    let v332 : US2 option = v5 |> Option.map v331 
    let v346 : US2 = US2_1
    let v347 : US2 = v332 |> Option.defaultValue v346 
    let v465 : System.DateTime =
        match v347 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v448 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v449 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v449 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v450 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v450 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v452 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v448 = v452 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v455 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v455 
            #endif
#if FABLE_COMPILER_PYTHON
            let v456 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v456 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v457 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v457 
            #endif
#else
            let v458 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v458 
            #endif
            let v459 : System.DateTime = _run_target_args'_v448 
            v459
        | US2_0(v351) -> (* Some *)
            (* run_target_args'
            let v354 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v355 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v355 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v356 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v356 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v358 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v354 = v358 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v361 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v361 
            #endif
#if FABLE_COMPILER_PYTHON
            let v362 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v362 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v363 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v363 
            #endif
#else
            let v364 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v364 
            #endif
            let v365 : System.DateTime = _run_target_args'_v354 
            (* run_target_args'
            let v373 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v374 : (System.DateTime -> int64) = _.Ticks
            let v375 : int64 = v374 v365
            let _run_target_args'_v373 = v375 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v376 : (System.DateTime -> int64) = _.Ticks
            let v377 : int64 = v376 v365
            let _run_target_args'_v373 = v377 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v379 : int64 = null |> unbox<int64>
            let _run_target_args'_v373 = v379 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v382 : (System.DateTime -> int64) = _.Ticks
            let v383 : int64 = v382 v365
            let _run_target_args'_v373 = v383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v384 : (System.DateTime -> int64) = _.Ticks
            let v385 : int64 = v384 v365
            let _run_target_args'_v373 = v385 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v386 : (System.DateTime -> int64) = _.Ticks
            let v387 : int64 = v386 v365
            let _run_target_args'_v373 = v387 
            #endif
#else
            let v388 : (System.DateTime -> int64) = _.Ticks
            let v389 : int64 = v388 v365
            let _run_target_args'_v373 = v389 
            #endif
            let v390 : int64 = _run_target_args'_v373 
            let v411 : int64 = v390 |> int64 
            let v414 : int64 = v411 - v351
            let v417 : System.TimeSpan = v414 |> System.TimeSpan 
            let v423 : (System.TimeSpan -> int32) = _.Hours
            let v424 : int32 = v423 v417
            let v428 : (System.TimeSpan -> int32) = _.Minutes
            let v429 : int32 = v428 v417
            let v433 : (System.TimeSpan -> int32) = _.Seconds
            let v434 : int32 = v433 v417
            let v438 : (System.TimeSpan -> int32) = _.Milliseconds
            let v439 : int32 = v438 v417
            let v443 : System.DateTime = System.DateTime (1, 1, 1, v424, v429, v434, v439)
            v443
    let v467 : string = method10()
    let v471 : bool = v467 = ""
    let v473 : string =
        if v471 then
            let v472 : string = "M-d-y hh:mm:ss tt"
            v472
        else
            v467
    let v474 : (string -> string) = v465.ToString
    let v475 : string = v474 v473
    let _run_target_args'_v167 = v475 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v490 : string = $"near_sdk::env::block_timestamp()"
    let v491 : uint64 = Fable.Core.RustInterop.emitRustExpr () v490 
    let v494 : (int64 -> US2) = method9()
    let v495 : US2 option = v5 |> Option.map v494 
    let v509 : US2 = US2_1
    let v510 : US2 = v495 |> Option.defaultValue v509 
    let v522 : uint64 =
        match v510 with
        | US2_1 -> (* None *)
            v491
        | US2_0(v514) -> (* Some *)
            let v516 : (int64 -> uint64) = uint64
            let v517 : uint64 = v516 v514
            let v520 : uint64 = v491 - v517
            v520
    let v523 : uint64 = v522 / 1000000000UL
    let v524 : uint64 = v523 % 60UL
    let v525 : uint64 = v523 / 60UL
    let v526 : uint64 = v525 % 60UL
    let v527 : uint64 = v523 / 3600UL
    let v528 : uint64 = v527 % 24UL
    let v529 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v530 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v528, v526, v524) v529 
    let v531 : string = "fable_library_rust::String_::fromString($0)"
    let v532 : string = Fable.Core.RustInterop.emitRustExpr v530 v531 
    let _run_target_args'_v167 = v532 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v535 : (int64 -> US2) = method9()
    let v536 : US2 option = v5 |> Option.map v535 
    let v550 : US2 = US2_1
    let v551 : US2 = v536 |> Option.defaultValue v550 
    let v669 : System.DateTime =
        match v551 with
        | US2_1 -> (* None *)
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
            v663
        | US2_0(v555) -> (* Some *)
            (* run_target_args'
            let v558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v559 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v559 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v560 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v560 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v562 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v558 = v562 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v565 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v565 
            #endif
#if FABLE_COMPILER_PYTHON
            let v566 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v566 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v567 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v567 
            #endif
#else
            let v568 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v568 
            #endif
            let v569 : System.DateTime = _run_target_args'_v558 
            (* run_target_args'
            let v577 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v578 : (System.DateTime -> int64) = _.Ticks
            let v579 : int64 = v578 v569
            let _run_target_args'_v577 = v579 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v580 : (System.DateTime -> int64) = _.Ticks
            let v581 : int64 = v580 v569
            let _run_target_args'_v577 = v581 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v583 : int64 = null |> unbox<int64>
            let _run_target_args'_v577 = v583 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v586 : (System.DateTime -> int64) = _.Ticks
            let v587 : int64 = v586 v569
            let _run_target_args'_v577 = v587 
            #endif
#if FABLE_COMPILER_PYTHON
            let v588 : (System.DateTime -> int64) = _.Ticks
            let v589 : int64 = v588 v569
            let _run_target_args'_v577 = v589 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v590 : (System.DateTime -> int64) = _.Ticks
            let v591 : int64 = v590 v569
            let _run_target_args'_v577 = v591 
            #endif
#else
            let v592 : (System.DateTime -> int64) = _.Ticks
            let v593 : int64 = v592 v569
            let _run_target_args'_v577 = v593 
            #endif
            let v594 : int64 = _run_target_args'_v577 
            let v615 : int64 = v594 |> int64 
            let v618 : int64 = v615 - v555
            let v621 : System.TimeSpan = v618 |> System.TimeSpan 
            let v627 : (System.TimeSpan -> int32) = _.Hours
            let v628 : int32 = v627 v621
            let v632 : (System.TimeSpan -> int32) = _.Minutes
            let v633 : int32 = v632 v621
            let v637 : (System.TimeSpan -> int32) = _.Seconds
            let v638 : int32 = v637 v621
            let v642 : (System.TimeSpan -> int32) = _.Milliseconds
            let v643 : int32 = v642 v621
            let v647 : System.DateTime = System.DateTime (1, 1, 1, v628, v633, v638, v643)
            v647
    let v671 : string = method11()
    let v675 : bool = v671 = ""
    let v677 : string =
        if v675 then
            let v676 : string = "M-d-y hh:mm:ss tt"
            v676
        else
            v671
    let v678 : (string -> string) = v669.ToString
    let v679 : string = v678 v677
    let _run_target_args'_v167 = v679 
    #endif
#if FABLE_COMPILER_PYTHON
    let v696 : (int64 -> US2) = method9()
    let v697 : US2 option = v5 |> Option.map v696 
    let v711 : US2 = US2_1
    let v712 : US2 = v697 |> Option.defaultValue v711 
    let v830 : System.DateTime =
        match v712 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v813 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v814 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v814 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v815 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v815 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v817 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v813 = v817 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v820 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v820 
            #endif
#if FABLE_COMPILER_PYTHON
            let v821 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v821 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v822 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v822 
            #endif
#else
            let v823 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v823 
            #endif
            let v824 : System.DateTime = _run_target_args'_v813 
            v824
        | US2_0(v716) -> (* Some *)
            (* run_target_args'
            let v719 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v720 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v720 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v721 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v721 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v723 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v719 = v723 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v726 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v726 
            #endif
#if FABLE_COMPILER_PYTHON
            let v727 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v727 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v728 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v728 
            #endif
#else
            let v729 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v729 
            #endif
            let v730 : System.DateTime = _run_target_args'_v719 
            (* run_target_args'
            let v738 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v739 : (System.DateTime -> int64) = _.Ticks
            let v740 : int64 = v739 v730
            let _run_target_args'_v738 = v740 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v741 : (System.DateTime -> int64) = _.Ticks
            let v742 : int64 = v741 v730
            let _run_target_args'_v738 = v742 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v744 : int64 = null |> unbox<int64>
            let _run_target_args'_v738 = v744 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v747 : (System.DateTime -> int64) = _.Ticks
            let v748 : int64 = v747 v730
            let _run_target_args'_v738 = v748 
            #endif
#if FABLE_COMPILER_PYTHON
            let v749 : (System.DateTime -> int64) = _.Ticks
            let v750 : int64 = v749 v730
            let _run_target_args'_v738 = v750 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v751 : (System.DateTime -> int64) = _.Ticks
            let v752 : int64 = v751 v730
            let _run_target_args'_v738 = v752 
            #endif
#else
            let v753 : (System.DateTime -> int64) = _.Ticks
            let v754 : int64 = v753 v730
            let _run_target_args'_v738 = v754 
            #endif
            let v755 : int64 = _run_target_args'_v738 
            let v776 : int64 = v755 |> int64 
            let v779 : int64 = v776 - v716
            let v782 : System.TimeSpan = v779 |> System.TimeSpan 
            let v788 : (System.TimeSpan -> int32) = _.Hours
            let v789 : int32 = v788 v782
            let v793 : (System.TimeSpan -> int32) = _.Minutes
            let v794 : int32 = v793 v782
            let v798 : (System.TimeSpan -> int32) = _.Seconds
            let v799 : int32 = v798 v782
            let v803 : (System.TimeSpan -> int32) = _.Milliseconds
            let v804 : int32 = v803 v782
            let v808 : System.DateTime = System.DateTime (1, 1, 1, v789, v794, v799, v804)
            v808
    let v832 : string = method11()
    let v836 : bool = v832 = ""
    let v838 : string =
        if v836 then
            let v837 : string = "M-d-y hh:mm:ss tt"
            v837
        else
            v832
    let v839 : (string -> string) = v830.ToString
    let v840 : string = v839 v838
    let _run_target_args'_v167 = v840 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v857 : (int64 -> US2) = method9()
    let v858 : US2 option = v5 |> Option.map v857 
    let v872 : US2 = US2_1
    let v873 : US2 = v858 |> Option.defaultValue v872 
    let v991 : System.DateTime =
        match v873 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v974 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v975 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v975 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v976 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v976 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v978 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v974 = v978 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v981 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v981 
            #endif
#if FABLE_COMPILER_PYTHON
            let v982 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v982 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v983 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v983 
            #endif
#else
            let v984 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v984 
            #endif
            let v985 : System.DateTime = _run_target_args'_v974 
            v985
        | US2_0(v877) -> (* Some *)
            (* run_target_args'
            let v880 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v881 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v881 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v882 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v882 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v884 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v880 = v884 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v887 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v887 
            #endif
#if FABLE_COMPILER_PYTHON
            let v888 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v888 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v889 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v889 
            #endif
#else
            let v890 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v890 
            #endif
            let v891 : System.DateTime = _run_target_args'_v880 
            (* run_target_args'
            let v899 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v900 : (System.DateTime -> int64) = _.Ticks
            let v901 : int64 = v900 v891
            let _run_target_args'_v899 = v901 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v902 : (System.DateTime -> int64) = _.Ticks
            let v903 : int64 = v902 v891
            let _run_target_args'_v899 = v903 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v905 : int64 = null |> unbox<int64>
            let _run_target_args'_v899 = v905 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v908 : (System.DateTime -> int64) = _.Ticks
            let v909 : int64 = v908 v891
            let _run_target_args'_v899 = v909 
            #endif
#if FABLE_COMPILER_PYTHON
            let v910 : (System.DateTime -> int64) = _.Ticks
            let v911 : int64 = v910 v891
            let _run_target_args'_v899 = v911 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v912 : (System.DateTime -> int64) = _.Ticks
            let v913 : int64 = v912 v891
            let _run_target_args'_v899 = v913 
            #endif
#else
            let v914 : (System.DateTime -> int64) = _.Ticks
            let v915 : int64 = v914 v891
            let _run_target_args'_v899 = v915 
            #endif
            let v916 : int64 = _run_target_args'_v899 
            let v937 : int64 = v916 |> int64 
            let v940 : int64 = v937 - v877
            let v943 : System.TimeSpan = v940 |> System.TimeSpan 
            let v949 : (System.TimeSpan -> int32) = _.Hours
            let v950 : int32 = v949 v943
            let v954 : (System.TimeSpan -> int32) = _.Minutes
            let v955 : int32 = v954 v943
            let v959 : (System.TimeSpan -> int32) = _.Seconds
            let v960 : int32 = v959 v943
            let v964 : (System.TimeSpan -> int32) = _.Milliseconds
            let v965 : int32 = v964 v943
            let v969 : System.DateTime = System.DateTime (1, 1, 1, v950, v955, v960, v965)
            v969
    let v993 : string = method11()
    let v997 : bool = v993 = ""
    let v999 : string =
        if v997 then
            let v998 : string = "M-d-y hh:mm:ss tt"
            v998
        else
            v993
    let v1000 : (string -> string) = v991.ToString
    let v1001 : string = v1000 v999
    let _run_target_args'_v167 = v1001 
    #endif
#else
    let v1018 : (int64 -> US2) = method9()
    let v1019 : US2 option = v5 |> Option.map v1018 
    let v1033 : US2 = US2_1
    let v1034 : US2 = v1019 |> Option.defaultValue v1033 
    let v1152 : System.DateTime =
        match v1034 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1135 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1136 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1136 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1137 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1137 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1139 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1135 = v1139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1142 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1142 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1143 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1144 
            #endif
#else
            let v1145 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1145 
            #endif
            let v1146 : System.DateTime = _run_target_args'_v1135 
            v1146
        | US2_0(v1038) -> (* Some *)
            (* run_target_args'
            let v1041 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1042 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1042 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1043 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1043 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1045 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1041 = v1045 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1048 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1048 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1049 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1049 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1050 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1050 
            #endif
#else
            let v1051 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1051 
            #endif
            let v1052 : System.DateTime = _run_target_args'_v1041 
            (* run_target_args'
            let v1060 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1061 : (System.DateTime -> int64) = _.Ticks
            let v1062 : int64 = v1061 v1052
            let _run_target_args'_v1060 = v1062 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1063 : (System.DateTime -> int64) = _.Ticks
            let v1064 : int64 = v1063 v1052
            let _run_target_args'_v1060 = v1064 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1066 : int64 = null |> unbox<int64>
            let _run_target_args'_v1060 = v1066 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1069 : (System.DateTime -> int64) = _.Ticks
            let v1070 : int64 = v1069 v1052
            let _run_target_args'_v1060 = v1070 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1071 : (System.DateTime -> int64) = _.Ticks
            let v1072 : int64 = v1071 v1052
            let _run_target_args'_v1060 = v1072 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1073 : (System.DateTime -> int64) = _.Ticks
            let v1074 : int64 = v1073 v1052
            let _run_target_args'_v1060 = v1074 
            #endif
#else
            let v1075 : (System.DateTime -> int64) = _.Ticks
            let v1076 : int64 = v1075 v1052
            let _run_target_args'_v1060 = v1076 
            #endif
            let v1077 : int64 = _run_target_args'_v1060 
            let v1098 : int64 = v1077 |> int64 
            let v1101 : int64 = v1098 - v1038
            let v1104 : System.TimeSpan = v1101 |> System.TimeSpan 
            let v1110 : (System.TimeSpan -> int32) = _.Hours
            let v1111 : int32 = v1110 v1104
            let v1115 : (System.TimeSpan -> int32) = _.Minutes
            let v1116 : int32 = v1115 v1104
            let v1120 : (System.TimeSpan -> int32) = _.Seconds
            let v1121 : int32 = v1120 v1104
            let v1125 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1126 : int32 = v1125 v1104
            let v1130 : System.DateTime = System.DateTime (1, 1, 1, v1111, v1116, v1121, v1126)
            v1130
    let v1154 : string = method11()
    let v1158 : bool = v1154 = ""
    let v1160 : string =
        if v1158 then
            let v1159 : string = "M-d-y hh:mm:ss tt"
            v1159
        else
            v1154
    let v1161 : (string -> string) = v1152.ToString
    let v1162 : string = v1161 v1160
    let _run_target_args'_v167 = v1162 
    #endif
    let v1177 : string = _run_target_args'_v167 
    v1177
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
    let v38 : char list = []
    let v40 : char list = '/' :: v38 
    let v44 : char list = ' ' :: v40 
    let v49 : (char list -> (char [])) = List.toArray
    let v50 : (char []) = v49 v44
    let v53 : string = v8.TrimEnd v50 
    v53
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
            let v70 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
            let v71 : (char -> (UH0 -> UH0)) = method28()
            let v72 : (char list -> (UH0 -> UH0)) = v70 v71
            let v73 : (UH0 -> UH0) = v72 v62
            let v74 : UH0 = UH0_0
            let v75 : UH0 = v73 v74
            let struct (v104 : System.Text.StringBuilder, v105 : int32, v106 : int32) = method29(v75, v1, v2, v3)
            US7_0(v10, v45, v104, v105, v106)
        else
            let v109 : string = "\n"
            let v110 : int32 = v0.IndexOf v109 
            let v113 : int32 = v110 - 1
            let v114 : bool = -2 = v113
            let v122 : int32 =
                if v114 then
                    let v116 : (string -> int32) = String.length
                    let v117 : int32 = v116 v0
                    let v120 : int32 = v117 + 1
                    v120
                else
                    let v121 : int32 = v113 + 1
                    v121
            let v128 : int32 = 0 |> int32 
            let v141 : int32 = v122 |> int32 
            let v149 : int32 = v141 - 1
            let v151 : string = v0.[int v128..int v149]
            let v156 : string = $"parsing.p_char / expected: '{'"'}' / line: {v2} / col: {v3}
{v1}{v151}"
            let v159 : int32 = v3 - 1
            let v160 : int32 = 0
            let v161 : (string -> string) = method30(v159, v160)
            let v162 : string = ""
            let v163 : string = v161 v162
            let v164 : string = "^"
            let v165 : string = v163 + v164 
            let v167 : string = $"{v156}
{v165}
"
            US7_1(v167)
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
            let v70 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
            let v71 : (char -> (UH0 -> UH0)) = method28()
            let v72 : (char list -> (UH0 -> UH0)) = v70 v71
            let v73 : (UH0 -> UH0) = v72 v62
            let v74 : UH0 = UH0_0
            let v75 : UH0 = v73 v74
            let struct (v104 : System.Text.StringBuilder, v105 : int32, v106 : int32) = method29(v75, v1, v2, v3)
            US7_0(v10, v45, v104, v105, v106)
        else
            let v109 : string = "\n"
            let v110 : int32 = v0.IndexOf v109 
            let v113 : int32 = v110 - 1
            let v114 : bool = -2 = v113
            let v122 : int32 =
                if v114 then
                    let v116 : (string -> int32) = String.length
                    let v117 : int32 = v116 v0
                    let v120 : int32 = v117 + 1
                    v120
                else
                    let v121 : int32 = v113 + 1
                    v121
            let v128 : int32 = 0 |> int32 
            let v141 : int32 = v122 |> int32 
            let v149 : int32 = v141 - 1
            let v151 : string = v0.[int v128..int v149]
            let v156 : string = $"parsing.p_char / expected: '{'''}' / line: {v2} / col: {v3}
{v1}{v151}"
            let v159 : int32 = v3 - 1
            let v160 : int32 = 0
            let v161 : (string -> string) = method30(v159, v160)
            let v162 : string = ""
            let v163 : string = v161 v162
            let v164 : string = "^"
            let v165 : string = v163 + v164 
            let v167 : string = $"{v156}
{v165}
"
            US7_1(v167)
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
    let v145 : US7 =
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
                let v87 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v88 : (char -> (UH0 -> UH0)) = method28()
                let v89 : (char list -> (UH0 -> UH0)) = v87 v88
                let v90 : (UH0 -> UH0) = v89 v79
                let v91 : UH0 = UH0_0
                let v92 : UH0 = v90 v91
                let struct (v121 : System.Text.StringBuilder, v122 : int32, v123 : int32) = method29(v92, v2, v3, v4)
                US7_0(v25, v62, v121, v122, v123)
            else
                let v125 : char list = []
                let v127 : char list = ''' :: v125 
                let v131 : char list = '"' :: v127 
                let v135 : (char list -> (char [])) = List.toArray
                let v136 : (char []) = v135 v131
                let v140 : string = $"parsing.none_of / unexpected char: '{v25}' / chars: %A{v136} / s: %A{struct (v2, v3, v4)}"
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
        method33(v168, v159, v160, v161, v162)
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
    let v153 : US7 =
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
                let v91 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v92 : (char -> (UH0 -> UH0)) = method28()
                let v93 : (char list -> (UH0 -> UH0)) = v91 v92
                let v94 : (UH0 -> UH0) = v93 v83
                let v95 : UH0 = UH0_0
                let v96 : UH0 = v94 v95
                let struct (v125 : System.Text.StringBuilder, v126 : int32, v127 : int32) = method29(v96, v2, v3, v4)
                US7_0(v29, v66, v125, v126, v127)
            else
                let v129 : char list = []
                let v131 : char list = ' ' :: v129 
                let v135 : char list = ''' :: v131 
                let v139 : char list = '"' :: v135 
                let v143 : (char list -> (char [])) = List.toArray
                let v144 : (char []) = v143 v139
                let v148 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v144} / s: %A{struct (v2, v3, v4)}"
                US7_1(v148)
    let v165 : US7 =
        match v153 with
        | US7_1(v162) -> (* Error *)
            US7_1(v162)
        | US7_0(v154, v155, v156, v157, v158) -> (* Ok *)
            let v159 : bool = '\\' = v154
            let v160 : char =
                if v159 then
                    '/'
                else
                    v154
            US7_0(v160, v155, v156, v157, v158)
    match v165 with
    | US7_1(v182) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v166, v167, v168, v169, v170) -> (* Ok *)
        let v172 : (char -> string) = _.ToString()
        let v173 : string = v172 v166
        let v176 : string = v0 + v173 
        method36(v176, v167, v168, v169, v170)
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
    let v108 : US7 =
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
            let v70 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
            let v71 : (char -> (UH0 -> UH0)) = method28()
            let v72 : (char list -> (UH0 -> UH0)) = v70 v71
            let v73 : (UH0 -> UH0) = v72 v62
            let v74 : UH0 = UH0_0
            let v75 : UH0 = v73 v74
            let struct (v104 : System.Text.StringBuilder, v105 : int32, v106 : int32) = method29(v75, v2, v3, v4)
            US7_0(v11, v45, v104, v105, v106)
    match v108 with
    | US7_1(v125) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v109, v110, v111, v112, v113) -> (* Ok *)
        let v115 : (char -> string) = _.ToString()
        let v116 : string = v115 v109
        let v119 : string = v0 + v116 
        method38(v119, v110, v111, v112, v113)
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
    let v20 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US7) = closure18()
    let v21 : UH1 = UH1_0
    let v22 : UH1 = UH1_1(v20, v21)
    let v23 : UH1 = UH1_1(v19, v22)
    let v24 : US7 = method31(v10, v16, v23)
    let v244 : US8 =
        match v24 with
        | US7_1(v241) -> (* Error *)
            US8_1(v241)
        | US7_0(v25, v26, v27, v28, v29) -> (* Ok *)
            let v30 : bool = "" = v26
            let v170 : US7 =
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
                    let v52 : bool = method32(v50, v51)
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
                        let v96 : int32 = v93.Length
                        let v97 : (char []) = Array.zeroCreate<char> (v96)
                        let v98 : Mut5 = {l0 = 0} : Mut5
                        while method27(v96, v98) do
                            let v100 : int32 = v98.l0
                            let v101 : char = v93.[int v100]
                            v97.[int v100] <- v101
                            let v102 : int32 = v100 + 1
                            v98.l0 <- v102
                            ()
                        let v104 : char list = v97 |> Array.toList
                        let v112 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v113 : (char -> (UH0 -> UH0)) = method28()
                        let v114 : (char list -> (UH0 -> UH0)) = v112 v113
                        let v115 : (UH0 -> UH0) = v114 v104
                        let v116 : UH0 = UH0_0
                        let v117 : UH0 = v115 v116
                        let struct (v146 : System.Text.StringBuilder, v147 : int32, v148 : int32) = method29(v117, v27, v28, v29)
                        US7_0(v50, v87, v146, v147, v148)
                    else
                        let v150 : char list = []
                        let v152 : char list = ''' :: v150 
                        let v156 : char list = '"' :: v152 
                        let v160 : (char list -> (char [])) = List.toArray
                        let v161 : (char []) = v160 v156
                        let v165 : string = $"parsing.none_of / unexpected char: '{v50}' / chars: %A{v161} / s: %A{struct (v27, v28, v29)}"
                        US7_1(v165)
            let v182 : US7 =
                match v170 with
                | US7_1(v179) -> (* Error *)
                    US7_1(v179)
                | US7_0(v171, v172, v173, v174, v175) -> (* Ok *)
                    let v176 : bool = '\\' = v171
                    let v177 : char =
                        if v176 then
                            '/'
                        else
                            v171
                    US7_0(v177, v172, v173, v174, v175)
            let v202 : US8 =
                match v182 with
                | US7_1(v199) -> (* Error *)
                    US8_1(v199)
                | US7_0(v183, v184, v185, v186, v187) -> (* Ok *)
                    let v189 : (char -> string) = _.ToString()
                    let v190 : string = v189 v183
                    let struct (v193 : string, v194 : string, v195 : System.Text.StringBuilder, v196 : int32, v197 : int32) = method33(v190, v184, v185, v186, v187)
                    US8_0(v193, v194, v195, v196, v197)
            let v212 : US8 =
                match v202 with
                | US8_1(v209) -> (* Error *)
                    US8_0(v9, v26, v27, v28, v29)
                | US8_0(v203, v204, v205, v206, v207) -> (* Ok *)
                    US8_0(v203, v204, v205, v206, v207)
            match v212 with
            | US8_1(v236) -> (* Error *)
                let v237 : string = "parsing.between / expected content"
                US8_1(v237)
            | US8_0(v213, v214, v215, v216, v217) -> (* Ok *)
                let v218 : UH1 = UH1_0
                let v219 : UH1 = UH1_1(v20, v218)
                let v220 : UH1 = UH1_1(v19, v219)
                let v221 : US7 = method34(v214, v215, v216, v217, v220)
                match v221 with
                | US7_1(v228) -> (* Error *)
                    let v230 : string = $"parsing.between / expected closing delimiter / e: %A{v228} / input: %A{struct (v10, v16, 1, 1)} / rest1: %A{struct (v26, v27, v28, v29)} / rest2: %A{struct (v214, v215, v216, v217)}"
                    US8_1(v230)
                | US7_0(v222, v223, v224, v225, v226) -> (* Ok *)
                    US8_0(v213, v223, v224, v225, v226)
    let v510 : US8 =
        match v244 with
        | US8_1(v250) -> (* Error *)
            let v251 : bool = "" = v10
            let v401 : US7 =
                if v251 then
                    let v252 : char list = []
                    let v254 : char list = ' ' :: v252 
                    let v258 : char list = ''' :: v254 
                    let v262 : char list = '"' :: v258 
                    let v266 : (char list -> (char [])) = List.toArray
                    let v267 : (char []) = v266 v262
                    let v271 : string = $"parsing.none_of / unexpected end of input / chars: %A{v267} / s: %A{struct (v16, 1, 1)}"
                    US7_1(v271)
                else
                    let v275 : char = v10.[int 0]
                    let v276 : int64 = 0L
                    let v277 : bool = method35(v275, v276)
                    let v278 : bool = v277 = false
                    if v278 then
                        let v280 : (string -> int32) = String.length
                        let v281 : int32 = v280 v10
                        let v289 : int32 = 1 |> int32 
                        let v302 : int32 = v281 |> int32 
                        let v310 : int32 = v302 - 1
                        let v312 : string = v10.[int v289..int v310]
                        let v317 : (char -> string) = _.ToString()
                        let v318 : string = v317 v275
                        let v321 : int32 = v318.Length
                        let v322 : (char []) = Array.zeroCreate<char> (v321)
                        let v323 : Mut5 = {l0 = 0} : Mut5
                        while method27(v321, v323) do
                            let v325 : int32 = v323.l0
                            let v326 : char = v318.[int v325]
                            v322.[int v325] <- v326
                            let v327 : int32 = v325 + 1
                            v323.l0 <- v327
                            ()
                        let v329 : char list = v322 |> Array.toList
                        let v337 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v338 : (char -> (UH0 -> UH0)) = method28()
                        let v339 : (char list -> (UH0 -> UH0)) = v337 v338
                        let v340 : (UH0 -> UH0) = v339 v329
                        let v341 : UH0 = UH0_0
                        let v342 : UH0 = v340 v341
                        let v371 : int32 = 1
                        let v372 : int32 = 1
                        let struct (v373 : System.Text.StringBuilder, v374 : int32, v375 : int32) = method29(v342, v16, v371, v372)
                        US7_0(v275, v312, v373, v374, v375)
                    else
                        let v377 : char list = []
                        let v379 : char list = ' ' :: v377 
                        let v383 : char list = ''' :: v379 
                        let v387 : char list = '"' :: v383 
                        let v391 : (char list -> (char [])) = List.toArray
                        let v392 : (char []) = v391 v387
                        let v396 : string = $"parsing.none_of / unexpected char: '{v275}' / chars: %A{v392} / s: %A{struct (v16, 1, 1)}"
                        US7_1(v396)
            let v413 : US7 =
                match v401 with
                | US7_1(v410) -> (* Error *)
                    US7_1(v410)
                | US7_0(v402, v403, v404, v405, v406) -> (* Ok *)
                    let v407 : bool = '\\' = v402
                    let v408 : char =
                        if v407 then
                            '/'
                        else
                            v402
                    US7_0(v408, v403, v404, v405, v406)
            let v433 : US8 =
                match v413 with
                | US7_1(v430) -> (* Error *)
                    US8_1(v430)
                | US7_0(v414, v415, v416, v417, v418) -> (* Ok *)
                    let v420 : (char -> string) = _.ToString()
                    let v421 : string = v420 v414
                    let struct (v424 : string, v425 : string, v426 : System.Text.StringBuilder, v427 : int32, v428 : int32) = method36(v421, v415, v416, v417, v418)
                    US8_0(v424, v425, v426, v427, v428)
            match v433 with
            | US8_1(v439) -> (* Error *)
                let v440 : int32 = v10.Length
                let v441 : bool = v440 = 0
                let v448 : US10 =
                    if v441 then
                        US10_0(v10, v16, 1, 1)
                    else
                        let v444 : string = $"parsing.eof / expected end of input / input: %A{v10}"
                        US10_1(v444)
                let v457 : US8 =
                    match v448 with
                    | US10_1(v454) -> (* Error *)
                        US8_1(v454)
                    | US10_0(v449, v450, v451, v452) -> (* Ok *)
                        US8_0(v9, v449, v450, v451, v452)
                match v457 with
                | US8_1(v503) -> (* Error *)
                    US8_1(v503)
                | US8_0(v458, v459, v460, v461, v462) -> (* Ok *)
                    let v463 : int32 = 0
                    let v464 : int32 = method37(v459, v463)
                    let v466 : (string -> int32) = String.length
                    let v467 : int32 = v466 v459
                    let v475 : int32 = v464 |> int32 
                    let v488 : int32 = v467 |> int32 
                    let v496 : int32 = v488 - 1
                    let v498 : string = v459.[int v475..int v496]
                    US8_0(v458, v498, v460, v461, v462)
            | US8_0(v434, v435, v436, v437, v438) -> (* Ok *)
                v433
        | US8_0(v245, v246, v247, v248, v249) -> (* Ok *)
            v244
    let v854 : US11 =
        match v510 with
        | US8_1(v851) -> (* Error *)
            US11_1(v851)
        | US8_0(v511, v512, v513, v514, v515) -> (* Ok *)
            let v516 : bool = "" = v512
            let v683 : US7 =
                if v516 then
                    let v518 : string = $"parsing.p_char / unexpected end of input / c: '{' '}' / s: %A{struct (v513, v514, v515)}"
                    US7_1(v518)
                else
                    let v522 : char = v512.[int 0]
                    let v523 : bool = v522 = ' '
                    if v523 then
                        let v525 : (string -> int32) = String.length
                        let v526 : int32 = v525 v512
                        let v534 : int32 = 1 |> int32 
                        let v547 : int32 = v526 |> int32 
                        let v555 : int32 = v547 - 1
                        let v557 : string = v512.[int v534..int v555]
                        let v562 : (char -> string) = _.ToString()
                        let v563 : string = v562 v522
                        let v566 : int32 = v563.Length
                        let v567 : (char []) = Array.zeroCreate<char> (v566)
                        let v568 : Mut5 = {l0 = 0} : Mut5
                        while method27(v566, v568) do
                            let v570 : int32 = v568.l0
                            let v571 : char = v563.[int v570]
                            v567.[int v570] <- v571
                            let v572 : int32 = v570 + 1
                            v568.l0 <- v572
                            ()
                        let v574 : char list = v567 |> Array.toList
                        let v582 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v583 : (char -> (UH0 -> UH0)) = method28()
                        let v584 : (char list -> (UH0 -> UH0)) = v582 v583
                        let v585 : (UH0 -> UH0) = v584 v574
                        let v586 : UH0 = UH0_0
                        let v587 : UH0 = v585 v586
                        let struct (v616 : System.Text.StringBuilder, v617 : int32, v618 : int32) = method29(v587, v513, v514, v515)
                        US7_0(v522, v557, v616, v617, v618)
                    else
                        let v621 : string = "\n"
                        let v622 : int32 = v512.IndexOf v621 
                        let v625 : int32 = v622 - 1
                        let v626 : bool = -2 = v625
                        let v634 : int32 =
                            if v626 then
                                let v628 : (string -> int32) = String.length
                                let v629 : int32 = v628 v512
                                let v632 : int32 = v629 + 1
                                v632
                            else
                                let v633 : int32 = v625 + 1
                                v633
                        let v640 : int32 = 0 |> int32 
                        let v653 : int32 = v634 |> int32 
                        let v661 : int32 = v653 - 1
                        let v663 : string = v512.[int v640..int v661]
                        let v668 : string = $"parsing.p_char / expected: '{' '}' / line: {v514} / col: {v515}
{v513}{v663}"
                        let v671 : int32 = v515 - 1
                        let v672 : int32 = 0
                        let v673 : (string -> string) = method30(v671, v672)
                        let v674 : string = v673 v9
                        let v675 : string = "^"
                        let v676 : string = v674 + v675 
                        let v678 : string = $"{v668}
{v676}
"
                        US7_1(v678)
            let v695 : US12 =
                match v683 with
                | US7_1(v691) -> (* Error *)
                    let v692 : US9 = US9_1
                    US12_0(v692, v512, v513, v514, v515)
                | US7_0(v684, v685, v686, v687, v688) -> (* Ok *)
                    let v689 : US9 = US9_0(v684)
                    US12_0(v689, v685, v686, v687, v688)
            let v828 : US8 =
                match v695 with
                | US12_1(v825) -> (* Error *)
                    US8_1(v825)
                | US12_0(v696, v697, v698, v699, v700) -> (* Ok *)
                    let v701 : bool = "" = v697
                    let v804 : US7 =
                        if v701 then
                            let v703 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v698, v699, v700)}"
                            US7_1(v703)
                        else
                            let v707 : char = v697.[int 0]
                            let v709 : (string -> int32) = String.length
                            let v710 : int32 = v709 v697
                            let v718 : int32 = 1 |> int32 
                            let v731 : int32 = v710 |> int32 
                            let v739 : int32 = v731 - 1
                            let v741 : string = v697.[int v718..int v739]
                            let v746 : (char -> string) = _.ToString()
                            let v747 : string = v746 v707
                            let v750 : int32 = v747.Length
                            let v751 : (char []) = Array.zeroCreate<char> (v750)
                            let v752 : Mut5 = {l0 = 0} : Mut5
                            while method27(v750, v752) do
                                let v754 : int32 = v752.l0
                                let v755 : char = v747.[int v754]
                                v751.[int v754] <- v755
                                let v756 : int32 = v754 + 1
                                v752.l0 <- v756
                                ()
                            let v758 : char list = v751 |> Array.toList
                            let v766 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                            let v767 : (char -> (UH0 -> UH0)) = method28()
                            let v768 : (char list -> (UH0 -> UH0)) = v766 v767
                            let v769 : (UH0 -> UH0) = v768 v758
                            let v770 : UH0 = UH0_0
                            let v771 : UH0 = v769 v770
                            let struct (v800 : System.Text.StringBuilder, v801 : int32, v802 : int32) = method29(v771, v698, v699, v700)
                            US7_0(v707, v741, v800, v801, v802)
                    match v804 with
                    | US7_1(v821) -> (* Error *)
                        US8_1(v821)
                    | US7_0(v805, v806, v807, v808, v809) -> (* Ok *)
                        let v811 : (char -> string) = _.ToString()
                        let v812 : string = v811 v805
                        let struct (v815 : string, v816 : string, v817 : System.Text.StringBuilder, v818 : int32, v819 : int32) = method38(v812, v806, v807, v808, v809)
                        US8_0(v815, v816, v817, v818, v819)
            let v840 : US13 =
                match v828 with
                | US8_1(v836) -> (* Error *)
                    let v837 : US5 = US5_1
                    US13_0(v837, v512, v513, v514, v515)
                | US8_0(v829, v830, v831, v832, v833) -> (* Ok *)
                    let v834 : US5 = US5_0(v829)
                    US13_0(v834, v830, v831, v832, v833)
            match v840 with
            | US13_1(v847) -> (* Error *)
                US11_1(v847)
            | US13_0(v841, v842, v843, v844, v845) -> (* Ok *)
                US11_0(v511, v841, v842, v843, v844, v845)
    match v854 with
    | US11_1(v862) -> (* Error *)
        US6_1(v862)
    | US11_0(v855, v856, v857, v858, v859, v860) -> (* Ok *)
        US6_0(v855, v856)
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
                let v41 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v42 : US14 option = v3 |> Option.map v41 
                let v56 : US14 = US14_1
                let v57 : US14 = v42 |> Option.defaultValue v56 
                match v57 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v61) -> (* Some *)
                    let v62 : int32 = method47(v7)
                    let v63 : Async<unit> = v61 struct (v62, v32, v9)
                    do! v63 
                    ()
                let v66 : string =
                    if v9 then
                        let v64 : string = $"! {v32}"
                        v64
                    else
                        let v65 : string = $"> {v32}"
                        v65
                if v5 then
                    let v67 : unit = ()
                    let v68 : (unit -> unit) = closure22(v66)
                    let v69 : unit = (fun () -> v68 (); v67) ()
                    ()
                else
                    let v119 : unit = ()
                    let v120 : (unit -> unit) = closure10(v66)
                    let v121 : unit = (fun () -> v120 (); v119) ()
                    ()
                let v125 : string =
                    if v9 then
                        let v123 : string = "\u001b[7;4m"
                        v123
                    else
                        let v124 : string = ""
                        v124
                let v128 : string =
                    if v9 then
                        let v126 : string = "\u001b[0m"
                        v126
                    else
                        let v127 : string = ""
                        v127
                let v129 : string = $"{v125}{v32}{v128}"
                (* run_target_args'
                let v130 : unit = ()
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
                let v131 : (string -> unit) = v8.Push
                v131 v129
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
    let v832 : Async<unit> = _let'_v29 
    let _run_target_args'_v15 = v832 
    #endif
#if FABLE_COMPILER_PYTHON
    let v834 : unit = ()
    let _let'_v834 =
        async {
            let v837 : string = method45(v10)
            let v839 : string = null |> unbox<string>
            let v842 : bool = v837 = v839
            let v843 : bool = v842 <> true
            if v843 then
                let v846 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v847 : US14 option = v3 |> Option.map v846 
                let v861 : US14 = US14_1
                let v862 : US14 = v847 |> Option.defaultValue v861 
                match v862 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v866) -> (* Some *)
                    let v867 : int32 = method47(v7)
                    let v868 : Async<unit> = v866 struct (v867, v837, v9)
                    do! v868 
                    ()
                let v871 : string =
                    if v9 then
                        let v869 : string = $"! {v837}"
                        v869
                    else
                        let v870 : string = $"> {v837}"
                        v870
                if v5 then
                    let v872 : unit = ()
                    let v873 : (unit -> unit) = closure22(v871)
                    let v874 : unit = (fun () -> v873 (); v872) ()
                    ()
                else
                    let v924 : unit = ()
                    let v925 : (unit -> unit) = closure10(v871)
                    let v926 : unit = (fun () -> v925 (); v924) ()
                    ()
                let v930 : string =
                    if v9 then
                        let v928 : string = "\u001b[7;4m"
                        v928
                    else
                        let v929 : string = ""
                        v929
                let v933 : string =
                    if v9 then
                        let v931 : string = "\u001b[0m"
                        v931
                    else
                        let v932 : string = ""
                        v932
                let v934 : string = $"{v930}{v837}{v933}"
                (* run_target_args'
                let v935 : unit = ()
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
                let v936 : (string -> unit) = v8.Push
                v936 v934
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
    let v1637 : Async<unit> = _let'_v834 
    let _run_target_args'_v15 = v1637 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1639 : unit = ()
    let _let'_v1639 =
        async {
            let v1642 : string = method45(v10)
            let v1644 : string = null |> unbox<string>
            let v1647 : bool = v1642 = v1644
            let v1648 : bool = v1647 <> true
            if v1648 then
                let v1651 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v1652 : US14 option = v3 |> Option.map v1651 
                let v1666 : US14 = US14_1
                let v1667 : US14 = v1652 |> Option.defaultValue v1666 
                match v1667 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v1671) -> (* Some *)
                    let v1672 : int32 = method47(v7)
                    let v1673 : Async<unit> = v1671 struct (v1672, v1642, v9)
                    do! v1673 
                    ()
                let v1676 : string =
                    if v9 then
                        let v1674 : string = $"! {v1642}"
                        v1674
                    else
                        let v1675 : string = $"> {v1642}"
                        v1675
                if v5 then
                    let v1677 : unit = ()
                    let v1678 : (unit -> unit) = closure22(v1676)
                    let v1679 : unit = (fun () -> v1678 (); v1677) ()
                    ()
                else
                    let v1729 : unit = ()
                    let v1730 : (unit -> unit) = closure10(v1676)
                    let v1731 : unit = (fun () -> v1730 (); v1729) ()
                    ()
                let v1735 : string =
                    if v9 then
                        let v1733 : string = "\u001b[7;4m"
                        v1733
                    else
                        let v1734 : string = ""
                        v1734
                let v1738 : string =
                    if v9 then
                        let v1736 : string = "\u001b[0m"
                        v1736
                    else
                        let v1737 : string = ""
                        v1737
                let v1739 : string = $"{v1735}{v1642}{v1738}"
                (* run_target_args'
                let v1740 : unit = ()
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
                let v1741 : (string -> unit) = v8.Push
                v1741 v1739
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
    let v2442 : Async<unit> = _let'_v1639 
    let _run_target_args'_v15 = v2442 
    #endif
#else
    let v2444 : unit = ()
    let _let'_v2444 =
        async {
            let v2447 : string = method45(v10)
            let v2449 : string = null |> unbox<string>
            let v2452 : bool = v2447 = v2449
            let v2453 : bool = v2452 <> true
            if v2453 then
                let v2456 : ((struct (int32 * string * bool) -> Async<unit>) -> US14) = method46()
                let v2457 : US14 option = v3 |> Option.map v2456 
                let v2471 : US14 = US14_1
                let v2472 : US14 = v2457 |> Option.defaultValue v2471 
                match v2472 with
                | US14_1 -> (* None *)
                    ()
                | US14_0(v2476) -> (* Some *)
                    let v2477 : int32 = method47(v7)
                    let v2478 : Async<unit> = v2476 struct (v2477, v2447, v9)
                    do! v2478 
                    ()
                let v2481 : string =
                    if v9 then
                        let v2479 : string = $"! {v2447}"
                        v2479
                    else
                        let v2480 : string = $"> {v2447}"
                        v2480
                if v5 then
                    let v2482 : unit = ()
                    let v2483 : (unit -> unit) = closure22(v2481)
                    let v2484 : unit = (fun () -> v2483 (); v2482) ()
                    ()
                else
                    let v2534 : unit = ()
                    let v2535 : (unit -> unit) = closure10(v2481)
                    let v2536 : unit = (fun () -> v2535 (); v2534) ()
                    ()
                let v2540 : string =
                    if v9 then
                        let v2538 : string = "\u001b[7;4m"
                        v2538
                    else
                        let v2539 : string = ""
                        v2539
                let v2543 : string =
                    if v9 then
                        let v2541 : string = "\u001b[0m"
                        v2541
                    else
                        let v2542 : string = ""
                        v2542
                let v2544 : string = $"{v2540}{v2447}{v2543}"
                (* run_target_args'
                let v2545 : unit = ()
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
                let v2546 : (string -> unit) = v8.Push
                v2546 v2544
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
    let v3247 : Async<unit> = _let'_v2444 
    let _run_target_args'_v15 = v3247 
    #endif
    let v3248 : Async<unit> = _run_target_args'_v15 
    v3248
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
            let v101 : (string -> US5) = method5()
            let v102 : US5 option = v6 |> Option.map v101 
            let v116 : US5 = US5_1
            let v117 : US5 = v102 |> Option.defaultValue v116 
            let v124 : string =
                match v117 with
                | US5_1 -> (* None *)
                    let v122 : string = ""
                    v122
                | US5_0(v121) -> (* Some *)
                    v121
            let v125 : unit = ()
            let v126 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v98, v97)
            let v127 : unit = (fun () -> v126 (); v125) ()
            let v174 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v178 : string =
                match v98 with
                | US5_1 -> (* None *)
                    let v176 : string = ""
                    v176
                | US5_0(v175) -> (* Some *)
                    v175
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v178,
              StandardOutputEncoding = v174,
              WorkingDirectory = v124,
              FileName = v97,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v179 : System.Diagnostics.ProcessStartInfo = start_info
            let v180 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v181 : int32 = v180.Length
            let v182 : Mut5 = {l0 = 0} : Mut5
            while method27(v181, v182) do
                let v184 : int32 = v182.l0
                let struct (v185 : string, v186 : string) = v180.[int v184]
                v179.EnvironmentVariables.[v185] <- v186 
                let v187 : int32 = v184 + 1
                v182.l0 <- v187
                ()
            let v188 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v179)
            use v188 = v188 
            let v189 : System.Diagnostics.Process = v188 
            let v190 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v191 : System.Collections.Concurrent.ConcurrentStack<string> = v190 ()
            let v192 : bool = false
            let v193 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v189, v191, v192)
            v189.OutputDataReceived.Add v193 
            let v194 : bool = true
            let v195 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v189, v191, v194)
            v189.ErrorDataReceived.Add v195 
            let v196 : (unit -> bool) = v189.Start
            let v197 : bool = v196 ()
            let v198 : bool = v197 = false
            if v198 then
                let v199 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v199
            let v200 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v200 v189
            let v201 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v201 v189
            let v204 : (System.Threading.CancellationToken -> US15) = method50()
            let v205 : US15 option = v1 |> Option.map v204 
            let v219 : US15 = US15_1
            let v220 : US15 = v205 |> Option.defaultValue v219 
            let v227 : System.Threading.CancellationToken =
                match v220 with
                | US15_1 -> (* None *)
                    let v225 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v225
                | US15_0(v224) -> (* Some *)
                    v224
            let v228 : Async<System.Threading.CancellationToken> = method51(v227)
            let! v228 = v228 
            let v229 : System.Threading.CancellationToken = v228 
            let v230 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v229.Register
            let v231 : (unit -> unit) = closure24(v189)
            let v232 : System.Threading.CancellationTokenRegistration = v230 v231
            use v232 = v232 
            let v233 : System.Threading.CancellationTokenRegistration = v232 
            let v234 : Async<int32> = method54(v189, v191, v229)
            let! v234 = v234 
            let v235 : int32 = v234 
            let v237 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v238 : string seq = v237 v191
            let v242 : (string seq -> string seq) = Seq.rev
            let v243 : string seq = v242 v238
            let v247 : string = method57()
            let v248 : (string -> (string seq -> string)) = String.concat
            let v249 : (string seq -> string) = v248 v247
            let v250 : string = v249 v243
            let v254 : unit = ()
            let v255 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v235, v250)
            let v256 : unit = (fun () -> v255 (); v254) ()
            return struct (v235, v250) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2300 : Async<struct (int32 * string)> = _let'_v25 
    let _run_target_args'_v11 = v2300 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2302 : unit = ()
    let _let'_v2302 =
        async {
            (* run_target_args'
            let v2313 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v2316 : int32, v2317 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2316, v2317) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v2324 : int32, v2325 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2324, v2325) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v2332 : int32, v2333 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2332, v2333) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v2340 : int32, v2341 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2340, v2341) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v2348 : int32, v2349 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2348, v2349) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v2356 : int32, v2357 : string) = null |> unbox<struct (int32 * string)>
            return struct (v2356, v2357) 
            #endif
#else
            let v2362 : US6 = method25(v0)
            let struct (v2374 : string, v2375 : US5) =
                match v2362 with
                | US6_1(v2365) -> (* Error *)
                    let v2367 : string = $"resultm.get / Result value was Error: {v2365}"
                    failwith<struct (string * US5)> v2367
                | US6_0(v2363, v2364) -> (* Ok *)
                    struct (v2363, v2364)
            let v2378 : (string -> US5) = method5()
            let v2379 : US5 option = v6 |> Option.map v2378 
            let v2393 : US5 = US5_1
            let v2394 : US5 = v2379 |> Option.defaultValue v2393 
            let v2401 : string =
                match v2394 with
                | US5_1 -> (* None *)
                    let v2399 : string = ""
                    v2399
                | US5_0(v2398) -> (* Some *)
                    v2398
            let v2402 : unit = ()
            let v2403 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v2375, v2374)
            let v2404 : unit = (fun () -> v2403 (); v2402) ()
            let v2451 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v2455 : string =
                match v2375 with
                | US5_1 -> (* None *)
                    let v2453 : string = ""
                    v2453
                | US5_0(v2452) -> (* Some *)
                    v2452
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v2455,
              StandardOutputEncoding = v2451,
              WorkingDirectory = v2401,
              FileName = v2374,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v2456 : System.Diagnostics.ProcessStartInfo = start_info
            let v2457 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v2458 : int32 = v2457.Length
            let v2459 : Mut5 = {l0 = 0} : Mut5
            while method27(v2458, v2459) do
                let v2461 : int32 = v2459.l0
                let struct (v2462 : string, v2463 : string) = v2457.[int v2461]
                v2456.EnvironmentVariables.[v2462] <- v2463 
                let v2464 : int32 = v2461 + 1
                v2459.l0 <- v2464
                ()
            let v2465 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v2456)
            use v2465 = v2465 
            let v2466 : System.Diagnostics.Process = v2465 
            let v2467 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v2468 : System.Collections.Concurrent.ConcurrentStack<string> = v2467 ()
            let v2469 : bool = false
            let v2470 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v2466, v2468, v2469)
            v2466.OutputDataReceived.Add v2470 
            let v2471 : bool = true
            let v2472 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v2466, v2468, v2471)
            v2466.ErrorDataReceived.Add v2472 
            let v2473 : (unit -> bool) = v2466.Start
            let v2474 : bool = v2473 ()
            let v2475 : bool = v2474 = false
            if v2475 then
                let v2476 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v2476
            let v2477 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v2477 v2466
            let v2478 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v2478 v2466
            let v2481 : (System.Threading.CancellationToken -> US15) = method50()
            let v2482 : US15 option = v1 |> Option.map v2481 
            let v2496 : US15 = US15_1
            let v2497 : US15 = v2482 |> Option.defaultValue v2496 
            let v2504 : System.Threading.CancellationToken =
                match v2497 with
                | US15_1 -> (* None *)
                    let v2502 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v2502
                | US15_0(v2501) -> (* Some *)
                    v2501
            let v2505 : Async<System.Threading.CancellationToken> = method51(v2504)
            let! v2505 = v2505 
            let v2506 : System.Threading.CancellationToken = v2505 
            let v2507 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v2506.Register
            let v2508 : (unit -> unit) = closure24(v2466)
            let v2509 : System.Threading.CancellationTokenRegistration = v2507 v2508
            use v2509 = v2509 
            let v2510 : System.Threading.CancellationTokenRegistration = v2509 
            let v2511 : Async<int32> = method54(v2466, v2468, v2506)
            let! v2511 = v2511 
            let v2512 : int32 = v2511 
            let v2514 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v2515 : string seq = v2514 v2468
            let v2519 : (string seq -> string seq) = Seq.rev
            let v2520 : string seq = v2519 v2515
            let v2524 : string = method57()
            let v2525 : (string -> (string seq -> string)) = String.concat
            let v2526 : (string seq -> string) = v2525 v2524
            let v2527 : string = v2526 v2520
            let v2531 : unit = ()
            let v2532 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v2512, v2527)
            let v2533 : unit = (fun () -> v2532 (); v2531) ()
            return struct (v2512, v2527) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4577 : Async<struct (int32 * string)> = _let'_v2302 
    let _run_target_args'_v11 = v4577 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4579 : unit = ()
    let _let'_v4579 =
        async {
            (* run_target_args'
            let v4590 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v4593 : int32, v4594 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4593, v4594) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v4601 : int32, v4602 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4601, v4602) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v4609 : int32, v4610 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4609, v4610) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v4617 : int32, v4618 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4617, v4618) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v4625 : int32, v4626 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4625, v4626) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v4633 : int32, v4634 : string) = null |> unbox<struct (int32 * string)>
            return struct (v4633, v4634) 
            #endif
#else
            let v4639 : US6 = method25(v0)
            let struct (v4651 : string, v4652 : US5) =
                match v4639 with
                | US6_1(v4642) -> (* Error *)
                    let v4644 : string = $"resultm.get / Result value was Error: {v4642}"
                    failwith<struct (string * US5)> v4644
                | US6_0(v4640, v4641) -> (* Ok *)
                    struct (v4640, v4641)
            let v4655 : (string -> US5) = method5()
            let v4656 : US5 option = v6 |> Option.map v4655 
            let v4670 : US5 = US5_1
            let v4671 : US5 = v4656 |> Option.defaultValue v4670 
            let v4678 : string =
                match v4671 with
                | US5_1 -> (* None *)
                    let v4676 : string = ""
                    v4676
                | US5_0(v4675) -> (* Some *)
                    v4675
            let v4679 : unit = ()
            let v4680 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v4652, v4651)
            let v4681 : unit = (fun () -> v4680 (); v4679) ()
            let v4728 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v4732 : string =
                match v4652 with
                | US5_1 -> (* None *)
                    let v4730 : string = ""
                    v4730
                | US5_0(v4729) -> (* Some *)
                    v4729
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v4732,
              StandardOutputEncoding = v4728,
              WorkingDirectory = v4678,
              FileName = v4651,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v4733 : System.Diagnostics.ProcessStartInfo = start_info
            let v4734 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v4735 : int32 = v4734.Length
            let v4736 : Mut5 = {l0 = 0} : Mut5
            while method27(v4735, v4736) do
                let v4738 : int32 = v4736.l0
                let struct (v4739 : string, v4740 : string) = v4734.[int v4738]
                v4733.EnvironmentVariables.[v4739] <- v4740 
                let v4741 : int32 = v4738 + 1
                v4736.l0 <- v4741
                ()
            let v4742 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v4733)
            use v4742 = v4742 
            let v4743 : System.Diagnostics.Process = v4742 
            let v4744 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v4745 : System.Collections.Concurrent.ConcurrentStack<string> = v4744 ()
            let v4746 : bool = false
            let v4747 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v4743, v4745, v4746)
            v4743.OutputDataReceived.Add v4747 
            let v4748 : bool = true
            let v4749 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v4743, v4745, v4748)
            v4743.ErrorDataReceived.Add v4749 
            let v4750 : (unit -> bool) = v4743.Start
            let v4751 : bool = v4750 ()
            let v4752 : bool = v4751 = false
            if v4752 then
                let v4753 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v4753
            let v4754 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v4754 v4743
            let v4755 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v4755 v4743
            let v4758 : (System.Threading.CancellationToken -> US15) = method50()
            let v4759 : US15 option = v1 |> Option.map v4758 
            let v4773 : US15 = US15_1
            let v4774 : US15 = v4759 |> Option.defaultValue v4773 
            let v4781 : System.Threading.CancellationToken =
                match v4774 with
                | US15_1 -> (* None *)
                    let v4779 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v4779
                | US15_0(v4778) -> (* Some *)
                    v4778
            let v4782 : Async<System.Threading.CancellationToken> = method51(v4781)
            let! v4782 = v4782 
            let v4783 : System.Threading.CancellationToken = v4782 
            let v4784 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v4783.Register
            let v4785 : (unit -> unit) = closure24(v4743)
            let v4786 : System.Threading.CancellationTokenRegistration = v4784 v4785
            use v4786 = v4786 
            let v4787 : System.Threading.CancellationTokenRegistration = v4786 
            let v4788 : Async<int32> = method54(v4743, v4745, v4783)
            let! v4788 = v4788 
            let v4789 : int32 = v4788 
            let v4791 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v4792 : string seq = v4791 v4745
            let v4796 : (string seq -> string seq) = Seq.rev
            let v4797 : string seq = v4796 v4792
            let v4801 : string = method57()
            let v4802 : (string -> (string seq -> string)) = String.concat
            let v4803 : (string seq -> string) = v4802 v4801
            let v4804 : string = v4803 v4797
            let v4808 : unit = ()
            let v4809 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v4789, v4804)
            let v4810 : unit = (fun () -> v4809 (); v4808) ()
            return struct (v4789, v4804) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6854 : Async<struct (int32 * string)> = _let'_v4579 
    let _run_target_args'_v11 = v6854 
    #endif
#else
    let v6856 : unit = ()
    let _let'_v6856 =
        async {
            (* run_target_args'
            let v6867 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let struct (v6870 : int32, v6871 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6870, v6871) 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let struct (v6878 : int32, v6879 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6878, v6879) 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let struct (v6886 : int32, v6887 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6886, v6887) 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let struct (v6894 : int32, v6895 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6894, v6895) 
            #endif
#if FABLE_COMPILER_PYTHON
            let struct (v6902 : int32, v6903 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6902, v6903) 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let struct (v6910 : int32, v6911 : string) = null |> unbox<struct (int32 * string)>
            return struct (v6910, v6911) 
            #endif
#else
            let v6916 : US6 = method25(v0)
            let struct (v6928 : string, v6929 : US5) =
                match v6916 with
                | US6_1(v6919) -> (* Error *)
                    let v6921 : string = $"resultm.get / Result value was Error: {v6919}"
                    failwith<struct (string * US5)> v6921
                | US6_0(v6917, v6918) -> (* Ok *)
                    struct (v6917, v6918)
            let v6932 : (string -> US5) = method5()
            let v6933 : US5 option = v6 |> Option.map v6932 
            let v6947 : US5 = US5_1
            let v6948 : US5 = v6933 |> Option.defaultValue v6947 
            let v6955 : string =
                match v6948 with
                | US5_1 -> (* None *)
                    let v6953 : string = ""
                    v6953
                | US5_0(v6952) -> (* Some *)
                    v6952
            let v6956 : unit = ()
            let v6957 : (unit -> unit) = closure19(v0, v1, v2, v3, v4, v5, v6, v6929, v6928)
            let v6958 : unit = (fun () -> v6957 (); v6956) ()
            let v7005 : System.Text.Encoding = System.Text.Encoding.UTF8
            let v7009 : string =
                match v6929 with
                | US5_1 -> (* None *)
                    let v7007 : string = ""
                    v7007
                | US5_0(v7006) -> (* Some *)
                    v7006
            let start_info = System.Diagnostics.ProcessStartInfo (
              Arguments = v7009,
              StandardOutputEncoding = v7005,
              WorkingDirectory = v6955,
              FileName = v6928,
              CreateNoWindow = true,
              RedirectStandardError = true,
              RedirectStandardOutput = true,
              UseShellExecute = false
            )
            let v7010 : System.Diagnostics.ProcessStartInfo = start_info
            let v7011 : (struct (string * string) []) = method42(v0, v1, v2, v3, v4, v5, v6)
            let v7012 : int32 = v7011.Length
            let v7013 : Mut5 = {l0 = 0} : Mut5
            while method27(v7012, v7013) do
                let v7015 : int32 = v7013.l0
                let struct (v7016 : string, v7017 : string) = v7011.[int v7015]
                v7010.EnvironmentVariables.[v7016] <- v7017 
                let v7018 : int32 = v7015 + 1
                v7013.l0 <- v7018
                ()
            let v7019 : System.Diagnostics.Process = new System.Diagnostics.Process (StartInfo = v7010)
            use v7019 = v7019 
            let v7020 : System.Diagnostics.Process = v7019 
            let v7021 : (unit -> System.Collections.Concurrent.ConcurrentStack<string>) = System.Collections.Concurrent.ConcurrentStack<string>
            let v7022 : System.Collections.Concurrent.ConcurrentStack<string> = v7021 ()
            let v7023 : bool = false
            let v7024 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v7020, v7022, v7023)
            v7020.OutputDataReceived.Add v7024 
            let v7025 : bool = true
            let v7026 : (System.Diagnostics.DataReceivedEventArgs -> unit) = closure20(v0, v1, v2, v3, v4, v5, v6, v7020, v7022, v7025)
            v7020.ErrorDataReceived.Add v7026 
            let v7027 : (unit -> bool) = v7020.Start
            let v7028 : bool = v7027 ()
            let v7029 : bool = v7028 = false
            if v7029 then
                let v7030 : string = $"runtime.execute_with_options_async / process_start error"
                failwith<unit> v7030
            let v7031 : (System.Diagnostics.Process -> unit) = _.BeginErrorReadLine()
            v7031 v7020
            let v7032 : (System.Diagnostics.Process -> unit) = _.BeginOutputReadLine()
            v7032 v7020
            let v7035 : (System.Threading.CancellationToken -> US15) = method50()
            let v7036 : US15 option = v1 |> Option.map v7035 
            let v7050 : US15 = US15_1
            let v7051 : US15 = v7036 |> Option.defaultValue v7050 
            let v7058 : System.Threading.CancellationToken =
                match v7051 with
                | US15_1 -> (* None *)
                    let v7056 : System.Threading.CancellationToken = System.Threading.CancellationToken.None
                    v7056
                | US15_0(v7055) -> (* Some *)
                    v7055
            let v7059 : Async<System.Threading.CancellationToken> = method51(v7058)
            let! v7059 = v7059 
            let v7060 : System.Threading.CancellationToken = v7059 
            let v7061 : ((unit -> unit) -> System.Threading.CancellationTokenRegistration) = v7060.Register
            let v7062 : (unit -> unit) = closure24(v7020)
            let v7063 : System.Threading.CancellationTokenRegistration = v7061 v7062
            use v7063 = v7063 
            let v7064 : System.Threading.CancellationTokenRegistration = v7063 
            let v7065 : Async<int32> = method54(v7020, v7022, v7060)
            let! v7065 = v7065 
            let v7066 : int32 = v7065 
            let v7068 : (System.Collections.Concurrent.ConcurrentStack<string> -> string seq) = Seq.cast
            let v7069 : string seq = v7068 v7022
            let v7073 : (string seq -> string seq) = Seq.rev
            let v7074 : string seq = v7073 v7069
            let v7078 : string = method57()
            let v7079 : (string -> (string seq -> string)) = String.concat
            let v7080 : (string seq -> string) = v7079 v7078
            let v7081 : string = v7080 v7074
            let v7085 : unit = ()
            let v7086 : (unit -> unit) = closure26(v0, v1, v2, v3, v4, v5, v6, v7066, v7081)
            let v7087 : unit = (fun () -> v7086 (); v7085) ()
            return struct (v7066, v7081) 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9131 : Async<struct (int32 * string)> = _let'_v6856 
    let _run_target_args'_v11 = v9131 
    #endif
    let v9132 : Async<struct (int32 * string)> = _run_target_args'_v11 
    v9132
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
    let v161 : US7 =
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
                let v95 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v96 : (char -> (UH0 -> UH0)) = method28()
                let v97 : (char list -> (UH0 -> UH0)) = v95 v96
                let v98 : (UH0 -> UH0) = v97 v87
                let v99 : UH0 = UH0_0
                let v100 : UH0 = v98 v99
                let struct (v129 : System.Text.StringBuilder, v130 : int32, v131 : int32) = method29(v100, v2, v3, v4)
                US7_0(v33, v70, v129, v130, v131)
            else
                let v133 : char list = []
                let v135 : char list = ' ' :: v133 
                let v139 : char list = '"' :: v135 
                let v143 : char list = '`' :: v139 
                let v147 : char list = '\\' :: v143 
                let v151 : (char list -> (char [])) = List.toArray
                let v152 : (char []) = v151 v147
                let v156 : string = $"parsing.none_of / unexpected char: '{v33}' / chars: %A{v152} / s: %A{struct (v2, v3, v4)}"
                US7_1(v156)
    match v161 with
    | US7_1(v178) -> (* Error *)
        struct (v0, v1, v2, v3, v4)
    | US7_0(v162, v163, v164, v165, v166) -> (* Ok *)
        let v168 : (char -> string) = _.ToString()
        let v169 : string = v168 v162
        let v172 : string = v0 + v169 
        method63(v172, v163, v164, v165, v166)
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
    let v172 : US7 =
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
                let v70 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v71 : (char -> (UH0 -> UH0)) = method28()
                let v72 : (char list -> (UH0 -> UH0)) = v70 v71
                let v73 : (UH0 -> UH0) = v72 v62
                let v74 : UH0 = UH0_0
                let v75 : UH0 = v73 v74
                let struct (v104 : System.Text.StringBuilder, v105 : int32, v106 : int32) = method29(v75, v1, v2, v3)
                US7_0(v10, v45, v104, v105, v106)
            else
                let v109 : string = "\n"
                let v110 : int32 = v0.IndexOf v109 
                let v113 : int32 = v110 - 1
                let v114 : bool = -2 = v113
                let v122 : int32 =
                    if v114 then
                        let v116 : (string -> int32) = String.length
                        let v117 : int32 = v116 v0
                        let v120 : int32 = v117 + 1
                        v120
                    else
                        let v121 : int32 = v113 + 1
                        v121
                let v128 : int32 = 0 |> int32 
                let v141 : int32 = v122 |> int32 
                let v149 : int32 = v141 - 1
                let v151 : string = v0.[int v128..int v149]
                let v156 : string = $"parsing.p_char / expected: '{'\\'}' / line: {v2} / col: {v3}
{v1}{v151}"
                let v159 : int32 = v3 - 1
                let v160 : int32 = 0
                let v161 : (string -> string) = method30(v159, v160)
                let v162 : string = ""
                let v163 : string = v161 v162
                let v164 : string = "^"
                let v165 : string = v163 + v164 
                let v167 : string = $"{v156}
{v165}
"
                US7_1(v167)
    let v285 : US7 =
        match v172 with
        | US7_1(v282) -> (* Error *)
            US7_1(v282)
        | US7_0(v173, v174, v175, v176, v177) -> (* Ok *)
            let v178 : bool = "" = v174
            if v178 then
                let v180 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v175, v176, v177)}"
                US7_1(v180)
            else
                let v184 : char = v174.[int 0]
                let v186 : (string -> int32) = String.length
                let v187 : int32 = v186 v174
                let v195 : int32 = 1 |> int32 
                let v208 : int32 = v187 |> int32 
                let v216 : int32 = v208 - 1
                let v218 : string = v174.[int v195..int v216]
                let v223 : (char -> string) = _.ToString()
                let v224 : string = v223 v184
                let v227 : int32 = v224.Length
                let v228 : (char []) = Array.zeroCreate<char> (v227)
                let v229 : Mut5 = {l0 = 0} : Mut5
                while method27(v227, v229) do
                    let v231 : int32 = v229.l0
                    let v232 : char = v224.[int v231]
                    v228.[int v231] <- v232
                    let v233 : int32 = v231 + 1
                    v229.l0 <- v233
                    ()
                let v235 : char list = v228 |> Array.toList
                let v243 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v244 : (char -> (UH0 -> UH0)) = method28()
                let v245 : (char list -> (UH0 -> UH0)) = v243 v244
                let v246 : (UH0 -> UH0) = v245 v235
                let v247 : UH0 = UH0_0
                let v248 : UH0 = v246 v247
                let struct (v277 : System.Text.StringBuilder, v278 : int32, v279 : int32) = method29(v248, v175, v176, v177)
                US7_0(v184, v218, v277, v278, v279)
    match v285 with
    | US7_1(v303) -> (* Error *)
        US8_1(v303)
    | US7_0(v286, v287, v288, v289, v290) -> (* Ok *)
        let v292 : (char -> string) = _.ToString()
        let v293 : string = v292 '\\'
        let v297 : (char -> string) = _.ToString()
        let v298 : string = v297 v286
        let v301 : string = v293 + v298 
        US8_0(v301, v287, v288, v289, v290)
and closure31 () struct (v0 : string, v1 : System.Text.StringBuilder, v2 : int32, v3 : int32) : US8 =
    let v4 : bool = "" = v0
    let v172 : US7 =
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
                let v70 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v71 : (char -> (UH0 -> UH0)) = method28()
                let v72 : (char list -> (UH0 -> UH0)) = v70 v71
                let v73 : (UH0 -> UH0) = v72 v62
                let v74 : UH0 = UH0_0
                let v75 : UH0 = v73 v74
                let struct (v104 : System.Text.StringBuilder, v105 : int32, v106 : int32) = method29(v75, v1, v2, v3)
                US7_0(v10, v45, v104, v105, v106)
            else
                let v109 : string = "\n"
                let v110 : int32 = v0.IndexOf v109 
                let v113 : int32 = v110 - 1
                let v114 : bool = -2 = v113
                let v122 : int32 =
                    if v114 then
                        let v116 : (string -> int32) = String.length
                        let v117 : int32 = v116 v0
                        let v120 : int32 = v117 + 1
                        v120
                    else
                        let v121 : int32 = v113 + 1
                        v121
                let v128 : int32 = 0 |> int32 
                let v141 : int32 = v122 |> int32 
                let v149 : int32 = v141 - 1
                let v151 : string = v0.[int v128..int v149]
                let v156 : string = $"parsing.p_char / expected: '{'`'}' / line: {v2} / col: {v3}
{v1}{v151}"
                let v159 : int32 = v3 - 1
                let v160 : int32 = 0
                let v161 : (string -> string) = method30(v159, v160)
                let v162 : string = ""
                let v163 : string = v161 v162
                let v164 : string = "^"
                let v165 : string = v163 + v164 
                let v167 : string = $"{v156}
{v165}
"
                US7_1(v167)
    let v285 : US7 =
        match v172 with
        | US7_1(v282) -> (* Error *)
            US7_1(v282)
        | US7_0(v173, v174, v175, v176, v177) -> (* Ok *)
            let v178 : bool = "" = v174
            if v178 then
                let v180 : string = $"parsing.any_char / unexpected end of input / s: %A{struct (v175, v176, v177)}"
                US7_1(v180)
            else
                let v184 : char = v174.[int 0]
                let v186 : (string -> int32) = String.length
                let v187 : int32 = v186 v174
                let v195 : int32 = 1 |> int32 
                let v208 : int32 = v187 |> int32 
                let v216 : int32 = v208 - 1
                let v218 : string = v174.[int v195..int v216]
                let v223 : (char -> string) = _.ToString()
                let v224 : string = v223 v184
                let v227 : int32 = v224.Length
                let v228 : (char []) = Array.zeroCreate<char> (v227)
                let v229 : Mut5 = {l0 = 0} : Mut5
                while method27(v227, v229) do
                    let v231 : int32 = v229.l0
                    let v232 : char = v224.[int v231]
                    v228.[int v231] <- v232
                    let v233 : int32 = v231 + 1
                    v229.l0 <- v233
                    ()
                let v235 : char list = v228 |> Array.toList
                let v243 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v244 : (char -> (UH0 -> UH0)) = method28()
                let v245 : (char list -> (UH0 -> UH0)) = v243 v244
                let v246 : (UH0 -> UH0) = v245 v235
                let v247 : UH0 = UH0_0
                let v248 : UH0 = v246 v247
                let struct (v277 : System.Text.StringBuilder, v278 : int32, v279 : int32) = method29(v248, v175, v176, v177)
                US7_0(v184, v218, v277, v278, v279)
    match v285 with
    | US7_1(v303) -> (* Error *)
        US8_1(v303)
    | US7_0(v286, v287, v288, v289, v290) -> (* Ok *)
        let v292 : (char -> string) = _.ToString()
        let v293 : string = v292 '`'
        let v297 : (char -> string) = _.ToString()
        let v298 : string = v297 v286
        let v301 : string = v293 + v298 
        US8_0(v301, v287, v288, v289, v290)
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
    let v153 : US7 =
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
                let v91 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v92 : (char -> (UH0 -> UH0)) = method28()
                let v93 : (char list -> (UH0 -> UH0)) = v91 v92
                let v94 : (UH0 -> UH0) = v93 v83
                let v95 : UH0 = UH0_0
                let v96 : UH0 = v94 v95
                let struct (v125 : System.Text.StringBuilder, v126 : int32, v127 : int32) = method29(v96, v2, v3, v4)
                US7_0(v29, v66, v125, v126, v127)
            else
                let v129 : char list = []
                let v131 : char list = '"' :: v129 
                let v135 : char list = '`' :: v131 
                let v139 : char list = '\\' :: v135 
                let v143 : (char list -> (char [])) = List.toArray
                let v144 : (char []) = v143 v139
                let v148 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v144} / s: %A{struct (v2, v3, v4)}"
                US7_1(v148)
    let v168 : US8 =
        match v153 with
        | US7_1(v165) -> (* Error *)
            US8_1(v165)
        | US7_0(v154, v155, v156, v157, v158) -> (* Ok *)
            let v160 : (char -> string) = _.ToString()
            let v161 : string = v160 v154
            US8_0(v161, v155, v156, v157, v158)
    let v182 : US8 =
        match v168 with
        | US8_1(v174) -> (* Error *)
            let v175 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure30()
            let v176 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure31()
            let v177 : UH3 = UH3_0
            let v178 : UH3 = UH3_1(v176, v177)
            let v179 : UH3 = UH3_1(v175, v178)
            method66(v1, v2, v3, v4, v179)
        | US8_0(v169, v170, v171, v172, v173) -> (* Ok *)
            v168
    match v182 with
    | US8_1(v190) -> (* Error *)
        let v191 : UH2 = UH2_0
        let v192 : UH2 = method67(v0, v191)
        US17_0(v192, v1, v2, v3, v4)
    | US8_0(v183, v184, v185, v186, v187) -> (* Ok *)
        let v188 : UH2 = UH2_1(v183, v0)
        method64(v188, v184, v185, v186, v187)
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
    let v153 : US7 =
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
                let v91 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v92 : (char -> (UH0 -> UH0)) = method28()
                let v93 : (char list -> (UH0 -> UH0)) = v91 v92
                let v94 : (UH0 -> UH0) = v93 v83
                let v95 : UH0 = UH0_0
                let v96 : UH0 = v94 v95
                let struct (v125 : System.Text.StringBuilder, v126 : int32, v127 : int32) = method29(v96, v2, v3, v4)
                US7_0(v29, v66, v125, v126, v127)
            else
                let v129 : char list = []
                let v131 : char list = '"' :: v129 
                let v135 : char list = '`' :: v131 
                let v139 : char list = '\\' :: v135 
                let v143 : (char list -> (char [])) = List.toArray
                let v144 : (char []) = v143 v139
                let v148 : string = $"parsing.none_of / unexpected char: '{v29}' / chars: %A{v144} / s: %A{struct (v2, v3, v4)}"
                US7_1(v148)
    let v168 : US8 =
        match v153 with
        | US7_1(v165) -> (* Error *)
            US8_1(v165)
        | US7_0(v154, v155, v156, v157, v158) -> (* Ok *)
            let v160 : (char -> string) = _.ToString()
            let v161 : string = v160 v154
            US8_0(v161, v155, v156, v157, v158)
    match v168 with
    | US8_1(v176) -> (* Error *)
        let v177 : UH2 = UH2_0
        let v178 : UH2 = method67(v0, v177)
        US17_0(v178, v1, v2, v3, v4)
    | US8_0(v169, v170, v171, v172, v173) -> (* Ok *)
        let v174 : UH2 = UH2_1(v169, v0)
        method69(v174, v170, v171, v172, v173)
and method61 (v0 : UH2, v1 : string, v2 : System.Text.StringBuilder, v3 : int32, v4 : int32) : US17 =
    let v5 : bool = "" = v1
    let v161 : US7 =
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
                let v95 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                let v96 : (char -> (UH0 -> UH0)) = method28()
                let v97 : (char list -> (UH0 -> UH0)) = v95 v96
                let v98 : (UH0 -> UH0) = v97 v87
                let v99 : UH0 = UH0_0
                let v100 : UH0 = v98 v99
                let struct (v129 : System.Text.StringBuilder, v130 : int32, v131 : int32) = method29(v100, v2, v3, v4)
                US7_0(v33, v70, v129, v130, v131)
            else
                let v133 : char list = []
                let v135 : char list = ' ' :: v133 
                let v139 : char list = '"' :: v135 
                let v143 : char list = '`' :: v139 
                let v147 : char list = '\\' :: v143 
                let v151 : (char list -> (char [])) = List.toArray
                let v152 : (char []) = v151 v147
                let v156 : string = $"parsing.none_of / unexpected char: '{v33}' / chars: %A{v152} / s: %A{struct (v2, v3, v4)}"
                US7_1(v156)
    let v181 : US8 =
        match v161 with
        | US7_1(v178) -> (* Error *)
            US8_1(v178)
        | US7_0(v162, v163, v164, v165, v166) -> (* Ok *)
            let v168 : (char -> string) = _.ToString()
            let v169 : string = v168 v162
            let struct (v172 : string, v173 : string, v174 : System.Text.StringBuilder, v175 : int32, v176 : int32) = method63(v169, v163, v164, v165, v166)
            US8_0(v172, v173, v174, v175, v176)
    let v659 : US8 =
        match v181 with
        | US8_1(v187) -> (* Error *)
            let v355 : US7 =
                if v5 then
                    let v189 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v2, v3, v4)}"
                    US7_1(v189)
                else
                    let v193 : char = v1.[int 0]
                    let v194 : bool = v193 = '"'
                    if v194 then
                        let v196 : (string -> int32) = String.length
                        let v197 : int32 = v196 v1
                        let v205 : int32 = 1 |> int32 
                        let v218 : int32 = v197 |> int32 
                        let v226 : int32 = v218 - 1
                        let v228 : string = v1.[int v205..int v226]
                        let v233 : (char -> string) = _.ToString()
                        let v234 : string = v233 v193
                        let v237 : int32 = v234.Length
                        let v238 : (char []) = Array.zeroCreate<char> (v237)
                        let v239 : Mut5 = {l0 = 0} : Mut5
                        while method27(v237, v239) do
                            let v241 : int32 = v239.l0
                            let v242 : char = v234.[int v241]
                            v238.[int v241] <- v242
                            let v243 : int32 = v241 + 1
                            v239.l0 <- v243
                            ()
                        let v245 : char list = v238 |> Array.toList
                        let v253 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                        let v254 : (char -> (UH0 -> UH0)) = method28()
                        let v255 : (char list -> (UH0 -> UH0)) = v253 v254
                        let v256 : (UH0 -> UH0) = v255 v245
                        let v257 : UH0 = UH0_0
                        let v258 : UH0 = v256 v257
                        let struct (v287 : System.Text.StringBuilder, v288 : int32, v289 : int32) = method29(v258, v2, v3, v4)
                        US7_0(v193, v228, v287, v288, v289)
                    else
                        let v292 : string = "\n"
                        let v293 : int32 = v1.IndexOf v292 
                        let v296 : int32 = v293 - 1
                        let v297 : bool = -2 = v296
                        let v305 : int32 =
                            if v297 then
                                let v299 : (string -> int32) = String.length
                                let v300 : int32 = v299 v1
                                let v303 : int32 = v300 + 1
                                v303
                            else
                                let v304 : int32 = v296 + 1
                                v304
                        let v311 : int32 = 0 |> int32 
                        let v324 : int32 = v305 |> int32 
                        let v332 : int32 = v324 - 1
                        let v334 : string = v1.[int v311..int v332]
                        let v339 : string = $"parsing.p_char / expected: '{'"'}' / line: {v3} / col: {v4}
{v2}{v334}"
                        let v342 : int32 = v4 - 1
                        let v343 : int32 = 0
                        let v344 : (string -> string) = method30(v342, v343)
                        let v345 : string = ""
                        let v346 : string = v344 v345
                        let v347 : string = "^"
                        let v348 : string = v346 + v347 
                        let v350 : string = $"{v339}
{v348}
"
                        US7_1(v350)
            let v590 : US8 =
                match v355 with
                | US7_1(v587) -> (* Error *)
                    US8_1(v587)
                | US7_0(v356, v357, v358, v359, v360) -> (* Ok *)
                    let v361 : UH2 = UH2_0
                    let v362 : US17 = method64(v361, v357, v358, v359, v360)
                    let v393 : US8 =
                        match v362 with
                        | US17_1(v390) -> (* Error *)
                            US8_1(v390)
                        | US17_0(v363, v364, v365, v366, v367) -> (* Ok *)
                            let v368 : string list = []
                            let v369 : string list = method68(v363, v368)
                            let v373 : unit = ()
                            let _let'_v373 =
                                seq {
                                    yield! v369 
                                    (* indent
                                    ()
                                indent *)
                                }
                                (* indent
                                ()
                            indent *)
                            let v376 : string seq = _let'_v373 
                            let v383 : (string -> (string seq -> string)) = String.concat
                            let v384 : string = ""
                            let v385 : (string seq -> string) = v383 v384
                            let v386 : string = v385 v376
                            US8_0(v386, v364, v365, v366, v367)
                    match v393 with
                    | US8_1(v582) -> (* Error *)
                        let v583 : string = "parsing.between / expected content"
                        US8_1(v583)
                    | US8_0(v394, v395, v396, v397, v398) -> (* Ok *)
                        let v399 : bool = "" = v395
                        let v567 : US7 =
                            if v399 then
                                let v401 : string = $"parsing.p_char / unexpected end of input / c: '{'"'}' / s: %A{struct (v396, v397, v398)}"
                                US7_1(v401)
                            else
                                let v405 : char = v395.[int 0]
                                let v406 : bool = v405 = '"'
                                if v406 then
                                    let v408 : (string -> int32) = String.length
                                    let v409 : int32 = v408 v395
                                    let v417 : int32 = 1 |> int32 
                                    let v430 : int32 = v409 |> int32 
                                    let v438 : int32 = v430 - 1
                                    let v440 : string = v395.[int v417..int v438]
                                    let v445 : (char -> string) = _.ToString()
                                    let v446 : string = v445 v405
                                    let v449 : int32 = v446.Length
                                    let v450 : (char []) = Array.zeroCreate<char> (v449)
                                    let v451 : Mut5 = {l0 = 0} : Mut5
                                    while method27(v449, v451) do
                                        let v453 : int32 = v451.l0
                                        let v454 : char = v446.[int v453]
                                        v450.[int v453] <- v454
                                        let v455 : int32 = v453 + 1
                                        v451.l0 <- v455
                                        ()
                                    let v457 : char list = v450 |> Array.toList
                                    let v465 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
                                    let v466 : (char -> (UH0 -> UH0)) = method28()
                                    let v467 : (char list -> (UH0 -> UH0)) = v465 v466
                                    let v468 : (UH0 -> UH0) = v467 v457
                                    let v469 : UH0 = UH0_0
                                    let v470 : UH0 = v468 v469
                                    let struct (v499 : System.Text.StringBuilder, v500 : int32, v501 : int32) = method29(v470, v396, v397, v398)
                                    US7_0(v405, v440, v499, v500, v501)
                                else
                                    let v504 : string = "\n"
                                    let v505 : int32 = v395.IndexOf v504 
                                    let v508 : int32 = v505 - 1
                                    let v509 : bool = -2 = v508
                                    let v517 : int32 =
                                        if v509 then
                                            let v511 : (string -> int32) = String.length
                                            let v512 : int32 = v511 v395
                                            let v515 : int32 = v512 + 1
                                            v515
                                        else
                                            let v516 : int32 = v508 + 1
                                            v516
                                    let v523 : int32 = 0 |> int32 
                                    let v536 : int32 = v517 |> int32 
                                    let v544 : int32 = v536 - 1
                                    let v546 : string = v395.[int v523..int v544]
                                    let v551 : string = $"parsing.p_char / expected: '{'"'}' / line: {v397} / col: {v398}
{v396}{v546}"
                                    let v554 : int32 = v398 - 1
                                    let v555 : int32 = 0
                                    let v556 : (string -> string) = method30(v554, v555)
                                    let v557 : string = ""
                                    let v558 : string = v556 v557
                                    let v559 : string = "^"
                                    let v560 : string = v558 + v559 
                                    let v562 : string = $"{v551}
{v560}
"
                                    US7_1(v562)
                        match v567 with
                        | US7_1(v574) -> (* Error *)
                            let v576 : string = $"parsing.between / expected closing delimiter / e: %A{v574} / input: %A{struct (v1, v2, v3, v4)} / rest1: %A{struct (v357, v358, v359, v360)} / rest2: %A{struct (v395, v396, v397, v398)}"
                            US8_1(v576)
                        | US7_0(v568, v569, v570, v571, v572) -> (* Ok *)
                            US8_0(v394, v569, v570, v571, v572)
            match v590 with
            | US8_1(v596) -> (* Error *)
                let v597 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure30()
                let v598 : (struct (string * System.Text.StringBuilder * int32 * int32) -> US8) = closure31()
                let v599 : UH3 = UH3_0
                let v600 : UH3 = UH3_1(v598, v599)
                let v601 : UH3 = UH3_1(v597, v600)
                let v602 : US8 = method66(v1, v2, v3, v4, v601)
                let v613 : US8 =
                    match v602 with
                    | US8_1(v610) -> (* Error *)
                        US8_1(v610)
                    | US8_0(v603, v604, v605, v606, v607) -> (* Ok *)
                        let v608 : string = ""
                        US8_0(v608, v604, v605, v606, v607)
                let v624 : US17 =
                    match v613 with
                    | US8_1(v621) -> (* Error *)
                        US17_1(v621)
                    | US8_0(v614, v615, v616, v617, v618) -> (* Ok *)
                        let v619 : UH2 = UH2_0
                        method69(v619, v615, v616, v617, v618)
                match v624 with
                | US17_1(v652) -> (* Error *)
                    US8_1(v652)
                | US17_0(v625, v626, v627, v628, v629) -> (* Ok *)
                    let v630 : string list = []
                    let v631 : string list = method68(v625, v630)
                    let v635 : unit = ()
                    let _let'_v635 =
                        seq {
                            yield! v631 
                            (* indent
                            ()
                        indent *)
                        }
                        (* indent
                        ()
                    indent *)
                    let v638 : string seq = _let'_v635 
                    let v645 : (string -> (string seq -> string)) = String.concat
                    let v646 : string = ""
                    let v647 : (string seq -> string) = v645 v646
                    let v648 : string = v647 v638
                    US8_0(v648, v626, v627, v628, v629)
            | US8_0(v591, v592, v593, v594, v595) -> (* Ok *)
                v590
        | US8_0(v182, v183, v184, v185, v186) -> (* Ok *)
            v181
    match v659 with
    | US8_1(v722) -> (* Error *)
        let v723 : UH2 = UH2_0
        let v724 : UH2 = method67(v0, v723)
        US17_0(v724, v1, v2, v3, v4)
    | US8_0(v660, v661, v662, v663, v664) -> (* Ok *)
        let v665 : int32 = 0
        let v666 : int32 = method37(v661, v665)
        let v667 : bool = 0 = v666
        let v708 : US10 =
            if v667 then
                let v668 : string = "parsing.spaces1 / expected at least one space"
                US10_1(v668)
            else
                let v671 : (string -> int32) = String.length
                let v672 : int32 = v671 v661
                let v680 : int32 = v666 |> int32 
                let v693 : int32 = v672 |> int32 
                let v701 : int32 = v693 - 1
                let v703 : string = v661.[int v680..int v701]
                US10_0(v703, v662, v663, v664)
        match v708 with
        | US10_1(v715) -> (* Error *)
            let v716 : UH2 = UH2_0
            let v717 : UH2 = UH2_1(v660, v716)
            let v718 : UH2 = method67(v0, v717)
            US17_0(v718, v661, v662, v663, v664)
        | US10_0(v709, v710, v711, v712) -> (* Ok *)
            let v713 : UH2 = UH2_1(v660, v0)
            method61(v713, v709, v710, v711, v712)
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
and closure29 () (v0 : string) : Result<(string []), string> =
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
let v19 : (struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option) -> Async<struct (int32 * string)>) = closure27()
let execute_with_options_async x = v19 x
let v20 : ((Heap0 -> Heap0) -> struct (string * System.Threading.CancellationToken option * (struct (string * string) []) * (struct (int32 * string * bool) -> Async<unit>) option * (std_sync_Arc<std_sync_Mutex<std_process_ChildStdin>> -> unit) option * bool * string option)) = closure28()
let execution_options x = v20 x
let v21 : (string -> Result<(string []), string>) = closure29()
let split_args x = v21 x
()
