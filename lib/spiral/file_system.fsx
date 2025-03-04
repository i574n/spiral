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
[<Fable.Core.Erase; Fable.Core.Emit("std::path::PathBuf")>]
type std_path_PathBuf = class end
#else
type std_path_PathBuf = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::ffi::OsString")>]
#endif
type std_ffi_OsString = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("mut $0")>]
#endif
type Mut<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("Vec<$0>")>]
#endif
type Vec<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::io::Error")>]
type std_io_Error = class end
#else
type std_io_Error = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::DateTime<$0>")>]
#endif
type chrono_DateTime<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::NaiveDateTime")>]
#endif
type chrono_NaiveDateTime = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::path::Display")>]
type std_path_Display = class end
#else
type std_path_Display = string
#endif

#if FABLE_COMPILER
type System_IO_DirectoryInfo = bool
#else
type System_IO_DirectoryInfo = System.IO.DirectoryInfo
#endif

#if FABLE_COMPILER
type System_IO_FileInfo = bool
#else
type System_IO_FileInfo = System.IO.FileInfo
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("regex::Regex")>]
#endif
type regex_Regex = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::borrow::Cow<$0>")>]
#endif
type std_borrow_Cow<'T> = class end
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

type IFsExistsSync = abstract existsSync: path: string -> bool
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::ffi::OsStr")>]
#endif
type std_ffi_OsStr = class end
type IPathBasename = abstract basename: path: string -> string
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::FromUtf8Error")>]
#endif
type std_string_FromUtf8Error = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::Utc")>]
#endif
type chrono_Utc = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("chrono::Local")>]
#endif
type chrono_Local = class end
type IPathJoin = abstract join: [<System.ParamArray>] paths: string[] -> string
type Disposable (f : unit -> unit) = interface System.IDisposable with member _.Dispose () = f ()
type IPathDirname = abstract dirname: path: string -> string
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("regex::Error")>]
#endif
type regex_Error = class end
type IFs = abstract realpathSync: path: string -> string
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
and [<Struct>] US7 =
    | US7_0
    | US7_1
    | US7_2
and [<Struct>] US8 =
    | US8_0
    | US8_1
    | US8_2
    | US8_3
    | US8_4
and [<Struct>] US6 =
    | US6_0 of f0_0 : US7 * f0_1 : US8
    | US6_1
and [<Struct>] US9 =
    | US9_0
    | US9_1 of f1_0 : string
and [<Struct>] US10 =
    | US10_0 of f0_0 : int64
    | US10_1 of f1_0 : exn
and [<Struct>] US11 =
    | US11_0 of f0_0 : int64
    | US11_1 of f1_0 : exn
and [<Struct>] US12 =
    | US12_0 of f0_0 : chrono_DateTime<chrono_Utc>
    | US12_1
and [<Struct>] US13 =
    | US13_0
    | US13_1 of f1_0 : std_string_String
and [<Struct>] US14 =
    | US14_0 of f0_0 : std_path_PathBuf
    | US14_1 of f1_0 : string
and [<Struct>] US15 =
    | US15_0 of f0_0 : std_path_PathBuf
    | US15_1
and Mut5 = {mutable l0 : int32; mutable l1 : int32; mutable l2 : (string [])}
and Mut6 = {mutable l0 : int32}
and [<Struct>] US16 =
    | US16_0
    | US16_1
and [<Struct>] US17 =
    | US17_0 of f0_0 : string
    | US17_1 of f1_0 : string
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
and method10 (v0 : string) : bool =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v18 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
#else
    let v30 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v30 
    #endif
    let v33 : Ref<Str> = _run_target_args'_v10 
    (* run_target_args'
    let v43 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v44 : string = "String::from($0)"
    let v45 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v44 
    let _run_target_args'_v43 = v45 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v46 : string = "String::from($0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v46 
    let _run_target_args'_v43 = v47 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v48 : string = "String::from($0)"
    let v49 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v48 
    let _run_target_args'_v43 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v59 
    #endif
#else
    let v63 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v63 
    #endif
    let v66 : std_string_String = _run_target_args'_v43 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "std::path::PathBuf::from($0)"
    let v78 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "std::path::PathBuf::from($0)"
    let v80 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "std::path::PathBuf::from($0)"
    let v82 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : std_path_PathBuf = _run_target_args'_v76 
    let v105 : string = "$0.exists()"
    let v106 : bool = Fable.Core.RustInterop.emitRustExpr v99 v105 
    let v109 : bool =
        if v106 then
            let v107 : string = "$0.is_dir()"
            let v108 : bool = Fable.Core.RustInterop.emitRustExpr v99 v107 
            v108
        else
            false
    let _run_target_args'_v5 = v109 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v111 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v111 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v115 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v115 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v118 : string = "fs"
    let v119 : IFsExistsSync = Fable.Core.JsInterop.importAll v118 
    let v120 : string = "$0.existsSync($1)"
    let v121 : bool = Fable.Core.JsInterop.emitJsExpr struct (v119, v0) v120 
    let _run_target_args'_v5 = v121 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v127 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v127 
    #endif
#else
    let v130 : (string -> bool) = System.IO.Directory.Exists
    let v131 : bool = v130 v0
    let _run_target_args'_v5 = v131 
    #endif
    let v132 : bool = _run_target_args'_v5 
    v132
and method9 (v0 : bool, v1 : string) : unit =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : bool = method10(v1)
    if v3 then
        if v0 then
            let v4 : string = "std::fs::remove_dir_all(&*$0).unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1 v4 
            ()
        else
            let v5 : string = "std::fs::remove_dir(&*$0).unwrap()"
            Fable.Core.RustInterop.emitRustExpr v1 v5 
            ()
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
    System.IO.Directory.Delete (v1, v0)
    #endif
    // run_target_args' is_unit
    ()
and method11 (v0 : US0) : bool =
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
and closure5 () (v0 : int64) : US2 =
    US2_0(v0)
and method13 () : (int64 -> US2) =
    closure5()
and method14 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method15 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method12 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v165 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v167 : (int64 -> US2) = method13()
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
    let v302 : string = method14()
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
    let v326 : (int64 -> US2) = method13()
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
    let v461 : string = method14()
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
    let v487 : (int64 -> US2) = method13()
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
    let v526 : (int64 -> US2) = method13()
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
    let v661 : string = method15()
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
    let v685 : (int64 -> US2) = method13()
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
    let v820 : string = method15()
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
    let v844 : (int64 -> US2) = method13()
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
    let v979 : string = method15()
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
    let v1003 : (int64 -> US2) = method13()
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
    let v1138 : string = method15()
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
and method18 () : string =
    let v0 : string = ""
    v0
and closure6 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method17 (v0 : char) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure6(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method19 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method16 () : string =
    
    
    
    
    
    let v1 : string = "Debug"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method17(v6)
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
    let v137 : string = method19()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[94m"
    let v141 : string = method19()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[94m"
    let v145 : string = method19()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[94m"
    let v149 : string = method19()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method20 (v0 : string) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v18 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
#else
    let v30 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v30 
    #endif
    let v33 : Ref<Str> = _run_target_args'_v10 
    (* run_target_args'
    let v43 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v44 : string = "String::from($0)"
    let v45 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v44 
    let _run_target_args'_v43 = v45 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v46 : string = "String::from($0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v46 
    let _run_target_args'_v43 = v47 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v48 : string = "String::from($0)"
    let v49 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v48 
    let _run_target_args'_v43 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v59 
    #endif
#else
    let v63 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v63 
    #endif
    let v66 : std_string_String = _run_target_args'_v43 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "std::path::PathBuf::from($0)"
    let v78 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "std::path::PathBuf::from($0)"
    let v80 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "std::path::PathBuf::from($0)"
    let v82 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : std_path_PathBuf = _run_target_args'_v76 
    let v105 : string = "$0.file_name()"
    let v106 : Ref<std_ffi_OsStr> option = Fable.Core.RustInterop.emitRustExpr v99 v105 
    let v107 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v108 : bool = Fable.Core.RustInterop.emitRustExpr v106 v107 
    let v109 : string = "x"
    let v110 : Ref<std_ffi_OsStr> = Fable.Core.RustInterop.emitRustExpr () v109 
    let v111 : string = "$0.to_os_string()"
    let v112 : std_ffi_OsString = Fable.Core.RustInterop.emitRustExpr v110 v111 
    let v113 : string = "$0.to_str()"
    let v114 : Ref<Str> option = Fable.Core.RustInterop.emitRustExpr v112 v113 
    let v115 : string = "$0.unwrap()"
    let v116 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v114 v115 
    (* run_target_args'
    let v121 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v122 : string = "String::from($0)"
    let v123 : std_string_String = Fable.Core.RustInterop.emitRustExpr v116 v122 
    let _run_target_args'_v121 = v123 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v124 : string = "String::from($0)"
    let v125 : std_string_String = Fable.Core.RustInterop.emitRustExpr v116 v124 
    let _run_target_args'_v121 = v125 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v126 : string = "String::from($0)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr v116 v126 
    let _run_target_args'_v121 = v127 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v129 : std_string_String = v116 |> unbox<std_string_String>
    let _run_target_args'_v121 = v129 
    #endif
#if FABLE_COMPILER_PYTHON
    let v133 : std_string_String = v116 |> unbox<std_string_String>
    let _run_target_args'_v121 = v133 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v137 : std_string_String = v116 |> unbox<std_string_String>
    let _run_target_args'_v121 = v137 
    #endif
#else
    let v141 : std_string_String = v116 |> unbox<std_string_String>
    let _run_target_args'_v121 = v141 
    #endif
    let v144 : std_string_String = _run_target_args'_v121 
    let v150 : string = "fable_library_rust::String_::fromString($0)"
    let v151 : string = Fable.Core.RustInterop.emitRustExpr v144 v150 
    let v152 : string = "true; $0 })"
    let v153 : bool = Fable.Core.RustInterop.emitRustExpr v151 v152 
    let v154 : string = "_optionm_map_"
    let v155 : string option = Fable.Core.RustInterop.emitRustExpr () v154 
    let v157 : (string -> US5) = method5()
    let v158 : US5 option = v155 |> Option.map v157 
    let v171 : US5 = US5_1
    let v172 : US5 = v158 |> Option.defaultValue v171 
    let v179 : string =
        match v172 with
        | US5_1 -> (* None *)
            let v177 : string = ""
            v177
        | US5_0(v176) -> (* Some *)
            v176
    let _run_target_args'_v5 = v179 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v180 : US3 = US3_1
    let v181 : US4 = US4_3(v180)
    let v182 : string = $"file_system.get_file_name / target: {v181} / path: {v0}"
    let v183 : string = failwith<string> v182
    let _run_target_args'_v5 = v183 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v185 : string = null |> unbox<string>
    let _run_target_args'_v5 = v185 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v188 : string = "path"
    let v189 : IPathBasename = Fable.Core.JsInterop.importAll v188 
    let v190 : string = "v189.basename($0)"
    let v191 : string = Fable.Core.JsInterop.emitJsExpr v0 v190 
    let _run_target_args'_v5 = v191 
    #endif
#if FABLE_COMPILER_PYTHON
    let v192 : US3 = US3_0
    let v193 : US4 = US4_5(v192)
    let v194 : string = $"file_system.get_file_name / target: {v193} / path: {v0}"
    let v195 : string = failwith<string> v194
    let _run_target_args'_v5 = v195 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v196 : US3 = US3_1
    let v197 : US4 = US4_1(v196)
    let v198 : string = $"file_system.get_file_name / target: {v197} / path: {v0}"
    let v199 : string = failwith<string> v198
    let _run_target_args'_v5 = v199 
    #endif
#else
    let v200 : (string -> string) = System.IO.Path.GetFileName
    let v201 : string = v200 v0
    let _run_target_args'_v5 = v201 
    #endif
    let v202 : string = _run_target_args'_v5 
    v202
and method22 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "ex"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "path"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure6(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method23 (v0 : string) : string =
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
and method21 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method22(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "file_system.delete_directory_async"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure7 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure9 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure8 () (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure9(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method24 (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure0()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut0, v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure7(v24)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : (string -> unit) = closure8()
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
and closure4 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method16()
        (* run_target_args'
        let v51 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v51 = v53 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v57 : string = $"%A{v1}"
        let _run_target_args'_v51 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v61 : string = $"%A{v1}"
        let _run_target_args'_v51 = v61 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v65 : string = $"%A{v1}"
        let _run_target_args'_v51 = v65 
        #endif
#if FABLE_COMPILER_PYTHON
        let v69 : string = $"%A{v1}"
        let _run_target_args'_v51 = v69 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v73 : string = $"%A{v1}"
        let _run_target_args'_v51 = v73 
        #endif
#else
        let v76 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v51 = v76 
        #endif
        let v77 : string = _run_target_args'_v51 
        let v83 : string = method20(v0)
        let v84 : string = method21(v27, v28, v29, v30, v31, v32, v45, v46, v77, v83)
        method24(v84)
and method8 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            try
                let v23 : bool = true
                method9(v23, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v25 : exn = ex
                let v26 : int64 = v1 % 100L
                let v27 : bool = v26 = 0L
                if v27 then
                    let v28 : unit = ()
                    let v29 : (unit -> unit) = closure4(v0, v25)
                    let v30 : unit = (fun () -> v29 (); v28) ()
                    ()
                (* run_target_args'
                let v118 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v119 : (int32 -> Async<unit>) = Async.Sleep
                let v120 : Async<unit> = v119 10
                let _run_target_args'_v118 = v120 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v118 = v122 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v123 : (int32 -> Async<unit>) = Async.Sleep
                let v124 : Async<unit> = v123 10
                let _run_target_args'_v118 = v124 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v125 : (int32 -> Async<unit>) = Async.Sleep
                let v126 : Async<unit> = v125 10
                let _run_target_args'_v118 = v126 
                #endif
#if FABLE_COMPILER_PYTHON
                let v127 : (int32 -> Async<unit>) = Async.Sleep
                let v128 : Async<unit> = v127 10
                let _run_target_args'_v118 = v128 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v129 : (int32 -> Async<unit>) = Async.Sleep
                let v130 : Async<unit> = v129 10
                let _run_target_args'_v118 = v130 
                #endif
#else
                let v131 : (int32 -> Async<unit>) = Async.Sleep
                let v132 : Async<unit> = v131 10
                let _run_target_args'_v118 = v132 
                #endif
                let v133 : Async<unit> = _run_target_args'_v118 
                do! v133 
                let v136 : int64 = v1 + 1L
                let v137 : Async<int64> = method7(v0, v136)
                return! v137 
                (* indent
                ()
            indent *)
            (* try_unit
            let v252 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1879 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v1879 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1881 : unit = ()
    let _let'_v1881 =
        async {
            try
                let v1884 : bool = true
                method9(v1884, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v1886 : exn = ex
                let v1887 : int64 = v1 % 100L
                let v1888 : bool = v1887 = 0L
                if v1888 then
                    let v1889 : unit = ()
                    let v1890 : (unit -> unit) = closure4(v0, v1886)
                    let v1891 : unit = (fun () -> v1890 (); v1889) ()
                    ()
                (* run_target_args'
                let v1979 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1980 : (int32 -> Async<unit>) = Async.Sleep
                let v1981 : Async<unit> = v1980 10
                let _run_target_args'_v1979 = v1981 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1982 : (int32 -> Async<unit>) = Async.Sleep
                let v1983 : Async<unit> = v1982 10
                let _run_target_args'_v1979 = v1983 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1984 : (int32 -> Async<unit>) = Async.Sleep
                let v1985 : Async<unit> = v1984 10
                let _run_target_args'_v1979 = v1985 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1986 : (int32 -> Async<unit>) = Async.Sleep
                let v1987 : Async<unit> = v1986 10
                let _run_target_args'_v1979 = v1987 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1988 : (int32 -> Async<unit>) = Async.Sleep
                let v1989 : Async<unit> = v1988 10
                let _run_target_args'_v1979 = v1989 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1990 : (int32 -> Async<unit>) = Async.Sleep
                let v1991 : Async<unit> = v1990 10
                let _run_target_args'_v1979 = v1991 
                #endif
#else
                let v1992 : (int32 -> Async<unit>) = Async.Sleep
                let v1993 : Async<unit> = v1992 10
                let _run_target_args'_v1979 = v1993 
                #endif
                let v1994 : Async<unit> = _run_target_args'_v1979 
                do! v1994 
                let v1997 : int64 = v1 + 1L
                let v1998 : Async<int64> = method7(v0, v1997)
                return! v1998 
                (* indent
                ()
            indent *)
            (* try_unit
            let v2113 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3740 : Async<int64> = _let'_v1881 
    let _run_target_args'_v6 = v3740 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3742 : unit = ()
    let _let'_v3742 =
        async {
            try
                let v3745 : bool = true
                method9(v3745, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v3747 : exn = ex
                let v3748 : int64 = v1 % 100L
                let v3749 : bool = v3748 = 0L
                if v3749 then
                    let v3750 : unit = ()
                    let v3751 : (unit -> unit) = closure4(v0, v3747)
                    let v3752 : unit = (fun () -> v3751 (); v3750) ()
                    ()
                (* run_target_args'
                let v3840 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3841 : (int32 -> Async<unit>) = Async.Sleep
                let v3842 : Async<unit> = v3841 10
                let _run_target_args'_v3840 = v3842 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3843 : (int32 -> Async<unit>) = Async.Sleep
                let v3844 : Async<unit> = v3843 10
                let _run_target_args'_v3840 = v3844 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3845 : (int32 -> Async<unit>) = Async.Sleep
                let v3846 : Async<unit> = v3845 10
                let _run_target_args'_v3840 = v3846 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3847 : (int32 -> Async<unit>) = Async.Sleep
                let v3848 : Async<unit> = v3847 10
                let _run_target_args'_v3840 = v3848 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3849 : (int32 -> Async<unit>) = Async.Sleep
                let v3850 : Async<unit> = v3849 10
                let _run_target_args'_v3840 = v3850 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3851 : (int32 -> Async<unit>) = Async.Sleep
                let v3852 : Async<unit> = v3851 10
                let _run_target_args'_v3840 = v3852 
                #endif
#else
                let v3853 : (int32 -> Async<unit>) = Async.Sleep
                let v3854 : Async<unit> = v3853 10
                let _run_target_args'_v3840 = v3854 
                #endif
                let v3855 : Async<unit> = _run_target_args'_v3840 
                do! v3855 
                let v3858 : int64 = v1 + 1L
                let v3859 : Async<int64> = method7(v0, v3858)
                return! v3859 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3974 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5601 : Async<int64> = _let'_v3742 
    let _run_target_args'_v6 = v5601 
    #endif
#else
    let v5603 : unit = ()
    let _let'_v5603 =
        async {
            try
                let v5606 : bool = true
                method9(v5606, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v5608 : exn = ex
                let v5609 : int64 = v1 % 100L
                let v5610 : bool = v5609 = 0L
                if v5610 then
                    let v5611 : unit = ()
                    let v5612 : (unit -> unit) = closure4(v0, v5608)
                    let v5613 : unit = (fun () -> v5612 (); v5611) ()
                    ()
                (* run_target_args'
                let v5701 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5702 : (int32 -> Async<unit>) = Async.Sleep
                let v5703 : Async<unit> = v5702 10
                let _run_target_args'_v5701 = v5703 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5704 : (int32 -> Async<unit>) = Async.Sleep
                let v5705 : Async<unit> = v5704 10
                let _run_target_args'_v5701 = v5705 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5706 : (int32 -> Async<unit>) = Async.Sleep
                let v5707 : Async<unit> = v5706 10
                let _run_target_args'_v5701 = v5707 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5708 : (int32 -> Async<unit>) = Async.Sleep
                let v5709 : Async<unit> = v5708 10
                let _run_target_args'_v5701 = v5709 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5710 : (int32 -> Async<unit>) = Async.Sleep
                let v5711 : Async<unit> = v5710 10
                let _run_target_args'_v5701 = v5711 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5712 : (int32 -> Async<unit>) = Async.Sleep
                let v5713 : Async<unit> = v5712 10
                let _run_target_args'_v5701 = v5713 
                #endif
#else
                let v5714 : (int32 -> Async<unit>) = Async.Sleep
                let v5715 : Async<unit> = v5714 10
                let _run_target_args'_v5701 = v5715 
                #endif
                let v5716 : Async<unit> = _run_target_args'_v5701 
                do! v5716 
                let v5719 : int64 = v1 + 1L
                let v5720 : Async<int64> = method7(v0, v5719)
                return! v5720 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5835 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7462 : Async<int64> = _let'_v5603 
    let _run_target_args'_v6 = v7462 
    #endif
    let v7463 : Async<int64> = _run_target_args'_v6 
    v7463
and method7 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v28 
    #endif
#else
    let v31 : Async<int64> = method8(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<int64> = _run_target_args'_v6 
    v32
and method6 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method7(v0, v1)
and closure3 () (v0 : string) : Async<int64> =
    method6(v0)
and method29 (v0 : string, v1 : int64, v2 : string) : string =
    let v3 : string = method18()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "path"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure6(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure6(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure6(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "retry"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure6(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v74 : string = $"{v1}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v83 : string = $"{v45}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v92 : string = "ex"
    let v93 : string = $"{v92}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure6(v4, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = $"{v26}"
    let v105 : unit = ()
    let v106 : (unit -> unit) = closure6(v4, v102)
    let v107 : unit = (fun () -> v106 (); v105) ()
    let v111 : string = $"{v2}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure6(v4, v111)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v120 : string = " }"
    let v121 : string = $"{v120}"
    let v124 : unit = ()
    let v125 : (unit -> unit) = closure6(v4, v121)
    let v126 : unit = (fun () -> v125 (); v124) ()
    let v129 : string = v4.l0
    v129
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : int64, v10 : string) : string =
    let v11 : string = method29(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v14 : string = "file_system.wait_for_file_access"
    let v15 : string = $"{v6} {v7} #{v12} %s{v14} / {v11}"
    method23(v15)
and closure12 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v3 : US0 = US0_1
    let v4 : bool = method11(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method16()
        let v48 : string = method20(v0)
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v55 : string = $"%A{v2}"
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v59 : string = $"%A{v2}"
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v63 : string = $"%A{v2}"
        let _run_target_args'_v53 = v63 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v67 : string = $"%A{v2}"
        let _run_target_args'_v53 = v67 
        #endif
#if FABLE_COMPILER_PYTHON
        let v71 : string = $"%A{v2}"
        let _run_target_args'_v53 = v71 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = $"%A{v2}"
        let _run_target_args'_v53 = v75 
        #endif
#else
        let v78 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v53 = v78 
        #endif
        let v79 : string = _run_target_args'_v53 
        let v85 : string = method28(v28, v29, v30, v31, v32, v33, v46, v47, v48, v1, v79)
        method24(v85)
and method27 (v0 : US6, v1 : string, v2 : int64, v3 : US8, v4 : US7) : Async<int64> =
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
            try
                (* run_target_args'
                let v30 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v30 = v32 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v36 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v30 = v36 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v40 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v30 = v40 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v44 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v30 = v44 
                #endif
#if FABLE_COMPILER_PYTHON
                let v48 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v30 = v48 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v52 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v30 = v52 
                #endif
#else
                let v55 : System.IO.FileMode = System.IO.FileMode.Open
                let v61 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v56 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v56
                    | US7_2 -> (* AccessReadWrite *)
                        let v58 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v58
                    | US7_1 -> (* AccessWrite *)
                        let v57 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v57
                let v71 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v66 : System.IO.FileShare = System.IO.FileShare.Delete
                        v66
                    | US8_0 -> (* ShareNone *)
                        let v62 : System.IO.FileShare = System.IO.FileShare.None
                        v62
                    | US8_1 -> (* ShareRead *)
                        let v63 : System.IO.FileShare = System.IO.FileShare.Read
                        v63
                    | US8_3 -> (* ShareReadWrite *)
                        let v65 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v65
                    | US8_2 -> (* ShareWrite *)
                        let v64 : System.IO.FileShare = System.IO.FileShare.Write
                        v64
                let v72 : System.IO.FileStream = new System.IO.FileStream (v1, v55, v61, v71)
                let _run_target_args'_v30 = v72 
                #endif
                let v73 : System.IO.FileStream = _run_target_args'_v30 
                use v73 = v73 
                let v79 : System.IO.FileStream = v73 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v134 : exn = ex
                let v135 : bool = v2 > 0L
                let v138 : bool =
                    if v135 then
                        let v136 : int64 = v2 % 100L
                        let v137 : bool = v136 = 0L
                        v137
                    else
                        false
                if v138 then
                    let v139 : unit = ()
                    let v140 : (unit -> unit) = closure12(v1, v2, v134)
                    let v141 : unit = (fun () -> v140 (); v139) ()
                    ()
                (* run_target_args'
                let v229 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v230 : (int32 -> Async<unit>) = Async.Sleep
                let v231 : Async<unit> = v230 10
                let _run_target_args'_v229 = v231 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v232 : (int32 -> Async<unit>) = Async.Sleep
                let v233 : Async<unit> = v232 10
                let _run_target_args'_v229 = v233 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v234 : (int32 -> Async<unit>) = Async.Sleep
                let v235 : Async<unit> = v234 10
                let _run_target_args'_v229 = v235 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v236 : (int32 -> Async<unit>) = Async.Sleep
                let v237 : Async<unit> = v236 10
                let _run_target_args'_v229 = v237 
                #endif
#if FABLE_COMPILER_PYTHON
                let v238 : (int32 -> Async<unit>) = Async.Sleep
                let v239 : Async<unit> = v238 10
                let _run_target_args'_v229 = v239 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v240 : (int32 -> Async<unit>) = Async.Sleep
                let v241 : Async<unit> = v240 10
                let _run_target_args'_v229 = v241 
                #endif
#else
                let v242 : (int32 -> Async<unit>) = Async.Sleep
                let v243 : Async<unit> = v242 10
                let _run_target_args'_v229 = v243 
                #endif
                let v244 : Async<unit> = _run_target_args'_v229 
                do! v244 
                let v247 : int64 = v2 + 1L
                let v248 : Async<int64> = method26(v0, v1, v247)
                return! v248 
                (* indent
                ()
            indent *)
            (* try_unit
            let v365 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2762 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v2762 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2764 : unit = ()
    let _let'_v2764 =
        async {
            try
                (* run_target_args'
                let v2771 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2773 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2771 = v2773 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2777 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2771 = v2777 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2781 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2771 = v2781 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2785 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2771 = v2785 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2789 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2771 = v2789 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2793 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2771 = v2793 
                #endif
#else
                let v2796 : System.IO.FileMode = System.IO.FileMode.Open
                let v2802 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v2797 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v2797
                    | US7_2 -> (* AccessReadWrite *)
                        let v2799 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v2799
                    | US7_1 -> (* AccessWrite *)
                        let v2798 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v2798
                let v2812 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v2807 : System.IO.FileShare = System.IO.FileShare.Delete
                        v2807
                    | US8_0 -> (* ShareNone *)
                        let v2803 : System.IO.FileShare = System.IO.FileShare.None
                        v2803
                    | US8_1 -> (* ShareRead *)
                        let v2804 : System.IO.FileShare = System.IO.FileShare.Read
                        v2804
                    | US8_3 -> (* ShareReadWrite *)
                        let v2806 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v2806
                    | US8_2 -> (* ShareWrite *)
                        let v2805 : System.IO.FileShare = System.IO.FileShare.Write
                        v2805
                let v2813 : System.IO.FileStream = new System.IO.FileStream (v1, v2796, v2802, v2812)
                let _run_target_args'_v2771 = v2813 
                #endif
                let v2814 : System.IO.FileStream = _run_target_args'_v2771 
                use v2814 = v2814 
                let v2820 : System.IO.FileStream = v2814 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v2875 : exn = ex
                let v2876 : bool = v2 > 0L
                let v2879 : bool =
                    if v2876 then
                        let v2877 : int64 = v2 % 100L
                        let v2878 : bool = v2877 = 0L
                        v2878
                    else
                        false
                if v2879 then
                    let v2880 : unit = ()
                    let v2881 : (unit -> unit) = closure12(v1, v2, v2875)
                    let v2882 : unit = (fun () -> v2881 (); v2880) ()
                    ()
                (* run_target_args'
                let v2970 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2971 : (int32 -> Async<unit>) = Async.Sleep
                let v2972 : Async<unit> = v2971 10
                let _run_target_args'_v2970 = v2972 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2973 : (int32 -> Async<unit>) = Async.Sleep
                let v2974 : Async<unit> = v2973 10
                let _run_target_args'_v2970 = v2974 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2975 : (int32 -> Async<unit>) = Async.Sleep
                let v2976 : Async<unit> = v2975 10
                let _run_target_args'_v2970 = v2976 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2977 : (int32 -> Async<unit>) = Async.Sleep
                let v2978 : Async<unit> = v2977 10
                let _run_target_args'_v2970 = v2978 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2979 : (int32 -> Async<unit>) = Async.Sleep
                let v2980 : Async<unit> = v2979 10
                let _run_target_args'_v2970 = v2980 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2981 : (int32 -> Async<unit>) = Async.Sleep
                let v2982 : Async<unit> = v2981 10
                let _run_target_args'_v2970 = v2982 
                #endif
#else
                let v2983 : (int32 -> Async<unit>) = Async.Sleep
                let v2984 : Async<unit> = v2983 10
                let _run_target_args'_v2970 = v2984 
                #endif
                let v2985 : Async<unit> = _run_target_args'_v2970 
                do! v2985 
                let v2988 : int64 = v2 + 1L
                let v2989 : Async<int64> = method26(v0, v1, v2988)
                return! v2989 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3106 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5503 : Async<int64> = _let'_v2764 
    let _run_target_args'_v9 = v5503 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5505 : unit = ()
    let _let'_v5505 =
        async {
            try
                (* run_target_args'
                let v5512 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5514 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5512 = v5514 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5518 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5512 = v5518 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5522 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5512 = v5522 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5526 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5512 = v5526 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5530 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5512 = v5530 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5534 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5512 = v5534 
                #endif
#else
                let v5537 : System.IO.FileMode = System.IO.FileMode.Open
                let v5543 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v5538 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v5538
                    | US7_2 -> (* AccessReadWrite *)
                        let v5540 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v5540
                    | US7_1 -> (* AccessWrite *)
                        let v5539 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v5539
                let v5553 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v5548 : System.IO.FileShare = System.IO.FileShare.Delete
                        v5548
                    | US8_0 -> (* ShareNone *)
                        let v5544 : System.IO.FileShare = System.IO.FileShare.None
                        v5544
                    | US8_1 -> (* ShareRead *)
                        let v5545 : System.IO.FileShare = System.IO.FileShare.Read
                        v5545
                    | US8_3 -> (* ShareReadWrite *)
                        let v5547 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v5547
                    | US8_2 -> (* ShareWrite *)
                        let v5546 : System.IO.FileShare = System.IO.FileShare.Write
                        v5546
                let v5554 : System.IO.FileStream = new System.IO.FileStream (v1, v5537, v5543, v5553)
                let _run_target_args'_v5512 = v5554 
                #endif
                let v5555 : System.IO.FileStream = _run_target_args'_v5512 
                use v5555 = v5555 
                let v5561 : System.IO.FileStream = v5555 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v5616 : exn = ex
                let v5617 : bool = v2 > 0L
                let v5620 : bool =
                    if v5617 then
                        let v5618 : int64 = v2 % 100L
                        let v5619 : bool = v5618 = 0L
                        v5619
                    else
                        false
                if v5620 then
                    let v5621 : unit = ()
                    let v5622 : (unit -> unit) = closure12(v1, v2, v5616)
                    let v5623 : unit = (fun () -> v5622 (); v5621) ()
                    ()
                (* run_target_args'
                let v5711 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5712 : (int32 -> Async<unit>) = Async.Sleep
                let v5713 : Async<unit> = v5712 10
                let _run_target_args'_v5711 = v5713 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5714 : (int32 -> Async<unit>) = Async.Sleep
                let v5715 : Async<unit> = v5714 10
                let _run_target_args'_v5711 = v5715 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5716 : (int32 -> Async<unit>) = Async.Sleep
                let v5717 : Async<unit> = v5716 10
                let _run_target_args'_v5711 = v5717 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5718 : (int32 -> Async<unit>) = Async.Sleep
                let v5719 : Async<unit> = v5718 10
                let _run_target_args'_v5711 = v5719 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5720 : (int32 -> Async<unit>) = Async.Sleep
                let v5721 : Async<unit> = v5720 10
                let _run_target_args'_v5711 = v5721 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5722 : (int32 -> Async<unit>) = Async.Sleep
                let v5723 : Async<unit> = v5722 10
                let _run_target_args'_v5711 = v5723 
                #endif
#else
                let v5724 : (int32 -> Async<unit>) = Async.Sleep
                let v5725 : Async<unit> = v5724 10
                let _run_target_args'_v5711 = v5725 
                #endif
                let v5726 : Async<unit> = _run_target_args'_v5711 
                do! v5726 
                let v5729 : int64 = v2 + 1L
                let v5730 : Async<int64> = method26(v0, v1, v5729)
                return! v5730 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5847 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v8244 : Async<int64> = _let'_v5505 
    let _run_target_args'_v9 = v8244 
    #endif
#else
    let v8246 : unit = ()
    let _let'_v8246 =
        async {
            try
                (* run_target_args'
                let v8253 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v8255 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8253 = v8255 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v8259 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8253 = v8259 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v8263 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8253 = v8263 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v8267 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8253 = v8267 
                #endif
#if FABLE_COMPILER_PYTHON
                let v8271 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8253 = v8271 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v8275 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8253 = v8275 
                #endif
#else
                let v8278 : System.IO.FileMode = System.IO.FileMode.Open
                let v8284 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v8279 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v8279
                    | US7_2 -> (* AccessReadWrite *)
                        let v8281 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v8281
                    | US7_1 -> (* AccessWrite *)
                        let v8280 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v8280
                let v8294 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v8289 : System.IO.FileShare = System.IO.FileShare.Delete
                        v8289
                    | US8_0 -> (* ShareNone *)
                        let v8285 : System.IO.FileShare = System.IO.FileShare.None
                        v8285
                    | US8_1 -> (* ShareRead *)
                        let v8286 : System.IO.FileShare = System.IO.FileShare.Read
                        v8286
                    | US8_3 -> (* ShareReadWrite *)
                        let v8288 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v8288
                    | US8_2 -> (* ShareWrite *)
                        let v8287 : System.IO.FileShare = System.IO.FileShare.Write
                        v8287
                let v8295 : System.IO.FileStream = new System.IO.FileStream (v1, v8278, v8284, v8294)
                let _run_target_args'_v8253 = v8295 
                #endif
                let v8296 : System.IO.FileStream = _run_target_args'_v8253 
                use v8296 = v8296 
                let v8302 : System.IO.FileStream = v8296 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v8357 : exn = ex
                let v8358 : bool = v2 > 0L
                let v8361 : bool =
                    if v8358 then
                        let v8359 : int64 = v2 % 100L
                        let v8360 : bool = v8359 = 0L
                        v8360
                    else
                        false
                if v8361 then
                    let v8362 : unit = ()
                    let v8363 : (unit -> unit) = closure12(v1, v2, v8357)
                    let v8364 : unit = (fun () -> v8363 (); v8362) ()
                    ()
                (* run_target_args'
                let v8452 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v8453 : (int32 -> Async<unit>) = Async.Sleep
                let v8454 : Async<unit> = v8453 10
                let _run_target_args'_v8452 = v8454 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v8455 : (int32 -> Async<unit>) = Async.Sleep
                let v8456 : Async<unit> = v8455 10
                let _run_target_args'_v8452 = v8456 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v8457 : (int32 -> Async<unit>) = Async.Sleep
                let v8458 : Async<unit> = v8457 10
                let _run_target_args'_v8452 = v8458 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v8459 : (int32 -> Async<unit>) = Async.Sleep
                let v8460 : Async<unit> = v8459 10
                let _run_target_args'_v8452 = v8460 
                #endif
#if FABLE_COMPILER_PYTHON
                let v8461 : (int32 -> Async<unit>) = Async.Sleep
                let v8462 : Async<unit> = v8461 10
                let _run_target_args'_v8452 = v8462 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v8463 : (int32 -> Async<unit>) = Async.Sleep
                let v8464 : Async<unit> = v8463 10
                let _run_target_args'_v8452 = v8464 
                #endif
#else
                let v8465 : (int32 -> Async<unit>) = Async.Sleep
                let v8466 : Async<unit> = v8465 10
                let _run_target_args'_v8452 = v8466 
                #endif
                let v8467 : Async<unit> = _run_target_args'_v8452 
                do! v8467 
                let v8470 : int64 = v2 + 1L
                let v8471 : Async<int64> = method26(v0, v1, v8470)
                return! v8471 
                (* indent
                ()
            indent *)
            (* try_unit
            let v8588 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v10985 : Async<int64> = _let'_v8246 
    let _run_target_args'_v9 = v10985 
    #endif
    let v10986 : Async<int64> = _run_target_args'_v9 
    v10986
and method26 (v0 : US6, v1 : string, v2 : int64) : Async<int64> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v21 
    #endif
#if FABLE_COMPILER_PYTHON
    let v25 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v25 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v29 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v29 
    #endif
#else
    let struct (v38 : US7, v39 : US8) =
        match v0 with
        | US6_1 -> (* None *)
            let v34 : US7 = US7_2
            let v35 : US8 = US8_1
            struct (v34, v35)
        | US6_0(v32, v33) -> (* Some *)
            struct (v32, v33)
    let v40 : Async<int64> = method27(v0, v1, v2, v39, v38)
    let _run_target_args'_v7 = v40 
    #endif
    let v41 : Async<int64> = _run_target_args'_v7 
    v41
and method25 (v0 : US6, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method26(v0, v1, v2)
and closure11 (v0 : US6) (v1 : string) : Async<int64> =
    method25(v0, v1)
and closure10 () (v0 : US6) : (string -> Async<int64>) =
    closure11(v0)
and method30 (v0 : string) : Async<int64> =
    let v1 : US7 = US7_0
    let v2 : US8 = US8_1
    let v3 : US6 = US6_0(v1, v2)
    method25(v3, v0)
and closure13 () (v0 : string) : Async<int64> =
    method30(v0)
and method34 () : string =
    
    
    
    
    
    let v1 : string = "Verbose"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method17(v6)
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
    let v137 : string = method19()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[90m"
    let v141 : string = method19()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[90m"
    let v145 : string = method19()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[90m"
    let v149 : string = method19()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method36 (v0 : int64, v1 : string, v2 : exn) : string =
    let v3 : string = method18()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "retry"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure6(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure6(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure6(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "path"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure6(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v74 : string = $"{v1}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v83 : string = $"{v45}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v92 : string = "ex"
    let v93 : string = $"{v92}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure6(v4, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = $"{v26}"
    let v105 : unit = ()
    let v106 : (unit -> unit) = closure6(v4, v102)
    let v107 : unit = (fun () -> v106 (); v105) ()
    (* run_target_args'
    let v114 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v115 : string = "format!(\"{:#?}\", $0)"
    let v116 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v115 
    let v117 : string = "fable_library_rust::String_::fromString($0)"
    let v118 : string = Fable.Core.RustInterop.emitRustExpr v116 v117 
    let _run_target_args'_v114 = v118 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v119 : string = "format!(\"{:#?}\", $0)"
    let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v119 
    let v121 : string = "fable_library_rust::String_::fromString($0)"
    let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let _run_target_args'_v114 = v122 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v123 : string = "format!(\"{:#?}\", $0)"
    let v124 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v123 
    let v125 : string = "fable_library_rust::String_::fromString($0)"
    let v126 : string = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let _run_target_args'_v114 = v126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v128 : string = $"%A{v2}"
    let _run_target_args'_v114 = v128 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : string = $"%A{v2}"
    let _run_target_args'_v114 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : string = $"%A{v2}"
    let _run_target_args'_v114 = v136 
    #endif
#else
    let v140 : string = $"%A{v2}"
    let _run_target_args'_v114 = v140 
    #endif
    let v143 : string = _run_target_args'_v114 
    let v150 : string = $"{v143}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure6(v4, v150)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v159 : string = " }"
    let v160 : string = $"{v159}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure6(v4, v160)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v168 : string = v4.l0
    v168
and method35 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string, v10 : exn) : string =
    let v11 : string = method36(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v14 : string = "file_system.read_all_text_async"
    let v15 : string = $"{v6} {v7} #{v12} %s{v14} / {v11}"
    method23(v15)
and closure15 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v3 : US0 = US0_0
    let v4 : bool = method11(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method34()
        let v48 : string = method35(v28, v29, v30, v31, v32, v33, v46, v47, v1, v0, v2)
        method24(v48)
and method33 (v0 : string, v1 : int64) : Async<string> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            try
                (* run_target_args'
                let v27 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v29 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27 = v29 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v33 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27 = v33 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v37 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27 = v37 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v41 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27 = v41 
                #endif
#if FABLE_COMPILER_PYTHON
                let v45 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27 = v45 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v49 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27 = v49 
                #endif
#else
                let v52 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v53 : System.Threading.Tasks.Task<string> = v52 v0
                let _run_target_args'_v27 = v53 
                #endif
                let v54 : System.Threading.Tasks.Task<string> = _run_target_args'_v27 
                (* run_target_args'
                let v64 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v64 = v66 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v70 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v64 = v70 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v74 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v64 = v74 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v77 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v78 : Async<string> = v77 v54
                let _run_target_args'_v64 = v78 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v80 : Async<string> = v79 v54
                let _run_target_args'_v64 = v80 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v81 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v82 : Async<string> = v81 v54
                let _run_target_args'_v64 = v82 
                #endif
#else
                let v83 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v84 : Async<string> = v83 v54
                let _run_target_args'_v64 = v84 
                #endif
                let v85 : Async<string> = _run_target_args'_v64 
                return! v85 
                (* indent
                ()
            indent *)
            with ex ->
                let v159 : exn = ex
                let v160 : unit = ()
                let v161 : (unit -> unit) = closure15(v0, v1, v159)
                let v162 : unit = (fun () -> v161 (); v160) ()
                (* run_target_args'
                let v213 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v214 : (int32 -> Async<unit>) = Async.Sleep
                let v215 : Async<unit> = v214 10
                let _run_target_args'_v213 = v215 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v216 : (int32 -> Async<unit>) = Async.Sleep
                let v217 : Async<unit> = v216 10
                let _run_target_args'_v213 = v217 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v218 : (int32 -> Async<unit>) = Async.Sleep
                let v219 : Async<unit> = v218 10
                let _run_target_args'_v213 = v219 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v220 : (int32 -> Async<unit>) = Async.Sleep
                let v221 : Async<unit> = v220 10
                let _run_target_args'_v213 = v221 
                #endif
#if FABLE_COMPILER_PYTHON
                let v222 : (int32 -> Async<unit>) = Async.Sleep
                let v223 : Async<unit> = v222 10
                let _run_target_args'_v213 = v223 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v224 : (int32 -> Async<unit>) = Async.Sleep
                let v225 : Async<unit> = v224 10
                let _run_target_args'_v213 = v225 
                #endif
#else
                let v226 : (int32 -> Async<unit>) = Async.Sleep
                let v227 : Async<unit> = v226 10
                let _run_target_args'_v213 = v227 
                #endif
                let v228 : Async<unit> = _run_target_args'_v213 
                do! v228 
                let v231 : bool = v1 < 3L
                let v236 : Async<string> =
                    if v231 then
                        let v232 : int64 = v1 + 1L
                        method32(v0, v232)
                    else
                        let v234 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v234
                return! v236 
                (* indent
                ()
            indent *)
            (* try_unit
            let v316 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2391 : Async<string> = _let'_v20 
    let _run_target_args'_v6 = v2391 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2393 : unit = ()
    let _let'_v2393 =
        async {
            try
                (* run_target_args'
                let v2400 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2402 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2400 = v2402 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2406 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2400 = v2406 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2410 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2400 = v2410 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2414 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2400 = v2414 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2418 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2400 = v2418 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2422 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2400 = v2422 
                #endif
#else
                let v2425 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v2426 : System.Threading.Tasks.Task<string> = v2425 v0
                let _run_target_args'_v2400 = v2426 
                #endif
                let v2427 : System.Threading.Tasks.Task<string> = _run_target_args'_v2400 
                (* run_target_args'
                let v2437 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2439 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v2437 = v2439 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2443 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v2437 = v2443 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2447 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v2437 = v2447 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2450 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2451 : Async<string> = v2450 v2427
                let _run_target_args'_v2437 = v2451 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2452 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2453 : Async<string> = v2452 v2427
                let _run_target_args'_v2437 = v2453 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2454 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2455 : Async<string> = v2454 v2427
                let _run_target_args'_v2437 = v2455 
                #endif
#else
                let v2456 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2457 : Async<string> = v2456 v2427
                let _run_target_args'_v2437 = v2457 
                #endif
                let v2458 : Async<string> = _run_target_args'_v2437 
                return! v2458 
                (* indent
                ()
            indent *)
            with ex ->
                let v2532 : exn = ex
                let v2533 : unit = ()
                let v2534 : (unit -> unit) = closure15(v0, v1, v2532)
                let v2535 : unit = (fun () -> v2534 (); v2533) ()
                (* run_target_args'
                let v2586 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2587 : (int32 -> Async<unit>) = Async.Sleep
                let v2588 : Async<unit> = v2587 10
                let _run_target_args'_v2586 = v2588 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2589 : (int32 -> Async<unit>) = Async.Sleep
                let v2590 : Async<unit> = v2589 10
                let _run_target_args'_v2586 = v2590 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2591 : (int32 -> Async<unit>) = Async.Sleep
                let v2592 : Async<unit> = v2591 10
                let _run_target_args'_v2586 = v2592 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2593 : (int32 -> Async<unit>) = Async.Sleep
                let v2594 : Async<unit> = v2593 10
                let _run_target_args'_v2586 = v2594 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2595 : (int32 -> Async<unit>) = Async.Sleep
                let v2596 : Async<unit> = v2595 10
                let _run_target_args'_v2586 = v2596 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2597 : (int32 -> Async<unit>) = Async.Sleep
                let v2598 : Async<unit> = v2597 10
                let _run_target_args'_v2586 = v2598 
                #endif
#else
                let v2599 : (int32 -> Async<unit>) = Async.Sleep
                let v2600 : Async<unit> = v2599 10
                let _run_target_args'_v2586 = v2600 
                #endif
                let v2601 : Async<unit> = _run_target_args'_v2586 
                do! v2601 
                let v2604 : bool = v1 < 3L
                let v2609 : Async<string> =
                    if v2604 then
                        let v2605 : int64 = v1 + 1L
                        method32(v0, v2605)
                    else
                        let v2607 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v2607
                return! v2609 
                (* indent
                ()
            indent *)
            (* try_unit
            let v2689 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4764 : Async<string> = _let'_v2393 
    let _run_target_args'_v6 = v4764 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4766 : unit = ()
    let _let'_v4766 =
        async {
            try
                (* run_target_args'
                let v4773 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4775 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4773 = v4775 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4779 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4773 = v4779 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4783 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4773 = v4783 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4787 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4773 = v4787 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4791 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4773 = v4791 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4795 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4773 = v4795 
                #endif
#else
                let v4798 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v4799 : System.Threading.Tasks.Task<string> = v4798 v0
                let _run_target_args'_v4773 = v4799 
                #endif
                let v4800 : System.Threading.Tasks.Task<string> = _run_target_args'_v4773 
                (* run_target_args'
                let v4810 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4812 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v4810 = v4812 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4816 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v4810 = v4816 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4820 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v4810 = v4820 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4823 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4824 : Async<string> = v4823 v4800
                let _run_target_args'_v4810 = v4824 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4825 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4826 : Async<string> = v4825 v4800
                let _run_target_args'_v4810 = v4826 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4827 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4828 : Async<string> = v4827 v4800
                let _run_target_args'_v4810 = v4828 
                #endif
#else
                let v4829 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4830 : Async<string> = v4829 v4800
                let _run_target_args'_v4810 = v4830 
                #endif
                let v4831 : Async<string> = _run_target_args'_v4810 
                return! v4831 
                (* indent
                ()
            indent *)
            with ex ->
                let v4905 : exn = ex
                let v4906 : unit = ()
                let v4907 : (unit -> unit) = closure15(v0, v1, v4905)
                let v4908 : unit = (fun () -> v4907 (); v4906) ()
                (* run_target_args'
                let v4959 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4960 : (int32 -> Async<unit>) = Async.Sleep
                let v4961 : Async<unit> = v4960 10
                let _run_target_args'_v4959 = v4961 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4962 : (int32 -> Async<unit>) = Async.Sleep
                let v4963 : Async<unit> = v4962 10
                let _run_target_args'_v4959 = v4963 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4964 : (int32 -> Async<unit>) = Async.Sleep
                let v4965 : Async<unit> = v4964 10
                let _run_target_args'_v4959 = v4965 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4966 : (int32 -> Async<unit>) = Async.Sleep
                let v4967 : Async<unit> = v4966 10
                let _run_target_args'_v4959 = v4967 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4968 : (int32 -> Async<unit>) = Async.Sleep
                let v4969 : Async<unit> = v4968 10
                let _run_target_args'_v4959 = v4969 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4970 : (int32 -> Async<unit>) = Async.Sleep
                let v4971 : Async<unit> = v4970 10
                let _run_target_args'_v4959 = v4971 
                #endif
#else
                let v4972 : (int32 -> Async<unit>) = Async.Sleep
                let v4973 : Async<unit> = v4972 10
                let _run_target_args'_v4959 = v4973 
                #endif
                let v4974 : Async<unit> = _run_target_args'_v4959 
                do! v4974 
                let v4977 : bool = v1 < 3L
                let v4982 : Async<string> =
                    if v4977 then
                        let v4978 : int64 = v1 + 1L
                        method32(v0, v4978)
                    else
                        let v4980 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v4980
                return! v4982 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5062 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7137 : Async<string> = _let'_v4766 
    let _run_target_args'_v6 = v7137 
    #endif
#else
    let v7139 : unit = ()
    let _let'_v7139 =
        async {
            try
                (* run_target_args'
                let v7146 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7148 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7146 = v7148 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7152 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7146 = v7152 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7156 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7146 = v7156 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7160 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7146 = v7160 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7164 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7146 = v7164 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7168 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7146 = v7168 
                #endif
#else
                let v7171 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v7172 : System.Threading.Tasks.Task<string> = v7171 v0
                let _run_target_args'_v7146 = v7172 
                #endif
                let v7173 : System.Threading.Tasks.Task<string> = _run_target_args'_v7146 
                (* run_target_args'
                let v7183 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7185 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v7183 = v7185 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7189 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v7183 = v7189 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7193 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v7183 = v7193 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7196 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7197 : Async<string> = v7196 v7173
                let _run_target_args'_v7183 = v7197 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7198 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7199 : Async<string> = v7198 v7173
                let _run_target_args'_v7183 = v7199 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7200 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7201 : Async<string> = v7200 v7173
                let _run_target_args'_v7183 = v7201 
                #endif
#else
                let v7202 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7203 : Async<string> = v7202 v7173
                let _run_target_args'_v7183 = v7203 
                #endif
                let v7204 : Async<string> = _run_target_args'_v7183 
                return! v7204 
                (* indent
                ()
            indent *)
            with ex ->
                let v7278 : exn = ex
                let v7279 : unit = ()
                let v7280 : (unit -> unit) = closure15(v0, v1, v7278)
                let v7281 : unit = (fun () -> v7280 (); v7279) ()
                (* run_target_args'
                let v7332 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7333 : (int32 -> Async<unit>) = Async.Sleep
                let v7334 : Async<unit> = v7333 10
                let _run_target_args'_v7332 = v7334 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7335 : (int32 -> Async<unit>) = Async.Sleep
                let v7336 : Async<unit> = v7335 10
                let _run_target_args'_v7332 = v7336 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7337 : (int32 -> Async<unit>) = Async.Sleep
                let v7338 : Async<unit> = v7337 10
                let _run_target_args'_v7332 = v7338 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7339 : (int32 -> Async<unit>) = Async.Sleep
                let v7340 : Async<unit> = v7339 10
                let _run_target_args'_v7332 = v7340 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7341 : (int32 -> Async<unit>) = Async.Sleep
                let v7342 : Async<unit> = v7341 10
                let _run_target_args'_v7332 = v7342 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7343 : (int32 -> Async<unit>) = Async.Sleep
                let v7344 : Async<unit> = v7343 10
                let _run_target_args'_v7332 = v7344 
                #endif
#else
                let v7345 : (int32 -> Async<unit>) = Async.Sleep
                let v7346 : Async<unit> = v7345 10
                let _run_target_args'_v7332 = v7346 
                #endif
                let v7347 : Async<unit> = _run_target_args'_v7332 
                do! v7347 
                let v7350 : bool = v1 < 3L
                let v7355 : Async<string> =
                    if v7350 then
                        let v7351 : int64 = v1 + 1L
                        method32(v0, v7351)
                    else
                        let v7353 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v7353
                return! v7355 
                (* indent
                ()
            indent *)
            (* try_unit
            let v7435 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9510 : Async<string> = _let'_v7139 
    let _run_target_args'_v6 = v9510 
    #endif
    let v9511 : Async<string> = _run_target_args'_v6 
    v9511
and method32 (v0 : string, v1 : int64) : Async<string> =
    method33(v0, v1)
and method31 (v0 : string) : Async<string> =
    let v1 : int64 = 0L
    method32(v0, v1)
and closure14 () (v0 : string) : Async<string> =
    method31(v0)
and method38 (v0 : string) : bool =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v18 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
#else
    let v30 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v30 
    #endif
    let v33 : Ref<Str> = _run_target_args'_v10 
    (* run_target_args'
    let v43 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v44 : string = "String::from($0)"
    let v45 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v44 
    let _run_target_args'_v43 = v45 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v46 : string = "String::from($0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v46 
    let _run_target_args'_v43 = v47 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v48 : string = "String::from($0)"
    let v49 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v48 
    let _run_target_args'_v43 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v59 
    #endif
#else
    let v63 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v63 
    #endif
    let v66 : std_string_String = _run_target_args'_v43 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "std::path::PathBuf::from($0)"
    let v78 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "std::path::PathBuf::from($0)"
    let v80 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "std::path::PathBuf::from($0)"
    let v82 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : std_path_PathBuf = _run_target_args'_v76 
    let v105 : string = "$0.exists()"
    let v106 : bool = Fable.Core.RustInterop.emitRustExpr v99 v105 
    let v109 : bool =
        if v106 then
            let v107 : string = "$0.is_file()"
            let v108 : bool = Fable.Core.RustInterop.emitRustExpr v99 v107 
            v108
        else
            false
    let _run_target_args'_v5 = v109 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v111 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v111 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v115 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v115 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v118 : string = "fs"
    let v119 : IFsExistsSync = Fable.Core.JsInterop.importAll v118 
    let v120 : string = "$0.existsSync($1)"
    let v121 : bool = Fable.Core.JsInterop.emitJsExpr struct (v119, v0) v120 
    let _run_target_args'_v5 = v121 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v127 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v127 
    #endif
#else
    let v130 : (string -> bool) = System.IO.File.Exists
    let v131 : bool = v130 v0
    let _run_target_args'_v5 = v131 
    #endif
    let v132 : bool = _run_target_args'_v5 
    v132
and method39 (v0 : Vec<uint8>) : Vec<uint8> =
    v0
and method37 (v0 : string, v1 : string) : bool =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : bool = method38(v0)
    let v8 : bool = v7 = false
    let v113 : bool =
        if v8 then
            false
        else
            (* run_target_args'
            let v13 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            (* run_target_args'
            let v18 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v19 : string = "std::fs::read(&*$0)"
            let v20 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v19 
            (* run_target_args'
            let v22 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v23 : string = "$0.unwrap()"
            let v24 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v20 v23 
            let _run_target_args'_v22 = v24 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v25 : string = "$0.unwrap()"
            let v26 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v20 v25 
            let _run_target_args'_v22 = v26 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v27 : string = "$0.unwrap()"
            let v28 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v20 v27 
            let _run_target_args'_v22 = v28 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v29 : Vec<uint8> = match v20 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v22 = v29 
            #endif
#if FABLE_COMPILER_PYTHON
            let v30 : Vec<uint8> = match v20 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v22 = v30 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v31 : Vec<uint8> = match v20 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v22 = v31 
            #endif
#else
            let v32 : Vec<uint8> = match v20 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v22 = v32 
            #endif
            let v33 : Vec<uint8> = _run_target_args'_v22 
            let _run_target_args'_v18 = v33 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v37 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v18 = v37 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v41 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v18 = v41 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v45 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v18 = v45 
            #endif
#if FABLE_COMPILER_PYTHON
            let v49 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v18 = v49 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v53 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v18 = v53 
            #endif
#else
            let v56 : (uint8 []) = v0 |> System.IO.File.ReadAllBytes
            let v57 : string = "$0.to_vec()"
            let v58 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v56 v57 
            let _run_target_args'_v18 = v58 
            #endif
            let v59 : Vec<uint8> = _run_target_args'_v18 
            let v65 : Vec<uint8> = method39(v59)
            let v66 : string = "std::string::String::from_utf8($0)"
            let v67 : Result<std_string_String, std_string_FromUtf8Error> = Fable.Core.RustInterop.emitRustExpr v65 v66 
            (* run_target_args'
            let v69 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v70 : string = "$0.unwrap()"
            let v71 : std_string_String = Fable.Core.RustInterop.emitRustExpr v67 v70 
            let _run_target_args'_v69 = v71 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v72 : string = "$0.unwrap()"
            let v73 : std_string_String = Fable.Core.RustInterop.emitRustExpr v67 v72 
            let _run_target_args'_v69 = v73 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v74 : string = "$0.unwrap()"
            let v75 : std_string_String = Fable.Core.RustInterop.emitRustExpr v67 v74 
            let _run_target_args'_v69 = v75 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v76 : std_string_String = match v67 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v69 = v76 
            #endif
#if FABLE_COMPILER_PYTHON
            let v77 : std_string_String = match v67 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v69 = v77 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v78 : std_string_String = match v67 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v69 = v78 
            #endif
#else
            let v79 : std_string_String = match v67 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v69 = v79 
            #endif
            let v80 : std_string_String = _run_target_args'_v69 
            let v83 : string = "fable_library_rust::String_::fromString($0)"
            let v84 : string = Fable.Core.RustInterop.emitRustExpr v80 v83 
            let _run_target_args'_v13 = v84 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v86 : string = null |> unbox<string>
            let _run_target_args'_v13 = v86 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v90 : string = null |> unbox<string>
            let _run_target_args'_v13 = v90 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v94 : string = null |> unbox<string>
            let _run_target_args'_v13 = v94 
            #endif
#if FABLE_COMPILER_PYTHON
            let v98 : string = null |> unbox<string>
            let _run_target_args'_v13 = v98 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v102 : string = null |> unbox<string>
            let _run_target_args'_v13 = v102 
            #endif
#else
            let v105 : string = v0 |> System.IO.File.ReadAllText
            let _run_target_args'_v13 = v105 
            #endif
            let v106 : string = _run_target_args'_v13 
            let v112 : bool = v1 = v106
            v112
    let _run_target_args'_v6 = v113 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v115 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v115 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v119 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v119 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v123 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v123 
    #endif
#if FABLE_COMPILER_PYTHON
    let v127 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v127 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v131 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v131 
    #endif
#else
    let v135 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v135 
    #endif
    let v138 : bool = _run_target_args'_v6 
    v138
and closure17 (v0 : string) (v1 : string) : bool =
    method37(v0, v1)
and closure16 () (v0 : string) : (string -> bool) =
    closure17(v0)
and method40 (v0 : string, v1 : string) : Async<unit> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v28 
    #endif
#else
    let v31 : System.Threading.Tasks.Task = System.IO.File.WriteAllTextAsync (v0, v1)
    (* run_target_args'
    let v36 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v38 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v36 = v38 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v36 = v42 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v46 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v36 = v46 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v49 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v50 : Async<unit> = v49 v31
    let _run_target_args'_v36 = v50 
    #endif
#if FABLE_COMPILER_PYTHON
    let v51 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v52 : Async<unit> = v51 v31
    let _run_target_args'_v36 = v52 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v53 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v54 : Async<unit> = v53 v31
    let _run_target_args'_v36 = v54 
    #endif
#else
    let v55 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v56 : Async<unit> = v55 v31
    let _run_target_args'_v36 = v56 
    #endif
    let v57 : Async<unit> = _run_target_args'_v36 
    let _run_target_args'_v6 = v57 
    #endif
    let v63 : Async<unit> = _run_target_args'_v6 
    v63
and closure19 (v0 : string) (v1 : string) : Async<unit> =
    method40(v0, v1)
and closure18 () (v0 : string) : (string -> Async<unit>) =
    closure19(v0)
and method44 (v0 : string, v1 : string) : Async<bool> =
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
            let v23 : bool = method38(v0)
            let v24 : bool = v23 = false
            if v24 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v25 : Async<string> = method31(v0)
                let! v25 = v25 
                let v26 : string = v25 
                let v27 : bool = v1 = v26
                return v27 
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
    let v63 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v63 
    #endif
#if FABLE_COMPILER_PYTHON
    let v65 : unit = ()
    let _let'_v65 =
        async {
            let v68 : bool = method38(v0)
            let v69 : bool = v68 = false
            if v69 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v70 : Async<string> = method31(v0)
                let! v70 = v70 
                let v71 : string = v70 
                let v72 : bool = v1 = v71
                return v72 
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
    let v108 : Async<bool> = _let'_v65 
    let _run_target_args'_v6 = v108 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v110 : unit = ()
    let _let'_v110 =
        async {
            let v113 : bool = method38(v0)
            let v114 : bool = v113 = false
            if v114 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v115 : Async<string> = method31(v0)
                let! v115 = v115 
                let v116 : string = v115 
                let v117 : bool = v1 = v116
                return v117 
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
    let v153 : Async<bool> = _let'_v110 
    let _run_target_args'_v6 = v153 
    #endif
#else
    let v155 : unit = ()
    let _let'_v155 =
        async {
            let v158 : bool = method38(v0)
            let v159 : bool = v158 = false
            if v159 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v160 : Async<string> = method31(v0)
                let! v160 = v160 
                let v161 : string = v160 
                let v162 : bool = v1 = v161
                return v162 
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
    let v198 : Async<bool> = _let'_v155 
    let _run_target_args'_v6 = v198 
    #endif
    let v199 : Async<bool> = _run_target_args'_v6 
    v199
and method43 (v0 : string, v1 : string) : Async<bool> =
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
    let v20 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v6 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v6 = v28 
    #endif
#else
    let v31 : Async<bool> = method44(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<bool> = _run_target_args'_v6 
    v32
and method42 (v0 : string, v1 : string) : Async<unit> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let v23 : Async<bool> = method43(v0, v1)
            let! v23 = v23 
            let v24 : bool = v23 
            let v25 : bool = v24 = false
            if v25 then
                let v26 : Async<unit> = method40(v0, v1)
                do! v26 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v55 : Async<unit> = _let'_v20 
    let _run_target_args'_v6 = v55 
    #endif
#if FABLE_COMPILER_PYTHON
    let v57 : unit = ()
    let _let'_v57 =
        async {
            let v60 : Async<bool> = method43(v0, v1)
            let! v60 = v60 
            let v61 : bool = v60 
            let v62 : bool = v61 = false
            if v62 then
                let v63 : Async<unit> = method40(v0, v1)
                do! v63 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v92 : Async<unit> = _let'_v57 
    let _run_target_args'_v6 = v92 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v94 : unit = ()
    let _let'_v94 =
        async {
            let v97 : Async<bool> = method43(v0, v1)
            let! v97 = v97 
            let v98 : bool = v97 
            let v99 : bool = v98 = false
            if v99 then
                let v100 : Async<unit> = method40(v0, v1)
                do! v100 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v129 : Async<unit> = _let'_v94 
    let _run_target_args'_v6 = v129 
    #endif
#else
    let v131 : unit = ()
    let _let'_v131 =
        async {
            let v134 : Async<bool> = method43(v0, v1)
            let! v134 = v134 
            let v135 : bool = v134 
            let v136 : bool = v135 = false
            if v136 then
                let v137 : Async<unit> = method40(v0, v1)
                do! v137 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v166 : Async<unit> = _let'_v131 
    let _run_target_args'_v6 = v166 
    #endif
    let v167 : Async<unit> = _run_target_args'_v6 
    v167
and method41 (v0 : string, v1 : string) : Async<unit> =
    method42(v0, v1)
and closure21 (v0 : string) (v1 : string) : Async<unit> =
    method41(v0, v1)
and closure20 () (v0 : string) : (string -> Async<unit>) =
    closure21(v0)
and method49 (v0 : std_io_Error) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "format!(\"{:#?}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let _run_target_args'_v7 = v11 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : string = "format!(\"{:#?}\", $0)"
    let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let v14 : string = "fable_library_rust::String_::fromString($0)"
    let v15 : string = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let _run_target_args'_v7 = v15 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : string = "format!(\"{:#?}\", $0)"
    let v17 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v16 
    let v18 : string = "fable_library_rust::String_::fromString($0)"
    let v19 : string = Fable.Core.RustInterop.emitRustExpr v17 v18 
    let _run_target_args'_v7 = v19 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : string = $"%A{v0}"
    let _run_target_args'_v7 = v21 
    #endif
#if FABLE_COMPILER_PYTHON
    let v25 : string = $"%A{v0}"
    let _run_target_args'_v7 = v25 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v29 : string = $"%A{v0}"
    let _run_target_args'_v7 = v29 
    #endif
#else
    let v33 : string = $"%A{v0}"
    let _run_target_args'_v7 = v33 
    #endif
    let v36 : string = _run_target_args'_v7 
    let v43 : string = $"{v36}"
    let v46 : unit = ()
    let v47 : (unit -> unit) = closure6(v2, v43)
    let v48 : unit = (fun () -> v47 (); v46) ()
    let v51 : string = v2.l0
    v51
and closure23 () (v0 : std_io_Error) : string =
    method49(v0)
and method48 () : (std_io_Error -> string) =
    closure23()
and closure24 () () : US9 =
    US9_0
and method50 () : (unit -> US9) =
    closure24()
and closure25 () (v0 : string) : US9 =
    US9_1(v0)
and method51 () : (string -> US9) =
    closure25()
and method52 () : string =
    
    
    
    
    
    let v1 : string = "Critical"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method17(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_red"
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
    let v54 : string = "inline_colorization::color_bright_red"
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
    let v95 : string = "inline_colorization::color_bright_red"
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
    let v136 : string = "\u001b[91m"
    let v137 : string = method19()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[91m"
    let v141 : string = method19()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[91m"
    let v145 : string = method19()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[91m"
    let v149 : string = method19()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method54 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "error'"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure6(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure6(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"{v0}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure6(v2, v34)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v43 : string = " }"
    let v44 : string = $"{v43}"
    let v47 : unit = ()
    let v48 : (unit -> unit) = closure6(v2, v44)
    let v49 : unit = (fun () -> v48 (); v47) ()
    let v52 : string = v2.l0
    v52
and method53 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method54(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "file_system.file_delete"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method23(v13)
and closure26 (v0 : string) () : unit =
    let v1 : US0 = US0_4
    let v2 : bool = method11(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method12(v26, v27, v28, v29, v30, v31)
        let v45 : string = method52()
        let v46 : string = method53(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method24(v46)
and method55 () : string =
    
    
    
    
    
    let v1 : string = "Warning"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method17(v6)
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
    let v137 : string = method19()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[93m"
    let v141 : string = method19()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[93m"
    let v145 : string = method19()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[93m"
    let v149 : string = method19()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method57 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "path"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "ex"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure6(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method56 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method57(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "delete_file_async"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure27 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method55()
        let v47 : string = method20(v0)
        (* run_target_args'
        let v52 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v54 : string = $"%A{v1}"
        let _run_target_args'_v52 = v54 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v58 : string = $"%A{v1}"
        let _run_target_args'_v52 = v58 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v62 : string = $"%A{v1}"
        let _run_target_args'_v52 = v62 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v66 : string = $"%A{v1}"
        let _run_target_args'_v52 = v66 
        #endif
#if FABLE_COMPILER_PYTHON
        let v70 : string = $"%A{v1}"
        let _run_target_args'_v52 = v70 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v74 : string = $"%A{v1}"
        let _run_target_args'_v52 = v74 
        #endif
#else
        let v77 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v52 = v77 
        #endif
        let v78 : string = _run_target_args'_v52 
        let v84 : string = method56(v27, v28, v29, v30, v31, v32, v45, v46, v47, v78)
        method24(v84)
and method47 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            try
                (* run_target_args'
                let v23 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v24 : string = "std::fs::remove_file(&*$0)"
                let v25 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v24 
                let v26 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v28 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v29 : string = "$0.map_err(|x| $1(x))"
                let v30 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v25, v26) v29 
                let _run_target_args'_v28 = v30 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v31 : string = "$0.map_err(|x| $1(x))"
                let v32 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v25, v26) v31 
                let _run_target_args'_v28 = v32 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v33 : string = "$0.map_err(|x| $1(x))"
                let v34 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v25, v26) v33 
                let _run_target_args'_v28 = v34 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v35 : Result<unit, string> = match v25 with Ok x -> Ok x | Error x -> Error (v26 x)
                let _run_target_args'_v28 = v35 
                #endif
#if FABLE_COMPILER_PYTHON
                let v36 : Result<unit, string> = match v25 with Ok x -> Ok x | Error x -> Error (v26 x)
                let _run_target_args'_v28 = v36 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v37 : Result<unit, string> = match v25 with Ok x -> Ok x | Error x -> Error (v26 x)
                let _run_target_args'_v28 = v37 
                #endif
#else
                let v38 : Result<unit, string> = match v25 with Ok x -> Ok x | Error x -> Error (v26 x)
                let _run_target_args'_v28 = v38 
                #endif
                let v39 : Result<unit, string> = _run_target_args'_v28 
                let v42 : (unit -> US9) = method50()
                let v43 : (string -> US9) = method51()
                let v44 : US9 = match v39 with Ok () -> v42 () | Error x -> v43 x
                match v44 with
                | US9_1(v45) -> (* Error *)
                    let v46 : unit = ()
                    let v47 : (unit -> unit) = closure26(v45)
                    let v48 : unit = (fun () -> v47 (); v46) ()
                    ()
                | US9_0 -> (* Ok *)
                    ()
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
                let v95 : (string -> unit) = System.IO.File.Delete
                v95 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v169 : exn = ex
                let v170 : int64 = v1 % 100L
                let v171 : bool = v170 = 0L
                if v171 then
                    let v172 : unit = ()
                    let v173 : (unit -> unit) = closure27(v0, v169)
                    let v174 : unit = (fun () -> v173 (); v172) ()
                    ()
                (* run_target_args'
                let v262 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v263 : (int32 -> Async<unit>) = Async.Sleep
                let v264 : Async<unit> = v263 10
                let _run_target_args'_v262 = v264 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v265 : (int32 -> Async<unit>) = Async.Sleep
                let v266 : Async<unit> = v265 10
                let _run_target_args'_v262 = v266 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v267 : (int32 -> Async<unit>) = Async.Sleep
                let v268 : Async<unit> = v267 10
                let _run_target_args'_v262 = v268 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v269 : (int32 -> Async<unit>) = Async.Sleep
                let v270 : Async<unit> = v269 10
                let _run_target_args'_v262 = v270 
                #endif
#if FABLE_COMPILER_PYTHON
                let v271 : (int32 -> Async<unit>) = Async.Sleep
                let v272 : Async<unit> = v271 10
                let _run_target_args'_v262 = v272 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v273 : (int32 -> Async<unit>) = Async.Sleep
                let v274 : Async<unit> = v273 10
                let _run_target_args'_v262 = v274 
                #endif
#else
                let v275 : (int32 -> Async<unit>) = Async.Sleep
                let v276 : Async<unit> = v275 10
                let _run_target_args'_v262 = v276 
                #endif
                let v277 : Async<unit> = _run_target_args'_v262 
                do! v277 
                let v280 : int64 = v1 + 1L
                let v281 : Async<int64> = method46(v0, v280)
                return! v281 
                (* indent
                ()
            indent *)
            (* try_unit
            let v396 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3031 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v3031 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3033 : unit = ()
    let _let'_v3033 =
        async {
            try
                (* run_target_args'
                let v3036 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3037 : string = "std::fs::remove_file(&*$0)"
                let v3038 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v3037 
                let v3039 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v3041 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3042 : string = "$0.map_err(|x| $1(x))"
                let v3043 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3038, v3039) v3042 
                let _run_target_args'_v3041 = v3043 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3044 : string = "$0.map_err(|x| $1(x))"
                let v3045 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3038, v3039) v3044 
                let _run_target_args'_v3041 = v3045 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3046 : string = "$0.map_err(|x| $1(x))"
                let v3047 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3038, v3039) v3046 
                let _run_target_args'_v3041 = v3047 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3048 : Result<unit, string> = match v3038 with Ok x -> Ok x | Error x -> Error (v3039 x)
                let _run_target_args'_v3041 = v3048 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3049 : Result<unit, string> = match v3038 with Ok x -> Ok x | Error x -> Error (v3039 x)
                let _run_target_args'_v3041 = v3049 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3050 : Result<unit, string> = match v3038 with Ok x -> Ok x | Error x -> Error (v3039 x)
                let _run_target_args'_v3041 = v3050 
                #endif
#else
                let v3051 : Result<unit, string> = match v3038 with Ok x -> Ok x | Error x -> Error (v3039 x)
                let _run_target_args'_v3041 = v3051 
                #endif
                let v3052 : Result<unit, string> = _run_target_args'_v3041 
                let v3055 : (unit -> US9) = method50()
                let v3056 : (string -> US9) = method51()
                let v3057 : US9 = match v3052 with Ok () -> v3055 () | Error x -> v3056 x
                match v3057 with
                | US9_1(v3058) -> (* Error *)
                    let v3059 : unit = ()
                    let v3060 : (unit -> unit) = closure26(v3058)
                    let v3061 : unit = (fun () -> v3060 (); v3059) ()
                    ()
                | US9_0 -> (* Ok *)
                    ()
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
                let v3108 : (string -> unit) = System.IO.File.Delete
                v3108 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v3182 : exn = ex
                let v3183 : int64 = v1 % 100L
                let v3184 : bool = v3183 = 0L
                if v3184 then
                    let v3185 : unit = ()
                    let v3186 : (unit -> unit) = closure27(v0, v3182)
                    let v3187 : unit = (fun () -> v3186 (); v3185) ()
                    ()
                (* run_target_args'
                let v3275 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3276 : (int32 -> Async<unit>) = Async.Sleep
                let v3277 : Async<unit> = v3276 10
                let _run_target_args'_v3275 = v3277 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3278 : (int32 -> Async<unit>) = Async.Sleep
                let v3279 : Async<unit> = v3278 10
                let _run_target_args'_v3275 = v3279 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3280 : (int32 -> Async<unit>) = Async.Sleep
                let v3281 : Async<unit> = v3280 10
                let _run_target_args'_v3275 = v3281 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3282 : (int32 -> Async<unit>) = Async.Sleep
                let v3283 : Async<unit> = v3282 10
                let _run_target_args'_v3275 = v3283 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3284 : (int32 -> Async<unit>) = Async.Sleep
                let v3285 : Async<unit> = v3284 10
                let _run_target_args'_v3275 = v3285 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3286 : (int32 -> Async<unit>) = Async.Sleep
                let v3287 : Async<unit> = v3286 10
                let _run_target_args'_v3275 = v3287 
                #endif
#else
                let v3288 : (int32 -> Async<unit>) = Async.Sleep
                let v3289 : Async<unit> = v3288 10
                let _run_target_args'_v3275 = v3289 
                #endif
                let v3290 : Async<unit> = _run_target_args'_v3275 
                do! v3290 
                let v3293 : int64 = v1 + 1L
                let v3294 : Async<int64> = method46(v0, v3293)
                return! v3294 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3409 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6044 : Async<int64> = _let'_v3033 
    let _run_target_args'_v6 = v6044 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v6046 : unit = ()
    let _let'_v6046 =
        async {
            try
                (* run_target_args'
                let v6049 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6050 : string = "std::fs::remove_file(&*$0)"
                let v6051 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v6050 
                let v6052 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v6054 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6055 : string = "$0.map_err(|x| $1(x))"
                let v6056 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6051, v6052) v6055 
                let _run_target_args'_v6054 = v6056 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6057 : string = "$0.map_err(|x| $1(x))"
                let v6058 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6051, v6052) v6057 
                let _run_target_args'_v6054 = v6058 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6059 : string = "$0.map_err(|x| $1(x))"
                let v6060 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6051, v6052) v6059 
                let _run_target_args'_v6054 = v6060 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6061 : Result<unit, string> = match v6051 with Ok x -> Ok x | Error x -> Error (v6052 x)
                let _run_target_args'_v6054 = v6061 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6062 : Result<unit, string> = match v6051 with Ok x -> Ok x | Error x -> Error (v6052 x)
                let _run_target_args'_v6054 = v6062 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6063 : Result<unit, string> = match v6051 with Ok x -> Ok x | Error x -> Error (v6052 x)
                let _run_target_args'_v6054 = v6063 
                #endif
#else
                let v6064 : Result<unit, string> = match v6051 with Ok x -> Ok x | Error x -> Error (v6052 x)
                let _run_target_args'_v6054 = v6064 
                #endif
                let v6065 : Result<unit, string> = _run_target_args'_v6054 
                let v6068 : (unit -> US9) = method50()
                let v6069 : (string -> US9) = method51()
                let v6070 : US9 = match v6065 with Ok () -> v6068 () | Error x -> v6069 x
                match v6070 with
                | US9_1(v6071) -> (* Error *)
                    let v6072 : unit = ()
                    let v6073 : (unit -> unit) = closure26(v6071)
                    let v6074 : unit = (fun () -> v6073 (); v6072) ()
                    ()
                | US9_0 -> (* Ok *)
                    ()
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
                let v6121 : (string -> unit) = System.IO.File.Delete
                v6121 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v6195 : exn = ex
                let v6196 : int64 = v1 % 100L
                let v6197 : bool = v6196 = 0L
                if v6197 then
                    let v6198 : unit = ()
                    let v6199 : (unit -> unit) = closure27(v0, v6195)
                    let v6200 : unit = (fun () -> v6199 (); v6198) ()
                    ()
                (* run_target_args'
                let v6288 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6289 : (int32 -> Async<unit>) = Async.Sleep
                let v6290 : Async<unit> = v6289 10
                let _run_target_args'_v6288 = v6290 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6291 : (int32 -> Async<unit>) = Async.Sleep
                let v6292 : Async<unit> = v6291 10
                let _run_target_args'_v6288 = v6292 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6293 : (int32 -> Async<unit>) = Async.Sleep
                let v6294 : Async<unit> = v6293 10
                let _run_target_args'_v6288 = v6294 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6295 : (int32 -> Async<unit>) = Async.Sleep
                let v6296 : Async<unit> = v6295 10
                let _run_target_args'_v6288 = v6296 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6297 : (int32 -> Async<unit>) = Async.Sleep
                let v6298 : Async<unit> = v6297 10
                let _run_target_args'_v6288 = v6298 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6299 : (int32 -> Async<unit>) = Async.Sleep
                let v6300 : Async<unit> = v6299 10
                let _run_target_args'_v6288 = v6300 
                #endif
#else
                let v6301 : (int32 -> Async<unit>) = Async.Sleep
                let v6302 : Async<unit> = v6301 10
                let _run_target_args'_v6288 = v6302 
                #endif
                let v6303 : Async<unit> = _run_target_args'_v6288 
                do! v6303 
                let v6306 : int64 = v1 + 1L
                let v6307 : Async<int64> = method46(v0, v6306)
                return! v6307 
                (* indent
                ()
            indent *)
            (* try_unit
            let v6422 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9057 : Async<int64> = _let'_v6046 
    let _run_target_args'_v6 = v9057 
    #endif
#else
    let v9059 : unit = ()
    let _let'_v9059 =
        async {
            try
                (* run_target_args'
                let v9062 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9063 : string = "std::fs::remove_file(&*$0)"
                let v9064 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v9063 
                let v9065 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v9067 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9068 : string = "$0.map_err(|x| $1(x))"
                let v9069 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9064, v9065) v9068 
                let _run_target_args'_v9067 = v9069 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9070 : string = "$0.map_err(|x| $1(x))"
                let v9071 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9064, v9065) v9070 
                let _run_target_args'_v9067 = v9071 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9072 : string = "$0.map_err(|x| $1(x))"
                let v9073 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9064, v9065) v9072 
                let _run_target_args'_v9067 = v9073 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9074 : Result<unit, string> = match v9064 with Ok x -> Ok x | Error x -> Error (v9065 x)
                let _run_target_args'_v9067 = v9074 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9075 : Result<unit, string> = match v9064 with Ok x -> Ok x | Error x -> Error (v9065 x)
                let _run_target_args'_v9067 = v9075 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9076 : Result<unit, string> = match v9064 with Ok x -> Ok x | Error x -> Error (v9065 x)
                let _run_target_args'_v9067 = v9076 
                #endif
#else
                let v9077 : Result<unit, string> = match v9064 with Ok x -> Ok x | Error x -> Error (v9065 x)
                let _run_target_args'_v9067 = v9077 
                #endif
                let v9078 : Result<unit, string> = _run_target_args'_v9067 
                let v9081 : (unit -> US9) = method50()
                let v9082 : (string -> US9) = method51()
                let v9083 : US9 = match v9078 with Ok () -> v9081 () | Error x -> v9082 x
                match v9083 with
                | US9_1(v9084) -> (* Error *)
                    let v9085 : unit = ()
                    let v9086 : (unit -> unit) = closure26(v9084)
                    let v9087 : unit = (fun () -> v9086 (); v9085) ()
                    ()
                | US9_0 -> (* Ok *)
                    ()
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
                let v9134 : (string -> unit) = System.IO.File.Delete
                v9134 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v9208 : exn = ex
                let v9209 : int64 = v1 % 100L
                let v9210 : bool = v9209 = 0L
                if v9210 then
                    let v9211 : unit = ()
                    let v9212 : (unit -> unit) = closure27(v0, v9208)
                    let v9213 : unit = (fun () -> v9212 (); v9211) ()
                    ()
                (* run_target_args'
                let v9301 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9302 : (int32 -> Async<unit>) = Async.Sleep
                let v9303 : Async<unit> = v9302 10
                let _run_target_args'_v9301 = v9303 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9304 : (int32 -> Async<unit>) = Async.Sleep
                let v9305 : Async<unit> = v9304 10
                let _run_target_args'_v9301 = v9305 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9306 : (int32 -> Async<unit>) = Async.Sleep
                let v9307 : Async<unit> = v9306 10
                let _run_target_args'_v9301 = v9307 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9308 : (int32 -> Async<unit>) = Async.Sleep
                let v9309 : Async<unit> = v9308 10
                let _run_target_args'_v9301 = v9309 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9310 : (int32 -> Async<unit>) = Async.Sleep
                let v9311 : Async<unit> = v9310 10
                let _run_target_args'_v9301 = v9311 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9312 : (int32 -> Async<unit>) = Async.Sleep
                let v9313 : Async<unit> = v9312 10
                let _run_target_args'_v9301 = v9313 
                #endif
#else
                let v9314 : (int32 -> Async<unit>) = Async.Sleep
                let v9315 : Async<unit> = v9314 10
                let _run_target_args'_v9301 = v9315 
                #endif
                let v9316 : Async<unit> = _run_target_args'_v9301 
                do! v9316 
                let v9319 : int64 = v1 + 1L
                let v9320 : Async<int64> = method46(v0, v9319)
                return! v9320 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9435 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v12070 : Async<int64> = _let'_v9059 
    let _run_target_args'_v6 = v12070 
    #endif
    let v12071 : Async<int64> = _run_target_args'_v6 
    v12071
and method46 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v6 = v28 
    #endif
#else
    let v31 : Async<int64> = method47(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<int64> = _run_target_args'_v6 
    v32
and method45 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method46(v0, v1)
and closure22 () (v0 : string) : Async<int64> =
    method45(v0)
and method61 (v0 : string, v1 : string) : unit =
    (* run_target_args'
    let v2 : unit = ()
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
    System.IO.File.Move (v1, v0)
    #endif
    // run_target_args' is_unit
    ()
and method63 (v0 : string, v1 : string, v2 : string) : string =
    let v3 : string = method18()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "old_path"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure6(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure6(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure6(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure6(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "new_path"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure6(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v74 : string = $"{v1}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v83 : string = $"{v45}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v92 : string = "ex"
    let v93 : string = $"{v92}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure6(v4, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = $"{v26}"
    let v105 : unit = ()
    let v106 : (unit -> unit) = closure6(v4, v102)
    let v107 : unit = (fun () -> v106 (); v105) ()
    let v111 : string = $"{v2}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure6(v4, v111)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v120 : string = " }"
    let v121 : string = $"{v120}"
    let v124 : unit = ()
    let v125 : (unit -> unit) = closure6(v4, v121)
    let v126 : unit = (fun () -> v125 (); v124) ()
    let v129 : string = v4.l0
    v129
and method62 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string, v10 : string) : string =
    let v11 : string = method63(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v14 : string = "move_file_async"
    let v15 : string = $"{v6} {v7} #{v12} %s{v14} / {v11}"
    method23(v15)
and closure30 (v0 : string, v1 : string, v2 : exn) () : unit =
    let v3 : US0 = US0_3
    let v4 : bool = method11(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method55()
        let v48 : string = method20(v1)
        let v49 : string = method20(v0)
        (* run_target_args'
        let v54 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v56 : string = $"%A{v2}"
        let _run_target_args'_v54 = v56 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v60 : string = $"%A{v2}"
        let _run_target_args'_v54 = v60 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v64 : string = $"%A{v2}"
        let _run_target_args'_v54 = v64 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v68 : string = $"%A{v2}"
        let _run_target_args'_v54 = v68 
        #endif
#if FABLE_COMPILER_PYTHON
        let v72 : string = $"%A{v2}"
        let _run_target_args'_v54 = v72 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v76 : string = $"%A{v2}"
        let _run_target_args'_v54 = v76 
        #endif
#else
        let v79 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v54 = v79 
        #endif
        let v80 : string = _run_target_args'_v54 
        let v86 : string = method62(v28, v29, v30, v31, v32, v33, v46, v47, v48, v49, v80)
        method24(v86)
and method60 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : unit = ()
    let _let'_v21 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v24 : exn = ex
                let v25 : int64 = v2 % 100L
                let v26 : bool = v25 = 0L
                if v26 then
                    let v27 : unit = ()
                    let v28 : (unit -> unit) = closure30(v0, v1, v24)
                    let v29 : unit = (fun () -> v28 (); v27) ()
                    ()
                (* run_target_args'
                let v118 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v119 : (int32 -> Async<unit>) = Async.Sleep
                let v120 : Async<unit> = v119 10
                let _run_target_args'_v118 = v120 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v118 = v122 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v123 : (int32 -> Async<unit>) = Async.Sleep
                let v124 : Async<unit> = v123 10
                let _run_target_args'_v118 = v124 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v125 : (int32 -> Async<unit>) = Async.Sleep
                let v126 : Async<unit> = v125 10
                let _run_target_args'_v118 = v126 
                #endif
#if FABLE_COMPILER_PYTHON
                let v127 : (int32 -> Async<unit>) = Async.Sleep
                let v128 : Async<unit> = v127 10
                let _run_target_args'_v118 = v128 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v129 : (int32 -> Async<unit>) = Async.Sleep
                let v130 : Async<unit> = v129 10
                let _run_target_args'_v118 = v130 
                #endif
#else
                let v131 : (int32 -> Async<unit>) = Async.Sleep
                let v132 : Async<unit> = v131 10
                let _run_target_args'_v118 = v132 
                #endif
                let v133 : Async<unit> = _run_target_args'_v118 
                do! v133 
                let v136 : int64 = v2 + 1L
                let v137 : Async<int64> = method59(v0, v1, v136)
                return! v137 
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
    let v1848 : Async<int64> = _let'_v21 
    let _run_target_args'_v7 = v1848 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1850 : unit = ()
    let _let'_v1850 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v1853 : exn = ex
                let v1854 : int64 = v2 % 100L
                let v1855 : bool = v1854 = 0L
                if v1855 then
                    let v1856 : unit = ()
                    let v1857 : (unit -> unit) = closure30(v0, v1, v1853)
                    let v1858 : unit = (fun () -> v1857 (); v1856) ()
                    ()
                (* run_target_args'
                let v1947 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1948 : (int32 -> Async<unit>) = Async.Sleep
                let v1949 : Async<unit> = v1948 10
                let _run_target_args'_v1947 = v1949 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1950 : (int32 -> Async<unit>) = Async.Sleep
                let v1951 : Async<unit> = v1950 10
                let _run_target_args'_v1947 = v1951 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1952 : (int32 -> Async<unit>) = Async.Sleep
                let v1953 : Async<unit> = v1952 10
                let _run_target_args'_v1947 = v1953 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1954 : (int32 -> Async<unit>) = Async.Sleep
                let v1955 : Async<unit> = v1954 10
                let _run_target_args'_v1947 = v1955 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1956 : (int32 -> Async<unit>) = Async.Sleep
                let v1957 : Async<unit> = v1956 10
                let _run_target_args'_v1947 = v1957 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1958 : (int32 -> Async<unit>) = Async.Sleep
                let v1959 : Async<unit> = v1958 10
                let _run_target_args'_v1947 = v1959 
                #endif
#else
                let v1960 : (int32 -> Async<unit>) = Async.Sleep
                let v1961 : Async<unit> = v1960 10
                let _run_target_args'_v1947 = v1961 
                #endif
                let v1962 : Async<unit> = _run_target_args'_v1947 
                do! v1962 
                let v1965 : int64 = v2 + 1L
                let v1966 : Async<int64> = method59(v0, v1, v1965)
                return! v1966 
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
    let v3677 : Async<int64> = _let'_v1850 
    let _run_target_args'_v7 = v3677 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3679 : unit = ()
    let _let'_v3679 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v3682 : exn = ex
                let v3683 : int64 = v2 % 100L
                let v3684 : bool = v3683 = 0L
                if v3684 then
                    let v3685 : unit = ()
                    let v3686 : (unit -> unit) = closure30(v0, v1, v3682)
                    let v3687 : unit = (fun () -> v3686 (); v3685) ()
                    ()
                (* run_target_args'
                let v3776 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3777 : (int32 -> Async<unit>) = Async.Sleep
                let v3778 : Async<unit> = v3777 10
                let _run_target_args'_v3776 = v3778 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3779 : (int32 -> Async<unit>) = Async.Sleep
                let v3780 : Async<unit> = v3779 10
                let _run_target_args'_v3776 = v3780 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3781 : (int32 -> Async<unit>) = Async.Sleep
                let v3782 : Async<unit> = v3781 10
                let _run_target_args'_v3776 = v3782 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3783 : (int32 -> Async<unit>) = Async.Sleep
                let v3784 : Async<unit> = v3783 10
                let _run_target_args'_v3776 = v3784 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3785 : (int32 -> Async<unit>) = Async.Sleep
                let v3786 : Async<unit> = v3785 10
                let _run_target_args'_v3776 = v3786 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3787 : (int32 -> Async<unit>) = Async.Sleep
                let v3788 : Async<unit> = v3787 10
                let _run_target_args'_v3776 = v3788 
                #endif
#else
                let v3789 : (int32 -> Async<unit>) = Async.Sleep
                let v3790 : Async<unit> = v3789 10
                let _run_target_args'_v3776 = v3790 
                #endif
                let v3791 : Async<unit> = _run_target_args'_v3776 
                do! v3791 
                let v3794 : int64 = v2 + 1L
                let v3795 : Async<int64> = method59(v0, v1, v3794)
                return! v3795 
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
    let v5506 : Async<int64> = _let'_v3679 
    let _run_target_args'_v7 = v5506 
    #endif
#else
    let v5508 : unit = ()
    let _let'_v5508 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v5511 : exn = ex
                let v5512 : int64 = v2 % 100L
                let v5513 : bool = v5512 = 0L
                if v5513 then
                    let v5514 : unit = ()
                    let v5515 : (unit -> unit) = closure30(v0, v1, v5511)
                    let v5516 : unit = (fun () -> v5515 (); v5514) ()
                    ()
                (* run_target_args'
                let v5605 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5606 : (int32 -> Async<unit>) = Async.Sleep
                let v5607 : Async<unit> = v5606 10
                let _run_target_args'_v5605 = v5607 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5608 : (int32 -> Async<unit>) = Async.Sleep
                let v5609 : Async<unit> = v5608 10
                let _run_target_args'_v5605 = v5609 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5610 : (int32 -> Async<unit>) = Async.Sleep
                let v5611 : Async<unit> = v5610 10
                let _run_target_args'_v5605 = v5611 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5612 : (int32 -> Async<unit>) = Async.Sleep
                let v5613 : Async<unit> = v5612 10
                let _run_target_args'_v5605 = v5613 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5614 : (int32 -> Async<unit>) = Async.Sleep
                let v5615 : Async<unit> = v5614 10
                let _run_target_args'_v5605 = v5615 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5616 : (int32 -> Async<unit>) = Async.Sleep
                let v5617 : Async<unit> = v5616 10
                let _run_target_args'_v5605 = v5617 
                #endif
#else
                let v5618 : (int32 -> Async<unit>) = Async.Sleep
                let v5619 : Async<unit> = v5618 10
                let _run_target_args'_v5605 = v5619 
                #endif
                let v5620 : Async<unit> = _run_target_args'_v5605 
                do! v5620 
                let v5623 : int64 = v2 + 1L
                let v5624 : Async<int64> = method59(v0, v1, v5623)
                return! v5624 
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
    let v7335 : Async<int64> = _let'_v5508 
    let _run_target_args'_v7 = v7335 
    #endif
    let v7336 : Async<int64> = _run_target_args'_v7 
    v7336
and method59 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v21 
    #endif
#if FABLE_COMPILER_PYTHON
    let v25 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v25 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v29 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v7 = v29 
    #endif
#else
    let v32 : Async<int64> = method60(v0, v1, v2)
    let _run_target_args'_v7 = v32 
    #endif
    let v33 : Async<int64> = _run_target_args'_v7 
    v33
and method58 (v0 : string, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method59(v0, v1, v2)
and closure29 (v0 : string) (v1 : string) : Async<int64> =
    method58(v0, v1)
and closure28 () (v0 : string) : (string -> Async<int64>) =
    closure29(v0)
and closure32 () (v0 : int64) : US10 =
    US10_0(v0)
and method70 () : (int64 -> US10) =
    closure32()
and closure33 () (v0 : exn) : US10 =
    US10_1(v0)
and method71 () : (exn -> US10) =
    closure33()
and method69 (v0 : Async<Choice<int64, exn>>) : Async<US10> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US10> = null |> unbox<Async<US10>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<US10> = null |> unbox<Async<US10>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<US10> = null |> unbox<Async<US10>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v22 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v27 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v29 : US10 = null |> unbox<US10>
            let _run_target_args'_v27 = v29 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v33 : US10 = null |> unbox<US10>
            let _run_target_args'_v27 = v33 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : US10 = null |> unbox<US10>
            let _run_target_args'_v27 = v37 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v41 : US10 = null |> unbox<US10>
            let _run_target_args'_v27 = v41 
            #endif
#if FABLE_COMPILER_PYTHON
            let v45 : US10 = null |> unbox<US10>
            let _run_target_args'_v27 = v45 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v48 : (int64 -> US10) = method70()
            let v49 : (exn -> US10) = method71()
            let v50 : US10 = match v22 with Choice1Of2 x -> v48 x | Choice2Of2 x -> v49 x
            let _run_target_args'_v27 = v50 
            #endif
#else
            let v51 : (int64 -> US10) = method70()
            let v52 : (exn -> US10) = method71()
            let v53 : US10 = match v22 with Choice1Of2 x -> v51 x | Choice2Of2 x -> v52 x
            let _run_target_args'_v27 = v53 
            #endif
            let v54 : US10 = _run_target_args'_v27 
            return v54 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v326 : Async<US10> = _let'_v19 
    let _run_target_args'_v5 = v326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v328 : unit = ()
    let _let'_v328 =
        async {
            let! v0 = v0 
            let v331 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v336 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v338 : US10 = null |> unbox<US10>
            let _run_target_args'_v336 = v338 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v342 : US10 = null |> unbox<US10>
            let _run_target_args'_v336 = v342 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v346 : US10 = null |> unbox<US10>
            let _run_target_args'_v336 = v346 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v350 : US10 = null |> unbox<US10>
            let _run_target_args'_v336 = v350 
            #endif
#if FABLE_COMPILER_PYTHON
            let v354 : US10 = null |> unbox<US10>
            let _run_target_args'_v336 = v354 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v357 : (int64 -> US10) = method70()
            let v358 : (exn -> US10) = method71()
            let v359 : US10 = match v331 with Choice1Of2 x -> v357 x | Choice2Of2 x -> v358 x
            let _run_target_args'_v336 = v359 
            #endif
#else
            let v360 : (int64 -> US10) = method70()
            let v361 : (exn -> US10) = method71()
            let v362 : US10 = match v331 with Choice1Of2 x -> v360 x | Choice2Of2 x -> v361 x
            let _run_target_args'_v336 = v362 
            #endif
            let v363 : US10 = _run_target_args'_v336 
            return v363 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v635 : Async<US10> = _let'_v328 
    let _run_target_args'_v5 = v635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v637 : unit = ()
    let _let'_v637 =
        async {
            let! v0 = v0 
            let v640 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v645 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v647 : US10 = null |> unbox<US10>
            let _run_target_args'_v645 = v647 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v651 : US10 = null |> unbox<US10>
            let _run_target_args'_v645 = v651 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v655 : US10 = null |> unbox<US10>
            let _run_target_args'_v645 = v655 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v659 : US10 = null |> unbox<US10>
            let _run_target_args'_v645 = v659 
            #endif
#if FABLE_COMPILER_PYTHON
            let v663 : US10 = null |> unbox<US10>
            let _run_target_args'_v645 = v663 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v666 : (int64 -> US10) = method70()
            let v667 : (exn -> US10) = method71()
            let v668 : US10 = match v640 with Choice1Of2 x -> v666 x | Choice2Of2 x -> v667 x
            let _run_target_args'_v645 = v668 
            #endif
#else
            let v669 : (int64 -> US10) = method70()
            let v670 : (exn -> US10) = method71()
            let v671 : US10 = match v640 with Choice1Of2 x -> v669 x | Choice2Of2 x -> v670 x
            let _run_target_args'_v645 = v671 
            #endif
            let v672 : US10 = _run_target_args'_v645 
            return v672 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v944 : Async<US10> = _let'_v637 
    let _run_target_args'_v5 = v944 
    #endif
#else
    let v946 : unit = ()
    let _let'_v946 =
        async {
            let! v0 = v0 
            let v949 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v954 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v956 : US10 = null |> unbox<US10>
            let _run_target_args'_v954 = v956 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v960 : US10 = null |> unbox<US10>
            let _run_target_args'_v954 = v960 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v964 : US10 = null |> unbox<US10>
            let _run_target_args'_v954 = v964 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v968 : US10 = null |> unbox<US10>
            let _run_target_args'_v954 = v968 
            #endif
#if FABLE_COMPILER_PYTHON
            let v972 : US10 = null |> unbox<US10>
            let _run_target_args'_v954 = v972 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v975 : (int64 -> US10) = method70()
            let v976 : (exn -> US10) = method71()
            let v977 : US10 = match v949 with Choice1Of2 x -> v975 x | Choice2Of2 x -> v976 x
            let _run_target_args'_v954 = v977 
            #endif
#else
            let v978 : (int64 -> US10) = method70()
            let v979 : (exn -> US10) = method71()
            let v980 : US10 = match v949 with Choice1Of2 x -> v978 x | Choice2Of2 x -> v979 x
            let _run_target_args'_v954 = v980 
            #endif
            let v981 : US10 = _run_target_args'_v954 
            return v981 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1253 : Async<US10> = _let'_v946 
    let _run_target_args'_v5 = v1253 
    #endif
    let v1254 : Async<US10> = _run_target_args'_v5 
    v1254
and method72 (v0 : Async<US10>) : Async<US11> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v22 : US10 = v0 
            let v28 : US11 =
                match v22 with
                | US10_0(v23) -> (* C1of2 *)
                    US11_0(v23)
                | US10_1(v25) -> (* C2of2 *)
                    US11_1(v25)
            return v28 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v78 : Async<US11> = _let'_v19 
    let _run_target_args'_v5 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v80 : unit = ()
    let _let'_v80 =
        async {
            let! v0 = v0 
            let v83 : US10 = v0 
            let v89 : US11 =
                match v83 with
                | US10_0(v84) -> (* C1of2 *)
                    US11_0(v84)
                | US10_1(v86) -> (* C2of2 *)
                    US11_1(v86)
            return v89 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v139 : Async<US11> = _let'_v80 
    let _run_target_args'_v5 = v139 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v141 : unit = ()
    let _let'_v141 =
        async {
            let! v0 = v0 
            let v144 : US10 = v0 
            let v150 : US11 =
                match v144 with
                | US10_0(v145) -> (* C1of2 *)
                    US11_0(v145)
                | US10_1(v147) -> (* C2of2 *)
                    US11_1(v147)
            return v150 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v200 : Async<US11> = _let'_v141 
    let _run_target_args'_v5 = v200 
    #endif
#else
    let v202 : unit = ()
    let _let'_v202 =
        async {
            let! v0 = v0 
            let v205 : US10 = v0 
            let v211 : US11 =
                match v205 with
                | US10_0(v206) -> (* C1of2 *)
                    US11_0(v206)
                | US10_1(v208) -> (* C2of2 *)
                    US11_1(v208)
            return v211 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v261 : Async<US11> = _let'_v202 
    let _run_target_args'_v5 = v261 
    #endif
    let v262 : Async<US11> = _run_target_args'_v5 
    v262
and method75 (v0 : int32) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "timeout"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure6(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure6(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"{v0}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure6(v2, v34)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v43 : string = " }"
    let v44 : string = $"{v43}"
    let v47 : unit = ()
    let v48 : (unit -> unit) = closure6(v2, v44)
    let v49 : unit = (fun () -> v48 (); v47) ()
    let v52 : string = v2.l0
    v52
and method74 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method75(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "async.run_with_timeout_async"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method23(v13)
and closure34 (v0 : int32) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method11(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method12(v26, v27, v28, v29, v30, v31)
        let v45 : string = method34()
        let v46 : string = method74(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method24(v46)
and method77 (v0 : int32, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "timeout"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "ex"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure6(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method76 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method77(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "async.run_with_timeout_async**"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure35 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method52()
        (* run_target_args'
        let v51 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v51 = v53 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v57 : string = $"%A{v1}"
        let _run_target_args'_v51 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v61 : string = $"%A{v1}"
        let _run_target_args'_v51 = v61 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v65 : string = $"%A{v1}"
        let _run_target_args'_v51 = v65 
        #endif
#if FABLE_COMPILER_PYTHON
        let v69 : string = $"%A{v1}"
        let _run_target_args'_v51 = v69 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v73 : string = $"%A{v1}"
        let _run_target_args'_v51 = v73 
        #endif
#else
        let v76 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v51 = v76 
        #endif
        let v77 : string = _run_target_args'_v51 
        let v83 : string = method76(v27, v28, v29, v30, v31, v32, v45, v46, v0, v77)
        method24(v83)
and method73 (v0 : int32, v1 : Async<US11>) : Async<US2> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v23 : US11 = v1 
            let v174 : US2 =
                match v23 with
                | US11_1(v26) -> (* Error *)
                    let v28 : string = $"%A{v26}"
                    let v32 : string = "System.TimeoutException"
                    let v33 : bool = v28.Contains v32 
                    if v33 then
                        let v36 : unit = ()
                        let v37 : (unit -> unit) = closure34(v0)
                        let v38 : unit = (fun () -> v37 (); v36) ()
                        US2_1
                    else
                        let v86 : unit = ()
                        let v87 : (unit -> unit) = closure35(v0, v26)
                        let v88 : unit = (fun () -> v87 (); v86) ()
                        US2_1
                | US11_0(v24) -> (* Ok *)
                    US2_0(v24)
            return v174 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1239 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v1239 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1241 : unit = ()
    let _let'_v1241 =
        async {
            let! v1 = v1 
            let v1244 : US11 = v1 
            let v1395 : US2 =
                match v1244 with
                | US11_1(v1247) -> (* Error *)
                    let v1249 : string = $"%A{v1247}"
                    let v1253 : string = "System.TimeoutException"
                    let v1254 : bool = v1249.Contains v1253 
                    if v1254 then
                        let v1257 : unit = ()
                        let v1258 : (unit -> unit) = closure34(v0)
                        let v1259 : unit = (fun () -> v1258 (); v1257) ()
                        US2_1
                    else
                        let v1307 : unit = ()
                        let v1308 : (unit -> unit) = closure35(v0, v1247)
                        let v1309 : unit = (fun () -> v1308 (); v1307) ()
                        US2_1
                | US11_0(v1245) -> (* Ok *)
                    US2_0(v1245)
            return v1395 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2460 : Async<US2> = _let'_v1241 
    let _run_target_args'_v6 = v2460 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2462 : unit = ()
    let _let'_v2462 =
        async {
            let! v1 = v1 
            let v2465 : US11 = v1 
            let v2616 : US2 =
                match v2465 with
                | US11_1(v2468) -> (* Error *)
                    let v2470 : string = $"%A{v2468}"
                    let v2474 : string = "System.TimeoutException"
                    let v2475 : bool = v2470.Contains v2474 
                    if v2475 then
                        let v2478 : unit = ()
                        let v2479 : (unit -> unit) = closure34(v0)
                        let v2480 : unit = (fun () -> v2479 (); v2478) ()
                        US2_1
                    else
                        let v2528 : unit = ()
                        let v2529 : (unit -> unit) = closure35(v0, v2468)
                        let v2530 : unit = (fun () -> v2529 (); v2528) ()
                        US2_1
                | US11_0(v2466) -> (* Ok *)
                    US2_0(v2466)
            return v2616 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3681 : Async<US2> = _let'_v2462 
    let _run_target_args'_v6 = v3681 
    #endif
#else
    let v3683 : unit = ()
    let _let'_v3683 =
        async {
            let! v1 = v1 
            let v3686 : US11 = v1 
            let v3837 : US2 =
                match v3686 with
                | US11_1(v3689) -> (* Error *)
                    let v3691 : string = $"%A{v3689}"
                    let v3695 : string = "System.TimeoutException"
                    let v3696 : bool = v3691.Contains v3695 
                    if v3696 then
                        let v3699 : unit = ()
                        let v3700 : (unit -> unit) = closure34(v0)
                        let v3701 : unit = (fun () -> v3700 (); v3699) ()
                        US2_1
                    else
                        let v3749 : unit = ()
                        let v3750 : (unit -> unit) = closure35(v0, v3689)
                        let v3751 : unit = (fun () -> v3750 (); v3749) ()
                        US2_1
                | US11_0(v3687) -> (* Ok *)
                    US2_0(v3687)
            return v3837 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4902 : Async<US2> = _let'_v3683 
    let _run_target_args'_v6 = v4902 
    #endif
    let v4903 : Async<US2> = _run_target_args'_v6 
    v4903
and method68 (v0 : Async<int64>, v1 : int32) : Async<US2> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            (* run_target_args'
            let v27 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v29 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v27 = v29 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v33 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v27 = v33 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v37 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v27 = v37 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v40 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v40 
            #endif
#if FABLE_COMPILER_PYTHON
            let v41 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v41 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v42 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v42 
            #endif
#else
            let v43 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v27 = v43 
            #endif
            let v44 : Async<Async<int64>> = _run_target_args'_v27 
            let! v44 = v44 
            let v50 : Async<int64> = v44 
            (* run_target_args'
            let v55 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v57 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v55 = v57 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v55 = v61 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v65 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v55 = v65 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v68 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v69 : Async<Choice<int64, exn>> = v68 v50
            let _run_target_args'_v55 = v69 
            #endif
#if FABLE_COMPILER_PYTHON
            let v70 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v71 : Async<Choice<int64, exn>> = v70 v50
            let _run_target_args'_v55 = v71 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v72 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v73 : Async<Choice<int64, exn>> = v72 v50
            let _run_target_args'_v55 = v73 
            #endif
#else
            let v74 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v75 : Async<Choice<int64, exn>> = v74 v50
            let _run_target_args'_v55 = v75 
            #endif
            let v76 : Async<Choice<int64, exn>> = _run_target_args'_v55 
            let v82 : Async<US10> = method69(v76)
            let v83 : Async<US11> = method72(v82)
            let v84 : Async<US2> = method73(v1, v83)
            return! v84 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v519 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v519 
    #endif
#if FABLE_COMPILER_PYTHON
    let v521 : unit = ()
    let _let'_v521 =
        async {
            (* run_target_args'
            let v528 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v530 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v528 = v530 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v534 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v528 = v534 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v538 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v528 = v538 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v541 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v541 
            #endif
#if FABLE_COMPILER_PYTHON
            let v542 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v542 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v543 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v543 
            #endif
#else
            let v544 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v528 = v544 
            #endif
            let v545 : Async<Async<int64>> = _run_target_args'_v528 
            let! v545 = v545 
            let v551 : Async<int64> = v545 
            (* run_target_args'
            let v556 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v558 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v556 = v558 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v562 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v556 = v562 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v566 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v556 = v566 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v569 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v570 : Async<Choice<int64, exn>> = v569 v551
            let _run_target_args'_v556 = v570 
            #endif
#if FABLE_COMPILER_PYTHON
            let v571 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v572 : Async<Choice<int64, exn>> = v571 v551
            let _run_target_args'_v556 = v572 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v573 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v574 : Async<Choice<int64, exn>> = v573 v551
            let _run_target_args'_v556 = v574 
            #endif
#else
            let v575 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v576 : Async<Choice<int64, exn>> = v575 v551
            let _run_target_args'_v556 = v576 
            #endif
            let v577 : Async<Choice<int64, exn>> = _run_target_args'_v556 
            let v583 : Async<US10> = method69(v577)
            let v584 : Async<US11> = method72(v583)
            let v585 : Async<US2> = method73(v1, v584)
            return! v585 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1020 : Async<US2> = _let'_v521 
    let _run_target_args'_v6 = v1020 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1022 : unit = ()
    let _let'_v1022 =
        async {
            (* run_target_args'
            let v1029 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1031 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1029 = v1031 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1035 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1029 = v1035 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1039 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1029 = v1039 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1042 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1042 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1043 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1043 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1044 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1044 
            #endif
#else
            let v1045 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1029 = v1045 
            #endif
            let v1046 : Async<Async<int64>> = _run_target_args'_v1029 
            let! v1046 = v1046 
            let v1052 : Async<int64> = v1046 
            (* run_target_args'
            let v1057 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1059 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1057 = v1059 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1063 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1057 = v1063 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1067 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1057 = v1067 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1070 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1071 : Async<Choice<int64, exn>> = v1070 v1052
            let _run_target_args'_v1057 = v1071 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1072 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1073 : Async<Choice<int64, exn>> = v1072 v1052
            let _run_target_args'_v1057 = v1073 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1074 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1075 : Async<Choice<int64, exn>> = v1074 v1052
            let _run_target_args'_v1057 = v1075 
            #endif
#else
            let v1076 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1077 : Async<Choice<int64, exn>> = v1076 v1052
            let _run_target_args'_v1057 = v1077 
            #endif
            let v1078 : Async<Choice<int64, exn>> = _run_target_args'_v1057 
            let v1084 : Async<US10> = method69(v1078)
            let v1085 : Async<US11> = method72(v1084)
            let v1086 : Async<US2> = method73(v1, v1085)
            return! v1086 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1521 : Async<US2> = _let'_v1022 
    let _run_target_args'_v6 = v1521 
    #endif
#else
    let v1523 : unit = ()
    let _let'_v1523 =
        async {
            (* run_target_args'
            let v1530 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1532 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1530 = v1532 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1536 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1530 = v1536 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1540 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1530 = v1540 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1543 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1543 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1544 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1544 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1545 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1545 
            #endif
#else
            let v1546 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1530 = v1546 
            #endif
            let v1547 : Async<Async<int64>> = _run_target_args'_v1530 
            let! v1547 = v1547 
            let v1553 : Async<int64> = v1547 
            (* run_target_args'
            let v1558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1560 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1558 = v1560 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1564 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1558 = v1564 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1568 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1558 = v1568 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1571 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1572 : Async<Choice<int64, exn>> = v1571 v1553
            let _run_target_args'_v1558 = v1572 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1573 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1574 : Async<Choice<int64, exn>> = v1573 v1553
            let _run_target_args'_v1558 = v1574 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1575 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1576 : Async<Choice<int64, exn>> = v1575 v1553
            let _run_target_args'_v1558 = v1576 
            #endif
#else
            let v1577 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1578 : Async<Choice<int64, exn>> = v1577 v1553
            let _run_target_args'_v1558 = v1578 
            #endif
            let v1579 : Async<Choice<int64, exn>> = _run_target_args'_v1558 
            let v1585 : Async<US10> = method69(v1579)
            let v1586 : Async<US11> = method72(v1585)
            let v1587 : Async<US2> = method73(v1, v1586)
            return! v1587 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2022 : Async<US2> = _let'_v1523 
    let _run_target_args'_v6 = v2022 
    #endif
    let v2023 : Async<US2> = _run_target_args'_v6 
    v2023
and method67 (v0 : int32, v1 : Async<int64>) : Async<US2> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US2> = method68(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US2> = _run_target_args'_v6 
    v14
and method78 (v0 : Async<string>) : Async<string option> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v22 : string = v0 
            let v24 : string option = Some v22 
            return v24 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v62 : Async<string option> = _let'_v19 
    let _run_target_args'_v5 = v62 
    #endif
#if FABLE_COMPILER_PYTHON
    let v64 : unit = ()
    let _let'_v64 =
        async {
            let! v0 = v0 
            let v67 : string = v0 
            let v69 : string option = Some v67 
            return v69 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v107 : Async<string option> = _let'_v64 
    let _run_target_args'_v5 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v109 : unit = ()
    let _let'_v109 =
        async {
            let! v0 = v0 
            let v112 : string = v0 
            let v114 : string option = Some v112 
            return v114 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v152 : Async<string option> = _let'_v109 
    let _run_target_args'_v5 = v152 
    #endif
#else
    let v154 : unit = ()
    let _let'_v154 =
        async {
            let! v0 = v0 
            let v157 : string = v0 
            let v159 : string option = Some v157 
            return v159 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v197 : Async<string option> = _let'_v154 
    let _run_target_args'_v5 = v197 
    #endif
    let v198 : Async<string option> = _run_target_args'_v5 
    v198
and method80 (v0 : int64, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "retry"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "ex"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure6(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method79 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string) : string =
    let v10 : string = method80(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "file_system.read_all_text_retry_async"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure36 (v0 : int64, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method16()
        (* run_target_args'
        let v51 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v51 = v53 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v57 : string = $"%A{v1}"
        let _run_target_args'_v51 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v61 : string = $"%A{v1}"
        let _run_target_args'_v51 = v61 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v65 : string = $"%A{v1}"
        let _run_target_args'_v51 = v65 
        #endif
#if FABLE_COMPILER_PYTHON
        let v69 : string = $"%A{v1}"
        let _run_target_args'_v51 = v69 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v73 : string = $"%A{v1}"
        let _run_target_args'_v51 = v73 
        #endif
#else
        let v76 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v51 = v76 
        #endif
        let v77 : string = _run_target_args'_v51 
        let v83 : string = method79(v27, v28, v29, v30, v31, v32, v45, v46, v0, v77)
        method24(v83)
and method66 (v0 : string, v1 : int64) : Async<string option> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            try
                let v23 : bool = v1 > 0L
                if v23 then
                    let v24 : Async<int64> = method30(v0)
                    let v25 : int32 = 1000
                    let v26 : Async<US2> = method67(v25, v24)
                    (* run_target_args'
                    let v31 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v33 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v31 = v33 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v37 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v31 = v37 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v41 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v31 = v41 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v44 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v45 : Async<unit> = v44 v26
                    let _run_target_args'_v31 = v45 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v46 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v47 : Async<unit> = v46 v26
                    let _run_target_args'_v31 = v47 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v48 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v49 : Async<unit> = v48 v26
                    let _run_target_args'_v31 = v49 
                    #endif
#else
                    let v50 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v51 : Async<unit> = v50 v26
                    let _run_target_args'_v31 = v51 
                    #endif
                    let v52 : Async<unit> = _run_target_args'_v31 
                    do! v52 
                    ()
                let v58 : Async<string> = method31(v0)
                let v59 : Async<string option> = method78(v58)
                return! v59 
                (* indent
                ()
            indent *)
            with ex ->
                let v97 : exn = ex
                let v98 : bool = v1 = 0L
                let v99 : bool = v98 <> true
                if v99 then
                    let v100 : unit = ()
                    let v101 : (unit -> unit) = closure36(v1, v97)
                    let v102 : unit = (fun () -> v101 (); v100) ()
                    let v185 : string option = None
                    return v185 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v186 : int64 = v1 + 1L
                    let v187 : Async<string option> = method65(v0, v186)
                    return! v187 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v280 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2103 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v2103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2105 : unit = ()
    let _let'_v2105 =
        async {
            try
                let v2108 : bool = v1 > 0L
                if v2108 then
                    let v2109 : Async<int64> = method30(v0)
                    let v2110 : int32 = 1000
                    let v2111 : Async<US2> = method67(v2110, v2109)
                    (* run_target_args'
                    let v2116 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v2118 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v2116 = v2118 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v2122 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v2116 = v2122 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v2126 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v2116 = v2126 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v2129 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2130 : Async<unit> = v2129 v2111
                    let _run_target_args'_v2116 = v2130 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v2131 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2132 : Async<unit> = v2131 v2111
                    let _run_target_args'_v2116 = v2132 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v2133 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2134 : Async<unit> = v2133 v2111
                    let _run_target_args'_v2116 = v2134 
                    #endif
#else
                    let v2135 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2136 : Async<unit> = v2135 v2111
                    let _run_target_args'_v2116 = v2136 
                    #endif
                    let v2137 : Async<unit> = _run_target_args'_v2116 
                    do! v2137 
                    ()
                let v2143 : Async<string> = method31(v0)
                let v2144 : Async<string option> = method78(v2143)
                return! v2144 
                (* indent
                ()
            indent *)
            with ex ->
                let v2182 : exn = ex
                let v2183 : bool = v1 = 0L
                let v2184 : bool = v2183 <> true
                if v2184 then
                    let v2185 : unit = ()
                    let v2186 : (unit -> unit) = closure36(v1, v2182)
                    let v2187 : unit = (fun () -> v2186 (); v2185) ()
                    let v2270 : string option = None
                    return v2270 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v2271 : int64 = v1 + 1L
                    let v2272 : Async<string option> = method65(v0, v2271)
                    return! v2272 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v2365 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4188 : Async<string option> = _let'_v2105 
    let _run_target_args'_v6 = v4188 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4190 : unit = ()
    let _let'_v4190 =
        async {
            try
                let v4193 : bool = v1 > 0L
                if v4193 then
                    let v4194 : Async<int64> = method30(v0)
                    let v4195 : int32 = 1000
                    let v4196 : Async<US2> = method67(v4195, v4194)
                    (* run_target_args'
                    let v4201 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v4203 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4201 = v4203 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v4207 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4201 = v4207 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v4211 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4201 = v4211 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v4214 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4215 : Async<unit> = v4214 v4196
                    let _run_target_args'_v4201 = v4215 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v4216 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4217 : Async<unit> = v4216 v4196
                    let _run_target_args'_v4201 = v4217 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v4218 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4219 : Async<unit> = v4218 v4196
                    let _run_target_args'_v4201 = v4219 
                    #endif
#else
                    let v4220 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4221 : Async<unit> = v4220 v4196
                    let _run_target_args'_v4201 = v4221 
                    #endif
                    let v4222 : Async<unit> = _run_target_args'_v4201 
                    do! v4222 
                    ()
                let v4228 : Async<string> = method31(v0)
                let v4229 : Async<string option> = method78(v4228)
                return! v4229 
                (* indent
                ()
            indent *)
            with ex ->
                let v4267 : exn = ex
                let v4268 : bool = v1 = 0L
                let v4269 : bool = v4268 <> true
                if v4269 then
                    let v4270 : unit = ()
                    let v4271 : (unit -> unit) = closure36(v1, v4267)
                    let v4272 : unit = (fun () -> v4271 (); v4270) ()
                    let v4355 : string option = None
                    return v4355 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v4356 : int64 = v1 + 1L
                    let v4357 : Async<string option> = method65(v0, v4356)
                    return! v4357 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v4450 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6273 : Async<string option> = _let'_v4190 
    let _run_target_args'_v6 = v6273 
    #endif
#else
    let v6275 : unit = ()
    let _let'_v6275 =
        async {
            try
                let v6278 : bool = v1 > 0L
                if v6278 then
                    let v6279 : Async<int64> = method30(v0)
                    let v6280 : int32 = 1000
                    let v6281 : Async<US2> = method67(v6280, v6279)
                    (* run_target_args'
                    let v6286 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v6288 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v6286 = v6288 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v6292 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v6286 = v6292 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v6296 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v6286 = v6296 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v6299 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6300 : Async<unit> = v6299 v6281
                    let _run_target_args'_v6286 = v6300 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v6301 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6302 : Async<unit> = v6301 v6281
                    let _run_target_args'_v6286 = v6302 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v6303 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6304 : Async<unit> = v6303 v6281
                    let _run_target_args'_v6286 = v6304 
                    #endif
#else
                    let v6305 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6306 : Async<unit> = v6305 v6281
                    let _run_target_args'_v6286 = v6306 
                    #endif
                    let v6307 : Async<unit> = _run_target_args'_v6286 
                    do! v6307 
                    ()
                let v6313 : Async<string> = method31(v0)
                let v6314 : Async<string option> = method78(v6313)
                return! v6314 
                (* indent
                ()
            indent *)
            with ex ->
                let v6352 : exn = ex
                let v6353 : bool = v1 = 0L
                let v6354 : bool = v6353 <> true
                if v6354 then
                    let v6355 : unit = ()
                    let v6356 : (unit -> unit) = closure36(v1, v6352)
                    let v6357 : unit = (fun () -> v6356 (); v6355) ()
                    let v6440 : string option = None
                    return v6440 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v6441 : int64 = v1 + 1L
                    let v6442 : Async<string option> = method65(v0, v6441)
                    return! v6442 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v6535 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v8358 : Async<string option> = _let'_v6275 
    let _run_target_args'_v6 = v8358 
    #endif
    let v8359 : Async<string option> = _run_target_args'_v6 
    v8359
and method65 (v0 : string, v1 : int64) : Async<string option> =
    method66(v0, v1)
and method64 (v0 : string) : Async<string option> =
    let v1 : int64 = 0L
    method65(v0, v1)
and closure31 () (v0 : string) : Async<string option> =
    method64(v0)
and closure38 () (v0 : chrono_DateTime<chrono_Utc>) : US12 =
    US12_0(v0)
and method83 () : (chrono_DateTime<chrono_Utc> -> US12) =
    closure38()
and method84 () : string =
    let v0 : string = "hh:mm"
    v0
and method85 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method86 () : string =
    let v0 : string = "hhmm"
    v0
and method82 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
    (* run_target_args'
    let v569 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v571 : System.DateTime = System.DateTime.UnixEpoch
    let v575 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v576 : System.DateTime = v575 v571
    let v580 : System.DateTimeKind = System.DateTimeKind.Local
    let v581 : System.DateTime = System.DateTime.SpecifyKind (v1, v580)
    let v585 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v586 : System.DateTime = v585 v581
    (* run_target_args'
    let v592 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v593 : (System.DateTime -> int64) = _.Ticks
    let v594 : int64 = v593 v586
    let _run_target_args'_v592 = v594 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v595 : (System.DateTime -> int64) = _.Ticks
    let v596 : int64 = v595 v586
    let _run_target_args'_v592 = v596 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v598 : int64 = null |> unbox<int64>
    let _run_target_args'_v592 = v598 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v601 : (System.DateTime -> int64) = _.Ticks
    let v602 : int64 = v601 v586
    let _run_target_args'_v592 = v602 
    #endif
#if FABLE_COMPILER_PYTHON
    let v603 : (System.DateTime -> int64) = _.Ticks
    let v604 : int64 = v603 v586
    let _run_target_args'_v592 = v604 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v605 : (System.DateTime -> int64) = _.Ticks
    let v606 : int64 = v605 v586
    let _run_target_args'_v592 = v606 
    #endif
#else
    let v607 : (System.DateTime -> int64) = _.Ticks
    let v608 : int64 = v607 v586
    let _run_target_args'_v592 = v608 
    #endif
    let v609 : int64 = _run_target_args'_v592 
    (* run_target_args'
    let v632 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v633 : (System.DateTime -> int64) = _.Ticks
    let v634 : int64 = v633 v576
    let _run_target_args'_v632 = v634 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v635 : (System.DateTime -> int64) = _.Ticks
    let v636 : int64 = v635 v576
    let _run_target_args'_v632 = v636 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v638 : int64 = null |> unbox<int64>
    let _run_target_args'_v632 = v638 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v641 : (System.DateTime -> int64) = _.Ticks
    let v642 : int64 = v641 v576
    let _run_target_args'_v632 = v642 
    #endif
#if FABLE_COMPILER_PYTHON
    let v643 : (System.DateTime -> int64) = _.Ticks
    let v644 : int64 = v643 v576
    let _run_target_args'_v632 = v644 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v645 : (System.DateTime -> int64) = _.Ticks
    let v646 : int64 = v645 v576
    let _run_target_args'_v632 = v646 
    #endif
#else
    let v647 : (System.DateTime -> int64) = _.Ticks
    let v648 : int64 = v647 v576
    let _run_target_args'_v632 = v648 
    #endif
    let v649 : int64 = _run_target_args'_v632 
    let v670 : int64 = v609 |> int64 
    let v674 : int64 = v649 |> int64 
    let v677 : int64 = v670 - v674
    let v678 : int64 = v677 / 10L
    let v679 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v680 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v678 v679 
    let v682 : (chrono_DateTime<chrono_Utc> -> US12) = method83()
    let v683 : US12 option = v680 |> Option.map v682 
    let v696 : US12 = US12_1
    let v697 : US12 = v683 |> Option.defaultValue v696 
    let v717 : US5 =
        match v697 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v701) -> (* Some *)
            let v702 : string = "$0.naive_utc()"
            let v703 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v701 v702 
            let v704 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v705 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v703 v704 
            let v706 : string = "%Y%m%d-%H%M-%S%f"
            let v707 : string = "r#\"" + v706 + "\"#"
            let v708 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v707 
            let v709 : string = "$0.format($1).to_string()"
            let v710 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v705, v708) v709 
            let v711 : string = "fable_library_rust::String_::fromString($0)"
            let v712 : string = Fable.Core.RustInterop.emitRustExpr v710 v711 
            let v713 : string = $"{v712.[0..17]}-{v712.[18..21]}-{v712.[22]}"
            US5_0(v713)
    let v721 : string =
        match v717 with
        | US5_1 -> (* None *)
            let v719 : string = ""
            v719
        | US5_0(v718) -> (* Some *)
            v718
    (* run_target_args'
    let v726 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v727 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v728 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v727 
    let _run_target_args'_v726 = v728 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v730 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v730 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v734 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v734 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v738 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v738 
    #endif
#if FABLE_COMPILER_PYTHON
    let v742 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v726 = v742 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v745 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v726 = v745 
    #endif
#else
    let v746 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v726 = v746 
    #endif
    let v747 : System.TimeZoneInfo = _run_target_args'_v726 
    (* run_target_args'
    let v760 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v764 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v765 : (System.DateTime -> int64) = _.Ticks
    let v766 : int64 = v765 v586
    let _run_target_args'_v764 = v766 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v767 : (System.DateTime -> int64) = _.Ticks
    let v768 : int64 = v767 v586
    let _run_target_args'_v764 = v768 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v770 : int64 = null |> unbox<int64>
    let _run_target_args'_v764 = v770 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v773 : (System.DateTime -> int64) = _.Ticks
    let v774 : int64 = v773 v586
    let _run_target_args'_v764 = v774 
    #endif
#if FABLE_COMPILER_PYTHON
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v586
    let _run_target_args'_v764 = v776 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v777 : (System.DateTime -> int64) = _.Ticks
    let v778 : int64 = v777 v586
    let _run_target_args'_v764 = v778 
    #endif
#else
    let v779 : (System.DateTime -> int64) = _.Ticks
    let v780 : int64 = v779 v586
    let _run_target_args'_v764 = v780 
    #endif
    let v781 : int64 = _run_target_args'_v764 
    let v801 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v802 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v781) v801 
    let v804 : System.TimeSpan = v802 |> System.TimeSpan 
    let _run_target_args'_v760 = v804 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v810 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v811 : (System.DateTime -> int64) = _.Ticks
    let v812 : int64 = v811 v586
    let _run_target_args'_v810 = v812 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v813 : (System.DateTime -> int64) = _.Ticks
    let v814 : int64 = v813 v586
    let _run_target_args'_v810 = v814 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v816 : int64 = null |> unbox<int64>
    let _run_target_args'_v810 = v816 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v819 : (System.DateTime -> int64) = _.Ticks
    let v820 : int64 = v819 v586
    let _run_target_args'_v810 = v820 
    #endif
#if FABLE_COMPILER_PYTHON
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v586
    let _run_target_args'_v810 = v822 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v823 : (System.DateTime -> int64) = _.Ticks
    let v824 : int64 = v823 v586
    let _run_target_args'_v810 = v824 
    #endif
#else
    let v825 : (System.DateTime -> int64) = _.Ticks
    let v826 : int64 = v825 v586
    let _run_target_args'_v810 = v826 
    #endif
    let v827 : int64 = _run_target_args'_v810 
    let v847 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v848 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v827) v847 
    let v850 : System.TimeSpan = v848 |> System.TimeSpan 
    let _run_target_args'_v760 = v850 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v854 : US3 = US3_2
    let v855 : US4 = US4_3(v854)
    let v856 : string = $"date_time.get_utc_offset / target: {v855}"
    let v857 : System.TimeSpan = failwith<System.TimeSpan> v856
    let _run_target_args'_v760 = v857 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v861 : US3 = US3_0
    let v862 : US4 = US4_4(v861)
    let v863 : string = $"date_time.get_utc_offset / target: {v862}"
    let v864 : System.TimeSpan = failwith<System.TimeSpan> v863
    let _run_target_args'_v760 = v864 
    #endif
#if FABLE_COMPILER_PYTHON
    let v868 : US3 = US3_0
    let v869 : US4 = US4_5(v868)
    let v870 : string = $"date_time.get_utc_offset / target: {v869}"
    let v871 : System.TimeSpan = failwith<System.TimeSpan> v870
    let _run_target_args'_v760 = v871 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v874 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v879 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v880 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v881 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v880 
    let _run_target_args'_v879 = v881 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v883 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v883 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v887 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v887 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v891 
    #endif
#if FABLE_COMPILER_PYTHON
    let v895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v879 = v895 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v898 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v879 = v898 
    #endif
#else
    let v899 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v879 = v899 
    #endif
    let v900 : System.TimeZoneInfo = _run_target_args'_v879 
    let v906 : (System.DateTime -> System.TimeSpan) = v874 v900
    let v907 : System.TimeSpan = v906 v586
    let _run_target_args'_v760 = v907 
    #endif
#else
    let v908 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v913 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v914 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v915 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v914 
    let _run_target_args'_v913 = v915 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v917 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v917 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v921 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v921 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v925 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v925 
    #endif
#if FABLE_COMPILER_PYTHON
    let v929 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v913 = v929 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v932 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v913 = v932 
    #endif
#else
    let v933 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v913 = v933 
    #endif
    let v934 : System.TimeZoneInfo = _run_target_args'_v913 
    let v940 : (System.DateTime -> System.TimeSpan) = v908 v934
    let v941 : System.TimeSpan = v940 v586
    let _run_target_args'_v760 = v941 
    #endif
    let v942 : System.TimeSpan = _run_target_args'_v760 
    let v952 : (System.TimeSpan -> int32) = _.Hours
    let v953 : int32 = v952 v942
    let v956 : bool = v953 > 0
    let v957 : uint8 =
        if v956 then
            1uy
        else
            0uy
    let v958 : string = method84()
    (* run_target_args'
    let v1012 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1013 : string = "$0.toString($1)"
    let v1014 : string = Fable.Core.RustInterop.emitRustExpr struct (v942, v958) v1013 
    let _run_target_args'_v1012 = v1014 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1015 : string = "$0.toString($1)"
    let v1016 : string = Fable.Core.RustInterop.emitRustExpr struct (v942, v958) v1015 
    let _run_target_args'_v1012 = v1016 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1017 : string = "$0.toString($1)"
    let v1018 : string = Fable.Core.RustInterop.emitRustExpr struct (v942, v958) v1017 
    let _run_target_args'_v1012 = v1018 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1019 : string = v942.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1012 = v1019 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1020 : string = v942.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1012 = v1020 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1022 : string = v942.ToString v958 
    let _run_target_args'_v1012 = v1022 
    #endif
#else
    let v1075 : string = v942.ToString v958 
    let _run_target_args'_v1012 = v1075 
    #endif
    let v1127 : string = _run_target_args'_v1012 
    let v1182 : string = $"{v957}{v1127.[0..1]}{v1127.[3..4]}"
    let v1184 : (System.Guid -> string) = _.ToString()
    let v1185 : string = v1184 v0
    let v1188 : int32 = v721.Length
    let v1189 : int32 = v1182.Length
    let v1190 : int32 = v1188 + v1189
    let v1192 : (string -> int32) = String.length
    let v1193 : int32 = v1192 v1185
    let v1201 : int32 = v1190 |> int32 
    let v1214 : int32 = v1193 |> int32 
    let v1222 : int32 = v1214 - 1
    let v1224 : string = v1185.[int v1201..int v1222]
    let v1228 : string = $"{v721}{v1182}{v1224}"
    (* run_target_args'
    let v1233 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1235 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1235 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1239 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1239 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1243 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1233 = v1243 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1247 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1247 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1251 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1251 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1255 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1255 
    #endif
#else
    let v1259 : System.Guid = v1228 |> System.Guid 
    let _run_target_args'_v1233 = v1259 
    #endif
    let v1262 : System.Guid = _run_target_args'_v1233 
    let _run_target_args'_v569 = v1262 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1269 : System.DateTime = System.DateTime.UnixEpoch
    let v1273 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1274 : System.DateTime = v1273 v1269
    let v1278 : System.DateTimeKind = System.DateTimeKind.Local
    let v1279 : System.DateTime = System.DateTime.SpecifyKind (v1, v1278)
    let v1283 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1284 : System.DateTime = v1283 v1279
    (* run_target_args'
    let v1290 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1291 : (System.DateTime -> int64) = _.Ticks
    let v1292 : int64 = v1291 v1284
    let _run_target_args'_v1290 = v1292 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1293 : (System.DateTime -> int64) = _.Ticks
    let v1294 : int64 = v1293 v1284
    let _run_target_args'_v1290 = v1294 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1296 : int64 = null |> unbox<int64>
    let _run_target_args'_v1290 = v1296 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1299 : (System.DateTime -> int64) = _.Ticks
    let v1300 : int64 = v1299 v1284
    let _run_target_args'_v1290 = v1300 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1301 : (System.DateTime -> int64) = _.Ticks
    let v1302 : int64 = v1301 v1284
    let _run_target_args'_v1290 = v1302 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1303 : (System.DateTime -> int64) = _.Ticks
    let v1304 : int64 = v1303 v1284
    let _run_target_args'_v1290 = v1304 
    #endif
#else
    let v1305 : (System.DateTime -> int64) = _.Ticks
    let v1306 : int64 = v1305 v1284
    let _run_target_args'_v1290 = v1306 
    #endif
    let v1307 : int64 = _run_target_args'_v1290 
    (* run_target_args'
    let v1330 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1331 : (System.DateTime -> int64) = _.Ticks
    let v1332 : int64 = v1331 v1274
    let _run_target_args'_v1330 = v1332 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1333 : (System.DateTime -> int64) = _.Ticks
    let v1334 : int64 = v1333 v1274
    let _run_target_args'_v1330 = v1334 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1336 : int64 = null |> unbox<int64>
    let _run_target_args'_v1330 = v1336 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1339 : (System.DateTime -> int64) = _.Ticks
    let v1340 : int64 = v1339 v1274
    let _run_target_args'_v1330 = v1340 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1341 : (System.DateTime -> int64) = _.Ticks
    let v1342 : int64 = v1341 v1274
    let _run_target_args'_v1330 = v1342 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1343 : (System.DateTime -> int64) = _.Ticks
    let v1344 : int64 = v1343 v1274
    let _run_target_args'_v1330 = v1344 
    #endif
#else
    let v1345 : (System.DateTime -> int64) = _.Ticks
    let v1346 : int64 = v1345 v1274
    let _run_target_args'_v1330 = v1346 
    #endif
    let v1347 : int64 = _run_target_args'_v1330 
    let v1368 : int64 = v1307 |> int64 
    let v1372 : int64 = v1347 |> int64 
    let v1375 : int64 = v1368 - v1372
    let v1376 : int64 = v1375 / 10L
    let v1377 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1378 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1376 v1377 
    let v1380 : (chrono_DateTime<chrono_Utc> -> US12) = method83()
    let v1381 : US12 option = v1378 |> Option.map v1380 
    let v1394 : US12 = US12_1
    let v1395 : US12 = v1381 |> Option.defaultValue v1394 
    let v1415 : US5 =
        match v1395 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v1399) -> (* Some *)
            let v1400 : string = "$0.naive_utc()"
            let v1401 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1399 v1400 
            let v1402 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1403 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1401 v1402 
            let v1404 : string = "%Y%m%d-%H%M-%S%f"
            let v1405 : string = "r#\"" + v1404 + "\"#"
            let v1406 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1405 
            let v1407 : string = "$0.format($1).to_string()"
            let v1408 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1403, v1406) v1407 
            let v1409 : string = "fable_library_rust::String_::fromString($0)"
            let v1410 : string = Fable.Core.RustInterop.emitRustExpr v1408 v1409 
            let v1411 : string = $"{v1410.[0..17]}-{v1410.[18..21]}-{v1410.[22]}"
            US5_0(v1411)
    let v1419 : string =
        match v1415 with
        | US5_1 -> (* None *)
            let v1417 : string = ""
            v1417
        | US5_0(v1416) -> (* Some *)
            v1416
    (* run_target_args'
    let v1424 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1425 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1426 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1425 
    let _run_target_args'_v1424 = v1426 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1428 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1428 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1432 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1432 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1440 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1424 = v1440 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1443 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1424 = v1443 
    #endif
#else
    let v1444 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1424 = v1444 
    #endif
    let v1445 : System.TimeZoneInfo = _run_target_args'_v1424 
    (* run_target_args'
    let v1458 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1462 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1463 : (System.DateTime -> int64) = _.Ticks
    let v1464 : int64 = v1463 v1284
    let _run_target_args'_v1462 = v1464 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1465 : (System.DateTime -> int64) = _.Ticks
    let v1466 : int64 = v1465 v1284
    let _run_target_args'_v1462 = v1466 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1468 : int64 = null |> unbox<int64>
    let _run_target_args'_v1462 = v1468 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1471 : (System.DateTime -> int64) = _.Ticks
    let v1472 : int64 = v1471 v1284
    let _run_target_args'_v1462 = v1472 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1473 : (System.DateTime -> int64) = _.Ticks
    let v1474 : int64 = v1473 v1284
    let _run_target_args'_v1462 = v1474 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1475 : (System.DateTime -> int64) = _.Ticks
    let v1476 : int64 = v1475 v1284
    let _run_target_args'_v1462 = v1476 
    #endif
#else
    let v1477 : (System.DateTime -> int64) = _.Ticks
    let v1478 : int64 = v1477 v1284
    let _run_target_args'_v1462 = v1478 
    #endif
    let v1479 : int64 = _run_target_args'_v1462 
    let v1499 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1500 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1284, v1479) v1499 
    let v1502 : System.TimeSpan = v1500 |> System.TimeSpan 
    let _run_target_args'_v1458 = v1502 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1508 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1509 : (System.DateTime -> int64) = _.Ticks
    let v1510 : int64 = v1509 v1284
    let _run_target_args'_v1508 = v1510 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1511 : (System.DateTime -> int64) = _.Ticks
    let v1512 : int64 = v1511 v1284
    let _run_target_args'_v1508 = v1512 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1514 : int64 = null |> unbox<int64>
    let _run_target_args'_v1508 = v1514 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1517 : (System.DateTime -> int64) = _.Ticks
    let v1518 : int64 = v1517 v1284
    let _run_target_args'_v1508 = v1518 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1519 : (System.DateTime -> int64) = _.Ticks
    let v1520 : int64 = v1519 v1284
    let _run_target_args'_v1508 = v1520 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1521 : (System.DateTime -> int64) = _.Ticks
    let v1522 : int64 = v1521 v1284
    let _run_target_args'_v1508 = v1522 
    #endif
#else
    let v1523 : (System.DateTime -> int64) = _.Ticks
    let v1524 : int64 = v1523 v1284
    let _run_target_args'_v1508 = v1524 
    #endif
    let v1525 : int64 = _run_target_args'_v1508 
    let v1545 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1546 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1284, v1525) v1545 
    let v1548 : System.TimeSpan = v1546 |> System.TimeSpan 
    let _run_target_args'_v1458 = v1548 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1552 : US3 = US3_2
    let v1553 : US4 = US4_3(v1552)
    let v1554 : string = $"date_time.get_utc_offset / target: {v1553}"
    let v1555 : System.TimeSpan = failwith<System.TimeSpan> v1554
    let _run_target_args'_v1458 = v1555 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1559 : US3 = US3_0
    let v1560 : US4 = US4_4(v1559)
    let v1561 : string = $"date_time.get_utc_offset / target: {v1560}"
    let v1562 : System.TimeSpan = failwith<System.TimeSpan> v1561
    let _run_target_args'_v1458 = v1562 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1566 : US3 = US3_0
    let v1567 : US4 = US4_5(v1566)
    let v1568 : string = $"date_time.get_utc_offset / target: {v1567}"
    let v1569 : System.TimeSpan = failwith<System.TimeSpan> v1568
    let _run_target_args'_v1458 = v1569 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1572 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1577 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1578 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1579 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1578 
    let _run_target_args'_v1577 = v1579 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1581 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1581 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1585 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1585 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1589 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1589 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1577 = v1593 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1596 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1577 = v1596 
    #endif
#else
    let v1597 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1577 = v1597 
    #endif
    let v1598 : System.TimeZoneInfo = _run_target_args'_v1577 
    let v1604 : (System.DateTime -> System.TimeSpan) = v1572 v1598
    let v1605 : System.TimeSpan = v1604 v1284
    let _run_target_args'_v1458 = v1605 
    #endif
#else
    let v1606 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1611 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1612 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1613 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1612 
    let _run_target_args'_v1611 = v1613 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1615 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1615 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1619 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1619 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1623 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1623 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1627 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1611 = v1627 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1630 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1611 = v1630 
    #endif
#else
    let v1631 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1611 = v1631 
    #endif
    let v1632 : System.TimeZoneInfo = _run_target_args'_v1611 
    let v1638 : (System.DateTime -> System.TimeSpan) = v1606 v1632
    let v1639 : System.TimeSpan = v1638 v1284
    let _run_target_args'_v1458 = v1639 
    #endif
    let v1640 : System.TimeSpan = _run_target_args'_v1458 
    let v1650 : (System.TimeSpan -> int32) = _.Hours
    let v1651 : int32 = v1650 v1640
    let v1654 : bool = v1651 > 0
    let v1655 : uint8 =
        if v1654 then
            1uy
        else
            0uy
    let v1656 : string = method84()
    (* run_target_args'
    let v1710 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1711 : string = "$0.toString($1)"
    let v1712 : string = Fable.Core.RustInterop.emitRustExpr struct (v1640, v1656) v1711 
    let _run_target_args'_v1710 = v1712 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1713 : string = "$0.toString($1)"
    let v1714 : string = Fable.Core.RustInterop.emitRustExpr struct (v1640, v1656) v1713 
    let _run_target_args'_v1710 = v1714 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1715 : string = "$0.toString($1)"
    let v1716 : string = Fable.Core.RustInterop.emitRustExpr struct (v1640, v1656) v1715 
    let _run_target_args'_v1710 = v1716 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1717 : string = v1640.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1710 = v1717 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1718 : string = v1640.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1710 = v1718 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1720 : string = v1640.ToString v1656 
    let _run_target_args'_v1710 = v1720 
    #endif
#else
    let v1773 : string = v1640.ToString v1656 
    let _run_target_args'_v1710 = v1773 
    #endif
    let v1825 : string = _run_target_args'_v1710 
    let v1880 : string = $"{v1655}{v1825.[0..1]}{v1825.[3..4]}"
    let v1882 : (System.Guid -> string) = _.ToString()
    let v1883 : string = v1882 v0
    let v1886 : int32 = v1419.Length
    let v1887 : int32 = v1880.Length
    let v1888 : int32 = v1886 + v1887
    let v1890 : (string -> int32) = String.length
    let v1891 : int32 = v1890 v1883
    let v1899 : int32 = v1888 |> int32 
    let v1912 : int32 = v1891 |> int32 
    let v1920 : int32 = v1912 - 1
    let v1922 : string = v1883.[int v1899..int v1920]
    let v1926 : string = $"{v1419}{v1880}{v1922}"
    (* run_target_args'
    let v1931 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1933 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1933 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1937 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1937 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1941 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1931 = v1941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1945 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1945 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1949 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1949 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1953 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1953 
    #endif
#else
    let v1957 : System.Guid = v1926 |> System.Guid 
    let _run_target_args'_v1931 = v1957 
    #endif
    let v1960 : System.Guid = _run_target_args'_v1931 
    let _run_target_args'_v569 = v1960 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1967 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v569 = v1967 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1970 : string = method85()
    let v1972 : bool = v1970 = ""
    let v1974 : string =
        if v1972 then
            let v1973 : string = "M-d-y hh:mm:ss tt"
            v1973
        else
            v1970
    let v1975 : (string -> string) = v1.ToString
    let v1976 : string = v1975 v1974
    (* run_target_args'
    let v1995 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1996 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1997 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1996 
    let _run_target_args'_v1995 = v1997 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1999 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v1999 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2003 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v2003 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2007 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v2007 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2011 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1995 = v2011 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2014 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1995 = v2014 
    #endif
#else
    let v2015 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1995 = v2015 
    #endif
    let v2016 : System.TimeZoneInfo = _run_target_args'_v1995 
    (* run_target_args'
    let v2029 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2033 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2034 : (System.DateTime -> int64) = _.Ticks
    let v2035 : int64 = v2034 v1
    let _run_target_args'_v2033 = v2035 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2036 : (System.DateTime -> int64) = _.Ticks
    let v2037 : int64 = v2036 v1
    let _run_target_args'_v2033 = v2037 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2039 : int64 = null |> unbox<int64>
    let _run_target_args'_v2033 = v2039 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2042 : (System.DateTime -> int64) = _.Ticks
    let v2043 : int64 = v2042 v1
    let _run_target_args'_v2033 = v2043 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2044 : (System.DateTime -> int64) = _.Ticks
    let v2045 : int64 = v2044 v1
    let _run_target_args'_v2033 = v2045 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2046 : (System.DateTime -> int64) = _.Ticks
    let v2047 : int64 = v2046 v1
    let _run_target_args'_v2033 = v2047 
    #endif
#else
    let v2048 : (System.DateTime -> int64) = _.Ticks
    let v2049 : int64 = v2048 v1
    let _run_target_args'_v2033 = v2049 
    #endif
    let v2050 : int64 = _run_target_args'_v2033 
    let v2070 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2071 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2050) v2070 
    let v2073 : System.TimeSpan = v2071 |> System.TimeSpan 
    let _run_target_args'_v2029 = v2073 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2079 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2080 : (System.DateTime -> int64) = _.Ticks
    let v2081 : int64 = v2080 v1
    let _run_target_args'_v2079 = v2081 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2082 : (System.DateTime -> int64) = _.Ticks
    let v2083 : int64 = v2082 v1
    let _run_target_args'_v2079 = v2083 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2085 : int64 = null |> unbox<int64>
    let _run_target_args'_v2079 = v2085 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2088 : (System.DateTime -> int64) = _.Ticks
    let v2089 : int64 = v2088 v1
    let _run_target_args'_v2079 = v2089 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2090 : (System.DateTime -> int64) = _.Ticks
    let v2091 : int64 = v2090 v1
    let _run_target_args'_v2079 = v2091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2092 : (System.DateTime -> int64) = _.Ticks
    let v2093 : int64 = v2092 v1
    let _run_target_args'_v2079 = v2093 
    #endif
#else
    let v2094 : (System.DateTime -> int64) = _.Ticks
    let v2095 : int64 = v2094 v1
    let _run_target_args'_v2079 = v2095 
    #endif
    let v2096 : int64 = _run_target_args'_v2079 
    let v2116 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2117 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2096) v2116 
    let v2119 : System.TimeSpan = v2117 |> System.TimeSpan 
    let _run_target_args'_v2029 = v2119 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2123 : US3 = US3_2
    let v2124 : US4 = US4_3(v2123)
    let v2125 : string = $"date_time.get_utc_offset / target: {v2124}"
    let v2126 : System.TimeSpan = failwith<System.TimeSpan> v2125
    let _run_target_args'_v2029 = v2126 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2130 : US3 = US3_0
    let v2131 : US4 = US4_4(v2130)
    let v2132 : string = $"date_time.get_utc_offset / target: {v2131}"
    let v2133 : System.TimeSpan = failwith<System.TimeSpan> v2132
    let _run_target_args'_v2029 = v2133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2137 : US3 = US3_0
    let v2138 : US4 = US4_5(v2137)
    let v2139 : string = $"date_time.get_utc_offset / target: {v2138}"
    let v2140 : System.TimeSpan = failwith<System.TimeSpan> v2139
    let _run_target_args'_v2029 = v2140 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2143 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2149 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2150 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2149 
    let _run_target_args'_v2148 = v2150 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2152 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2152 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2156 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2160 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2160 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2164 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2148 = v2164 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2167 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2148 = v2167 
    #endif
#else
    let v2168 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2148 = v2168 
    #endif
    let v2169 : System.TimeZoneInfo = _run_target_args'_v2148 
    let v2175 : (System.DateTime -> System.TimeSpan) = v2143 v2169
    let v2176 : System.TimeSpan = v2175 v1
    let _run_target_args'_v2029 = v2176 
    #endif
#else
    let v2177 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2182 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2183 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2184 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2183 
    let _run_target_args'_v2182 = v2184 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2186 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2186 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2190 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2190 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2194 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2194 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2198 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2182 = v2198 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2201 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2182 = v2201 
    #endif
#else
    let v2202 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2182 = v2202 
    #endif
    let v2203 : System.TimeZoneInfo = _run_target_args'_v2182 
    let v2209 : (System.DateTime -> System.TimeSpan) = v2177 v2203
    let v2210 : System.TimeSpan = v2209 v1
    let _run_target_args'_v2029 = v2210 
    #endif
    let v2211 : System.TimeSpan = _run_target_args'_v2029 
    let v2221 : (System.TimeSpan -> int32) = _.Hours
    let v2222 : int32 = v2221 v2211
    let v2225 : bool = v2222 > 0
    let v2226 : uint8 =
        if v2225 then
            1uy
        else
            0uy
    let v2227 : string = method86()
    (* run_target_args'
    let v2281 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2282 : string = "$0.toString($1)"
    let v2283 : string = Fable.Core.RustInterop.emitRustExpr struct (v2211, v2227) v2282 
    let _run_target_args'_v2281 = v2283 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2284 : string = "$0.toString($1)"
    let v2285 : string = Fable.Core.RustInterop.emitRustExpr struct (v2211, v2227) v2284 
    let _run_target_args'_v2281 = v2285 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2286 : string = "$0.toString($1)"
    let v2287 : string = Fable.Core.RustInterop.emitRustExpr struct (v2211, v2227) v2286 
    let _run_target_args'_v2281 = v2287 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2288 : string = v2211.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2281 = v2288 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2289 : string = v2211.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2281 = v2289 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2291 : string = v2211.ToString v2227 
    let _run_target_args'_v2281 = v2291 
    #endif
#else
    let v2344 : string = v2211.ToString v2227 
    let _run_target_args'_v2281 = v2344 
    #endif
    let v2396 : string = _run_target_args'_v2281 
    let v2451 : string = $"{v2226}{v2396}"
    let v2453 : (System.Guid -> string) = _.ToString()
    let v2454 : string = v2453 v0
    let v2457 : int32 = v1976.Length
    let v2458 : int32 = v2451.Length
    let v2459 : int32 = v2457 + v2458
    let v2461 : (string -> int32) = String.length
    let v2462 : int32 = v2461 v2454
    let v2470 : int32 = v2459 |> int32 
    let v2483 : int32 = v2462 |> int32 
    let v2491 : int32 = v2483 - 1
    let v2493 : string = v2454.[int v2470..int v2491]
    let v2497 : string = $"{v1976}{v2451}{v2493}"
    (* run_target_args'
    let v2502 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2504 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2504 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2508 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2508 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2512 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2502 = v2512 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2516 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2516 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2520 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2520 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2524 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2524 
    #endif
#else
    let v2528 : System.Guid = v2497 |> System.Guid 
    let _run_target_args'_v2502 = v2528 
    #endif
    let v2531 : System.Guid = _run_target_args'_v2502 
    let _run_target_args'_v569 = v2531 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2537 : string = method85()
    let v2539 : bool = v2537 = ""
    let v2541 : string =
        if v2539 then
            let v2540 : string = "M-d-y hh:mm:ss tt"
            v2540
        else
            v2537
    let v2542 : (string -> string) = v1.ToString
    let v2543 : string = v2542 v2541
    (* run_target_args'
    let v2562 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2563 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2564 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2563 
    let _run_target_args'_v2562 = v2564 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2566 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2566 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2570 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2570 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2574 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2574 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2578 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2562 = v2578 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2581 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2562 = v2581 
    #endif
#else
    let v2582 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2562 = v2582 
    #endif
    let v2583 : System.TimeZoneInfo = _run_target_args'_v2562 
    (* run_target_args'
    let v2596 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2600 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2601 : (System.DateTime -> int64) = _.Ticks
    let v2602 : int64 = v2601 v1
    let _run_target_args'_v2600 = v2602 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2603 : (System.DateTime -> int64) = _.Ticks
    let v2604 : int64 = v2603 v1
    let _run_target_args'_v2600 = v2604 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2606 : int64 = null |> unbox<int64>
    let _run_target_args'_v2600 = v2606 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2609 : (System.DateTime -> int64) = _.Ticks
    let v2610 : int64 = v2609 v1
    let _run_target_args'_v2600 = v2610 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2611 : (System.DateTime -> int64) = _.Ticks
    let v2612 : int64 = v2611 v1
    let _run_target_args'_v2600 = v2612 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2613 : (System.DateTime -> int64) = _.Ticks
    let v2614 : int64 = v2613 v1
    let _run_target_args'_v2600 = v2614 
    #endif
#else
    let v2615 : (System.DateTime -> int64) = _.Ticks
    let v2616 : int64 = v2615 v1
    let _run_target_args'_v2600 = v2616 
    #endif
    let v2617 : int64 = _run_target_args'_v2600 
    let v2637 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2638 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2617) v2637 
    let v2640 : System.TimeSpan = v2638 |> System.TimeSpan 
    let _run_target_args'_v2596 = v2640 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2646 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2647 : (System.DateTime -> int64) = _.Ticks
    let v2648 : int64 = v2647 v1
    let _run_target_args'_v2646 = v2648 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2649 : (System.DateTime -> int64) = _.Ticks
    let v2650 : int64 = v2649 v1
    let _run_target_args'_v2646 = v2650 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2652 : int64 = null |> unbox<int64>
    let _run_target_args'_v2646 = v2652 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2655 : (System.DateTime -> int64) = _.Ticks
    let v2656 : int64 = v2655 v1
    let _run_target_args'_v2646 = v2656 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2657 : (System.DateTime -> int64) = _.Ticks
    let v2658 : int64 = v2657 v1
    let _run_target_args'_v2646 = v2658 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2659 : (System.DateTime -> int64) = _.Ticks
    let v2660 : int64 = v2659 v1
    let _run_target_args'_v2646 = v2660 
    #endif
#else
    let v2661 : (System.DateTime -> int64) = _.Ticks
    let v2662 : int64 = v2661 v1
    let _run_target_args'_v2646 = v2662 
    #endif
    let v2663 : int64 = _run_target_args'_v2646 
    let v2683 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2684 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2663) v2683 
    let v2686 : System.TimeSpan = v2684 |> System.TimeSpan 
    let _run_target_args'_v2596 = v2686 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2690 : US3 = US3_2
    let v2691 : US4 = US4_3(v2690)
    let v2692 : string = $"date_time.get_utc_offset / target: {v2691}"
    let v2693 : System.TimeSpan = failwith<System.TimeSpan> v2692
    let _run_target_args'_v2596 = v2693 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2697 : US3 = US3_0
    let v2698 : US4 = US4_4(v2697)
    let v2699 : string = $"date_time.get_utc_offset / target: {v2698}"
    let v2700 : System.TimeSpan = failwith<System.TimeSpan> v2699
    let _run_target_args'_v2596 = v2700 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2704 : US3 = US3_0
    let v2705 : US4 = US4_5(v2704)
    let v2706 : string = $"date_time.get_utc_offset / target: {v2705}"
    let v2707 : System.TimeSpan = failwith<System.TimeSpan> v2706
    let _run_target_args'_v2596 = v2707 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2710 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2715 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2716 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2717 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2716 
    let _run_target_args'_v2715 = v2717 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2719 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2719 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2723 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2723 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2727 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2727 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2731 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2715 = v2731 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2734 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2715 = v2734 
    #endif
#else
    let v2735 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2715 = v2735 
    #endif
    let v2736 : System.TimeZoneInfo = _run_target_args'_v2715 
    let v2742 : (System.DateTime -> System.TimeSpan) = v2710 v2736
    let v2743 : System.TimeSpan = v2742 v1
    let _run_target_args'_v2596 = v2743 
    #endif
#else
    let v2744 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2749 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2750 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2751 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2750 
    let _run_target_args'_v2749 = v2751 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2753 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2753 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2757 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2757 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2761 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2761 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2765 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2749 = v2765 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2768 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2749 = v2768 
    #endif
#else
    let v2769 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2749 = v2769 
    #endif
    let v2770 : System.TimeZoneInfo = _run_target_args'_v2749 
    let v2776 : (System.DateTime -> System.TimeSpan) = v2744 v2770
    let v2777 : System.TimeSpan = v2776 v1
    let _run_target_args'_v2596 = v2777 
    #endif
    let v2778 : System.TimeSpan = _run_target_args'_v2596 
    let v2788 : (System.TimeSpan -> int32) = _.Hours
    let v2789 : int32 = v2788 v2778
    let v2792 : bool = v2789 > 0
    let v2793 : uint8 =
        if v2792 then
            1uy
        else
            0uy
    let v2794 : string = method86()
    (* run_target_args'
    let v2848 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2849 : string = "$0.toString($1)"
    let v2850 : string = Fable.Core.RustInterop.emitRustExpr struct (v2778, v2794) v2849 
    let _run_target_args'_v2848 = v2850 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2851 : string = "$0.toString($1)"
    let v2852 : string = Fable.Core.RustInterop.emitRustExpr struct (v2778, v2794) v2851 
    let _run_target_args'_v2848 = v2852 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2853 : string = "$0.toString($1)"
    let v2854 : string = Fable.Core.RustInterop.emitRustExpr struct (v2778, v2794) v2853 
    let _run_target_args'_v2848 = v2854 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2855 : string = v2778.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2848 = v2855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2856 : string = v2778.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2848 = v2856 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2858 : string = v2778.ToString v2794 
    let _run_target_args'_v2848 = v2858 
    #endif
#else
    let v2911 : string = v2778.ToString v2794 
    let _run_target_args'_v2848 = v2911 
    #endif
    let v2963 : string = _run_target_args'_v2848 
    let v3018 : string = $"{v2793}{v2963}"
    let v3020 : (System.Guid -> string) = _.ToString()
    let v3021 : string = v3020 v0
    let v3024 : int32 = v2543.Length
    let v3025 : int32 = v3018.Length
    let v3026 : int32 = v3024 + v3025
    let v3028 : (string -> int32) = String.length
    let v3029 : int32 = v3028 v3021
    let v3037 : int32 = v3026 |> int32 
    let v3050 : int32 = v3029 |> int32 
    let v3058 : int32 = v3050 - 1
    let v3060 : string = v3021.[int v3037..int v3058]
    let v3064 : string = $"{v2543}{v3018}{v3060}"
    (* run_target_args'
    let v3069 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3071 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3071 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3075 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3075 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3079 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3069 = v3079 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3083 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3083 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3087 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3087 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3091 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3091 
    #endif
#else
    let v3095 : System.Guid = v3064 |> System.Guid 
    let _run_target_args'_v3069 = v3095 
    #endif
    let v3098 : System.Guid = _run_target_args'_v3069 
    let _run_target_args'_v569 = v3098 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3104 : string = method85()
    let v3106 : bool = v3104 = ""
    let v3108 : string =
        if v3106 then
            let v3107 : string = "M-d-y hh:mm:ss tt"
            v3107
        else
            v3104
    let v3109 : (string -> string) = v1.ToString
    let v3110 : string = v3109 v3108
    (* run_target_args'
    let v3129 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3130 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3131 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3130 
    let _run_target_args'_v3129 = v3131 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3133 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3133 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3137 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3137 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3141 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3141 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3145 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3129 = v3145 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3148 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3129 = v3148 
    #endif
#else
    let v3149 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3129 = v3149 
    #endif
    let v3150 : System.TimeZoneInfo = _run_target_args'_v3129 
    (* run_target_args'
    let v3163 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3168 : (System.DateTime -> int64) = _.Ticks
    let v3169 : int64 = v3168 v1
    let _run_target_args'_v3167 = v3169 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3170 : (System.DateTime -> int64) = _.Ticks
    let v3171 : int64 = v3170 v1
    let _run_target_args'_v3167 = v3171 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3173 : int64 = null |> unbox<int64>
    let _run_target_args'_v3167 = v3173 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3176 : (System.DateTime -> int64) = _.Ticks
    let v3177 : int64 = v3176 v1
    let _run_target_args'_v3167 = v3177 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3178 : (System.DateTime -> int64) = _.Ticks
    let v3179 : int64 = v3178 v1
    let _run_target_args'_v3167 = v3179 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3180 : (System.DateTime -> int64) = _.Ticks
    let v3181 : int64 = v3180 v1
    let _run_target_args'_v3167 = v3181 
    #endif
#else
    let v3182 : (System.DateTime -> int64) = _.Ticks
    let v3183 : int64 = v3182 v1
    let _run_target_args'_v3167 = v3183 
    #endif
    let v3184 : int64 = _run_target_args'_v3167 
    let v3204 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3205 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3184) v3204 
    let v3207 : System.TimeSpan = v3205 |> System.TimeSpan 
    let _run_target_args'_v3163 = v3207 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3213 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3214 : (System.DateTime -> int64) = _.Ticks
    let v3215 : int64 = v3214 v1
    let _run_target_args'_v3213 = v3215 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3216 : (System.DateTime -> int64) = _.Ticks
    let v3217 : int64 = v3216 v1
    let _run_target_args'_v3213 = v3217 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3219 : int64 = null |> unbox<int64>
    let _run_target_args'_v3213 = v3219 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3222 : (System.DateTime -> int64) = _.Ticks
    let v3223 : int64 = v3222 v1
    let _run_target_args'_v3213 = v3223 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3224 : (System.DateTime -> int64) = _.Ticks
    let v3225 : int64 = v3224 v1
    let _run_target_args'_v3213 = v3225 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3226 : (System.DateTime -> int64) = _.Ticks
    let v3227 : int64 = v3226 v1
    let _run_target_args'_v3213 = v3227 
    #endif
#else
    let v3228 : (System.DateTime -> int64) = _.Ticks
    let v3229 : int64 = v3228 v1
    let _run_target_args'_v3213 = v3229 
    #endif
    let v3230 : int64 = _run_target_args'_v3213 
    let v3250 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3251 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3230) v3250 
    let v3253 : System.TimeSpan = v3251 |> System.TimeSpan 
    let _run_target_args'_v3163 = v3253 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3257 : US3 = US3_2
    let v3258 : US4 = US4_3(v3257)
    let v3259 : string = $"date_time.get_utc_offset / target: {v3258}"
    let v3260 : System.TimeSpan = failwith<System.TimeSpan> v3259
    let _run_target_args'_v3163 = v3260 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3264 : US3 = US3_0
    let v3265 : US4 = US4_4(v3264)
    let v3266 : string = $"date_time.get_utc_offset / target: {v3265}"
    let v3267 : System.TimeSpan = failwith<System.TimeSpan> v3266
    let _run_target_args'_v3163 = v3267 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3271 : US3 = US3_0
    let v3272 : US4 = US4_5(v3271)
    let v3273 : string = $"date_time.get_utc_offset / target: {v3272}"
    let v3274 : System.TimeSpan = failwith<System.TimeSpan> v3273
    let _run_target_args'_v3163 = v3274 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3277 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3282 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3283 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3284 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3283 
    let _run_target_args'_v3282 = v3284 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3286 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3286 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3290 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3290 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3294 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3294 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3298 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3282 = v3298 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3301 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3282 = v3301 
    #endif
#else
    let v3302 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3282 = v3302 
    #endif
    let v3303 : System.TimeZoneInfo = _run_target_args'_v3282 
    let v3309 : (System.DateTime -> System.TimeSpan) = v3277 v3303
    let v3310 : System.TimeSpan = v3309 v1
    let _run_target_args'_v3163 = v3310 
    #endif
#else
    let v3311 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3316 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3317 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3318 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3317 
    let _run_target_args'_v3316 = v3318 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3320 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3320 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3324 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3328 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3328 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3332 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3316 = v3332 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3335 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3316 = v3335 
    #endif
#else
    let v3336 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3316 = v3336 
    #endif
    let v3337 : System.TimeZoneInfo = _run_target_args'_v3316 
    let v3343 : (System.DateTime -> System.TimeSpan) = v3311 v3337
    let v3344 : System.TimeSpan = v3343 v1
    let _run_target_args'_v3163 = v3344 
    #endif
    let v3345 : System.TimeSpan = _run_target_args'_v3163 
    let v3355 : (System.TimeSpan -> int32) = _.Hours
    let v3356 : int32 = v3355 v3345
    let v3359 : bool = v3356 > 0
    let v3360 : uint8 =
        if v3359 then
            1uy
        else
            0uy
    let v3361 : string = method86()
    (* run_target_args'
    let v3415 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3416 : string = "$0.toString($1)"
    let v3417 : string = Fable.Core.RustInterop.emitRustExpr struct (v3345, v3361) v3416 
    let _run_target_args'_v3415 = v3417 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3418 : string = "$0.toString($1)"
    let v3419 : string = Fable.Core.RustInterop.emitRustExpr struct (v3345, v3361) v3418 
    let _run_target_args'_v3415 = v3419 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3420 : string = "$0.toString($1)"
    let v3421 : string = Fable.Core.RustInterop.emitRustExpr struct (v3345, v3361) v3420 
    let _run_target_args'_v3415 = v3421 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3422 : string = v3345.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3415 = v3422 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3423 : string = v3345.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3415 = v3423 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3425 : string = v3345.ToString v3361 
    let _run_target_args'_v3415 = v3425 
    #endif
#else
    let v3478 : string = v3345.ToString v3361 
    let _run_target_args'_v3415 = v3478 
    #endif
    let v3530 : string = _run_target_args'_v3415 
    let v3585 : string = $"{v3360}{v3530}"
    let v3587 : (System.Guid -> string) = _.ToString()
    let v3588 : string = v3587 v0
    let v3591 : int32 = v3110.Length
    let v3592 : int32 = v3585.Length
    let v3593 : int32 = v3591 + v3592
    let v3595 : (string -> int32) = String.length
    let v3596 : int32 = v3595 v3588
    let v3604 : int32 = v3593 |> int32 
    let v3617 : int32 = v3596 |> int32 
    let v3625 : int32 = v3617 - 1
    let v3627 : string = v3588.[int v3604..int v3625]
    let v3631 : string = $"{v3110}{v3585}{v3627}"
    (* run_target_args'
    let v3636 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3638 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3638 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3642 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3642 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3646 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3636 = v3646 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3650 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3650 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3654 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3654 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3658 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3658 
    #endif
#else
    let v3662 : System.Guid = v3631 |> System.Guid 
    let _run_target_args'_v3636 = v3662 
    #endif
    let v3665 : System.Guid = _run_target_args'_v3636 
    let _run_target_args'_v569 = v3665 
    #endif
#else
    let v3671 : string = method85()
    let v3673 : bool = v3671 = ""
    let v3675 : string =
        if v3673 then
            let v3674 : string = "M-d-y hh:mm:ss tt"
            v3674
        else
            v3671
    let v3676 : (string -> string) = v1.ToString
    let v3677 : string = v3676 v3675
    (* run_target_args'
    let v3696 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3697 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3698 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3697 
    let _run_target_args'_v3696 = v3698 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3700 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3700 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3704 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3704 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3708 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3708 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3712 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3696 = v3712 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3715 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3696 = v3715 
    #endif
#else
    let v3716 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3696 = v3716 
    #endif
    let v3717 : System.TimeZoneInfo = _run_target_args'_v3696 
    (* run_target_args'
    let v3730 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3735 : (System.DateTime -> int64) = _.Ticks
    let v3736 : int64 = v3735 v1
    let _run_target_args'_v3734 = v3736 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3737 : (System.DateTime -> int64) = _.Ticks
    let v3738 : int64 = v3737 v1
    let _run_target_args'_v3734 = v3738 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3740 : int64 = null |> unbox<int64>
    let _run_target_args'_v3734 = v3740 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3743 : (System.DateTime -> int64) = _.Ticks
    let v3744 : int64 = v3743 v1
    let _run_target_args'_v3734 = v3744 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3745 : (System.DateTime -> int64) = _.Ticks
    let v3746 : int64 = v3745 v1
    let _run_target_args'_v3734 = v3746 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3747 : (System.DateTime -> int64) = _.Ticks
    let v3748 : int64 = v3747 v1
    let _run_target_args'_v3734 = v3748 
    #endif
#else
    let v3749 : (System.DateTime -> int64) = _.Ticks
    let v3750 : int64 = v3749 v1
    let _run_target_args'_v3734 = v3750 
    #endif
    let v3751 : int64 = _run_target_args'_v3734 
    let v3771 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3772 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3751) v3771 
    let v3774 : System.TimeSpan = v3772 |> System.TimeSpan 
    let _run_target_args'_v3730 = v3774 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3780 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3781 : (System.DateTime -> int64) = _.Ticks
    let v3782 : int64 = v3781 v1
    let _run_target_args'_v3780 = v3782 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3783 : (System.DateTime -> int64) = _.Ticks
    let v3784 : int64 = v3783 v1
    let _run_target_args'_v3780 = v3784 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3786 : int64 = null |> unbox<int64>
    let _run_target_args'_v3780 = v3786 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3789 : (System.DateTime -> int64) = _.Ticks
    let v3790 : int64 = v3789 v1
    let _run_target_args'_v3780 = v3790 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3791 : (System.DateTime -> int64) = _.Ticks
    let v3792 : int64 = v3791 v1
    let _run_target_args'_v3780 = v3792 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3793 : (System.DateTime -> int64) = _.Ticks
    let v3794 : int64 = v3793 v1
    let _run_target_args'_v3780 = v3794 
    #endif
#else
    let v3795 : (System.DateTime -> int64) = _.Ticks
    let v3796 : int64 = v3795 v1
    let _run_target_args'_v3780 = v3796 
    #endif
    let v3797 : int64 = _run_target_args'_v3780 
    let v3817 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3818 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3797) v3817 
    let v3820 : System.TimeSpan = v3818 |> System.TimeSpan 
    let _run_target_args'_v3730 = v3820 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3824 : US3 = US3_2
    let v3825 : US4 = US4_3(v3824)
    let v3826 : string = $"date_time.get_utc_offset / target: {v3825}"
    let v3827 : System.TimeSpan = failwith<System.TimeSpan> v3826
    let _run_target_args'_v3730 = v3827 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3831 : US3 = US3_0
    let v3832 : US4 = US4_4(v3831)
    let v3833 : string = $"date_time.get_utc_offset / target: {v3832}"
    let v3834 : System.TimeSpan = failwith<System.TimeSpan> v3833
    let _run_target_args'_v3730 = v3834 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3838 : US3 = US3_0
    let v3839 : US4 = US4_5(v3838)
    let v3840 : string = $"date_time.get_utc_offset / target: {v3839}"
    let v3841 : System.TimeSpan = failwith<System.TimeSpan> v3840
    let _run_target_args'_v3730 = v3841 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3844 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3849 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3850 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3851 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3850 
    let _run_target_args'_v3849 = v3851 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3853 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3853 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3857 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3857 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3861 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3861 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3865 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3849 = v3865 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3868 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3849 = v3868 
    #endif
#else
    let v3869 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3849 = v3869 
    #endif
    let v3870 : System.TimeZoneInfo = _run_target_args'_v3849 
    let v3876 : (System.DateTime -> System.TimeSpan) = v3844 v3870
    let v3877 : System.TimeSpan = v3876 v1
    let _run_target_args'_v3730 = v3877 
    #endif
#else
    let v3878 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3883 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3884 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3885 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3884 
    let _run_target_args'_v3883 = v3885 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3887 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3887 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3891 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3895 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3899 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3883 = v3899 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3902 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3883 = v3902 
    #endif
#else
    let v3903 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3883 = v3903 
    #endif
    let v3904 : System.TimeZoneInfo = _run_target_args'_v3883 
    let v3910 : (System.DateTime -> System.TimeSpan) = v3878 v3904
    let v3911 : System.TimeSpan = v3910 v1
    let _run_target_args'_v3730 = v3911 
    #endif
    let v3912 : System.TimeSpan = _run_target_args'_v3730 
    let v3922 : (System.TimeSpan -> int32) = _.Hours
    let v3923 : int32 = v3922 v3912
    let v3926 : bool = v3923 > 0
    let v3927 : uint8 =
        if v3926 then
            1uy
        else
            0uy
    let v3928 : string = method86()
    (* run_target_args'
    let v3982 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3983 : string = "$0.toString($1)"
    let v3984 : string = Fable.Core.RustInterop.emitRustExpr struct (v3912, v3928) v3983 
    let _run_target_args'_v3982 = v3984 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3985 : string = "$0.toString($1)"
    let v3986 : string = Fable.Core.RustInterop.emitRustExpr struct (v3912, v3928) v3985 
    let _run_target_args'_v3982 = v3986 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3987 : string = "$0.toString($1)"
    let v3988 : string = Fable.Core.RustInterop.emitRustExpr struct (v3912, v3928) v3987 
    let _run_target_args'_v3982 = v3988 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3989 : string = v3912.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3982 = v3989 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3990 : string = v3912.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3982 = v3990 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3992 : string = v3912.ToString v3928 
    let _run_target_args'_v3982 = v3992 
    #endif
#else
    let v4045 : string = v3912.ToString v3928 
    let _run_target_args'_v3982 = v4045 
    #endif
    let v4097 : string = _run_target_args'_v3982 
    let v4152 : string = $"{v3927}{v4097}"
    let v4154 : (System.Guid -> string) = _.ToString()
    let v4155 : string = v4154 v0
    let v4158 : int32 = v3677.Length
    let v4159 : int32 = v4152.Length
    let v4160 : int32 = v4158 + v4159
    let v4162 : (string -> int32) = String.length
    let v4163 : int32 = v4162 v4155
    let v4171 : int32 = v4160 |> int32 
    let v4184 : int32 = v4163 |> int32 
    let v4192 : int32 = v4184 - 1
    let v4194 : string = v4155.[int v4171..int v4192]
    let v4198 : string = $"{v3677}{v4152}{v4194}"
    (* run_target_args'
    let v4203 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4205 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4205 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4209 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4209 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4213 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4203 = v4213 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4217 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4217 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4221 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4221 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4225 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4225 
    #endif
#else
    let v4229 : System.Guid = v4198 |> System.Guid 
    let _run_target_args'_v4203 = v4229 
    #endif
    let v4232 : System.Guid = _run_target_args'_v4203 
    let _run_target_args'_v569 = v4232 
    #endif
    let v4238 : System.Guid = _run_target_args'_v569 
    v4238
and method88 () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = "std::env::temp_dir()"
    let v6 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr () v5 
    (* run_target_args'
    let v11 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v12 : string = "$0.display()"
    let v13 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v6 v12 
    let _run_target_args'_v11 = v13 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v14 : string = "$0.display()"
    let v15 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v6 v14 
    let _run_target_args'_v11 = v15 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : string = "$0.display()"
    let v17 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v6 v16 
    let _run_target_args'_v11 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : std_path_Display = v6 |> unbox<std_path_Display>
    let _run_target_args'_v11 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : std_path_Display = v6 |> unbox<std_path_Display>
    let _run_target_args'_v11 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : std_path_Display = v6 |> unbox<std_path_Display>
    let _run_target_args'_v11 = v27 
    #endif
#else
    let v31 : std_path_Display = v6 |> unbox<std_path_Display>
    let _run_target_args'_v11 = v31 
    #endif
    let v34 : std_path_Display = _run_target_args'_v11 
    (* run_target_args'
    let v44 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v45 : string = "format!(\"{}\", $0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v45 
    let _run_target_args'_v44 = v46 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v47 : string = "format!(\"{}\", $0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v47 
    let _run_target_args'_v44 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "format!(\"{}\", $0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v49 
    let _run_target_args'_v44 = v50 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v52 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v44 = v52 
    #endif
#if FABLE_COMPILER_PYTHON
    let v56 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v44 = v56 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v60 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v44 = v60 
    #endif
#else
    let v64 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v44 = v64 
    #endif
    let v67 : std_string_String = _run_target_args'_v44 
    let v73 : string = "fable_library_rust::String_::fromString($0)"
    let v74 : string = Fable.Core.RustInterop.emitRustExpr v67 v73 
    let _run_target_args'_v4 = v74 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v75 : US3 = US3_1
    let v76 : US4 = US4_3(v75)
    let v77 : string = $"file_system.get_temp_path / target: {v76}"
    let v78 : string = failwith<string> v77
    let _run_target_args'_v4 = v78 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v80 : string = null |> unbox<string>
    let _run_target_args'_v4 = v80 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v83 : US3 = US3_0
    let v84 : US4 = US4_4(v83)
    let v85 : string = $"file_system.get_temp_path / target: {v84}"
    let v86 : string = failwith<string> v85
    let _run_target_args'_v4 = v86 
    #endif
#if FABLE_COMPILER_PYTHON
    let v87 : US3 = US3_0
    let v88 : US4 = US4_5(v87)
    let v89 : string = $"file_system.get_temp_path / target: {v88}"
    let v90 : string = failwith<string> v89
    let _run_target_args'_v4 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v91 : US3 = US3_1
    let v92 : US4 = US4_1(v91)
    let v93 : string = $"file_system.get_temp_path / target: {v92}"
    let v94 : string = failwith<string> v93
    let _run_target_args'_v4 = v94 
    #endif
#else
    let v95 : (unit -> string) = System.IO.Path.GetTempPath
    let v96 : string = v95 ()
    let _run_target_args'_v4 = v96 
    #endif
    let v97 : string = _run_target_args'_v4 
    v97
and method89 () : string =
    let v0 : string = "!create_temp_path_"
    v0
and method90 (v0 : string, v1 : string) : string =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v11 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v12 : string = "&*$0"
    let v13 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let _run_target_args'_v11 = v13 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v14 : string = "&*$0"
    let v15 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v14 
    let _run_target_args'_v11 = v15 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : string = "&*$0"
    let v17 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v16 
    let _run_target_args'_v11 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v11 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v11 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v11 = v27 
    #endif
#else
    let v31 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v11 = v31 
    #endif
    let v34 : Ref<Str> = _run_target_args'_v11 
    (* run_target_args'
    let v44 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v45 : string = "String::from($0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v45 
    let _run_target_args'_v44 = v46 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v47 : string = "String::from($0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v47 
    let _run_target_args'_v44 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v49 
    let _run_target_args'_v44 = v50 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v52 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v44 = v52 
    #endif
#if FABLE_COMPILER_PYTHON
    let v56 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v44 = v56 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v44 = v60 
    #endif
#else
    let v64 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v44 = v64 
    #endif
    let v67 : std_string_String = _run_target_args'_v44 
    (* run_target_args'
    let v77 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v78 : string = "std::path::PathBuf::from($0)"
    let v79 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v67 v78 
    let _run_target_args'_v77 = v79 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v80 : string = "std::path::PathBuf::from($0)"
    let v81 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v67 v80 
    let _run_target_args'_v77 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "std::path::PathBuf::from($0)"
    let v83 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v67 v82 
    let _run_target_args'_v77 = v83 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v85 : std_path_PathBuf = v67 |> unbox<std_path_PathBuf>
    let _run_target_args'_v77 = v85 
    #endif
#if FABLE_COMPILER_PYTHON
    let v89 : std_path_PathBuf = v67 |> unbox<std_path_PathBuf>
    let _run_target_args'_v77 = v89 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v93 : std_path_PathBuf = v67 |> unbox<std_path_PathBuf>
    let _run_target_args'_v77 = v93 
    #endif
#else
    let v97 : std_path_PathBuf = v67 |> unbox<std_path_PathBuf>
    let _run_target_args'_v77 = v97 
    #endif
    let v100 : std_path_PathBuf = _run_target_args'_v77 
    (* run_target_args'
    let v110 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v111 : string = "&*$0"
    let v112 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v111 
    let _run_target_args'_v110 = v112 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v113 : string = "&*$0"
    let v114 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v113 
    let _run_target_args'_v110 = v114 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v115 : string = "&*$0"
    let v116 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v115 
    let _run_target_args'_v110 = v116 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v118 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v110 = v118 
    #endif
#if FABLE_COMPILER_PYTHON
    let v122 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v110 = v122 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v126 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v110 = v126 
    #endif
#else
    let v130 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v110 = v130 
    #endif
    let v133 : Ref<Str> = _run_target_args'_v110 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "String::from($0)"
    let v145 : std_string_String = Fable.Core.RustInterop.emitRustExpr v133 v144 
    let _run_target_args'_v143 = v145 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v146 : string = "String::from($0)"
    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v133 v146 
    let _run_target_args'_v143 = v147 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v148 : string = "String::from($0)"
    let v149 : std_string_String = Fable.Core.RustInterop.emitRustExpr v133 v148 
    let _run_target_args'_v143 = v149 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v151 : std_string_String = v133 |> unbox<std_string_String>
    let _run_target_args'_v143 = v151 
    #endif
#if FABLE_COMPILER_PYTHON
    let v155 : std_string_String = v133 |> unbox<std_string_String>
    let _run_target_args'_v143 = v155 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v159 : std_string_String = v133 |> unbox<std_string_String>
    let _run_target_args'_v143 = v159 
    #endif
#else
    let v163 : std_string_String = v133 |> unbox<std_string_String>
    let _run_target_args'_v143 = v163 
    #endif
    let v166 : std_string_String = _run_target_args'_v143 
    let v172 : string = "$0.join($1)"
    let v173 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr struct (v100, v166) v172 
    (* run_target_args'
    let v178 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v179 : string = "$0.display()"
    let v180 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v173 v179 
    let _run_target_args'_v178 = v180 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v181 : string = "$0.display()"
    let v182 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v173 v181 
    let _run_target_args'_v178 = v182 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v183 : string = "$0.display()"
    let v184 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v173 v183 
    let _run_target_args'_v178 = v184 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v186 : std_path_Display = v173 |> unbox<std_path_Display>
    let _run_target_args'_v178 = v186 
    #endif
#if FABLE_COMPILER_PYTHON
    let v190 : std_path_Display = v173 |> unbox<std_path_Display>
    let _run_target_args'_v178 = v190 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v194 : std_path_Display = v173 |> unbox<std_path_Display>
    let _run_target_args'_v178 = v194 
    #endif
#else
    let v198 : std_path_Display = v173 |> unbox<std_path_Display>
    let _run_target_args'_v178 = v198 
    #endif
    let v201 : std_path_Display = _run_target_args'_v178 
    (* run_target_args'
    let v211 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v212 : string = "format!(\"{}\", $0)"
    let v213 : std_string_String = Fable.Core.RustInterop.emitRustExpr v201 v212 
    let _run_target_args'_v211 = v213 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v214 : string = "format!(\"{}\", $0)"
    let v215 : std_string_String = Fable.Core.RustInterop.emitRustExpr v201 v214 
    let _run_target_args'_v211 = v215 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v216 : string = "format!(\"{}\", $0)"
    let v217 : std_string_String = Fable.Core.RustInterop.emitRustExpr v201 v216 
    let _run_target_args'_v211 = v217 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v219 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v211 = v219 
    #endif
#if FABLE_COMPILER_PYTHON
    let v223 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v211 = v223 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v227 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v211 = v227 
    #endif
#else
    let v231 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v211 = v231 
    #endif
    let v234 : std_string_String = _run_target_args'_v211 
    let v240 : string = "fable_library_rust::String_::fromString($0)"
    let v241 : string = Fable.Core.RustInterop.emitRustExpr v234 v240 
    let _run_target_args'_v6 = v241 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v242 : US3 = US3_1
    let v243 : US4 = US4_3(v242)
    let v244 : string = $"file_system.(</>) / target: {v243} / a: {v0} / b: {v1}"
    let v245 : string = failwith<string> v244
    let _run_target_args'_v6 = v245 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v247 : string = null |> unbox<string>
    let _run_target_args'_v6 = v247 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v250 : string = "path"
    let v251 : IPathJoin = Fable.Core.JsInterop.importAll v250 
    let v252 : string = "v251.join($0, $1)"
    let v253 : string = Fable.Core.JsInterop.emitJsExpr struct (v0, v1) v252 
    let _run_target_args'_v6 = v253 
    #endif
#if FABLE_COMPILER_PYTHON
    let v254 : US3 = US3_0
    let v255 : US4 = US4_5(v254)
    let v256 : string = $"file_system.(</>) / target: {v255} / a: {v0} / b: {v1}"
    let v257 : string = failwith<string> v256
    let _run_target_args'_v6 = v257 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v258 : US3 = US3_1
    let v259 : US4 = US4_1(v258)
    let v260 : string = $"file_system.(</>) / target: {v259} / a: {v0} / b: {v1}"
    let v261 : string = failwith<string> v260
    let _run_target_args'_v6 = v261 
    #endif
#else
    let v262 : string = System.IO.Path.Combine (v0, v1)
    let _run_target_args'_v6 = v262 
    #endif
    let v263 : string = _run_target_args'_v6 
    v263
and method92 () : string =
    let v0 : string = "CARGO_PKG_NAME"
    v0
and method91 () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = method92()
    let v6 : string = method2(v5)
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : string = method92()
    let v8 : string = method2(v7)
    let _run_target_args'_v4 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : string = method92()
    let v10 : string = method2(v9)
    let _run_target_args'_v4 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : US3 = US3_0
    let v12 : US4 = US4_4(v11)
    let v13 : string = $"env.get_entry_assembly_name / target: {v12}"
    let v14 : string = failwith<string> v13
    let _run_target_args'_v4 = v14 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : US3 = US3_0
    let v16 : US4 = US4_5(v15)
    let v17 : string = $"env.get_entry_assembly_name / target: {v16}"
    let v18 : string = failwith<string> v17
    let _run_target_args'_v4 = v18 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v19 : string = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
    let _run_target_args'_v4 = v19 
    #endif
#else
    let v20 : string = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
    let _run_target_args'_v4 = v20 
    #endif
    let v21 : string = _run_target_args'_v4 
    v21
and method87 (v0 : System.Guid) : string =
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = method88()
    let v14 : string = method89()
    let v15 : string = method90(v13, v14)
    let v16 : string = method91()
    let v17 : string = method90(v15, v16)
    let v19 : (System.Guid -> string) = _.ToString()
    let v20 : string = v19 v0
    let v23 : string = method90(v17, v20)
    let _run_target_args'_v12 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v24 : string = method88()
    let v25 : string = method89()
    let v26 : string = method90(v24, v25)
    let v27 : string = method91()
    let v28 : string = method90(v26, v27)
    let v30 : (System.Guid -> string) = _.ToString()
    let v31 : string = v30 v0
    let v34 : string = method90(v28, v31)
    let _run_target_args'_v12 = v34 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = null |> unbox<string>
    let _run_target_args'_v12 = v36 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v39 : string = method88()
    let v40 : string = method89()
    let v41 : string = method90(v39, v40)
    let v42 : string = method91()
    let v43 : string = method90(v41, v42)
    let v45 : (System.Guid -> string) = _.ToString()
    let v46 : string = v45 v0
    let v49 : string = method90(v43, v46)
    let _run_target_args'_v12 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v50 : string = method88()
    let v51 : string = method89()
    let v52 : string = method90(v50, v51)
    let v53 : string = method91()
    let v54 : string = method90(v52, v53)
    let v56 : (System.Guid -> string) = _.ToString()
    let v57 : string = v56 v0
    let v60 : string = method90(v54, v57)
    let _run_target_args'_v12 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v61 : string = method88()
    let v62 : string = method89()
    let v63 : string = method90(v61, v62)
    let v64 : string = method91()
    let v65 : string = method90(v63, v64)
    let v67 : (System.Guid -> string) = _.ToString()
    let v68 : string = v67 v0
    let v71 : string = method90(v65, v68)
    let _run_target_args'_v12 = v71 
    #endif
#else
    let v72 : string = method88()
    let v73 : string = method89()
    let v74 : string = method90(v72, v73)
    let v75 : string = method91()
    let v76 : string = method90(v74, v75)
    let v78 : (System.Guid -> string) = _.ToString()
    let v79 : string = v78 v0
    let v82 : string = method90(v76, v79)
    let _run_target_args'_v12 = v82 
    #endif
    let v83 : string = _run_target_args'_v12 
    v83
and method81 () : string =
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v28 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v29 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v28 = v29 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v30 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v28 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v32 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v28 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v35 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v28 = v35 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v28 = v36 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v37 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v28 = v37 
    #endif
#else
    let v38 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v28 = v38 
    #endif
    let v39 : System.DateTime = _run_target_args'_v28 
    let v45 : (unit -> System.Guid) = System.Guid.NewGuid
    let v46 : System.Guid = v45 ()
    let v49 : System.Guid = method82(v46, v39)
    let v50 : string = method87(v49)
    let _run_target_args'_v25 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v53 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v54 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v53 = v54 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v55 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v53 = v55 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v57 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v53 = v57 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v60 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v53 = v60 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v53 = v61 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v53 = v62 
    #endif
#else
    let v63 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v53 = v63 
    #endif
    let v64 : System.DateTime = _run_target_args'_v53 
    let v70 : (unit -> System.Guid) = System.Guid.NewGuid
    let v71 : System.Guid = v70 ()
    let v74 : System.Guid = method82(v71, v64)
    let v75 : string = method87(v74)
    let _run_target_args'_v25 = v75 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v77 : string = null |> unbox<string>
    let _run_target_args'_v25 = v77 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v82 = v83 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v84 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v82 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v86 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v89 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v82 = v89 
    #endif
#if FABLE_COMPILER_PYTHON
    let v90 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v82 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v91 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v82 = v91 
    #endif
#else
    let v92 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v82 = v92 
    #endif
    let v93 : System.DateTime = _run_target_args'_v82 
    let v99 : (unit -> System.Guid) = System.Guid.NewGuid
    let v100 : System.Guid = v99 ()
    let v103 : System.Guid = method82(v100, v93)
    let v104 : string = method87(v103)
    let _run_target_args'_v25 = v104 
    #endif
#if FABLE_COMPILER_PYTHON
    (* run_target_args'
    let v107 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v108 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v107 = v108 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v109 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v107 = v109 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v111 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v107 = v111 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v114 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v107 = v114 
    #endif
#if FABLE_COMPILER_PYTHON
    let v115 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v107 = v115 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v116 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v107 = v116 
    #endif
#else
    let v117 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v107 = v117 
    #endif
    let v118 : System.DateTime = _run_target_args'_v107 
    let v124 : (unit -> System.Guid) = System.Guid.NewGuid
    let v125 : System.Guid = v124 ()
    let v128 : System.Guid = method82(v125, v118)
    let v129 : string = method87(v128)
    let _run_target_args'_v25 = v129 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    (* run_target_args'
    let v132 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v133 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v132 = v133 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v134 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v132 = v134 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v132 = v136 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v139 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v132 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v132 = v140 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v141 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v132 = v141 
    #endif
#else
    let v142 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v132 = v142 
    #endif
    let v143 : System.DateTime = _run_target_args'_v132 
    let v149 : (unit -> System.Guid) = System.Guid.NewGuid
    let v150 : System.Guid = v149 ()
    let v153 : System.Guid = method82(v150, v143)
    let v154 : string = method87(v153)
    let _run_target_args'_v25 = v154 
    #endif
#else
    (* run_target_args'
    let v157 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v158 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v157 = v158 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v159 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v157 = v159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v161 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v157 = v161 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v164 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v157 = v164 
    #endif
#if FABLE_COMPILER_PYTHON
    let v165 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v157 = v165 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v157 = v166 
    #endif
#else
    let v167 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v157 = v167 
    #endif
    let v168 : System.DateTime = _run_target_args'_v157 
    let v174 : (unit -> System.Guid) = System.Guid.NewGuid
    let v175 : System.Guid = v174 ()
    let v178 : System.Guid = method82(v175, v168)
    let v179 : string = method87(v178)
    let _run_target_args'_v25 = v179 
    #endif
    let v180 : string = _run_target_args'_v25 
    v180
and closure37 () () : string =
    method81()
and closure40 () (v0 : std_io_Error) : std_string_String =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "format!(\"{}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v6 
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "format!(\"{}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : string = "format!(\"{}\", $0)"
    let v11 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v10 
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v17 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v17 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v21 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v21 
    #endif
#else
    let v25 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v5 = v25 
    #endif
    let v28 : std_string_String = _run_target_args'_v5 
    v28
and method94 () : (std_io_Error -> std_string_String) =
    closure40()
and closure41 () () : US13 =
    US13_0
and method95 () : (unit -> US13) =
    closure41()
and closure42 () (v0 : std_string_String) : US13 =
    US13_1(v0)
and method96 () : (std_string_String -> US13) =
    closure42()
and method98 (v0 : string, v1 : std_string_String) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "dir"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "error"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "format!(\"{:#?}\", $0)"
    let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v77 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v78 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v81 : string = "format!(\"{:#?}\", $0)"
    let v82 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v81 
    let v83 : string = "fable_library_rust::String_::fromString($0)"
    let v84 : string = Fable.Core.RustInterop.emitRustExpr v82 v83 
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v85 : string = "format!(\"{:#?}\", $0)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v76 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : string = $"%A{v1}"
    let _run_target_args'_v76 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : string = $"%A{v1}"
    let _run_target_args'_v76 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : string = $"%A{v1}"
    let _run_target_args'_v76 = v98 
    #endif
#else
    let v102 : string = $"%A{v1}"
    let _run_target_args'_v76 = v102 
    #endif
    let v105 : string = _run_target_args'_v76 
    let v112 : string = $"{v105}"
    let v115 : unit = ()
    let v116 : (unit -> unit) = closure6(v3, v112)
    let v117 : unit = (fun () -> v116 (); v115) ()
    let v121 : string = " }"
    let v122 : string = $"{v121}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure6(v3, v122)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v130 : string = v3.l0
    v130
and method97 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : std_string_String) : string =
    let v10 : string = method98(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "file_system.create_dir"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure43 (v0 : string, v1 : std_string_String) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method52()
        let v47 : string = method97(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method24(v47)
and method100 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v2, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v14 : string = "dir"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure6(v2, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v24 : string = " = "
    let v25 : string = $"{v24}"
    let v28 : unit = ()
    let v29 : (unit -> unit) = closure6(v2, v25)
    let v30 : unit = (fun () -> v29 (); v28) ()
    let v34 : string = $"{v0}"
    let v37 : unit = ()
    let v38 : (unit -> unit) = closure6(v2, v34)
    let v39 : unit = (fun () -> v38 (); v37) ()
    let v43 : string = " }"
    let v44 : string = $"{v43}"
    let v47 : unit = ()
    let v48 : (unit -> unit) = closure6(v2, v44)
    let v49 : unit = (fun () -> v48 (); v47) ()
    let v52 : string = v2.l0
    v52
and method99 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method100(v8)
    let v10 : int64 = v0.l0
    let v12 : string = "file_system.create_dir"
    let v13 : string = $"{v6} {v7} #{v10} %s{v12} / {v9}"
    method23(v13)
and closure44 (v0 : string) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method11(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
        let v44 : string = method12(v26, v27, v28, v29, v30, v31)
        let v45 : string = method34()
        let v46 : string = method99(v26, v27, v28, v29, v30, v31, v44, v45, v0)
        method24(v46)
and closure45 (v0 : string) () : unit =
    let v1 : bool = true
    method9(v1, v0)
and method101 (v0 : string) : (unit -> unit) =
    closure45(v0)
and method102 (v0 : string) : (unit -> unit) =
    closure45(v0)
and method103 (v0 : string) : System_IO_DirectoryInfo =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v30 : (string -> System_IO_DirectoryInfo) = System.IO.Directory.CreateDirectory
    let v31 : System_IO_DirectoryInfo = v30 v0
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : System_IO_DirectoryInfo = _run_target_args'_v5 
    v32
and method105 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "dir"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "result"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure6(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method104 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method105(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "file_system.create_dir"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure46 (v0 : string, v1 : string) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method16()
        let v47 : string = method104(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method24(v47)
and closure47 (v0 : string) () : unit =
    let v1 : Async<int64> = method6(v0)
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v20 : Async<unit> = v19 v1
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v21 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v22 : Async<unit> = v21 v1
    let _run_target_args'_v6 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v24 : Async<unit> = v23 v1
    let _run_target_args'_v6 = v24 
    #endif
#else
    let v25 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v26 : Async<unit> = v25 v1
    let _run_target_args'_v6 = v26 
    #endif
    let v27 : Async<unit> = _run_target_args'_v6 
    (* run_target_args'
    let v33 : unit = ()
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
    null |> unbox<unit>
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : (Async<unit> -> unit) = Async.RunSynchronously
    v34 v27
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : (Async<unit> -> unit) = Async.RunSynchronously
    v35 v27
    #endif
#else
    let v36 : (Async<unit> -> unit) = Async.RunSynchronously
    v36 v27
    #endif
    // run_target_args' is_unit
    ()
and method106 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method107 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method93 (v0 : string) : System.IDisposable =
    (* run_target_args'
    let v154 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v155 : string = "std::fs::create_dir_all(&*$0)"
    let v156 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v155 
    let v157 : (std_io_Error -> std_string_String) = method94()
    (* run_target_args'
    let v159 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v160 : string = "$0.map_err(|x| $1(x))"
    let v161 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v156, v157) v160 
    let _run_target_args'_v159 = v161 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v162 : string = "$0.map_err(|x| $1(x))"
    let v163 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v156, v157) v162 
    let _run_target_args'_v159 = v163 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v164 : string = "$0.map_err(|x| $1(x))"
    let v165 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v156, v157) v164 
    let _run_target_args'_v159 = v165 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v166 : Result<unit, std_string_String> = match v156 with Ok x -> Ok x | Error x -> Error (v157 x)
    let _run_target_args'_v159 = v166 
    #endif
#if FABLE_COMPILER_PYTHON
    let v167 : Result<unit, std_string_String> = match v156 with Ok x -> Ok x | Error x -> Error (v157 x)
    let _run_target_args'_v159 = v167 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v168 : Result<unit, std_string_String> = match v156 with Ok x -> Ok x | Error x -> Error (v157 x)
    let _run_target_args'_v159 = v168 
    #endif
#else
    let v169 : Result<unit, std_string_String> = match v156 with Ok x -> Ok x | Error x -> Error (v157 x)
    let _run_target_args'_v159 = v169 
    #endif
    let v170 : Result<unit, std_string_String> = _run_target_args'_v159 
    let v173 : (unit -> US13) = method95()
    let v174 : (std_string_String -> US13) = method96()
    let v175 : US13 = match v170 with Ok () -> v173 () | Error x -> v174 x
    match v175 with
    | US13_1(v225) -> (* Error *)
        let v226 : unit = ()
        let v227 : (unit -> unit) = closure43(v0, v225)
        let v228 : unit = (fun () -> v227 (); v226) ()
        ()
    | US13_0 -> (* Ok *)
        let v176 : unit = ()
        let v177 : (unit -> unit) = closure44(v0)
        let v178 : unit = (fun () -> v177 (); v176) ()
        ()
    (* run_target_args'
    let v279 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v280 : (unit -> unit) = method101(v0)
    let v281 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v280 "$0()" )
    let _run_target_args'_v279 = v281 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v282 : (unit -> unit) = method101(v0)
    let v283 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v282 "$0()" )
    let _run_target_args'_v279 = v283 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v284 : (unit -> unit) = method101(v0)
    let v285 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v284 "$0()" )
    let _run_target_args'_v279 = v285 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v286 : (unit -> unit) = method102(v0)
    let v287 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v286 () }
    let _run_target_args'_v279 = v287 
    #endif
#if FABLE_COMPILER_PYTHON
    let v288 : (unit -> unit) = method102(v0)
    let v289 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v288 () }
    let _run_target_args'_v279 = v289 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v290 : (unit -> unit) = method102(v0)
    let v291 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v290 () }
    let _run_target_args'_v279 = v291 
    #endif
#else
    let v292 : (unit -> unit) = method102(v0)
    let v293 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v292 () }
    let _run_target_args'_v279 = v293 
    #endif
    let v294 : System.IDisposable = _run_target_args'_v279 
    let _run_target_args'_v154 = v294 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v299 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v154 = v299 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v303 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v154 = v303 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v306 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v311 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v313 : bool = null |> unbox<bool>
    let _run_target_args'_v311 = v313 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v317 : bool = null |> unbox<bool>
    let _run_target_args'_v311 = v317 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v321 : bool = null |> unbox<bool>
    let _run_target_args'_v311 = v321 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v325 : bool = null |> unbox<bool>
    let _run_target_args'_v311 = v325 
    #endif
#if FABLE_COMPILER_PYTHON
    let v329 : bool = null |> unbox<bool>
    let _run_target_args'_v311 = v329 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v333 : bool = null |> unbox<bool>
    let _run_target_args'_v311 = v333 
    #endif
#else
    let v336 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v337 : bool = v336 v306
    let _run_target_args'_v311 = v337 
    #endif
    let v338 : bool = _run_target_args'_v311 
    let v344 : bool = v338 = false
    if v344 then
        (* run_target_args'
        let v349 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v351 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v349 = v351 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v355 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v349 = v355 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v359 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v349 = v359 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v363 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v349 = v363 
        #endif
#if FABLE_COMPILER_PYTHON
        let v367 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v349 = v367 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v371 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v349 = v371 
        #endif
#else
        let v374 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v375 : System.DateTime = v374 v306
        let _run_target_args'_v349 = v375 
        #endif
        let v376 : System.DateTime = _run_target_args'_v349 
        let v382 : _ = {| Exists = v338; CreationTime = v376 |}
        let v384 : string = $"%A{v382}"
        let v387 : unit = ()
        let v388 : (unit -> unit) = closure46(v0, v384)
        let v389 : unit = (fun () -> v388 (); v387) ()
        ()
    (* run_target_args'
    let v440 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v441 : (unit -> unit) = method106(v0)
    let v442 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v441 "$0()" )
    let _run_target_args'_v440 = v442 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v443 : (unit -> unit) = method106(v0)
    let v444 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v443 "$0()" )
    let _run_target_args'_v440 = v444 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v445 : (unit -> unit) = method106(v0)
    let v446 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v445 "$0()" )
    let _run_target_args'_v440 = v446 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v447 : (unit -> unit) = method107(v0)
    let v448 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v447 () }
    let _run_target_args'_v440 = v448 
    #endif
#if FABLE_COMPILER_PYTHON
    let v449 : (unit -> unit) = method107(v0)
    let v450 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v449 () }
    let _run_target_args'_v440 = v450 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v451 : (unit -> unit) = method107(v0)
    let v452 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v451 () }
    let _run_target_args'_v440 = v452 
    #endif
#else
    let v453 : (unit -> unit) = method107(v0)
    let v454 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v453 () }
    let _run_target_args'_v440 = v454 
    #endif
    let v455 : System.IDisposable = _run_target_args'_v440 
    let _run_target_args'_v154 = v455 
    #endif
#if FABLE_COMPILER_PYTHON
    let v459 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v464 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v466 : bool = null |> unbox<bool>
    let _run_target_args'_v464 = v466 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v470 : bool = null |> unbox<bool>
    let _run_target_args'_v464 = v470 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v474 : bool = null |> unbox<bool>
    let _run_target_args'_v464 = v474 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v478 : bool = null |> unbox<bool>
    let _run_target_args'_v464 = v478 
    #endif
#if FABLE_COMPILER_PYTHON
    let v482 : bool = null |> unbox<bool>
    let _run_target_args'_v464 = v482 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v486 : bool = null |> unbox<bool>
    let _run_target_args'_v464 = v486 
    #endif
#else
    let v489 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v490 : bool = v489 v459
    let _run_target_args'_v464 = v490 
    #endif
    let v491 : bool = _run_target_args'_v464 
    let v497 : bool = v491 = false
    if v497 then
        (* run_target_args'
        let v502 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v504 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v502 = v504 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v508 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v502 = v508 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v512 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v502 = v512 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v516 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v502 = v516 
        #endif
#if FABLE_COMPILER_PYTHON
        let v520 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v502 = v520 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v524 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v502 = v524 
        #endif
#else
        let v527 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v528 : System.DateTime = v527 v459
        let _run_target_args'_v502 = v528 
        #endif
        let v529 : System.DateTime = _run_target_args'_v502 
        let v535 : _ = {| Exists = v491; CreationTime = v529 |}
        let v537 : string = $"%A{v535}"
        let v540 : unit = ()
        let v541 : (unit -> unit) = closure46(v0, v537)
        let v542 : unit = (fun () -> v541 (); v540) ()
        ()
    (* run_target_args'
    let v593 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v594 : (unit -> unit) = method106(v0)
    let v595 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v594 "$0()" )
    let _run_target_args'_v593 = v595 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v596 : (unit -> unit) = method106(v0)
    let v597 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v596 "$0()" )
    let _run_target_args'_v593 = v597 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v598 : (unit -> unit) = method106(v0)
    let v599 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v598 "$0()" )
    let _run_target_args'_v593 = v599 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v600 : (unit -> unit) = method107(v0)
    let v601 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v600 () }
    let _run_target_args'_v593 = v601 
    #endif
#if FABLE_COMPILER_PYTHON
    let v602 : (unit -> unit) = method107(v0)
    let v603 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v602 () }
    let _run_target_args'_v593 = v603 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v604 : (unit -> unit) = method107(v0)
    let v605 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v604 () }
    let _run_target_args'_v593 = v605 
    #endif
#else
    let v606 : (unit -> unit) = method107(v0)
    let v607 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v606 () }
    let _run_target_args'_v593 = v607 
    #endif
    let v608 : System.IDisposable = _run_target_args'_v593 
    let _run_target_args'_v154 = v608 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v612 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v617 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v619 : bool = null |> unbox<bool>
    let _run_target_args'_v617 = v619 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v623 : bool = null |> unbox<bool>
    let _run_target_args'_v617 = v623 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v627 : bool = null |> unbox<bool>
    let _run_target_args'_v617 = v627 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v631 : bool = null |> unbox<bool>
    let _run_target_args'_v617 = v631 
    #endif
#if FABLE_COMPILER_PYTHON
    let v635 : bool = null |> unbox<bool>
    let _run_target_args'_v617 = v635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v639 : bool = null |> unbox<bool>
    let _run_target_args'_v617 = v639 
    #endif
#else
    let v642 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v643 : bool = v642 v612
    let _run_target_args'_v617 = v643 
    #endif
    let v644 : bool = _run_target_args'_v617 
    let v650 : bool = v644 = false
    if v650 then
        (* run_target_args'
        let v655 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v657 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v655 = v657 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v661 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v655 = v661 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v665 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v655 = v665 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v669 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v655 = v669 
        #endif
#if FABLE_COMPILER_PYTHON
        let v673 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v655 = v673 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v677 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v655 = v677 
        #endif
#else
        let v680 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v681 : System.DateTime = v680 v612
        let _run_target_args'_v655 = v681 
        #endif
        let v682 : System.DateTime = _run_target_args'_v655 
        let v688 : _ = {| Exists = v644; CreationTime = v682 |}
        let v690 : string = $"%A{v688}"
        let v693 : unit = ()
        let v694 : (unit -> unit) = closure46(v0, v690)
        let v695 : unit = (fun () -> v694 (); v693) ()
        ()
    (* run_target_args'
    let v746 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v747 : (unit -> unit) = method106(v0)
    let v748 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v747 "$0()" )
    let _run_target_args'_v746 = v748 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v749 : (unit -> unit) = method106(v0)
    let v750 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v749 "$0()" )
    let _run_target_args'_v746 = v750 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v751 : (unit -> unit) = method106(v0)
    let v752 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v751 "$0()" )
    let _run_target_args'_v746 = v752 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v753 : (unit -> unit) = method107(v0)
    let v754 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v753 () }
    let _run_target_args'_v746 = v754 
    #endif
#if FABLE_COMPILER_PYTHON
    let v755 : (unit -> unit) = method107(v0)
    let v756 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v755 () }
    let _run_target_args'_v746 = v756 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v757 : (unit -> unit) = method107(v0)
    let v758 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v757 () }
    let _run_target_args'_v746 = v758 
    #endif
#else
    let v759 : (unit -> unit) = method107(v0)
    let v760 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v759 () }
    let _run_target_args'_v746 = v760 
    #endif
    let v761 : System.IDisposable = _run_target_args'_v746 
    let _run_target_args'_v154 = v761 
    #endif
#else
    let v765 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v770 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v772 : bool = null |> unbox<bool>
    let _run_target_args'_v770 = v772 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v776 : bool = null |> unbox<bool>
    let _run_target_args'_v770 = v776 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v780 : bool = null |> unbox<bool>
    let _run_target_args'_v770 = v780 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v784 : bool = null |> unbox<bool>
    let _run_target_args'_v770 = v784 
    #endif
#if FABLE_COMPILER_PYTHON
    let v788 : bool = null |> unbox<bool>
    let _run_target_args'_v770 = v788 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v792 : bool = null |> unbox<bool>
    let _run_target_args'_v770 = v792 
    #endif
#else
    let v795 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v796 : bool = v795 v765
    let _run_target_args'_v770 = v796 
    #endif
    let v797 : bool = _run_target_args'_v770 
    let v803 : bool = v797 = false
    if v803 then
        (* run_target_args'
        let v808 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v810 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v808 = v810 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v814 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v808 = v814 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v818 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v808 = v818 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v822 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v808 = v822 
        #endif
#if FABLE_COMPILER_PYTHON
        let v826 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v808 = v826 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v830 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v808 = v830 
        #endif
#else
        let v833 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v834 : System.DateTime = v833 v765
        let _run_target_args'_v808 = v834 
        #endif
        let v835 : System.DateTime = _run_target_args'_v808 
        let v841 : _ = {| Exists = v797; CreationTime = v835 |}
        let v843 : string = $"%A{v841}"
        let v846 : unit = ()
        let v847 : (unit -> unit) = closure46(v0, v843)
        let v848 : unit = (fun () -> v847 (); v846) ()
        ()
    (* run_target_args'
    let v899 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v900 : (unit -> unit) = method106(v0)
    let v901 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v900 "$0()" )
    let _run_target_args'_v899 = v901 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v902 : (unit -> unit) = method106(v0)
    let v903 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v902 "$0()" )
    let _run_target_args'_v899 = v903 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v904 : (unit -> unit) = method106(v0)
    let v905 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v904 "$0()" )
    let _run_target_args'_v899 = v905 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v906 : (unit -> unit) = method107(v0)
    let v907 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v906 () }
    let _run_target_args'_v899 = v907 
    #endif
#if FABLE_COMPILER_PYTHON
    let v908 : (unit -> unit) = method107(v0)
    let v909 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v908 () }
    let _run_target_args'_v899 = v909 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v910 : (unit -> unit) = method107(v0)
    let v911 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v910 () }
    let _run_target_args'_v899 = v911 
    #endif
#else
    let v912 : (unit -> unit) = method107(v0)
    let v913 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v912 () }
    let _run_target_args'_v899 = v913 
    #endif
    let v914 : System.IDisposable = _run_target_args'_v899 
    let _run_target_args'_v154 = v914 
    #endif
    let v918 : System.IDisposable = _run_target_args'_v154 
    v918
and closure39 () () : struct (string * System.IDisposable) =
    let v0 : string = method81()
    let v1 : System.IDisposable = method93(v0)
    struct (v0, v1)
and closure49 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method109(v0, v1, v5)
        let v7 : string = v3 + v1 
        v6 v7
and method109 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure49(v0, v1, v2)
and method108 (v0 : string) : System.Guid =
    let v2 : (char -> string) = _.ToString()
    let v3 : string = v2 '0'
    let v6 : int32 = v0.Length
    let v7 : int32 = 32 - v6
    let v8 : int32 = 0
    let v9 : (string -> string) = method109(v7, v3, v8)
    let v10 : string = ""
    let v11 : string = v9 v10
    let v12 : string = v11 + v0 
    (* run_target_args'
    let v213 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : int32 = 0 |> int32 
    let v232 : int32 = 8 |> int32 
    let v240 : int32 = v232 - 1
    let v242 : string = v12.[int v219..int v240]
    let v251 : int32 = 8 |> int32 
    let v264 : int32 = 12 |> int32 
    let v272 : int32 = v264 - 1
    let v274 : string = v12.[int v251..int v272]
    let v283 : int32 = 12 |> int32 
    let v296 : int32 = 16 |> int32 
    let v304 : int32 = v296 - 1
    let v306 : string = v12.[int v283..int v304]
    let v315 : int32 = 16 |> int32 
    let v328 : int32 = 20 |> int32 
    let v336 : int32 = v328 - 1
    let v338 : string = v12.[int v315..int v336]
    let v347 : int32 = 20 |> int32 
    let v360 : int32 = 32 |> int32 
    let v368 : int32 = v360 - 1
    let v370 : string = v12.[int v347..int v368]
    let v374 : string = $"{v242}-{v274}-{v306}-{v338}-{v370}"
    (* run_target_args'
    let v379 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v381 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v381 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v385 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v385 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v389 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v379 = v389 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v393 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v393 
    #endif
#if FABLE_COMPILER_PYTHON
    let v397 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v397 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v401 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v401 
    #endif
#else
    let v405 : System.Guid = v374 |> System.Guid 
    let _run_target_args'_v379 = v405 
    #endif
    let v408 : System.Guid = _run_target_args'_v379 
    let _run_target_args'_v213 = v408 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v419 : int32 = 0 |> int32 
    let v432 : int32 = 8 |> int32 
    let v440 : int32 = v432 - 1
    let v442 : string = v12.[int v419..int v440]
    let v451 : int32 = 8 |> int32 
    let v464 : int32 = 12 |> int32 
    let v472 : int32 = v464 - 1
    let v474 : string = v12.[int v451..int v472]
    let v483 : int32 = 12 |> int32 
    let v496 : int32 = 16 |> int32 
    let v504 : int32 = v496 - 1
    let v506 : string = v12.[int v483..int v504]
    let v515 : int32 = 16 |> int32 
    let v528 : int32 = 20 |> int32 
    let v536 : int32 = v528 - 1
    let v538 : string = v12.[int v515..int v536]
    let v547 : int32 = 20 |> int32 
    let v560 : int32 = 32 |> int32 
    let v568 : int32 = v560 - 1
    let v570 : string = v12.[int v547..int v568]
    let v574 : string = $"{v442}-{v474}-{v506}-{v538}-{v570}"
    (* run_target_args'
    let v579 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v581 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v581 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v585 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v585 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v589 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v579 = v589 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v593 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v597 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v597 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v601 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v601 
    #endif
#else
    let v605 : System.Guid = v574 |> System.Guid 
    let _run_target_args'_v579 = v605 
    #endif
    let v608 : System.Guid = _run_target_args'_v579 
    let _run_target_args'_v213 = v608 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v615 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v213 = v615 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v623 : int32 = 0 |> int32 
    let v636 : int32 = 8 |> int32 
    let v644 : int32 = v636 - 1
    let v646 : string = v12.[int v623..int v644]
    let v655 : int32 = 8 |> int32 
    let v668 : int32 = 12 |> int32 
    let v676 : int32 = v668 - 1
    let v678 : string = v12.[int v655..int v676]
    let v687 : int32 = 12 |> int32 
    let v700 : int32 = 16 |> int32 
    let v708 : int32 = v700 - 1
    let v710 : string = v12.[int v687..int v708]
    let v719 : int32 = 16 |> int32 
    let v732 : int32 = 20 |> int32 
    let v740 : int32 = v732 - 1
    let v742 : string = v12.[int v719..int v740]
    let v751 : int32 = 20 |> int32 
    let v764 : int32 = 32 |> int32 
    let v772 : int32 = v764 - 1
    let v774 : string = v12.[int v751..int v772]
    let v778 : string = $"{v646}-{v678}-{v710}-{v742}-{v774}"
    (* run_target_args'
    let v783 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v785 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v785 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v789 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v789 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v793 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v783 = v793 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v797 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v797 
    #endif
#if FABLE_COMPILER_PYTHON
    let v801 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v801 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v805 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v805 
    #endif
#else
    let v809 : System.Guid = v778 |> System.Guid 
    let _run_target_args'_v783 = v809 
    #endif
    let v812 : System.Guid = _run_target_args'_v783 
    let _run_target_args'_v213 = v812 
    #endif
#if FABLE_COMPILER_PYTHON
    let v823 : int32 = 0 |> int32 
    let v836 : int32 = 8 |> int32 
    let v844 : int32 = v836 - 1
    let v846 : string = v12.[int v823..int v844]
    let v855 : int32 = 8 |> int32 
    let v868 : int32 = 12 |> int32 
    let v876 : int32 = v868 - 1
    let v878 : string = v12.[int v855..int v876]
    let v887 : int32 = 12 |> int32 
    let v900 : int32 = 16 |> int32 
    let v908 : int32 = v900 - 1
    let v910 : string = v12.[int v887..int v908]
    let v919 : int32 = 16 |> int32 
    let v932 : int32 = 20 |> int32 
    let v940 : int32 = v932 - 1
    let v942 : string = v12.[int v919..int v940]
    let v951 : int32 = 20 |> int32 
    let v964 : int32 = 32 |> int32 
    let v972 : int32 = v964 - 1
    let v974 : string = v12.[int v951..int v972]
    let v978 : string = $"{v846}-{v878}-{v910}-{v942}-{v974}"
    (* run_target_args'
    let v983 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v985 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v985 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v989 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v989 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v993 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v983 = v993 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v997 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v997 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1001 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v1001 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1005 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v1005 
    #endif
#else
    let v1009 : System.Guid = v978 |> System.Guid 
    let _run_target_args'_v983 = v1009 
    #endif
    let v1012 : System.Guid = _run_target_args'_v983 
    let _run_target_args'_v213 = v1012 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1023 : int32 = 0 |> int32 
    let v1036 : int32 = 8 |> int32 
    let v1044 : int32 = v1036 - 1
    let v1046 : string = v12.[int v1023..int v1044]
    let v1055 : int32 = 8 |> int32 
    let v1068 : int32 = 12 |> int32 
    let v1076 : int32 = v1068 - 1
    let v1078 : string = v12.[int v1055..int v1076]
    let v1087 : int32 = 12 |> int32 
    let v1100 : int32 = 16 |> int32 
    let v1108 : int32 = v1100 - 1
    let v1110 : string = v12.[int v1087..int v1108]
    let v1119 : int32 = 16 |> int32 
    let v1132 : int32 = 20 |> int32 
    let v1140 : int32 = v1132 - 1
    let v1142 : string = v12.[int v1119..int v1140]
    let v1151 : int32 = 20 |> int32 
    let v1164 : int32 = 32 |> int32 
    let v1172 : int32 = v1164 - 1
    let v1174 : string = v12.[int v1151..int v1172]
    let v1178 : string = $"{v1046}-{v1078}-{v1110}-{v1142}-{v1174}"
    (* run_target_args'
    let v1183 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1185 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1185 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1189 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1189 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1193 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1183 = v1193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1197 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1197 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1201 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1201 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1205 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1205 
    #endif
#else
    let v1209 : System.Guid = v1178 |> System.Guid 
    let _run_target_args'_v1183 = v1209 
    #endif
    let v1212 : System.Guid = _run_target_args'_v1183 
    let _run_target_args'_v213 = v1212 
    #endif
#else
    let v1223 : int32 = 0 |> int32 
    let v1236 : int32 = 8 |> int32 
    let v1244 : int32 = v1236 - 1
    let v1246 : string = v12.[int v1223..int v1244]
    let v1255 : int32 = 8 |> int32 
    let v1268 : int32 = 12 |> int32 
    let v1276 : int32 = v1268 - 1
    let v1278 : string = v12.[int v1255..int v1276]
    let v1287 : int32 = 12 |> int32 
    let v1300 : int32 = 16 |> int32 
    let v1308 : int32 = v1300 - 1
    let v1310 : string = v12.[int v1287..int v1308]
    let v1319 : int32 = 16 |> int32 
    let v1332 : int32 = 20 |> int32 
    let v1340 : int32 = v1332 - 1
    let v1342 : string = v12.[int v1319..int v1340]
    let v1351 : int32 = 20 |> int32 
    let v1364 : int32 = 32 |> int32 
    let v1372 : int32 = v1364 - 1
    let v1374 : string = v12.[int v1351..int v1372]
    let v1378 : string = $"{v1246}-{v1278}-{v1310}-{v1342}-{v1374}"
    (* run_target_args'
    let v1383 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1385 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1385 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1389 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1389 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1393 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1383 = v1393 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1397 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1397 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1401 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1401 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1405 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1405 
    #endif
#else
    let v1409 : System.Guid = v1378 |> System.Guid 
    let _run_target_args'_v1383 = v1409 
    #endif
    let v1412 : System.Guid = _run_target_args'_v1383 
    let _run_target_args'_v213 = v1412 
    #endif
    let v1418 : System.Guid = _run_target_args'_v213 
    v1418
and closure48 () (v0 : string) : struct (string * System.IDisposable) =
    let v1 : System.Guid = method108(v0)
    let v2 : string = method87(v1)
    let v3 : System.IDisposable = method93(v2)
    struct (v2, v3)
and closure50 () () : string =
    let v0 : string = __SOURCE_DIRECTORY__
    v0
and closure52 () (v0 : std_path_PathBuf) : US14 =
    US14_0(v0)
and method113 () : (std_path_PathBuf -> US14) =
    closure52()
and closure53 () (v0 : string) : US14 =
    US14_1(v0)
and method114 () : (string -> US14) =
    closure53()
and method117 (v0 : string) : string option =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "&*$0"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : string = "&*$0"
    let v11 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v10 
    let _run_target_args'_v7 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : string = "&*$0"
    let v13 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v15 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v7 = v15 
    #endif
#if FABLE_COMPILER_PYTHON
    let v19 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v7 = v19 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v7 = v23 
    #endif
#else
    let v27 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v7 = v27 
    #endif
    let v30 : Ref<Str> = _run_target_args'_v7 
    (* run_target_args'
    let v40 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v41 : string = "String::from($0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v41 
    let _run_target_args'_v40 = v42 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v43 : string = "String::from($0)"
    let v44 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v43 
    let _run_target_args'_v40 = v44 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v45 : string = "String::from($0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v30 v45 
    let _run_target_args'_v40 = v46 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v48 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v40 = v48 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v40 = v52 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v56 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v40 = v56 
    #endif
#else
    let v60 : std_string_String = v30 |> unbox<std_string_String>
    let _run_target_args'_v40 = v60 
    #endif
    let v63 : std_string_String = _run_target_args'_v40 
    (* run_target_args'
    let v73 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v74 : string = "std::path::PathBuf::from($0)"
    let v75 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v63 v74 
    let _run_target_args'_v73 = v75 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v76 : string = "std::path::PathBuf::from($0)"
    let v77 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v63 v76 
    let _run_target_args'_v73 = v77 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v78 : string = "std::path::PathBuf::from($0)"
    let v79 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v63 v78 
    let _run_target_args'_v73 = v79 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v81 : std_path_PathBuf = v63 |> unbox<std_path_PathBuf>
    let _run_target_args'_v73 = v81 
    #endif
#if FABLE_COMPILER_PYTHON
    let v85 : std_path_PathBuf = v63 |> unbox<std_path_PathBuf>
    let _run_target_args'_v73 = v85 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v89 : std_path_PathBuf = v63 |> unbox<std_path_PathBuf>
    let _run_target_args'_v73 = v89 
    #endif
#else
    let v93 : std_path_PathBuf = v63 |> unbox<std_path_PathBuf>
    let _run_target_args'_v73 = v93 
    #endif
    let v96 : std_path_PathBuf = _run_target_args'_v73 
    let v102 : string = "$0.parent().map(std::path::PathBuf::from)"
    let v103 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v96 v102 
    let v104 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v105 : bool = Fable.Core.RustInterop.emitRustExpr v103 v104 
    let v106 : string = "x"
    let v107 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr () v106 
    (* run_target_args'
    let v112 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v113 : string = "$0.display()"
    let v114 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v107 v113 
    let _run_target_args'_v112 = v114 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v115 : string = "$0.display()"
    let v116 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v107 v115 
    let _run_target_args'_v112 = v116 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v117 : string = "$0.display()"
    let v118 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v107 v117 
    let _run_target_args'_v112 = v118 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v120 : std_path_Display = v107 |> unbox<std_path_Display>
    let _run_target_args'_v112 = v120 
    #endif
#if FABLE_COMPILER_PYTHON
    let v124 : std_path_Display = v107 |> unbox<std_path_Display>
    let _run_target_args'_v112 = v124 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v128 : std_path_Display = v107 |> unbox<std_path_Display>
    let _run_target_args'_v112 = v128 
    #endif
#else
    let v132 : std_path_Display = v107 |> unbox<std_path_Display>
    let _run_target_args'_v112 = v132 
    #endif
    let v135 : std_path_Display = _run_target_args'_v112 
    (* run_target_args'
    let v145 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v146 : string = "format!(\"{}\", $0)"
    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v135 v146 
    let _run_target_args'_v145 = v147 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v148 : string = "format!(\"{}\", $0)"
    let v149 : std_string_String = Fable.Core.RustInterop.emitRustExpr v135 v148 
    let _run_target_args'_v145 = v149 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v150 : string = "format!(\"{}\", $0)"
    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v135 v150 
    let _run_target_args'_v145 = v151 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v153 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v145 = v153 
    #endif
#if FABLE_COMPILER_PYTHON
    let v157 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v145 = v157 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v161 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v145 = v161 
    #endif
#else
    let v165 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v145 = v165 
    #endif
    let v168 : std_string_String = _run_target_args'_v145 
    let v174 : string = "fable_library_rust::String_::fromString($0)"
    let v175 : string = Fable.Core.RustInterop.emitRustExpr v168 v174 
    let v176 : string = "true; $0 })"
    let v177 : bool = Fable.Core.RustInterop.emitRustExpr v175 v176 
    let v178 : string = "_optionm_map_"
    let v179 : string option = Fable.Core.RustInterop.emitRustExpr () v178 
    let _run_target_args'_v2 = v179 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v180 : string option = None
    let _run_target_args'_v2 = v180 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v181 : string option = None
    let _run_target_args'_v2 = v181 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v182 : string = "path"
    let v183 : IPathDirname = Fable.Core.JsInterop.importAll v182 
    let v184 : string = "v183.dirname($0)"
    let v185 : string = Fable.Core.JsInterop.emitJsExpr v0 v184 
    let v186 : bool = v185 = v0
    let v189 : US5 =
        if v186 then
            US5_1
        else
            US5_0(v185)
    let v197 : string option =
        match v189 with
        | US5_1 -> (* None *)
            let v195 : string option = None
            v195
        | US5_0(v190) -> (* Some *)
            let v192 : string option = Some v190 
            v192
    let _run_target_args'_v2 = v197 
    #endif
#if FABLE_COMPILER_PYTHON
    let v198 : string option = None
    let _run_target_args'_v2 = v198 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v199 : string option = None
    let _run_target_args'_v2 = v199 
    #endif
#else
    let v200 : (string -> System_IO_DirectoryInfo) = System.IO.Directory.GetParent
    let v201 : System_IO_DirectoryInfo = v200 v0
    let v203 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let v207 : bool = v201 = v203 
    let v249 : US5 =
        if v207 then
            US5_1
        else
            (* run_target_args'
            let v215 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v217 : string = null |> unbox<string>
            let _run_target_args'_v215 = v217 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v221 : string = null |> unbox<string>
            let _run_target_args'_v215 = v221 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v225 : string = null |> unbox<string>
            let _run_target_args'_v215 = v225 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v229 : string = null |> unbox<string>
            let _run_target_args'_v215 = v229 
            #endif
#if FABLE_COMPILER_PYTHON
            let v233 : string = null |> unbox<string>
            let _run_target_args'_v215 = v233 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v237 : string = null |> unbox<string>
            let _run_target_args'_v215 = v237 
            #endif
#else
            let v240 : (System_IO_DirectoryInfo -> string) = _.FullName
            let v241 : string = v240 v201
            let _run_target_args'_v215 = v241 
            #endif
            let v242 : string = _run_target_args'_v215 
            US5_0(v242)
    let v257 : string option =
        match v249 with
        | US5_1 -> (* None *)
            let v255 : string option = None
            v255
        | US5_0(v250) -> (* Some *)
            let v252 : string option = Some v250 
            v252
    let _run_target_args'_v2 = v257 
    #endif
    let v258 : string option = _run_target_args'_v2 
    v258
and method118 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure6(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method116 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method20(v4)
    let v6 : string option = method117(v4)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v6 |> Option.map v8 
    let v22 : US5 = US5_1
    let v23 : US5 = v9 |> Option.defaultValue v22 
    let v27 : string = method118(v3)
    let v28 : bool = v2 >= 11uy
    if v28 then
        let v29 : string = $"file_system.read_link / "
        let v30 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v31 : string = v29 + v30 
        (* run_target_args'
        let v36 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v37 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v38 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v31 v37 
        let _run_target_args'_v36 = v38 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v39 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v40 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v31 v39 
        let _run_target_args'_v36 = v40 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v41 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v42 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v31 v41 
        let _run_target_args'_v36 = v42 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v44 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v44 
        #endif
#if FABLE_COMPILER_PYTHON
        let v48 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v48 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v52 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v52 
        #endif
#else
        let v56 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v56 
        #endif
        let v59 : std_io_Error = _run_target_args'_v36 
        (* run_target_args'
        let v66 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = "Err($0)"
        let v68 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v59 v67 
        let _run_target_args'_v66 = v68 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v69 : string = "Err($0)"
        let v70 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v59 v69 
        let _run_target_args'_v66 = v70 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v71 : string = "Err($0)"
        let v72 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v59 v71 
        let _run_target_args'_v66 = v72 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v73 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v73 
        #endif
#if FABLE_COMPILER_PYTHON
        let v74 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v74 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v75 
        #endif
#else
        let v76 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v76 
        #endif
        let v77 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v66 
        v77
    else
        match v23 with
        | US5_0(v80) -> (* Some *)
            let v83 : string = ""
            let v84 : bool = v4 <> v83 
            if v84 then
                let v87 : uint8 = v2 + 1uy
                let v88 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v87
                let v89 : Result<std_path_PathBuf, std_io_Error> = v88 v80
                let v90 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v92 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v93 : string = "$0.map_err(|x| $1(x))"
                let v94 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v89, v90) v93 
                let _run_target_args'_v92 = v94 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v95 : string = "$0.map_err(|x| $1(x))"
                let v96 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v89, v90) v95 
                let _run_target_args'_v92 = v96 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v97 : string = "$0.map_err(|x| $1(x))"
                let v98 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v89, v90) v97 
                let _run_target_args'_v92 = v98 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v99 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v99 
                #endif
#if FABLE_COMPILER_PYTHON
                let v100 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v100 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v101 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v101 
                #endif
#else
                let v102 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v102 
                #endif
                let v103 : Result<std_path_PathBuf, string> = _run_target_args'_v92 
                let v106 : (std_path_PathBuf -> US14) = method113()
                let v107 : (string -> US14) = method114()
                let v108 : US14 = match v103 with Ok x -> v106 x | Error x -> v107 x
                match v108 with
                | US14_1(v262) -> (* Error *)
                    let v263 : string = $"file_system.read_link / "
                    let v264 : string = $"error': {v262} / error: {v27} / name: {v5}"
                    let v265 : string = v263 + v264 
                    (* run_target_args'
                    let v270 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v271 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v272 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v265 v271 
                    let _run_target_args'_v270 = v272 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v273 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v274 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v265 v273 
                    let _run_target_args'_v270 = v274 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v275 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v276 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v265 v275 
                    let _run_target_args'_v270 = v276 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v278 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v278 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v282 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v282 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v286 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v286 
                    #endif
#else
                    let v290 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v290 
                    #endif
                    let v293 : std_io_Error = _run_target_args'_v270 
                    (* run_target_args'
                    let v300 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v301 : string = "Err($0)"
                    let v302 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v293 v301 
                    let _run_target_args'_v300 = v302 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v303 : string = "Err($0)"
                    let v304 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v293 v303 
                    let _run_target_args'_v300 = v304 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v305 : string = "Err($0)"
                    let v306 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v293 v305 
                    let _run_target_args'_v300 = v306 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v307 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v307 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v308 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v308 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v309 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v309 
                    #endif
#else
                    let v310 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v310 
                    #endif
                    let v311 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v300 
                    v311
                | US14_0(v109) -> (* Ok *)
                    (* run_target_args'
                    let v114 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v115 : string = "$0.display()"
                    let v116 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v109 v115 
                    let _run_target_args'_v114 = v116 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v117 : string = "$0.display()"
                    let v118 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v109 v117 
                    let _run_target_args'_v114 = v118 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v119 : string = "$0.display()"
                    let v120 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v109 v119 
                    let _run_target_args'_v114 = v120 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v122 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v122 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v126 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v126 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v130 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v130 
                    #endif
#else
                    let v134 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v134 
                    #endif
                    let v137 : std_path_Display = _run_target_args'_v114 
                    let v144 : string = v137 |> string 
                    let v147 : string = method90(v144, v5)
                    (* run_target_args'
                    let v152 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v153 : string = "&*$0"
                    let v154 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v153 
                    let _run_target_args'_v152 = v154 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v155 : string = "&*$0"
                    let v156 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v155 
                    let _run_target_args'_v152 = v156 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v157 : string = "&*$0"
                    let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v157 
                    let _run_target_args'_v152 = v158 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v160 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v160 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v164 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v164 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v168 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v168 
                    #endif
#else
                    let v172 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v172 
                    #endif
                    let v175 : Ref<Str> = _run_target_args'_v152 
                    (* run_target_args'
                    let v185 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v186 : string = "String::from($0)"
                    let v187 : std_string_String = Fable.Core.RustInterop.emitRustExpr v175 v186 
                    let _run_target_args'_v185 = v187 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v188 : string = "String::from($0)"
                    let v189 : std_string_String = Fable.Core.RustInterop.emitRustExpr v175 v188 
                    let _run_target_args'_v185 = v189 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v190 : string = "String::from($0)"
                    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v175 v190 
                    let _run_target_args'_v185 = v191 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v193 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v193 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v197 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v197 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v201 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v201 
                    #endif
#else
                    let v205 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v205 
                    #endif
                    let v208 : std_string_String = _run_target_args'_v185 
                    (* run_target_args'
                    let v218 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v219 : string = "std::path::PathBuf::from($0)"
                    let v220 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v208 v219 
                    let _run_target_args'_v218 = v220 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v221 : string = "std::path::PathBuf::from($0)"
                    let v222 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v208 v221 
                    let _run_target_args'_v218 = v222 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v223 : string = "std::path::PathBuf::from($0)"
                    let v224 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v208 v223 
                    let _run_target_args'_v218 = v224 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v226 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v226 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v230 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v230 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v234 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v234 
                    #endif
#else
                    let v238 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v238 
                    #endif
                    let v241 : std_path_PathBuf = _run_target_args'_v218 
                    (* run_target_args'
                    let v248 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v249 : string = "Ok($0)"
                    let v250 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v241 v249 
                    let _run_target_args'_v248 = v250 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v251 : string = "Ok($0)"
                    let v252 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v241 v251 
                    let _run_target_args'_v248 = v252 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v253 : string = "Ok($0)"
                    let v254 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v241 v253 
                    let _run_target_args'_v248 = v254 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v255 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v255 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v256 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v256 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v257 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v257 
                    #endif
#else
                    let v258 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v258 
                    #endif
                    let v259 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v248 
                    v259
            else
                let v316 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v317 : string = $"path: {v0} / error: {v27} / path': {v4} / name: {v5}"
                let v318 : string = v316 + v317 
                (* run_target_args'
                let v323 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v324 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v325 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v318 v324 
                let _run_target_args'_v323 = v325 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v326 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v327 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v318 v326 
                let _run_target_args'_v323 = v327 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v328 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v329 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v318 v328 
                let _run_target_args'_v323 = v329 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v331 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v331 
                #endif
#if FABLE_COMPILER_PYTHON
                let v335 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v335 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v339 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v339 
                #endif
#else
                let v343 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v343 
                #endif
                let v346 : std_io_Error = _run_target_args'_v323 
                (* run_target_args'
                let v353 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v354 : string = "Err($0)"
                let v355 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v346 v354 
                let _run_target_args'_v353 = v355 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v356 : string = "Err($0)"
                let v357 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v346 v356 
                let _run_target_args'_v353 = v357 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v358 : string = "Err($0)"
                let v359 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v346 v358 
                let _run_target_args'_v353 = v359 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v360 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v360 
                #endif
#if FABLE_COMPILER_PYTHON
                let v361 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v361 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v362 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v362 
                #endif
#else
                let v363 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v363 
                #endif
                let v364 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v353 
                v364
        | _ ->
            let v368 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v369 : string = $"path: {v0} / error: {v27} / path': {v4} / name: {v5}"
            let v370 : string = v368 + v369 
            (* run_target_args'
            let v375 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v376 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v377 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v370 v376 
            let _run_target_args'_v375 = v377 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v378 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v379 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v370 v378 
            let _run_target_args'_v375 = v379 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v380 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v381 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v370 v380 
            let _run_target_args'_v375 = v381 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v383 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v387 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v387 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v391 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v391 
            #endif
#else
            let v395 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v395 
            #endif
            let v398 : std_io_Error = _run_target_args'_v375 
            (* run_target_args'
            let v405 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v406 : string = "Err($0)"
            let v407 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v398 v406 
            let _run_target_args'_v405 = v407 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v408 : string = "Err($0)"
            let v409 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v398 v408 
            let _run_target_args'_v405 = v409 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v410 : string = "Err($0)"
            let v411 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v398 v410 
            let _run_target_args'_v405 = v411 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v412 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v412 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v414 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v414 
            #endif
#else
            let v415 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v415 
            #endif
            let v416 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v405 
            v416
and method115 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "std::fs::read_link(&*$0)"
    let v9 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let v10 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "$0.map_err(|x| $1(x))"
    let v14 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v9, v10) v13 
    let _run_target_args'_v12 = v14 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v15 : string = "$0.map_err(|x| $1(x))"
    let v16 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v9, v10) v15 
    let _run_target_args'_v12 = v16 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : string = "$0.map_err(|x| $1(x))"
    let v18 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v9, v10) v17 
    let _run_target_args'_v12 = v18 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : Result<std_path_PathBuf, string> = match v9 with Ok x -> Ok x | Error x -> Error (v10 x)
    let _run_target_args'_v12 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : Result<std_path_PathBuf, string> = match v9 with Ok x -> Ok x | Error x -> Error (v10 x)
    let _run_target_args'_v12 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v21 : Result<std_path_PathBuf, string> = match v9 with Ok x -> Ok x | Error x -> Error (v10 x)
    let _run_target_args'_v12 = v21 
    #endif
#else
    let v22 : Result<std_path_PathBuf, string> = match v9 with Ok x -> Ok x | Error x -> Error (v10 x)
    let _run_target_args'_v12 = v22 
    #endif
    let v23 : Result<std_path_PathBuf, string> = _run_target_args'_v12 
    let v26 : (std_path_PathBuf -> US14) = method113()
    let v27 : (string -> US14) = method114()
    let v28 : US14 = match v23 with Ok x -> v26 x | Error x -> v27 x
    let v49 : Result<std_path_PathBuf, std_io_Error> =
        match v28 with
        | US14_1(v45) -> (* Error *)
            let v46 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method116(v0, v46, v1, v45, v2)
        | US14_0(v29) -> (* Ok *)
            (* run_target_args'
            let v31 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v32 : string = "Ok($0)"
            let v33 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v29 v32 
            let _run_target_args'_v31 = v33 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v34 : string = "Ok($0)"
            let v35 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v29 v34 
            let _run_target_args'_v31 = v35 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v36 : string = "Ok($0)"
            let v37 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v29 v36 
            let _run_target_args'_v31 = v37 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v38 : Result<std_path_PathBuf, std_io_Error> = v29 |> Ok
            let _run_target_args'_v31 = v38 
            #endif
#if FABLE_COMPILER_PYTHON
            let v39 : Result<std_path_PathBuf, std_io_Error> = v29 |> Ok
            let _run_target_args'_v31 = v39 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v40 : Result<std_path_PathBuf, std_io_Error> = v29 |> Ok
            let _run_target_args'_v31 = v40 
            #endif
#else
            let v41 : Result<std_path_PathBuf, std_io_Error> = v29 |> Ok
            let _run_target_args'_v31 = v41 
            #endif
            let v42 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v31 
            v42
    let _run_target_args'_v7 = v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = "std::fs::read_link(&*$0)"
    let v51 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v50 
    let v52 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v54 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v55 : string = "$0.map_err(|x| $1(x))"
    let v56 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v51, v52) v55 
    let _run_target_args'_v54 = v56 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v57 : string = "$0.map_err(|x| $1(x))"
    let v58 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v51, v52) v57 
    let _run_target_args'_v54 = v58 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v59 : string = "$0.map_err(|x| $1(x))"
    let v60 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v51, v52) v59 
    let _run_target_args'_v54 = v60 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v61 : Result<std_path_PathBuf, string> = match v51 with Ok x -> Ok x | Error x -> Error (v52 x)
    let _run_target_args'_v54 = v61 
    #endif
#if FABLE_COMPILER_PYTHON
    let v62 : Result<std_path_PathBuf, string> = match v51 with Ok x -> Ok x | Error x -> Error (v52 x)
    let _run_target_args'_v54 = v62 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : Result<std_path_PathBuf, string> = match v51 with Ok x -> Ok x | Error x -> Error (v52 x)
    let _run_target_args'_v54 = v63 
    #endif
#else
    let v64 : Result<std_path_PathBuf, string> = match v51 with Ok x -> Ok x | Error x -> Error (v52 x)
    let _run_target_args'_v54 = v64 
    #endif
    let v65 : Result<std_path_PathBuf, string> = _run_target_args'_v54 
    let v68 : (std_path_PathBuf -> US14) = method113()
    let v69 : (string -> US14) = method114()
    let v70 : US14 = match v65 with Ok x -> v68 x | Error x -> v69 x
    let v91 : Result<std_path_PathBuf, std_io_Error> =
        match v70 with
        | US14_1(v87) -> (* Error *)
            let v88 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method116(v0, v88, v1, v87, v2)
        | US14_0(v71) -> (* Ok *)
            (* run_target_args'
            let v73 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v74 : string = "Ok($0)"
            let v75 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v71 v74 
            let _run_target_args'_v73 = v75 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v76 : string = "Ok($0)"
            let v77 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v71 v76 
            let _run_target_args'_v73 = v77 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v78 : string = "Ok($0)"
            let v79 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v71 v78 
            let _run_target_args'_v73 = v79 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v80 : Result<std_path_PathBuf, std_io_Error> = v71 |> Ok
            let _run_target_args'_v73 = v80 
            #endif
#if FABLE_COMPILER_PYTHON
            let v81 : Result<std_path_PathBuf, std_io_Error> = v71 |> Ok
            let _run_target_args'_v73 = v81 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v82 : Result<std_path_PathBuf, std_io_Error> = v71 |> Ok
            let _run_target_args'_v73 = v82 
            #endif
#else
            let v83 : Result<std_path_PathBuf, std_io_Error> = v71 |> Ok
            let _run_target_args'_v73 = v83 
            #endif
            let v84 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v73 
            v84
    let _run_target_args'_v7 = v91 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v92 : string = "std::fs::read_link(&*$0)"
    let v93 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v92 
    let v94 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v96 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v97 : string = "$0.map_err(|x| $1(x))"
    let v98 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v93, v94) v97 
    let _run_target_args'_v96 = v98 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v99 : string = "$0.map_err(|x| $1(x))"
    let v100 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v93, v94) v99 
    let _run_target_args'_v96 = v100 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v101 : string = "$0.map_err(|x| $1(x))"
    let v102 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v93, v94) v101 
    let _run_target_args'_v96 = v102 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Result<std_path_PathBuf, string> = match v93 with Ok x -> Ok x | Error x -> Error (v94 x)
    let _run_target_args'_v96 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v104 : Result<std_path_PathBuf, string> = match v93 with Ok x -> Ok x | Error x -> Error (v94 x)
    let _run_target_args'_v96 = v104 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v105 : Result<std_path_PathBuf, string> = match v93 with Ok x -> Ok x | Error x -> Error (v94 x)
    let _run_target_args'_v96 = v105 
    #endif
#else
    let v106 : Result<std_path_PathBuf, string> = match v93 with Ok x -> Ok x | Error x -> Error (v94 x)
    let _run_target_args'_v96 = v106 
    #endif
    let v107 : Result<std_path_PathBuf, string> = _run_target_args'_v96 
    let v110 : (std_path_PathBuf -> US14) = method113()
    let v111 : (string -> US14) = method114()
    let v112 : US14 = match v107 with Ok x -> v110 x | Error x -> v111 x
    let v133 : Result<std_path_PathBuf, std_io_Error> =
        match v112 with
        | US14_1(v129) -> (* Error *)
            let v130 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method116(v0, v130, v1, v129, v2)
        | US14_0(v113) -> (* Ok *)
            (* run_target_args'
            let v115 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v116 : string = "Ok($0)"
            let v117 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v113 v116 
            let _run_target_args'_v115 = v117 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v118 : string = "Ok($0)"
            let v119 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v113 v118 
            let _run_target_args'_v115 = v119 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v120 : string = "Ok($0)"
            let v121 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v113 v120 
            let _run_target_args'_v115 = v121 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v122 : Result<std_path_PathBuf, std_io_Error> = v113 |> Ok
            let _run_target_args'_v115 = v122 
            #endif
#if FABLE_COMPILER_PYTHON
            let v123 : Result<std_path_PathBuf, std_io_Error> = v113 |> Ok
            let _run_target_args'_v115 = v123 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v124 : Result<std_path_PathBuf, std_io_Error> = v113 |> Ok
            let _run_target_args'_v115 = v124 
            #endif
#else
            let v125 : Result<std_path_PathBuf, std_io_Error> = v113 |> Ok
            let _run_target_args'_v115 = v125 
            #endif
            let v126 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v115 
            v126
    let _run_target_args'_v7 = v133 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v135 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v135 
    #endif
#if FABLE_COMPILER_PYTHON
    let v139 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v139 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v143 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v143 
    #endif
#else
    let v147 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v147 
    #endif
    let v150 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v7 
    v150
and closure55 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method115(v0, v1, v2)
and closure54 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure55(v0, v1)
and method119 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method20(v0)
    let v5 : string option = method117(v0)
    let v7 : (string -> US5) = method5()
    let v8 : US5 option = v5 |> Option.map v7 
    let v21 : US5 = US5_1
    let v22 : US5 = v8 |> Option.defaultValue v21 
    let v26 : string = method118(v3)
    let v27 : bool = v2 >= 11uy
    if v27 then
        let v28 : string = $"file_system.read_link / "
        let v29 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v30 : string = v28 + v29 
        (* run_target_args'
        let v35 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v36 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v37 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v30 v36 
        let _run_target_args'_v35 = v37 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v38 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v39 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v30 v38 
        let _run_target_args'_v35 = v39 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v40 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v41 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v30 v40 
        let _run_target_args'_v35 = v41 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v43 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v43 
        #endif
#if FABLE_COMPILER_PYTHON
        let v47 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v47 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v51 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v51 
        #endif
#else
        let v55 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v55 
        #endif
        let v58 : std_io_Error = _run_target_args'_v35 
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v66 : string = "Err($0)"
        let v67 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v58 v66 
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v68 : string = "Err($0)"
        let v69 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v58 v68 
        let _run_target_args'_v65 = v69 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v70 : string = "Err($0)"
        let v71 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v58 v70 
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v72 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v72 
        #endif
#if FABLE_COMPILER_PYTHON
        let v73 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v73 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v74 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v74 
        #endif
#else
        let v75 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v75 
        #endif
        let v76 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v65 
        v76
    else
        match v22 with
        | US5_0(v79) -> (* Some *)
            let v82 : string = ""
            let v83 : bool = v0 <> v82 
            if v83 then
                let v86 : uint8 = v2 + 1uy
                let v87 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v86
                let v88 : Result<std_path_PathBuf, std_io_Error> = v87 v79
                let v89 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v91 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v92 : string = "$0.map_err(|x| $1(x))"
                let v93 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v88, v89) v92 
                let _run_target_args'_v91 = v93 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v94 : string = "$0.map_err(|x| $1(x))"
                let v95 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v88, v89) v94 
                let _run_target_args'_v91 = v95 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v96 : string = "$0.map_err(|x| $1(x))"
                let v97 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v88, v89) v96 
                let _run_target_args'_v91 = v97 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v98 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v98 
                #endif
#if FABLE_COMPILER_PYTHON
                let v99 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v99 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v100 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v100 
                #endif
#else
                let v101 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v101 
                #endif
                let v102 : Result<std_path_PathBuf, string> = _run_target_args'_v91 
                let v105 : (std_path_PathBuf -> US14) = method113()
                let v106 : (string -> US14) = method114()
                let v107 : US14 = match v102 with Ok x -> v105 x | Error x -> v106 x
                match v107 with
                | US14_1(v261) -> (* Error *)
                    let v262 : string = $"file_system.read_link / "
                    let v263 : string = $"error': {v261} / error: {v26} / name: {v4}"
                    let v264 : string = v262 + v263 
                    (* run_target_args'
                    let v269 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v270 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v271 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v264 v270 
                    let _run_target_args'_v269 = v271 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v272 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v273 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v264 v272 
                    let _run_target_args'_v269 = v273 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v274 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v275 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v264 v274 
                    let _run_target_args'_v269 = v275 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v277 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v277 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v281 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v281 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v285 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v285 
                    #endif
#else
                    let v289 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v289 
                    #endif
                    let v292 : std_io_Error = _run_target_args'_v269 
                    (* run_target_args'
                    let v299 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v300 : string = "Err($0)"
                    let v301 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v292 v300 
                    let _run_target_args'_v299 = v301 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v302 : string = "Err($0)"
                    let v303 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v292 v302 
                    let _run_target_args'_v299 = v303 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v304 : string = "Err($0)"
                    let v305 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v292 v304 
                    let _run_target_args'_v299 = v305 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v306 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v306 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v307 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v307 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v308 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v308 
                    #endif
#else
                    let v309 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v309 
                    #endif
                    let v310 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v299 
                    v310
                | US14_0(v108) -> (* Ok *)
                    (* run_target_args'
                    let v113 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v114 : string = "$0.display()"
                    let v115 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v108 v114 
                    let _run_target_args'_v113 = v115 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v116 : string = "$0.display()"
                    let v117 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v108 v116 
                    let _run_target_args'_v113 = v117 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v118 : string = "$0.display()"
                    let v119 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v108 v118 
                    let _run_target_args'_v113 = v119 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v121 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v121 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v125 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v125 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v129 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v129 
                    #endif
#else
                    let v133 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v133 
                    #endif
                    let v136 : std_path_Display = _run_target_args'_v113 
                    let v143 : string = v136 |> string 
                    let v146 : string = method90(v143, v4)
                    (* run_target_args'
                    let v151 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v152 : string = "&*$0"
                    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v146 v152 
                    let _run_target_args'_v151 = v153 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v154 : string = "&*$0"
                    let v155 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v146 v154 
                    let _run_target_args'_v151 = v155 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v156 : string = "&*$0"
                    let v157 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v146 v156 
                    let _run_target_args'_v151 = v157 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v159 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v159 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v163 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v163 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v167 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v167 
                    #endif
#else
                    let v171 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v171 
                    #endif
                    let v174 : Ref<Str> = _run_target_args'_v151 
                    (* run_target_args'
                    let v184 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v185 : string = "String::from($0)"
                    let v186 : std_string_String = Fable.Core.RustInterop.emitRustExpr v174 v185 
                    let _run_target_args'_v184 = v186 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v187 : string = "String::from($0)"
                    let v188 : std_string_String = Fable.Core.RustInterop.emitRustExpr v174 v187 
                    let _run_target_args'_v184 = v188 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v189 : string = "String::from($0)"
                    let v190 : std_string_String = Fable.Core.RustInterop.emitRustExpr v174 v189 
                    let _run_target_args'_v184 = v190 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v192 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v192 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v196 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v196 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v200 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v200 
                    #endif
#else
                    let v204 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v204 
                    #endif
                    let v207 : std_string_String = _run_target_args'_v184 
                    (* run_target_args'
                    let v217 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v218 : string = "std::path::PathBuf::from($0)"
                    let v219 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v207 v218 
                    let _run_target_args'_v217 = v219 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v220 : string = "std::path::PathBuf::from($0)"
                    let v221 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v207 v220 
                    let _run_target_args'_v217 = v221 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v222 : string = "std::path::PathBuf::from($0)"
                    let v223 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v207 v222 
                    let _run_target_args'_v217 = v223 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v225 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v225 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v229 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v229 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v233 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v233 
                    #endif
#else
                    let v237 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v237 
                    #endif
                    let v240 : std_path_PathBuf = _run_target_args'_v217 
                    (* run_target_args'
                    let v247 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v248 : string = "Ok($0)"
                    let v249 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v240 v248 
                    let _run_target_args'_v247 = v249 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v250 : string = "Ok($0)"
                    let v251 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v240 v250 
                    let _run_target_args'_v247 = v251 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v252 : string = "Ok($0)"
                    let v253 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v240 v252 
                    let _run_target_args'_v247 = v253 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v254 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v254 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v255 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v255 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v256 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v256 
                    #endif
#else
                    let v257 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v257 
                    #endif
                    let v258 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v247 
                    v258
            else
                let v315 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v316 : string = $"path: {v0} / error: {v26} / path': {v0} / name: {v4}"
                let v317 : string = v315 + v316 
                (* run_target_args'
                let v322 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v323 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v324 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v317 v323 
                let _run_target_args'_v322 = v324 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v325 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v326 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v317 v325 
                let _run_target_args'_v322 = v326 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v327 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v328 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v317 v327 
                let _run_target_args'_v322 = v328 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v330 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v330 
                #endif
#if FABLE_COMPILER_PYTHON
                let v334 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v334 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v338 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v338 
                #endif
#else
                let v342 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v342 
                #endif
                let v345 : std_io_Error = _run_target_args'_v322 
                (* run_target_args'
                let v352 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v353 : string = "Err($0)"
                let v354 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v345 v353 
                let _run_target_args'_v352 = v354 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v355 : string = "Err($0)"
                let v356 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v345 v355 
                let _run_target_args'_v352 = v356 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v357 : string = "Err($0)"
                let v358 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v345 v357 
                let _run_target_args'_v352 = v358 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v359 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v359 
                #endif
#if FABLE_COMPILER_PYTHON
                let v360 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v360 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v361 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v361 
                #endif
#else
                let v362 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v362 
                #endif
                let v363 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v352 
                v363
        | _ ->
            let v367 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v368 : string = $"path: {v0} / error: {v26} / path': {v0} / name: {v4}"
            let v369 : string = v367 + v368 
            (* run_target_args'
            let v374 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v375 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v376 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v369 v375 
            let _run_target_args'_v374 = v376 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v377 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v378 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v369 v377 
            let _run_target_args'_v374 = v378 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v379 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v380 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v369 v379 
            let _run_target_args'_v374 = v380 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v382 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v382 
            #endif
#if FABLE_COMPILER_PYTHON
            let v386 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v386 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v390 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v390 
            #endif
#else
            let v394 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v394 
            #endif
            let v397 : std_io_Error = _run_target_args'_v374 
            (* run_target_args'
            let v404 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v405 : string = "Err($0)"
            let v406 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v397 v405 
            let _run_target_args'_v404 = v406 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v407 : string = "Err($0)"
            let v408 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v397 v407 
            let _run_target_args'_v404 = v408 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v409 : string = "Err($0)"
            let v410 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v397 v409 
            let _run_target_args'_v404 = v410 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v411 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v411 
            #endif
#if FABLE_COMPILER_PYTHON
            let v412 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v412 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v413 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v413 
            #endif
#else
            let v414 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v414 
            #endif
            let v415 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v404 
            v415
and method112 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "std::fs::read_link(&*$0)"
    let v8 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let v9 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v11 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v12 : string = "$0.map_err(|x| $1(x))"
    let v13 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v8, v9) v12 
    let _run_target_args'_v11 = v13 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v14 : string = "$0.map_err(|x| $1(x))"
    let v15 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v8, v9) v14 
    let _run_target_args'_v11 = v15 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : string = "$0.map_err(|x| $1(x))"
    let v17 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v8, v9) v16 
    let _run_target_args'_v11 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : Result<std_path_PathBuf, string> = match v8 with Ok x -> Ok x | Error x -> Error (v9 x)
    let _run_target_args'_v11 = v18 
    #endif
#if FABLE_COMPILER_PYTHON
    let v19 : Result<std_path_PathBuf, string> = match v8 with Ok x -> Ok x | Error x -> Error (v9 x)
    let _run_target_args'_v11 = v19 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v20 : Result<std_path_PathBuf, string> = match v8 with Ok x -> Ok x | Error x -> Error (v9 x)
    let _run_target_args'_v11 = v20 
    #endif
#else
    let v21 : Result<std_path_PathBuf, string> = match v8 with Ok x -> Ok x | Error x -> Error (v9 x)
    let _run_target_args'_v11 = v21 
    #endif
    let v22 : Result<std_path_PathBuf, string> = _run_target_args'_v11 
    let v25 : (std_path_PathBuf -> US14) = method113()
    let v26 : (string -> US14) = method114()
    let v27 : US14 = match v22 with Ok x -> v25 x | Error x -> v26 x
    let v48 : Result<std_path_PathBuf, std_io_Error> =
        match v27 with
        | US14_1(v44) -> (* Error *)
            let v45 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method119(v0, v45, v1, v44)
        | US14_0(v28) -> (* Ok *)
            (* run_target_args'
            let v30 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v31 : string = "Ok($0)"
            let v32 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v28 v31 
            let _run_target_args'_v30 = v32 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v33 : string = "Ok($0)"
            let v34 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v28 v33 
            let _run_target_args'_v30 = v34 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v35 : string = "Ok($0)"
            let v36 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v28 v35 
            let _run_target_args'_v30 = v36 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v37 : Result<std_path_PathBuf, std_io_Error> = v28 |> Ok
            let _run_target_args'_v30 = v37 
            #endif
#if FABLE_COMPILER_PYTHON
            let v38 : Result<std_path_PathBuf, std_io_Error> = v28 |> Ok
            let _run_target_args'_v30 = v38 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v39 : Result<std_path_PathBuf, std_io_Error> = v28 |> Ok
            let _run_target_args'_v30 = v39 
            #endif
#else
            let v40 : Result<std_path_PathBuf, std_io_Error> = v28 |> Ok
            let _run_target_args'_v30 = v40 
            #endif
            let v41 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v30 
            v41
    let _run_target_args'_v6 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "std::fs::read_link(&*$0)"
    let v50 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v49 
    let v51 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v53 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v54 : string = "$0.map_err(|x| $1(x))"
    let v55 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v50, v51) v54 
    let _run_target_args'_v53 = v55 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v56 : string = "$0.map_err(|x| $1(x))"
    let v57 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v50, v51) v56 
    let _run_target_args'_v53 = v57 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v58 : string = "$0.map_err(|x| $1(x))"
    let v59 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v50, v51) v58 
    let _run_target_args'_v53 = v59 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v60 : Result<std_path_PathBuf, string> = match v50 with Ok x -> Ok x | Error x -> Error (v51 x)
    let _run_target_args'_v53 = v60 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61 : Result<std_path_PathBuf, string> = match v50 with Ok x -> Ok x | Error x -> Error (v51 x)
    let _run_target_args'_v53 = v61 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : Result<std_path_PathBuf, string> = match v50 with Ok x -> Ok x | Error x -> Error (v51 x)
    let _run_target_args'_v53 = v62 
    #endif
#else
    let v63 : Result<std_path_PathBuf, string> = match v50 with Ok x -> Ok x | Error x -> Error (v51 x)
    let _run_target_args'_v53 = v63 
    #endif
    let v64 : Result<std_path_PathBuf, string> = _run_target_args'_v53 
    let v67 : (std_path_PathBuf -> US14) = method113()
    let v68 : (string -> US14) = method114()
    let v69 : US14 = match v64 with Ok x -> v67 x | Error x -> v68 x
    let v90 : Result<std_path_PathBuf, std_io_Error> =
        match v69 with
        | US14_1(v86) -> (* Error *)
            let v87 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method119(v0, v87, v1, v86)
        | US14_0(v70) -> (* Ok *)
            (* run_target_args'
            let v72 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v73 : string = "Ok($0)"
            let v74 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v70 v73 
            let _run_target_args'_v72 = v74 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v75 : string = "Ok($0)"
            let v76 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v70 v75 
            let _run_target_args'_v72 = v76 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v77 : string = "Ok($0)"
            let v78 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v70 v77 
            let _run_target_args'_v72 = v78 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v79 : Result<std_path_PathBuf, std_io_Error> = v70 |> Ok
            let _run_target_args'_v72 = v79 
            #endif
#if FABLE_COMPILER_PYTHON
            let v80 : Result<std_path_PathBuf, std_io_Error> = v70 |> Ok
            let _run_target_args'_v72 = v80 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v81 : Result<std_path_PathBuf, std_io_Error> = v70 |> Ok
            let _run_target_args'_v72 = v81 
            #endif
#else
            let v82 : Result<std_path_PathBuf, std_io_Error> = v70 |> Ok
            let _run_target_args'_v72 = v82 
            #endif
            let v83 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v72 
            v83
    let _run_target_args'_v6 = v90 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : string = "std::fs::read_link(&*$0)"
    let v92 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v91 
    let v93 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "$0.map_err(|x| $1(x))"
    let v97 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v92, v93) v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "$0.map_err(|x| $1(x))"
    let v99 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v92, v93) v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "$0.map_err(|x| $1(x))"
    let v101 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v92, v93) v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v102 : Result<std_path_PathBuf, string> = match v92 with Ok x -> Ok x | Error x -> Error (v93 x)
    let _run_target_args'_v95 = v102 
    #endif
#if FABLE_COMPILER_PYTHON
    let v103 : Result<std_path_PathBuf, string> = match v92 with Ok x -> Ok x | Error x -> Error (v93 x)
    let _run_target_args'_v95 = v103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : Result<std_path_PathBuf, string> = match v92 with Ok x -> Ok x | Error x -> Error (v93 x)
    let _run_target_args'_v95 = v104 
    #endif
#else
    let v105 : Result<std_path_PathBuf, string> = match v92 with Ok x -> Ok x | Error x -> Error (v93 x)
    let _run_target_args'_v95 = v105 
    #endif
    let v106 : Result<std_path_PathBuf, string> = _run_target_args'_v95 
    let v109 : (std_path_PathBuf -> US14) = method113()
    let v110 : (string -> US14) = method114()
    let v111 : US14 = match v106 with Ok x -> v109 x | Error x -> v110 x
    let v132 : Result<std_path_PathBuf, std_io_Error> =
        match v111 with
        | US14_1(v128) -> (* Error *)
            let v129 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method119(v0, v129, v1, v128)
        | US14_0(v112) -> (* Ok *)
            (* run_target_args'
            let v114 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v115 : string = "Ok($0)"
            let v116 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v112 v115 
            let _run_target_args'_v114 = v116 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v117 : string = "Ok($0)"
            let v118 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v112 v117 
            let _run_target_args'_v114 = v118 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v119 : string = "Ok($0)"
            let v120 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v112 v119 
            let _run_target_args'_v114 = v120 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v121 : Result<std_path_PathBuf, std_io_Error> = v112 |> Ok
            let _run_target_args'_v114 = v121 
            #endif
#if FABLE_COMPILER_PYTHON
            let v122 : Result<std_path_PathBuf, std_io_Error> = v112 |> Ok
            let _run_target_args'_v114 = v122 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v123 : Result<std_path_PathBuf, std_io_Error> = v112 |> Ok
            let _run_target_args'_v114 = v123 
            #endif
#else
            let v124 : Result<std_path_PathBuf, std_io_Error> = v112 |> Ok
            let _run_target_args'_v114 = v124 
            #endif
            let v125 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v114 
            v125
    let _run_target_args'_v6 = v132 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v134 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v134 
    #endif
#if FABLE_COMPILER_PYTHON
    let v138 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v138 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v142 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v142 
    #endif
#else
    let v146 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v146 
    #endif
    let v149 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v6 
    v149
and method121 (v0 : System_IO_DirectoryInfo) : System.IO.FileAttributes =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v30 : (System_IO_DirectoryInfo -> System.IO.FileAttributes) = _.Attributes
    let v31 : System.IO.FileAttributes = v30 v0
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : System.IO.FileAttributes = _run_target_args'_v5 
    v32
and method122 () : System.IO.FileAttributes =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v4 = v10 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v4 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v4 = v18 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v4 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v4 = v26 
    #endif
#else
    let v29 : System.IO.FileAttributes = System.IO.FileAttributes.ReparsePoint
    let _run_target_args'_v4 = v29 
    #endif
    let v30 : System.IO.FileAttributes = _run_target_args'_v4 
    v30
and method123 (v0 : System.IO.FileAttributes, v1 : System.IO.FileAttributes) : bool =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v28 
    #endif
#else
    let v31 : bool = v1.HasFlag v0 
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : bool = _run_target_args'_v6 
    v32
and method125 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method20(v4)
    let v6 : string option = method117(v4)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v6 |> Option.map v8 
    let v22 : US5 = US5_1
    let v23 : US5 = v9 |> Option.defaultValue v22 
    let v27 : string = method49(v3)
    let v28 : bool = v2 >= 11uy
    if v28 then
        let v29 : string = $"file_system.read_link / "
        let v30 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v31 : string = v29 + v30 
        (* run_target_args'
        let v36 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v37 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v38 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v31 v37 
        let _run_target_args'_v36 = v38 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v39 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v40 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v31 v39 
        let _run_target_args'_v36 = v40 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v41 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v42 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v31 v41 
        let _run_target_args'_v36 = v42 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v44 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v44 
        #endif
#if FABLE_COMPILER_PYTHON
        let v48 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v48 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v52 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v52 
        #endif
#else
        let v56 : std_io_Error = v31 |> unbox<std_io_Error>
        let _run_target_args'_v36 = v56 
        #endif
        let v59 : std_io_Error = _run_target_args'_v36 
        (* run_target_args'
        let v66 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = "Err($0)"
        let v68 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v59 v67 
        let _run_target_args'_v66 = v68 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v69 : string = "Err($0)"
        let v70 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v59 v69 
        let _run_target_args'_v66 = v70 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v71 : string = "Err($0)"
        let v72 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v59 v71 
        let _run_target_args'_v66 = v72 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v73 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v73 
        #endif
#if FABLE_COMPILER_PYTHON
        let v74 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v74 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v75 
        #endif
#else
        let v76 : Result<std_path_PathBuf, std_io_Error> = v59 |> Error
        let _run_target_args'_v66 = v76 
        #endif
        let v77 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v66 
        v77
    else
        match v23 with
        | US5_0(v80) -> (* Some *)
            let v83 : string = ""
            let v84 : bool = v4 <> v83 
            if v84 then
                let v87 : uint8 = v2 + 1uy
                let v88 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v87
                let v89 : Result<std_path_PathBuf, std_io_Error> = v88 v80
                let v90 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v92 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v93 : string = "$0.map_err(|x| $1(x))"
                let v94 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v89, v90) v93 
                let _run_target_args'_v92 = v94 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v95 : string = "$0.map_err(|x| $1(x))"
                let v96 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v89, v90) v95 
                let _run_target_args'_v92 = v96 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v97 : string = "$0.map_err(|x| $1(x))"
                let v98 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v89, v90) v97 
                let _run_target_args'_v92 = v98 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v99 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v99 
                #endif
#if FABLE_COMPILER_PYTHON
                let v100 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v100 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v101 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v101 
                #endif
#else
                let v102 : Result<std_path_PathBuf, string> = match v89 with Ok x -> Ok x | Error x -> Error (v90 x)
                let _run_target_args'_v92 = v102 
                #endif
                let v103 : Result<std_path_PathBuf, string> = _run_target_args'_v92 
                let v106 : (std_path_PathBuf -> US14) = method113()
                let v107 : (string -> US14) = method114()
                let v108 : US14 = match v103 with Ok x -> v106 x | Error x -> v107 x
                match v108 with
                | US14_1(v262) -> (* Error *)
                    let v263 : string = $"file_system.read_link / "
                    let v264 : string = $"error': {v262} / error: {v27} / name: {v5}"
                    let v265 : string = v263 + v264 
                    (* run_target_args'
                    let v270 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v271 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v272 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v265 v271 
                    let _run_target_args'_v270 = v272 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v273 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v274 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v265 v273 
                    let _run_target_args'_v270 = v274 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v275 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v276 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v265 v275 
                    let _run_target_args'_v270 = v276 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v278 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v278 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v282 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v282 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v286 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v286 
                    #endif
#else
                    let v290 : std_io_Error = v265 |> unbox<std_io_Error>
                    let _run_target_args'_v270 = v290 
                    #endif
                    let v293 : std_io_Error = _run_target_args'_v270 
                    (* run_target_args'
                    let v300 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v301 : string = "Err($0)"
                    let v302 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v293 v301 
                    let _run_target_args'_v300 = v302 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v303 : string = "Err($0)"
                    let v304 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v293 v303 
                    let _run_target_args'_v300 = v304 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v305 : string = "Err($0)"
                    let v306 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v293 v305 
                    let _run_target_args'_v300 = v306 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v307 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v307 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v308 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v308 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v309 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v309 
                    #endif
#else
                    let v310 : Result<std_path_PathBuf, std_io_Error> = v293 |> Error
                    let _run_target_args'_v300 = v310 
                    #endif
                    let v311 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v300 
                    v311
                | US14_0(v109) -> (* Ok *)
                    (* run_target_args'
                    let v114 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v115 : string = "$0.display()"
                    let v116 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v109 v115 
                    let _run_target_args'_v114 = v116 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v117 : string = "$0.display()"
                    let v118 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v109 v117 
                    let _run_target_args'_v114 = v118 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v119 : string = "$0.display()"
                    let v120 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v109 v119 
                    let _run_target_args'_v114 = v120 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v122 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v122 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v126 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v126 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v130 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v130 
                    #endif
#else
                    let v134 : std_path_Display = v109 |> unbox<std_path_Display>
                    let _run_target_args'_v114 = v134 
                    #endif
                    let v137 : std_path_Display = _run_target_args'_v114 
                    let v144 : string = v137 |> string 
                    let v147 : string = method90(v144, v5)
                    (* run_target_args'
                    let v152 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v153 : string = "&*$0"
                    let v154 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v153 
                    let _run_target_args'_v152 = v154 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v155 : string = "&*$0"
                    let v156 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v155 
                    let _run_target_args'_v152 = v156 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v157 : string = "&*$0"
                    let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v147 v157 
                    let _run_target_args'_v152 = v158 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v160 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v160 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v164 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v164 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v168 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v168 
                    #endif
#else
                    let v172 : Ref<Str> = v147 |> unbox<Ref<Str>>
                    let _run_target_args'_v152 = v172 
                    #endif
                    let v175 : Ref<Str> = _run_target_args'_v152 
                    (* run_target_args'
                    let v185 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v186 : string = "String::from($0)"
                    let v187 : std_string_String = Fable.Core.RustInterop.emitRustExpr v175 v186 
                    let _run_target_args'_v185 = v187 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v188 : string = "String::from($0)"
                    let v189 : std_string_String = Fable.Core.RustInterop.emitRustExpr v175 v188 
                    let _run_target_args'_v185 = v189 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v190 : string = "String::from($0)"
                    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v175 v190 
                    let _run_target_args'_v185 = v191 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v193 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v193 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v197 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v197 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v201 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v201 
                    #endif
#else
                    let v205 : std_string_String = v175 |> unbox<std_string_String>
                    let _run_target_args'_v185 = v205 
                    #endif
                    let v208 : std_string_String = _run_target_args'_v185 
                    (* run_target_args'
                    let v218 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v219 : string = "std::path::PathBuf::from($0)"
                    let v220 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v208 v219 
                    let _run_target_args'_v218 = v220 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v221 : string = "std::path::PathBuf::from($0)"
                    let v222 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v208 v221 
                    let _run_target_args'_v218 = v222 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v223 : string = "std::path::PathBuf::from($0)"
                    let v224 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v208 v223 
                    let _run_target_args'_v218 = v224 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v226 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v226 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v230 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v230 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v234 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v234 
                    #endif
#else
                    let v238 : std_path_PathBuf = v208 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v218 = v238 
                    #endif
                    let v241 : std_path_PathBuf = _run_target_args'_v218 
                    (* run_target_args'
                    let v248 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v249 : string = "Ok($0)"
                    let v250 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v241 v249 
                    let _run_target_args'_v248 = v250 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v251 : string = "Ok($0)"
                    let v252 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v241 v251 
                    let _run_target_args'_v248 = v252 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v253 : string = "Ok($0)"
                    let v254 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v241 v253 
                    let _run_target_args'_v248 = v254 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v255 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v255 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v256 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v256 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v257 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v257 
                    #endif
#else
                    let v258 : Result<std_path_PathBuf, std_io_Error> = v241 |> Ok
                    let _run_target_args'_v248 = v258 
                    #endif
                    let v259 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v248 
                    v259
            else
                let v316 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v317 : string = $"path: {v0} / error: {v27} / path': {v4} / name: {v5}"
                let v318 : string = v316 + v317 
                (* run_target_args'
                let v323 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v324 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v325 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v318 v324 
                let _run_target_args'_v323 = v325 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v326 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v327 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v318 v326 
                let _run_target_args'_v323 = v327 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v328 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v329 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v318 v328 
                let _run_target_args'_v323 = v329 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v331 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v331 
                #endif
#if FABLE_COMPILER_PYTHON
                let v335 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v335 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v339 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v339 
                #endif
#else
                let v343 : std_io_Error = v318 |> unbox<std_io_Error>
                let _run_target_args'_v323 = v343 
                #endif
                let v346 : std_io_Error = _run_target_args'_v323 
                (* run_target_args'
                let v353 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v354 : string = "Err($0)"
                let v355 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v346 v354 
                let _run_target_args'_v353 = v355 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v356 : string = "Err($0)"
                let v357 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v346 v356 
                let _run_target_args'_v353 = v357 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v358 : string = "Err($0)"
                let v359 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v346 v358 
                let _run_target_args'_v353 = v359 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v360 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v360 
                #endif
#if FABLE_COMPILER_PYTHON
                let v361 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v361 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v362 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v362 
                #endif
#else
                let v363 : Result<std_path_PathBuf, std_io_Error> = v346 |> Error
                let _run_target_args'_v353 = v363 
                #endif
                let v364 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v353 
                v364
        | _ ->
            let v368 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v369 : string = $"path: {v0} / error: {v27} / path': {v4} / name: {v5}"
            let v370 : string = v368 + v369 
            (* run_target_args'
            let v375 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v376 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v377 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v370 v376 
            let _run_target_args'_v375 = v377 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v378 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v379 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v370 v378 
            let _run_target_args'_v375 = v379 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v380 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v381 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v370 v380 
            let _run_target_args'_v375 = v381 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v383 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v387 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v387 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v391 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v391 
            #endif
#else
            let v395 : std_io_Error = v370 |> unbox<std_io_Error>
            let _run_target_args'_v375 = v395 
            #endif
            let v398 : std_io_Error = _run_target_args'_v375 
            (* run_target_args'
            let v405 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v406 : string = "Err($0)"
            let v407 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v398 v406 
            let _run_target_args'_v405 = v407 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v408 : string = "Err($0)"
            let v409 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v398 v408 
            let _run_target_args'_v405 = v409 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v410 : string = "Err($0)"
            let v411 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v398 v410 
            let _run_target_args'_v405 = v411 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v412 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v412 
            #endif
#if FABLE_COMPILER_PYTHON
            let v413 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v413 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v414 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v414 
            #endif
#else
            let v415 : Result<std_path_PathBuf, std_io_Error> = v398 |> Error
            let _run_target_args'_v405 = v415 
            #endif
            let v416 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v405 
            v416
and method124 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v17 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v7 = v17 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v7 = v21 
    #endif
#if FABLE_COMPILER_PYTHON
    let v25 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v7 = v25 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v29 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v7 = v29 
    #endif
#else
    let v33 : System_IO_DirectoryInfo = v2 |> System_IO_DirectoryInfo 
    let _run_target_args'_v7 = v33 
    #endif
    let v36 : System_IO_DirectoryInfo = _run_target_args'_v7 
    let v42 : System.IO.FileAttributes = method121(v36)
    let v43 : System.IO.FileAttributes = method122()
    let v44 : bool = method123(v43, v42)
    if v44 then
        (* run_target_args'
        let v49 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v51 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v49 = v51 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v55 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v49 = v55 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v59 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v49 = v59 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v63 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v49 = v63 
        #endif
#if FABLE_COMPILER_PYTHON
        let v67 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v49 = v67 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v71 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v49 = v71 
        #endif
#else
        let v75 : System_IO_FileInfo = v2 |> System_IO_FileInfo 
        let _run_target_args'_v49 = v75 
        #endif
        let v78 : System_IO_FileInfo = _run_target_args'_v49 
        (* run_target_args'
        let v88 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v90 : string = null |> unbox<string>
        let _run_target_args'_v88 = v90 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v94 : string = null |> unbox<string>
        let _run_target_args'_v88 = v94 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v98 : string = null |> unbox<string>
        let _run_target_args'_v88 = v98 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v102 : string = null |> unbox<string>
        let _run_target_args'_v88 = v102 
        #endif
#if FABLE_COMPILER_PYTHON
        let v106 : string = null |> unbox<string>
        let _run_target_args'_v88 = v106 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v110 : string = null |> unbox<string>
        let _run_target_args'_v88 = v110 
        #endif
#else
        let v113 : (System_IO_FileInfo -> string) = _.LinkTarget
        let v114 : string = v113 v78
        let _run_target_args'_v88 = v114 
        #endif
        let v115 : string = _run_target_args'_v88 
        let v122 : std_path_PathBuf = v115 |> unbox<std_path_PathBuf>
        (* run_target_args'
        let v126 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v127 : string = "Ok($0)"
        let v128 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v122 v127 
        let _run_target_args'_v126 = v128 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v129 : string = "Ok($0)"
        let v130 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v122 v129 
        let _run_target_args'_v126 = v130 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v131 : string = "Ok($0)"
        let v132 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v122 v131 
        let _run_target_args'_v126 = v132 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v133 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
        let _run_target_args'_v126 = v133 
        #endif
#if FABLE_COMPILER_PYTHON
        let v134 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
        let _run_target_args'_v126 = v134 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v135 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
        let _run_target_args'_v126 = v135 
        #endif
#else
        let v136 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
        let _run_target_args'_v126 = v136 
        #endif
        let v137 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v126 
        v137
    else
        let v140 : string = $"file_system.read_link / Fsharp / "
        let v141 : string = $"The file or directory is not a reparse point. / "
        let v142 : string = v140 + v141 
        let v143 : string = $"path: {v0} / result: {v44} / path': {v2} / n: {v1}"
        let v144 : string = v142 + v143 
        (* run_target_args'
        let v149 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v150 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v151 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v144 v150 
        let _run_target_args'_v149 = v151 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v152 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v153 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v144 v152 
        let _run_target_args'_v149 = v153 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v154 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v155 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v144 v154 
        let _run_target_args'_v149 = v155 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v157 : std_io_Error = v144 |> unbox<std_io_Error>
        let _run_target_args'_v149 = v157 
        #endif
#if FABLE_COMPILER_PYTHON
        let v161 : std_io_Error = v144 |> unbox<std_io_Error>
        let _run_target_args'_v149 = v161 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v165 : std_io_Error = v144 |> unbox<std_io_Error>
        let _run_target_args'_v149 = v165 
        #endif
#else
        let v169 : std_io_Error = v144 |> unbox<std_io_Error>
        let _run_target_args'_v149 = v169 
        #endif
        let v172 : std_io_Error = _run_target_args'_v149 
        let v178 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure56(v0)
        method125(v0, v178, v1, v172, v2)
and closure57 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method124(v0, v1, v2)
and closure56 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure57(v0, v1)
and method126 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method20(v0)
    let v5 : string option = method117(v0)
    let v7 : (string -> US5) = method5()
    let v8 : US5 option = v5 |> Option.map v7 
    let v21 : US5 = US5_1
    let v22 : US5 = v8 |> Option.defaultValue v21 
    let v26 : string = method49(v3)
    let v27 : bool = v2 >= 11uy
    if v27 then
        let v28 : string = $"file_system.read_link / "
        let v29 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v30 : string = v28 + v29 
        (* run_target_args'
        let v35 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v36 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v37 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v30 v36 
        let _run_target_args'_v35 = v37 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v38 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v39 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v30 v38 
        let _run_target_args'_v35 = v39 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v40 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v41 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v30 v40 
        let _run_target_args'_v35 = v41 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v43 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v43 
        #endif
#if FABLE_COMPILER_PYTHON
        let v47 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v47 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v51 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v51 
        #endif
#else
        let v55 : std_io_Error = v30 |> unbox<std_io_Error>
        let _run_target_args'_v35 = v55 
        #endif
        let v58 : std_io_Error = _run_target_args'_v35 
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v66 : string = "Err($0)"
        let v67 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v58 v66 
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v68 : string = "Err($0)"
        let v69 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v58 v68 
        let _run_target_args'_v65 = v69 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v70 : string = "Err($0)"
        let v71 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v58 v70 
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v72 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v72 
        #endif
#if FABLE_COMPILER_PYTHON
        let v73 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v73 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v74 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v74 
        #endif
#else
        let v75 : Result<std_path_PathBuf, std_io_Error> = v58 |> Error
        let _run_target_args'_v65 = v75 
        #endif
        let v76 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v65 
        v76
    else
        match v22 with
        | US5_0(v79) -> (* Some *)
            let v82 : string = ""
            let v83 : bool = v0 <> v82 
            if v83 then
                let v86 : uint8 = v2 + 1uy
                let v87 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v86
                let v88 : Result<std_path_PathBuf, std_io_Error> = v87 v79
                let v89 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v91 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v92 : string = "$0.map_err(|x| $1(x))"
                let v93 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v88, v89) v92 
                let _run_target_args'_v91 = v93 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v94 : string = "$0.map_err(|x| $1(x))"
                let v95 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v88, v89) v94 
                let _run_target_args'_v91 = v95 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v96 : string = "$0.map_err(|x| $1(x))"
                let v97 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v88, v89) v96 
                let _run_target_args'_v91 = v97 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v98 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v98 
                #endif
#if FABLE_COMPILER_PYTHON
                let v99 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v99 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v100 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v100 
                #endif
#else
                let v101 : Result<std_path_PathBuf, string> = match v88 with Ok x -> Ok x | Error x -> Error (v89 x)
                let _run_target_args'_v91 = v101 
                #endif
                let v102 : Result<std_path_PathBuf, string> = _run_target_args'_v91 
                let v105 : (std_path_PathBuf -> US14) = method113()
                let v106 : (string -> US14) = method114()
                let v107 : US14 = match v102 with Ok x -> v105 x | Error x -> v106 x
                match v107 with
                | US14_1(v261) -> (* Error *)
                    let v262 : string = $"file_system.read_link / "
                    let v263 : string = $"error': {v261} / error: {v26} / name: {v4}"
                    let v264 : string = v262 + v263 
                    (* run_target_args'
                    let v269 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v270 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v271 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v264 v270 
                    let _run_target_args'_v269 = v271 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v272 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v273 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v264 v272 
                    let _run_target_args'_v269 = v273 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v274 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v275 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v264 v274 
                    let _run_target_args'_v269 = v275 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v277 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v277 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v281 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v281 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v285 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v285 
                    #endif
#else
                    let v289 : std_io_Error = v264 |> unbox<std_io_Error>
                    let _run_target_args'_v269 = v289 
                    #endif
                    let v292 : std_io_Error = _run_target_args'_v269 
                    (* run_target_args'
                    let v299 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v300 : string = "Err($0)"
                    let v301 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v292 v300 
                    let _run_target_args'_v299 = v301 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v302 : string = "Err($0)"
                    let v303 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v292 v302 
                    let _run_target_args'_v299 = v303 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v304 : string = "Err($0)"
                    let v305 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v292 v304 
                    let _run_target_args'_v299 = v305 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v306 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v306 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v307 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v307 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v308 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v308 
                    #endif
#else
                    let v309 : Result<std_path_PathBuf, std_io_Error> = v292 |> Error
                    let _run_target_args'_v299 = v309 
                    #endif
                    let v310 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v299 
                    v310
                | US14_0(v108) -> (* Ok *)
                    (* run_target_args'
                    let v113 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v114 : string = "$0.display()"
                    let v115 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v108 v114 
                    let _run_target_args'_v113 = v115 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v116 : string = "$0.display()"
                    let v117 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v108 v116 
                    let _run_target_args'_v113 = v117 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v118 : string = "$0.display()"
                    let v119 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v108 v118 
                    let _run_target_args'_v113 = v119 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v121 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v121 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v125 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v125 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v129 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v129 
                    #endif
#else
                    let v133 : std_path_Display = v108 |> unbox<std_path_Display>
                    let _run_target_args'_v113 = v133 
                    #endif
                    let v136 : std_path_Display = _run_target_args'_v113 
                    let v143 : string = v136 |> string 
                    let v146 : string = method90(v143, v4)
                    (* run_target_args'
                    let v151 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v152 : string = "&*$0"
                    let v153 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v146 v152 
                    let _run_target_args'_v151 = v153 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v154 : string = "&*$0"
                    let v155 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v146 v154 
                    let _run_target_args'_v151 = v155 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v156 : string = "&*$0"
                    let v157 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v146 v156 
                    let _run_target_args'_v151 = v157 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v159 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v159 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v163 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v163 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v167 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v167 
                    #endif
#else
                    let v171 : Ref<Str> = v146 |> unbox<Ref<Str>>
                    let _run_target_args'_v151 = v171 
                    #endif
                    let v174 : Ref<Str> = _run_target_args'_v151 
                    (* run_target_args'
                    let v184 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v185 : string = "String::from($0)"
                    let v186 : std_string_String = Fable.Core.RustInterop.emitRustExpr v174 v185 
                    let _run_target_args'_v184 = v186 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v187 : string = "String::from($0)"
                    let v188 : std_string_String = Fable.Core.RustInterop.emitRustExpr v174 v187 
                    let _run_target_args'_v184 = v188 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v189 : string = "String::from($0)"
                    let v190 : std_string_String = Fable.Core.RustInterop.emitRustExpr v174 v189 
                    let _run_target_args'_v184 = v190 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v192 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v192 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v196 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v196 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v200 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v200 
                    #endif
#else
                    let v204 : std_string_String = v174 |> unbox<std_string_String>
                    let _run_target_args'_v184 = v204 
                    #endif
                    let v207 : std_string_String = _run_target_args'_v184 
                    (* run_target_args'
                    let v217 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v218 : string = "std::path::PathBuf::from($0)"
                    let v219 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v207 v218 
                    let _run_target_args'_v217 = v219 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v220 : string = "std::path::PathBuf::from($0)"
                    let v221 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v207 v220 
                    let _run_target_args'_v217 = v221 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v222 : string = "std::path::PathBuf::from($0)"
                    let v223 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v207 v222 
                    let _run_target_args'_v217 = v223 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v225 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v225 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v229 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v229 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v233 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v233 
                    #endif
#else
                    let v237 : std_path_PathBuf = v207 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v217 = v237 
                    #endif
                    let v240 : std_path_PathBuf = _run_target_args'_v217 
                    (* run_target_args'
                    let v247 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v248 : string = "Ok($0)"
                    let v249 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v240 v248 
                    let _run_target_args'_v247 = v249 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v250 : string = "Ok($0)"
                    let v251 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v240 v250 
                    let _run_target_args'_v247 = v251 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v252 : string = "Ok($0)"
                    let v253 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v240 v252 
                    let _run_target_args'_v247 = v253 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v254 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v254 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v255 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v255 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v256 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v256 
                    #endif
#else
                    let v257 : Result<std_path_PathBuf, std_io_Error> = v240 |> Ok
                    let _run_target_args'_v247 = v257 
                    #endif
                    let v258 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v247 
                    v258
            else
                let v315 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v316 : string = $"path: {v0} / error: {v26} / path': {v0} / name: {v4}"
                let v317 : string = v315 + v316 
                (* run_target_args'
                let v322 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v323 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v324 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v317 v323 
                let _run_target_args'_v322 = v324 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v325 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v326 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v317 v325 
                let _run_target_args'_v322 = v326 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v327 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v328 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v317 v327 
                let _run_target_args'_v322 = v328 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v330 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v330 
                #endif
#if FABLE_COMPILER_PYTHON
                let v334 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v334 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v338 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v338 
                #endif
#else
                let v342 : std_io_Error = v317 |> unbox<std_io_Error>
                let _run_target_args'_v322 = v342 
                #endif
                let v345 : std_io_Error = _run_target_args'_v322 
                (* run_target_args'
                let v352 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v353 : string = "Err($0)"
                let v354 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v345 v353 
                let _run_target_args'_v352 = v354 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v355 : string = "Err($0)"
                let v356 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v345 v355 
                let _run_target_args'_v352 = v356 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v357 : string = "Err($0)"
                let v358 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v345 v357 
                let _run_target_args'_v352 = v358 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v359 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v359 
                #endif
#if FABLE_COMPILER_PYTHON
                let v360 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v360 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v361 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v361 
                #endif
#else
                let v362 : Result<std_path_PathBuf, std_io_Error> = v345 |> Error
                let _run_target_args'_v352 = v362 
                #endif
                let v363 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v352 
                v363
        | _ ->
            let v367 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v368 : string = $"path: {v0} / error: {v26} / path': {v0} / name: {v4}"
            let v369 : string = v367 + v368 
            (* run_target_args'
            let v374 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v375 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v376 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v369 v375 
            let _run_target_args'_v374 = v376 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v377 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v378 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v369 v377 
            let _run_target_args'_v374 = v378 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v379 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v380 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v369 v379 
            let _run_target_args'_v374 = v380 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v382 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v382 
            #endif
#if FABLE_COMPILER_PYTHON
            let v386 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v386 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v390 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v390 
            #endif
#else
            let v394 : std_io_Error = v369 |> unbox<std_io_Error>
            let _run_target_args'_v374 = v394 
            #endif
            let v397 : std_io_Error = _run_target_args'_v374 
            (* run_target_args'
            let v404 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v405 : string = "Err($0)"
            let v406 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v397 v405 
            let _run_target_args'_v404 = v406 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v407 : string = "Err($0)"
            let v408 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v397 v407 
            let _run_target_args'_v404 = v408 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v409 : string = "Err($0)"
            let v410 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v397 v409 
            let _run_target_args'_v404 = v410 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v411 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v411 
            #endif
#if FABLE_COMPILER_PYTHON
            let v412 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v412 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v413 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v413 
            #endif
#else
            let v414 : Result<std_path_PathBuf, std_io_Error> = v397 |> Error
            let _run_target_args'_v404 = v414 
            #endif
            let v415 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v404 
            v415
and method120 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v6 = v20 
    #endif
#if FABLE_COMPILER_PYTHON
    let v24 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v6 = v24 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v28 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v6 = v28 
    #endif
#else
    let v32 : System_IO_DirectoryInfo = v0 |> System_IO_DirectoryInfo 
    let _run_target_args'_v6 = v32 
    #endif
    let v35 : System_IO_DirectoryInfo = _run_target_args'_v6 
    let v41 : System.IO.FileAttributes = method121(v35)
    let v42 : System.IO.FileAttributes = method122()
    let v43 : bool = method123(v42, v41)
    if v43 then
        (* run_target_args'
        let v48 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v50 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v48 = v50 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v54 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v48 = v54 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v58 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v48 = v58 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v62 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v48 = v62 
        #endif
#if FABLE_COMPILER_PYTHON
        let v66 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v48 = v66 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v70 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v48 = v70 
        #endif
#else
        let v74 : System_IO_FileInfo = v0 |> System_IO_FileInfo 
        let _run_target_args'_v48 = v74 
        #endif
        let v77 : System_IO_FileInfo = _run_target_args'_v48 
        (* run_target_args'
        let v87 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v89 : string = null |> unbox<string>
        let _run_target_args'_v87 = v89 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v93 : string = null |> unbox<string>
        let _run_target_args'_v87 = v93 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v97 : string = null |> unbox<string>
        let _run_target_args'_v87 = v97 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v101 : string = null |> unbox<string>
        let _run_target_args'_v87 = v101 
        #endif
#if FABLE_COMPILER_PYTHON
        let v105 : string = null |> unbox<string>
        let _run_target_args'_v87 = v105 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v109 : string = null |> unbox<string>
        let _run_target_args'_v87 = v109 
        #endif
#else
        let v112 : (System_IO_FileInfo -> string) = _.LinkTarget
        let v113 : string = v112 v77
        let _run_target_args'_v87 = v113 
        #endif
        let v114 : string = _run_target_args'_v87 
        let v121 : std_path_PathBuf = v114 |> unbox<std_path_PathBuf>
        (* run_target_args'
        let v125 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v126 : string = "Ok($0)"
        let v127 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v121 v126 
        let _run_target_args'_v125 = v127 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v128 : string = "Ok($0)"
        let v129 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v121 v128 
        let _run_target_args'_v125 = v129 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v130 : string = "Ok($0)"
        let v131 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v121 v130 
        let _run_target_args'_v125 = v131 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v132 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
        let _run_target_args'_v125 = v132 
        #endif
#if FABLE_COMPILER_PYTHON
        let v133 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
        let _run_target_args'_v125 = v133 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v134 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
        let _run_target_args'_v125 = v134 
        #endif
#else
        let v135 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
        let _run_target_args'_v125 = v135 
        #endif
        let v136 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v125 
        v136
    else
        let v139 : string = $"file_system.read_link / Fsharp / "
        let v140 : string = $"The file or directory is not a reparse point. / "
        let v141 : string = v139 + v140 
        let v142 : string = $"path: {v0} / result: {v43} / path': {v0} / n: {v1}"
        let v143 : string = v141 + v142 
        (* run_target_args'
        let v148 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v149 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v150 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v143 v149 
        let _run_target_args'_v148 = v150 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v151 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v152 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v143 v151 
        let _run_target_args'_v148 = v152 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v153 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v154 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v143 v153 
        let _run_target_args'_v148 = v154 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v156 : std_io_Error = v143 |> unbox<std_io_Error>
        let _run_target_args'_v148 = v156 
        #endif
#if FABLE_COMPILER_PYTHON
        let v160 : std_io_Error = v143 |> unbox<std_io_Error>
        let _run_target_args'_v148 = v160 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v164 : std_io_Error = v143 |> unbox<std_io_Error>
        let _run_target_args'_v148 = v164 
        #endif
#else
        let v168 : std_io_Error = v143 |> unbox<std_io_Error>
        let _run_target_args'_v148 = v168 
        #endif
        let v171 : std_io_Error = _run_target_args'_v148 
        let v177 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure56(v0)
        method126(v0, v177, v1, v171)
and method111 (v0 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : bool = method10(v0)
    let v8 : Result<std_path_PathBuf, std_io_Error> =
        if v3 then
            let v4 : string = "std::fs::read_link(&*$0)"
            let v5 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v4 
            v5
        else
            let v6 : uint8 = 0uy
            method112(v0, v6)
    let _run_target_args'_v2 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v9 : bool = method10(v0)
    let v14 : Result<std_path_PathBuf, std_io_Error> =
        if v9 then
            let v10 : string = "std::fs::read_link(&*$0)"
            let v11 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v10 
            v11
        else
            let v12 : uint8 = 0uy
            method112(v0, v12)
    let _run_target_args'_v2 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : bool = method10(v0)
    let v20 : Result<std_path_PathBuf, std_io_Error> =
        if v15 then
            let v16 : string = "std::fs::read_link(&*$0)"
            let v17 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v16 
            v17
        else
            let v18 : uint8 = 0uy
            method112(v0, v18)
    let _run_target_args'_v2 = v20 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : uint8 = 0uy
    let v22 : Result<std_path_PathBuf, std_io_Error> = method120(v0, v21)
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : Result<std_path_PathBuf, std_io_Error> = Unchecked.defaultof<_>
    let _run_target_args'_v2 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : uint8 = 0uy
    let v25 : Result<std_path_PathBuf, std_io_Error> = method120(v0, v24)
    let _run_target_args'_v2 = v25 
    #endif
#else
    let v26 : uint8 = 0uy
    let v27 : Result<std_path_PathBuf, std_io_Error> = method120(v0, v26)
    let _run_target_args'_v2 = v27 
    #endif
    let v28 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v2 
    v28
and closure58 () (v0 : std_path_PathBuf) : US15 =
    US15_0(v0)
and method127 () : (std_path_PathBuf -> US15) =
    closure58()
and method129 (v0 : string) : string =
    v0
and method130 () : string =
    let v0 : string = ""
    v0
and method128 (v0 : string, v1 : string, v2 : string) : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = $"regex::Regex::new(&$0)"
    let v6 : Result<regex_Regex, regex_Error> = Fable.Core.RustInterop.emitRustExpr v0 v5 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "$0.unwrap()"
    let v10 : regex_Regex = Fable.Core.RustInterop.emitRustExpr v6 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "$0.unwrap()"
    let v12 : regex_Regex = Fable.Core.RustInterop.emitRustExpr v6 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "$0.unwrap()"
    let v14 : regex_Regex = Fable.Core.RustInterop.emitRustExpr v6 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v15 : regex_Regex = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v15 
    #endif
#if FABLE_COMPILER_PYTHON
    let v16 : regex_Regex = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v16 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v17 : regex_Regex = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v17 
    #endif
#else
    let v18 : regex_Regex = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v18 
    #endif
    let v19 : regex_Regex = _run_target_args'_v8 
    let v22 : string = method129(v2)
    let v23 : string = $"$0.replace_all(&*$1, &*$2)"
    let v24 : std_borrow_Cow<Str> = Fable.Core.RustInterop.emitRustExpr struct (v19, v22, v1) v23 
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v4 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = method130()
    let _run_target_args'_v4 = v29 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v30 : string = method130()
    let _run_target_args'_v4 = v30 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v31 : string = method130()
    let _run_target_args'_v4 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : string = method130()
    let _run_target_args'_v4 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v33 : string = method130()
    let _run_target_args'_v4 = v33 
    #endif
#else
    let v34 : string = System.Text.RegularExpressions.Regex.Replace (v2, v0, v1)
    let _run_target_args'_v4 = v34 
    #endif
    let v35 : string = _run_target_args'_v4 
    v35
and method110 (v0 : string) : string =
    let v1 : bool = v0 = ""
    if v1 then
        let v2 : string = ""
        v2
    else
        let v3 : Result<std_path_PathBuf, std_io_Error> = method111(v0)
        (* run_target_args'
        let v5 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v6 : string = "$0.ok()"
        let v7 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v3 v6 
        let _run_target_args'_v5 = v7 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v8 : string = "$0.ok()"
        let v9 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v3 v8 
        let _run_target_args'_v5 = v9 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v10 : string = "$0.ok()"
        let v11 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v3 v10 
        let _run_target_args'_v5 = v11 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v12 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v5 = v12 
        #endif
#if FABLE_COMPILER_PYTHON
        let v13 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v5 = v13 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v14 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v5 = v14 
        #endif
#else
        let v15 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v5 = v15 
        #endif
        let v16 : std_path_PathBuf option = _run_target_args'_v5 
        let v20 : (std_path_PathBuf -> US15) = method127()
        let v21 : US15 option = v16 |> Option.map v20 
        let v34 : US15 = US15_1
        let v35 : US15 = v21 |> Option.defaultValue v34 
        let v78 : string =
            match v35 with
            | US15_1 -> (* None *)
                v0
            | US15_0(v39) -> (* Some *)
                (* run_target_args'
                let v44 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45 : string = "$0.display()"
                let v46 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v39 v45 
                let _run_target_args'_v44 = v46 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v47 : string = "$0.display()"
                let v48 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v39 v47 
                let _run_target_args'_v44 = v48 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v49 : string = "$0.display()"
                let v50 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v39 v49 
                let _run_target_args'_v44 = v50 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v52 : std_path_Display = v39 |> unbox<std_path_Display>
                let _run_target_args'_v44 = v52 
                #endif
#if FABLE_COMPILER_PYTHON
                let v56 : std_path_Display = v39 |> unbox<std_path_Display>
                let _run_target_args'_v44 = v56 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v60 : std_path_Display = v39 |> unbox<std_path_Display>
                let _run_target_args'_v44 = v60 
                #endif
#else
                let v64 : std_path_Display = v39 |> unbox<std_path_Display>
                let _run_target_args'_v44 = v64 
                #endif
                let v67 : std_path_Display = _run_target_args'_v44 
                let v74 : string = v67 |> string 
                v74
        let v79 : bool = v78 = ""
        let v80 : string =
            if v79 then
                v0
            else
                v78
        let v81 : string = "^\\\\\\\\\\?\\\\"
        let v82 : string = ""
        let v83 : string = method128(v81, v82, v80)
        let v84 : int32 = v83.Length
        let v85 : bool = v84 < 2
        if v85 then
            v0
        else
            let v86 : string = $"{v83.[0] |> string |> _.ToLower()}{v83.[1..]}"
            let v87 : string = "\\"
            let v88 : string = "/"
            let v89 : string = v86.Replace (v87, v88)
            v89
and closure51 () (v0 : string) : string =
    method110(v0)
and method132 () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = "std::env::current_dir()"
    let v6 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr () v5 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "$0.unwrap()"
    let v10 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v6 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "$0.unwrap()"
    let v12 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v6 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "$0.unwrap()"
    let v14 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v6 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v15 : std_path_PathBuf = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v15 
    #endif
#if FABLE_COMPILER_PYTHON
    let v16 : std_path_PathBuf = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v16 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v17 : std_path_PathBuf = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v17 
    #endif
#else
    let v18 : std_path_PathBuf = match v6 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v8 = v18 
    #endif
    let v19 : std_path_PathBuf = _run_target_args'_v8 
    (* run_target_args'
    let v26 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v27 : string = "$0.display()"
    let v28 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v19 v27 
    let _run_target_args'_v26 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = "$0.display()"
    let v30 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v19 v29 
    let _run_target_args'_v26 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "$0.display()"
    let v32 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v19 v31 
    let _run_target_args'_v26 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v34 : std_path_Display = v19 |> unbox<std_path_Display>
    let _run_target_args'_v26 = v34 
    #endif
#if FABLE_COMPILER_PYTHON
    let v38 : std_path_Display = v19 |> unbox<std_path_Display>
    let _run_target_args'_v26 = v38 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v42 : std_path_Display = v19 |> unbox<std_path_Display>
    let _run_target_args'_v26 = v42 
    #endif
#else
    let v46 : std_path_Display = v19 |> unbox<std_path_Display>
    let _run_target_args'_v26 = v46 
    #endif
    let v49 : std_path_Display = _run_target_args'_v26 
    (* run_target_args'
    let v59 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v60 : string = "format!(\"{}\", $0)"
    let v61 : std_string_String = Fable.Core.RustInterop.emitRustExpr v49 v60 
    let _run_target_args'_v59 = v61 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v62 : string = "format!(\"{}\", $0)"
    let v63 : std_string_String = Fable.Core.RustInterop.emitRustExpr v49 v62 
    let _run_target_args'_v59 = v63 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v64 : string = "format!(\"{}\", $0)"
    let v65 : std_string_String = Fable.Core.RustInterop.emitRustExpr v49 v64 
    let _run_target_args'_v59 = v65 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v67 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v59 = v67 
    #endif
#if FABLE_COMPILER_PYTHON
    let v71 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v59 = v71 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v75 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v59 = v75 
    #endif
#else
    let v79 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v59 = v79 
    #endif
    let v82 : std_string_String = _run_target_args'_v59 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v82 v88 
    let _run_target_args'_v4 = v89 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = null |> unbox<string>
    let _run_target_args'_v4 = v91 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = null |> unbox<string>
    let _run_target_args'_v4 = v95 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v98 : string = "fs"
    let v99 : IFs = Fable.Core.JsInterop.importAll v98 
    let v100 : string = "fs.realpathSync('.')"
    let v101 : string = Fable.Core.JsInterop.emitJsExpr () v100 
    let _run_target_args'_v4 = v101 
    #endif
#if FABLE_COMPILER_PYTHON
    let v103 : string = null |> unbox<string>
    let _run_target_args'_v4 = v103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v107 : string = null |> unbox<string>
    let _run_target_args'_v4 = v107 
    #endif
#else
    let v110 : (unit -> string) = System.IO.Directory.GetCurrentDirectory
    let v111 : string = v110 ()
    let _run_target_args'_v4 = v111 
    #endif
    let v112 : string = _run_target_args'_v4 
    v112
and method133 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method134 (v0 : int32, v1 : Mut6) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method135 () : char =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "std::path::MAIN_SEPARATOR"
    let v3 : char = Fable.Core.RustInterop.emitRustExpr () v2 
    let _run_target_args'_v1 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : string = "std::path::MAIN_SEPARATOR"
    let v5 : char = Fable.Core.RustInterop.emitRustExpr () v4 
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6 : string = "std::path::MAIN_SEPARATOR"
    let v7 : char = Fable.Core.RustInterop.emitRustExpr () v6 
    let _run_target_args'_v1 = v7 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v1 = '/' 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v1 = '/' 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v8 : char = System.IO.Path.DirectorySeparatorChar
    let _run_target_args'_v1 = v8 
    #endif
#else
    let v9 : char = System.IO.Path.DirectorySeparatorChar
    let _run_target_args'_v1 = v9 
    #endif
    let v10 : char = _run_target_args'_v1 
    v10
and method136 (v0 : string) : string =
    v0
and method131 (v0 : string) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v18 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
#else
    let v30 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v30 
    #endif
    let v33 : Ref<Str> = _run_target_args'_v10 
    (* run_target_args'
    let v43 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v44 : string = "String::from($0)"
    let v45 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v44 
    let _run_target_args'_v43 = v45 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v46 : string = "String::from($0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v46 
    let _run_target_args'_v43 = v47 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v48 : string = "String::from($0)"
    let v49 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v48 
    let _run_target_args'_v43 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v51 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v51 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v59 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v59 
    #endif
#else
    let v63 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v43 = v63 
    #endif
    let v66 : std_string_String = _run_target_args'_v43 
    (* run_target_args'
    let v76 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v77 : string = "std::path::PathBuf::from($0)"
    let v78 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v77 
    let _run_target_args'_v76 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : string = "std::path::PathBuf::from($0)"
    let v80 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v79 
    let _run_target_args'_v76 = v80 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v81 : string = "std::path::PathBuf::from($0)"
    let v82 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v66 v81 
    let _run_target_args'_v76 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v84 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v84 
    #endif
#if FABLE_COMPILER_PYTHON
    let v88 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v88 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v92 
    #endif
#else
    let v96 : std_path_PathBuf = v66 |> unbox<std_path_PathBuf>
    let _run_target_args'_v76 = v96 
    #endif
    let v99 : std_path_PathBuf = _run_target_args'_v76 
    let v105 : string = "$0.exists()"
    let v106 : bool = Fable.Core.RustInterop.emitRustExpr v99 v105 
    let v107 : bool = v106 = false
    let v289 : string =
        if v107 then
            let v108 : string = method132()
            let v109 : string = method90(v108, v0)
            let v110 : string = method110(v109)
            let v112 : string = "/"
            let v113 : (string []) = v110.Split v112 
            let v116 : (string []) = [||]
            let v117 : int32 = v113.Length
            let v118 : Mut5 = {l0 = 0; l1 = 0; l2 = v116} : Mut5
            while method133(v117, v118) do
                let v120 : int32 = v118.l0
                let v121 : int32 =  -v120
                let v122 : int32 = v121 + v117
                let v123 : int32 = v122 - 1
                let struct (v124 : int32, v125 : (string [])) = v118.l1, v118.l2
                let v126 : string = v113.[int v123]
                let v127 : bool = ".." = v126
                let struct (v172 : int32, v173 : (string [])) =
                    if v127 then
                        let v128 : int32 = v124 + 1
                        struct (v128, v125)
                    else
                        let v129 : bool = "." = v126
                        if v129 then
                            struct (v124, v125)
                        else
                            let v130 : bool = 0 = v124
                            if v130 then
                                let v132 : string = ":"
                                let v133 : bool = v126.EndsWith (v132, false, null)
                                if v133 then
                                    let v136 : string = $"{v108.[0]}:"
                                    let v137 : (string []) = [|v136|]
                                    let v138 : int32 = v137.Length
                                    let v139 : int32 = v125.Length
                                    let v140 : int32 = v138 + v139
                                    let v141 : (string []) = Array.zeroCreate<string> (v140)
                                    let v142 : Mut6 = {l0 = 0} : Mut6
                                    while method134(v140, v142) do
                                        let v144 : int32 = v142.l0
                                        let v145 : bool = v144 < v138
                                        let v149 : string =
                                            if v145 then
                                                let v146 : string = v137.[int v144]
                                                v146
                                            else
                                                let v147 : int32 = v144 - v138
                                                let v148 : string = v125.[int v147]
                                                v148
                                        v141.[int v144] <- v149
                                        let v150 : int32 = v144 + 1
                                        v142.l0 <- v150
                                        ()
                                    struct (0, v141)
                                else
                                    let v151 : (string []) = [|v126|]
                                    let v152 : int32 = v151.Length
                                    let v153 : int32 = v125.Length
                                    let v154 : int32 = v152 + v153
                                    let v155 : (string []) = Array.zeroCreate<string> (v154)
                                    let v156 : Mut6 = {l0 = 0} : Mut6
                                    while method134(v154, v156) do
                                        let v158 : int32 = v156.l0
                                        let v159 : bool = v158 < v152
                                        let v163 : string =
                                            if v159 then
                                                let v160 : string = v151.[int v158]
                                                v160
                                            else
                                                let v161 : int32 = v158 - v152
                                                let v162 : string = v125.[int v161]
                                                v162
                                        v155.[int v158] <- v163
                                        let v164 : int32 = v158 + 1
                                        v156.l0 <- v164
                                        ()
                                    struct (0, v155)
                            else
                                let v167 : int32 = v124 - 1
                                struct (v167, v125)
                let v174 : int32 = v120 + 1
                v118.l0 <- v174
                v118.l1 <- v172
                v118.l2 <- v173
                ()
            let struct (v175 : int32, v176 : (string [])) = v118.l1, v118.l2
            let v180 : unit = ()
            let _let'_v180 =
                seq {
                    for i = 0 to v176.Length - 1 do yield v176.[i]
                    (* indent
                    ()
                indent *)
                }
                (* indent
                ()
            indent *)
            let v183 : string seq = _let'_v180 
            let v189 : char = method135()
            let v191 : (char -> string) = _.ToString()
            let v192 : string = v191 v189
            let v196 : bool = v192 = "\n"
            let v198 : string =
                if v196 then
                    method136(v192)
                else
                    v192
            let v199 : (string -> (string seq -> string)) = String.concat
            let v200 : (string seq -> string) = v199 v198
            v200 v183
        else
            let v204 : string = "std::fs::canonicalize(&*$0)"
            let v205 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v204 
            (* run_target_args'
            let v207 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v208 : string = "$0.unwrap()"
            let v209 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v205 v208 
            let _run_target_args'_v207 = v209 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v210 : string = "$0.unwrap()"
            let v211 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v205 v210 
            let _run_target_args'_v207 = v211 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v212 : string = "$0.unwrap()"
            let v213 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v205 v212 
            let _run_target_args'_v207 = v213 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v214 : std_path_PathBuf = match v205 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v207 = v214 
            #endif
#if FABLE_COMPILER_PYTHON
            let v215 : std_path_PathBuf = match v205 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v207 = v215 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v216 : std_path_PathBuf = match v205 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v207 = v216 
            #endif
#else
            let v217 : std_path_PathBuf = match v205 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v207 = v217 
            #endif
            let v218 : std_path_PathBuf = _run_target_args'_v207 
            (* run_target_args'
            let v225 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v226 : string = "$0.display()"
            let v227 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v218 v226 
            let _run_target_args'_v225 = v227 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v228 : string = "$0.display()"
            let v229 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v218 v228 
            let _run_target_args'_v225 = v229 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v230 : string = "$0.display()"
            let v231 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v218 v230 
            let _run_target_args'_v225 = v231 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v233 : std_path_Display = v218 |> unbox<std_path_Display>
            let _run_target_args'_v225 = v233 
            #endif
#if FABLE_COMPILER_PYTHON
            let v237 : std_path_Display = v218 |> unbox<std_path_Display>
            let _run_target_args'_v225 = v237 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v241 : std_path_Display = v218 |> unbox<std_path_Display>
            let _run_target_args'_v225 = v241 
            #endif
#else
            let v245 : std_path_Display = v218 |> unbox<std_path_Display>
            let _run_target_args'_v225 = v245 
            #endif
            let v248 : std_path_Display = _run_target_args'_v225 
            (* run_target_args'
            let v258 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v259 : string = "format!(\"{}\", $0)"
            let v260 : std_string_String = Fable.Core.RustInterop.emitRustExpr v248 v259 
            let _run_target_args'_v258 = v260 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v261 : string = "format!(\"{}\", $0)"
            let v262 : std_string_String = Fable.Core.RustInterop.emitRustExpr v248 v261 
            let _run_target_args'_v258 = v262 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v263 : string = "format!(\"{}\", $0)"
            let v264 : std_string_String = Fable.Core.RustInterop.emitRustExpr v248 v263 
            let _run_target_args'_v258 = v264 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v266 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v258 = v266 
            #endif
#if FABLE_COMPILER_PYTHON
            let v270 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v258 = v270 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v274 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v258 = v274 
            #endif
#else
            let v278 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v258 = v278 
            #endif
            let v281 : std_string_String = _run_target_args'_v258 
            let v287 : string = "fable_library_rust::String_::fromString($0)"
            let v288 : string = Fable.Core.RustInterop.emitRustExpr v281 v287 
            v288
    let _run_target_args'_v5 = v289 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v291 : string = null |> unbox<string>
    let _run_target_args'_v5 = v291 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v295 : string = null |> unbox<string>
    let _run_target_args'_v5 = v295 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v299 : string = null |> unbox<string>
    let _run_target_args'_v5 = v299 
    #endif
#if FABLE_COMPILER_PYTHON
    let v303 : string = null |> unbox<string>
    let _run_target_args'_v5 = v303 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v307 : string = null |> unbox<string>
    let _run_target_args'_v5 = v307 
    #endif
#else
    let v310 : (string -> string) = System.IO.Path.GetFullPath
    let v311 : string = v310 v0
    let _run_target_args'_v5 = v311 
    #endif
    let v312 : string = _run_target_args'_v5 
    v312
and closure59 () (v0 : string) : string =
    method131(v0)
and method137 (v0 : string) : string =
    let v1 : string = method131(v0)
    method110(v1)
and closure60 () (v0 : string) : string =
    method137(v0)
and closure61 () (v0 : string) : string =
    let v1 : char list = []
    let v3 : char list = '/' :: v1 
    let v8 : (char list -> (char [])) = List.toArray
    let v9 : (char []) = v8 v3
    let v12 : string = v0.TrimStart v9 
    let v41 : string = $"file:///{v12}"
    v41
and closure63 () (v0 : string) : bool =
    method38(v0)
and closure64 () (v0 : string) : bool =
    method10(v0)
and method141 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool), v4 : string) : US17 =
    let v5 : string = method90(v4, v0)
    let v6 : bool = v3 v5
    if v6 then
        US17_0(v4)
    else
        let v8 : string option = method117(v4)
        let v10 : (string -> US5) = method5()
        let v11 : US5 option = v8 |> Option.map v10 
        let v24 : US5 = US5_1
        let v25 : US5 = v11 |> Option.defaultValue v24 
        match v25 with
        | US5_1 -> (* None *)
            let v31 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v32 : string = $" '{v0}' at '{v1}' (until '{v4}')"
            let v33 : string = v31 + v32 
            US17_1(v33)
        | US5_0(v29) -> (* Some *)
            method141(v0, v1, v2, v3, v29)
and method140 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool)) : US17 =
    let v4 : string = method90(v1, v0)
    let v5 : bool = v3 v4
    if v5 then
        US17_0(v1)
    else
        let v7 : string option = method117(v1)
        let v9 : (string -> US5) = method5()
        let v10 : US5 option = v7 |> Option.map v9 
        let v23 : US5 = US5_1
        let v24 : US5 = v10 |> Option.defaultValue v23 
        match v24 with
        | US5_1 -> (* None *)
            let v30 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v31 : string = $" '{v0}' at '{v1}' (until '{v1}')"
            let v32 : string = v30 + v31 
            US17_1(v32)
        | US5_0(v28) -> (* Some *)
            method141(v0, v1, v2, v3, v28)
and method139 (v0 : US16, v1 : string, v2 : string) : US17 =
    let v3 : bool =
        match v0 with
        | US16_0 -> (* File *)
            true
        | _ ->
            false
    let v6 : (string -> bool) =
        if v3 then
            closure63()
        else
            closure64()
    method140(v1, v2, v3, v6)
and method143 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v3, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v15 : string = "dir"
    let v16 : string = $"{v15}"
    let v19 : unit = ()
    let v20 : (unit -> unit) = closure6(v3, v16)
    let v21 : unit = (fun () -> v20 (); v19) ()
    let v25 : string = " = "
    let v26 : string = $"{v25}"
    let v29 : unit = ()
    let v30 : (unit -> unit) = closure6(v3, v26)
    let v31 : unit = (fun () -> v30 (); v29) ()
    let v35 : string = $"{v0}"
    let v38 : unit = ()
    let v39 : (unit -> unit) = closure6(v3, v35)
    let v40 : unit = (fun () -> v39 (); v38) ()
    let v44 : string = "; "
    let v45 : string = $"{v44}"
    let v48 : unit = ()
    let v49 : (unit -> unit) = closure6(v3, v45)
    let v50 : unit = (fun () -> v49 (); v48) ()
    let v54 : string = "error"
    let v55 : string = $"{v54}"
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure6(v3, v55)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v64 : string = $"{v25}"
    let v67 : unit = ()
    let v68 : (unit -> unit) = closure6(v3, v64)
    let v69 : unit = (fun () -> v68 (); v67) ()
    let v73 : string = $"{v1}"
    let v76 : unit = ()
    let v77 : (unit -> unit) = closure6(v3, v73)
    let v78 : unit = (fun () -> v77 (); v76) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v3, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = v3.l0
    v91
and method142 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method143(v8, v9)
    let v11 : int64 = v0.l0
    let v13 : string = "file_system.get_workspace_root"
    let v14 : string = $"{v6} {v7} #{v11} %s{v13} / {v10}"
    method23(v14)
and closure65 (v0 : string, v1 : string) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v27 : Mut0, v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : int64 option) = TraceState.trace_state.Value
        let v45 : string = method12(v27, v28, v29, v30, v31, v32)
        let v46 : string = method55()
        let v47 : string = method142(v27, v28, v29, v30, v31, v32, v45, v46, v0, v1)
        method24(v47)
and method138 (v0 : string) : US5 =
    let v1 : US16 = US16_1
    let v2 : string = "spiral"
    let v3 : string = "workspace"
    let v4 : string = method90(v2, v3)
    let v5 : US17 = method139(v1, v4, v0)
    match v5 with
    | US17_1(v9) -> (* Error *)
        let v10 : unit = ()
        let v11 : (unit -> unit) = closure65(v0, v9)
        let v12 : unit = (fun () -> v11 (); v10) ()
        US5_1
    | US17_0(v6) -> (* Ok *)
        let v7 : string = method110(v6)
        US5_0(v7)
and closure62 () () : string =
    let v0 : string = method132()
    let v1 : US5 = method138(v0)
    let v7 : US5 =
        match v1 with
        | US5_1 -> (* None *)
            let v4 : string = __SOURCE_DIRECTORY__
            method138(v4)
        | US5_0(v2) -> (* Some *)
            US5_0(v2)
    let v13 : US5 =
        match v7 with
        | US5_1 -> (* None *)
            let v10 : string = "/workspaces"
            method138(v10)
        | US5_0(v8) -> (* Some *)
            US5_0(v8)
    let v17 : string =
        match v13 with
        | US5_1 -> (* None *)
            failwith<string> "Option does not have a value."
        | US5_0(v14) -> (* Some *)
            v14
    let v18 : string = method20(v17)
    let v19 : bool = "deps" = v18
    let v30 : string =
        if v19 then
            let v20 : string option = method117(v17)
            let v22 : string = v20 |> Option.get
            let v25 : US5 = method138(v22)
            match v25 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v26) -> (* Some *)
                v26
        else
            v17
    let v31 : string = "polyglot"
    method90(v30, v31)
and closure67 (v0 : exn) () : exn =
    v0
and method144 (v0 : string) : unit =
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
    try
        let v2 : string = method91()
        (* run_target_args'
        let v5 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v6 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v5 = v6 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v7 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v5 = v7 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v9 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v5 = v9 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v12 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v5 = v12 
        #endif
#if FABLE_COMPILER_PYTHON
        let v13 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v5 = v13 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v14 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v5 = v14 
        #endif
#else
        let v15 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v5 = v15 
        #endif
        let v16 : System.DateTime = _run_target_args'_v5 
        let v22 : (unit -> System.Guid) = System.Guid.NewGuid
        let v23 : System.Guid = v22 ()
        let v26 : System.Guid = method82(v23, v16)
        let v27 : string = $"{v2}_{v26}.txt"
        let v28 : string = method132()
        let v29 : US5 = method138(v28)
        let v35 : US5 =
            match v29 with
            | US5_1 -> (* None *)
                let v32 : string = __SOURCE_DIRECTORY__
                method138(v32)
            | US5_0(v30) -> (* Some *)
                US5_0(v30)
        let v41 : US5 =
            match v35 with
            | US5_1 -> (* None *)
                let v38 : string = "/workspaces"
                method138(v38)
            | US5_0(v36) -> (* Some *)
                US5_0(v36)
        let v45 : string =
            match v41 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v42) -> (* Some *)
                v42
        let v46 : string = method20(v45)
        let v47 : bool = "deps" = v46
        let v58 : string =
            if v47 then
                let v48 : string option = method117(v45)
                let v50 : string = v48 |> Option.get
                let v53 : US5 = method138(v50)
                match v53 with
                | US5_1 -> (* None *)
                    failwith<string> "Option does not have a value."
                | US5_0(v54) -> (* Some *)
                    v54
            else
                v45
        let v59 : string = "polyglot"
        let v60 : string = method90(v58, v59)
        let v61 : string = "target/trace"
        let v62 : string = method90(v60, v61)
        let v63 : System_IO_DirectoryInfo = method103(v62)
        let v64 : string = method90(v62, v27)
        let v65 : Async<unit> = method40(v64, v0)
        (* run_target_args'
        let v66 : unit = ()
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
        null |> unbox<unit>
        #endif
#if FABLE_COMPILER_PYTHON
        let v67 : (Async<unit> -> unit) = Async.RunSynchronously
        v67 v65
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v68 : (Async<unit> -> unit) = Async.RunSynchronously
        v68 v65
        #endif
#else
        let v69 : (Async<unit> -> unit) = Async.RunSynchronously
        v69 v65
        #endif
        // run_target_args' is_unit
        (* indent
        ()
    indent *)
    with ex ->
        let v138 : exn = ex
        let v139 : (unit -> exn) = closure67(v138)
        let v140 : string = $"file_system.trace_file / ex: %A{v139}"
        let v141 : unit = ()
        let v142 : (unit -> unit) = closure9(v140)
        let v143 : unit = (fun () -> v142 (); v141) ()
        method144(v140)
        (* indent
        ()
    indent *)
    (* try_unit
    try_unit *)
    #endif
    // run_target_args' is_unit
    ()
and closure66 () (v0 : string) : unit =
    method144(v0)
and closure68 () (v0 : bool) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure0()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut0, v25 : Mut1, v26 : Mut2, v27 : Mut3, v28 : Mut4, v29 : int64 option) = TraceState.trace_state.Value
    let v44 : (string -> unit) =
        if v0 then
            closure66()
        else
            closure2()
    v25.l0 <- v44
    ()
and method145 (v0 : string, v1 : string) : unit =
    let v2 : bool = method10(v0)
    let v3 : bool = v2 = false
    if v3 then
        let v4 : System.IDisposable = method93(v0)
        ()
    let v5 : string option = method117(v1)
    let v7 : string = ""
    let v8 : string = v5 |> Option.defaultValue v7 
    let v11 : bool = method10(v8)
    let v12 : bool = v11 = false
    if v12 then
        let v13 : System.IDisposable = method93(v8)
        ()
    let v14 : bool = method10(v1)
    let v25 : bool =
        if v14 then
            let v15 : Result<std_path_PathBuf, std_io_Error> = method111(v1)
            (* run_target_args'
            let v16 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v17 : string = "$0.is_err()"
            let v18 : bool = Fable.Core.RustInterop.emitRustExpr v15 v17 
            let _run_target_args'_v16 = v18 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v19 : string = "$0.is_err()"
            let v20 : bool = Fable.Core.RustInterop.emitRustExpr v15 v19 
            let _run_target_args'_v16 = v20 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v21 : string = "$0.is_err()"
            let v22 : bool = Fable.Core.RustInterop.emitRustExpr v15 v21 
            let _run_target_args'_v16 = v22 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let _run_target_args'_v16 = true 
            #endif
#if FABLE_COMPILER_PYTHON
            let _run_target_args'_v16 = true 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let _run_target_args'_v16 = true 
            #endif
#else
            let _run_target_args'_v16 = true 
            #endif
            let v23 : bool = _run_target_args'_v16 
            v23
        else
            false
    if v25 then
        let v26 : bool = true
        method9(v26, v1)
    let v27 : bool = method10(v1)
    let v28 : bool = v27 = false
    if v28 then
        (* run_target_args'
        let v29 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v30 : string = "true; #[cfg(windows)] std::os::windows::fs::symlink_dir(&*$0, &*$1).unwrap()"
        let v31 : bool = Fable.Core.RustInterop.emitRustExpr struct (v0, v1) v30 
        let v32 : string = "true; #[cfg(unix)] std::os::unix::fs::symlink(&*$0, &*$1).unwrap()"
        let v33 : bool = Fable.Core.RustInterop.emitRustExpr struct (v0, v1) v32 
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
        let v34 : System.IO.FileSystemInfo = System.IO.Directory.CreateSymbolicLink (v1, v0)
        #endif
        // run_target_args' is_unit
        ()
and closure70 (v0 : string) (v1 : string) : unit =
    method145(v0, v1)
and closure69 () (v0 : string) : (string -> unit) =
    closure70(v0)
and closure72 (v0 : string) (v1 : string) : string =
    method90(v0, v1)
and closure71 () (v0 : string) : (string -> string) =
    closure72(v0)
let v0 : unit = ()
let v1 : (unit -> unit) = closure0()
let v2 : unit = (fun () -> v1 (); v0) ()
let v17 : (string -> Async<int64>) = closure3()
let delete_directory_async x = v17 x
let v18 : (US6 -> (string -> Async<int64>)) = closure10()
let wait_for_file_access x = v18 x
let v19 : (string -> Async<int64>) = closure13()
let wait_for_file_access_read x = v19 x
let v20 : (string -> Async<string>) = closure14()
let read_all_text_async x = v20 x
let v21 : (string -> (string -> bool)) = closure16()
let file_exists_content x = v21 x
let v22 : (string -> (string -> Async<unit>)) = closure18()
let write_all_text_async x = v22 x
let v23 : (string -> (string -> Async<unit>)) = closure20()
let write_all_text_exists x = v23 x
let v24 : (string -> Async<int64>) = closure22()
let delete_file_async x = v24 x
let v25 : (string -> (string -> Async<int64>)) = closure28()
let move_file_async x = v25 x
let v26 : (string -> Async<string option>) = closure31()
let read_all_text_retry_async x = v26 x
let v27 : (unit -> string) = closure37()
let create_temp_path () = v27 ()
let v28 : (unit -> struct (string * System.IDisposable)) = closure39()
let create_temp_dir () = v28 ()
let v29 : (string -> struct (string * System.IDisposable)) = closure48()
let create_temp_dir' x = v29 x
let v30 : (unit -> string) = closure50()
let get_source_directory () = v30 ()
let v31 : (string -> string) = closure51()
let normalize_path x = v31 x
let v32 : (string -> string) = closure59()
let get_full_path x = v32 x
let v33 : (string -> string) = closure60()
let standardize_path x = v33 x
let v34 : (string -> string) = closure61()
let new_file_uri x = v34 x
let v35 : (unit -> string) = closure62()
let get_workspace_root () = v35 ()
let v36 : (string -> unit) = closure66()
let trace_file x = v36 x
let v37 : (bool -> unit) = closure68()
let init_trace_file x = v37 x
let v38 : (string -> (string -> unit)) = closure69()
let link_directory x = v38 x
let v39 : (string -> (string -> string)) = closure71()
let (</>) x = v39 x
()
