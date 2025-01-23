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
    | US16_0 of f0_0 : string
    | US16_1 of f1_0 : string
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
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = method3(v0)
    let v3 : string = "std::env::var(&*$0)"
    let v4 : Result<std_string_String, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr v2 v3 
    let v5 : string = "true; let _result_map_ = $0.map(|x| { //"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr v4 v5 
    let v7 : string = "x"
    let v8 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v7 
    let v9 : string = "fable_library_rust::String_::fromString($0)"
    let v10 : string = Fable.Core.RustInterop.emitRustExpr v8 v9 
    let v11 : string = "true; $0 })"
    let v12 : bool = Fable.Core.RustInterop.emitRustExpr v10 v11 
    let v13 : string = "_result_map_"
    let v14 : Result<string, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr () v13 
    let v15 : string = method4()
    let v16 : string = "$0.unwrap_or($1)"
    let v17 : string = Fable.Core.RustInterop.emitRustExpr struct (v14, v15) v16 
    let _run_target_args'_v1 = v17 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v18 : US3 = US3_1
    let v19 : US4 = US4_2(v18)
    let v20 : string = $"env.get_environment_variable / target: {v19} / var: {v0}"
    let v21 : string = failwith<string> v20
    let _run_target_args'_v1 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : US3 = US3_2
    let v23 : US4 = US4_2(v22)
    let v24 : string = $"env.get_environment_variable / target: {v23} / var: {v0}"
    let v25 : string = failwith<string> v24
    let _run_target_args'_v1 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v26 : string = "process.env[$0] ?? \"\""
    let v27 : string = Fable.Core.JsInterop.emitJsExpr v0 v26 
    let _run_target_args'_v1 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v28 : string = "os"
    let v29 : IOsEnviron = Fable.Core.PyInterop.importAll v28 
    let v30 : string = "v29.environ"
    let v31 : obj = Fable.Core.PyInterop.emitPyExpr () v30 
    let v34 : string = "v31.get($0)"
    let v35 : string = Fable.Core.PyInterop.emitPyExpr v0 v34 
    let mutable _v35 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v38 : (string -> string option) = Option.ofObj
    let v39 : string option = v38 v35
    v39 
    #else
    Some v35 
    #endif
    |> fun x -> _v35 <- Some x
    let v40 : string option = match _v35 with Some x -> x | None -> failwith "optionm'.of_obj / _v35=None"
    let v43 : (string -> US5) = method5()
    let v44 : US5 option = v40 |> Option.map v43 
    let v55 : US5 = US5_1
    let v56 : US5 = v44 |> Option.defaultValue v55 
    let v63 : string =
        match v56 with
        | US5_1 -> (* None *)
            let v61 : string = ""
            v61
        | US5_0(v60) -> (* Some *)
            v60
    let _run_target_args'_v1 = v63 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : US3 = US3_1
    let v65 : US4 = US4_0(v64)
    let v66 : string = $"env.get_environment_variable / target: {v65} / var: {v0}"
    let v67 : string = failwith<string> v66
    let _run_target_args'_v1 = v67 
    #endif
#else
    let v68 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v69 : string = v68 v0
    let mutable _v69 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v70 : (string -> string option) = Option.ofObj
    let v71 : string option = v70 v69
    v71 
    #else
    Some v69 
    #endif
    |> fun x -> _v69 <- Some x
    let v72 : string option = match _v69 with Some x -> x | None -> failwith "optionm'.of_obj / _v69=None"
    let v75 : (string -> US5) = method5()
    let v76 : US5 option = v72 |> Option.map v75 
    let v87 : US5 = US5_1
    let v88 : US5 = v76 |> Option.defaultValue v87 
    let v95 : string =
        match v88 with
        | US5_1 -> (* None *)
            let v93 : string = ""
            v93
        | US5_0(v92) -> (* Some *)
            v92
    let _run_target_args'_v1 = v95 
    #endif
    let v96 : string = _run_target_args'_v1 
    v96
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
    let v50 : string = "True"
    let v51 : bool = v49 <> v50 
    let v107 : US2 =
        if v51 then
            US2_1
        else
            (* run_target_args'
            let v55 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v56 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v55 = v56 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v57 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v55 = v57 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v58 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v55 = v58 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v61 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v55 = v61 
            #endif
#if FABLE_COMPILER_PYTHON
            let v62 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v55 = v62 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v63 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v55 = v63 
            #endif
#else
            let v64 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v55 = v64 
            #endif
            let v65 : System.DateTime = _run_target_args'_v55 
            (* run_target_args'
            let v70 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v71 : (System.DateTime -> int64) = _.Ticks
            let v72 : int64 = v71 v65
            let _run_target_args'_v70 = v72 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v73 : (System.DateTime -> int64) = _.Ticks
            let v74 : int64 = v73 v65
            let _run_target_args'_v70 = v74 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v75 : int64 = null |> unbox<int64>
            let _run_target_args'_v70 = v75 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v78 : (System.DateTime -> int64) = _.Ticks
            let v79 : int64 = v78 v65
            let _run_target_args'_v70 = v79 
            #endif
#if FABLE_COMPILER_PYTHON
            let v80 : (System.DateTime -> int64) = _.Ticks
            let v81 : int64 = v80 v65
            let _run_target_args'_v70 = v81 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v82 : (System.DateTime -> int64) = _.Ticks
            let v83 : int64 = v82 v65
            let _run_target_args'_v70 = v83 
            #endif
#else
            let v84 : (System.DateTime -> int64) = _.Ticks
            let v85 : int64 = v84 v65
            let _run_target_args'_v70 = v85 
            #endif
            let v86 : int64 = _run_target_args'_v70 
            let v103 : int64 = v86 |> int64 
            US2_0(v103)
    struct (v47, v107)
and closure2 () (v0 : string) : unit =
    ()
and method0 (v0 : US0) : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v2 : US1, v3 : US2) = method1()
    let _run_target_args'_v1 = struct (v2, v3) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : US1 = US1_1
    let v5 : US2 = US2_1
    let _run_target_args'_v1 = struct (v4, v5) 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6 : string = "AUTOMATION"
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "option_env!(\"" + v6 + "\").unwrap_or(\"\")"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v8 
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "String::from($0)"
    let v16 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : std_string_String = v9 |> unbox<std_string_String>
    let _run_target_args'_v10 = v17 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v9 |> unbox<std_string_String>
    let _run_target_args'_v10 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : std_string_String = v9 |> unbox<std_string_String>
    let _run_target_args'_v10 = v23 
    #endif
#else
    let v26 : std_string_String = v9 |> unbox<std_string_String>
    let _run_target_args'_v10 = v26 
    #endif
    let v29 : std_string_String = _run_target_args'_v10 
    let v34 : string = "fable_library_rust::String_::fromString($0)"
    let v35 : string = Fable.Core.RustInterop.emitRustExpr v29 v34 
    let _run_target_args'_v7 = v35 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v36 : string = "option_env!(\"" + v6 + "\").unwrap_or(\"\")"
    let v37 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v36 
    (* run_target_args'
    let v38 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v39 : string = "String::from($0)"
    let v40 : std_string_String = Fable.Core.RustInterop.emitRustExpr v37 v39 
    let _run_target_args'_v38 = v40 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v41 : string = "String::from($0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v37 v41 
    let _run_target_args'_v38 = v42 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v43 : string = "String::from($0)"
    let v44 : std_string_String = Fable.Core.RustInterop.emitRustExpr v37 v43 
    let _run_target_args'_v38 = v44 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v45 : std_string_String = v37 |> unbox<std_string_String>
    let _run_target_args'_v38 = v45 
    #endif
#if FABLE_COMPILER_PYTHON
    let v48 : std_string_String = v37 |> unbox<std_string_String>
    let _run_target_args'_v38 = v48 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v51 : std_string_String = v37 |> unbox<std_string_String>
    let _run_target_args'_v38 = v51 
    #endif
#else
    let v54 : std_string_String = v37 |> unbox<std_string_String>
    let _run_target_args'_v38 = v54 
    #endif
    let v57 : std_string_String = _run_target_args'_v38 
    let v62 : string = "fable_library_rust::String_::fromString($0)"
    let v63 : string = Fable.Core.RustInterop.emitRustExpr v57 v62 
    let _run_target_args'_v7 = v63 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v64 : string = "option_env!(\"" + v6 + "\").unwrap_or(\"\")"
    let v65 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v64 
    (* run_target_args'
    let v66 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v67 : string = "String::from($0)"
    let v68 : std_string_String = Fable.Core.RustInterop.emitRustExpr v65 v67 
    let _run_target_args'_v66 = v68 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v69 : string = "String::from($0)"
    let v70 : std_string_String = Fable.Core.RustInterop.emitRustExpr v65 v69 
    let _run_target_args'_v66 = v70 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v71 : string = "String::from($0)"
    let v72 : std_string_String = Fable.Core.RustInterop.emitRustExpr v65 v71 
    let _run_target_args'_v66 = v72 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v73 : std_string_String = v65 |> unbox<std_string_String>
    let _run_target_args'_v66 = v73 
    #endif
#if FABLE_COMPILER_PYTHON
    let v76 : std_string_String = v65 |> unbox<std_string_String>
    let _run_target_args'_v66 = v76 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v79 : std_string_String = v65 |> unbox<std_string_String>
    let _run_target_args'_v66 = v79 
    #endif
#else
    let v82 : std_string_String = v65 |> unbox<std_string_String>
    let _run_target_args'_v66 = v82 
    #endif
    let v85 : std_string_String = _run_target_args'_v66 
    let v90 : string = "fable_library_rust::String_::fromString($0)"
    let v91 : string = Fable.Core.RustInterop.emitRustExpr v85 v90 
    let _run_target_args'_v7 = v91 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v92 : string = null |> unbox<string>
    let _run_target_args'_v7 = v92 
    #endif
#if FABLE_COMPILER_PYTHON
    let v95 : string = null |> unbox<string>
    let _run_target_args'_v7 = v95 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : string = null |> unbox<string>
    let _run_target_args'_v7 = v98 
    #endif
#else
    let v101 : string = null |> unbox<string>
    let _run_target_args'_v7 = v101 
    #endif
    let v104 : string = _run_target_args'_v7 
    let v109 : string = "True"
    let v110 : bool = v104 <> v109 
    let v121 : US2 =
        if v110 then
            US2_1
        else
            let v114 : string = $"near_sdk::env::block_timestamp()"
            let v115 : uint64 = Fable.Core.RustInterop.emitRustExpr () v114 
            let v116 : (uint64 -> int64) = int64
            let v117 : int64 = v116 v115
            US2_0(v117)
    let v122 : US1 = US1_1
    let _run_target_args'_v1 = struct (v122, v121) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v123 : US1, v124 : US2) = method1()
    let _run_target_args'_v1 = struct (v123, v124) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v125 : US1, v126 : US2) = method1()
    let _run_target_args'_v1 = struct (v125, v126) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v127 : US1, v128 : US2) = method1()
    let _run_target_args'_v1 = struct (v127, v128) 
    #endif
#else
    let struct (v129 : US1, v130 : US2) = method1()
    let _run_target_args'_v1 = struct (v129, v130) 
    #endif
    let struct (v131 : US1, v132 : US2) = _run_target_args'_v1 
    let v137 : Mut0 = {l0 = 1L} : Mut0
    let v138 : (string -> unit) = closure2()
    let v139 : Mut1 = {l0 = v138} : Mut1
    let v140 : Mut2 = {l0 = true} : Mut2
    let v141 : string = ""
    let v142 : Mut3 = {l0 = v141} : Mut3
    let v145 : US0 =
        match v131 with
        | US1_1 -> (* None *)
            v0
        | US1_0(v143) -> (* Some *)
            v143
    let v146 : Mut4 = {l0 = v145} : Mut4
    let v153 : int64 option =
        match v132 with
        | US2_1 -> (* None *)
            let v151 : int64 option = None
            v151
        | US2_0(v147) -> (* Some *)
            let v148 : int64 option = Some v147 
            v148
    struct (v137, v139, v140, v142, v146, v153)
and closure0 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US0 = US0_0
        let struct (v2 : Mut0, v3 : Mut1, v4 : Mut2, v5 : Mut3, v6 : Mut4, v7 : int64 option) = method0(v1)
        let v8 : struct (Mut0 * Mut1 * Mut2 * Mut3 * Mut4 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v8 
        ()
and method10 (v0 : string) : bool =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "&*$0"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let _run_target_args'_v2 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : string = "&*$0"
    let v6 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v5 
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7 : string = "&*$0"
    let v8 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let _run_target_args'_v2 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v9 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v12 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v15 
    #endif
#else
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v18 
    #endif
    let v21 : Ref<Str> = _run_target_args'_v2 
    (* run_target_args'
    let v26 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v27 : string = "String::from($0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v27 
    let _run_target_args'_v26 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = "String::from($0)"
    let v30 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v29 
    let _run_target_args'_v26 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "String::from($0)"
    let v32 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v31 
    let _run_target_args'_v26 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v33 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v36 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v39 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v39 
    #endif
#else
    let v42 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v42 
    #endif
    let v45 : std_string_String = _run_target_args'_v26 
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = "std::path::PathBuf::from($0)"
    let v52 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v51 
    let _run_target_args'_v50 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : string = "std::path::PathBuf::from($0)"
    let v54 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v53 
    let _run_target_args'_v50 = v54 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v55 : string = "std::path::PathBuf::from($0)"
    let v56 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v55 
    let _run_target_args'_v50 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v57 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v57 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v63 
    #endif
#else
    let v66 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v66 
    #endif
    let v69 : std_path_PathBuf = _run_target_args'_v50 
    let v74 : string = "$0.exists()"
    let v75 : bool = Fable.Core.RustInterop.emitRustExpr v69 v74 
    let v78 : bool =
        if v75 then
            let v76 : string = "$0.is_dir()"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v69 v76 
            v77
        else
            false
    let _run_target_args'_v1 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v79 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v85 : string = "fs"
    let v86 : IFsExistsSync = Fable.Core.JsInterop.importAll v85 
    let v87 : string = "$0.existsSync($1)"
    let v88 : bool = Fable.Core.JsInterop.emitJsExpr struct (v86, v0) v87 
    let _run_target_args'_v1 = v88 
    #endif
#if FABLE_COMPILER_PYTHON
    let v89 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v89 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v92 
    #endif
#else
    let v95 : (string -> bool) = System.IO.Directory.Exists
    let v96 : bool = v95 v0
    let _run_target_args'_v1 = v96 
    #endif
    let v97 : bool = _run_target_args'_v1 
    v97
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
    let struct (v17 : Mut0, v18 : Mut1, v19 : Mut2, v20 : Mut3, v21 : Mut4, v22 : int64 option) = TraceState.trace_state.Value
    let v35 : US0 = v21.l0
    let v36 : bool = v19.l0
    let v37 : bool = v36 = false
    if v37 then
        false
    else
        let v38 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
        let v39 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v35
        let v40 : bool = v38 >= v39
        v40
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
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : (int64 -> US2) = method13()
    let v8 : US2 option = v5 |> Option.map v7 
    let v19 : US2 = US2_1
    let v20 : US2 = v8 |> Option.defaultValue v19 
    let v117 : System.DateTime =
        match v20 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v101 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v102 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v101 = v102 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v103 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v101 = v103 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v104 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v101 = v104 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v107 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v101 = v107 
            #endif
#if FABLE_COMPILER_PYTHON
            let v108 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v101 = v108 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v109 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v101 = v109 
            #endif
#else
            let v110 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v101 = v110 
            #endif
            let v111 : System.DateTime = _run_target_args'_v101 
            v111
        | US2_0(v24) -> (* Some *)
            (* run_target_args'
            let v25 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v26 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v25 = v26 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v27 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v25 = v27 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v28 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v25 = v28 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v31 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v25 = v31 
            #endif
#if FABLE_COMPILER_PYTHON
            let v32 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v25 = v32 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v33 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v25 = v33 
            #endif
#else
            let v34 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v25 = v34 
            #endif
            let v35 : System.DateTime = _run_target_args'_v25 
            (* run_target_args'
            let v40 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v41 : (System.DateTime -> int64) = _.Ticks
            let v42 : int64 = v41 v35
            let _run_target_args'_v40 = v42 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v43 : (System.DateTime -> int64) = _.Ticks
            let v44 : int64 = v43 v35
            let _run_target_args'_v40 = v44 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v45 : int64 = null |> unbox<int64>
            let _run_target_args'_v40 = v45 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v48 : (System.DateTime -> int64) = _.Ticks
            let v49 : int64 = v48 v35
            let _run_target_args'_v40 = v49 
            #endif
#if FABLE_COMPILER_PYTHON
            let v50 : (System.DateTime -> int64) = _.Ticks
            let v51 : int64 = v50 v35
            let _run_target_args'_v40 = v51 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v52 : (System.DateTime -> int64) = _.Ticks
            let v53 : int64 = v52 v35
            let _run_target_args'_v40 = v53 
            #endif
#else
            let v54 : (System.DateTime -> int64) = _.Ticks
            let v55 : int64 = v54 v35
            let _run_target_args'_v40 = v55 
            #endif
            let v56 : int64 = _run_target_args'_v40 
            let v73 : int64 = v56 |> int64 
            let v76 : int64 = v73 - v24
            let v77 : System.TimeSpan = v76 |> System.TimeSpan 
            let v82 : (System.TimeSpan -> int32) = _.Hours
            let v83 : int32 = v82 v77
            let v86 : (System.TimeSpan -> int32) = _.Minutes
            let v87 : int32 = v86 v77
            let v90 : (System.TimeSpan -> int32) = _.Seconds
            let v91 : int32 = v90 v77
            let v94 : (System.TimeSpan -> int32) = _.Milliseconds
            let v95 : int32 = v94 v77
            let v98 : System.DateTime = System.DateTime (1, 1, 1, v83, v87, v91, v95)
            v98
    let v118 : string = method14()
    let v121 : bool = v118 = ""
    let v123 : string =
        if v121 then
            let v122 : string = "M-d-y hh:mm:ss tt"
            v122
        else
            v118
    let v124 : (string -> string) = v117.ToString
    let v125 : string = v124 v123
    let _run_target_args'_v6 = v125 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : (int64 -> US2) = method13()
    let v140 : US2 option = v5 |> Option.map v139 
    let v151 : US2 = US2_1
    let v152 : US2 = v140 |> Option.defaultValue v151 
    let v249 : System.DateTime =
        match v152 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v233 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v234 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v233 = v234 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v235 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v233 = v235 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v236 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v233 = v236 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v239 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v233 = v239 
            #endif
#if FABLE_COMPILER_PYTHON
            let v240 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v233 = v240 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v241 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v233 = v241 
            #endif
#else
            let v242 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v233 = v242 
            #endif
            let v243 : System.DateTime = _run_target_args'_v233 
            v243
        | US2_0(v156) -> (* Some *)
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
            let v160 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v157 = v160 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v163 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v157 = v163 
            #endif
#if FABLE_COMPILER_PYTHON
            let v164 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v157 = v164 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v165 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v157 = v165 
            #endif
#else
            let v166 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v157 = v166 
            #endif
            let v167 : System.DateTime = _run_target_args'_v157 
            (* run_target_args'
            let v172 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v173 : (System.DateTime -> int64) = _.Ticks
            let v174 : int64 = v173 v167
            let _run_target_args'_v172 = v174 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v175 : (System.DateTime -> int64) = _.Ticks
            let v176 : int64 = v175 v167
            let _run_target_args'_v172 = v176 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v177 : int64 = null |> unbox<int64>
            let _run_target_args'_v172 = v177 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v180 : (System.DateTime -> int64) = _.Ticks
            let v181 : int64 = v180 v167
            let _run_target_args'_v172 = v181 
            #endif
#if FABLE_COMPILER_PYTHON
            let v182 : (System.DateTime -> int64) = _.Ticks
            let v183 : int64 = v182 v167
            let _run_target_args'_v172 = v183 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v184 : (System.DateTime -> int64) = _.Ticks
            let v185 : int64 = v184 v167
            let _run_target_args'_v172 = v185 
            #endif
#else
            let v186 : (System.DateTime -> int64) = _.Ticks
            let v187 : int64 = v186 v167
            let _run_target_args'_v172 = v187 
            #endif
            let v188 : int64 = _run_target_args'_v172 
            let v205 : int64 = v188 |> int64 
            let v208 : int64 = v205 - v156
            let v209 : System.TimeSpan = v208 |> System.TimeSpan 
            let v214 : (System.TimeSpan -> int32) = _.Hours
            let v215 : int32 = v214 v209
            let v218 : (System.TimeSpan -> int32) = _.Minutes
            let v219 : int32 = v218 v209
            let v222 : (System.TimeSpan -> int32) = _.Seconds
            let v223 : int32 = v222 v209
            let v226 : (System.TimeSpan -> int32) = _.Milliseconds
            let v227 : int32 = v226 v209
            let v230 : System.DateTime = System.DateTime (1, 1, 1, v215, v219, v223, v227)
            v230
    let v250 : string = method14()
    let v253 : bool = v250 = ""
    let v255 : string =
        if v253 then
            let v254 : string = "M-d-y hh:mm:ss tt"
            v254
        else
            v250
    let v256 : (string -> string) = v249.ToString
    let v257 : string = v256 v255
    let _run_target_args'_v6 = v257 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v271 : string = $"near_sdk::env::block_timestamp()"
    let v272 : uint64 = Fable.Core.RustInterop.emitRustExpr () v271 
    let v273 : (int64 -> US2) = method13()
    let v274 : US2 option = v5 |> Option.map v273 
    let v285 : US2 = US2_1
    let v286 : US2 = v274 |> Option.defaultValue v285 
    let v297 : uint64 =
        match v286 with
        | US2_1 -> (* None *)
            v272
        | US2_0(v290) -> (* Some *)
            let v291 : (int64 -> uint64) = uint64
            let v292 : uint64 = v291 v290
            let v295 : uint64 = v272 - v292
            v295
    let v298 : uint64 = v297 / 1000000000UL
    let v299 : uint64 = v298 % 60UL
    let v300 : uint64 = v298 / 60UL
    let v301 : uint64 = v300 % 60UL
    let v302 : uint64 = v298 / 3600UL
    let v303 : uint64 = v302 % 24UL
    let v304 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v305 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v303, v301, v299) v304 
    let v306 : string = "fable_library_rust::String_::fromString($0)"
    let v307 : string = Fable.Core.RustInterop.emitRustExpr v305 v306 
    let _run_target_args'_v6 = v307 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v308 : (int64 -> US2) = method13()
    let v309 : US2 option = v5 |> Option.map v308 
    let v320 : US2 = US2_1
    let v321 : US2 = v309 |> Option.defaultValue v320 
    let v418 : System.DateTime =
        match v321 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v402 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v403 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v402 = v403 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v404 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v402 = v404 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v405 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v402 = v405 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v408 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v402 = v408 
            #endif
#if FABLE_COMPILER_PYTHON
            let v409 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v402 = v409 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v410 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v402 = v410 
            #endif
#else
            let v411 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v402 = v411 
            #endif
            let v412 : System.DateTime = _run_target_args'_v402 
            v412
        | US2_0(v325) -> (* Some *)
            (* run_target_args'
            let v326 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v327 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v326 = v327 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v328 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v326 = v328 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v329 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v326 = v329 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v332 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v326 = v332 
            #endif
#if FABLE_COMPILER_PYTHON
            let v333 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v326 = v333 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v334 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v326 = v334 
            #endif
#else
            let v335 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v326 = v335 
            #endif
            let v336 : System.DateTime = _run_target_args'_v326 
            (* run_target_args'
            let v341 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v342 : (System.DateTime -> int64) = _.Ticks
            let v343 : int64 = v342 v336
            let _run_target_args'_v341 = v343 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v344 : (System.DateTime -> int64) = _.Ticks
            let v345 : int64 = v344 v336
            let _run_target_args'_v341 = v345 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v346 : int64 = null |> unbox<int64>
            let _run_target_args'_v341 = v346 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v349 : (System.DateTime -> int64) = _.Ticks
            let v350 : int64 = v349 v336
            let _run_target_args'_v341 = v350 
            #endif
#if FABLE_COMPILER_PYTHON
            let v351 : (System.DateTime -> int64) = _.Ticks
            let v352 : int64 = v351 v336
            let _run_target_args'_v341 = v352 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v353 : (System.DateTime -> int64) = _.Ticks
            let v354 : int64 = v353 v336
            let _run_target_args'_v341 = v354 
            #endif
#else
            let v355 : (System.DateTime -> int64) = _.Ticks
            let v356 : int64 = v355 v336
            let _run_target_args'_v341 = v356 
            #endif
            let v357 : int64 = _run_target_args'_v341 
            let v374 : int64 = v357 |> int64 
            let v377 : int64 = v374 - v325
            let v378 : System.TimeSpan = v377 |> System.TimeSpan 
            let v383 : (System.TimeSpan -> int32) = _.Hours
            let v384 : int32 = v383 v378
            let v387 : (System.TimeSpan -> int32) = _.Minutes
            let v388 : int32 = v387 v378
            let v391 : (System.TimeSpan -> int32) = _.Seconds
            let v392 : int32 = v391 v378
            let v395 : (System.TimeSpan -> int32) = _.Milliseconds
            let v396 : int32 = v395 v378
            let v399 : System.DateTime = System.DateTime (1, 1, 1, v384, v388, v392, v396)
            v399
    let v419 : string = method15()
    let v422 : bool = v419 = ""
    let v424 : string =
        if v422 then
            let v423 : string = "M-d-y hh:mm:ss tt"
            v423
        else
            v419
    let v425 : (string -> string) = v418.ToString
    let v426 : string = v425 v424
    let _run_target_args'_v6 = v426 
    #endif
#if FABLE_COMPILER_PYTHON
    let v440 : (int64 -> US2) = method13()
    let v441 : US2 option = v5 |> Option.map v440 
    let v452 : US2 = US2_1
    let v453 : US2 = v441 |> Option.defaultValue v452 
    let v550 : System.DateTime =
        match v453 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v534 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v535 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v534 = v535 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v536 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v534 = v536 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v537 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v534 = v537 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v540 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v534 = v540 
            #endif
#if FABLE_COMPILER_PYTHON
            let v541 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v534 = v541 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v542 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v534 = v542 
            #endif
#else
            let v543 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v534 = v543 
            #endif
            let v544 : System.DateTime = _run_target_args'_v534 
            v544
        | US2_0(v457) -> (* Some *)
            (* run_target_args'
            let v458 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v459 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v458 = v459 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v460 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v458 = v460 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v461 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v458 = v461 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v464 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v458 = v464 
            #endif
#if FABLE_COMPILER_PYTHON
            let v465 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v458 = v465 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v466 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v458 = v466 
            #endif
#else
            let v467 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v458 = v467 
            #endif
            let v468 : System.DateTime = _run_target_args'_v458 
            (* run_target_args'
            let v473 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v474 : (System.DateTime -> int64) = _.Ticks
            let v475 : int64 = v474 v468
            let _run_target_args'_v473 = v475 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v476 : (System.DateTime -> int64) = _.Ticks
            let v477 : int64 = v476 v468
            let _run_target_args'_v473 = v477 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v478 : int64 = null |> unbox<int64>
            let _run_target_args'_v473 = v478 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v481 : (System.DateTime -> int64) = _.Ticks
            let v482 : int64 = v481 v468
            let _run_target_args'_v473 = v482 
            #endif
#if FABLE_COMPILER_PYTHON
            let v483 : (System.DateTime -> int64) = _.Ticks
            let v484 : int64 = v483 v468
            let _run_target_args'_v473 = v484 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v485 : (System.DateTime -> int64) = _.Ticks
            let v486 : int64 = v485 v468
            let _run_target_args'_v473 = v486 
            #endif
#else
            let v487 : (System.DateTime -> int64) = _.Ticks
            let v488 : int64 = v487 v468
            let _run_target_args'_v473 = v488 
            #endif
            let v489 : int64 = _run_target_args'_v473 
            let v506 : int64 = v489 |> int64 
            let v509 : int64 = v506 - v457
            let v510 : System.TimeSpan = v509 |> System.TimeSpan 
            let v515 : (System.TimeSpan -> int32) = _.Hours
            let v516 : int32 = v515 v510
            let v519 : (System.TimeSpan -> int32) = _.Minutes
            let v520 : int32 = v519 v510
            let v523 : (System.TimeSpan -> int32) = _.Seconds
            let v524 : int32 = v523 v510
            let v527 : (System.TimeSpan -> int32) = _.Milliseconds
            let v528 : int32 = v527 v510
            let v531 : System.DateTime = System.DateTime (1, 1, 1, v516, v520, v524, v528)
            v531
    let v551 : string = method15()
    let v554 : bool = v551 = ""
    let v556 : string =
        if v554 then
            let v555 : string = "M-d-y hh:mm:ss tt"
            v555
        else
            v551
    let v557 : (string -> string) = v550.ToString
    let v558 : string = v557 v556
    let _run_target_args'_v6 = v558 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v572 : (int64 -> US2) = method13()
    let v573 : US2 option = v5 |> Option.map v572 
    let v584 : US2 = US2_1
    let v585 : US2 = v573 |> Option.defaultValue v584 
    let v682 : System.DateTime =
        match v585 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v666 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v667 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v666 = v667 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v668 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v666 = v668 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v669 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v666 = v669 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v672 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v666 = v672 
            #endif
#if FABLE_COMPILER_PYTHON
            let v673 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v666 = v673 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v674 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v666 = v674 
            #endif
#else
            let v675 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v666 = v675 
            #endif
            let v676 : System.DateTime = _run_target_args'_v666 
            v676
        | US2_0(v589) -> (* Some *)
            (* run_target_args'
            let v590 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v591 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v590 = v591 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v592 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v590 = v592 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v593 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v590 = v593 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v596 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v590 = v596 
            #endif
#if FABLE_COMPILER_PYTHON
            let v597 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v590 = v597 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v598 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v590 = v598 
            #endif
#else
            let v599 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v590 = v599 
            #endif
            let v600 : System.DateTime = _run_target_args'_v590 
            (* run_target_args'
            let v605 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v606 : (System.DateTime -> int64) = _.Ticks
            let v607 : int64 = v606 v600
            let _run_target_args'_v605 = v607 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v608 : (System.DateTime -> int64) = _.Ticks
            let v609 : int64 = v608 v600
            let _run_target_args'_v605 = v609 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v610 : int64 = null |> unbox<int64>
            let _run_target_args'_v605 = v610 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v613 : (System.DateTime -> int64) = _.Ticks
            let v614 : int64 = v613 v600
            let _run_target_args'_v605 = v614 
            #endif
#if FABLE_COMPILER_PYTHON
            let v615 : (System.DateTime -> int64) = _.Ticks
            let v616 : int64 = v615 v600
            let _run_target_args'_v605 = v616 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v617 : (System.DateTime -> int64) = _.Ticks
            let v618 : int64 = v617 v600
            let _run_target_args'_v605 = v618 
            #endif
#else
            let v619 : (System.DateTime -> int64) = _.Ticks
            let v620 : int64 = v619 v600
            let _run_target_args'_v605 = v620 
            #endif
            let v621 : int64 = _run_target_args'_v605 
            let v638 : int64 = v621 |> int64 
            let v641 : int64 = v638 - v589
            let v642 : System.TimeSpan = v641 |> System.TimeSpan 
            let v647 : (System.TimeSpan -> int32) = _.Hours
            let v648 : int32 = v647 v642
            let v651 : (System.TimeSpan -> int32) = _.Minutes
            let v652 : int32 = v651 v642
            let v655 : (System.TimeSpan -> int32) = _.Seconds
            let v656 : int32 = v655 v642
            let v659 : (System.TimeSpan -> int32) = _.Milliseconds
            let v660 : int32 = v659 v642
            let v663 : System.DateTime = System.DateTime (1, 1, 1, v648, v652, v656, v660)
            v663
    let v683 : string = method15()
    let v686 : bool = v683 = ""
    let v688 : string =
        if v686 then
            let v687 : string = "M-d-y hh:mm:ss tt"
            v687
        else
            v683
    let v689 : (string -> string) = v682.ToString
    let v690 : string = v689 v688
    let _run_target_args'_v6 = v690 
    #endif
#else
    let v704 : (int64 -> US2) = method13()
    let v705 : US2 option = v5 |> Option.map v704 
    let v716 : US2 = US2_1
    let v717 : US2 = v705 |> Option.defaultValue v716 
    let v814 : System.DateTime =
        match v717 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v798 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v799 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v798 = v799 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v800 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v798 = v800 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v801 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v798 = v801 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v804 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v798 = v804 
            #endif
#if FABLE_COMPILER_PYTHON
            let v805 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v798 = v805 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v806 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v798 = v806 
            #endif
#else
            let v807 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v798 = v807 
            #endif
            let v808 : System.DateTime = _run_target_args'_v798 
            v808
        | US2_0(v721) -> (* Some *)
            (* run_target_args'
            let v722 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v723 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v722 = v723 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v724 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v722 = v724 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v725 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v722 = v725 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v728 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v722 = v728 
            #endif
#if FABLE_COMPILER_PYTHON
            let v729 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v722 = v729 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v730 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v722 = v730 
            #endif
#else
            let v731 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v722 = v731 
            #endif
            let v732 : System.DateTime = _run_target_args'_v722 
            (* run_target_args'
            let v737 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v738 : (System.DateTime -> int64) = _.Ticks
            let v739 : int64 = v738 v732
            let _run_target_args'_v737 = v739 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v740 : (System.DateTime -> int64) = _.Ticks
            let v741 : int64 = v740 v732
            let _run_target_args'_v737 = v741 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v742 : int64 = null |> unbox<int64>
            let _run_target_args'_v737 = v742 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v745 : (System.DateTime -> int64) = _.Ticks
            let v746 : int64 = v745 v732
            let _run_target_args'_v737 = v746 
            #endif
#if FABLE_COMPILER_PYTHON
            let v747 : (System.DateTime -> int64) = _.Ticks
            let v748 : int64 = v747 v732
            let _run_target_args'_v737 = v748 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v749 : (System.DateTime -> int64) = _.Ticks
            let v750 : int64 = v749 v732
            let _run_target_args'_v737 = v750 
            #endif
#else
            let v751 : (System.DateTime -> int64) = _.Ticks
            let v752 : int64 = v751 v732
            let _run_target_args'_v737 = v752 
            #endif
            let v753 : int64 = _run_target_args'_v737 
            let v770 : int64 = v753 |> int64 
            let v773 : int64 = v770 - v721
            let v774 : System.TimeSpan = v773 |> System.TimeSpan 
            let v779 : (System.TimeSpan -> int32) = _.Hours
            let v780 : int32 = v779 v774
            let v783 : (System.TimeSpan -> int32) = _.Minutes
            let v784 : int32 = v783 v774
            let v787 : (System.TimeSpan -> int32) = _.Seconds
            let v788 : int32 = v787 v774
            let v791 : (System.TimeSpan -> int32) = _.Milliseconds
            let v792 : int32 = v791 v774
            let v795 : System.DateTime = System.DateTime (1, 1, 1, v780, v784, v788, v792)
            v795
    let v815 : string = method15()
    let v818 : bool = v815 = ""
    let v820 : string =
        if v818 then
            let v819 : string = "M-d-y hh:mm:ss tt"
            v819
        else
            v815
    let v821 : (string -> string) = v814.ToString
    let v822 : string = v821 v820
    let _run_target_args'_v6 = v822 
    #endif
    let v836 : string = _run_target_args'_v6 
    v836
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
    let v3 : string = $"{v0}"
    let v6 : unit = ()
    let v7 : (unit -> unit) = closure6(v2, v3)
    let v8 : unit = (fun () -> v7 (); v6) ()
    let v11 : string = v2.l0
    v11
and method19 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method16 () : string =
    
    
    
    
    
    let v0 : string = "Debug"
    let v1 : (unit -> string) = v0.ToLower
    let v2 : string = v1 ()
    let v5 : char = v2.[int 0]
    let v6 : string = method17(v5)
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "inline_colorization::color_bright_blue"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v8 
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v17 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v23 
    #endif
#else
    let v26 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
    let v29 : Ref<Str> = _run_target_args'_v10 
    let v34 : string = "inline_colorization::color_reset"
    let v35 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v34 
    let v36 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v9, v29, v35) v36 
    let v38 : string = "fable_library_rust::String_::fromString($0)"
    let v39 : string = Fable.Core.RustInterop.emitRustExpr v37 v38 
    let _run_target_args'_v7 = v39 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v40 : string = "inline_colorization::color_bright_blue"
    let v41 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v40 
    (* run_target_args'
    let v42 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v43 : string = "&*$0"
    let v44 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v43 
    let _run_target_args'_v42 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "&*$0"
    let v46 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v45 
    let _run_target_args'_v42 = v46 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v47 : string = "&*$0"
    let v48 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v47 
    let _run_target_args'_v42 = v48 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v49 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v52 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v55 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v55 
    #endif
#else
    let v58 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v58 
    #endif
    let v61 : Ref<Str> = _run_target_args'_v42 
    let v66 : string = "inline_colorization::color_reset"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v66 
    let v68 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v69 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v41, v61, v67) v68 
    let v70 : string = "fable_library_rust::String_::fromString($0)"
    let v71 : string = Fable.Core.RustInterop.emitRustExpr v69 v70 
    let _run_target_args'_v7 = v71 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v72 : string = "inline_colorization::color_bright_blue"
    let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v72 
    (* run_target_args'
    let v74 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v75 : string = "&*$0"
    let v76 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v75 
    let _run_target_args'_v74 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v77 
    let _run_target_args'_v74 = v78 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v79 
    let _run_target_args'_v74 = v80 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v81 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v81 
    #endif
#if FABLE_COMPILER_PYTHON
    let v84 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v84 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v87 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v87 
    #endif
#else
    let v90 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v90 
    #endif
    let v93 : Ref<Str> = _run_target_args'_v74 
    let v98 : string = "inline_colorization::color_reset"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v98 
    let v100 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v101 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v73, v93, v99) v100 
    let v102 : string = "fable_library_rust::String_::fromString($0)"
    let v103 : string = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let _run_target_args'_v7 = v103 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v104 : string = "\u001b[94m"
    let v105 : string = method19()
    let v106 : string = v104 + v6 
    let v107 : string = v106 + v105 
    let _run_target_args'_v7 = v107 
    #endif
#if FABLE_COMPILER_PYTHON
    let v108 : string = "\u001b[94m"
    let v109 : string = method19()
    let v110 : string = v108 + v6 
    let v111 : string = v110 + v109 
    let _run_target_args'_v7 = v111 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v112 : string = "\u001b[94m"
    let v113 : string = method19()
    let v114 : string = v112 + v6 
    let v115 : string = v114 + v113 
    let _run_target_args'_v7 = v115 
    #endif
#else
    let v116 : string = "\u001b[94m"
    let v117 : string = method19()
    let v118 : string = v116 + v6 
    let v119 : string = v118 + v117 
    let _run_target_args'_v7 = v119 
    #endif
    let v120 : string = _run_target_args'_v7 
    v120
and method20 (v0 : string) : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "&*$0"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let _run_target_args'_v2 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : string = "&*$0"
    let v6 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v5 
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7 : string = "&*$0"
    let v8 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let _run_target_args'_v2 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v9 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v12 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v15 
    #endif
#else
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v18 
    #endif
    let v21 : Ref<Str> = _run_target_args'_v2 
    (* run_target_args'
    let v26 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v27 : string = "String::from($0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v27 
    let _run_target_args'_v26 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = "String::from($0)"
    let v30 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v29 
    let _run_target_args'_v26 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "String::from($0)"
    let v32 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v31 
    let _run_target_args'_v26 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v33 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v36 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v39 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v39 
    #endif
#else
    let v42 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v42 
    #endif
    let v45 : std_string_String = _run_target_args'_v26 
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = "std::path::PathBuf::from($0)"
    let v52 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v51 
    let _run_target_args'_v50 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : string = "std::path::PathBuf::from($0)"
    let v54 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v53 
    let _run_target_args'_v50 = v54 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v55 : string = "std::path::PathBuf::from($0)"
    let v56 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v55 
    let _run_target_args'_v50 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v57 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v57 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v63 
    #endif
#else
    let v66 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v66 
    #endif
    let v69 : std_path_PathBuf = _run_target_args'_v50 
    let v74 : string = "$0.file_name()"
    let v75 : Ref<std_ffi_OsStr> option = Fable.Core.RustInterop.emitRustExpr v69 v74 
    let v76 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
    let v78 : string = "x"
    let v79 : Ref<std_ffi_OsStr> = Fable.Core.RustInterop.emitRustExpr () v78 
    let v80 : string = "$0.to_os_string()"
    let v81 : std_ffi_OsString = Fable.Core.RustInterop.emitRustExpr v79 v80 
    let v82 : string = "$0.to_str()"
    let v83 : Ref<Str> option = Fable.Core.RustInterop.emitRustExpr v81 v82 
    let v84 : string = "$0.unwrap()"
    let v85 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v83 v84 
    (* run_target_args'
    let v86 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v87 : string = "String::from($0)"
    let v88 : std_string_String = Fable.Core.RustInterop.emitRustExpr v85 v87 
    let _run_target_args'_v86 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v85 v89 
    let _run_target_args'_v86 = v90 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v85 v91 
    let _run_target_args'_v86 = v92 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v93 : std_string_String = v85 |> unbox<std_string_String>
    let _run_target_args'_v86 = v93 
    #endif
#if FABLE_COMPILER_PYTHON
    let v96 : std_string_String = v85 |> unbox<std_string_String>
    let _run_target_args'_v86 = v96 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v99 : std_string_String = v85 |> unbox<std_string_String>
    let _run_target_args'_v86 = v99 
    #endif
#else
    let v102 : std_string_String = v85 |> unbox<std_string_String>
    let _run_target_args'_v86 = v102 
    #endif
    let v105 : std_string_String = _run_target_args'_v86 
    let v110 : string = "fable_library_rust::String_::fromString($0)"
    let v111 : string = Fable.Core.RustInterop.emitRustExpr v105 v110 
    let v112 : string = "true; $0 })"
    let v113 : bool = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let v114 : string = "_optionm_map_"
    let v115 : string option = Fable.Core.RustInterop.emitRustExpr () v114 
    let v116 : (string -> US5) = method5()
    let v117 : US5 option = v115 |> Option.map v116 
    let v128 : US5 = US5_1
    let v129 : US5 = v117 |> Option.defaultValue v128 
    let v136 : string =
        match v129 with
        | US5_1 -> (* None *)
            let v134 : string = ""
            v134
        | US5_0(v133) -> (* Some *)
            v133
    let _run_target_args'_v1 = v136 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v137 : US3 = US3_1
    let v138 : US4 = US4_2(v137)
    let v139 : string = $"file_system.get_file_name / target: {v138} / path: {v0}"
    let v140 : string = failwith<string> v139
    let _run_target_args'_v1 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = null |> unbox<string>
    let _run_target_args'_v1 = v141 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : string = "path"
    let v145 : IPathBasename = Fable.Core.JsInterop.importAll v144 
    let v146 : string = "v145.basename($0)"
    let v147 : string = Fable.Core.JsInterop.emitJsExpr v0 v146 
    let _run_target_args'_v1 = v147 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : US3 = US3_0
    let v149 : US4 = US4_4(v148)
    let v150 : string = $"file_system.get_file_name / target: {v149} / path: {v0}"
    let v151 : string = failwith<string> v150
    let _run_target_args'_v1 = v151 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : US3 = US3_1
    let v153 : US4 = US4_0(v152)
    let v154 : string = $"file_system.get_file_name / target: {v153} / path: {v0}"
    let v155 : string = failwith<string> v154
    let _run_target_args'_v1 = v155 
    #endif
#else
    let v156 : (string -> string) = System.IO.Path.GetFileName
    let v157 : string = v156 v0
    let _run_target_args'_v1 = v157 
    #endif
    let v158 : string = _run_target_args'_v1 
    v158
and method22 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "ex"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "path"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v65 : string = $"{v1}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v3, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v73 : string = " }"
    let v74 : string = $"{v73}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v3, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = v3.l0
    v82
and method23 (v0 : string) : string =
    let v1 : char list = []
    let v2 : (char list -> (char [])) = List.toArray
    let v3 : (char []) = v2 v1
    let v6 : string = v0.TrimStart v3 
    let v30 : char list = []
    let v31 : char list = '/' :: v30 
    let v34 : char list = ' ' :: v31 
    let v37 : (char list -> (char [])) = List.toArray
    let v38 : (char []) = v37 v34
    let v41 : string = v6.TrimEnd v38 
    v41
and method21 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method22(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "file_system.delete_directory_async"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
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
    let struct (v17 : Mut0, v18 : Mut1, v19 : Mut2, v20 : Mut3, v21 : Mut4, v22 : int64 option) = TraceState.trace_state.Value
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure7(v17)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v40 : (string -> unit) = closure8()
    (* run_target_args'
    let v41 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v42 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v42 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v43 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v43 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v44 : string = v20.l0
    let v45 : bool = v44 = ""
    let v53 : string =
        if v45 then
            v0
        else
            let v46 : bool = v0 = ""
            if v46 then
                let v47 : string = v20.l0
                v47
            else
                let v48 : string = v20.l0
                let v49 : string = "\n"
                let v50 : string = v48 + v49 
                let v51 : string = v50 + v0 
                v51
    (* run_target_args'
    let v54 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v55 : string = "&*$0"
    let v56 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v53 v55 
    let _run_target_args'_v54 = v56 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v57 : string = "&*$0"
    let v58 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v53 v57 
    let _run_target_args'_v54 = v58 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v59 : string = "&*$0"
    let v60 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v53 v59 
    let _run_target_args'_v54 = v60 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v61 : Ref<Str> = v53 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v61 
    #endif
#if FABLE_COMPILER_PYTHON
    let v64 : Ref<Str> = v53 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v64 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v67 : Ref<Str> = v53 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v67 
    #endif
#else
    let v70 : Ref<Str> = v53 |> unbox<Ref<Str>>
    let _run_target_args'_v54 = v70 
    #endif
    let v73 : Ref<Str> = _run_target_args'_v54 
    let v78 : string = $"$0.chars()"
    let v79 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v73 v78 
    let v80 : string = "$0"
    let v81 : _ = Fable.Core.RustInterop.emitRustExpr v79 v80 
    let v82 : string = "$0.collect::<Vec<_>>()"
    let v83 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v81 v82 
    let v84 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v85 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let v86 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v87 : bool = Fable.Core.RustInterop.emitRustExpr v85 v86 
    let v88 : string = "x"
    let v89 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v88 
    let v90 : string = "String::from_iter($0)"
    let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let v92 : string = "true; $0 }).collect::<Vec<_>>()"
    let v93 : bool = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let v94 : string = "_vec_map"
    let v95 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v94 
    let v96 : string = "$0.len()"
    let v97 : unativeint = Fable.Core.RustInterop.emitRustExpr v95 v96 
    let v98 : int32 = v97 |> int32 
    let v105 : string = ""
    let v106 : bool = v0 <> v105 
    let v110 : bool =
        if v106 then
            let v109 : bool = v98 <= 1
            v109
        else
            false
    if v110 then
        v20.l0 <- v53
        ()
    else
        v20.l0 <- v105
        let v111 : string = "true; $0.into_iter().for_each(|x| { //"
        let v112 : bool = Fable.Core.RustInterop.emitRustExpr v95 v111 
        let v113 : string = "x"
        let v114 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v113 
        let v115 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v116 : bool = Fable.Core.RustInterop.emitRustExpr v114 v115 
        let v117 : string = $"true"
        let v118 : bool = Fable.Core.RustInterop.emitRustExpr () v117 
        let v119 : string = "true; }); //"
        let v120 : bool = Fable.Core.RustInterop.emitRustExpr () v119 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v40 v0
    #endif
#if FABLE_COMPILER_PYTHON
    v40 v0
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v40 v0
    #endif
#else
    v40 v0
    #endif
    // run_target_args' is_unit
    let v121 : (string -> unit) = v18.l0
    v121 v0
and closure4 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method16()
        (* run_target_args'
        let v40 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v41 : string = $"%A{v1}"
        let _run_target_args'_v40 = v41 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v44 : string = $"%A{v1}"
        let _run_target_args'_v40 = v44 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v47 : string = $"%A{v1}"
        let _run_target_args'_v40 = v47 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v50 : string = $"%A{v1}"
        let _run_target_args'_v40 = v50 
        #endif
#if FABLE_COMPILER_PYTHON
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v40 = v53 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v56 : string = $"%A{v1}"
        let _run_target_args'_v40 = v56 
        #endif
#else
        let v59 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v40 = v59 
        #endif
        let v60 : string = _run_target_args'_v40 
        let v65 : string = method20(v0)
        let v66 : string = method21(v20, v21, v22, v23, v24, v25, v38, v39, v60, v65)
        method24(v66)
and method8 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            try
                let v15 : bool = true
                method9(v15, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v17 : exn = ex
                let v18 : int64 = v1 % 100L
                let v19 : bool = v18 = 0L
                if v19 then
                    let v20 : unit = ()
                    let v21 : (unit -> unit) = closure4(v0, v17)
                    let v22 : unit = (fun () -> v21 (); v20) ()
                    ()
                (* run_target_args'
                let v88 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v89 : (int32 -> Async<unit>) = Async.Sleep
                let v90 : Async<unit> = v89 10
                let _run_target_args'_v88 = v90 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v91 : (int32 -> Async<unit>) = Async.Sleep
                let v92 : Async<unit> = v91 10
                let _run_target_args'_v88 = v92 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v93 : (int32 -> Async<unit>) = Async.Sleep
                let v94 : Async<unit> = v93 10
                let _run_target_args'_v88 = v94 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v95 : (int32 -> Async<unit>) = Async.Sleep
                let v96 : Async<unit> = v95 10
                let _run_target_args'_v88 = v96 
                #endif
#if FABLE_COMPILER_PYTHON
                let v97 : (int32 -> Async<unit>) = Async.Sleep
                let v98 : Async<unit> = v97 10
                let _run_target_args'_v88 = v98 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v99 : (int32 -> Async<unit>) = Async.Sleep
                let v100 : Async<unit> = v99 10
                let _run_target_args'_v88 = v100 
                #endif
#else
                let v101 : (int32 -> Async<unit>) = Async.Sleep
                let v102 : Async<unit> = v101 10
                let _run_target_args'_v88 = v102 
                #endif
                let v103 : Async<unit> = _run_target_args'_v88 
                do! v103 
                let v106 : int64 = v1 + 1L
                let v107 : Async<int64> = method7(v0, v106)
                return! v107 
                (* indent
                ()
            indent *)
            (* try_unit
            let v199 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1511 : Async<int64> = _let'_v12 
    let _run_target_args'_v2 = v1511 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1512 : unit = ()
    let _let'_v1512 =
        async {
            try
                let v1515 : bool = true
                method9(v1515, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v1517 : exn = ex
                let v1518 : int64 = v1 % 100L
                let v1519 : bool = v1518 = 0L
                if v1519 then
                    let v1520 : unit = ()
                    let v1521 : (unit -> unit) = closure4(v0, v1517)
                    let v1522 : unit = (fun () -> v1521 (); v1520) ()
                    ()
                (* run_target_args'
                let v1588 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1589 : (int32 -> Async<unit>) = Async.Sleep
                let v1590 : Async<unit> = v1589 10
                let _run_target_args'_v1588 = v1590 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1591 : (int32 -> Async<unit>) = Async.Sleep
                let v1592 : Async<unit> = v1591 10
                let _run_target_args'_v1588 = v1592 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1593 : (int32 -> Async<unit>) = Async.Sleep
                let v1594 : Async<unit> = v1593 10
                let _run_target_args'_v1588 = v1594 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1595 : (int32 -> Async<unit>) = Async.Sleep
                let v1596 : Async<unit> = v1595 10
                let _run_target_args'_v1588 = v1596 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1597 : (int32 -> Async<unit>) = Async.Sleep
                let v1598 : Async<unit> = v1597 10
                let _run_target_args'_v1588 = v1598 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1599 : (int32 -> Async<unit>) = Async.Sleep
                let v1600 : Async<unit> = v1599 10
                let _run_target_args'_v1588 = v1600 
                #endif
#else
                let v1601 : (int32 -> Async<unit>) = Async.Sleep
                let v1602 : Async<unit> = v1601 10
                let _run_target_args'_v1588 = v1602 
                #endif
                let v1603 : Async<unit> = _run_target_args'_v1588 
                do! v1603 
                let v1606 : int64 = v1 + 1L
                let v1607 : Async<int64> = method7(v0, v1606)
                return! v1607 
                (* indent
                ()
            indent *)
            (* try_unit
            let v1699 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3011 : Async<int64> = _let'_v1512 
    let _run_target_args'_v2 = v3011 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3012 : unit = ()
    let _let'_v3012 =
        async {
            try
                let v3015 : bool = true
                method9(v3015, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v3017 : exn = ex
                let v3018 : int64 = v1 % 100L
                let v3019 : bool = v3018 = 0L
                if v3019 then
                    let v3020 : unit = ()
                    let v3021 : (unit -> unit) = closure4(v0, v3017)
                    let v3022 : unit = (fun () -> v3021 (); v3020) ()
                    ()
                (* run_target_args'
                let v3088 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3089 : (int32 -> Async<unit>) = Async.Sleep
                let v3090 : Async<unit> = v3089 10
                let _run_target_args'_v3088 = v3090 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3091 : (int32 -> Async<unit>) = Async.Sleep
                let v3092 : Async<unit> = v3091 10
                let _run_target_args'_v3088 = v3092 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3093 : (int32 -> Async<unit>) = Async.Sleep
                let v3094 : Async<unit> = v3093 10
                let _run_target_args'_v3088 = v3094 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3095 : (int32 -> Async<unit>) = Async.Sleep
                let v3096 : Async<unit> = v3095 10
                let _run_target_args'_v3088 = v3096 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3097 : (int32 -> Async<unit>) = Async.Sleep
                let v3098 : Async<unit> = v3097 10
                let _run_target_args'_v3088 = v3098 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3099 : (int32 -> Async<unit>) = Async.Sleep
                let v3100 : Async<unit> = v3099 10
                let _run_target_args'_v3088 = v3100 
                #endif
#else
                let v3101 : (int32 -> Async<unit>) = Async.Sleep
                let v3102 : Async<unit> = v3101 10
                let _run_target_args'_v3088 = v3102 
                #endif
                let v3103 : Async<unit> = _run_target_args'_v3088 
                do! v3103 
                let v3106 : int64 = v1 + 1L
                let v3107 : Async<int64> = method7(v0, v3106)
                return! v3107 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3199 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4511 : Async<int64> = _let'_v3012 
    let _run_target_args'_v2 = v4511 
    #endif
#else
    let v4512 : unit = ()
    let _let'_v4512 =
        async {
            try
                let v4515 : bool = true
                method9(v4515, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v4517 : exn = ex
                let v4518 : int64 = v1 % 100L
                let v4519 : bool = v4518 = 0L
                if v4519 then
                    let v4520 : unit = ()
                    let v4521 : (unit -> unit) = closure4(v0, v4517)
                    let v4522 : unit = (fun () -> v4521 (); v4520) ()
                    ()
                (* run_target_args'
                let v4588 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4589 : (int32 -> Async<unit>) = Async.Sleep
                let v4590 : Async<unit> = v4589 10
                let _run_target_args'_v4588 = v4590 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4591 : (int32 -> Async<unit>) = Async.Sleep
                let v4592 : Async<unit> = v4591 10
                let _run_target_args'_v4588 = v4592 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4593 : (int32 -> Async<unit>) = Async.Sleep
                let v4594 : Async<unit> = v4593 10
                let _run_target_args'_v4588 = v4594 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4595 : (int32 -> Async<unit>) = Async.Sleep
                let v4596 : Async<unit> = v4595 10
                let _run_target_args'_v4588 = v4596 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4597 : (int32 -> Async<unit>) = Async.Sleep
                let v4598 : Async<unit> = v4597 10
                let _run_target_args'_v4588 = v4598 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4599 : (int32 -> Async<unit>) = Async.Sleep
                let v4600 : Async<unit> = v4599 10
                let _run_target_args'_v4588 = v4600 
                #endif
#else
                let v4601 : (int32 -> Async<unit>) = Async.Sleep
                let v4602 : Async<unit> = v4601 10
                let _run_target_args'_v4588 = v4602 
                #endif
                let v4603 : Async<unit> = _run_target_args'_v4588 
                do! v4603 
                let v4606 : int64 = v1 + 1L
                let v4607 : Async<int64> = method7(v0, v4606)
                return! v4607 
                (* indent
                ()
            indent *)
            (* try_unit
            let v4699 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6011 : Async<int64> = _let'_v4512 
    let _run_target_args'_v2 = v6011 
    #endif
    let v6012 : Async<int64> = _run_target_args'_v2 
    v6012
and method7 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v18 
    #endif
#else
    let v21 : Async<int64> = method8(v0, v1)
    let _run_target_args'_v2 = v21 
    #endif
    let v22 : Async<int64> = _run_target_args'_v2 
    v22
and method6 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method7(v0, v1)
and closure3 () (v0 : string) : Async<int64> =
    method6(v0)
and method29 (v0 : string, v1 : int64, v2 : string) : string =
    let v3 : string = method18()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v4, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v14 : string = "path"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure6(v4, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v23 : string = " = "
    let v24 : string = $"{v23}"
    let v27 : unit = ()
    let v28 : (unit -> unit) = closure6(v4, v24)
    let v29 : unit = (fun () -> v28 (); v27) ()
    let v32 : string = $"{v0}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure6(v4, v32)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v40 : string = "; "
    let v41 : string = $"{v40}"
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure6(v4, v41)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v49 : string = "retry"
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v58 : string = $"{v23}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v4, v58)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v66 : string = $"{v1}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure6(v4, v66)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v74 : string = $"{v40}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = "ex"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = $"{v23}"
    let v94 : unit = ()
    let v95 : (unit -> unit) = closure6(v4, v91)
    let v96 : unit = (fun () -> v95 (); v94) ()
    let v99 : string = $"{v2}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure6(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v107 : string = " }"
    let v108 : string = $"{v107}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v116 : string = v4.l0
    v116
and method28 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : int64, v10 : string) : string =
    let v11 : string = method29(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v13 : string = "file_system.wait_for_file_access"
    let v14 : string = $"{v6} {v7} #{v12} %s{v13} / {v11}"
    method23(v14)
and closure12 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v3 : US0 = US0_1
    let v4 : bool = method11(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v21 : Mut0, v22 : Mut1, v23 : Mut2, v24 : Mut3, v25 : Mut4, v26 : int64 option) = TraceState.trace_state.Value
        let v39 : string = method12(v21, v22, v23, v24, v25, v26)
        let v40 : string = method16()
        let v41 : string = method20(v0)
        (* run_target_args'
        let v42 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v43 : string = $"%A{v2}"
        let _run_target_args'_v42 = v43 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v46 : string = $"%A{v2}"
        let _run_target_args'_v42 = v46 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v49 : string = $"%A{v2}"
        let _run_target_args'_v42 = v49 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v52 : string = $"%A{v2}"
        let _run_target_args'_v42 = v52 
        #endif
#if FABLE_COMPILER_PYTHON
        let v55 : string = $"%A{v2}"
        let _run_target_args'_v42 = v55 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v58 : string = $"%A{v2}"
        let _run_target_args'_v42 = v58 
        #endif
#else
        let v61 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v42 = v61 
        #endif
        let v62 : string = _run_target_args'_v42 
        let v67 : string = method28(v21, v22, v23, v24, v25, v26, v39, v40, v41, v1, v62)
        method24(v67)
and method27 (v0 : US6, v1 : string, v2 : int64, v3 : US8, v4 : US7) : Async<int64> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v5 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v5 = v12 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v15 : unit = ()
    let _let'_v15 =
        async {
            try
                (* run_target_args'
                let v18 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v19 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v18 = v19 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v22 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v18 = v22 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v25 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v18 = v25 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v18 = v28 
                #endif
#if FABLE_COMPILER_PYTHON
                let v31 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v18 = v31 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v34 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v18 = v34 
                #endif
#else
                let v37 : System.IO.FileMode = System.IO.FileMode.Open
                let v43 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v38 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v38
                    | US7_2 -> (* AccessReadWrite *)
                        let v40 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v40
                    | US7_1 -> (* AccessWrite *)
                        let v39 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v39
                let v53 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v48 : System.IO.FileShare = System.IO.FileShare.Delete
                        v48
                    | US8_0 -> (* ShareNone *)
                        let v44 : System.IO.FileShare = System.IO.FileShare.None
                        v44
                    | US8_1 -> (* ShareRead *)
                        let v45 : System.IO.FileShare = System.IO.FileShare.Read
                        v45
                    | US8_3 -> (* ShareReadWrite *)
                        let v47 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v47
                    | US8_2 -> (* ShareWrite *)
                        let v46 : System.IO.FileShare = System.IO.FileShare.Write
                        v46
                let v54 : System.IO.FileStream = new System.IO.FileStream (v1, v37, v43, v53)
                let _run_target_args'_v18 = v54 
                #endif
                let v55 : System.IO.FileStream = _run_target_args'_v18 
                use v55 = v55 
                let v60 : System.IO.FileStream = v55 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v104 : exn = ex
                let v105 : bool = v2 > 0L
                let v108 : bool =
                    if v105 then
                        let v106 : int64 = v2 % 100L
                        let v107 : bool = v106 = 0L
                        v107
                    else
                        false
                if v108 then
                    let v109 : unit = ()
                    let v110 : (unit -> unit) = closure12(v1, v2, v104)
                    let v111 : unit = (fun () -> v110 (); v109) ()
                    ()
                (* run_target_args'
                let v177 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v178 : (int32 -> Async<unit>) = Async.Sleep
                let v179 : Async<unit> = v178 10
                let _run_target_args'_v177 = v179 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v180 : (int32 -> Async<unit>) = Async.Sleep
                let v181 : Async<unit> = v180 10
                let _run_target_args'_v177 = v181 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v182 : (int32 -> Async<unit>) = Async.Sleep
                let v183 : Async<unit> = v182 10
                let _run_target_args'_v177 = v183 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v184 : (int32 -> Async<unit>) = Async.Sleep
                let v185 : Async<unit> = v184 10
                let _run_target_args'_v177 = v185 
                #endif
#if FABLE_COMPILER_PYTHON
                let v186 : (int32 -> Async<unit>) = Async.Sleep
                let v187 : Async<unit> = v186 10
                let _run_target_args'_v177 = v187 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v188 : (int32 -> Async<unit>) = Async.Sleep
                let v189 : Async<unit> = v188 10
                let _run_target_args'_v177 = v189 
                #endif
#else
                let v190 : (int32 -> Async<unit>) = Async.Sleep
                let v191 : Async<unit> = v190 10
                let _run_target_args'_v177 = v191 
                #endif
                let v192 : Async<unit> = _run_target_args'_v177 
                do! v192 
                let v195 : int64 = v2 + 1L
                let v196 : Async<int64> = method26(v0, v1, v195)
                return! v196 
                (* indent
                ()
            indent *)
            (* try_unit
            let v290 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2218 : Async<int64> = _let'_v15 
    let _run_target_args'_v5 = v2218 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2219 : unit = ()
    let _let'_v2219 =
        async {
            try
                (* run_target_args'
                let v2222 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2223 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2222 = v2223 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2226 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2222 = v2226 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2229 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2222 = v2229 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2232 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2222 = v2232 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2235 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2222 = v2235 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2238 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2222 = v2238 
                #endif
#else
                let v2241 : System.IO.FileMode = System.IO.FileMode.Open
                let v2247 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v2242 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v2242
                    | US7_2 -> (* AccessReadWrite *)
                        let v2244 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v2244
                    | US7_1 -> (* AccessWrite *)
                        let v2243 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v2243
                let v2257 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v2252 : System.IO.FileShare = System.IO.FileShare.Delete
                        v2252
                    | US8_0 -> (* ShareNone *)
                        let v2248 : System.IO.FileShare = System.IO.FileShare.None
                        v2248
                    | US8_1 -> (* ShareRead *)
                        let v2249 : System.IO.FileShare = System.IO.FileShare.Read
                        v2249
                    | US8_3 -> (* ShareReadWrite *)
                        let v2251 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v2251
                    | US8_2 -> (* ShareWrite *)
                        let v2250 : System.IO.FileShare = System.IO.FileShare.Write
                        v2250
                let v2258 : System.IO.FileStream = new System.IO.FileStream (v1, v2241, v2247, v2257)
                let _run_target_args'_v2222 = v2258 
                #endif
                let v2259 : System.IO.FileStream = _run_target_args'_v2222 
                use v2259 = v2259 
                let v2264 : System.IO.FileStream = v2259 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v2308 : exn = ex
                let v2309 : bool = v2 > 0L
                let v2312 : bool =
                    if v2309 then
                        let v2310 : int64 = v2 % 100L
                        let v2311 : bool = v2310 = 0L
                        v2311
                    else
                        false
                if v2312 then
                    let v2313 : unit = ()
                    let v2314 : (unit -> unit) = closure12(v1, v2, v2308)
                    let v2315 : unit = (fun () -> v2314 (); v2313) ()
                    ()
                (* run_target_args'
                let v2381 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2382 : (int32 -> Async<unit>) = Async.Sleep
                let v2383 : Async<unit> = v2382 10
                let _run_target_args'_v2381 = v2383 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2384 : (int32 -> Async<unit>) = Async.Sleep
                let v2385 : Async<unit> = v2384 10
                let _run_target_args'_v2381 = v2385 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2386 : (int32 -> Async<unit>) = Async.Sleep
                let v2387 : Async<unit> = v2386 10
                let _run_target_args'_v2381 = v2387 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2388 : (int32 -> Async<unit>) = Async.Sleep
                let v2389 : Async<unit> = v2388 10
                let _run_target_args'_v2381 = v2389 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2390 : (int32 -> Async<unit>) = Async.Sleep
                let v2391 : Async<unit> = v2390 10
                let _run_target_args'_v2381 = v2391 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2392 : (int32 -> Async<unit>) = Async.Sleep
                let v2393 : Async<unit> = v2392 10
                let _run_target_args'_v2381 = v2393 
                #endif
#else
                let v2394 : (int32 -> Async<unit>) = Async.Sleep
                let v2395 : Async<unit> = v2394 10
                let _run_target_args'_v2381 = v2395 
                #endif
                let v2396 : Async<unit> = _run_target_args'_v2381 
                do! v2396 
                let v2399 : int64 = v2 + 1L
                let v2400 : Async<int64> = method26(v0, v1, v2399)
                return! v2400 
                (* indent
                ()
            indent *)
            (* try_unit
            let v2494 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4422 : Async<int64> = _let'_v2219 
    let _run_target_args'_v5 = v4422 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4423 : unit = ()
    let _let'_v4423 =
        async {
            try
                (* run_target_args'
                let v4426 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4427 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v4426 = v4427 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4430 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v4426 = v4430 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4433 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v4426 = v4433 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4436 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v4426 = v4436 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4439 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v4426 = v4439 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4442 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v4426 = v4442 
                #endif
#else
                let v4445 : System.IO.FileMode = System.IO.FileMode.Open
                let v4451 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v4446 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v4446
                    | US7_2 -> (* AccessReadWrite *)
                        let v4448 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v4448
                    | US7_1 -> (* AccessWrite *)
                        let v4447 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v4447
                let v4461 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v4456 : System.IO.FileShare = System.IO.FileShare.Delete
                        v4456
                    | US8_0 -> (* ShareNone *)
                        let v4452 : System.IO.FileShare = System.IO.FileShare.None
                        v4452
                    | US8_1 -> (* ShareRead *)
                        let v4453 : System.IO.FileShare = System.IO.FileShare.Read
                        v4453
                    | US8_3 -> (* ShareReadWrite *)
                        let v4455 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v4455
                    | US8_2 -> (* ShareWrite *)
                        let v4454 : System.IO.FileShare = System.IO.FileShare.Write
                        v4454
                let v4462 : System.IO.FileStream = new System.IO.FileStream (v1, v4445, v4451, v4461)
                let _run_target_args'_v4426 = v4462 
                #endif
                let v4463 : System.IO.FileStream = _run_target_args'_v4426 
                use v4463 = v4463 
                let v4468 : System.IO.FileStream = v4463 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v4512 : exn = ex
                let v4513 : bool = v2 > 0L
                let v4516 : bool =
                    if v4513 then
                        let v4514 : int64 = v2 % 100L
                        let v4515 : bool = v4514 = 0L
                        v4515
                    else
                        false
                if v4516 then
                    let v4517 : unit = ()
                    let v4518 : (unit -> unit) = closure12(v1, v2, v4512)
                    let v4519 : unit = (fun () -> v4518 (); v4517) ()
                    ()
                (* run_target_args'
                let v4585 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4586 : (int32 -> Async<unit>) = Async.Sleep
                let v4587 : Async<unit> = v4586 10
                let _run_target_args'_v4585 = v4587 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4588 : (int32 -> Async<unit>) = Async.Sleep
                let v4589 : Async<unit> = v4588 10
                let _run_target_args'_v4585 = v4589 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4590 : (int32 -> Async<unit>) = Async.Sleep
                let v4591 : Async<unit> = v4590 10
                let _run_target_args'_v4585 = v4591 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4592 : (int32 -> Async<unit>) = Async.Sleep
                let v4593 : Async<unit> = v4592 10
                let _run_target_args'_v4585 = v4593 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4594 : (int32 -> Async<unit>) = Async.Sleep
                let v4595 : Async<unit> = v4594 10
                let _run_target_args'_v4585 = v4595 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4596 : (int32 -> Async<unit>) = Async.Sleep
                let v4597 : Async<unit> = v4596 10
                let _run_target_args'_v4585 = v4597 
                #endif
#else
                let v4598 : (int32 -> Async<unit>) = Async.Sleep
                let v4599 : Async<unit> = v4598 10
                let _run_target_args'_v4585 = v4599 
                #endif
                let v4600 : Async<unit> = _run_target_args'_v4585 
                do! v4600 
                let v4603 : int64 = v2 + 1L
                let v4604 : Async<int64> = method26(v0, v1, v4603)
                return! v4604 
                (* indent
                ()
            indent *)
            (* try_unit
            let v4698 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6626 : Async<int64> = _let'_v4423 
    let _run_target_args'_v5 = v6626 
    #endif
#else
    let v6627 : unit = ()
    let _let'_v6627 =
        async {
            try
                (* run_target_args'
                let v6630 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6631 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v6630 = v6631 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6634 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v6630 = v6634 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6637 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v6630 = v6637 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6640 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v6630 = v6640 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6643 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v6630 = v6643 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6646 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v6630 = v6646 
                #endif
#else
                let v6649 : System.IO.FileMode = System.IO.FileMode.Open
                let v6655 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v6650 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v6650
                    | US7_2 -> (* AccessReadWrite *)
                        let v6652 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v6652
                    | US7_1 -> (* AccessWrite *)
                        let v6651 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v6651
                let v6665 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v6660 : System.IO.FileShare = System.IO.FileShare.Delete
                        v6660
                    | US8_0 -> (* ShareNone *)
                        let v6656 : System.IO.FileShare = System.IO.FileShare.None
                        v6656
                    | US8_1 -> (* ShareRead *)
                        let v6657 : System.IO.FileShare = System.IO.FileShare.Read
                        v6657
                    | US8_3 -> (* ShareReadWrite *)
                        let v6659 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v6659
                    | US8_2 -> (* ShareWrite *)
                        let v6658 : System.IO.FileShare = System.IO.FileShare.Write
                        v6658
                let v6666 : System.IO.FileStream = new System.IO.FileStream (v1, v6649, v6655, v6665)
                let _run_target_args'_v6630 = v6666 
                #endif
                let v6667 : System.IO.FileStream = _run_target_args'_v6630 
                use v6667 = v6667 
                let v6672 : System.IO.FileStream = v6667 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v6716 : exn = ex
                let v6717 : bool = v2 > 0L
                let v6720 : bool =
                    if v6717 then
                        let v6718 : int64 = v2 % 100L
                        let v6719 : bool = v6718 = 0L
                        v6719
                    else
                        false
                if v6720 then
                    let v6721 : unit = ()
                    let v6722 : (unit -> unit) = closure12(v1, v2, v6716)
                    let v6723 : unit = (fun () -> v6722 (); v6721) ()
                    ()
                (* run_target_args'
                let v6789 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6790 : (int32 -> Async<unit>) = Async.Sleep
                let v6791 : Async<unit> = v6790 10
                let _run_target_args'_v6789 = v6791 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6792 : (int32 -> Async<unit>) = Async.Sleep
                let v6793 : Async<unit> = v6792 10
                let _run_target_args'_v6789 = v6793 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6794 : (int32 -> Async<unit>) = Async.Sleep
                let v6795 : Async<unit> = v6794 10
                let _run_target_args'_v6789 = v6795 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6796 : (int32 -> Async<unit>) = Async.Sleep
                let v6797 : Async<unit> = v6796 10
                let _run_target_args'_v6789 = v6797 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6798 : (int32 -> Async<unit>) = Async.Sleep
                let v6799 : Async<unit> = v6798 10
                let _run_target_args'_v6789 = v6799 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6800 : (int32 -> Async<unit>) = Async.Sleep
                let v6801 : Async<unit> = v6800 10
                let _run_target_args'_v6789 = v6801 
                #endif
#else
                let v6802 : (int32 -> Async<unit>) = Async.Sleep
                let v6803 : Async<unit> = v6802 10
                let _run_target_args'_v6789 = v6803 
                #endif
                let v6804 : Async<unit> = _run_target_args'_v6789 
                do! v6804 
                let v6807 : int64 = v2 + 1L
                let v6808 : Async<int64> = method26(v0, v1, v6807)
                return! v6808 
                (* indent
                ()
            indent *)
            (* try_unit
            let v6902 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v8830 : Async<int64> = _let'_v6627 
    let _run_target_args'_v5 = v8830 
    #endif
    let v8831 : Async<int64> = _run_target_args'_v5 
    v8831
and method26 (v0 : US6, v1 : string, v2 : int64) : Async<int64> =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v16 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v16 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v19 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v19 
    #endif
#else
    let struct (v28 : US7, v29 : US8) =
        match v0 with
        | US6_1 -> (* None *)
            let v24 : US7 = US7_2
            let v25 : US8 = US8_1
            struct (v24, v25)
        | US6_0(v22, v23) -> (* Some *)
            struct (v22, v23)
    let v30 : Async<int64> = method27(v0, v1, v2, v29, v28)
    let _run_target_args'_v3 = v30 
    #endif
    let v31 : Async<int64> = _run_target_args'_v3 
    v31
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
and method31 (v0 : string) : Async<string> =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v1 = v11 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v1 = v14 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v17 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v1 = v17 
    #endif
#else
    let v20 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
    let v21 : System.Threading.Tasks.Task<string> = v20 v0
    (* run_target_args'
    let v22 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v23 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v22 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v26 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v22 = v26 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : Async<string> = null |> unbox<Async<string>>
    let _run_target_args'_v22 = v29 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v32 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
    let v33 : Async<string> = v32 v21
    let _run_target_args'_v22 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
    let v35 : Async<string> = v34 v21
    let _run_target_args'_v22 = v35 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
    let v37 : Async<string> = v36 v21
    let _run_target_args'_v22 = v37 
    #endif
#else
    let v38 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
    let v39 : Async<string> = v38 v21
    let _run_target_args'_v22 = v39 
    #endif
    let v40 : Async<string> = _run_target_args'_v22 
    let _run_target_args'_v1 = v40 
    #endif
    let v45 : Async<string> = _run_target_args'_v1 
    v45
and closure14 () (v0 : string) : Async<string> =
    method31(v0)
and method33 (v0 : string) : bool =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "&*$0"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let _run_target_args'_v2 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : string = "&*$0"
    let v6 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v5 
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7 : string = "&*$0"
    let v8 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let _run_target_args'_v2 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v9 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v12 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v15 
    #endif
#else
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v18 
    #endif
    let v21 : Ref<Str> = _run_target_args'_v2 
    (* run_target_args'
    let v26 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v27 : string = "String::from($0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v27 
    let _run_target_args'_v26 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = "String::from($0)"
    let v30 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v29 
    let _run_target_args'_v26 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "String::from($0)"
    let v32 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v31 
    let _run_target_args'_v26 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v33 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v36 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v39 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v39 
    #endif
#else
    let v42 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v42 
    #endif
    let v45 : std_string_String = _run_target_args'_v26 
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = "std::path::PathBuf::from($0)"
    let v52 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v51 
    let _run_target_args'_v50 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : string = "std::path::PathBuf::from($0)"
    let v54 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v53 
    let _run_target_args'_v50 = v54 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v55 : string = "std::path::PathBuf::from($0)"
    let v56 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v55 
    let _run_target_args'_v50 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v57 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v57 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v63 
    #endif
#else
    let v66 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v66 
    #endif
    let v69 : std_path_PathBuf = _run_target_args'_v50 
    let v74 : string = "$0.exists()"
    let v75 : bool = Fable.Core.RustInterop.emitRustExpr v69 v74 
    let v78 : bool =
        if v75 then
            let v76 : string = "$0.is_file()"
            let v77 : bool = Fable.Core.RustInterop.emitRustExpr v69 v76 
            v77
        else
            false
    let _run_target_args'_v1 = v78 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v79 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v79 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v82 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v85 : string = "fs"
    let v86 : IFsExistsSync = Fable.Core.JsInterop.importAll v85 
    let v87 : string = "$0.existsSync($1)"
    let v88 : bool = Fable.Core.JsInterop.emitJsExpr struct (v86, v0) v87 
    let _run_target_args'_v1 = v88 
    #endif
#if FABLE_COMPILER_PYTHON
    let v89 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v89 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v92 : bool = null |> unbox<bool>
    let _run_target_args'_v1 = v92 
    #endif
#else
    let v95 : (string -> bool) = System.IO.File.Exists
    let v96 : bool = v95 v0
    let _run_target_args'_v1 = v96 
    #endif
    let v97 : bool = _run_target_args'_v1 
    v97
and method34 (v0 : Vec<uint8>) : Vec<uint8> =
    v0
and method32 (v0 : string, v1 : string) : bool =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : bool = method33(v0)
    let v4 : bool = v3 = false
    let v87 : bool =
        if v4 then
            false
        else
            (* run_target_args'
            let v5 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            (* run_target_args'
            let v6 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v7 : string = "std::fs::read(&*$0)"
            let v8 : Result<Vec<uint8>, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v7 
            (* run_target_args'
            let v9 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v10 : string = "$0.unwrap()"
            let v11 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v8 v10 
            let _run_target_args'_v9 = v11 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v12 : string = "$0.unwrap()"
            let v13 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v8 v12 
            let _run_target_args'_v9 = v13 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v14 : string = "$0.unwrap()"
            let v15 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v8 v14 
            let _run_target_args'_v9 = v15 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v16 : Vec<uint8> = match v8 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v9 = v16 
            #endif
#if FABLE_COMPILER_PYTHON
            let v17 : Vec<uint8> = match v8 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v9 = v17 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v18 : Vec<uint8> = match v8 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v9 = v18 
            #endif
#else
            let v19 : Vec<uint8> = match v8 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v9 = v19 
            #endif
            let v20 : Vec<uint8> = _run_target_args'_v9 
            let _run_target_args'_v6 = v20 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v23 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v6 = v23 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v26 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v6 = v26 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v29 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v6 = v29 
            #endif
#if FABLE_COMPILER_PYTHON
            let v32 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v6 = v32 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v35 : Vec<uint8> = null |> unbox<Vec<uint8>>
            let _run_target_args'_v6 = v35 
            #endif
#else
            let v38 : (uint8 []) = v0 |> System.IO.File.ReadAllBytes
            let v39 : string = "$0.to_vec()"
            let v40 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v38 v39 
            let _run_target_args'_v6 = v40 
            #endif
            let v41 : Vec<uint8> = _run_target_args'_v6 
            let v46 : Vec<uint8> = method34(v41)
            let v47 : string = "std::string::String::from_utf8($0)"
            let v48 : Result<std_string_String, std_string_FromUtf8Error> = Fable.Core.RustInterop.emitRustExpr v46 v47 
            (* run_target_args'
            let v49 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v50 : string = "$0.unwrap()"
            let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr v48 v50 
            let _run_target_args'_v49 = v51 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v52 : string = "$0.unwrap()"
            let v53 : std_string_String = Fable.Core.RustInterop.emitRustExpr v48 v52 
            let _run_target_args'_v49 = v53 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v54 : string = "$0.unwrap()"
            let v55 : std_string_String = Fable.Core.RustInterop.emitRustExpr v48 v54 
            let _run_target_args'_v49 = v55 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v56 : std_string_String = match v48 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v49 = v56 
            #endif
#if FABLE_COMPILER_PYTHON
            let v57 : std_string_String = match v48 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v49 = v57 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v58 : std_string_String = match v48 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v49 = v58 
            #endif
#else
            let v59 : std_string_String = match v48 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v49 = v59 
            #endif
            let v60 : std_string_String = _run_target_args'_v49 
            let v63 : string = "fable_library_rust::String_::fromString($0)"
            let v64 : string = Fable.Core.RustInterop.emitRustExpr v60 v63 
            let _run_target_args'_v5 = v64 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v65 : string = null |> unbox<string>
            let _run_target_args'_v5 = v65 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v68 : string = null |> unbox<string>
            let _run_target_args'_v5 = v68 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v71 : string = null |> unbox<string>
            let _run_target_args'_v5 = v71 
            #endif
#if FABLE_COMPILER_PYTHON
            let v74 : string = null |> unbox<string>
            let _run_target_args'_v5 = v74 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v77 : string = null |> unbox<string>
            let _run_target_args'_v5 = v77 
            #endif
#else
            let v80 : string = v0 |> System.IO.File.ReadAllText
            let _run_target_args'_v5 = v80 
            #endif
            let v81 : string = _run_target_args'_v5 
            let v86 : bool = v1 = v81
            v86
    let _run_target_args'_v2 = v87 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v88 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v88 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v91 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v94 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v94 
    #endif
#if FABLE_COMPILER_PYTHON
    let v97 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v97 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v100 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v100 
    #endif
#else
    let v103 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v103 
    #endif
    let v106 : bool = _run_target_args'_v2 
    v106
and closure16 (v0 : string) (v1 : string) : bool =
    method32(v0, v1)
and closure15 () (v0 : string) : (string -> bool) =
    closure16(v0)
and method35 (v0 : string, v1 : string) : Async<unit> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v18 
    #endif
#else
    let v21 : System.Threading.Tasks.Task = System.IO.File.WriteAllTextAsync (v0, v1)
    (* run_target_args'
    let v22 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v23 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v22 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v26 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v22 = v26 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v29 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v22 = v29 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v32 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v33 : Async<unit> = v32 v21
    let _run_target_args'_v22 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v34 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v35 : Async<unit> = v34 v21
    let _run_target_args'_v22 = v35 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v37 : Async<unit> = v36 v21
    let _run_target_args'_v22 = v37 
    #endif
#else
    let v38 : (System.Threading.Tasks.Task -> Async<unit>) = Async.AwaitTask
    let v39 : Async<unit> = v38 v21
    let _run_target_args'_v22 = v39 
    #endif
    let v40 : Async<unit> = _run_target_args'_v22 
    let _run_target_args'_v2 = v40 
    #endif
    let v45 : Async<unit> = _run_target_args'_v2 
    v45
and closure18 (v0 : string) (v1 : string) : Async<unit> =
    method35(v0, v1)
and closure17 () (v0 : string) : (string -> Async<unit>) =
    closure18(v0)
and method39 (v0 : string, v1 : string) : Async<bool> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            let v15 : bool = method33(v0)
            let v16 : bool = v15 = false
            if v16 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v17 : Async<string> = method31(v0)
                let! v17 = v17 
                let v18 : string = v17 
                let v19 : bool = v1 = v18
                return v19 
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
    let v55 : Async<bool> = _let'_v12 
    let _run_target_args'_v2 = v55 
    #endif
#if FABLE_COMPILER_PYTHON
    let v56 : unit = ()
    let _let'_v56 =
        async {
            let v59 : bool = method33(v0)
            let v60 : bool = v59 = false
            if v60 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v61 : Async<string> = method31(v0)
                let! v61 = v61 
                let v62 : string = v61 
                let v63 : bool = v1 = v62
                return v63 
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
    let v99 : Async<bool> = _let'_v56 
    let _run_target_args'_v2 = v99 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v100 : unit = ()
    let _let'_v100 =
        async {
            let v103 : bool = method33(v0)
            let v104 : bool = v103 = false
            if v104 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v105 : Async<string> = method31(v0)
                let! v105 = v105 
                let v106 : string = v105 
                let v107 : bool = v1 = v106
                return v107 
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
    let v143 : Async<bool> = _let'_v100 
    let _run_target_args'_v2 = v143 
    #endif
#else
    let v144 : unit = ()
    let _let'_v144 =
        async {
            let v147 : bool = method33(v0)
            let v148 : bool = v147 = false
            if v148 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v149 : Async<string> = method31(v0)
                let! v149 = v149 
                let v150 : string = v149 
                let v151 : bool = v1 = v150
                return v151 
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
    let v187 : Async<bool> = _let'_v144 
    let _run_target_args'_v2 = v187 
    #endif
    let v188 : Async<bool> = _run_target_args'_v2 
    v188
and method38 (v0 : string, v1 : string) : Async<bool> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18 : Async<bool> = null |> unbox<Async<bool>>
    let _run_target_args'_v2 = v18 
    #endif
#else
    let v21 : Async<bool> = method39(v0, v1)
    let _run_target_args'_v2 = v21 
    #endif
    let v22 : Async<bool> = _run_target_args'_v2 
    v22
and method37 (v0 : string, v1 : string) : Async<unit> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            let v15 : Async<bool> = method38(v0, v1)
            let! v15 = v15 
            let v16 : bool = v15 
            let v17 : bool = v16 = false
            if v17 then
                let v18 : Async<unit> = method35(v0, v1)
                do! v18 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v47 : Async<unit> = _let'_v12 
    let _run_target_args'_v2 = v47 
    #endif
#if FABLE_COMPILER_PYTHON
    let v48 : unit = ()
    let _let'_v48 =
        async {
            let v51 : Async<bool> = method38(v0, v1)
            let! v51 = v51 
            let v52 : bool = v51 
            let v53 : bool = v52 = false
            if v53 then
                let v54 : Async<unit> = method35(v0, v1)
                do! v54 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v83 : Async<unit> = _let'_v48 
    let _run_target_args'_v2 = v83 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v84 : unit = ()
    let _let'_v84 =
        async {
            let v87 : Async<bool> = method38(v0, v1)
            let! v87 = v87 
            let v88 : bool = v87 
            let v89 : bool = v88 = false
            if v89 then
                let v90 : Async<unit> = method35(v0, v1)
                do! v90 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v119 : Async<unit> = _let'_v84 
    let _run_target_args'_v2 = v119 
    #endif
#else
    let v120 : unit = ()
    let _let'_v120 =
        async {
            let v123 : Async<bool> = method38(v0, v1)
            let! v123 = v123 
            let v124 : bool = v123 
            let v125 : bool = v124 = false
            if v125 then
                let v126 : Async<unit> = method35(v0, v1)
                do! v126 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v155 : Async<unit> = _let'_v120 
    let _run_target_args'_v2 = v155 
    #endif
    let v156 : Async<unit> = _run_target_args'_v2 
    v156
and method36 (v0 : string, v1 : string) : Async<unit> =
    method37(v0, v1)
and closure20 (v0 : string) (v1 : string) : Async<unit> =
    method36(v0, v1)
and closure19 () (v0 : string) : (string -> Async<unit>) =
    closure20(v0)
and method44 (v0 : std_io_Error) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "format!(\"{:#?}\", $0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v4 
    let v6 : string = "fable_library_rust::String_::fromString($0)"
    let v7 : string = Fable.Core.RustInterop.emitRustExpr v5 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "format!(\"{:#?}\", $0)"
    let v9 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let v10 : string = "fable_library_rust::String_::fromString($0)"
    let v11 : string = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let _run_target_args'_v3 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : string = "format!(\"{:#?}\", $0)"
    let v13 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v12 
    let v14 : string = "fable_library_rust::String_::fromString($0)"
    let v15 : string = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let _run_target_args'_v3 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : string = $"%A{v0}"
    let _run_target_args'_v3 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v19 : string = $"%A{v0}"
    let _run_target_args'_v3 = v19 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v22 : string = $"%A{v0}"
    let _run_target_args'_v3 = v22 
    #endif
#else
    let v25 : string = $"%A{v0}"
    let _run_target_args'_v3 = v25 
    #endif
    let v28 : string = _run_target_args'_v3 
    let v33 : string = $"{v28}"
    let v36 : unit = ()
    let v37 : (unit -> unit) = closure6(v2, v33)
    let v38 : unit = (fun () -> v37 (); v36) ()
    let v41 : string = v2.l0
    v41
and closure22 () (v0 : std_io_Error) : string =
    method44(v0)
and method43 () : (std_io_Error -> string) =
    closure22()
and closure23 () () : US9 =
    US9_0
and method45 () : (unit -> US9) =
    closure23()
and closure24 () (v0 : string) : US9 =
    US9_1(v0)
and method46 () : (string -> US9) =
    closure24()
and method47 () : string =
    
    
    
    
    
    let v0 : string = "Critical"
    let v1 : (unit -> string) = v0.ToLower
    let v2 : string = v1 ()
    let v5 : char = v2.[int 0]
    let v6 : string = method17(v5)
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "inline_colorization::color_bright_red"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v8 
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v17 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v23 
    #endif
#else
    let v26 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
    let v29 : Ref<Str> = _run_target_args'_v10 
    let v34 : string = "inline_colorization::color_reset"
    let v35 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v34 
    let v36 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v9, v29, v35) v36 
    let v38 : string = "fable_library_rust::String_::fromString($0)"
    let v39 : string = Fable.Core.RustInterop.emitRustExpr v37 v38 
    let _run_target_args'_v7 = v39 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v40 : string = "inline_colorization::color_bright_red"
    let v41 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v40 
    (* run_target_args'
    let v42 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v43 : string = "&*$0"
    let v44 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v43 
    let _run_target_args'_v42 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "&*$0"
    let v46 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v45 
    let _run_target_args'_v42 = v46 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v47 : string = "&*$0"
    let v48 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v47 
    let _run_target_args'_v42 = v48 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v49 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v52 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v55 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v55 
    #endif
#else
    let v58 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v58 
    #endif
    let v61 : Ref<Str> = _run_target_args'_v42 
    let v66 : string = "inline_colorization::color_reset"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v66 
    let v68 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v69 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v41, v61, v67) v68 
    let v70 : string = "fable_library_rust::String_::fromString($0)"
    let v71 : string = Fable.Core.RustInterop.emitRustExpr v69 v70 
    let _run_target_args'_v7 = v71 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v72 : string = "inline_colorization::color_bright_red"
    let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v72 
    (* run_target_args'
    let v74 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v75 : string = "&*$0"
    let v76 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v75 
    let _run_target_args'_v74 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v77 
    let _run_target_args'_v74 = v78 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v79 
    let _run_target_args'_v74 = v80 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v81 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v81 
    #endif
#if FABLE_COMPILER_PYTHON
    let v84 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v84 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v87 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v87 
    #endif
#else
    let v90 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v90 
    #endif
    let v93 : Ref<Str> = _run_target_args'_v74 
    let v98 : string = "inline_colorization::color_reset"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v98 
    let v100 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v101 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v73, v93, v99) v100 
    let v102 : string = "fable_library_rust::String_::fromString($0)"
    let v103 : string = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let _run_target_args'_v7 = v103 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v104 : string = "\u001b[91m"
    let v105 : string = method19()
    let v106 : string = v104 + v6 
    let v107 : string = v106 + v105 
    let _run_target_args'_v7 = v107 
    #endif
#if FABLE_COMPILER_PYTHON
    let v108 : string = "\u001b[91m"
    let v109 : string = method19()
    let v110 : string = v108 + v6 
    let v111 : string = v110 + v109 
    let _run_target_args'_v7 = v111 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v112 : string = "\u001b[91m"
    let v113 : string = method19()
    let v114 : string = v112 + v6 
    let v115 : string = v114 + v113 
    let _run_target_args'_v7 = v115 
    #endif
#else
    let v116 : string = "\u001b[91m"
    let v117 : string = method19()
    let v118 : string = v116 + v6 
    let v119 : string = v118 + v117 
    let _run_target_args'_v7 = v119 
    #endif
    let v120 : string = _run_target_args'_v7 
    v120
and method49 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v3 : string = "{ "
    let v4 : string = $"{v3}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure6(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = "error'"
    let v13 : string = $"{v12}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6(v2, v13)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v21 : string = " = "
    let v22 : string = $"{v21}"
    let v25 : unit = ()
    let v26 : (unit -> unit) = closure6(v2, v22)
    let v27 : unit = (fun () -> v26 (); v25) ()
    let v30 : string = $"{v0}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v2, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v38 : string = " }"
    let v39 : string = $"{v38}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v2, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : string = v2.l0
    v47
and method48 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method49(v8)
    let v10 : int64 = v0.l0
    let v11 : string = "file_system.file_delete"
    let v12 : string = $"{v6} {v7} #{v10} %s{v11} / {v9}"
    method23(v12)
and closure25 (v0 : string) () : unit =
    let v1 : US0 = US0_4
    let v2 : bool = method11(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v19 : Mut0, v20 : Mut1, v21 : Mut2, v22 : Mut3, v23 : Mut4, v24 : int64 option) = TraceState.trace_state.Value
        let v37 : string = method12(v19, v20, v21, v22, v23, v24)
        let v38 : string = method47()
        let v39 : string = method48(v19, v20, v21, v22, v23, v24, v37, v38, v0)
        method24(v39)
and method50 () : string =
    
    
    
    
    
    let v0 : string = "Warning"
    let v1 : (unit -> string) = v0.ToLower
    let v2 : string = v1 ()
    let v5 : char = v2.[int 0]
    let v6 : string = method17(v5)
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "inline_colorization::color_yellow"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v8 
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v17 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v23 
    #endif
#else
    let v26 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
    let v29 : Ref<Str> = _run_target_args'_v10 
    let v34 : string = "inline_colorization::color_reset"
    let v35 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v34 
    let v36 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v9, v29, v35) v36 
    let v38 : string = "fable_library_rust::String_::fromString($0)"
    let v39 : string = Fable.Core.RustInterop.emitRustExpr v37 v38 
    let _run_target_args'_v7 = v39 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v40 : string = "inline_colorization::color_yellow"
    let v41 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v40 
    (* run_target_args'
    let v42 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v43 : string = "&*$0"
    let v44 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v43 
    let _run_target_args'_v42 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "&*$0"
    let v46 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v45 
    let _run_target_args'_v42 = v46 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v47 : string = "&*$0"
    let v48 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v47 
    let _run_target_args'_v42 = v48 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v49 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v52 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v55 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v55 
    #endif
#else
    let v58 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v58 
    #endif
    let v61 : Ref<Str> = _run_target_args'_v42 
    let v66 : string = "inline_colorization::color_reset"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v66 
    let v68 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v69 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v41, v61, v67) v68 
    let v70 : string = "fable_library_rust::String_::fromString($0)"
    let v71 : string = Fable.Core.RustInterop.emitRustExpr v69 v70 
    let _run_target_args'_v7 = v71 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v72 : string = "inline_colorization::color_yellow"
    let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v72 
    (* run_target_args'
    let v74 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v75 : string = "&*$0"
    let v76 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v75 
    let _run_target_args'_v74 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v77 
    let _run_target_args'_v74 = v78 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v79 
    let _run_target_args'_v74 = v80 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v81 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v81 
    #endif
#if FABLE_COMPILER_PYTHON
    let v84 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v84 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v87 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v87 
    #endif
#else
    let v90 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v90 
    #endif
    let v93 : Ref<Str> = _run_target_args'_v74 
    let v98 : string = "inline_colorization::color_reset"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v98 
    let v100 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v101 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v73, v93, v99) v100 
    let v102 : string = "fable_library_rust::String_::fromString($0)"
    let v103 : string = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let _run_target_args'_v7 = v103 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v104 : string = "\u001b[93m"
    let v105 : string = method19()
    let v106 : string = v104 + v6 
    let v107 : string = v106 + v105 
    let _run_target_args'_v7 = v107 
    #endif
#if FABLE_COMPILER_PYTHON
    let v108 : string = "\u001b[93m"
    let v109 : string = method19()
    let v110 : string = v108 + v6 
    let v111 : string = v110 + v109 
    let _run_target_args'_v7 = v111 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v112 : string = "\u001b[93m"
    let v113 : string = method19()
    let v114 : string = v112 + v6 
    let v115 : string = v114 + v113 
    let _run_target_args'_v7 = v115 
    #endif
#else
    let v116 : string = "\u001b[93m"
    let v117 : string = method19()
    let v118 : string = v116 + v6 
    let v119 : string = v118 + v117 
    let _run_target_args'_v7 = v119 
    #endif
    let v120 : string = _run_target_args'_v7 
    v120
and method52 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "path"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "ex"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v65 : string = $"{v1}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v3, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v73 : string = " }"
    let v74 : string = $"{v73}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v3, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = v3.l0
    v82
and method51 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method52(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "delete_file_async"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
and closure26 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method50()
        let v40 : string = method20(v0)
        (* run_target_args'
        let v41 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v42 : string = $"%A{v1}"
        let _run_target_args'_v41 = v42 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v45 : string = $"%A{v1}"
        let _run_target_args'_v41 = v45 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v48 : string = $"%A{v1}"
        let _run_target_args'_v41 = v48 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v51 : string = $"%A{v1}"
        let _run_target_args'_v41 = v51 
        #endif
#if FABLE_COMPILER_PYTHON
        let v54 : string = $"%A{v1}"
        let _run_target_args'_v41 = v54 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v57 : string = $"%A{v1}"
        let _run_target_args'_v41 = v57 
        #endif
#else
        let v60 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v41 = v60 
        #endif
        let v61 : string = _run_target_args'_v41 
        let v66 : string = method51(v20, v21, v22, v23, v24, v25, v38, v39, v40, v61)
        method24(v66)
and method42 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            try
                (* run_target_args'
                let v15 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v16 : string = "std::fs::remove_file(&*$0)"
                let v17 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v16 
                let v18 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v19 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v20 : string = "$0.map_err(|x| $1(x))"
                let v21 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v17, v18) v20 
                let _run_target_args'_v19 = v21 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v22 : string = "$0.map_err(|x| $1(x))"
                let v23 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v17, v18) v22 
                let _run_target_args'_v19 = v23 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v24 : string = "$0.map_err(|x| $1(x))"
                let v25 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v17, v18) v24 
                let _run_target_args'_v19 = v25 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v26 : Result<unit, string> = match v17 with Ok x -> Ok x | Error x -> Error (v18 x)
                let _run_target_args'_v19 = v26 
                #endif
#if FABLE_COMPILER_PYTHON
                let v27 : Result<unit, string> = match v17 with Ok x -> Ok x | Error x -> Error (v18 x)
                let _run_target_args'_v19 = v27 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28 : Result<unit, string> = match v17 with Ok x -> Ok x | Error x -> Error (v18 x)
                let _run_target_args'_v19 = v28 
                #endif
#else
                let v29 : Result<unit, string> = match v17 with Ok x -> Ok x | Error x -> Error (v18 x)
                let _run_target_args'_v19 = v29 
                #endif
                let v30 : Result<unit, string> = _run_target_args'_v19 
                let v33 : (unit -> US9) = method45()
                let v34 : (string -> US9) = method46()
                let v35 : US9 = match v30 with Ok () -> v33 () | Error x -> v34 x
                match v35 with
                | US9_1(v36) -> (* Error *)
                    let v37 : unit = ()
                    let v38 : (unit -> unit) = closure25(v36)
                    let v39 : unit = (fun () -> v38 (); v37) ()
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
                let v79 : (string -> unit) = System.IO.File.Delete
                v79 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v145 : exn = ex
                let v146 : int64 = v1 % 100L
                let v147 : bool = v146 = 0L
                if v147 then
                    let v148 : unit = ()
                    let v149 : (unit -> unit) = closure26(v0, v145)
                    let v150 : unit = (fun () -> v149 (); v148) ()
                    ()
                (* run_target_args'
                let v216 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v217 : (int32 -> Async<unit>) = Async.Sleep
                let v218 : Async<unit> = v217 10
                let _run_target_args'_v216 = v218 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v219 : (int32 -> Async<unit>) = Async.Sleep
                let v220 : Async<unit> = v219 10
                let _run_target_args'_v216 = v220 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v221 : (int32 -> Async<unit>) = Async.Sleep
                let v222 : Async<unit> = v221 10
                let _run_target_args'_v216 = v222 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v223 : (int32 -> Async<unit>) = Async.Sleep
                let v224 : Async<unit> = v223 10
                let _run_target_args'_v216 = v224 
                #endif
#if FABLE_COMPILER_PYTHON
                let v225 : (int32 -> Async<unit>) = Async.Sleep
                let v226 : Async<unit> = v225 10
                let _run_target_args'_v216 = v226 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v227 : (int32 -> Async<unit>) = Async.Sleep
                let v228 : Async<unit> = v227 10
                let _run_target_args'_v216 = v228 
                #endif
#else
                let v229 : (int32 -> Async<unit>) = Async.Sleep
                let v230 : Async<unit> = v229 10
                let _run_target_args'_v216 = v230 
                #endif
                let v231 : Async<unit> = _run_target_args'_v216 
                do! v231 
                let v234 : int64 = v1 + 1L
                let v235 : Async<int64> = method41(v0, v234)
                return! v235 
                (* indent
                ()
            indent *)
            (* try_unit
            let v327 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2535 : Async<int64> = _let'_v12 
    let _run_target_args'_v2 = v2535 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2536 : unit = ()
    let _let'_v2536 =
        async {
            try
                (* run_target_args'
                let v2539 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2540 : string = "std::fs::remove_file(&*$0)"
                let v2541 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v2540 
                let v2542 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v2543 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2544 : string = "$0.map_err(|x| $1(x))"
                let v2545 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v2541, v2542) v2544 
                let _run_target_args'_v2543 = v2545 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2546 : string = "$0.map_err(|x| $1(x))"
                let v2547 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v2541, v2542) v2546 
                let _run_target_args'_v2543 = v2547 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2548 : string = "$0.map_err(|x| $1(x))"
                let v2549 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v2541, v2542) v2548 
                let _run_target_args'_v2543 = v2549 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2550 : Result<unit, string> = match v2541 with Ok x -> Ok x | Error x -> Error (v2542 x)
                let _run_target_args'_v2543 = v2550 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2551 : Result<unit, string> = match v2541 with Ok x -> Ok x | Error x -> Error (v2542 x)
                let _run_target_args'_v2543 = v2551 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2552 : Result<unit, string> = match v2541 with Ok x -> Ok x | Error x -> Error (v2542 x)
                let _run_target_args'_v2543 = v2552 
                #endif
#else
                let v2553 : Result<unit, string> = match v2541 with Ok x -> Ok x | Error x -> Error (v2542 x)
                let _run_target_args'_v2543 = v2553 
                #endif
                let v2554 : Result<unit, string> = _run_target_args'_v2543 
                let v2557 : (unit -> US9) = method45()
                let v2558 : (string -> US9) = method46()
                let v2559 : US9 = match v2554 with Ok () -> v2557 () | Error x -> v2558 x
                match v2559 with
                | US9_1(v2560) -> (* Error *)
                    let v2561 : unit = ()
                    let v2562 : (unit -> unit) = closure25(v2560)
                    let v2563 : unit = (fun () -> v2562 (); v2561) ()
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
                let v2603 : (string -> unit) = System.IO.File.Delete
                v2603 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v2669 : exn = ex
                let v2670 : int64 = v1 % 100L
                let v2671 : bool = v2670 = 0L
                if v2671 then
                    let v2672 : unit = ()
                    let v2673 : (unit -> unit) = closure26(v0, v2669)
                    let v2674 : unit = (fun () -> v2673 (); v2672) ()
                    ()
                (* run_target_args'
                let v2740 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2741 : (int32 -> Async<unit>) = Async.Sleep
                let v2742 : Async<unit> = v2741 10
                let _run_target_args'_v2740 = v2742 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2743 : (int32 -> Async<unit>) = Async.Sleep
                let v2744 : Async<unit> = v2743 10
                let _run_target_args'_v2740 = v2744 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2745 : (int32 -> Async<unit>) = Async.Sleep
                let v2746 : Async<unit> = v2745 10
                let _run_target_args'_v2740 = v2746 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2747 : (int32 -> Async<unit>) = Async.Sleep
                let v2748 : Async<unit> = v2747 10
                let _run_target_args'_v2740 = v2748 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2749 : (int32 -> Async<unit>) = Async.Sleep
                let v2750 : Async<unit> = v2749 10
                let _run_target_args'_v2740 = v2750 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2751 : (int32 -> Async<unit>) = Async.Sleep
                let v2752 : Async<unit> = v2751 10
                let _run_target_args'_v2740 = v2752 
                #endif
#else
                let v2753 : (int32 -> Async<unit>) = Async.Sleep
                let v2754 : Async<unit> = v2753 10
                let _run_target_args'_v2740 = v2754 
                #endif
                let v2755 : Async<unit> = _run_target_args'_v2740 
                do! v2755 
                let v2758 : int64 = v1 + 1L
                let v2759 : Async<int64> = method41(v0, v2758)
                return! v2759 
                (* indent
                ()
            indent *)
            (* try_unit
            let v2851 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5059 : Async<int64> = _let'_v2536 
    let _run_target_args'_v2 = v5059 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5060 : unit = ()
    let _let'_v5060 =
        async {
            try
                (* run_target_args'
                let v5063 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5064 : string = "std::fs::remove_file(&*$0)"
                let v5065 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v5064 
                let v5066 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v5067 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5068 : string = "$0.map_err(|x| $1(x))"
                let v5069 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v5065, v5066) v5068 
                let _run_target_args'_v5067 = v5069 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5070 : string = "$0.map_err(|x| $1(x))"
                let v5071 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v5065, v5066) v5070 
                let _run_target_args'_v5067 = v5071 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5072 : string = "$0.map_err(|x| $1(x))"
                let v5073 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v5065, v5066) v5072 
                let _run_target_args'_v5067 = v5073 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5074 : Result<unit, string> = match v5065 with Ok x -> Ok x | Error x -> Error (v5066 x)
                let _run_target_args'_v5067 = v5074 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5075 : Result<unit, string> = match v5065 with Ok x -> Ok x | Error x -> Error (v5066 x)
                let _run_target_args'_v5067 = v5075 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5076 : Result<unit, string> = match v5065 with Ok x -> Ok x | Error x -> Error (v5066 x)
                let _run_target_args'_v5067 = v5076 
                #endif
#else
                let v5077 : Result<unit, string> = match v5065 with Ok x -> Ok x | Error x -> Error (v5066 x)
                let _run_target_args'_v5067 = v5077 
                #endif
                let v5078 : Result<unit, string> = _run_target_args'_v5067 
                let v5081 : (unit -> US9) = method45()
                let v5082 : (string -> US9) = method46()
                let v5083 : US9 = match v5078 with Ok () -> v5081 () | Error x -> v5082 x
                match v5083 with
                | US9_1(v5084) -> (* Error *)
                    let v5085 : unit = ()
                    let v5086 : (unit -> unit) = closure25(v5084)
                    let v5087 : unit = (fun () -> v5086 (); v5085) ()
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
                let v5127 : (string -> unit) = System.IO.File.Delete
                v5127 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v5193 : exn = ex
                let v5194 : int64 = v1 % 100L
                let v5195 : bool = v5194 = 0L
                if v5195 then
                    let v5196 : unit = ()
                    let v5197 : (unit -> unit) = closure26(v0, v5193)
                    let v5198 : unit = (fun () -> v5197 (); v5196) ()
                    ()
                (* run_target_args'
                let v5264 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5265 : (int32 -> Async<unit>) = Async.Sleep
                let v5266 : Async<unit> = v5265 10
                let _run_target_args'_v5264 = v5266 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5267 : (int32 -> Async<unit>) = Async.Sleep
                let v5268 : Async<unit> = v5267 10
                let _run_target_args'_v5264 = v5268 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5269 : (int32 -> Async<unit>) = Async.Sleep
                let v5270 : Async<unit> = v5269 10
                let _run_target_args'_v5264 = v5270 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5271 : (int32 -> Async<unit>) = Async.Sleep
                let v5272 : Async<unit> = v5271 10
                let _run_target_args'_v5264 = v5272 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5273 : (int32 -> Async<unit>) = Async.Sleep
                let v5274 : Async<unit> = v5273 10
                let _run_target_args'_v5264 = v5274 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5275 : (int32 -> Async<unit>) = Async.Sleep
                let v5276 : Async<unit> = v5275 10
                let _run_target_args'_v5264 = v5276 
                #endif
#else
                let v5277 : (int32 -> Async<unit>) = Async.Sleep
                let v5278 : Async<unit> = v5277 10
                let _run_target_args'_v5264 = v5278 
                #endif
                let v5279 : Async<unit> = _run_target_args'_v5264 
                do! v5279 
                let v5282 : int64 = v1 + 1L
                let v5283 : Async<int64> = method41(v0, v5282)
                return! v5283 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5375 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7583 : Async<int64> = _let'_v5060 
    let _run_target_args'_v2 = v7583 
    #endif
#else
    let v7584 : unit = ()
    let _let'_v7584 =
        async {
            try
                (* run_target_args'
                let v7587 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7588 : string = "std::fs::remove_file(&*$0)"
                let v7589 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v7588 
                let v7590 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v7591 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7592 : string = "$0.map_err(|x| $1(x))"
                let v7593 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v7589, v7590) v7592 
                let _run_target_args'_v7591 = v7593 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7594 : string = "$0.map_err(|x| $1(x))"
                let v7595 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v7589, v7590) v7594 
                let _run_target_args'_v7591 = v7595 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7596 : string = "$0.map_err(|x| $1(x))"
                let v7597 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v7589, v7590) v7596 
                let _run_target_args'_v7591 = v7597 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7598 : Result<unit, string> = match v7589 with Ok x -> Ok x | Error x -> Error (v7590 x)
                let _run_target_args'_v7591 = v7598 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7599 : Result<unit, string> = match v7589 with Ok x -> Ok x | Error x -> Error (v7590 x)
                let _run_target_args'_v7591 = v7599 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7600 : Result<unit, string> = match v7589 with Ok x -> Ok x | Error x -> Error (v7590 x)
                let _run_target_args'_v7591 = v7600 
                #endif
#else
                let v7601 : Result<unit, string> = match v7589 with Ok x -> Ok x | Error x -> Error (v7590 x)
                let _run_target_args'_v7591 = v7601 
                #endif
                let v7602 : Result<unit, string> = _run_target_args'_v7591 
                let v7605 : (unit -> US9) = method45()
                let v7606 : (string -> US9) = method46()
                let v7607 : US9 = match v7602 with Ok () -> v7605 () | Error x -> v7606 x
                match v7607 with
                | US9_1(v7608) -> (* Error *)
                    let v7609 : unit = ()
                    let v7610 : (unit -> unit) = closure25(v7608)
                    let v7611 : unit = (fun () -> v7610 (); v7609) ()
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
                let v7651 : (string -> unit) = System.IO.File.Delete
                v7651 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v7717 : exn = ex
                let v7718 : int64 = v1 % 100L
                let v7719 : bool = v7718 = 0L
                if v7719 then
                    let v7720 : unit = ()
                    let v7721 : (unit -> unit) = closure26(v0, v7717)
                    let v7722 : unit = (fun () -> v7721 (); v7720) ()
                    ()
                (* run_target_args'
                let v7788 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7789 : (int32 -> Async<unit>) = Async.Sleep
                let v7790 : Async<unit> = v7789 10
                let _run_target_args'_v7788 = v7790 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7791 : (int32 -> Async<unit>) = Async.Sleep
                let v7792 : Async<unit> = v7791 10
                let _run_target_args'_v7788 = v7792 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7793 : (int32 -> Async<unit>) = Async.Sleep
                let v7794 : Async<unit> = v7793 10
                let _run_target_args'_v7788 = v7794 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7795 : (int32 -> Async<unit>) = Async.Sleep
                let v7796 : Async<unit> = v7795 10
                let _run_target_args'_v7788 = v7796 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7797 : (int32 -> Async<unit>) = Async.Sleep
                let v7798 : Async<unit> = v7797 10
                let _run_target_args'_v7788 = v7798 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7799 : (int32 -> Async<unit>) = Async.Sleep
                let v7800 : Async<unit> = v7799 10
                let _run_target_args'_v7788 = v7800 
                #endif
#else
                let v7801 : (int32 -> Async<unit>) = Async.Sleep
                let v7802 : Async<unit> = v7801 10
                let _run_target_args'_v7788 = v7802 
                #endif
                let v7803 : Async<unit> = _run_target_args'_v7788 
                do! v7803 
                let v7806 : int64 = v1 + 1L
                let v7807 : Async<int64> = method41(v0, v7806)
                return! v7807 
                (* indent
                ()
            indent *)
            (* try_unit
            let v7899 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v10107 : Async<int64> = _let'_v7584 
    let _run_target_args'_v2 = v10107 
    #endif
    let v10108 : Async<int64> = _run_target_args'_v2 
    v10108
and method41 (v0 : string, v1 : int64) : Async<int64> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v2 = v18 
    #endif
#else
    let v21 : Async<int64> = method42(v0, v1)
    let _run_target_args'_v2 = v21 
    #endif
    let v22 : Async<int64> = _run_target_args'_v2 
    v22
and method40 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method41(v0, v1)
and closure21 () (v0 : string) : Async<int64> =
    method40(v0)
and method56 (v0 : string, v1 : string) : unit =
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
and method58 (v0 : string, v1 : string, v2 : string) : string =
    let v3 : string = method18()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v4, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v14 : string = "old_path"
    let v15 : string = $"{v14}"
    let v18 : unit = ()
    let v19 : (unit -> unit) = closure6(v4, v15)
    let v20 : unit = (fun () -> v19 (); v18) ()
    let v23 : string = " = "
    let v24 : string = $"{v23}"
    let v27 : unit = ()
    let v28 : (unit -> unit) = closure6(v4, v24)
    let v29 : unit = (fun () -> v28 (); v27) ()
    let v32 : string = $"{v0}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure6(v4, v32)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v40 : string = "; "
    let v41 : string = $"{v40}"
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure6(v4, v41)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v49 : string = "new_path"
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v58 : string = $"{v23}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v4, v58)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v66 : string = $"{v1}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure6(v4, v66)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v74 : string = $"{v40}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = "ex"
    let v83 : string = $"{v82}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure6(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v91 : string = $"{v23}"
    let v94 : unit = ()
    let v95 : (unit -> unit) = closure6(v4, v91)
    let v96 : unit = (fun () -> v95 (); v94) ()
    let v99 : string = $"{v2}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure6(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v107 : string = " }"
    let v108 : string = $"{v107}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v116 : string = v4.l0
    v116
and method57 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string, v10 : string) : string =
    let v11 : string = method58(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v13 : string = "move_file_async"
    let v14 : string = $"{v6} {v7} #{v12} %s{v13} / {v11}"
    method23(v14)
and closure29 (v0 : string, v1 : string, v2 : exn) () : unit =
    let v3 : US0 = US0_3
    let v4 : bool = method11(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v21 : Mut0, v22 : Mut1, v23 : Mut2, v24 : Mut3, v25 : Mut4, v26 : int64 option) = TraceState.trace_state.Value
        let v39 : string = method12(v21, v22, v23, v24, v25, v26)
        let v40 : string = method50()
        let v41 : string = method20(v1)
        let v42 : string = method20(v0)
        (* run_target_args'
        let v43 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v44 : string = $"%A{v2}"
        let _run_target_args'_v43 = v44 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v47 : string = $"%A{v2}"
        let _run_target_args'_v43 = v47 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v50 : string = $"%A{v2}"
        let _run_target_args'_v43 = v50 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v53 : string = $"%A{v2}"
        let _run_target_args'_v43 = v53 
        #endif
#if FABLE_COMPILER_PYTHON
        let v56 : string = $"%A{v2}"
        let _run_target_args'_v43 = v56 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v59 : string = $"%A{v2}"
        let _run_target_args'_v43 = v59 
        #endif
#else
        let v62 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v43 = v62 
        #endif
        let v63 : string = _run_target_args'_v43 
        let v68 : string = method57(v21, v22, v23, v24, v25, v26, v39, v40, v41, v42, v63)
        method24(v68)
and method55 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : unit = ()
    let _let'_v13 =
        async {
            try
                method56(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v16 : exn = ex
                let v17 : int64 = v2 % 100L
                let v18 : bool = v17 = 0L
                if v18 then
                    let v19 : unit = ()
                    let v20 : (unit -> unit) = closure29(v0, v1, v16)
                    let v21 : unit = (fun () -> v20 (); v19) ()
                    ()
                (* run_target_args'
                let v88 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v89 : (int32 -> Async<unit>) = Async.Sleep
                let v90 : Async<unit> = v89 10
                let _run_target_args'_v88 = v90 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v91 : (int32 -> Async<unit>) = Async.Sleep
                let v92 : Async<unit> = v91 10
                let _run_target_args'_v88 = v92 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v93 : (int32 -> Async<unit>) = Async.Sleep
                let v94 : Async<unit> = v93 10
                let _run_target_args'_v88 = v94 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v95 : (int32 -> Async<unit>) = Async.Sleep
                let v96 : Async<unit> = v95 10
                let _run_target_args'_v88 = v96 
                #endif
#if FABLE_COMPILER_PYTHON
                let v97 : (int32 -> Async<unit>) = Async.Sleep
                let v98 : Async<unit> = v97 10
                let _run_target_args'_v88 = v98 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v99 : (int32 -> Async<unit>) = Async.Sleep
                let v100 : Async<unit> = v99 10
                let _run_target_args'_v88 = v100 
                #endif
#else
                let v101 : (int32 -> Async<unit>) = Async.Sleep
                let v102 : Async<unit> = v101 10
                let _run_target_args'_v88 = v102 
                #endif
                let v103 : Async<unit> = _run_target_args'_v88 
                do! v103 
                let v106 : int64 = v2 + 1L
                let v107 : Async<int64> = method54(v0, v1, v106)
                return! v107 
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
    let v1488 : Async<int64> = _let'_v13 
    let _run_target_args'_v3 = v1488 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1489 : unit = ()
    let _let'_v1489 =
        async {
            try
                method56(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v1492 : exn = ex
                let v1493 : int64 = v2 % 100L
                let v1494 : bool = v1493 = 0L
                if v1494 then
                    let v1495 : unit = ()
                    let v1496 : (unit -> unit) = closure29(v0, v1, v1492)
                    let v1497 : unit = (fun () -> v1496 (); v1495) ()
                    ()
                (* run_target_args'
                let v1564 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1565 : (int32 -> Async<unit>) = Async.Sleep
                let v1566 : Async<unit> = v1565 10
                let _run_target_args'_v1564 = v1566 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1567 : (int32 -> Async<unit>) = Async.Sleep
                let v1568 : Async<unit> = v1567 10
                let _run_target_args'_v1564 = v1568 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1569 : (int32 -> Async<unit>) = Async.Sleep
                let v1570 : Async<unit> = v1569 10
                let _run_target_args'_v1564 = v1570 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1571 : (int32 -> Async<unit>) = Async.Sleep
                let v1572 : Async<unit> = v1571 10
                let _run_target_args'_v1564 = v1572 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1573 : (int32 -> Async<unit>) = Async.Sleep
                let v1574 : Async<unit> = v1573 10
                let _run_target_args'_v1564 = v1574 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1575 : (int32 -> Async<unit>) = Async.Sleep
                let v1576 : Async<unit> = v1575 10
                let _run_target_args'_v1564 = v1576 
                #endif
#else
                let v1577 : (int32 -> Async<unit>) = Async.Sleep
                let v1578 : Async<unit> = v1577 10
                let _run_target_args'_v1564 = v1578 
                #endif
                let v1579 : Async<unit> = _run_target_args'_v1564 
                do! v1579 
                let v1582 : int64 = v2 + 1L
                let v1583 : Async<int64> = method54(v0, v1, v1582)
                return! v1583 
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
    let v2964 : Async<int64> = _let'_v1489 
    let _run_target_args'_v3 = v2964 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2965 : unit = ()
    let _let'_v2965 =
        async {
            try
                method56(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v2968 : exn = ex
                let v2969 : int64 = v2 % 100L
                let v2970 : bool = v2969 = 0L
                if v2970 then
                    let v2971 : unit = ()
                    let v2972 : (unit -> unit) = closure29(v0, v1, v2968)
                    let v2973 : unit = (fun () -> v2972 (); v2971) ()
                    ()
                (* run_target_args'
                let v3040 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3041 : (int32 -> Async<unit>) = Async.Sleep
                let v3042 : Async<unit> = v3041 10
                let _run_target_args'_v3040 = v3042 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3043 : (int32 -> Async<unit>) = Async.Sleep
                let v3044 : Async<unit> = v3043 10
                let _run_target_args'_v3040 = v3044 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3045 : (int32 -> Async<unit>) = Async.Sleep
                let v3046 : Async<unit> = v3045 10
                let _run_target_args'_v3040 = v3046 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3047 : (int32 -> Async<unit>) = Async.Sleep
                let v3048 : Async<unit> = v3047 10
                let _run_target_args'_v3040 = v3048 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3049 : (int32 -> Async<unit>) = Async.Sleep
                let v3050 : Async<unit> = v3049 10
                let _run_target_args'_v3040 = v3050 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3051 : (int32 -> Async<unit>) = Async.Sleep
                let v3052 : Async<unit> = v3051 10
                let _run_target_args'_v3040 = v3052 
                #endif
#else
                let v3053 : (int32 -> Async<unit>) = Async.Sleep
                let v3054 : Async<unit> = v3053 10
                let _run_target_args'_v3040 = v3054 
                #endif
                let v3055 : Async<unit> = _run_target_args'_v3040 
                do! v3055 
                let v3058 : int64 = v2 + 1L
                let v3059 : Async<int64> = method54(v0, v1, v3058)
                return! v3059 
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
    let v4440 : Async<int64> = _let'_v2965 
    let _run_target_args'_v3 = v4440 
    #endif
#else
    let v4441 : unit = ()
    let _let'_v4441 =
        async {
            try
                method56(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v4444 : exn = ex
                let v4445 : int64 = v2 % 100L
                let v4446 : bool = v4445 = 0L
                if v4446 then
                    let v4447 : unit = ()
                    let v4448 : (unit -> unit) = closure29(v0, v1, v4444)
                    let v4449 : unit = (fun () -> v4448 (); v4447) ()
                    ()
                (* run_target_args'
                let v4516 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4517 : (int32 -> Async<unit>) = Async.Sleep
                let v4518 : Async<unit> = v4517 10
                let _run_target_args'_v4516 = v4518 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4519 : (int32 -> Async<unit>) = Async.Sleep
                let v4520 : Async<unit> = v4519 10
                let _run_target_args'_v4516 = v4520 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4521 : (int32 -> Async<unit>) = Async.Sleep
                let v4522 : Async<unit> = v4521 10
                let _run_target_args'_v4516 = v4522 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4523 : (int32 -> Async<unit>) = Async.Sleep
                let v4524 : Async<unit> = v4523 10
                let _run_target_args'_v4516 = v4524 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4525 : (int32 -> Async<unit>) = Async.Sleep
                let v4526 : Async<unit> = v4525 10
                let _run_target_args'_v4516 = v4526 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4527 : (int32 -> Async<unit>) = Async.Sleep
                let v4528 : Async<unit> = v4527 10
                let _run_target_args'_v4516 = v4528 
                #endif
#else
                let v4529 : (int32 -> Async<unit>) = Async.Sleep
                let v4530 : Async<unit> = v4529 10
                let _run_target_args'_v4516 = v4530 
                #endif
                let v4531 : Async<unit> = _run_target_args'_v4516 
                do! v4531 
                let v4534 : int64 = v2 + 1L
                let v4535 : Async<int64> = method54(v0, v1, v4534)
                return! v4535 
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
    let v5916 : Async<int64> = _let'_v4441 
    let _run_target_args'_v3 = v5916 
    #endif
    let v5917 : Async<int64> = _run_target_args'_v3 
    v5917
and method54 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v16 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v16 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v19 : Async<int64> = null |> unbox<Async<int64>>
    let _run_target_args'_v3 = v19 
    #endif
#else
    let v22 : Async<int64> = method55(v0, v1, v2)
    let _run_target_args'_v3 = v22 
    #endif
    let v23 : Async<int64> = _run_target_args'_v3 
    v23
and method53 (v0 : string, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method54(v0, v1, v2)
and closure28 (v0 : string) (v1 : string) : Async<int64> =
    method53(v0, v1)
and closure27 () (v0 : string) : (string -> Async<int64>) =
    closure28(v0)
and closure31 () (v0 : int64) : US10 =
    US10_0(v0)
and method65 () : (int64 -> US10) =
    closure31()
and closure32 () (v0 : exn) : US10 =
    US10_1(v0)
and method66 () : (exn -> US10) =
    closure32()
and method64 (v0 : Async<Choice<int64, exn>>) : Async<US10> =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : Async<US10> = null |> unbox<Async<US10>>
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : Async<US10> = null |> unbox<Async<US10>>
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : Async<US10> = null |> unbox<Async<US10>>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : unit = ()
    let _let'_v11 =
        async {
            let! v0 = v0 
            let v14 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v15 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v16 : US10 = null |> unbox<US10>
            let _run_target_args'_v15 = v16 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v19 : US10 = null |> unbox<US10>
            let _run_target_args'_v15 = v19 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v22 : US10 = null |> unbox<US10>
            let _run_target_args'_v15 = v22 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v25 : US10 = null |> unbox<US10>
            let _run_target_args'_v15 = v25 
            #endif
#if FABLE_COMPILER_PYTHON
            let v28 : US10 = null |> unbox<US10>
            let _run_target_args'_v15 = v28 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v31 : (int64 -> US10) = method65()
            let v32 : (exn -> US10) = method66()
            let v33 : US10 = match v14 with Choice1Of2 x -> v31 x | Choice2Of2 x -> v32 x
            let _run_target_args'_v15 = v33 
            #endif
#else
            let v34 : (int64 -> US10) = method65()
            let v35 : (exn -> US10) = method66()
            let v36 : US10 = match v14 with Choice1Of2 x -> v34 x | Choice2Of2 x -> v35 x
            let _run_target_args'_v15 = v36 
            #endif
            let v37 : US10 = _run_target_args'_v15 
            return v37 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v238 : Async<US10> = _let'_v11 
    let _run_target_args'_v1 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v239 : unit = ()
    let _let'_v239 =
        async {
            let! v0 = v0 
            let v242 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v243 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v244 : US10 = null |> unbox<US10>
            let _run_target_args'_v243 = v244 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v247 : US10 = null |> unbox<US10>
            let _run_target_args'_v243 = v247 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v250 : US10 = null |> unbox<US10>
            let _run_target_args'_v243 = v250 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v253 : US10 = null |> unbox<US10>
            let _run_target_args'_v243 = v253 
            #endif
#if FABLE_COMPILER_PYTHON
            let v256 : US10 = null |> unbox<US10>
            let _run_target_args'_v243 = v256 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v259 : (int64 -> US10) = method65()
            let v260 : (exn -> US10) = method66()
            let v261 : US10 = match v242 with Choice1Of2 x -> v259 x | Choice2Of2 x -> v260 x
            let _run_target_args'_v243 = v261 
            #endif
#else
            let v262 : (int64 -> US10) = method65()
            let v263 : (exn -> US10) = method66()
            let v264 : US10 = match v242 with Choice1Of2 x -> v262 x | Choice2Of2 x -> v263 x
            let _run_target_args'_v243 = v264 
            #endif
            let v265 : US10 = _run_target_args'_v243 
            return v265 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v466 : Async<US10> = _let'_v239 
    let _run_target_args'_v1 = v466 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v467 : unit = ()
    let _let'_v467 =
        async {
            let! v0 = v0 
            let v470 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v471 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v472 : US10 = null |> unbox<US10>
            let _run_target_args'_v471 = v472 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v475 : US10 = null |> unbox<US10>
            let _run_target_args'_v471 = v475 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v478 : US10 = null |> unbox<US10>
            let _run_target_args'_v471 = v478 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v481 : US10 = null |> unbox<US10>
            let _run_target_args'_v471 = v481 
            #endif
#if FABLE_COMPILER_PYTHON
            let v484 : US10 = null |> unbox<US10>
            let _run_target_args'_v471 = v484 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v487 : (int64 -> US10) = method65()
            let v488 : (exn -> US10) = method66()
            let v489 : US10 = match v470 with Choice1Of2 x -> v487 x | Choice2Of2 x -> v488 x
            let _run_target_args'_v471 = v489 
            #endif
#else
            let v490 : (int64 -> US10) = method65()
            let v491 : (exn -> US10) = method66()
            let v492 : US10 = match v470 with Choice1Of2 x -> v490 x | Choice2Of2 x -> v491 x
            let _run_target_args'_v471 = v492 
            #endif
            let v493 : US10 = _run_target_args'_v471 
            return v493 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v694 : Async<US10> = _let'_v467 
    let _run_target_args'_v1 = v694 
    #endif
#else
    let v695 : unit = ()
    let _let'_v695 =
        async {
            let! v0 = v0 
            let v698 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v699 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v700 : US10 = null |> unbox<US10>
            let _run_target_args'_v699 = v700 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v703 : US10 = null |> unbox<US10>
            let _run_target_args'_v699 = v703 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v706 : US10 = null |> unbox<US10>
            let _run_target_args'_v699 = v706 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v709 : US10 = null |> unbox<US10>
            let _run_target_args'_v699 = v709 
            #endif
#if FABLE_COMPILER_PYTHON
            let v712 : US10 = null |> unbox<US10>
            let _run_target_args'_v699 = v712 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v715 : (int64 -> US10) = method65()
            let v716 : (exn -> US10) = method66()
            let v717 : US10 = match v698 with Choice1Of2 x -> v715 x | Choice2Of2 x -> v716 x
            let _run_target_args'_v699 = v717 
            #endif
#else
            let v718 : (int64 -> US10) = method65()
            let v719 : (exn -> US10) = method66()
            let v720 : US10 = match v698 with Choice1Of2 x -> v718 x | Choice2Of2 x -> v719 x
            let _run_target_args'_v699 = v720 
            #endif
            let v721 : US10 = _run_target_args'_v699 
            return v721 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v922 : Async<US10> = _let'_v695 
    let _run_target_args'_v1 = v922 
    #endif
    let v923 : Async<US10> = _run_target_args'_v1 
    v923
and method67 (v0 : Async<US10>) : Async<US11> =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : unit = ()
    let _let'_v11 =
        async {
            let! v0 = v0 
            let v14 : US10 = v0 
            let v20 : US11 =
                match v14 with
                | US10_0(v15) -> (* C1of2 *)
                    US11_0(v15)
                | US10_1(v17) -> (* C2of2 *)
                    US11_1(v17)
            return v20 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v70 : Async<US11> = _let'_v11 
    let _run_target_args'_v1 = v70 
    #endif
#if FABLE_COMPILER_PYTHON
    let v71 : unit = ()
    let _let'_v71 =
        async {
            let! v0 = v0 
            let v74 : US10 = v0 
            let v80 : US11 =
                match v74 with
                | US10_0(v75) -> (* C1of2 *)
                    US11_0(v75)
                | US10_1(v77) -> (* C2of2 *)
                    US11_1(v77)
            return v80 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v130 : Async<US11> = _let'_v71 
    let _run_target_args'_v1 = v130 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v131 : unit = ()
    let _let'_v131 =
        async {
            let! v0 = v0 
            let v134 : US10 = v0 
            let v140 : US11 =
                match v134 with
                | US10_0(v135) -> (* C1of2 *)
                    US11_0(v135)
                | US10_1(v137) -> (* C2of2 *)
                    US11_1(v137)
            return v140 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v190 : Async<US11> = _let'_v131 
    let _run_target_args'_v1 = v190 
    #endif
#else
    let v191 : unit = ()
    let _let'_v191 =
        async {
            let! v0 = v0 
            let v194 : US10 = v0 
            let v200 : US11 =
                match v194 with
                | US10_0(v195) -> (* C1of2 *)
                    US11_0(v195)
                | US10_1(v197) -> (* C2of2 *)
                    US11_1(v197)
            return v200 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v250 : Async<US11> = _let'_v191 
    let _run_target_args'_v1 = v250 
    #endif
    let v251 : Async<US11> = _run_target_args'_v1 
    v251
and method69 () : string =
    
    
    
    
    
    let v0 : string = "Verbose"
    let v1 : (unit -> string) = v0.ToLower
    let v2 : string = v1 ()
    let v5 : char = v2.[int 0]
    let v6 : string = method17(v5)
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "inline_colorization::color_bright_black"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v8 
    (* run_target_args'
    let v10 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v11 : string = "&*$0"
    let v12 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v11 
    let _run_target_args'_v10 = v12 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v13 : string = "&*$0"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v13 
    let _run_target_args'_v10 = v14 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = "&*$0"
    let v16 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v15 
    let _run_target_args'_v10 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v17 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v17 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v23 
    #endif
#else
    let v26 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v10 = v26 
    #endif
    let v29 : Ref<Str> = _run_target_args'_v10 
    let v34 : string = "inline_colorization::color_reset"
    let v35 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v34 
    let v36 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v37 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v9, v29, v35) v36 
    let v38 : string = "fable_library_rust::String_::fromString($0)"
    let v39 : string = Fable.Core.RustInterop.emitRustExpr v37 v38 
    let _run_target_args'_v7 = v39 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v40 : string = "inline_colorization::color_bright_black"
    let v41 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v40 
    (* run_target_args'
    let v42 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v43 : string = "&*$0"
    let v44 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v43 
    let _run_target_args'_v42 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "&*$0"
    let v46 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v45 
    let _run_target_args'_v42 = v46 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v47 : string = "&*$0"
    let v48 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v47 
    let _run_target_args'_v42 = v48 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v49 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v52 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v52 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v55 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v55 
    #endif
#else
    let v58 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v42 = v58 
    #endif
    let v61 : Ref<Str> = _run_target_args'_v42 
    let v66 : string = "inline_colorization::color_reset"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v66 
    let v68 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v69 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v41, v61, v67) v68 
    let v70 : string = "fable_library_rust::String_::fromString($0)"
    let v71 : string = Fable.Core.RustInterop.emitRustExpr v69 v70 
    let _run_target_args'_v7 = v71 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v72 : string = "inline_colorization::color_bright_black"
    let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v72 
    (* run_target_args'
    let v74 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v75 : string = "&*$0"
    let v76 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v75 
    let _run_target_args'_v74 = v76 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v77 : string = "&*$0"
    let v78 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v77 
    let _run_target_args'_v74 = v78 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v79 : string = "&*$0"
    let v80 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v6 v79 
    let _run_target_args'_v74 = v80 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v81 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v81 
    #endif
#if FABLE_COMPILER_PYTHON
    let v84 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v84 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v87 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v87 
    #endif
#else
    let v90 : Ref<Str> = v6 |> unbox<Ref<Str>>
    let _run_target_args'_v74 = v90 
    #endif
    let v93 : Ref<Str> = _run_target_args'_v74 
    let v98 : string = "inline_colorization::color_reset"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v98 
    let v100 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v101 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v73, v93, v99) v100 
    let v102 : string = "fable_library_rust::String_::fromString($0)"
    let v103 : string = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let _run_target_args'_v7 = v103 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v104 : string = "\u001b[90m"
    let v105 : string = method19()
    let v106 : string = v104 + v6 
    let v107 : string = v106 + v105 
    let _run_target_args'_v7 = v107 
    #endif
#if FABLE_COMPILER_PYTHON
    let v108 : string = "\u001b[90m"
    let v109 : string = method19()
    let v110 : string = v108 + v6 
    let v111 : string = v110 + v109 
    let _run_target_args'_v7 = v111 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v112 : string = "\u001b[90m"
    let v113 : string = method19()
    let v114 : string = v112 + v6 
    let v115 : string = v114 + v113 
    let _run_target_args'_v7 = v115 
    #endif
#else
    let v116 : string = "\u001b[90m"
    let v117 : string = method19()
    let v118 : string = v116 + v6 
    let v119 : string = v118 + v117 
    let _run_target_args'_v7 = v119 
    #endif
    let v120 : string = _run_target_args'_v7 
    v120
and method71 (v0 : int32) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v3 : string = "{ "
    let v4 : string = $"{v3}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure6(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = "timeout"
    let v13 : string = $"{v12}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6(v2, v13)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v21 : string = " = "
    let v22 : string = $"{v21}"
    let v25 : unit = ()
    let v26 : (unit -> unit) = closure6(v2, v22)
    let v27 : unit = (fun () -> v26 (); v25) ()
    let v30 : string = $"{v0}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v2, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v38 : string = " }"
    let v39 : string = $"{v38}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v2, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : string = v2.l0
    v47
and method70 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method71(v8)
    let v10 : int64 = v0.l0
    let v11 : string = "async.run_with_timeout_async"
    let v12 : string = $"{v6} {v7} #{v10} %s{v11} / {v9}"
    method23(v12)
and closure33 (v0 : int32) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method11(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v19 : Mut0, v20 : Mut1, v21 : Mut2, v22 : Mut3, v23 : Mut4, v24 : int64 option) = TraceState.trace_state.Value
        let v37 : string = method12(v19, v20, v21, v22, v23, v24)
        let v38 : string = method69()
        let v39 : string = method70(v19, v20, v21, v22, v23, v24, v37, v38, v0)
        method24(v39)
and method73 (v0 : int32, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "timeout"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "ex"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v65 : string = $"{v1}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v3, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v73 : string = " }"
    let v74 : string = $"{v73}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v3, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = v3.l0
    v82
and method72 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method73(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "async.run_with_timeout_async**"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
and closure34 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method47()
        (* run_target_args'
        let v40 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v41 : string = $"%A{v1}"
        let _run_target_args'_v40 = v41 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v44 : string = $"%A{v1}"
        let _run_target_args'_v40 = v44 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v47 : string = $"%A{v1}"
        let _run_target_args'_v40 = v47 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v50 : string = $"%A{v1}"
        let _run_target_args'_v40 = v50 
        #endif
#if FABLE_COMPILER_PYTHON
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v40 = v53 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v56 : string = $"%A{v1}"
        let _run_target_args'_v40 = v56 
        #endif
#else
        let v59 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v40 = v59 
        #endif
        let v60 : string = _run_target_args'_v40 
        let v65 : string = method72(v20, v21, v22, v23, v24, v25, v38, v39, v0, v60)
        method24(v65)
and method68 (v0 : int32, v1 : Async<US11>) : Async<US2> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            let! v1 = v1 
            let v15 : US11 = v1 
            let v139 : US2 =
                match v15 with
                | US11_1(v18) -> (* Error *)
                    let v19 : string = $"%A{v18}"
                    let v22 : string = "System.TimeoutException"
                    let v23 : bool = v19.Contains v22 
                    if v23 then
                        let v26 : unit = ()
                        let v27 : (unit -> unit) = closure33(v0)
                        let v28 : unit = (fun () -> v27 (); v26) ()
                        US2_1
                    else
                        let v69 : unit = ()
                        let v70 : (unit -> unit) = closure34(v0, v18)
                        let v71 : unit = (fun () -> v70 (); v69) ()
                        US2_1
                | US11_0(v16) -> (* Ok *)
                    US2_0(v16)
            return v139 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1015 : Async<US2> = _let'_v12 
    let _run_target_args'_v2 = v1015 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1016 : unit = ()
    let _let'_v1016 =
        async {
            let! v1 = v1 
            let v1019 : US11 = v1 
            let v1143 : US2 =
                match v1019 with
                | US11_1(v1022) -> (* Error *)
                    let v1023 : string = $"%A{v1022}"
                    let v1026 : string = "System.TimeoutException"
                    let v1027 : bool = v1023.Contains v1026 
                    if v1027 then
                        let v1030 : unit = ()
                        let v1031 : (unit -> unit) = closure33(v0)
                        let v1032 : unit = (fun () -> v1031 (); v1030) ()
                        US2_1
                    else
                        let v1073 : unit = ()
                        let v1074 : (unit -> unit) = closure34(v0, v1022)
                        let v1075 : unit = (fun () -> v1074 (); v1073) ()
                        US2_1
                | US11_0(v1020) -> (* Ok *)
                    US2_0(v1020)
            return v1143 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2019 : Async<US2> = _let'_v1016 
    let _run_target_args'_v2 = v2019 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2020 : unit = ()
    let _let'_v2020 =
        async {
            let! v1 = v1 
            let v2023 : US11 = v1 
            let v2147 : US2 =
                match v2023 with
                | US11_1(v2026) -> (* Error *)
                    let v2027 : string = $"%A{v2026}"
                    let v2030 : string = "System.TimeoutException"
                    let v2031 : bool = v2027.Contains v2030 
                    if v2031 then
                        let v2034 : unit = ()
                        let v2035 : (unit -> unit) = closure33(v0)
                        let v2036 : unit = (fun () -> v2035 (); v2034) ()
                        US2_1
                    else
                        let v2077 : unit = ()
                        let v2078 : (unit -> unit) = closure34(v0, v2026)
                        let v2079 : unit = (fun () -> v2078 (); v2077) ()
                        US2_1
                | US11_0(v2024) -> (* Ok *)
                    US2_0(v2024)
            return v2147 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3023 : Async<US2> = _let'_v2020 
    let _run_target_args'_v2 = v3023 
    #endif
#else
    let v3024 : unit = ()
    let _let'_v3024 =
        async {
            let! v1 = v1 
            let v3027 : US11 = v1 
            let v3151 : US2 =
                match v3027 with
                | US11_1(v3030) -> (* Error *)
                    let v3031 : string = $"%A{v3030}"
                    let v3034 : string = "System.TimeoutException"
                    let v3035 : bool = v3031.Contains v3034 
                    if v3035 then
                        let v3038 : unit = ()
                        let v3039 : (unit -> unit) = closure33(v0)
                        let v3040 : unit = (fun () -> v3039 (); v3038) ()
                        US2_1
                    else
                        let v3081 : unit = ()
                        let v3082 : (unit -> unit) = closure34(v0, v3030)
                        let v3083 : unit = (fun () -> v3082 (); v3081) ()
                        US2_1
                | US11_0(v3028) -> (* Ok *)
                    US2_0(v3028)
            return v3151 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4027 : Async<US2> = _let'_v3024 
    let _run_target_args'_v2 = v4027 
    #endif
    let v4028 : Async<US2> = _run_target_args'_v2 
    v4028
and method63 (v0 : Async<int64>, v1 : int32) : Async<US2> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US2> = null |> unbox<Async<US2>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            (* run_target_args'
            let v15 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v16 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v15 = v16 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v19 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v15 = v19 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v22 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v15 = v22 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v25 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v15 = v25 
            #endif
#if FABLE_COMPILER_PYTHON
            let v26 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v15 = v26 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v27 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v15 = v27 
            #endif
#else
            let v28 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v15 = v28 
            #endif
            let v29 : Async<Async<int64>> = _run_target_args'_v15 
            let! v29 = v29 
            let v34 : Async<int64> = v29 
            (* run_target_args'
            let v35 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v36 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v35 = v36 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v39 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v35 = v39 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v42 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v35 = v42 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v45 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v46 : Async<Choice<int64, exn>> = v45 v34
            let _run_target_args'_v35 = v46 
            #endif
#if FABLE_COMPILER_PYTHON
            let v47 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v48 : Async<Choice<int64, exn>> = v47 v34
            let _run_target_args'_v35 = v48 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v49 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v50 : Async<Choice<int64, exn>> = v49 v34
            let _run_target_args'_v35 = v50 
            #endif
#else
            let v51 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v52 : Async<Choice<int64, exn>> = v51 v34
            let _run_target_args'_v35 = v52 
            #endif
            let v53 : Async<Choice<int64, exn>> = _run_target_args'_v35 
            let v58 : Async<US10> = method64(v53)
            let v59 : Async<US11> = method67(v58)
            let v60 : Async<US2> = method68(v1, v59)
            return! v60 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v383 : Async<US2> = _let'_v12 
    let _run_target_args'_v2 = v383 
    #endif
#if FABLE_COMPILER_PYTHON
    let v384 : unit = ()
    let _let'_v384 =
        async {
            (* run_target_args'
            let v387 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v388 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v387 = v388 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v391 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v387 = v391 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v394 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v387 = v394 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v397 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v387 = v397 
            #endif
#if FABLE_COMPILER_PYTHON
            let v398 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v387 = v398 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v399 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v387 = v399 
            #endif
#else
            let v400 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v387 = v400 
            #endif
            let v401 : Async<Async<int64>> = _run_target_args'_v387 
            let! v401 = v401 
            let v406 : Async<int64> = v401 
            (* run_target_args'
            let v407 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v408 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v407 = v408 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v411 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v407 = v411 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v414 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v407 = v414 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v417 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v418 : Async<Choice<int64, exn>> = v417 v406
            let _run_target_args'_v407 = v418 
            #endif
#if FABLE_COMPILER_PYTHON
            let v419 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v420 : Async<Choice<int64, exn>> = v419 v406
            let _run_target_args'_v407 = v420 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v421 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v422 : Async<Choice<int64, exn>> = v421 v406
            let _run_target_args'_v407 = v422 
            #endif
#else
            let v423 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v424 : Async<Choice<int64, exn>> = v423 v406
            let _run_target_args'_v407 = v424 
            #endif
            let v425 : Async<Choice<int64, exn>> = _run_target_args'_v407 
            let v430 : Async<US10> = method64(v425)
            let v431 : Async<US11> = method67(v430)
            let v432 : Async<US2> = method68(v1, v431)
            return! v432 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v755 : Async<US2> = _let'_v384 
    let _run_target_args'_v2 = v755 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v756 : unit = ()
    let _let'_v756 =
        async {
            (* run_target_args'
            let v759 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v760 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v759 = v760 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v763 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v759 = v763 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v766 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v759 = v766 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v769 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v759 = v769 
            #endif
#if FABLE_COMPILER_PYTHON
            let v770 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v759 = v770 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v771 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v759 = v771 
            #endif
#else
            let v772 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v759 = v772 
            #endif
            let v773 : Async<Async<int64>> = _run_target_args'_v759 
            let! v773 = v773 
            let v778 : Async<int64> = v773 
            (* run_target_args'
            let v779 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v780 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v779 = v780 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v783 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v779 = v783 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v786 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v779 = v786 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v789 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v790 : Async<Choice<int64, exn>> = v789 v778
            let _run_target_args'_v779 = v790 
            #endif
#if FABLE_COMPILER_PYTHON
            let v791 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v792 : Async<Choice<int64, exn>> = v791 v778
            let _run_target_args'_v779 = v792 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v793 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v794 : Async<Choice<int64, exn>> = v793 v778
            let _run_target_args'_v779 = v794 
            #endif
#else
            let v795 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v796 : Async<Choice<int64, exn>> = v795 v778
            let _run_target_args'_v779 = v796 
            #endif
            let v797 : Async<Choice<int64, exn>> = _run_target_args'_v779 
            let v802 : Async<US10> = method64(v797)
            let v803 : Async<US11> = method67(v802)
            let v804 : Async<US2> = method68(v1, v803)
            return! v804 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1127 : Async<US2> = _let'_v756 
    let _run_target_args'_v2 = v1127 
    #endif
#else
    let v1128 : unit = ()
    let _let'_v1128 =
        async {
            (* run_target_args'
            let v1131 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1132 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1131 = v1132 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1135 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1131 = v1135 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1138 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v1131 = v1138 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1141 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1131 = v1141 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1142 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1131 = v1142 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1143 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1131 = v1143 
            #endif
#else
            let v1144 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v1131 = v1144 
            #endif
            let v1145 : Async<Async<int64>> = _run_target_args'_v1131 
            let! v1145 = v1145 
            let v1150 : Async<int64> = v1145 
            (* run_target_args'
            let v1151 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1152 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1151 = v1152 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1155 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1151 = v1155 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1158 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v1151 = v1158 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1161 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1162 : Async<Choice<int64, exn>> = v1161 v1150
            let _run_target_args'_v1151 = v1162 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1163 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1164 : Async<Choice<int64, exn>> = v1163 v1150
            let _run_target_args'_v1151 = v1164 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1165 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1166 : Async<Choice<int64, exn>> = v1165 v1150
            let _run_target_args'_v1151 = v1166 
            #endif
#else
            let v1167 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1168 : Async<Choice<int64, exn>> = v1167 v1150
            let _run_target_args'_v1151 = v1168 
            #endif
            let v1169 : Async<Choice<int64, exn>> = _run_target_args'_v1151 
            let v1174 : Async<US10> = method64(v1169)
            let v1175 : Async<US11> = method67(v1174)
            let v1176 : Async<US2> = method68(v1, v1175)
            return! v1176 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1499 : Async<US2> = _let'_v1128 
    let _run_target_args'_v2 = v1499 
    #endif
    let v1500 : Async<US2> = _run_target_args'_v2 
    v1500
and method62 (v0 : int32, v1 : Async<int64>) : Async<US2> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v4 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v5 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v6 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_PYTHON
    let v7 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v7 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v8 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v8 
    #endif
#else
    let v9 : Async<US2> = method63(v1, v0)
    let _run_target_args'_v2 = v9 
    #endif
    let v10 : Async<US2> = _run_target_args'_v2 
    v10
and method74 (v0 : Async<string>) : Async<string option> =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : unit = ()
    let _let'_v11 =
        async {
            let! v0 = v0 
            let v14 : string = v0 
            let v15 : string option = Some v14 
            return v15 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v46 : Async<string option> = _let'_v11 
    let _run_target_args'_v1 = v46 
    #endif
#if FABLE_COMPILER_PYTHON
    let v47 : unit = ()
    let _let'_v47 =
        async {
            let! v0 = v0 
            let v50 : string = v0 
            let v51 : string option = Some v50 
            return v51 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v82 : Async<string option> = _let'_v47 
    let _run_target_args'_v1 = v82 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v83 : unit = ()
    let _let'_v83 =
        async {
            let! v0 = v0 
            let v86 : string = v0 
            let v87 : string option = Some v86 
            return v87 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v118 : Async<string option> = _let'_v83 
    let _run_target_args'_v1 = v118 
    #endif
#else
    let v119 : unit = ()
    let _let'_v119 =
        async {
            let! v0 = v0 
            let v122 : string = v0 
            let v123 : string option = Some v122 
            return v123 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v154 : Async<string option> = _let'_v119 
    let _run_target_args'_v1 = v154 
    #endif
    let v155 : Async<string option> = _run_target_args'_v1 
    v155
and method76 (v0 : int64, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "retry"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "ex"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v65 : string = $"{v1}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v3, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v73 : string = " }"
    let v74 : string = $"{v73}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v3, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = v3.l0
    v82
and method75 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string) : string =
    let v10 : string = method76(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "file_system.read_all_text_retry_async"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
and closure35 (v0 : int64, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method16()
        (* run_target_args'
        let v40 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v41 : string = $"%A{v1}"
        let _run_target_args'_v40 = v41 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v44 : string = $"%A{v1}"
        let _run_target_args'_v40 = v44 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v47 : string = $"%A{v1}"
        let _run_target_args'_v40 = v47 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v50 : string = $"%A{v1}"
        let _run_target_args'_v40 = v50 
        #endif
#if FABLE_COMPILER_PYTHON
        let v53 : string = $"%A{v1}"
        let _run_target_args'_v40 = v53 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v56 : string = $"%A{v1}"
        let _run_target_args'_v40 = v56 
        #endif
#else
        let v59 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v40 = v59 
        #endif
        let v60 : string = _run_target_args'_v40 
        let v65 : string = method75(v20, v21, v22, v23, v24, v25, v38, v39, v0, v60)
        method24(v65)
and method61 (v0 : string, v1 : int64) : Async<string option> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<string option> = null |> unbox<Async<string option>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : unit = ()
    let _let'_v12 =
        async {
            try
                let v15 : bool = v1 > 0L
                if v15 then
                    let v16 : Async<int64> = method30(v0)
                    let v17 : int32 = 1000
                    let v18 : Async<US2> = method62(v17, v16)
                    (* run_target_args'
                    let v19 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v20 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v19 = v20 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v23 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v19 = v23 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v26 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v19 = v26 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v29 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v30 : Async<unit> = v29 v18
                    let _run_target_args'_v19 = v30 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v31 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v32 : Async<unit> = v31 v18
                    let _run_target_args'_v19 = v32 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v33 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v34 : Async<unit> = v33 v18
                    let _run_target_args'_v19 = v34 
                    #endif
#else
                    let v35 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v36 : Async<unit> = v35 v18
                    let _run_target_args'_v19 = v36 
                    #endif
                    let v37 : Async<unit> = _run_target_args'_v19 
                    do! v37 
                    ()
                let v42 : Async<string> = method31(v0)
                let v43 : Async<string option> = method74(v42)
                return! v43 
                (* indent
                ()
            indent *)
            with ex ->
                let v73 : exn = ex
                let v74 : bool = v1 = 0L
                let v75 : bool = v74 <> true
                if v75 then
                    let v76 : unit = ()
                    let v77 : (unit -> unit) = closure35(v1, v73)
                    let v78 : unit = (fun () -> v77 (); v76) ()
                    let v143 : string option = None
                    return v143 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v144 : int64 = v1 + 1L
                    let v145 : Async<string option> = method60(v0, v144)
                    return! v145 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v219 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1671 : Async<string option> = _let'_v12 
    let _run_target_args'_v2 = v1671 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1672 : unit = ()
    let _let'_v1672 =
        async {
            try
                let v1675 : bool = v1 > 0L
                if v1675 then
                    let v1676 : Async<int64> = method30(v0)
                    let v1677 : int32 = 1000
                    let v1678 : Async<US2> = method62(v1677, v1676)
                    (* run_target_args'
                    let v1679 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v1680 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v1679 = v1680 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v1683 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v1679 = v1683 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v1686 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v1679 = v1686 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v1689 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v1690 : Async<unit> = v1689 v1678
                    let _run_target_args'_v1679 = v1690 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v1691 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v1692 : Async<unit> = v1691 v1678
                    let _run_target_args'_v1679 = v1692 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v1693 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v1694 : Async<unit> = v1693 v1678
                    let _run_target_args'_v1679 = v1694 
                    #endif
#else
                    let v1695 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v1696 : Async<unit> = v1695 v1678
                    let _run_target_args'_v1679 = v1696 
                    #endif
                    let v1697 : Async<unit> = _run_target_args'_v1679 
                    do! v1697 
                    ()
                let v1702 : Async<string> = method31(v0)
                let v1703 : Async<string option> = method74(v1702)
                return! v1703 
                (* indent
                ()
            indent *)
            with ex ->
                let v1733 : exn = ex
                let v1734 : bool = v1 = 0L
                let v1735 : bool = v1734 <> true
                if v1735 then
                    let v1736 : unit = ()
                    let v1737 : (unit -> unit) = closure35(v1, v1733)
                    let v1738 : unit = (fun () -> v1737 (); v1736) ()
                    let v1803 : string option = None
                    return v1803 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v1804 : int64 = v1 + 1L
                    let v1805 : Async<string option> = method60(v0, v1804)
                    return! v1805 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v1879 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3331 : Async<string option> = _let'_v1672 
    let _run_target_args'_v2 = v3331 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3332 : unit = ()
    let _let'_v3332 =
        async {
            try
                let v3335 : bool = v1 > 0L
                if v3335 then
                    let v3336 : Async<int64> = method30(v0)
                    let v3337 : int32 = 1000
                    let v3338 : Async<US2> = method62(v3337, v3336)
                    (* run_target_args'
                    let v3339 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v3340 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v3339 = v3340 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v3343 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v3339 = v3343 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v3346 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v3339 = v3346 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v3349 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v3350 : Async<unit> = v3349 v3338
                    let _run_target_args'_v3339 = v3350 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v3351 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v3352 : Async<unit> = v3351 v3338
                    let _run_target_args'_v3339 = v3352 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v3353 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v3354 : Async<unit> = v3353 v3338
                    let _run_target_args'_v3339 = v3354 
                    #endif
#else
                    let v3355 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v3356 : Async<unit> = v3355 v3338
                    let _run_target_args'_v3339 = v3356 
                    #endif
                    let v3357 : Async<unit> = _run_target_args'_v3339 
                    do! v3357 
                    ()
                let v3362 : Async<string> = method31(v0)
                let v3363 : Async<string option> = method74(v3362)
                return! v3363 
                (* indent
                ()
            indent *)
            with ex ->
                let v3393 : exn = ex
                let v3394 : bool = v1 = 0L
                let v3395 : bool = v3394 <> true
                if v3395 then
                    let v3396 : unit = ()
                    let v3397 : (unit -> unit) = closure35(v1, v3393)
                    let v3398 : unit = (fun () -> v3397 (); v3396) ()
                    let v3463 : string option = None
                    return v3463 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v3464 : int64 = v1 + 1L
                    let v3465 : Async<string option> = method60(v0, v3464)
                    return! v3465 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v3539 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4991 : Async<string option> = _let'_v3332 
    let _run_target_args'_v2 = v4991 
    #endif
#else
    let v4992 : unit = ()
    let _let'_v4992 =
        async {
            try
                let v4995 : bool = v1 > 0L
                if v4995 then
                    let v4996 : Async<int64> = method30(v0)
                    let v4997 : int32 = 1000
                    let v4998 : Async<US2> = method62(v4997, v4996)
                    (* run_target_args'
                    let v4999 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v5000 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4999 = v5000 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v5003 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4999 = v5003 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v5006 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4999 = v5006 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v5009 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v5010 : Async<unit> = v5009 v4998
                    let _run_target_args'_v4999 = v5010 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v5011 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v5012 : Async<unit> = v5011 v4998
                    let _run_target_args'_v4999 = v5012 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v5013 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v5014 : Async<unit> = v5013 v4998
                    let _run_target_args'_v4999 = v5014 
                    #endif
#else
                    let v5015 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v5016 : Async<unit> = v5015 v4998
                    let _run_target_args'_v4999 = v5016 
                    #endif
                    let v5017 : Async<unit> = _run_target_args'_v4999 
                    do! v5017 
                    ()
                let v5022 : Async<string> = method31(v0)
                let v5023 : Async<string option> = method74(v5022)
                return! v5023 
                (* indent
                ()
            indent *)
            with ex ->
                let v5053 : exn = ex
                let v5054 : bool = v1 = 0L
                let v5055 : bool = v5054 <> true
                if v5055 then
                    let v5056 : unit = ()
                    let v5057 : (unit -> unit) = closure35(v1, v5053)
                    let v5058 : unit = (fun () -> v5057 (); v5056) ()
                    let v5123 : string option = None
                    return v5123 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v5124 : int64 = v1 + 1L
                    let v5125 : Async<string option> = method60(v0, v5124)
                    return! v5125 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v5199 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6651 : Async<string option> = _let'_v4992 
    let _run_target_args'_v2 = v6651 
    #endif
    let v6652 : Async<string option> = _run_target_args'_v2 
    v6652
and method60 (v0 : string, v1 : int64) : Async<string option> =
    method61(v0, v1)
and method59 (v0 : string) : Async<string option> =
    let v1 : int64 = 0L
    method60(v0, v1)
and closure30 () (v0 : string) : Async<string option> =
    method59(v0)
and closure37 () (v0 : chrono_DateTime<chrono_Utc>) : US12 =
    US12_0(v0)
and method79 () : (chrono_DateTime<chrono_Utc> -> US12) =
    closure37()
and method80 () : string =
    let v0 : string = "hh:mm"
    v0
and method81 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method82 () : string =
    let v0 : string = "hhmm"
    v0
and method78 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : System.DateTime = System.DateTime.UnixEpoch
    let v6 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v7 : System.DateTime = v6 v3
    let v10 : System.DateTimeKind = System.DateTimeKind.Local
    let v11 : System.DateTime = System.DateTime.SpecifyKind (v1, v10)
    let v14 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v15 : System.DateTime = v14 v11
    (* run_target_args'
    let v18 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v19 : (System.DateTime -> int64) = _.Ticks
    let v20 : int64 = v19 v15
    let _run_target_args'_v18 = v20 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v21 : (System.DateTime -> int64) = _.Ticks
    let v22 : int64 = v21 v15
    let _run_target_args'_v18 = v22 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v23 : int64 = null |> unbox<int64>
    let _run_target_args'_v18 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v26 : (System.DateTime -> int64) = _.Ticks
    let v27 : int64 = v26 v15
    let _run_target_args'_v18 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v28 : (System.DateTime -> int64) = _.Ticks
    let v29 : int64 = v28 v15
    let _run_target_args'_v18 = v29 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v30 : (System.DateTime -> int64) = _.Ticks
    let v31 : int64 = v30 v15
    let _run_target_args'_v18 = v31 
    #endif
#else
    let v32 : (System.DateTime -> int64) = _.Ticks
    let v33 : int64 = v32 v15
    let _run_target_args'_v18 = v33 
    #endif
    let v34 : int64 = _run_target_args'_v18 
    (* run_target_args'
    let v51 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v52 : (System.DateTime -> int64) = _.Ticks
    let v53 : int64 = v52 v7
    let _run_target_args'_v51 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : (System.DateTime -> int64) = _.Ticks
    let v55 : int64 = v54 v7
    let _run_target_args'_v51 = v55 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v56 : int64 = null |> unbox<int64>
    let _run_target_args'_v51 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v59 : (System.DateTime -> int64) = _.Ticks
    let v60 : int64 = v59 v7
    let _run_target_args'_v51 = v60 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61 : (System.DateTime -> int64) = _.Ticks
    let v62 : int64 = v61 v7
    let _run_target_args'_v51 = v62 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : (System.DateTime -> int64) = _.Ticks
    let v64 : int64 = v63 v7
    let _run_target_args'_v51 = v64 
    #endif
#else
    let v65 : (System.DateTime -> int64) = _.Ticks
    let v66 : int64 = v65 v7
    let _run_target_args'_v51 = v66 
    #endif
    let v67 : int64 = _run_target_args'_v51 
    let v84 : int64 = v34 |> int64 
    let v87 : int64 = v67 |> int64 
    let v90 : int64 = v84 - v87
    let v91 : int64 = v90 / 10L
    let v92 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v93 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let v94 : (chrono_DateTime<chrono_Utc> -> US12) = method79()
    let v95 : US12 option = v93 |> Option.map v94 
    let v106 : US12 = US12_1
    let v107 : US12 = v95 |> Option.defaultValue v106 
    let v127 : US5 =
        match v107 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v111) -> (* Some *)
            let v112 : string = "$0.naive_utc()"
            let v113 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v111 v112 
            let v114 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v115 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v113 v114 
            let v116 : string = "%Y%m%d-%H%M-%S%f"
            let v117 : string = "r#\"" + v116 + "\"#"
            let v118 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v117 
            let v119 : string = "$0.format($1).to_string()"
            let v120 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v115, v118) v119 
            let v121 : string = "fable_library_rust::String_::fromString($0)"
            let v122 : string = Fable.Core.RustInterop.emitRustExpr v120 v121 
            let v123 : string = $"{v122.[0..17]}-{v122.[18..21]}-{v122.[22]}"
            US5_0(v123)
    let v131 : string =
        match v127 with
        | US5_1 -> (* None *)
            let v129 : string = ""
            v129
        | US5_0(v128) -> (* Some *)
            v128
    (* run_target_args'
    let v132 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v133 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v134 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v133 
    let _run_target_args'_v132 = v134 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v135 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v138 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v138 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v141 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v141 
    #endif
#if FABLE_COMPILER_PYTHON
    let v144 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v132 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v147 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v132 = v147 
    #endif
#else
    let v148 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v132 = v148 
    #endif
    let v149 : System.TimeZoneInfo = _run_target_args'_v132 
    (* run_target_args'
    let v154 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v155 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v156 : (System.DateTime -> int64) = _.Ticks
    let v157 : int64 = v156 v15
    let _run_target_args'_v155 = v157 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v158 : (System.DateTime -> int64) = _.Ticks
    let v159 : int64 = v158 v15
    let _run_target_args'_v155 = v159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v160 : int64 = null |> unbox<int64>
    let _run_target_args'_v155 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v163 : (System.DateTime -> int64) = _.Ticks
    let v164 : int64 = v163 v15
    let _run_target_args'_v155 = v164 
    #endif
#if FABLE_COMPILER_PYTHON
    let v165 : (System.DateTime -> int64) = _.Ticks
    let v166 : int64 = v165 v15
    let _run_target_args'_v155 = v166 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v167 : (System.DateTime -> int64) = _.Ticks
    let v168 : int64 = v167 v15
    let _run_target_args'_v155 = v168 
    #endif
#else
    let v169 : (System.DateTime -> int64) = _.Ticks
    let v170 : int64 = v169 v15
    let _run_target_args'_v155 = v170 
    #endif
    let v171 : int64 = _run_target_args'_v155 
    let v188 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v189 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v15, v171) v188 
    let v190 : System.TimeSpan = v189 |> System.TimeSpan 
    let _run_target_args'_v154 = v190 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : (System.DateTime -> int64) = _.Ticks
    let v195 : int64 = v194 v15
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : (System.DateTime -> int64) = _.Ticks
    let v197 : int64 = v196 v15
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : int64 = null |> unbox<int64>
    let _run_target_args'_v193 = v198 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : (System.DateTime -> int64) = _.Ticks
    let v202 : int64 = v201 v15
    let _run_target_args'_v193 = v202 
    #endif
#if FABLE_COMPILER_PYTHON
    let v203 : (System.DateTime -> int64) = _.Ticks
    let v204 : int64 = v203 v15
    let _run_target_args'_v193 = v204 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v205 : (System.DateTime -> int64) = _.Ticks
    let v206 : int64 = v205 v15
    let _run_target_args'_v193 = v206 
    #endif
#else
    let v207 : (System.DateTime -> int64) = _.Ticks
    let v208 : int64 = v207 v15
    let _run_target_args'_v193 = v208 
    #endif
    let v209 : int64 = _run_target_args'_v193 
    let v226 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v227 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v15, v209) v226 
    let v228 : System.TimeSpan = v227 |> System.TimeSpan 
    let _run_target_args'_v154 = v228 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v231 : US3 = US3_2
    let v232 : US4 = US4_2(v231)
    let v233 : string = $"date_time.get_utc_offset / target: {v232}"
    let v234 : System.TimeSpan = failwith<System.TimeSpan> v233
    let _run_target_args'_v154 = v234 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v237 : US3 = US3_0
    let v238 : US4 = US4_3(v237)
    let v239 : string = $"date_time.get_utc_offset / target: {v238}"
    let v240 : System.TimeSpan = failwith<System.TimeSpan> v239
    let _run_target_args'_v154 = v240 
    #endif
#if FABLE_COMPILER_PYTHON
    let v243 : US3 = US3_0
    let v244 : US4 = US4_4(v243)
    let v245 : string = $"date_time.get_utc_offset / target: {v244}"
    let v246 : System.TimeSpan = failwith<System.TimeSpan> v245
    let _run_target_args'_v154 = v246 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v249 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v250 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v251 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v252 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v251 
    let _run_target_args'_v250 = v252 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v253 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v253 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v256 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v256 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v259 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v259 
    #endif
#if FABLE_COMPILER_PYTHON
    let v262 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v250 = v262 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v265 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v250 = v265 
    #endif
#else
    let v266 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v250 = v266 
    #endif
    let v267 : System.TimeZoneInfo = _run_target_args'_v250 
    let v272 : (System.DateTime -> System.TimeSpan) = v249 v267
    let v273 : System.TimeSpan = v272 v15
    let _run_target_args'_v154 = v273 
    #endif
#else
    let v274 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v275 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v276 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v277 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v276 
    let _run_target_args'_v275 = v277 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v278 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v278 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v281 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v281 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v284 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v284 
    #endif
#if FABLE_COMPILER_PYTHON
    let v287 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v275 = v287 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v290 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v275 = v290 
    #endif
#else
    let v291 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v275 = v291 
    #endif
    let v292 : System.TimeZoneInfo = _run_target_args'_v275 
    let v297 : (System.DateTime -> System.TimeSpan) = v274 v292
    let v298 : System.TimeSpan = v297 v15
    let _run_target_args'_v154 = v298 
    #endif
    let v299 : System.TimeSpan = _run_target_args'_v154 
    let v307 : (System.TimeSpan -> int32) = _.Hours
    let v308 : int32 = v307 v299
    let v311 : bool = v308 > 0
    let v312 : uint8 =
        if v311 then
            1uy
        else
            0uy
    let v313 : string = method80()
    (* run_target_args'
    let v314 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v315 : string = "$0.toString($1)"
    let v316 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v315 
    let _run_target_args'_v314 = v316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v317 : string = "$0.toString($1)"
    let v318 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v317 
    let _run_target_args'_v314 = v318 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v319 : string = "$0.toString($1)"
    let v320 : string = Fable.Core.RustInterop.emitRustExpr struct (v299, v313) v319 
    let _run_target_args'_v314 = v320 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v321 : string = v299.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v314 = v321 
    #endif
#if FABLE_COMPILER_PYTHON
    let v322 : string = v299.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v314 = v322 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v323 : string = v299.ToString v313 
    let _run_target_args'_v314 = v323 
    #endif
#else
    let v369 : string = v299.ToString v313 
    let _run_target_args'_v314 = v369 
    #endif
    let v415 : string = _run_target_args'_v314 
    let v463 : string = $"{v312}{v415.[0..1]}{v415.[3..4]}"
    let v464 : (System.Guid -> string) = _.ToString()
    let v465 : string = v464 v0
    let v468 : int32 = v131.Length
    let v469 : int32 = v463.Length
    let v470 : int32 = v468 + v469
    let v471 : (string -> int32) = String.length
    let v472 : int32 = v471 v465
    let v475 : int32 = v470 |> int32 
    let v482 : int32 = v472 |> int32 
    let v489 : int32 = v482 - 1
    let v490 : string = v465.[int v475..int v489]
    let v494 : string = $"{v131}{v463}{v490}"
    (* run_target_args'
    let v495 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v496 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v496 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v499 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v499 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v502 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v495 = v502 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v505 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v505 
    #endif
#if FABLE_COMPILER_PYTHON
    let v508 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v508 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v511 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v511 
    #endif
#else
    let v514 : System.Guid = v494 |> System.Guid 
    let _run_target_args'_v495 = v514 
    #endif
    let v517 : System.Guid = _run_target_args'_v495 
    let _run_target_args'_v2 = v517 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v522 : System.DateTime = System.DateTime.UnixEpoch
    let v525 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v526 : System.DateTime = v525 v522
    let v529 : System.DateTimeKind = System.DateTimeKind.Local
    let v530 : System.DateTime = System.DateTime.SpecifyKind (v1, v529)
    let v533 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v534 : System.DateTime = v533 v530
    (* run_target_args'
    let v537 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v538 : (System.DateTime -> int64) = _.Ticks
    let v539 : int64 = v538 v534
    let _run_target_args'_v537 = v539 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v540 : (System.DateTime -> int64) = _.Ticks
    let v541 : int64 = v540 v534
    let _run_target_args'_v537 = v541 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v542 : int64 = null |> unbox<int64>
    let _run_target_args'_v537 = v542 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v545 : (System.DateTime -> int64) = _.Ticks
    let v546 : int64 = v545 v534
    let _run_target_args'_v537 = v546 
    #endif
#if FABLE_COMPILER_PYTHON
    let v547 : (System.DateTime -> int64) = _.Ticks
    let v548 : int64 = v547 v534
    let _run_target_args'_v537 = v548 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v549 : (System.DateTime -> int64) = _.Ticks
    let v550 : int64 = v549 v534
    let _run_target_args'_v537 = v550 
    #endif
#else
    let v551 : (System.DateTime -> int64) = _.Ticks
    let v552 : int64 = v551 v534
    let _run_target_args'_v537 = v552 
    #endif
    let v553 : int64 = _run_target_args'_v537 
    (* run_target_args'
    let v570 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v571 : (System.DateTime -> int64) = _.Ticks
    let v572 : int64 = v571 v526
    let _run_target_args'_v570 = v572 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v573 : (System.DateTime -> int64) = _.Ticks
    let v574 : int64 = v573 v526
    let _run_target_args'_v570 = v574 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v575 : int64 = null |> unbox<int64>
    let _run_target_args'_v570 = v575 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v578 : (System.DateTime -> int64) = _.Ticks
    let v579 : int64 = v578 v526
    let _run_target_args'_v570 = v579 
    #endif
#if FABLE_COMPILER_PYTHON
    let v580 : (System.DateTime -> int64) = _.Ticks
    let v581 : int64 = v580 v526
    let _run_target_args'_v570 = v581 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v582 : (System.DateTime -> int64) = _.Ticks
    let v583 : int64 = v582 v526
    let _run_target_args'_v570 = v583 
    #endif
#else
    let v584 : (System.DateTime -> int64) = _.Ticks
    let v585 : int64 = v584 v526
    let _run_target_args'_v570 = v585 
    #endif
    let v586 : int64 = _run_target_args'_v570 
    let v603 : int64 = v553 |> int64 
    let v606 : int64 = v586 |> int64 
    let v609 : int64 = v603 - v606
    let v610 : int64 = v609 / 10L
    let v611 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v612 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v610 v611 
    let v613 : (chrono_DateTime<chrono_Utc> -> US12) = method79()
    let v614 : US12 option = v612 |> Option.map v613 
    let v625 : US12 = US12_1
    let v626 : US12 = v614 |> Option.defaultValue v625 
    let v646 : US5 =
        match v626 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v630) -> (* Some *)
            let v631 : string = "$0.naive_utc()"
            let v632 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v630 v631 
            let v633 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v634 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v632 v633 
            let v635 : string = "%Y%m%d-%H%M-%S%f"
            let v636 : string = "r#\"" + v635 + "\"#"
            let v637 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v636 
            let v638 : string = "$0.format($1).to_string()"
            let v639 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v634, v637) v638 
            let v640 : string = "fable_library_rust::String_::fromString($0)"
            let v641 : string = Fable.Core.RustInterop.emitRustExpr v639 v640 
            let v642 : string = $"{v641.[0..17]}-{v641.[18..21]}-{v641.[22]}"
            US5_0(v642)
    let v650 : string =
        match v646 with
        | US5_1 -> (* None *)
            let v648 : string = ""
            v648
        | US5_0(v647) -> (* Some *)
            v647
    (* run_target_args'
    let v651 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v652 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v653 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v652 
    let _run_target_args'_v651 = v653 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v654 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v654 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v657 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v657 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v660 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v660 
    #endif
#if FABLE_COMPILER_PYTHON
    let v663 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v651 = v663 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v666 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v651 = v666 
    #endif
#else
    let v667 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v651 = v667 
    #endif
    let v668 : System.TimeZoneInfo = _run_target_args'_v651 
    (* run_target_args'
    let v673 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v674 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v675 : (System.DateTime -> int64) = _.Ticks
    let v676 : int64 = v675 v534
    let _run_target_args'_v674 = v676 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v677 : (System.DateTime -> int64) = _.Ticks
    let v678 : int64 = v677 v534
    let _run_target_args'_v674 = v678 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v679 : int64 = null |> unbox<int64>
    let _run_target_args'_v674 = v679 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v682 : (System.DateTime -> int64) = _.Ticks
    let v683 : int64 = v682 v534
    let _run_target_args'_v674 = v683 
    #endif
#if FABLE_COMPILER_PYTHON
    let v684 : (System.DateTime -> int64) = _.Ticks
    let v685 : int64 = v684 v534
    let _run_target_args'_v674 = v685 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v686 : (System.DateTime -> int64) = _.Ticks
    let v687 : int64 = v686 v534
    let _run_target_args'_v674 = v687 
    #endif
#else
    let v688 : (System.DateTime -> int64) = _.Ticks
    let v689 : int64 = v688 v534
    let _run_target_args'_v674 = v689 
    #endif
    let v690 : int64 = _run_target_args'_v674 
    let v707 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v708 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v534, v690) v707 
    let v709 : System.TimeSpan = v708 |> System.TimeSpan 
    let _run_target_args'_v673 = v709 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v712 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v713 : (System.DateTime -> int64) = _.Ticks
    let v714 : int64 = v713 v534
    let _run_target_args'_v712 = v714 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v715 : (System.DateTime -> int64) = _.Ticks
    let v716 : int64 = v715 v534
    let _run_target_args'_v712 = v716 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v717 : int64 = null |> unbox<int64>
    let _run_target_args'_v712 = v717 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v720 : (System.DateTime -> int64) = _.Ticks
    let v721 : int64 = v720 v534
    let _run_target_args'_v712 = v721 
    #endif
#if FABLE_COMPILER_PYTHON
    let v722 : (System.DateTime -> int64) = _.Ticks
    let v723 : int64 = v722 v534
    let _run_target_args'_v712 = v723 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v724 : (System.DateTime -> int64) = _.Ticks
    let v725 : int64 = v724 v534
    let _run_target_args'_v712 = v725 
    #endif
#else
    let v726 : (System.DateTime -> int64) = _.Ticks
    let v727 : int64 = v726 v534
    let _run_target_args'_v712 = v727 
    #endif
    let v728 : int64 = _run_target_args'_v712 
    let v745 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v746 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v534, v728) v745 
    let v747 : System.TimeSpan = v746 |> System.TimeSpan 
    let _run_target_args'_v673 = v747 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v750 : US3 = US3_2
    let v751 : US4 = US4_2(v750)
    let v752 : string = $"date_time.get_utc_offset / target: {v751}"
    let v753 : System.TimeSpan = failwith<System.TimeSpan> v752
    let _run_target_args'_v673 = v753 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v756 : US3 = US3_0
    let v757 : US4 = US4_3(v756)
    let v758 : string = $"date_time.get_utc_offset / target: {v757}"
    let v759 : System.TimeSpan = failwith<System.TimeSpan> v758
    let _run_target_args'_v673 = v759 
    #endif
#if FABLE_COMPILER_PYTHON
    let v762 : US3 = US3_0
    let v763 : US4 = US4_4(v762)
    let v764 : string = $"date_time.get_utc_offset / target: {v763}"
    let v765 : System.TimeSpan = failwith<System.TimeSpan> v764
    let _run_target_args'_v673 = v765 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v768 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v769 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v770 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v771 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v770 
    let _run_target_args'_v769 = v771 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v772 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v772 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v775 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v775 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v778 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v778 
    #endif
#if FABLE_COMPILER_PYTHON
    let v781 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v769 = v781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v784 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v769 = v784 
    #endif
#else
    let v785 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v769 = v785 
    #endif
    let v786 : System.TimeZoneInfo = _run_target_args'_v769 
    let v791 : (System.DateTime -> System.TimeSpan) = v768 v786
    let v792 : System.TimeSpan = v791 v534
    let _run_target_args'_v673 = v792 
    #endif
#else
    let v793 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v794 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v795 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v796 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v795 
    let _run_target_args'_v794 = v796 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v797 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v797 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v800 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v800 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v803 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v803 
    #endif
#if FABLE_COMPILER_PYTHON
    let v806 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v794 = v806 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v809 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v794 = v809 
    #endif
#else
    let v810 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v794 = v810 
    #endif
    let v811 : System.TimeZoneInfo = _run_target_args'_v794 
    let v816 : (System.DateTime -> System.TimeSpan) = v793 v811
    let v817 : System.TimeSpan = v816 v534
    let _run_target_args'_v673 = v817 
    #endif
    let v818 : System.TimeSpan = _run_target_args'_v673 
    let v826 : (System.TimeSpan -> int32) = _.Hours
    let v827 : int32 = v826 v818
    let v830 : bool = v827 > 0
    let v831 : uint8 =
        if v830 then
            1uy
        else
            0uy
    let v832 : string = method80()
    (* run_target_args'
    let v833 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v834 : string = "$0.toString($1)"
    let v835 : string = Fable.Core.RustInterop.emitRustExpr struct (v818, v832) v834 
    let _run_target_args'_v833 = v835 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v836 : string = "$0.toString($1)"
    let v837 : string = Fable.Core.RustInterop.emitRustExpr struct (v818, v832) v836 
    let _run_target_args'_v833 = v837 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v838 : string = "$0.toString($1)"
    let v839 : string = Fable.Core.RustInterop.emitRustExpr struct (v818, v832) v838 
    let _run_target_args'_v833 = v839 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v840 : string = v818.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v833 = v840 
    #endif
#if FABLE_COMPILER_PYTHON
    let v841 : string = v818.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v833 = v841 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v842 : string = v818.ToString v832 
    let _run_target_args'_v833 = v842 
    #endif
#else
    let v888 : string = v818.ToString v832 
    let _run_target_args'_v833 = v888 
    #endif
    let v934 : string = _run_target_args'_v833 
    let v982 : string = $"{v831}{v934.[0..1]}{v934.[3..4]}"
    let v983 : (System.Guid -> string) = _.ToString()
    let v984 : string = v983 v0
    let v987 : int32 = v650.Length
    let v988 : int32 = v982.Length
    let v989 : int32 = v987 + v988
    let v990 : (string -> int32) = String.length
    let v991 : int32 = v990 v984
    let v994 : int32 = v989 |> int32 
    let v1001 : int32 = v991 |> int32 
    let v1008 : int32 = v1001 - 1
    let v1009 : string = v984.[int v994..int v1008]
    let v1013 : string = $"{v650}{v982}{v1009}"
    (* run_target_args'
    let v1014 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1015 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1015 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1018 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1018 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1021 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1014 = v1021 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1024 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1024 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1027 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1027 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1030 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1030 
    #endif
#else
    let v1033 : System.Guid = v1013 |> System.Guid 
    let _run_target_args'_v1014 = v1033 
    #endif
    let v1036 : System.Guid = _run_target_args'_v1014 
    let _run_target_args'_v2 = v1036 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1041 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2 = v1041 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1044 : string = method81()
    let v1045 : bool = v1044 = ""
    let v1047 : string =
        if v1045 then
            let v1046 : string = "M-d-y hh:mm:ss tt"
            v1046
        else
            v1044
    let v1048 : (string -> string) = v1.ToString
    let v1049 : string = v1048 v1047
    (* run_target_args'
    let v1063 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1064 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1065 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1064 
    let _run_target_args'_v1063 = v1065 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1066 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1066 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1069 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1069 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1072 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1072 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1075 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1063 = v1075 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1078 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1063 = v1078 
    #endif
#else
    let v1079 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1063 = v1079 
    #endif
    let v1080 : System.TimeZoneInfo = _run_target_args'_v1063 
    (* run_target_args'
    let v1085 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1086 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1087 : (System.DateTime -> int64) = _.Ticks
    let v1088 : int64 = v1087 v1
    let _run_target_args'_v1086 = v1088 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1089 : (System.DateTime -> int64) = _.Ticks
    let v1090 : int64 = v1089 v1
    let _run_target_args'_v1086 = v1090 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1091 : int64 = null |> unbox<int64>
    let _run_target_args'_v1086 = v1091 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1094 : (System.DateTime -> int64) = _.Ticks
    let v1095 : int64 = v1094 v1
    let _run_target_args'_v1086 = v1095 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1096 : (System.DateTime -> int64) = _.Ticks
    let v1097 : int64 = v1096 v1
    let _run_target_args'_v1086 = v1097 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1098 : (System.DateTime -> int64) = _.Ticks
    let v1099 : int64 = v1098 v1
    let _run_target_args'_v1086 = v1099 
    #endif
#else
    let v1100 : (System.DateTime -> int64) = _.Ticks
    let v1101 : int64 = v1100 v1
    let _run_target_args'_v1086 = v1101 
    #endif
    let v1102 : int64 = _run_target_args'_v1086 
    let v1119 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1120 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1102) v1119 
    let v1121 : System.TimeSpan = v1120 |> System.TimeSpan 
    let _run_target_args'_v1085 = v1121 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1124 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1125 : (System.DateTime -> int64) = _.Ticks
    let v1126 : int64 = v1125 v1
    let _run_target_args'_v1124 = v1126 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1127 : (System.DateTime -> int64) = _.Ticks
    let v1128 : int64 = v1127 v1
    let _run_target_args'_v1124 = v1128 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1129 : int64 = null |> unbox<int64>
    let _run_target_args'_v1124 = v1129 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1132 : (System.DateTime -> int64) = _.Ticks
    let v1133 : int64 = v1132 v1
    let _run_target_args'_v1124 = v1133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1134 : (System.DateTime -> int64) = _.Ticks
    let v1135 : int64 = v1134 v1
    let _run_target_args'_v1124 = v1135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1136 : (System.DateTime -> int64) = _.Ticks
    let v1137 : int64 = v1136 v1
    let _run_target_args'_v1124 = v1137 
    #endif
#else
    let v1138 : (System.DateTime -> int64) = _.Ticks
    let v1139 : int64 = v1138 v1
    let _run_target_args'_v1124 = v1139 
    #endif
    let v1140 : int64 = _run_target_args'_v1124 
    let v1157 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1158 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1140) v1157 
    let v1159 : System.TimeSpan = v1158 |> System.TimeSpan 
    let _run_target_args'_v1085 = v1159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1162 : US3 = US3_2
    let v1163 : US4 = US4_2(v1162)
    let v1164 : string = $"date_time.get_utc_offset / target: {v1163}"
    let v1165 : System.TimeSpan = failwith<System.TimeSpan> v1164
    let _run_target_args'_v1085 = v1165 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1168 : US3 = US3_0
    let v1169 : US4 = US4_3(v1168)
    let v1170 : string = $"date_time.get_utc_offset / target: {v1169}"
    let v1171 : System.TimeSpan = failwith<System.TimeSpan> v1170
    let _run_target_args'_v1085 = v1171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1174 : US3 = US3_0
    let v1175 : US4 = US4_4(v1174)
    let v1176 : string = $"date_time.get_utc_offset / target: {v1175}"
    let v1177 : System.TimeSpan = failwith<System.TimeSpan> v1176
    let _run_target_args'_v1085 = v1177 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1180 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1181 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1182 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1183 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1182 
    let _run_target_args'_v1181 = v1183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1184 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1184 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1187 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1187 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1190 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1190 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1193 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1181 = v1193 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1196 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1181 = v1196 
    #endif
#else
    let v1197 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1181 = v1197 
    #endif
    let v1198 : System.TimeZoneInfo = _run_target_args'_v1181 
    let v1203 : (System.DateTime -> System.TimeSpan) = v1180 v1198
    let v1204 : System.TimeSpan = v1203 v1
    let _run_target_args'_v1085 = v1204 
    #endif
#else
    let v1205 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1206 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1207 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1208 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1207 
    let _run_target_args'_v1206 = v1208 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1209 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1209 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1212 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1212 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1215 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1215 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1218 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1206 = v1218 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1221 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1206 = v1221 
    #endif
#else
    let v1222 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1206 = v1222 
    #endif
    let v1223 : System.TimeZoneInfo = _run_target_args'_v1206 
    let v1228 : (System.DateTime -> System.TimeSpan) = v1205 v1223
    let v1229 : System.TimeSpan = v1228 v1
    let _run_target_args'_v1085 = v1229 
    #endif
    let v1230 : System.TimeSpan = _run_target_args'_v1085 
    let v1238 : (System.TimeSpan -> int32) = _.Hours
    let v1239 : int32 = v1238 v1230
    let v1242 : bool = v1239 > 0
    let v1243 : uint8 =
        if v1242 then
            1uy
        else
            0uy
    let v1244 : string = method82()
    (* run_target_args'
    let v1245 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1246 : string = "$0.toString($1)"
    let v1247 : string = Fable.Core.RustInterop.emitRustExpr struct (v1230, v1244) v1246 
    let _run_target_args'_v1245 = v1247 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1248 : string = "$0.toString($1)"
    let v1249 : string = Fable.Core.RustInterop.emitRustExpr struct (v1230, v1244) v1248 
    let _run_target_args'_v1245 = v1249 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1250 : string = "$0.toString($1)"
    let v1251 : string = Fable.Core.RustInterop.emitRustExpr struct (v1230, v1244) v1250 
    let _run_target_args'_v1245 = v1251 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1252 : string = v1230.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1245 = v1252 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1253 : string = v1230.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1245 = v1253 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1254 : string = v1230.ToString v1244 
    let _run_target_args'_v1245 = v1254 
    #endif
#else
    let v1300 : string = v1230.ToString v1244 
    let _run_target_args'_v1245 = v1300 
    #endif
    let v1346 : string = _run_target_args'_v1245 
    let v1394 : string = $"{v1243}{v1346}"
    let v1395 : (System.Guid -> string) = _.ToString()
    let v1396 : string = v1395 v0
    let v1399 : int32 = v1049.Length
    let v1400 : int32 = v1394.Length
    let v1401 : int32 = v1399 + v1400
    let v1402 : (string -> int32) = String.length
    let v1403 : int32 = v1402 v1396
    let v1406 : int32 = v1401 |> int32 
    let v1413 : int32 = v1403 |> int32 
    let v1420 : int32 = v1413 - 1
    let v1421 : string = v1396.[int v1406..int v1420]
    let v1425 : string = $"{v1049}{v1394}{v1421}"
    (* run_target_args'
    let v1426 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1427 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1427 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1430 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1430 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1433 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1426 = v1433 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1436 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1439 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1439 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1442 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1442 
    #endif
#else
    let v1445 : System.Guid = v1425 |> System.Guid 
    let _run_target_args'_v1426 = v1445 
    #endif
    let v1448 : System.Guid = _run_target_args'_v1426 
    let _run_target_args'_v2 = v1448 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1453 : string = method81()
    let v1454 : bool = v1453 = ""
    let v1456 : string =
        if v1454 then
            let v1455 : string = "M-d-y hh:mm:ss tt"
            v1455
        else
            v1453
    let v1457 : (string -> string) = v1.ToString
    let v1458 : string = v1457 v1456
    (* run_target_args'
    let v1472 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1473 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1474 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1473 
    let _run_target_args'_v1472 = v1474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1475 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1475 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1478 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1478 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1481 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1481 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1484 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1472 = v1484 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1487 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1472 = v1487 
    #endif
#else
    let v1488 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1472 = v1488 
    #endif
    let v1489 : System.TimeZoneInfo = _run_target_args'_v1472 
    (* run_target_args'
    let v1494 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1495 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1496 : (System.DateTime -> int64) = _.Ticks
    let v1497 : int64 = v1496 v1
    let _run_target_args'_v1495 = v1497 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1498 : (System.DateTime -> int64) = _.Ticks
    let v1499 : int64 = v1498 v1
    let _run_target_args'_v1495 = v1499 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1500 : int64 = null |> unbox<int64>
    let _run_target_args'_v1495 = v1500 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1503 : (System.DateTime -> int64) = _.Ticks
    let v1504 : int64 = v1503 v1
    let _run_target_args'_v1495 = v1504 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1505 : (System.DateTime -> int64) = _.Ticks
    let v1506 : int64 = v1505 v1
    let _run_target_args'_v1495 = v1506 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1507 : (System.DateTime -> int64) = _.Ticks
    let v1508 : int64 = v1507 v1
    let _run_target_args'_v1495 = v1508 
    #endif
#else
    let v1509 : (System.DateTime -> int64) = _.Ticks
    let v1510 : int64 = v1509 v1
    let _run_target_args'_v1495 = v1510 
    #endif
    let v1511 : int64 = _run_target_args'_v1495 
    let v1528 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1529 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1511) v1528 
    let v1530 : System.TimeSpan = v1529 |> System.TimeSpan 
    let _run_target_args'_v1494 = v1530 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1533 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1534 : (System.DateTime -> int64) = _.Ticks
    let v1535 : int64 = v1534 v1
    let _run_target_args'_v1533 = v1535 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1536 : (System.DateTime -> int64) = _.Ticks
    let v1537 : int64 = v1536 v1
    let _run_target_args'_v1533 = v1537 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1538 : int64 = null |> unbox<int64>
    let _run_target_args'_v1533 = v1538 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1541 : (System.DateTime -> int64) = _.Ticks
    let v1542 : int64 = v1541 v1
    let _run_target_args'_v1533 = v1542 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1543 : (System.DateTime -> int64) = _.Ticks
    let v1544 : int64 = v1543 v1
    let _run_target_args'_v1533 = v1544 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1545 : (System.DateTime -> int64) = _.Ticks
    let v1546 : int64 = v1545 v1
    let _run_target_args'_v1533 = v1546 
    #endif
#else
    let v1547 : (System.DateTime -> int64) = _.Ticks
    let v1548 : int64 = v1547 v1
    let _run_target_args'_v1533 = v1548 
    #endif
    let v1549 : int64 = _run_target_args'_v1533 
    let v1566 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1567 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1549) v1566 
    let v1568 : System.TimeSpan = v1567 |> System.TimeSpan 
    let _run_target_args'_v1494 = v1568 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1571 : US3 = US3_2
    let v1572 : US4 = US4_2(v1571)
    let v1573 : string = $"date_time.get_utc_offset / target: {v1572}"
    let v1574 : System.TimeSpan = failwith<System.TimeSpan> v1573
    let _run_target_args'_v1494 = v1574 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1577 : US3 = US3_0
    let v1578 : US4 = US4_3(v1577)
    let v1579 : string = $"date_time.get_utc_offset / target: {v1578}"
    let v1580 : System.TimeSpan = failwith<System.TimeSpan> v1579
    let _run_target_args'_v1494 = v1580 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1583 : US3 = US3_0
    let v1584 : US4 = US4_4(v1583)
    let v1585 : string = $"date_time.get_utc_offset / target: {v1584}"
    let v1586 : System.TimeSpan = failwith<System.TimeSpan> v1585
    let _run_target_args'_v1494 = v1586 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1589 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1590 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1591 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1592 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1591 
    let _run_target_args'_v1590 = v1592 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1593 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1596 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1596 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1599 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1599 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1602 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1590 = v1602 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1605 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1590 = v1605 
    #endif
#else
    let v1606 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1590 = v1606 
    #endif
    let v1607 : System.TimeZoneInfo = _run_target_args'_v1590 
    let v1612 : (System.DateTime -> System.TimeSpan) = v1589 v1607
    let v1613 : System.TimeSpan = v1612 v1
    let _run_target_args'_v1494 = v1613 
    #endif
#else
    let v1614 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1615 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1616 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1617 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1616 
    let _run_target_args'_v1615 = v1617 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1618 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1618 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1621 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1621 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1624 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1624 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1627 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1627 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1630 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1630 
    #endif
#else
    let v1631 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1631 
    #endif
    let v1632 : System.TimeZoneInfo = _run_target_args'_v1615 
    let v1637 : (System.DateTime -> System.TimeSpan) = v1614 v1632
    let v1638 : System.TimeSpan = v1637 v1
    let _run_target_args'_v1494 = v1638 
    #endif
    let v1639 : System.TimeSpan = _run_target_args'_v1494 
    let v1647 : (System.TimeSpan -> int32) = _.Hours
    let v1648 : int32 = v1647 v1639
    let v1651 : bool = v1648 > 0
    let v1652 : uint8 =
        if v1651 then
            1uy
        else
            0uy
    let v1653 : string = method82()
    (* run_target_args'
    let v1654 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1655 : string = "$0.toString($1)"
    let v1656 : string = Fable.Core.RustInterop.emitRustExpr struct (v1639, v1653) v1655 
    let _run_target_args'_v1654 = v1656 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1657 : string = "$0.toString($1)"
    let v1658 : string = Fable.Core.RustInterop.emitRustExpr struct (v1639, v1653) v1657 
    let _run_target_args'_v1654 = v1658 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1659 : string = "$0.toString($1)"
    let v1660 : string = Fable.Core.RustInterop.emitRustExpr struct (v1639, v1653) v1659 
    let _run_target_args'_v1654 = v1660 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1661 : string = v1639.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1654 = v1661 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1662 : string = v1639.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1654 = v1662 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1663 : string = v1639.ToString v1653 
    let _run_target_args'_v1654 = v1663 
    #endif
#else
    let v1709 : string = v1639.ToString v1653 
    let _run_target_args'_v1654 = v1709 
    #endif
    let v1755 : string = _run_target_args'_v1654 
    let v1803 : string = $"{v1652}{v1755}"
    let v1804 : (System.Guid -> string) = _.ToString()
    let v1805 : string = v1804 v0
    let v1808 : int32 = v1458.Length
    let v1809 : int32 = v1803.Length
    let v1810 : int32 = v1808 + v1809
    let v1811 : (string -> int32) = String.length
    let v1812 : int32 = v1811 v1805
    let v1815 : int32 = v1810 |> int32 
    let v1822 : int32 = v1812 |> int32 
    let v1829 : int32 = v1822 - 1
    let v1830 : string = v1805.[int v1815..int v1829]
    let v1834 : string = $"{v1458}{v1803}{v1830}"
    (* run_target_args'
    let v1835 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1836 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1836 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1839 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1839 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1842 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1835 = v1842 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1845 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1845 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1848 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1848 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1851 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1851 
    #endif
#else
    let v1854 : System.Guid = v1834 |> System.Guid 
    let _run_target_args'_v1835 = v1854 
    #endif
    let v1857 : System.Guid = _run_target_args'_v1835 
    let _run_target_args'_v2 = v1857 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1862 : string = method81()
    let v1863 : bool = v1862 = ""
    let v1865 : string =
        if v1863 then
            let v1864 : string = "M-d-y hh:mm:ss tt"
            v1864
        else
            v1862
    let v1866 : (string -> string) = v1.ToString
    let v1867 : string = v1866 v1865
    (* run_target_args'
    let v1881 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1882 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1883 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1882 
    let _run_target_args'_v1881 = v1883 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1884 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1884 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1887 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1887 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1890 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1890 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1893 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1896 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1896 
    #endif
#else
    let v1897 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1897 
    #endif
    let v1898 : System.TimeZoneInfo = _run_target_args'_v1881 
    (* run_target_args'
    let v1903 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1904 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1905 : (System.DateTime -> int64) = _.Ticks
    let v1906 : int64 = v1905 v1
    let _run_target_args'_v1904 = v1906 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1907 : (System.DateTime -> int64) = _.Ticks
    let v1908 : int64 = v1907 v1
    let _run_target_args'_v1904 = v1908 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1909 : int64 = null |> unbox<int64>
    let _run_target_args'_v1904 = v1909 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1912 : (System.DateTime -> int64) = _.Ticks
    let v1913 : int64 = v1912 v1
    let _run_target_args'_v1904 = v1913 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1914 : (System.DateTime -> int64) = _.Ticks
    let v1915 : int64 = v1914 v1
    let _run_target_args'_v1904 = v1915 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1916 : (System.DateTime -> int64) = _.Ticks
    let v1917 : int64 = v1916 v1
    let _run_target_args'_v1904 = v1917 
    #endif
#else
    let v1918 : (System.DateTime -> int64) = _.Ticks
    let v1919 : int64 = v1918 v1
    let _run_target_args'_v1904 = v1919 
    #endif
    let v1920 : int64 = _run_target_args'_v1904 
    let v1937 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1938 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1920) v1937 
    let v1939 : System.TimeSpan = v1938 |> System.TimeSpan 
    let _run_target_args'_v1903 = v1939 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1942 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1943 : (System.DateTime -> int64) = _.Ticks
    let v1944 : int64 = v1943 v1
    let _run_target_args'_v1942 = v1944 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1945 : (System.DateTime -> int64) = _.Ticks
    let v1946 : int64 = v1945 v1
    let _run_target_args'_v1942 = v1946 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1947 : int64 = null |> unbox<int64>
    let _run_target_args'_v1942 = v1947 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1950 : (System.DateTime -> int64) = _.Ticks
    let v1951 : int64 = v1950 v1
    let _run_target_args'_v1942 = v1951 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1952 : (System.DateTime -> int64) = _.Ticks
    let v1953 : int64 = v1952 v1
    let _run_target_args'_v1942 = v1953 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1954 : (System.DateTime -> int64) = _.Ticks
    let v1955 : int64 = v1954 v1
    let _run_target_args'_v1942 = v1955 
    #endif
#else
    let v1956 : (System.DateTime -> int64) = _.Ticks
    let v1957 : int64 = v1956 v1
    let _run_target_args'_v1942 = v1957 
    #endif
    let v1958 : int64 = _run_target_args'_v1942 
    let v1975 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1976 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v1958) v1975 
    let v1977 : System.TimeSpan = v1976 |> System.TimeSpan 
    let _run_target_args'_v1903 = v1977 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1980 : US3 = US3_2
    let v1981 : US4 = US4_2(v1980)
    let v1982 : string = $"date_time.get_utc_offset / target: {v1981}"
    let v1983 : System.TimeSpan = failwith<System.TimeSpan> v1982
    let _run_target_args'_v1903 = v1983 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1986 : US3 = US3_0
    let v1987 : US4 = US4_3(v1986)
    let v1988 : string = $"date_time.get_utc_offset / target: {v1987}"
    let v1989 : System.TimeSpan = failwith<System.TimeSpan> v1988
    let _run_target_args'_v1903 = v1989 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1992 : US3 = US3_0
    let v1993 : US4 = US4_4(v1992)
    let v1994 : string = $"date_time.get_utc_offset / target: {v1993}"
    let v1995 : System.TimeSpan = failwith<System.TimeSpan> v1994
    let _run_target_args'_v1903 = v1995 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1998 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1999 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2000 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2001 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2000 
    let _run_target_args'_v1999 = v2001 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2002 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2002 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2005 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2005 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2008 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2008 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2011 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2011 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2014 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2014 
    #endif
#else
    let v2015 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2015 
    #endif
    let v2016 : System.TimeZoneInfo = _run_target_args'_v1999 
    let v2021 : (System.DateTime -> System.TimeSpan) = v1998 v2016
    let v2022 : System.TimeSpan = v2021 v1
    let _run_target_args'_v1903 = v2022 
    #endif
#else
    let v2023 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2024 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2025 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2026 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2025 
    let _run_target_args'_v2024 = v2026 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2027 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2027 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2030 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2030 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2033 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2033 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2036 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2024 = v2036 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2039 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2024 = v2039 
    #endif
#else
    let v2040 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2024 = v2040 
    #endif
    let v2041 : System.TimeZoneInfo = _run_target_args'_v2024 
    let v2046 : (System.DateTime -> System.TimeSpan) = v2023 v2041
    let v2047 : System.TimeSpan = v2046 v1
    let _run_target_args'_v1903 = v2047 
    #endif
    let v2048 : System.TimeSpan = _run_target_args'_v1903 
    let v2056 : (System.TimeSpan -> int32) = _.Hours
    let v2057 : int32 = v2056 v2048
    let v2060 : bool = v2057 > 0
    let v2061 : uint8 =
        if v2060 then
            1uy
        else
            0uy
    let v2062 : string = method82()
    (* run_target_args'
    let v2063 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2064 : string = "$0.toString($1)"
    let v2065 : string = Fable.Core.RustInterop.emitRustExpr struct (v2048, v2062) v2064 
    let _run_target_args'_v2063 = v2065 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2066 : string = "$0.toString($1)"
    let v2067 : string = Fable.Core.RustInterop.emitRustExpr struct (v2048, v2062) v2066 
    let _run_target_args'_v2063 = v2067 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2068 : string = "$0.toString($1)"
    let v2069 : string = Fable.Core.RustInterop.emitRustExpr struct (v2048, v2062) v2068 
    let _run_target_args'_v2063 = v2069 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2070 : string = v2048.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2063 = v2070 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2071 : string = v2048.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2063 = v2071 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2072 : string = v2048.ToString v2062 
    let _run_target_args'_v2063 = v2072 
    #endif
#else
    let v2118 : string = v2048.ToString v2062 
    let _run_target_args'_v2063 = v2118 
    #endif
    let v2164 : string = _run_target_args'_v2063 
    let v2212 : string = $"{v2061}{v2164}"
    let v2213 : (System.Guid -> string) = _.ToString()
    let v2214 : string = v2213 v0
    let v2217 : int32 = v1867.Length
    let v2218 : int32 = v2212.Length
    let v2219 : int32 = v2217 + v2218
    let v2220 : (string -> int32) = String.length
    let v2221 : int32 = v2220 v2214
    let v2224 : int32 = v2219 |> int32 
    let v2231 : int32 = v2221 |> int32 
    let v2238 : int32 = v2231 - 1
    let v2239 : string = v2214.[int v2224..int v2238]
    let v2243 : string = $"{v1867}{v2212}{v2239}"
    (* run_target_args'
    let v2244 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2245 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2245 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2248 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2248 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2251 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2244 = v2251 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2254 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2254 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2257 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2257 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2260 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2260 
    #endif
#else
    let v2263 : System.Guid = v2243 |> System.Guid 
    let _run_target_args'_v2244 = v2263 
    #endif
    let v2266 : System.Guid = _run_target_args'_v2244 
    let _run_target_args'_v2 = v2266 
    #endif
#else
    let v2271 : string = method81()
    let v2272 : bool = v2271 = ""
    let v2274 : string =
        if v2272 then
            let v2273 : string = "M-d-y hh:mm:ss tt"
            v2273
        else
            v2271
    let v2275 : (string -> string) = v1.ToString
    let v2276 : string = v2275 v2274
    (* run_target_args'
    let v2290 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2291 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2292 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2291 
    let _run_target_args'_v2290 = v2292 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2293 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2293 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2296 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2296 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2299 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2299 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2302 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2290 = v2302 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2305 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2290 = v2305 
    #endif
#else
    let v2306 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2290 = v2306 
    #endif
    let v2307 : System.TimeZoneInfo = _run_target_args'_v2290 
    (* run_target_args'
    let v2312 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2313 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2314 : (System.DateTime -> int64) = _.Ticks
    let v2315 : int64 = v2314 v1
    let _run_target_args'_v2313 = v2315 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2316 : (System.DateTime -> int64) = _.Ticks
    let v2317 : int64 = v2316 v1
    let _run_target_args'_v2313 = v2317 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2318 : int64 = null |> unbox<int64>
    let _run_target_args'_v2313 = v2318 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2321 : (System.DateTime -> int64) = _.Ticks
    let v2322 : int64 = v2321 v1
    let _run_target_args'_v2313 = v2322 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2323 : (System.DateTime -> int64) = _.Ticks
    let v2324 : int64 = v2323 v1
    let _run_target_args'_v2313 = v2324 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2325 : (System.DateTime -> int64) = _.Ticks
    let v2326 : int64 = v2325 v1
    let _run_target_args'_v2313 = v2326 
    #endif
#else
    let v2327 : (System.DateTime -> int64) = _.Ticks
    let v2328 : int64 = v2327 v1
    let _run_target_args'_v2313 = v2328 
    #endif
    let v2329 : int64 = _run_target_args'_v2313 
    let v2346 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2347 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2329) v2346 
    let v2348 : System.TimeSpan = v2347 |> System.TimeSpan 
    let _run_target_args'_v2312 = v2348 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2351 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2352 : (System.DateTime -> int64) = _.Ticks
    let v2353 : int64 = v2352 v1
    let _run_target_args'_v2351 = v2353 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2354 : (System.DateTime -> int64) = _.Ticks
    let v2355 : int64 = v2354 v1
    let _run_target_args'_v2351 = v2355 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2356 : int64 = null |> unbox<int64>
    let _run_target_args'_v2351 = v2356 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2359 : (System.DateTime -> int64) = _.Ticks
    let v2360 : int64 = v2359 v1
    let _run_target_args'_v2351 = v2360 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2361 : (System.DateTime -> int64) = _.Ticks
    let v2362 : int64 = v2361 v1
    let _run_target_args'_v2351 = v2362 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2363 : (System.DateTime -> int64) = _.Ticks
    let v2364 : int64 = v2363 v1
    let _run_target_args'_v2351 = v2364 
    #endif
#else
    let v2365 : (System.DateTime -> int64) = _.Ticks
    let v2366 : int64 = v2365 v1
    let _run_target_args'_v2351 = v2366 
    #endif
    let v2367 : int64 = _run_target_args'_v2351 
    let v2384 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2385 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2367) v2384 
    let v2386 : System.TimeSpan = v2385 |> System.TimeSpan 
    let _run_target_args'_v2312 = v2386 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2389 : US3 = US3_2
    let v2390 : US4 = US4_2(v2389)
    let v2391 : string = $"date_time.get_utc_offset / target: {v2390}"
    let v2392 : System.TimeSpan = failwith<System.TimeSpan> v2391
    let _run_target_args'_v2312 = v2392 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2395 : US3 = US3_0
    let v2396 : US4 = US4_3(v2395)
    let v2397 : string = $"date_time.get_utc_offset / target: {v2396}"
    let v2398 : System.TimeSpan = failwith<System.TimeSpan> v2397
    let _run_target_args'_v2312 = v2398 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2401 : US3 = US3_0
    let v2402 : US4 = US4_4(v2401)
    let v2403 : string = $"date_time.get_utc_offset / target: {v2402}"
    let v2404 : System.TimeSpan = failwith<System.TimeSpan> v2403
    let _run_target_args'_v2312 = v2404 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2407 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2408 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2409 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2410 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2409 
    let _run_target_args'_v2408 = v2410 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2411 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2411 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2414 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2414 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2417 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2417 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2420 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2408 = v2420 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2423 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2408 = v2423 
    #endif
#else
    let v2424 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2408 = v2424 
    #endif
    let v2425 : System.TimeZoneInfo = _run_target_args'_v2408 
    let v2430 : (System.DateTime -> System.TimeSpan) = v2407 v2425
    let v2431 : System.TimeSpan = v2430 v1
    let _run_target_args'_v2312 = v2431 
    #endif
#else
    let v2432 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2433 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2434 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2435 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2434 
    let _run_target_args'_v2433 = v2435 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2436 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2439 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2439 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2442 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2442 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2445 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2433 = v2445 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2448 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2433 = v2448 
    #endif
#else
    let v2449 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2433 = v2449 
    #endif
    let v2450 : System.TimeZoneInfo = _run_target_args'_v2433 
    let v2455 : (System.DateTime -> System.TimeSpan) = v2432 v2450
    let v2456 : System.TimeSpan = v2455 v1
    let _run_target_args'_v2312 = v2456 
    #endif
    let v2457 : System.TimeSpan = _run_target_args'_v2312 
    let v2465 : (System.TimeSpan -> int32) = _.Hours
    let v2466 : int32 = v2465 v2457
    let v2469 : bool = v2466 > 0
    let v2470 : uint8 =
        if v2469 then
            1uy
        else
            0uy
    let v2471 : string = method82()
    (* run_target_args'
    let v2472 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2473 : string = "$0.toString($1)"
    let v2474 : string = Fable.Core.RustInterop.emitRustExpr struct (v2457, v2471) v2473 
    let _run_target_args'_v2472 = v2474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2475 : string = "$0.toString($1)"
    let v2476 : string = Fable.Core.RustInterop.emitRustExpr struct (v2457, v2471) v2475 
    let _run_target_args'_v2472 = v2476 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2477 : string = "$0.toString($1)"
    let v2478 : string = Fable.Core.RustInterop.emitRustExpr struct (v2457, v2471) v2477 
    let _run_target_args'_v2472 = v2478 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2479 : string = v2457.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2472 = v2479 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2480 : string = v2457.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2472 = v2480 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2481 : string = v2457.ToString v2471 
    let _run_target_args'_v2472 = v2481 
    #endif
#else
    let v2527 : string = v2457.ToString v2471 
    let _run_target_args'_v2472 = v2527 
    #endif
    let v2573 : string = _run_target_args'_v2472 
    let v2621 : string = $"{v2470}{v2573}"
    let v2622 : (System.Guid -> string) = _.ToString()
    let v2623 : string = v2622 v0
    let v2626 : int32 = v2276.Length
    let v2627 : int32 = v2621.Length
    let v2628 : int32 = v2626 + v2627
    let v2629 : (string -> int32) = String.length
    let v2630 : int32 = v2629 v2623
    let v2633 : int32 = v2628 |> int32 
    let v2640 : int32 = v2630 |> int32 
    let v2647 : int32 = v2640 - 1
    let v2648 : string = v2623.[int v2633..int v2647]
    let v2652 : string = $"{v2276}{v2621}{v2648}"
    (* run_target_args'
    let v2653 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2654 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2654 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2657 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2657 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2660 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2653 = v2660 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2663 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2663 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2666 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2666 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2669 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2669 
    #endif
#else
    let v2672 : System.Guid = v2652 |> System.Guid 
    let _run_target_args'_v2653 = v2672 
    #endif
    let v2675 : System.Guid = _run_target_args'_v2653 
    let _run_target_args'_v2 = v2675 
    #endif
    let v2680 : System.Guid = _run_target_args'_v2 
    v2680
and method84 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "std::env::temp_dir()"
    let v2 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr () v1 
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "$0.display()"
    let v5 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "$0.display()"
    let v7 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v2 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "$0.display()"
    let v9 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : std_path_Display = v2 |> unbox<std_path_Display>
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v13 : std_path_Display = v2 |> unbox<std_path_Display>
    let _run_target_args'_v3 = v13 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : std_path_Display = v2 |> unbox<std_path_Display>
    let _run_target_args'_v3 = v16 
    #endif
#else
    let v19 : std_path_Display = v2 |> unbox<std_path_Display>
    let _run_target_args'_v3 = v19 
    #endif
    let v22 : std_path_Display = _run_target_args'_v3 
    (* run_target_args'
    let v27 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v28 : string = "format!(\"{}\", $0)"
    let v29 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v28 
    let _run_target_args'_v27 = v29 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v30 : string = "format!(\"{}\", $0)"
    let v31 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v30 
    let _run_target_args'_v27 = v31 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v32 : string = "format!(\"{}\", $0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v32 
    let _run_target_args'_v27 = v33 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v34 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v27 = v34 
    #endif
#if FABLE_COMPILER_PYTHON
    let v37 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v27 = v37 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v40 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v27 = v40 
    #endif
#else
    let v43 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v27 = v43 
    #endif
    let v46 : std_string_String = _run_target_args'_v27 
    let v51 : string = "fable_library_rust::String_::fromString($0)"
    let v52 : string = Fable.Core.RustInterop.emitRustExpr v46 v51 
    let _run_target_args'_v0 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : US3 = US3_1
    let v54 : US4 = US4_2(v53)
    let v55 : string = $"file_system.get_temp_path / target: {v54}"
    let v56 : string = failwith<string> v55
    let _run_target_args'_v0 = v56 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v57 : string = null |> unbox<string>
    let _run_target_args'_v0 = v57 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v60 : US3 = US3_0
    let v61 : US4 = US4_3(v60)
    let v62 : string = $"file_system.get_temp_path / target: {v61}"
    let v63 : string = failwith<string> v62
    let _run_target_args'_v0 = v63 
    #endif
#if FABLE_COMPILER_PYTHON
    let v64 : US3 = US3_0
    let v65 : US4 = US4_4(v64)
    let v66 : string = $"file_system.get_temp_path / target: {v65}"
    let v67 : string = failwith<string> v66
    let _run_target_args'_v0 = v67 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v68 : US3 = US3_1
    let v69 : US4 = US4_0(v68)
    let v70 : string = $"file_system.get_temp_path / target: {v69}"
    let v71 : string = failwith<string> v70
    let _run_target_args'_v0 = v71 
    #endif
#else
    let v72 : (unit -> string) = System.IO.Path.GetTempPath
    let v73 : string = v72 ()
    let _run_target_args'_v0 = v73 
    #endif
    let v74 : string = _run_target_args'_v0 
    v74
and method85 () : string =
    let v0 : string = "!create_temp_path_"
    v0
and method86 (v0 : string, v1 : string) : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "&*$0"
    let v5 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "&*$0"
    let v7 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "&*$0"
    let v9 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v13 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v3 = v13 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v3 = v16 
    #endif
#else
    let v19 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v3 = v19 
    #endif
    let v22 : Ref<Str> = _run_target_args'_v3 
    (* run_target_args'
    let v27 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v28 : string = "String::from($0)"
    let v29 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v28 
    let _run_target_args'_v27 = v29 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v30 : string = "String::from($0)"
    let v31 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v30 
    let _run_target_args'_v27 = v31 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v32 : string = "String::from($0)"
    let v33 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v32 
    let _run_target_args'_v27 = v33 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v34 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v27 = v34 
    #endif
#if FABLE_COMPILER_PYTHON
    let v37 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v27 = v37 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v40 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v27 = v40 
    #endif
#else
    let v43 : std_string_String = v22 |> unbox<std_string_String>
    let _run_target_args'_v27 = v43 
    #endif
    let v46 : std_string_String = _run_target_args'_v27 
    (* run_target_args'
    let v51 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v52 : string = "std::path::PathBuf::from($0)"
    let v53 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v46 v52 
    let _run_target_args'_v51 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "std::path::PathBuf::from($0)"
    let v55 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v46 v54 
    let _run_target_args'_v51 = v55 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v56 : string = "std::path::PathBuf::from($0)"
    let v57 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v46 v56 
    let _run_target_args'_v51 = v57 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v58 : std_path_PathBuf = v46 |> unbox<std_path_PathBuf>
    let _run_target_args'_v51 = v58 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61 : std_path_PathBuf = v46 |> unbox<std_path_PathBuf>
    let _run_target_args'_v51 = v61 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_path_PathBuf = v46 |> unbox<std_path_PathBuf>
    let _run_target_args'_v51 = v64 
    #endif
#else
    let v67 : std_path_PathBuf = v46 |> unbox<std_path_PathBuf>
    let _run_target_args'_v51 = v67 
    #endif
    let v70 : std_path_PathBuf = _run_target_args'_v51 
    (* run_target_args'
    let v75 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v76 : string = "&*$0"
    let v77 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v76 
    let _run_target_args'_v75 = v77 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v78 : string = "&*$0"
    let v79 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v78 
    let _run_target_args'_v75 = v79 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v80 : string = "&*$0"
    let v81 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v80 
    let _run_target_args'_v75 = v81 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v82 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v75 = v82 
    #endif
#if FABLE_COMPILER_PYTHON
    let v85 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v75 = v85 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v88 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v75 = v88 
    #endif
#else
    let v91 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v75 = v91 
    #endif
    let v94 : Ref<Str> = _run_target_args'_v75 
    (* run_target_args'
    let v99 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v100 : string = "String::from($0)"
    let v101 : std_string_String = Fable.Core.RustInterop.emitRustExpr v94 v100 
    let _run_target_args'_v99 = v101 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v102 : string = "String::from($0)"
    let v103 : std_string_String = Fable.Core.RustInterop.emitRustExpr v94 v102 
    let _run_target_args'_v99 = v103 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v104 : string = "String::from($0)"
    let v105 : std_string_String = Fable.Core.RustInterop.emitRustExpr v94 v104 
    let _run_target_args'_v99 = v105 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v106 : std_string_String = v94 |> unbox<std_string_String>
    let _run_target_args'_v99 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v109 : std_string_String = v94 |> unbox<std_string_String>
    let _run_target_args'_v99 = v109 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v112 : std_string_String = v94 |> unbox<std_string_String>
    let _run_target_args'_v99 = v112 
    #endif
#else
    let v115 : std_string_String = v94 |> unbox<std_string_String>
    let _run_target_args'_v99 = v115 
    #endif
    let v118 : std_string_String = _run_target_args'_v99 
    let v123 : string = "$0.join($1)"
    let v124 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr struct (v70, v118) v123 
    (* run_target_args'
    let v125 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v126 : string = "$0.display()"
    let v127 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v124 v126 
    let _run_target_args'_v125 = v127 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v128 : string = "$0.display()"
    let v129 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v124 v128 
    let _run_target_args'_v125 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "$0.display()"
    let v131 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v124 v130 
    let _run_target_args'_v125 = v131 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v132 : std_path_Display = v124 |> unbox<std_path_Display>
    let _run_target_args'_v125 = v132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v135 : std_path_Display = v124 |> unbox<std_path_Display>
    let _run_target_args'_v125 = v135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : std_path_Display = v124 |> unbox<std_path_Display>
    let _run_target_args'_v125 = v138 
    #endif
#else
    let v141 : std_path_Display = v124 |> unbox<std_path_Display>
    let _run_target_args'_v125 = v141 
    #endif
    let v144 : std_path_Display = _run_target_args'_v125 
    (* run_target_args'
    let v149 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v150 : string = "format!(\"{}\", $0)"
    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v144 v150 
    let _run_target_args'_v149 = v151 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v152 : string = "format!(\"{}\", $0)"
    let v153 : std_string_String = Fable.Core.RustInterop.emitRustExpr v144 v152 
    let _run_target_args'_v149 = v153 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v154 : string = "format!(\"{}\", $0)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr v144 v154 
    let _run_target_args'_v149 = v155 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v156 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v149 = v156 
    #endif
#if FABLE_COMPILER_PYTHON
    let v159 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v149 = v159 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v162 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v149 = v162 
    #endif
#else
    let v165 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v149 = v165 
    #endif
    let v168 : std_string_String = _run_target_args'_v149 
    let v173 : string = "fable_library_rust::String_::fromString($0)"
    let v174 : string = Fable.Core.RustInterop.emitRustExpr v168 v173 
    let _run_target_args'_v2 = v174 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v175 : US3 = US3_1
    let v176 : US4 = US4_2(v175)
    let v177 : string = $"file_system.(</>) / target: {v176} / a: {v0} / b: {v1}"
    let v178 : string = failwith<string> v177
    let _run_target_args'_v2 = v178 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v179 : string = null |> unbox<string>
    let _run_target_args'_v2 = v179 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v182 : string = "path"
    let v183 : IPathJoin = Fable.Core.JsInterop.importAll v182 
    let v184 : string = "v183.join($0, $1)"
    let v185 : string = Fable.Core.JsInterop.emitJsExpr struct (v0, v1) v184 
    let _run_target_args'_v2 = v185 
    #endif
#if FABLE_COMPILER_PYTHON
    let v186 : US3 = US3_0
    let v187 : US4 = US4_4(v186)
    let v188 : string = $"file_system.(</>) / target: {v187} / a: {v0} / b: {v1}"
    let v189 : string = failwith<string> v188
    let _run_target_args'_v2 = v189 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v190 : US3 = US3_1
    let v191 : US4 = US4_0(v190)
    let v192 : string = $"file_system.(</>) / target: {v191} / a: {v0} / b: {v1}"
    let v193 : string = failwith<string> v192
    let _run_target_args'_v2 = v193 
    #endif
#else
    let v194 : string = System.IO.Path.Combine (v0, v1)
    let _run_target_args'_v2 = v194 
    #endif
    let v195 : string = _run_target_args'_v2 
    v195
and method88 () : string =
    let v0 : string = "CARGO_PKG_NAME"
    v0
and method87 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = method88()
    let v2 : string = method2(v1)
    let _run_target_args'_v0 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3 : string = method88()
    let v4 : string = method2(v3)
    let _run_target_args'_v0 = v4 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5 : string = method88()
    let v6 : string = method2(v5)
    let _run_target_args'_v0 = v6 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v7 : US3 = US3_0
    let v8 : US4 = US4_3(v7)
    let v9 : string = $"env.get_entry_assembly_name / target: {v8}"
    let v10 : string = failwith<string> v9
    let _run_target_args'_v0 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : US3 = US3_0
    let v12 : US4 = US4_4(v11)
    let v13 : string = $"env.get_entry_assembly_name / target: {v12}"
    let v14 : string = failwith<string> v13
    let _run_target_args'_v0 = v14 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : string = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
    let _run_target_args'_v0 = v15 
    #endif
#else
    let v16 : string = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
    let _run_target_args'_v0 = v16 
    #endif
    let v17 : string = _run_target_args'_v0 
    v17
and method83 (v0 : System.Guid) : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = method84()
    let v3 : string = method85()
    let v4 : string = method86(v2, v3)
    let v5 : string = method87()
    let v6 : string = method86(v4, v5)
    let v7 : (System.Guid -> string) = _.ToString()
    let v8 : string = v7 v0
    let v11 : string = method86(v6, v8)
    let _run_target_args'_v1 = v11 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : string = method84()
    let v13 : string = method85()
    let v14 : string = method86(v12, v13)
    let v15 : string = method87()
    let v16 : string = method86(v14, v15)
    let v17 : (System.Guid -> string) = _.ToString()
    let v18 : string = v17 v0
    let v21 : string = method86(v16, v18)
    let _run_target_args'_v1 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = null |> unbox<string>
    let _run_target_args'_v1 = v22 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v25 : string = method84()
    let v26 : string = method85()
    let v27 : string = method86(v25, v26)
    let v28 : string = method87()
    let v29 : string = method86(v27, v28)
    let v30 : (System.Guid -> string) = _.ToString()
    let v31 : string = v30 v0
    let v34 : string = method86(v29, v31)
    let _run_target_args'_v1 = v34 
    #endif
#if FABLE_COMPILER_PYTHON
    let v35 : string = method84()
    let v36 : string = method85()
    let v37 : string = method86(v35, v36)
    let v38 : string = method87()
    let v39 : string = method86(v37, v38)
    let v40 : (System.Guid -> string) = _.ToString()
    let v41 : string = v40 v0
    let v44 : string = method86(v39, v41)
    let _run_target_args'_v1 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : string = method84()
    let v46 : string = method85()
    let v47 : string = method86(v45, v46)
    let v48 : string = method87()
    let v49 : string = method86(v47, v48)
    let v50 : (System.Guid -> string) = _.ToString()
    let v51 : string = v50 v0
    let v54 : string = method86(v49, v51)
    let _run_target_args'_v1 = v54 
    #endif
#else
    let v55 : string = method84()
    let v56 : string = method85()
    let v57 : string = method86(v55, v56)
    let v58 : string = method87()
    let v59 : string = method86(v57, v58)
    let v60 : (System.Guid -> string) = _.ToString()
    let v61 : string = v60 v0
    let v64 : string = method86(v59, v61)
    let _run_target_args'_v1 = v64 
    #endif
    let v65 : string = _run_target_args'_v1 
    v65
and method77 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v1 = v3 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v1 = v4 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v7 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v1 = v7 
    #endif
#if FABLE_COMPILER_PYTHON
    let v8 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v1 = v8 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v9 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v1 = v9 
    #endif
#else
    let v10 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v1 = v10 
    #endif
    let v11 : System.DateTime = _run_target_args'_v1 
    let v16 : (unit -> System.Guid) = System.Guid.NewGuid
    let v17 : System.Guid = v16 ()
    let v20 : System.Guid = method78(v17, v11)
    let v21 : string = method83(v20)
    let _run_target_args'_v0 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v22 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v23 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v22 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v24 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v22 = v24 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v25 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v22 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v28 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v22 = v28 
    #endif
#if FABLE_COMPILER_PYTHON
    let v29 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v22 = v29 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v30 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v22 = v30 
    #endif
#else
    let v31 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v22 = v31 
    #endif
    let v32 : System.DateTime = _run_target_args'_v22 
    let v37 : (unit -> System.Guid) = System.Guid.NewGuid
    let v38 : System.Guid = v37 ()
    let v41 : System.Guid = method78(v38, v32)
    let v42 : string = method83(v41)
    let _run_target_args'_v0 = v42 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v43 : string = null |> unbox<string>
    let _run_target_args'_v0 = v43 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    (* run_target_args'
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v46 = v47 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v48 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v46 = v49 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v52 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_PYTHON
    let v53 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v46 = v53 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v54 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v46 = v54 
    #endif
#else
    let v55 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v46 = v55 
    #endif
    let v56 : System.DateTime = _run_target_args'_v46 
    let v61 : (unit -> System.Guid) = System.Guid.NewGuid
    let v62 : System.Guid = v61 ()
    let v65 : System.Guid = method78(v62, v56)
    let v66 : string = method83(v65)
    let _run_target_args'_v0 = v66 
    #endif
#if FABLE_COMPILER_PYTHON
    (* run_target_args'
    let v67 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v68 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v67 = v68 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v69 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v67 = v69 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v70 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v67 = v70 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v73 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v67 = v73 
    #endif
#if FABLE_COMPILER_PYTHON
    let v74 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v67 = v74 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v75 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v67 = v75 
    #endif
#else
    let v76 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v67 = v76 
    #endif
    let v77 : System.DateTime = _run_target_args'_v67 
    let v82 : (unit -> System.Guid) = System.Guid.NewGuid
    let v83 : System.Guid = v82 ()
    let v86 : System.Guid = method78(v83, v77)
    let v87 : string = method83(v86)
    let _run_target_args'_v0 = v87 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v88 = v89 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v90 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v88 = v91 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v94 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_PYTHON
    let v95 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v88 = v95 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v96 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v88 = v96 
    #endif
#else
    let v97 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v88 = v97 
    #endif
    let v98 : System.DateTime = _run_target_args'_v88 
    let v103 : (unit -> System.Guid) = System.Guid.NewGuid
    let v104 : System.Guid = v103 ()
    let v107 : System.Guid = method78(v104, v98)
    let v108 : string = method83(v107)
    let _run_target_args'_v0 = v108 
    #endif
#else
    (* run_target_args'
    let v109 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v110 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v109 = v110 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v111 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v109 = v111 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v112 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v109 = v112 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v115 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v109 = v115 
    #endif
#if FABLE_COMPILER_PYTHON
    let v116 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v109 = v116 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v109 = v117 
    #endif
#else
    let v118 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v109 = v118 
    #endif
    let v119 : System.DateTime = _run_target_args'_v109 
    let v124 : (unit -> System.Guid) = System.Guid.NewGuid
    let v125 : System.Guid = v124 ()
    let v128 : System.Guid = method78(v125, v119)
    let v129 : string = method83(v128)
    let _run_target_args'_v0 = v129 
    #endif
    let v130 : string = _run_target_args'_v0 
    v130
and closure36 () () : string =
    method77()
and closure39 () (v0 : std_io_Error) : std_string_String =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "format!(\"{}\", $0)"
    let v3 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v2 
    let _run_target_args'_v1 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : string = "format!(\"{}\", $0)"
    let v5 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v4 
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6 : string = "format!(\"{}\", $0)"
    let v7 : std_string_String = Fable.Core.RustInterop.emitRustExpr v0 v6 
    let _run_target_args'_v1 = v7 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v8 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v1 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v14 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v1 = v14 
    #endif
#else
    let v17 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v1 = v17 
    #endif
    let v20 : std_string_String = _run_target_args'_v1 
    v20
and method90 () : (std_io_Error -> std_string_String) =
    closure39()
and closure40 () () : US13 =
    US13_0
and method91 () : (unit -> US13) =
    closure40()
and closure41 () (v0 : std_string_String) : US13 =
    US13_1(v0)
and method92 () : (std_string_String -> US13) =
    closure41()
and method94 (v0 : string, v1 : std_string_String) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "dir"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "error"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    (* run_target_args'
    let v65 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v66 : string = "format!(\"{:#?}\", $0)"
    let v67 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v66 
    let v68 : string = "fable_library_rust::String_::fromString($0)"
    let v69 : string = Fable.Core.RustInterop.emitRustExpr v67 v68 
    let _run_target_args'_v65 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "format!(\"{:#?}\", $0)"
    let v71 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v70 
    let v72 : string = "fable_library_rust::String_::fromString($0)"
    let v73 : string = Fable.Core.RustInterop.emitRustExpr v71 v72 
    let _run_target_args'_v65 = v73 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v74 : string = "format!(\"{:#?}\", $0)"
    let v75 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v74 
    let v76 : string = "fable_library_rust::String_::fromString($0)"
    let v77 : string = Fable.Core.RustInterop.emitRustExpr v75 v76 
    let _run_target_args'_v65 = v77 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v78 : string = $"%A{v1}"
    let _run_target_args'_v65 = v78 
    #endif
#if FABLE_COMPILER_PYTHON
    let v81 : string = $"%A{v1}"
    let _run_target_args'_v65 = v81 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v84 : string = $"%A{v1}"
    let _run_target_args'_v65 = v84 
    #endif
#else
    let v87 : string = $"%A{v1}"
    let _run_target_args'_v65 = v87 
    #endif
    let v90 : string = _run_target_args'_v65 
    let v95 : string = $"{v90}"
    let v98 : unit = ()
    let v99 : (unit -> unit) = closure6(v3, v95)
    let v100 : unit = (fun () -> v99 (); v98) ()
    let v103 : string = " }"
    let v104 : string = $"{v103}"
    let v107 : unit = ()
    let v108 : (unit -> unit) = closure6(v3, v104)
    let v109 : unit = (fun () -> v108 (); v107) ()
    let v112 : string = v3.l0
    v112
and method93 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : std_string_String) : string =
    let v10 : string = method94(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "file_system.create_dir"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
and closure42 (v0 : string, v1 : std_string_String) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method47()
        let v40 : string = method93(v20, v21, v22, v23, v24, v25, v38, v39, v0, v1)
        method24(v40)
and method96 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v3 : string = "{ "
    let v4 : string = $"{v3}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure6(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = "dir"
    let v13 : string = $"{v12}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6(v2, v13)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v21 : string = " = "
    let v22 : string = $"{v21}"
    let v25 : unit = ()
    let v26 : (unit -> unit) = closure6(v2, v22)
    let v27 : unit = (fun () -> v26 (); v25) ()
    let v30 : string = $"{v0}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v2, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v38 : string = " }"
    let v39 : string = $"{v38}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v2, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : string = v2.l0
    v47
and method95 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method96(v8)
    let v10 : int64 = v0.l0
    let v11 : string = "file_system.create_dir"
    let v12 : string = $"{v6} {v7} #{v10} %s{v11} / {v9}"
    method23(v12)
and closure43 (v0 : string) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method11(v1)
    if v2 then
        let v3 : unit = ()
        let v4 : (unit -> unit) = closure0()
        let v5 : unit = (fun () -> v4 (); v3) ()
        let struct (v19 : Mut0, v20 : Mut1, v21 : Mut2, v22 : Mut3, v23 : Mut4, v24 : int64 option) = TraceState.trace_state.Value
        let v37 : string = method12(v19, v20, v21, v22, v23, v24)
        let v38 : string = method69()
        let v39 : string = method95(v19, v20, v21, v22, v23, v24, v37, v38, v0)
        method24(v39)
and closure44 (v0 : string) () : unit =
    let v1 : bool = true
    method9(v1, v0)
and method97 (v0 : string) : (unit -> unit) =
    closure44(v0)
and method98 (v0 : string) : (unit -> unit) =
    closure44(v0)
and method99 (v0 : string) : System_IO_DirectoryInfo =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v1 = v11 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v1 = v14 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v17 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v1 = v17 
    #endif
#else
    let v20 : (string -> System_IO_DirectoryInfo) = System.IO.Directory.CreateDirectory
    let v21 : System_IO_DirectoryInfo = v20 v0
    let _run_target_args'_v1 = v21 
    #endif
    let v22 : System_IO_DirectoryInfo = _run_target_args'_v1 
    v22
and method101 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "dir"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "result"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v65 : string = $"{v1}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v3, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v73 : string = " }"
    let v74 : string = $"{v73}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v3, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = v3.l0
    v82
and method100 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method101(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "file_system.create_dir"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
and closure45 (v0 : string, v1 : string) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method16()
        let v40 : string = method100(v20, v21, v22, v23, v24, v25, v38, v39, v0, v1)
        method24(v40)
and closure46 (v0 : string) () : unit =
    let v1 : Async<int64> = method6(v0)
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<unit> = null |> unbox<Async<unit>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v13 : Async<unit> = v12 v1
    let _run_target_args'_v2 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v15 : Async<unit> = v14 v1
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v17 : Async<unit> = v16 v1
    let _run_target_args'_v2 = v17 
    #endif
#else
    let v18 : (Async<int64> -> Async<unit>) = Async.Ignore
    let v19 : Async<unit> = v18 v1
    let _run_target_args'_v2 = v19 
    #endif
    let v20 : Async<unit> = _run_target_args'_v2 
    (* run_target_args'
    let v25 : unit = ()
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
    let v26 : (Async<unit> -> unit) = Async.RunSynchronously
    v26 v20
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : (Async<unit> -> unit) = Async.RunSynchronously
    v27 v20
    #endif
#else
    let v28 : (Async<unit> -> unit) = Async.RunSynchronously
    v28 v20
    #endif
    // run_target_args' is_unit
    ()
and method102 (v0 : string) : (unit -> unit) =
    closure46(v0)
and method103 (v0 : string) : (unit -> unit) =
    closure46(v0)
and method89 (v0 : string) : System.IDisposable =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "std::fs::create_dir_all(&*$0)"
    let v3 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v2 
    let v4 : (std_io_Error -> std_string_String) = method90()
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = "$0.map_err(|x| $1(x))"
    let v7 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v3, v4) v6 
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : string = "$0.map_err(|x| $1(x))"
    let v9 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v3, v4) v8 
    let _run_target_args'_v5 = v9 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : string = "$0.map_err(|x| $1(x))"
    let v11 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v3, v4) v10 
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : Result<unit, std_string_String> = match v3 with Ok x -> Ok x | Error x -> Error (v4 x)
    let _run_target_args'_v5 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v13 : Result<unit, std_string_String> = match v3 with Ok x -> Ok x | Error x -> Error (v4 x)
    let _run_target_args'_v5 = v13 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v14 : Result<unit, std_string_String> = match v3 with Ok x -> Ok x | Error x -> Error (v4 x)
    let _run_target_args'_v5 = v14 
    #endif
#else
    let v15 : Result<unit, std_string_String> = match v3 with Ok x -> Ok x | Error x -> Error (v4 x)
    let _run_target_args'_v5 = v15 
    #endif
    let v16 : Result<unit, std_string_String> = _run_target_args'_v5 
    let v19 : (unit -> US13) = method91()
    let v20 : (std_string_String -> US13) = method92()
    let v21 : US13 = match v16 with Ok () -> v19 () | Error x -> v20 x
    match v21 with
    | US13_1(v64) -> (* Error *)
        let v65 : unit = ()
        let v66 : (unit -> unit) = closure42(v0, v64)
        let v67 : unit = (fun () -> v66 (); v65) ()
        ()
    | US13_0 -> (* Ok *)
        let v22 : unit = ()
        let v23 : (unit -> unit) = closure43(v0)
        let v24 : unit = (fun () -> v23 (); v22) ()
        ()
    (* run_target_args'
    let v107 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v108 : (unit -> unit) = method97(v0)
    let v109 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v108 "$0()" )
    let _run_target_args'_v107 = v109 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v110 : (unit -> unit) = method97(v0)
    let v111 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v110 "$0()" )
    let _run_target_args'_v107 = v111 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v112 : (unit -> unit) = method97(v0)
    let v113 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v112 "$0()" )
    let _run_target_args'_v107 = v113 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v114 : (unit -> unit) = method98(v0)
    let v115 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v114 () }
    let _run_target_args'_v107 = v115 
    #endif
#if FABLE_COMPILER_PYTHON
    let v116 : (unit -> unit) = method98(v0)
    let v117 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v116 () }
    let _run_target_args'_v107 = v117 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v118 : (unit -> unit) = method98(v0)
    let v119 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v118 () }
    let _run_target_args'_v107 = v119 
    #endif
#else
    let v120 : (unit -> unit) = method98(v0)
    let v121 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v120 () }
    let _run_target_args'_v107 = v121 
    #endif
    let v122 : System.IDisposable = _run_target_args'_v107 
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v126 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v1 = v126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v129 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v1 = v129 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v132 : System_IO_DirectoryInfo = method99(v0)
    (* run_target_args'
    let v133 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v134 : bool = null |> unbox<bool>
    let _run_target_args'_v133 = v134 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v137 : bool = null |> unbox<bool>
    let _run_target_args'_v133 = v137 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v140 : bool = null |> unbox<bool>
    let _run_target_args'_v133 = v140 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v143 : bool = null |> unbox<bool>
    let _run_target_args'_v133 = v143 
    #endif
#if FABLE_COMPILER_PYTHON
    let v146 : bool = null |> unbox<bool>
    let _run_target_args'_v133 = v146 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v149 : bool = null |> unbox<bool>
    let _run_target_args'_v133 = v149 
    #endif
#else
    let v152 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v153 : bool = v152 v132
    let _run_target_args'_v133 = v153 
    #endif
    let v154 : bool = _run_target_args'_v133 
    let v159 : bool = v154 = false
    if v159 then
        (* run_target_args'
        let v160 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v161 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v160 = v161 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v164 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v160 = v164 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v167 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v160 = v167 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v170 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v160 = v170 
        #endif
#if FABLE_COMPILER_PYTHON
        let v173 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v160 = v173 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v176 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v160 = v176 
        #endif
#else
        let v179 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v180 : System.DateTime = v179 v132
        let _run_target_args'_v160 = v180 
        #endif
        let v181 : System.DateTime = _run_target_args'_v160 
        let v186 : _ = {| Exists = v154; CreationTime = v181 |}
        let v187 : string = $"%A{v186}"
        let v190 : unit = ()
        let v191 : (unit -> unit) = closure45(v0, v187)
        let v192 : unit = (fun () -> v191 (); v190) ()
        ()
    (* run_target_args'
    let v232 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v233 : (unit -> unit) = method102(v0)
    let v234 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v233 "$0()" )
    let _run_target_args'_v232 = v234 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v235 : (unit -> unit) = method102(v0)
    let v236 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v235 "$0()" )
    let _run_target_args'_v232 = v236 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v237 : (unit -> unit) = method102(v0)
    let v238 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v237 "$0()" )
    let _run_target_args'_v232 = v238 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v239 : (unit -> unit) = method103(v0)
    let v240 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v239 () }
    let _run_target_args'_v232 = v240 
    #endif
#if FABLE_COMPILER_PYTHON
    let v241 : (unit -> unit) = method103(v0)
    let v242 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v241 () }
    let _run_target_args'_v232 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v243 : (unit -> unit) = method103(v0)
    let v244 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v243 () }
    let _run_target_args'_v232 = v244 
    #endif
#else
    let v245 : (unit -> unit) = method103(v0)
    let v246 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v245 () }
    let _run_target_args'_v232 = v246 
    #endif
    let v247 : System.IDisposable = _run_target_args'_v232 
    let _run_target_args'_v1 = v247 
    #endif
#if FABLE_COMPILER_PYTHON
    let v251 : System_IO_DirectoryInfo = method99(v0)
    (* run_target_args'
    let v252 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v253 : bool = null |> unbox<bool>
    let _run_target_args'_v252 = v253 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v256 : bool = null |> unbox<bool>
    let _run_target_args'_v252 = v256 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v259 : bool = null |> unbox<bool>
    let _run_target_args'_v252 = v259 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v262 : bool = null |> unbox<bool>
    let _run_target_args'_v252 = v262 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : bool = null |> unbox<bool>
    let _run_target_args'_v252 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v268 : bool = null |> unbox<bool>
    let _run_target_args'_v252 = v268 
    #endif
#else
    let v271 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v272 : bool = v271 v251
    let _run_target_args'_v252 = v272 
    #endif
    let v273 : bool = _run_target_args'_v252 
    let v278 : bool = v273 = false
    if v278 then
        (* run_target_args'
        let v279 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v280 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v279 = v280 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v283 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v279 = v283 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v286 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v279 = v286 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v289 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v279 = v289 
        #endif
#if FABLE_COMPILER_PYTHON
        let v292 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v279 = v292 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v295 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v279 = v295 
        #endif
#else
        let v298 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v299 : System.DateTime = v298 v251
        let _run_target_args'_v279 = v299 
        #endif
        let v300 : System.DateTime = _run_target_args'_v279 
        let v305 : _ = {| Exists = v273; CreationTime = v300 |}
        let v306 : string = $"%A{v305}"
        let v309 : unit = ()
        let v310 : (unit -> unit) = closure45(v0, v306)
        let v311 : unit = (fun () -> v310 (); v309) ()
        ()
    (* run_target_args'
    let v351 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v352 : (unit -> unit) = method102(v0)
    let v353 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v352 "$0()" )
    let _run_target_args'_v351 = v353 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v354 : (unit -> unit) = method102(v0)
    let v355 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v354 "$0()" )
    let _run_target_args'_v351 = v355 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v356 : (unit -> unit) = method102(v0)
    let v357 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v356 "$0()" )
    let _run_target_args'_v351 = v357 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v358 : (unit -> unit) = method103(v0)
    let v359 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v358 () }
    let _run_target_args'_v351 = v359 
    #endif
#if FABLE_COMPILER_PYTHON
    let v360 : (unit -> unit) = method103(v0)
    let v361 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v360 () }
    let _run_target_args'_v351 = v361 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v362 : (unit -> unit) = method103(v0)
    let v363 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v362 () }
    let _run_target_args'_v351 = v363 
    #endif
#else
    let v364 : (unit -> unit) = method103(v0)
    let v365 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v364 () }
    let _run_target_args'_v351 = v365 
    #endif
    let v366 : System.IDisposable = _run_target_args'_v351 
    let _run_target_args'_v1 = v366 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v370 : System_IO_DirectoryInfo = method99(v0)
    (* run_target_args'
    let v371 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v372 : bool = null |> unbox<bool>
    let _run_target_args'_v371 = v372 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v375 : bool = null |> unbox<bool>
    let _run_target_args'_v371 = v375 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v378 : bool = null |> unbox<bool>
    let _run_target_args'_v371 = v378 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v381 : bool = null |> unbox<bool>
    let _run_target_args'_v371 = v381 
    #endif
#if FABLE_COMPILER_PYTHON
    let v384 : bool = null |> unbox<bool>
    let _run_target_args'_v371 = v384 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v387 : bool = null |> unbox<bool>
    let _run_target_args'_v371 = v387 
    #endif
#else
    let v390 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v391 : bool = v390 v370
    let _run_target_args'_v371 = v391 
    #endif
    let v392 : bool = _run_target_args'_v371 
    let v397 : bool = v392 = false
    if v397 then
        (* run_target_args'
        let v398 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v399 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v398 = v399 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v402 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v398 = v402 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v405 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v398 = v405 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v408 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v398 = v408 
        #endif
#if FABLE_COMPILER_PYTHON
        let v411 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v398 = v411 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v414 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v398 = v414 
        #endif
#else
        let v417 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v418 : System.DateTime = v417 v370
        let _run_target_args'_v398 = v418 
        #endif
        let v419 : System.DateTime = _run_target_args'_v398 
        let v424 : _ = {| Exists = v392; CreationTime = v419 |}
        let v425 : string = $"%A{v424}"
        let v428 : unit = ()
        let v429 : (unit -> unit) = closure45(v0, v425)
        let v430 : unit = (fun () -> v429 (); v428) ()
        ()
    (* run_target_args'
    let v470 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v471 : (unit -> unit) = method102(v0)
    let v472 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v471 "$0()" )
    let _run_target_args'_v470 = v472 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v473 : (unit -> unit) = method102(v0)
    let v474 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v473 "$0()" )
    let _run_target_args'_v470 = v474 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v475 : (unit -> unit) = method102(v0)
    let v476 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v475 "$0()" )
    let _run_target_args'_v470 = v476 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v477 : (unit -> unit) = method103(v0)
    let v478 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v477 () }
    let _run_target_args'_v470 = v478 
    #endif
#if FABLE_COMPILER_PYTHON
    let v479 : (unit -> unit) = method103(v0)
    let v480 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v479 () }
    let _run_target_args'_v470 = v480 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v481 : (unit -> unit) = method103(v0)
    let v482 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v481 () }
    let _run_target_args'_v470 = v482 
    #endif
#else
    let v483 : (unit -> unit) = method103(v0)
    let v484 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v483 () }
    let _run_target_args'_v470 = v484 
    #endif
    let v485 : System.IDisposable = _run_target_args'_v470 
    let _run_target_args'_v1 = v485 
    #endif
#else
    let v489 : System_IO_DirectoryInfo = method99(v0)
    (* run_target_args'
    let v490 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v491 : bool = null |> unbox<bool>
    let _run_target_args'_v490 = v491 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v494 : bool = null |> unbox<bool>
    let _run_target_args'_v490 = v494 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v497 : bool = null |> unbox<bool>
    let _run_target_args'_v490 = v497 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v500 : bool = null |> unbox<bool>
    let _run_target_args'_v490 = v500 
    #endif
#if FABLE_COMPILER_PYTHON
    let v503 : bool = null |> unbox<bool>
    let _run_target_args'_v490 = v503 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v506 : bool = null |> unbox<bool>
    let _run_target_args'_v490 = v506 
    #endif
#else
    let v509 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v510 : bool = v509 v489
    let _run_target_args'_v490 = v510 
    #endif
    let v511 : bool = _run_target_args'_v490 
    let v516 : bool = v511 = false
    if v516 then
        (* run_target_args'
        let v517 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v518 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v517 = v518 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v521 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v517 = v521 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v524 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v517 = v524 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v527 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v517 = v527 
        #endif
#if FABLE_COMPILER_PYTHON
        let v530 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v517 = v530 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v533 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v517 = v533 
        #endif
#else
        let v536 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v537 : System.DateTime = v536 v489
        let _run_target_args'_v517 = v537 
        #endif
        let v538 : System.DateTime = _run_target_args'_v517 
        let v543 : _ = {| Exists = v511; CreationTime = v538 |}
        let v544 : string = $"%A{v543}"
        let v547 : unit = ()
        let v548 : (unit -> unit) = closure45(v0, v544)
        let v549 : unit = (fun () -> v548 (); v547) ()
        ()
    (* run_target_args'
    let v589 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v590 : (unit -> unit) = method102(v0)
    let v591 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v590 "$0()" )
    let _run_target_args'_v589 = v591 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v592 : (unit -> unit) = method102(v0)
    let v593 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v592 "$0()" )
    let _run_target_args'_v589 = v593 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v594 : (unit -> unit) = method102(v0)
    let v595 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v594 "$0()" )
    let _run_target_args'_v589 = v595 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v596 : (unit -> unit) = method103(v0)
    let v597 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v596 () }
    let _run_target_args'_v589 = v597 
    #endif
#if FABLE_COMPILER_PYTHON
    let v598 : (unit -> unit) = method103(v0)
    let v599 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v598 () }
    let _run_target_args'_v589 = v599 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v600 : (unit -> unit) = method103(v0)
    let v601 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v600 () }
    let _run_target_args'_v589 = v601 
    #endif
#else
    let v602 : (unit -> unit) = method103(v0)
    let v603 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v602 () }
    let _run_target_args'_v589 = v603 
    #endif
    let v604 : System.IDisposable = _run_target_args'_v589 
    let _run_target_args'_v1 = v604 
    #endif
    let v608 : System.IDisposable = _run_target_args'_v1 
    v608
and closure38 () () : struct (string * System.IDisposable) =
    let v0 : string = method77()
    let v1 : System.IDisposable = method89(v0)
    struct (v0, v1)
and closure48 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method105(v0, v1, v5)
        let v7 : string = v3 + v1 
        v6 v7
and method105 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure48(v0, v1, v2)
and method104 (v0 : string) : System.Guid =
    let v1 : (char -> string) = _.ToString()
    let v2 : string = v1 '0'
    let v5 : int32 = v0.Length
    let v6 : int32 = 32 - v5
    let v7 : int32 = 0
    let v8 : (string -> string) = method105(v6, v2, v7)
    let v9 : string = ""
    let v10 : string = v8 v9
    let v11 : string = v10 + v0 
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : int32 = 0 |> int32 
    let v20 : int32 = 8 |> int32 
    let v27 : int32 = v20 - 1
    let v28 : string = v11.[int v13..int v27]
    let v32 : int32 = 8 |> int32 
    let v39 : int32 = 12 |> int32 
    let v46 : int32 = v39 - 1
    let v47 : string = v11.[int v32..int v46]
    let v51 : int32 = 12 |> int32 
    let v58 : int32 = 16 |> int32 
    let v65 : int32 = v58 - 1
    let v66 : string = v11.[int v51..int v65]
    let v70 : int32 = 16 |> int32 
    let v77 : int32 = 20 |> int32 
    let v84 : int32 = v77 - 1
    let v85 : string = v11.[int v70..int v84]
    let v89 : int32 = 20 |> int32 
    let v96 : int32 = 32 |> int32 
    let v103 : int32 = v96 - 1
    let v104 : string = v11.[int v89..int v103]
    let v108 : string = $"{v28}-{v47}-{v66}-{v85}-{v104}"
    (* run_target_args'
    let v109 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v110 : System.Guid = v108 |> System.Guid 
    let _run_target_args'_v109 = v110 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v113 : System.Guid = v108 |> System.Guid 
    let _run_target_args'_v109 = v113 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v116 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v109 = v116 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v119 : System.Guid = v108 |> System.Guid 
    let _run_target_args'_v109 = v119 
    #endif
#if FABLE_COMPILER_PYTHON
    let v122 : System.Guid = v108 |> System.Guid 
    let _run_target_args'_v109 = v122 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v125 : System.Guid = v108 |> System.Guid 
    let _run_target_args'_v109 = v125 
    #endif
#else
    let v128 : System.Guid = v108 |> System.Guid 
    let _run_target_args'_v109 = v128 
    #endif
    let v131 : System.Guid = _run_target_args'_v109 
    let _run_target_args'_v12 = v131 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v136 : int32 = 0 |> int32 
    let v143 : int32 = 8 |> int32 
    let v150 : int32 = v143 - 1
    let v151 : string = v11.[int v136..int v150]
    let v155 : int32 = 8 |> int32 
    let v162 : int32 = 12 |> int32 
    let v169 : int32 = v162 - 1
    let v170 : string = v11.[int v155..int v169]
    let v174 : int32 = 12 |> int32 
    let v181 : int32 = 16 |> int32 
    let v188 : int32 = v181 - 1
    let v189 : string = v11.[int v174..int v188]
    let v193 : int32 = 16 |> int32 
    let v200 : int32 = 20 |> int32 
    let v207 : int32 = v200 - 1
    let v208 : string = v11.[int v193..int v207]
    let v212 : int32 = 20 |> int32 
    let v219 : int32 = 32 |> int32 
    let v226 : int32 = v219 - 1
    let v227 : string = v11.[int v212..int v226]
    let v231 : string = $"{v151}-{v170}-{v189}-{v208}-{v227}"
    (* run_target_args'
    let v232 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v233 : System.Guid = v231 |> System.Guid 
    let _run_target_args'_v232 = v233 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v236 : System.Guid = v231 |> System.Guid 
    let _run_target_args'_v232 = v236 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v239 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v232 = v239 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v242 : System.Guid = v231 |> System.Guid 
    let _run_target_args'_v232 = v242 
    #endif
#if FABLE_COMPILER_PYTHON
    let v245 : System.Guid = v231 |> System.Guid 
    let _run_target_args'_v232 = v245 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v248 : System.Guid = v231 |> System.Guid 
    let _run_target_args'_v232 = v248 
    #endif
#else
    let v251 : System.Guid = v231 |> System.Guid 
    let _run_target_args'_v232 = v251 
    #endif
    let v254 : System.Guid = _run_target_args'_v232 
    let _run_target_args'_v12 = v254 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v259 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v12 = v259 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v262 : int32 = 0 |> int32 
    let v269 : int32 = 8 |> int32 
    let v276 : int32 = v269 - 1
    let v277 : string = v11.[int v262..int v276]
    let v281 : int32 = 8 |> int32 
    let v288 : int32 = 12 |> int32 
    let v295 : int32 = v288 - 1
    let v296 : string = v11.[int v281..int v295]
    let v300 : int32 = 12 |> int32 
    let v307 : int32 = 16 |> int32 
    let v314 : int32 = v307 - 1
    let v315 : string = v11.[int v300..int v314]
    let v319 : int32 = 16 |> int32 
    let v326 : int32 = 20 |> int32 
    let v333 : int32 = v326 - 1
    let v334 : string = v11.[int v319..int v333]
    let v338 : int32 = 20 |> int32 
    let v345 : int32 = 32 |> int32 
    let v352 : int32 = v345 - 1
    let v353 : string = v11.[int v338..int v352]
    let v357 : string = $"{v277}-{v296}-{v315}-{v334}-{v353}"
    (* run_target_args'
    let v358 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v359 : System.Guid = v357 |> System.Guid 
    let _run_target_args'_v358 = v359 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v362 : System.Guid = v357 |> System.Guid 
    let _run_target_args'_v358 = v362 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v365 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v358 = v365 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v368 : System.Guid = v357 |> System.Guid 
    let _run_target_args'_v358 = v368 
    #endif
#if FABLE_COMPILER_PYTHON
    let v371 : System.Guid = v357 |> System.Guid 
    let _run_target_args'_v358 = v371 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v374 : System.Guid = v357 |> System.Guid 
    let _run_target_args'_v358 = v374 
    #endif
#else
    let v377 : System.Guid = v357 |> System.Guid 
    let _run_target_args'_v358 = v377 
    #endif
    let v380 : System.Guid = _run_target_args'_v358 
    let _run_target_args'_v12 = v380 
    #endif
#if FABLE_COMPILER_PYTHON
    let v385 : int32 = 0 |> int32 
    let v392 : int32 = 8 |> int32 
    let v399 : int32 = v392 - 1
    let v400 : string = v11.[int v385..int v399]
    let v404 : int32 = 8 |> int32 
    let v411 : int32 = 12 |> int32 
    let v418 : int32 = v411 - 1
    let v419 : string = v11.[int v404..int v418]
    let v423 : int32 = 12 |> int32 
    let v430 : int32 = 16 |> int32 
    let v437 : int32 = v430 - 1
    let v438 : string = v11.[int v423..int v437]
    let v442 : int32 = 16 |> int32 
    let v449 : int32 = 20 |> int32 
    let v456 : int32 = v449 - 1
    let v457 : string = v11.[int v442..int v456]
    let v461 : int32 = 20 |> int32 
    let v468 : int32 = 32 |> int32 
    let v475 : int32 = v468 - 1
    let v476 : string = v11.[int v461..int v475]
    let v480 : string = $"{v400}-{v419}-{v438}-{v457}-{v476}"
    (* run_target_args'
    let v481 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v482 : System.Guid = v480 |> System.Guid 
    let _run_target_args'_v481 = v482 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v485 : System.Guid = v480 |> System.Guid 
    let _run_target_args'_v481 = v485 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v488 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v481 = v488 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v491 : System.Guid = v480 |> System.Guid 
    let _run_target_args'_v481 = v491 
    #endif
#if FABLE_COMPILER_PYTHON
    let v494 : System.Guid = v480 |> System.Guid 
    let _run_target_args'_v481 = v494 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v497 : System.Guid = v480 |> System.Guid 
    let _run_target_args'_v481 = v497 
    #endif
#else
    let v500 : System.Guid = v480 |> System.Guid 
    let _run_target_args'_v481 = v500 
    #endif
    let v503 : System.Guid = _run_target_args'_v481 
    let _run_target_args'_v12 = v503 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v508 : int32 = 0 |> int32 
    let v515 : int32 = 8 |> int32 
    let v522 : int32 = v515 - 1
    let v523 : string = v11.[int v508..int v522]
    let v527 : int32 = 8 |> int32 
    let v534 : int32 = 12 |> int32 
    let v541 : int32 = v534 - 1
    let v542 : string = v11.[int v527..int v541]
    let v546 : int32 = 12 |> int32 
    let v553 : int32 = 16 |> int32 
    let v560 : int32 = v553 - 1
    let v561 : string = v11.[int v546..int v560]
    let v565 : int32 = 16 |> int32 
    let v572 : int32 = 20 |> int32 
    let v579 : int32 = v572 - 1
    let v580 : string = v11.[int v565..int v579]
    let v584 : int32 = 20 |> int32 
    let v591 : int32 = 32 |> int32 
    let v598 : int32 = v591 - 1
    let v599 : string = v11.[int v584..int v598]
    let v603 : string = $"{v523}-{v542}-{v561}-{v580}-{v599}"
    (* run_target_args'
    let v604 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v605 : System.Guid = v603 |> System.Guid 
    let _run_target_args'_v604 = v605 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v608 : System.Guid = v603 |> System.Guid 
    let _run_target_args'_v604 = v608 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v611 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v604 = v611 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v614 : System.Guid = v603 |> System.Guid 
    let _run_target_args'_v604 = v614 
    #endif
#if FABLE_COMPILER_PYTHON
    let v617 : System.Guid = v603 |> System.Guid 
    let _run_target_args'_v604 = v617 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v620 : System.Guid = v603 |> System.Guid 
    let _run_target_args'_v604 = v620 
    #endif
#else
    let v623 : System.Guid = v603 |> System.Guid 
    let _run_target_args'_v604 = v623 
    #endif
    let v626 : System.Guid = _run_target_args'_v604 
    let _run_target_args'_v12 = v626 
    #endif
#else
    let v631 : int32 = 0 |> int32 
    let v638 : int32 = 8 |> int32 
    let v645 : int32 = v638 - 1
    let v646 : string = v11.[int v631..int v645]
    let v650 : int32 = 8 |> int32 
    let v657 : int32 = 12 |> int32 
    let v664 : int32 = v657 - 1
    let v665 : string = v11.[int v650..int v664]
    let v669 : int32 = 12 |> int32 
    let v676 : int32 = 16 |> int32 
    let v683 : int32 = v676 - 1
    let v684 : string = v11.[int v669..int v683]
    let v688 : int32 = 16 |> int32 
    let v695 : int32 = 20 |> int32 
    let v702 : int32 = v695 - 1
    let v703 : string = v11.[int v688..int v702]
    let v707 : int32 = 20 |> int32 
    let v714 : int32 = 32 |> int32 
    let v721 : int32 = v714 - 1
    let v722 : string = v11.[int v707..int v721]
    let v726 : string = $"{v646}-{v665}-{v684}-{v703}-{v722}"
    (* run_target_args'
    let v727 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v728 : System.Guid = v726 |> System.Guid 
    let _run_target_args'_v727 = v728 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v731 : System.Guid = v726 |> System.Guid 
    let _run_target_args'_v727 = v731 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v734 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v727 = v734 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v737 : System.Guid = v726 |> System.Guid 
    let _run_target_args'_v727 = v737 
    #endif
#if FABLE_COMPILER_PYTHON
    let v740 : System.Guid = v726 |> System.Guid 
    let _run_target_args'_v727 = v740 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v743 : System.Guid = v726 |> System.Guid 
    let _run_target_args'_v727 = v743 
    #endif
#else
    let v746 : System.Guid = v726 |> System.Guid 
    let _run_target_args'_v727 = v746 
    #endif
    let v749 : System.Guid = _run_target_args'_v727 
    let _run_target_args'_v12 = v749 
    #endif
    let v754 : System.Guid = _run_target_args'_v12 
    v754
and closure47 () (v0 : string) : struct (string * System.IDisposable) =
    let v1 : System.Guid = method104(v0)
    let v2 : string = method83(v1)
    let v3 : System.IDisposable = method89(v2)
    struct (v2, v3)
and closure49 () () : string =
    let v0 : string = __SOURCE_DIRECTORY__
    v0
and closure51 () (v0 : std_path_PathBuf) : US14 =
    US14_0(v0)
and method109 () : (std_path_PathBuf -> US14) =
    closure51()
and closure52 () (v0 : string) : US14 =
    US14_1(v0)
and method110 () : (string -> US14) =
    closure52()
and method113 (v0 : string) : string option =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "&*$0"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let _run_target_args'_v2 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : string = "&*$0"
    let v6 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v5 
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7 : string = "&*$0"
    let v8 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let _run_target_args'_v2 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v9 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v12 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v15 
    #endif
#else
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v18 
    #endif
    let v21 : Ref<Str> = _run_target_args'_v2 
    (* run_target_args'
    let v26 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v27 : string = "String::from($0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v27 
    let _run_target_args'_v26 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = "String::from($0)"
    let v30 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v29 
    let _run_target_args'_v26 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "String::from($0)"
    let v32 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v31 
    let _run_target_args'_v26 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v33 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v36 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v39 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v39 
    #endif
#else
    let v42 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v42 
    #endif
    let v45 : std_string_String = _run_target_args'_v26 
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = "std::path::PathBuf::from($0)"
    let v52 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v51 
    let _run_target_args'_v50 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : string = "std::path::PathBuf::from($0)"
    let v54 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v53 
    let _run_target_args'_v50 = v54 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v55 : string = "std::path::PathBuf::from($0)"
    let v56 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v55 
    let _run_target_args'_v50 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v57 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v57 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v63 
    #endif
#else
    let v66 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v66 
    #endif
    let v69 : std_path_PathBuf = _run_target_args'_v50 
    let v74 : string = "$0.parent().map(std::path::PathBuf::from)"
    let v75 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v69 v74 
    let v76 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v77 : bool = Fable.Core.RustInterop.emitRustExpr v75 v76 
    let v78 : string = "x"
    let v79 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr () v78 
    (* run_target_args'
    let v80 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v81 : string = "$0.display()"
    let v82 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v79 v81 
    let _run_target_args'_v80 = v82 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v83 : string = "$0.display()"
    let v84 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v79 v83 
    let _run_target_args'_v80 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v85 : string = "$0.display()"
    let v86 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v79 v85 
    let _run_target_args'_v80 = v86 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v87 : std_path_Display = v79 |> unbox<std_path_Display>
    let _run_target_args'_v80 = v87 
    #endif
#if FABLE_COMPILER_PYTHON
    let v90 : std_path_Display = v79 |> unbox<std_path_Display>
    let _run_target_args'_v80 = v90 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v93 : std_path_Display = v79 |> unbox<std_path_Display>
    let _run_target_args'_v80 = v93 
    #endif
#else
    let v96 : std_path_Display = v79 |> unbox<std_path_Display>
    let _run_target_args'_v80 = v96 
    #endif
    let v99 : std_path_Display = _run_target_args'_v80 
    (* run_target_args'
    let v104 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v105 : string = "format!(\"{}\", $0)"
    let v106 : std_string_String = Fable.Core.RustInterop.emitRustExpr v99 v105 
    let _run_target_args'_v104 = v106 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v107 : string = "format!(\"{}\", $0)"
    let v108 : std_string_String = Fable.Core.RustInterop.emitRustExpr v99 v107 
    let _run_target_args'_v104 = v108 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v109 : string = "format!(\"{}\", $0)"
    let v110 : std_string_String = Fable.Core.RustInterop.emitRustExpr v99 v109 
    let _run_target_args'_v104 = v110 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v111 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v104 = v111 
    #endif
#if FABLE_COMPILER_PYTHON
    let v114 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v104 = v114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v104 = v117 
    #endif
#else
    let v120 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v104 = v120 
    #endif
    let v123 : std_string_String = _run_target_args'_v104 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v123 v128 
    let v130 : string = "true; $0 })"
    let v131 : bool = Fable.Core.RustInterop.emitRustExpr v129 v130 
    let v132 : string = "_optionm_map_"
    let v133 : string option = Fable.Core.RustInterop.emitRustExpr () v132 
    let _run_target_args'_v1 = v133 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v134 : string option = None
    let _run_target_args'_v1 = v134 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v135 : string option = None
    let _run_target_args'_v1 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "path"
    let v137 : IPathDirname = Fable.Core.JsInterop.importAll v136 
    let v138 : string = "v137.dirname($0)"
    let v139 : string = Fable.Core.JsInterop.emitJsExpr v0 v138 
    let v140 : string option = Some v139 
    let _run_target_args'_v1 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v143 : string option = None
    let _run_target_args'_v1 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string option = None
    let _run_target_args'_v1 = v144 
    #endif
#else
    let v145 : (string -> System_IO_DirectoryInfo) = System.IO.Directory.GetParent
    let v146 : System_IO_DirectoryInfo = v145 v0
    let v147 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let v150 : bool = v146 = v147 
    let v181 : US5 =
        if v150 then
            US5_1
        else
            (* run_target_args'
            let v154 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v155 : string = null |> unbox<string>
            let _run_target_args'_v154 = v155 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v158 : string = null |> unbox<string>
            let _run_target_args'_v154 = v158 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v161 : string = null |> unbox<string>
            let _run_target_args'_v154 = v161 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v164 : string = null |> unbox<string>
            let _run_target_args'_v154 = v164 
            #endif
#if FABLE_COMPILER_PYTHON
            let v167 : string = null |> unbox<string>
            let _run_target_args'_v154 = v167 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v170 : string = null |> unbox<string>
            let _run_target_args'_v154 = v170 
            #endif
#else
            let v173 : (System_IO_DirectoryInfo -> string) = _.FullName
            let v174 : string = v173 v146
            let _run_target_args'_v154 = v174 
            #endif
            let v175 : string = _run_target_args'_v154 
            US5_0(v175)
    let v188 : string option =
        match v181 with
        | US5_1 -> (* None *)
            let v186 : string option = None
            v186
        | US5_0(v182) -> (* Some *)
            let v183 : string option = Some v182 
            v183
    let _run_target_args'_v1 = v188 
    #endif
    let v189 : string option = _run_target_args'_v1 
    v189
and method114 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v3 : string = $"{v0}"
    let v6 : unit = ()
    let v7 : (unit -> unit) = closure6(v2, v3)
    let v8 : unit = (fun () -> v7 (); v6) ()
    let v11 : string = v2.l0
    v11
and method112 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method20(v4)
    let v6 : string option = method113(v4)
    let v7 : (string -> US5) = method5()
    let v8 : US5 option = v6 |> Option.map v7 
    let v19 : US5 = US5_1
    let v20 : US5 = v8 |> Option.defaultValue v19 
    let v24 : string = method114(v3)
    let v25 : bool = v2 >= 11uy
    if v25 then
        let v26 : string = $"file_system.read_link / "
        let v27 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v28 : string = v26 + v27 
        (* run_target_args'
        let v29 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v30 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v31 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v28 v30 
        let _run_target_args'_v29 = v31 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v32 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v33 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v28 v32 
        let _run_target_args'_v29 = v33 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v34 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v35 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v28 v34 
        let _run_target_args'_v29 = v35 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v36 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v36 
        #endif
#if FABLE_COMPILER_PYTHON
        let v39 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v39 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v42 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v42 
        #endif
#else
        let v45 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v45 
        #endif
        let v48 : std_io_Error = _run_target_args'_v29 
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v54 : string = "Err($0)"
        let v55 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v48 v54 
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v56 : string = "Err($0)"
        let v57 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v48 v56 
        let _run_target_args'_v53 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v58 : string = "Err($0)"
        let v59 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v48 v58 
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v60 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v60 
        #endif
#if FABLE_COMPILER_PYTHON
        let v61 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v61 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v62 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v62 
        #endif
#else
        let v63 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v63 
        #endif
        let v64 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v53 
        v64
    else
        match v20 with
        | US5_0(v67) -> (* Some *)
            let v68 : string = ""
            let v69 : bool = v4 <> v68 
            if v69 then
                let v72 : uint8 = v2 + 1uy
                let v73 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v72
                let v74 : Result<std_path_PathBuf, std_io_Error> = v73 v67
                let v75 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v76 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v77 : string = "$0.map_err(|x| $1(x))"
                let v78 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v74, v75) v77 
                let _run_target_args'_v76 = v78 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79 : string = "$0.map_err(|x| $1(x))"
                let v80 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v74, v75) v79 
                let _run_target_args'_v76 = v80 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v81 : string = "$0.map_err(|x| $1(x))"
                let v82 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v74, v75) v81 
                let _run_target_args'_v76 = v82 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v83 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v83 
                #endif
#if FABLE_COMPILER_PYTHON
                let v84 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v84 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v85 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v85 
                #endif
#else
                let v86 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v86 
                #endif
                let v87 : Result<std_path_PathBuf, string> = _run_target_args'_v76 
                let v90 : (std_path_PathBuf -> US14) = method109()
                let v91 : (string -> US14) = method110()
                let v92 : US14 = match v87 with Ok x -> v90 x | Error x -> v91 x
                match v92 with
                | US14_1(v208) -> (* Error *)
                    let v209 : string = $"file_system.read_link / "
                    let v210 : string = $"error': {v208} / error: {v24} / name: {v5}"
                    let v211 : string = v209 + v210 
                    (* run_target_args'
                    let v212 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v213 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v214 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v211 v213 
                    let _run_target_args'_v212 = v214 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v215 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v216 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v211 v215 
                    let _run_target_args'_v212 = v216 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v217 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v218 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v211 v217 
                    let _run_target_args'_v212 = v218 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v219 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v219 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v222 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v222 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v225 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v225 
                    #endif
#else
                    let v228 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v228 
                    #endif
                    let v231 : std_io_Error = _run_target_args'_v212 
                    (* run_target_args'
                    let v236 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v237 : string = "Err($0)"
                    let v238 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v231 v237 
                    let _run_target_args'_v236 = v238 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v239 : string = "Err($0)"
                    let v240 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v231 v239 
                    let _run_target_args'_v236 = v240 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v241 : string = "Err($0)"
                    let v242 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v231 v241 
                    let _run_target_args'_v236 = v242 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v243 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v243 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v244 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v244 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v245 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v245 
                    #endif
#else
                    let v246 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v246 
                    #endif
                    let v247 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v236 
                    v247
                | US14_0(v93) -> (* Ok *)
                    (* run_target_args'
                    let v94 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v95 : string = "$0.display()"
                    let v96 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v93 v95 
                    let _run_target_args'_v94 = v96 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v97 : string = "$0.display()"
                    let v98 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v93 v97 
                    let _run_target_args'_v94 = v98 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v99 : string = "$0.display()"
                    let v100 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v93 v99 
                    let _run_target_args'_v94 = v100 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v101 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v101 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v104 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v104 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v107 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v107 
                    #endif
#else
                    let v110 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v110 
                    #endif
                    let v113 : std_path_Display = _run_target_args'_v94 
                    let v118 : string = v113 |> string 
                    let v121 : string = method86(v118, v5)
                    (* run_target_args'
                    let v122 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v123 : string = "&*$0"
                    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v121 v123 
                    let _run_target_args'_v122 = v124 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v125 : string = "&*$0"
                    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v121 v125 
                    let _run_target_args'_v122 = v126 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v127 : string = "&*$0"
                    let v128 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v121 v127 
                    let _run_target_args'_v122 = v128 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v129 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v129 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v132 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v132 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v135 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v135 
                    #endif
#else
                    let v138 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v138 
                    #endif
                    let v141 : Ref<Str> = _run_target_args'_v122 
                    (* run_target_args'
                    let v146 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v147 : string = "String::from($0)"
                    let v148 : std_string_String = Fable.Core.RustInterop.emitRustExpr v141 v147 
                    let _run_target_args'_v146 = v148 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v149 : string = "String::from($0)"
                    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v141 v149 
                    let _run_target_args'_v146 = v150 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v151 : string = "String::from($0)"
                    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v141 v151 
                    let _run_target_args'_v146 = v152 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v153 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v153 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v156 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v156 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v159 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v159 
                    #endif
#else
                    let v162 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v162 
                    #endif
                    let v165 : std_string_String = _run_target_args'_v146 
                    (* run_target_args'
                    let v170 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v171 : string = "std::path::PathBuf::from($0)"
                    let v172 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v165 v171 
                    let _run_target_args'_v170 = v172 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v173 : string = "std::path::PathBuf::from($0)"
                    let v174 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v165 v173 
                    let _run_target_args'_v170 = v174 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v175 : string = "std::path::PathBuf::from($0)"
                    let v176 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v165 v175 
                    let _run_target_args'_v170 = v176 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v177 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v177 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v180 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v180 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v183 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v183 
                    #endif
#else
                    let v186 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v186 
                    #endif
                    let v189 : std_path_PathBuf = _run_target_args'_v170 
                    (* run_target_args'
                    let v194 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v195 : string = "Ok($0)"
                    let v196 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v189 v195 
                    let _run_target_args'_v194 = v196 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v197 : string = "Ok($0)"
                    let v198 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v189 v197 
                    let _run_target_args'_v194 = v198 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v199 : string = "Ok($0)"
                    let v200 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v189 v199 
                    let _run_target_args'_v194 = v200 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v201 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v201 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v202 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v202 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v203 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v203 
                    #endif
#else
                    let v204 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v204 
                    #endif
                    let v205 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v194 
                    v205
            else
                let v252 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v253 : string = $"path: {v0} / error: {v24} / path': {v4} / name: {v5}"
                let v254 : string = v252 + v253 
                (* run_target_args'
                let v255 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v256 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v257 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v254 v256 
                let _run_target_args'_v255 = v257 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v258 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v259 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v254 v258 
                let _run_target_args'_v255 = v259 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v260 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v261 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v254 v260 
                let _run_target_args'_v255 = v261 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v262 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v262 
                #endif
#if FABLE_COMPILER_PYTHON
                let v265 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v265 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v268 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v268 
                #endif
#else
                let v271 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v271 
                #endif
                let v274 : std_io_Error = _run_target_args'_v255 
                (* run_target_args'
                let v279 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v280 : string = "Err($0)"
                let v281 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v274 v280 
                let _run_target_args'_v279 = v281 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v282 : string = "Err($0)"
                let v283 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v274 v282 
                let _run_target_args'_v279 = v283 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v284 : string = "Err($0)"
                let v285 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v274 v284 
                let _run_target_args'_v279 = v285 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v286 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v286 
                #endif
#if FABLE_COMPILER_PYTHON
                let v287 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v287 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v288 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v288 
                #endif
#else
                let v289 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v289 
                #endif
                let v290 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v279 
                v290
        | _ ->
            let v294 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v295 : string = $"path: {v0} / error: {v24} / path': {v4} / name: {v5}"
            let v296 : string = v294 + v295 
            (* run_target_args'
            let v297 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v298 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v299 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v296 v298 
            let _run_target_args'_v297 = v299 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v300 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v301 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v296 v300 
            let _run_target_args'_v297 = v301 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v302 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v303 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v296 v302 
            let _run_target_args'_v297 = v303 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v304 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v304 
            #endif
#if FABLE_COMPILER_PYTHON
            let v307 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v307 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v310 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v310 
            #endif
#else
            let v313 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v313 
            #endif
            let v316 : std_io_Error = _run_target_args'_v297 
            (* run_target_args'
            let v321 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v322 : string = "Err($0)"
            let v323 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v316 v322 
            let _run_target_args'_v321 = v323 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v324 : string = "Err($0)"
            let v325 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v316 v324 
            let _run_target_args'_v321 = v325 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v326 : string = "Err($0)"
            let v327 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v316 v326 
            let _run_target_args'_v321 = v327 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v328 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v328 
            #endif
#if FABLE_COMPILER_PYTHON
            let v329 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v329 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v330 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v330 
            #endif
#else
            let v331 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v331 
            #endif
            let v332 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v321 
            v332
and method111 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "std::fs::read_link(&*$0)"
    let v5 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let v6 : (std_io_Error -> string) = method43()
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "$0.map_err(|x| $1(x))"
    let v9 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v5, v6) v8 
    let _run_target_args'_v7 = v9 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v10 : string = "$0.map_err(|x| $1(x))"
    let v11 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v5, v6) v10 
    let _run_target_args'_v7 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v12 : string = "$0.map_err(|x| $1(x))"
    let v13 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v5, v6) v12 
    let _run_target_args'_v7 = v13 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v14 : Result<std_path_PathBuf, string> = match v5 with Ok x -> Ok x | Error x -> Error (v6 x)
    let _run_target_args'_v7 = v14 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : Result<std_path_PathBuf, string> = match v5 with Ok x -> Ok x | Error x -> Error (v6 x)
    let _run_target_args'_v7 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : Result<std_path_PathBuf, string> = match v5 with Ok x -> Ok x | Error x -> Error (v6 x)
    let _run_target_args'_v7 = v16 
    #endif
#else
    let v17 : Result<std_path_PathBuf, string> = match v5 with Ok x -> Ok x | Error x -> Error (v6 x)
    let _run_target_args'_v7 = v17 
    #endif
    let v18 : Result<std_path_PathBuf, string> = _run_target_args'_v7 
    let v21 : (std_path_PathBuf -> US14) = method109()
    let v22 : (string -> US14) = method110()
    let v23 : US14 = match v18 with Ok x -> v21 x | Error x -> v22 x
    let v43 : Result<std_path_PathBuf, std_io_Error> =
        match v23 with
        | US14_1(v39) -> (* Error *)
            let v40 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure53(v0)
            method112(v0, v40, v1, v39, v2)
        | US14_0(v24) -> (* Ok *)
            (* run_target_args'
            let v25 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v26 : string = "Ok($0)"
            let v27 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v24 v26 
            let _run_target_args'_v25 = v27 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v28 : string = "Ok($0)"
            let v29 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v24 v28 
            let _run_target_args'_v25 = v29 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v30 : string = "Ok($0)"
            let v31 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v24 v30 
            let _run_target_args'_v25 = v31 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v32 : Result<std_path_PathBuf, std_io_Error> = v24 |> Ok
            let _run_target_args'_v25 = v32 
            #endif
#if FABLE_COMPILER_PYTHON
            let v33 : Result<std_path_PathBuf, std_io_Error> = v24 |> Ok
            let _run_target_args'_v25 = v33 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v34 : Result<std_path_PathBuf, std_io_Error> = v24 |> Ok
            let _run_target_args'_v25 = v34 
            #endif
#else
            let v35 : Result<std_path_PathBuf, std_io_Error> = v24 |> Ok
            let _run_target_args'_v25 = v35 
            #endif
            let v36 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v25 
            v36
    let _run_target_args'_v3 = v43 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v44 : string = "std::fs::read_link(&*$0)"
    let v45 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v44 
    let v46 : (std_io_Error -> string) = method43()
    (* run_target_args'
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "$0.map_err(|x| $1(x))"
    let v49 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v45, v46) v48 
    let _run_target_args'_v47 = v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = "$0.map_err(|x| $1(x))"
    let v51 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v45, v46) v50 
    let _run_target_args'_v47 = v51 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v52 : string = "$0.map_err(|x| $1(x))"
    let v53 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v45, v46) v52 
    let _run_target_args'_v47 = v53 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : Result<std_path_PathBuf, string> = match v45 with Ok x -> Ok x | Error x -> Error (v46 x)
    let _run_target_args'_v47 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v55 : Result<std_path_PathBuf, string> = match v45 with Ok x -> Ok x | Error x -> Error (v46 x)
    let _run_target_args'_v47 = v55 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v56 : Result<std_path_PathBuf, string> = match v45 with Ok x -> Ok x | Error x -> Error (v46 x)
    let _run_target_args'_v47 = v56 
    #endif
#else
    let v57 : Result<std_path_PathBuf, string> = match v45 with Ok x -> Ok x | Error x -> Error (v46 x)
    let _run_target_args'_v47 = v57 
    #endif
    let v58 : Result<std_path_PathBuf, string> = _run_target_args'_v47 
    let v61 : (std_path_PathBuf -> US14) = method109()
    let v62 : (string -> US14) = method110()
    let v63 : US14 = match v58 with Ok x -> v61 x | Error x -> v62 x
    let v83 : Result<std_path_PathBuf, std_io_Error> =
        match v63 with
        | US14_1(v79) -> (* Error *)
            let v80 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure53(v0)
            method112(v0, v80, v1, v79, v2)
        | US14_0(v64) -> (* Ok *)
            (* run_target_args'
            let v65 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v66 : string = "Ok($0)"
            let v67 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v64 v66 
            let _run_target_args'_v65 = v67 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v68 : string = "Ok($0)"
            let v69 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v64 v68 
            let _run_target_args'_v65 = v69 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v70 : string = "Ok($0)"
            let v71 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v64 v70 
            let _run_target_args'_v65 = v71 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v72 : Result<std_path_PathBuf, std_io_Error> = v64 |> Ok
            let _run_target_args'_v65 = v72 
            #endif
#if FABLE_COMPILER_PYTHON
            let v73 : Result<std_path_PathBuf, std_io_Error> = v64 |> Ok
            let _run_target_args'_v65 = v73 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v74 : Result<std_path_PathBuf, std_io_Error> = v64 |> Ok
            let _run_target_args'_v65 = v74 
            #endif
#else
            let v75 : Result<std_path_PathBuf, std_io_Error> = v64 |> Ok
            let _run_target_args'_v65 = v75 
            #endif
            let v76 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v65 
            v76
    let _run_target_args'_v3 = v83 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v84 : string = "std::fs::read_link(&*$0)"
    let v85 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v84 
    let v86 : (std_io_Error -> string) = method43()
    (* run_target_args'
    let v87 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v88 : string = "$0.map_err(|x| $1(x))"
    let v89 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v85, v86) v88 
    let _run_target_args'_v87 = v89 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v90 : string = "$0.map_err(|x| $1(x))"
    let v91 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v85, v86) v90 
    let _run_target_args'_v87 = v91 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v92 : string = "$0.map_err(|x| $1(x))"
    let v93 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v85, v86) v92 
    let _run_target_args'_v87 = v93 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v94 : Result<std_path_PathBuf, string> = match v85 with Ok x -> Ok x | Error x -> Error (v86 x)
    let _run_target_args'_v87 = v94 
    #endif
#if FABLE_COMPILER_PYTHON
    let v95 : Result<std_path_PathBuf, string> = match v85 with Ok x -> Ok x | Error x -> Error (v86 x)
    let _run_target_args'_v87 = v95 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v96 : Result<std_path_PathBuf, string> = match v85 with Ok x -> Ok x | Error x -> Error (v86 x)
    let _run_target_args'_v87 = v96 
    #endif
#else
    let v97 : Result<std_path_PathBuf, string> = match v85 with Ok x -> Ok x | Error x -> Error (v86 x)
    let _run_target_args'_v87 = v97 
    #endif
    let v98 : Result<std_path_PathBuf, string> = _run_target_args'_v87 
    let v101 : (std_path_PathBuf -> US14) = method109()
    let v102 : (string -> US14) = method110()
    let v103 : US14 = match v98 with Ok x -> v101 x | Error x -> v102 x
    let v123 : Result<std_path_PathBuf, std_io_Error> =
        match v103 with
        | US14_1(v119) -> (* Error *)
            let v120 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure53(v0)
            method112(v0, v120, v1, v119, v2)
        | US14_0(v104) -> (* Ok *)
            (* run_target_args'
            let v105 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v106 : string = "Ok($0)"
            let v107 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v104 v106 
            let _run_target_args'_v105 = v107 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v108 : string = "Ok($0)"
            let v109 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v104 v108 
            let _run_target_args'_v105 = v109 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v110 : string = "Ok($0)"
            let v111 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v104 v110 
            let _run_target_args'_v105 = v111 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v112 : Result<std_path_PathBuf, std_io_Error> = v104 |> Ok
            let _run_target_args'_v105 = v112 
            #endif
#if FABLE_COMPILER_PYTHON
            let v113 : Result<std_path_PathBuf, std_io_Error> = v104 |> Ok
            let _run_target_args'_v105 = v113 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v114 : Result<std_path_PathBuf, std_io_Error> = v104 |> Ok
            let _run_target_args'_v105 = v114 
            #endif
#else
            let v115 : Result<std_path_PathBuf, std_io_Error> = v104 |> Ok
            let _run_target_args'_v105 = v115 
            #endif
            let v116 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v105 
            v116
    let _run_target_args'_v3 = v123 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v124 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v3 = v124 
    #endif
#if FABLE_COMPILER_PYTHON
    let v127 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v3 = v127 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v130 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v3 = v130 
    #endif
#else
    let v133 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v3 = v133 
    #endif
    let v136 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v3 
    v136
and closure54 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method111(v0, v1, v2)
and closure53 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure54(v0, v1)
and method115 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method20(v0)
    let v5 : string option = method113(v0)
    let v6 : (string -> US5) = method5()
    let v7 : US5 option = v5 |> Option.map v6 
    let v18 : US5 = US5_1
    let v19 : US5 = v7 |> Option.defaultValue v18 
    let v23 : string = method114(v3)
    let v24 : bool = v2 >= 11uy
    if v24 then
        let v25 : string = $"file_system.read_link / "
        let v26 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v27 : string = v25 + v26 
        (* run_target_args'
        let v28 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v29 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v30 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v27 v29 
        let _run_target_args'_v28 = v30 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v31 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v32 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v27 v31 
        let _run_target_args'_v28 = v32 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v33 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v34 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v27 v33 
        let _run_target_args'_v28 = v34 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v35 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v35 
        #endif
#if FABLE_COMPILER_PYTHON
        let v38 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v38 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v41 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v41 
        #endif
#else
        let v44 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v44 
        #endif
        let v47 : std_io_Error = _run_target_args'_v28 
        (* run_target_args'
        let v52 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = "Err($0)"
        let v54 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v47 v53 
        let _run_target_args'_v52 = v54 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v55 : string = "Err($0)"
        let v56 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v47 v55 
        let _run_target_args'_v52 = v56 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v57 : string = "Err($0)"
        let v58 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v47 v57 
        let _run_target_args'_v52 = v58 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v59 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v59 
        #endif
#if FABLE_COMPILER_PYTHON
        let v60 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v60 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v61 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v61 
        #endif
#else
        let v62 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v62 
        #endif
        let v63 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v52 
        v63
    else
        match v19 with
        | US5_0(v66) -> (* Some *)
            let v67 : string = ""
            let v68 : bool = v0 <> v67 
            if v68 then
                let v71 : uint8 = v2 + 1uy
                let v72 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v71
                let v73 : Result<std_path_PathBuf, std_io_Error> = v72 v66
                let v74 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v75 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76 : string = "$0.map_err(|x| $1(x))"
                let v77 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v73, v74) v76 
                let _run_target_args'_v75 = v77 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v78 : string = "$0.map_err(|x| $1(x))"
                let v79 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v73, v74) v78 
                let _run_target_args'_v75 = v79 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v80 : string = "$0.map_err(|x| $1(x))"
                let v81 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v73, v74) v80 
                let _run_target_args'_v75 = v81 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v82 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v82 
                #endif
#if FABLE_COMPILER_PYTHON
                let v83 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v83 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v84 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v84 
                #endif
#else
                let v85 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v85 
                #endif
                let v86 : Result<std_path_PathBuf, string> = _run_target_args'_v75 
                let v89 : (std_path_PathBuf -> US14) = method109()
                let v90 : (string -> US14) = method110()
                let v91 : US14 = match v86 with Ok x -> v89 x | Error x -> v90 x
                match v91 with
                | US14_1(v207) -> (* Error *)
                    let v208 : string = $"file_system.read_link / "
                    let v209 : string = $"error': {v207} / error: {v23} / name: {v4}"
                    let v210 : string = v208 + v209 
                    (* run_target_args'
                    let v211 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v212 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v213 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v210 v212 
                    let _run_target_args'_v211 = v213 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v214 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v215 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v210 v214 
                    let _run_target_args'_v211 = v215 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v216 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v217 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v210 v216 
                    let _run_target_args'_v211 = v217 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v218 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v218 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v221 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v221 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v224 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v224 
                    #endif
#else
                    let v227 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v227 
                    #endif
                    let v230 : std_io_Error = _run_target_args'_v211 
                    (* run_target_args'
                    let v235 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v236 : string = "Err($0)"
                    let v237 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v230 v236 
                    let _run_target_args'_v235 = v237 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v238 : string = "Err($0)"
                    let v239 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v230 v238 
                    let _run_target_args'_v235 = v239 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v240 : string = "Err($0)"
                    let v241 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v230 v240 
                    let _run_target_args'_v235 = v241 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v242 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v242 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v243 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v243 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v244 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v244 
                    #endif
#else
                    let v245 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v245 
                    #endif
                    let v246 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v235 
                    v246
                | US14_0(v92) -> (* Ok *)
                    (* run_target_args'
                    let v93 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v94 : string = "$0.display()"
                    let v95 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v92 v94 
                    let _run_target_args'_v93 = v95 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v96 : string = "$0.display()"
                    let v97 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v92 v96 
                    let _run_target_args'_v93 = v97 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v98 : string = "$0.display()"
                    let v99 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v92 v98 
                    let _run_target_args'_v93 = v99 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v100 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v100 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v103 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v103 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v106 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v106 
                    #endif
#else
                    let v109 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v109 
                    #endif
                    let v112 : std_path_Display = _run_target_args'_v93 
                    let v117 : string = v112 |> string 
                    let v120 : string = method86(v117, v4)
                    (* run_target_args'
                    let v121 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v122 : string = "&*$0"
                    let v123 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v120 v122 
                    let _run_target_args'_v121 = v123 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v124 : string = "&*$0"
                    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v120 v124 
                    let _run_target_args'_v121 = v125 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v126 : string = "&*$0"
                    let v127 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v120 v126 
                    let _run_target_args'_v121 = v127 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v128 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v128 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v131 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v131 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v134 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v134 
                    #endif
#else
                    let v137 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v137 
                    #endif
                    let v140 : Ref<Str> = _run_target_args'_v121 
                    (* run_target_args'
                    let v145 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v146 : string = "String::from($0)"
                    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v140 v146 
                    let _run_target_args'_v145 = v147 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v148 : string = "String::from($0)"
                    let v149 : std_string_String = Fable.Core.RustInterop.emitRustExpr v140 v148 
                    let _run_target_args'_v145 = v149 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v150 : string = "String::from($0)"
                    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v140 v150 
                    let _run_target_args'_v145 = v151 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v152 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v152 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v155 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v155 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v158 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v158 
                    #endif
#else
                    let v161 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v161 
                    #endif
                    let v164 : std_string_String = _run_target_args'_v145 
                    (* run_target_args'
                    let v169 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v170 : string = "std::path::PathBuf::from($0)"
                    let v171 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v164 v170 
                    let _run_target_args'_v169 = v171 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v172 : string = "std::path::PathBuf::from($0)"
                    let v173 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v164 v172 
                    let _run_target_args'_v169 = v173 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v174 : string = "std::path::PathBuf::from($0)"
                    let v175 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v164 v174 
                    let _run_target_args'_v169 = v175 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v176 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v176 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v179 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v179 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v182 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v182 
                    #endif
#else
                    let v185 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v185 
                    #endif
                    let v188 : std_path_PathBuf = _run_target_args'_v169 
                    (* run_target_args'
                    let v193 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v194 : string = "Ok($0)"
                    let v195 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v188 v194 
                    let _run_target_args'_v193 = v195 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v196 : string = "Ok($0)"
                    let v197 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v188 v196 
                    let _run_target_args'_v193 = v197 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v198 : string = "Ok($0)"
                    let v199 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v188 v198 
                    let _run_target_args'_v193 = v199 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v200 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v200 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v201 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v201 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v202 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v202 
                    #endif
#else
                    let v203 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v203 
                    #endif
                    let v204 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v193 
                    v204
            else
                let v251 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v252 : string = $"path: {v0} / error: {v23} / path': {v0} / name: {v4}"
                let v253 : string = v251 + v252 
                (* run_target_args'
                let v254 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v255 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v256 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v253 v255 
                let _run_target_args'_v254 = v256 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v257 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v258 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v253 v257 
                let _run_target_args'_v254 = v258 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v259 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v260 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v253 v259 
                let _run_target_args'_v254 = v260 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v261 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v261 
                #endif
#if FABLE_COMPILER_PYTHON
                let v264 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v264 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v267 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v267 
                #endif
#else
                let v270 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v270 
                #endif
                let v273 : std_io_Error = _run_target_args'_v254 
                (* run_target_args'
                let v278 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v279 : string = "Err($0)"
                let v280 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v273 v279 
                let _run_target_args'_v278 = v280 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v281 : string = "Err($0)"
                let v282 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v273 v281 
                let _run_target_args'_v278 = v282 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v283 : string = "Err($0)"
                let v284 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v273 v283 
                let _run_target_args'_v278 = v284 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v285 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v285 
                #endif
#if FABLE_COMPILER_PYTHON
                let v286 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v286 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v287 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v287 
                #endif
#else
                let v288 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v288 
                #endif
                let v289 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v278 
                v289
        | _ ->
            let v293 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v294 : string = $"path: {v0} / error: {v23} / path': {v0} / name: {v4}"
            let v295 : string = v293 + v294 
            (* run_target_args'
            let v296 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v297 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v298 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v297 
            let _run_target_args'_v296 = v298 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v299 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v300 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v299 
            let _run_target_args'_v296 = v300 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v301 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v302 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v301 
            let _run_target_args'_v296 = v302 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v303 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v303 
            #endif
#if FABLE_COMPILER_PYTHON
            let v306 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v306 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v309 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v309 
            #endif
#else
            let v312 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v312 
            #endif
            let v315 : std_io_Error = _run_target_args'_v296 
            (* run_target_args'
            let v320 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v321 : string = "Err($0)"
            let v322 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v315 v321 
            let _run_target_args'_v320 = v322 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v323 : string = "Err($0)"
            let v324 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v315 v323 
            let _run_target_args'_v320 = v324 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v325 : string = "Err($0)"
            let v326 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v315 v325 
            let _run_target_args'_v320 = v326 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v327 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v327 
            #endif
#if FABLE_COMPILER_PYTHON
            let v328 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v328 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v329 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v329 
            #endif
#else
            let v330 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v330 
            #endif
            let v331 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v320 
            v331
and method108 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "std::fs::read_link(&*$0)"
    let v4 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let v5 : (std_io_Error -> string) = method43()
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "$0.map_err(|x| $1(x))"
    let v8 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v4, v5) v7 
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v9 : string = "$0.map_err(|x| $1(x))"
    let v10 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v4, v5) v9 
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v11 : string = "$0.map_err(|x| $1(x))"
    let v12 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v4, v5) v11 
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : Result<std_path_PathBuf, string> = match v4 with Ok x -> Ok x | Error x -> Error (v5 x)
    let _run_target_args'_v6 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : Result<std_path_PathBuf, string> = match v4 with Ok x -> Ok x | Error x -> Error (v5 x)
    let _run_target_args'_v6 = v14 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : Result<std_path_PathBuf, string> = match v4 with Ok x -> Ok x | Error x -> Error (v5 x)
    let _run_target_args'_v6 = v15 
    #endif
#else
    let v16 : Result<std_path_PathBuf, string> = match v4 with Ok x -> Ok x | Error x -> Error (v5 x)
    let _run_target_args'_v6 = v16 
    #endif
    let v17 : Result<std_path_PathBuf, string> = _run_target_args'_v6 
    let v20 : (std_path_PathBuf -> US14) = method109()
    let v21 : (string -> US14) = method110()
    let v22 : US14 = match v17 with Ok x -> v20 x | Error x -> v21 x
    let v42 : Result<std_path_PathBuf, std_io_Error> =
        match v22 with
        | US14_1(v38) -> (* Error *)
            let v39 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure53(v0)
            method115(v0, v39, v1, v38)
        | US14_0(v23) -> (* Ok *)
            (* run_target_args'
            let v24 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v25 : string = "Ok($0)"
            let v26 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v23 v25 
            let _run_target_args'_v24 = v26 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v27 : string = "Ok($0)"
            let v28 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v23 v27 
            let _run_target_args'_v24 = v28 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v29 : string = "Ok($0)"
            let v30 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v23 v29 
            let _run_target_args'_v24 = v30 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v31 : Result<std_path_PathBuf, std_io_Error> = v23 |> Ok
            let _run_target_args'_v24 = v31 
            #endif
#if FABLE_COMPILER_PYTHON
            let v32 : Result<std_path_PathBuf, std_io_Error> = v23 |> Ok
            let _run_target_args'_v24 = v32 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v33 : Result<std_path_PathBuf, std_io_Error> = v23 |> Ok
            let _run_target_args'_v24 = v33 
            #endif
#else
            let v34 : Result<std_path_PathBuf, std_io_Error> = v23 |> Ok
            let _run_target_args'_v24 = v34 
            #endif
            let v35 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v24 
            v35
    let _run_target_args'_v2 = v42 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v43 : string = "std::fs::read_link(&*$0)"
    let v44 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v43 
    let v45 : (std_io_Error -> string) = method43()
    (* run_target_args'
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : string = "$0.map_err(|x| $1(x))"
    let v48 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v44, v45) v47 
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "$0.map_err(|x| $1(x))"
    let v50 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v44, v45) v49 
    let _run_target_args'_v46 = v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = "$0.map_err(|x| $1(x))"
    let v52 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v44, v45) v51 
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v53 : Result<std_path_PathBuf, string> = match v44 with Ok x -> Ok x | Error x -> Error (v45 x)
    let _run_target_args'_v46 = v53 
    #endif
#if FABLE_COMPILER_PYTHON
    let v54 : Result<std_path_PathBuf, string> = match v44 with Ok x -> Ok x | Error x -> Error (v45 x)
    let _run_target_args'_v46 = v54 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v55 : Result<std_path_PathBuf, string> = match v44 with Ok x -> Ok x | Error x -> Error (v45 x)
    let _run_target_args'_v46 = v55 
    #endif
#else
    let v56 : Result<std_path_PathBuf, string> = match v44 with Ok x -> Ok x | Error x -> Error (v45 x)
    let _run_target_args'_v46 = v56 
    #endif
    let v57 : Result<std_path_PathBuf, string> = _run_target_args'_v46 
    let v60 : (std_path_PathBuf -> US14) = method109()
    let v61 : (string -> US14) = method110()
    let v62 : US14 = match v57 with Ok x -> v60 x | Error x -> v61 x
    let v82 : Result<std_path_PathBuf, std_io_Error> =
        match v62 with
        | US14_1(v78) -> (* Error *)
            let v79 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure53(v0)
            method115(v0, v79, v1, v78)
        | US14_0(v63) -> (* Ok *)
            (* run_target_args'
            let v64 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v65 : string = "Ok($0)"
            let v66 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v63 v65 
            let _run_target_args'_v64 = v66 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v67 : string = "Ok($0)"
            let v68 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v63 v67 
            let _run_target_args'_v64 = v68 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v69 : string = "Ok($0)"
            let v70 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v63 v69 
            let _run_target_args'_v64 = v70 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v71 : Result<std_path_PathBuf, std_io_Error> = v63 |> Ok
            let _run_target_args'_v64 = v71 
            #endif
#if FABLE_COMPILER_PYTHON
            let v72 : Result<std_path_PathBuf, std_io_Error> = v63 |> Ok
            let _run_target_args'_v64 = v72 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v73 : Result<std_path_PathBuf, std_io_Error> = v63 |> Ok
            let _run_target_args'_v64 = v73 
            #endif
#else
            let v74 : Result<std_path_PathBuf, std_io_Error> = v63 |> Ok
            let _run_target_args'_v64 = v74 
            #endif
            let v75 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v64 
            v75
    let _run_target_args'_v2 = v82 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v83 : string = "std::fs::read_link(&*$0)"
    let v84 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v83 
    let v85 : (std_io_Error -> string) = method43()
    (* run_target_args'
    let v86 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v87 : string = "$0.map_err(|x| $1(x))"
    let v88 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v84, v85) v87 
    let _run_target_args'_v86 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "$0.map_err(|x| $1(x))"
    let v90 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v84, v85) v89 
    let _run_target_args'_v86 = v90 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v91 : string = "$0.map_err(|x| $1(x))"
    let v92 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v84, v85) v91 
    let _run_target_args'_v86 = v92 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v93 : Result<std_path_PathBuf, string> = match v84 with Ok x -> Ok x | Error x -> Error (v85 x)
    let _run_target_args'_v86 = v93 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : Result<std_path_PathBuf, string> = match v84 with Ok x -> Ok x | Error x -> Error (v85 x)
    let _run_target_args'_v86 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v95 : Result<std_path_PathBuf, string> = match v84 with Ok x -> Ok x | Error x -> Error (v85 x)
    let _run_target_args'_v86 = v95 
    #endif
#else
    let v96 : Result<std_path_PathBuf, string> = match v84 with Ok x -> Ok x | Error x -> Error (v85 x)
    let _run_target_args'_v86 = v96 
    #endif
    let v97 : Result<std_path_PathBuf, string> = _run_target_args'_v86 
    let v100 : (std_path_PathBuf -> US14) = method109()
    let v101 : (string -> US14) = method110()
    let v102 : US14 = match v97 with Ok x -> v100 x | Error x -> v101 x
    let v122 : Result<std_path_PathBuf, std_io_Error> =
        match v102 with
        | US14_1(v118) -> (* Error *)
            let v119 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure53(v0)
            method115(v0, v119, v1, v118)
        | US14_0(v103) -> (* Ok *)
            (* run_target_args'
            let v104 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v105 : string = "Ok($0)"
            let v106 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v103 v105 
            let _run_target_args'_v104 = v106 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v107 : string = "Ok($0)"
            let v108 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v103 v107 
            let _run_target_args'_v104 = v108 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v109 : string = "Ok($0)"
            let v110 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v103 v109 
            let _run_target_args'_v104 = v110 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v111 : Result<std_path_PathBuf, std_io_Error> = v103 |> Ok
            let _run_target_args'_v104 = v111 
            #endif
#if FABLE_COMPILER_PYTHON
            let v112 : Result<std_path_PathBuf, std_io_Error> = v103 |> Ok
            let _run_target_args'_v104 = v112 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v113 : Result<std_path_PathBuf, std_io_Error> = v103 |> Ok
            let _run_target_args'_v104 = v113 
            #endif
#else
            let v114 : Result<std_path_PathBuf, std_io_Error> = v103 |> Ok
            let _run_target_args'_v104 = v114 
            #endif
            let v115 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v104 
            v115
    let _run_target_args'_v2 = v122 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v123 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v2 = v123 
    #endif
#if FABLE_COMPILER_PYTHON
    let v126 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v2 = v126 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v129 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v2 = v129 
    #endif
#else
    let v132 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v2 = v132 
    #endif
    let v135 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v2 
    v135
and method117 (v0 : System_IO_DirectoryInfo) : System.IO.FileAttributes =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v1 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v1 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v1 = v11 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v1 = v14 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v17 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v1 = v17 
    #endif
#else
    let v20 : (System_IO_DirectoryInfo -> System.IO.FileAttributes) = _.Attributes
    let v21 : System.IO.FileAttributes = v20 v0
    let _run_target_args'_v1 = v21 
    #endif
    let v22 : System.IO.FileAttributes = _run_target_args'_v1 
    v22
and method118 () : System.IO.FileAttributes =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v0 = v1 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v0 = v4 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v0 = v7 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v0 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v13 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v0 = v13 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : System.IO.FileAttributes = null |> unbox<System.IO.FileAttributes>
    let _run_target_args'_v0 = v16 
    #endif
#else
    let v19 : System.IO.FileAttributes = System.IO.FileAttributes.ReparsePoint
    let _run_target_args'_v0 = v19 
    #endif
    let v20 : System.IO.FileAttributes = _run_target_args'_v0 
    v20
and method119 (v0 : System.IO.FileAttributes, v1 : System.IO.FileAttributes) : bool =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18 : bool = null |> unbox<bool>
    let _run_target_args'_v2 = v18 
    #endif
#else
    let v21 : bool = v1.HasFlag v0 
    let _run_target_args'_v2 = v21 
    #endif
    let v22 : bool = _run_target_args'_v2 
    v22
and method121 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method20(v4)
    let v6 : string option = method113(v4)
    let v7 : (string -> US5) = method5()
    let v8 : US5 option = v6 |> Option.map v7 
    let v19 : US5 = US5_1
    let v20 : US5 = v8 |> Option.defaultValue v19 
    let v24 : string = method44(v3)
    let v25 : bool = v2 >= 11uy
    if v25 then
        let v26 : string = $"file_system.read_link / "
        let v27 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v28 : string = v26 + v27 
        (* run_target_args'
        let v29 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v30 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v31 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v28 v30 
        let _run_target_args'_v29 = v31 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v32 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v33 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v28 v32 
        let _run_target_args'_v29 = v33 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v34 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v35 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v28 v34 
        let _run_target_args'_v29 = v35 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v36 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v36 
        #endif
#if FABLE_COMPILER_PYTHON
        let v39 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v39 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v42 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v42 
        #endif
#else
        let v45 : std_io_Error = v28 |> unbox<std_io_Error>
        let _run_target_args'_v29 = v45 
        #endif
        let v48 : std_io_Error = _run_target_args'_v29 
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v54 : string = "Err($0)"
        let v55 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v48 v54 
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v56 : string = "Err($0)"
        let v57 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v48 v56 
        let _run_target_args'_v53 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v58 : string = "Err($0)"
        let v59 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v48 v58 
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v60 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v60 
        #endif
#if FABLE_COMPILER_PYTHON
        let v61 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v61 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v62 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v62 
        #endif
#else
        let v63 : Result<std_path_PathBuf, std_io_Error> = v48 |> Error
        let _run_target_args'_v53 = v63 
        #endif
        let v64 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v53 
        v64
    else
        match v20 with
        | US5_0(v67) -> (* Some *)
            let v68 : string = ""
            let v69 : bool = v4 <> v68 
            if v69 then
                let v72 : uint8 = v2 + 1uy
                let v73 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v72
                let v74 : Result<std_path_PathBuf, std_io_Error> = v73 v67
                let v75 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v76 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v77 : string = "$0.map_err(|x| $1(x))"
                let v78 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v74, v75) v77 
                let _run_target_args'_v76 = v78 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79 : string = "$0.map_err(|x| $1(x))"
                let v80 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v74, v75) v79 
                let _run_target_args'_v76 = v80 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v81 : string = "$0.map_err(|x| $1(x))"
                let v82 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v74, v75) v81 
                let _run_target_args'_v76 = v82 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v83 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v83 
                #endif
#if FABLE_COMPILER_PYTHON
                let v84 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v84 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v85 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v85 
                #endif
#else
                let v86 : Result<std_path_PathBuf, string> = match v74 with Ok x -> Ok x | Error x -> Error (v75 x)
                let _run_target_args'_v76 = v86 
                #endif
                let v87 : Result<std_path_PathBuf, string> = _run_target_args'_v76 
                let v90 : (std_path_PathBuf -> US14) = method109()
                let v91 : (string -> US14) = method110()
                let v92 : US14 = match v87 with Ok x -> v90 x | Error x -> v91 x
                match v92 with
                | US14_1(v208) -> (* Error *)
                    let v209 : string = $"file_system.read_link / "
                    let v210 : string = $"error': {v208} / error: {v24} / name: {v5}"
                    let v211 : string = v209 + v210 
                    (* run_target_args'
                    let v212 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v213 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v214 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v211 v213 
                    let _run_target_args'_v212 = v214 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v215 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v216 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v211 v215 
                    let _run_target_args'_v212 = v216 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v217 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v218 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v211 v217 
                    let _run_target_args'_v212 = v218 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v219 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v219 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v222 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v222 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v225 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v225 
                    #endif
#else
                    let v228 : std_io_Error = v211 |> unbox<std_io_Error>
                    let _run_target_args'_v212 = v228 
                    #endif
                    let v231 : std_io_Error = _run_target_args'_v212 
                    (* run_target_args'
                    let v236 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v237 : string = "Err($0)"
                    let v238 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v231 v237 
                    let _run_target_args'_v236 = v238 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v239 : string = "Err($0)"
                    let v240 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v231 v239 
                    let _run_target_args'_v236 = v240 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v241 : string = "Err($0)"
                    let v242 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v231 v241 
                    let _run_target_args'_v236 = v242 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v243 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v243 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v244 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v244 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v245 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v245 
                    #endif
#else
                    let v246 : Result<std_path_PathBuf, std_io_Error> = v231 |> Error
                    let _run_target_args'_v236 = v246 
                    #endif
                    let v247 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v236 
                    v247
                | US14_0(v93) -> (* Ok *)
                    (* run_target_args'
                    let v94 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v95 : string = "$0.display()"
                    let v96 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v93 v95 
                    let _run_target_args'_v94 = v96 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v97 : string = "$0.display()"
                    let v98 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v93 v97 
                    let _run_target_args'_v94 = v98 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v99 : string = "$0.display()"
                    let v100 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v93 v99 
                    let _run_target_args'_v94 = v100 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v101 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v101 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v104 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v104 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v107 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v107 
                    #endif
#else
                    let v110 : std_path_Display = v93 |> unbox<std_path_Display>
                    let _run_target_args'_v94 = v110 
                    #endif
                    let v113 : std_path_Display = _run_target_args'_v94 
                    let v118 : string = v113 |> string 
                    let v121 : string = method86(v118, v5)
                    (* run_target_args'
                    let v122 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v123 : string = "&*$0"
                    let v124 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v121 v123 
                    let _run_target_args'_v122 = v124 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v125 : string = "&*$0"
                    let v126 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v121 v125 
                    let _run_target_args'_v122 = v126 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v127 : string = "&*$0"
                    let v128 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v121 v127 
                    let _run_target_args'_v122 = v128 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v129 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v129 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v132 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v132 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v135 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v135 
                    #endif
#else
                    let v138 : Ref<Str> = v121 |> unbox<Ref<Str>>
                    let _run_target_args'_v122 = v138 
                    #endif
                    let v141 : Ref<Str> = _run_target_args'_v122 
                    (* run_target_args'
                    let v146 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v147 : string = "String::from($0)"
                    let v148 : std_string_String = Fable.Core.RustInterop.emitRustExpr v141 v147 
                    let _run_target_args'_v146 = v148 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v149 : string = "String::from($0)"
                    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v141 v149 
                    let _run_target_args'_v146 = v150 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v151 : string = "String::from($0)"
                    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v141 v151 
                    let _run_target_args'_v146 = v152 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v153 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v153 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v156 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v156 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v159 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v159 
                    #endif
#else
                    let v162 : std_string_String = v141 |> unbox<std_string_String>
                    let _run_target_args'_v146 = v162 
                    #endif
                    let v165 : std_string_String = _run_target_args'_v146 
                    (* run_target_args'
                    let v170 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v171 : string = "std::path::PathBuf::from($0)"
                    let v172 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v165 v171 
                    let _run_target_args'_v170 = v172 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v173 : string = "std::path::PathBuf::from($0)"
                    let v174 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v165 v173 
                    let _run_target_args'_v170 = v174 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v175 : string = "std::path::PathBuf::from($0)"
                    let v176 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v165 v175 
                    let _run_target_args'_v170 = v176 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v177 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v177 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v180 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v180 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v183 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v183 
                    #endif
#else
                    let v186 : std_path_PathBuf = v165 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v170 = v186 
                    #endif
                    let v189 : std_path_PathBuf = _run_target_args'_v170 
                    (* run_target_args'
                    let v194 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v195 : string = "Ok($0)"
                    let v196 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v189 v195 
                    let _run_target_args'_v194 = v196 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v197 : string = "Ok($0)"
                    let v198 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v189 v197 
                    let _run_target_args'_v194 = v198 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v199 : string = "Ok($0)"
                    let v200 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v189 v199 
                    let _run_target_args'_v194 = v200 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v201 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v201 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v202 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v202 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v203 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v203 
                    #endif
#else
                    let v204 : Result<std_path_PathBuf, std_io_Error> = v189 |> Ok
                    let _run_target_args'_v194 = v204 
                    #endif
                    let v205 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v194 
                    v205
            else
                let v252 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v253 : string = $"path: {v0} / error: {v24} / path': {v4} / name: {v5}"
                let v254 : string = v252 + v253 
                (* run_target_args'
                let v255 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v256 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v257 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v254 v256 
                let _run_target_args'_v255 = v257 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v258 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v259 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v254 v258 
                let _run_target_args'_v255 = v259 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v260 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v261 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v254 v260 
                let _run_target_args'_v255 = v261 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v262 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v262 
                #endif
#if FABLE_COMPILER_PYTHON
                let v265 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v265 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v268 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v268 
                #endif
#else
                let v271 : std_io_Error = v254 |> unbox<std_io_Error>
                let _run_target_args'_v255 = v271 
                #endif
                let v274 : std_io_Error = _run_target_args'_v255 
                (* run_target_args'
                let v279 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v280 : string = "Err($0)"
                let v281 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v274 v280 
                let _run_target_args'_v279 = v281 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v282 : string = "Err($0)"
                let v283 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v274 v282 
                let _run_target_args'_v279 = v283 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v284 : string = "Err($0)"
                let v285 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v274 v284 
                let _run_target_args'_v279 = v285 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v286 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v286 
                #endif
#if FABLE_COMPILER_PYTHON
                let v287 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v287 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v288 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v288 
                #endif
#else
                let v289 : Result<std_path_PathBuf, std_io_Error> = v274 |> Error
                let _run_target_args'_v279 = v289 
                #endif
                let v290 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v279 
                v290
        | _ ->
            let v294 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v295 : string = $"path: {v0} / error: {v24} / path': {v4} / name: {v5}"
            let v296 : string = v294 + v295 
            (* run_target_args'
            let v297 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v298 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v299 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v296 v298 
            let _run_target_args'_v297 = v299 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v300 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v301 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v296 v300 
            let _run_target_args'_v297 = v301 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v302 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v303 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v296 v302 
            let _run_target_args'_v297 = v303 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v304 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v304 
            #endif
#if FABLE_COMPILER_PYTHON
            let v307 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v307 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v310 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v310 
            #endif
#else
            let v313 : std_io_Error = v296 |> unbox<std_io_Error>
            let _run_target_args'_v297 = v313 
            #endif
            let v316 : std_io_Error = _run_target_args'_v297 
            (* run_target_args'
            let v321 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v322 : string = "Err($0)"
            let v323 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v316 v322 
            let _run_target_args'_v321 = v323 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v324 : string = "Err($0)"
            let v325 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v316 v324 
            let _run_target_args'_v321 = v325 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v326 : string = "Err($0)"
            let v327 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v316 v326 
            let _run_target_args'_v321 = v327 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v328 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v328 
            #endif
#if FABLE_COMPILER_PYTHON
            let v329 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v329 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v330 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v330 
            #endif
#else
            let v331 : Result<std_path_PathBuf, std_io_Error> = v316 |> Error
            let _run_target_args'_v321 = v331 
            #endif
            let v332 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v321 
            v332
and method120 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v3 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v10 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v3 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v16 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v3 = v16 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v19 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v3 = v19 
    #endif
#else
    let v22 : System_IO_DirectoryInfo = v2 |> System_IO_DirectoryInfo 
    let _run_target_args'_v3 = v22 
    #endif
    let v25 : System_IO_DirectoryInfo = _run_target_args'_v3 
    let v30 : System.IO.FileAttributes = method117(v25)
    let v31 : System.IO.FileAttributes = method118()
    let v32 : bool = method119(v31, v30)
    if v32 then
        (* run_target_args'
        let v33 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v34 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v33 = v34 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v37 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v33 = v37 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v40 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v33 = v40 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v43 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v33 = v43 
        #endif
#if FABLE_COMPILER_PYTHON
        let v46 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v33 = v46 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v49 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v33 = v49 
        #endif
#else
        let v52 : System_IO_FileInfo = v2 |> System_IO_FileInfo 
        let _run_target_args'_v33 = v52 
        #endif
        let v55 : System_IO_FileInfo = _run_target_args'_v33 
        (* run_target_args'
        let v60 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v61 : string = null |> unbox<string>
        let _run_target_args'_v60 = v61 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v64 : string = null |> unbox<string>
        let _run_target_args'_v60 = v64 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v67 : string = null |> unbox<string>
        let _run_target_args'_v60 = v67 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v70 : string = null |> unbox<string>
        let _run_target_args'_v60 = v70 
        #endif
#if FABLE_COMPILER_PYTHON
        let v73 : string = null |> unbox<string>
        let _run_target_args'_v60 = v73 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v76 : string = null |> unbox<string>
        let _run_target_args'_v60 = v76 
        #endif
#else
        let v79 : (System_IO_FileInfo -> string) = _.LinkTarget
        let v80 : string = v79 v55
        let _run_target_args'_v60 = v80 
        #endif
        let v81 : string = _run_target_args'_v60 
        let v86 : std_path_PathBuf = v81 |> unbox<std_path_PathBuf>
        (* run_target_args'
        let v89 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v90 : string = "Ok($0)"
        let v91 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v90 
        let _run_target_args'_v89 = v91 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v92 : string = "Ok($0)"
        let v93 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v92 
        let _run_target_args'_v89 = v93 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v94 : string = "Ok($0)"
        let v95 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v94 
        let _run_target_args'_v89 = v95 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v96 : Result<std_path_PathBuf, std_io_Error> = v86 |> Ok
        let _run_target_args'_v89 = v96 
        #endif
#if FABLE_COMPILER_PYTHON
        let v97 : Result<std_path_PathBuf, std_io_Error> = v86 |> Ok
        let _run_target_args'_v89 = v97 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v98 : Result<std_path_PathBuf, std_io_Error> = v86 |> Ok
        let _run_target_args'_v89 = v98 
        #endif
#else
        let v99 : Result<std_path_PathBuf, std_io_Error> = v86 |> Ok
        let _run_target_args'_v89 = v99 
        #endif
        let v100 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v89 
        v100
    else
        let v103 : string = $"file_system.read_link / Fsharp / "
        let v104 : string = $"The file or directory is not a reparse point. / "
        let v105 : string = v103 + v104 
        let v106 : string = $"path: {v0} / result: {v32} / path': {v2} / n: {v1}"
        let v107 : string = v105 + v106 
        (* run_target_args'
        let v108 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v109 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v110 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v107 v109 
        let _run_target_args'_v108 = v110 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v111 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v112 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v107 v111 
        let _run_target_args'_v108 = v112 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v113 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v114 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v107 v113 
        let _run_target_args'_v108 = v114 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v115 : std_io_Error = v107 |> unbox<std_io_Error>
        let _run_target_args'_v108 = v115 
        #endif
#if FABLE_COMPILER_PYTHON
        let v118 : std_io_Error = v107 |> unbox<std_io_Error>
        let _run_target_args'_v108 = v118 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v121 : std_io_Error = v107 |> unbox<std_io_Error>
        let _run_target_args'_v108 = v121 
        #endif
#else
        let v124 : std_io_Error = v107 |> unbox<std_io_Error>
        let _run_target_args'_v108 = v124 
        #endif
        let v127 : std_io_Error = _run_target_args'_v108 
        let v132 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure55(v0)
        method121(v0, v132, v1, v127, v2)
and closure56 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method120(v0, v1, v2)
and closure55 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure56(v0, v1)
and method122 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method20(v0)
    let v5 : string option = method113(v0)
    let v6 : (string -> US5) = method5()
    let v7 : US5 option = v5 |> Option.map v6 
    let v18 : US5 = US5_1
    let v19 : US5 = v7 |> Option.defaultValue v18 
    let v23 : string = method44(v3)
    let v24 : bool = v2 >= 11uy
    if v24 then
        let v25 : string = $"file_system.read_link / "
        let v26 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v27 : string = v25 + v26 
        (* run_target_args'
        let v28 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v29 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v30 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v27 v29 
        let _run_target_args'_v28 = v30 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v31 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v32 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v27 v31 
        let _run_target_args'_v28 = v32 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v33 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v34 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v27 v33 
        let _run_target_args'_v28 = v34 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v35 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v35 
        #endif
#if FABLE_COMPILER_PYTHON
        let v38 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v38 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v41 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v41 
        #endif
#else
        let v44 : std_io_Error = v27 |> unbox<std_io_Error>
        let _run_target_args'_v28 = v44 
        #endif
        let v47 : std_io_Error = _run_target_args'_v28 
        (* run_target_args'
        let v52 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : string = "Err($0)"
        let v54 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v47 v53 
        let _run_target_args'_v52 = v54 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v55 : string = "Err($0)"
        let v56 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v47 v55 
        let _run_target_args'_v52 = v56 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v57 : string = "Err($0)"
        let v58 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v47 v57 
        let _run_target_args'_v52 = v58 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v59 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v59 
        #endif
#if FABLE_COMPILER_PYTHON
        let v60 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v60 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v61 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v61 
        #endif
#else
        let v62 : Result<std_path_PathBuf, std_io_Error> = v47 |> Error
        let _run_target_args'_v52 = v62 
        #endif
        let v63 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v52 
        v63
    else
        match v19 with
        | US5_0(v66) -> (* Some *)
            let v67 : string = ""
            let v68 : bool = v0 <> v67 
            if v68 then
                let v71 : uint8 = v2 + 1uy
                let v72 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v71
                let v73 : Result<std_path_PathBuf, std_io_Error> = v72 v66
                let v74 : (std_io_Error -> string) = method43()
                (* run_target_args'
                let v75 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76 : string = "$0.map_err(|x| $1(x))"
                let v77 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v73, v74) v76 
                let _run_target_args'_v75 = v77 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v78 : string = "$0.map_err(|x| $1(x))"
                let v79 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v73, v74) v78 
                let _run_target_args'_v75 = v79 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v80 : string = "$0.map_err(|x| $1(x))"
                let v81 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v73, v74) v80 
                let _run_target_args'_v75 = v81 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v82 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v82 
                #endif
#if FABLE_COMPILER_PYTHON
                let v83 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v83 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v84 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v84 
                #endif
#else
                let v85 : Result<std_path_PathBuf, string> = match v73 with Ok x -> Ok x | Error x -> Error (v74 x)
                let _run_target_args'_v75 = v85 
                #endif
                let v86 : Result<std_path_PathBuf, string> = _run_target_args'_v75 
                let v89 : (std_path_PathBuf -> US14) = method109()
                let v90 : (string -> US14) = method110()
                let v91 : US14 = match v86 with Ok x -> v89 x | Error x -> v90 x
                match v91 with
                | US14_1(v207) -> (* Error *)
                    let v208 : string = $"file_system.read_link / "
                    let v209 : string = $"error': {v207} / error: {v23} / name: {v4}"
                    let v210 : string = v208 + v209 
                    (* run_target_args'
                    let v211 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v212 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v213 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v210 v212 
                    let _run_target_args'_v211 = v213 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v214 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v215 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v210 v214 
                    let _run_target_args'_v211 = v215 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v216 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v217 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v210 v216 
                    let _run_target_args'_v211 = v217 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v218 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v218 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v221 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v221 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v224 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v224 
                    #endif
#else
                    let v227 : std_io_Error = v210 |> unbox<std_io_Error>
                    let _run_target_args'_v211 = v227 
                    #endif
                    let v230 : std_io_Error = _run_target_args'_v211 
                    (* run_target_args'
                    let v235 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v236 : string = "Err($0)"
                    let v237 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v230 v236 
                    let _run_target_args'_v235 = v237 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v238 : string = "Err($0)"
                    let v239 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v230 v238 
                    let _run_target_args'_v235 = v239 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v240 : string = "Err($0)"
                    let v241 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v230 v240 
                    let _run_target_args'_v235 = v241 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v242 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v242 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v243 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v243 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v244 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v244 
                    #endif
#else
                    let v245 : Result<std_path_PathBuf, std_io_Error> = v230 |> Error
                    let _run_target_args'_v235 = v245 
                    #endif
                    let v246 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v235 
                    v246
                | US14_0(v92) -> (* Ok *)
                    (* run_target_args'
                    let v93 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v94 : string = "$0.display()"
                    let v95 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v92 v94 
                    let _run_target_args'_v93 = v95 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v96 : string = "$0.display()"
                    let v97 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v92 v96 
                    let _run_target_args'_v93 = v97 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v98 : string = "$0.display()"
                    let v99 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v92 v98 
                    let _run_target_args'_v93 = v99 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v100 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v100 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v103 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v103 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v106 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v106 
                    #endif
#else
                    let v109 : std_path_Display = v92 |> unbox<std_path_Display>
                    let _run_target_args'_v93 = v109 
                    #endif
                    let v112 : std_path_Display = _run_target_args'_v93 
                    let v117 : string = v112 |> string 
                    let v120 : string = method86(v117, v4)
                    (* run_target_args'
                    let v121 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v122 : string = "&*$0"
                    let v123 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v120 v122 
                    let _run_target_args'_v121 = v123 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v124 : string = "&*$0"
                    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v120 v124 
                    let _run_target_args'_v121 = v125 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v126 : string = "&*$0"
                    let v127 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v120 v126 
                    let _run_target_args'_v121 = v127 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v128 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v128 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v131 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v131 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v134 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v134 
                    #endif
#else
                    let v137 : Ref<Str> = v120 |> unbox<Ref<Str>>
                    let _run_target_args'_v121 = v137 
                    #endif
                    let v140 : Ref<Str> = _run_target_args'_v121 
                    (* run_target_args'
                    let v145 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v146 : string = "String::from($0)"
                    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v140 v146 
                    let _run_target_args'_v145 = v147 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v148 : string = "String::from($0)"
                    let v149 : std_string_String = Fable.Core.RustInterop.emitRustExpr v140 v148 
                    let _run_target_args'_v145 = v149 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v150 : string = "String::from($0)"
                    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v140 v150 
                    let _run_target_args'_v145 = v151 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v152 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v152 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v155 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v155 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v158 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v158 
                    #endif
#else
                    let v161 : std_string_String = v140 |> unbox<std_string_String>
                    let _run_target_args'_v145 = v161 
                    #endif
                    let v164 : std_string_String = _run_target_args'_v145 
                    (* run_target_args'
                    let v169 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v170 : string = "std::path::PathBuf::from($0)"
                    let v171 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v164 v170 
                    let _run_target_args'_v169 = v171 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v172 : string = "std::path::PathBuf::from($0)"
                    let v173 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v164 v172 
                    let _run_target_args'_v169 = v173 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v174 : string = "std::path::PathBuf::from($0)"
                    let v175 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v164 v174 
                    let _run_target_args'_v169 = v175 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v176 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v176 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v179 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v179 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v182 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v182 
                    #endif
#else
                    let v185 : std_path_PathBuf = v164 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v169 = v185 
                    #endif
                    let v188 : std_path_PathBuf = _run_target_args'_v169 
                    (* run_target_args'
                    let v193 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v194 : string = "Ok($0)"
                    let v195 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v188 v194 
                    let _run_target_args'_v193 = v195 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v196 : string = "Ok($0)"
                    let v197 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v188 v196 
                    let _run_target_args'_v193 = v197 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v198 : string = "Ok($0)"
                    let v199 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v188 v198 
                    let _run_target_args'_v193 = v199 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v200 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v200 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v201 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v201 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v202 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v202 
                    #endif
#else
                    let v203 : Result<std_path_PathBuf, std_io_Error> = v188 |> Ok
                    let _run_target_args'_v193 = v203 
                    #endif
                    let v204 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v193 
                    v204
            else
                let v251 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v252 : string = $"path: {v0} / error: {v23} / path': {v0} / name: {v4}"
                let v253 : string = v251 + v252 
                (* run_target_args'
                let v254 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v255 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v256 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v253 v255 
                let _run_target_args'_v254 = v256 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v257 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v258 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v253 v257 
                let _run_target_args'_v254 = v258 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v259 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v260 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v253 v259 
                let _run_target_args'_v254 = v260 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v261 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v261 
                #endif
#if FABLE_COMPILER_PYTHON
                let v264 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v264 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v267 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v267 
                #endif
#else
                let v270 : std_io_Error = v253 |> unbox<std_io_Error>
                let _run_target_args'_v254 = v270 
                #endif
                let v273 : std_io_Error = _run_target_args'_v254 
                (* run_target_args'
                let v278 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v279 : string = "Err($0)"
                let v280 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v273 v279 
                let _run_target_args'_v278 = v280 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v281 : string = "Err($0)"
                let v282 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v273 v281 
                let _run_target_args'_v278 = v282 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v283 : string = "Err($0)"
                let v284 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v273 v283 
                let _run_target_args'_v278 = v284 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v285 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v285 
                #endif
#if FABLE_COMPILER_PYTHON
                let v286 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v286 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v287 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v287 
                #endif
#else
                let v288 : Result<std_path_PathBuf, std_io_Error> = v273 |> Error
                let _run_target_args'_v278 = v288 
                #endif
                let v289 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v278 
                v289
        | _ ->
            let v293 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v294 : string = $"path: {v0} / error: {v23} / path': {v0} / name: {v4}"
            let v295 : string = v293 + v294 
            (* run_target_args'
            let v296 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v297 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v298 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v297 
            let _run_target_args'_v296 = v298 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v299 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v300 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v299 
            let _run_target_args'_v296 = v300 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v301 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v302 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v301 
            let _run_target_args'_v296 = v302 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v303 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v303 
            #endif
#if FABLE_COMPILER_PYTHON
            let v306 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v306 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v309 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v309 
            #endif
#else
            let v312 : std_io_Error = v295 |> unbox<std_io_Error>
            let _run_target_args'_v296 = v312 
            #endif
            let v315 : std_io_Error = _run_target_args'_v296 
            (* run_target_args'
            let v320 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v321 : string = "Err($0)"
            let v322 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v315 v321 
            let _run_target_args'_v320 = v322 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v323 : string = "Err($0)"
            let v324 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v315 v323 
            let _run_target_args'_v320 = v324 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v325 : string = "Err($0)"
            let v326 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v315 v325 
            let _run_target_args'_v320 = v326 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v327 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v327 
            #endif
#if FABLE_COMPILER_PYTHON
            let v328 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v328 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v329 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v329 
            #endif
#else
            let v330 : Result<std_path_PathBuf, std_io_Error> = v315 |> Error
            let _run_target_args'_v320 = v330 
            #endif
            let v331 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v320 
            v331
and method116 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v2 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v12 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v2 = v12 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v2 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let _run_target_args'_v2 = v18 
    #endif
#else
    let v21 : System_IO_DirectoryInfo = v0 |> System_IO_DirectoryInfo 
    let _run_target_args'_v2 = v21 
    #endif
    let v24 : System_IO_DirectoryInfo = _run_target_args'_v2 
    let v29 : System.IO.FileAttributes = method117(v24)
    let v30 : System.IO.FileAttributes = method118()
    let v31 : bool = method119(v30, v29)
    if v31 then
        (* run_target_args'
        let v32 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v33 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v32 = v33 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v36 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v32 = v36 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v39 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v32 = v39 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v42 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v32 = v42 
        #endif
#if FABLE_COMPILER_PYTHON
        let v45 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v32 = v45 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v48 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v32 = v48 
        #endif
#else
        let v51 : System_IO_FileInfo = v0 |> System_IO_FileInfo 
        let _run_target_args'_v32 = v51 
        #endif
        let v54 : System_IO_FileInfo = _run_target_args'_v32 
        (* run_target_args'
        let v59 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v60 : string = null |> unbox<string>
        let _run_target_args'_v59 = v60 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v63 : string = null |> unbox<string>
        let _run_target_args'_v59 = v63 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v66 : string = null |> unbox<string>
        let _run_target_args'_v59 = v66 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v69 : string = null |> unbox<string>
        let _run_target_args'_v59 = v69 
        #endif
#if FABLE_COMPILER_PYTHON
        let v72 : string = null |> unbox<string>
        let _run_target_args'_v59 = v72 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = null |> unbox<string>
        let _run_target_args'_v59 = v75 
        #endif
#else
        let v78 : (System_IO_FileInfo -> string) = _.LinkTarget
        let v79 : string = v78 v54
        let _run_target_args'_v59 = v79 
        #endif
        let v80 : string = _run_target_args'_v59 
        let v85 : std_path_PathBuf = v80 |> unbox<std_path_PathBuf>
        (* run_target_args'
        let v88 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v89 : string = "Ok($0)"
        let v90 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v89 
        let _run_target_args'_v88 = v90 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v91 : string = "Ok($0)"
        let v92 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v91 
        let _run_target_args'_v88 = v92 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v93 : string = "Ok($0)"
        let v94 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v93 
        let _run_target_args'_v88 = v94 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v95 : Result<std_path_PathBuf, std_io_Error> = v85 |> Ok
        let _run_target_args'_v88 = v95 
        #endif
#if FABLE_COMPILER_PYTHON
        let v96 : Result<std_path_PathBuf, std_io_Error> = v85 |> Ok
        let _run_target_args'_v88 = v96 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v97 : Result<std_path_PathBuf, std_io_Error> = v85 |> Ok
        let _run_target_args'_v88 = v97 
        #endif
#else
        let v98 : Result<std_path_PathBuf, std_io_Error> = v85 |> Ok
        let _run_target_args'_v88 = v98 
        #endif
        let v99 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v88 
        v99
    else
        let v102 : string = $"file_system.read_link / Fsharp / "
        let v103 : string = $"The file or directory is not a reparse point. / "
        let v104 : string = v102 + v103 
        let v105 : string = $"path: {v0} / result: {v31} / path': {v0} / n: {v1}"
        let v106 : string = v104 + v105 
        (* run_target_args'
        let v107 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v108 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v109 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v106 v108 
        let _run_target_args'_v107 = v109 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v110 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v111 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v106 v110 
        let _run_target_args'_v107 = v111 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v112 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v113 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v106 v112 
        let _run_target_args'_v107 = v113 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v114 : std_io_Error = v106 |> unbox<std_io_Error>
        let _run_target_args'_v107 = v114 
        #endif
#if FABLE_COMPILER_PYTHON
        let v117 : std_io_Error = v106 |> unbox<std_io_Error>
        let _run_target_args'_v107 = v117 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v120 : std_io_Error = v106 |> unbox<std_io_Error>
        let _run_target_args'_v107 = v120 
        #endif
#else
        let v123 : std_io_Error = v106 |> unbox<std_io_Error>
        let _run_target_args'_v107 = v123 
        #endif
        let v126 : std_io_Error = _run_target_args'_v107 
        let v131 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure55(v0)
        method122(v0, v131, v1, v126)
and method107 (v0 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : bool = method10(v0)
    let v7 : Result<std_path_PathBuf, std_io_Error> =
        if v2 then
            let v3 : string = "std::fs::read_link(&*$0)"
            let v4 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v3 
            v4
        else
            let v5 : uint8 = 0uy
            method108(v0, v5)
    let _run_target_args'_v1 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : bool = method10(v0)
    let v13 : Result<std_path_PathBuf, std_io_Error> =
        if v8 then
            let v9 : string = "std::fs::read_link(&*$0)"
            let v10 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v9 
            v10
        else
            let v11 : uint8 = 0uy
            method108(v0, v11)
    let _run_target_args'_v1 = v13 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v14 : bool = method10(v0)
    let v19 : Result<std_path_PathBuf, std_io_Error> =
        if v14 then
            let v15 : string = "std::fs::read_link(&*$0)"
            let v16 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v15 
            v16
        else
            let v17 : uint8 = 0uy
            method108(v0, v17)
    let _run_target_args'_v1 = v19 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : uint8 = 0uy
    let v21 : Result<std_path_PathBuf, std_io_Error> = method116(v0, v20)
    let _run_target_args'_v1 = v21 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22 : Result<std_path_PathBuf, std_io_Error> = Unchecked.defaultof<_>
    let _run_target_args'_v1 = v22 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v23 : uint8 = 0uy
    let v24 : Result<std_path_PathBuf, std_io_Error> = method116(v0, v23)
    let _run_target_args'_v1 = v24 
    #endif
#else
    let v25 : uint8 = 0uy
    let v26 : Result<std_path_PathBuf, std_io_Error> = method116(v0, v25)
    let _run_target_args'_v1 = v26 
    #endif
    let v27 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v1 
    v27
and closure57 () (v0 : std_path_PathBuf) : US15 =
    US15_0(v0)
and method123 () : (std_path_PathBuf -> US15) =
    closure57()
and method125 (v0 : string) : string =
    v0
and method126 () : string =
    let v0 : string = ""
    v0
and method124 (v0 : string, v1 : string, v2 : string) : string =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = $"regex::Regex::new(&$0)"
    let v5 : Result<regex_Regex, regex_Error> = Fable.Core.RustInterop.emitRustExpr v0 v4 
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "$0.unwrap()"
    let v8 : regex_Regex = Fable.Core.RustInterop.emitRustExpr v5 v7 
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v9 : string = "$0.unwrap()"
    let v10 : regex_Regex = Fable.Core.RustInterop.emitRustExpr v5 v9 
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v11 : string = "$0.unwrap()"
    let v12 : regex_Regex = Fable.Core.RustInterop.emitRustExpr v5 v11 
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v13 : regex_Regex = match v5 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v6 = v13 
    #endif
#if FABLE_COMPILER_PYTHON
    let v14 : regex_Regex = match v5 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v6 = v14 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : regex_Regex = match v5 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v6 = v15 
    #endif
#else
    let v16 : regex_Regex = match v5 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v6 = v16 
    #endif
    let v17 : regex_Regex = _run_target_args'_v6 
    let v20 : string = method125(v2)
    let v21 : string = $"$0.replace_all(&*$1, &*$2)"
    let v22 : std_borrow_Cow<Str> = Fable.Core.RustInterop.emitRustExpr struct (v17, v20, v1) v21 
    let v23 : string = "String::from($0)"
    let v24 : std_string_String = Fable.Core.RustInterop.emitRustExpr v22 v23 
    let v25 : string = "fable_library_rust::String_::fromString($0)"
    let v26 : string = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let _run_target_args'_v3 = v26 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v27 : string = method126()
    let _run_target_args'_v3 = v27 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v28 : string = method126()
    let _run_target_args'_v3 = v28 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v29 : string = method126()
    let _run_target_args'_v3 = v29 
    #endif
#if FABLE_COMPILER_PYTHON
    let v30 : string = method126()
    let _run_target_args'_v3 = v30 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v31 : string = method126()
    let _run_target_args'_v3 = v31 
    #endif
#else
    let v32 : string = System.Text.RegularExpressions.Regex.Replace (v2, v0, v1)
    let _run_target_args'_v3 = v32 
    #endif
    let v33 : string = _run_target_args'_v3 
    v33
and method106 (v0 : string) : string =
    let v1 : bool = v0 = ""
    if v1 then
        let v2 : string = ""
        v2
    else
        let v3 : Result<std_path_PathBuf, std_io_Error> = method107(v0)
        (* run_target_args'
        let v4 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v5 : string = "$0.ok()"
        let v6 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v3 v5 
        let _run_target_args'_v4 = v6 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v7 : string = "$0.ok()"
        let v8 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v3 v7 
        let _run_target_args'_v4 = v8 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v9 : string = "$0.ok()"
        let v10 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v3 v9 
        let _run_target_args'_v4 = v10 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v11 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v4 = v11 
        #endif
#if FABLE_COMPILER_PYTHON
        let v12 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v4 = v12 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v13 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v4 = v13 
        #endif
#else
        let v14 : std_path_PathBuf option = match v3 with Ok x -> Some x | Error _ -> None
        let _run_target_args'_v4 = v14 
        #endif
        let v15 : std_path_PathBuf option = _run_target_args'_v4 
        let v18 : (std_path_PathBuf -> US15) = method123()
        let v19 : US15 option = v15 |> Option.map v18 
        let v30 : US15 = US15_1
        let v31 : US15 = v19 |> Option.defaultValue v30 
        let v64 : string =
            match v31 with
            | US15_1 -> (* None *)
                v0
            | US15_0(v35) -> (* Some *)
                (* run_target_args'
                let v36 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v37 : string = "$0.display()"
                let v38 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v35 v37 
                let _run_target_args'_v36 = v38 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v39 : string = "$0.display()"
                let v40 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v35 v39 
                let _run_target_args'_v36 = v40 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v41 : string = "$0.display()"
                let v42 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v35 v41 
                let _run_target_args'_v36 = v42 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v43 : std_path_Display = v35 |> unbox<std_path_Display>
                let _run_target_args'_v36 = v43 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46 : std_path_Display = v35 |> unbox<std_path_Display>
                let _run_target_args'_v36 = v46 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v49 : std_path_Display = v35 |> unbox<std_path_Display>
                let _run_target_args'_v36 = v49 
                #endif
#else
                let v52 : std_path_Display = v35 |> unbox<std_path_Display>
                let _run_target_args'_v36 = v52 
                #endif
                let v55 : std_path_Display = _run_target_args'_v36 
                let v60 : string = v55 |> string 
                v60
        let v65 : bool = v64 = ""
        let v66 : string =
            if v65 then
                v0
            else
                v64
        let v67 : string = "^\\\\\\\\\\?\\\\"
        let v68 : string = ""
        let v69 : string = method124(v67, v68, v66)
        let v70 : int32 = v69.Length
        let v71 : bool = v70 < 2
        if v71 then
            v0
        else
            let v72 : string = $"{v69.[0] |> string |> _.ToLower()}{v69.[1..]}"
            let v73 : string = "\\"
            let v74 : string = "/"
            let v75 : string = v72.Replace (v73, v74)
            v75
and closure50 () (v0 : string) : string =
    method106(v0)
and method128 () : string =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "std::env::current_dir()"
    let v2 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr () v1 
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4 : string = "$0.unwrap()"
    let v5 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v2 v4 
    let _run_target_args'_v3 = v5 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v6 : string = "$0.unwrap()"
    let v7 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v2 v6 
    let _run_target_args'_v3 = v7 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v8 : string = "$0.unwrap()"
    let v9 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let _run_target_args'_v3 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : std_path_PathBuf = match v2 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v3 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : std_path_PathBuf = match v2 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v3 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : std_path_PathBuf = match v2 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v3 = v12 
    #endif
#else
    let v13 : std_path_PathBuf = match v2 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v3 = v13 
    #endif
    let v14 : std_path_PathBuf = _run_target_args'_v3 
    (* run_target_args'
    let v17 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v18 : string = "$0.display()"
    let v19 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v14 v18 
    let _run_target_args'_v17 = v19 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v20 : string = "$0.display()"
    let v21 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v14 v20 
    let _run_target_args'_v17 = v21 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v22 : string = "$0.display()"
    let v23 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v14 v22 
    let _run_target_args'_v17 = v23 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v24 : std_path_Display = v14 |> unbox<std_path_Display>
    let _run_target_args'_v17 = v24 
    #endif
#if FABLE_COMPILER_PYTHON
    let v27 : std_path_Display = v14 |> unbox<std_path_Display>
    let _run_target_args'_v17 = v27 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v30 : std_path_Display = v14 |> unbox<std_path_Display>
    let _run_target_args'_v17 = v30 
    #endif
#else
    let v33 : std_path_Display = v14 |> unbox<std_path_Display>
    let _run_target_args'_v17 = v33 
    #endif
    let v36 : std_path_Display = _run_target_args'_v17 
    (* run_target_args'
    let v41 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v42 : string = "format!(\"{}\", $0)"
    let v43 : std_string_String = Fable.Core.RustInterop.emitRustExpr v36 v42 
    let _run_target_args'_v41 = v43 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v44 : string = "format!(\"{}\", $0)"
    let v45 : std_string_String = Fable.Core.RustInterop.emitRustExpr v36 v44 
    let _run_target_args'_v41 = v45 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v46 : string = "format!(\"{}\", $0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v36 v46 
    let _run_target_args'_v41 = v47 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v48 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v41 = v48 
    #endif
#if FABLE_COMPILER_PYTHON
    let v51 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v41 = v51 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v54 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v41 = v54 
    #endif
#else
    let v57 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v41 = v57 
    #endif
    let v60 : std_string_String = _run_target_args'_v41 
    let v65 : string = "fable_library_rust::String_::fromString($0)"
    let v66 : string = Fable.Core.RustInterop.emitRustExpr v60 v65 
    let _run_target_args'_v0 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : string = null |> unbox<string>
    let _run_target_args'_v0 = v67 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v70 : string = null |> unbox<string>
    let _run_target_args'_v0 = v70 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v73 : string = null |> unbox<string>
    let _run_target_args'_v0 = v73 
    #endif
#if FABLE_COMPILER_PYTHON
    let v76 : string = null |> unbox<string>
    let _run_target_args'_v0 = v76 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v79 : string = null |> unbox<string>
    let _run_target_args'_v0 = v79 
    #endif
#else
    let v82 : (unit -> string) = System.IO.Directory.GetCurrentDirectory
    let v83 : string = v82 ()
    let _run_target_args'_v0 = v83 
    #endif
    let v84 : string = _run_target_args'_v0 
    v84
and method129 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method130 (v0 : int32, v1 : Mut6) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method131 () : char =
    (* run_target_args'
    let v0 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1 : string = "std::path::MAIN_SEPARATOR"
    let v2 : char = Fable.Core.RustInterop.emitRustExpr () v1 
    let _run_target_args'_v0 = v2 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3 : string = "std::path::MAIN_SEPARATOR"
    let v4 : char = Fable.Core.RustInterop.emitRustExpr () v3 
    let _run_target_args'_v0 = v4 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5 : string = "std::path::MAIN_SEPARATOR"
    let v6 : char = Fable.Core.RustInterop.emitRustExpr () v5 
    let _run_target_args'_v0 = v6 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let _run_target_args'_v0 = '/' 
    #endif
#if FABLE_COMPILER_PYTHON
    let _run_target_args'_v0 = '/' 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v7 : char = System.IO.Path.DirectorySeparatorChar
    let _run_target_args'_v0 = v7 
    #endif
#else
    let v8 : char = System.IO.Path.DirectorySeparatorChar
    let _run_target_args'_v0 = v8 
    #endif
    let v9 : char = _run_target_args'_v0 
    v9
and method132 (v0 : string) : string =
    v0
and method127 (v0 : string) : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = "&*$0"
    let v4 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v3 
    let _run_target_args'_v2 = v4 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5 : string = "&*$0"
    let v6 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v5 
    let _run_target_args'_v2 = v6 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v7 : string = "&*$0"
    let v8 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let _run_target_args'_v2 = v8 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v9 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v9 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v12 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v15 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v15 
    #endif
#else
    let v18 : Ref<Str> = v0 |> unbox<Ref<Str>>
    let _run_target_args'_v2 = v18 
    #endif
    let v21 : Ref<Str> = _run_target_args'_v2 
    (* run_target_args'
    let v26 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v27 : string = "String::from($0)"
    let v28 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v27 
    let _run_target_args'_v26 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = "String::from($0)"
    let v30 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v29 
    let _run_target_args'_v26 = v30 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v31 : string = "String::from($0)"
    let v32 : std_string_String = Fable.Core.RustInterop.emitRustExpr v21 v31 
    let _run_target_args'_v26 = v32 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v33 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v33 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v36 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v39 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v39 
    #endif
#else
    let v42 : std_string_String = v21 |> unbox<std_string_String>
    let _run_target_args'_v26 = v42 
    #endif
    let v45 : std_string_String = _run_target_args'_v26 
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = "std::path::PathBuf::from($0)"
    let v52 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v51 
    let _run_target_args'_v50 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : string = "std::path::PathBuf::from($0)"
    let v54 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v53 
    let _run_target_args'_v50 = v54 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v55 : string = "std::path::PathBuf::from($0)"
    let v56 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v45 v55 
    let _run_target_args'_v50 = v56 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v57 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v57 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v63 
    #endif
#else
    let v66 : std_path_PathBuf = v45 |> unbox<std_path_PathBuf>
    let _run_target_args'_v50 = v66 
    #endif
    let v69 : std_path_PathBuf = _run_target_args'_v50 
    let v74 : string = "$0.exists()"
    let v75 : bool = Fable.Core.RustInterop.emitRustExpr v69 v74 
    let v76 : bool = v75 = false
    let v232 : string =
        if v76 then
            let v77 : string = method128()
            let v78 : string = method86(v77, v0)
            let v79 : string = method106(v78)
            let v80 : string = "/"
            let v81 : (string []) = v79.Split v80 
            let v84 : (string []) = [||]
            let v85 : int32 = v81.Length
            let v86 : Mut5 = {l0 = 0; l1 = 0; l2 = v84} : Mut5
            while method129(v85, v86) do
                let v88 : int32 = v86.l0
                let v89 : int32 =  -v88
                let v90 : int32 = v89 + v85
                let v91 : int32 = v90 - 1
                let struct (v92 : int32, v93 : (string [])) = v86.l1, v86.l2
                let v94 : string = v81.[int v91]
                let v95 : bool = ".." = v94
                let struct (v139 : int32, v140 : (string [])) =
                    if v95 then
                        let v96 : int32 = v92 + 1
                        struct (v96, v93)
                    else
                        let v97 : bool = "." = v94
                        if v97 then
                            struct (v92, v93)
                        else
                            let v98 : bool = 0 = v92
                            if v98 then
                                let v99 : string = ":"
                                let v100 : bool = v94.EndsWith (v99, false, null)
                                if v100 then
                                    let v103 : string = $"{v77.[0]}:"
                                    let v104 : (string []) = [|v103|]
                                    let v105 : int32 = v104.Length
                                    let v106 : int32 = v93.Length
                                    let v107 : int32 = v105 + v106
                                    let v108 : (string []) = Array.zeroCreate<string> (v107)
                                    let v109 : Mut6 = {l0 = 0} : Mut6
                                    while method130(v107, v109) do
                                        let v111 : int32 = v109.l0
                                        let v112 : bool = v111 < v105
                                        let v116 : string =
                                            if v112 then
                                                let v113 : string = v104.[int v111]
                                                v113
                                            else
                                                let v114 : int32 = v111 - v105
                                                let v115 : string = v93.[int v114]
                                                v115
                                        v108.[int v111] <- v116
                                        let v117 : int32 = v111 + 1
                                        v109.l0 <- v117
                                        ()
                                    struct (0, v108)
                                else
                                    let v118 : (string []) = [|v94|]
                                    let v119 : int32 = v118.Length
                                    let v120 : int32 = v93.Length
                                    let v121 : int32 = v119 + v120
                                    let v122 : (string []) = Array.zeroCreate<string> (v121)
                                    let v123 : Mut6 = {l0 = 0} : Mut6
                                    while method130(v121, v123) do
                                        let v125 : int32 = v123.l0
                                        let v126 : bool = v125 < v119
                                        let v130 : string =
                                            if v126 then
                                                let v127 : string = v118.[int v125]
                                                v127
                                            else
                                                let v128 : int32 = v125 - v119
                                                let v129 : string = v93.[int v128]
                                                v129
                                        v122.[int v125] <- v130
                                        let v131 : int32 = v125 + 1
                                        v123.l0 <- v131
                                        ()
                                    struct (0, v122)
                            else
                                let v134 : int32 = v92 - 1
                                struct (v134, v93)
                let v141 : int32 = v88 + 1
                v86.l0 <- v141
                v86.l1 <- v139
                v86.l2 <- v140
                ()
            let struct (v142 : int32, v143 : (string [])) = v86.l1, v86.l2
            let v144 : unit = ()
            let _let'_v144 =
                seq {
                    for i = 0 to v143.Length - 1 do yield v143.[i]
                    (* indent
                    ()
                indent *)
                }
                (* indent
                ()
            indent *)
            let v147 : string seq = _let'_v144 
            let v153 : char = method131()
            let v154 : (char -> string) = _.ToString()
            let v155 : string = v154 v153
            let v158 : bool = v155 = "\n"
            let v160 : string =
                if v158 then
                    method132(v155)
                else
                    v155
            let v161 : (string -> (string seq -> string)) = String.concat
            let v162 : (string seq -> string) = v161 v160
            v162 v147
        else
            let v166 : string = "std::fs::canonicalize(&*$0)"
            let v167 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v166 
            (* run_target_args'
            let v168 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v169 : string = "$0.unwrap()"
            let v170 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v167 v169 
            let _run_target_args'_v168 = v170 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v171 : string = "$0.unwrap()"
            let v172 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v167 v171 
            let _run_target_args'_v168 = v172 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v173 : string = "$0.unwrap()"
            let v174 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v167 v173 
            let _run_target_args'_v168 = v174 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v175 : std_path_PathBuf = match v167 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v168 = v175 
            #endif
#if FABLE_COMPILER_PYTHON
            let v176 : std_path_PathBuf = match v167 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v168 = v176 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v177 : std_path_PathBuf = match v167 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v168 = v177 
            #endif
#else
            let v178 : std_path_PathBuf = match v167 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v168 = v178 
            #endif
            let v179 : std_path_PathBuf = _run_target_args'_v168 
            (* run_target_args'
            let v182 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v183 : string = "$0.display()"
            let v184 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v179 v183 
            let _run_target_args'_v182 = v184 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v185 : string = "$0.display()"
            let v186 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v179 v185 
            let _run_target_args'_v182 = v186 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v187 : string = "$0.display()"
            let v188 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v179 v187 
            let _run_target_args'_v182 = v188 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v189 : std_path_Display = v179 |> unbox<std_path_Display>
            let _run_target_args'_v182 = v189 
            #endif
#if FABLE_COMPILER_PYTHON
            let v192 : std_path_Display = v179 |> unbox<std_path_Display>
            let _run_target_args'_v182 = v192 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v195 : std_path_Display = v179 |> unbox<std_path_Display>
            let _run_target_args'_v182 = v195 
            #endif
#else
            let v198 : std_path_Display = v179 |> unbox<std_path_Display>
            let _run_target_args'_v182 = v198 
            #endif
            let v201 : std_path_Display = _run_target_args'_v182 
            (* run_target_args'
            let v206 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v207 : string = "format!(\"{}\", $0)"
            let v208 : std_string_String = Fable.Core.RustInterop.emitRustExpr v201 v207 
            let _run_target_args'_v206 = v208 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v209 : string = "format!(\"{}\", $0)"
            let v210 : std_string_String = Fable.Core.RustInterop.emitRustExpr v201 v209 
            let _run_target_args'_v206 = v210 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v211 : string = "format!(\"{}\", $0)"
            let v212 : std_string_String = Fable.Core.RustInterop.emitRustExpr v201 v211 
            let _run_target_args'_v206 = v212 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v213 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v206 = v213 
            #endif
#if FABLE_COMPILER_PYTHON
            let v216 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v206 = v216 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v219 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v206 = v219 
            #endif
#else
            let v222 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v206 = v222 
            #endif
            let v225 : std_string_String = _run_target_args'_v206 
            let v230 : string = "fable_library_rust::String_::fromString($0)"
            let v231 : string = Fable.Core.RustInterop.emitRustExpr v225 v230 
            v231
    let _run_target_args'_v1 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = null |> unbox<string>
    let _run_target_args'_v1 = v233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v236 : string = null |> unbox<string>
    let _run_target_args'_v1 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v239 : string = null |> unbox<string>
    let _run_target_args'_v1 = v239 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : string = null |> unbox<string>
    let _run_target_args'_v1 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v245 : string = null |> unbox<string>
    let _run_target_args'_v1 = v245 
    #endif
#else
    let v248 : (string -> string) = System.IO.Path.GetFullPath
    let v249 : string = v248 v0
    let _run_target_args'_v1 = v249 
    #endif
    let v250 : string = _run_target_args'_v1 
    v250
and closure58 () (v0 : string) : string =
    method127(v0)
and method133 (v0 : string) : string =
    let v1 : string = method127(v0)
    method106(v1)
and closure59 () (v0 : string) : string =
    method133(v0)
and closure60 () (v0 : string) : string =
    let v1 : char list = []
    let v2 : char list = '/' :: v1 
    let v5 : (char list -> (char [])) = List.toArray
    let v6 : (char []) = v5 v2
    let v9 : string = v0.TrimStart v6 
    let v33 : string = $"file:///{v9}"
    v33
and method136 (v0 : string, v1 : string, v2 : string) : US16 =
    let v3 : string = method86(v2, v0)
    let v4 : bool = method10(v3)
    if v4 then
        US16_0(v2)
    else
        let v6 : string option = method113(v2)
        let v7 : (string -> US5) = method5()
        let v8 : US5 option = v6 |> Option.map v7 
        let v19 : US5 = US5_1
        let v20 : US5 = v8 |> Option.defaultValue v19 
        match v20 with
        | US5_1 -> (* None *)
            let v26 : string = $"""No parent for {if false then "file" else "dir"} '{v0}'"""
            let v27 : string = $" at '{v1}' (until '{v2}')"
            let v28 : string = v26 + v27 
            US16_1(v28)
        | US5_0(v24) -> (* Some *)
            method136(v0, v1, v24)
and method135 (v0 : string, v1 : string) : US16 =
    let v2 : string = method86(v1, v0)
    let v3 : bool = method10(v2)
    if v3 then
        US16_0(v1)
    else
        let v5 : string option = method113(v1)
        let v6 : (string -> US5) = method5()
        let v7 : US5 option = v5 |> Option.map v6 
        let v18 : US5 = US5_1
        let v19 : US5 = v7 |> Option.defaultValue v18 
        match v19 with
        | US5_1 -> (* None *)
            let v25 : string = $"""No parent for {if false then "file" else "dir"} '{v0}'"""
            let v26 : string = $" at '{v1}' (until '{v1}')"
            let v27 : string = v25 + v26 
            US16_1(v27)
        | US5_0(v23) -> (* Some *)
            method136(v0, v1, v23)
and method138 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v4 : string = "{ "
    let v5 : string = $"{v4}"
    let v8 : unit = ()
    let v9 : (unit -> unit) = closure6(v3, v5)
    let v10 : unit = (fun () -> v9 (); v8) ()
    let v13 : string = "dir"
    let v14 : string = $"{v13}"
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure6(v3, v14)
    let v19 : unit = (fun () -> v18 (); v17) ()
    let v22 : string = " = "
    let v23 : string = $"{v22}"
    let v26 : unit = ()
    let v27 : (unit -> unit) = closure6(v3, v23)
    let v28 : unit = (fun () -> v27 (); v26) ()
    let v31 : string = $"{v0}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v31)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v39 : string = "; "
    let v40 : string = $"{v39}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v3, v40)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v48 : string = "error"
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v57 : string = $"{v22}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v3, v57)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v65 : string = $"{v1}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure6(v3, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v73 : string = " }"
    let v74 : string = $"{v73}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v3, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v82 : string = v3.l0
    v82
and method137 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method138(v8, v9)
    let v11 : int64 = v0.l0
    let v12 : string = "file_system.get_workspace_root"
    let v13 : string = $"{v6} {v7} #{v11} %s{v12} / {v10}"
    method23(v13)
and closure62 (v0 : string, v1 : string) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method11(v2)
    if v3 then
        let v4 : unit = ()
        let v5 : (unit -> unit) = closure0()
        let v6 : unit = (fun () -> v5 (); v4) ()
        let struct (v20 : Mut0, v21 : Mut1, v22 : Mut2, v23 : Mut3, v24 : Mut4, v25 : int64 option) = TraceState.trace_state.Value
        let v38 : string = method12(v20, v21, v22, v23, v24, v25)
        let v39 : string = method50()
        let v40 : string = method137(v20, v21, v22, v23, v24, v25, v38, v39, v0, v1)
        method24(v40)
and method134 (v0 : string) : US5 =
    let v1 : string = "spiral"
    let v2 : string = "workspace"
    let v3 : string = method86(v1, v2)
    let v4 : US16 = method135(v3, v0)
    match v4 with
    | US16_1(v8) -> (* Error *)
        let v9 : unit = ()
        let v10 : (unit -> unit) = closure62(v0, v8)
        let v11 : unit = (fun () -> v10 (); v9) ()
        US5_1
    | US16_0(v5) -> (* Ok *)
        let v6 : string = method106(v5)
        US5_0(v6)
and closure61 () () : string =
    let v0 : string = __SOURCE_DIRECTORY__
    let v1 : US5 = method134(v0)
    let v7 : US5 =
        match v1 with
        | US5_1 -> (* None *)
            let v4 : string = method128()
            method134(v4)
        | US5_0(v2) -> (* Some *)
            US5_0(v2)
    let v11 : string =
        match v7 with
        | US5_1 -> (* None *)
            failwith<string> "Option does not have a value."
        | US5_0(v8) -> (* Some *)
            v8
    let v12 : string = method20(v11)
    let v13 : bool = "deps" = v12
    let v23 : string =
        if v13 then
            let v14 : string option = method113(v11)
            let v15 : string = v14 |> Option.get
            let v18 : US5 = method134(v15)
            match v18 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v19) -> (* Some *)
                v19
        else
            v11
    let v24 : string = "polyglot"
    method86(v23, v24)
and closure64 (v0 : exn) () : exn =
    v0
and method139 (v0 : string) : unit =
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
        let v2 : string = method87()
        (* run_target_args'
        let v3 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v4 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v3 = v4 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v5 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v3 = v5 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v6 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3 = v6 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v9 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v3 = v9 
        #endif
#if FABLE_COMPILER_PYTHON
        let v10 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v3 = v10 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v11 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v3 = v11 
        #endif
#else
        let v12 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v3 = v12 
        #endif
        let v13 : System.DateTime = _run_target_args'_v3 
        let v18 : (unit -> System.Guid) = System.Guid.NewGuid
        let v19 : System.Guid = v18 ()
        let v22 : System.Guid = method78(v19, v13)
        let v23 : string = $"{v2}_{v22}.txt"
        let v24 : string = __SOURCE_DIRECTORY__
        let v25 : US5 = method134(v24)
        let v31 : US5 =
            match v25 with
            | US5_1 -> (* None *)
                let v28 : string = method128()
                method134(v28)
            | US5_0(v26) -> (* Some *)
                US5_0(v26)
        let v35 : string =
            match v31 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v32) -> (* Some *)
                v32
        let v36 : string = method20(v35)
        let v37 : bool = "deps" = v36
        let v47 : string =
            if v37 then
                let v38 : string option = method113(v35)
                let v39 : string = v38 |> Option.get
                let v42 : US5 = method134(v39)
                match v42 with
                | US5_1 -> (* None *)
                    failwith<string> "Option does not have a value."
                | US5_0(v43) -> (* Some *)
                    v43
            else
                v35
        let v48 : string = "polyglot"
        let v49 : string = method86(v47, v48)
        let v50 : string = "target/trace"
        let v51 : string = method86(v49, v50)
        let v52 : System_IO_DirectoryInfo = method99(v51)
        let v53 : string = method86(v51, v23)
        let v54 : Async<unit> = method35(v53, v0)
        (* run_target_args'
        let v55 : unit = ()
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
        let v56 : (Async<unit> -> unit) = Async.RunSynchronously
        v56 v54
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v57 : (Async<unit> -> unit) = Async.RunSynchronously
        v57 v54
        #endif
#else
        let v58 : (Async<unit> -> unit) = Async.RunSynchronously
        v58 v54
        #endif
        // run_target_args' is_unit
        (* indent
        ()
    indent *)
    with ex ->
        let v116 : exn = ex
        let v117 : (unit -> exn) = closure64(v116)
        let v118 : string = $"file_system.trace_file / ex: %A{v117}"
        let v119 : unit = ()
        let v120 : (unit -> unit) = closure9(v118)
        let v121 : unit = (fun () -> v120 (); v119) ()
        method139(v118)
        (* indent
        ()
    indent *)
    (* try_unit
    try_unit *)
    #endif
    // run_target_args' is_unit
    ()
and closure63 () (v0 : string) : unit =
    method139(v0)
and closure65 () (v0 : bool) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure0()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v17 : Mut0, v18 : Mut1, v19 : Mut2, v20 : Mut3, v21 : Mut4, v22 : int64 option) = TraceState.trace_state.Value
    let v37 : (string -> unit) =
        if v0 then
            closure63()
        else
            closure2()
    v18.l0 <- v37
    ()
and method140 (v0 : string, v1 : string) : unit =
    let v2 : bool = method10(v0)
    let v3 : bool = v2 = false
    if v3 then
        let v4 : System.IDisposable = method89(v0)
        ()
    let v5 : string option = method113(v1)
    let v6 : string = ""
    let v7 : string = v5 |> Option.defaultValue v6 
    let v10 : bool = method10(v7)
    let v11 : bool = v10 = false
    if v11 then
        let v12 : System.IDisposable = method89(v7)
        ()
    let v13 : bool = method10(v1)
    let v24 : bool =
        if v13 then
            let v14 : Result<std_path_PathBuf, std_io_Error> = method107(v1)
            (* run_target_args'
            let v15 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v16 : string = "$0.is_err()"
            let v17 : bool = Fable.Core.RustInterop.emitRustExpr v14 v16 
            let _run_target_args'_v15 = v17 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v18 : string = "$0.is_err()"
            let v19 : bool = Fable.Core.RustInterop.emitRustExpr v14 v18 
            let _run_target_args'_v15 = v19 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v20 : string = "$0.is_err()"
            let v21 : bool = Fable.Core.RustInterop.emitRustExpr v14 v20 
            let _run_target_args'_v15 = v21 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let _run_target_args'_v15 = true 
            #endif
#if FABLE_COMPILER_PYTHON
            let _run_target_args'_v15 = true 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let _run_target_args'_v15 = true 
            #endif
#else
            let _run_target_args'_v15 = true 
            #endif
            let v22 : bool = _run_target_args'_v15 
            v22
        else
            false
    if v24 then
        let v25 : bool = true
        method9(v25, v1)
    let v26 : bool = method10(v1)
    let v27 : bool = v26 = false
    if v27 then
        (* run_target_args'
        let v28 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v29 : string = "true; #[cfg(windows)] std::os::windows::fs::symlink_dir(&*$0, &*$1).unwrap()"
        let v30 : bool = Fable.Core.RustInterop.emitRustExpr struct (v0, v1) v29 
        let v31 : string = "true; #[cfg(unix)] std::os::unix::fs::symlink(&*$0, &*$1).unwrap()"
        let v32 : bool = Fable.Core.RustInterop.emitRustExpr struct (v0, v1) v31 
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
        let v33 : System.IO.FileSystemInfo = System.IO.Directory.CreateSymbolicLink (v1, v0)
        #endif
        // run_target_args' is_unit
        ()
and closure67 (v0 : string) (v1 : string) : unit =
    method140(v0, v1)
and closure66 () (v0 : string) : (string -> unit) =
    closure67(v0)
and closure69 (v0 : string) (v1 : string) : string =
    method86(v0, v1)
and closure68 () (v0 : string) : (string -> string) =
    closure69(v0)
let v0 : unit = ()
let v1 : (unit -> unit) = closure0()
let v2 : unit = (fun () -> v1 (); v0) ()
let v16 : (string -> Async<int64>) = closure3()
let delete_directory_async x = v16 x
let v17 : (US6 -> (string -> Async<int64>)) = closure10()
let wait_for_file_access x = v17 x
let v18 : (string -> Async<int64>) = closure13()
let wait_for_file_access_read x = v18 x
let v19 : (string -> Async<string>) = closure14()
let read_all_text_async x = v19 x
let v20 : (string -> (string -> bool)) = closure15()
let file_exists_content x = v20 x
let v21 : (string -> (string -> Async<unit>)) = closure17()
let write_all_text_async x = v21 x
let v22 : (string -> (string -> Async<unit>)) = closure19()
let write_all_text_exists x = v22 x
let v23 : (string -> Async<int64>) = closure21()
let delete_file_async x = v23 x
let v24 : (string -> (string -> Async<int64>)) = closure27()
let move_file_async x = v24 x
let v25 : (string -> Async<string option>) = closure30()
let read_all_text_retry_async x = v25 x
let v26 : (unit -> string) = closure36()
let create_temp_path () = v26 ()
let v27 : (unit -> struct (string * System.IDisposable)) = closure38()
let create_temp_dir () = v27 ()
let v28 : (string -> struct (string * System.IDisposable)) = closure47()
let create_temp_dir' x = v28 x
let v29 : (unit -> string) = closure49()
let get_source_directory () = v29 ()
let v30 : (string -> string) = closure50()
let normalize_path x = v30 x
let v31 : (string -> string) = closure58()
let get_full_path x = v31 x
let v32 : (string -> string) = closure59()
let standardize_path x = v32 x
let v33 : (string -> string) = closure60()
let new_file_uri x = v33 x
let v34 : (unit -> string) = closure61()
let get_workspace_root () = v34 ()
let v35 : (string -> unit) = closure63()
let trace_file x = v35 x
let v36 : (bool -> unit) = closure65()
let init_trace_file x = v36 x
let v37 : (string -> (string -> unit)) = closure66()
let link_directory x = v37 x
let v38 : (string -> (string -> string)) = closure68()
let (</>) x = v38 x
()
