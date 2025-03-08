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
    
    
    
    
    
    
    
    
    
    
    let v3 : string = "Critical"
    let v4 : (unit -> string) = v3.ToLower
    let v5 : string = v4 ()
    let v9 : string = "Warning"
    let v10 : (unit -> string) = v9.ToLower
    let v11 : string = v10 ()
    let v15 : string = "Info"
    let v16 : (unit -> string) = v15.ToLower
    let v17 : string = v16 ()
    let v21 : string = "Debug"
    let v22 : (unit -> string) = v21.ToLower
    let v23 : string = v22 ()
    let v27 : string = "Verbose"
    let v28 : (unit -> string) = v27.ToLower
    let v29 : string = v28 ()
    let v32 : bool = "Verbose" = v1
    let v36 : US1 =
        if v32 then
            let v33 : US0 = US0_0
            US1_0(v33)
        else
            US1_1
    let v122 : US1 =
        match v36 with
        | US1_1 -> (* None *)
            let v39 : bool = "Debug" = v1
            let v43 : US1 =
                if v39 then
                    let v40 : US0 = US0_1
                    US1_0(v40)
                else
                    US1_1
            match v43 with
            | US1_1 -> (* None *)
                let v46 : bool = "Info" = v1
                let v50 : US1 =
                    if v46 then
                        let v47 : US0 = US0_2
                        US1_0(v47)
                    else
                        US1_1
                match v50 with
                | US1_1 -> (* None *)
                    let v53 : bool = "Warning" = v1
                    let v57 : US1 =
                        if v53 then
                            let v54 : US0 = US0_3
                            US1_0(v54)
                        else
                            US1_1
                    match v57 with
                    | US1_1 -> (* None *)
                        let v60 : bool = "Critical" = v1
                        let v64 : US1 =
                            if v60 then
                                let v61 : US0 = US0_4
                                US1_0(v61)
                            else
                                US1_1
                        match v64 with
                        | US1_1 -> (* None *)
                            let v67 : bool = v29 = v1
                            let v71 : US1 =
                                if v67 then
                                    let v68 : US0 = US0_0
                                    US1_0(v68)
                                else
                                    US1_1
                            match v71 with
                            | US1_1 -> (* None *)
                                let v74 : bool = v23 = v1
                                let v78 : US1 =
                                    if v74 then
                                        let v75 : US0 = US0_1
                                        US1_0(v75)
                                    else
                                        US1_1
                                match v78 with
                                | US1_1 -> (* None *)
                                    let v81 : bool = v17 = v1
                                    let v85 : US1 =
                                        if v81 then
                                            let v82 : US0 = US0_2
                                            US1_0(v82)
                                        else
                                            US1_1
                                    match v85 with
                                    | US1_1 -> (* None *)
                                        let v88 : bool = v11 = v1
                                        let v92 : US1 =
                                            if v88 then
                                                let v89 : US0 = US0_3
                                                US1_0(v89)
                                            else
                                                US1_1
                                        match v92 with
                                        | US1_1 -> (* None *)
                                            let v95 : bool = v5 = v1
                                            let v99 : US1 =
                                                if v95 then
                                                    let v96 : US0 = US0_4
                                                    US1_0(v96)
                                                else
                                                    US1_1
                                            match v99 with
                                            | US1_1 -> (* None *)
                                                US1_1
                                            | US1_0(v100) -> (* Some *)
                                                US1_0(v100)
                                        | US1_0(v93) -> (* Some *)
                                            US1_0(v93)
                                    | US1_0(v86) -> (* Some *)
                                        US1_0(v86)
                                | US1_0(v79) -> (* Some *)
                                    US1_0(v79)
                            | US1_0(v72) -> (* Some *)
                                US1_0(v72)
                        | US1_0(v65) -> (* Some *)
                            US1_0(v65)
                    | US1_0(v58) -> (* Some *)
                        US1_0(v58)
                | US1_0(v51) -> (* Some *)
                    US1_0(v51)
            | US1_0(v44) -> (* Some *)
                US1_0(v44)
        | US1_0(v37) -> (* Some *)
            US1_0(v37)
    let v123 : string = "AUTOMATION"
    let v124 : string = method2(v123)
    let v127 : string = "True"
    let v128 : bool = v124 <> v127 
    let v195 : US2 =
        if v128 then
            US2_1
        else
            (* run_target_args'
            let v134 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v135 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v134 = v135 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v136 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v134 = v136 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v138 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v134 = v138 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v141 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v134 = v141 
            #endif
#if FABLE_COMPILER_PYTHON
            let v142 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v134 = v142 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v134 = v143 
            #endif
#else
            let v144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v134 = v144 
            #endif
            let v145 : System.DateTime = _run_target_args'_v134 
            (* run_target_args'
            let v153 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v154 : (System.DateTime -> int64) = _.Ticks
            let v155 : int64 = v154 v145
            let _run_target_args'_v153 = v155 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v156 : (System.DateTime -> int64) = _.Ticks
            let v157 : int64 = v156 v145
            let _run_target_args'_v153 = v157 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v159 : int64 = null |> unbox<int64>
            let _run_target_args'_v153 = v159 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v162 : (System.DateTime -> int64) = _.Ticks
            let v163 : int64 = v162 v145
            let _run_target_args'_v153 = v163 
            #endif
#if FABLE_COMPILER_PYTHON
            let v164 : (System.DateTime -> int64) = _.Ticks
            let v165 : int64 = v164 v145
            let _run_target_args'_v153 = v165 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v166 : (System.DateTime -> int64) = _.Ticks
            let v167 : int64 = v166 v145
            let _run_target_args'_v153 = v167 
            #endif
#else
            let v168 : (System.DateTime -> int64) = _.Ticks
            let v169 : int64 = v168 v145
            let _run_target_args'_v153 = v169 
            #endif
            let v170 : int64 = _run_target_args'_v153 
            let v191 : int64 = v170 |> int64 
            US2_0(v191)
    struct (v122, v195)
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
    let v167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v170 : (int64 -> US2) = method13()
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
    let v306 : string = method14()
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
    let v331 : (int64 -> US2) = method13()
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
    let v467 : string = method14()
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
    let v494 : (int64 -> US2) = method13()
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
    let v535 : (int64 -> US2) = method13()
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
    let v671 : string = method15()
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
    let v696 : (int64 -> US2) = method13()
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
    let v832 : string = method15()
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
    let v857 : (int64 -> US2) = method13()
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
    let v993 : string = method15()
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
    let v1018 : (int64 -> US2) = method13()
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
    let v1154 : string = method15()
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
    let v158 : (string -> US5) = method5()
    let v159 : US5 option = v155 |> Option.map v158 
    let v173 : US5 = US5_1
    let v174 : US5 = v159 |> Option.defaultValue v173 
    let v181 : string =
        match v174 with
        | US5_1 -> (* None *)
            let v179 : string = ""
            v179
        | US5_0(v178) -> (* Some *)
            v178
    let _run_target_args'_v5 = v181 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v182 : US3 = US3_1
    let v183 : US4 = US4_3(v182)
    let v184 : string = $"file_system.get_file_name / target: {v183} / path: {v0}"
    let v185 : string = failwith<string> v184
    let _run_target_args'_v5 = v185 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v187 : string = null |> unbox<string>
    let _run_target_args'_v5 = v187 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v190 : string = "path"
    let v191 : IPathBasename = Fable.Core.JsInterop.importAll v190 
    let v192 : string = "v191.basename($0)"
    let v193 : string = Fable.Core.JsInterop.emitJsExpr v0 v192 
    let _run_target_args'_v5 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v194 : US3 = US3_0
    let v195 : US4 = US4_5(v194)
    let v196 : string = $"file_system.get_file_name / target: {v195} / path: {v0}"
    let v197 : string = failwith<string> v196
    let _run_target_args'_v5 = v197 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v198 : US3 = US3_1
    let v199 : US4 = US4_1(v198)
    let v200 : string = $"file_system.get_file_name / target: {v199} / path: {v0}"
    let v201 : string = failwith<string> v200
    let _run_target_args'_v5 = v201 
    #endif
#else
    let v202 : (string -> string) = System.IO.Path.GetFileName
    let v203 : string = v202 v0
    let _run_target_args'_v5 = v203 
    #endif
    let v204 : string = _run_target_args'_v5 
    v204
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
    let v38 : char list = []
    let v40 : char list = '/' :: v38 
    let v44 : char list = ' ' :: v40 
    let v49 : (char list -> (char [])) = List.toArray
    let v50 : (char []) = v49 v44
    let v53 : string = v8.TrimEnd v50 
    v53
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
                let v45 : US9 = match v39 with Ok () -> v42 () | Error x -> v43 x
                match v45 with
                | US9_1(v48) -> (* Error *)
                    let v49 : unit = ()
                    let v50 : (unit -> unit) = closure26(v48)
                    let v51 : unit = (fun () -> v50 (); v49) ()
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
                let v98 : (string -> unit) = System.IO.File.Delete
                v98 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v175 : exn = ex
                let v176 : int64 = v1 % 100L
                let v177 : bool = v176 = 0L
                if v177 then
                    let v178 : unit = ()
                    let v179 : (unit -> unit) = closure27(v0, v175)
                    let v180 : unit = (fun () -> v179 (); v178) ()
                    ()
                (* run_target_args'
                let v268 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v269 : (int32 -> Async<unit>) = Async.Sleep
                let v270 : Async<unit> = v269 10
                let _run_target_args'_v268 = v270 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v271 : (int32 -> Async<unit>) = Async.Sleep
                let v272 : Async<unit> = v271 10
                let _run_target_args'_v268 = v272 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v273 : (int32 -> Async<unit>) = Async.Sleep
                let v274 : Async<unit> = v273 10
                let _run_target_args'_v268 = v274 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v275 : (int32 -> Async<unit>) = Async.Sleep
                let v276 : Async<unit> = v275 10
                let _run_target_args'_v268 = v276 
                #endif
#if FABLE_COMPILER_PYTHON
                let v277 : (int32 -> Async<unit>) = Async.Sleep
                let v278 : Async<unit> = v277 10
                let _run_target_args'_v268 = v278 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v279 : (int32 -> Async<unit>) = Async.Sleep
                let v280 : Async<unit> = v279 10
                let _run_target_args'_v268 = v280 
                #endif
#else
                let v281 : (int32 -> Async<unit>) = Async.Sleep
                let v282 : Async<unit> = v281 10
                let _run_target_args'_v268 = v282 
                #endif
                let v283 : Async<unit> = _run_target_args'_v268 
                do! v283 
                let v286 : int64 = v1 + 1L
                let v287 : Async<int64> = method46(v0, v286)
                return! v287 
                (* indent
                ()
            indent *)
            (* try_unit
            let v402 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3079 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v3079 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3081 : unit = ()
    let _let'_v3081 =
        async {
            try
                (* run_target_args'
                let v3084 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3085 : string = "std::fs::remove_file(&*$0)"
                let v3086 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v3085 
                let v3087 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v3089 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3090 : string = "$0.map_err(|x| $1(x))"
                let v3091 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3086, v3087) v3090 
                let _run_target_args'_v3089 = v3091 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3092 : string = "$0.map_err(|x| $1(x))"
                let v3093 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3086, v3087) v3092 
                let _run_target_args'_v3089 = v3093 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3094 : string = "$0.map_err(|x| $1(x))"
                let v3095 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3086, v3087) v3094 
                let _run_target_args'_v3089 = v3095 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3096 : Result<unit, string> = match v3086 with Ok x -> Ok x | Error x -> Error (v3087 x)
                let _run_target_args'_v3089 = v3096 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3097 : Result<unit, string> = match v3086 with Ok x -> Ok x | Error x -> Error (v3087 x)
                let _run_target_args'_v3089 = v3097 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3098 : Result<unit, string> = match v3086 with Ok x -> Ok x | Error x -> Error (v3087 x)
                let _run_target_args'_v3089 = v3098 
                #endif
#else
                let v3099 : Result<unit, string> = match v3086 with Ok x -> Ok x | Error x -> Error (v3087 x)
                let _run_target_args'_v3089 = v3099 
                #endif
                let v3100 : Result<unit, string> = _run_target_args'_v3089 
                let v3103 : (unit -> US9) = method50()
                let v3104 : (string -> US9) = method51()
                let v3106 : US9 = match v3100 with Ok () -> v3103 () | Error x -> v3104 x
                match v3106 with
                | US9_1(v3109) -> (* Error *)
                    let v3110 : unit = ()
                    let v3111 : (unit -> unit) = closure26(v3109)
                    let v3112 : unit = (fun () -> v3111 (); v3110) ()
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
                let v3159 : (string -> unit) = System.IO.File.Delete
                v3159 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v3236 : exn = ex
                let v3237 : int64 = v1 % 100L
                let v3238 : bool = v3237 = 0L
                if v3238 then
                    let v3239 : unit = ()
                    let v3240 : (unit -> unit) = closure27(v0, v3236)
                    let v3241 : unit = (fun () -> v3240 (); v3239) ()
                    ()
                (* run_target_args'
                let v3329 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3330 : (int32 -> Async<unit>) = Async.Sleep
                let v3331 : Async<unit> = v3330 10
                let _run_target_args'_v3329 = v3331 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3332 : (int32 -> Async<unit>) = Async.Sleep
                let v3333 : Async<unit> = v3332 10
                let _run_target_args'_v3329 = v3333 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3334 : (int32 -> Async<unit>) = Async.Sleep
                let v3335 : Async<unit> = v3334 10
                let _run_target_args'_v3329 = v3335 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3336 : (int32 -> Async<unit>) = Async.Sleep
                let v3337 : Async<unit> = v3336 10
                let _run_target_args'_v3329 = v3337 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3338 : (int32 -> Async<unit>) = Async.Sleep
                let v3339 : Async<unit> = v3338 10
                let _run_target_args'_v3329 = v3339 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3340 : (int32 -> Async<unit>) = Async.Sleep
                let v3341 : Async<unit> = v3340 10
                let _run_target_args'_v3329 = v3341 
                #endif
#else
                let v3342 : (int32 -> Async<unit>) = Async.Sleep
                let v3343 : Async<unit> = v3342 10
                let _run_target_args'_v3329 = v3343 
                #endif
                let v3344 : Async<unit> = _run_target_args'_v3329 
                do! v3344 
                let v3347 : int64 = v1 + 1L
                let v3348 : Async<int64> = method46(v0, v3347)
                return! v3348 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3463 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6140 : Async<int64> = _let'_v3081 
    let _run_target_args'_v6 = v6140 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v6142 : unit = ()
    let _let'_v6142 =
        async {
            try
                (* run_target_args'
                let v6145 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6146 : string = "std::fs::remove_file(&*$0)"
                let v6147 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v6146 
                let v6148 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v6150 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6151 : string = "$0.map_err(|x| $1(x))"
                let v6152 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6147, v6148) v6151 
                let _run_target_args'_v6150 = v6152 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6153 : string = "$0.map_err(|x| $1(x))"
                let v6154 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6147, v6148) v6153 
                let _run_target_args'_v6150 = v6154 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6155 : string = "$0.map_err(|x| $1(x))"
                let v6156 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6147, v6148) v6155 
                let _run_target_args'_v6150 = v6156 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6157 : Result<unit, string> = match v6147 with Ok x -> Ok x | Error x -> Error (v6148 x)
                let _run_target_args'_v6150 = v6157 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6158 : Result<unit, string> = match v6147 with Ok x -> Ok x | Error x -> Error (v6148 x)
                let _run_target_args'_v6150 = v6158 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6159 : Result<unit, string> = match v6147 with Ok x -> Ok x | Error x -> Error (v6148 x)
                let _run_target_args'_v6150 = v6159 
                #endif
#else
                let v6160 : Result<unit, string> = match v6147 with Ok x -> Ok x | Error x -> Error (v6148 x)
                let _run_target_args'_v6150 = v6160 
                #endif
                let v6161 : Result<unit, string> = _run_target_args'_v6150 
                let v6164 : (unit -> US9) = method50()
                let v6165 : (string -> US9) = method51()
                let v6167 : US9 = match v6161 with Ok () -> v6164 () | Error x -> v6165 x
                match v6167 with
                | US9_1(v6170) -> (* Error *)
                    let v6171 : unit = ()
                    let v6172 : (unit -> unit) = closure26(v6170)
                    let v6173 : unit = (fun () -> v6172 (); v6171) ()
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
                let v6220 : (string -> unit) = System.IO.File.Delete
                v6220 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v6297 : exn = ex
                let v6298 : int64 = v1 % 100L
                let v6299 : bool = v6298 = 0L
                if v6299 then
                    let v6300 : unit = ()
                    let v6301 : (unit -> unit) = closure27(v0, v6297)
                    let v6302 : unit = (fun () -> v6301 (); v6300) ()
                    ()
                (* run_target_args'
                let v6390 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6391 : (int32 -> Async<unit>) = Async.Sleep
                let v6392 : Async<unit> = v6391 10
                let _run_target_args'_v6390 = v6392 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6393 : (int32 -> Async<unit>) = Async.Sleep
                let v6394 : Async<unit> = v6393 10
                let _run_target_args'_v6390 = v6394 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6395 : (int32 -> Async<unit>) = Async.Sleep
                let v6396 : Async<unit> = v6395 10
                let _run_target_args'_v6390 = v6396 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6397 : (int32 -> Async<unit>) = Async.Sleep
                let v6398 : Async<unit> = v6397 10
                let _run_target_args'_v6390 = v6398 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6399 : (int32 -> Async<unit>) = Async.Sleep
                let v6400 : Async<unit> = v6399 10
                let _run_target_args'_v6390 = v6400 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6401 : (int32 -> Async<unit>) = Async.Sleep
                let v6402 : Async<unit> = v6401 10
                let _run_target_args'_v6390 = v6402 
                #endif
#else
                let v6403 : (int32 -> Async<unit>) = Async.Sleep
                let v6404 : Async<unit> = v6403 10
                let _run_target_args'_v6390 = v6404 
                #endif
                let v6405 : Async<unit> = _run_target_args'_v6390 
                do! v6405 
                let v6408 : int64 = v1 + 1L
                let v6409 : Async<int64> = method46(v0, v6408)
                return! v6409 
                (* indent
                ()
            indent *)
            (* try_unit
            let v6524 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9201 : Async<int64> = _let'_v6142 
    let _run_target_args'_v6 = v9201 
    #endif
#else
    let v9203 : unit = ()
    let _let'_v9203 =
        async {
            try
                (* run_target_args'
                let v9206 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9207 : string = "std::fs::remove_file(&*$0)"
                let v9208 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v9207 
                let v9209 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v9211 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9212 : string = "$0.map_err(|x| $1(x))"
                let v9213 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9208, v9209) v9212 
                let _run_target_args'_v9211 = v9213 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9214 : string = "$0.map_err(|x| $1(x))"
                let v9215 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9208, v9209) v9214 
                let _run_target_args'_v9211 = v9215 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9216 : string = "$0.map_err(|x| $1(x))"
                let v9217 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9208, v9209) v9216 
                let _run_target_args'_v9211 = v9217 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9218 : Result<unit, string> = match v9208 with Ok x -> Ok x | Error x -> Error (v9209 x)
                let _run_target_args'_v9211 = v9218 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9219 : Result<unit, string> = match v9208 with Ok x -> Ok x | Error x -> Error (v9209 x)
                let _run_target_args'_v9211 = v9219 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9220 : Result<unit, string> = match v9208 with Ok x -> Ok x | Error x -> Error (v9209 x)
                let _run_target_args'_v9211 = v9220 
                #endif
#else
                let v9221 : Result<unit, string> = match v9208 with Ok x -> Ok x | Error x -> Error (v9209 x)
                let _run_target_args'_v9211 = v9221 
                #endif
                let v9222 : Result<unit, string> = _run_target_args'_v9211 
                let v9225 : (unit -> US9) = method50()
                let v9226 : (string -> US9) = method51()
                let v9228 : US9 = match v9222 with Ok () -> v9225 () | Error x -> v9226 x
                match v9228 with
                | US9_1(v9231) -> (* Error *)
                    let v9232 : unit = ()
                    let v9233 : (unit -> unit) = closure26(v9231)
                    let v9234 : unit = (fun () -> v9233 (); v9232) ()
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
                let v9281 : (string -> unit) = System.IO.File.Delete
                v9281 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v9358 : exn = ex
                let v9359 : int64 = v1 % 100L
                let v9360 : bool = v9359 = 0L
                if v9360 then
                    let v9361 : unit = ()
                    let v9362 : (unit -> unit) = closure27(v0, v9358)
                    let v9363 : unit = (fun () -> v9362 (); v9361) ()
                    ()
                (* run_target_args'
                let v9451 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9452 : (int32 -> Async<unit>) = Async.Sleep
                let v9453 : Async<unit> = v9452 10
                let _run_target_args'_v9451 = v9453 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9454 : (int32 -> Async<unit>) = Async.Sleep
                let v9455 : Async<unit> = v9454 10
                let _run_target_args'_v9451 = v9455 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9456 : (int32 -> Async<unit>) = Async.Sleep
                let v9457 : Async<unit> = v9456 10
                let _run_target_args'_v9451 = v9457 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9458 : (int32 -> Async<unit>) = Async.Sleep
                let v9459 : Async<unit> = v9458 10
                let _run_target_args'_v9451 = v9459 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9460 : (int32 -> Async<unit>) = Async.Sleep
                let v9461 : Async<unit> = v9460 10
                let _run_target_args'_v9451 = v9461 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9462 : (int32 -> Async<unit>) = Async.Sleep
                let v9463 : Async<unit> = v9462 10
                let _run_target_args'_v9451 = v9463 
                #endif
#else
                let v9464 : (int32 -> Async<unit>) = Async.Sleep
                let v9465 : Async<unit> = v9464 10
                let _run_target_args'_v9451 = v9465 
                #endif
                let v9466 : Async<unit> = _run_target_args'_v9451 
                do! v9466 
                let v9469 : int64 = v1 + 1L
                let v9470 : Async<int64> = method46(v0, v9469)
                return! v9470 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9585 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v12262 : Async<int64> = _let'_v9203 
    let _run_target_args'_v6 = v12262 
    #endif
    let v12263 : Async<int64> = _run_target_args'_v6 
    v12263
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
    let v683 : (chrono_DateTime<chrono_Utc> -> US12) = method83()
    let v684 : US12 option = v680 |> Option.map v683 
    let v698 : US12 = US12_1
    let v699 : US12 = v684 |> Option.defaultValue v698 
    let v719 : US5 =
        match v699 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v703) -> (* Some *)
            let v704 : string = "$0.naive_utc()"
            let v705 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v703 v704 
            let v706 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v707 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v705 v706 
            let v708 : string = "%Y%m%d-%H%M-%S%f"
            let v709 : string = "r#\"" + v708 + "\"#"
            let v710 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v709 
            let v711 : string = "$0.format($1).to_string()"
            let v712 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v707, v710) v711 
            let v713 : string = "fable_library_rust::String_::fromString($0)"
            let v714 : string = Fable.Core.RustInterop.emitRustExpr v712 v713 
            let v715 : string = $"{v714.[0..17]}-{v714.[18..21]}-{v714.[22]}"
            US5_0(v715)
    let v723 : string =
        match v719 with
        | US5_1 -> (* None *)
            let v721 : string = ""
            v721
        | US5_0(v720) -> (* Some *)
            v720
    (* run_target_args'
    let v728 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v729 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v730 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v729 
    let _run_target_args'_v728 = v730 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v732 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v732 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v736 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v736 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v740 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v740 
    #endif
#if FABLE_COMPILER_PYTHON
    let v744 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v728 = v744 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v747 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v728 = v747 
    #endif
#else
    let v748 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v728 = v748 
    #endif
    let v749 : System.TimeZoneInfo = _run_target_args'_v728 
    (* run_target_args'
    let v762 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v766 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v767 : (System.DateTime -> int64) = _.Ticks
    let v768 : int64 = v767 v586
    let _run_target_args'_v766 = v768 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v769 : (System.DateTime -> int64) = _.Ticks
    let v770 : int64 = v769 v586
    let _run_target_args'_v766 = v770 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v772 : int64 = null |> unbox<int64>
    let _run_target_args'_v766 = v772 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v586
    let _run_target_args'_v766 = v776 
    #endif
#if FABLE_COMPILER_PYTHON
    let v777 : (System.DateTime -> int64) = _.Ticks
    let v778 : int64 = v777 v586
    let _run_target_args'_v766 = v778 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v779 : (System.DateTime -> int64) = _.Ticks
    let v780 : int64 = v779 v586
    let _run_target_args'_v766 = v780 
    #endif
#else
    let v781 : (System.DateTime -> int64) = _.Ticks
    let v782 : int64 = v781 v586
    let _run_target_args'_v766 = v782 
    #endif
    let v783 : int64 = _run_target_args'_v766 
    let v803 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v804 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v783) v803 
    let v806 : System.TimeSpan = v804 |> System.TimeSpan 
    let _run_target_args'_v762 = v806 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v812 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v813 : (System.DateTime -> int64) = _.Ticks
    let v814 : int64 = v813 v586
    let _run_target_args'_v812 = v814 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v815 : (System.DateTime -> int64) = _.Ticks
    let v816 : int64 = v815 v586
    let _run_target_args'_v812 = v816 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v818 : int64 = null |> unbox<int64>
    let _run_target_args'_v812 = v818 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v586
    let _run_target_args'_v812 = v822 
    #endif
#if FABLE_COMPILER_PYTHON
    let v823 : (System.DateTime -> int64) = _.Ticks
    let v824 : int64 = v823 v586
    let _run_target_args'_v812 = v824 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v825 : (System.DateTime -> int64) = _.Ticks
    let v826 : int64 = v825 v586
    let _run_target_args'_v812 = v826 
    #endif
#else
    let v827 : (System.DateTime -> int64) = _.Ticks
    let v828 : int64 = v827 v586
    let _run_target_args'_v812 = v828 
    #endif
    let v829 : int64 = _run_target_args'_v812 
    let v849 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v850 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v829) v849 
    let v852 : System.TimeSpan = v850 |> System.TimeSpan 
    let _run_target_args'_v762 = v852 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v856 : US3 = US3_2
    let v857 : US4 = US4_3(v856)
    let v858 : string = $"date_time.get_utc_offset / target: {v857}"
    let v859 : System.TimeSpan = failwith<System.TimeSpan> v858
    let _run_target_args'_v762 = v859 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v863 : US3 = US3_0
    let v864 : US4 = US4_4(v863)
    let v865 : string = $"date_time.get_utc_offset / target: {v864}"
    let v866 : System.TimeSpan = failwith<System.TimeSpan> v865
    let _run_target_args'_v762 = v866 
    #endif
#if FABLE_COMPILER_PYTHON
    let v870 : US3 = US3_0
    let v871 : US4 = US4_5(v870)
    let v872 : string = $"date_time.get_utc_offset / target: {v871}"
    let v873 : System.TimeSpan = failwith<System.TimeSpan> v872
    let _run_target_args'_v762 = v873 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v876 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v881 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v882 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v883 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v882 
    let _run_target_args'_v881 = v883 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v885 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v885 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v889 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v889 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v893 
    #endif
#if FABLE_COMPILER_PYTHON
    let v897 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v881 = v897 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v900 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v881 = v900 
    #endif
#else
    let v901 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v881 = v901 
    #endif
    let v902 : System.TimeZoneInfo = _run_target_args'_v881 
    let v908 : (System.DateTime -> System.TimeSpan) = v876 v902
    let v909 : System.TimeSpan = v908 v586
    let _run_target_args'_v762 = v909 
    #endif
#else
    let v910 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v915 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v916 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v917 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v916 
    let _run_target_args'_v915 = v917 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v919 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v923 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v927 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v927 
    #endif
#if FABLE_COMPILER_PYTHON
    let v931 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v915 = v931 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v934 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v915 = v934 
    #endif
#else
    let v935 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v915 = v935 
    #endif
    let v936 : System.TimeZoneInfo = _run_target_args'_v915 
    let v942 : (System.DateTime -> System.TimeSpan) = v910 v936
    let v943 : System.TimeSpan = v942 v586
    let _run_target_args'_v762 = v943 
    #endif
    let v944 : System.TimeSpan = _run_target_args'_v762 
    let v954 : (System.TimeSpan -> int32) = _.Hours
    let v955 : int32 = v954 v944
    let v958 : bool = v955 > 0
    let v959 : uint8 =
        if v958 then
            1uy
        else
            0uy
    let v960 : string = method84()
    (* run_target_args'
    let v1014 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1015 : string = "$0.toString($1)"
    let v1016 : string = Fable.Core.RustInterop.emitRustExpr struct (v944, v960) v1015 
    let _run_target_args'_v1014 = v1016 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1017 : string = "$0.toString($1)"
    let v1018 : string = Fable.Core.RustInterop.emitRustExpr struct (v944, v960) v1017 
    let _run_target_args'_v1014 = v1018 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1019 : string = "$0.toString($1)"
    let v1020 : string = Fable.Core.RustInterop.emitRustExpr struct (v944, v960) v1019 
    let _run_target_args'_v1014 = v1020 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1021 : string = v944.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1014 = v1021 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1022 : string = v944.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1014 = v1022 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1024 : string = v944.ToString v960 
    let _run_target_args'_v1014 = v1024 
    #endif
#else
    let v1077 : string = v944.ToString v960 
    let _run_target_args'_v1014 = v1077 
    #endif
    let v1129 : string = _run_target_args'_v1014 
    let v1184 : string = $"{v959}{v1129.[0..1]}{v1129.[3..4]}"
    let v1186 : (System.Guid -> string) = _.ToString()
    let v1187 : string = v1186 v0
    let v1190 : int32 = v723.Length
    let v1191 : int32 = v1184.Length
    let v1192 : int32 = v1190 + v1191
    let v1194 : (string -> int32) = String.length
    let v1195 : int32 = v1194 v1187
    let v1203 : int32 = v1192 |> int32 
    let v1216 : int32 = v1195 |> int32 
    let v1224 : int32 = v1216 - 1
    let v1226 : string = v1187.[int v1203..int v1224]
    let v1230 : string = $"{v723}{v1184}{v1226}"
    (* run_target_args'
    let v1235 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1237 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1237 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1241 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1241 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1245 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1235 = v1245 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1249 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1249 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1253 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1253 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1257 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1257 
    #endif
#else
    let v1261 : System.Guid = v1230 |> System.Guid 
    let _run_target_args'_v1235 = v1261 
    #endif
    let v1264 : System.Guid = _run_target_args'_v1235 
    let _run_target_args'_v569 = v1264 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1271 : System.DateTime = System.DateTime.UnixEpoch
    let v1275 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1276 : System.DateTime = v1275 v1271
    let v1280 : System.DateTimeKind = System.DateTimeKind.Local
    let v1281 : System.DateTime = System.DateTime.SpecifyKind (v1, v1280)
    let v1285 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1286 : System.DateTime = v1285 v1281
    (* run_target_args'
    let v1292 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1293 : (System.DateTime -> int64) = _.Ticks
    let v1294 : int64 = v1293 v1286
    let _run_target_args'_v1292 = v1294 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1295 : (System.DateTime -> int64) = _.Ticks
    let v1296 : int64 = v1295 v1286
    let _run_target_args'_v1292 = v1296 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1298 : int64 = null |> unbox<int64>
    let _run_target_args'_v1292 = v1298 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1301 : (System.DateTime -> int64) = _.Ticks
    let v1302 : int64 = v1301 v1286
    let _run_target_args'_v1292 = v1302 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1303 : (System.DateTime -> int64) = _.Ticks
    let v1304 : int64 = v1303 v1286
    let _run_target_args'_v1292 = v1304 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1305 : (System.DateTime -> int64) = _.Ticks
    let v1306 : int64 = v1305 v1286
    let _run_target_args'_v1292 = v1306 
    #endif
#else
    let v1307 : (System.DateTime -> int64) = _.Ticks
    let v1308 : int64 = v1307 v1286
    let _run_target_args'_v1292 = v1308 
    #endif
    let v1309 : int64 = _run_target_args'_v1292 
    (* run_target_args'
    let v1332 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1333 : (System.DateTime -> int64) = _.Ticks
    let v1334 : int64 = v1333 v1276
    let _run_target_args'_v1332 = v1334 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1335 : (System.DateTime -> int64) = _.Ticks
    let v1336 : int64 = v1335 v1276
    let _run_target_args'_v1332 = v1336 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1338 : int64 = null |> unbox<int64>
    let _run_target_args'_v1332 = v1338 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1341 : (System.DateTime -> int64) = _.Ticks
    let v1342 : int64 = v1341 v1276
    let _run_target_args'_v1332 = v1342 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1343 : (System.DateTime -> int64) = _.Ticks
    let v1344 : int64 = v1343 v1276
    let _run_target_args'_v1332 = v1344 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1345 : (System.DateTime -> int64) = _.Ticks
    let v1346 : int64 = v1345 v1276
    let _run_target_args'_v1332 = v1346 
    #endif
#else
    let v1347 : (System.DateTime -> int64) = _.Ticks
    let v1348 : int64 = v1347 v1276
    let _run_target_args'_v1332 = v1348 
    #endif
    let v1349 : int64 = _run_target_args'_v1332 
    let v1370 : int64 = v1309 |> int64 
    let v1374 : int64 = v1349 |> int64 
    let v1377 : int64 = v1370 - v1374
    let v1378 : int64 = v1377 / 10L
    let v1379 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1380 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1378 v1379 
    let v1383 : (chrono_DateTime<chrono_Utc> -> US12) = method83()
    let v1384 : US12 option = v1380 |> Option.map v1383 
    let v1398 : US12 = US12_1
    let v1399 : US12 = v1384 |> Option.defaultValue v1398 
    let v1419 : US5 =
        match v1399 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v1403) -> (* Some *)
            let v1404 : string = "$0.naive_utc()"
            let v1405 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1403 v1404 
            let v1406 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1407 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1405 v1406 
            let v1408 : string = "%Y%m%d-%H%M-%S%f"
            let v1409 : string = "r#\"" + v1408 + "\"#"
            let v1410 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1409 
            let v1411 : string = "$0.format($1).to_string()"
            let v1412 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1407, v1410) v1411 
            let v1413 : string = "fable_library_rust::String_::fromString($0)"
            let v1414 : string = Fable.Core.RustInterop.emitRustExpr v1412 v1413 
            let v1415 : string = $"{v1414.[0..17]}-{v1414.[18..21]}-{v1414.[22]}"
            US5_0(v1415)
    let v1423 : string =
        match v1419 with
        | US5_1 -> (* None *)
            let v1421 : string = ""
            v1421
        | US5_0(v1420) -> (* Some *)
            v1420
    (* run_target_args'
    let v1428 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1429 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1430 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1429 
    let _run_target_args'_v1428 = v1430 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1432 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1432 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1436 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1436 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1440 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1440 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1444 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1428 = v1444 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1447 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1428 = v1447 
    #endif
#else
    let v1448 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1428 = v1448 
    #endif
    let v1449 : System.TimeZoneInfo = _run_target_args'_v1428 
    (* run_target_args'
    let v1462 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1466 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1467 : (System.DateTime -> int64) = _.Ticks
    let v1468 : int64 = v1467 v1286
    let _run_target_args'_v1466 = v1468 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1469 : (System.DateTime -> int64) = _.Ticks
    let v1470 : int64 = v1469 v1286
    let _run_target_args'_v1466 = v1470 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1472 : int64 = null |> unbox<int64>
    let _run_target_args'_v1466 = v1472 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1475 : (System.DateTime -> int64) = _.Ticks
    let v1476 : int64 = v1475 v1286
    let _run_target_args'_v1466 = v1476 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1477 : (System.DateTime -> int64) = _.Ticks
    let v1478 : int64 = v1477 v1286
    let _run_target_args'_v1466 = v1478 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1479 : (System.DateTime -> int64) = _.Ticks
    let v1480 : int64 = v1479 v1286
    let _run_target_args'_v1466 = v1480 
    #endif
#else
    let v1481 : (System.DateTime -> int64) = _.Ticks
    let v1482 : int64 = v1481 v1286
    let _run_target_args'_v1466 = v1482 
    #endif
    let v1483 : int64 = _run_target_args'_v1466 
    let v1503 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1504 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1286, v1483) v1503 
    let v1506 : System.TimeSpan = v1504 |> System.TimeSpan 
    let _run_target_args'_v1462 = v1506 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1512 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1513 : (System.DateTime -> int64) = _.Ticks
    let v1514 : int64 = v1513 v1286
    let _run_target_args'_v1512 = v1514 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1515 : (System.DateTime -> int64) = _.Ticks
    let v1516 : int64 = v1515 v1286
    let _run_target_args'_v1512 = v1516 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1518 : int64 = null |> unbox<int64>
    let _run_target_args'_v1512 = v1518 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1521 : (System.DateTime -> int64) = _.Ticks
    let v1522 : int64 = v1521 v1286
    let _run_target_args'_v1512 = v1522 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1523 : (System.DateTime -> int64) = _.Ticks
    let v1524 : int64 = v1523 v1286
    let _run_target_args'_v1512 = v1524 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1525 : (System.DateTime -> int64) = _.Ticks
    let v1526 : int64 = v1525 v1286
    let _run_target_args'_v1512 = v1526 
    #endif
#else
    let v1527 : (System.DateTime -> int64) = _.Ticks
    let v1528 : int64 = v1527 v1286
    let _run_target_args'_v1512 = v1528 
    #endif
    let v1529 : int64 = _run_target_args'_v1512 
    let v1549 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1550 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1286, v1529) v1549 
    let v1552 : System.TimeSpan = v1550 |> System.TimeSpan 
    let _run_target_args'_v1462 = v1552 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1556 : US3 = US3_2
    let v1557 : US4 = US4_3(v1556)
    let v1558 : string = $"date_time.get_utc_offset / target: {v1557}"
    let v1559 : System.TimeSpan = failwith<System.TimeSpan> v1558
    let _run_target_args'_v1462 = v1559 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1563 : US3 = US3_0
    let v1564 : US4 = US4_4(v1563)
    let v1565 : string = $"date_time.get_utc_offset / target: {v1564}"
    let v1566 : System.TimeSpan = failwith<System.TimeSpan> v1565
    let _run_target_args'_v1462 = v1566 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1570 : US3 = US3_0
    let v1571 : US4 = US4_5(v1570)
    let v1572 : string = $"date_time.get_utc_offset / target: {v1571}"
    let v1573 : System.TimeSpan = failwith<System.TimeSpan> v1572
    let _run_target_args'_v1462 = v1573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1576 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1581 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1582 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1583 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1582 
    let _run_target_args'_v1581 = v1583 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1585 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1585 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1589 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1589 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1597 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1581 = v1597 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1600 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1581 = v1600 
    #endif
#else
    let v1601 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1581 = v1601 
    #endif
    let v1602 : System.TimeZoneInfo = _run_target_args'_v1581 
    let v1608 : (System.DateTime -> System.TimeSpan) = v1576 v1602
    let v1609 : System.TimeSpan = v1608 v1286
    let _run_target_args'_v1462 = v1609 
    #endif
#else
    let v1610 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
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
    let v1619 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1619 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1623 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1623 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1627 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1627 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1631 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1615 = v1631 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1634 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1634 
    #endif
#else
    let v1635 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1615 = v1635 
    #endif
    let v1636 : System.TimeZoneInfo = _run_target_args'_v1615 
    let v1642 : (System.DateTime -> System.TimeSpan) = v1610 v1636
    let v1643 : System.TimeSpan = v1642 v1286
    let _run_target_args'_v1462 = v1643 
    #endif
    let v1644 : System.TimeSpan = _run_target_args'_v1462 
    let v1654 : (System.TimeSpan -> int32) = _.Hours
    let v1655 : int32 = v1654 v1644
    let v1658 : bool = v1655 > 0
    let v1659 : uint8 =
        if v1658 then
            1uy
        else
            0uy
    let v1660 : string = method84()
    (* run_target_args'
    let v1714 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1715 : string = "$0.toString($1)"
    let v1716 : string = Fable.Core.RustInterop.emitRustExpr struct (v1644, v1660) v1715 
    let _run_target_args'_v1714 = v1716 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1717 : string = "$0.toString($1)"
    let v1718 : string = Fable.Core.RustInterop.emitRustExpr struct (v1644, v1660) v1717 
    let _run_target_args'_v1714 = v1718 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1719 : string = "$0.toString($1)"
    let v1720 : string = Fable.Core.RustInterop.emitRustExpr struct (v1644, v1660) v1719 
    let _run_target_args'_v1714 = v1720 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1721 : string = v1644.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1714 = v1721 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1722 : string = v1644.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1714 = v1722 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1724 : string = v1644.ToString v1660 
    let _run_target_args'_v1714 = v1724 
    #endif
#else
    let v1777 : string = v1644.ToString v1660 
    let _run_target_args'_v1714 = v1777 
    #endif
    let v1829 : string = _run_target_args'_v1714 
    let v1884 : string = $"{v1659}{v1829.[0..1]}{v1829.[3..4]}"
    let v1886 : (System.Guid -> string) = _.ToString()
    let v1887 : string = v1886 v0
    let v1890 : int32 = v1423.Length
    let v1891 : int32 = v1884.Length
    let v1892 : int32 = v1890 + v1891
    let v1894 : (string -> int32) = String.length
    let v1895 : int32 = v1894 v1887
    let v1903 : int32 = v1892 |> int32 
    let v1916 : int32 = v1895 |> int32 
    let v1924 : int32 = v1916 - 1
    let v1926 : string = v1887.[int v1903..int v1924]
    let v1930 : string = $"{v1423}{v1884}{v1926}"
    (* run_target_args'
    let v1935 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1937 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1937 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1941 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1941 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1945 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1935 = v1945 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1949 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1949 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1953 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1953 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1957 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1957 
    #endif
#else
    let v1961 : System.Guid = v1930 |> System.Guid 
    let _run_target_args'_v1935 = v1961 
    #endif
    let v1964 : System.Guid = _run_target_args'_v1935 
    let _run_target_args'_v569 = v1964 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1971 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v569 = v1971 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1974 : string = method85()
    let v1976 : bool = v1974 = ""
    let v1978 : string =
        if v1976 then
            let v1977 : string = "M-d-y hh:mm:ss tt"
            v1977
        else
            v1974
    let v1979 : (string -> string) = v1.ToString
    let v1980 : string = v1979 v1978
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
    let v2003 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2003 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2007 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2007 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2011 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2011 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2015 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1999 = v2015 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2018 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2018 
    #endif
#else
    let v2019 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1999 = v2019 
    #endif
    let v2020 : System.TimeZoneInfo = _run_target_args'_v1999 
    (* run_target_args'
    let v2033 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2037 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2038 : (System.DateTime -> int64) = _.Ticks
    let v2039 : int64 = v2038 v1
    let _run_target_args'_v2037 = v2039 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2040 : (System.DateTime -> int64) = _.Ticks
    let v2041 : int64 = v2040 v1
    let _run_target_args'_v2037 = v2041 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2043 : int64 = null |> unbox<int64>
    let _run_target_args'_v2037 = v2043 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2046 : (System.DateTime -> int64) = _.Ticks
    let v2047 : int64 = v2046 v1
    let _run_target_args'_v2037 = v2047 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2048 : (System.DateTime -> int64) = _.Ticks
    let v2049 : int64 = v2048 v1
    let _run_target_args'_v2037 = v2049 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2050 : (System.DateTime -> int64) = _.Ticks
    let v2051 : int64 = v2050 v1
    let _run_target_args'_v2037 = v2051 
    #endif
#else
    let v2052 : (System.DateTime -> int64) = _.Ticks
    let v2053 : int64 = v2052 v1
    let _run_target_args'_v2037 = v2053 
    #endif
    let v2054 : int64 = _run_target_args'_v2037 
    let v2074 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2075 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2054) v2074 
    let v2077 : System.TimeSpan = v2075 |> System.TimeSpan 
    let _run_target_args'_v2033 = v2077 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2083 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2084 : (System.DateTime -> int64) = _.Ticks
    let v2085 : int64 = v2084 v1
    let _run_target_args'_v2083 = v2085 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2086 : (System.DateTime -> int64) = _.Ticks
    let v2087 : int64 = v2086 v1
    let _run_target_args'_v2083 = v2087 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2089 : int64 = null |> unbox<int64>
    let _run_target_args'_v2083 = v2089 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2092 : (System.DateTime -> int64) = _.Ticks
    let v2093 : int64 = v2092 v1
    let _run_target_args'_v2083 = v2093 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2094 : (System.DateTime -> int64) = _.Ticks
    let v2095 : int64 = v2094 v1
    let _run_target_args'_v2083 = v2095 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2096 : (System.DateTime -> int64) = _.Ticks
    let v2097 : int64 = v2096 v1
    let _run_target_args'_v2083 = v2097 
    #endif
#else
    let v2098 : (System.DateTime -> int64) = _.Ticks
    let v2099 : int64 = v2098 v1
    let _run_target_args'_v2083 = v2099 
    #endif
    let v2100 : int64 = _run_target_args'_v2083 
    let v2120 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2121 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2100) v2120 
    let v2123 : System.TimeSpan = v2121 |> System.TimeSpan 
    let _run_target_args'_v2033 = v2123 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2127 : US3 = US3_2
    let v2128 : US4 = US4_3(v2127)
    let v2129 : string = $"date_time.get_utc_offset / target: {v2128}"
    let v2130 : System.TimeSpan = failwith<System.TimeSpan> v2129
    let _run_target_args'_v2033 = v2130 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2134 : US3 = US3_0
    let v2135 : US4 = US4_4(v2134)
    let v2136 : string = $"date_time.get_utc_offset / target: {v2135}"
    let v2137 : System.TimeSpan = failwith<System.TimeSpan> v2136
    let _run_target_args'_v2033 = v2137 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2141 : US3 = US3_0
    let v2142 : US4 = US4_5(v2141)
    let v2143 : string = $"date_time.get_utc_offset / target: {v2142}"
    let v2144 : System.TimeSpan = failwith<System.TimeSpan> v2143
    let _run_target_args'_v2033 = v2144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2147 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2152 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2153 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2154 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2153 
    let _run_target_args'_v2152 = v2154 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2156 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2156 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2160 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2164 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2164 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2168 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2152 = v2168 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2171 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2152 = v2171 
    #endif
#else
    let v2172 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2152 = v2172 
    #endif
    let v2173 : System.TimeZoneInfo = _run_target_args'_v2152 
    let v2179 : (System.DateTime -> System.TimeSpan) = v2147 v2173
    let v2180 : System.TimeSpan = v2179 v1
    let _run_target_args'_v2033 = v2180 
    #endif
#else
    let v2181 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2186 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2187 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2188 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2187 
    let _run_target_args'_v2186 = v2188 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2190 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2190 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2194 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2194 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2198 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2202 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2186 = v2202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2205 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2186 = v2205 
    #endif
#else
    let v2206 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2186 = v2206 
    #endif
    let v2207 : System.TimeZoneInfo = _run_target_args'_v2186 
    let v2213 : (System.DateTime -> System.TimeSpan) = v2181 v2207
    let v2214 : System.TimeSpan = v2213 v1
    let _run_target_args'_v2033 = v2214 
    #endif
    let v2215 : System.TimeSpan = _run_target_args'_v2033 
    let v2225 : (System.TimeSpan -> int32) = _.Hours
    let v2226 : int32 = v2225 v2215
    let v2229 : bool = v2226 > 0
    let v2230 : uint8 =
        if v2229 then
            1uy
        else
            0uy
    let v2231 : string = method86()
    (* run_target_args'
    let v2285 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2286 : string = "$0.toString($1)"
    let v2287 : string = Fable.Core.RustInterop.emitRustExpr struct (v2215, v2231) v2286 
    let _run_target_args'_v2285 = v2287 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2288 : string = "$0.toString($1)"
    let v2289 : string = Fable.Core.RustInterop.emitRustExpr struct (v2215, v2231) v2288 
    let _run_target_args'_v2285 = v2289 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2290 : string = "$0.toString($1)"
    let v2291 : string = Fable.Core.RustInterop.emitRustExpr struct (v2215, v2231) v2290 
    let _run_target_args'_v2285 = v2291 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2292 : string = v2215.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2285 = v2292 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2293 : string = v2215.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2285 = v2293 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2295 : string = v2215.ToString v2231 
    let _run_target_args'_v2285 = v2295 
    #endif
#else
    let v2348 : string = v2215.ToString v2231 
    let _run_target_args'_v2285 = v2348 
    #endif
    let v2400 : string = _run_target_args'_v2285 
    let v2455 : string = $"{v2230}{v2400}"
    let v2457 : (System.Guid -> string) = _.ToString()
    let v2458 : string = v2457 v0
    let v2461 : int32 = v1980.Length
    let v2462 : int32 = v2455.Length
    let v2463 : int32 = v2461 + v2462
    let v2465 : (string -> int32) = String.length
    let v2466 : int32 = v2465 v2458
    let v2474 : int32 = v2463 |> int32 
    let v2487 : int32 = v2466 |> int32 
    let v2495 : int32 = v2487 - 1
    let v2497 : string = v2458.[int v2474..int v2495]
    let v2501 : string = $"{v1980}{v2455}{v2497}"
    (* run_target_args'
    let v2506 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2508 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2508 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2512 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2512 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2516 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2506 = v2516 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2520 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2520 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2524 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2524 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2528 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2528 
    #endif
#else
    let v2532 : System.Guid = v2501 |> System.Guid 
    let _run_target_args'_v2506 = v2532 
    #endif
    let v2535 : System.Guid = _run_target_args'_v2506 
    let _run_target_args'_v569 = v2535 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2541 : string = method85()
    let v2543 : bool = v2541 = ""
    let v2545 : string =
        if v2543 then
            let v2544 : string = "M-d-y hh:mm:ss tt"
            v2544
        else
            v2541
    let v2546 : (string -> string) = v1.ToString
    let v2547 : string = v2546 v2545
    (* run_target_args'
    let v2566 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2567 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2568 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2567 
    let _run_target_args'_v2566 = v2568 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2570 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2570 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2574 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2574 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2578 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2578 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2582 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2566 = v2582 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2585 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2566 = v2585 
    #endif
#else
    let v2586 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2566 = v2586 
    #endif
    let v2587 : System.TimeZoneInfo = _run_target_args'_v2566 
    (* run_target_args'
    let v2600 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2604 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2605 : (System.DateTime -> int64) = _.Ticks
    let v2606 : int64 = v2605 v1
    let _run_target_args'_v2604 = v2606 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2607 : (System.DateTime -> int64) = _.Ticks
    let v2608 : int64 = v2607 v1
    let _run_target_args'_v2604 = v2608 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2610 : int64 = null |> unbox<int64>
    let _run_target_args'_v2604 = v2610 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2613 : (System.DateTime -> int64) = _.Ticks
    let v2614 : int64 = v2613 v1
    let _run_target_args'_v2604 = v2614 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2615 : (System.DateTime -> int64) = _.Ticks
    let v2616 : int64 = v2615 v1
    let _run_target_args'_v2604 = v2616 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2617 : (System.DateTime -> int64) = _.Ticks
    let v2618 : int64 = v2617 v1
    let _run_target_args'_v2604 = v2618 
    #endif
#else
    let v2619 : (System.DateTime -> int64) = _.Ticks
    let v2620 : int64 = v2619 v1
    let _run_target_args'_v2604 = v2620 
    #endif
    let v2621 : int64 = _run_target_args'_v2604 
    let v2641 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2642 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2621) v2641 
    let v2644 : System.TimeSpan = v2642 |> System.TimeSpan 
    let _run_target_args'_v2600 = v2644 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2650 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2651 : (System.DateTime -> int64) = _.Ticks
    let v2652 : int64 = v2651 v1
    let _run_target_args'_v2650 = v2652 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2653 : (System.DateTime -> int64) = _.Ticks
    let v2654 : int64 = v2653 v1
    let _run_target_args'_v2650 = v2654 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2656 : int64 = null |> unbox<int64>
    let _run_target_args'_v2650 = v2656 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2659 : (System.DateTime -> int64) = _.Ticks
    let v2660 : int64 = v2659 v1
    let _run_target_args'_v2650 = v2660 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2661 : (System.DateTime -> int64) = _.Ticks
    let v2662 : int64 = v2661 v1
    let _run_target_args'_v2650 = v2662 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2663 : (System.DateTime -> int64) = _.Ticks
    let v2664 : int64 = v2663 v1
    let _run_target_args'_v2650 = v2664 
    #endif
#else
    let v2665 : (System.DateTime -> int64) = _.Ticks
    let v2666 : int64 = v2665 v1
    let _run_target_args'_v2650 = v2666 
    #endif
    let v2667 : int64 = _run_target_args'_v2650 
    let v2687 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2688 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2667) v2687 
    let v2690 : System.TimeSpan = v2688 |> System.TimeSpan 
    let _run_target_args'_v2600 = v2690 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2694 : US3 = US3_2
    let v2695 : US4 = US4_3(v2694)
    let v2696 : string = $"date_time.get_utc_offset / target: {v2695}"
    let v2697 : System.TimeSpan = failwith<System.TimeSpan> v2696
    let _run_target_args'_v2600 = v2697 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2701 : US3 = US3_0
    let v2702 : US4 = US4_4(v2701)
    let v2703 : string = $"date_time.get_utc_offset / target: {v2702}"
    let v2704 : System.TimeSpan = failwith<System.TimeSpan> v2703
    let _run_target_args'_v2600 = v2704 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2708 : US3 = US3_0
    let v2709 : US4 = US4_5(v2708)
    let v2710 : string = $"date_time.get_utc_offset / target: {v2709}"
    let v2711 : System.TimeSpan = failwith<System.TimeSpan> v2710
    let _run_target_args'_v2600 = v2711 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2714 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2719 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2720 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2721 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2720 
    let _run_target_args'_v2719 = v2721 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2723 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2723 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2727 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2727 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2731 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2731 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2735 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2719 = v2735 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2738 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2719 = v2738 
    #endif
#else
    let v2739 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2719 = v2739 
    #endif
    let v2740 : System.TimeZoneInfo = _run_target_args'_v2719 
    let v2746 : (System.DateTime -> System.TimeSpan) = v2714 v2740
    let v2747 : System.TimeSpan = v2746 v1
    let _run_target_args'_v2600 = v2747 
    #endif
#else
    let v2748 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2753 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2754 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2755 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2754 
    let _run_target_args'_v2753 = v2755 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2757 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2757 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2761 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2761 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2765 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2765 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2769 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2753 = v2769 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2772 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2753 = v2772 
    #endif
#else
    let v2773 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2753 = v2773 
    #endif
    let v2774 : System.TimeZoneInfo = _run_target_args'_v2753 
    let v2780 : (System.DateTime -> System.TimeSpan) = v2748 v2774
    let v2781 : System.TimeSpan = v2780 v1
    let _run_target_args'_v2600 = v2781 
    #endif
    let v2782 : System.TimeSpan = _run_target_args'_v2600 
    let v2792 : (System.TimeSpan -> int32) = _.Hours
    let v2793 : int32 = v2792 v2782
    let v2796 : bool = v2793 > 0
    let v2797 : uint8 =
        if v2796 then
            1uy
        else
            0uy
    let v2798 : string = method86()
    (* run_target_args'
    let v2852 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2853 : string = "$0.toString($1)"
    let v2854 : string = Fable.Core.RustInterop.emitRustExpr struct (v2782, v2798) v2853 
    let _run_target_args'_v2852 = v2854 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2855 : string = "$0.toString($1)"
    let v2856 : string = Fable.Core.RustInterop.emitRustExpr struct (v2782, v2798) v2855 
    let _run_target_args'_v2852 = v2856 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2857 : string = "$0.toString($1)"
    let v2858 : string = Fable.Core.RustInterop.emitRustExpr struct (v2782, v2798) v2857 
    let _run_target_args'_v2852 = v2858 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2859 : string = v2782.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2852 = v2859 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2860 : string = v2782.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2852 = v2860 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2862 : string = v2782.ToString v2798 
    let _run_target_args'_v2852 = v2862 
    #endif
#else
    let v2915 : string = v2782.ToString v2798 
    let _run_target_args'_v2852 = v2915 
    #endif
    let v2967 : string = _run_target_args'_v2852 
    let v3022 : string = $"{v2797}{v2967}"
    let v3024 : (System.Guid -> string) = _.ToString()
    let v3025 : string = v3024 v0
    let v3028 : int32 = v2547.Length
    let v3029 : int32 = v3022.Length
    let v3030 : int32 = v3028 + v3029
    let v3032 : (string -> int32) = String.length
    let v3033 : int32 = v3032 v3025
    let v3041 : int32 = v3030 |> int32 
    let v3054 : int32 = v3033 |> int32 
    let v3062 : int32 = v3054 - 1
    let v3064 : string = v3025.[int v3041..int v3062]
    let v3068 : string = $"{v2547}{v3022}{v3064}"
    (* run_target_args'
    let v3073 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3075 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3075 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3079 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3079 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3083 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3073 = v3083 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3087 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3087 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3091 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3095 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3095 
    #endif
#else
    let v3099 : System.Guid = v3068 |> System.Guid 
    let _run_target_args'_v3073 = v3099 
    #endif
    let v3102 : System.Guid = _run_target_args'_v3073 
    let _run_target_args'_v569 = v3102 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3108 : string = method85()
    let v3110 : bool = v3108 = ""
    let v3112 : string =
        if v3110 then
            let v3111 : string = "M-d-y hh:mm:ss tt"
            v3111
        else
            v3108
    let v3113 : (string -> string) = v1.ToString
    let v3114 : string = v3113 v3112
    (* run_target_args'
    let v3133 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3134 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3135 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3134 
    let _run_target_args'_v3133 = v3135 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3137 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3137 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3141 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3141 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3145 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3145 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3149 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3133 = v3149 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3152 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3133 = v3152 
    #endif
#else
    let v3153 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3133 = v3153 
    #endif
    let v3154 : System.TimeZoneInfo = _run_target_args'_v3133 
    (* run_target_args'
    let v3167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3171 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3172 : (System.DateTime -> int64) = _.Ticks
    let v3173 : int64 = v3172 v1
    let _run_target_args'_v3171 = v3173 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3174 : (System.DateTime -> int64) = _.Ticks
    let v3175 : int64 = v3174 v1
    let _run_target_args'_v3171 = v3175 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3177 : int64 = null |> unbox<int64>
    let _run_target_args'_v3171 = v3177 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3180 : (System.DateTime -> int64) = _.Ticks
    let v3181 : int64 = v3180 v1
    let _run_target_args'_v3171 = v3181 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3182 : (System.DateTime -> int64) = _.Ticks
    let v3183 : int64 = v3182 v1
    let _run_target_args'_v3171 = v3183 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3184 : (System.DateTime -> int64) = _.Ticks
    let v3185 : int64 = v3184 v1
    let _run_target_args'_v3171 = v3185 
    #endif
#else
    let v3186 : (System.DateTime -> int64) = _.Ticks
    let v3187 : int64 = v3186 v1
    let _run_target_args'_v3171 = v3187 
    #endif
    let v3188 : int64 = _run_target_args'_v3171 
    let v3208 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3209 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3188) v3208 
    let v3211 : System.TimeSpan = v3209 |> System.TimeSpan 
    let _run_target_args'_v3167 = v3211 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3217 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3218 : (System.DateTime -> int64) = _.Ticks
    let v3219 : int64 = v3218 v1
    let _run_target_args'_v3217 = v3219 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3220 : (System.DateTime -> int64) = _.Ticks
    let v3221 : int64 = v3220 v1
    let _run_target_args'_v3217 = v3221 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3223 : int64 = null |> unbox<int64>
    let _run_target_args'_v3217 = v3223 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3226 : (System.DateTime -> int64) = _.Ticks
    let v3227 : int64 = v3226 v1
    let _run_target_args'_v3217 = v3227 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3228 : (System.DateTime -> int64) = _.Ticks
    let v3229 : int64 = v3228 v1
    let _run_target_args'_v3217 = v3229 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3230 : (System.DateTime -> int64) = _.Ticks
    let v3231 : int64 = v3230 v1
    let _run_target_args'_v3217 = v3231 
    #endif
#else
    let v3232 : (System.DateTime -> int64) = _.Ticks
    let v3233 : int64 = v3232 v1
    let _run_target_args'_v3217 = v3233 
    #endif
    let v3234 : int64 = _run_target_args'_v3217 
    let v3254 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3255 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3234) v3254 
    let v3257 : System.TimeSpan = v3255 |> System.TimeSpan 
    let _run_target_args'_v3167 = v3257 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3261 : US3 = US3_2
    let v3262 : US4 = US4_3(v3261)
    let v3263 : string = $"date_time.get_utc_offset / target: {v3262}"
    let v3264 : System.TimeSpan = failwith<System.TimeSpan> v3263
    let _run_target_args'_v3167 = v3264 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3268 : US3 = US3_0
    let v3269 : US4 = US4_4(v3268)
    let v3270 : string = $"date_time.get_utc_offset / target: {v3269}"
    let v3271 : System.TimeSpan = failwith<System.TimeSpan> v3270
    let _run_target_args'_v3167 = v3271 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3275 : US3 = US3_0
    let v3276 : US4 = US4_5(v3275)
    let v3277 : string = $"date_time.get_utc_offset / target: {v3276}"
    let v3278 : System.TimeSpan = failwith<System.TimeSpan> v3277
    let _run_target_args'_v3167 = v3278 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3281 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3286 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3287 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3288 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3287 
    let _run_target_args'_v3286 = v3288 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3290 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3290 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3294 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3294 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3298 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3298 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3302 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3286 = v3302 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3305 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3286 = v3305 
    #endif
#else
    let v3306 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3286 = v3306 
    #endif
    let v3307 : System.TimeZoneInfo = _run_target_args'_v3286 
    let v3313 : (System.DateTime -> System.TimeSpan) = v3281 v3307
    let v3314 : System.TimeSpan = v3313 v1
    let _run_target_args'_v3167 = v3314 
    #endif
#else
    let v3315 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3320 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3321 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3322 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3321 
    let _run_target_args'_v3320 = v3322 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3324 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3324 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3328 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3328 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3332 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3332 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3336 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3320 = v3336 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3339 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3320 = v3339 
    #endif
#else
    let v3340 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3320 = v3340 
    #endif
    let v3341 : System.TimeZoneInfo = _run_target_args'_v3320 
    let v3347 : (System.DateTime -> System.TimeSpan) = v3315 v3341
    let v3348 : System.TimeSpan = v3347 v1
    let _run_target_args'_v3167 = v3348 
    #endif
    let v3349 : System.TimeSpan = _run_target_args'_v3167 
    let v3359 : (System.TimeSpan -> int32) = _.Hours
    let v3360 : int32 = v3359 v3349
    let v3363 : bool = v3360 > 0
    let v3364 : uint8 =
        if v3363 then
            1uy
        else
            0uy
    let v3365 : string = method86()
    (* run_target_args'
    let v3419 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3420 : string = "$0.toString($1)"
    let v3421 : string = Fable.Core.RustInterop.emitRustExpr struct (v3349, v3365) v3420 
    let _run_target_args'_v3419 = v3421 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3422 : string = "$0.toString($1)"
    let v3423 : string = Fable.Core.RustInterop.emitRustExpr struct (v3349, v3365) v3422 
    let _run_target_args'_v3419 = v3423 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3424 : string = "$0.toString($1)"
    let v3425 : string = Fable.Core.RustInterop.emitRustExpr struct (v3349, v3365) v3424 
    let _run_target_args'_v3419 = v3425 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3426 : string = v3349.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3419 = v3426 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3427 : string = v3349.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3419 = v3427 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3429 : string = v3349.ToString v3365 
    let _run_target_args'_v3419 = v3429 
    #endif
#else
    let v3482 : string = v3349.ToString v3365 
    let _run_target_args'_v3419 = v3482 
    #endif
    let v3534 : string = _run_target_args'_v3419 
    let v3589 : string = $"{v3364}{v3534}"
    let v3591 : (System.Guid -> string) = _.ToString()
    let v3592 : string = v3591 v0
    let v3595 : int32 = v3114.Length
    let v3596 : int32 = v3589.Length
    let v3597 : int32 = v3595 + v3596
    let v3599 : (string -> int32) = String.length
    let v3600 : int32 = v3599 v3592
    let v3608 : int32 = v3597 |> int32 
    let v3621 : int32 = v3600 |> int32 
    let v3629 : int32 = v3621 - 1
    let v3631 : string = v3592.[int v3608..int v3629]
    let v3635 : string = $"{v3114}{v3589}{v3631}"
    (* run_target_args'
    let v3640 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3642 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3642 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3646 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3646 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3650 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3640 = v3650 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3654 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3654 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3658 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3658 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3662 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3662 
    #endif
#else
    let v3666 : System.Guid = v3635 |> System.Guid 
    let _run_target_args'_v3640 = v3666 
    #endif
    let v3669 : System.Guid = _run_target_args'_v3640 
    let _run_target_args'_v569 = v3669 
    #endif
#else
    let v3675 : string = method85()
    let v3677 : bool = v3675 = ""
    let v3679 : string =
        if v3677 then
            let v3678 : string = "M-d-y hh:mm:ss tt"
            v3678
        else
            v3675
    let v3680 : (string -> string) = v1.ToString
    let v3681 : string = v3680 v3679
    (* run_target_args'
    let v3700 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3701 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3702 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3701 
    let _run_target_args'_v3700 = v3702 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3704 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3704 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3708 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3708 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3712 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3712 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3716 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3700 = v3716 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3719 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3700 = v3719 
    #endif
#else
    let v3720 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3700 = v3720 
    #endif
    let v3721 : System.TimeZoneInfo = _run_target_args'_v3700 
    (* run_target_args'
    let v3734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3738 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3739 : (System.DateTime -> int64) = _.Ticks
    let v3740 : int64 = v3739 v1
    let _run_target_args'_v3738 = v3740 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3741 : (System.DateTime -> int64) = _.Ticks
    let v3742 : int64 = v3741 v1
    let _run_target_args'_v3738 = v3742 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3744 : int64 = null |> unbox<int64>
    let _run_target_args'_v3738 = v3744 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3747 : (System.DateTime -> int64) = _.Ticks
    let v3748 : int64 = v3747 v1
    let _run_target_args'_v3738 = v3748 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3749 : (System.DateTime -> int64) = _.Ticks
    let v3750 : int64 = v3749 v1
    let _run_target_args'_v3738 = v3750 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3751 : (System.DateTime -> int64) = _.Ticks
    let v3752 : int64 = v3751 v1
    let _run_target_args'_v3738 = v3752 
    #endif
#else
    let v3753 : (System.DateTime -> int64) = _.Ticks
    let v3754 : int64 = v3753 v1
    let _run_target_args'_v3738 = v3754 
    #endif
    let v3755 : int64 = _run_target_args'_v3738 
    let v3775 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3776 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3755) v3775 
    let v3778 : System.TimeSpan = v3776 |> System.TimeSpan 
    let _run_target_args'_v3734 = v3778 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3784 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3785 : (System.DateTime -> int64) = _.Ticks
    let v3786 : int64 = v3785 v1
    let _run_target_args'_v3784 = v3786 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3787 : (System.DateTime -> int64) = _.Ticks
    let v3788 : int64 = v3787 v1
    let _run_target_args'_v3784 = v3788 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3790 : int64 = null |> unbox<int64>
    let _run_target_args'_v3784 = v3790 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3793 : (System.DateTime -> int64) = _.Ticks
    let v3794 : int64 = v3793 v1
    let _run_target_args'_v3784 = v3794 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3795 : (System.DateTime -> int64) = _.Ticks
    let v3796 : int64 = v3795 v1
    let _run_target_args'_v3784 = v3796 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3797 : (System.DateTime -> int64) = _.Ticks
    let v3798 : int64 = v3797 v1
    let _run_target_args'_v3784 = v3798 
    #endif
#else
    let v3799 : (System.DateTime -> int64) = _.Ticks
    let v3800 : int64 = v3799 v1
    let _run_target_args'_v3784 = v3800 
    #endif
    let v3801 : int64 = _run_target_args'_v3784 
    let v3821 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3822 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3801) v3821 
    let v3824 : System.TimeSpan = v3822 |> System.TimeSpan 
    let _run_target_args'_v3734 = v3824 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3828 : US3 = US3_2
    let v3829 : US4 = US4_3(v3828)
    let v3830 : string = $"date_time.get_utc_offset / target: {v3829}"
    let v3831 : System.TimeSpan = failwith<System.TimeSpan> v3830
    let _run_target_args'_v3734 = v3831 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3835 : US3 = US3_0
    let v3836 : US4 = US4_4(v3835)
    let v3837 : string = $"date_time.get_utc_offset / target: {v3836}"
    let v3838 : System.TimeSpan = failwith<System.TimeSpan> v3837
    let _run_target_args'_v3734 = v3838 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3842 : US3 = US3_0
    let v3843 : US4 = US4_5(v3842)
    let v3844 : string = $"date_time.get_utc_offset / target: {v3843}"
    let v3845 : System.TimeSpan = failwith<System.TimeSpan> v3844
    let _run_target_args'_v3734 = v3845 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3848 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3853 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3854 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3855 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3854 
    let _run_target_args'_v3853 = v3855 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3857 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3857 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3861 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3861 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3865 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3865 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3869 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3853 = v3869 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3872 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3853 = v3872 
    #endif
#else
    let v3873 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3853 = v3873 
    #endif
    let v3874 : System.TimeZoneInfo = _run_target_args'_v3853 
    let v3880 : (System.DateTime -> System.TimeSpan) = v3848 v3874
    let v3881 : System.TimeSpan = v3880 v1
    let _run_target_args'_v3734 = v3881 
    #endif
#else
    let v3882 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3887 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3888 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3889 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3888 
    let _run_target_args'_v3887 = v3889 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3891 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3895 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3899 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3899 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3903 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3887 = v3903 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3906 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3887 = v3906 
    #endif
#else
    let v3907 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3887 = v3907 
    #endif
    let v3908 : System.TimeZoneInfo = _run_target_args'_v3887 
    let v3914 : (System.DateTime -> System.TimeSpan) = v3882 v3908
    let v3915 : System.TimeSpan = v3914 v1
    let _run_target_args'_v3734 = v3915 
    #endif
    let v3916 : System.TimeSpan = _run_target_args'_v3734 
    let v3926 : (System.TimeSpan -> int32) = _.Hours
    let v3927 : int32 = v3926 v3916
    let v3930 : bool = v3927 > 0
    let v3931 : uint8 =
        if v3930 then
            1uy
        else
            0uy
    let v3932 : string = method86()
    (* run_target_args'
    let v3986 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3987 : string = "$0.toString($1)"
    let v3988 : string = Fable.Core.RustInterop.emitRustExpr struct (v3916, v3932) v3987 
    let _run_target_args'_v3986 = v3988 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3989 : string = "$0.toString($1)"
    let v3990 : string = Fable.Core.RustInterop.emitRustExpr struct (v3916, v3932) v3989 
    let _run_target_args'_v3986 = v3990 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3991 : string = "$0.toString($1)"
    let v3992 : string = Fable.Core.RustInterop.emitRustExpr struct (v3916, v3932) v3991 
    let _run_target_args'_v3986 = v3992 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3993 : string = v3916.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3986 = v3993 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3994 : string = v3916.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3986 = v3994 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3996 : string = v3916.ToString v3932 
    let _run_target_args'_v3986 = v3996 
    #endif
#else
    let v4049 : string = v3916.ToString v3932 
    let _run_target_args'_v3986 = v4049 
    #endif
    let v4101 : string = _run_target_args'_v3986 
    let v4156 : string = $"{v3931}{v4101}"
    let v4158 : (System.Guid -> string) = _.ToString()
    let v4159 : string = v4158 v0
    let v4162 : int32 = v3681.Length
    let v4163 : int32 = v4156.Length
    let v4164 : int32 = v4162 + v4163
    let v4166 : (string -> int32) = String.length
    let v4167 : int32 = v4166 v4159
    let v4175 : int32 = v4164 |> int32 
    let v4188 : int32 = v4167 |> int32 
    let v4196 : int32 = v4188 - 1
    let v4198 : string = v4159.[int v4175..int v4196]
    let v4202 : string = $"{v3681}{v4156}{v4198}"
    (* run_target_args'
    let v4207 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4209 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4209 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4213 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4213 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4217 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4207 = v4217 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4221 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4221 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4225 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4225 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4229 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4229 
    #endif
#else
    let v4233 : System.Guid = v4202 |> System.Guid 
    let _run_target_args'_v4207 = v4233 
    #endif
    let v4236 : System.Guid = _run_target_args'_v4207 
    let _run_target_args'_v569 = v4236 
    #endif
    let v4242 : System.Guid = _run_target_args'_v569 
    v4242
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
    let v176 : US13 = match v170 with Ok () -> v173 () | Error x -> v174 x
    match v176 with
    | US13_1(v228) -> (* Error *)
        let v229 : unit = ()
        let v230 : (unit -> unit) = closure43(v0, v228)
        let v231 : unit = (fun () -> v230 (); v229) ()
        ()
    | US13_0 -> (* Ok *)
        let v179 : unit = ()
        let v180 : (unit -> unit) = closure44(v0)
        let v181 : unit = (fun () -> v180 (); v179) ()
        ()
    (* run_target_args'
    let v282 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v283 : (unit -> unit) = method101(v0)
    let v284 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v283 "$0()" )
    let _run_target_args'_v282 = v284 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v285 : (unit -> unit) = method101(v0)
    let v286 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v285 "$0()" )
    let _run_target_args'_v282 = v286 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v287 : (unit -> unit) = method101(v0)
    let v288 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v287 "$0()" )
    let _run_target_args'_v282 = v288 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v289 : (unit -> unit) = method102(v0)
    let v290 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v289 () }
    let _run_target_args'_v282 = v290 
    #endif
#if FABLE_COMPILER_PYTHON
    let v291 : (unit -> unit) = method102(v0)
    let v292 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v291 () }
    let _run_target_args'_v282 = v292 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v293 : (unit -> unit) = method102(v0)
    let v294 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v293 () }
    let _run_target_args'_v282 = v294 
    #endif
#else
    let v295 : (unit -> unit) = method102(v0)
    let v296 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v295 () }
    let _run_target_args'_v282 = v296 
    #endif
    let v297 : System.IDisposable = _run_target_args'_v282 
    let _run_target_args'_v154 = v297 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v302 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v154 = v302 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v306 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v154 = v306 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v309 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v314 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v316 : bool = null |> unbox<bool>
    let _run_target_args'_v314 = v316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v320 : bool = null |> unbox<bool>
    let _run_target_args'_v314 = v320 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v324 : bool = null |> unbox<bool>
    let _run_target_args'_v314 = v324 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v328 : bool = null |> unbox<bool>
    let _run_target_args'_v314 = v328 
    #endif
#if FABLE_COMPILER_PYTHON
    let v332 : bool = null |> unbox<bool>
    let _run_target_args'_v314 = v332 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v336 : bool = null |> unbox<bool>
    let _run_target_args'_v314 = v336 
    #endif
#else
    let v339 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v340 : bool = v339 v309
    let _run_target_args'_v314 = v340 
    #endif
    let v341 : bool = _run_target_args'_v314 
    let v347 : bool = v341 = false
    if v347 then
        (* run_target_args'
        let v352 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v354 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v352 = v354 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v358 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v352 = v358 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v362 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v352 = v362 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v366 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v352 = v366 
        #endif
#if FABLE_COMPILER_PYTHON
        let v370 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v352 = v370 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v374 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v352 = v374 
        #endif
#else
        let v377 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v378 : System.DateTime = v377 v309
        let _run_target_args'_v352 = v378 
        #endif
        let v379 : System.DateTime = _run_target_args'_v352 
        let v385 : _ = {| Exists = v341; CreationTime = v379 |}
        let v387 : string = $"%A{v385}"
        let v390 : unit = ()
        let v391 : (unit -> unit) = closure46(v0, v387)
        let v392 : unit = (fun () -> v391 (); v390) ()
        ()
    (* run_target_args'
    let v443 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v444 : (unit -> unit) = method106(v0)
    let v445 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v444 "$0()" )
    let _run_target_args'_v443 = v445 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v446 : (unit -> unit) = method106(v0)
    let v447 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v446 "$0()" )
    let _run_target_args'_v443 = v447 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v448 : (unit -> unit) = method106(v0)
    let v449 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v448 "$0()" )
    let _run_target_args'_v443 = v449 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v450 : (unit -> unit) = method107(v0)
    let v451 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v450 () }
    let _run_target_args'_v443 = v451 
    #endif
#if FABLE_COMPILER_PYTHON
    let v452 : (unit -> unit) = method107(v0)
    let v453 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v452 () }
    let _run_target_args'_v443 = v453 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v454 : (unit -> unit) = method107(v0)
    let v455 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v454 () }
    let _run_target_args'_v443 = v455 
    #endif
#else
    let v456 : (unit -> unit) = method107(v0)
    let v457 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v456 () }
    let _run_target_args'_v443 = v457 
    #endif
    let v458 : System.IDisposable = _run_target_args'_v443 
    let _run_target_args'_v154 = v458 
    #endif
#if FABLE_COMPILER_PYTHON
    let v462 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v467 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v469 : bool = null |> unbox<bool>
    let _run_target_args'_v467 = v469 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v473 : bool = null |> unbox<bool>
    let _run_target_args'_v467 = v473 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v477 : bool = null |> unbox<bool>
    let _run_target_args'_v467 = v477 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v481 : bool = null |> unbox<bool>
    let _run_target_args'_v467 = v481 
    #endif
#if FABLE_COMPILER_PYTHON
    let v485 : bool = null |> unbox<bool>
    let _run_target_args'_v467 = v485 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v489 : bool = null |> unbox<bool>
    let _run_target_args'_v467 = v489 
    #endif
#else
    let v492 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v493 : bool = v492 v462
    let _run_target_args'_v467 = v493 
    #endif
    let v494 : bool = _run_target_args'_v467 
    let v500 : bool = v494 = false
    if v500 then
        (* run_target_args'
        let v505 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v507 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v505 = v507 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v511 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v505 = v511 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v515 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v505 = v515 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v519 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v505 = v519 
        #endif
#if FABLE_COMPILER_PYTHON
        let v523 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v505 = v523 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v527 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v505 = v527 
        #endif
#else
        let v530 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v531 : System.DateTime = v530 v462
        let _run_target_args'_v505 = v531 
        #endif
        let v532 : System.DateTime = _run_target_args'_v505 
        let v538 : _ = {| Exists = v494; CreationTime = v532 |}
        let v540 : string = $"%A{v538}"
        let v543 : unit = ()
        let v544 : (unit -> unit) = closure46(v0, v540)
        let v545 : unit = (fun () -> v544 (); v543) ()
        ()
    (* run_target_args'
    let v596 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v597 : (unit -> unit) = method106(v0)
    let v598 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v597 "$0()" )
    let _run_target_args'_v596 = v598 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v599 : (unit -> unit) = method106(v0)
    let v600 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v599 "$0()" )
    let _run_target_args'_v596 = v600 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v601 : (unit -> unit) = method106(v0)
    let v602 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v601 "$0()" )
    let _run_target_args'_v596 = v602 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v603 : (unit -> unit) = method107(v0)
    let v604 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v603 () }
    let _run_target_args'_v596 = v604 
    #endif
#if FABLE_COMPILER_PYTHON
    let v605 : (unit -> unit) = method107(v0)
    let v606 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v605 () }
    let _run_target_args'_v596 = v606 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v607 : (unit -> unit) = method107(v0)
    let v608 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v607 () }
    let _run_target_args'_v596 = v608 
    #endif
