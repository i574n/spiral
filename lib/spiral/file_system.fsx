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
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure0()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
    let v44 : US0 = v30.l0
    let v45 : bool = v28.l0
    let v46 : bool = v45 = false
    if v46 then
        false
    else
        let v47 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
        let v48 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v44
        let v49 : bool = v47 >= v48
        v49
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
    let v173 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v176 : (int64 -> US2) = method13()
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
    let v318 : string = method14()
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
    let v343 : (int64 -> US2) = method13()
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
    let v485 : string = method14()
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
    let v512 : (int64 -> US2) = method13()
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
    let v559 : (int64 -> US2) = method13()
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
    let v701 : string = method15()
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
    let v726 : (int64 -> US2) = method13()
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
    let v868 : string = method15()
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
    let v893 : (int64 -> US2) = method13()
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
    let v1035 : string = method15()
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
    let v1060 : (int64 -> US2) = method13()
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
    let v1202 : string = method15()
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
    
    
    
    
    
    let v2 : string = "Debug"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17(v7)
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
    let v138 : string = method19()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[94m"
    let v142 : string = method19()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[94m"
    let v146 : string = method19()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[94m"
    let v150 : string = method19()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
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
    let v179 : US5 = US5_1
    let v180 : US5 = v159 |> Option.defaultValue v179 
    let v187 : string =
        match v180 with
        | US5_1 -> (* None *)
            let v185 : string = ""
            v185
        | US5_0(v184) -> (* Some *)
            v184
    let _run_target_args'_v5 = v187 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v188 : US3 = US3_1
    let v189 : US4 = US4_3(v188)
    let v190 : string = $"file_system.get_file_name / target: {v189} / path: {v0}"
    let v191 : string = failwith<string> v190
    let _run_target_args'_v5 = v191 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v193 : string = null |> unbox<string>
    let _run_target_args'_v5 = v193 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v196 : string = "path"
    let v197 : IPathBasename = Fable.Core.JsInterop.importAll v196 
    let v198 : string = "v197.basename($0)"
    let v199 : string = Fable.Core.JsInterop.emitJsExpr v0 v198 
    let _run_target_args'_v5 = v199 
    #endif
#if FABLE_COMPILER_PYTHON
    let v200 : US3 = US3_0
    let v201 : US4 = US4_5(v200)
    let v202 : string = $"file_system.get_file_name / target: {v201} / path: {v0}"
    let v203 : string = failwith<string> v202
    let _run_target_args'_v5 = v203 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : US3 = US3_1
    let v205 : US4 = US4_1(v204)
    let v206 : string = $"file_system.get_file_name / target: {v205} / path: {v0}"
    let v207 : string = failwith<string> v206
    let _run_target_args'_v5 = v207 
    #endif
#else
    let v208 : (string -> string) = System.IO.Path.GetFileName
    let v209 : string = v208 v0
    let _run_target_args'_v5 = v209 
    #endif
    let v210 : string = _run_target_args'_v5 
    v210
and method22 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "ex"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "path"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
and method23 (v0 : string) : string =
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
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure0()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
    let v44 : unit = ()
    let v45 : (unit -> unit) = closure7(v26)
    let v46 : unit = (fun () -> v45 (); v44) ()
    let v49 : (string -> unit) = closure8()
    (* run_target_args'
    let v50 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v51 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v51 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v52 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = v29.l0
    let v54 : bool = v53 = ""
    let v62 : string =
        if v54 then
            v0
        else
            let v55 : bool = v0 = ""
            if v55 then
                let v56 : string = v29.l0
                v56
            else
                let v57 : string = v29.l0
                let v58 : string = "\n"
                let v59 : string = v57 + v58 
                let v60 : string = v59 + v0 
                v60
    (* run_target_args'
    let v67 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v68 : string = "&*$0"
    let v69 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v62 v68 
    let _run_target_args'_v67 = v69 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v70 : string = "&*$0"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v62 v70 
    let _run_target_args'_v67 = v71 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v72 : string = "&*$0"
    let v73 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v62 v72 
    let _run_target_args'_v67 = v73 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v75 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v75 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v79 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v83 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v83 
    #endif
#else
    let v87 : Ref<Str> = v62 |> unbox<Ref<Str>>
    let _run_target_args'_v67 = v87 
    #endif
    let v90 : Ref<Str> = _run_target_args'_v67 
    let v96 : string = $"$0.chars()"
    let v97 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v90 v96 
    let v98 : string = "$0"
    let v99 : _ = Fable.Core.RustInterop.emitRustExpr v97 v98 
    let v100 : string = "$0.collect::<Vec<_>>()"
    let v101 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v99 v100 
    let v102 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v103 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let v104 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v105 : bool = Fable.Core.RustInterop.emitRustExpr v103 v104 
    let v106 : string = "x"
    let v107 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v106 
    let v108 : string = "String::from_iter($0)"
    let v109 : std_string_String = Fable.Core.RustInterop.emitRustExpr v107 v108 
    let v110 : string = "true; $0 }).collect::<Vec<_>>()"
    let v111 : bool = Fable.Core.RustInterop.emitRustExpr v109 v110 
    let v112 : string = "_vec_map"
    let v113 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v112 
    let v114 : string = "$0.len()"
    let v115 : unativeint = Fable.Core.RustInterop.emitRustExpr v113 v114 
    let v121 : int32 = v115 |> int32 
    let v131 : string = ""
    let v132 : bool = v0 <> v131 
    let v136 : bool =
        if v132 then
            let v135 : bool = v121 <= 1
            v135
        else
            false
    if v136 then
        v29.l0 <- v62
        ()
    else
        v29.l0 <- v131
        let v137 : string = "true; $0.into_iter().for_each(|x| { //"
        let v138 : bool = Fable.Core.RustInterop.emitRustExpr v113 v137 
        let v139 : string = "x"
        let v140 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v139 
        let v141 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v142 : bool = Fable.Core.RustInterop.emitRustExpr v140 v141 
        let v143 : string = $"true"
        let v144 : bool = Fable.Core.RustInterop.emitRustExpr () v143 
        let v145 : string = "true; }); //"
        let v146 : bool = Fable.Core.RustInterop.emitRustExpr () v145 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v49 v0
    #endif
#if FABLE_COMPILER_PYTHON
    v49 v0
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v49 v0
    #endif
#else
    v49 v0
    #endif
    // run_target_args' is_unit
    let v147 : (string -> unit) = v27.l0
    v147 v0
and closure4 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method16()
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v55 : string = $"%A{v1}"
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v59 : string = $"%A{v1}"
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v63 : string = $"%A{v1}"
        let _run_target_args'_v53 = v63 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v53 = v67 
        #endif
#if FABLE_COMPILER_PYTHON
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v53 = v71 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v53 = v75 
        #endif
#else
        let v78 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v53 = v78 
        #endif
        let v79 : string = _run_target_args'_v53 
        let v85 : string = method20(v0)
        let v86 : string = method21(v29, v30, v31, v32, v33, v34, v47, v48, v79, v85)
        method24(v86)
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
                let v120 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v120 = v122 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v123 : (int32 -> Async<unit>) = Async.Sleep
                let v124 : Async<unit> = v123 10
                let _run_target_args'_v120 = v124 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v125 : (int32 -> Async<unit>) = Async.Sleep
                let v126 : Async<unit> = v125 10
                let _run_target_args'_v120 = v126 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v127 : (int32 -> Async<unit>) = Async.Sleep
                let v128 : Async<unit> = v127 10
                let _run_target_args'_v120 = v128 
                #endif
#if FABLE_COMPILER_PYTHON
                let v129 : (int32 -> Async<unit>) = Async.Sleep
                let v130 : Async<unit> = v129 10
                let _run_target_args'_v120 = v130 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v131 : (int32 -> Async<unit>) = Async.Sleep
                let v132 : Async<unit> = v131 10
                let _run_target_args'_v120 = v132 
                #endif
#else
                let v133 : (int32 -> Async<unit>) = Async.Sleep
                let v134 : Async<unit> = v133 10
                let _run_target_args'_v120 = v134 
                #endif
                let v135 : Async<unit> = _run_target_args'_v120 
                do! v135 
                let v138 : int64 = v1 + 1L
                let v139 : Async<int64> = method7(v0, v138)
                return! v139 
                (* indent
                ()
            indent *)
            (* try_unit
            let v256 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1911 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v1911 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1913 : unit = ()
    let _let'_v1913 =
        async {
            try
                let v1916 : bool = true
                method9(v1916, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v1918 : exn = ex
                let v1919 : int64 = v1 % 100L
                let v1920 : bool = v1919 = 0L
                if v1920 then
                    let v1921 : unit = ()
                    let v1922 : (unit -> unit) = closure4(v0, v1918)
                    let v1923 : unit = (fun () -> v1922 (); v1921) ()
                    ()
                (* run_target_args'
                let v2013 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2014 : (int32 -> Async<unit>) = Async.Sleep
                let v2015 : Async<unit> = v2014 10
                let _run_target_args'_v2013 = v2015 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2016 : (int32 -> Async<unit>) = Async.Sleep
                let v2017 : Async<unit> = v2016 10
                let _run_target_args'_v2013 = v2017 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2018 : (int32 -> Async<unit>) = Async.Sleep
                let v2019 : Async<unit> = v2018 10
                let _run_target_args'_v2013 = v2019 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2020 : (int32 -> Async<unit>) = Async.Sleep
                let v2021 : Async<unit> = v2020 10
                let _run_target_args'_v2013 = v2021 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2022 : (int32 -> Async<unit>) = Async.Sleep
                let v2023 : Async<unit> = v2022 10
                let _run_target_args'_v2013 = v2023 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2024 : (int32 -> Async<unit>) = Async.Sleep
                let v2025 : Async<unit> = v2024 10
                let _run_target_args'_v2013 = v2025 
                #endif
#else
                let v2026 : (int32 -> Async<unit>) = Async.Sleep
                let v2027 : Async<unit> = v2026 10
                let _run_target_args'_v2013 = v2027 
                #endif
                let v2028 : Async<unit> = _run_target_args'_v2013 
                do! v2028 
                let v2031 : int64 = v1 + 1L
                let v2032 : Async<int64> = method7(v0, v2031)
                return! v2032 
                (* indent
                ()
            indent *)
            (* try_unit
            let v2149 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3804 : Async<int64> = _let'_v1913 
    let _run_target_args'_v6 = v3804 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3806 : unit = ()
    let _let'_v3806 =
        async {
            try
                let v3809 : bool = true
                method9(v3809, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v3811 : exn = ex
                let v3812 : int64 = v1 % 100L
                let v3813 : bool = v3812 = 0L
                if v3813 then
                    let v3814 : unit = ()
                    let v3815 : (unit -> unit) = closure4(v0, v3811)
                    let v3816 : unit = (fun () -> v3815 (); v3814) ()
                    ()
                (* run_target_args'
                let v3906 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3907 : (int32 -> Async<unit>) = Async.Sleep
                let v3908 : Async<unit> = v3907 10
                let _run_target_args'_v3906 = v3908 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3909 : (int32 -> Async<unit>) = Async.Sleep
                let v3910 : Async<unit> = v3909 10
                let _run_target_args'_v3906 = v3910 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3911 : (int32 -> Async<unit>) = Async.Sleep
                let v3912 : Async<unit> = v3911 10
                let _run_target_args'_v3906 = v3912 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3913 : (int32 -> Async<unit>) = Async.Sleep
                let v3914 : Async<unit> = v3913 10
                let _run_target_args'_v3906 = v3914 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3915 : (int32 -> Async<unit>) = Async.Sleep
                let v3916 : Async<unit> = v3915 10
                let _run_target_args'_v3906 = v3916 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3917 : (int32 -> Async<unit>) = Async.Sleep
                let v3918 : Async<unit> = v3917 10
                let _run_target_args'_v3906 = v3918 
                #endif
#else
                let v3919 : (int32 -> Async<unit>) = Async.Sleep
                let v3920 : Async<unit> = v3919 10
                let _run_target_args'_v3906 = v3920 
                #endif
                let v3921 : Async<unit> = _run_target_args'_v3906 
                do! v3921 
                let v3924 : int64 = v1 + 1L
                let v3925 : Async<int64> = method7(v0, v3924)
                return! v3925 
                (* indent
                ()
            indent *)
            (* try_unit
            let v4042 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5697 : Async<int64> = _let'_v3806 
    let _run_target_args'_v6 = v5697 
    #endif
#else
    let v5699 : unit = ()
    let _let'_v5699 =
        async {
            try
                let v5702 : bool = true
                method9(v5702, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v5704 : exn = ex
                let v5705 : int64 = v1 % 100L
                let v5706 : bool = v5705 = 0L
                if v5706 then
                    let v5707 : unit = ()
                    let v5708 : (unit -> unit) = closure4(v0, v5704)
                    let v5709 : unit = (fun () -> v5708 (); v5707) ()
                    ()
                (* run_target_args'
                let v5799 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5800 : (int32 -> Async<unit>) = Async.Sleep
                let v5801 : Async<unit> = v5800 10
                let _run_target_args'_v5799 = v5801 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5802 : (int32 -> Async<unit>) = Async.Sleep
                let v5803 : Async<unit> = v5802 10
                let _run_target_args'_v5799 = v5803 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5804 : (int32 -> Async<unit>) = Async.Sleep
                let v5805 : Async<unit> = v5804 10
                let _run_target_args'_v5799 = v5805 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5806 : (int32 -> Async<unit>) = Async.Sleep
                let v5807 : Async<unit> = v5806 10
                let _run_target_args'_v5799 = v5807 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5808 : (int32 -> Async<unit>) = Async.Sleep
                let v5809 : Async<unit> = v5808 10
                let _run_target_args'_v5799 = v5809 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5810 : (int32 -> Async<unit>) = Async.Sleep
                let v5811 : Async<unit> = v5810 10
                let _run_target_args'_v5799 = v5811 
                #endif
#else
                let v5812 : (int32 -> Async<unit>) = Async.Sleep
                let v5813 : Async<unit> = v5812 10
                let _run_target_args'_v5799 = v5813 
                #endif
                let v5814 : Async<unit> = _run_target_args'_v5799 
                do! v5814 
                let v5817 : int64 = v1 + 1L
                let v5818 : Async<int64> = method7(v0, v5817)
                return! v5818 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5935 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7590 : Async<int64> = _let'_v5699 
    let _run_target_args'_v6 = v7590 
    #endif
    let v7591 : Async<int64> = _run_target_args'_v6 
    v7591
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
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure6(v4, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v18 : string = "path"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v4, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v29 : string = " = "
    let v30 : string = $"{v29}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v4, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v39 : string = $"{v0}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v4, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v49 : string = "; "
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v60 : string = "retry"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure6(v4, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v29}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure6(v4, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v79 : string = $"{v1}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure6(v4, v79)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v88 : string = $"{v49}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure6(v4, v88)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v98 : string = "ex"
    let v99 : string = $"{v98}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure6(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v108 : string = $"{v29}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v117 : string = $"{v2}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure6(v4, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure6(v4, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v4.l0
    v136
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
        let v7 : unit = ()
        let v8 : (unit -> unit) = closure0()
        let v9 : unit = (fun () -> v8 (); v7) ()
        let struct (v30 : Mut0, v31 : Mut1, v32 : Mut2, v33 : Mut3, v34 : Mut4, v35 : int64 option) = TraceState.trace_state.Value
        let v48 : string = method12(v30, v31, v32, v33, v34, v35)
        let v49 : string = method16()
        let v50 : string = method20(v0)
        (* run_target_args'
        let v55 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v57 : string = $"%A{v2}"
        let _run_target_args'_v55 = v57 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v61 : string = $"%A{v2}"
        let _run_target_args'_v55 = v61 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v65 : string = $"%A{v2}"
        let _run_target_args'_v55 = v65 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v69 : string = $"%A{v2}"
        let _run_target_args'_v55 = v69 
        #endif
#if FABLE_COMPILER_PYTHON
        let v73 : string = $"%A{v2}"
        let _run_target_args'_v55 = v73 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v77 : string = $"%A{v2}"
        let _run_target_args'_v55 = v77 
        #endif
#else
        let v80 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v55 = v80 
        #endif
        let v81 : string = _run_target_args'_v55 
        let v87 : string = method28(v30, v31, v32, v33, v34, v35, v48, v49, v50, v1, v81)
        method24(v87)
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
                let v231 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v232 : (int32 -> Async<unit>) = Async.Sleep
                let v233 : Async<unit> = v232 10
                let _run_target_args'_v231 = v233 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v234 : (int32 -> Async<unit>) = Async.Sleep
                let v235 : Async<unit> = v234 10
                let _run_target_args'_v231 = v235 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v236 : (int32 -> Async<unit>) = Async.Sleep
                let v237 : Async<unit> = v236 10
                let _run_target_args'_v231 = v237 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v238 : (int32 -> Async<unit>) = Async.Sleep
                let v239 : Async<unit> = v238 10
                let _run_target_args'_v231 = v239 
                #endif
#if FABLE_COMPILER_PYTHON
                let v240 : (int32 -> Async<unit>) = Async.Sleep
                let v241 : Async<unit> = v240 10
                let _run_target_args'_v231 = v241 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v242 : (int32 -> Async<unit>) = Async.Sleep
                let v243 : Async<unit> = v242 10
                let _run_target_args'_v231 = v243 
                #endif
#else
                let v244 : (int32 -> Async<unit>) = Async.Sleep
                let v245 : Async<unit> = v244 10
                let _run_target_args'_v231 = v245 
                #endif
                let v246 : Async<unit> = _run_target_args'_v231 
                do! v246 
                let v249 : int64 = v2 + 1L
                let v250 : Async<int64> = method26(v0, v1, v249)
                return! v250 
                (* indent
                ()
            indent *)
            (* try_unit
            let v369 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2794 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v2794 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2796 : unit = ()
    let _let'_v2796 =
        async {
            try
                (* run_target_args'
                let v2803 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2805 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2803 = v2805 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2809 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2803 = v2809 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2813 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2803 = v2813 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2817 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2803 = v2817 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2821 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2803 = v2821 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2825 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v2803 = v2825 
                #endif
#else
                let v2828 : System.IO.FileMode = System.IO.FileMode.Open
                let v2834 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v2829 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v2829
                    | US7_2 -> (* AccessReadWrite *)
                        let v2831 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v2831
                    | US7_1 -> (* AccessWrite *)
                        let v2830 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v2830
                let v2844 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v2839 : System.IO.FileShare = System.IO.FileShare.Delete
                        v2839
                    | US8_0 -> (* ShareNone *)
                        let v2835 : System.IO.FileShare = System.IO.FileShare.None
                        v2835
                    | US8_1 -> (* ShareRead *)
                        let v2836 : System.IO.FileShare = System.IO.FileShare.Read
                        v2836
                    | US8_3 -> (* ShareReadWrite *)
                        let v2838 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v2838
                    | US8_2 -> (* ShareWrite *)
                        let v2837 : System.IO.FileShare = System.IO.FileShare.Write
                        v2837
                let v2845 : System.IO.FileStream = new System.IO.FileStream (v1, v2828, v2834, v2844)
                let _run_target_args'_v2803 = v2845 
                #endif
                let v2846 : System.IO.FileStream = _run_target_args'_v2803 
                use v2846 = v2846 
                let v2852 : System.IO.FileStream = v2846 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v2907 : exn = ex
                let v2908 : bool = v2 > 0L
                let v2911 : bool =
                    if v2908 then
                        let v2909 : int64 = v2 % 100L
                        let v2910 : bool = v2909 = 0L
                        v2910
                    else
                        false
                if v2911 then
                    let v2912 : unit = ()
                    let v2913 : (unit -> unit) = closure12(v1, v2, v2907)
                    let v2914 : unit = (fun () -> v2913 (); v2912) ()
                    ()
                (* run_target_args'
                let v3004 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3005 : (int32 -> Async<unit>) = Async.Sleep
                let v3006 : Async<unit> = v3005 10
                let _run_target_args'_v3004 = v3006 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3007 : (int32 -> Async<unit>) = Async.Sleep
                let v3008 : Async<unit> = v3007 10
                let _run_target_args'_v3004 = v3008 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3009 : (int32 -> Async<unit>) = Async.Sleep
                let v3010 : Async<unit> = v3009 10
                let _run_target_args'_v3004 = v3010 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3011 : (int32 -> Async<unit>) = Async.Sleep
                let v3012 : Async<unit> = v3011 10
                let _run_target_args'_v3004 = v3012 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3013 : (int32 -> Async<unit>) = Async.Sleep
                let v3014 : Async<unit> = v3013 10
                let _run_target_args'_v3004 = v3014 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3015 : (int32 -> Async<unit>) = Async.Sleep
                let v3016 : Async<unit> = v3015 10
                let _run_target_args'_v3004 = v3016 
                #endif
#else
                let v3017 : (int32 -> Async<unit>) = Async.Sleep
                let v3018 : Async<unit> = v3017 10
                let _run_target_args'_v3004 = v3018 
                #endif
                let v3019 : Async<unit> = _run_target_args'_v3004 
                do! v3019 
                let v3022 : int64 = v2 + 1L
                let v3023 : Async<int64> = method26(v0, v1, v3022)
                return! v3023 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3142 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5567 : Async<int64> = _let'_v2796 
    let _run_target_args'_v9 = v5567 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5569 : unit = ()
    let _let'_v5569 =
        async {
            try
                (* run_target_args'
                let v5576 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5578 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5576 = v5578 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5582 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5576 = v5582 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5586 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5576 = v5586 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5590 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5576 = v5590 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5594 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5576 = v5594 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5598 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v5576 = v5598 
                #endif
#else
                let v5601 : System.IO.FileMode = System.IO.FileMode.Open
                let v5607 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v5602 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v5602
                    | US7_2 -> (* AccessReadWrite *)
                        let v5604 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v5604
                    | US7_1 -> (* AccessWrite *)
                        let v5603 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v5603
                let v5617 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v5612 : System.IO.FileShare = System.IO.FileShare.Delete
                        v5612
                    | US8_0 -> (* ShareNone *)
                        let v5608 : System.IO.FileShare = System.IO.FileShare.None
                        v5608
                    | US8_1 -> (* ShareRead *)
                        let v5609 : System.IO.FileShare = System.IO.FileShare.Read
                        v5609
                    | US8_3 -> (* ShareReadWrite *)
                        let v5611 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v5611
                    | US8_2 -> (* ShareWrite *)
                        let v5610 : System.IO.FileShare = System.IO.FileShare.Write
                        v5610
                let v5618 : System.IO.FileStream = new System.IO.FileStream (v1, v5601, v5607, v5617)
                let _run_target_args'_v5576 = v5618 
                #endif
                let v5619 : System.IO.FileStream = _run_target_args'_v5576 
                use v5619 = v5619 
                let v5625 : System.IO.FileStream = v5619 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v5680 : exn = ex
                let v5681 : bool = v2 > 0L
                let v5684 : bool =
                    if v5681 then
                        let v5682 : int64 = v2 % 100L
                        let v5683 : bool = v5682 = 0L
                        v5683
                    else
                        false
                if v5684 then
                    let v5685 : unit = ()
                    let v5686 : (unit -> unit) = closure12(v1, v2, v5680)
                    let v5687 : unit = (fun () -> v5686 (); v5685) ()
                    ()
                (* run_target_args'
                let v5777 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5778 : (int32 -> Async<unit>) = Async.Sleep
                let v5779 : Async<unit> = v5778 10
                let _run_target_args'_v5777 = v5779 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5780 : (int32 -> Async<unit>) = Async.Sleep
                let v5781 : Async<unit> = v5780 10
                let _run_target_args'_v5777 = v5781 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5782 : (int32 -> Async<unit>) = Async.Sleep
                let v5783 : Async<unit> = v5782 10
                let _run_target_args'_v5777 = v5783 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5784 : (int32 -> Async<unit>) = Async.Sleep
                let v5785 : Async<unit> = v5784 10
                let _run_target_args'_v5777 = v5785 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5786 : (int32 -> Async<unit>) = Async.Sleep
                let v5787 : Async<unit> = v5786 10
                let _run_target_args'_v5777 = v5787 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5788 : (int32 -> Async<unit>) = Async.Sleep
                let v5789 : Async<unit> = v5788 10
                let _run_target_args'_v5777 = v5789 
                #endif
#else
                let v5790 : (int32 -> Async<unit>) = Async.Sleep
                let v5791 : Async<unit> = v5790 10
                let _run_target_args'_v5777 = v5791 
                #endif
                let v5792 : Async<unit> = _run_target_args'_v5777 
                do! v5792 
                let v5795 : int64 = v2 + 1L
                let v5796 : Async<int64> = method26(v0, v1, v5795)
                return! v5796 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5915 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v8340 : Async<int64> = _let'_v5569 
    let _run_target_args'_v9 = v8340 
    #endif
#else
    let v8342 : unit = ()
    let _let'_v8342 =
        async {
            try
                (* run_target_args'
                let v8349 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v8351 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8349 = v8351 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v8355 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8349 = v8355 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v8359 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8349 = v8359 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v8363 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8349 = v8363 
                #endif
#if FABLE_COMPILER_PYTHON
                let v8367 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8349 = v8367 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v8371 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v8349 = v8371 
                #endif
#else
                let v8374 : System.IO.FileMode = System.IO.FileMode.Open
                let v8380 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v8375 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v8375
                    | US7_2 -> (* AccessReadWrite *)
                        let v8377 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v8377
                    | US7_1 -> (* AccessWrite *)
                        let v8376 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v8376
                let v8390 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v8385 : System.IO.FileShare = System.IO.FileShare.Delete
                        v8385
                    | US8_0 -> (* ShareNone *)
                        let v8381 : System.IO.FileShare = System.IO.FileShare.None
                        v8381
                    | US8_1 -> (* ShareRead *)
                        let v8382 : System.IO.FileShare = System.IO.FileShare.Read
                        v8382
                    | US8_3 -> (* ShareReadWrite *)
                        let v8384 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v8384
                    | US8_2 -> (* ShareWrite *)
                        let v8383 : System.IO.FileShare = System.IO.FileShare.Write
                        v8383
                let v8391 : System.IO.FileStream = new System.IO.FileStream (v1, v8374, v8380, v8390)
                let _run_target_args'_v8349 = v8391 
                #endif
                let v8392 : System.IO.FileStream = _run_target_args'_v8349 
                use v8392 = v8392 
                let v8398 : System.IO.FileStream = v8392 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v8453 : exn = ex
                let v8454 : bool = v2 > 0L
                let v8457 : bool =
                    if v8454 then
                        let v8455 : int64 = v2 % 100L
                        let v8456 : bool = v8455 = 0L
                        v8456
                    else
                        false
                if v8457 then
                    let v8458 : unit = ()
                    let v8459 : (unit -> unit) = closure12(v1, v2, v8453)
                    let v8460 : unit = (fun () -> v8459 (); v8458) ()
                    ()
                (* run_target_args'
                let v8550 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v8551 : (int32 -> Async<unit>) = Async.Sleep
                let v8552 : Async<unit> = v8551 10
                let _run_target_args'_v8550 = v8552 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v8553 : (int32 -> Async<unit>) = Async.Sleep
                let v8554 : Async<unit> = v8553 10
                let _run_target_args'_v8550 = v8554 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v8555 : (int32 -> Async<unit>) = Async.Sleep
                let v8556 : Async<unit> = v8555 10
                let _run_target_args'_v8550 = v8556 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v8557 : (int32 -> Async<unit>) = Async.Sleep
                let v8558 : Async<unit> = v8557 10
                let _run_target_args'_v8550 = v8558 
                #endif
#if FABLE_COMPILER_PYTHON
                let v8559 : (int32 -> Async<unit>) = Async.Sleep
                let v8560 : Async<unit> = v8559 10
                let _run_target_args'_v8550 = v8560 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v8561 : (int32 -> Async<unit>) = Async.Sleep
                let v8562 : Async<unit> = v8561 10
                let _run_target_args'_v8550 = v8562 
                #endif
#else
                let v8563 : (int32 -> Async<unit>) = Async.Sleep
                let v8564 : Async<unit> = v8563 10
                let _run_target_args'_v8550 = v8564 
                #endif
                let v8565 : Async<unit> = _run_target_args'_v8550 
                do! v8565 
                let v8568 : int64 = v2 + 1L
                let v8569 : Async<int64> = method26(v0, v1, v8568)
                return! v8569 
                (* indent
                ()
            indent *)
            (* try_unit
            let v8688 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v11113 : Async<int64> = _let'_v8342 
    let _run_target_args'_v9 = v11113 
    #endif
    let v11114 : Async<int64> = _run_target_args'_v9 
    v11114
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
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17(v7)
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
    let v138 : string = method19()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[90m"
    let v142 : string = method19()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[90m"
    let v146 : string = method19()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[90m"
    let v150 : string = method19()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method36 (v0 : int64, v1 : string, v2 : exn) : string =
    let v3 : string = method18()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure6(v4, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v18 : string = "retry"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v4, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v29 : string = " = "
    let v30 : string = $"{v29}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v4, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v39 : string = $"{v0}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v4, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v49 : string = "; "
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v60 : string = "path"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure6(v4, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v29}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure6(v4, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v79 : string = $"{v1}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure6(v4, v79)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v88 : string = $"{v49}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure6(v4, v88)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v98 : string = "ex"
    let v99 : string = $"{v98}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure6(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v108 : string = $"{v29}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    (* run_target_args'
    let v120 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v121 : string = "format!(\"{:#?}\", $0)"
    let v122 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v121 
    let v123 : string = "fable_library_rust::String_::fromString($0)"
    let v124 : string = Fable.Core.RustInterop.emitRustExpr v122 v123 
    let _run_target_args'_v120 = v124 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v125 : string = "format!(\"{:#?}\", $0)"
    let v126 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v125 
    let v127 : string = "fable_library_rust::String_::fromString($0)"
    let v128 : string = Fable.Core.RustInterop.emitRustExpr v126 v127 
    let _run_target_args'_v120 = v128 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v129 : string = "format!(\"{:#?}\", $0)"
    let v130 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v129 
    let v131 : string = "fable_library_rust::String_::fromString($0)"
    let v132 : string = Fable.Core.RustInterop.emitRustExpr v130 v131 
    let _run_target_args'_v120 = v132 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v134 : string = $"%A{v2}"
    let _run_target_args'_v120 = v134 
    #endif
#if FABLE_COMPILER_PYTHON
    let v138 : string = $"%A{v2}"
    let _run_target_args'_v120 = v138 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v142 : string = $"%A{v2}"
    let _run_target_args'_v120 = v142 
    #endif
#else
    let v146 : string = $"%A{v2}"
    let _run_target_args'_v120 = v146 
    #endif
    let v149 : string = _run_target_args'_v120 
    let v156 : string = $"{v149}"
    let v159 : unit = ()
    let v160 : (unit -> unit) = closure6(v4, v156)
    let v161 : unit = (fun () -> v160 (); v159) ()
    let v166 : string = " }"
    let v167 : string = $"{v166}"
    let v170 : unit = ()
    let v171 : (unit -> unit) = closure6(v4, v167)
    let v172 : unit = (fun () -> v171 (); v170) ()
    let v175 : string = v4.l0
    v175
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
        let v7 : unit = ()
        let v8 : (unit -> unit) = closure0()
        let v9 : unit = (fun () -> v8 (); v7) ()
        let struct (v30 : Mut0, v31 : Mut1, v32 : Mut2, v33 : Mut3, v34 : Mut4, v35 : int64 option) = TraceState.trace_state.Value
        let v48 : string = method12(v30, v31, v32, v33, v34, v35)
        let v49 : string = method34()
        let v50 : string = method35(v30, v31, v32, v33, v34, v35, v48, v49, v1, v0, v2)
        method24(v50)
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
                let v215 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v216 : (int32 -> Async<unit>) = Async.Sleep
                let v217 : Async<unit> = v216 10
                let _run_target_args'_v215 = v217 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v218 : (int32 -> Async<unit>) = Async.Sleep
                let v219 : Async<unit> = v218 10
                let _run_target_args'_v215 = v219 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v220 : (int32 -> Async<unit>) = Async.Sleep
                let v221 : Async<unit> = v220 10
                let _run_target_args'_v215 = v221 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v222 : (int32 -> Async<unit>) = Async.Sleep
                let v223 : Async<unit> = v222 10
                let _run_target_args'_v215 = v223 
                #endif
#if FABLE_COMPILER_PYTHON
                let v224 : (int32 -> Async<unit>) = Async.Sleep
                let v225 : Async<unit> = v224 10
                let _run_target_args'_v215 = v225 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v226 : (int32 -> Async<unit>) = Async.Sleep
                let v227 : Async<unit> = v226 10
                let _run_target_args'_v215 = v227 
                #endif
#else
                let v228 : (int32 -> Async<unit>) = Async.Sleep
                let v229 : Async<unit> = v228 10
                let _run_target_args'_v215 = v229 
                #endif
                let v230 : Async<unit> = _run_target_args'_v215 
                do! v230 
                let v233 : bool = v1 < 3L
                let v238 : Async<string> =
                    if v233 then
                        let v234 : int64 = v1 + 1L
                        method32(v0, v234)
                    else
                        let v236 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v236
                return! v238 
                (* indent
                ()
            indent *)
            (* try_unit
            let v320 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2423 : Async<string> = _let'_v20 
    let _run_target_args'_v6 = v2423 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2425 : unit = ()
    let _let'_v2425 =
        async {
            try
                (* run_target_args'
                let v2432 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2434 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2432 = v2434 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2438 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2432 = v2438 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2442 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2432 = v2442 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2446 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2432 = v2446 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2450 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2432 = v2450 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2454 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v2432 = v2454 
                #endif
#else
                let v2457 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v2458 : System.Threading.Tasks.Task<string> = v2457 v0
                let _run_target_args'_v2432 = v2458 
                #endif
                let v2459 : System.Threading.Tasks.Task<string> = _run_target_args'_v2432 
                (* run_target_args'
                let v2469 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2471 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v2469 = v2471 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2475 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v2469 = v2475 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2479 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v2469 = v2479 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2482 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2483 : Async<string> = v2482 v2459
                let _run_target_args'_v2469 = v2483 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2484 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2485 : Async<string> = v2484 v2459
                let _run_target_args'_v2469 = v2485 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2486 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2487 : Async<string> = v2486 v2459
                let _run_target_args'_v2469 = v2487 
                #endif
#else
                let v2488 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v2489 : Async<string> = v2488 v2459
                let _run_target_args'_v2469 = v2489 
                #endif
                let v2490 : Async<string> = _run_target_args'_v2469 
                return! v2490 
                (* indent
                ()
            indent *)
            with ex ->
                let v2564 : exn = ex
                let v2565 : unit = ()
                let v2566 : (unit -> unit) = closure15(v0, v1, v2564)
                let v2567 : unit = (fun () -> v2566 (); v2565) ()
                (* run_target_args'
                let v2620 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v2621 : (int32 -> Async<unit>) = Async.Sleep
                let v2622 : Async<unit> = v2621 10
                let _run_target_args'_v2620 = v2622 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v2623 : (int32 -> Async<unit>) = Async.Sleep
                let v2624 : Async<unit> = v2623 10
                let _run_target_args'_v2620 = v2624 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v2625 : (int32 -> Async<unit>) = Async.Sleep
                let v2626 : Async<unit> = v2625 10
                let _run_target_args'_v2620 = v2626 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v2627 : (int32 -> Async<unit>) = Async.Sleep
                let v2628 : Async<unit> = v2627 10
                let _run_target_args'_v2620 = v2628 
                #endif
#if FABLE_COMPILER_PYTHON
                let v2629 : (int32 -> Async<unit>) = Async.Sleep
                let v2630 : Async<unit> = v2629 10
                let _run_target_args'_v2620 = v2630 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v2631 : (int32 -> Async<unit>) = Async.Sleep
                let v2632 : Async<unit> = v2631 10
                let _run_target_args'_v2620 = v2632 
                #endif
#else
                let v2633 : (int32 -> Async<unit>) = Async.Sleep
                let v2634 : Async<unit> = v2633 10
                let _run_target_args'_v2620 = v2634 
                #endif
                let v2635 : Async<unit> = _run_target_args'_v2620 
                do! v2635 
                let v2638 : bool = v1 < 3L
                let v2643 : Async<string> =
                    if v2638 then
                        let v2639 : int64 = v1 + 1L
                        method32(v0, v2639)
                    else
                        let v2641 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v2641
                return! v2643 
                (* indent
                ()
            indent *)
            (* try_unit
            let v2725 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4828 : Async<string> = _let'_v2425 
    let _run_target_args'_v6 = v4828 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4830 : unit = ()
    let _let'_v4830 =
        async {
            try
                (* run_target_args'
                let v4837 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4839 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4837 = v4839 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4843 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4837 = v4843 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4847 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4837 = v4847 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4851 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4837 = v4851 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4855 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4837 = v4855 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4859 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v4837 = v4859 
                #endif
#else
                let v4862 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v4863 : System.Threading.Tasks.Task<string> = v4862 v0
                let _run_target_args'_v4837 = v4863 
                #endif
                let v4864 : System.Threading.Tasks.Task<string> = _run_target_args'_v4837 
                (* run_target_args'
                let v4874 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v4876 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v4874 = v4876 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v4880 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v4874 = v4880 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v4884 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v4874 = v4884 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v4887 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4888 : Async<string> = v4887 v4864
                let _run_target_args'_v4874 = v4888 
                #endif
#if FABLE_COMPILER_PYTHON
                let v4889 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4890 : Async<string> = v4889 v4864
                let _run_target_args'_v4874 = v4890 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v4891 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4892 : Async<string> = v4891 v4864
                let _run_target_args'_v4874 = v4892 
                #endif
#else
                let v4893 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v4894 : Async<string> = v4893 v4864
                let _run_target_args'_v4874 = v4894 
                #endif
                let v4895 : Async<string> = _run_target_args'_v4874 
                return! v4895 
                (* indent
                ()
            indent *)
            with ex ->
                let v4969 : exn = ex
                let v4970 : unit = ()
                let v4971 : (unit -> unit) = closure15(v0, v1, v4969)
                let v4972 : unit = (fun () -> v4971 (); v4970) ()
                (* run_target_args'
                let v5025 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5026 : (int32 -> Async<unit>) = Async.Sleep
                let v5027 : Async<unit> = v5026 10
                let _run_target_args'_v5025 = v5027 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5028 : (int32 -> Async<unit>) = Async.Sleep
                let v5029 : Async<unit> = v5028 10
                let _run_target_args'_v5025 = v5029 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5030 : (int32 -> Async<unit>) = Async.Sleep
                let v5031 : Async<unit> = v5030 10
                let _run_target_args'_v5025 = v5031 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5032 : (int32 -> Async<unit>) = Async.Sleep
                let v5033 : Async<unit> = v5032 10
                let _run_target_args'_v5025 = v5033 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5034 : (int32 -> Async<unit>) = Async.Sleep
                let v5035 : Async<unit> = v5034 10
                let _run_target_args'_v5025 = v5035 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5036 : (int32 -> Async<unit>) = Async.Sleep
                let v5037 : Async<unit> = v5036 10
                let _run_target_args'_v5025 = v5037 
                #endif
#else
                let v5038 : (int32 -> Async<unit>) = Async.Sleep
                let v5039 : Async<unit> = v5038 10
                let _run_target_args'_v5025 = v5039 
                #endif
                let v5040 : Async<unit> = _run_target_args'_v5025 
                do! v5040 
                let v5043 : bool = v1 < 3L
                let v5048 : Async<string> =
                    if v5043 then
                        let v5044 : int64 = v1 + 1L
                        method32(v0, v5044)
                    else
                        let v5046 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v5046
                return! v5048 
                (* indent
                ()
            indent *)
            (* try_unit
            let v5130 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7233 : Async<string> = _let'_v4830 
    let _run_target_args'_v6 = v7233 
    #endif
#else
    let v7235 : unit = ()
    let _let'_v7235 =
        async {
            try
                (* run_target_args'
                let v7242 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7244 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7242 = v7244 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7248 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7242 = v7248 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7252 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7242 = v7252 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7256 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7242 = v7256 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7260 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7242 = v7260 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7264 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v7242 = v7264 
                #endif
#else
                let v7267 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v7268 : System.Threading.Tasks.Task<string> = v7267 v0
                let _run_target_args'_v7242 = v7268 
                #endif
                let v7269 : System.Threading.Tasks.Task<string> = _run_target_args'_v7242 
                (* run_target_args'
                let v7279 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7281 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v7279 = v7281 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7285 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v7279 = v7285 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7289 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v7279 = v7289 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7292 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7293 : Async<string> = v7292 v7269
                let _run_target_args'_v7279 = v7293 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7294 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7295 : Async<string> = v7294 v7269
                let _run_target_args'_v7279 = v7295 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7296 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7297 : Async<string> = v7296 v7269
                let _run_target_args'_v7279 = v7297 
                #endif
#else
                let v7298 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v7299 : Async<string> = v7298 v7269
                let _run_target_args'_v7279 = v7299 
                #endif
                let v7300 : Async<string> = _run_target_args'_v7279 
                return! v7300 
                (* indent
                ()
            indent *)
            with ex ->
                let v7374 : exn = ex
                let v7375 : unit = ()
                let v7376 : (unit -> unit) = closure15(v0, v1, v7374)
                let v7377 : unit = (fun () -> v7376 (); v7375) ()
                (* run_target_args'
                let v7430 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v7431 : (int32 -> Async<unit>) = Async.Sleep
                let v7432 : Async<unit> = v7431 10
                let _run_target_args'_v7430 = v7432 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v7433 : (int32 -> Async<unit>) = Async.Sleep
                let v7434 : Async<unit> = v7433 10
                let _run_target_args'_v7430 = v7434 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v7435 : (int32 -> Async<unit>) = Async.Sleep
                let v7436 : Async<unit> = v7435 10
                let _run_target_args'_v7430 = v7436 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v7437 : (int32 -> Async<unit>) = Async.Sleep
                let v7438 : Async<unit> = v7437 10
                let _run_target_args'_v7430 = v7438 
                #endif
#if FABLE_COMPILER_PYTHON
                let v7439 : (int32 -> Async<unit>) = Async.Sleep
                let v7440 : Async<unit> = v7439 10
                let _run_target_args'_v7430 = v7440 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v7441 : (int32 -> Async<unit>) = Async.Sleep
                let v7442 : Async<unit> = v7441 10
                let _run_target_args'_v7430 = v7442 
                #endif
#else
                let v7443 : (int32 -> Async<unit>) = Async.Sleep
                let v7444 : Async<unit> = v7443 10
                let _run_target_args'_v7430 = v7444 
                #endif
                let v7445 : Async<unit> = _run_target_args'_v7430 
                do! v7445 
                let v7448 : bool = v1 < 3L
                let v7453 : Async<string> =
                    if v7448 then
                        let v7449 : int64 = v1 + 1L
                        method32(v0, v7449)
                    else
                        let v7451 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v7451
                return! v7453 
                (* indent
                ()
            indent *)
            (* try_unit
            let v7535 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9638 : Async<string> = _let'_v7235 
    let _run_target_args'_v6 = v9638 
    #endif
    let v9639 : Async<string> = _run_target_args'_v6 
    v9639
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
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17(v7)
    (* run_target_args'
    let v13 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v14 : string = "inline_colorization::color_bright_red"
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
    let v55 : string = "inline_colorization::color_bright_red"
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
    let v96 : string = "inline_colorization::color_bright_red"
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
    let v137 : string = "\u001b[91m"
    let v138 : string = method19()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[91m"
    let v142 : string = method19()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[91m"
    let v146 : string = method19()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[91m"
    let v150 : string = method19()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method54 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "error'"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure6(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"{v0}"
    let v40 : unit = ()
    let v41 : (unit -> unit) = closure6(v2, v37)
    let v42 : unit = (fun () -> v41 (); v40) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure6(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
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
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method52()
        let v48 : string = method53(v28, v29, v30, v31, v32, v33, v46, v47, v0)
        method24(v48)
and method55 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17(v7)
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
    let v138 : string = method19()
    let v139 : string = v137 + v8 
    let v140 : string = v139 + v138 
    let _run_target_args'_v13 = v140 
    #endif
#if FABLE_COMPILER_PYTHON
    let v141 : string = "\u001b[93m"
    let v142 : string = method19()
    let v143 : string = v141 + v8 
    let v144 : string = v143 + v142 
    let _run_target_args'_v13 = v144 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v145 : string = "\u001b[93m"
    let v146 : string = method19()
    let v147 : string = v145 + v8 
    let v148 : string = v147 + v146 
    let _run_target_args'_v13 = v148 
    #endif
#else
    let v149 : string = "\u001b[93m"
    let v150 : string = method19()
    let v151 : string = v149 + v8 
    let v152 : string = v151 + v150 
    let _run_target_args'_v13 = v152 
    #endif
    let v153 : string = _run_target_args'_v13 
    v153
and method57 (v0 : string, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "path"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "ex"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method55()
        let v49 : string = method20(v0)
        (* run_target_args'
        let v54 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v56 : string = $"%A{v1}"
        let _run_target_args'_v54 = v56 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v60 : string = $"%A{v1}"
        let _run_target_args'_v54 = v60 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v64 : string = $"%A{v1}"
        let _run_target_args'_v54 = v64 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v68 : string = $"%A{v1}"
        let _run_target_args'_v54 = v68 
        #endif
#if FABLE_COMPILER_PYTHON
        let v72 : string = $"%A{v1}"
        let _run_target_args'_v54 = v72 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v76 : string = $"%A{v1}"
        let _run_target_args'_v54 = v76 
        #endif
#else
        let v79 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v54 = v79 
        #endif
        let v80 : string = _run_target_args'_v54 
        let v86 : string = method56(v29, v30, v31, v32, v33, v34, v47, v48, v49, v80)
        method24(v86)
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
                let v100 : (string -> unit) = System.IO.File.Delete
                v100 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v179 : exn = ex
                let v180 : int64 = v1 % 100L
                let v181 : bool = v180 = 0L
                if v181 then
                    let v182 : unit = ()
                    let v183 : (unit -> unit) = closure27(v0, v179)
                    let v184 : unit = (fun () -> v183 (); v182) ()
                    ()
                (* run_target_args'
                let v274 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v275 : (int32 -> Async<unit>) = Async.Sleep
                let v276 : Async<unit> = v275 10
                let _run_target_args'_v274 = v276 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v277 : (int32 -> Async<unit>) = Async.Sleep
                let v278 : Async<unit> = v277 10
                let _run_target_args'_v274 = v278 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v279 : (int32 -> Async<unit>) = Async.Sleep
                let v280 : Async<unit> = v279 10
                let _run_target_args'_v274 = v280 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v281 : (int32 -> Async<unit>) = Async.Sleep
                let v282 : Async<unit> = v281 10
                let _run_target_args'_v274 = v282 
                #endif
#if FABLE_COMPILER_PYTHON
                let v283 : (int32 -> Async<unit>) = Async.Sleep
                let v284 : Async<unit> = v283 10
                let _run_target_args'_v274 = v284 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v285 : (int32 -> Async<unit>) = Async.Sleep
                let v286 : Async<unit> = v285 10
                let _run_target_args'_v274 = v286 
                #endif
#else
                let v287 : (int32 -> Async<unit>) = Async.Sleep
                let v288 : Async<unit> = v287 10
                let _run_target_args'_v274 = v288 
                #endif
                let v289 : Async<unit> = _run_target_args'_v274 
                do! v289 
                let v292 : int64 = v1 + 1L
                let v293 : Async<int64> = method46(v0, v292)
                return! v293 
                (* indent
                ()
            indent *)
            (* try_unit
            let v410 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3143 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v3143 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3145 : unit = ()
    let _let'_v3145 =
        async {
            try
                (* run_target_args'
                let v3148 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3149 : string = "std::fs::remove_file(&*$0)"
                let v3150 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v3149 
                let v3151 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v3153 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3154 : string = "$0.map_err(|x| $1(x))"
                let v3155 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3150, v3151) v3154 
                let _run_target_args'_v3153 = v3155 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3156 : string = "$0.map_err(|x| $1(x))"
                let v3157 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3150, v3151) v3156 
                let _run_target_args'_v3153 = v3157 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3158 : string = "$0.map_err(|x| $1(x))"
                let v3159 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v3150, v3151) v3158 
                let _run_target_args'_v3153 = v3159 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3160 : Result<unit, string> = match v3150 with Ok x -> Ok x | Error x -> Error (v3151 x)
                let _run_target_args'_v3153 = v3160 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3161 : Result<unit, string> = match v3150 with Ok x -> Ok x | Error x -> Error (v3151 x)
                let _run_target_args'_v3153 = v3161 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3162 : Result<unit, string> = match v3150 with Ok x -> Ok x | Error x -> Error (v3151 x)
                let _run_target_args'_v3153 = v3162 
                #endif
#else
                let v3163 : Result<unit, string> = match v3150 with Ok x -> Ok x | Error x -> Error (v3151 x)
                let _run_target_args'_v3153 = v3163 
                #endif
                let v3164 : Result<unit, string> = _run_target_args'_v3153 
                let v3167 : (unit -> US9) = method50()
                let v3168 : (string -> US9) = method51()
                let v3170 : US9 = match v3164 with Ok () -> v3167 () | Error x -> v3168 x
                match v3170 with
                | US9_1(v3173) -> (* Error *)
                    let v3174 : unit = ()
                    let v3175 : (unit -> unit) = closure26(v3173)
                    let v3176 : unit = (fun () -> v3175 (); v3174) ()
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
                let v3225 : (string -> unit) = System.IO.File.Delete
                v3225 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v3304 : exn = ex
                let v3305 : int64 = v1 % 100L
                let v3306 : bool = v3305 = 0L
                if v3306 then
                    let v3307 : unit = ()
                    let v3308 : (unit -> unit) = closure27(v0, v3304)
                    let v3309 : unit = (fun () -> v3308 (); v3307) ()
                    ()
                (* run_target_args'
                let v3399 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3400 : (int32 -> Async<unit>) = Async.Sleep
                let v3401 : Async<unit> = v3400 10
                let _run_target_args'_v3399 = v3401 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3402 : (int32 -> Async<unit>) = Async.Sleep
                let v3403 : Async<unit> = v3402 10
                let _run_target_args'_v3399 = v3403 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3404 : (int32 -> Async<unit>) = Async.Sleep
                let v3405 : Async<unit> = v3404 10
                let _run_target_args'_v3399 = v3405 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3406 : (int32 -> Async<unit>) = Async.Sleep
                let v3407 : Async<unit> = v3406 10
                let _run_target_args'_v3399 = v3407 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3408 : (int32 -> Async<unit>) = Async.Sleep
                let v3409 : Async<unit> = v3408 10
                let _run_target_args'_v3399 = v3409 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3410 : (int32 -> Async<unit>) = Async.Sleep
                let v3411 : Async<unit> = v3410 10
                let _run_target_args'_v3399 = v3411 
                #endif
#else
                let v3412 : (int32 -> Async<unit>) = Async.Sleep
                let v3413 : Async<unit> = v3412 10
                let _run_target_args'_v3399 = v3413 
                #endif
                let v3414 : Async<unit> = _run_target_args'_v3399 
                do! v3414 
                let v3417 : int64 = v1 + 1L
                let v3418 : Async<int64> = method46(v0, v3417)
                return! v3418 
                (* indent
                ()
            indent *)
            (* try_unit
            let v3535 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6268 : Async<int64> = _let'_v3145 
    let _run_target_args'_v6 = v6268 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v6270 : unit = ()
    let _let'_v6270 =
        async {
            try
                (* run_target_args'
                let v6273 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6274 : string = "std::fs::remove_file(&*$0)"
                let v6275 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v6274 
                let v6276 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v6278 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6279 : string = "$0.map_err(|x| $1(x))"
                let v6280 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6275, v6276) v6279 
                let _run_target_args'_v6278 = v6280 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6281 : string = "$0.map_err(|x| $1(x))"
                let v6282 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6275, v6276) v6281 
                let _run_target_args'_v6278 = v6282 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6283 : string = "$0.map_err(|x| $1(x))"
                let v6284 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v6275, v6276) v6283 
                let _run_target_args'_v6278 = v6284 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6285 : Result<unit, string> = match v6275 with Ok x -> Ok x | Error x -> Error (v6276 x)
                let _run_target_args'_v6278 = v6285 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6286 : Result<unit, string> = match v6275 with Ok x -> Ok x | Error x -> Error (v6276 x)
                let _run_target_args'_v6278 = v6286 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6287 : Result<unit, string> = match v6275 with Ok x -> Ok x | Error x -> Error (v6276 x)
                let _run_target_args'_v6278 = v6287 
                #endif
#else
                let v6288 : Result<unit, string> = match v6275 with Ok x -> Ok x | Error x -> Error (v6276 x)
                let _run_target_args'_v6278 = v6288 
                #endif
                let v6289 : Result<unit, string> = _run_target_args'_v6278 
                let v6292 : (unit -> US9) = method50()
                let v6293 : (string -> US9) = method51()
                let v6295 : US9 = match v6289 with Ok () -> v6292 () | Error x -> v6293 x
                match v6295 with
                | US9_1(v6298) -> (* Error *)
                    let v6299 : unit = ()
                    let v6300 : (unit -> unit) = closure26(v6298)
                    let v6301 : unit = (fun () -> v6300 (); v6299) ()
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
                let v6350 : (string -> unit) = System.IO.File.Delete
                v6350 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v6429 : exn = ex
                let v6430 : int64 = v1 % 100L
                let v6431 : bool = v6430 = 0L
                if v6431 then
                    let v6432 : unit = ()
                    let v6433 : (unit -> unit) = closure27(v0, v6429)
                    let v6434 : unit = (fun () -> v6433 (); v6432) ()
                    ()
                (* run_target_args'
                let v6524 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v6525 : (int32 -> Async<unit>) = Async.Sleep
                let v6526 : Async<unit> = v6525 10
                let _run_target_args'_v6524 = v6526 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v6527 : (int32 -> Async<unit>) = Async.Sleep
                let v6528 : Async<unit> = v6527 10
                let _run_target_args'_v6524 = v6528 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v6529 : (int32 -> Async<unit>) = Async.Sleep
                let v6530 : Async<unit> = v6529 10
                let _run_target_args'_v6524 = v6530 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v6531 : (int32 -> Async<unit>) = Async.Sleep
                let v6532 : Async<unit> = v6531 10
                let _run_target_args'_v6524 = v6532 
                #endif
#if FABLE_COMPILER_PYTHON
                let v6533 : (int32 -> Async<unit>) = Async.Sleep
                let v6534 : Async<unit> = v6533 10
                let _run_target_args'_v6524 = v6534 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v6535 : (int32 -> Async<unit>) = Async.Sleep
                let v6536 : Async<unit> = v6535 10
                let _run_target_args'_v6524 = v6536 
                #endif
#else
                let v6537 : (int32 -> Async<unit>) = Async.Sleep
                let v6538 : Async<unit> = v6537 10
                let _run_target_args'_v6524 = v6538 
                #endif
                let v6539 : Async<unit> = _run_target_args'_v6524 
                do! v6539 
                let v6542 : int64 = v1 + 1L
                let v6543 : Async<int64> = method46(v0, v6542)
                return! v6543 
                (* indent
                ()
            indent *)
            (* try_unit
            let v6660 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9393 : Async<int64> = _let'_v6270 
    let _run_target_args'_v6 = v9393 
    #endif
#else
    let v9395 : unit = ()
    let _let'_v9395 =
        async {
            try
                (* run_target_args'
                let v9398 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9399 : string = "std::fs::remove_file(&*$0)"
                let v9400 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v9399 
                let v9401 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v9403 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9404 : string = "$0.map_err(|x| $1(x))"
                let v9405 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9400, v9401) v9404 
                let _run_target_args'_v9403 = v9405 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9406 : string = "$0.map_err(|x| $1(x))"
                let v9407 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9400, v9401) v9406 
                let _run_target_args'_v9403 = v9407 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9408 : string = "$0.map_err(|x| $1(x))"
                let v9409 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v9400, v9401) v9408 
                let _run_target_args'_v9403 = v9409 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9410 : Result<unit, string> = match v9400 with Ok x -> Ok x | Error x -> Error (v9401 x)
                let _run_target_args'_v9403 = v9410 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9411 : Result<unit, string> = match v9400 with Ok x -> Ok x | Error x -> Error (v9401 x)
                let _run_target_args'_v9403 = v9411 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9412 : Result<unit, string> = match v9400 with Ok x -> Ok x | Error x -> Error (v9401 x)
                let _run_target_args'_v9403 = v9412 
                #endif
#else
                let v9413 : Result<unit, string> = match v9400 with Ok x -> Ok x | Error x -> Error (v9401 x)
                let _run_target_args'_v9403 = v9413 
                #endif
                let v9414 : Result<unit, string> = _run_target_args'_v9403 
                let v9417 : (unit -> US9) = method50()
                let v9418 : (string -> US9) = method51()
                let v9420 : US9 = match v9414 with Ok () -> v9417 () | Error x -> v9418 x
                match v9420 with
                | US9_1(v9423) -> (* Error *)
                    let v9424 : unit = ()
                    let v9425 : (unit -> unit) = closure26(v9423)
                    let v9426 : unit = (fun () -> v9425 (); v9424) ()
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
                let v9475 : (string -> unit) = System.IO.File.Delete
                v9475 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v9554 : exn = ex
                let v9555 : int64 = v1 % 100L
                let v9556 : bool = v9555 = 0L
                if v9556 then
                    let v9557 : unit = ()
                    let v9558 : (unit -> unit) = closure27(v0, v9554)
                    let v9559 : unit = (fun () -> v9558 (); v9557) ()
                    ()
                (* run_target_args'
                let v9649 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9650 : (int32 -> Async<unit>) = Async.Sleep
                let v9651 : Async<unit> = v9650 10
                let _run_target_args'_v9649 = v9651 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9652 : (int32 -> Async<unit>) = Async.Sleep
                let v9653 : Async<unit> = v9652 10
                let _run_target_args'_v9649 = v9653 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9654 : (int32 -> Async<unit>) = Async.Sleep
                let v9655 : Async<unit> = v9654 10
                let _run_target_args'_v9649 = v9655 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9656 : (int32 -> Async<unit>) = Async.Sleep
                let v9657 : Async<unit> = v9656 10
                let _run_target_args'_v9649 = v9657 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9658 : (int32 -> Async<unit>) = Async.Sleep
                let v9659 : Async<unit> = v9658 10
                let _run_target_args'_v9649 = v9659 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9660 : (int32 -> Async<unit>) = Async.Sleep
                let v9661 : Async<unit> = v9660 10
                let _run_target_args'_v9649 = v9661 
                #endif
#else
                let v9662 : (int32 -> Async<unit>) = Async.Sleep
                let v9663 : Async<unit> = v9662 10
                let _run_target_args'_v9649 = v9663 
                #endif
                let v9664 : Async<unit> = _run_target_args'_v9649 
                do! v9664 
                let v9667 : int64 = v1 + 1L
                let v9668 : Async<int64> = method46(v0, v9667)
                return! v9668 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9785 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v12518 : Async<int64> = _let'_v9395 
    let _run_target_args'_v6 = v12518 
    #endif
    let v12519 : Async<int64> = _run_target_args'_v6 
    v12519
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
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v11 : unit = ()
    let v12 : (unit -> unit) = closure6(v4, v8)
    let v13 : unit = (fun () -> v12 (); v11) ()
    let v18 : string = "old_path"
    let v19 : string = $"{v18}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v4, v19)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v29 : string = " = "
    let v30 : string = $"{v29}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v4, v30)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v39 : string = $"{v0}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v4, v39)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v49 : string = "; "
    let v50 : string = $"{v49}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v4, v50)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v60 : string = "new_path"
    let v61 : string = $"{v60}"
    let v64 : unit = ()
    let v65 : (unit -> unit) = closure6(v4, v61)
    let v66 : unit = (fun () -> v65 (); v64) ()
    let v70 : string = $"{v29}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure6(v4, v70)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v79 : string = $"{v1}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure6(v4, v79)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v88 : string = $"{v49}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure6(v4, v88)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v98 : string = "ex"
    let v99 : string = $"{v98}"
    let v102 : unit = ()
    let v103 : (unit -> unit) = closure6(v4, v99)
    let v104 : unit = (fun () -> v103 (); v102) ()
    let v108 : string = $"{v29}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v4, v108)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v117 : string = $"{v2}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure6(v4, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure6(v4, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v4.l0
    v136
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
        let v7 : unit = ()
        let v8 : (unit -> unit) = closure0()
        let v9 : unit = (fun () -> v8 (); v7) ()
        let struct (v30 : Mut0, v31 : Mut1, v32 : Mut2, v33 : Mut3, v34 : Mut4, v35 : int64 option) = TraceState.trace_state.Value
        let v48 : string = method12(v30, v31, v32, v33, v34, v35)
        let v49 : string = method55()
        let v50 : string = method20(v1)
        let v51 : string = method20(v0)
        (* run_target_args'
        let v56 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v58 : string = $"%A{v2}"
        let _run_target_args'_v56 = v58 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v62 : string = $"%A{v2}"
        let _run_target_args'_v56 = v62 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v66 : string = $"%A{v2}"
        let _run_target_args'_v56 = v66 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v70 : string = $"%A{v2}"
        let _run_target_args'_v56 = v70 
        #endif
#if FABLE_COMPILER_PYTHON
        let v74 : string = $"%A{v2}"
        let _run_target_args'_v56 = v74 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v78 : string = $"%A{v2}"
        let _run_target_args'_v56 = v78 
        #endif
#else
        let v81 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v56 = v81 
        #endif
        let v82 : string = _run_target_args'_v56 
        let v88 : string = method62(v30, v31, v32, v33, v34, v35, v48, v49, v50, v51, v82)
        method24(v88)
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
                let v120 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v121 : (int32 -> Async<unit>) = Async.Sleep
                let v122 : Async<unit> = v121 10
                let _run_target_args'_v120 = v122 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v123 : (int32 -> Async<unit>) = Async.Sleep
                let v124 : Async<unit> = v123 10
                let _run_target_args'_v120 = v124 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v125 : (int32 -> Async<unit>) = Async.Sleep
                let v126 : Async<unit> = v125 10
                let _run_target_args'_v120 = v126 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v127 : (int32 -> Async<unit>) = Async.Sleep
                let v128 : Async<unit> = v127 10
                let _run_target_args'_v120 = v128 
                #endif
#if FABLE_COMPILER_PYTHON
                let v129 : (int32 -> Async<unit>) = Async.Sleep
                let v130 : Async<unit> = v129 10
                let _run_target_args'_v120 = v130 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v131 : (int32 -> Async<unit>) = Async.Sleep
                let v132 : Async<unit> = v131 10
                let _run_target_args'_v120 = v132 
                #endif
#else
                let v133 : (int32 -> Async<unit>) = Async.Sleep
                let v134 : Async<unit> = v133 10
                let _run_target_args'_v120 = v134 
                #endif
                let v135 : Async<unit> = _run_target_args'_v120 
                do! v135 
                let v138 : int64 = v2 + 1L
                let v139 : Async<int64> = method59(v0, v1, v138)
                return! v139 
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
    let v1880 : Async<int64> = _let'_v21 
    let _run_target_args'_v7 = v1880 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1882 : unit = ()
    let _let'_v1882 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v1885 : exn = ex
                let v1886 : int64 = v2 % 100L
                let v1887 : bool = v1886 = 0L
                if v1887 then
                    let v1888 : unit = ()
                    let v1889 : (unit -> unit) = closure30(v0, v1, v1885)
                    let v1890 : unit = (fun () -> v1889 (); v1888) ()
                    ()
                (* run_target_args'
                let v1981 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v1982 : (int32 -> Async<unit>) = Async.Sleep
                let v1983 : Async<unit> = v1982 10
                let _run_target_args'_v1981 = v1983 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v1984 : (int32 -> Async<unit>) = Async.Sleep
                let v1985 : Async<unit> = v1984 10
                let _run_target_args'_v1981 = v1985 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v1986 : (int32 -> Async<unit>) = Async.Sleep
                let v1987 : Async<unit> = v1986 10
                let _run_target_args'_v1981 = v1987 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v1988 : (int32 -> Async<unit>) = Async.Sleep
                let v1989 : Async<unit> = v1988 10
                let _run_target_args'_v1981 = v1989 
                #endif
#if FABLE_COMPILER_PYTHON
                let v1990 : (int32 -> Async<unit>) = Async.Sleep
                let v1991 : Async<unit> = v1990 10
                let _run_target_args'_v1981 = v1991 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v1992 : (int32 -> Async<unit>) = Async.Sleep
                let v1993 : Async<unit> = v1992 10
                let _run_target_args'_v1981 = v1993 
                #endif
#else
                let v1994 : (int32 -> Async<unit>) = Async.Sleep
                let v1995 : Async<unit> = v1994 10
                let _run_target_args'_v1981 = v1995 
                #endif
                let v1996 : Async<unit> = _run_target_args'_v1981 
                do! v1996 
                let v1999 : int64 = v2 + 1L
                let v2000 : Async<int64> = method59(v0, v1, v1999)
                return! v2000 
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
    let v3741 : Async<int64> = _let'_v1882 
    let _run_target_args'_v7 = v3741 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3743 : unit = ()
    let _let'_v3743 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v3746 : exn = ex
                let v3747 : int64 = v2 % 100L
                let v3748 : bool = v3747 = 0L
                if v3748 then
                    let v3749 : unit = ()
                    let v3750 : (unit -> unit) = closure30(v0, v1, v3746)
                    let v3751 : unit = (fun () -> v3750 (); v3749) ()
                    ()
                (* run_target_args'
                let v3842 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v3843 : (int32 -> Async<unit>) = Async.Sleep
                let v3844 : Async<unit> = v3843 10
                let _run_target_args'_v3842 = v3844 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v3845 : (int32 -> Async<unit>) = Async.Sleep
                let v3846 : Async<unit> = v3845 10
                let _run_target_args'_v3842 = v3846 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v3847 : (int32 -> Async<unit>) = Async.Sleep
                let v3848 : Async<unit> = v3847 10
                let _run_target_args'_v3842 = v3848 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v3849 : (int32 -> Async<unit>) = Async.Sleep
                let v3850 : Async<unit> = v3849 10
                let _run_target_args'_v3842 = v3850 
                #endif
#if FABLE_COMPILER_PYTHON
                let v3851 : (int32 -> Async<unit>) = Async.Sleep
                let v3852 : Async<unit> = v3851 10
                let _run_target_args'_v3842 = v3852 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v3853 : (int32 -> Async<unit>) = Async.Sleep
                let v3854 : Async<unit> = v3853 10
                let _run_target_args'_v3842 = v3854 
                #endif
#else
                let v3855 : (int32 -> Async<unit>) = Async.Sleep
                let v3856 : Async<unit> = v3855 10
                let _run_target_args'_v3842 = v3856 
                #endif
                let v3857 : Async<unit> = _run_target_args'_v3842 
                do! v3857 
                let v3860 : int64 = v2 + 1L
                let v3861 : Async<int64> = method59(v0, v1, v3860)
                return! v3861 
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
    let v5602 : Async<int64> = _let'_v3743 
    let _run_target_args'_v7 = v5602 
    #endif
#else
    let v5604 : unit = ()
    let _let'_v5604 =
        async {
            try
                method61(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v5607 : exn = ex
                let v5608 : int64 = v2 % 100L
                let v5609 : bool = v5608 = 0L
                if v5609 then
                    let v5610 : unit = ()
                    let v5611 : (unit -> unit) = closure30(v0, v1, v5607)
                    let v5612 : unit = (fun () -> v5611 (); v5610) ()
                    ()
                (* run_target_args'
                let v5703 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v5704 : (int32 -> Async<unit>) = Async.Sleep
                let v5705 : Async<unit> = v5704 10
                let _run_target_args'_v5703 = v5705 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v5706 : (int32 -> Async<unit>) = Async.Sleep
                let v5707 : Async<unit> = v5706 10
                let _run_target_args'_v5703 = v5707 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v5708 : (int32 -> Async<unit>) = Async.Sleep
                let v5709 : Async<unit> = v5708 10
                let _run_target_args'_v5703 = v5709 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v5710 : (int32 -> Async<unit>) = Async.Sleep
                let v5711 : Async<unit> = v5710 10
                let _run_target_args'_v5703 = v5711 
                #endif
#if FABLE_COMPILER_PYTHON
                let v5712 : (int32 -> Async<unit>) = Async.Sleep
                let v5713 : Async<unit> = v5712 10
                let _run_target_args'_v5703 = v5713 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v5714 : (int32 -> Async<unit>) = Async.Sleep
                let v5715 : Async<unit> = v5714 10
                let _run_target_args'_v5703 = v5715 
                #endif
#else
                let v5716 : (int32 -> Async<unit>) = Async.Sleep
                let v5717 : Async<unit> = v5716 10
                let _run_target_args'_v5703 = v5717 
                #endif
                let v5718 : Async<unit> = _run_target_args'_v5703 
                do! v5718 
                let v5721 : int64 = v2 + 1L
                let v5722 : Async<int64> = method59(v0, v1, v5721)
                return! v5722 
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
    let v7463 : Async<int64> = _let'_v5604 
    let _run_target_args'_v7 = v7463 
    #endif
    let v7464 : Async<int64> = _run_target_args'_v7 
    v7464
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
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "timeout"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure6(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"{v0}"
    let v40 : unit = ()
    let v41 : (unit -> unit) = closure6(v2, v37)
    let v42 : unit = (fun () -> v41 (); v40) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure6(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
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
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method34()
        let v48 : string = method74(v28, v29, v30, v31, v32, v33, v46, v47, v0)
        method24(v48)
and method77 (v0 : int32, v1 : string) : string =
    let v2 : string = method18()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "timeout"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "ex"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method52()
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v55 : string = $"%A{v1}"
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v59 : string = $"%A{v1}"
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v63 : string = $"%A{v1}"
        let _run_target_args'_v53 = v63 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v53 = v67 
        #endif
#if FABLE_COMPILER_PYTHON
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v53 = v71 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v53 = v75 
        #endif
#else
        let v78 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v53 = v78 
        #endif
        let v79 : string = _run_target_args'_v53 
        let v85 : string = method76(v29, v30, v31, v32, v33, v34, v47, v48, v0, v79)
        method24(v85)
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
            let v179 : US2 =
                match v23 with
                | US11_1(v26) -> (* Error *)
                    let v28 : string = $"%A{v26}"
                    let v33 : string = "System.TimeoutException"
                    let v34 : bool = v28.Contains v33 
                    if v34 then
                        let v37 : unit = ()
                        let v38 : (unit -> unit) = closure34(v0)
                        let v39 : unit = (fun () -> v38 (); v37) ()
                        US2_1
                    else
                        let v89 : unit = ()
                        let v90 : (unit -> unit) = closure35(v0, v26)
                        let v91 : unit = (fun () -> v90 (); v89) ()
                        US2_1
                | US11_0(v24) -> (* Ok *)
                    US2_0(v24)
            return v179 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1279 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v1279 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1281 : unit = ()
    let _let'_v1281 =
        async {
            let! v1 = v1 
            let v1284 : US11 = v1 
            let v1440 : US2 =
                match v1284 with
                | US11_1(v1287) -> (* Error *)
                    let v1289 : string = $"%A{v1287}"
                    let v1294 : string = "System.TimeoutException"
                    let v1295 : bool = v1289.Contains v1294 
                    if v1295 then
                        let v1298 : unit = ()
                        let v1299 : (unit -> unit) = closure34(v0)
                        let v1300 : unit = (fun () -> v1299 (); v1298) ()
                        US2_1
                    else
                        let v1350 : unit = ()
                        let v1351 : (unit -> unit) = closure35(v0, v1287)
                        let v1352 : unit = (fun () -> v1351 (); v1350) ()
                        US2_1
                | US11_0(v1285) -> (* Ok *)
                    US2_0(v1285)
            return v1440 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2540 : Async<US2> = _let'_v1281 
    let _run_target_args'_v6 = v2540 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2542 : unit = ()
    let _let'_v2542 =
        async {
            let! v1 = v1 
            let v2545 : US11 = v1 
            let v2701 : US2 =
                match v2545 with
                | US11_1(v2548) -> (* Error *)
                    let v2550 : string = $"%A{v2548}"
                    let v2555 : string = "System.TimeoutException"
                    let v2556 : bool = v2550.Contains v2555 
                    if v2556 then
                        let v2559 : unit = ()
                        let v2560 : (unit -> unit) = closure34(v0)
                        let v2561 : unit = (fun () -> v2560 (); v2559) ()
                        US2_1
                    else
                        let v2611 : unit = ()
                        let v2612 : (unit -> unit) = closure35(v0, v2548)
                        let v2613 : unit = (fun () -> v2612 (); v2611) ()
                        US2_1
                | US11_0(v2546) -> (* Ok *)
                    US2_0(v2546)
            return v2701 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3801 : Async<US2> = _let'_v2542 
    let _run_target_args'_v6 = v3801 
    #endif
#else
    let v3803 : unit = ()
    let _let'_v3803 =
        async {
            let! v1 = v1 
            let v3806 : US11 = v1 
            let v3962 : US2 =
                match v3806 with
                | US11_1(v3809) -> (* Error *)
                    let v3811 : string = $"%A{v3809}"
                    let v3816 : string = "System.TimeoutException"
                    let v3817 : bool = v3811.Contains v3816 
                    if v3817 then
                        let v3820 : unit = ()
                        let v3821 : (unit -> unit) = closure34(v0)
                        let v3822 : unit = (fun () -> v3821 (); v3820) ()
                        US2_1
                    else
                        let v3872 : unit = ()
                        let v3873 : (unit -> unit) = closure35(v0, v3809)
                        let v3874 : unit = (fun () -> v3873 (); v3872) ()
                        US2_1
                | US11_0(v3807) -> (* Ok *)
                    US2_0(v3807)
            return v3962 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5062 : Async<US2> = _let'_v3803 
    let _run_target_args'_v6 = v5062 
    #endif
    let v5063 : Async<US2> = _run_target_args'_v6 
    v5063
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
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "retry"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "ex"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method16()
        (* run_target_args'
        let v53 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v55 : string = $"%A{v1}"
        let _run_target_args'_v53 = v55 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v59 : string = $"%A{v1}"
        let _run_target_args'_v53 = v59 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v63 : string = $"%A{v1}"
        let _run_target_args'_v53 = v63 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v53 = v67 
        #endif
#if FABLE_COMPILER_PYTHON
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v53 = v71 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v53 = v75 
        #endif
#else
        let v78 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v53 = v78 
        #endif
        let v79 : string = _run_target_args'_v53 
        let v85 : string = method79(v29, v30, v31, v32, v33, v34, v47, v48, v0, v79)
        method24(v85)
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
                    let v188 : string option = None
                    return v188 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v191 : int64 = v1 + 1L
                    let v192 : Async<string option> = method65(v0, v191)
                    return! v192 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v290 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2183 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v2183 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2185 : unit = ()
    let _let'_v2185 =
        async {
            try
                let v2188 : bool = v1 > 0L
                if v2188 then
                    let v2189 : Async<int64> = method30(v0)
                    let v2190 : int32 = 1000
                    let v2191 : Async<US2> = method67(v2190, v2189)
                    (* run_target_args'
                    let v2196 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v2198 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v2196 = v2198 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v2202 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v2196 = v2202 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v2206 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v2196 = v2206 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v2209 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2210 : Async<unit> = v2209 v2191
                    let _run_target_args'_v2196 = v2210 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v2211 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2212 : Async<unit> = v2211 v2191
                    let _run_target_args'_v2196 = v2212 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v2213 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2214 : Async<unit> = v2213 v2191
                    let _run_target_args'_v2196 = v2214 
                    #endif
#else
                    let v2215 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v2216 : Async<unit> = v2215 v2191
                    let _run_target_args'_v2196 = v2216 
                    #endif
                    let v2217 : Async<unit> = _run_target_args'_v2196 
                    do! v2217 
                    ()
                let v2223 : Async<string> = method31(v0)
                let v2224 : Async<string option> = method78(v2223)
                return! v2224 
                (* indent
                ()
            indent *)
            with ex ->
                let v2262 : exn = ex
                let v2263 : bool = v1 = 0L
                let v2264 : bool = v2263 <> true
                if v2264 then
                    let v2265 : unit = ()
                    let v2266 : (unit -> unit) = closure36(v1, v2262)
                    let v2267 : unit = (fun () -> v2266 (); v2265) ()
                    let v2353 : string option = None
                    return v2353 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v2356 : int64 = v1 + 1L
                    let v2357 : Async<string option> = method65(v0, v2356)
                    return! v2357 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v2455 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4348 : Async<string option> = _let'_v2185 
    let _run_target_args'_v6 = v4348 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4350 : unit = ()
    let _let'_v4350 =
        async {
            try
                let v4353 : bool = v1 > 0L
                if v4353 then
                    let v4354 : Async<int64> = method30(v0)
                    let v4355 : int32 = 1000
                    let v4356 : Async<US2> = method67(v4355, v4354)
                    (* run_target_args'
                    let v4361 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v4363 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4361 = v4363 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v4367 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4361 = v4367 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v4371 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v4361 = v4371 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v4374 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4375 : Async<unit> = v4374 v4356
                    let _run_target_args'_v4361 = v4375 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v4376 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4377 : Async<unit> = v4376 v4356
                    let _run_target_args'_v4361 = v4377 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v4378 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4379 : Async<unit> = v4378 v4356
                    let _run_target_args'_v4361 = v4379 
                    #endif
#else
                    let v4380 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v4381 : Async<unit> = v4380 v4356
                    let _run_target_args'_v4361 = v4381 
                    #endif
                    let v4382 : Async<unit> = _run_target_args'_v4361 
                    do! v4382 
                    ()
                let v4388 : Async<string> = method31(v0)
                let v4389 : Async<string option> = method78(v4388)
                return! v4389 
                (* indent
                ()
            indent *)
            with ex ->
                let v4427 : exn = ex
                let v4428 : bool = v1 = 0L
                let v4429 : bool = v4428 <> true
                if v4429 then
                    let v4430 : unit = ()
                    let v4431 : (unit -> unit) = closure36(v1, v4427)
                    let v4432 : unit = (fun () -> v4431 (); v4430) ()
                    let v4518 : string option = None
                    return v4518 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v4521 : int64 = v1 + 1L
                    let v4522 : Async<string option> = method65(v0, v4521)
                    return! v4522 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v4620 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6513 : Async<string option> = _let'_v4350 
    let _run_target_args'_v6 = v6513 
    #endif
#else
    let v6515 : unit = ()
    let _let'_v6515 =
        async {
            try
                let v6518 : bool = v1 > 0L
                if v6518 then
                    let v6519 : Async<int64> = method30(v0)
                    let v6520 : int32 = 1000
                    let v6521 : Async<US2> = method67(v6520, v6519)
                    (* run_target_args'
                    let v6526 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v6528 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v6526 = v6528 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v6532 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v6526 = v6532 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v6536 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v6526 = v6536 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v6539 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6540 : Async<unit> = v6539 v6521
                    let _run_target_args'_v6526 = v6540 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v6541 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6542 : Async<unit> = v6541 v6521
                    let _run_target_args'_v6526 = v6542 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v6543 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6544 : Async<unit> = v6543 v6521
                    let _run_target_args'_v6526 = v6544 
                    #endif
#else
                    let v6545 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v6546 : Async<unit> = v6545 v6521
                    let _run_target_args'_v6526 = v6546 
                    #endif
                    let v6547 : Async<unit> = _run_target_args'_v6526 
                    do! v6547 
                    ()
                let v6553 : Async<string> = method31(v0)
                let v6554 : Async<string option> = method78(v6553)
                return! v6554 
                (* indent
                ()
            indent *)
            with ex ->
                let v6592 : exn = ex
                let v6593 : bool = v1 = 0L
                let v6594 : bool = v6593 <> true
                if v6594 then
                    let v6595 : unit = ()
                    let v6596 : (unit -> unit) = closure36(v1, v6592)
                    let v6597 : unit = (fun () -> v6596 (); v6595) ()
                    let v6683 : string option = None
                    return v6683 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v6686 : int64 = v1 + 1L
                    let v6687 : Async<string option> = method65(v0, v6686)
                    return! v6687 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v6785 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v8678 : Async<string option> = _let'_v6515 
    let _run_target_args'_v6 = v8678 
    #endif
    let v8679 : Async<string option> = _run_target_args'_v6 
    v8679
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
    let v704 : US12 = US12_1
    let v705 : US12 = v684 |> Option.defaultValue v704 
    let v725 : US5 =
        match v705 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v709) -> (* Some *)
            let v710 : string = "$0.naive_utc()"
            let v711 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v709 v710 
            let v712 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v713 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v711 v712 
            let v714 : string = "%Y%m%d-%H%M-%S%f"
            let v715 : string = "r#\"" + v714 + "\"#"
            let v716 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v715 
            let v717 : string = "$0.format($1).to_string()"
            let v718 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v713, v716) v717 
            let v719 : string = "fable_library_rust::String_::fromString($0)"
            let v720 : string = Fable.Core.RustInterop.emitRustExpr v718 v719 
            let v721 : string = $"{v720.[0..17]}-{v720.[18..21]}-{v720.[22]}"
            US5_0(v721)
    let v729 : string =
        match v725 with
        | US5_1 -> (* None *)
            let v727 : string = ""
            v727
        | US5_0(v726) -> (* Some *)
            v726
    (* run_target_args'
    let v734 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v735 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v736 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v735 
    let _run_target_args'_v734 = v736 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v738 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v738 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v742 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v742 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v746 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v746 
    #endif
#if FABLE_COMPILER_PYTHON
    let v750 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v734 = v750 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v753 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v734 = v753 
    #endif
#else
    let v754 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v734 = v754 
    #endif
    let v755 : System.TimeZoneInfo = _run_target_args'_v734 
    (* run_target_args'
    let v768 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v772 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v773 : (System.DateTime -> int64) = _.Ticks
    let v774 : int64 = v773 v586
    let _run_target_args'_v772 = v774 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v775 : (System.DateTime -> int64) = _.Ticks
    let v776 : int64 = v775 v586
    let _run_target_args'_v772 = v776 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v778 : int64 = null |> unbox<int64>
    let _run_target_args'_v772 = v778 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v781 : (System.DateTime -> int64) = _.Ticks
    let v782 : int64 = v781 v586
    let _run_target_args'_v772 = v782 
    #endif
#if FABLE_COMPILER_PYTHON
    let v783 : (System.DateTime -> int64) = _.Ticks
    let v784 : int64 = v783 v586
    let _run_target_args'_v772 = v784 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v785 : (System.DateTime -> int64) = _.Ticks
    let v786 : int64 = v785 v586
    let _run_target_args'_v772 = v786 
    #endif
#else
    let v787 : (System.DateTime -> int64) = _.Ticks
    let v788 : int64 = v787 v586
    let _run_target_args'_v772 = v788 
    #endif
    let v789 : int64 = _run_target_args'_v772 
    let v809 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v810 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v789) v809 
    let v812 : System.TimeSpan = v810 |> System.TimeSpan 
    let _run_target_args'_v768 = v812 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v818 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v819 : (System.DateTime -> int64) = _.Ticks
    let v820 : int64 = v819 v586
    let _run_target_args'_v818 = v820 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v821 : (System.DateTime -> int64) = _.Ticks
    let v822 : int64 = v821 v586
    let _run_target_args'_v818 = v822 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v824 : int64 = null |> unbox<int64>
    let _run_target_args'_v818 = v824 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v827 : (System.DateTime -> int64) = _.Ticks
    let v828 : int64 = v827 v586
    let _run_target_args'_v818 = v828 
    #endif
#if FABLE_COMPILER_PYTHON
    let v829 : (System.DateTime -> int64) = _.Ticks
    let v830 : int64 = v829 v586
    let _run_target_args'_v818 = v830 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v831 : (System.DateTime -> int64) = _.Ticks
    let v832 : int64 = v831 v586
    let _run_target_args'_v818 = v832 
    #endif
#else
    let v833 : (System.DateTime -> int64) = _.Ticks
    let v834 : int64 = v833 v586
    let _run_target_args'_v818 = v834 
    #endif
    let v835 : int64 = _run_target_args'_v818 
    let v855 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v856 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v586, v835) v855 
    let v858 : System.TimeSpan = v856 |> System.TimeSpan 
    let _run_target_args'_v768 = v858 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v862 : US3 = US3_2
    let v863 : US4 = US4_3(v862)
    let v864 : string = $"date_time.get_utc_offset / target: {v863}"
    let v865 : System.TimeSpan = failwith<System.TimeSpan> v864
    let _run_target_args'_v768 = v865 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v869 : US3 = US3_0
    let v870 : US4 = US4_4(v869)
    let v871 : string = $"date_time.get_utc_offset / target: {v870}"
    let v872 : System.TimeSpan = failwith<System.TimeSpan> v871
    let _run_target_args'_v768 = v872 
    #endif
#if FABLE_COMPILER_PYTHON
    let v876 : US3 = US3_0
    let v877 : US4 = US4_5(v876)
    let v878 : string = $"date_time.get_utc_offset / target: {v877}"
    let v879 : System.TimeSpan = failwith<System.TimeSpan> v878
    let _run_target_args'_v768 = v879 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v882 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v887 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v888 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v889 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v888 
    let _run_target_args'_v887 = v889 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v891 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v891 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v895 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v895 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v899 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v899 
    #endif
#if FABLE_COMPILER_PYTHON
    let v903 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v887 = v903 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v906 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v887 = v906 
    #endif
#else
    let v907 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v887 = v907 
    #endif
    let v908 : System.TimeZoneInfo = _run_target_args'_v887 
    let v914 : (System.DateTime -> System.TimeSpan) = v882 v908
    let v915 : System.TimeSpan = v914 v586
    let _run_target_args'_v768 = v915 
    #endif
#else
    let v916 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v921 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v922 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v923 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v922 
    let _run_target_args'_v921 = v923 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v925 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v925 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v929 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v929 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v933 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v933 
    #endif
#if FABLE_COMPILER_PYTHON
    let v937 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v921 = v937 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v940 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v921 = v940 
    #endif
#else
    let v941 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v921 = v941 
    #endif
    let v942 : System.TimeZoneInfo = _run_target_args'_v921 
    let v948 : (System.DateTime -> System.TimeSpan) = v916 v942
    let v949 : System.TimeSpan = v948 v586
    let _run_target_args'_v768 = v949 
    #endif
    let v950 : System.TimeSpan = _run_target_args'_v768 
    let v960 : (System.TimeSpan -> int32) = _.Hours
    let v961 : int32 = v960 v950
    let v964 : bool = v961 > 0
    let v965 : uint8 =
        if v964 then
            1uy
        else
            0uy
    let v966 : string = method84()
    (* run_target_args'
    let v1020 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1021 : string = "$0.toString($1)"
    let v1022 : string = Fable.Core.RustInterop.emitRustExpr struct (v950, v966) v1021 
    let _run_target_args'_v1020 = v1022 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1023 : string = "$0.toString($1)"
    let v1024 : string = Fable.Core.RustInterop.emitRustExpr struct (v950, v966) v1023 
    let _run_target_args'_v1020 = v1024 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1025 : string = "$0.toString($1)"
    let v1026 : string = Fable.Core.RustInterop.emitRustExpr struct (v950, v966) v1025 
    let _run_target_args'_v1020 = v1026 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1027 : string = v950.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1020 = v1027 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1028 : string = v950.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1020 = v1028 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1030 : string = v950.ToString v966 
    let _run_target_args'_v1020 = v1030 
    #endif
#else
    let v1083 : string = v950.ToString v966 
    let _run_target_args'_v1020 = v1083 
    #endif
    let v1135 : string = _run_target_args'_v1020 
    let v1190 : string = $"{v965}{v1135.[0..1]}{v1135.[3..4]}"
    let v1192 : (System.Guid -> string) = _.ToString()
    let v1193 : string = v1192 v0
    let v1196 : int32 = v729.Length
    let v1197 : int32 = v1190.Length
    let v1198 : int32 = v1196 + v1197
    let v1200 : (string -> int32) = String.length
    let v1201 : int32 = v1200 v1193
    let v1209 : int32 = v1198 |> int32 
    let v1222 : int32 = v1201 |> int32 
    let v1230 : int32 = v1222 - 1
    let v1232 : string = v1193.[int v1209..int v1230]
    let v1236 : string = $"{v729}{v1190}{v1232}"
    (* run_target_args'
    let v1241 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1243 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1243 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1247 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1247 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1251 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1241 = v1251 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1255 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1255 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1259 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1259 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1263 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1263 
    #endif
#else
    let v1267 : System.Guid = v1236 |> System.Guid 
    let _run_target_args'_v1241 = v1267 
    #endif
    let v1270 : System.Guid = _run_target_args'_v1241 
    let _run_target_args'_v569 = v1270 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1277 : System.DateTime = System.DateTime.UnixEpoch
    let v1281 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1282 : System.DateTime = v1281 v1277
    let v1286 : System.DateTimeKind = System.DateTimeKind.Local
    let v1287 : System.DateTime = System.DateTime.SpecifyKind (v1, v1286)
    let v1291 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1292 : System.DateTime = v1291 v1287
    (* run_target_args'
    let v1298 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1299 : (System.DateTime -> int64) = _.Ticks
    let v1300 : int64 = v1299 v1292
    let _run_target_args'_v1298 = v1300 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1301 : (System.DateTime -> int64) = _.Ticks
    let v1302 : int64 = v1301 v1292
    let _run_target_args'_v1298 = v1302 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1304 : int64 = null |> unbox<int64>
    let _run_target_args'_v1298 = v1304 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1307 : (System.DateTime -> int64) = _.Ticks
    let v1308 : int64 = v1307 v1292
    let _run_target_args'_v1298 = v1308 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1309 : (System.DateTime -> int64) = _.Ticks
    let v1310 : int64 = v1309 v1292
    let _run_target_args'_v1298 = v1310 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1311 : (System.DateTime -> int64) = _.Ticks
    let v1312 : int64 = v1311 v1292
    let _run_target_args'_v1298 = v1312 
    #endif
#else
    let v1313 : (System.DateTime -> int64) = _.Ticks
    let v1314 : int64 = v1313 v1292
    let _run_target_args'_v1298 = v1314 
    #endif
    let v1315 : int64 = _run_target_args'_v1298 
    (* run_target_args'
    let v1338 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1339 : (System.DateTime -> int64) = _.Ticks
    let v1340 : int64 = v1339 v1282
    let _run_target_args'_v1338 = v1340 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1341 : (System.DateTime -> int64) = _.Ticks
    let v1342 : int64 = v1341 v1282
    let _run_target_args'_v1338 = v1342 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1344 : int64 = null |> unbox<int64>
    let _run_target_args'_v1338 = v1344 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1347 : (System.DateTime -> int64) = _.Ticks
    let v1348 : int64 = v1347 v1282
    let _run_target_args'_v1338 = v1348 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1349 : (System.DateTime -> int64) = _.Ticks
    let v1350 : int64 = v1349 v1282
    let _run_target_args'_v1338 = v1350 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1351 : (System.DateTime -> int64) = _.Ticks
    let v1352 : int64 = v1351 v1282
    let _run_target_args'_v1338 = v1352 
    #endif
#else
    let v1353 : (System.DateTime -> int64) = _.Ticks
    let v1354 : int64 = v1353 v1282
    let _run_target_args'_v1338 = v1354 
    #endif
    let v1355 : int64 = _run_target_args'_v1338 
    let v1376 : int64 = v1315 |> int64 
    let v1380 : int64 = v1355 |> int64 
    let v1383 : int64 = v1376 - v1380
    let v1384 : int64 = v1383 / 10L
    let v1385 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1386 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1384 v1385 
    let v1389 : (chrono_DateTime<chrono_Utc> -> US12) = method83()
    let v1390 : US12 option = v1386 |> Option.map v1389 
    let v1410 : US12 = US12_1
    let v1411 : US12 = v1390 |> Option.defaultValue v1410 
    let v1431 : US5 =
        match v1411 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v1415) -> (* Some *)
            let v1416 : string = "$0.naive_utc()"
            let v1417 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1415 v1416 
            let v1418 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1419 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1417 v1418 
            let v1420 : string = "%Y%m%d-%H%M-%S%f"
            let v1421 : string = "r#\"" + v1420 + "\"#"
            let v1422 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1421 
            let v1423 : string = "$0.format($1).to_string()"
            let v1424 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1419, v1422) v1423 
            let v1425 : string = "fable_library_rust::String_::fromString($0)"
            let v1426 : string = Fable.Core.RustInterop.emitRustExpr v1424 v1425 
            let v1427 : string = $"{v1426.[0..17]}-{v1426.[18..21]}-{v1426.[22]}"
            US5_0(v1427)
    let v1435 : string =
        match v1431 with
        | US5_1 -> (* None *)
            let v1433 : string = ""
            v1433
        | US5_0(v1432) -> (* Some *)
            v1432
    (* run_target_args'
    let v1440 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1441 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1442 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1441 
    let _run_target_args'_v1440 = v1442 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1444 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1444 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1448 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1448 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1452 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1452 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1456 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1440 = v1456 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1459 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1440 = v1459 
    #endif
#else
    let v1460 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1440 = v1460 
    #endif
    let v1461 : System.TimeZoneInfo = _run_target_args'_v1440 
    (* run_target_args'
    let v1474 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1478 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1479 : (System.DateTime -> int64) = _.Ticks
    let v1480 : int64 = v1479 v1292
    let _run_target_args'_v1478 = v1480 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1481 : (System.DateTime -> int64) = _.Ticks
    let v1482 : int64 = v1481 v1292
    let _run_target_args'_v1478 = v1482 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1484 : int64 = null |> unbox<int64>
    let _run_target_args'_v1478 = v1484 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1487 : (System.DateTime -> int64) = _.Ticks
    let v1488 : int64 = v1487 v1292
    let _run_target_args'_v1478 = v1488 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1489 : (System.DateTime -> int64) = _.Ticks
    let v1490 : int64 = v1489 v1292
    let _run_target_args'_v1478 = v1490 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1491 : (System.DateTime -> int64) = _.Ticks
    let v1492 : int64 = v1491 v1292
    let _run_target_args'_v1478 = v1492 
    #endif
#else
    let v1493 : (System.DateTime -> int64) = _.Ticks
    let v1494 : int64 = v1493 v1292
    let _run_target_args'_v1478 = v1494 
    #endif
    let v1495 : int64 = _run_target_args'_v1478 
    let v1515 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1516 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1292, v1495) v1515 
    let v1518 : System.TimeSpan = v1516 |> System.TimeSpan 
    let _run_target_args'_v1474 = v1518 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1524 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1525 : (System.DateTime -> int64) = _.Ticks
    let v1526 : int64 = v1525 v1292
    let _run_target_args'_v1524 = v1526 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1527 : (System.DateTime -> int64) = _.Ticks
    let v1528 : int64 = v1527 v1292
    let _run_target_args'_v1524 = v1528 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1530 : int64 = null |> unbox<int64>
    let _run_target_args'_v1524 = v1530 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1533 : (System.DateTime -> int64) = _.Ticks
    let v1534 : int64 = v1533 v1292
    let _run_target_args'_v1524 = v1534 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1535 : (System.DateTime -> int64) = _.Ticks
    let v1536 : int64 = v1535 v1292
    let _run_target_args'_v1524 = v1536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1537 : (System.DateTime -> int64) = _.Ticks
    let v1538 : int64 = v1537 v1292
    let _run_target_args'_v1524 = v1538 
    #endif
#else
    let v1539 : (System.DateTime -> int64) = _.Ticks
    let v1540 : int64 = v1539 v1292
    let _run_target_args'_v1524 = v1540 
    #endif
    let v1541 : int64 = _run_target_args'_v1524 
    let v1561 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1562 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1292, v1541) v1561 
    let v1564 : System.TimeSpan = v1562 |> System.TimeSpan 
    let _run_target_args'_v1474 = v1564 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1568 : US3 = US3_2
    let v1569 : US4 = US4_3(v1568)
    let v1570 : string = $"date_time.get_utc_offset / target: {v1569}"
    let v1571 : System.TimeSpan = failwith<System.TimeSpan> v1570
    let _run_target_args'_v1474 = v1571 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1575 : US3 = US3_0
    let v1576 : US4 = US4_4(v1575)
    let v1577 : string = $"date_time.get_utc_offset / target: {v1576}"
    let v1578 : System.TimeSpan = failwith<System.TimeSpan> v1577
    let _run_target_args'_v1474 = v1578 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1582 : US3 = US3_0
    let v1583 : US4 = US4_5(v1582)
    let v1584 : string = $"date_time.get_utc_offset / target: {v1583}"
    let v1585 : System.TimeSpan = failwith<System.TimeSpan> v1584
    let _run_target_args'_v1474 = v1585 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1588 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1593 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1594 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1595 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1594 
    let _run_target_args'_v1593 = v1595 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1597 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1597 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1601 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1601 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1605 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1605 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1609 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1593 = v1609 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1612 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1593 = v1612 
    #endif
#else
    let v1613 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1593 = v1613 
    #endif
    let v1614 : System.TimeZoneInfo = _run_target_args'_v1593 
    let v1620 : (System.DateTime -> System.TimeSpan) = v1588 v1614
    let v1621 : System.TimeSpan = v1620 v1292
    let _run_target_args'_v1474 = v1621 
    #endif
#else
    let v1622 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1627 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1628 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1629 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1628 
    let _run_target_args'_v1627 = v1629 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1631 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1631 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1635 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1635 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1639 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1639 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1643 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1627 = v1643 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1646 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1627 = v1646 
    #endif
#else
    let v1647 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1627 = v1647 
    #endif
    let v1648 : System.TimeZoneInfo = _run_target_args'_v1627 
    let v1654 : (System.DateTime -> System.TimeSpan) = v1622 v1648
    let v1655 : System.TimeSpan = v1654 v1292
    let _run_target_args'_v1474 = v1655 
    #endif
    let v1656 : System.TimeSpan = _run_target_args'_v1474 
    let v1666 : (System.TimeSpan -> int32) = _.Hours
    let v1667 : int32 = v1666 v1656
    let v1670 : bool = v1667 > 0
    let v1671 : uint8 =
        if v1670 then
            1uy
        else
            0uy
    let v1672 : string = method84()
    (* run_target_args'
    let v1726 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1727 : string = "$0.toString($1)"
    let v1728 : string = Fable.Core.RustInterop.emitRustExpr struct (v1656, v1672) v1727 
    let _run_target_args'_v1726 = v1728 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1729 : string = "$0.toString($1)"
    let v1730 : string = Fable.Core.RustInterop.emitRustExpr struct (v1656, v1672) v1729 
    let _run_target_args'_v1726 = v1730 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1731 : string = "$0.toString($1)"
    let v1732 : string = Fable.Core.RustInterop.emitRustExpr struct (v1656, v1672) v1731 
    let _run_target_args'_v1726 = v1732 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1733 : string = v1656.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1726 = v1733 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1734 : string = v1656.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1726 = v1734 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1736 : string = v1656.ToString v1672 
    let _run_target_args'_v1726 = v1736 
    #endif
#else
    let v1789 : string = v1656.ToString v1672 
    let _run_target_args'_v1726 = v1789 
    #endif
    let v1841 : string = _run_target_args'_v1726 
    let v1896 : string = $"{v1671}{v1841.[0..1]}{v1841.[3..4]}"
    let v1898 : (System.Guid -> string) = _.ToString()
    let v1899 : string = v1898 v0
    let v1902 : int32 = v1435.Length
    let v1903 : int32 = v1896.Length
    let v1904 : int32 = v1902 + v1903
    let v1906 : (string -> int32) = String.length
    let v1907 : int32 = v1906 v1899
    let v1915 : int32 = v1904 |> int32 
    let v1928 : int32 = v1907 |> int32 
    let v1936 : int32 = v1928 - 1
    let v1938 : string = v1899.[int v1915..int v1936]
    let v1942 : string = $"{v1435}{v1896}{v1938}"
    (* run_target_args'
    let v1947 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1949 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1949 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1953 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1953 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1957 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1947 = v1957 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1961 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1961 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1965 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1965 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1969 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1969 
    #endif
#else
    let v1973 : System.Guid = v1942 |> System.Guid 
    let _run_target_args'_v1947 = v1973 
    #endif
    let v1976 : System.Guid = _run_target_args'_v1947 
    let _run_target_args'_v569 = v1976 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1983 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v569 = v1983 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1986 : string = method85()
    let v1988 : bool = v1986 = ""
    let v1990 : string =
        if v1988 then
            let v1989 : string = "M-d-y hh:mm:ss tt"
            v1989
        else
            v1986
    let v1991 : (string -> string) = v1.ToString
    let v1992 : string = v1991 v1990
    (* run_target_args'
    let v2011 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2012 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2013 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2012 
    let _run_target_args'_v2011 = v2013 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2015 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2015 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2019 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2019 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2023 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2023 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2027 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2011 = v2027 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2030 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2011 = v2030 
    #endif
#else
    let v2031 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2011 = v2031 
    #endif
    let v2032 : System.TimeZoneInfo = _run_target_args'_v2011 
    (* run_target_args'
    let v2045 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2049 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2050 : (System.DateTime -> int64) = _.Ticks
    let v2051 : int64 = v2050 v1
    let _run_target_args'_v2049 = v2051 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2052 : (System.DateTime -> int64) = _.Ticks
    let v2053 : int64 = v2052 v1
    let _run_target_args'_v2049 = v2053 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2055 : int64 = null |> unbox<int64>
    let _run_target_args'_v2049 = v2055 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2058 : (System.DateTime -> int64) = _.Ticks
    let v2059 : int64 = v2058 v1
    let _run_target_args'_v2049 = v2059 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2060 : (System.DateTime -> int64) = _.Ticks
    let v2061 : int64 = v2060 v1
    let _run_target_args'_v2049 = v2061 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2062 : (System.DateTime -> int64) = _.Ticks
    let v2063 : int64 = v2062 v1
    let _run_target_args'_v2049 = v2063 
    #endif
#else
    let v2064 : (System.DateTime -> int64) = _.Ticks
    let v2065 : int64 = v2064 v1
    let _run_target_args'_v2049 = v2065 
    #endif
    let v2066 : int64 = _run_target_args'_v2049 
    let v2086 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2087 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2066) v2086 
    let v2089 : System.TimeSpan = v2087 |> System.TimeSpan 
    let _run_target_args'_v2045 = v2089 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2095 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2096 : (System.DateTime -> int64) = _.Ticks
    let v2097 : int64 = v2096 v1
    let _run_target_args'_v2095 = v2097 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2098 : (System.DateTime -> int64) = _.Ticks
    let v2099 : int64 = v2098 v1
    let _run_target_args'_v2095 = v2099 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2101 : int64 = null |> unbox<int64>
    let _run_target_args'_v2095 = v2101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2104 : (System.DateTime -> int64) = _.Ticks
    let v2105 : int64 = v2104 v1
    let _run_target_args'_v2095 = v2105 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2106 : (System.DateTime -> int64) = _.Ticks
    let v2107 : int64 = v2106 v1
    let _run_target_args'_v2095 = v2107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2108 : (System.DateTime -> int64) = _.Ticks
    let v2109 : int64 = v2108 v1
    let _run_target_args'_v2095 = v2109 
    #endif
#else
    let v2110 : (System.DateTime -> int64) = _.Ticks
    let v2111 : int64 = v2110 v1
    let _run_target_args'_v2095 = v2111 
    #endif
    let v2112 : int64 = _run_target_args'_v2095 
    let v2132 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2133 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2112) v2132 
    let v2135 : System.TimeSpan = v2133 |> System.TimeSpan 
    let _run_target_args'_v2045 = v2135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2139 : US3 = US3_2
    let v2140 : US4 = US4_3(v2139)
    let v2141 : string = $"date_time.get_utc_offset / target: {v2140}"
    let v2142 : System.TimeSpan = failwith<System.TimeSpan> v2141
    let _run_target_args'_v2045 = v2142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2146 : US3 = US3_0
    let v2147 : US4 = US4_4(v2146)
    let v2148 : string = $"date_time.get_utc_offset / target: {v2147}"
    let v2149 : System.TimeSpan = failwith<System.TimeSpan> v2148
    let _run_target_args'_v2045 = v2149 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2153 : US3 = US3_0
    let v2154 : US4 = US4_5(v2153)
    let v2155 : string = $"date_time.get_utc_offset / target: {v2154}"
    let v2156 : System.TimeSpan = failwith<System.TimeSpan> v2155
    let _run_target_args'_v2045 = v2156 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2159 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2164 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2165 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2166 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2165 
    let _run_target_args'_v2164 = v2166 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2168 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2168 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2172 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2172 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2176 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2176 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2180 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2164 = v2180 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2183 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2164 = v2183 
    #endif
#else
    let v2184 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2164 = v2184 
    #endif
    let v2185 : System.TimeZoneInfo = _run_target_args'_v2164 
    let v2191 : (System.DateTime -> System.TimeSpan) = v2159 v2185
    let v2192 : System.TimeSpan = v2191 v1
    let _run_target_args'_v2045 = v2192 
    #endif
#else
    let v2193 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2198 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2199 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2200 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2199 
    let _run_target_args'_v2198 = v2200 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2202 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2202 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2206 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2206 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2210 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2210 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2214 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2198 = v2214 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2217 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2198 = v2217 
    #endif
#else
    let v2218 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2198 = v2218 
    #endif
    let v2219 : System.TimeZoneInfo = _run_target_args'_v2198 
    let v2225 : (System.DateTime -> System.TimeSpan) = v2193 v2219
    let v2226 : System.TimeSpan = v2225 v1
    let _run_target_args'_v2045 = v2226 
    #endif
    let v2227 : System.TimeSpan = _run_target_args'_v2045 
    let v2237 : (System.TimeSpan -> int32) = _.Hours
    let v2238 : int32 = v2237 v2227
    let v2241 : bool = v2238 > 0
    let v2242 : uint8 =
        if v2241 then
            1uy
        else
            0uy
    let v2243 : string = method86()
    (* run_target_args'
    let v2297 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2298 : string = "$0.toString($1)"
    let v2299 : string = Fable.Core.RustInterop.emitRustExpr struct (v2227, v2243) v2298 
    let _run_target_args'_v2297 = v2299 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2300 : string = "$0.toString($1)"
    let v2301 : string = Fable.Core.RustInterop.emitRustExpr struct (v2227, v2243) v2300 
    let _run_target_args'_v2297 = v2301 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2302 : string = "$0.toString($1)"
    let v2303 : string = Fable.Core.RustInterop.emitRustExpr struct (v2227, v2243) v2302 
    let _run_target_args'_v2297 = v2303 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2304 : string = v2227.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2297 = v2304 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2305 : string = v2227.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2297 = v2305 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2307 : string = v2227.ToString v2243 
    let _run_target_args'_v2297 = v2307 
    #endif
#else
    let v2360 : string = v2227.ToString v2243 
    let _run_target_args'_v2297 = v2360 
    #endif
    let v2412 : string = _run_target_args'_v2297 
    let v2467 : string = $"{v2242}{v2412}"
    let v2469 : (System.Guid -> string) = _.ToString()
    let v2470 : string = v2469 v0
    let v2473 : int32 = v1992.Length
    let v2474 : int32 = v2467.Length
    let v2475 : int32 = v2473 + v2474
    let v2477 : (string -> int32) = String.length
    let v2478 : int32 = v2477 v2470
    let v2486 : int32 = v2475 |> int32 
    let v2499 : int32 = v2478 |> int32 
    let v2507 : int32 = v2499 - 1
    let v2509 : string = v2470.[int v2486..int v2507]
    let v2513 : string = $"{v1992}{v2467}{v2509}"
    (* run_target_args'
    let v2518 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2520 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2520 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2524 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2524 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2528 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2518 = v2528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2532 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2532 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2536 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2540 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2540 
    #endif
#else
    let v2544 : System.Guid = v2513 |> System.Guid 
    let _run_target_args'_v2518 = v2544 
    #endif
    let v2547 : System.Guid = _run_target_args'_v2518 
    let _run_target_args'_v569 = v2547 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2553 : string = method85()
    let v2555 : bool = v2553 = ""
    let v2557 : string =
        if v2555 then
            let v2556 : string = "M-d-y hh:mm:ss tt"
            v2556
        else
            v2553
    let v2558 : (string -> string) = v1.ToString
    let v2559 : string = v2558 v2557
    (* run_target_args'
    let v2578 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2579 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2580 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2579 
    let _run_target_args'_v2578 = v2580 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2582 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2582 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2586 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2586 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2590 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2590 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2594 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2578 = v2594 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2597 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2578 = v2597 
    #endif
#else
    let v2598 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2578 = v2598 
    #endif
    let v2599 : System.TimeZoneInfo = _run_target_args'_v2578 
    (* run_target_args'
    let v2612 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2616 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2617 : (System.DateTime -> int64) = _.Ticks
    let v2618 : int64 = v2617 v1
    let _run_target_args'_v2616 = v2618 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2619 : (System.DateTime -> int64) = _.Ticks
    let v2620 : int64 = v2619 v1
    let _run_target_args'_v2616 = v2620 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2622 : int64 = null |> unbox<int64>
    let _run_target_args'_v2616 = v2622 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2625 : (System.DateTime -> int64) = _.Ticks
    let v2626 : int64 = v2625 v1
    let _run_target_args'_v2616 = v2626 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2627 : (System.DateTime -> int64) = _.Ticks
    let v2628 : int64 = v2627 v1
    let _run_target_args'_v2616 = v2628 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2629 : (System.DateTime -> int64) = _.Ticks
    let v2630 : int64 = v2629 v1
    let _run_target_args'_v2616 = v2630 
    #endif
#else
    let v2631 : (System.DateTime -> int64) = _.Ticks
    let v2632 : int64 = v2631 v1
    let _run_target_args'_v2616 = v2632 
    #endif
    let v2633 : int64 = _run_target_args'_v2616 
    let v2653 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2654 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2633) v2653 
    let v2656 : System.TimeSpan = v2654 |> System.TimeSpan 
    let _run_target_args'_v2612 = v2656 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2662 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2663 : (System.DateTime -> int64) = _.Ticks
    let v2664 : int64 = v2663 v1
    let _run_target_args'_v2662 = v2664 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2665 : (System.DateTime -> int64) = _.Ticks
    let v2666 : int64 = v2665 v1
    let _run_target_args'_v2662 = v2666 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2668 : int64 = null |> unbox<int64>
    let _run_target_args'_v2662 = v2668 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2671 : (System.DateTime -> int64) = _.Ticks
    let v2672 : int64 = v2671 v1
    let _run_target_args'_v2662 = v2672 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2673 : (System.DateTime -> int64) = _.Ticks
    let v2674 : int64 = v2673 v1
    let _run_target_args'_v2662 = v2674 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2675 : (System.DateTime -> int64) = _.Ticks
    let v2676 : int64 = v2675 v1
    let _run_target_args'_v2662 = v2676 
    #endif
#else
    let v2677 : (System.DateTime -> int64) = _.Ticks
    let v2678 : int64 = v2677 v1
    let _run_target_args'_v2662 = v2678 
    #endif
    let v2679 : int64 = _run_target_args'_v2662 
    let v2699 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2700 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2679) v2699 
    let v2702 : System.TimeSpan = v2700 |> System.TimeSpan 
    let _run_target_args'_v2612 = v2702 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2706 : US3 = US3_2
    let v2707 : US4 = US4_3(v2706)
    let v2708 : string = $"date_time.get_utc_offset / target: {v2707}"
    let v2709 : System.TimeSpan = failwith<System.TimeSpan> v2708
    let _run_target_args'_v2612 = v2709 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2713 : US3 = US3_0
    let v2714 : US4 = US4_4(v2713)
    let v2715 : string = $"date_time.get_utc_offset / target: {v2714}"
    let v2716 : System.TimeSpan = failwith<System.TimeSpan> v2715
    let _run_target_args'_v2612 = v2716 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2720 : US3 = US3_0
    let v2721 : US4 = US4_5(v2720)
    let v2722 : string = $"date_time.get_utc_offset / target: {v2721}"
    let v2723 : System.TimeSpan = failwith<System.TimeSpan> v2722
    let _run_target_args'_v2612 = v2723 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2726 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2731 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2732 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2733 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2732 
    let _run_target_args'_v2731 = v2733 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2735 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2735 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2739 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2739 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2743 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2743 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2747 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2731 = v2747 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2750 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2731 = v2750 
    #endif
#else
    let v2751 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2731 = v2751 
    #endif
    let v2752 : System.TimeZoneInfo = _run_target_args'_v2731 
    let v2758 : (System.DateTime -> System.TimeSpan) = v2726 v2752
    let v2759 : System.TimeSpan = v2758 v1
    let _run_target_args'_v2612 = v2759 
    #endif
#else
    let v2760 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2765 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2766 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2767 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2766 
    let _run_target_args'_v2765 = v2767 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2769 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2769 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2773 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2773 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2777 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2777 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2781 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2765 = v2781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2784 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2765 = v2784 
    #endif
#else
    let v2785 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2765 = v2785 
    #endif
    let v2786 : System.TimeZoneInfo = _run_target_args'_v2765 
    let v2792 : (System.DateTime -> System.TimeSpan) = v2760 v2786
    let v2793 : System.TimeSpan = v2792 v1
    let _run_target_args'_v2612 = v2793 
    #endif
    let v2794 : System.TimeSpan = _run_target_args'_v2612 
    let v2804 : (System.TimeSpan -> int32) = _.Hours
    let v2805 : int32 = v2804 v2794
    let v2808 : bool = v2805 > 0
    let v2809 : uint8 =
        if v2808 then
            1uy
        else
            0uy
    let v2810 : string = method86()
    (* run_target_args'
    let v2864 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2865 : string = "$0.toString($1)"
    let v2866 : string = Fable.Core.RustInterop.emitRustExpr struct (v2794, v2810) v2865 
    let _run_target_args'_v2864 = v2866 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2867 : string = "$0.toString($1)"
    let v2868 : string = Fable.Core.RustInterop.emitRustExpr struct (v2794, v2810) v2867 
    let _run_target_args'_v2864 = v2868 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2869 : string = "$0.toString($1)"
    let v2870 : string = Fable.Core.RustInterop.emitRustExpr struct (v2794, v2810) v2869 
    let _run_target_args'_v2864 = v2870 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2871 : string = v2794.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2864 = v2871 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2872 : string = v2794.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2864 = v2872 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2874 : string = v2794.ToString v2810 
    let _run_target_args'_v2864 = v2874 
    #endif
#else
    let v2927 : string = v2794.ToString v2810 
    let _run_target_args'_v2864 = v2927 
    #endif
    let v2979 : string = _run_target_args'_v2864 
    let v3034 : string = $"{v2809}{v2979}"
    let v3036 : (System.Guid -> string) = _.ToString()
    let v3037 : string = v3036 v0
    let v3040 : int32 = v2559.Length
    let v3041 : int32 = v3034.Length
    let v3042 : int32 = v3040 + v3041
    let v3044 : (string -> int32) = String.length
    let v3045 : int32 = v3044 v3037
    let v3053 : int32 = v3042 |> int32 
    let v3066 : int32 = v3045 |> int32 
    let v3074 : int32 = v3066 - 1
    let v3076 : string = v3037.[int v3053..int v3074]
    let v3080 : string = $"{v2559}{v3034}{v3076}"
    (* run_target_args'
    let v3085 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3087 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3087 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3091 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3091 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3095 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3085 = v3095 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3099 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3099 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3103 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3107 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3107 
    #endif
#else
    let v3111 : System.Guid = v3080 |> System.Guid 
    let _run_target_args'_v3085 = v3111 
    #endif
    let v3114 : System.Guid = _run_target_args'_v3085 
    let _run_target_args'_v569 = v3114 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3120 : string = method85()
    let v3122 : bool = v3120 = ""
    let v3124 : string =
        if v3122 then
            let v3123 : string = "M-d-y hh:mm:ss tt"
            v3123
        else
            v3120
    let v3125 : (string -> string) = v1.ToString
    let v3126 : string = v3125 v3124
    (* run_target_args'
    let v3145 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3146 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3147 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3146 
    let _run_target_args'_v3145 = v3147 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3149 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3149 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3153 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3153 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3157 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3157 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3161 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3145 = v3161 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3164 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3145 = v3164 
    #endif
#else
    let v3165 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3145 = v3165 
    #endif
    let v3166 : System.TimeZoneInfo = _run_target_args'_v3145 
    (* run_target_args'
    let v3179 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3183 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3184 : (System.DateTime -> int64) = _.Ticks
    let v3185 : int64 = v3184 v1
    let _run_target_args'_v3183 = v3185 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3186 : (System.DateTime -> int64) = _.Ticks
    let v3187 : int64 = v3186 v1
    let _run_target_args'_v3183 = v3187 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3189 : int64 = null |> unbox<int64>
    let _run_target_args'_v3183 = v3189 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3192 : (System.DateTime -> int64) = _.Ticks
    let v3193 : int64 = v3192 v1
    let _run_target_args'_v3183 = v3193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3194 : (System.DateTime -> int64) = _.Ticks
    let v3195 : int64 = v3194 v1
    let _run_target_args'_v3183 = v3195 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3196 : (System.DateTime -> int64) = _.Ticks
    let v3197 : int64 = v3196 v1
    let _run_target_args'_v3183 = v3197 
    #endif
#else
    let v3198 : (System.DateTime -> int64) = _.Ticks
    let v3199 : int64 = v3198 v1
    let _run_target_args'_v3183 = v3199 
    #endif
    let v3200 : int64 = _run_target_args'_v3183 
    let v3220 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3221 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3200) v3220 
    let v3223 : System.TimeSpan = v3221 |> System.TimeSpan 
    let _run_target_args'_v3179 = v3223 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3229 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3230 : (System.DateTime -> int64) = _.Ticks
    let v3231 : int64 = v3230 v1
    let _run_target_args'_v3229 = v3231 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3232 : (System.DateTime -> int64) = _.Ticks
    let v3233 : int64 = v3232 v1
    let _run_target_args'_v3229 = v3233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3235 : int64 = null |> unbox<int64>
    let _run_target_args'_v3229 = v3235 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3238 : (System.DateTime -> int64) = _.Ticks
    let v3239 : int64 = v3238 v1
    let _run_target_args'_v3229 = v3239 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3240 : (System.DateTime -> int64) = _.Ticks
    let v3241 : int64 = v3240 v1
    let _run_target_args'_v3229 = v3241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3242 : (System.DateTime -> int64) = _.Ticks
    let v3243 : int64 = v3242 v1
    let _run_target_args'_v3229 = v3243 
    #endif
#else
    let v3244 : (System.DateTime -> int64) = _.Ticks
    let v3245 : int64 = v3244 v1
    let _run_target_args'_v3229 = v3245 
    #endif
    let v3246 : int64 = _run_target_args'_v3229 
    let v3266 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3267 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3246) v3266 
    let v3269 : System.TimeSpan = v3267 |> System.TimeSpan 
    let _run_target_args'_v3179 = v3269 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3273 : US3 = US3_2
    let v3274 : US4 = US4_3(v3273)
    let v3275 : string = $"date_time.get_utc_offset / target: {v3274}"
    let v3276 : System.TimeSpan = failwith<System.TimeSpan> v3275
    let _run_target_args'_v3179 = v3276 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3280 : US3 = US3_0
    let v3281 : US4 = US4_4(v3280)
    let v3282 : string = $"date_time.get_utc_offset / target: {v3281}"
    let v3283 : System.TimeSpan = failwith<System.TimeSpan> v3282
    let _run_target_args'_v3179 = v3283 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3287 : US3 = US3_0
    let v3288 : US4 = US4_5(v3287)
    let v3289 : string = $"date_time.get_utc_offset / target: {v3288}"
    let v3290 : System.TimeSpan = failwith<System.TimeSpan> v3289
    let _run_target_args'_v3179 = v3290 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3293 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3298 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3299 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3300 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3299 
    let _run_target_args'_v3298 = v3300 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3302 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3302 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3306 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3306 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3310 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3310 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3314 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3298 = v3314 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3317 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3298 = v3317 
    #endif
#else
    let v3318 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3298 = v3318 
    #endif
    let v3319 : System.TimeZoneInfo = _run_target_args'_v3298 
    let v3325 : (System.DateTime -> System.TimeSpan) = v3293 v3319
    let v3326 : System.TimeSpan = v3325 v1
    let _run_target_args'_v3179 = v3326 
    #endif
#else
    let v3327 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3332 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3333 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3334 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3333 
    let _run_target_args'_v3332 = v3334 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3336 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3336 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3340 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3340 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3344 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3344 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3348 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3332 = v3348 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3351 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3332 = v3351 
    #endif
#else
    let v3352 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3332 = v3352 
    #endif
    let v3353 : System.TimeZoneInfo = _run_target_args'_v3332 
    let v3359 : (System.DateTime -> System.TimeSpan) = v3327 v3353
    let v3360 : System.TimeSpan = v3359 v1
    let _run_target_args'_v3179 = v3360 
    #endif
    let v3361 : System.TimeSpan = _run_target_args'_v3179 
    let v3371 : (System.TimeSpan -> int32) = _.Hours
    let v3372 : int32 = v3371 v3361
    let v3375 : bool = v3372 > 0
    let v3376 : uint8 =
        if v3375 then
            1uy
        else
            0uy
    let v3377 : string = method86()
    (* run_target_args'
    let v3431 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3432 : string = "$0.toString($1)"
    let v3433 : string = Fable.Core.RustInterop.emitRustExpr struct (v3361, v3377) v3432 
    let _run_target_args'_v3431 = v3433 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3434 : string = "$0.toString($1)"
    let v3435 : string = Fable.Core.RustInterop.emitRustExpr struct (v3361, v3377) v3434 
    let _run_target_args'_v3431 = v3435 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3436 : string = "$0.toString($1)"
    let v3437 : string = Fable.Core.RustInterop.emitRustExpr struct (v3361, v3377) v3436 
    let _run_target_args'_v3431 = v3437 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3438 : string = v3361.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3431 = v3438 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3439 : string = v3361.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3431 = v3439 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3441 : string = v3361.ToString v3377 
    let _run_target_args'_v3431 = v3441 
    #endif
#else
    let v3494 : string = v3361.ToString v3377 
    let _run_target_args'_v3431 = v3494 
    #endif
    let v3546 : string = _run_target_args'_v3431 
    let v3601 : string = $"{v3376}{v3546}"
    let v3603 : (System.Guid -> string) = _.ToString()
    let v3604 : string = v3603 v0
    let v3607 : int32 = v3126.Length
    let v3608 : int32 = v3601.Length
    let v3609 : int32 = v3607 + v3608
    let v3611 : (string -> int32) = String.length
    let v3612 : int32 = v3611 v3604
    let v3620 : int32 = v3609 |> int32 
    let v3633 : int32 = v3612 |> int32 
    let v3641 : int32 = v3633 - 1
    let v3643 : string = v3604.[int v3620..int v3641]
    let v3647 : string = $"{v3126}{v3601}{v3643}"
    (* run_target_args'
    let v3652 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3654 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3654 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3658 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3658 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3662 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3652 = v3662 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3666 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3666 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3670 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3670 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3674 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3674 
    #endif
#else
    let v3678 : System.Guid = v3647 |> System.Guid 
    let _run_target_args'_v3652 = v3678 
    #endif
    let v3681 : System.Guid = _run_target_args'_v3652 
    let _run_target_args'_v569 = v3681 
    #endif
#else
    let v3687 : string = method85()
    let v3689 : bool = v3687 = ""
    let v3691 : string =
        if v3689 then
            let v3690 : string = "M-d-y hh:mm:ss tt"
            v3690
        else
            v3687
    let v3692 : (string -> string) = v1.ToString
    let v3693 : string = v3692 v3691
    (* run_target_args'
    let v3712 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3713 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3714 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3713 
    let _run_target_args'_v3712 = v3714 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3716 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3716 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3720 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3720 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3724 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3724 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3728 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3712 = v3728 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3731 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3712 = v3731 
    #endif
#else
    let v3732 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3712 = v3732 
    #endif
    let v3733 : System.TimeZoneInfo = _run_target_args'_v3712 
    (* run_target_args'
    let v3746 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3750 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3751 : (System.DateTime -> int64) = _.Ticks
    let v3752 : int64 = v3751 v1
    let _run_target_args'_v3750 = v3752 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3753 : (System.DateTime -> int64) = _.Ticks
    let v3754 : int64 = v3753 v1
    let _run_target_args'_v3750 = v3754 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3756 : int64 = null |> unbox<int64>
    let _run_target_args'_v3750 = v3756 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3759 : (System.DateTime -> int64) = _.Ticks
    let v3760 : int64 = v3759 v1
    let _run_target_args'_v3750 = v3760 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3761 : (System.DateTime -> int64) = _.Ticks
    let v3762 : int64 = v3761 v1
    let _run_target_args'_v3750 = v3762 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3763 : (System.DateTime -> int64) = _.Ticks
    let v3764 : int64 = v3763 v1
    let _run_target_args'_v3750 = v3764 
    #endif
#else
    let v3765 : (System.DateTime -> int64) = _.Ticks
    let v3766 : int64 = v3765 v1
    let _run_target_args'_v3750 = v3766 
    #endif
    let v3767 : int64 = _run_target_args'_v3750 
    let v3787 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3788 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3767) v3787 
    let v3790 : System.TimeSpan = v3788 |> System.TimeSpan 
    let _run_target_args'_v3746 = v3790 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3796 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3797 : (System.DateTime -> int64) = _.Ticks
    let v3798 : int64 = v3797 v1
    let _run_target_args'_v3796 = v3798 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3799 : (System.DateTime -> int64) = _.Ticks
    let v3800 : int64 = v3799 v1
    let _run_target_args'_v3796 = v3800 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3802 : int64 = null |> unbox<int64>
    let _run_target_args'_v3796 = v3802 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3805 : (System.DateTime -> int64) = _.Ticks
    let v3806 : int64 = v3805 v1
    let _run_target_args'_v3796 = v3806 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3807 : (System.DateTime -> int64) = _.Ticks
    let v3808 : int64 = v3807 v1
    let _run_target_args'_v3796 = v3808 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3809 : (System.DateTime -> int64) = _.Ticks
    let v3810 : int64 = v3809 v1
    let _run_target_args'_v3796 = v3810 
    #endif
#else
    let v3811 : (System.DateTime -> int64) = _.Ticks
    let v3812 : int64 = v3811 v1
    let _run_target_args'_v3796 = v3812 
    #endif
    let v3813 : int64 = _run_target_args'_v3796 
    let v3833 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3834 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3813) v3833 
    let v3836 : System.TimeSpan = v3834 |> System.TimeSpan 
    let _run_target_args'_v3746 = v3836 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3840 : US3 = US3_2
    let v3841 : US4 = US4_3(v3840)
    let v3842 : string = $"date_time.get_utc_offset / target: {v3841}"
    let v3843 : System.TimeSpan = failwith<System.TimeSpan> v3842
    let _run_target_args'_v3746 = v3843 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3847 : US3 = US3_0
    let v3848 : US4 = US4_4(v3847)
    let v3849 : string = $"date_time.get_utc_offset / target: {v3848}"
    let v3850 : System.TimeSpan = failwith<System.TimeSpan> v3849
    let _run_target_args'_v3746 = v3850 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3854 : US3 = US3_0
    let v3855 : US4 = US4_5(v3854)
    let v3856 : string = $"date_time.get_utc_offset / target: {v3855}"
    let v3857 : System.TimeSpan = failwith<System.TimeSpan> v3856
    let _run_target_args'_v3746 = v3857 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3860 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3865 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3866 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3867 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3866 
    let _run_target_args'_v3865 = v3867 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3869 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3869 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3873 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3873 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3877 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3877 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3881 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3865 = v3881 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3884 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3865 = v3884 
    #endif
#else
    let v3885 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3865 = v3885 
    #endif
    let v3886 : System.TimeZoneInfo = _run_target_args'_v3865 
    let v3892 : (System.DateTime -> System.TimeSpan) = v3860 v3886
    let v3893 : System.TimeSpan = v3892 v1
    let _run_target_args'_v3746 = v3893 
    #endif
#else
    let v3894 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3899 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3900 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3901 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3900 
    let _run_target_args'_v3899 = v3901 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3903 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3903 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3907 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3907 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3911 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3911 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3899 = v3915 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3918 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3899 = v3918 
    #endif
#else
    let v3919 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3899 = v3919 
    #endif
    let v3920 : System.TimeZoneInfo = _run_target_args'_v3899 
    let v3926 : (System.DateTime -> System.TimeSpan) = v3894 v3920
    let v3927 : System.TimeSpan = v3926 v1
    let _run_target_args'_v3746 = v3927 
    #endif
    let v3928 : System.TimeSpan = _run_target_args'_v3746 
    let v3938 : (System.TimeSpan -> int32) = _.Hours
    let v3939 : int32 = v3938 v3928
    let v3942 : bool = v3939 > 0
    let v3943 : uint8 =
        if v3942 then
            1uy
        else
            0uy
    let v3944 : string = method86()
    (* run_target_args'
    let v3998 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3999 : string = "$0.toString($1)"
    let v4000 : string = Fable.Core.RustInterop.emitRustExpr struct (v3928, v3944) v3999 
    let _run_target_args'_v3998 = v4000 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4001 : string = "$0.toString($1)"
    let v4002 : string = Fable.Core.RustInterop.emitRustExpr struct (v3928, v3944) v4001 
    let _run_target_args'_v3998 = v4002 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4003 : string = "$0.toString($1)"
    let v4004 : string = Fable.Core.RustInterop.emitRustExpr struct (v3928, v3944) v4003 
    let _run_target_args'_v3998 = v4004 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4005 : string = v3928.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3998 = v4005 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4006 : string = v3928.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3998 = v4006 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4008 : string = v3928.ToString v3944 
    let _run_target_args'_v3998 = v4008 
    #endif
#else
    let v4061 : string = v3928.ToString v3944 
    let _run_target_args'_v3998 = v4061 
    #endif
    let v4113 : string = _run_target_args'_v3998 
    let v4168 : string = $"{v3943}{v4113}"
    let v4170 : (System.Guid -> string) = _.ToString()
    let v4171 : string = v4170 v0
    let v4174 : int32 = v3693.Length
    let v4175 : int32 = v4168.Length
    let v4176 : int32 = v4174 + v4175
    let v4178 : (string -> int32) = String.length
    let v4179 : int32 = v4178 v4171
    let v4187 : int32 = v4176 |> int32 
    let v4200 : int32 = v4179 |> int32 
    let v4208 : int32 = v4200 - 1
    let v4210 : string = v4171.[int v4187..int v4208]
    let v4214 : string = $"{v3693}{v4168}{v4210}"
    (* run_target_args'
    let v4219 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4221 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4221 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4225 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4225 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4229 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4219 = v4229 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4233 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4233 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4237 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4237 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4241 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4241 
    #endif
#else
    let v4245 : System.Guid = v4214 |> System.Guid 
    let _run_target_args'_v4219 = v4245 
    #endif
    let v4248 : System.Guid = _run_target_args'_v4219 
    let _run_target_args'_v569 = v4248 
    #endif
    let v4254 : System.Guid = _run_target_args'_v569 
    v4254
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
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "dir"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "error"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    (* run_target_args'
    let v81 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v82 : string = "format!(\"{:#?}\", $0)"
    let v83 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v82 
    let v84 : string = "fable_library_rust::String_::fromString($0)"
    let v85 : string = Fable.Core.RustInterop.emitRustExpr v83 v84 
    let _run_target_args'_v81 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "format!(\"{:#?}\", $0)"
    let v87 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v86 
    let v88 : string = "fable_library_rust::String_::fromString($0)"
    let v89 : string = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let _run_target_args'_v81 = v89 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v90 : string = "format!(\"{:#?}\", $0)"
    let v91 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v90 
    let v92 : string = "fable_library_rust::String_::fromString($0)"
    let v93 : string = Fable.Core.RustInterop.emitRustExpr v91 v92 
    let _run_target_args'_v81 = v93 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v95 : string = $"%A{v1}"
    let _run_target_args'_v81 = v95 
    #endif
#if FABLE_COMPILER_PYTHON
    let v99 : string = $"%A{v1}"
    let _run_target_args'_v81 = v99 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v103 : string = $"%A{v1}"
    let _run_target_args'_v81 = v103 
    #endif
#else
    let v107 : string = $"%A{v1}"
    let _run_target_args'_v81 = v107 
    #endif
    let v110 : string = _run_target_args'_v81 
    let v117 : string = $"{v110}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure6(v3, v117)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v127 : string = " }"
    let v128 : string = $"{v127}"
    let v131 : unit = ()
    let v132 : (unit -> unit) = closure6(v3, v128)
    let v133 : unit = (fun () -> v132 (); v131) ()
    let v136 : string = v3.l0
    v136
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method52()
        let v49 : string = method97(v29, v30, v31, v32, v33, v34, v47, v48, v0, v1)
        method24(v49)
and method100 (v0 : string) : string =
    let v1 : string = method18()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v9 : unit = ()
    let v10 : (unit -> unit) = closure6(v2, v6)
    let v11 : unit = (fun () -> v10 (); v9) ()
    let v16 : string = "dir"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure6(v2, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v27 : string = " = "
    let v28 : string = $"{v27}"
    let v31 : unit = ()
    let v32 : (unit -> unit) = closure6(v2, v28)
    let v33 : unit = (fun () -> v32 (); v31) ()
    let v37 : string = $"{v0}"
    let v40 : unit = ()
    let v41 : (unit -> unit) = closure6(v2, v37)
    let v42 : unit = (fun () -> v41 (); v40) ()
    let v47 : string = " }"
    let v48 : string = $"{v47}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure6(v2, v48)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v56 : string = v2.l0
    v56
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
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure0()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut0, v29 : Mut1, v30 : Mut2, v31 : Mut3, v32 : Mut4, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method34()
        let v48 : string = method99(v28, v29, v30, v31, v32, v33, v46, v47, v0)
        method24(v48)
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
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "dir"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "result"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method16()
        let v49 : string = method104(v29, v30, v31, v32, v33, v34, v47, v48, v0, v1)
        method24(v49)
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
    let v156 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v157 : string = "std::fs::create_dir_all(&*$0)"
    let v158 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v157 
    let v159 : (std_io_Error -> std_string_String) = method94()
    (* run_target_args'
    let v161 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v162 : string = "$0.map_err(|x| $1(x))"
    let v163 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v158, v159) v162 
    let _run_target_args'_v161 = v163 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v164 : string = "$0.map_err(|x| $1(x))"
    let v165 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v158, v159) v164 
    let _run_target_args'_v161 = v165 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v166 : string = "$0.map_err(|x| $1(x))"
    let v167 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v158, v159) v166 
    let _run_target_args'_v161 = v167 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v168 : Result<unit, std_string_String> = match v158 with Ok x -> Ok x | Error x -> Error (v159 x)
    let _run_target_args'_v161 = v168 
    #endif
#if FABLE_COMPILER_PYTHON
    let v169 : Result<unit, std_string_String> = match v158 with Ok x -> Ok x | Error x -> Error (v159 x)
    let _run_target_args'_v161 = v169 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v170 : Result<unit, std_string_String> = match v158 with Ok x -> Ok x | Error x -> Error (v159 x)
    let _run_target_args'_v161 = v170 
    #endif
#else
    let v171 : Result<unit, std_string_String> = match v158 with Ok x -> Ok x | Error x -> Error (v159 x)
    let _run_target_args'_v161 = v171 
    #endif
    let v172 : Result<unit, std_string_String> = _run_target_args'_v161 
    let v175 : (unit -> US13) = method95()
    let v176 : (std_string_String -> US13) = method96()
    let v178 : US13 = match v172 with Ok () -> v175 () | Error x -> v176 x
    match v178 with
    | US13_1(v232) -> (* Error *)
        let v233 : unit = ()
        let v234 : (unit -> unit) = closure43(v0, v232)
        let v235 : unit = (fun () -> v234 (); v233) ()
        ()
    | US13_0 -> (* Ok *)
        let v181 : unit = ()
        let v182 : (unit -> unit) = closure44(v0)
        let v183 : unit = (fun () -> v182 (); v181) ()
        ()
    (* run_target_args'
    let v288 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v289 : (unit -> unit) = method101(v0)
    let v290 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v289 "$0()" )
    let _run_target_args'_v288 = v290 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v291 : (unit -> unit) = method101(v0)
    let v292 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v291 "$0()" )
    let _run_target_args'_v288 = v292 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v293 : (unit -> unit) = method101(v0)
    let v294 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v293 "$0()" )
    let _run_target_args'_v288 = v294 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v295 : (unit -> unit) = method102(v0)
    let v296 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v295 () }
    let _run_target_args'_v288 = v296 
    #endif
#if FABLE_COMPILER_PYTHON
    let v297 : (unit -> unit) = method102(v0)
    let v298 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v297 () }
    let _run_target_args'_v288 = v298 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v299 : (unit -> unit) = method102(v0)
    let v300 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v299 () }
    let _run_target_args'_v288 = v300 
    #endif
#else
    let v301 : (unit -> unit) = method102(v0)
    let v302 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v301 () }
    let _run_target_args'_v288 = v302 
    #endif
    let v303 : System.IDisposable = _run_target_args'_v288 
    let _run_target_args'_v156 = v303 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v308 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v156 = v308 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v312 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v156 = v312 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v315 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v320 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v322 : bool = null |> unbox<bool>
    let _run_target_args'_v320 = v322 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v326 : bool = null |> unbox<bool>
    let _run_target_args'_v320 = v326 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v330 : bool = null |> unbox<bool>
    let _run_target_args'_v320 = v330 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v334 : bool = null |> unbox<bool>
    let _run_target_args'_v320 = v334 
    #endif
#if FABLE_COMPILER_PYTHON
    let v338 : bool = null |> unbox<bool>
    let _run_target_args'_v320 = v338 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v342 : bool = null |> unbox<bool>
    let _run_target_args'_v320 = v342 
    #endif
#else
    let v345 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v346 : bool = v345 v315
    let _run_target_args'_v320 = v346 
    #endif
    let v347 : bool = _run_target_args'_v320 
    let v353 : bool = v347 = false
    if v353 then
        (* run_target_args'
        let v358 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v360 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v358 = v360 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v364 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v358 = v364 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v368 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v358 = v368 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v372 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v358 = v372 
        #endif
#if FABLE_COMPILER_PYTHON
        let v376 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v358 = v376 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v380 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v358 = v380 
        #endif
#else
        let v383 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v384 : System.DateTime = v383 v315
        let _run_target_args'_v358 = v384 
        #endif
        let v385 : System.DateTime = _run_target_args'_v358 
        let v391 : _ = {| Exists = v347; CreationTime = v385 |}
        let v393 : string = $"%A{v391}"
        let v396 : unit = ()
        let v397 : (unit -> unit) = closure46(v0, v393)
        let v398 : unit = (fun () -> v397 (); v396) ()
        ()
    (* run_target_args'
    let v451 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v452 : (unit -> unit) = method106(v0)
    let v453 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v452 "$0()" )
    let _run_target_args'_v451 = v453 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v454 : (unit -> unit) = method106(v0)
    let v455 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v454 "$0()" )
    let _run_target_args'_v451 = v455 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v456 : (unit -> unit) = method106(v0)
    let v457 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v456 "$0()" )
    let _run_target_args'_v451 = v457 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v458 : (unit -> unit) = method107(v0)
    let v459 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v458 () }
    let _run_target_args'_v451 = v459 
    #endif
#if FABLE_COMPILER_PYTHON
    let v460 : (unit -> unit) = method107(v0)
    let v461 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v460 () }
    let _run_target_args'_v451 = v461 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v462 : (unit -> unit) = method107(v0)
    let v463 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v462 () }
    let _run_target_args'_v451 = v463 
    #endif
#else
    let v464 : (unit -> unit) = method107(v0)
    let v465 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v464 () }
    let _run_target_args'_v451 = v465 
    #endif
    let v466 : System.IDisposable = _run_target_args'_v451 
    let _run_target_args'_v156 = v466 
    #endif
#if FABLE_COMPILER_PYTHON
    let v470 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v475 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v477 : bool = null |> unbox<bool>
    let _run_target_args'_v475 = v477 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v481 : bool = null |> unbox<bool>
    let _run_target_args'_v475 = v481 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v485 : bool = null |> unbox<bool>
    let _run_target_args'_v475 = v485 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v489 : bool = null |> unbox<bool>
    let _run_target_args'_v475 = v489 
    #endif
#if FABLE_COMPILER_PYTHON
    let v493 : bool = null |> unbox<bool>
    let _run_target_args'_v475 = v493 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v497 : bool = null |> unbox<bool>
    let _run_target_args'_v475 = v497 
    #endif
#else
    let v500 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v501 : bool = v500 v470
    let _run_target_args'_v475 = v501 
    #endif
    let v502 : bool = _run_target_args'_v475 
    let v508 : bool = v502 = false
    if v508 then
        (* run_target_args'
        let v513 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v515 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v513 = v515 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v519 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v513 = v519 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v523 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v513 = v523 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v527 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v513 = v527 
        #endif
#if FABLE_COMPILER_PYTHON
        let v531 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v513 = v531 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v535 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v513 = v535 
        #endif
#else
        let v538 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v539 : System.DateTime = v538 v470
        let _run_target_args'_v513 = v539 
        #endif
        let v540 : System.DateTime = _run_target_args'_v513 
        let v546 : _ = {| Exists = v502; CreationTime = v540 |}
        let v548 : string = $"%A{v546}"
        let v551 : unit = ()
        let v552 : (unit -> unit) = closure46(v0, v548)
        let v553 : unit = (fun () -> v552 (); v551) ()
        ()
    (* run_target_args'
    let v606 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v607 : (unit -> unit) = method106(v0)
    let v608 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v607 "$0()" )
    let _run_target_args'_v606 = v608 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v609 : (unit -> unit) = method106(v0)
    let v610 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v609 "$0()" )
    let _run_target_args'_v606 = v610 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v611 : (unit -> unit) = method106(v0)
    let v612 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v611 "$0()" )
    let _run_target_args'_v606 = v612 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v613 : (unit -> unit) = method107(v0)
    let v614 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v613 () }
    let _run_target_args'_v606 = v614 
    #endif
#if FABLE_COMPILER_PYTHON
    let v615 : (unit -> unit) = method107(v0)
    let v616 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v615 () }
    let _run_target_args'_v606 = v616 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v617 : (unit -> unit) = method107(v0)
    let v618 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v617 () }
    let _run_target_args'_v606 = v618 
    #endif
#else
    let v619 : (unit -> unit) = method107(v0)
    let v620 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v619 () }
    let _run_target_args'_v606 = v620 
    #endif
    let v621 : System.IDisposable = _run_target_args'_v606 
    let _run_target_args'_v156 = v621 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v625 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v630 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v632 : bool = null |> unbox<bool>
    let _run_target_args'_v630 = v632 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v636 : bool = null |> unbox<bool>
    let _run_target_args'_v630 = v636 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v640 : bool = null |> unbox<bool>
    let _run_target_args'_v630 = v640 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v644 : bool = null |> unbox<bool>
    let _run_target_args'_v630 = v644 
    #endif
#if FABLE_COMPILER_PYTHON
    let v648 : bool = null |> unbox<bool>
    let _run_target_args'_v630 = v648 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v652 : bool = null |> unbox<bool>
    let _run_target_args'_v630 = v652 
    #endif
#else
    let v655 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v656 : bool = v655 v625
    let _run_target_args'_v630 = v656 
    #endif
    let v657 : bool = _run_target_args'_v630 
    let v663 : bool = v657 = false
    if v663 then
        (* run_target_args'
        let v668 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v670 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v668 = v670 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v674 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v668 = v674 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v678 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v668 = v678 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v682 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v668 = v682 
        #endif
#if FABLE_COMPILER_PYTHON
        let v686 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v668 = v686 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v690 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v668 = v690 
        #endif
#else
        let v693 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v694 : System.DateTime = v693 v625
        let _run_target_args'_v668 = v694 
        #endif
        let v695 : System.DateTime = _run_target_args'_v668 
        let v701 : _ = {| Exists = v657; CreationTime = v695 |}
        let v703 : string = $"%A{v701}"
        let v706 : unit = ()
        let v707 : (unit -> unit) = closure46(v0, v703)
        let v708 : unit = (fun () -> v707 (); v706) ()
        ()
    (* run_target_args'
    let v761 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v762 : (unit -> unit) = method106(v0)
    let v763 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v762 "$0()" )
    let _run_target_args'_v761 = v763 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v764 : (unit -> unit) = method106(v0)
    let v765 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v764 "$0()" )
    let _run_target_args'_v761 = v765 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v766 : (unit -> unit) = method106(v0)
    let v767 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v766 "$0()" )
    let _run_target_args'_v761 = v767 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v768 : (unit -> unit) = method107(v0)
    let v769 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v768 () }
    let _run_target_args'_v761 = v769 
    #endif
#if FABLE_COMPILER_PYTHON
    let v770 : (unit -> unit) = method107(v0)
    let v771 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v770 () }
    let _run_target_args'_v761 = v771 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v772 : (unit -> unit) = method107(v0)
    let v773 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v772 () }
    let _run_target_args'_v761 = v773 
    #endif
#else
    let v774 : (unit -> unit) = method107(v0)
    let v775 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v774 () }
    let _run_target_args'_v761 = v775 
    #endif
    let v776 : System.IDisposable = _run_target_args'_v761 
    let _run_target_args'_v156 = v776 
    #endif
#else
    let v780 : System_IO_DirectoryInfo = method103(v0)
    (* run_target_args'
    let v785 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v787 : bool = null |> unbox<bool>
    let _run_target_args'_v785 = v787 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v791 : bool = null |> unbox<bool>
    let _run_target_args'_v785 = v791 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v795 : bool = null |> unbox<bool>
    let _run_target_args'_v785 = v795 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v799 : bool = null |> unbox<bool>
    let _run_target_args'_v785 = v799 
    #endif
#if FABLE_COMPILER_PYTHON
    let v803 : bool = null |> unbox<bool>
    let _run_target_args'_v785 = v803 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v807 : bool = null |> unbox<bool>
    let _run_target_args'_v785 = v807 
    #endif
#else
    let v810 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v811 : bool = v810 v780
    let _run_target_args'_v785 = v811 
    #endif
    let v812 : bool = _run_target_args'_v785 
    let v818 : bool = v812 = false
    if v818 then
        (* run_target_args'
        let v823 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v825 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v823 = v825 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v829 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v823 = v829 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v833 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v823 = v833 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v837 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v823 = v837 
        #endif
#if FABLE_COMPILER_PYTHON
        let v841 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v823 = v841 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v845 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v823 = v845 
        #endif
#else
        let v848 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v849 : System.DateTime = v848 v780
        let _run_target_args'_v823 = v849 
        #endif
        let v850 : System.DateTime = _run_target_args'_v823 
        let v856 : _ = {| Exists = v812; CreationTime = v850 |}
        let v858 : string = $"%A{v856}"
        let v861 : unit = ()
        let v862 : (unit -> unit) = closure46(v0, v858)
        let v863 : unit = (fun () -> v862 (); v861) ()
        ()
    (* run_target_args'
    let v916 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v917 : (unit -> unit) = method106(v0)
    let v918 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v917 "$0()" )
    let _run_target_args'_v916 = v918 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v919 : (unit -> unit) = method106(v0)
    let v920 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v919 "$0()" )
    let _run_target_args'_v916 = v920 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v921 : (unit -> unit) = method106(v0)
    let v922 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v921 "$0()" )
    let _run_target_args'_v916 = v922 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v923 : (unit -> unit) = method107(v0)
    let v924 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v923 () }
    let _run_target_args'_v916 = v924 
    #endif
#if FABLE_COMPILER_PYTHON
    let v925 : (unit -> unit) = method107(v0)
    let v926 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v925 () }
    let _run_target_args'_v916 = v926 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v927 : (unit -> unit) = method107(v0)
    let v928 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v927 () }
    let _run_target_args'_v916 = v928 
    #endif
#else
    let v929 : (unit -> unit) = method107(v0)
    let v930 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v929 () }
    let _run_target_args'_v916 = v930 
    #endif
    let v931 : System.IDisposable = _run_target_args'_v916 
    let _run_target_args'_v156 = v931 
    #endif
    let v935 : System.IDisposable = _run_target_args'_v156 
    v935
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
        let v8 : string = v3 + v1 
        v6 v8
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
    let v105 : string = "$0.parent().map(std::path::PathBuf::from)"
    let v106 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v99 v105 
    let v107 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v108 : bool = Fable.Core.RustInterop.emitRustExpr v106 v107 
    let v109 : string = "x"
    let v110 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr () v109 
    (* run_target_args'
    let v115 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v116 : string = "$0.display()"
    let v117 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v110 v116 
    let _run_target_args'_v115 = v117 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v118 : string = "$0.display()"
    let v119 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v110 v118 
    let _run_target_args'_v115 = v119 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v120 : string = "$0.display()"
    let v121 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v110 v120 
    let _run_target_args'_v115 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v123 : std_path_Display = v110 |> unbox<std_path_Display>
    let _run_target_args'_v115 = v123 
    #endif
#if FABLE_COMPILER_PYTHON
    let v127 : std_path_Display = v110 |> unbox<std_path_Display>
    let _run_target_args'_v115 = v127 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v131 : std_path_Display = v110 |> unbox<std_path_Display>
    let _run_target_args'_v115 = v131 
    #endif
#else
    let v135 : std_path_Display = v110 |> unbox<std_path_Display>
    let _run_target_args'_v115 = v135 
    #endif
    let v138 : std_path_Display = _run_target_args'_v115 
    (* run_target_args'
    let v148 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v149 : string = "format!(\"{}\", $0)"
    let v150 : std_string_String = Fable.Core.RustInterop.emitRustExpr v138 v149 
    let _run_target_args'_v148 = v150 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v151 : string = "format!(\"{}\", $0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v138 v151 
    let _run_target_args'_v148 = v152 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v153 : string = "format!(\"{}\", $0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v138 v153 
    let _run_target_args'_v148 = v154 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v156 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v148 = v156 
    #endif
#if FABLE_COMPILER_PYTHON
    let v160 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v148 = v160 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v164 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v148 = v164 
    #endif
#else
    let v168 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v148 = v168 
    #endif
    let v171 : std_string_String = _run_target_args'_v148 
    let v177 : string = "fable_library_rust::String_::fromString($0)"
    let v178 : string = Fable.Core.RustInterop.emitRustExpr v171 v177 
    let v179 : string = "true; $0 })"
    let v180 : bool = Fable.Core.RustInterop.emitRustExpr v178 v179 
    let v181 : string = "_optionm_map_"
    let v182 : string option = Fable.Core.RustInterop.emitRustExpr () v181 
    let _run_target_args'_v5 = v182 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string option = None
    let _run_target_args'_v5 = v184 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v188 : string option = None
    let _run_target_args'_v5 = v188 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v191 : string = "path"
    let v192 : IPathDirname = Fable.Core.JsInterop.importAll v191 
    let v193 : string = "v192.dirname($0)"
    let v194 : string = Fable.Core.JsInterop.emitJsExpr v0 v193 
    let v195 : bool = v194 = v0
    let v198 : US5 =
        if v195 then
            US5_1
        else
            US5_0(v194)
    let v209 : string option =
        match v198 with
        | US5_1 -> (* None *)
            let v205 : string option = None
            v205
        | US5_0(v199) -> (* Some *)
            let v201 : string option = Some v199 
            v201
    let _run_target_args'_v5 = v209 
    #endif
#if FABLE_COMPILER_PYTHON
    let v211 : string option = None
    let _run_target_args'_v5 = v211 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v215 : string option = None
    let _run_target_args'_v5 = v215 
    #endif
#else
    let v218 : (string -> System_IO_DirectoryInfo) = System.IO.Directory.GetParent
    let v219 : System_IO_DirectoryInfo = v218 v0
    let v221 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let v225 : bool = v219 = v221 
    let v267 : US5 =
        if v225 then
            US5_1
        else
            (* run_target_args'
            let v233 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v235 : string = null |> unbox<string>
            let _run_target_args'_v233 = v235 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v239 : string = null |> unbox<string>
            let _run_target_args'_v233 = v239 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v243 : string = null |> unbox<string>
            let _run_target_args'_v233 = v243 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v247 : string = null |> unbox<string>
            let _run_target_args'_v233 = v247 
            #endif
#if FABLE_COMPILER_PYTHON
            let v251 : string = null |> unbox<string>
            let _run_target_args'_v233 = v251 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v255 : string = null |> unbox<string>
            let _run_target_args'_v233 = v255 
            #endif
#else
            let v258 : (System_IO_DirectoryInfo -> string) = _.FullName
            let v259 : string = v258 v219
            let _run_target_args'_v233 = v259 
            #endif
            let v260 : string = _run_target_args'_v233 
            US5_0(v260)
    let v278 : string option =
        match v267 with
        | US5_1 -> (* None *)
            let v274 : string option = None
            v274
        | US5_0(v268) -> (* Some *)
            let v270 : string option = Some v268 
            v270
    let _run_target_args'_v5 = v278 
    #endif
    let v279 : string option = _run_target_args'_v5 
    v279
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
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method118(v3)
    let v36 : bool = v2 >= 11uy
    if v36 then
        let v37 : string = $"file_system.read_link / "
        let v38 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v39 : string = v37 + v38 
        (* run_target_args'
        let v44 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v45 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v46 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v39 v45 
        let _run_target_args'_v44 = v46 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v47 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v48 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v39 v47 
        let _run_target_args'_v44 = v48 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v49 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v50 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v39 v49 
        let _run_target_args'_v44 = v50 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v52 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v52 
        #endif
#if FABLE_COMPILER_PYTHON
        let v56 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v56 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v60 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v60 
        #endif
#else
        let v64 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v64 
        #endif
        let v67 : std_io_Error = _run_target_args'_v44 
        (* run_target_args'
        let v74 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v75 : string = "Err($0)"
        let v76 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v75 
        let _run_target_args'_v74 = v76 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v77 : string = "Err($0)"
        let v78 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v77 
        let _run_target_args'_v74 = v78 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v79 : string = "Err($0)"
        let v80 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v79 
        let _run_target_args'_v74 = v80 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v81 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v81 
        #endif
#if FABLE_COMPILER_PYTHON
        let v82 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v82 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v83 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v83 
        #endif
#else
        let v84 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v84 
        #endif
        let v85 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v74 
        v85
    else
        match v31 with
        | US5_0(v88) -> (* Some *)
            let v91 : string = ""
            let v92 : bool = v4 <> v91 
            if v92 then
                let v95 : uint8 = v2 + 1uy
                let v96 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v95
                let v97 : Result<std_path_PathBuf, std_io_Error> = v96 v88
                let v98 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v100 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v101 : string = "$0.map_err(|x| $1(x))"
                let v102 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v97, v98) v101 
                let _run_target_args'_v100 = v102 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v103 : string = "$0.map_err(|x| $1(x))"
                let v104 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v97, v98) v103 
                let _run_target_args'_v100 = v104 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v105 : string = "$0.map_err(|x| $1(x))"
                let v106 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v97, v98) v105 
                let _run_target_args'_v100 = v106 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v107 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v107 
                #endif
#if FABLE_COMPILER_PYTHON
                let v108 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v108 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v109 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v109 
                #endif
#else
                let v110 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v110 
                #endif
                let v111 : Result<std_path_PathBuf, string> = _run_target_args'_v100 
                let v114 : (std_path_PathBuf -> US14) = method113()
                let v115 : (string -> US14) = method114()
                let v117 : US14 = match v111 with Ok x -> v114 x | Error x -> v115 x
                match v117 with
                | US14_1(v273) -> (* Error *)
                    let v274 : string = $"file_system.read_link / "
                    let v275 : string = $"error': {v273} / error: {v35} / name: {v5}"
                    let v276 : string = v274 + v275 
                    (* run_target_args'
                    let v281 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v282 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v283 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v276 v282 
                    let _run_target_args'_v281 = v283 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v284 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v285 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v276 v284 
                    let _run_target_args'_v281 = v285 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v286 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v287 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v276 v286 
                    let _run_target_args'_v281 = v287 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v289 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v289 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v293 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v293 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v297 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v297 
                    #endif
#else
                    let v301 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v301 
                    #endif
                    let v304 : std_io_Error = _run_target_args'_v281 
                    (* run_target_args'
                    let v311 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v312 : string = "Err($0)"
                    let v313 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v304 v312 
                    let _run_target_args'_v311 = v313 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v314 : string = "Err($0)"
                    let v315 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v304 v314 
                    let _run_target_args'_v311 = v315 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v316 : string = "Err($0)"
                    let v317 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v304 v316 
                    let _run_target_args'_v311 = v317 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v318 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v318 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v319 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v319 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v320 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v320 
                    #endif
#else
                    let v321 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v321 
                    #endif
                    let v322 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v311 
                    v322
                | US14_0(v120) -> (* Ok *)
                    (* run_target_args'
                    let v125 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v126 : string = "$0.display()"
                    let v127 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v120 v126 
                    let _run_target_args'_v125 = v127 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v128 : string = "$0.display()"
                    let v129 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v120 v128 
                    let _run_target_args'_v125 = v129 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v130 : string = "$0.display()"
                    let v131 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v120 v130 
                    let _run_target_args'_v125 = v131 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v133 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v133 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v137 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v137 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v141 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v141 
                    #endif
#else
                    let v145 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v145 
                    #endif
                    let v148 : std_path_Display = _run_target_args'_v125 
                    let v155 : string = v148 |> string 
                    let v158 : string = method90(v155, v5)
                    (* run_target_args'
                    let v163 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v164 : string = "&*$0"
                    let v165 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v158 v164 
                    let _run_target_args'_v163 = v165 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v166 : string = "&*$0"
                    let v167 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v158 v166 
                    let _run_target_args'_v163 = v167 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v168 : string = "&*$0"
                    let v169 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v158 v168 
                    let _run_target_args'_v163 = v169 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v171 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v171 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v175 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v175 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v179 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v179 
                    #endif
#else
                    let v183 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v183 
                    #endif
                    let v186 : Ref<Str> = _run_target_args'_v163 
                    (* run_target_args'
                    let v196 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v197 : string = "String::from($0)"
                    let v198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v186 v197 
                    let _run_target_args'_v196 = v198 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v199 : string = "String::from($0)"
                    let v200 : std_string_String = Fable.Core.RustInterop.emitRustExpr v186 v199 
                    let _run_target_args'_v196 = v200 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v201 : string = "String::from($0)"
                    let v202 : std_string_String = Fable.Core.RustInterop.emitRustExpr v186 v201 
                    let _run_target_args'_v196 = v202 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v204 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v204 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v208 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v208 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v212 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v212 
                    #endif
#else
                    let v216 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v216 
                    #endif
                    let v219 : std_string_String = _run_target_args'_v196 
                    (* run_target_args'
                    let v229 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v230 : string = "std::path::PathBuf::from($0)"
                    let v231 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v219 v230 
                    let _run_target_args'_v229 = v231 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v232 : string = "std::path::PathBuf::from($0)"
                    let v233 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v219 v232 
                    let _run_target_args'_v229 = v233 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v234 : string = "std::path::PathBuf::from($0)"
                    let v235 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v219 v234 
                    let _run_target_args'_v229 = v235 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v237 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v237 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v241 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v241 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v245 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v245 
                    #endif
#else
                    let v249 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v249 
                    #endif
                    let v252 : std_path_PathBuf = _run_target_args'_v229 
                    (* run_target_args'
                    let v259 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v260 : string = "Ok($0)"
                    let v261 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v252 v260 
                    let _run_target_args'_v259 = v261 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v262 : string = "Ok($0)"
                    let v263 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v252 v262 
                    let _run_target_args'_v259 = v263 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v264 : string = "Ok($0)"
                    let v265 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v252 v264 
                    let _run_target_args'_v259 = v265 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v266 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v266 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v267 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v267 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v268 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v268 
                    #endif
#else
                    let v269 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v269 
                    #endif
                    let v270 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v259 
                    v270
            else
                let v327 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v328 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
                let v329 : string = v327 + v328 
                (* run_target_args'
                let v334 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v335 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v336 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v329 v335 
                let _run_target_args'_v334 = v336 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v337 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v338 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v329 v337 
                let _run_target_args'_v334 = v338 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v339 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v340 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v329 v339 
                let _run_target_args'_v334 = v340 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v342 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v342 
                #endif
#if FABLE_COMPILER_PYTHON
                let v346 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v346 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v350 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v350 
                #endif
#else
                let v354 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v354 
                #endif
                let v357 : std_io_Error = _run_target_args'_v334 
                (* run_target_args'
                let v364 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v365 : string = "Err($0)"
                let v366 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v357 v365 
                let _run_target_args'_v364 = v366 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v367 : string = "Err($0)"
                let v368 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v357 v367 
                let _run_target_args'_v364 = v368 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v369 : string = "Err($0)"
                let v370 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v357 v369 
                let _run_target_args'_v364 = v370 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v371 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v371 
                #endif
#if FABLE_COMPILER_PYTHON
                let v372 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v372 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v373 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v373 
                #endif
#else
                let v374 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v374 
                #endif
                let v375 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v364 
                v375
        | _ ->
            let v379 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v380 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
            let v381 : string = v379 + v380 
            (* run_target_args'
            let v386 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v387 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v388 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v381 v387 
            let _run_target_args'_v386 = v388 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v389 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v390 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v381 v389 
            let _run_target_args'_v386 = v390 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v391 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v392 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v381 v391 
            let _run_target_args'_v386 = v392 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v394 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v394 
            #endif
#if FABLE_COMPILER_PYTHON
            let v398 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v398 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v402 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v402 
            #endif
#else
            let v406 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v406 
            #endif
            let v409 : std_io_Error = _run_target_args'_v386 
            (* run_target_args'
            let v416 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v417 : string = "Err($0)"
            let v418 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v409 v417 
            let _run_target_args'_v416 = v418 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v419 : string = "Err($0)"
            let v420 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v409 v419 
            let _run_target_args'_v416 = v420 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v421 : string = "Err($0)"
            let v422 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v409 v421 
            let _run_target_args'_v416 = v422 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v423 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v423 
            #endif
#if FABLE_COMPILER_PYTHON
            let v424 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v424 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v425 
            #endif
#else
            let v426 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v426 
            #endif
            let v427 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v416 
            v427
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
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method118(v3)
    let v35 : bool = v2 >= 11uy
    if v35 then
        let v36 : string = $"file_system.read_link / "
        let v37 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v38 : string = v36 + v37 
        (* run_target_args'
        let v43 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v44 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v45 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v38 v44 
        let _run_target_args'_v43 = v45 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v46 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v47 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v38 v46 
        let _run_target_args'_v43 = v47 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v48 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v49 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v38 v48 
        let _run_target_args'_v43 = v49 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v51 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v51 
        #endif
#if FABLE_COMPILER_PYTHON
        let v55 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v55 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v59 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v59 
        #endif
#else
        let v63 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v63 
        #endif
        let v66 : std_io_Error = _run_target_args'_v43 
        (* run_target_args'
        let v73 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v74 : string = "Err($0)"
        let v75 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v74 
        let _run_target_args'_v73 = v75 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v76 : string = "Err($0)"
        let v77 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v76 
        let _run_target_args'_v73 = v77 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v78 : string = "Err($0)"
        let v79 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v78 
        let _run_target_args'_v73 = v79 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v80 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v80 
        #endif
#if FABLE_COMPILER_PYTHON
        let v81 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v81 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v82 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v82 
        #endif
#else
        let v83 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v83 
        #endif
        let v84 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v73 
        v84
    else
        match v30 with
        | US5_0(v87) -> (* Some *)
            let v90 : string = ""
            let v91 : bool = v0 <> v90 
            if v91 then
                let v94 : uint8 = v2 + 1uy
                let v95 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v94
                let v96 : Result<std_path_PathBuf, std_io_Error> = v95 v87
                let v97 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v99 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v100 : string = "$0.map_err(|x| $1(x))"
                let v101 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v96, v97) v100 
                let _run_target_args'_v99 = v101 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v102 : string = "$0.map_err(|x| $1(x))"
                let v103 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v96, v97) v102 
                let _run_target_args'_v99 = v103 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v104 : string = "$0.map_err(|x| $1(x))"
                let v105 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v96, v97) v104 
                let _run_target_args'_v99 = v105 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v106 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v106 
                #endif
#if FABLE_COMPILER_PYTHON
                let v107 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v107 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v108 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v108 
                #endif
#else
                let v109 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v109 
                #endif
                let v110 : Result<std_path_PathBuf, string> = _run_target_args'_v99 
                let v113 : (std_path_PathBuf -> US14) = method113()
                let v114 : (string -> US14) = method114()
                let v116 : US14 = match v110 with Ok x -> v113 x | Error x -> v114 x
                match v116 with
                | US14_1(v272) -> (* Error *)
                    let v273 : string = $"file_system.read_link / "
                    let v274 : string = $"error': {v272} / error: {v34} / name: {v4}"
                    let v275 : string = v273 + v274 
                    (* run_target_args'
                    let v280 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v281 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v282 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v275 v281 
                    let _run_target_args'_v280 = v282 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v283 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v284 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v275 v283 
                    let _run_target_args'_v280 = v284 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v285 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v286 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v275 v285 
                    let _run_target_args'_v280 = v286 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v288 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v288 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v292 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v292 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v296 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v296 
                    #endif
#else
                    let v300 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v300 
                    #endif
                    let v303 : std_io_Error = _run_target_args'_v280 
                    (* run_target_args'
                    let v310 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v311 : string = "Err($0)"
                    let v312 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v303 v311 
                    let _run_target_args'_v310 = v312 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v313 : string = "Err($0)"
                    let v314 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v303 v313 
                    let _run_target_args'_v310 = v314 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v315 : string = "Err($0)"
                    let v316 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v303 v315 
                    let _run_target_args'_v310 = v316 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v317 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v317 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v318 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v318 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v319 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v319 
                    #endif
#else
                    let v320 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v320 
                    #endif
                    let v321 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v310 
                    v321
                | US14_0(v119) -> (* Ok *)
                    (* run_target_args'
                    let v124 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v125 : string = "$0.display()"
                    let v126 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v119 v125 
                    let _run_target_args'_v124 = v126 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v127 : string = "$0.display()"
                    let v128 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v119 v127 
                    let _run_target_args'_v124 = v128 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v129 : string = "$0.display()"
                    let v130 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v119 v129 
                    let _run_target_args'_v124 = v130 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v132 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v132 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v136 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v136 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v140 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v140 
                    #endif
#else
                    let v144 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v144 
                    #endif
                    let v147 : std_path_Display = _run_target_args'_v124 
                    let v154 : string = v147 |> string 
                    let v157 : string = method90(v154, v4)
                    (* run_target_args'
                    let v162 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v163 : string = "&*$0"
                    let v164 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v157 v163 
                    let _run_target_args'_v162 = v164 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v165 : string = "&*$0"
                    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v157 v165 
                    let _run_target_args'_v162 = v166 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v167 : string = "&*$0"
                    let v168 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v157 v167 
                    let _run_target_args'_v162 = v168 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v170 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v170 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v174 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v174 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v178 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v178 
                    #endif
#else
                    let v182 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v182 
                    #endif
                    let v185 : Ref<Str> = _run_target_args'_v162 
                    (* run_target_args'
                    let v195 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v196 : string = "String::from($0)"
                    let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v196 
                    let _run_target_args'_v195 = v197 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v198 : string = "String::from($0)"
                    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v198 
                    let _run_target_args'_v195 = v199 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v200 : string = "String::from($0)"
                    let v201 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v200 
                    let _run_target_args'_v195 = v201 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v203 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v203 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v207 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v207 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v211 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v211 
                    #endif
#else
                    let v215 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v215 
                    #endif
                    let v218 : std_string_String = _run_target_args'_v195 
                    (* run_target_args'
                    let v228 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v229 : string = "std::path::PathBuf::from($0)"
                    let v230 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v218 v229 
                    let _run_target_args'_v228 = v230 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v231 : string = "std::path::PathBuf::from($0)"
                    let v232 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v218 v231 
                    let _run_target_args'_v228 = v232 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v233 : string = "std::path::PathBuf::from($0)"
                    let v234 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v218 v233 
                    let _run_target_args'_v228 = v234 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v236 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v236 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v240 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v240 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v244 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v244 
                    #endif
#else
                    let v248 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v248 
                    #endif
                    let v251 : std_path_PathBuf = _run_target_args'_v228 
                    (* run_target_args'
                    let v258 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v259 : string = "Ok($0)"
                    let v260 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v251 v259 
                    let _run_target_args'_v258 = v260 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v261 : string = "Ok($0)"
                    let v262 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v251 v261 
                    let _run_target_args'_v258 = v262 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v263 : string = "Ok($0)"
                    let v264 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v251 v263 
                    let _run_target_args'_v258 = v264 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v265 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v265 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v266 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v266 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v267 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v267 
                    #endif
#else
                    let v268 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v268 
                    #endif
                    let v269 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v258 
                    v269
            else
                let v326 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v327 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
                let v328 : string = v326 + v327 
                (* run_target_args'
                let v333 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v334 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v335 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v328 v334 
                let _run_target_args'_v333 = v335 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v336 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v337 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v328 v336 
                let _run_target_args'_v333 = v337 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v338 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v339 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v328 v338 
                let _run_target_args'_v333 = v339 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v341 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v341 
                #endif
#if FABLE_COMPILER_PYTHON
                let v345 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v345 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v349 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v349 
                #endif
#else
                let v353 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v353 
                #endif
                let v356 : std_io_Error = _run_target_args'_v333 
                (* run_target_args'
                let v363 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v364 : string = "Err($0)"
                let v365 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v356 v364 
                let _run_target_args'_v363 = v365 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v366 : string = "Err($0)"
                let v367 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v356 v366 
                let _run_target_args'_v363 = v367 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v368 : string = "Err($0)"
                let v369 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v356 v368 
                let _run_target_args'_v363 = v369 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v370 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v370 
                #endif
#if FABLE_COMPILER_PYTHON
                let v371 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v371 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v372 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v372 
                #endif
#else
                let v373 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v373 
                #endif
                let v374 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v363 
                v374
        | _ ->
            let v378 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v379 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
            let v380 : string = v378 + v379 
            (* run_target_args'
            let v385 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v386 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v387 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v380 v386 
            let _run_target_args'_v385 = v387 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v388 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v389 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v380 v388 
            let _run_target_args'_v385 = v389 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v390 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v391 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v380 v390 
            let _run_target_args'_v385 = v391 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v393 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v393 
            #endif
#if FABLE_COMPILER_PYTHON
            let v397 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v397 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v401 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v401 
            #endif
#else
            let v405 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v405 
            #endif
            let v408 : std_io_Error = _run_target_args'_v385 
            (* run_target_args'
            let v415 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v416 : string = "Err($0)"
            let v417 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v408 v416 
            let _run_target_args'_v415 = v417 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v418 : string = "Err($0)"
            let v419 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v408 v418 
            let _run_target_args'_v415 = v419 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v420 : string = "Err($0)"
            let v421 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v408 v420 
            let _run_target_args'_v415 = v421 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v422 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v422 
            #endif
#if FABLE_COMPILER_PYTHON
            let v423 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v423 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v424 
            #endif
#else
            let v425 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v425 
            #endif
            let v426 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v415 
            v426
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
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method49(v3)
    let v36 : bool = v2 >= 11uy
    if v36 then
        let v37 : string = $"file_system.read_link / "
        let v38 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v39 : string = v37 + v38 
        (* run_target_args'
        let v44 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v45 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v46 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v39 v45 
        let _run_target_args'_v44 = v46 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v47 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v48 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v39 v47 
        let _run_target_args'_v44 = v48 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v49 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v50 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v39 v49 
        let _run_target_args'_v44 = v50 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v52 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v52 
        #endif
#if FABLE_COMPILER_PYTHON
        let v56 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v56 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v60 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v60 
        #endif
#else
        let v64 : std_io_Error = v39 |> unbox<std_io_Error>
        let _run_target_args'_v44 = v64 
        #endif
        let v67 : std_io_Error = _run_target_args'_v44 
        (* run_target_args'
        let v74 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v75 : string = "Err($0)"
        let v76 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v75 
        let _run_target_args'_v74 = v76 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v77 : string = "Err($0)"
        let v78 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v77 
        let _run_target_args'_v74 = v78 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v79 : string = "Err($0)"
        let v80 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v79 
        let _run_target_args'_v74 = v80 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v81 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v81 
        #endif
#if FABLE_COMPILER_PYTHON
        let v82 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v82 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v83 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v83 
        #endif
#else
        let v84 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v74 = v84 
        #endif
        let v85 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v74 
        v85
    else
        match v31 with
        | US5_0(v88) -> (* Some *)
            let v91 : string = ""
            let v92 : bool = v4 <> v91 
            if v92 then
                let v95 : uint8 = v2 + 1uy
                let v96 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v95
                let v97 : Result<std_path_PathBuf, std_io_Error> = v96 v88
                let v98 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v100 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v101 : string = "$0.map_err(|x| $1(x))"
                let v102 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v97, v98) v101 
                let _run_target_args'_v100 = v102 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v103 : string = "$0.map_err(|x| $1(x))"
                let v104 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v97, v98) v103 
                let _run_target_args'_v100 = v104 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v105 : string = "$0.map_err(|x| $1(x))"
                let v106 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v97, v98) v105 
                let _run_target_args'_v100 = v106 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v107 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v107 
                #endif
#if FABLE_COMPILER_PYTHON
                let v108 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v108 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v109 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v109 
                #endif
#else
                let v110 : Result<std_path_PathBuf, string> = match v97 with Ok x -> Ok x | Error x -> Error (v98 x)
                let _run_target_args'_v100 = v110 
                #endif
                let v111 : Result<std_path_PathBuf, string> = _run_target_args'_v100 
                let v114 : (std_path_PathBuf -> US14) = method113()
                let v115 : (string -> US14) = method114()
                let v117 : US14 = match v111 with Ok x -> v114 x | Error x -> v115 x
                match v117 with
                | US14_1(v273) -> (* Error *)
                    let v274 : string = $"file_system.read_link / "
                    let v275 : string = $"error': {v273} / error: {v35} / name: {v5}"
                    let v276 : string = v274 + v275 
                    (* run_target_args'
                    let v281 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v282 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v283 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v276 v282 
                    let _run_target_args'_v281 = v283 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v284 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v285 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v276 v284 
                    let _run_target_args'_v281 = v285 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v286 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v287 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v276 v286 
                    let _run_target_args'_v281 = v287 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v289 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v289 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v293 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v293 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v297 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v297 
                    #endif
#else
                    let v301 : std_io_Error = v276 |> unbox<std_io_Error>
                    let _run_target_args'_v281 = v301 
                    #endif
                    let v304 : std_io_Error = _run_target_args'_v281 
                    (* run_target_args'
                    let v311 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v312 : string = "Err($0)"
                    let v313 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v304 v312 
                    let _run_target_args'_v311 = v313 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v314 : string = "Err($0)"
                    let v315 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v304 v314 
                    let _run_target_args'_v311 = v315 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v316 : string = "Err($0)"
                    let v317 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v304 v316 
                    let _run_target_args'_v311 = v317 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v318 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v318 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v319 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v319 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v320 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v320 
                    #endif
#else
                    let v321 : Result<std_path_PathBuf, std_io_Error> = v304 |> Error
                    let _run_target_args'_v311 = v321 
                    #endif
                    let v322 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v311 
                    v322
                | US14_0(v120) -> (* Ok *)
                    (* run_target_args'
                    let v125 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v126 : string = "$0.display()"
                    let v127 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v120 v126 
                    let _run_target_args'_v125 = v127 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v128 : string = "$0.display()"
                    let v129 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v120 v128 
                    let _run_target_args'_v125 = v129 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v130 : string = "$0.display()"
                    let v131 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v120 v130 
                    let _run_target_args'_v125 = v131 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v133 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v133 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v137 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v137 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v141 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v141 
                    #endif
#else
                    let v145 : std_path_Display = v120 |> unbox<std_path_Display>
                    let _run_target_args'_v125 = v145 
                    #endif
                    let v148 : std_path_Display = _run_target_args'_v125 
                    let v155 : string = v148 |> string 
                    let v158 : string = method90(v155, v5)
                    (* run_target_args'
                    let v163 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v164 : string = "&*$0"
                    let v165 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v158 v164 
                    let _run_target_args'_v163 = v165 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v166 : string = "&*$0"
                    let v167 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v158 v166 
                    let _run_target_args'_v163 = v167 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v168 : string = "&*$0"
                    let v169 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v158 v168 
                    let _run_target_args'_v163 = v169 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v171 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v171 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v175 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v175 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v179 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v179 
                    #endif
#else
                    let v183 : Ref<Str> = v158 |> unbox<Ref<Str>>
                    let _run_target_args'_v163 = v183 
                    #endif
                    let v186 : Ref<Str> = _run_target_args'_v163 
                    (* run_target_args'
                    let v196 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v197 : string = "String::from($0)"
                    let v198 : std_string_String = Fable.Core.RustInterop.emitRustExpr v186 v197 
                    let _run_target_args'_v196 = v198 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v199 : string = "String::from($0)"
                    let v200 : std_string_String = Fable.Core.RustInterop.emitRustExpr v186 v199 
                    let _run_target_args'_v196 = v200 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v201 : string = "String::from($0)"
                    let v202 : std_string_String = Fable.Core.RustInterop.emitRustExpr v186 v201 
                    let _run_target_args'_v196 = v202 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v204 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v204 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v208 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v208 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v212 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v212 
                    #endif
#else
                    let v216 : std_string_String = v186 |> unbox<std_string_String>
                    let _run_target_args'_v196 = v216 
                    #endif
                    let v219 : std_string_String = _run_target_args'_v196 
                    (* run_target_args'
                    let v229 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v230 : string = "std::path::PathBuf::from($0)"
                    let v231 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v219 v230 
                    let _run_target_args'_v229 = v231 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v232 : string = "std::path::PathBuf::from($0)"
                    let v233 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v219 v232 
                    let _run_target_args'_v229 = v233 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v234 : string = "std::path::PathBuf::from($0)"
                    let v235 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v219 v234 
                    let _run_target_args'_v229 = v235 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v237 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v237 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v241 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v241 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v245 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v245 
                    #endif
#else
                    let v249 : std_path_PathBuf = v219 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v229 = v249 
                    #endif
                    let v252 : std_path_PathBuf = _run_target_args'_v229 
                    (* run_target_args'
                    let v259 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v260 : string = "Ok($0)"
                    let v261 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v252 v260 
                    let _run_target_args'_v259 = v261 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v262 : string = "Ok($0)"
                    let v263 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v252 v262 
                    let _run_target_args'_v259 = v263 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v264 : string = "Ok($0)"
                    let v265 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v252 v264 
                    let _run_target_args'_v259 = v265 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v266 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v266 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v267 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v267 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v268 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v268 
                    #endif
#else
                    let v269 : Result<std_path_PathBuf, std_io_Error> = v252 |> Ok
                    let _run_target_args'_v259 = v269 
                    #endif
                    let v270 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v259 
                    v270
            else
                let v327 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v328 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
                let v329 : string = v327 + v328 
                (* run_target_args'
                let v334 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v335 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v336 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v329 v335 
                let _run_target_args'_v334 = v336 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v337 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v338 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v329 v337 
                let _run_target_args'_v334 = v338 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v339 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v340 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v329 v339 
                let _run_target_args'_v334 = v340 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v342 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v342 
                #endif
#if FABLE_COMPILER_PYTHON
                let v346 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v346 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v350 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v350 
                #endif
#else
                let v354 : std_io_Error = v329 |> unbox<std_io_Error>
                let _run_target_args'_v334 = v354 
                #endif
                let v357 : std_io_Error = _run_target_args'_v334 
                (* run_target_args'
                let v364 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v365 : string = "Err($0)"
                let v366 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v357 v365 
                let _run_target_args'_v364 = v366 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v367 : string = "Err($0)"
                let v368 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v357 v367 
                let _run_target_args'_v364 = v368 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v369 : string = "Err($0)"
                let v370 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v357 v369 
                let _run_target_args'_v364 = v370 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v371 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v371 
                #endif
#if FABLE_COMPILER_PYTHON
                let v372 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v372 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v373 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v373 
                #endif
#else
                let v374 : Result<std_path_PathBuf, std_io_Error> = v357 |> Error
                let _run_target_args'_v364 = v374 
                #endif
                let v375 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v364 
                v375
        | _ ->
            let v379 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v380 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
            let v381 : string = v379 + v380 
            (* run_target_args'
            let v386 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v387 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v388 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v381 v387 
            let _run_target_args'_v386 = v388 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v389 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v390 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v381 v389 
            let _run_target_args'_v386 = v390 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v391 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v392 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v381 v391 
            let _run_target_args'_v386 = v392 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v394 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v394 
            #endif
#if FABLE_COMPILER_PYTHON
            let v398 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v398 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v402 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v402 
            #endif
#else
            let v406 : std_io_Error = v381 |> unbox<std_io_Error>
            let _run_target_args'_v386 = v406 
            #endif
            let v409 : std_io_Error = _run_target_args'_v386 
            (* run_target_args'
            let v416 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v417 : string = "Err($0)"
            let v418 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v409 v417 
            let _run_target_args'_v416 = v418 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v419 : string = "Err($0)"
            let v420 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v409 v419 
            let _run_target_args'_v416 = v420 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v421 : string = "Err($0)"
            let v422 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v409 v421 
            let _run_target_args'_v416 = v422 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v423 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v423 
            #endif
#if FABLE_COMPILER_PYTHON
            let v424 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v424 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v425 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v425 
            #endif
#else
            let v426 : Result<std_path_PathBuf, std_io_Error> = v409 |> Error
            let _run_target_args'_v416 = v426 
            #endif
            let v427 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v416 
            v427
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
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method49(v3)
    let v35 : bool = v2 >= 11uy
    if v35 then
        let v36 : string = $"file_system.read_link / "
        let v37 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v38 : string = v36 + v37 
        (* run_target_args'
        let v43 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v44 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v45 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v38 v44 
        let _run_target_args'_v43 = v45 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v46 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v47 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v38 v46 
        let _run_target_args'_v43 = v47 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v48 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v49 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v38 v48 
        let _run_target_args'_v43 = v49 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v51 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v51 
        #endif
#if FABLE_COMPILER_PYTHON
        let v55 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v55 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v59 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v59 
        #endif
#else
        let v63 : std_io_Error = v38 |> unbox<std_io_Error>
        let _run_target_args'_v43 = v63 
        #endif
        let v66 : std_io_Error = _run_target_args'_v43 
        (* run_target_args'
        let v73 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v74 : string = "Err($0)"
        let v75 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v74 
        let _run_target_args'_v73 = v75 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v76 : string = "Err($0)"
        let v77 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v76 
        let _run_target_args'_v73 = v77 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v78 : string = "Err($0)"
        let v79 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v78 
        let _run_target_args'_v73 = v79 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v80 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v80 
        #endif
#if FABLE_COMPILER_PYTHON
        let v81 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v81 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v82 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v82 
        #endif
#else
        let v83 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v73 = v83 
        #endif
        let v84 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v73 
        v84
    else
        match v30 with
        | US5_0(v87) -> (* Some *)
            let v90 : string = ""
            let v91 : bool = v0 <> v90 
            if v91 then
                let v94 : uint8 = v2 + 1uy
                let v95 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v94
                let v96 : Result<std_path_PathBuf, std_io_Error> = v95 v87
                let v97 : (std_io_Error -> string) = method48()
                (* run_target_args'
                let v99 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v100 : string = "$0.map_err(|x| $1(x))"
                let v101 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v96, v97) v100 
                let _run_target_args'_v99 = v101 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v102 : string = "$0.map_err(|x| $1(x))"
                let v103 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v96, v97) v102 
                let _run_target_args'_v99 = v103 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v104 : string = "$0.map_err(|x| $1(x))"
                let v105 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v96, v97) v104 
                let _run_target_args'_v99 = v105 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v106 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v106 
                #endif
#if FABLE_COMPILER_PYTHON
                let v107 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v107 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v108 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v108 
                #endif
#else
                let v109 : Result<std_path_PathBuf, string> = match v96 with Ok x -> Ok x | Error x -> Error (v97 x)
                let _run_target_args'_v99 = v109 
                #endif
                let v110 : Result<std_path_PathBuf, string> = _run_target_args'_v99 
                let v113 : (std_path_PathBuf -> US14) = method113()
                let v114 : (string -> US14) = method114()
                let v116 : US14 = match v110 with Ok x -> v113 x | Error x -> v114 x
                match v116 with
                | US14_1(v272) -> (* Error *)
                    let v273 : string = $"file_system.read_link / "
                    let v274 : string = $"error': {v272} / error: {v34} / name: {v4}"
                    let v275 : string = v273 + v274 
                    (* run_target_args'
                    let v280 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v281 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v282 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v275 v281 
                    let _run_target_args'_v280 = v282 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v283 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v284 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v275 v283 
                    let _run_target_args'_v280 = v284 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v285 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v286 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v275 v285 
                    let _run_target_args'_v280 = v286 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v288 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v288 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v292 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v292 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v296 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v296 
                    #endif
#else
                    let v300 : std_io_Error = v275 |> unbox<std_io_Error>
                    let _run_target_args'_v280 = v300 
                    #endif
                    let v303 : std_io_Error = _run_target_args'_v280 
                    (* run_target_args'
                    let v310 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v311 : string = "Err($0)"
                    let v312 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v303 v311 
                    let _run_target_args'_v310 = v312 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v313 : string = "Err($0)"
                    let v314 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v303 v313 
                    let _run_target_args'_v310 = v314 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v315 : string = "Err($0)"
                    let v316 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v303 v315 
                    let _run_target_args'_v310 = v316 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v317 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v317 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v318 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v318 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v319 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v319 
                    #endif
#else
                    let v320 : Result<std_path_PathBuf, std_io_Error> = v303 |> Error
                    let _run_target_args'_v310 = v320 
                    #endif
                    let v321 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v310 
                    v321
                | US14_0(v119) -> (* Ok *)
                    (* run_target_args'
                    let v124 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v125 : string = "$0.display()"
                    let v126 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v119 v125 
                    let _run_target_args'_v124 = v126 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v127 : string = "$0.display()"
                    let v128 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v119 v127 
                    let _run_target_args'_v124 = v128 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v129 : string = "$0.display()"
                    let v130 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v119 v129 
                    let _run_target_args'_v124 = v130 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v132 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v132 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v136 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v136 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v140 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v140 
                    #endif
#else
                    let v144 : std_path_Display = v119 |> unbox<std_path_Display>
                    let _run_target_args'_v124 = v144 
                    #endif
                    let v147 : std_path_Display = _run_target_args'_v124 
                    let v154 : string = v147 |> string 
                    let v157 : string = method90(v154, v4)
                    (* run_target_args'
                    let v162 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v163 : string = "&*$0"
                    let v164 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v157 v163 
                    let _run_target_args'_v162 = v164 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v165 : string = "&*$0"
                    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v157 v165 
                    let _run_target_args'_v162 = v166 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v167 : string = "&*$0"
                    let v168 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v157 v167 
                    let _run_target_args'_v162 = v168 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v170 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v170 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v174 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v174 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v178 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v178 
                    #endif
#else
                    let v182 : Ref<Str> = v157 |> unbox<Ref<Str>>
                    let _run_target_args'_v162 = v182 
                    #endif
                    let v185 : Ref<Str> = _run_target_args'_v162 
                    (* run_target_args'
                    let v195 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v196 : string = "String::from($0)"
                    let v197 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v196 
                    let _run_target_args'_v195 = v197 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v198 : string = "String::from($0)"
                    let v199 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v198 
                    let _run_target_args'_v195 = v199 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v200 : string = "String::from($0)"
                    let v201 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v200 
                    let _run_target_args'_v195 = v201 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v203 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v203 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v207 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v207 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v211 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v211 
                    #endif
#else
                    let v215 : std_string_String = v185 |> unbox<std_string_String>
                    let _run_target_args'_v195 = v215 
                    #endif
                    let v218 : std_string_String = _run_target_args'_v195 
                    (* run_target_args'
                    let v228 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v229 : string = "std::path::PathBuf::from($0)"
                    let v230 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v218 v229 
                    let _run_target_args'_v228 = v230 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v231 : string = "std::path::PathBuf::from($0)"
                    let v232 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v218 v231 
                    let _run_target_args'_v228 = v232 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v233 : string = "std::path::PathBuf::from($0)"
                    let v234 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v218 v233 
                    let _run_target_args'_v228 = v234 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v236 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v236 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v240 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v240 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v244 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v244 
                    #endif
#else
                    let v248 : std_path_PathBuf = v218 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v228 = v248 
                    #endif
                    let v251 : std_path_PathBuf = _run_target_args'_v228 
                    (* run_target_args'
                    let v258 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v259 : string = "Ok($0)"
                    let v260 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v251 v259 
                    let _run_target_args'_v258 = v260 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v261 : string = "Ok($0)"
                    let v262 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v251 v261 
                    let _run_target_args'_v258 = v262 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v263 : string = "Ok($0)"
                    let v264 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v251 v263 
                    let _run_target_args'_v258 = v264 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v265 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v265 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v266 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v266 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v267 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v267 
                    #endif
#else
                    let v268 : Result<std_path_PathBuf, std_io_Error> = v251 |> Ok
                    let _run_target_args'_v258 = v268 
                    #endif
                    let v269 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v258 
                    v269
            else
                let v326 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v327 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
                let v328 : string = v326 + v327 
                (* run_target_args'
                let v333 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v334 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v335 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v328 v334 
                let _run_target_args'_v333 = v335 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v336 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v337 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v328 v336 
                let _run_target_args'_v333 = v337 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v338 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v339 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v328 v338 
                let _run_target_args'_v333 = v339 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v341 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v341 
                #endif
#if FABLE_COMPILER_PYTHON
                let v345 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v345 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v349 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v349 
                #endif
#else
                let v353 : std_io_Error = v328 |> unbox<std_io_Error>
                let _run_target_args'_v333 = v353 
                #endif
                let v356 : std_io_Error = _run_target_args'_v333 
                (* run_target_args'
                let v363 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v364 : string = "Err($0)"
                let v365 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v356 v364 
                let _run_target_args'_v363 = v365 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v366 : string = "Err($0)"
                let v367 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v356 v366 
                let _run_target_args'_v363 = v367 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v368 : string = "Err($0)"
                let v369 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v356 v368 
                let _run_target_args'_v363 = v369 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v370 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v370 
                #endif
#if FABLE_COMPILER_PYTHON
                let v371 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v371 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v372 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v372 
                #endif
#else
                let v373 : Result<std_path_PathBuf, std_io_Error> = v356 |> Error
                let _run_target_args'_v363 = v373 
                #endif
                let v374 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v363 
                v374
        | _ ->
            let v378 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v379 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
            let v380 : string = v378 + v379 
            (* run_target_args'
            let v385 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v386 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v387 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v380 v386 
            let _run_target_args'_v385 = v387 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v388 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v389 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v380 v388 
            let _run_target_args'_v385 = v389 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v390 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v391 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v380 v390 
            let _run_target_args'_v385 = v391 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v393 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v393 
            #endif
#if FABLE_COMPILER_PYTHON
            let v397 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v397 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v401 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v401 
            #endif
#else
            let v405 : std_io_Error = v380 |> unbox<std_io_Error>
            let _run_target_args'_v385 = v405 
            #endif
            let v408 : std_io_Error = _run_target_args'_v385 
            (* run_target_args'
            let v415 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v416 : string = "Err($0)"
            let v417 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v408 v416 
            let _run_target_args'_v415 = v417 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v418 : string = "Err($0)"
            let v419 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v408 v418 
            let _run_target_args'_v415 = v419 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v420 : string = "Err($0)"
            let v421 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v408 v420 
            let _run_target_args'_v415 = v421 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v422 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v422 
            #endif
#if FABLE_COMPILER_PYTHON
            let v423 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v423 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v424 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v424 
            #endif
#else
            let v425 : Result<std_path_PathBuf, std_io_Error> = v408 |> Error
            let _run_target_args'_v415 = v425 
            #endif
            let v426 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v415 
            v426
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
        let v42 : US15 = US15_1
        let v43 : US15 = v22 |> Option.defaultValue v42 
        let v86 : string =
            match v43 with
            | US15_1 -> (* None *)
                v0
            | US15_0(v47) -> (* Some *)
                (* run_target_args'
                let v52 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v53 : string = "$0.display()"
                let v54 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v47 v53 
                let _run_target_args'_v52 = v54 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v55 : string = "$0.display()"
                let v56 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v47 v55 
                let _run_target_args'_v52 = v56 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v57 : string = "$0.display()"
                let v58 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v47 v57 
                let _run_target_args'_v52 = v58 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v60 : std_path_Display = v47 |> unbox<std_path_Display>
                let _run_target_args'_v52 = v60 
                #endif
#if FABLE_COMPILER_PYTHON
                let v64 : std_path_Display = v47 |> unbox<std_path_Display>
                let _run_target_args'_v52 = v64 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v68 : std_path_Display = v47 |> unbox<std_path_Display>
                let _run_target_args'_v52 = v68 
                #endif
#else
                let v72 : std_path_Display = v47 |> unbox<std_path_Display>
                let _run_target_args'_v52 = v72 
                #endif
                let v75 : std_path_Display = _run_target_args'_v52 
                let v82 : string = v75 |> string 
                v82
        let v87 : bool = v86 = ""
        let v88 : string =
            if v87 then
                v0
            else
                v86
        let v89 : string = "^\\\\\\\\\\?\\\\"
        let v90 : string = ""
        let v91 : string = method128(v89, v90, v88)
        let v92 : int32 = v91.Length
        let v93 : bool = v92 < 2
        if v93 then
            v0
        else
            let v94 : string = $"{v91.[0] |> string |> _.ToLower()}{v91.[1..]}"
            let v95 : string = "\\"
            let v96 : string = "/"
            let v97 : string = v94.Replace (v95, v96)
            v97
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
    let v297 : string =
        if v107 then
            let v108 : string = method132()
            let v109 : string = method90(v108, v0)
            let v110 : string = method110(v109)
            let v118 : string = "/"
            let v119 : (string []) = v110.Split v118 
            let v122 : (string []) = [||]
            let v123 : int32 = v119.Length
            let v124 : Mut5 = {l0 = 0; l1 = 0; l2 = v122} : Mut5
            while method133(v123, v124) do
                let v126 : int32 = v124.l0
                let v127 : int32 =  -v126
                let v128 : int32 = v127 + v123
                let v129 : int32 = v128 - 1
                let struct (v130 : int32, v131 : (string [])) = v124.l1, v124.l2
                let v132 : string = v119.[int v129]
                let v133 : bool = ".." = v132
                let struct (v179 : int32, v180 : (string [])) =
                    if v133 then
                        let v134 : int32 = v130 + 1
                        struct (v134, v131)
                    else
                        let v135 : bool = "." = v132
                        if v135 then
                            struct (v130, v131)
                        else
                            let v136 : bool = 0 = v130
                            if v136 then
                                let v139 : string = ":"
                                let v140 : bool = v132.EndsWith (v139, false, null)
                                if v140 then
                                    let v143 : string = $"{v108.[0]}:"
                                    let v144 : (string []) = [|v143|]
                                    let v145 : int32 = v144.Length
                                    let v146 : int32 = v131.Length
                                    let v147 : int32 = v145 + v146
                                    let v148 : (string []) = Array.zeroCreate<string> (v147)
                                    let v149 : Mut6 = {l0 = 0} : Mut6
                                    while method134(v147, v149) do
                                        let v151 : int32 = v149.l0
                                        let v152 : bool = v151 < v145
                                        let v156 : string =
                                            if v152 then
                                                let v153 : string = v144.[int v151]
                                                v153
                                            else
                                                let v154 : int32 = v151 - v145
                                                let v155 : string = v131.[int v154]
                                                v155
                                        v148.[int v151] <- v156
                                        let v157 : int32 = v151 + 1
                                        v149.l0 <- v157
                                        ()
                                    struct (0, v148)
                                else
                                    let v158 : (string []) = [|v132|]
                                    let v159 : int32 = v158.Length
                                    let v160 : int32 = v131.Length
                                    let v161 : int32 = v159 + v160
                                    let v162 : (string []) = Array.zeroCreate<string> (v161)
                                    let v163 : Mut6 = {l0 = 0} : Mut6
                                    while method134(v161, v163) do
                                        let v165 : int32 = v163.l0
                                        let v166 : bool = v165 < v159
                                        let v170 : string =
                                            if v166 then
                                                let v167 : string = v158.[int v165]
                                                v167
                                            else
                                                let v168 : int32 = v165 - v159
                                                let v169 : string = v131.[int v168]
                                                v169
                                        v162.[int v165] <- v170
                                        let v171 : int32 = v165 + 1
                                        v163.l0 <- v171
                                        ()
                                    struct (0, v162)
                            else
                                let v174 : int32 = v130 - 1
                                struct (v174, v131)
                let v181 : int32 = v126 + 1
                v124.l0 <- v181
                v124.l1 <- v179
                v124.l2 <- v180
                ()
            let struct (v182 : int32, v183 : (string [])) = v124.l1, v124.l2
            let v188 : unit = ()
            let _let'_v188 =
                seq {
                    for i = 0 to v183.Length - 1 do yield v183.[i]
                    (* indent
                    ()
                indent *)
                }
                (* indent
                ()
            indent *)
            let v191 : string seq = _let'_v188 
            let v197 : char = method135()
            let v199 : (char -> string) = _.ToString()
            let v200 : string = v199 v197
            let v204 : bool = v200 = "\n"
            let v206 : string =
                if v204 then
                    method136(v200)
                else
                    v200
            let v207 : (string -> (string seq -> string)) = String.concat
            let v208 : (string seq -> string) = v207 v206
            v208 v191
        else
            let v212 : string = "std::fs::canonicalize(&*$0)"
            let v213 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v212 
            (* run_target_args'
            let v215 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v216 : string = "$0.unwrap()"
            let v217 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v216 
            let _run_target_args'_v215 = v217 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v218 : string = "$0.unwrap()"
            let v219 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v218 
            let _run_target_args'_v215 = v219 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v220 : string = "$0.unwrap()"
            let v221 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v213 v220 
            let _run_target_args'_v215 = v221 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : std_path_PathBuf = match v213 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v215 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v223 : std_path_PathBuf = match v213 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v215 = v223 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v224 : std_path_PathBuf = match v213 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v215 = v224 
            #endif
#else
            let v225 : std_path_PathBuf = match v213 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v215 = v225 
            #endif
            let v226 : std_path_PathBuf = _run_target_args'_v215 
            (* run_target_args'
            let v233 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v234 : string = "$0.display()"
            let v235 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v226 v234 
            let _run_target_args'_v233 = v235 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v236 : string = "$0.display()"
            let v237 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v226 v236 
            let _run_target_args'_v233 = v237 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v238 : string = "$0.display()"
            let v239 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v226 v238 
            let _run_target_args'_v233 = v239 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v241 : std_path_Display = v226 |> unbox<std_path_Display>
            let _run_target_args'_v233 = v241 
            #endif
#if FABLE_COMPILER_PYTHON
            let v245 : std_path_Display = v226 |> unbox<std_path_Display>
            let _run_target_args'_v233 = v245 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v249 : std_path_Display = v226 |> unbox<std_path_Display>
            let _run_target_args'_v233 = v249 
            #endif
#else
            let v253 : std_path_Display = v226 |> unbox<std_path_Display>
            let _run_target_args'_v233 = v253 
            #endif
            let v256 : std_path_Display = _run_target_args'_v233 
            (* run_target_args'
            let v266 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v267 : string = "format!(\"{}\", $0)"
            let v268 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v267 
            let _run_target_args'_v266 = v268 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v269 : string = "format!(\"{}\", $0)"
            let v270 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v269 
            let _run_target_args'_v266 = v270 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v271 : string = "format!(\"{}\", $0)"
            let v272 : std_string_String = Fable.Core.RustInterop.emitRustExpr v256 v271 
            let _run_target_args'_v266 = v272 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v274 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v266 = v274 
            #endif
#if FABLE_COMPILER_PYTHON
            let v278 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v266 = v278 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v282 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v266 = v282 
            #endif
#else
            let v286 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v266 = v286 
            #endif
            let v289 : std_string_String = _run_target_args'_v266 
            let v295 : string = "fable_library_rust::String_::fromString($0)"
            let v296 : string = Fable.Core.RustInterop.emitRustExpr v289 v295 
            v296
    let _run_target_args'_v5 = v297 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v299 : string = null |> unbox<string>
    let _run_target_args'_v5 = v299 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v303 : string = null |> unbox<string>
    let _run_target_args'_v5 = v303 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v307 : string = null |> unbox<string>
    let _run_target_args'_v5 = v307 
    #endif
#if FABLE_COMPILER_PYTHON
    let v311 : string = null |> unbox<string>
    let _run_target_args'_v5 = v311 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v315 : string = null |> unbox<string>
    let _run_target_args'_v5 = v315 
    #endif
#else
    let v318 : (string -> string) = System.IO.Path.GetFullPath
    let v319 : string = v318 v0
    let _run_target_args'_v5 = v319 
    #endif
    let v320 : string = _run_target_args'_v5 
    v320
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
    let v44 : string = $"file:///{v12}"
    v44
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
        let v32 : US5 = US5_1
        let v33 : US5 = v12 |> Option.defaultValue v32 
        match v33 with
        | US5_1 -> (* None *)
            let v39 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v40 : string = $" '{v0}' at '{v1}' (until '{v4}')"
            let v41 : string = v39 + v40 
            US17_1(v41)
        | US5_0(v37) -> (* Some *)
            method141(v0, v1, v2, v3, v37)
and method140 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool)) : US17 =
    let v4 : string = method90(v1, v0)
    let v5 : bool = v3 v4
    if v5 then
        US17_0(v1)
    else
        let v7 : string option = method117(v1)
        let v10 : (string -> US5) = method5()
        let v11 : US5 option = v7 |> Option.map v10 
        let v31 : US5 = US5_1
        let v32 : US5 = v11 |> Option.defaultValue v31 
        match v32 with
        | US5_1 -> (* None *)
            let v38 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v39 : string = $" '{v0}' at '{v1}' (until '{v1}')"
            let v40 : string = v38 + v39 
            US17_1(v40)
        | US5_0(v36) -> (* Some *)
            method141(v0, v1, v2, v3, v36)
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
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure6(v3, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v17 : string = "dir"
    let v18 : string = $"{v17}"
    let v21 : unit = ()
    let v22 : (unit -> unit) = closure6(v3, v18)
    let v23 : unit = (fun () -> v22 (); v21) ()
    let v28 : string = " = "
    let v29 : string = $"{v28}"
    let v32 : unit = ()
    let v33 : (unit -> unit) = closure6(v3, v29)
    let v34 : unit = (fun () -> v33 (); v32) ()
    let v38 : string = $"{v0}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v3, v38)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v48 : string = "; "
    let v49 : string = $"{v48}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v3, v49)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v59 : string = "error"
    let v60 : string = $"{v59}"
    let v63 : unit = ()
    let v64 : (unit -> unit) = closure6(v3, v60)
    let v65 : unit = (fun () -> v64 (); v63) ()
    let v69 : string = $"{v28}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v3, v69)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v78 : string = $"{v1}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v3, v78)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v88 : string = " }"
    let v89 : string = $"{v88}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v89)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v97 : string = v3.l0
    v97
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
        let v6 : unit = ()
        let v7 : (unit -> unit) = closure0()
        let v8 : unit = (fun () -> v7 (); v6) ()
        let struct (v29 : Mut0, v30 : Mut1, v31 : Mut2, v32 : Mut3, v33 : Mut4, v34 : int64 option) = TraceState.trace_state.Value
        let v47 : string = method12(v29, v30, v31, v32, v33, v34)
        let v48 : string = method55()
        let v49 : string = method142(v29, v30, v31, v32, v33, v34, v47, v48, v0, v1)
        method24(v49)
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
    let v3 : unit = ()
    let v4 : (unit -> unit) = closure0()
    let v5 : unit = (fun () -> v4 (); v3) ()
    let struct (v26 : Mut0, v27 : Mut1, v28 : Mut2, v29 : Mut3, v30 : Mut4, v31 : int64 option) = TraceState.trace_state.Value
    let v46 : (string -> unit) =
        if v0 then
            closure66()
        else
            closure2()
    v27.l0 <- v46
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
let v2 : unit = ()
let v3 : (unit -> unit) = closure0()
let v4 : unit = (fun () -> v3 (); v2) ()
let v19 : (string -> Async<int64>) = closure3()
let delete_directory_async x = v19 x
let v20 : (US6 -> (string -> Async<int64>)) = closure10()
let wait_for_file_access x = v20 x
let v21 : (string -> Async<int64>) = closure13()
let wait_for_file_access_read x = v21 x
let v22 : (string -> Async<string>) = closure14()
let read_all_text_async x = v22 x
let v23 : (string -> (string -> bool)) = closure16()
let file_exists_content x = v23 x
let v24 : (string -> (string -> Async<unit>)) = closure18()
let write_all_text_async x = v24 x
let v25 : (string -> (string -> Async<unit>)) = closure20()
let write_all_text_exists x = v25 x
let v26 : (string -> Async<int64>) = closure22()
let delete_file_async x = v26 x
let v27 : (string -> (string -> Async<int64>)) = closure28()
let move_file_async x = v27 x
let v28 : (string -> Async<string option>) = closure31()
let read_all_text_retry_async x = v28 x
let v29 : (unit -> string) = closure37()
let create_temp_path () = v29 ()
let v30 : (unit -> struct (string * System.IDisposable)) = closure39()
let create_temp_dir () = v30 ()
let v31 : (string -> struct (string * System.IDisposable)) = closure48()
let create_temp_dir' x = v31 x
let v32 : (unit -> string) = closure50()
let get_source_directory () = v32 ()
let v33 : (string -> string) = closure51()
let normalize_path x = v33 x
let v34 : (string -> string) = closure59()
let get_full_path x = v34 x
let v35 : (string -> string) = closure60()
let standardize_path x = v35 x
let v36 : (string -> string) = closure61()
let new_file_uri x = v36 x
let v37 : (unit -> string) = closure62()
let get_workspace_root () = v37 ()
let v38 : (string -> unit) = closure66()
let trace_file x = v38 x
let v39 : (bool -> unit) = closure68()
let init_trace_file x = v39 x
let v40 : (string -> (string -> unit)) = closure69()
let link_directory x = v40 x
let v41 : (string -> (string -> string)) = closure71()
let (</>) x = v41 x
()