#else
    let v609 : (unit -> unit) = method107(v0)
    let v610 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v609 () }
    let _run_target_args'_v596 = v610 
    #endif
    let v611 : System.IDisposable = _run_target_args'_v596 
    let _run_target_args'_v154 = v611 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v615 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v620 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v622 : bool = null |> unbox<bool>
    let _run_target_args'_v620 = v622 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v626 : bool = null |> unbox<bool>
    let _run_target_args'_v620 = v626 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v630 : bool = null |> unbox<bool>
    let _run_target_args'_v620 = v630 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v634 : bool = null |> unbox<bool>
    let _run_target_args'_v620 = v634 
    #endif
#if FABLE_COMPILER_PYTHON
    let v638 : bool = null |> unbox<bool>
    let _run_target_args'_v620 = v638 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v642 : bool = null |> unbox<bool>
    let _run_target_args'_v620 = v642 
    #endif
#else
    let v645 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v646 : bool = v645 v615
    let _run_target_args'_v620 = v646 
    #endif
    let v647 : bool = _run_target_args'_v620 
    let v653 : bool = v647 = false
    if v653 then
        (* run_target_args'
        let v658 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v660 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v658 = v660 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v664 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v658 = v664 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v668 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v658 = v668 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v672 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v658 = v672 
        #endif
#if FABLE_COMPILER_PYTHON
        let v676 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v658 = v676 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v680 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v658 = v680 
        #endif
#else
        let v683 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v684 : System.DateTime = v683 v615
        let _run_target_args'_v658 = v684 
        #endif
        let v685 : System.DateTime = _run_target_args'_v658 
        let v691 : _ = {| Exists = v647; CreationTime = v685 |}
        let v693 : string = $"%A{v691}"
        let v696 : unit = ()
        let v697 : (unit -> unit) = closure46(v0, v693)
        let v698 : unit = (fun () -> v697 (); v696) ()
        ()
    (* run_target_args'
    let v749 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v750 : (unit -> unit) = method106(v0)
    let v751 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v750 "$0()" )
    let _run_target_args'_v749 = v751 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v752 : (unit -> unit) = method106(v0)
    let v753 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v752 "$0()" )
    let _run_target_args'_v749 = v753 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v754 : (unit -> unit) = method106(v0)
    let v755 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v754 "$0()" )
    let _run_target_args'_v749 = v755 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v756 : (unit -> unit) = method107(v0)
    let v757 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v756 () }
    let _run_target_args'_v749 = v757 
    #endif
#if FABLE_COMPILER_PYTHON
    let v758 : (unit -> unit) = method107(v0)
    let v759 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v758 () }
    let _run_target_args'_v749 = v759 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v760 : (unit -> unit) = method107(v0)
    let v761 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v760 () }
    let _run_target_args'_v749 = v761 
    #endif
#else
    let v762 : (unit -> unit) = method107(v0)
    let v763 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v762 () }
    let _run_target_args'_v749 = v763 
    #endif
    let v764 : System.IDisposable = _run_target_args'_v749 
    let _run_target_args'_v154 = v764 
    #endif
#else
    let v768 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v773 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v775 : bool = null |> unbox<bool>
    let _run_target_args'_v773 = v775 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v779 : bool = null |> unbox<bool>
    let _run_target_args'_v773 = v779 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v783 : bool = null |> unbox<bool>
    let _run_target_args'_v773 = v783 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v787 : bool = null |> unbox<bool>
    let _run_target_args'_v773 = v787 
    #endif
#if FABLE_COMPILER_PYTHON
    let v791 : bool = null |> unbox<bool>
    let _run_target_args'_v773 = v791 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v795 : bool = null |> unbox<bool>
    let _run_target_args'_v773 = v795 
    #endif
#else
    let v798 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v799 : bool = v798 v768
    let _run_target_args'_v773 = v799 
    #endif
    let v800 : bool = _run_target_args'_v773 
    let v806 : bool = v800 = false
    if v806 then
        (* run_target_args'
        let v811 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v813 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v811 = v813 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v817 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v811 = v817 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v821 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v811 = v821 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v825 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v811 = v825 
        #endif
#if FABLE_COMPILER_PYTHON
        let v829 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v811 = v829 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v833 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v811 = v833 
        #endif
#else
        let v836 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v837 : System.DateTime = v836 v768
        let _run_target_args'_v811 = v837 
        #endif
        let v838 : System.DateTime = _run_target_args'_v811 
        let v844 : _ = {| Exists = v800; CreationTime = v838 |}
        let v846 : string = $"%A{v844}"
        let v849 : unit = ()
        let v850 : (unit -> unit) = closure46(v0, v846)
        let v851 : unit = (fun () -> v850 (); v849) ()
        ()
    (* run_target_args'
    let v902 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v903 : (unit -> unit) = method106(v0)
    let v904 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v903 "$0()" )
    let _run_target_args'_v902 = v904 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v905 : (unit -> unit) = method106(v0)
    let v906 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v905 "$0()" )
    let _run_target_args'_v902 = v906 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v907 : (unit -> unit) = method106(v0)
    let v908 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v907 "$0()" )
    let _run_target_args'_v902 = v908 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v909 : (unit -> unit) = method107(v0)
    let v910 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v909 () }
    let _run_target_args'_v902 = v910 
    #endif
#if FABLE_COMPILER_PYTHON
    let v911 : (unit -> unit) = method107(v0)
    let v912 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v911 () }
    let _run_target_args'_v902 = v912 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v913 : (unit -> unit) = method107(v0)
    let v914 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v913 () }
    let _run_target_args'_v902 = v914 
    #endif
#else
    let v915 : (unit -> unit) = method107(v0)
    let v916 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v915 () }
    let _run_target_args'_v902 = v916 
    #endif
    let v917 : System.IDisposable = _run_target_args'_v902 
    let _run_target_args'_v154 = v917 
    #endif
    let v921 : System.IDisposable = _run_target_args'_v154 
    v921
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
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v24 : US5 = US5_1
    let v25 : US5 = v10 |> Option.defaultValue v24 
    let v29 : string = method118(v3)
    let v30 : bool = v2 >= 11uy
    if v30 then
        let v31 : string = $"file_system.read_link / "
        let v32 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v33 : string = v31 + v32 
        (* run_target_args'
        let v38 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v39 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v40 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v33 v39 
        let _run_target_args'_v38 = v40 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v41 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v42 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v33 v41 
        let _run_target_args'_v38 = v42 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v43 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v44 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v33 v43 
        let _run_target_args'_v38 = v44 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v46 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v46 
        #endif
#if FABLE_COMPILER_PYTHON
        let v50 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v50 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v54 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v54 
        #endif
#else
        let v58 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v58 
        #endif
        let v61 : std_io_Error = _run_target_args'_v38 
        (* run_target_args'
        let v68 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v69 : string = "Err($0)"
        let v70 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v61 v69 
        let _run_target_args'_v68 = v70 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = "Err($0)"
        let v72 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v61 v71 
        let _run_target_args'_v68 = v72 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v73 : string = "Err($0)"
        let v74 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v61 v73 
        let _run_target_args'_v68 = v74 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v75 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v75 
        #endif
#if FABLE_COMPILER_PYTHON
        let v76 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v76 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v77 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v77 
        #endif
#else
        let v78 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v78 
        #endif
        let v79 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v68 
        v79
    else
        match v25 with
        | US5_0(v82) -> (* Some *)
            let v85 : string = ""
            let v86 : bool = v4 <> v85 
            if v86 then
                let v89 : uint8 = v2 + 1uy
                let v90 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v89
                let v91 : Result<std_path_PathBuf, std_io_Error> = v90 v82
                let v92 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v94 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v95 : string = "$0.map_err(|x| $1(x))"
                let v96 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v91, v92) v95 
                let _run_target_args'_v94 = v96 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v97 : string = "$0.map_err(|x| $1(x))"
                let v98 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v91, v92) v97 
                let _run_target_args'_v94 = v98 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v99 : string = "$0.map_err(|x| $1(x))"
                let v100 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v91, v92) v99 
                let _run_target_args'_v94 = v100 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v101 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v101 
                #endif
#if FABLE_COMPILER_PYTHON
                let v102 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v102 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v103 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v103 
                #endif
#else
                let v104 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v104 
                #endif
                let v105 : Result<std_path_PathBuf, string> = _run_target_args'_v94 
                let v108 : (std_path_PathBuf -> US14) = method113()
                let v109 : (string -> US14) = method114()
                let v111 : US14 = match v105 with Ok x -> v108 x | Error x -> v109 x
                match v111 with
                | US14_1(v267) -> (* Error *)
                    let v268 : string = $"file_system.read_link / "
                    let v269 : string = $"error': {v267} / error: {v29} / name: {v5}"
                    let v270 : string = v268 + v269 
                    (* run_target_args'
                    let v275 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v276 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v277 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v270 v276 
                    let _run_target_args'_v275 = v277 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v278 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v279 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v270 v278 
                    let _run_target_args'_v275 = v279 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v280 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v281 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v270 v280 
                    let _run_target_args'_v275 = v281 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v283 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v283 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v287 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v287 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v291 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v291 
                    #endif
#else
                    let v295 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v295 
                    #endif
                    let v298 : std_io_Error = _run_target_args'_v275 
                    (* run_target_args'
                    let v305 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v306 : string = "Err($0)"
                    let v307 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v298 v306 
                    let _run_target_args'_v305 = v307 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v308 : string = "Err($0)"
                    let v309 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v298 v308 
                    let _run_target_args'_v305 = v309 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v310 : string = "Err($0)"
                    let v311 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v298 v310 
                    let _run_target_args'_v305 = v311 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v312 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v312 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v313 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v313 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v314 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v314 
                    #endif
#else
                    let v315 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v315 
                    #endif
                    let v316 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v305 
                    v316
                | US14_0(v114) -> (* Ok *)
                    (* run_target_args'
                    let v119 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v120 : string = "$0.display()"
                    let v121 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v114 v120 
                    let _run_target_args'_v119 = v121 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v122 : string = "$0.display()"
                    let v123 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v114 v122 
                    let _run_target_args'_v119 = v123 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v124 : string = "$0.display()"
                    let v125 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v114 v124 
                    let _run_target_args'_v119 = v125 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v127 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v127 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v131 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v131 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v135 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v135 
                    #endif
#else
                    let v139 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v139 
                    #endif
                    let v142 : std_path_Display = _run_target_args'_v119 
                    let v149 : string = v142 |> string 
                    let v152 : string = method90(v149, v5)
                    (* run_target_args'
                    let v157 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v158 : string = "&*$0"
                    let v159 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v152 v158 
                    let _run_target_args'_v157 = v159 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v160 : string = "&*$0"
                    let v161 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v152 v160 
                    let _run_target_args'_v157 = v161 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v162 : string = "&*$0"
                    let v163 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v152 v162 
                    let _run_target_args'_v157 = v163 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v165 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v165 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v169 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v169 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v173 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v173 
                    #endif
#else
                    let v177 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v177 
                    #endif
                    let v180 : Ref<Str> = _run_target_args'_v157 
                    (* run_target_args'
                    let v190 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v191 : string = "String::from($0)"
                    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v180 v191 
                    let _run_target_args'_v190 = v192 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v193 : string = "String::from($0)"
                    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v180 v193 
                    let _run_target_args'_v190 = v194 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v195 : string = "String::from($0)"
                    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v180 v195 
                    let _run_target_args'_v190 = v196 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v198 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v198 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v202 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v202 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v206 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v206 
                    #endif
#else
                    let v210 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v210 
                    #endif
                    let v213 : std_string_String = _run_target_args'_v190 
                    (* run_target_args'
                    let v223 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v224 : string = "std::path::PathBuf::from($0)"
                    let v225 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v224 
                    let _run_target_args'_v223 = v225 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v226 : string = "std::path::PathBuf::from($0)"
                    let v227 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v226 
                    let _run_target_args'_v223 = v227 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v228 : string = "std::path::PathBuf::from($0)"
                    let v229 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v228 
                    let _run_target_args'_v223 = v229 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v231 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v231 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v235 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v235 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v239 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v239 
                    #endif
#else
                    let v243 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v243 
                    #endif
                    let v246 : std_path_PathBuf = _run_target_args'_v223 
                    (* run_target_args'
                    let v253 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v254 : string = "Ok($0)"
                    let v255 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v246 v254 
                    let _run_target_args'_v253 = v255 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v256 : string = "Ok($0)"
                    let v257 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v246 v256 
                    let _run_target_args'_v253 = v257 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v258 : string = "Ok($0)"
                    let v259 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v246 v258 
                    let _run_target_args'_v253 = v259 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v260 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v260 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v261 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v261 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v262 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v262 
                    #endif
#else
                    let v263 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v263 
                    #endif
                    let v264 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v253 
                    v264
            else
                let v321 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v322 : string = $"path: {v0} / error: {v29} / path': {v4} / name: {v5}"
                let v323 : string = v321 + v322 
                (* run_target_args'
                let v328 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v329 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v330 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v323 v329 
                let _run_target_args'_v328 = v330 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v331 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v332 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v323 v331 
                let _run_target_args'_v328 = v332 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v333 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v334 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v323 v333 
                let _run_target_args'_v328 = v334 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v336 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v336 
                #endif
#if FABLE_COMPILER_PYTHON
                let v340 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v340 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v344 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v344 
                #endif
#else
                let v348 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v348 
                #endif
                let v351 : std_io_Error = _run_target_args'_v328 
                (* run_target_args'
                let v358 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v359 : string = "Err($0)"
                let v360 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v351 v359 
                let _run_target_args'_v358 = v360 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v361 : string = "Err($0)"
                let v362 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v351 v361 
                let _run_target_args'_v358 = v362 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v363 : string = "Err($0)"
                let v364 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v351 v363 
                let _run_target_args'_v358 = v364 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v365 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v365 
                #endif
#if FABLE_COMPILER_PYTHON
                let v366 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v366 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v367 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v367 
                #endif
#else
                let v368 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v368 
                #endif
                let v369 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v358 
                v369
        | _ ->
            let v373 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v374 : string = $"path: {v0} / error: {v29} / path': {v4} / name: {v5}"
            let v375 : string = v373 + v374 
            (* run_target_args'
            let v380 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v381 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v382 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v375 v381 
            let _run_target_args'_v380 = v382 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v383 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v384 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v375 v383 
            let _run_target_args'_v380 = v384 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v385 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v386 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v375 v385 
            let _run_target_args'_v380 = v386 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v388 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v388 
            #endif
#if FABLE_COMPILER_PYTHON
            let v392 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v392 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v396 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v396 
            #endif
#else
            let v400 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v400 
            #endif
            let v403 : std_io_Error = _run_target_args'_v380 
            (* run_target_args'
            let v410 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v411 : string = "Err($0)"
            let v412 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v403 v411 
            let _run_target_args'_v410 = v412 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v413 : string = "Err($0)"
            let v414 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v403 v413 
            let _run_target_args'_v410 = v414 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v415 : string = "Err($0)"
            let v416 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v403 v415 
            let _run_target_args'_v410 = v416 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v417 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v417 
            #endif
#if FABLE_COMPILER_PYTHON
            let v418 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v418 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v419 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v419 
            #endif
#else
            let v420 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v420 
            #endif
            let v421 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v410 
            v421
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
    let v29 : US14 = match v23 with Ok x -> v26 x | Error x -> v27 x
    let v52 : Result<std_path_PathBuf, std_io_Error> =
        match v29 with
        | US14_1(v48) -> (* Error *)
            let v49 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method116(v0, v49, v1, v48, v2)
        | US14_0(v32) -> (* Ok *)
            (* run_target_args'
            let v34 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v35 : string = "Ok($0)"
            let v36 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v32 v35 
            let _run_target_args'_v34 = v36 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v37 : string = "Ok($0)"
            let v38 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v32 v37 
            let _run_target_args'_v34 = v38 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v39 : string = "Ok($0)"
            let v40 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v32 v39 
            let _run_target_args'_v34 = v40 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v41 : Result<std_path_PathBuf, std_io_Error> = v32 |> Ok
            let _run_target_args'_v34 = v41 
            #endif
#if FABLE_COMPILER_PYTHON
            let v42 : Result<std_path_PathBuf, std_io_Error> = v32 |> Ok
            let _run_target_args'_v34 = v42 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v43 : Result<std_path_PathBuf, std_io_Error> = v32 |> Ok
            let _run_target_args'_v34 = v43 
            #endif
#else
            let v44 : Result<std_path_PathBuf, std_io_Error> = v32 |> Ok
            let _run_target_args'_v34 = v44 
            #endif
            let v45 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v34 
            v45
    let _run_target_args'_v7 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v53 : string = "std::fs::read_link(&*$0)"
    let v54 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v53 
    let v55 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v57 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v58 : string = "$0.map_err(|x| $1(x))"
    let v59 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v54, v55) v58 
    let _run_target_args'_v57 = v59 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v60 : string = "$0.map_err(|x| $1(x))"
    let v61 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v54, v55) v60 
    let _run_target_args'_v57 = v61 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v62 : string = "$0.map_err(|x| $1(x))"
    let v63 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v54, v55) v62 
    let _run_target_args'_v57 = v63 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v64 : Result<std_path_PathBuf, string> = match v54 with Ok x -> Ok x | Error x -> Error (v55 x)
    let _run_target_args'_v57 = v64 
    #endif
#if FABLE_COMPILER_PYTHON
    let v65 : Result<std_path_PathBuf, string> = match v54 with Ok x -> Ok x | Error x -> Error (v55 x)
    let _run_target_args'_v57 = v65 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v66 : Result<std_path_PathBuf, string> = match v54 with Ok x -> Ok x | Error x -> Error (v55 x)
    let _run_target_args'_v57 = v66 
    #endif
#else
    let v67 : Result<std_path_PathBuf, string> = match v54 with Ok x -> Ok x | Error x -> Error (v55 x)
    let _run_target_args'_v57 = v67 
    #endif
    let v68 : Result<std_path_PathBuf, string> = _run_target_args'_v57 
    let v71 : (std_path_PathBuf -> US14) = method113()
    let v72 : (string -> US14) = method114()
    let v74 : US14 = match v68 with Ok x -> v71 x | Error x -> v72 x
    let v97 : Result<std_path_PathBuf, std_io_Error> =
        match v74 with
        | US14_1(v93) -> (* Error *)
            let v94 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method116(v0, v94, v1, v93, v2)
        | US14_0(v77) -> (* Ok *)
            (* run_target_args'
            let v79 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v80 : string = "Ok($0)"
            let v81 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v77 v80 
            let _run_target_args'_v79 = v81 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v82 : string = "Ok($0)"
            let v83 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v77 v82 
            let _run_target_args'_v79 = v83 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v84 : string = "Ok($0)"
            let v85 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v77 v84 
            let _run_target_args'_v79 = v85 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v86 : Result<std_path_PathBuf, std_io_Error> = v77 |> Ok
            let _run_target_args'_v79 = v86 
            #endif
#if FABLE_COMPILER_PYTHON
            let v87 : Result<std_path_PathBuf, std_io_Error> = v77 |> Ok
            let _run_target_args'_v79 = v87 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v88 : Result<std_path_PathBuf, std_io_Error> = v77 |> Ok
            let _run_target_args'_v79 = v88 
            #endif
#else
            let v89 : Result<std_path_PathBuf, std_io_Error> = v77 |> Ok
            let _run_target_args'_v79 = v89 
            #endif
            let v90 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v79 
            v90
    let _run_target_args'_v7 = v97 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v98 : string = "std::fs::read_link(&*$0)"
    let v99 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v98 
    let v100 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v102 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v103 : string = "$0.map_err(|x| $1(x))"
    let v104 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v99, v100) v103 
    let _run_target_args'_v102 = v104 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v105 : string = "$0.map_err(|x| $1(x))"
    let v106 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v99, v100) v105 
    let _run_target_args'_v102 = v106 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v107 : string = "$0.map_err(|x| $1(x))"
    let v108 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v99, v100) v107 
    let _run_target_args'_v102 = v108 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Result<std_path_PathBuf, string> = match v99 with Ok x -> Ok x | Error x -> Error (v100 x)
    let _run_target_args'_v102 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v110 : Result<std_path_PathBuf, string> = match v99 with Ok x -> Ok x | Error x -> Error (v100 x)
    let _run_target_args'_v102 = v110 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Result<std_path_PathBuf, string> = match v99 with Ok x -> Ok x | Error x -> Error (v100 x)
    let _run_target_args'_v102 = v111 
    #endif
#else
    let v112 : Result<std_path_PathBuf, string> = match v99 with Ok x -> Ok x | Error x -> Error (v100 x)
    let _run_target_args'_v102 = v112 
    #endif
    let v113 : Result<std_path_PathBuf, string> = _run_target_args'_v102 
    let v116 : (std_path_PathBuf -> US14) = method113()
    let v117 : (string -> US14) = method114()
    let v119 : US14 = match v113 with Ok x -> v116 x | Error x -> v117 x
    let v142 : Result<std_path_PathBuf, std_io_Error> =
        match v119 with
        | US14_1(v138) -> (* Error *)
            let v139 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method116(v0, v139, v1, v138, v2)
        | US14_0(v122) -> (* Ok *)
            (* run_target_args'
            let v124 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v125 : string = "Ok($0)"
            let v126 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v122 v125 
            let _run_target_args'_v124 = v126 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v127 : string = "Ok($0)"
            let v128 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v122 v127 
            let _run_target_args'_v124 = v128 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v129 : string = "Ok($0)"
            let v130 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v122 v129 
            let _run_target_args'_v124 = v130 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v131 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
            let _run_target_args'_v124 = v131 
            #endif
#if FABLE_COMPILER_PYTHON
            let v132 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
            let _run_target_args'_v124 = v132 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v133 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
            let _run_target_args'_v124 = v133 
            #endif
#else
            let v134 : Result<std_path_PathBuf, std_io_Error> = v122 |> Ok
            let _run_target_args'_v124 = v134 
            #endif
            let v135 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v124 
            v135
    let _run_target_args'_v7 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v152 
    #endif
#else
    let v156 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v7 = v156 
    #endif
    let v159 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v7 
    v159
and closure55 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method115(v0, v1, v2)
and closure54 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure55(v0, v1)
and method119 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method20(v0)
    let v5 : string option = method117(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v23 : US5 = US5_1
    let v24 : US5 = v9 |> Option.defaultValue v23 
    let v28 : string = method118(v3)
    let v29 : bool = v2 >= 11uy
    if v29 then
        let v30 : string = $"file_system.read_link / "
        let v31 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v32 : string = v30 + v31 
        (* run_target_args'
        let v37 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v38 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v39 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v32 v38 
        let _run_target_args'_v37 = v39 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v40 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v41 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v32 v40 
        let _run_target_args'_v37 = v41 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v42 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v43 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v32 v42 
        let _run_target_args'_v37 = v43 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v45 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v45 
        #endif
#if FABLE_COMPILER_PYTHON
        let v49 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v49 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v53 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v53 
        #endif
#else
        let v57 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v57 
        #endif
        let v60 : std_io_Error = _run_target_args'_v37 
        (* run_target_args'
        let v67 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v68 : string = "Err($0)"
        let v69 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v60 v68 
        let _run_target_args'_v67 = v69 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v70 : string = "Err($0)"
        let v71 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v60 v70 
        let _run_target_args'_v67 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v72 : string = "Err($0)"
        let v73 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v60 v72 
        let _run_target_args'_v67 = v73 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v74 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v74 
        #endif
#if FABLE_COMPILER_PYTHON
        let v75 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v75 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v76 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v76 
        #endif
#else
        let v77 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v77 
        #endif
        let v78 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v67 
        v78
    else
        match v24 with
        | US5_0(v81) -> (* Some *)
            let v84 : string = ""
            let v85 : bool = v0 <> v84 
            if v85 then
                let v88 : uint8 = v2 + 1uy
                let v89 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v88
                let v90 : Result<std_path_PathBuf, std_io_Error> = v89 v81
                let v91 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v93 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v94 : string = "$0.map_err(|x| $1(x))"
                let v95 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v90, v91) v94 
                let _run_target_args'_v93 = v95 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v96 : string = "$0.map_err(|x| $1(x))"
                let v97 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v90, v91) v96 
                let _run_target_args'_v93 = v97 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v98 : string = "$0.map_err(|x| $1(x))"
                let v99 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v90, v91) v98 
                let _run_target_args'_v93 = v99 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v100 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v100 
                #endif
#if FABLE_COMPILER_PYTHON
                let v101 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v101 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v102 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v102 
                #endif
#else
                let v103 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v103 
                #endif
                let v104 : Result<std_path_PathBuf, string> = _run_target_args'_v93 
                let v107 : (std_path_PathBuf -> US14) = method113()
                let v108 : (string -> US14) = method114()
                let v110 : US14 = match v104 with Ok x -> v107 x | Error x -> v108 x
                match v110 with
                | US14_1(v266) -> (* Error *)
                    let v267 : string = $"file_system.read_link / "
                    let v268 : string = $"error': {v266} / error: {v28} / name: {v4}"
                    let v269 : string = v267 + v268 
                    (* run_target_args'
                    let v274 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v275 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v276 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v269 v275 
                    let _run_target_args'_v274 = v276 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v277 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v278 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v269 v277 
                    let _run_target_args'_v274 = v278 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v279 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v280 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v269 v279 
                    let _run_target_args'_v274 = v280 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v282 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v282 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v286 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v286 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v290 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v290 
                    #endif
#else
                    let v294 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v294 
                    #endif
                    let v297 : std_io_Error = _run_target_args'_v274 
                    (* run_target_args'
                    let v304 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v305 : string = "Err($0)"
                    let v306 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v297 v305 
                    let _run_target_args'_v304 = v306 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v307 : string = "Err($0)"
                    let v308 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v297 v307 
                    let _run_target_args'_v304 = v308 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v309 : string = "Err($0)"
                    let v310 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v297 v309 
                    let _run_target_args'_v304 = v310 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v311 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v311 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v312 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v312 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v313 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v313 
                    #endif
#else
                    let v314 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v314 
                    #endif
                    let v315 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v304 
                    v315
                | US14_0(v113) -> (* Ok *)
                    (* run_target_args'
                    let v118 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v119 : string = "$0.display()"
                    let v120 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v113 v119 
                    let _run_target_args'_v118 = v120 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v121 : string = "$0.display()"
                    let v122 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v113 v121 
                    let _run_target_args'_v118 = v122 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v123 : string = "$0.display()"
                    let v124 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v113 v123 
                    let _run_target_args'_v118 = v124 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v126 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v126 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v130 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v130 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v134 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v134 
                    #endif
#else
                    let v138 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v138 
                    #endif
                    let v141 : std_path_Display = _run_target_args'_v118 
                    let v148 : string = v141 |> string 
                    let v151 : string = method90(v148, v4)
                    (* run_target_args'
                    let v156 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v157 : string = "&*$0"
                    let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v151 v157 
                    let _run_target_args'_v156 = v158 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v159 : string = "&*$0"
                    let v160 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v151 v159 
                    let _run_target_args'_v156 = v160 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v161 : string = "&*$0"
                    let v162 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v151 v161 
                    let _run_target_args'_v156 = v162 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v164 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v164 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v168 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v168 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v172 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v172 
                    #endif
#else
                    let v176 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v176 
                    #endif
                    let v179 : Ref<Str> = _run_target_args'_v156 
                    (* run_target_args'
                    let v189 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v190 : string = "String::from($0)"
                    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v179 v190 
                    let _run_target_args'_v189 = v191 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v192 : string = "String::from($0)"
                    let v193 : std_string_String = Fable.Core.RustInterop.emitRustExpr v179 v192 
                    let _run_target_args'_v189 = v193 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v194 : string = "String::from($0)"
                    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v179 v194 
                    let _run_target_args'_v189 = v195 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v197 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v197 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v201 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v201 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v205 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v205 
                    #endif
#else
                    let v209 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v209 
                    #endif
                    let v212 : std_string_String = _run_target_args'_v189 
                    (* run_target_args'
                    let v222 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v223 : string = "std::path::PathBuf::from($0)"
                    let v224 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v212 v223 
                    let _run_target_args'_v222 = v224 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v225 : string = "std::path::PathBuf::from($0)"
                    let v226 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v212 v225 
                    let _run_target_args'_v222 = v226 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v227 : string = "std::path::PathBuf::from($0)"
                    let v228 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v212 v227 
                    let _run_target_args'_v222 = v228 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v230 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v230 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v234 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v234 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v238 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v238 
                    #endif
#else
                    let v242 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v242 
                    #endif
                    let v245 : std_path_PathBuf = _run_target_args'_v222 
                    (* run_target_args'
                    let v252 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v253 : string = "Ok($0)"
                    let v254 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v245 v253 
                    let _run_target_args'_v252 = v254 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v255 : string = "Ok($0)"
                    let v256 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v245 v255 
                    let _run_target_args'_v252 = v256 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v257 : string = "Ok($0)"
                    let v258 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v245 v257 
                    let _run_target_args'_v252 = v258 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v259 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v259 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v260 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v260 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v261 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v261 
                    #endif
#else
                    let v262 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v262 
                    #endif
                    let v263 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v252 
                    v263
            else
                let v320 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v321 : string = $"path: {v0} / error: {v28} / path': {v0} / name: {v4}"
                let v322 : string = v320 + v321 
                (* run_target_args'
                let v327 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v328 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v329 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v322 v328 
                let _run_target_args'_v327 = v329 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v330 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v331 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v322 v330 
                let _run_target_args'_v327 = v331 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v332 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v333 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v322 v332 
                let _run_target_args'_v327 = v333 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v335 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v335 
                #endif
#if FABLE_COMPILER_PYTHON
                let v339 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v339 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v343 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v343 
                #endif
#else
                let v347 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v347 
                #endif
                let v350 : std_io_Error = _run_target_args'_v327 
                (* run_target_args'
                let v357 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v358 : string = "Err($0)"
                let v359 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v350 v358 
                let _run_target_args'_v357 = v359 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v360 : string = "Err($0)"
                let v361 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v350 v360 
                let _run_target_args'_v357 = v361 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v362 : string = "Err($0)"
                let v363 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v350 v362 
                let _run_target_args'_v357 = v363 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v364 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v364 
                #endif
#if FABLE_COMPILER_PYTHON
                let v365 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v365 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v366 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v366 
                #endif
#else
                let v367 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v367 
                #endif
                let v368 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v357 
                v368
        | _ ->
            let v372 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v373 : string = $"path: {v0} / error: {v28} / path': {v0} / name: {v4}"
            let v374 : string = v372 + v373 
            (* run_target_args'
            let v379 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v380 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v381 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v374 v380 
            let _run_target_args'_v379 = v381 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v382 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v383 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v374 v382 
            let _run_target_args'_v379 = v383 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v384 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v385 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v374 v384 
            let _run_target_args'_v379 = v385 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v387 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v387 
            #endif
#if FABLE_COMPILER_PYTHON
            let v391 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v391 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v395 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v395 
            #endif
#else
            let v399 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v399 
            #endif
            let v402 : std_io_Error = _run_target_args'_v379 
            (* run_target_args'
            let v409 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v410 : string = "Err($0)"
            let v411 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v402 v410 
            let _run_target_args'_v409 = v411 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v412 : string = "Err($0)"
            let v413 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v402 v412 
            let _run_target_args'_v409 = v413 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v414 : string = "Err($0)"
            let v415 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v402 v414 
            let _run_target_args'_v409 = v415 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v416 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v416 
            #endif
#if FABLE_COMPILER_PYTHON
            let v417 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v417 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v418 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v418 
            #endif
#else
            let v419 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v419 
            #endif
            let v420 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v409 
            v420
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
    let v28 : US14 = match v22 with Ok x -> v25 x | Error x -> v26 x
    let v51 : Result<std_path_PathBuf, std_io_Error> =
        match v28 with
        | US14_1(v47) -> (* Error *)
            let v48 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method119(v0, v48, v1, v47)
        | US14_0(v31) -> (* Ok *)
            (* run_target_args'
            let v33 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v34 : string = "Ok($0)"
            let v35 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v31 v34 
            let _run_target_args'_v33 = v35 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v36 : string = "Ok($0)"
            let v37 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v31 v36 
            let _run_target_args'_v33 = v37 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v38 : string = "Ok($0)"
            let v39 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v31 v38 
            let _run_target_args'_v33 = v39 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v40 : Result<std_path_PathBuf, std_io_Error> = v31 |> Ok
            let _run_target_args'_v33 = v40 
            #endif
#if FABLE_COMPILER_PYTHON
            let v41 : Result<std_path_PathBuf, std_io_Error> = v31 |> Ok
            let _run_target_args'_v33 = v41 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v42 : Result<std_path_PathBuf, std_io_Error> = v31 |> Ok
            let _run_target_args'_v33 = v42 
            #endif
#else
            let v43 : Result<std_path_PathBuf, std_io_Error> = v31 |> Ok
            let _run_target_args'_v33 = v43 
            #endif
            let v44 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v33 
            v44
    let _run_target_args'_v6 = v51 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v52 : string = "std::fs::read_link(&*$0)"
    let v53 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v52 
    let v54 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v56 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v57 : string = "$0.map_err(|x| $1(x))"
    let v58 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v53, v54) v57 
    let _run_target_args'_v56 = v58 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v59 : string = "$0.map_err(|x| $1(x))"
    let v60 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v53, v54) v59 
    let _run_target_args'_v56 = v60 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v61 : string = "$0.map_err(|x| $1(x))"
    let v62 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v53, v54) v61 
    let _run_target_args'_v56 = v62 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v63 : Result<std_path_PathBuf, string> = match v53 with Ok x -> Ok x | Error x -> Error (v54 x)
    let _run_target_args'_v56 = v63 
    #endif
#if FABLE_COMPILER_PYTHON
    let v64 : Result<std_path_PathBuf, string> = match v53 with Ok x -> Ok x | Error x -> Error (v54 x)
    let _run_target_args'_v56 = v64 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v65 : Result<std_path_PathBuf, string> = match v53 with Ok x -> Ok x | Error x -> Error (v54 x)
    let _run_target_args'_v56 = v65 
    #endif
#else
    let v66 : Result<std_path_PathBuf, string> = match v53 with Ok x -> Ok x | Error x -> Error (v54 x)
    let _run_target_args'_v56 = v66 
    #endif
    let v67 : Result<std_path_PathBuf, string> = _run_target_args'_v56 
    let v70 : (std_path_PathBuf -> US14) = method113()
    let v71 : (string -> US14) = method114()
    let v73 : US14 = match v67 with Ok x -> v70 x | Error x -> v71 x
    let v96 : Result<std_path_PathBuf, std_io_Error> =
        match v73 with
        | US14_1(v92) -> (* Error *)
            let v93 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method119(v0, v93, v1, v92)
        | US14_0(v76) -> (* Ok *)
            (* run_target_args'
            let v78 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v79 : string = "Ok($0)"
            let v80 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v76 v79 
            let _run_target_args'_v78 = v80 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v81 : string = "Ok($0)"
            let v82 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v76 v81 
            let _run_target_args'_v78 = v82 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v83 : string = "Ok($0)"
            let v84 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v76 v83 
            let _run_target_args'_v78 = v84 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v85 : Result<std_path_PathBuf, std_io_Error> = v76 |> Ok
            let _run_target_args'_v78 = v85 
            #endif
#if FABLE_COMPILER_PYTHON
            let v86 : Result<std_path_PathBuf, std_io_Error> = v76 |> Ok
            let _run_target_args'_v78 = v86 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v87 : Result<std_path_PathBuf, std_io_Error> = v76 |> Ok
            let _run_target_args'_v78 = v87 
            #endif
#else
            let v88 : Result<std_path_PathBuf, std_io_Error> = v76 |> Ok
            let _run_target_args'_v78 = v88 
            #endif
            let v89 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v78 
            v89
    let _run_target_args'_v6 = v96 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v97 : string = "std::fs::read_link(&*$0)"
    let v98 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v97 
    let v99 : (std_io_Error -> string) = method48()
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "$0.map_err(|x| $1(x))"
    let v103 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v98, v99) v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "$0.map_err(|x| $1(x))"
    let v105 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v98, v99) v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "$0.map_err(|x| $1(x))"
    let v107 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v98, v99) v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v108 : Result<std_path_PathBuf, string> = match v98 with Ok x -> Ok x | Error x -> Error (v99 x)
    let _run_target_args'_v101 = v108 
    #endif
#if FABLE_COMPILER_PYTHON
    let v109 : Result<std_path_PathBuf, string> = match v98 with Ok x -> Ok x | Error x -> Error (v99 x)
    let _run_target_args'_v101 = v109 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v110 : Result<std_path_PathBuf, string> = match v98 with Ok x -> Ok x | Error x -> Error (v99 x)
    let _run_target_args'_v101 = v110 
    #endif
#else
    let v111 : Result<std_path_PathBuf, string> = match v98 with Ok x -> Ok x | Error x -> Error (v99 x)
    let _run_target_args'_v101 = v111 
    #endif
    let v112 : Result<std_path_PathBuf, string> = _run_target_args'_v101 
    let v115 : (std_path_PathBuf -> US14) = method113()
    let v116 : (string -> US14) = method114()
    let v118 : US14 = match v112 with Ok x -> v115 x | Error x -> v116 x
    let v141 : Result<std_path_PathBuf, std_io_Error> =
        match v118 with
        | US14_1(v137) -> (* Error *)
            let v138 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method119(v0, v138, v1, v137)
        | US14_0(v121) -> (* Ok *)
            (* run_target_args'
            let v123 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v124 : string = "Ok($0)"
            let v125 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v121 v124 
            let _run_target_args'_v123 = v125 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v126 : string = "Ok($0)"
            let v127 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v121 v126 
            let _run_target_args'_v123 = v127 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v128 : string = "Ok($0)"
            let v129 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v121 v128 
            let _run_target_args'_v123 = v129 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v130 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
            let _run_target_args'_v123 = v130 
            #endif
#if FABLE_COMPILER_PYTHON
            let v131 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
            let _run_target_args'_v123 = v131 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v132 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
            let _run_target_args'_v123 = v132 
            #endif
#else
            let v133 : Result<std_path_PathBuf, std_io_Error> = v121 |> Ok
            let _run_target_args'_v123 = v133 
            #endif
            let v134 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v123 
            v134
    let _run_target_args'_v6 = v141 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v143 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v143 
    #endif
#if FABLE_COMPILER_PYTHON
    let v147 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v147 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v151 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v151 
    #endif
#else
    let v155 : Result<std_path_PathBuf, std_io_Error> = null |> unbox<Result<std_path_PathBuf, std_io_Error>>
    let _run_target_args'_v6 = v155 
    #endif
    let v158 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v6 
    v158
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
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v24 : US5 = US5_1
    let v25 : US5 = v10 |> Option.defaultValue v24 
    let v29 : string = method49(v3)
    let v30 : bool = v2 >= 11uy
    if v30 then
        let v31 : string = $"file_system.read_link / "
        let v32 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v33 : string = v31 + v32 
        (* run_target_args'
        let v38 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v39 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v40 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v33 v39 
        let _run_target_args'_v38 = v40 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v41 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v42 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v33 v41 
        let _run_target_args'_v38 = v42 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v43 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v44 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v33 v43 
        let _run_target_args'_v38 = v44 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v46 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v46 
        #endif
#if FABLE_COMPILER_PYTHON
        let v50 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v50 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v54 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v54 
        #endif
#else
        let v58 : std_io_Error = v33 |> unbox<std_io_Error>
        let _run_target_args'_v38 = v58 
        #endif
        let v61 : std_io_Error = _run_target_args'_v38 
        (* run_target_args'
        let v68 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v69 : string = "Err($0)"
        let v70 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v61 v69 
        let _run_target_args'_v68 = v70 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = "Err($0)"
        let v72 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v61 v71 
        let _run_target_args'_v68 = v72 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v73 : string = "Err($0)"
        let v74 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v61 v73 
        let _run_target_args'_v68 = v74 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v75 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v75 
        #endif
#if FABLE_COMPILER_PYTHON
        let v76 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v76 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v77 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v77 
        #endif
#else
        let v78 : Result<std_path_PathBuf, std_io_Error> = v61 |> Error
        let _run_target_args'_v68 = v78 
        #endif
        let v79 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v68 
        v79
    else
        match v25 with
        | US5_0(v82) -> (* Some *)
            let v85 : string = ""
            let v86 : bool = v4 <> v85 
            if v86 then
                let v89 : uint8 = v2 + 1uy
                let v90 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v89
                let v91 : Result<std_path_PathBuf, std_io_Error> = v90 v82
                let v92 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v94 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v95 : string = "$0.map_err(|x| $1(x))"
                let v96 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v91, v92) v95 
                let _run_target_args'_v94 = v96 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v97 : string = "$0.map_err(|x| $1(x))"
                let v98 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v91, v92) v97 
                let _run_target_args'_v94 = v98 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v99 : string = "$0.map_err(|x| $1(x))"
                let v100 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v91, v92) v99 
                let _run_target_args'_v94 = v100 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v101 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v101 
                #endif
#if FABLE_COMPILER_PYTHON
                let v102 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v102 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v103 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v103 
                #endif
#else
                let v104 : Result<std_path_PathBuf, string> = match v91 with Ok x -> Ok x | Error x -> Error (v92 x)
                let _run_target_args'_v94 = v104 
                #endif
                let v105 : Result<std_path_PathBuf, string> = _run_target_args'_v94 
                let v108 : (std_path_PathBuf -> US14) = method113()
                let v109 : (string -> US14) = method114()
                let v111 : US14 = match v105 with Ok x -> v108 x | Error x -> v109 x
                match v111 with
                | US14_1(v267) -> (* Error *)
                    let v268 : string = $"file_system.read_link / "
                    let v269 : string = $"error': {v267} / error: {v29} / name: {v5}"
                    let v270 : string = v268 + v269 
                    (* run_target_args'
                    let v275 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v276 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v277 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v270 v276 
                    let _run_target_args'_v275 = v277 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v278 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v279 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v270 v278 
                    let _run_target_args'_v275 = v279 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v280 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v281 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v270 v280 
                    let _run_target_args'_v275 = v281 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v283 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v283 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v287 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v287 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v291 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v291 
                    #endif
#else
                    let v295 : std_io_Error = v270 |> unbox<std_io_Error>
                    let _run_target_args'_v275 = v295 
                    #endif
                    let v298 : std_io_Error = _run_target_args'_v275 
                    (* run_target_args'
                    let v305 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v306 : string = "Err($0)"
                    let v307 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v298 v306 
                    let _run_target_args'_v305 = v307 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v308 : string = "Err($0)"
                    let v309 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v298 v308 
                    let _run_target_args'_v305 = v309 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v310 : string = "Err($0)"
                    let v311 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v298 v310 
                    let _run_target_args'_v305 = v311 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v312 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v312 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v313 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v313 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v314 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v314 
                    #endif
#else
                    let v315 : Result<std_path_PathBuf, std_io_Error> = v298 |> Error
                    let _run_target_args'_v305 = v315 
                    #endif
                    let v316 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v305 
                    v316
                | US14_0(v114) -> (* Ok *)
                    (* run_target_args'
                    let v119 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v120 : string = "$0.display()"
                    let v121 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v114 v120 
                    let _run_target_args'_v119 = v121 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v122 : string = "$0.display()"
                    let v123 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v114 v122 
                    let _run_target_args'_v119 = v123 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v124 : string = "$0.display()"
                    let v125 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v114 v124 
                    let _run_target_args'_v119 = v125 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v127 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v127 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v131 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v131 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v135 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v135 
                    #endif
#else
                    let v139 : std_path_Display = v114 |> unbox<std_path_Display>
                    let _run_target_args'_v119 = v139 
                    #endif
                    let v142 : std_path_Display = _run_target_args'_v119 
                    let v149 : string = v142 |> string 
                    let v152 : string = method90(v149, v5)
                    (* run_target_args'
                    let v157 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v158 : string = "&*$0"
                    let v159 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v152 v158 
                    let _run_target_args'_v157 = v159 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v160 : string = "&*$0"
                    let v161 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v152 v160 
                    let _run_target_args'_v157 = v161 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v162 : string = "&*$0"
                    let v163 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v152 v162 
                    let _run_target_args'_v157 = v163 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v165 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v165 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v169 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v169 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v173 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v173 
                    #endif
#else
                    let v177 : Ref<Str> = v152 |> unbox<Ref<Str>>
                    let _run_target_args'_v157 = v177 
                    #endif
                    let v180 : Ref<Str> = _run_target_args'_v157 
                    (* run_target_args'
                    let v190 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v191 : string = "String::from($0)"
                    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v180 v191 
                    let _run_target_args'_v190 = v192 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v193 : string = "String::from($0)"
                    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v180 v193 
                    let _run_target_args'_v190 = v194 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v195 : string = "String::from($0)"
                    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v180 v195 
                    let _run_target_args'_v190 = v196 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v198 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v198 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v202 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v202 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v206 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v206 
                    #endif
#else
                    let v210 : std_string_String = v180 |> unbox<std_string_String>
                    let _run_target_args'_v190 = v210 
                    #endif
                    let v213 : std_string_String = _run_target_args'_v190 
                    (* run_target_args'
                    let v223 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v224 : string = "std::path::PathBuf::from($0)"
                    let v225 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v224 
                    let _run_target_args'_v223 = v225 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v226 : string = "std::path::PathBuf::from($0)"
                    let v227 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v226 
                    let _run_target_args'_v223 = v227 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v228 : string = "std::path::PathBuf::from($0)"
                    let v229 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v228 
                    let _run_target_args'_v223 = v229 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v231 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v231 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v235 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v235 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v239 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v239 
                    #endif
#else
                    let v243 : std_path_PathBuf = v213 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v223 = v243 
                    #endif
                    let v246 : std_path_PathBuf = _run_target_args'_v223 
                    (* run_target_args'
                    let v253 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v254 : string = "Ok($0)"
                    let v255 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v246 v254 
                    let _run_target_args'_v253 = v255 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v256 : string = "Ok($0)"
                    let v257 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v246 v256 
                    let _run_target_args'_v253 = v257 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v258 : string = "Ok($0)"
                    let v259 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v246 v258 
                    let _run_target_args'_v253 = v259 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v260 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v260 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v261 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v261 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v262 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v262 
                    #endif
#else
                    let v263 : Result<std_path_PathBuf, std_io_Error> = v246 |> Ok
                    let _run_target_args'_v253 = v263 
                    #endif
                    let v264 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v253 
                    v264
            else
                let v321 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v322 : string = $"path: {v0} / error: {v29} / path': {v4} / name: {v5}"
                let v323 : string = v321 + v322 
                (* run_target_args'
                let v328 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v329 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v330 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v323 v329 
                let _run_target_args'_v328 = v330 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v331 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v332 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v323 v331 
                let _run_target_args'_v328 = v332 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v333 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v334 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v323 v333 
                let _run_target_args'_v328 = v334 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v336 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v336 
                #endif
#if FABLE_COMPILER_PYTHON
                let v340 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v340 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v344 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v344 
                #endif
#else
                let v348 : std_io_Error = v323 |> unbox<std_io_Error>
                let _run_target_args'_v328 = v348 
                #endif
                let v351 : std_io_Error = _run_target_args'_v328 
                (* run_target_args'
                let v358 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v359 : string = "Err($0)"
                let v360 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v351 v359 
                let _run_target_args'_v358 = v360 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v361 : string = "Err($0)"
                let v362 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v351 v361 
                let _run_target_args'_v358 = v362 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v363 : string = "Err($0)"
                let v364 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v351 v363 
                let _run_target_args'_v358 = v364 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v365 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v365 
                #endif
#if FABLE_COMPILER_PYTHON
                let v366 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v366 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v367 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v367 
                #endif
#else
                let v368 : Result<std_path_PathBuf, std_io_Error> = v351 |> Error
                let _run_target_args'_v358 = v368 
                #endif
                let v369 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v358 
                v369
        | _ ->
            let v373 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v374 : string = $"path: {v0} / error: {v29} / path': {v4} / name: {v5}"
            let v375 : string = v373 + v374 
            (* run_target_args'
            let v380 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v381 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v382 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v375 v381 
            let _run_target_args'_v380 = v382 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v383 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v384 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v375 v383 
            let _run_target_args'_v380 = v384 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v385 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v386 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v375 v385 
            let _run_target_args'_v380 = v386 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v388 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v388 
            #endif
#if FABLE_COMPILER_PYTHON
            let v392 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v392 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v396 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v396 
            #endif
#else
            let v400 : std_io_Error = v375 |> unbox<std_io_Error>
            let _run_target_args'_v380 = v400 
            #endif
            let v403 : std_io_Error = _run_target_args'_v380 
            (* run_target_args'
            let v410 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v411 : string = "Err($0)"
            let v412 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v403 v411 
            let _run_target_args'_v410 = v412 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v413 : string = "Err($0)"
            let v414 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v403 v413 
            let _run_target_args'_v410 = v414 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v415 : string = "Err($0)"
            let v416 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v403 v415 
            let _run_target_args'_v410 = v416 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v417 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v417 
            #endif
#if FABLE_COMPILER_PYTHON
            let v418 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v418 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v419 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v419 
            #endif
#else
            let v420 : Result<std_path_PathBuf, std_io_Error> = v403 |> Error
            let _run_target_args'_v410 = v420 
            #endif
            let v421 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v410 
            v421
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
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v23 : US5 = US5_1
    let v24 : US5 = v9 |> Option.defaultValue v23 
    let v28 : string = method49(v3)
    let v29 : bool = v2 >= 11uy
    if v29 then
        let v30 : string = $"file_system.read_link / "
        let v31 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v32 : string = v30 + v31 
        (* run_target_args'
        let v37 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v38 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v39 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v32 v38 
        let _run_target_args'_v37 = v39 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v40 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v41 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v32 v40 
        let _run_target_args'_v37 = v41 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v42 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v43 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v32 v42 
        let _run_target_args'_v37 = v43 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v45 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v45 
        #endif
#if FABLE_COMPILER_PYTHON
        let v49 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v49 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v53 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v53 
        #endif
#else
        let v57 : std_io_Error = v32 |> unbox<std_io_Error>
        let _run_target_args'_v37 = v57 
        #endif
        let v60 : std_io_Error = _run_target_args'_v37 
        (* run_target_args'
        let v67 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v68 : string = "Err($0)"
        let v69 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v60 v68 
        let _run_target_args'_v67 = v69 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v70 : string = "Err($0)"
        let v71 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v60 v70 
        let _run_target_args'_v67 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v72 : string = "Err($0)"
        let v73 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v60 v72 
        let _run_target_args'_v67 = v73 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v74 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v74 
        #endif
#if FABLE_COMPILER_PYTHON
        let v75 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v75 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v76 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v76 
        #endif
#else
        let v77 : Result<std_path_PathBuf, std_io_Error> = v60 |> Error
        let _run_target_args'_v67 = v77 
        #endif
        let v78 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v67 
        v78
    else
        match v24 with
        | US5_0(v81) -> (* Some *)
            let v84 : string = ""
            let v85 : bool = v0 <> v84 
            if v85 then
                let v88 : uint8 = v2 + 1uy
                let v89 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v88
                let v90 : Result<std_path_PathBuf, std_io_Error> = v89 v81
                let v91 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v93 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v94 : string = "$0.map_err(|x| $1(x))"
                let v95 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v90, v91) v94 
                let _run_target_args'_v93 = v95 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v96 : string = "$0.map_err(|x| $1(x))"
                let v97 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v90, v91) v96 
                let _run_target_args'_v93 = v97 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v98 : string = "$0.map_err(|x| $1(x))"
                let v99 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v90, v91) v98 
                let _run_target_args'_v93 = v99 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v100 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v100 
                #endif
#if FABLE_COMPILER_PYTHON
                let v101 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v101 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v102 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v102 
                #endif
#else
                let v103 : Result<std_path_PathBuf, string> = match v90 with Ok x -> Ok x | Error x -> Error (v91 x)
                let _run_target_args'_v93 = v103 
                #endif
                let v104 : Result<std_path_PathBuf, string> = _run_target_args'_v93 
                let v107 : (std_path_PathBuf -> US14) = method113()
                let v108 : (string -> US14) = method114()
                let v110 : US14 = match v104 with Ok x -> v107 x | Error x -> v108 x
                match v110 with
                | US14_1(v266) -> (* Error *)
                    let v267 : string = $"file_system.read_link / "
                    let v268 : string = $"error': {v266} / error: {v28} / name: {v4}"
                    let v269 : string = v267 + v268 
                    (* run_target_args'
                    let v274 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v275 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v276 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v269 v275 
                    let _run_target_args'_v274 = v276 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v277 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v278 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v269 v277 
                    let _run_target_args'_v274 = v278 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v279 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v280 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v269 v279 
                    let _run_target_args'_v274 = v280 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v282 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v282 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v286 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v286 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v290 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v290 
                    #endif
#else
                    let v294 : std_io_Error = v269 |> unbox<std_io_Error>
                    let _run_target_args'_v274 = v294 
                    #endif
                    let v297 : std_io_Error = _run_target_args'_v274 
                    (* run_target_args'
                    let v304 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v305 : string = "Err($0)"
                    let v306 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v297 v305 
                    let _run_target_args'_v304 = v306 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v307 : string = "Err($0)"
                    let v308 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v297 v307 
                    let _run_target_args'_v304 = v308 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v309 : string = "Err($0)"
                    let v310 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v297 v309 
                    let _run_target_args'_v304 = v310 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v311 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v311 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v312 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v312 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v313 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v313 
                    #endif
#else
                    let v314 : Result<std_path_PathBuf, std_io_Error> = v297 |> Error
                    let _run_target_args'_v304 = v314 
                    #endif
                    let v315 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v304 
                    v315
                | US14_0(v113) -> (* Ok *)
                    (* run_target_args'
                    let v118 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v119 : string = "$0.display()"
                    let v120 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v113 v119 
                    let _run_target_args'_v118 = v120 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v121 : string = "$0.display()"
                    let v122 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v113 v121 
                    let _run_target_args'_v118 = v122 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v123 : string = "$0.display()"
                    let v124 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v113 v123 
                    let _run_target_args'_v118 = v124 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v126 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v126 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v130 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v130 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v134 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v134 
                    #endif
#else
                    let v138 : std_path_Display = v113 |> unbox<std_path_Display>
                    let _run_target_args'_v118 = v138 
                    #endif
                    let v141 : std_path_Display = _run_target_args'_v118 
                    let v148 : string = v141 |> string 
                    let v151 : string = method90(v148, v4)
                    (* run_target_args'
                    let v156 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v157 : string = "&*$0"
                    let v158 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v151 v157 
                    let _run_target_args'_v156 = v158 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v159 : string = "&*$0"
                    let v160 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v151 v159 
                    let _run_target_args'_v156 = v160 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v161 : string = "&*$0"
                    let v162 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v151 v161 
                    let _run_target_args'_v156 = v162 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v164 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v164 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v168 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v168 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v172 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v172 
                    #endif
#else
                    let v176 : Ref<Str> = v151 |> unbox<Ref<Str>>
                    let _run_target_args'_v156 = v176 
                    #endif
                    let v179 : Ref<Str> = _run_target_args'_v156 
                    (* run_target_args'
                    let v189 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v190 : string = "String::from($0)"
                    let v191 : std_string_String = Fable.Core.RustInterop.emitRustExpr v179 v190 
                    let _run_target_args'_v189 = v191 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v192 : string = "String::from($0)"
                    let v193 : std_string_String = Fable.Core.RustInterop.emitRustExpr v179 v192 
                    let _run_target_args'_v189 = v193 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v194 : string = "String::from($0)"
                    let v195 : std_string_String = Fable.Core.RustInterop.emitRustExpr v179 v194 
                    let _run_target_args'_v189 = v195 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v197 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v197 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v201 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v201 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v205 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v205 
                    #endif
#else
                    let v209 : std_string_String = v179 |> unbox<std_string_String>
                    let _run_target_args'_v189 = v209 
                    #endif
                    let v212 : std_string_String = _run_target_args'_v189 
                    (* run_target_args'
                    let v222 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v223 : string = "std::path::PathBuf::from($0)"
                    let v224 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v212 v223 
                    let _run_target_args'_v222 = v224 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v225 : string = "std::path::PathBuf::from($0)"
                    let v226 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v212 v225 
                    let _run_target_args'_v222 = v226 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v227 : string = "std::path::PathBuf::from($0)"
                    let v228 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v212 v227 
                    let _run_target_args'_v222 = v228 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v230 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v230 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v234 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v234 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v238 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v238 
                    #endif
#else
                    let v242 : std_path_PathBuf = v212 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v222 = v242 
                    #endif
                    let v245 : std_path_PathBuf = _run_target_args'_v222 
                    (* run_target_args'
                    let v252 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v253 : string = "Ok($0)"
                    let v254 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v245 v253 
                    let _run_target_args'_v252 = v254 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v255 : string = "Ok($0)"
                    let v256 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v245 v255 
                    let _run_target_args'_v252 = v256 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v257 : string = "Ok($0)"
                    let v258 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v245 v257 
                    let _run_target_args'_v252 = v258 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v259 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v259 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v260 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v260 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v261 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v261 
                    #endif
#else
                    let v262 : Result<std_path_PathBuf, std_io_Error> = v245 |> Ok
                    let _run_target_args'_v252 = v262 
                    #endif
                    let v263 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v252 
                    v263
            else
                let v320 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v321 : string = $"path: {v0} / error: {v28} / path': {v0} / name: {v4}"
                let v322 : string = v320 + v321 
                (* run_target_args'
                let v327 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v328 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v329 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v322 v328 
                let _run_target_args'_v327 = v329 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v330 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v331 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v322 v330 
                let _run_target_args'_v327 = v331 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v332 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v333 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v322 v332 
                let _run_target_args'_v327 = v333 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v335 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v335 
                #endif
#if FABLE_COMPILER_PYTHON
                let v339 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v339 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v343 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v343 
                #endif
#else
                let v347 : std_io_Error = v322 |> unbox<std_io_Error>
                let _run_target_args'_v327 = v347 
                #endif
                let v350 : std_io_Error = _run_target_args'_v327 
                (* run_target_args'
                let v357 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v358 : string = "Err($0)"
                let v359 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v350 v358 
                let _run_target_args'_v357 = v359 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v360 : string = "Err($0)"
                let v361 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v350 v360 
                let _run_target_args'_v357 = v361 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v362 : string = "Err($0)"
                let v363 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v350 v362 
                let _run_target_args'_v357 = v363 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v364 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v364 
                #endif
#if FABLE_COMPILER_PYTHON
                let v365 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v365 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v366 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v366 
                #endif
#else
                let v367 : Result<std_path_PathBuf, std_io_Error> = v350 |> Error
                let _run_target_args'_v357 = v367 
                #endif
                let v368 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v357 
                v368
        | _ ->
            let v372 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v373 : string = $"path: {v0} / error: {v28} / path': {v0} / name: {v4}"
            let v374 : string = v372 + v373 
            (* run_target_args'
            let v379 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v380 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v381 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v374 v380 
            let _run_target_args'_v379 = v381 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v382 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v383 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v374 v382 
            let _run_target_args'_v379 = v383 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v384 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v385 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v374 v384 
            let _run_target_args'_v379 = v385 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v387 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v387 
            #endif
#if FABLE_COMPILER_PYTHON
            let v391 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v391 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v395 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v395 
            #endif
#else
            let v399 : std_io_Error = v374 |> unbox<std_io_Error>
            let _run_target_args'_v379 = v399 
            #endif
            let v402 : std_io_Error = _run_target_args'_v379 
            (* run_target_args'
            let v409 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v410 : string = "Err($0)"
            let v411 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v402 v410 
            let _run_target_args'_v409 = v411 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v412 : string = "Err($0)"
            let v413 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v402 v412 
            let _run_target_args'_v409 = v413 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v414 : string = "Err($0)"
            let v415 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v402 v414 
            let _run_target_args'_v409 = v415 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v416 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v416 
            #endif
#if FABLE_COMPILER_PYTHON
            let v417 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v417 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v418 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v418 
            #endif
#else
            let v419 : Result<std_path_PathBuf, std_io_Error> = v402 |> Error
            let _run_target_args'_v409 = v419 
            #endif
            let v420 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v409 
            v420
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
        let v21 : (std_path_PathBuf -> US15) = method127()
        let v22 : US15 option = v16 |> Option.map v21 
        let v36 : US15 = US15_1
        let v37 : US15 = v22 |> Option.defaultValue v36 
        let v80 : string =
            match v37 with
            | US15_1 -> (* None *)
                v0
            | US15_0(v41) -> (* Some *)
                (* run_target_args'
                let v46 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v47 : string = "$0.display()"
                let v48 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v41 v47 
                let _run_target_args'_v46 = v48 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v49 : string = "$0.display()"
                let v50 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v41 v49 
                let _run_target_args'_v46 = v50 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v51 : string = "$0.display()"
                let v52 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v41 v51 
                let _run_target_args'_v46 = v52 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v54 : std_path_Display = v41 |> unbox<std_path_Display>
                let _run_target_args'_v46 = v54 
                #endif
#if FABLE_COMPILER_PYTHON
                let v58 : std_path_Display = v41 |> unbox<std_path_Display>
                let _run_target_args'_v46 = v58 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v62 : std_path_Display = v41 |> unbox<std_path_Display>
                let _run_target_args'_v46 = v62 
                #endif
#else
                let v66 : std_path_Display = v41 |> unbox<std_path_Display>
                let _run_target_args'_v46 = v66 
                #endif
                let v69 : std_path_Display = _run_target_args'_v46 
                let v76 : string = v69 |> string 
                v76
        let v81 : bool = v80 = ""
        let v82 : string =
            if v81 then
                v0
            else
                v80
        let v83 : string = "^\\\\\\\\\\?\\\\"
        let v84 : string = ""
        let v85 : string = method128(v83, v84, v82)
        let v86 : int32 = v85.Length
        let v87 : bool = v86 < 2
        if v87 then
            v0
        else
            let v88 : string = $"{v85.[0] |> string |> _.ToLower()}{v85.[1..]}"
            let v89 : string = "\\"
            let v90 : string = "/"
            let v91 : string = v88.Replace (v89, v90)
            v91
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
    let v42 : string = $"file:///{v12}"
    v42
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
        let v11 : (string -> US5) = method5()
        let v12 : US5 option = v8 |> Option.map v11 
        let v26 : US5 = US5_1
        let v27 : US5 = v12 |> Option.defaultValue v26 
        match v27 with
        | US5_1 -> (* None *)
            let v33 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v34 : string = $" '{v0}' at '{v1}' (until '{v4}')"
            let v35 : string = v33 + v34 
            US17_1(v35)
        | US5_0(v31) -> (* Some *)
            method141(v0, v1, v2, v3, v31)
and method140 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool)) : US17 =
    let v4 : string = method90(v1, v0)
    let v5 : bool = v3 v4
    if v5 then
        US17_0(v1)
    else
        let v7 : string option = method117(v1)
        let v10 : (string -> US5) = method5()
        let v11 : US5 option = v7 |> Option.map v10 
        let v25 : US5 = US5_1
        let v26 : US5 = v11 |> Option.defaultValue v25 
        match v26 with
        | US5_1 -> (* None *)
            let v32 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v33 : string = $" '{v0}' at '{v1}' (until '{v1}')"
            let v34 : string = v32 + v33 
            US17_1(v34)
        | US5_0(v30) -> (* Some *)
            method141(v0, v1, v2, v3, v30)
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
    let v8 : string = ""
    let v9 : string = v5 |> Option.defaultValue v8 
    let v12 : bool = method10(v9)
    let v13 : bool = v12 = false
    if v13 then
        let v14 : System.IDisposable = method93(v9)
        ()
    let v15 : bool = method10(v1)
    let v26 : bool =
        if v15 then
            let v16 : Result<std_path_PathBuf, std_io_Error> = method111(v1)
            (* run_target_args'
            let v17 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v18 : string = "$0.is_err()"
            let v19 : bool = Fable.Core.RustInterop.emitRustExpr v16 v18 
            let _run_target_args'_v17 = v19 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v20 : string = "$0.is_err()"
            let v21 : bool = Fable.Core.RustInterop.emitRustExpr v16 v20 
            let _run_target_args'_v17 = v21 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v22 : string = "$0.is_err()"
            let v23 : bool = Fable.Core.RustInterop.emitRustExpr v16 v22 
            let _run_target_args'_v17 = v23 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let _run_target_args'_v17 = true 
            #endif
#if FABLE_COMPILER_PYTHON
            let _run_target_args'_v17 = true 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let _run_target_args'_v17 = true 
            #endif
#else
            let _run_target_args'_v17 = true 
            #endif
            let v24 : bool = _run_target_args'_v17 
            v24
        else
            false
    if v26 then
        let v27 : bool = true
        method9(v27, v1)
    let v28 : bool = method10(v1)
    let v29 : bool = v28 = false
    if v29 then
        (* run_target_args'
        let v30 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v31 : string = "true; #[cfg(windows)] std::os::windows::fs::symlink_dir(&*$0, &*$1).unwrap()"
        let v32 : bool = Fable.Core.RustInterop.emitRustExpr struct (v0, v1) v31 
        let v33 : string = "true; #[cfg(unix)] std::os::unix::fs::symlink(&*$0, &*$1).unwrap()"
        let v34 : bool = Fable.Core.RustInterop.emitRustExpr struct (v0, v1) v33 
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
        let v35 : System.IO.FileSystemInfo = System.IO.Directory.CreateSymbolicLink (v1, v0)
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
