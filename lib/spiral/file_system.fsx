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
[<Fable.Core.Erase; Fable.Core.Emit("std::path::PathBuf")>]
type std_path_PathBuf = class end
#else
type std_path_PathBuf = string
#endif

type IFsExistsSync = abstract existsSync: path: string -> bool
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::ffi::OsString")>]
#endif
type std_ffi_OsString = class end
type IPathBasename = abstract basename: path: string -> string
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

type IPathJoin = abstract join: [<System.ParamArray>] paths: string[] -> string
#if FABLE_COMPILER
type System_IO_DirectoryInfo = bool
#else
type System_IO_DirectoryInfo = System.IO.DirectoryInfo
#endif

type Disposable (f : unit -> unit) = interface System.IDisposable with member _.Dispose () = f ()
type IPathDirname = abstract dirname: path: string -> string
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
type IFs = abstract realpathSync: path: string -> string
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
[<Fable.Core.Erase; Fable.Core.Emit("std::ffi::OsStr")>]
#endif
type std_ffi_OsStr = class end
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
    | US4_5 of f5_0 : US3
    | US4_6 of f6_0 : US3
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
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : string = "String::from($0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v47 
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v49 
    let _run_target_args'_v46 = v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v51 
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v62 
    #endif
#else
    let v66 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v66 
    #endif
    let v69 : std_string_String = _run_target_args'_v46 
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : string = "std::path::PathBuf::from($0)"
    let v84 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v83 
    let _run_target_args'_v82 = v84 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v85 : string = "std::path::PathBuf::from($0)"
    let v86 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v85 
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v87 : string = "std::path::PathBuf::from($0)"
    let v88 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v87 
    let _run_target_args'_v82 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v98 
    #endif
#else
    let v102 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v102 
    #endif
    let v105 : std_path_PathBuf = _run_target_args'_v82 
    let v114 : string = "$0.exists()"
    let v115 : bool = Fable.Core.RustInterop.emitRustExpr v105 v114 
    let v118 : bool =
        if v115 then
            let v116 : string = "$0.is_dir()"
            let v117 : bool = Fable.Core.RustInterop.emitRustExpr v105 v116 
            v117
        else
            false
    let _run_target_args'_v5 = v118 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v120 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v120 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v124 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v124 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v127 : string = "fs"
    let v128 : IFsExistsSync = Fable.Core.JsInterop.importAll v127 
    let v129 : string = "$0.existsSync($1)"
    let v130 : bool = Fable.Core.JsInterop.emitJsExpr struct (v128, v0) v129 
    let _run_target_args'_v5 = v130 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v136 
    #endif
#else
    let v139 : (string -> bool) = System.IO.Directory.Exists
    let v140 : bool = v139 v0
    let _run_target_args'_v5 = v140 
    #endif
    let v141 : bool = _run_target_args'_v5 
    v141
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
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US2) = method13()
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
    let v361 : string = method14()
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
    let v384 : (int64 -> US2) = method13()
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
    let v547 : string = method14()
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
    let v572 : (int64 -> US2) = method13()
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
    let v619 : (int64 -> US2) = method13()
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
    let v782 : string = method15()
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
    let v805 : (int64 -> US2) = method13()
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
    let v968 : string = method15()
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
    let v991 : (int64 -> US2) = method13()
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
    let v1154 : string = method15()
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
    let v1177 : (int64 -> US2) = method13()
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
    let v1340 : string = method15()
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
and method17 () : string =
    let v0 : string = ""
    v0
and closure6 (v0 : Mut3, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method18 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method16 () : string =
    
    
    
    
    
    let v2 : string = "Debug"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v9, v14)
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
    let v185 : string = method18()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[94m"
    let v201 : string = method18()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[94m"
    let v217 : string = method18()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[94m"
    let v233 : string = method18()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method19 (v0 : string) : string =
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
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : string = "String::from($0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v47 
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v49 
    let _run_target_args'_v46 = v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v51 
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v62 
    #endif
#else
    let v66 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v66 
    #endif
    let v69 : std_string_String = _run_target_args'_v46 
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : string = "std::path::PathBuf::from($0)"
    let v84 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v83 
    let _run_target_args'_v82 = v84 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v85 : string = "std::path::PathBuf::from($0)"
    let v86 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v85 
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v87 : string = "std::path::PathBuf::from($0)"
    let v88 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v87 
    let _run_target_args'_v82 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v98 
    #endif
#else
    let v102 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v102 
    #endif
    let v105 : std_path_PathBuf = _run_target_args'_v82 
    let v114 : string = "$0.file_name()"
    let v115 : Ref<std_ffi_OsStr> option = Fable.Core.RustInterop.emitRustExpr v105 v114 
    let v116 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v117 : bool = Fable.Core.RustInterop.emitRustExpr v115 v116 
    let v118 : string = "x"
    let v119 : Ref<std_ffi_OsStr> = Fable.Core.RustInterop.emitRustExpr () v118 
    let v120 : string = "$0.to_os_string()"
    let v121 : std_ffi_OsString = Fable.Core.RustInterop.emitRustExpr v119 v120 
    let v122 : string = "$0.to_str()"
    let v123 : Ref<Str> option = Fable.Core.RustInterop.emitRustExpr v121 v122 
    let v124 : string = "$0.unwrap()"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v123 v124 
    (* run_target_args'
    let v130 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v131 : string = "String::from($0)"
    let v132 : std_string_String = Fable.Core.RustInterop.emitRustExpr v125 v131 
    let _run_target_args'_v130 = v132 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v133 : string = "String::from($0)"
    let v134 : std_string_String = Fable.Core.RustInterop.emitRustExpr v125 v133 
    let _run_target_args'_v130 = v134 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v135 : string = "String::from($0)"
    let v136 : std_string_String = Fable.Core.RustInterop.emitRustExpr v125 v135 
    let _run_target_args'_v130 = v136 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v138 : std_string_String = v125 |> unbox<std_string_String>
    let _run_target_args'_v130 = v138 
    #endif
#if FABLE_COMPILER_PYTHON
    let v142 : std_string_String = v125 |> unbox<std_string_String>
    let _run_target_args'_v130 = v142 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v146 : std_string_String = v125 |> unbox<std_string_String>
    let _run_target_args'_v130 = v146 
    #endif
#else
    let v150 : std_string_String = v125 |> unbox<std_string_String>
    let _run_target_args'_v130 = v150 
    #endif
    let v153 : std_string_String = _run_target_args'_v130 
    let v162 : string = "fable_library_rust::String_::fromString($0)"
    let v163 : string = Fable.Core.RustInterop.emitRustExpr v153 v162 
    let v164 : string = "true; $0 })"
    let v165 : bool = Fable.Core.RustInterop.emitRustExpr v163 v164 
    let v166 : string = "_optionm_map_"
    let v167 : string option = Fable.Core.RustInterop.emitRustExpr () v166 
    let v170 : (string -> US5) = method5()
    let v171 : US5 option = v167 |> Option.map v170 
    let v191 : US5 = US5_1
    let v192 : US5 = v171 |> Option.defaultValue v191 
    let v199 : string =
        match v192 with
        | US5_1 -> (* None *)
            let v197 : string = ""
            v197
        | US5_0(v196) -> (* Some *)
            v196
    let _run_target_args'_v5 = v199 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v200 : US3 = US3_1
    let v201 : US4 = US4_4(v200)
    let v202 : string = $"file_system.get_file_name / target: {v201} / path: {v0}"
    let v203 : string = failwith<string> v202
    let _run_target_args'_v5 = v203 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v205 : string = null |> unbox<string>
    let _run_target_args'_v5 = v205 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v208 : string = "path"
    let v209 : IPathBasename = Fable.Core.JsInterop.importAll v208 
    let v210 : string = "v209.basename($0)"
    let v211 : string = Fable.Core.JsInterop.emitJsExpr v0 v210 
    let _run_target_args'_v5 = v211 
    #endif
#if FABLE_COMPILER_PYTHON
    let v212 : US3 = US3_0
    let v213 : US4 = US4_6(v212)
    let v214 : string = $"file_system.get_file_name / target: {v213} / path: {v0}"
    let v215 : string = failwith<string> v214
    let _run_target_args'_v5 = v215 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v216 : US3 = US3_1
    let v217 : US4 = US4_1(v216)
    let v218 : string = $"file_system.get_file_name / target: {v217} / path: {v0}"
    let v219 : string = failwith<string> v218
    let _run_target_args'_v5 = v219 
    #endif
#else
    let v220 : (string -> string) = System.IO.Path.GetFileName
    let v221 : string = v220 v0
    let _run_target_args'_v5 = v221 
    #endif
    let v222 : string = _run_target_args'_v5 
    v222
and method21 (v0 : string) : string =
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
and method20 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "ex"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v70 : string = $"{v8}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure6(v11, v70)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v88 : string = "; "
    let v89 : string = $"{v88}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure6(v11, v89)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v107 : string = "path"
    let v108 : string = $"{v107}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure6(v11, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v125 : string = $"{v52}"
    let v133 : unit = ()
    let v134 : (unit -> unit) = closure6(v11, v125)
    let v135 : unit = (fun () -> v134 (); v133) ()
    let v142 : string = $"{v9}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure6(v11, v142)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v160 : string = " }"
    let v161 : string = $"{v160}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure6(v11, v161)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v177 : string = v11.l0
    let v178 : int64 = v0.l0
    let v181 : string = " "
    let v182 : string = v6 + v181 
    let v186 : string = v182 + v7 
    let v191 : string = " #"
    let v192 : string = v186 + v191 
    let v196 : (int64 -> string) = _.ToString()
    let v197 : string = v196 v178
    let v201 : string = v192 + v197 
    let v205 : string = v201 + v181 
    let v210 : string = "file_system.delete_directory_async"
    let v211 : string = v205 + v210 
    let v216 : string = " / "
    let v217 : string = v211 + v216 
    let v221 : string = v217 + v177 
    method21(v221)
and closure7 (v0 : Mut0) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure9 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure8 () (v0 : string) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure9(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and method22 (v0 : string) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut0, v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : int64 option) = TraceState.trace_state.Value
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure7(v38)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v63 : (string -> unit) = closure8()
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
and closure4 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method16()
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v65 = v75 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v79 : string = $"%A{v1}"
        let _run_target_args'_v65 = v79 
        #endif
#if FABLE_COMPILER_PYTHON
        let v83 : string = $"%A{v1}"
        let _run_target_args'_v65 = v83 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v87 : string = $"%A{v1}"
        let _run_target_args'_v65 = v87 
        #endif
#else
        let v90 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v65 = v90 
        #endif
        let v91 : string = _run_target_args'_v65 
        let v100 : string = method19(v0)
        let v101 : string = method20(v41, v42, v43, v44, v45, v46, v59, v60, v91, v100)
        method22(v101)
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
                let v9202 : bool = true
                method9(v9202, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v9437 : exn = ex
                let v9438 : int64 = v1 % 100L
                let v9439 : bool = v9438 = 0L
                if v9439 then
                    let v9540 : unit = ()
                    let v9541 : (unit -> unit) = closure4(v0, v9437)
                    let v9542 : unit = (fun () -> v9541 (); v9540) ()
                    ()
                (* run_target_args'
                let v9647 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9648 : (int32 -> Async<unit>) = Async.Sleep
                let v9649 : Async<unit> = v9648 10
                let _run_target_args'_v9647 = v9649 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9650 : (int32 -> Async<unit>) = Async.Sleep
                let v9651 : Async<unit> = v9650 10
                let _run_target_args'_v9647 = v9651 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9652 : (int32 -> Async<unit>) = Async.Sleep
                let v9653 : Async<unit> = v9652 10
                let _run_target_args'_v9647 = v9653 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9654 : (int32 -> Async<unit>) = Async.Sleep
                let v9655 : Async<unit> = v9654 10
                let _run_target_args'_v9647 = v9655 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9656 : (int32 -> Async<unit>) = Async.Sleep
                let v9657 : Async<unit> = v9656 10
                let _run_target_args'_v9647 = v9657 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9658 : (int32 -> Async<unit>) = Async.Sleep
                let v9659 : Async<unit> = v9658 10
                let _run_target_args'_v9647 = v9659 
                #endif
#else
                let v9660 : (int32 -> Async<unit>) = Async.Sleep
                let v9661 : Async<unit> = v9660 10
                let _run_target_args'_v9647 = v9661 
                #endif
                let v9662 : Async<unit> = _run_target_args'_v9647 
                do! v9662 
                let v9668 : int64 = v1 + 1L
                let v9669 : Async<int64> = method7(v0, v9668)
                return! v9669 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9904 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v19085 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v19085 
    #endif
#if FABLE_COMPILER_PYTHON
    let v19087 : unit = ()
    let _let'_v19087 =
        async {
            try
                let v28269 : bool = true
                method9(v28269, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v28504 : exn = ex
                let v28505 : int64 = v1 % 100L
                let v28506 : bool = v28505 = 0L
                if v28506 then
                    let v28607 : unit = ()
                    let v28608 : (unit -> unit) = closure4(v0, v28504)
                    let v28609 : unit = (fun () -> v28608 (); v28607) ()
                    ()
                (* run_target_args'
                let v28714 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v28715 : (int32 -> Async<unit>) = Async.Sleep
                let v28716 : Async<unit> = v28715 10
                let _run_target_args'_v28714 = v28716 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v28717 : (int32 -> Async<unit>) = Async.Sleep
                let v28718 : Async<unit> = v28717 10
                let _run_target_args'_v28714 = v28718 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v28719 : (int32 -> Async<unit>) = Async.Sleep
                let v28720 : Async<unit> = v28719 10
                let _run_target_args'_v28714 = v28720 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28721 : (int32 -> Async<unit>) = Async.Sleep
                let v28722 : Async<unit> = v28721 10
                let _run_target_args'_v28714 = v28722 
                #endif
#if FABLE_COMPILER_PYTHON
                let v28723 : (int32 -> Async<unit>) = Async.Sleep
                let v28724 : Async<unit> = v28723 10
                let _run_target_args'_v28714 = v28724 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28725 : (int32 -> Async<unit>) = Async.Sleep
                let v28726 : Async<unit> = v28725 10
                let _run_target_args'_v28714 = v28726 
                #endif
#else
                let v28727 : (int32 -> Async<unit>) = Async.Sleep
                let v28728 : Async<unit> = v28727 10
                let _run_target_args'_v28714 = v28728 
                #endif
                let v28729 : Async<unit> = _run_target_args'_v28714 
                do! v28729 
                let v28735 : int64 = v1 + 1L
                let v28736 : Async<int64> = method7(v0, v28735)
                return! v28736 
                (* indent
                ()
            indent *)
            (* try_unit
            let v28971 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v38152 : Async<int64> = _let'_v19087 
    let _run_target_args'_v6 = v38152 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v38154 : unit = ()
    let _let'_v38154 =
        async {
            try
                let v47336 : bool = true
                method9(v47336, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v47571 : exn = ex
                let v47572 : int64 = v1 % 100L
                let v47573 : bool = v47572 = 0L
                if v47573 then
                    let v47674 : unit = ()
                    let v47675 : (unit -> unit) = closure4(v0, v47571)
                    let v47676 : unit = (fun () -> v47675 (); v47674) ()
                    ()
                (* run_target_args'
                let v47781 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v47782 : (int32 -> Async<unit>) = Async.Sleep
                let v47783 : Async<unit> = v47782 10
                let _run_target_args'_v47781 = v47783 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v47784 : (int32 -> Async<unit>) = Async.Sleep
                let v47785 : Async<unit> = v47784 10
                let _run_target_args'_v47781 = v47785 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v47786 : (int32 -> Async<unit>) = Async.Sleep
                let v47787 : Async<unit> = v47786 10
                let _run_target_args'_v47781 = v47787 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v47788 : (int32 -> Async<unit>) = Async.Sleep
                let v47789 : Async<unit> = v47788 10
                let _run_target_args'_v47781 = v47789 
                #endif
#if FABLE_COMPILER_PYTHON
                let v47790 : (int32 -> Async<unit>) = Async.Sleep
                let v47791 : Async<unit> = v47790 10
                let _run_target_args'_v47781 = v47791 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v47792 : (int32 -> Async<unit>) = Async.Sleep
                let v47793 : Async<unit> = v47792 10
                let _run_target_args'_v47781 = v47793 
                #endif
#else
                let v47794 : (int32 -> Async<unit>) = Async.Sleep
                let v47795 : Async<unit> = v47794 10
                let _run_target_args'_v47781 = v47795 
                #endif
                let v47796 : Async<unit> = _run_target_args'_v47781 
                do! v47796 
                let v47802 : int64 = v1 + 1L
                let v47803 : Async<int64> = method7(v0, v47802)
                return! v47803 
                (* indent
                ()
            indent *)
            (* try_unit
            let v48038 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v57219 : Async<int64> = _let'_v38154 
    let _run_target_args'_v6 = v57219 
    #endif
#else
    let v57221 : unit = ()
    let _let'_v57221 =
        async {
            try
                let v66403 : bool = true
                method9(v66403, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v66638 : exn = ex
                let v66639 : int64 = v1 % 100L
                let v66640 : bool = v66639 = 0L
                if v66640 then
                    let v66741 : unit = ()
                    let v66742 : (unit -> unit) = closure4(v0, v66638)
                    let v66743 : unit = (fun () -> v66742 (); v66741) ()
                    ()
                (* run_target_args'
                let v66848 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66849 : (int32 -> Async<unit>) = Async.Sleep
                let v66850 : Async<unit> = v66849 10
                let _run_target_args'_v66848 = v66850 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v66851 : (int32 -> Async<unit>) = Async.Sleep
                let v66852 : Async<unit> = v66851 10
                let _run_target_args'_v66848 = v66852 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v66853 : (int32 -> Async<unit>) = Async.Sleep
                let v66854 : Async<unit> = v66853 10
                let _run_target_args'_v66848 = v66854 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v66855 : (int32 -> Async<unit>) = Async.Sleep
                let v66856 : Async<unit> = v66855 10
                let _run_target_args'_v66848 = v66856 
                #endif
#if FABLE_COMPILER_PYTHON
                let v66857 : (int32 -> Async<unit>) = Async.Sleep
                let v66858 : Async<unit> = v66857 10
                let _run_target_args'_v66848 = v66858 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v66859 : (int32 -> Async<unit>) = Async.Sleep
                let v66860 : Async<unit> = v66859 10
                let _run_target_args'_v66848 = v66860 
                #endif
#else
                let v66861 : (int32 -> Async<unit>) = Async.Sleep
                let v66862 : Async<unit> = v66861 10
                let _run_target_args'_v66848 = v66862 
                #endif
                let v66863 : Async<unit> = _run_target_args'_v66848 
                do! v66863 
                let v66869 : int64 = v1 + 1L
                let v66870 : Async<int64> = method7(v0, v66869)
                return! v66870 
                (* indent
                ()
            indent *)
            (* try_unit
            let v67105 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v76286 : Async<int64> = _let'_v57221 
    let _run_target_args'_v6 = v76286 
    #endif
    let v76287 : Async<int64> = _run_target_args'_v6 
    v76287
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
and method26 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : int64, v10 : string) : string =
    let v11 : string = method17()
    let v12 : Mut3 = {l0 = v11} : Mut3
    let v15 : string = "{ "
    let v16 : string = $"{v15}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure6(v12, v16)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v34 : string = "path"
    let v35 : string = $"{v34}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v12, v35)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v53 : string = " = "
    let v54 : string = $"{v53}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure6(v12, v54)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v71 : string = $"{v8}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure6(v12, v71)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v89 : string = "; "
    let v90 : string = $"{v89}"
    let v98 : unit = ()
    let v99 : (unit -> unit) = closure6(v12, v90)
    let v100 : unit = (fun () -> v99 (); v98) ()
    let v108 : string = "retry"
    let v109 : string = $"{v108}"
    let v117 : unit = ()
    let v118 : (unit -> unit) = closure6(v12, v109)
    let v119 : unit = (fun () -> v118 (); v117) ()
    let v126 : string = $"{v53}"
    let v134 : unit = ()
    let v135 : (unit -> unit) = closure6(v12, v126)
    let v136 : unit = (fun () -> v135 (); v134) ()
    let v146 : string = $"{v9}"
    let v154 : unit = ()
    let v155 : (unit -> unit) = closure6(v12, v146)
    let v156 : unit = (fun () -> v155 (); v154) ()
    let v163 : string = $"{v89}"
    let v171 : unit = ()
    let v172 : (unit -> unit) = closure6(v12, v163)
    let v173 : unit = (fun () -> v172 (); v171) ()
    let v181 : string = "ex"
    let v182 : string = $"{v181}"
    let v190 : unit = ()
    let v191 : (unit -> unit) = closure6(v12, v182)
    let v192 : unit = (fun () -> v191 (); v190) ()
    let v199 : string = $"{v53}"
    let v207 : unit = ()
    let v208 : (unit -> unit) = closure6(v12, v199)
    let v209 : unit = (fun () -> v208 (); v207) ()
    let v216 : string = $"{v10}"
    let v224 : unit = ()
    let v225 : (unit -> unit) = closure6(v12, v216)
    let v226 : unit = (fun () -> v225 (); v224) ()
    let v234 : string = " }"
    let v235 : string = $"{v234}"
    let v243 : unit = ()
    let v244 : (unit -> unit) = closure6(v12, v235)
    let v245 : unit = (fun () -> v244 (); v243) ()
    let v251 : string = v12.l0
    let v252 : int64 = v0.l0
    let v255 : string = " "
    let v256 : string = v6 + v255 
    let v260 : string = v256 + v7 
    let v265 : string = " #"
    let v266 : string = v260 + v265 
    let v270 : (int64 -> string) = _.ToString()
    let v271 : string = v270 v252
    let v275 : string = v266 + v271 
    let v279 : string = v275 + v255 
    let v284 : string = "file_system.wait_for_file_access"
    let v285 : string = v279 + v284 
    let v290 : string = " / "
    let v291 : string = v285 + v290 
    let v295 : string = v291 + v251 
    method21(v295)
and closure12 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v3 : US0 = US0_1
    let v4 : bool = method11(v3)
    if v4 then
        let v19 : unit = ()
        let v20 : (unit -> unit) = closure0()
        let v21 : unit = (fun () -> v20 (); v19) ()
        let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
        let v60 : string = method12(v42, v43, v44, v45, v46, v47)
        let v61 : string = method16()
        let v62 : string = method19(v0)
        (* run_target_args'
        let v67 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v69 : string = $"%A{v2}"
        let _run_target_args'_v67 = v69 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v73 : string = $"%A{v2}"
        let _run_target_args'_v67 = v73 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v77 : string = $"%A{v2}"
        let _run_target_args'_v67 = v77 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v81 : string = $"%A{v2}"
        let _run_target_args'_v67 = v81 
        #endif
#if FABLE_COMPILER_PYTHON
        let v85 : string = $"%A{v2}"
        let _run_target_args'_v67 = v85 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v89 : string = $"%A{v2}"
        let _run_target_args'_v67 = v89 
        #endif
#else
        let v92 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v67 = v92 
        #endif
        let v93 : string = _run_target_args'_v67 
        let v102 : string = method26(v42, v43, v44, v45, v46, v47, v60, v61, v62, v1, v93)
        method22(v102)
and method25 (v0 : US6, v1 : string, v2 : int64, v3 : US8, v4 : US7) : Async<int64> =
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
                let v11527 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11529 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11527 = v11529 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11533 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11527 = v11533 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11537 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11527 = v11537 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11541 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11527 = v11541 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11545 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11527 = v11545 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11549 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11527 = v11549 
                #endif
#else
                let v11552 : System.IO.FileMode = System.IO.FileMode.Open
                let v11558 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v11553 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v11553
                    | US7_2 -> (* AccessReadWrite *)
                        let v11555 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v11555
                    | US7_1 -> (* AccessWrite *)
                        let v11554 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v11554
                let v11568 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v11563 : System.IO.FileShare = System.IO.FileShare.Delete
                        v11563
                    | US8_0 -> (* ShareNone *)
                        let v11559 : System.IO.FileShare = System.IO.FileShare.None
                        v11559
                    | US8_1 -> (* ShareRead *)
                        let v11560 : System.IO.FileShare = System.IO.FileShare.Read
                        v11560
                    | US8_3 -> (* ShareReadWrite *)
                        let v11562 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v11562
                    | US8_2 -> (* ShareWrite *)
                        let v11561 : System.IO.FileShare = System.IO.FileShare.Write
                        v11561
                let v11569 : System.IO.FileStream = new System.IO.FileStream (v1, v11552, v11558, v11568)
                let _run_target_args'_v11527 = v11569 
                #endif
                let v11570 : System.IO.FileStream = _run_target_args'_v11527 
                use v11570 = v11570 
                let v11579 : System.IO.FileStream = v11570 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v11872 : exn = ex
                let v11873 : bool = v2 > 0L
                let v11876 : bool =
                    if v11873 then
                        let v11874 : int64 = v2 % 100L
                        let v11875 : bool = v11874 = 0L
                        v11875
                    else
                        false
                if v11876 then
                    let v11977 : unit = ()
                    let v11978 : (unit -> unit) = closure12(v1, v2, v11872)
                    let v11979 : unit = (fun () -> v11978 (); v11977) ()
                    ()
                (* run_target_args'
                let v12084 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v12085 : (int32 -> Async<unit>) = Async.Sleep
                let v12086 : Async<unit> = v12085 10
                let _run_target_args'_v12084 = v12086 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v12087 : (int32 -> Async<unit>) = Async.Sleep
                let v12088 : Async<unit> = v12087 10
                let _run_target_args'_v12084 = v12088 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v12089 : (int32 -> Async<unit>) = Async.Sleep
                let v12090 : Async<unit> = v12089 10
                let _run_target_args'_v12084 = v12090 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v12091 : (int32 -> Async<unit>) = Async.Sleep
                let v12092 : Async<unit> = v12091 10
                let _run_target_args'_v12084 = v12092 
                #endif
#if FABLE_COMPILER_PYTHON
                let v12093 : (int32 -> Async<unit>) = Async.Sleep
                let v12094 : Async<unit> = v12093 10
                let _run_target_args'_v12084 = v12094 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v12095 : (int32 -> Async<unit>) = Async.Sleep
                let v12096 : Async<unit> = v12095 10
                let _run_target_args'_v12084 = v12096 
                #endif
#else
                let v12097 : (int32 -> Async<unit>) = Async.Sleep
                let v12098 : Async<unit> = v12097 10
                let _run_target_args'_v12084 = v12098 
                #endif
                let v12099 : Async<unit> = _run_target_args'_v12084 
                do! v12099 
                let v12105 : int64 = v2 + 1L
                let v12106 : Async<int64> = method24(v0, v1, v12105)
                return! v12106 
                (* indent
                ()
            indent *)
            (* try_unit
            let v12343 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v23786 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v23786 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23788 : unit = ()
    let _let'_v23788 =
        async {
            try
                (* run_target_args'
                let v35292 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v35294 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v35292 = v35294 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v35298 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v35292 = v35298 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v35302 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v35292 = v35302 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v35306 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v35292 = v35306 
                #endif
#if FABLE_COMPILER_PYTHON
                let v35310 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v35292 = v35310 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v35314 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v35292 = v35314 
                #endif
#else
                let v35317 : System.IO.FileMode = System.IO.FileMode.Open
                let v35323 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v35318 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v35318
                    | US7_2 -> (* AccessReadWrite *)
                        let v35320 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v35320
                    | US7_1 -> (* AccessWrite *)
                        let v35319 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v35319
                let v35333 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v35328 : System.IO.FileShare = System.IO.FileShare.Delete
                        v35328
                    | US8_0 -> (* ShareNone *)
                        let v35324 : System.IO.FileShare = System.IO.FileShare.None
                        v35324
                    | US8_1 -> (* ShareRead *)
                        let v35325 : System.IO.FileShare = System.IO.FileShare.Read
                        v35325
                    | US8_3 -> (* ShareReadWrite *)
                        let v35327 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v35327
                    | US8_2 -> (* ShareWrite *)
                        let v35326 : System.IO.FileShare = System.IO.FileShare.Write
                        v35326
                let v35334 : System.IO.FileStream = new System.IO.FileStream (v1, v35317, v35323, v35333)
                let _run_target_args'_v35292 = v35334 
                #endif
                let v35335 : System.IO.FileStream = _run_target_args'_v35292 
                use v35335 = v35335 
                let v35344 : System.IO.FileStream = v35335 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v35637 : exn = ex
                let v35638 : bool = v2 > 0L
                let v35641 : bool =
                    if v35638 then
                        let v35639 : int64 = v2 % 100L
                        let v35640 : bool = v35639 = 0L
                        v35640
                    else
                        false
                if v35641 then
                    let v35742 : unit = ()
                    let v35743 : (unit -> unit) = closure12(v1, v2, v35637)
                    let v35744 : unit = (fun () -> v35743 (); v35742) ()
                    ()
                (* run_target_args'
                let v35849 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v35850 : (int32 -> Async<unit>) = Async.Sleep
                let v35851 : Async<unit> = v35850 10
                let _run_target_args'_v35849 = v35851 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v35852 : (int32 -> Async<unit>) = Async.Sleep
                let v35853 : Async<unit> = v35852 10
                let _run_target_args'_v35849 = v35853 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v35854 : (int32 -> Async<unit>) = Async.Sleep
                let v35855 : Async<unit> = v35854 10
                let _run_target_args'_v35849 = v35855 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v35856 : (int32 -> Async<unit>) = Async.Sleep
                let v35857 : Async<unit> = v35856 10
                let _run_target_args'_v35849 = v35857 
                #endif
#if FABLE_COMPILER_PYTHON
                let v35858 : (int32 -> Async<unit>) = Async.Sleep
                let v35859 : Async<unit> = v35858 10
                let _run_target_args'_v35849 = v35859 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v35860 : (int32 -> Async<unit>) = Async.Sleep
                let v35861 : Async<unit> = v35860 10
                let _run_target_args'_v35849 = v35861 
                #endif
#else
                let v35862 : (int32 -> Async<unit>) = Async.Sleep
                let v35863 : Async<unit> = v35862 10
                let _run_target_args'_v35849 = v35863 
                #endif
                let v35864 : Async<unit> = _run_target_args'_v35849 
                do! v35864 
                let v35870 : int64 = v2 + 1L
                let v35871 : Async<int64> = method24(v0, v1, v35870)
                return! v35871 
                (* indent
                ()
            indent *)
            (* try_unit
            let v36108 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v47551 : Async<int64> = _let'_v23788 
    let _run_target_args'_v9 = v47551 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v47553 : unit = ()
    let _let'_v47553 =
        async {
            try
                (* run_target_args'
                let v59057 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v59059 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v59057 = v59059 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v59063 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v59057 = v59063 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v59067 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v59057 = v59067 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v59071 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v59057 = v59071 
                #endif
#if FABLE_COMPILER_PYTHON
                let v59075 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v59057 = v59075 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v59079 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v59057 = v59079 
                #endif
#else
                let v59082 : System.IO.FileMode = System.IO.FileMode.Open
                let v59088 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v59083 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v59083
                    | US7_2 -> (* AccessReadWrite *)
                        let v59085 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v59085
                    | US7_1 -> (* AccessWrite *)
                        let v59084 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v59084
                let v59098 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v59093 : System.IO.FileShare = System.IO.FileShare.Delete
                        v59093
                    | US8_0 -> (* ShareNone *)
                        let v59089 : System.IO.FileShare = System.IO.FileShare.None
                        v59089
                    | US8_1 -> (* ShareRead *)
                        let v59090 : System.IO.FileShare = System.IO.FileShare.Read
                        v59090
                    | US8_3 -> (* ShareReadWrite *)
                        let v59092 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v59092
                    | US8_2 -> (* ShareWrite *)
                        let v59091 : System.IO.FileShare = System.IO.FileShare.Write
                        v59091
                let v59099 : System.IO.FileStream = new System.IO.FileStream (v1, v59082, v59088, v59098)
                let _run_target_args'_v59057 = v59099 
                #endif
                let v59100 : System.IO.FileStream = _run_target_args'_v59057 
                use v59100 = v59100 
                let v59109 : System.IO.FileStream = v59100 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v59402 : exn = ex
                let v59403 : bool = v2 > 0L
                let v59406 : bool =
                    if v59403 then
                        let v59404 : int64 = v2 % 100L
                        let v59405 : bool = v59404 = 0L
                        v59405
                    else
                        false
                if v59406 then
                    let v59507 : unit = ()
                    let v59508 : (unit -> unit) = closure12(v1, v2, v59402)
                    let v59509 : unit = (fun () -> v59508 (); v59507) ()
                    ()
                (* run_target_args'
                let v59614 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v59615 : (int32 -> Async<unit>) = Async.Sleep
                let v59616 : Async<unit> = v59615 10
                let _run_target_args'_v59614 = v59616 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v59617 : (int32 -> Async<unit>) = Async.Sleep
                let v59618 : Async<unit> = v59617 10
                let _run_target_args'_v59614 = v59618 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v59619 : (int32 -> Async<unit>) = Async.Sleep
                let v59620 : Async<unit> = v59619 10
                let _run_target_args'_v59614 = v59620 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v59621 : (int32 -> Async<unit>) = Async.Sleep
                let v59622 : Async<unit> = v59621 10
                let _run_target_args'_v59614 = v59622 
                #endif
#if FABLE_COMPILER_PYTHON
                let v59623 : (int32 -> Async<unit>) = Async.Sleep
                let v59624 : Async<unit> = v59623 10
                let _run_target_args'_v59614 = v59624 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v59625 : (int32 -> Async<unit>) = Async.Sleep
                let v59626 : Async<unit> = v59625 10
                let _run_target_args'_v59614 = v59626 
                #endif
#else
                let v59627 : (int32 -> Async<unit>) = Async.Sleep
                let v59628 : Async<unit> = v59627 10
                let _run_target_args'_v59614 = v59628 
                #endif
                let v59629 : Async<unit> = _run_target_args'_v59614 
                do! v59629 
                let v59635 : int64 = v2 + 1L
                let v59636 : Async<int64> = method24(v0, v1, v59635)
                return! v59636 
                (* indent
                ()
            indent *)
            (* try_unit
            let v59873 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v71316 : Async<int64> = _let'_v47553 
    let _run_target_args'_v9 = v71316 
    #endif
#else
    let v71318 : unit = ()
    let _let'_v71318 =
        async {
            try
                (* run_target_args'
                let v82822 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v82824 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v82822 = v82824 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v82828 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v82822 = v82828 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v82832 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v82822 = v82832 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v82836 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v82822 = v82836 
                #endif
#if FABLE_COMPILER_PYTHON
                let v82840 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v82822 = v82840 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v82844 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v82822 = v82844 
                #endif
#else
                let v82847 : System.IO.FileMode = System.IO.FileMode.Open
                let v82853 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v82848 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v82848
                    | US7_2 -> (* AccessReadWrite *)
                        let v82850 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v82850
                    | US7_1 -> (* AccessWrite *)
                        let v82849 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v82849
                let v82863 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v82858 : System.IO.FileShare = System.IO.FileShare.Delete
                        v82858
                    | US8_0 -> (* ShareNone *)
                        let v82854 : System.IO.FileShare = System.IO.FileShare.None
                        v82854
                    | US8_1 -> (* ShareRead *)
                        let v82855 : System.IO.FileShare = System.IO.FileShare.Read
                        v82855
                    | US8_3 -> (* ShareReadWrite *)
                        let v82857 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v82857
                    | US8_2 -> (* ShareWrite *)
                        let v82856 : System.IO.FileShare = System.IO.FileShare.Write
                        v82856
                let v82864 : System.IO.FileStream = new System.IO.FileStream (v1, v82847, v82853, v82863)
                let _run_target_args'_v82822 = v82864 
                #endif
                let v82865 : System.IO.FileStream = _run_target_args'_v82822 
                use v82865 = v82865 
                let v82874 : System.IO.FileStream = v82865 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v83167 : exn = ex
                let v83168 : bool = v2 > 0L
                let v83171 : bool =
                    if v83168 then
                        let v83169 : int64 = v2 % 100L
                        let v83170 : bool = v83169 = 0L
                        v83170
                    else
                        false
                if v83171 then
                    let v83272 : unit = ()
                    let v83273 : (unit -> unit) = closure12(v1, v2, v83167)
                    let v83274 : unit = (fun () -> v83273 (); v83272) ()
                    ()
                (* run_target_args'
                let v83379 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v83380 : (int32 -> Async<unit>) = Async.Sleep
                let v83381 : Async<unit> = v83380 10
                let _run_target_args'_v83379 = v83381 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v83382 : (int32 -> Async<unit>) = Async.Sleep
                let v83383 : Async<unit> = v83382 10
                let _run_target_args'_v83379 = v83383 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v83384 : (int32 -> Async<unit>) = Async.Sleep
                let v83385 : Async<unit> = v83384 10
                let _run_target_args'_v83379 = v83385 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v83386 : (int32 -> Async<unit>) = Async.Sleep
                let v83387 : Async<unit> = v83386 10
                let _run_target_args'_v83379 = v83387 
                #endif
#if FABLE_COMPILER_PYTHON
                let v83388 : (int32 -> Async<unit>) = Async.Sleep
                let v83389 : Async<unit> = v83388 10
                let _run_target_args'_v83379 = v83389 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v83390 : (int32 -> Async<unit>) = Async.Sleep
                let v83391 : Async<unit> = v83390 10
                let _run_target_args'_v83379 = v83391 
                #endif
#else
                let v83392 : (int32 -> Async<unit>) = Async.Sleep
                let v83393 : Async<unit> = v83392 10
                let _run_target_args'_v83379 = v83393 
                #endif
                let v83394 : Async<unit> = _run_target_args'_v83379 
                do! v83394 
                let v83400 : int64 = v2 + 1L
                let v83401 : Async<int64> = method24(v0, v1, v83400)
                return! v83401 
                (* indent
                ()
            indent *)
            (* try_unit
            let v83638 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v95081 : Async<int64> = _let'_v71318 
    let _run_target_args'_v9 = v95081 
    #endif
    let v95082 : Async<int64> = _run_target_args'_v9 
    v95082
and method24 (v0 : US6, v1 : string, v2 : int64) : Async<int64> =
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
    let v40 : Async<int64> = method25(v0, v1, v2, v39, v38)
    let _run_target_args'_v7 = v40 
    #endif
    let v41 : Async<int64> = _run_target_args'_v7 
    v41
and method23 (v0 : US6, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method24(v0, v1, v2)
and closure11 (v0 : US6) (v1 : string) : Async<int64> =
    method23(v0, v1)
and closure10 () (v0 : US6) : (string -> Async<int64>) =
    closure11(v0)
and method27 (v0 : string) : Async<int64> =
    let v1 : US7 = US7_0
    let v2 : US8 = US8_1
    let v3 : US6 = US6_0(v1, v2)
    method23(v3, v0)
and closure13 () (v0 : string) : Async<int64> =
    method27(v0)
and method31 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v9, v14)
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
    let v185 : string = method18()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[90m"
    let v201 : string = method18()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[90m"
    let v217 : string = method18()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[90m"
    let v233 : string = method18()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method32 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string, v10 : exn) : string =
    let v11 : string = method17()
    let v12 : Mut3 = {l0 = v11} : Mut3
    let v15 : string = "{ "
    let v16 : string = $"{v15}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure6(v12, v16)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v34 : string = "retry"
    let v35 : string = $"{v34}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v12, v35)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v53 : string = " = "
    let v54 : string = $"{v53}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure6(v12, v54)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v74 : string = $"{v8}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure6(v12, v74)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v92 : string = "; "
    let v93 : string = $"{v92}"
    let v101 : unit = ()
    let v102 : (unit -> unit) = closure6(v12, v93)
    let v103 : unit = (fun () -> v102 (); v101) ()
    let v111 : string = "path"
    let v112 : string = $"{v111}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure6(v12, v112)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v129 : string = $"{v53}"
    let v137 : unit = ()
    let v138 : (unit -> unit) = closure6(v12, v129)
    let v139 : unit = (fun () -> v138 (); v137) ()
    let v146 : string = $"{v9}"
    let v154 : unit = ()
    let v155 : (unit -> unit) = closure6(v12, v146)
    let v156 : unit = (fun () -> v155 (); v154) ()
    let v163 : string = $"{v92}"
    let v171 : unit = ()
    let v172 : (unit -> unit) = closure6(v12, v163)
    let v173 : unit = (fun () -> v172 (); v171) ()
    let v181 : string = "ex"
    let v182 : string = $"{v181}"
    let v190 : unit = ()
    let v191 : (unit -> unit) = closure6(v12, v182)
    let v192 : unit = (fun () -> v191 (); v190) ()
    let v199 : string = $"{v53}"
    let v207 : unit = ()
    let v208 : (unit -> unit) = closure6(v12, v199)
    let v209 : unit = (fun () -> v208 (); v207) ()
    (* run_target_args'
    let v219 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v220 : string = "format!(\"{:#?}\", $0)"
    let v221 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v220 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v221 v222 
    let _run_target_args'_v219 = v223 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v224 : string = "format!(\"{:#?}\", $0)"
    let v225 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v224 
    let v226 : string = "fable_library_rust::String_::fromString($0)"
    let v227 : string = Fable.Core.RustInterop.emitRustExpr v225 v226 
    let _run_target_args'_v219 = v227 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v228 : string = "format!(\"{:#?}\", $0)"
    let v229 : std_string_String = Fable.Core.RustInterop.emitRustExpr v10 v228 
    let v230 : string = "fable_library_rust::String_::fromString($0)"
    let v231 : string = Fable.Core.RustInterop.emitRustExpr v229 v230 
    let _run_target_args'_v219 = v231 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v233 : string = $"%A{v10}"
    let _run_target_args'_v219 = v233 
    #endif
#if FABLE_COMPILER_PYTHON
    let v237 : string = $"%A{v10}"
    let _run_target_args'_v219 = v237 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v241 : string = $"%A{v10}"
    let _run_target_args'_v219 = v241 
    #endif
#else
    let v245 : string = $"%A{v10}"
    let _run_target_args'_v219 = v245 
    #endif
    let v248 : string = _run_target_args'_v219 
    let v258 : string = $"{v248}"
    let v266 : unit = ()
    let v267 : (unit -> unit) = closure6(v12, v258)
    let v268 : unit = (fun () -> v267 (); v266) ()
    let v276 : string = " }"
    let v277 : string = $"{v276}"
    let v285 : unit = ()
    let v286 : (unit -> unit) = closure6(v12, v277)
    let v287 : unit = (fun () -> v286 (); v285) ()
    let v293 : string = v12.l0
    let v294 : int64 = v0.l0
    let v297 : string = " "
    let v298 : string = v6 + v297 
    let v302 : string = v298 + v7 
    let v307 : string = " #"
    let v308 : string = v302 + v307 
    let v312 : (int64 -> string) = _.ToString()
    let v313 : string = v312 v294
    let v317 : string = v308 + v313 
    let v321 : string = v317 + v297 
    let v326 : string = "file_system.read_all_text_async"
    let v327 : string = v321 + v326 
    let v332 : string = " / "
    let v333 : string = v327 + v332 
    let v337 : string = v333 + v293 
    method21(v337)
and closure15 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v3 : US0 = US0_0
    let v4 : bool = method11(v3)
    if v4 then
        let v19 : unit = ()
        let v20 : (unit -> unit) = closure0()
        let v21 : unit = (fun () -> v20 (); v19) ()
        let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
        let v60 : string = method12(v42, v43, v44, v45, v46, v47)
        let v61 : string = method31()
        let v62 : string = method32(v42, v43, v44, v45, v46, v47, v60, v61, v1, v0, v2)
        method22(v62)
and method30 (v0 : string, v1 : int64) : Async<string> =
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
                let v9084 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9086 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v9084 = v9086 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9090 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v9084 = v9090 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9094 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v9084 = v9094 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9098 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v9084 = v9098 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9102 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v9084 = v9102 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9106 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v9084 = v9106 
                #endif
#else
                let v9109 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v9110 : System.Threading.Tasks.Task<string> = v9109 v0
                let _run_target_args'_v9084 = v9110 
                #endif
                let v9111 : System.Threading.Tasks.Task<string> = _run_target_args'_v9084 
                (* run_target_args'
                let v9124 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9126 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v9124 = v9126 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9130 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v9124 = v9130 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9134 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v9124 = v9134 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9137 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v9138 : Async<string> = v9137 v9111
                let _run_target_args'_v9124 = v9138 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9139 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v9140 : Async<string> = v9139 v9111
                let _run_target_args'_v9124 = v9140 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9141 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v9142 : Async<string> = v9141 v9111
                let _run_target_args'_v9124 = v9142 
                #endif
#else
                let v9143 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v9144 : Async<string> = v9143 v9111
                let _run_target_args'_v9124 = v9144 
                #endif
                let v9145 : Async<string> = _run_target_args'_v9124 
                return! v9145 
                (* indent
                ()
            indent *)
            with ex ->
                let v9383 : exn = ex
                let v9444 : unit = ()
                let v9445 : (unit -> unit) = closure15(v0, v1, v9383)
                let v9446 : unit = (fun () -> v9445 (); v9444) ()
                (* run_target_args'
                let v9511 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9512 : (int32 -> Async<unit>) = Async.Sleep
                let v9513 : Async<unit> = v9512 10
                let _run_target_args'_v9511 = v9513 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9514 : (int32 -> Async<unit>) = Async.Sleep
                let v9515 : Async<unit> = v9514 10
                let _run_target_args'_v9511 = v9515 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9516 : (int32 -> Async<unit>) = Async.Sleep
                let v9517 : Async<unit> = v9516 10
                let _run_target_args'_v9511 = v9517 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9518 : (int32 -> Async<unit>) = Async.Sleep
                let v9519 : Async<unit> = v9518 10
                let _run_target_args'_v9511 = v9519 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9520 : (int32 -> Async<unit>) = Async.Sleep
                let v9521 : Async<unit> = v9520 10
                let _run_target_args'_v9511 = v9521 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9522 : (int32 -> Async<unit>) = Async.Sleep
                let v9523 : Async<unit> = v9522 10
                let _run_target_args'_v9511 = v9523 
                #endif
#else
                let v9524 : (int32 -> Async<unit>) = Async.Sleep
                let v9525 : Async<unit> = v9524 10
                let _run_target_args'_v9511 = v9525 
                #endif
                let v9526 : Async<unit> = _run_target_args'_v9511 
                do! v9526 
                let v9532 : bool = v1 < 3L
                let v9537 : Async<string> =
                    if v9532 then
                        let v9533 : int64 = v1 + 1L
                        method29(v0, v9533)
                    else
                        let v9535 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v9535
                return! v9537 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9694 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v18680 : Async<string> = _let'_v20 
    let _run_target_args'_v6 = v18680 
    #endif
#if FABLE_COMPILER_PYTHON
    let v18682 : unit = ()
    let _let'_v18682 =
        async {
            try
                (* run_target_args'
                let v27746 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v27748 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27746 = v27748 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v27752 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27746 = v27752 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v27756 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27746 = v27756 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v27760 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27746 = v27760 
                #endif
#if FABLE_COMPILER_PYTHON
                let v27764 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27746 = v27764 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v27768 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v27746 = v27768 
                #endif
#else
                let v27771 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v27772 : System.Threading.Tasks.Task<string> = v27771 v0
                let _run_target_args'_v27746 = v27772 
                #endif
                let v27773 : System.Threading.Tasks.Task<string> = _run_target_args'_v27746 
                (* run_target_args'
                let v27786 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v27788 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v27786 = v27788 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v27792 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v27786 = v27792 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v27796 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v27786 = v27796 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v27799 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v27800 : Async<string> = v27799 v27773
                let _run_target_args'_v27786 = v27800 
                #endif
#if FABLE_COMPILER_PYTHON
                let v27801 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v27802 : Async<string> = v27801 v27773
                let _run_target_args'_v27786 = v27802 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v27803 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v27804 : Async<string> = v27803 v27773
                let _run_target_args'_v27786 = v27804 
                #endif
#else
                let v27805 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v27806 : Async<string> = v27805 v27773
                let _run_target_args'_v27786 = v27806 
                #endif
                let v27807 : Async<string> = _run_target_args'_v27786 
                return! v27807 
                (* indent
                ()
            indent *)
            with ex ->
                let v28045 : exn = ex
                let v28106 : unit = ()
                let v28107 : (unit -> unit) = closure15(v0, v1, v28045)
                let v28108 : unit = (fun () -> v28107 (); v28106) ()
                (* run_target_args'
                let v28173 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v28174 : (int32 -> Async<unit>) = Async.Sleep
                let v28175 : Async<unit> = v28174 10
                let _run_target_args'_v28173 = v28175 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v28176 : (int32 -> Async<unit>) = Async.Sleep
                let v28177 : Async<unit> = v28176 10
                let _run_target_args'_v28173 = v28177 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v28178 : (int32 -> Async<unit>) = Async.Sleep
                let v28179 : Async<unit> = v28178 10
                let _run_target_args'_v28173 = v28179 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28180 : (int32 -> Async<unit>) = Async.Sleep
                let v28181 : Async<unit> = v28180 10
                let _run_target_args'_v28173 = v28181 
                #endif
#if FABLE_COMPILER_PYTHON
                let v28182 : (int32 -> Async<unit>) = Async.Sleep
                let v28183 : Async<unit> = v28182 10
                let _run_target_args'_v28173 = v28183 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28184 : (int32 -> Async<unit>) = Async.Sleep
                let v28185 : Async<unit> = v28184 10
                let _run_target_args'_v28173 = v28185 
                #endif
#else
                let v28186 : (int32 -> Async<unit>) = Async.Sleep
                let v28187 : Async<unit> = v28186 10
                let _run_target_args'_v28173 = v28187 
                #endif
                let v28188 : Async<unit> = _run_target_args'_v28173 
                do! v28188 
                let v28194 : bool = v1 < 3L
                let v28199 : Async<string> =
                    if v28194 then
                        let v28195 : int64 = v1 + 1L
                        method29(v0, v28195)
                    else
                        let v28197 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v28197
                return! v28199 
                (* indent
                ()
            indent *)
            (* try_unit
            let v28356 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v37342 : Async<string> = _let'_v18682 
    let _run_target_args'_v6 = v37342 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v37344 : unit = ()
    let _let'_v37344 =
        async {
            try
                (* run_target_args'
                let v46408 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v46410 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v46408 = v46410 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v46414 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v46408 = v46414 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v46418 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v46408 = v46418 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v46422 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v46408 = v46422 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46426 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v46408 = v46426 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v46430 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v46408 = v46430 
                #endif
#else
                let v46433 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v46434 : System.Threading.Tasks.Task<string> = v46433 v0
                let _run_target_args'_v46408 = v46434 
                #endif
                let v46435 : System.Threading.Tasks.Task<string> = _run_target_args'_v46408 
                (* run_target_args'
                let v46448 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v46450 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v46448 = v46450 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v46454 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v46448 = v46454 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v46458 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v46448 = v46458 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v46461 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v46462 : Async<string> = v46461 v46435
                let _run_target_args'_v46448 = v46462 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46463 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v46464 : Async<string> = v46463 v46435
                let _run_target_args'_v46448 = v46464 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v46465 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v46466 : Async<string> = v46465 v46435
                let _run_target_args'_v46448 = v46466 
                #endif
#else
                let v46467 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v46468 : Async<string> = v46467 v46435
                let _run_target_args'_v46448 = v46468 
                #endif
                let v46469 : Async<string> = _run_target_args'_v46448 
                return! v46469 
                (* indent
                ()
            indent *)
            with ex ->
                let v46707 : exn = ex
                let v46768 : unit = ()
                let v46769 : (unit -> unit) = closure15(v0, v1, v46707)
                let v46770 : unit = (fun () -> v46769 (); v46768) ()
                (* run_target_args'
                let v46835 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v46836 : (int32 -> Async<unit>) = Async.Sleep
                let v46837 : Async<unit> = v46836 10
                let _run_target_args'_v46835 = v46837 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v46838 : (int32 -> Async<unit>) = Async.Sleep
                let v46839 : Async<unit> = v46838 10
                let _run_target_args'_v46835 = v46839 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v46840 : (int32 -> Async<unit>) = Async.Sleep
                let v46841 : Async<unit> = v46840 10
                let _run_target_args'_v46835 = v46841 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v46842 : (int32 -> Async<unit>) = Async.Sleep
                let v46843 : Async<unit> = v46842 10
                let _run_target_args'_v46835 = v46843 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46844 : (int32 -> Async<unit>) = Async.Sleep
                let v46845 : Async<unit> = v46844 10
                let _run_target_args'_v46835 = v46845 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v46846 : (int32 -> Async<unit>) = Async.Sleep
                let v46847 : Async<unit> = v46846 10
                let _run_target_args'_v46835 = v46847 
                #endif
#else
                let v46848 : (int32 -> Async<unit>) = Async.Sleep
                let v46849 : Async<unit> = v46848 10
                let _run_target_args'_v46835 = v46849 
                #endif
                let v46850 : Async<unit> = _run_target_args'_v46835 
                do! v46850 
                let v46856 : bool = v1 < 3L
                let v46861 : Async<string> =
                    if v46856 then
                        let v46857 : int64 = v1 + 1L
                        method29(v0, v46857)
                    else
                        let v46859 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v46859
                return! v46861 
                (* indent
                ()
            indent *)
            (* try_unit
            let v47018 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v56004 : Async<string> = _let'_v37344 
    let _run_target_args'_v6 = v56004 
    #endif
#else
    let v56006 : unit = ()
    let _let'_v56006 =
        async {
            try
                (* run_target_args'
                let v65070 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v65072 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v65070 = v65072 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v65076 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v65070 = v65076 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v65080 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v65070 = v65080 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v65084 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v65070 = v65084 
                #endif
#if FABLE_COMPILER_PYTHON
                let v65088 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v65070 = v65088 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v65092 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v65070 = v65092 
                #endif
#else
                let v65095 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v65096 : System.Threading.Tasks.Task<string> = v65095 v0
                let _run_target_args'_v65070 = v65096 
                #endif
                let v65097 : System.Threading.Tasks.Task<string> = _run_target_args'_v65070 
                (* run_target_args'
                let v65110 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v65112 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v65110 = v65112 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v65116 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v65110 = v65116 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v65120 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v65110 = v65120 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v65123 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v65124 : Async<string> = v65123 v65097
                let _run_target_args'_v65110 = v65124 
                #endif
#if FABLE_COMPILER_PYTHON
                let v65125 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v65126 : Async<string> = v65125 v65097
                let _run_target_args'_v65110 = v65126 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v65127 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v65128 : Async<string> = v65127 v65097
                let _run_target_args'_v65110 = v65128 
                #endif
#else
                let v65129 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v65130 : Async<string> = v65129 v65097
                let _run_target_args'_v65110 = v65130 
                #endif
                let v65131 : Async<string> = _run_target_args'_v65110 
                return! v65131 
                (* indent
                ()
            indent *)
            with ex ->
                let v65369 : exn = ex
                let v65430 : unit = ()
                let v65431 : (unit -> unit) = closure15(v0, v1, v65369)
                let v65432 : unit = (fun () -> v65431 (); v65430) ()
                (* run_target_args'
                let v65497 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v65498 : (int32 -> Async<unit>) = Async.Sleep
                let v65499 : Async<unit> = v65498 10
                let _run_target_args'_v65497 = v65499 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v65500 : (int32 -> Async<unit>) = Async.Sleep
                let v65501 : Async<unit> = v65500 10
                let _run_target_args'_v65497 = v65501 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v65502 : (int32 -> Async<unit>) = Async.Sleep
                let v65503 : Async<unit> = v65502 10
                let _run_target_args'_v65497 = v65503 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v65504 : (int32 -> Async<unit>) = Async.Sleep
                let v65505 : Async<unit> = v65504 10
                let _run_target_args'_v65497 = v65505 
                #endif
#if FABLE_COMPILER_PYTHON
                let v65506 : (int32 -> Async<unit>) = Async.Sleep
                let v65507 : Async<unit> = v65506 10
                let _run_target_args'_v65497 = v65507 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v65508 : (int32 -> Async<unit>) = Async.Sleep
                let v65509 : Async<unit> = v65508 10
                let _run_target_args'_v65497 = v65509 
                #endif
#else
                let v65510 : (int32 -> Async<unit>) = Async.Sleep
                let v65511 : Async<unit> = v65510 10
                let _run_target_args'_v65497 = v65511 
                #endif
                let v65512 : Async<unit> = _run_target_args'_v65497 
                do! v65512 
                let v65518 : bool = v1 < 3L
                let v65523 : Async<string> =
                    if v65518 then
                        let v65519 : int64 = v1 + 1L
                        method29(v0, v65519)
                    else
                        let v65521 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v65521
                return! v65523 
                (* indent
                ()
            indent *)
            (* try_unit
            let v65680 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v74666 : Async<string> = _let'_v56006 
    let _run_target_args'_v6 = v74666 
    #endif
    let v74667 : Async<string> = _run_target_args'_v6 
    v74667
and method29 (v0 : string, v1 : int64) : Async<string> =
    method30(v0, v1)
and method28 (v0 : string) : Async<string> =
    let v1 : int64 = 0L
    method29(v0, v1)
and closure14 () (v0 : string) : Async<string> =
    method28(v0)
and method34 (v0 : string) : bool =
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
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : string = "String::from($0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v47 
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v49 
    let _run_target_args'_v46 = v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v51 
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v62 
    #endif
#else
    let v66 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v66 
    #endif
    let v69 : std_string_String = _run_target_args'_v46 
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : string = "std::path::PathBuf::from($0)"
    let v84 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v83 
    let _run_target_args'_v82 = v84 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v85 : string = "std::path::PathBuf::from($0)"
    let v86 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v85 
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v87 : string = "std::path::PathBuf::from($0)"
    let v88 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v87 
    let _run_target_args'_v82 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v98 
    #endif
#else
    let v102 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v102 
    #endif
    let v105 : std_path_PathBuf = _run_target_args'_v82 
    let v114 : string = "$0.exists()"
    let v115 : bool = Fable.Core.RustInterop.emitRustExpr v105 v114 
    let v118 : bool =
        if v115 then
            let v116 : string = "$0.is_file()"
            let v117 : bool = Fable.Core.RustInterop.emitRustExpr v105 v116 
            v117
        else
            false
    let _run_target_args'_v5 = v118 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v120 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v120 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v124 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v124 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v127 : string = "fs"
    let v128 : IFsExistsSync = Fable.Core.JsInterop.importAll v127 
    let v129 : string = "$0.existsSync($1)"
    let v130 : bool = Fable.Core.JsInterop.emitJsExpr struct (v128, v0) v129 
    let _run_target_args'_v5 = v130 
    #endif
#if FABLE_COMPILER_PYTHON
    let v132 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v132 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : bool = null |> unbox<bool>
    let _run_target_args'_v5 = v136 
    #endif
#else
    let v139 : (string -> bool) = System.IO.File.Exists
    let v140 : bool = v139 v0
    let _run_target_args'_v5 = v140 
    #endif
    let v141 : bool = _run_target_args'_v5 
    v141
and method35 (v0 : Vec<uint8>) : Vec<uint8> =
    v0
and method33 (v0 : string, v1 : string) : bool =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : bool = method34(v0)
    let v8 : bool = v7 = false
    let v119 : bool =
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
            let v68 : Vec<uint8> = method35(v59)
            let v69 : string = "std::string::String::from_utf8($0)"
            let v70 : Result<std_string_String, std_string_FromUtf8Error> = Fable.Core.RustInterop.emitRustExpr v68 v69 
            (* run_target_args'
            let v72 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v73 : string = "$0.unwrap()"
            let v74 : std_string_String = Fable.Core.RustInterop.emitRustExpr v70 v73 
            let _run_target_args'_v72 = v74 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v75 : string = "$0.unwrap()"
            let v76 : std_string_String = Fable.Core.RustInterop.emitRustExpr v70 v75 
            let _run_target_args'_v72 = v76 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v77 : string = "$0.unwrap()"
            let v78 : std_string_String = Fable.Core.RustInterop.emitRustExpr v70 v77 
            let _run_target_args'_v72 = v78 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v79 : std_string_String = match v70 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v72 = v79 
            #endif
#if FABLE_COMPILER_PYTHON
            let v80 : std_string_String = match v70 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v72 = v80 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v81 : std_string_String = match v70 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v72 = v81 
            #endif
#else
            let v82 : std_string_String = match v70 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v72 = v82 
            #endif
            let v83 : std_string_String = _run_target_args'_v72 
            let v86 : string = "fable_library_rust::String_::fromString($0)"
            let v87 : string = Fable.Core.RustInterop.emitRustExpr v83 v86 
            let _run_target_args'_v13 = v87 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v89 : string = null |> unbox<string>
            let _run_target_args'_v13 = v89 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v93 : string = null |> unbox<string>
            let _run_target_args'_v13 = v93 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v97 : string = null |> unbox<string>
            let _run_target_args'_v13 = v97 
            #endif
#if FABLE_COMPILER_PYTHON
            let v101 : string = null |> unbox<string>
            let _run_target_args'_v13 = v101 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v105 : string = null |> unbox<string>
            let _run_target_args'_v13 = v105 
            #endif
#else
            let v108 : string = v0 |> System.IO.File.ReadAllText
            let _run_target_args'_v13 = v108 
            #endif
            let v109 : string = _run_target_args'_v13 
            let v118 : bool = v1 = v109
            v118
    let _run_target_args'_v6 = v119 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v121 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v121 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v125 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v125 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v129 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v129 
    #endif
#if FABLE_COMPILER_PYTHON
    let v133 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v133 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v137 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v137 
    #endif
#else
    let v141 : bool = null |> unbox<bool>
    let _run_target_args'_v6 = v141 
    #endif
    let v144 : bool = _run_target_args'_v6 
    v144
and closure17 (v0 : string) (v1 : string) : bool =
    method33(v0, v1)
and closure16 () (v0 : string) : (string -> bool) =
    closure17(v0)
and method36 (v0 : string, v1 : string) : Async<unit> =
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
    let v66 : Async<unit> = _run_target_args'_v6 
    v66
and closure19 (v0 : string) (v1 : string) : Async<unit> =
    method36(v0, v1)
and closure18 () (v0 : string) : (string -> Async<unit>) =
    closure19(v0)
and method40 (v0 : string, v1 : string) : Async<bool> =
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
            let v88 : bool = method34(v0)
            let v89 : bool = v88 = false
            if v89 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v90 : Async<string> = method28(v0)
                let! v90 = v90 
                let v91 : string = v90 
                let v92 : bool = v1 = v91
                return v92 
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
    let v158 : Async<bool> = _let'_v20 
    let _run_target_args'_v6 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v160 : unit = ()
    let _let'_v160 =
        async {
            let v228 : bool = method34(v0)
            let v229 : bool = v228 = false
            if v229 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v230 : Async<string> = method28(v0)
                let! v230 = v230 
                let v231 : string = v230 
                let v232 : bool = v1 = v231
                return v232 
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
    let v298 : Async<bool> = _let'_v160 
    let _run_target_args'_v6 = v298 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v300 : unit = ()
    let _let'_v300 =
        async {
            let v368 : bool = method34(v0)
            let v369 : bool = v368 = false
            if v369 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v370 : Async<string> = method28(v0)
                let! v370 = v370 
                let v371 : string = v370 
                let v372 : bool = v1 = v371
                return v372 
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
    let v438 : Async<bool> = _let'_v300 
    let _run_target_args'_v6 = v438 
    #endif
#else
    let v440 : unit = ()
    let _let'_v440 =
        async {
            let v508 : bool = method34(v0)
            let v509 : bool = v508 = false
            if v509 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v510 : Async<string> = method28(v0)
                let! v510 = v510 
                let v511 : string = v510 
                let v512 : bool = v1 = v511
                return v512 
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
    let v578 : Async<bool> = _let'_v440 
    let _run_target_args'_v6 = v578 
    #endif
    let v579 : Async<bool> = _run_target_args'_v6 
    v579
and method39 (v0 : string, v1 : string) : Async<bool> =
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
    let v31 : Async<bool> = method40(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<bool> = _run_target_args'_v6 
    v32
and method38 (v0 : string, v1 : string) : Async<unit> =
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
            let v75 : Async<bool> = method39(v0, v1)
            let! v75 = v75 
            let v76 : bool = v75 
            let v77 : bool = v76 = false
            if v77 then
                let v78 : Async<unit> = method36(v0, v1)
                do! v78 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v131 : Async<unit> = _let'_v20 
    let _run_target_args'_v6 = v131 
    #endif
#if FABLE_COMPILER_PYTHON
    let v133 : unit = ()
    let _let'_v133 =
        async {
            let v188 : Async<bool> = method39(v0, v1)
            let! v188 = v188 
            let v189 : bool = v188 
            let v190 : bool = v189 = false
            if v190 then
                let v191 : Async<unit> = method36(v0, v1)
                do! v191 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v244 : Async<unit> = _let'_v133 
    let _run_target_args'_v6 = v244 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : unit = ()
    let _let'_v246 =
        async {
            let v301 : Async<bool> = method39(v0, v1)
            let! v301 = v301 
            let v302 : bool = v301 
            let v303 : bool = v302 = false
            if v303 then
                let v304 : Async<unit> = method36(v0, v1)
                do! v304 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v357 : Async<unit> = _let'_v246 
    let _run_target_args'_v6 = v357 
    #endif
#else
    let v359 : unit = ()
    let _let'_v359 =
        async {
            let v414 : Async<bool> = method39(v0, v1)
            let! v414 = v414 
            let v415 : bool = v414 
            let v416 : bool = v415 = false
            if v416 then
                let v417 : Async<unit> = method36(v0, v1)
                do! v417 
                ()
            ()
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v470 : Async<unit> = _let'_v359 
    let _run_target_args'_v6 = v470 
    #endif
    let v471 : Async<unit> = _run_target_args'_v6 
    v471
and method37 (v0 : string, v1 : string) : Async<unit> =
    method38(v0, v1)
and closure21 (v0 : string) (v1 : string) : Async<unit> =
    method37(v0, v1)
and closure20 () (v0 : string) : (string -> Async<unit>) =
    closure21(v0)
and closure23 () (v0 : std_io_Error) : string =
    let v1 : string = method17()
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
    let v46 : string = $"{v36}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure6(v2, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v62 : string = v2.l0
    v62
and method44 () : (std_io_Error -> string) =
    closure23()
and closure24 () () : US9 =
    US9_0
and method45 () : (unit -> US9) =
    closure24()
and closure25 () (v0 : string) : US9 =
    US9_1(v0)
and method46 () : (string -> US9) =
    closure25()
and method47 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v9, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v30 : string = v9.l0
    (* run_target_args'
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "inline_colorization::color_bright_red"
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
    let v92 : string = "inline_colorization::color_bright_red"
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
    let v136 : string = "inline_colorization::color_bright_red"
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
    let v181 : string = "\u001b[91m"
    let v185 : string = method18()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[91m"
    let v201 : string = method18()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[91m"
    let v217 : string = method18()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[91m"
    let v233 : string = method18()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method48 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method17()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "error'"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v69 : string = $"{v8}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v10, v69)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v87 : string = " }"
    let v88 : string = $"{v87}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure6(v10, v88)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v104 : string = v10.l0
    let v105 : int64 = v0.l0
    let v108 : string = " "
    let v109 : string = v6 + v108 
    let v113 : string = v109 + v7 
    let v118 : string = " #"
    let v119 : string = v113 + v118 
    let v123 : (int64 -> string) = _.ToString()
    let v124 : string = v123 v105
    let v128 : string = v119 + v124 
    let v132 : string = v128 + v108 
    let v137 : string = "file_system.file_delete"
    let v138 : string = v132 + v137 
    let v143 : string = " / "
    let v144 : string = v138 + v143 
    let v148 : string = v144 + v104 
    method21(v148)
and closure26 (v0 : string) () : unit =
    let v1 : US0 = US0_4
    let v2 : bool = method11(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure0()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method12(v40, v41, v42, v43, v44, v45)
        let v59 : string = method47()
        let v60 : string = method48(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method22(v60)
and method49 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17()
    let v9 : Mut3 = {l0 = v8} : Mut3
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v9, v14)
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
    let v185 : string = method18()
    let v189 : string = v181 + v30 
    let v193 : string = v189 + v185 
    let _run_target_args'_v47 = v193 
    #endif
#if FABLE_COMPILER_PYTHON
    let v197 : string = "\u001b[93m"
    let v201 : string = method18()
    let v205 : string = v197 + v30 
    let v209 : string = v205 + v201 
    let _run_target_args'_v47 = v209 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v213 : string = "\u001b[93m"
    let v217 : string = method18()
    let v221 : string = v213 + v30 
    let v225 : string = v221 + v217 
    let _run_target_args'_v47 = v225 
    #endif
#else
    let v229 : string = "\u001b[93m"
    let v233 : string = method18()
    let v237 : string = v229 + v30 
    let v241 : string = v237 + v233 
    let _run_target_args'_v47 = v241 
    #endif
    let v244 : string = _run_target_args'_v47 
    v244
and method50 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "path"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v70 : string = $"{v8}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure6(v11, v70)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v88 : string = "; "
    let v89 : string = $"{v88}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure6(v11, v89)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v107 : string = "ex"
    let v108 : string = $"{v107}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure6(v11, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v125 : string = $"{v52}"
    let v133 : unit = ()
    let v134 : (unit -> unit) = closure6(v11, v125)
    let v135 : unit = (fun () -> v134 (); v133) ()
    let v142 : string = $"{v9}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure6(v11, v142)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v160 : string = " }"
    let v161 : string = $"{v160}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure6(v11, v161)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v177 : string = v11.l0
    let v178 : int64 = v0.l0
    let v181 : string = " "
    let v182 : string = v6 + v181 
    let v186 : string = v182 + v7 
    let v191 : string = " #"
    let v192 : string = v186 + v191 
    let v196 : (int64 -> string) = _.ToString()
    let v197 : string = v196 v178
    let v201 : string = v192 + v197 
    let v205 : string = v201 + v181 
    let v210 : string = "delete_file_async"
    let v211 : string = v205 + v210 
    let v216 : string = " / "
    let v217 : string = v211 + v216 
    let v221 : string = v217 + v177 
    method21(v221)
and closure27 (v0 : string, v1 : exn) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method49()
        let v61 : string = method19(v0)
        (* run_target_args'
        let v66 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v68 : string = $"%A{v1}"
        let _run_target_args'_v66 = v68 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v72 : string = $"%A{v1}"
        let _run_target_args'_v66 = v72 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v76 : string = $"%A{v1}"
        let _run_target_args'_v66 = v76 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v80 : string = $"%A{v1}"
        let _run_target_args'_v66 = v80 
        #endif
#if FABLE_COMPILER_PYTHON
        let v84 : string = $"%A{v1}"
        let _run_target_args'_v66 = v84 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v88 : string = $"%A{v1}"
        let _run_target_args'_v66 = v88 
        #endif
#else
        let v91 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v66 = v91 
        #endif
        let v92 : string = _run_target_args'_v66 
        let v101 : string = method50(v41, v42, v43, v44, v45, v46, v59, v60, v61, v92)
        method22(v101)
and method43 (v0 : string, v1 : int64) : Async<int64> =
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
                let v15162 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v15163 : string = "std::fs::remove_file(&*$0)"
                let v15164 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v15163 
                let v15165 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v15167 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v15168 : string = "$0.map_err(|x| $1(x))"
                let v15169 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v15164, v15165) v15168 
                let _run_target_args'_v15167 = v15169 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v15170 : string = "$0.map_err(|x| $1(x))"
                let v15171 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v15164, v15165) v15170 
                let _run_target_args'_v15167 = v15171 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v15172 : string = "$0.map_err(|x| $1(x))"
                let v15173 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v15164, v15165) v15172 
                let _run_target_args'_v15167 = v15173 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v15174 : Result<unit, string> = match v15164 with Ok x -> Ok x | Error x -> Error (v15165 x)
                let _run_target_args'_v15167 = v15174 
                #endif
#if FABLE_COMPILER_PYTHON
                let v15175 : Result<unit, string> = match v15164 with Ok x -> Ok x | Error x -> Error (v15165 x)
                let _run_target_args'_v15167 = v15175 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v15176 : Result<unit, string> = match v15164 with Ok x -> Ok x | Error x -> Error (v15165 x)
                let _run_target_args'_v15167 = v15176 
                #endif
#else
                let v15177 : Result<unit, string> = match v15164 with Ok x -> Ok x | Error x -> Error (v15165 x)
                let _run_target_args'_v15167 = v15177 
                #endif
                let v15178 : Result<unit, string> = _run_target_args'_v15167 
                let v15181 : (unit -> US9) = method45()
                let v15182 : (string -> US9) = method46()
                let v15184 : US9 = match v15178 with Ok () -> v15181 () | Error x -> v15182 x
                match v15184 with
                | US9_1(v15187) -> (* Error *)
                    let v15248 : unit = ()
                    let v15249 : (unit -> unit) = closure26(v15187)
                    let v15250 : unit = (fun () -> v15249 (); v15248) ()
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
                let v15311 : (string -> unit) = System.IO.File.Delete
                v15311 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v15695 : exn = ex
                let v15696 : int64 = v1 % 100L
                let v15697 : bool = v15696 = 0L
                if v15697 then
                    let v15798 : unit = ()
                    let v15799 : (unit -> unit) = closure27(v0, v15695)
                    let v15800 : unit = (fun () -> v15799 (); v15798) ()
                    ()
                (* run_target_args'
                let v15905 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v15906 : (int32 -> Async<unit>) = Async.Sleep
                let v15907 : Async<unit> = v15906 10
                let _run_target_args'_v15905 = v15907 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v15908 : (int32 -> Async<unit>) = Async.Sleep
                let v15909 : Async<unit> = v15908 10
                let _run_target_args'_v15905 = v15909 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v15910 : (int32 -> Async<unit>) = Async.Sleep
                let v15911 : Async<unit> = v15910 10
                let _run_target_args'_v15905 = v15911 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v15912 : (int32 -> Async<unit>) = Async.Sleep
                let v15913 : Async<unit> = v15912 10
                let _run_target_args'_v15905 = v15913 
                #endif
#if FABLE_COMPILER_PYTHON
                let v15914 : (int32 -> Async<unit>) = Async.Sleep
                let v15915 : Async<unit> = v15914 10
                let _run_target_args'_v15905 = v15915 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v15916 : (int32 -> Async<unit>) = Async.Sleep
                let v15917 : Async<unit> = v15916 10
                let _run_target_args'_v15905 = v15917 
                #endif
#else
                let v15918 : (int32 -> Async<unit>) = Async.Sleep
                let v15919 : Async<unit> = v15918 10
                let _run_target_args'_v15905 = v15919 
                #endif
                let v15920 : Async<unit> = _run_target_args'_v15905 
                do! v15920 
                let v15926 : int64 = v1 + 1L
                let v15927 : Async<int64> = method42(v0, v15926)
                return! v15927 
                (* indent
                ()
            indent *)
            (* try_unit
            let v16162 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v31154 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v31154 
    #endif
#if FABLE_COMPILER_PYTHON
    let v31156 : unit = ()
    let _let'_v31156 =
        async {
            try
                (* run_target_args'
                let v46298 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v46299 : string = "std::fs::remove_file(&*$0)"
                let v46300 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v46299 
                let v46301 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v46303 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v46304 : string = "$0.map_err(|x| $1(x))"
                let v46305 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v46300, v46301) v46304 
                let _run_target_args'_v46303 = v46305 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v46306 : string = "$0.map_err(|x| $1(x))"
                let v46307 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v46300, v46301) v46306 
                let _run_target_args'_v46303 = v46307 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v46308 : string = "$0.map_err(|x| $1(x))"
                let v46309 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v46300, v46301) v46308 
                let _run_target_args'_v46303 = v46309 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v46310 : Result<unit, string> = match v46300 with Ok x -> Ok x | Error x -> Error (v46301 x)
                let _run_target_args'_v46303 = v46310 
                #endif
#if FABLE_COMPILER_PYTHON
                let v46311 : Result<unit, string> = match v46300 with Ok x -> Ok x | Error x -> Error (v46301 x)
                let _run_target_args'_v46303 = v46311 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v46312 : Result<unit, string> = match v46300 with Ok x -> Ok x | Error x -> Error (v46301 x)
                let _run_target_args'_v46303 = v46312 
                #endif
#else
                let v46313 : Result<unit, string> = match v46300 with Ok x -> Ok x | Error x -> Error (v46301 x)
                let _run_target_args'_v46303 = v46313 
                #endif
                let v46314 : Result<unit, string> = _run_target_args'_v46303 
                let v46317 : (unit -> US9) = method45()
                let v46318 : (string -> US9) = method46()
                let v46320 : US9 = match v46314 with Ok () -> v46317 () | Error x -> v46318 x
                match v46320 with
                | US9_1(v46323) -> (* Error *)
                    let v46384 : unit = ()
                    let v46385 : (unit -> unit) = closure26(v46323)
                    let v46386 : unit = (fun () -> v46385 (); v46384) ()
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
                let v46447 : (string -> unit) = System.IO.File.Delete
                v46447 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v46831 : exn = ex
                let v46832 : int64 = v1 % 100L
                let v46833 : bool = v46832 = 0L
                if v46833 then
                    let v46934 : unit = ()
                    let v46935 : (unit -> unit) = closure27(v0, v46831)
                    let v46936 : unit = (fun () -> v46935 (); v46934) ()
                    ()
                (* run_target_args'
                let v47041 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v47042 : (int32 -> Async<unit>) = Async.Sleep
                let v47043 : Async<unit> = v47042 10
                let _run_target_args'_v47041 = v47043 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v47044 : (int32 -> Async<unit>) = Async.Sleep
                let v47045 : Async<unit> = v47044 10
                let _run_target_args'_v47041 = v47045 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v47046 : (int32 -> Async<unit>) = Async.Sleep
                let v47047 : Async<unit> = v47046 10
                let _run_target_args'_v47041 = v47047 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v47048 : (int32 -> Async<unit>) = Async.Sleep
                let v47049 : Async<unit> = v47048 10
                let _run_target_args'_v47041 = v47049 
                #endif
#if FABLE_COMPILER_PYTHON
                let v47050 : (int32 -> Async<unit>) = Async.Sleep
                let v47051 : Async<unit> = v47050 10
                let _run_target_args'_v47041 = v47051 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v47052 : (int32 -> Async<unit>) = Async.Sleep
                let v47053 : Async<unit> = v47052 10
                let _run_target_args'_v47041 = v47053 
                #endif
#else
                let v47054 : (int32 -> Async<unit>) = Async.Sleep
                let v47055 : Async<unit> = v47054 10
                let _run_target_args'_v47041 = v47055 
                #endif
                let v47056 : Async<unit> = _run_target_args'_v47041 
                do! v47056 
                let v47062 : int64 = v1 + 1L
                let v47063 : Async<int64> = method42(v0, v47062)
                return! v47063 
                (* indent
                ()
            indent *)
            (* try_unit
            let v47298 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v62290 : Async<int64> = _let'_v31156 
    let _run_target_args'_v6 = v62290 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62292 : unit = ()
    let _let'_v62292 =
        async {
            try
                (* run_target_args'
                let v77434 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v77435 : string = "std::fs::remove_file(&*$0)"
                let v77436 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v77435 
                let v77437 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v77439 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v77440 : string = "$0.map_err(|x| $1(x))"
                let v77441 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v77436, v77437) v77440 
                let _run_target_args'_v77439 = v77441 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v77442 : string = "$0.map_err(|x| $1(x))"
                let v77443 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v77436, v77437) v77442 
                let _run_target_args'_v77439 = v77443 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v77444 : string = "$0.map_err(|x| $1(x))"
                let v77445 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v77436, v77437) v77444 
                let _run_target_args'_v77439 = v77445 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v77446 : Result<unit, string> = match v77436 with Ok x -> Ok x | Error x -> Error (v77437 x)
                let _run_target_args'_v77439 = v77446 
                #endif
#if FABLE_COMPILER_PYTHON
                let v77447 : Result<unit, string> = match v77436 with Ok x -> Ok x | Error x -> Error (v77437 x)
                let _run_target_args'_v77439 = v77447 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v77448 : Result<unit, string> = match v77436 with Ok x -> Ok x | Error x -> Error (v77437 x)
                let _run_target_args'_v77439 = v77448 
                #endif
#else
                let v77449 : Result<unit, string> = match v77436 with Ok x -> Ok x | Error x -> Error (v77437 x)
                let _run_target_args'_v77439 = v77449 
                #endif
                let v77450 : Result<unit, string> = _run_target_args'_v77439 
                let v77453 : (unit -> US9) = method45()
                let v77454 : (string -> US9) = method46()
                let v77456 : US9 = match v77450 with Ok () -> v77453 () | Error x -> v77454 x
                match v77456 with
                | US9_1(v77459) -> (* Error *)
                    let v77520 : unit = ()
                    let v77521 : (unit -> unit) = closure26(v77459)
                    let v77522 : unit = (fun () -> v77521 (); v77520) ()
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
                let v77583 : (string -> unit) = System.IO.File.Delete
                v77583 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v77967 : exn = ex
                let v77968 : int64 = v1 % 100L
                let v77969 : bool = v77968 = 0L
                if v77969 then
                    let v78070 : unit = ()
                    let v78071 : (unit -> unit) = closure27(v0, v77967)
                    let v78072 : unit = (fun () -> v78071 (); v78070) ()
                    ()
                (* run_target_args'
                let v78177 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v78178 : (int32 -> Async<unit>) = Async.Sleep
                let v78179 : Async<unit> = v78178 10
                let _run_target_args'_v78177 = v78179 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v78180 : (int32 -> Async<unit>) = Async.Sleep
                let v78181 : Async<unit> = v78180 10
                let _run_target_args'_v78177 = v78181 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v78182 : (int32 -> Async<unit>) = Async.Sleep
                let v78183 : Async<unit> = v78182 10
                let _run_target_args'_v78177 = v78183 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v78184 : (int32 -> Async<unit>) = Async.Sleep
                let v78185 : Async<unit> = v78184 10
                let _run_target_args'_v78177 = v78185 
                #endif
#if FABLE_COMPILER_PYTHON
                let v78186 : (int32 -> Async<unit>) = Async.Sleep
                let v78187 : Async<unit> = v78186 10
                let _run_target_args'_v78177 = v78187 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v78188 : (int32 -> Async<unit>) = Async.Sleep
                let v78189 : Async<unit> = v78188 10
                let _run_target_args'_v78177 = v78189 
                #endif
#else
                let v78190 : (int32 -> Async<unit>) = Async.Sleep
                let v78191 : Async<unit> = v78190 10
                let _run_target_args'_v78177 = v78191 
                #endif
                let v78192 : Async<unit> = _run_target_args'_v78177 
                do! v78192 
                let v78198 : int64 = v1 + 1L
                let v78199 : Async<int64> = method42(v0, v78198)
                return! v78199 
                (* indent
                ()
            indent *)
            (* try_unit
            let v78434 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v93426 : Async<int64> = _let'_v62292 
    let _run_target_args'_v6 = v93426 
    #endif
#else
    let v93428 : unit = ()
    let _let'_v93428 =
        async {
            try
                (* run_target_args'
                let v108570 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v108571 : string = "std::fs::remove_file(&*$0)"
                let v108572 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v108571 
                let v108573 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v108575 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v108576 : string = "$0.map_err(|x| $1(x))"
                let v108577 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v108572, v108573) v108576 
                let _run_target_args'_v108575 = v108577 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v108578 : string = "$0.map_err(|x| $1(x))"
                let v108579 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v108572, v108573) v108578 
                let _run_target_args'_v108575 = v108579 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v108580 : string = "$0.map_err(|x| $1(x))"
                let v108581 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v108572, v108573) v108580 
                let _run_target_args'_v108575 = v108581 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v108582 : Result<unit, string> = match v108572 with Ok x -> Ok x | Error x -> Error (v108573 x)
                let _run_target_args'_v108575 = v108582 
                #endif
#if FABLE_COMPILER_PYTHON
                let v108583 : Result<unit, string> = match v108572 with Ok x -> Ok x | Error x -> Error (v108573 x)
                let _run_target_args'_v108575 = v108583 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v108584 : Result<unit, string> = match v108572 with Ok x -> Ok x | Error x -> Error (v108573 x)
                let _run_target_args'_v108575 = v108584 
                #endif
#else
                let v108585 : Result<unit, string> = match v108572 with Ok x -> Ok x | Error x -> Error (v108573 x)
                let _run_target_args'_v108575 = v108585 
                #endif
                let v108586 : Result<unit, string> = _run_target_args'_v108575 
                let v108589 : (unit -> US9) = method45()
                let v108590 : (string -> US9) = method46()
                let v108592 : US9 = match v108586 with Ok () -> v108589 () | Error x -> v108590 x
                match v108592 with
                | US9_1(v108595) -> (* Error *)
                    let v108656 : unit = ()
                    let v108657 : (unit -> unit) = closure26(v108595)
                    let v108658 : unit = (fun () -> v108657 (); v108656) ()
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
                let v108719 : (string -> unit) = System.IO.File.Delete
                v108719 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v109103 : exn = ex
                let v109104 : int64 = v1 % 100L
                let v109105 : bool = v109104 = 0L
                if v109105 then
                    let v109206 : unit = ()
                    let v109207 : (unit -> unit) = closure27(v0, v109103)
                    let v109208 : unit = (fun () -> v109207 (); v109206) ()
                    ()
                (* run_target_args'
                let v109313 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v109314 : (int32 -> Async<unit>) = Async.Sleep
                let v109315 : Async<unit> = v109314 10
                let _run_target_args'_v109313 = v109315 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v109316 : (int32 -> Async<unit>) = Async.Sleep
                let v109317 : Async<unit> = v109316 10
                let _run_target_args'_v109313 = v109317 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v109318 : (int32 -> Async<unit>) = Async.Sleep
                let v109319 : Async<unit> = v109318 10
                let _run_target_args'_v109313 = v109319 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v109320 : (int32 -> Async<unit>) = Async.Sleep
                let v109321 : Async<unit> = v109320 10
                let _run_target_args'_v109313 = v109321 
                #endif
#if FABLE_COMPILER_PYTHON
                let v109322 : (int32 -> Async<unit>) = Async.Sleep
                let v109323 : Async<unit> = v109322 10
                let _run_target_args'_v109313 = v109323 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v109324 : (int32 -> Async<unit>) = Async.Sleep
                let v109325 : Async<unit> = v109324 10
                let _run_target_args'_v109313 = v109325 
                #endif
#else
                let v109326 : (int32 -> Async<unit>) = Async.Sleep
                let v109327 : Async<unit> = v109326 10
                let _run_target_args'_v109313 = v109327 
                #endif
                let v109328 : Async<unit> = _run_target_args'_v109313 
                do! v109328 
                let v109334 : int64 = v1 + 1L
                let v109335 : Async<int64> = method42(v0, v109334)
                return! v109335 
                (* indent
                ()
            indent *)
            (* try_unit
            let v109570 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v124562 : Async<int64> = _let'_v93428 
    let _run_target_args'_v6 = v124562 
    #endif
    let v124563 : Async<int64> = _run_target_args'_v6 
    v124563
and method42 (v0 : string, v1 : int64) : Async<int64> =
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
    let v31 : Async<int64> = method43(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<int64> = _run_target_args'_v6 
    v32
and method41 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method42(v0, v1)
and closure22 () (v0 : string) : Async<int64> =
    method41(v0)
and method54 (v0 : string, v1 : string) : unit =
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
and method55 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string, v10 : string) : string =
    let v11 : string = method17()
    let v12 : Mut3 = {l0 = v11} : Mut3
    let v15 : string = "{ "
    let v16 : string = $"{v15}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure6(v12, v16)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v34 : string = "old_path"
    let v35 : string = $"{v34}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure6(v12, v35)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v53 : string = " = "
    let v54 : string = $"{v53}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure6(v12, v54)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v71 : string = $"{v8}"
    let v79 : unit = ()
    let v80 : (unit -> unit) = closure6(v12, v71)
    let v81 : unit = (fun () -> v80 (); v79) ()
    let v89 : string = "; "
    let v90 : string = $"{v89}"
    let v98 : unit = ()
    let v99 : (unit -> unit) = closure6(v12, v90)
    let v100 : unit = (fun () -> v99 (); v98) ()
    let v108 : string = "new_path"
    let v109 : string = $"{v108}"
    let v117 : unit = ()
    let v118 : (unit -> unit) = closure6(v12, v109)
    let v119 : unit = (fun () -> v118 (); v117) ()
    let v126 : string = $"{v53}"
    let v134 : unit = ()
    let v135 : (unit -> unit) = closure6(v12, v126)
    let v136 : unit = (fun () -> v135 (); v134) ()
    let v143 : string = $"{v9}"
    let v151 : unit = ()
    let v152 : (unit -> unit) = closure6(v12, v143)
    let v153 : unit = (fun () -> v152 (); v151) ()
    let v160 : string = $"{v89}"
    let v168 : unit = ()
    let v169 : (unit -> unit) = closure6(v12, v160)
    let v170 : unit = (fun () -> v169 (); v168) ()
    let v178 : string = "ex"
    let v179 : string = $"{v178}"
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure6(v12, v179)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v196 : string = $"{v53}"
    let v204 : unit = ()
    let v205 : (unit -> unit) = closure6(v12, v196)
    let v206 : unit = (fun () -> v205 (); v204) ()
    let v213 : string = $"{v10}"
    let v221 : unit = ()
    let v222 : (unit -> unit) = closure6(v12, v213)
    let v223 : unit = (fun () -> v222 (); v221) ()
    let v231 : string = " }"
    let v232 : string = $"{v231}"
    let v240 : unit = ()
    let v241 : (unit -> unit) = closure6(v12, v232)
    let v242 : unit = (fun () -> v241 (); v240) ()
    let v248 : string = v12.l0
    let v249 : int64 = v0.l0
    let v252 : string = " "
    let v253 : string = v6 + v252 
    let v257 : string = v253 + v7 
    let v262 : string = " #"
    let v263 : string = v257 + v262 
    let v267 : (int64 -> string) = _.ToString()
    let v268 : string = v267 v249
    let v272 : string = v263 + v268 
    let v276 : string = v272 + v252 
    let v281 : string = "move_file_async"
    let v282 : string = v276 + v281 
    let v287 : string = " / "
    let v288 : string = v282 + v287 
    let v292 : string = v288 + v248 
    method21(v292)
and closure30 (v0 : string, v1 : string, v2 : exn) () : unit =
    let v3 : US0 = US0_3
    let v4 : bool = method11(v3)
    if v4 then
        let v19 : unit = ()
        let v20 : (unit -> unit) = closure0()
        let v21 : unit = (fun () -> v20 (); v19) ()
        let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
        let v60 : string = method12(v42, v43, v44, v45, v46, v47)
        let v61 : string = method49()
        let v62 : string = method19(v1)
        let v63 : string = method19(v0)
        (* run_target_args'
        let v68 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v70 : string = $"%A{v2}"
        let _run_target_args'_v68 = v70 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v74 : string = $"%A{v2}"
        let _run_target_args'_v68 = v74 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v78 : string = $"%A{v2}"
        let _run_target_args'_v68 = v78 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v82 : string = $"%A{v2}"
        let _run_target_args'_v68 = v82 
        #endif
#if FABLE_COMPILER_PYTHON
        let v86 : string = $"%A{v2}"
        let _run_target_args'_v68 = v86 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v90 : string = $"%A{v2}"
        let _run_target_args'_v68 = v90 
        #endif
#else
        let v93 : string = $"{v2.GetType ()}: {v2.Message}"
        let _run_target_args'_v68 = v93 
        #endif
        let v94 : string = _run_target_args'_v68 
        let v103 : string = method55(v42, v43, v44, v45, v46, v47, v60, v61, v62, v63, v94)
        method22(v103)
and method53 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
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
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v9424 : exn = ex
                let v9425 : int64 = v2 % 100L
                let v9426 : bool = v9425 = 0L
                if v9426 then
                    let v9528 : unit = ()
                    let v9529 : (unit -> unit) = closure30(v0, v1, v9424)
                    let v9530 : unit = (fun () -> v9529 (); v9528) ()
                    ()
                (* run_target_args'
                let v9636 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9637 : (int32 -> Async<unit>) = Async.Sleep
                let v9638 : Async<unit> = v9637 10
                let _run_target_args'_v9636 = v9638 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9639 : (int32 -> Async<unit>) = Async.Sleep
                let v9640 : Async<unit> = v9639 10
                let _run_target_args'_v9636 = v9640 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9641 : (int32 -> Async<unit>) = Async.Sleep
                let v9642 : Async<unit> = v9641 10
                let _run_target_args'_v9636 = v9642 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9643 : (int32 -> Async<unit>) = Async.Sleep
                let v9644 : Async<unit> = v9643 10
                let _run_target_args'_v9636 = v9644 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9645 : (int32 -> Async<unit>) = Async.Sleep
                let v9646 : Async<unit> = v9645 10
                let _run_target_args'_v9636 = v9646 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9647 : (int32 -> Async<unit>) = Async.Sleep
                let v9648 : Async<unit> = v9647 10
                let _run_target_args'_v9636 = v9648 
                #endif
#else
                let v9649 : (int32 -> Async<unit>) = Async.Sleep
                let v9650 : Async<unit> = v9649 10
                let _run_target_args'_v9636 = v9650 
                #endif
                let v9651 : Async<unit> = _run_target_args'_v9636 
                do! v9651 
                let v9657 : int64 = v2 + 1L
                let v9658 : Async<int64> = method52(v0, v1, v9657)
                return! v9658 
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
    let v19059 : Async<int64> = _let'_v21 
    let _run_target_args'_v7 = v19059 
    #endif
#if FABLE_COMPILER_PYTHON
    let v19061 : unit = ()
    let _let'_v19061 =
        async {
            try
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v28464 : exn = ex
                let v28465 : int64 = v2 % 100L
                let v28466 : bool = v28465 = 0L
                if v28466 then
                    let v28568 : unit = ()
                    let v28569 : (unit -> unit) = closure30(v0, v1, v28464)
                    let v28570 : unit = (fun () -> v28569 (); v28568) ()
                    ()
                (* run_target_args'
                let v28676 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v28677 : (int32 -> Async<unit>) = Async.Sleep
                let v28678 : Async<unit> = v28677 10
                let _run_target_args'_v28676 = v28678 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v28679 : (int32 -> Async<unit>) = Async.Sleep
                let v28680 : Async<unit> = v28679 10
                let _run_target_args'_v28676 = v28680 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v28681 : (int32 -> Async<unit>) = Async.Sleep
                let v28682 : Async<unit> = v28681 10
                let _run_target_args'_v28676 = v28682 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28683 : (int32 -> Async<unit>) = Async.Sleep
                let v28684 : Async<unit> = v28683 10
                let _run_target_args'_v28676 = v28684 
                #endif
#if FABLE_COMPILER_PYTHON
                let v28685 : (int32 -> Async<unit>) = Async.Sleep
                let v28686 : Async<unit> = v28685 10
                let _run_target_args'_v28676 = v28686 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28687 : (int32 -> Async<unit>) = Async.Sleep
                let v28688 : Async<unit> = v28687 10
                let _run_target_args'_v28676 = v28688 
                #endif
#else
                let v28689 : (int32 -> Async<unit>) = Async.Sleep
                let v28690 : Async<unit> = v28689 10
                let _run_target_args'_v28676 = v28690 
                #endif
                let v28691 : Async<unit> = _run_target_args'_v28676 
                do! v28691 
                let v28697 : int64 = v2 + 1L
                let v28698 : Async<int64> = method52(v0, v1, v28697)
                return! v28698 
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
    let v38099 : Async<int64> = _let'_v19061 
    let _run_target_args'_v7 = v38099 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v38101 : unit = ()
    let _let'_v38101 =
        async {
            try
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v47504 : exn = ex
                let v47505 : int64 = v2 % 100L
                let v47506 : bool = v47505 = 0L
                if v47506 then
                    let v47608 : unit = ()
                    let v47609 : (unit -> unit) = closure30(v0, v1, v47504)
                    let v47610 : unit = (fun () -> v47609 (); v47608) ()
                    ()
                (* run_target_args'
                let v47716 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v47717 : (int32 -> Async<unit>) = Async.Sleep
                let v47718 : Async<unit> = v47717 10
                let _run_target_args'_v47716 = v47718 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v47719 : (int32 -> Async<unit>) = Async.Sleep
                let v47720 : Async<unit> = v47719 10
                let _run_target_args'_v47716 = v47720 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v47721 : (int32 -> Async<unit>) = Async.Sleep
                let v47722 : Async<unit> = v47721 10
                let _run_target_args'_v47716 = v47722 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v47723 : (int32 -> Async<unit>) = Async.Sleep
                let v47724 : Async<unit> = v47723 10
                let _run_target_args'_v47716 = v47724 
                #endif
#if FABLE_COMPILER_PYTHON
                let v47725 : (int32 -> Async<unit>) = Async.Sleep
                let v47726 : Async<unit> = v47725 10
                let _run_target_args'_v47716 = v47726 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v47727 : (int32 -> Async<unit>) = Async.Sleep
                let v47728 : Async<unit> = v47727 10
                let _run_target_args'_v47716 = v47728 
                #endif
#else
                let v47729 : (int32 -> Async<unit>) = Async.Sleep
                let v47730 : Async<unit> = v47729 10
                let _run_target_args'_v47716 = v47730 
                #endif
                let v47731 : Async<unit> = _run_target_args'_v47716 
                do! v47731 
                let v47737 : int64 = v2 + 1L
                let v47738 : Async<int64> = method52(v0, v1, v47737)
                return! v47738 
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
    let v57139 : Async<int64> = _let'_v38101 
    let _run_target_args'_v7 = v57139 
    #endif
#else
    let v57141 : unit = ()
    let _let'_v57141 =
        async {
            try
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v66544 : exn = ex
                let v66545 : int64 = v2 % 100L
                let v66546 : bool = v66545 = 0L
                if v66546 then
                    let v66648 : unit = ()
                    let v66649 : (unit -> unit) = closure30(v0, v1, v66544)
                    let v66650 : unit = (fun () -> v66649 (); v66648) ()
                    ()
                (* run_target_args'
                let v66756 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v66757 : (int32 -> Async<unit>) = Async.Sleep
                let v66758 : Async<unit> = v66757 10
                let _run_target_args'_v66756 = v66758 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v66759 : (int32 -> Async<unit>) = Async.Sleep
                let v66760 : Async<unit> = v66759 10
                let _run_target_args'_v66756 = v66760 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v66761 : (int32 -> Async<unit>) = Async.Sleep
                let v66762 : Async<unit> = v66761 10
                let _run_target_args'_v66756 = v66762 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v66763 : (int32 -> Async<unit>) = Async.Sleep
                let v66764 : Async<unit> = v66763 10
                let _run_target_args'_v66756 = v66764 
                #endif
#if FABLE_COMPILER_PYTHON
                let v66765 : (int32 -> Async<unit>) = Async.Sleep
                let v66766 : Async<unit> = v66765 10
                let _run_target_args'_v66756 = v66766 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v66767 : (int32 -> Async<unit>) = Async.Sleep
                let v66768 : Async<unit> = v66767 10
                let _run_target_args'_v66756 = v66768 
                #endif
#else
                let v66769 : (int32 -> Async<unit>) = Async.Sleep
                let v66770 : Async<unit> = v66769 10
                let _run_target_args'_v66756 = v66770 
                #endif
                let v66771 : Async<unit> = _run_target_args'_v66756 
                do! v66771 
                let v66777 : int64 = v2 + 1L
                let v66778 : Async<int64> = method52(v0, v1, v66777)
                return! v66778 
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
    let v76179 : Async<int64> = _let'_v57141 
    let _run_target_args'_v7 = v76179 
    #endif
    let v76180 : Async<int64> = _run_target_args'_v7 
    v76180
and method52 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
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
    let v32 : Async<int64> = method53(v0, v1, v2)
    let _run_target_args'_v7 = v32 
    #endif
    let v33 : Async<int64> = _run_target_args'_v7 
    v33
and method51 (v0 : string, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method52(v0, v1, v2)
and closure29 (v0 : string) (v1 : string) : Async<int64> =
    method51(v0, v1)
and closure28 () (v0 : string) : (string -> Async<int64>) =
    closure29(v0)
and closure32 () (v0 : int64) : US10 =
    US10_0(v0)
and method62 () : (int64 -> US10) =
    closure32()
and closure33 () (v0 : exn) : US10 =
    US10_1(v0)
and method63 () : (exn -> US10) =
    closure33()
and method61 (v0 : Async<Choice<int64, exn>>) : Async<US10> =
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
            let v555 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v560 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v562 : US10 = null |> unbox<US10>
            let _run_target_args'_v560 = v562 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v566 : US10 = null |> unbox<US10>
            let _run_target_args'_v560 = v566 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v570 : US10 = null |> unbox<US10>
            let _run_target_args'_v560 = v570 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v574 : US10 = null |> unbox<US10>
            let _run_target_args'_v560 = v574 
            #endif
#if FABLE_COMPILER_PYTHON
            let v578 : US10 = null |> unbox<US10>
            let _run_target_args'_v560 = v578 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v581 : (int64 -> US10) = method62()
            let v582 : (exn -> US10) = method63()
            let v583 : US10 = match v555 with Choice1Of2 x -> v581 x | Choice2Of2 x -> v582 x
            let _run_target_args'_v560 = v583 
            #endif
#else
            let v584 : (int64 -> US10) = method62()
            let v585 : (exn -> US10) = method63()
            let v586 : US10 = match v555 with Choice1Of2 x -> v584 x | Choice2Of2 x -> v585 x
            let _run_target_args'_v560 = v586 
            #endif
            let v587 : US10 = _run_target_args'_v560 
            return v587 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1129 : Async<US10> = _let'_v19 
    let _run_target_args'_v5 = v1129 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1131 : unit = ()
    let _let'_v1131 =
        async {
            let! v0 = v0 
            let v1667 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v1672 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1674 : US10 = null |> unbox<US10>
            let _run_target_args'_v1672 = v1674 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1678 : US10 = null |> unbox<US10>
            let _run_target_args'_v1672 = v1678 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1682 : US10 = null |> unbox<US10>
            let _run_target_args'_v1672 = v1682 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1686 : US10 = null |> unbox<US10>
            let _run_target_args'_v1672 = v1686 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1690 : US10 = null |> unbox<US10>
            let _run_target_args'_v1672 = v1690 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1693 : (int64 -> US10) = method62()
            let v1694 : (exn -> US10) = method63()
            let v1695 : US10 = match v1667 with Choice1Of2 x -> v1693 x | Choice2Of2 x -> v1694 x
            let _run_target_args'_v1672 = v1695 
            #endif
#else
            let v1696 : (int64 -> US10) = method62()
            let v1697 : (exn -> US10) = method63()
            let v1698 : US10 = match v1667 with Choice1Of2 x -> v1696 x | Choice2Of2 x -> v1697 x
            let _run_target_args'_v1672 = v1698 
            #endif
            let v1699 : US10 = _run_target_args'_v1672 
            return v1699 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2241 : Async<US10> = _let'_v1131 
    let _run_target_args'_v5 = v2241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2243 : unit = ()
    let _let'_v2243 =
        async {
            let! v0 = v0 
            let v2779 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v2784 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2786 : US10 = null |> unbox<US10>
            let _run_target_args'_v2784 = v2786 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2790 : US10 = null |> unbox<US10>
            let _run_target_args'_v2784 = v2790 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2794 : US10 = null |> unbox<US10>
            let _run_target_args'_v2784 = v2794 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2798 : US10 = null |> unbox<US10>
            let _run_target_args'_v2784 = v2798 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2802 : US10 = null |> unbox<US10>
            let _run_target_args'_v2784 = v2802 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2805 : (int64 -> US10) = method62()
            let v2806 : (exn -> US10) = method63()
            let v2807 : US10 = match v2779 with Choice1Of2 x -> v2805 x | Choice2Of2 x -> v2806 x
            let _run_target_args'_v2784 = v2807 
            #endif
#else
            let v2808 : (int64 -> US10) = method62()
            let v2809 : (exn -> US10) = method63()
            let v2810 : US10 = match v2779 with Choice1Of2 x -> v2808 x | Choice2Of2 x -> v2809 x
            let _run_target_args'_v2784 = v2810 
            #endif
            let v2811 : US10 = _run_target_args'_v2784 
            return v2811 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3353 : Async<US10> = _let'_v2243 
    let _run_target_args'_v5 = v3353 
    #endif
#else
    let v3355 : unit = ()
    let _let'_v3355 =
        async {
            let! v0 = v0 
            let v3891 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v3896 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3898 : US10 = null |> unbox<US10>
            let _run_target_args'_v3896 = v3898 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3902 : US10 = null |> unbox<US10>
            let _run_target_args'_v3896 = v3902 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3906 : US10 = null |> unbox<US10>
            let _run_target_args'_v3896 = v3906 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3910 : US10 = null |> unbox<US10>
            let _run_target_args'_v3896 = v3910 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3914 : US10 = null |> unbox<US10>
            let _run_target_args'_v3896 = v3914 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3917 : (int64 -> US10) = method62()
            let v3918 : (exn -> US10) = method63()
            let v3919 : US10 = match v3891 with Choice1Of2 x -> v3917 x | Choice2Of2 x -> v3918 x
            let _run_target_args'_v3896 = v3919 
            #endif
#else
            let v3920 : (int64 -> US10) = method62()
            let v3921 : (exn -> US10) = method63()
            let v3922 : US10 = match v3891 with Choice1Of2 x -> v3920 x | Choice2Of2 x -> v3921 x
            let _run_target_args'_v3896 = v3922 
            #endif
            let v3923 : US10 = _run_target_args'_v3896 
            return v3923 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4465 : Async<US10> = _let'_v3355 
    let _run_target_args'_v5 = v4465 
    #endif
    let v4466 : Async<US10> = _run_target_args'_v5 
    v4466
and method64 (v0 : Async<US10>) : Async<US11> =
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
            let v113 : US10 = v0 
            let v119 : US11 =
                match v113 with
                | US10_0(v114) -> (* C1of2 *)
                    US11_0(v114)
                | US10_1(v116) -> (* C2of2 *)
                    US11_1(v116)
            return v119 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v211 : Async<US11> = _let'_v19 
    let _run_target_args'_v5 = v211 
    #endif
#if FABLE_COMPILER_PYTHON
    let v213 : unit = ()
    let _let'_v213 =
        async {
            let! v0 = v0 
            let v307 : US10 = v0 
            let v313 : US11 =
                match v307 with
                | US10_0(v308) -> (* C1of2 *)
                    US11_0(v308)
                | US10_1(v310) -> (* C2of2 *)
                    US11_1(v310)
            return v313 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v405 : Async<US11> = _let'_v213 
    let _run_target_args'_v5 = v405 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v407 : unit = ()
    let _let'_v407 =
        async {
            let! v0 = v0 
            let v501 : US10 = v0 
            let v507 : US11 =
                match v501 with
                | US10_0(v502) -> (* C1of2 *)
                    US11_0(v502)
                | US10_1(v504) -> (* C2of2 *)
                    US11_1(v504)
            return v507 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v599 : Async<US11> = _let'_v407 
    let _run_target_args'_v5 = v599 
    #endif
#else
    let v601 : unit = ()
    let _let'_v601 =
        async {
            let! v0 = v0 
            let v695 : US10 = v0 
            let v701 : US11 =
                match v695 with
                | US10_0(v696) -> (* C1of2 *)
                    US11_0(v696)
                | US10_1(v698) -> (* C2of2 *)
                    US11_1(v698)
            return v701 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v793 : Async<US11> = _let'_v601 
    let _run_target_args'_v5 = v793 
    #endif
    let v794 : Async<US11> = _run_target_args'_v5 
    v794
and method66 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method17()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "timeout"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v72 : string = $"{v8}"
    let v80 : unit = ()
    let v81 : (unit -> unit) = closure6(v10, v72)
    let v82 : unit = (fun () -> v81 (); v80) ()
    let v90 : string = " }"
    let v91 : string = $"{v90}"
    let v99 : unit = ()
    let v100 : (unit -> unit) = closure6(v10, v91)
    let v101 : unit = (fun () -> v100 (); v99) ()
    let v107 : string = v10.l0
    let v108 : int64 = v0.l0
    let v111 : string = " "
    let v112 : string = v6 + v111 
    let v116 : string = v112 + v7 
    let v121 : string = " #"
    let v122 : string = v116 + v121 
    let v126 : (int64 -> string) = _.ToString()
    let v127 : string = v126 v108
    let v131 : string = v122 + v127 
    let v135 : string = v131 + v111 
    let v140 : string = "async.run_with_timeout_async"
    let v141 : string = v135 + v140 
    let v146 : string = " / "
    let v147 : string = v141 + v146 
    let v151 : string = v147 + v107 
    method21(v151)
and closure34 (v0 : int32) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method11(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure0()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method12(v40, v41, v42, v43, v44, v45)
        let v59 : string = method31()
        let v60 : string = method66(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method22(v60)
and method67 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "timeout"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure6(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "ex"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure6(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure6(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    let v145 : string = $"{v9}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure6(v11, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v163 : string = " }"
    let v164 : string = $"{v163}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure6(v11, v164)
    let v174 : unit = (fun () -> v173 (); v172) ()
    let v180 : string = v11.l0
    let v181 : int64 = v0.l0
    let v184 : string = " "
    let v185 : string = v6 + v184 
    let v189 : string = v185 + v7 
    let v194 : string = " #"
    let v195 : string = v189 + v194 
    let v199 : (int64 -> string) = _.ToString()
    let v200 : string = v199 v181
    let v204 : string = v195 + v200 
    let v208 : string = v204 + v184 
    let v213 : string = "async.run_with_timeout_async**"
    let v214 : string = v208 + v213 
    let v219 : string = " / "
    let v220 : string = v214 + v219 
    let v224 : string = v220 + v180 
    method21(v224)
and closure35 (v0 : int32, v1 : exn) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method47()
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v65 = v75 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v79 : string = $"%A{v1}"
        let _run_target_args'_v65 = v79 
        #endif
#if FABLE_COMPILER_PYTHON
        let v83 : string = $"%A{v1}"
        let _run_target_args'_v65 = v83 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v87 : string = $"%A{v1}"
        let _run_target_args'_v65 = v87 
        #endif
#else
        let v90 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v65 = v90 
        #endif
        let v91 : string = _run_target_args'_v65 
        let v100 : string = method67(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method22(v100)
and method65 (v0 : int32, v1 : Async<US11>) : Async<US2> =
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
            let v4481 : US11 = v1 
            let v4823 : US2 =
                match v4481 with
                | US11_1(v4484) -> (* Error *)
                    let v4486 : string = $"%A{v4484}"
                    let v4491 : string = "System.TimeoutException"
                    let v4492 : bool = v4486.Contains v4491 
                    if v4492 then
                        let v4555 : unit = ()
                        let v4556 : (unit -> unit) = closure34(v0)
                        let v4557 : unit = (fun () -> v4556 (); v4555) ()
                        US2_1
                    else
                        let v4718 : unit = ()
                        let v4719 : (unit -> unit) = closure35(v0, v4484)
                        let v4720 : unit = (fun () -> v4719 (); v4718) ()
                        US2_1
                | US11_0(v4482) -> (* Ok *)
                    US2_0(v4482)
            return v4823 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9284 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v9284 
    #endif
#if FABLE_COMPILER_PYTHON
    let v9286 : unit = ()
    let _let'_v9286 =
        async {
            let! v1 = v1 
            let v13747 : US11 = v1 
            let v14089 : US2 =
                match v13747 with
                | US11_1(v13750) -> (* Error *)
                    let v13752 : string = $"%A{v13750}"
                    let v13757 : string = "System.TimeoutException"
                    let v13758 : bool = v13752.Contains v13757 
                    if v13758 then
                        let v13821 : unit = ()
                        let v13822 : (unit -> unit) = closure34(v0)
                        let v13823 : unit = (fun () -> v13822 (); v13821) ()
                        US2_1
                    else
                        let v13984 : unit = ()
                        let v13985 : (unit -> unit) = closure35(v0, v13750)
                        let v13986 : unit = (fun () -> v13985 (); v13984) ()
                        US2_1
                | US11_0(v13748) -> (* Ok *)
                    US2_0(v13748)
            return v14089 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v18550 : Async<US2> = _let'_v9286 
    let _run_target_args'_v6 = v18550 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18552 : unit = ()
    let _let'_v18552 =
        async {
            let! v1 = v1 
            let v23013 : US11 = v1 
            let v23355 : US2 =
                match v23013 with
                | US11_1(v23016) -> (* Error *)
                    let v23018 : string = $"%A{v23016}"
                    let v23023 : string = "System.TimeoutException"
                    let v23024 : bool = v23018.Contains v23023 
                    if v23024 then
                        let v23087 : unit = ()
                        let v23088 : (unit -> unit) = closure34(v0)
                        let v23089 : unit = (fun () -> v23088 (); v23087) ()
                        US2_1
                    else
                        let v23250 : unit = ()
                        let v23251 : (unit -> unit) = closure35(v0, v23016)
                        let v23252 : unit = (fun () -> v23251 (); v23250) ()
                        US2_1
                | US11_0(v23014) -> (* Ok *)
                    US2_0(v23014)
            return v23355 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v27816 : Async<US2> = _let'_v18552 
    let _run_target_args'_v6 = v27816 
    #endif
#else
    let v27818 : unit = ()
    let _let'_v27818 =
        async {
            let! v1 = v1 
            let v32279 : US11 = v1 
            let v32621 : US2 =
                match v32279 with
                | US11_1(v32282) -> (* Error *)
                    let v32284 : string = $"%A{v32282}"
                    let v32289 : string = "System.TimeoutException"
                    let v32290 : bool = v32284.Contains v32289 
                    if v32290 then
                        let v32353 : unit = ()
                        let v32354 : (unit -> unit) = closure34(v0)
                        let v32355 : unit = (fun () -> v32354 (); v32353) ()
                        US2_1
                    else
                        let v32516 : unit = ()
                        let v32517 : (unit -> unit) = closure35(v0, v32282)
                        let v32518 : unit = (fun () -> v32517 (); v32516) ()
                        US2_1
                | US11_0(v32280) -> (* Ok *)
                    US2_0(v32280)
            return v32621 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v37082 : Async<US2> = _let'_v27818 
    let _run_target_args'_v6 = v37082 
    #endif
    let v37083 : Async<US2> = _run_target_args'_v6 
    v37083
and method60 (v0 : Async<int64>, v1 : int32) : Async<US2> =
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
            let v911 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v913 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v911 = v913 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v917 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v911 = v917 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v921 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v911 = v921 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v924 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v924 
            #endif
#if FABLE_COMPILER_PYTHON
            let v925 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v925 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v926 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v926 
            #endif
#else
            let v927 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v911 = v927 
            #endif
            let v928 : Async<Async<int64>> = _run_target_args'_v911 
            let! v928 = v928 
            let v937 : Async<int64> = v928 
            (* run_target_args'
            let v942 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v944 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v942 = v944 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v948 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v942 = v948 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v952 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v942 = v952 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v955 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v956 : Async<Choice<int64, exn>> = v955 v937
            let _run_target_args'_v942 = v956 
            #endif
#if FABLE_COMPILER_PYTHON
            let v957 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v958 : Async<Choice<int64, exn>> = v957 v937
            let _run_target_args'_v942 = v958 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v959 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v960 : Async<Choice<int64, exn>> = v959 v937
            let _run_target_args'_v942 = v960 
            #endif
#else
            let v961 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v962 : Async<Choice<int64, exn>> = v961 v937
            let _run_target_args'_v942 = v962 
            #endif
            let v963 : Async<Choice<int64, exn>> = _run_target_args'_v942 
            let v972 : Async<US10> = method61(v963)
            let v973 : Async<US11> = method64(v972)
            let v974 : Async<US2> = method65(v1, v973)
            return! v974 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1859 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v1859 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1861 : unit = ()
    let _let'_v1861 =
        async {
            (* run_target_args'
            let v2752 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2754 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2752 = v2754 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2758 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2752 = v2758 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2762 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2752 = v2762 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2765 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2765 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2766 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2766 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2767 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2767 
            #endif
#else
            let v2768 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2752 = v2768 
            #endif
            let v2769 : Async<Async<int64>> = _run_target_args'_v2752 
            let! v2769 = v2769 
            let v2778 : Async<int64> = v2769 
            (* run_target_args'
            let v2783 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2785 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2783 = v2785 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2789 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2783 = v2789 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2793 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2783 = v2793 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2796 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2797 : Async<Choice<int64, exn>> = v2796 v2778
            let _run_target_args'_v2783 = v2797 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2798 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2799 : Async<Choice<int64, exn>> = v2798 v2778
            let _run_target_args'_v2783 = v2799 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2800 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2801 : Async<Choice<int64, exn>> = v2800 v2778
            let _run_target_args'_v2783 = v2801 
            #endif
#else
            let v2802 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2803 : Async<Choice<int64, exn>> = v2802 v2778
            let _run_target_args'_v2783 = v2803 
            #endif
            let v2804 : Async<Choice<int64, exn>> = _run_target_args'_v2783 
            let v2813 : Async<US10> = method61(v2804)
            let v2814 : Async<US11> = method64(v2813)
            let v2815 : Async<US2> = method65(v1, v2814)
            return! v2815 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3700 : Async<US2> = _let'_v1861 
    let _run_target_args'_v6 = v3700 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3702 : unit = ()
    let _let'_v3702 =
        async {
            (* run_target_args'
            let v4593 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4595 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4593 = v4595 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4599 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4593 = v4599 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4603 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4593 = v4603 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4606 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4606 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4607 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4607 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4608 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4608 
            #endif
#else
            let v4609 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4593 = v4609 
            #endif
            let v4610 : Async<Async<int64>> = _run_target_args'_v4593 
            let! v4610 = v4610 
            let v4619 : Async<int64> = v4610 
            (* run_target_args'
            let v4624 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4626 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4624 = v4626 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4630 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4624 = v4630 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4634 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4624 = v4634 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4637 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4638 : Async<Choice<int64, exn>> = v4637 v4619
            let _run_target_args'_v4624 = v4638 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4639 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4640 : Async<Choice<int64, exn>> = v4639 v4619
            let _run_target_args'_v4624 = v4640 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4641 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4642 : Async<Choice<int64, exn>> = v4641 v4619
            let _run_target_args'_v4624 = v4642 
            #endif
#else
            let v4643 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4644 : Async<Choice<int64, exn>> = v4643 v4619
            let _run_target_args'_v4624 = v4644 
            #endif
            let v4645 : Async<Choice<int64, exn>> = _run_target_args'_v4624 
            let v4654 : Async<US10> = method61(v4645)
            let v4655 : Async<US11> = method64(v4654)
            let v4656 : Async<US2> = method65(v1, v4655)
            return! v4656 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5541 : Async<US2> = _let'_v3702 
    let _run_target_args'_v6 = v5541 
    #endif
#else
    let v5543 : unit = ()
    let _let'_v5543 =
        async {
            (* run_target_args'
            let v6434 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6436 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v6434 = v6436 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6440 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v6434 = v6440 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6444 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v6434 = v6444 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6447 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6447 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6448 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6448 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6449 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6449 
            #endif
#else
            let v6450 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6434 = v6450 
            #endif
            let v6451 : Async<Async<int64>> = _run_target_args'_v6434 
            let! v6451 = v6451 
            let v6460 : Async<int64> = v6451 
            (* run_target_args'
            let v6465 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6467 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v6465 = v6467 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6471 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v6465 = v6471 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6475 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v6465 = v6475 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6478 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6479 : Async<Choice<int64, exn>> = v6478 v6460
            let _run_target_args'_v6465 = v6479 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6480 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6481 : Async<Choice<int64, exn>> = v6480 v6460
            let _run_target_args'_v6465 = v6481 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6482 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6483 : Async<Choice<int64, exn>> = v6482 v6460
            let _run_target_args'_v6465 = v6483 
            #endif
#else
            let v6484 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6485 : Async<Choice<int64, exn>> = v6484 v6460
            let _run_target_args'_v6465 = v6485 
            #endif
            let v6486 : Async<Choice<int64, exn>> = _run_target_args'_v6465 
            let v6495 : Async<US10> = method61(v6486)
            let v6496 : Async<US11> = method64(v6495)
            let v6497 : Async<US2> = method65(v1, v6496)
            return! v6497 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7382 : Async<US2> = _let'_v5543 
    let _run_target_args'_v6 = v7382 
    #endif
    let v7383 : Async<US2> = _run_target_args'_v6 
    v7383
and method59 (v0 : int32, v1 : Async<int64>) : Async<US2> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US2> = method60(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US2> = _run_target_args'_v6 
    v14
and method68 (v0 : Async<string>) : Async<string option> =
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
            let v87 : string = v0 
            let v89 : string option = Some v87 
            return v89 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v157 : Async<string option> = _let'_v19 
    let _run_target_args'_v5 = v157 
    #endif
#if FABLE_COMPILER_PYTHON
    let v159 : unit = ()
    let _let'_v159 =
        async {
            let! v0 = v0 
            let v227 : string = v0 
            let v229 : string option = Some v227 
            return v229 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v297 : Async<string option> = _let'_v159 
    let _run_target_args'_v5 = v297 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v299 : unit = ()
    let _let'_v299 =
        async {
            let! v0 = v0 
            let v367 : string = v0 
            let v369 : string option = Some v367 
            return v369 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v437 : Async<string option> = _let'_v299 
    let _run_target_args'_v5 = v437 
    #endif
#else
    let v439 : unit = ()
    let _let'_v439 =
        async {
            let! v0 = v0 
            let v507 : string = v0 
            let v509 : string option = Some v507 
            return v509 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v577 : Async<string option> = _let'_v439 
    let _run_target_args'_v5 = v577 
    #endif
    let v578 : Async<string option> = _run_target_args'_v5 
    v578
and method69 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "retry"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v73 : string = $"{v8}"
    let v81 : unit = ()
    let v82 : (unit -> unit) = closure6(v11, v73)
    let v83 : unit = (fun () -> v82 (); v81) ()
    let v91 : string = "; "
    let v92 : string = $"{v91}"
    let v100 : unit = ()
    let v101 : (unit -> unit) = closure6(v11, v92)
    let v102 : unit = (fun () -> v101 (); v100) ()
    let v110 : string = "ex"
    let v111 : string = $"{v110}"
    let v119 : unit = ()
    let v120 : (unit -> unit) = closure6(v11, v111)
    let v121 : unit = (fun () -> v120 (); v119) ()
    let v128 : string = $"{v52}"
    let v136 : unit = ()
    let v137 : (unit -> unit) = closure6(v11, v128)
    let v138 : unit = (fun () -> v137 (); v136) ()
    let v145 : string = $"{v9}"
    let v153 : unit = ()
    let v154 : (unit -> unit) = closure6(v11, v145)
    let v155 : unit = (fun () -> v154 (); v153) ()
    let v163 : string = " }"
    let v164 : string = $"{v163}"
    let v172 : unit = ()
    let v173 : (unit -> unit) = closure6(v11, v164)
    let v174 : unit = (fun () -> v173 (); v172) ()
    let v180 : string = v11.l0
    let v181 : int64 = v0.l0
    let v184 : string = " "
    let v185 : string = v6 + v184 
    let v189 : string = v185 + v7 
    let v194 : string = " #"
    let v195 : string = v189 + v194 
    let v199 : (int64 -> string) = _.ToString()
    let v200 : string = v199 v181
    let v204 : string = v195 + v200 
    let v208 : string = v204 + v184 
    let v213 : string = "file_system.read_all_text_retry_async"
    let v214 : string = v208 + v213 
    let v219 : string = " / "
    let v220 : string = v214 + v219 
    let v224 : string = v220 + v180 
    method21(v224)
and closure36 (v0 : int64, v1 : exn) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method16()
        (* run_target_args'
        let v65 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v67 : string = $"%A{v1}"
        let _run_target_args'_v65 = v67 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v71 : string = $"%A{v1}"
        let _run_target_args'_v65 = v71 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v75 : string = $"%A{v1}"
        let _run_target_args'_v65 = v75 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v79 : string = $"%A{v1}"
        let _run_target_args'_v65 = v79 
        #endif
#if FABLE_COMPILER_PYTHON
        let v83 : string = $"%A{v1}"
        let _run_target_args'_v65 = v83 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v87 : string = $"%A{v1}"
        let _run_target_args'_v65 = v87 
        #endif
#else
        let v90 : string = $"{v1.GetType ()}: {v1.Message}"
        let _run_target_args'_v65 = v90 
        #endif
        let v91 : string = _run_target_args'_v65 
        let v100 : string = method69(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method22(v100)
and method58 (v0 : string, v1 : int64) : Async<string option> =
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
                let v9865 : bool = v1 > 0L
                if v9865 then
                    let v9866 : Async<int64> = method27(v0)
                    let v9867 : int32 = 1000
                    let v9868 : Async<US2> = method59(v9867, v9866)
                    (* run_target_args'
                    let v9873 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v9875 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v9873 = v9875 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v9879 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v9873 = v9879 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v9883 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v9873 = v9883 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v9886 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9887 : Async<unit> = v9886 v9868
                    let _run_target_args'_v9873 = v9887 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v9888 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9889 : Async<unit> = v9888 v9868
                    let _run_target_args'_v9873 = v9889 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v9890 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9891 : Async<unit> = v9890 v9868
                    let _run_target_args'_v9873 = v9891 
                    #endif
#else
                    let v9892 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9893 : Async<unit> = v9892 v9868
                    let _run_target_args'_v9873 = v9893 
                    #endif
                    let v9894 : Async<unit> = _run_target_args'_v9873 
                    do! v9894 
                    ()
                let v9903 : Async<string> = method28(v0)
                let v9904 : Async<string option> = method68(v9903)
                return! v9904 
                (* indent
                ()
            indent *)
            with ex ->
                let v10155 : exn = ex
                let v10156 : bool = v1 = 0L
                let v10157 : bool = v10156 <> true
                if v10157 then
                    let v10257 : unit = ()
                    let v10258 : (unit -> unit) = closure36(v1, v10155)
                    let v10259 : unit = (fun () -> v10258 (); v10257) ()
                    let v10360 : string option = None
                    return v10360 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v10363 : int64 = v1 + 1L
                    let v10364 : Async<string option> = method57(v0, v10363)
                    return! v10364 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v10576 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v20381 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v20381 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20383 : unit = ()
    let _let'_v20383 =
        async {
            try
                let v30228 : bool = v1 > 0L
                if v30228 then
                    let v30229 : Async<int64> = method27(v0)
                    let v30230 : int32 = 1000
                    let v30231 : Async<US2> = method59(v30230, v30229)
                    (* run_target_args'
                    let v30236 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v30238 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v30236 = v30238 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v30242 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v30236 = v30242 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v30246 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v30236 = v30246 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v30249 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v30250 : Async<unit> = v30249 v30231
                    let _run_target_args'_v30236 = v30250 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v30251 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v30252 : Async<unit> = v30251 v30231
                    let _run_target_args'_v30236 = v30252 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v30253 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v30254 : Async<unit> = v30253 v30231
                    let _run_target_args'_v30236 = v30254 
                    #endif
#else
                    let v30255 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v30256 : Async<unit> = v30255 v30231
                    let _run_target_args'_v30236 = v30256 
                    #endif
                    let v30257 : Async<unit> = _run_target_args'_v30236 
                    do! v30257 
                    ()
                let v30266 : Async<string> = method28(v0)
                let v30267 : Async<string option> = method68(v30266)
                return! v30267 
                (* indent
                ()
            indent *)
            with ex ->
                let v30518 : exn = ex
                let v30519 : bool = v1 = 0L
                let v30520 : bool = v30519 <> true
                if v30520 then
                    let v30620 : unit = ()
                    let v30621 : (unit -> unit) = closure36(v1, v30518)
                    let v30622 : unit = (fun () -> v30621 (); v30620) ()
                    let v30723 : string option = None
                    return v30723 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v30726 : int64 = v1 + 1L
                    let v30727 : Async<string option> = method57(v0, v30726)
                    return! v30727 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v30939 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v40744 : Async<string option> = _let'_v20383 
    let _run_target_args'_v6 = v40744 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v40746 : unit = ()
    let _let'_v40746 =
        async {
            try
                let v50591 : bool = v1 > 0L
                if v50591 then
                    let v50592 : Async<int64> = method27(v0)
                    let v50593 : int32 = 1000
                    let v50594 : Async<US2> = method59(v50593, v50592)
                    (* run_target_args'
                    let v50599 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v50601 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v50599 = v50601 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v50605 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v50599 = v50605 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v50609 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v50599 = v50609 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v50612 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v50613 : Async<unit> = v50612 v50594
                    let _run_target_args'_v50599 = v50613 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v50614 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v50615 : Async<unit> = v50614 v50594
                    let _run_target_args'_v50599 = v50615 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v50616 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v50617 : Async<unit> = v50616 v50594
                    let _run_target_args'_v50599 = v50617 
                    #endif
#else
                    let v50618 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v50619 : Async<unit> = v50618 v50594
                    let _run_target_args'_v50599 = v50619 
                    #endif
                    let v50620 : Async<unit> = _run_target_args'_v50599 
                    do! v50620 
                    ()
                let v50629 : Async<string> = method28(v0)
                let v50630 : Async<string option> = method68(v50629)
                return! v50630 
                (* indent
                ()
            indent *)
            with ex ->
                let v50881 : exn = ex
                let v50882 : bool = v1 = 0L
                let v50883 : bool = v50882 <> true
                if v50883 then
                    let v50983 : unit = ()
                    let v50984 : (unit -> unit) = closure36(v1, v50881)
                    let v50985 : unit = (fun () -> v50984 (); v50983) ()
                    let v51086 : string option = None
                    return v51086 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v51089 : int64 = v1 + 1L
                    let v51090 : Async<string option> = method57(v0, v51089)
                    return! v51090 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v51302 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v61107 : Async<string option> = _let'_v40746 
    let _run_target_args'_v6 = v61107 
    #endif
#else
    let v61109 : unit = ()
    let _let'_v61109 =
        async {
            try
                let v70954 : bool = v1 > 0L
                if v70954 then
                    let v70955 : Async<int64> = method27(v0)
                    let v70956 : int32 = 1000
                    let v70957 : Async<US2> = method59(v70956, v70955)
                    (* run_target_args'
                    let v70962 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v70964 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v70962 = v70964 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v70968 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v70962 = v70968 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v70972 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v70962 = v70972 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v70975 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v70976 : Async<unit> = v70975 v70957
                    let _run_target_args'_v70962 = v70976 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v70977 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v70978 : Async<unit> = v70977 v70957
                    let _run_target_args'_v70962 = v70978 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v70979 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v70980 : Async<unit> = v70979 v70957
                    let _run_target_args'_v70962 = v70980 
                    #endif
#else
                    let v70981 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v70982 : Async<unit> = v70981 v70957
                    let _run_target_args'_v70962 = v70982 
                    #endif
                    let v70983 : Async<unit> = _run_target_args'_v70962 
                    do! v70983 
                    ()
                let v70992 : Async<string> = method28(v0)
                let v70993 : Async<string option> = method68(v70992)
                return! v70993 
                (* indent
                ()
            indent *)
            with ex ->
                let v71244 : exn = ex
                let v71245 : bool = v1 = 0L
                let v71246 : bool = v71245 <> true
                if v71246 then
                    let v71346 : unit = ()
                    let v71347 : (unit -> unit) = closure36(v1, v71244)
                    let v71348 : unit = (fun () -> v71347 (); v71346) ()
                    let v71449 : string option = None
                    return v71449 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v71452 : int64 = v1 + 1L
                    let v71453 : Async<string option> = method57(v0, v71452)
                    return! v71453 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v71665 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v81470 : Async<string option> = _let'_v61109 
    let _run_target_args'_v6 = v81470 
    #endif
    let v81471 : Async<string option> = _run_target_args'_v6 
    v81471
and method57 (v0 : string, v1 : int64) : Async<string option> =
    method58(v0, v1)
and method56 (v0 : string) : Async<string option> =
    let v1 : int64 = 0L
    method57(v0, v1)
and closure31 () (v0 : string) : Async<string option> =
    method56(v0)
and closure38 () (v0 : chrono_DateTime<chrono_Utc>) : US12 =
    US12_0(v0)
and method72 () : (chrono_DateTime<chrono_Utc> -> US12) =
    closure38()
and method73 () : string =
    let v0 : string = "hh:mm"
    v0
and method74 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method75 () : string =
    let v0 : string = "hhmm"
    v0
and method71 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
    (* run_target_args'
    let v677 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v683 : System.DateTime = System.DateTime.UnixEpoch
    let v687 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v688 : System.DateTime = v687 v683
    let v692 : System.DateTimeKind = System.DateTimeKind.Local
    let v693 : System.DateTime = System.DateTime.SpecifyKind (v1, v692)
    let v697 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v698 : System.DateTime = v697 v693
    (* run_target_args'
    let v707 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v708 : (System.DateTime -> int64) = _.Ticks
    let v709 : int64 = v708 v698
    let _run_target_args'_v707 = v709 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v710 : (System.DateTime -> int64) = _.Ticks
    let v711 : int64 = v710 v698
    let _run_target_args'_v707 = v711 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v713 : int64 = null |> unbox<int64>
    let _run_target_args'_v707 = v713 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v716 : (System.DateTime -> int64) = _.Ticks
    let v717 : int64 = v716 v698
    let _run_target_args'_v707 = v717 
    #endif
#if FABLE_COMPILER_PYTHON
    let v718 : (System.DateTime -> int64) = _.Ticks
    let v719 : int64 = v718 v698
    let _run_target_args'_v707 = v719 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v720 : (System.DateTime -> int64) = _.Ticks
    let v721 : int64 = v720 v698
    let _run_target_args'_v707 = v721 
    #endif
#else
    let v722 : (System.DateTime -> int64) = _.Ticks
    let v723 : int64 = v722 v698
    let _run_target_args'_v707 = v723 
    #endif
    let v724 : int64 = _run_target_args'_v707 
    (* run_target_args'
    let v751 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v752 : (System.DateTime -> int64) = _.Ticks
    let v753 : int64 = v752 v688
    let _run_target_args'_v751 = v753 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v754 : (System.DateTime -> int64) = _.Ticks
    let v755 : int64 = v754 v688
    let _run_target_args'_v751 = v755 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v757 : int64 = null |> unbox<int64>
    let _run_target_args'_v751 = v757 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v760 : (System.DateTime -> int64) = _.Ticks
    let v761 : int64 = v760 v688
    let _run_target_args'_v751 = v761 
    #endif
#if FABLE_COMPILER_PYTHON
    let v762 : (System.DateTime -> int64) = _.Ticks
    let v763 : int64 = v762 v688
    let _run_target_args'_v751 = v763 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v764 : (System.DateTime -> int64) = _.Ticks
    let v765 : int64 = v764 v688
    let _run_target_args'_v751 = v765 
    #endif
#else
    let v766 : (System.DateTime -> int64) = _.Ticks
    let v767 : int64 = v766 v688
    let _run_target_args'_v751 = v767 
    #endif
    let v768 : int64 = _run_target_args'_v751 
    let v790 : int64 = v724 |> int64 
    let v794 : int64 = v768 |> int64 
    let v797 : int64 = v790 - v794
    let v798 : int64 = v797 / 10L
    let v799 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v800 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v798 v799 
    let v803 : (chrono_DateTime<chrono_Utc> -> US12) = method72()
    let v804 : US12 option = v800 |> Option.map v803 
    let v824 : US12 = US12_1
    let v825 : US12 = v804 |> Option.defaultValue v824 
    let v845 : US5 =
        match v825 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v829) -> (* Some *)
            let v830 : string = "$0.naive_utc()"
            let v831 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v829 v830 
            let v832 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v833 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v831 v832 
            let v834 : string = "%Y%m%d-%H%M-%S%f"
            let v835 : string = "r#\"" + v834 + "\"#"
            let v836 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v835 
            let v837 : string = "$0.format($1).to_string()"
            let v838 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v833, v836) v837 
            let v839 : string = "fable_library_rust::String_::fromString($0)"
            let v840 : string = Fable.Core.RustInterop.emitRustExpr v838 v839 
            let v841 : string = $"{v840.[0..17]}-{v840.[18..21]}-{v840.[22]}"
            US5_0(v841)
    let v849 : string =
        match v845 with
        | US5_1 -> (* None *)
            let v847 : string = ""
            v847
        | US5_0(v846) -> (* Some *)
            v846
    (* run_target_args'
    let v854 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v855 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v856 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v855 
    let _run_target_args'_v854 = v856 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v858 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v858 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v862 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v862 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v866 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v866 
    #endif
#if FABLE_COMPILER_PYTHON
    let v870 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v854 = v870 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v873 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v854 = v873 
    #endif
#else
    let v874 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v854 = v874 
    #endif
    let v875 : System.TimeZoneInfo = _run_target_args'_v854 
    (* run_target_args'
    let v891 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v898 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v899 : (System.DateTime -> int64) = _.Ticks
    let v900 : int64 = v899 v698
    let _run_target_args'_v898 = v900 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v901 : (System.DateTime -> int64) = _.Ticks
    let v902 : int64 = v901 v698
    let _run_target_args'_v898 = v902 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v904 : int64 = null |> unbox<int64>
    let _run_target_args'_v898 = v904 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v907 : (System.DateTime -> int64) = _.Ticks
    let v908 : int64 = v907 v698
    let _run_target_args'_v898 = v908 
    #endif
#if FABLE_COMPILER_PYTHON
    let v909 : (System.DateTime -> int64) = _.Ticks
    let v910 : int64 = v909 v698
    let _run_target_args'_v898 = v910 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v911 : (System.DateTime -> int64) = _.Ticks
    let v912 : int64 = v911 v698
    let _run_target_args'_v898 = v912 
    #endif
#else
    let v913 : (System.DateTime -> int64) = _.Ticks
    let v914 : int64 = v913 v698
    let _run_target_args'_v898 = v914 
    #endif
    let v915 : int64 = _run_target_args'_v898 
    let v936 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v937 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v698, v915) v936 
    let v939 : System.TimeSpan = v937 |> System.TimeSpan 
    let _run_target_args'_v891 = v939 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v948 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v949 : (System.DateTime -> int64) = _.Ticks
    let v950 : int64 = v949 v698
    let _run_target_args'_v948 = v950 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v951 : (System.DateTime -> int64) = _.Ticks
    let v952 : int64 = v951 v698
    let _run_target_args'_v948 = v952 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v954 : int64 = null |> unbox<int64>
    let _run_target_args'_v948 = v954 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v957 : (System.DateTime -> int64) = _.Ticks
    let v958 : int64 = v957 v698
    let _run_target_args'_v948 = v958 
    #endif
#if FABLE_COMPILER_PYTHON
    let v959 : (System.DateTime -> int64) = _.Ticks
    let v960 : int64 = v959 v698
    let _run_target_args'_v948 = v960 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v961 : (System.DateTime -> int64) = _.Ticks
    let v962 : int64 = v961 v698
    let _run_target_args'_v948 = v962 
    #endif
#else
    let v963 : (System.DateTime -> int64) = _.Ticks
    let v964 : int64 = v963 v698
    let _run_target_args'_v948 = v964 
    #endif
    let v965 : int64 = _run_target_args'_v948 
    let v986 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v987 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v698, v965) v986 
    let v989 : System.TimeSpan = v987 |> System.TimeSpan 
    let _run_target_args'_v891 = v989 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v993 : US3 = US3_2
    let v994 : US4 = US4_4(v993)
    let v995 : string = $"date_time.get_utc_offset / target: {v994}"
    let v996 : System.TimeSpan = failwith<System.TimeSpan> v995
    let _run_target_args'_v891 = v996 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1000 : US3 = US3_0
    let v1001 : US4 = US4_5(v1000)
    let v1002 : string = $"date_time.get_utc_offset / target: {v1001}"
    let v1003 : System.TimeSpan = failwith<System.TimeSpan> v1002
    let _run_target_args'_v891 = v1003 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1007 : US3 = US3_0
    let v1008 : US4 = US4_6(v1007)
    let v1009 : string = $"date_time.get_utc_offset / target: {v1008}"
    let v1010 : System.TimeSpan = failwith<System.TimeSpan> v1009
    let _run_target_args'_v891 = v1010 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1013 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1018 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1019 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1020 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1019 
    let _run_target_args'_v1018 = v1020 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1022 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1022 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1026 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1026 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1030 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1030 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1034 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1018 = v1034 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1037 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1018 = v1037 
    #endif
#else
    let v1038 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1018 = v1038 
    #endif
    let v1039 : System.TimeZoneInfo = _run_target_args'_v1018 
    let v1048 : (System.DateTime -> System.TimeSpan) = v1013 v1039
    let v1049 : System.TimeSpan = v1048 v698
    let _run_target_args'_v891 = v1049 
    #endif
#else
    let v1050 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1055 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1056 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1057 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1056 
    let _run_target_args'_v1055 = v1057 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1059 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1059 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1063 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1063 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1067 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1067 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1071 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1055 = v1071 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1074 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1055 = v1074 
    #endif
#else
    let v1075 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1055 = v1075 
    #endif
    let v1076 : System.TimeZoneInfo = _run_target_args'_v1055 
    let v1085 : (System.DateTime -> System.TimeSpan) = v1050 v1076
    let v1086 : System.TimeSpan = v1085 v698
    let _run_target_args'_v891 = v1086 
    #endif
    let v1087 : System.TimeSpan = _run_target_args'_v891 
    let v1103 : (System.TimeSpan -> int32) = _.Hours
    let v1104 : int32 = v1103 v1087
    let v1107 : bool = v1104 > 0
    let v1108 : uint8 =
        if v1107 then
            1uy
        else
            0uy
    let v1109 : string = method73()
    (* run_target_args'
    let v1169 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1170 : string = "$0.toString($1)"
    let v1171 : string = Fable.Core.RustInterop.emitRustExpr struct (v1087, v1109) v1170 
    let _run_target_args'_v1169 = v1171 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1172 : string = "$0.toString($1)"
    let v1173 : string = Fable.Core.RustInterop.emitRustExpr struct (v1087, v1109) v1172 
    let _run_target_args'_v1169 = v1173 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1174 : string = "$0.toString($1)"
    let v1175 : string = Fable.Core.RustInterop.emitRustExpr struct (v1087, v1109) v1174 
    let _run_target_args'_v1169 = v1175 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1176 : string = v1087.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1169 = v1176 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1177 : string = v1087.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1169 = v1177 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1179 : string = v1087.ToString v1109 
    let _run_target_args'_v1169 = v1179 
    #endif
#else
    let v1238 : string = v1087.ToString v1109 
    let _run_target_args'_v1169 = v1238 
    #endif
    let v1296 : string = _run_target_args'_v1169 
    let v1415 : string = $"{v1108}{v1296.[0..1]}{v1296.[3..4]}"
    let v1417 : (System.Guid -> string) = _.ToString()
    let v1418 : string = v1417 v0
    let v1421 : int32 = v849.Length
    let v1422 : int32 = v1415.Length
    let v1423 : int32 = v1421 + v1422
    let v1425 : (string -> int32) = String.length
    let v1426 : int32 = v1425 v1418
    let v1434 : int32 = v1423 |> int32 
    let v1447 : int32 = v1426 |> int32 
    let v1455 : int32 = v1447 - 1
    let v1457 : string = v1418.[int v1434..int v1455]
    let v1461 : string = $"{v849}{v1415}{v1457}"
    (* run_target_args'
    let v1466 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1468 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1468 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1472 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1472 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1476 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1466 = v1476 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1480 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1480 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1484 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1484 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1488 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1488 
    #endif
#else
    let v1492 : System.Guid = v1461 |> System.Guid 
    let _run_target_args'_v1466 = v1492 
    #endif
    let v1495 : System.Guid = _run_target_args'_v1466 
    let _run_target_args'_v677 = v1495 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1509 : System.DateTime = System.DateTime.UnixEpoch
    let v1513 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1514 : System.DateTime = v1513 v1509
    let v1518 : System.DateTimeKind = System.DateTimeKind.Local
    let v1519 : System.DateTime = System.DateTime.SpecifyKind (v1, v1518)
    let v1523 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1524 : System.DateTime = v1523 v1519
    (* run_target_args'
    let v1533 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1534 : (System.DateTime -> int64) = _.Ticks
    let v1535 : int64 = v1534 v1524
    let _run_target_args'_v1533 = v1535 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1536 : (System.DateTime -> int64) = _.Ticks
    let v1537 : int64 = v1536 v1524
    let _run_target_args'_v1533 = v1537 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1539 : int64 = null |> unbox<int64>
    let _run_target_args'_v1533 = v1539 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1542 : (System.DateTime -> int64) = _.Ticks
    let v1543 : int64 = v1542 v1524
    let _run_target_args'_v1533 = v1543 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1544 : (System.DateTime -> int64) = _.Ticks
    let v1545 : int64 = v1544 v1524
    let _run_target_args'_v1533 = v1545 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1546 : (System.DateTime -> int64) = _.Ticks
    let v1547 : int64 = v1546 v1524
    let _run_target_args'_v1533 = v1547 
    #endif
#else
    let v1548 : (System.DateTime -> int64) = _.Ticks
    let v1549 : int64 = v1548 v1524
    let _run_target_args'_v1533 = v1549 
    #endif
    let v1550 : int64 = _run_target_args'_v1533 
    (* run_target_args'
    let v1577 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1578 : (System.DateTime -> int64) = _.Ticks
    let v1579 : int64 = v1578 v1514
    let _run_target_args'_v1577 = v1579 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1580 : (System.DateTime -> int64) = _.Ticks
    let v1581 : int64 = v1580 v1514
    let _run_target_args'_v1577 = v1581 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1583 : int64 = null |> unbox<int64>
    let _run_target_args'_v1577 = v1583 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1586 : (System.DateTime -> int64) = _.Ticks
    let v1587 : int64 = v1586 v1514
    let _run_target_args'_v1577 = v1587 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1588 : (System.DateTime -> int64) = _.Ticks
    let v1589 : int64 = v1588 v1514
    let _run_target_args'_v1577 = v1589 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1590 : (System.DateTime -> int64) = _.Ticks
    let v1591 : int64 = v1590 v1514
    let _run_target_args'_v1577 = v1591 
    #endif
#else
    let v1592 : (System.DateTime -> int64) = _.Ticks
    let v1593 : int64 = v1592 v1514
    let _run_target_args'_v1577 = v1593 
    #endif
    let v1594 : int64 = _run_target_args'_v1577 
    let v1616 : int64 = v1550 |> int64 
    let v1620 : int64 = v1594 |> int64 
    let v1623 : int64 = v1616 - v1620
    let v1624 : int64 = v1623 / 10L
    let v1625 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1626 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1624 v1625 
    let v1629 : (chrono_DateTime<chrono_Utc> -> US12) = method72()
    let v1630 : US12 option = v1626 |> Option.map v1629 
    let v1650 : US12 = US12_1
    let v1651 : US12 = v1630 |> Option.defaultValue v1650 
    let v1671 : US5 =
        match v1651 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v1655) -> (* Some *)
            let v1656 : string = "$0.naive_utc()"
            let v1657 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1655 v1656 
            let v1658 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1659 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1657 v1658 
            let v1660 : string = "%Y%m%d-%H%M-%S%f"
            let v1661 : string = "r#\"" + v1660 + "\"#"
            let v1662 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1661 
            let v1663 : string = "$0.format($1).to_string()"
            let v1664 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1659, v1662) v1663 
            let v1665 : string = "fable_library_rust::String_::fromString($0)"
            let v1666 : string = Fable.Core.RustInterop.emitRustExpr v1664 v1665 
            let v1667 : string = $"{v1666.[0..17]}-{v1666.[18..21]}-{v1666.[22]}"
            US5_0(v1667)
    let v1675 : string =
        match v1671 with
        | US5_1 -> (* None *)
            let v1673 : string = ""
            v1673
        | US5_0(v1672) -> (* Some *)
            v1672
    (* run_target_args'
    let v1680 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1681 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1682 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1681 
    let _run_target_args'_v1680 = v1682 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1684 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1684 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1688 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1688 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1692 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1692 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1696 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1680 = v1696 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1699 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1680 = v1699 
    #endif
#else
    let v1700 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1680 = v1700 
    #endif
    let v1701 : System.TimeZoneInfo = _run_target_args'_v1680 
    (* run_target_args'
    let v1717 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1724 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1725 : (System.DateTime -> int64) = _.Ticks
    let v1726 : int64 = v1725 v1524
    let _run_target_args'_v1724 = v1726 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1727 : (System.DateTime -> int64) = _.Ticks
    let v1728 : int64 = v1727 v1524
    let _run_target_args'_v1724 = v1728 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1730 : int64 = null |> unbox<int64>
    let _run_target_args'_v1724 = v1730 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1733 : (System.DateTime -> int64) = _.Ticks
    let v1734 : int64 = v1733 v1524
    let _run_target_args'_v1724 = v1734 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1735 : (System.DateTime -> int64) = _.Ticks
    let v1736 : int64 = v1735 v1524
    let _run_target_args'_v1724 = v1736 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1737 : (System.DateTime -> int64) = _.Ticks
    let v1738 : int64 = v1737 v1524
    let _run_target_args'_v1724 = v1738 
    #endif
#else
    let v1739 : (System.DateTime -> int64) = _.Ticks
    let v1740 : int64 = v1739 v1524
    let _run_target_args'_v1724 = v1740 
    #endif
    let v1741 : int64 = _run_target_args'_v1724 
    let v1762 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1763 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1524, v1741) v1762 
    let v1765 : System.TimeSpan = v1763 |> System.TimeSpan 
    let _run_target_args'_v1717 = v1765 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1774 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1775 : (System.DateTime -> int64) = _.Ticks
    let v1776 : int64 = v1775 v1524
    let _run_target_args'_v1774 = v1776 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1777 : (System.DateTime -> int64) = _.Ticks
    let v1778 : int64 = v1777 v1524
    let _run_target_args'_v1774 = v1778 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1780 : int64 = null |> unbox<int64>
    let _run_target_args'_v1774 = v1780 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1783 : (System.DateTime -> int64) = _.Ticks
    let v1784 : int64 = v1783 v1524
    let _run_target_args'_v1774 = v1784 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1785 : (System.DateTime -> int64) = _.Ticks
    let v1786 : int64 = v1785 v1524
    let _run_target_args'_v1774 = v1786 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1787 : (System.DateTime -> int64) = _.Ticks
    let v1788 : int64 = v1787 v1524
    let _run_target_args'_v1774 = v1788 
    #endif
#else
    let v1789 : (System.DateTime -> int64) = _.Ticks
    let v1790 : int64 = v1789 v1524
    let _run_target_args'_v1774 = v1790 
    #endif
    let v1791 : int64 = _run_target_args'_v1774 
    let v1812 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1813 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1524, v1791) v1812 
    let v1815 : System.TimeSpan = v1813 |> System.TimeSpan 
    let _run_target_args'_v1717 = v1815 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1819 : US3 = US3_2
    let v1820 : US4 = US4_4(v1819)
    let v1821 : string = $"date_time.get_utc_offset / target: {v1820}"
    let v1822 : System.TimeSpan = failwith<System.TimeSpan> v1821
    let _run_target_args'_v1717 = v1822 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1826 : US3 = US3_0
    let v1827 : US4 = US4_5(v1826)
    let v1828 : string = $"date_time.get_utc_offset / target: {v1827}"
    let v1829 : System.TimeSpan = failwith<System.TimeSpan> v1828
    let _run_target_args'_v1717 = v1829 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1833 : US3 = US3_0
    let v1834 : US4 = US4_6(v1833)
    let v1835 : string = $"date_time.get_utc_offset / target: {v1834}"
    let v1836 : System.TimeSpan = failwith<System.TimeSpan> v1835
    let _run_target_args'_v1717 = v1836 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1839 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1844 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1845 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1846 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1845 
    let _run_target_args'_v1844 = v1846 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1848 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1848 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1852 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1852 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1856 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1856 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1860 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1844 = v1860 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1863 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1844 = v1863 
    #endif
#else
    let v1864 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1844 = v1864 
    #endif
    let v1865 : System.TimeZoneInfo = _run_target_args'_v1844 
    let v1874 : (System.DateTime -> System.TimeSpan) = v1839 v1865
    let v1875 : System.TimeSpan = v1874 v1524
    let _run_target_args'_v1717 = v1875 
    #endif
#else
    let v1876 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
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
    let v1885 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1885 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1889 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1889 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1893 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1897 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1881 = v1897 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1900 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1900 
    #endif
#else
    let v1901 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1881 = v1901 
    #endif
    let v1902 : System.TimeZoneInfo = _run_target_args'_v1881 
    let v1911 : (System.DateTime -> System.TimeSpan) = v1876 v1902
    let v1912 : System.TimeSpan = v1911 v1524
    let _run_target_args'_v1717 = v1912 
    #endif
    let v1913 : System.TimeSpan = _run_target_args'_v1717 
    let v1929 : (System.TimeSpan -> int32) = _.Hours
    let v1930 : int32 = v1929 v1913
    let v1933 : bool = v1930 > 0
    let v1934 : uint8 =
        if v1933 then
            1uy
        else
            0uy
    let v1935 : string = method73()
    (* run_target_args'
    let v1995 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1996 : string = "$0.toString($1)"
    let v1997 : string = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1935) v1996 
    let _run_target_args'_v1995 = v1997 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1998 : string = "$0.toString($1)"
    let v1999 : string = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1935) v1998 
    let _run_target_args'_v1995 = v1999 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2000 : string = "$0.toString($1)"
    let v2001 : string = Fable.Core.RustInterop.emitRustExpr struct (v1913, v1935) v2000 
    let _run_target_args'_v1995 = v2001 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2002 : string = v1913.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1995 = v2002 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2003 : string = v1913.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1995 = v2003 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2005 : string = v1913.ToString v1935 
    let _run_target_args'_v1995 = v2005 
    #endif
#else
    let v2064 : string = v1913.ToString v1935 
    let _run_target_args'_v1995 = v2064 
    #endif
    let v2122 : string = _run_target_args'_v1995 
    let v2241 : string = $"{v1934}{v2122.[0..1]}{v2122.[3..4]}"
    let v2243 : (System.Guid -> string) = _.ToString()
    let v2244 : string = v2243 v0
    let v2247 : int32 = v1675.Length
    let v2248 : int32 = v2241.Length
    let v2249 : int32 = v2247 + v2248
    let v2251 : (string -> int32) = String.length
    let v2252 : int32 = v2251 v2244
    let v2260 : int32 = v2249 |> int32 
    let v2273 : int32 = v2252 |> int32 
    let v2281 : int32 = v2273 - 1
    let v2283 : string = v2244.[int v2260..int v2281]
    let v2287 : string = $"{v1675}{v2241}{v2283}"
    (* run_target_args'
    let v2292 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2294 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2294 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2298 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2298 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2302 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2292 = v2302 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2306 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2306 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2310 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2310 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2314 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2314 
    #endif
#else
    let v2318 : System.Guid = v2287 |> System.Guid 
    let _run_target_args'_v2292 = v2318 
    #endif
    let v2321 : System.Guid = _run_target_args'_v2292 
    let _run_target_args'_v677 = v2321 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2331 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v677 = v2331 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2334 : string = method74()
    let v2335 : bool = v2334 = ""
    let v2337 : string =
        if v2335 then
            let v2336 : string = "M-d-y hh:mm:ss tt"
            v2336
        else
            v2334
    let v2338 : (string -> string) = v1.ToString
    let v2339 : string = v2338 v2337
    (* run_target_args'
    let v2358 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2359 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2360 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2359 
    let _run_target_args'_v2358 = v2360 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2362 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2362 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2366 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2366 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2370 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2370 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2374 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2358 = v2374 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2377 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2358 = v2377 
    #endif
#else
    let v2378 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2358 = v2378 
    #endif
    let v2379 : System.TimeZoneInfo = _run_target_args'_v2358 
    (* run_target_args'
    let v2395 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2402 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2403 : (System.DateTime -> int64) = _.Ticks
    let v2404 : int64 = v2403 v1
    let _run_target_args'_v2402 = v2404 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2405 : (System.DateTime -> int64) = _.Ticks
    let v2406 : int64 = v2405 v1
    let _run_target_args'_v2402 = v2406 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2408 : int64 = null |> unbox<int64>
    let _run_target_args'_v2402 = v2408 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2411 : (System.DateTime -> int64) = _.Ticks
    let v2412 : int64 = v2411 v1
    let _run_target_args'_v2402 = v2412 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2413 : (System.DateTime -> int64) = _.Ticks
    let v2414 : int64 = v2413 v1
    let _run_target_args'_v2402 = v2414 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2415 : (System.DateTime -> int64) = _.Ticks
    let v2416 : int64 = v2415 v1
    let _run_target_args'_v2402 = v2416 
    #endif
#else
    let v2417 : (System.DateTime -> int64) = _.Ticks
    let v2418 : int64 = v2417 v1
    let _run_target_args'_v2402 = v2418 
    #endif
    let v2419 : int64 = _run_target_args'_v2402 
    let v2440 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2441 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2419) v2440 
    let v2443 : System.TimeSpan = v2441 |> System.TimeSpan 
    let _run_target_args'_v2395 = v2443 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2452 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2453 : (System.DateTime -> int64) = _.Ticks
    let v2454 : int64 = v2453 v1
    let _run_target_args'_v2452 = v2454 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2455 : (System.DateTime -> int64) = _.Ticks
    let v2456 : int64 = v2455 v1
    let _run_target_args'_v2452 = v2456 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2458 : int64 = null |> unbox<int64>
    let _run_target_args'_v2452 = v2458 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2461 : (System.DateTime -> int64) = _.Ticks
    let v2462 : int64 = v2461 v1
    let _run_target_args'_v2452 = v2462 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2463 : (System.DateTime -> int64) = _.Ticks
    let v2464 : int64 = v2463 v1
    let _run_target_args'_v2452 = v2464 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2465 : (System.DateTime -> int64) = _.Ticks
    let v2466 : int64 = v2465 v1
    let _run_target_args'_v2452 = v2466 
    #endif
#else
    let v2467 : (System.DateTime -> int64) = _.Ticks
    let v2468 : int64 = v2467 v1
    let _run_target_args'_v2452 = v2468 
    #endif
    let v2469 : int64 = _run_target_args'_v2452 
    let v2490 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2491 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2469) v2490 
    let v2493 : System.TimeSpan = v2491 |> System.TimeSpan 
    let _run_target_args'_v2395 = v2493 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2497 : US3 = US3_2
    let v2498 : US4 = US4_4(v2497)
    let v2499 : string = $"date_time.get_utc_offset / target: {v2498}"
    let v2500 : System.TimeSpan = failwith<System.TimeSpan> v2499
    let _run_target_args'_v2395 = v2500 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2504 : US3 = US3_0
    let v2505 : US4 = US4_5(v2504)
    let v2506 : string = $"date_time.get_utc_offset / target: {v2505}"
    let v2507 : System.TimeSpan = failwith<System.TimeSpan> v2506
    let _run_target_args'_v2395 = v2507 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2511 : US3 = US3_0
    let v2512 : US4 = US4_6(v2511)
    let v2513 : string = $"date_time.get_utc_offset / target: {v2512}"
    let v2514 : System.TimeSpan = failwith<System.TimeSpan> v2513
    let _run_target_args'_v2395 = v2514 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2517 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2522 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2523 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2524 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2523 
    let _run_target_args'_v2522 = v2524 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2526 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2526 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2530 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2530 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2534 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2534 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2538 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2522 = v2538 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2541 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2522 = v2541 
    #endif
#else
    let v2542 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2522 = v2542 
    #endif
    let v2543 : System.TimeZoneInfo = _run_target_args'_v2522 
    let v2552 : (System.DateTime -> System.TimeSpan) = v2517 v2543
    let v2553 : System.TimeSpan = v2552 v1
    let _run_target_args'_v2395 = v2553 
    #endif
#else
    let v2554 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2559 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2560 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2561 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2560 
    let _run_target_args'_v2559 = v2561 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2563 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2563 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2567 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2567 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2571 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2575 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2559 = v2575 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2578 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2559 = v2578 
    #endif
#else
    let v2579 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2559 = v2579 
    #endif
    let v2580 : System.TimeZoneInfo = _run_target_args'_v2559 
    let v2589 : (System.DateTime -> System.TimeSpan) = v2554 v2580
    let v2590 : System.TimeSpan = v2589 v1
    let _run_target_args'_v2395 = v2590 
    #endif
    let v2591 : System.TimeSpan = _run_target_args'_v2395 
    let v2607 : (System.TimeSpan -> int32) = _.Hours
    let v2608 : int32 = v2607 v2591
    let v2611 : bool = v2608 > 0
    let v2612 : uint8 =
        if v2611 then
            1uy
        else
            0uy
    let v2613 : string = method75()
    (* run_target_args'
    let v2673 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2674 : string = "$0.toString($1)"
    let v2675 : string = Fable.Core.RustInterop.emitRustExpr struct (v2591, v2613) v2674 
    let _run_target_args'_v2673 = v2675 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2676 : string = "$0.toString($1)"
    let v2677 : string = Fable.Core.RustInterop.emitRustExpr struct (v2591, v2613) v2676 
    let _run_target_args'_v2673 = v2677 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2678 : string = "$0.toString($1)"
    let v2679 : string = Fable.Core.RustInterop.emitRustExpr struct (v2591, v2613) v2678 
    let _run_target_args'_v2673 = v2679 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2680 : string = v2591.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2673 = v2680 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2681 : string = v2591.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2673 = v2681 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2683 : string = v2591.ToString v2613 
    let _run_target_args'_v2673 = v2683 
    #endif
#else
    let v2742 : string = v2591.ToString v2613 
    let _run_target_args'_v2673 = v2742 
    #endif
    let v2800 : string = _run_target_args'_v2673 
    let v2919 : string = $"{v2612}{v2800}"
    let v2921 : (System.Guid -> string) = _.ToString()
    let v2922 : string = v2921 v0
    let v2925 : int32 = v2339.Length
    let v2926 : int32 = v2919.Length
    let v2927 : int32 = v2925 + v2926
    let v2929 : (string -> int32) = String.length
    let v2930 : int32 = v2929 v2922
    let v2938 : int32 = v2927 |> int32 
    let v2951 : int32 = v2930 |> int32 
    let v2959 : int32 = v2951 - 1
    let v2961 : string = v2922.[int v2938..int v2959]
    let v2965 : string = $"{v2339}{v2919}{v2961}"
    (* run_target_args'
    let v2970 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2972 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2972 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2976 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2976 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2980 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2970 = v2980 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2984 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2984 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2988 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2988 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2992 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2992 
    #endif
#else
    let v2996 : System.Guid = v2965 |> System.Guid 
    let _run_target_args'_v2970 = v2996 
    #endif
    let v2999 : System.Guid = _run_target_args'_v2970 
    let _run_target_args'_v677 = v2999 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3008 : string = method74()
    let v3009 : bool = v3008 = ""
    let v3011 : string =
        if v3009 then
            let v3010 : string = "M-d-y hh:mm:ss tt"
            v3010
        else
            v3008
    let v3012 : (string -> string) = v1.ToString
    let v3013 : string = v3012 v3011
    (* run_target_args'
    let v3032 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3033 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3034 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3033 
    let _run_target_args'_v3032 = v3034 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3036 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3036 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3040 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3040 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3044 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3044 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3048 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3032 = v3048 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3051 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3032 = v3051 
    #endif
#else
    let v3052 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3032 = v3052 
    #endif
    let v3053 : System.TimeZoneInfo = _run_target_args'_v3032 
    (* run_target_args'
    let v3069 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3076 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3077 : (System.DateTime -> int64) = _.Ticks
    let v3078 : int64 = v3077 v1
    let _run_target_args'_v3076 = v3078 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3079 : (System.DateTime -> int64) = _.Ticks
    let v3080 : int64 = v3079 v1
    let _run_target_args'_v3076 = v3080 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3082 : int64 = null |> unbox<int64>
    let _run_target_args'_v3076 = v3082 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3085 : (System.DateTime -> int64) = _.Ticks
    let v3086 : int64 = v3085 v1
    let _run_target_args'_v3076 = v3086 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3087 : (System.DateTime -> int64) = _.Ticks
    let v3088 : int64 = v3087 v1
    let _run_target_args'_v3076 = v3088 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3089 : (System.DateTime -> int64) = _.Ticks
    let v3090 : int64 = v3089 v1
    let _run_target_args'_v3076 = v3090 
    #endif
#else
    let v3091 : (System.DateTime -> int64) = _.Ticks
    let v3092 : int64 = v3091 v1
    let _run_target_args'_v3076 = v3092 
    #endif
    let v3093 : int64 = _run_target_args'_v3076 
    let v3114 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3115 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3093) v3114 
    let v3117 : System.TimeSpan = v3115 |> System.TimeSpan 
    let _run_target_args'_v3069 = v3117 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3126 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3127 : (System.DateTime -> int64) = _.Ticks
    let v3128 : int64 = v3127 v1
    let _run_target_args'_v3126 = v3128 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3129 : (System.DateTime -> int64) = _.Ticks
    let v3130 : int64 = v3129 v1
    let _run_target_args'_v3126 = v3130 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3132 : int64 = null |> unbox<int64>
    let _run_target_args'_v3126 = v3132 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3135 : (System.DateTime -> int64) = _.Ticks
    let v3136 : int64 = v3135 v1
    let _run_target_args'_v3126 = v3136 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3137 : (System.DateTime -> int64) = _.Ticks
    let v3138 : int64 = v3137 v1
    let _run_target_args'_v3126 = v3138 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3139 : (System.DateTime -> int64) = _.Ticks
    let v3140 : int64 = v3139 v1
    let _run_target_args'_v3126 = v3140 
    #endif
#else
    let v3141 : (System.DateTime -> int64) = _.Ticks
    let v3142 : int64 = v3141 v1
    let _run_target_args'_v3126 = v3142 
    #endif
    let v3143 : int64 = _run_target_args'_v3126 
    let v3164 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3165 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3143) v3164 
    let v3167 : System.TimeSpan = v3165 |> System.TimeSpan 
    let _run_target_args'_v3069 = v3167 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3171 : US3 = US3_2
    let v3172 : US4 = US4_4(v3171)
    let v3173 : string = $"date_time.get_utc_offset / target: {v3172}"
    let v3174 : System.TimeSpan = failwith<System.TimeSpan> v3173
    let _run_target_args'_v3069 = v3174 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3178 : US3 = US3_0
    let v3179 : US4 = US4_5(v3178)
    let v3180 : string = $"date_time.get_utc_offset / target: {v3179}"
    let v3181 : System.TimeSpan = failwith<System.TimeSpan> v3180
    let _run_target_args'_v3069 = v3181 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3185 : US3 = US3_0
    let v3186 : US4 = US4_6(v3185)
    let v3187 : string = $"date_time.get_utc_offset / target: {v3186}"
    let v3188 : System.TimeSpan = failwith<System.TimeSpan> v3187
    let _run_target_args'_v3069 = v3188 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3191 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3196 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3197 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3198 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3197 
    let _run_target_args'_v3196 = v3198 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3200 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3200 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3204 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3204 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3208 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3208 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3212 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3196 = v3212 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3215 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3196 = v3215 
    #endif
#else
    let v3216 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3196 = v3216 
    #endif
    let v3217 : System.TimeZoneInfo = _run_target_args'_v3196 
    let v3226 : (System.DateTime -> System.TimeSpan) = v3191 v3217
    let v3227 : System.TimeSpan = v3226 v1
    let _run_target_args'_v3069 = v3227 
    #endif
#else
    let v3228 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3233 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3234 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3235 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3234 
    let _run_target_args'_v3233 = v3235 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3237 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3237 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3241 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3241 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3245 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3245 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3249 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3233 = v3249 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3252 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3233 = v3252 
    #endif
#else
    let v3253 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3233 = v3253 
    #endif
    let v3254 : System.TimeZoneInfo = _run_target_args'_v3233 
    let v3263 : (System.DateTime -> System.TimeSpan) = v3228 v3254
    let v3264 : System.TimeSpan = v3263 v1
    let _run_target_args'_v3069 = v3264 
    #endif
    let v3265 : System.TimeSpan = _run_target_args'_v3069 
    let v3281 : (System.TimeSpan -> int32) = _.Hours
    let v3282 : int32 = v3281 v3265
    let v3285 : bool = v3282 > 0
    let v3286 : uint8 =
        if v3285 then
            1uy
        else
            0uy
    let v3287 : string = method75()
    (* run_target_args'
    let v3347 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3348 : string = "$0.toString($1)"
    let v3349 : string = Fable.Core.RustInterop.emitRustExpr struct (v3265, v3287) v3348 
    let _run_target_args'_v3347 = v3349 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3350 : string = "$0.toString($1)"
    let v3351 : string = Fable.Core.RustInterop.emitRustExpr struct (v3265, v3287) v3350 
    let _run_target_args'_v3347 = v3351 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3352 : string = "$0.toString($1)"
    let v3353 : string = Fable.Core.RustInterop.emitRustExpr struct (v3265, v3287) v3352 
    let _run_target_args'_v3347 = v3353 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3354 : string = v3265.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3347 = v3354 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3355 : string = v3265.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3347 = v3355 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3357 : string = v3265.ToString v3287 
    let _run_target_args'_v3347 = v3357 
    #endif
#else
    let v3416 : string = v3265.ToString v3287 
    let _run_target_args'_v3347 = v3416 
    #endif
    let v3474 : string = _run_target_args'_v3347 
    let v3593 : string = $"{v3286}{v3474}"
    let v3595 : (System.Guid -> string) = _.ToString()
    let v3596 : string = v3595 v0
    let v3599 : int32 = v3013.Length
    let v3600 : int32 = v3593.Length
    let v3601 : int32 = v3599 + v3600
    let v3603 : (string -> int32) = String.length
    let v3604 : int32 = v3603 v3596
    let v3612 : int32 = v3601 |> int32 
    let v3625 : int32 = v3604 |> int32 
    let v3633 : int32 = v3625 - 1
    let v3635 : string = v3596.[int v3612..int v3633]
    let v3639 : string = $"{v3013}{v3593}{v3635}"
    (* run_target_args'
    let v3644 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3646 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3646 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3650 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3650 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3654 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3644 = v3654 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3658 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3658 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3662 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3662 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3666 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3666 
    #endif
#else
    let v3670 : System.Guid = v3639 |> System.Guid 
    let _run_target_args'_v3644 = v3670 
    #endif
    let v3673 : System.Guid = _run_target_args'_v3644 
    let _run_target_args'_v677 = v3673 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3682 : string = method74()
    let v3683 : bool = v3682 = ""
    let v3685 : string =
        if v3683 then
            let v3684 : string = "M-d-y hh:mm:ss tt"
            v3684
        else
            v3682
    let v3686 : (string -> string) = v1.ToString
    let v3687 : string = v3686 v3685
    (* run_target_args'
    let v3706 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3707 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3708 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3707 
    let _run_target_args'_v3706 = v3708 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3710 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3710 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3714 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3714 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3718 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3718 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3722 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3706 = v3722 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3725 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3706 = v3725 
    #endif
#else
    let v3726 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3706 = v3726 
    #endif
    let v3727 : System.TimeZoneInfo = _run_target_args'_v3706 
    (* run_target_args'
    let v3743 : unit = ()
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
    let v3788 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3789 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3767) v3788 
    let v3791 : System.TimeSpan = v3789 |> System.TimeSpan 
    let _run_target_args'_v3743 = v3791 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3800 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3801 : (System.DateTime -> int64) = _.Ticks
    let v3802 : int64 = v3801 v1
    let _run_target_args'_v3800 = v3802 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3803 : (System.DateTime -> int64) = _.Ticks
    let v3804 : int64 = v3803 v1
    let _run_target_args'_v3800 = v3804 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3806 : int64 = null |> unbox<int64>
    let _run_target_args'_v3800 = v3806 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3809 : (System.DateTime -> int64) = _.Ticks
    let v3810 : int64 = v3809 v1
    let _run_target_args'_v3800 = v3810 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3811 : (System.DateTime -> int64) = _.Ticks
    let v3812 : int64 = v3811 v1
    let _run_target_args'_v3800 = v3812 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3813 : (System.DateTime -> int64) = _.Ticks
    let v3814 : int64 = v3813 v1
    let _run_target_args'_v3800 = v3814 
    #endif
#else
    let v3815 : (System.DateTime -> int64) = _.Ticks
    let v3816 : int64 = v3815 v1
    let _run_target_args'_v3800 = v3816 
    #endif
    let v3817 : int64 = _run_target_args'_v3800 
    let v3838 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3839 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3817) v3838 
    let v3841 : System.TimeSpan = v3839 |> System.TimeSpan 
    let _run_target_args'_v3743 = v3841 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3845 : US3 = US3_2
    let v3846 : US4 = US4_4(v3845)
    let v3847 : string = $"date_time.get_utc_offset / target: {v3846}"
    let v3848 : System.TimeSpan = failwith<System.TimeSpan> v3847
    let _run_target_args'_v3743 = v3848 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3852 : US3 = US3_0
    let v3853 : US4 = US4_5(v3852)
    let v3854 : string = $"date_time.get_utc_offset / target: {v3853}"
    let v3855 : System.TimeSpan = failwith<System.TimeSpan> v3854
    let _run_target_args'_v3743 = v3855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3859 : US3 = US3_0
    let v3860 : US4 = US4_6(v3859)
    let v3861 : string = $"date_time.get_utc_offset / target: {v3860}"
    let v3862 : System.TimeSpan = failwith<System.TimeSpan> v3861
    let _run_target_args'_v3743 = v3862 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3865 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3870 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3871 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3872 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3871 
    let _run_target_args'_v3870 = v3872 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3874 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3874 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3878 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3878 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3882 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3882 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3886 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3870 = v3886 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3889 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3870 = v3889 
    #endif
#else
    let v3890 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3870 = v3890 
    #endif
    let v3891 : System.TimeZoneInfo = _run_target_args'_v3870 
    let v3900 : (System.DateTime -> System.TimeSpan) = v3865 v3891
    let v3901 : System.TimeSpan = v3900 v1
    let _run_target_args'_v3743 = v3901 
    #endif
#else
    let v3902 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3907 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3908 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3909 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3908 
    let _run_target_args'_v3907 = v3909 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3911 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3911 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3915 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3919 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3907 = v3923 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3926 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3907 = v3926 
    #endif
#else
    let v3927 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3907 = v3927 
    #endif
    let v3928 : System.TimeZoneInfo = _run_target_args'_v3907 
    let v3937 : (System.DateTime -> System.TimeSpan) = v3902 v3928
    let v3938 : System.TimeSpan = v3937 v1
    let _run_target_args'_v3743 = v3938 
    #endif
    let v3939 : System.TimeSpan = _run_target_args'_v3743 
    let v3955 : (System.TimeSpan -> int32) = _.Hours
    let v3956 : int32 = v3955 v3939
    let v3959 : bool = v3956 > 0
    let v3960 : uint8 =
        if v3959 then
            1uy
        else
            0uy
    let v3961 : string = method75()
    (* run_target_args'
    let v4021 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4022 : string = "$0.toString($1)"
    let v4023 : string = Fable.Core.RustInterop.emitRustExpr struct (v3939, v3961) v4022 
    let _run_target_args'_v4021 = v4023 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4024 : string = "$0.toString($1)"
    let v4025 : string = Fable.Core.RustInterop.emitRustExpr struct (v3939, v3961) v4024 
    let _run_target_args'_v4021 = v4025 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4026 : string = "$0.toString($1)"
    let v4027 : string = Fable.Core.RustInterop.emitRustExpr struct (v3939, v3961) v4026 
    let _run_target_args'_v4021 = v4027 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4028 : string = v3939.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4021 = v4028 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4029 : string = v3939.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4021 = v4029 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4031 : string = v3939.ToString v3961 
    let _run_target_args'_v4021 = v4031 
    #endif
#else
    let v4090 : string = v3939.ToString v3961 
    let _run_target_args'_v4021 = v4090 
    #endif
    let v4148 : string = _run_target_args'_v4021 
    let v4267 : string = $"{v3960}{v4148}"
    let v4269 : (System.Guid -> string) = _.ToString()
    let v4270 : string = v4269 v0
    let v4273 : int32 = v3687.Length
    let v4274 : int32 = v4267.Length
    let v4275 : int32 = v4273 + v4274
    let v4277 : (string -> int32) = String.length
    let v4278 : int32 = v4277 v4270
    let v4286 : int32 = v4275 |> int32 
    let v4299 : int32 = v4278 |> int32 
    let v4307 : int32 = v4299 - 1
    let v4309 : string = v4270.[int v4286..int v4307]
    let v4313 : string = $"{v3687}{v4267}{v4309}"
    (* run_target_args'
    let v4318 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4320 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4320 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4324 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4324 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4328 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4318 = v4328 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4332 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4332 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4336 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4336 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4340 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4340 
    #endif
#else
    let v4344 : System.Guid = v4313 |> System.Guid 
    let _run_target_args'_v4318 = v4344 
    #endif
    let v4347 : System.Guid = _run_target_args'_v4318 
    let _run_target_args'_v677 = v4347 
    #endif
#else
    let v4356 : string = method74()
    let v4357 : bool = v4356 = ""
    let v4359 : string =
        if v4357 then
            let v4358 : string = "M-d-y hh:mm:ss tt"
            v4358
        else
            v4356
    let v4360 : (string -> string) = v1.ToString
    let v4361 : string = v4360 v4359
    (* run_target_args'
    let v4380 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4381 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4382 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4381 
    let _run_target_args'_v4380 = v4382 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4384 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4384 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4388 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4388 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4392 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4392 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4396 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4380 = v4396 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4399 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4380 = v4399 
    #endif
#else
    let v4400 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4380 = v4400 
    #endif
    let v4401 : System.TimeZoneInfo = _run_target_args'_v4380 
    (* run_target_args'
    let v4417 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4424 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4425 : (System.DateTime -> int64) = _.Ticks
    let v4426 : int64 = v4425 v1
    let _run_target_args'_v4424 = v4426 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4427 : (System.DateTime -> int64) = _.Ticks
    let v4428 : int64 = v4427 v1
    let _run_target_args'_v4424 = v4428 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4430 : int64 = null |> unbox<int64>
    let _run_target_args'_v4424 = v4430 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4433 : (System.DateTime -> int64) = _.Ticks
    let v4434 : int64 = v4433 v1
    let _run_target_args'_v4424 = v4434 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4435 : (System.DateTime -> int64) = _.Ticks
    let v4436 : int64 = v4435 v1
    let _run_target_args'_v4424 = v4436 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4437 : (System.DateTime -> int64) = _.Ticks
    let v4438 : int64 = v4437 v1
    let _run_target_args'_v4424 = v4438 
    #endif
#else
    let v4439 : (System.DateTime -> int64) = _.Ticks
    let v4440 : int64 = v4439 v1
    let _run_target_args'_v4424 = v4440 
    #endif
    let v4441 : int64 = _run_target_args'_v4424 
    let v4462 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4463 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4441) v4462 
    let v4465 : System.TimeSpan = v4463 |> System.TimeSpan 
    let _run_target_args'_v4417 = v4465 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4474 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4475 : (System.DateTime -> int64) = _.Ticks
    let v4476 : int64 = v4475 v1
    let _run_target_args'_v4474 = v4476 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4477 : (System.DateTime -> int64) = _.Ticks
    let v4478 : int64 = v4477 v1
    let _run_target_args'_v4474 = v4478 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4480 : int64 = null |> unbox<int64>
    let _run_target_args'_v4474 = v4480 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4483 : (System.DateTime -> int64) = _.Ticks
    let v4484 : int64 = v4483 v1
    let _run_target_args'_v4474 = v4484 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4485 : (System.DateTime -> int64) = _.Ticks
    let v4486 : int64 = v4485 v1
    let _run_target_args'_v4474 = v4486 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4487 : (System.DateTime -> int64) = _.Ticks
    let v4488 : int64 = v4487 v1
    let _run_target_args'_v4474 = v4488 
    #endif
#else
    let v4489 : (System.DateTime -> int64) = _.Ticks
    let v4490 : int64 = v4489 v1
    let _run_target_args'_v4474 = v4490 
    #endif
    let v4491 : int64 = _run_target_args'_v4474 
    let v4512 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4513 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4491) v4512 
    let v4515 : System.TimeSpan = v4513 |> System.TimeSpan 
    let _run_target_args'_v4417 = v4515 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4519 : US3 = US3_2
    let v4520 : US4 = US4_4(v4519)
    let v4521 : string = $"date_time.get_utc_offset / target: {v4520}"
    let v4522 : System.TimeSpan = failwith<System.TimeSpan> v4521
    let _run_target_args'_v4417 = v4522 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4526 : US3 = US3_0
    let v4527 : US4 = US4_5(v4526)
    let v4528 : string = $"date_time.get_utc_offset / target: {v4527}"
    let v4529 : System.TimeSpan = failwith<System.TimeSpan> v4528
    let _run_target_args'_v4417 = v4529 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4533 : US3 = US3_0
    let v4534 : US4 = US4_6(v4533)
    let v4535 : string = $"date_time.get_utc_offset / target: {v4534}"
    let v4536 : System.TimeSpan = failwith<System.TimeSpan> v4535
    let _run_target_args'_v4417 = v4536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4539 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4544 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4545 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4546 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4545 
    let _run_target_args'_v4544 = v4546 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4548 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4548 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4552 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4552 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4556 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4556 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4560 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4544 = v4560 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4563 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4544 = v4563 
    #endif
#else
    let v4564 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4544 = v4564 
    #endif
    let v4565 : System.TimeZoneInfo = _run_target_args'_v4544 
    let v4574 : (System.DateTime -> System.TimeSpan) = v4539 v4565
    let v4575 : System.TimeSpan = v4574 v1
    let _run_target_args'_v4417 = v4575 
    #endif
#else
    let v4576 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4581 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4582 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4583 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4582 
    let _run_target_args'_v4581 = v4583 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4585 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4585 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4589 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4589 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4593 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4593 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4597 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4581 = v4597 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4600 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4581 = v4600 
    #endif
#else
    let v4601 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4581 = v4601 
    #endif
    let v4602 : System.TimeZoneInfo = _run_target_args'_v4581 
    let v4611 : (System.DateTime -> System.TimeSpan) = v4576 v4602
    let v4612 : System.TimeSpan = v4611 v1
    let _run_target_args'_v4417 = v4612 
    #endif
    let v4613 : System.TimeSpan = _run_target_args'_v4417 
    let v4629 : (System.TimeSpan -> int32) = _.Hours
    let v4630 : int32 = v4629 v4613
    let v4633 : bool = v4630 > 0
    let v4634 : uint8 =
        if v4633 then
            1uy
        else
            0uy
    let v4635 : string = method75()
    (* run_target_args'
    let v4695 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4696 : string = "$0.toString($1)"
    let v4697 : string = Fable.Core.RustInterop.emitRustExpr struct (v4613, v4635) v4696 
    let _run_target_args'_v4695 = v4697 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4698 : string = "$0.toString($1)"
    let v4699 : string = Fable.Core.RustInterop.emitRustExpr struct (v4613, v4635) v4698 
    let _run_target_args'_v4695 = v4699 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4700 : string = "$0.toString($1)"
    let v4701 : string = Fable.Core.RustInterop.emitRustExpr struct (v4613, v4635) v4700 
    let _run_target_args'_v4695 = v4701 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4702 : string = v4613.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4695 = v4702 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4703 : string = v4613.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4695 = v4703 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4705 : string = v4613.ToString v4635 
    let _run_target_args'_v4695 = v4705 
    #endif
#else
    let v4764 : string = v4613.ToString v4635 
    let _run_target_args'_v4695 = v4764 
    #endif
    let v4822 : string = _run_target_args'_v4695 
    let v4941 : string = $"{v4634}{v4822}"
    let v4943 : (System.Guid -> string) = _.ToString()
    let v4944 : string = v4943 v0
    let v4947 : int32 = v4361.Length
    let v4948 : int32 = v4941.Length
    let v4949 : int32 = v4947 + v4948
    let v4951 : (string -> int32) = String.length
    let v4952 : int32 = v4951 v4944
    let v4960 : int32 = v4949 |> int32 
    let v4973 : int32 = v4952 |> int32 
    let v4981 : int32 = v4973 - 1
    let v4983 : string = v4944.[int v4960..int v4981]
    let v4987 : string = $"{v4361}{v4941}{v4983}"
    (* run_target_args'
    let v4992 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4994 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v4994 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4998 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v4998 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5002 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4992 = v5002 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5006 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5006 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5010 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5010 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5014 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5014 
    #endif
#else
    let v5018 : System.Guid = v4987 |> System.Guid 
    let _run_target_args'_v4992 = v5018 
    #endif
    let v5021 : System.Guid = _run_target_args'_v4992 
    let _run_target_args'_v677 = v5021 
    #endif
    let v5030 : System.Guid = _run_target_args'_v677 
    v5030
and method77 () : string =
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
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "format!(\"{}\", $0)"
    let v49 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v48 
    let _run_target_args'_v47 = v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = "format!(\"{}\", $0)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v50 
    let _run_target_args'_v47 = v51 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v52 : string = "format!(\"{}\", $0)"
    let v53 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v52 
    let _run_target_args'_v47 = v53 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v55 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v47 = v55 
    #endif
#if FABLE_COMPILER_PYTHON
    let v59 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v47 = v59 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v47 = v63 
    #endif
#else
    let v67 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v47 = v67 
    #endif
    let v70 : std_string_String = _run_target_args'_v47 
    let v79 : string = "fable_library_rust::String_::fromString($0)"
    let v80 : string = Fable.Core.RustInterop.emitRustExpr v70 v79 
    let _run_target_args'_v4 = v80 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v81 : US3 = US3_1
    let v82 : US4 = US4_4(v81)
    let v83 : string = $"file_system.get_temp_path / target: {v82}"
    let v84 : string = failwith<string> v83
    let _run_target_args'_v4 = v84 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v86 : string = null |> unbox<string>
    let _run_target_args'_v4 = v86 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v89 : US3 = US3_0
    let v90 : US4 = US4_5(v89)
    let v91 : string = $"file_system.get_temp_path / target: {v90}"
    let v92 : string = failwith<string> v91
    let _run_target_args'_v4 = v92 
    #endif
#if FABLE_COMPILER_PYTHON
    let v93 : US3 = US3_0
    let v94 : US4 = US4_6(v93)
    let v95 : string = $"file_system.get_temp_path / target: {v94}"
    let v96 : string = failwith<string> v95
    let _run_target_args'_v4 = v96 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v97 : US3 = US3_1
    let v98 : US4 = US4_1(v97)
    let v99 : string = $"file_system.get_temp_path / target: {v98}"
    let v100 : string = failwith<string> v99
    let _run_target_args'_v4 = v100 
    #endif
#else
    let v101 : (unit -> string) = System.IO.Path.GetTempPath
    let v102 : string = v101 ()
    let _run_target_args'_v4 = v102 
    #endif
    let v103 : string = _run_target_args'_v4 
    v103
and method78 () : string =
    let v0 : string = "!create_temp_path_"
    v0
and method79 (v0 : string, v1 : string) : string =
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
    let v47 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v48 : string = "String::from($0)"
    let v49 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v48 
    let _run_target_args'_v47 = v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = "String::from($0)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v50 
    let _run_target_args'_v47 = v51 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v52 : string = "String::from($0)"
    let v53 : std_string_String = Fable.Core.RustInterop.emitRustExpr v34 v52 
    let _run_target_args'_v47 = v53 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v55 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v47 = v55 
    #endif
#if FABLE_COMPILER_PYTHON
    let v59 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v47 = v59 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v47 = v63 
    #endif
#else
    let v67 : std_string_String = v34 |> unbox<std_string_String>
    let _run_target_args'_v47 = v67 
    #endif
    let v70 : std_string_String = _run_target_args'_v47 
    (* run_target_args'
    let v83 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v84 : string = "std::path::PathBuf::from($0)"
    let v85 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v70 v84 
    let _run_target_args'_v83 = v85 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v86 : string = "std::path::PathBuf::from($0)"
    let v87 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v70 v86 
    let _run_target_args'_v83 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v88 : string = "std::path::PathBuf::from($0)"
    let v89 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v70 v88 
    let _run_target_args'_v83 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v91 : std_path_PathBuf = v70 |> unbox<std_path_PathBuf>
    let _run_target_args'_v83 = v91 
    #endif
#if FABLE_COMPILER_PYTHON
    let v95 : std_path_PathBuf = v70 |> unbox<std_path_PathBuf>
    let _run_target_args'_v83 = v95 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v99 : std_path_PathBuf = v70 |> unbox<std_path_PathBuf>
    let _run_target_args'_v83 = v99 
    #endif
#else
    let v103 : std_path_PathBuf = v70 |> unbox<std_path_PathBuf>
    let _run_target_args'_v83 = v103 
    #endif
    let v106 : std_path_PathBuf = _run_target_args'_v83 
    (* run_target_args'
    let v119 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v120 : string = "&*$0"
    let v121 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v120 
    let _run_target_args'_v119 = v121 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v122 : string = "&*$0"
    let v123 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v122 
    let _run_target_args'_v119 = v123 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v124 : string = "&*$0"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v1 v124 
    let _run_target_args'_v119 = v125 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v127 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v119 = v127 
    #endif
#if FABLE_COMPILER_PYTHON
    let v131 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v119 = v131 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v135 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v119 = v135 
    #endif
#else
    let v139 : Ref<Str> = v1 |> unbox<Ref<Str>>
    let _run_target_args'_v119 = v139 
    #endif
    let v142 : Ref<Str> = _run_target_args'_v119 
    (* run_target_args'
    let v155 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v156 : string = "String::from($0)"
    let v157 : std_string_String = Fable.Core.RustInterop.emitRustExpr v142 v156 
    let _run_target_args'_v155 = v157 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v158 : string = "String::from($0)"
    let v159 : std_string_String = Fable.Core.RustInterop.emitRustExpr v142 v158 
    let _run_target_args'_v155 = v159 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v160 : string = "String::from($0)"
    let v161 : std_string_String = Fable.Core.RustInterop.emitRustExpr v142 v160 
    let _run_target_args'_v155 = v161 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v163 : std_string_String = v142 |> unbox<std_string_String>
    let _run_target_args'_v155 = v163 
    #endif
#if FABLE_COMPILER_PYTHON
    let v167 : std_string_String = v142 |> unbox<std_string_String>
    let _run_target_args'_v155 = v167 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v171 : std_string_String = v142 |> unbox<std_string_String>
    let _run_target_args'_v155 = v171 
    #endif
#else
    let v175 : std_string_String = v142 |> unbox<std_string_String>
    let _run_target_args'_v155 = v175 
    #endif
    let v178 : std_string_String = _run_target_args'_v155 
    let v187 : string = "$0.join($1)"
    let v188 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr struct (v106, v178) v187 
    (* run_target_args'
    let v193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v194 : string = "$0.display()"
    let v195 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v188 v194 
    let _run_target_args'_v193 = v195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v196 : string = "$0.display()"
    let v197 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v188 v196 
    let _run_target_args'_v193 = v197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v198 : string = "$0.display()"
    let v199 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v188 v198 
    let _run_target_args'_v193 = v199 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v201 : std_path_Display = v188 |> unbox<std_path_Display>
    let _run_target_args'_v193 = v201 
    #endif
#if FABLE_COMPILER_PYTHON
    let v205 : std_path_Display = v188 |> unbox<std_path_Display>
    let _run_target_args'_v193 = v205 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v209 : std_path_Display = v188 |> unbox<std_path_Display>
    let _run_target_args'_v193 = v209 
    #endif
#else
    let v213 : std_path_Display = v188 |> unbox<std_path_Display>
    let _run_target_args'_v193 = v213 
    #endif
    let v216 : std_path_Display = _run_target_args'_v193 
    (* run_target_args'
    let v229 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v230 : string = "format!(\"{}\", $0)"
    let v231 : std_string_String = Fable.Core.RustInterop.emitRustExpr v216 v230 
    let _run_target_args'_v229 = v231 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v232 : string = "format!(\"{}\", $0)"
    let v233 : std_string_String = Fable.Core.RustInterop.emitRustExpr v216 v232 
    let _run_target_args'_v229 = v233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v234 : string = "format!(\"{}\", $0)"
    let v235 : std_string_String = Fable.Core.RustInterop.emitRustExpr v216 v234 
    let _run_target_args'_v229 = v235 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v237 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v229 = v237 
    #endif
#if FABLE_COMPILER_PYTHON
    let v241 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v229 = v241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v245 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v229 = v245 
    #endif
#else
    let v249 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v229 = v249 
    #endif
    let v252 : std_string_String = _run_target_args'_v229 
    let v261 : string = "fable_library_rust::String_::fromString($0)"
    let v262 : string = Fable.Core.RustInterop.emitRustExpr v252 v261 
    let _run_target_args'_v6 = v262 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v263 : US3 = US3_1
    let v264 : US4 = US4_4(v263)
    let v265 : string = $"file_system.(</>) / target: {v264} / a: {v0} / b: {v1}"
    let v266 : string = failwith<string> v265
    let _run_target_args'_v6 = v266 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v268 : string = null |> unbox<string>
    let _run_target_args'_v6 = v268 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v271 : string = "path"
    let v272 : IPathJoin = Fable.Core.JsInterop.importAll v271 
    let v273 : string = "v272.join($0, $1)"
    let v274 : string = Fable.Core.JsInterop.emitJsExpr struct (v0, v1) v273 
    let _run_target_args'_v6 = v274 
    #endif
#if FABLE_COMPILER_PYTHON
    let v275 : US3 = US3_0
    let v276 : US4 = US4_6(v275)
    let v277 : string = $"file_system.(</>) / target: {v276} / a: {v0} / b: {v1}"
    let v278 : string = failwith<string> v277
    let _run_target_args'_v6 = v278 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v279 : US3 = US3_1
    let v280 : US4 = US4_1(v279)
    let v281 : string = $"file_system.(</>) / target: {v280} / a: {v0} / b: {v1}"
    let v282 : string = failwith<string> v281
    let _run_target_args'_v6 = v282 
    #endif
#else
    let v283 : string = System.IO.Path.Combine (v0, v1)
    let _run_target_args'_v6 = v283 
    #endif
    let v284 : string = _run_target_args'_v6 
    v284
and method81 () : string =
    let v0 : string = "CARGO_PKG_NAME"
    v0
and method80 () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = method81()
    let v6 : string = method2(v5)
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : string = method81()
    let v8 : string = method2(v7)
    let _run_target_args'_v4 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : string = method81()
    let v10 : string = method2(v9)
    let _run_target_args'_v4 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : US3 = US3_0
    let v12 : US4 = US4_5(v11)
    let v13 : string = $"env.get_entry_assembly_name / target: {v12}"
    let v14 : string = failwith<string> v13
    let _run_target_args'_v4 = v14 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : US3 = US3_0
    let v16 : US4 = US4_6(v15)
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
and method76 (v0 : System.Guid) : string =
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = method77()
    let v14 : string = method78()
    let v15 : string = method79(v13, v14)
    let v16 : string = method80()
    let v17 : string = method79(v15, v16)
    let v19 : (System.Guid -> string) = _.ToString()
    let v20 : string = v19 v0
    let v23 : string = method79(v17, v20)
    let _run_target_args'_v12 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v24 : string = method77()
    let v25 : string = method78()
    let v26 : string = method79(v24, v25)
    let v27 : string = method80()
    let v28 : string = method79(v26, v27)
    let v30 : (System.Guid -> string) = _.ToString()
    let v31 : string = v30 v0
    let v34 : string = method79(v28, v31)
    let _run_target_args'_v12 = v34 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = null |> unbox<string>
    let _run_target_args'_v12 = v36 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v39 : string = method77()
    let v40 : string = method78()
    let v41 : string = method79(v39, v40)
    let v42 : string = method80()
    let v43 : string = method79(v41, v42)
    let v45 : (System.Guid -> string) = _.ToString()
    let v46 : string = v45 v0
    let v49 : string = method79(v43, v46)
    let _run_target_args'_v12 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v50 : string = method77()
    let v51 : string = method78()
    let v52 : string = method79(v50, v51)
    let v53 : string = method80()
    let v54 : string = method79(v52, v53)
    let v56 : (System.Guid -> string) = _.ToString()
    let v57 : string = v56 v0
    let v60 : string = method79(v54, v57)
    let _run_target_args'_v12 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v61 : string = method77()
    let v62 : string = method78()
    let v63 : string = method79(v61, v62)
    let v64 : string = method80()
    let v65 : string = method79(v63, v64)
    let v67 : (System.Guid -> string) = _.ToString()
    let v68 : string = v67 v0
    let v71 : string = method79(v65, v68)
    let _run_target_args'_v12 = v71 
    #endif
#else
    let v72 : string = method77()
    let v73 : string = method78()
    let v74 : string = method79(v72, v73)
    let v75 : string = method80()
    let v76 : string = method79(v74, v75)
    let v78 : (System.Guid -> string) = _.ToString()
    let v79 : string = v78 v0
    let v82 : string = method79(v76, v79)
    let _run_target_args'_v12 = v82 
    #endif
    let v83 : string = _run_target_args'_v12 
    v83
and method70 () : string =
    (* run_target_args'
    let v29 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v36 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v37 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v36 = v37 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v38 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v36 = v38 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v40 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v36 = v40 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v43 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v36 = v43 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v36 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v36 = v45 
    #endif
#else
    let v46 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v36 = v46 
    #endif
    let v47 : System.DateTime = _run_target_args'_v36 
    let v53 : (unit -> System.Guid) = System.Guid.NewGuid
    let v54 : System.Guid = v53 ()
    let v57 : System.Guid = method71(v54, v47)
    let v58 : string = method76(v57)
    let _run_target_args'_v29 = v58 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v65 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v66 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v65 = v66 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v67 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v65 = v67 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v69 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v65 = v69 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v72 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v65 = v72 
    #endif
#if FABLE_COMPILER_PYTHON
    let v73 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v65 = v73 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v74 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v65 = v74 
    #endif
#else
    let v75 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v65 = v75 
    #endif
    let v76 : System.DateTime = _run_target_args'_v65 
    let v82 : (unit -> System.Guid) = System.Guid.NewGuid
    let v83 : System.Guid = v82 ()
    let v86 : System.Guid = method71(v83, v76)
    let v87 : string = method76(v86)
    let _run_target_args'_v29 = v87 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v89 : string = null |> unbox<string>
    let _run_target_args'_v29 = v89 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v98 = v99 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v100 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v102 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v105 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v98 = v105 
    #endif
#if FABLE_COMPILER_PYTHON
    let v106 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v98 = v106 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v107 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v98 = v107 
    #endif
#else
    let v108 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v98 = v108 
    #endif
    let v109 : System.DateTime = _run_target_args'_v98 
    let v115 : (unit -> System.Guid) = System.Guid.NewGuid
    let v116 : System.Guid = v115 ()
    let v119 : System.Guid = method71(v116, v109)
    let v120 : string = method76(v119)
    let _run_target_args'_v29 = v120 
    #endif
#if FABLE_COMPILER_PYTHON
    (* run_target_args'
    let v127 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v128 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v127 = v128 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v129 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v127 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v131 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v127 = v131 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v134 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v127 = v134 
    #endif
#if FABLE_COMPILER_PYTHON
    let v135 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v127 = v135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v136 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v127 = v136 
    #endif
#else
    let v137 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v127 = v137 
    #endif
    let v138 : System.DateTime = _run_target_args'_v127 
    let v144 : (unit -> System.Guid) = System.Guid.NewGuid
    let v145 : System.Guid = v144 ()
    let v148 : System.Guid = method71(v145, v138)
    let v149 : string = method76(v148)
    let _run_target_args'_v29 = v149 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    (* run_target_args'
    let v156 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v157 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v156 = v157 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v158 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v156 = v158 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v160 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v156 = v160 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v163 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v156 = v163 
    #endif
#if FABLE_COMPILER_PYTHON
    let v164 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v156 = v164 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v165 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v156 = v165 
    #endif
#else
    let v166 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v156 = v166 
    #endif
    let v167 : System.DateTime = _run_target_args'_v156 
    let v173 : (unit -> System.Guid) = System.Guid.NewGuid
    let v174 : System.Guid = v173 ()
    let v177 : System.Guid = method71(v174, v167)
    let v178 : string = method76(v177)
    let _run_target_args'_v29 = v178 
    #endif
#else
    (* run_target_args'
    let v185 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v186 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v185 = v186 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v187 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v185 = v187 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v189 : System.DateTime = null |> unbox<System.DateTime>
    let _run_target_args'_v185 = v189 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v192 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v185 = v192 
    #endif
#if FABLE_COMPILER_PYTHON
    let v193 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v185 = v193 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v194 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v185 = v194 
    #endif
#else
    let v195 : System.DateTime = System.DateTime.Now
    let _run_target_args'_v185 = v195 
    #endif
    let v196 : System.DateTime = _run_target_args'_v185 
    let v202 : (unit -> System.Guid) = System.Guid.NewGuid
    let v203 : System.Guid = v202 ()
    let v206 : System.Guid = method71(v203, v196)
    let v207 : string = method76(v206)
    let _run_target_args'_v29 = v207 
    #endif
    let v208 : string = _run_target_args'_v29 
    v208
and closure37 () () : string =
    method70()
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
and method83 () : (std_io_Error -> std_string_String) =
    closure40()
and closure41 () () : US13 =
    US13_0
and method84 () : (unit -> US13) =
    closure41()
and closure42 () (v0 : std_string_String) : US13 =
    US13_1(v0)
and method85 () : (std_string_String -> US13) =
    closure42()
and method86 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : std_string_String) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "dir"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v70 : string = $"{v8}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure6(v11, v70)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v88 : string = "; "
    let v89 : string = $"{v88}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure6(v11, v89)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v107 : string = "error"
    let v108 : string = $"{v107}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure6(v11, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v125 : string = $"{v52}"
    let v133 : unit = ()
    let v134 : (unit -> unit) = closure6(v11, v125)
    let v135 : unit = (fun () -> v134 (); v133) ()
    (* run_target_args'
    let v145 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v146 : string = "format!(\"{:#?}\", $0)"
    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v146 
    let v148 : string = "fable_library_rust::String_::fromString($0)"
    let v149 : string = Fable.Core.RustInterop.emitRustExpr v147 v148 
    let _run_target_args'_v145 = v149 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v150 : string = "format!(\"{:#?}\", $0)"
    let v151 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v150 
    let v152 : string = "fable_library_rust::String_::fromString($0)"
    let v153 : string = Fable.Core.RustInterop.emitRustExpr v151 v152 
    let _run_target_args'_v145 = v153 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v154 : string = "format!(\"{:#?}\", $0)"
    let v155 : std_string_String = Fable.Core.RustInterop.emitRustExpr v9 v154 
    let v156 : string = "fable_library_rust::String_::fromString($0)"
    let v157 : string = Fable.Core.RustInterop.emitRustExpr v155 v156 
    let _run_target_args'_v145 = v157 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v159 : string = $"%A{v9}"
    let _run_target_args'_v145 = v159 
    #endif
#if FABLE_COMPILER_PYTHON
    let v163 : string = $"%A{v9}"
    let _run_target_args'_v145 = v163 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v167 : string = $"%A{v9}"
    let _run_target_args'_v145 = v167 
    #endif
#else
    let v171 : string = $"%A{v9}"
    let _run_target_args'_v145 = v171 
    #endif
    let v174 : string = _run_target_args'_v145 
    let v184 : string = $"{v174}"
    let v192 : unit = ()
    let v193 : (unit -> unit) = closure6(v11, v184)
    let v194 : unit = (fun () -> v193 (); v192) ()
    let v202 : string = " }"
    let v203 : string = $"{v202}"
    let v211 : unit = ()
    let v212 : (unit -> unit) = closure6(v11, v203)
    let v213 : unit = (fun () -> v212 (); v211) ()
    let v219 : string = v11.l0
    let v220 : int64 = v0.l0
    let v223 : string = " "
    let v224 : string = v6 + v223 
    let v228 : string = v224 + v7 
    let v233 : string = " #"
    let v234 : string = v228 + v233 
    let v238 : (int64 -> string) = _.ToString()
    let v239 : string = v238 v220
    let v243 : string = v234 + v239 
    let v247 : string = v243 + v223 
    let v252 : string = "file_system.create_dir"
    let v253 : string = v247 + v252 
    let v258 : string = " / "
    let v259 : string = v253 + v258 
    let v263 : string = v259 + v219 
    method21(v263)
and closure43 (v0 : string, v1 : std_string_String) () : unit =
    let v2 : US0 = US0_4
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method47()
        let v61 : string = method86(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method22(v61)
and method87 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method17()
    let v10 : Mut3 = {l0 = v9} : Mut3
    let v13 : string = "{ "
    let v14 : string = $"{v13}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure6(v10, v14)
    let v24 : unit = (fun () -> v23 (); v22) ()
    let v32 : string = "dir"
    let v33 : string = $"{v32}"
    let v41 : unit = ()
    let v42 : (unit -> unit) = closure6(v10, v33)
    let v43 : unit = (fun () -> v42 (); v41) ()
    let v51 : string = " = "
    let v52 : string = $"{v51}"
    let v60 : unit = ()
    let v61 : (unit -> unit) = closure6(v10, v52)
    let v62 : unit = (fun () -> v61 (); v60) ()
    let v69 : string = $"{v8}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure6(v10, v69)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v87 : string = " }"
    let v88 : string = $"{v87}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure6(v10, v88)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v104 : string = v10.l0
    let v105 : int64 = v0.l0
    let v108 : string = " "
    let v109 : string = v6 + v108 
    let v113 : string = v109 + v7 
    let v118 : string = " #"
    let v119 : string = v113 + v118 
    let v123 : (int64 -> string) = _.ToString()
    let v124 : string = v123 v105
    let v128 : string = v119 + v124 
    let v132 : string = v128 + v108 
    let v137 : string = "file_system.create_dir"
    let v138 : string = v132 + v137 
    let v143 : string = " / "
    let v144 : string = v138 + v143 
    let v148 : string = v144 + v104 
    method21(v148)
and closure44 (v0 : string) () : unit =
    let v1 : US0 = US0_0
    let v2 : bool = method11(v1)
    if v2 then
        let v17 : unit = ()
        let v18 : (unit -> unit) = closure0()
        let v19 : unit = (fun () -> v18 (); v17) ()
        let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
        let v58 : string = method12(v40, v41, v42, v43, v44, v45)
        let v59 : string = method31()
        let v60 : string = method87(v40, v41, v42, v43, v44, v45, v58, v59, v0)
        method22(v60)
and closure45 (v0 : string) () : unit =
    let v1 : bool = true
    method9(v1, v0)
and method88 (v0 : string) : (unit -> unit) =
    closure45(v0)
and method89 (v0 : string) : (unit -> unit) =
    closure45(v0)
and method90 (v0 : string) : System_IO_DirectoryInfo =
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
and method91 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "dir"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v70 : string = $"{v8}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure6(v11, v70)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v88 : string = "; "
    let v89 : string = $"{v88}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure6(v11, v89)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v107 : string = "result"
    let v108 : string = $"{v107}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure6(v11, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v125 : string = $"{v52}"
    let v133 : unit = ()
    let v134 : (unit -> unit) = closure6(v11, v125)
    let v135 : unit = (fun () -> v134 (); v133) ()
    let v142 : string = $"{v9}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure6(v11, v142)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v160 : string = " }"
    let v161 : string = $"{v160}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure6(v11, v161)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v177 : string = v11.l0
    let v178 : int64 = v0.l0
    let v181 : string = " "
    let v182 : string = v6 + v181 
    let v186 : string = v182 + v7 
    let v191 : string = " #"
    let v192 : string = v186 + v191 
    let v196 : (int64 -> string) = _.ToString()
    let v197 : string = v196 v178
    let v201 : string = v192 + v197 
    let v205 : string = v201 + v181 
    let v210 : string = "file_system.create_dir"
    let v211 : string = v205 + v210 
    let v216 : string = " / "
    let v217 : string = v211 + v216 
    let v221 : string = v217 + v177 
    method21(v221)
and closure46 (v0 : string, v1 : string) () : unit =
    let v2 : US0 = US0_1
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method16()
        let v61 : string = method91(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method22(v61)
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
    let v36 : unit = ()
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
    let v37 : (Async<unit> -> unit) = Async.RunSynchronously
    v37 v27
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v38 : (Async<unit> -> unit) = Async.RunSynchronously
    v38 v27
    #endif
#else
    let v39 : (Async<unit> -> unit) = Async.RunSynchronously
    v39 v27
    #endif
    // run_target_args' is_unit
    ()
and method92 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method93 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method82 (v0 : string) : System.IDisposable =
    (* run_target_args'
    let v237 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v238 : string = "std::fs::create_dir_all(&*$0)"
    let v239 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v238 
    let v240 : (std_io_Error -> std_string_String) = method83()
    (* run_target_args'
    let v242 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v243 : string = "$0.map_err(|x| $1(x))"
    let v244 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v239, v240) v243 
    let _run_target_args'_v242 = v244 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v245 : string = "$0.map_err(|x| $1(x))"
    let v246 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v239, v240) v245 
    let _run_target_args'_v242 = v246 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v247 : string = "$0.map_err(|x| $1(x))"
    let v248 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v239, v240) v247 
    let _run_target_args'_v242 = v248 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v249 : Result<unit, std_string_String> = match v239 with Ok x -> Ok x | Error x -> Error (v240 x)
    let _run_target_args'_v242 = v249 
    #endif
#if FABLE_COMPILER_PYTHON
    let v250 : Result<unit, std_string_String> = match v239 with Ok x -> Ok x | Error x -> Error (v240 x)
    let _run_target_args'_v242 = v250 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v251 : Result<unit, std_string_String> = match v239 with Ok x -> Ok x | Error x -> Error (v240 x)
    let _run_target_args'_v242 = v251 
    #endif
#else
    let v252 : Result<unit, std_string_String> = match v239 with Ok x -> Ok x | Error x -> Error (v240 x)
    let _run_target_args'_v242 = v252 
    #endif
    let v253 : Result<unit, std_string_String> = _run_target_args'_v242 
    let v256 : (unit -> US13) = method84()
    let v257 : (std_string_String -> US13) = method85()
    let v259 : US13 = match v253 with Ok () -> v256 () | Error x -> v257 x
    match v259 with
    | US13_1(v385) -> (* Error *)
        let v446 : unit = ()
        let v447 : (unit -> unit) = closure43(v0, v385)
        let v448 : unit = (fun () -> v447 (); v446) ()
        ()
    | US13_0 -> (* Ok *)
        let v322 : unit = ()
        let v323 : (unit -> unit) = closure44(v0)
        let v324 : unit = (fun () -> v323 (); v322) ()
        ()
    (* run_target_args'
    let v513 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v514 : (unit -> unit) = method88(v0)
    let v515 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v514 "$0()" )
    let _run_target_args'_v513 = v515 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v516 : (unit -> unit) = method88(v0)
    let v517 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v516 "$0()" )
    let _run_target_args'_v513 = v517 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v518 : (unit -> unit) = method88(v0)
    let v519 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v518 "$0()" )
    let _run_target_args'_v513 = v519 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v520 : (unit -> unit) = method89(v0)
    let v521 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v520 () }
    let _run_target_args'_v513 = v521 
    #endif
#if FABLE_COMPILER_PYTHON
    let v522 : (unit -> unit) = method89(v0)
    let v523 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v522 () }
    let _run_target_args'_v513 = v523 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v524 : (unit -> unit) = method89(v0)
    let v525 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v524 () }
    let _run_target_args'_v513 = v525 
    #endif
#else
    let v526 : (unit -> unit) = method89(v0)
    let v527 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v526 () }
    let _run_target_args'_v513 = v527 
    #endif
    let v528 : System.IDisposable = _run_target_args'_v513 
    let _run_target_args'_v237 = v528 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v536 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v237 = v536 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v540 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v237 = v540 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v543 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v548 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v550 : bool = null |> unbox<bool>
    let _run_target_args'_v548 = v550 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v554 : bool = null |> unbox<bool>
    let _run_target_args'_v548 = v554 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v558 : bool = null |> unbox<bool>
    let _run_target_args'_v548 = v558 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v562 : bool = null |> unbox<bool>
    let _run_target_args'_v548 = v562 
    #endif
#if FABLE_COMPILER_PYTHON
    let v566 : bool = null |> unbox<bool>
    let _run_target_args'_v548 = v566 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v570 : bool = null |> unbox<bool>
    let _run_target_args'_v548 = v570 
    #endif
#else
    let v573 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v574 : bool = v573 v543
    let _run_target_args'_v548 = v574 
    #endif
    let v575 : bool = _run_target_args'_v548 
    let v584 : bool = v575 = false
    if v584 then
        (* run_target_args'
        let v589 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v591 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v589 = v591 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v595 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v589 = v595 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v599 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v589 = v599 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v603 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v589 = v603 
        #endif
#if FABLE_COMPILER_PYTHON
        let v607 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v589 = v607 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v611 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v589 = v611 
        #endif
#else
        let v614 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v615 : System.DateTime = v614 v543
        let _run_target_args'_v589 = v615 
        #endif
        let v616 : System.DateTime = _run_target_args'_v589 
        let v625 : _ = {| Exists = v575; CreationTime = v616 |}
        let v627 : string = $"%A{v625}"
        let v690 : unit = ()
        let v691 : (unit -> unit) = closure46(v0, v627)
        let v692 : unit = (fun () -> v691 (); v690) ()
        ()
    (* run_target_args'
    let v757 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v758 : (unit -> unit) = method92(v0)
    let v759 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v758 "$0()" )
    let _run_target_args'_v757 = v759 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v760 : (unit -> unit) = method92(v0)
    let v761 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v760 "$0()" )
    let _run_target_args'_v757 = v761 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v762 : (unit -> unit) = method92(v0)
    let v763 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v762 "$0()" )
    let _run_target_args'_v757 = v763 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v764 : (unit -> unit) = method93(v0)
    let v765 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v764 () }
    let _run_target_args'_v757 = v765 
    #endif
#if FABLE_COMPILER_PYTHON
    let v766 : (unit -> unit) = method93(v0)
    let v767 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v766 () }
    let _run_target_args'_v757 = v767 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v768 : (unit -> unit) = method93(v0)
    let v769 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v768 () }
    let _run_target_args'_v757 = v769 
    #endif
#else
    let v770 : (unit -> unit) = method93(v0)
    let v771 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v770 () }
    let _run_target_args'_v757 = v771 
    #endif
    let v772 : System.IDisposable = _run_target_args'_v757 
    let _run_target_args'_v237 = v772 
    #endif
#if FABLE_COMPILER_PYTHON
    let v779 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v784 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v786 : bool = null |> unbox<bool>
    let _run_target_args'_v784 = v786 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v790 : bool = null |> unbox<bool>
    let _run_target_args'_v784 = v790 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v794 : bool = null |> unbox<bool>
    let _run_target_args'_v784 = v794 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v798 : bool = null |> unbox<bool>
    let _run_target_args'_v784 = v798 
    #endif
#if FABLE_COMPILER_PYTHON
    let v802 : bool = null |> unbox<bool>
    let _run_target_args'_v784 = v802 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v806 : bool = null |> unbox<bool>
    let _run_target_args'_v784 = v806 
    #endif
#else
    let v809 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v810 : bool = v809 v779
    let _run_target_args'_v784 = v810 
    #endif
    let v811 : bool = _run_target_args'_v784 
    let v820 : bool = v811 = false
    if v820 then
        (* run_target_args'
        let v825 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v827 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v825 = v827 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v831 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v825 = v831 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v835 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v825 = v835 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v839 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v825 = v839 
        #endif
#if FABLE_COMPILER_PYTHON
        let v843 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v825 = v843 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v847 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v825 = v847 
        #endif
#else
        let v850 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v851 : System.DateTime = v850 v779
        let _run_target_args'_v825 = v851 
        #endif
        let v852 : System.DateTime = _run_target_args'_v825 
        let v861 : _ = {| Exists = v811; CreationTime = v852 |}
        let v863 : string = $"%A{v861}"
        let v926 : unit = ()
        let v927 : (unit -> unit) = closure46(v0, v863)
        let v928 : unit = (fun () -> v927 (); v926) ()
        ()
    (* run_target_args'
    let v993 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v994 : (unit -> unit) = method92(v0)
    let v995 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v994 "$0()" )
    let _run_target_args'_v993 = v995 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v996 : (unit -> unit) = method92(v0)
    let v997 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v996 "$0()" )
    let _run_target_args'_v993 = v997 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v998 : (unit -> unit) = method92(v0)
    let v999 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v998 "$0()" )
    let _run_target_args'_v993 = v999 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1000 : (unit -> unit) = method93(v0)
    let v1001 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1000 () }
    let _run_target_args'_v993 = v1001 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1002 : (unit -> unit) = method93(v0)
    let v1003 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1002 () }
    let _run_target_args'_v993 = v1003 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1004 : (unit -> unit) = method93(v0)
    let v1005 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1004 () }
    let _run_target_args'_v993 = v1005 
    #endif
#else
    let v1006 : (unit -> unit) = method93(v0)
    let v1007 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1006 () }
    let _run_target_args'_v993 = v1007 
    #endif
    let v1008 : System.IDisposable = _run_target_args'_v993 
    let _run_target_args'_v237 = v1008 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1015 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v1020 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1022 : bool = null |> unbox<bool>
    let _run_target_args'_v1020 = v1022 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1026 : bool = null |> unbox<bool>
    let _run_target_args'_v1020 = v1026 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1030 : bool = null |> unbox<bool>
    let _run_target_args'_v1020 = v1030 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1034 : bool = null |> unbox<bool>
    let _run_target_args'_v1020 = v1034 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1038 : bool = null |> unbox<bool>
    let _run_target_args'_v1020 = v1038 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1042 : bool = null |> unbox<bool>
    let _run_target_args'_v1020 = v1042 
    #endif
#else
    let v1045 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v1046 : bool = v1045 v1015
    let _run_target_args'_v1020 = v1046 
    #endif
    let v1047 : bool = _run_target_args'_v1020 
    let v1056 : bool = v1047 = false
    if v1056 then
        (* run_target_args'
        let v1061 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v1063 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1061 = v1063 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v1067 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1061 = v1067 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v1071 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1061 = v1071 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v1075 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1061 = v1075 
        #endif
#if FABLE_COMPILER_PYTHON
        let v1079 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1061 = v1079 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v1083 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1061 = v1083 
        #endif
#else
        let v1086 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v1087 : System.DateTime = v1086 v1015
        let _run_target_args'_v1061 = v1087 
        #endif
        let v1088 : System.DateTime = _run_target_args'_v1061 
        let v1097 : _ = {| Exists = v1047; CreationTime = v1088 |}
        let v1099 : string = $"%A{v1097}"
        let v1162 : unit = ()
        let v1163 : (unit -> unit) = closure46(v0, v1099)
        let v1164 : unit = (fun () -> v1163 (); v1162) ()
        ()
    (* run_target_args'
    let v1229 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1230 : (unit -> unit) = method92(v0)
    let v1231 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1230 "$0()" )
    let _run_target_args'_v1229 = v1231 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1232 : (unit -> unit) = method92(v0)
    let v1233 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1232 "$0()" )
    let _run_target_args'_v1229 = v1233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1234 : (unit -> unit) = method92(v0)
    let v1235 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1234 "$0()" )
    let _run_target_args'_v1229 = v1235 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1236 : (unit -> unit) = method93(v0)
    let v1237 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1236 () }
    let _run_target_args'_v1229 = v1237 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1238 : (unit -> unit) = method93(v0)
    let v1239 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1238 () }
    let _run_target_args'_v1229 = v1239 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1240 : (unit -> unit) = method93(v0)
    let v1241 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1240 () }
    let _run_target_args'_v1229 = v1241 
    #endif
#else
    let v1242 : (unit -> unit) = method93(v0)
    let v1243 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1242 () }
    let _run_target_args'_v1229 = v1243 
    #endif
    let v1244 : System.IDisposable = _run_target_args'_v1229 
    let _run_target_args'_v237 = v1244 
    #endif
#else
    let v1251 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v1256 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1258 : bool = null |> unbox<bool>
    let _run_target_args'_v1256 = v1258 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1262 : bool = null |> unbox<bool>
    let _run_target_args'_v1256 = v1262 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1266 : bool = null |> unbox<bool>
    let _run_target_args'_v1256 = v1266 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1270 : bool = null |> unbox<bool>
    let _run_target_args'_v1256 = v1270 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1274 : bool = null |> unbox<bool>
    let _run_target_args'_v1256 = v1274 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1278 : bool = null |> unbox<bool>
    let _run_target_args'_v1256 = v1278 
    #endif
#else
    let v1281 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v1282 : bool = v1281 v1251
    let _run_target_args'_v1256 = v1282 
    #endif
    let v1283 : bool = _run_target_args'_v1256 
    let v1292 : bool = v1283 = false
    if v1292 then
        (* run_target_args'
        let v1297 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v1299 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1297 = v1299 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v1303 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1297 = v1303 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v1307 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1297 = v1307 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v1311 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1297 = v1311 
        #endif
#if FABLE_COMPILER_PYTHON
        let v1315 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1297 = v1315 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v1319 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1297 = v1319 
        #endif
#else
        let v1322 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v1323 : System.DateTime = v1322 v1251
        let _run_target_args'_v1297 = v1323 
        #endif
        let v1324 : System.DateTime = _run_target_args'_v1297 
        let v1333 : _ = {| Exists = v1283; CreationTime = v1324 |}
        let v1335 : string = $"%A{v1333}"
        let v1398 : unit = ()
        let v1399 : (unit -> unit) = closure46(v0, v1335)
        let v1400 : unit = (fun () -> v1399 (); v1398) ()
        ()
    (* run_target_args'
    let v1465 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1466 : (unit -> unit) = method92(v0)
    let v1467 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1466 "$0()" )
    let _run_target_args'_v1465 = v1467 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1468 : (unit -> unit) = method92(v0)
    let v1469 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1468 "$0()" )
    let _run_target_args'_v1465 = v1469 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1470 : (unit -> unit) = method92(v0)
    let v1471 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1470 "$0()" )
    let _run_target_args'_v1465 = v1471 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1472 : (unit -> unit) = method93(v0)
    let v1473 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1472 () }
    let _run_target_args'_v1465 = v1473 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1474 : (unit -> unit) = method93(v0)
    let v1475 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1474 () }
    let _run_target_args'_v1465 = v1475 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1476 : (unit -> unit) = method93(v0)
    let v1477 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1476 () }
    let _run_target_args'_v1465 = v1477 
    #endif
#else
    let v1478 : (unit -> unit) = method93(v0)
    let v1479 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1478 () }
    let _run_target_args'_v1465 = v1479 
    #endif
    let v1480 : System.IDisposable = _run_target_args'_v1465 
    let _run_target_args'_v237 = v1480 
    #endif
    let v1487 : System.IDisposable = _run_target_args'_v237 
    v1487
and closure39 () () : struct (string * System.IDisposable) =
    let v0 : string = method70()
    let v1 : System.IDisposable = method82(v0)
    struct (v0, v1)
and closure49 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method95(v0, v1, v5)
        let v8 : string = v3 + v1 
        v6 v8
and method95 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure49(v0, v1, v2)
and method94 (v0 : string) : System.Guid =
    let v2 : (char -> string) = _.ToString()
    let v3 : string = v2 '0'
    let v6 : int32 = v0.Length
    let v7 : int32 = 32 - v6
    let v8 : int32 = 0
    let v9 : (string -> string) = method95(v7, v3, v8)
    let v10 : string = ""
    let v11 : string = v9 v10
    let v13 : string = v11 + v0 
    let v16 : string = "-"
    (* run_target_args'
    let v246 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v252 : int32 = 0 |> int32 
    let v265 : int32 = 8 |> int32 
    let v273 : int32 = v265 - 1
    let v275 : string = v13.[int v252..int v273]
    let v284 : int32 = 8 |> int32 
    let v297 : int32 = 12 |> int32 
    let v305 : int32 = v297 - 1
    let v307 : string = v13.[int v284..int v305]
    let v316 : int32 = 12 |> int32 
    let v329 : int32 = 16 |> int32 
    let v337 : int32 = v329 - 1
    let v339 : string = v13.[int v316..int v337]
    let v348 : int32 = 16 |> int32 
    let v361 : int32 = 20 |> int32 
    let v369 : int32 = v361 - 1
    let v371 : string = v13.[int v348..int v369]
    let v380 : int32 = 20 |> int32 
    let v393 : int32 = 32 |> int32 
    let v401 : int32 = v393 - 1
    let v403 : string = v13.[int v380..int v401]
    let v408 : string = v275 + v16 
    let v412 : string = v408 + v307 
    let v416 : string = v412 + v16 
    let v420 : string = v416 + v339 
    let v424 : string = v420 + v16 
    let v428 : string = v424 + v371 
    let v432 : string = v428 + v16 
    let v436 : string = v432 + v403 
    (* run_target_args'
    let v443 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v445 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v445 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v449 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v449 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v453 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v443 = v453 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v457 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v457 
    #endif
#if FABLE_COMPILER_PYTHON
    let v461 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v461 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v465 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v465 
    #endif
#else
    let v469 : System.Guid = v436 |> System.Guid 
    let _run_target_args'_v443 = v469 
    #endif
    let v472 : System.Guid = _run_target_args'_v443 
    let _run_target_args'_v246 = v472 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v486 : int32 = 0 |> int32 
    let v499 : int32 = 8 |> int32 
    let v507 : int32 = v499 - 1
    let v509 : string = v13.[int v486..int v507]
    let v518 : int32 = 8 |> int32 
    let v531 : int32 = 12 |> int32 
    let v539 : int32 = v531 - 1
    let v541 : string = v13.[int v518..int v539]
    let v550 : int32 = 12 |> int32 
    let v563 : int32 = 16 |> int32 
    let v571 : int32 = v563 - 1
    let v573 : string = v13.[int v550..int v571]
    let v582 : int32 = 16 |> int32 
    let v595 : int32 = 20 |> int32 
    let v603 : int32 = v595 - 1
    let v605 : string = v13.[int v582..int v603]
    let v614 : int32 = 20 |> int32 
    let v627 : int32 = 32 |> int32 
    let v635 : int32 = v627 - 1
    let v637 : string = v13.[int v614..int v635]
    let v642 : string = v509 + v16 
    let v646 : string = v642 + v541 
    let v650 : string = v646 + v16 
    let v654 : string = v650 + v573 
    let v658 : string = v654 + v16 
    let v662 : string = v658 + v605 
    let v666 : string = v662 + v16 
    let v670 : string = v666 + v637 
    (* run_target_args'
    let v677 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v679 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v679 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v683 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v683 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v687 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v677 = v687 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v691 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v691 
    #endif
#if FABLE_COMPILER_PYTHON
    let v695 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v695 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v699 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v699 
    #endif
#else
    let v703 : System.Guid = v670 |> System.Guid 
    let _run_target_args'_v677 = v703 
    #endif
    let v706 : System.Guid = _run_target_args'_v677 
    let _run_target_args'_v246 = v706 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v716 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v246 = v716 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v724 : int32 = 0 |> int32 
    let v737 : int32 = 8 |> int32 
    let v745 : int32 = v737 - 1
    let v747 : string = v13.[int v724..int v745]
    let v756 : int32 = 8 |> int32 
    let v769 : int32 = 12 |> int32 
    let v777 : int32 = v769 - 1
    let v779 : string = v13.[int v756..int v777]
    let v788 : int32 = 12 |> int32 
    let v801 : int32 = 16 |> int32 
    let v809 : int32 = v801 - 1
    let v811 : string = v13.[int v788..int v809]
    let v820 : int32 = 16 |> int32 
    let v833 : int32 = 20 |> int32 
    let v841 : int32 = v833 - 1
    let v843 : string = v13.[int v820..int v841]
    let v852 : int32 = 20 |> int32 
    let v865 : int32 = 32 |> int32 
    let v873 : int32 = v865 - 1
    let v875 : string = v13.[int v852..int v873]
    let v880 : string = v747 + v16 
    let v884 : string = v880 + v779 
    let v888 : string = v884 + v16 
    let v892 : string = v888 + v811 
    let v896 : string = v892 + v16 
    let v900 : string = v896 + v843 
    let v904 : string = v900 + v16 
    let v908 : string = v904 + v875 
    (* run_target_args'
    let v915 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v917 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v917 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v921 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v921 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v925 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v915 = v925 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v929 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v929 
    #endif
#if FABLE_COMPILER_PYTHON
    let v933 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v933 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v937 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v937 
    #endif
#else
    let v941 : System.Guid = v908 |> System.Guid 
    let _run_target_args'_v915 = v941 
    #endif
    let v944 : System.Guid = _run_target_args'_v915 
    let _run_target_args'_v246 = v944 
    #endif
#if FABLE_COMPILER_PYTHON
    let v958 : int32 = 0 |> int32 
    let v971 : int32 = 8 |> int32 
    let v979 : int32 = v971 - 1
    let v981 : string = v13.[int v958..int v979]
    let v990 : int32 = 8 |> int32 
    let v1003 : int32 = 12 |> int32 
    let v1011 : int32 = v1003 - 1
    let v1013 : string = v13.[int v990..int v1011]
    let v1022 : int32 = 12 |> int32 
    let v1035 : int32 = 16 |> int32 
    let v1043 : int32 = v1035 - 1
    let v1045 : string = v13.[int v1022..int v1043]
    let v1054 : int32 = 16 |> int32 
    let v1067 : int32 = 20 |> int32 
    let v1075 : int32 = v1067 - 1
    let v1077 : string = v13.[int v1054..int v1075]
    let v1086 : int32 = 20 |> int32 
    let v1099 : int32 = 32 |> int32 
    let v1107 : int32 = v1099 - 1
    let v1109 : string = v13.[int v1086..int v1107]
    let v1114 : string = v981 + v16 
    let v1118 : string = v1114 + v1013 
    let v1122 : string = v1118 + v16 
    let v1126 : string = v1122 + v1045 
    let v1130 : string = v1126 + v16 
    let v1134 : string = v1130 + v1077 
    let v1138 : string = v1134 + v16 
    let v1142 : string = v1138 + v1109 
    (* run_target_args'
    let v1149 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1151 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1151 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1155 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1155 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1159 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1149 = v1159 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1163 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1163 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1167 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1167 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1171 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1171 
    #endif
#else
    let v1175 : System.Guid = v1142 |> System.Guid 
    let _run_target_args'_v1149 = v1175 
    #endif
    let v1178 : System.Guid = _run_target_args'_v1149 
    let _run_target_args'_v246 = v1178 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1192 : int32 = 0 |> int32 
    let v1205 : int32 = 8 |> int32 
    let v1213 : int32 = v1205 - 1
    let v1215 : string = v13.[int v1192..int v1213]
    let v1224 : int32 = 8 |> int32 
    let v1237 : int32 = 12 |> int32 
    let v1245 : int32 = v1237 - 1
    let v1247 : string = v13.[int v1224..int v1245]
    let v1256 : int32 = 12 |> int32 
    let v1269 : int32 = 16 |> int32 
    let v1277 : int32 = v1269 - 1
    let v1279 : string = v13.[int v1256..int v1277]
    let v1288 : int32 = 16 |> int32 
    let v1301 : int32 = 20 |> int32 
    let v1309 : int32 = v1301 - 1
    let v1311 : string = v13.[int v1288..int v1309]
    let v1320 : int32 = 20 |> int32 
    let v1333 : int32 = 32 |> int32 
    let v1341 : int32 = v1333 - 1
    let v1343 : string = v13.[int v1320..int v1341]
    let v1348 : string = v1215 + v16 
    let v1352 : string = v1348 + v1247 
    let v1356 : string = v1352 + v16 
    let v1360 : string = v1356 + v1279 
    let v1364 : string = v1360 + v16 
    let v1368 : string = v1364 + v1311 
    let v1372 : string = v1368 + v16 
    let v1376 : string = v1372 + v1343 
    (* run_target_args'
    let v1383 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1385 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1385 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1389 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1389 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1393 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1383 = v1393 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1397 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1397 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1401 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1401 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1405 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1405 
    #endif
#else
    let v1409 : System.Guid = v1376 |> System.Guid 
    let _run_target_args'_v1383 = v1409 
    #endif
    let v1412 : System.Guid = _run_target_args'_v1383 
    let _run_target_args'_v246 = v1412 
    #endif
#else
    let v1426 : int32 = 0 |> int32 
    let v1439 : int32 = 8 |> int32 
    let v1447 : int32 = v1439 - 1
    let v1449 : string = v13.[int v1426..int v1447]
    let v1458 : int32 = 8 |> int32 
    let v1471 : int32 = 12 |> int32 
    let v1479 : int32 = v1471 - 1
    let v1481 : string = v13.[int v1458..int v1479]
    let v1490 : int32 = 12 |> int32 
    let v1503 : int32 = 16 |> int32 
    let v1511 : int32 = v1503 - 1
    let v1513 : string = v13.[int v1490..int v1511]
    let v1522 : int32 = 16 |> int32 
    let v1535 : int32 = 20 |> int32 
    let v1543 : int32 = v1535 - 1
    let v1545 : string = v13.[int v1522..int v1543]
    let v1554 : int32 = 20 |> int32 
    let v1567 : int32 = 32 |> int32 
    let v1575 : int32 = v1567 - 1
    let v1577 : string = v13.[int v1554..int v1575]
    let v1582 : string = v1449 + v16 
    let v1586 : string = v1582 + v1481 
    let v1590 : string = v1586 + v16 
    let v1594 : string = v1590 + v1513 
    let v1598 : string = v1594 + v16 
    let v1602 : string = v1598 + v1545 
    let v1606 : string = v1602 + v16 
    let v1610 : string = v1606 + v1577 
    (* run_target_args'
    let v1617 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1619 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1619 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1623 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1623 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1627 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1617 = v1627 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1631 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1631 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1635 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1635 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1639 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1639 
    #endif
#else
    let v1643 : System.Guid = v1610 |> System.Guid 
    let _run_target_args'_v1617 = v1643 
    #endif
    let v1646 : System.Guid = _run_target_args'_v1617 
    let _run_target_args'_v246 = v1646 
    #endif
    let v1655 : System.Guid = _run_target_args'_v246 
    v1655
and closure48 () (v0 : string) : struct (string * System.IDisposable) =
    let v1 : System.Guid = method94(v0)
    let v2 : string = method76(v1)
    let v3 : System.IDisposable = method82(v2)
    struct (v2, v3)
and closure50 () () : string =
    let v0 : string = __SOURCE_DIRECTORY__
    v0
and closure52 () (v0 : std_path_PathBuf) : US14 =
    US14_0(v0)
and method99 () : (std_path_PathBuf -> US14) =
    closure52()
and closure53 () (v0 : string) : US14 =
    US14_1(v0)
and method100 () : (string -> US14) =
    closure53()
and method103 (v0 : string) : string option =
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
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : string = "String::from($0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v47 
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v49 
    let _run_target_args'_v46 = v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v51 
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v62 
    #endif
#else
    let v66 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v66 
    #endif
    let v69 : std_string_String = _run_target_args'_v46 
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : string = "std::path::PathBuf::from($0)"
    let v84 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v83 
    let _run_target_args'_v82 = v84 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v85 : string = "std::path::PathBuf::from($0)"
    let v86 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v85 
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v87 : string = "std::path::PathBuf::from($0)"
    let v88 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v87 
    let _run_target_args'_v82 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v98 
    #endif
#else
    let v102 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v102 
    #endif
    let v105 : std_path_PathBuf = _run_target_args'_v82 
    let v114 : string = "$0.parent().map(std::path::PathBuf::from)"
    let v115 : std_path_PathBuf option = Fable.Core.RustInterop.emitRustExpr v105 v114 
    let v116 : string = "true; let _optionm_map_ = $0.map(|x| { //"
    let v117 : bool = Fable.Core.RustInterop.emitRustExpr v115 v116 
    let v118 : string = "x"
    let v119 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr () v118 
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
    (* run_target_args'
    let v160 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v161 : string = "format!(\"{}\", $0)"
    let v162 : std_string_String = Fable.Core.RustInterop.emitRustExpr v147 v161 
    let _run_target_args'_v160 = v162 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v163 : string = "format!(\"{}\", $0)"
    let v164 : std_string_String = Fable.Core.RustInterop.emitRustExpr v147 v163 
    let _run_target_args'_v160 = v164 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v165 : string = "format!(\"{}\", $0)"
    let v166 : std_string_String = Fable.Core.RustInterop.emitRustExpr v147 v165 
    let _run_target_args'_v160 = v166 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v168 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v160 = v168 
    #endif
#if FABLE_COMPILER_PYTHON
    let v172 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v160 = v172 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v176 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v160 = v176 
    #endif
#else
    let v180 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v160 = v180 
    #endif
    let v183 : std_string_String = _run_target_args'_v160 
    let v192 : string = "fable_library_rust::String_::fromString($0)"
    let v193 : string = Fable.Core.RustInterop.emitRustExpr v183 v192 
    let v194 : string = "true; $0 })"
    let v195 : bool = Fable.Core.RustInterop.emitRustExpr v193 v194 
    let v196 : string = "_optionm_map_"
    let v197 : string option = Fable.Core.RustInterop.emitRustExpr () v196 
    let _run_target_args'_v5 = v197 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v199 : string option = None
    let _run_target_args'_v5 = v199 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v203 : string option = None
    let _run_target_args'_v5 = v203 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v206 : string = "path"
    let v207 : IPathDirname = Fable.Core.JsInterop.importAll v206 
    let v208 : string = "v207.dirname($0)"
    let v209 : string = Fable.Core.JsInterop.emitJsExpr v0 v208 
    let v210 : bool = v209 = v0
    let v213 : US5 =
        if v210 then
            US5_1
        else
            US5_0(v209)
    let v224 : string option =
        match v213 with
        | US5_1 -> (* None *)
            let v220 : string option = None
            v220
        | US5_0(v214) -> (* Some *)
            let v216 : string option = Some v214 
            v216
    let _run_target_args'_v5 = v224 
    #endif
#if FABLE_COMPILER_PYTHON
    let v226 : string option = None
    let _run_target_args'_v5 = v226 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v230 : string option = None
    let _run_target_args'_v5 = v230 
    #endif
#else
    let v233 : (string -> System_IO_DirectoryInfo) = System.IO.Directory.GetParent
    let v234 : System_IO_DirectoryInfo = v233 v0
    let v236 : System_IO_DirectoryInfo = null |> unbox<System_IO_DirectoryInfo>
    let v240 : bool = v234 = v236 
    let v285 : US5 =
        if v240 then
            US5_1
        else
            (* run_target_args'
            let v248 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v250 : string = null |> unbox<string>
            let _run_target_args'_v248 = v250 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v254 : string = null |> unbox<string>
            let _run_target_args'_v248 = v254 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v258 : string = null |> unbox<string>
            let _run_target_args'_v248 = v258 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v262 : string = null |> unbox<string>
            let _run_target_args'_v248 = v262 
            #endif
#if FABLE_COMPILER_PYTHON
            let v266 : string = null |> unbox<string>
            let _run_target_args'_v248 = v266 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v270 : string = null |> unbox<string>
            let _run_target_args'_v248 = v270 
            #endif
#else
            let v273 : (System_IO_DirectoryInfo -> string) = _.FullName
            let v274 : string = v273 v234
            let _run_target_args'_v248 = v274 
            #endif
            let v275 : string = _run_target_args'_v248 
            US5_0(v275)
    let v296 : string option =
        match v285 with
        | US5_1 -> (* None *)
            let v292 : string option = None
            v292
        | US5_0(v286) -> (* Some *)
            let v288 : string option = Some v286 
            v288
    let _run_target_args'_v5 = v296 
    #endif
    let v297 : string option = _run_target_args'_v5 
    v297
and method102 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method19(v4)
    let v6 : string option = method103(v4)
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method17()
    let v36 : Mut3 = {l0 = v35} : Mut3
    let v38 : string = $"{v3}"
    let v46 : unit = ()
    let v47 : (unit -> unit) = closure6(v36, v38)
    let v48 : unit = (fun () -> v47 (); v46) ()
    let v54 : string = v36.l0
    let v55 : bool = v2 >= 11uy
    if v55 then
        let v56 : string = $"file_system.read_link / "
        let v57 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v58 : string = v56 + v57 
        (* run_target_args'
        let v63 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v64 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v65 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v58 v64 
        let _run_target_args'_v63 = v65 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v66 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v67 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v58 v66 
        let _run_target_args'_v63 = v67 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v68 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v69 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v58 v68 
        let _run_target_args'_v63 = v69 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v71 : std_io_Error = v58 |> unbox<std_io_Error>
        let _run_target_args'_v63 = v71 
        #endif
#if FABLE_COMPILER_PYTHON
        let v75 : std_io_Error = v58 |> unbox<std_io_Error>
        let _run_target_args'_v63 = v75 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v79 : std_io_Error = v58 |> unbox<std_io_Error>
        let _run_target_args'_v63 = v79 
        #endif
#else
        let v83 : std_io_Error = v58 |> unbox<std_io_Error>
        let _run_target_args'_v63 = v83 
        #endif
        let v86 : std_io_Error = _run_target_args'_v63 
        (* run_target_args'
        let v96 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v97 : string = "Err($0)"
        let v98 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v97 
        let _run_target_args'_v96 = v98 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v99 : string = "Err($0)"
        let v100 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v99 
        let _run_target_args'_v96 = v100 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v101 : string = "Err($0)"
        let v102 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v101 
        let _run_target_args'_v96 = v102 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v103 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v96 = v103 
        #endif
#if FABLE_COMPILER_PYTHON
        let v104 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v96 = v104 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v105 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v96 = v105 
        #endif
#else
        let v106 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v96 = v106 
        #endif
        let v107 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v96 
        v107
    else
        match v31 with
        | US5_0(v110) -> (* Some *)
            let v113 : string = ""
            let v114 : bool = v4 <> v113 
            if v114 then
                let v117 : uint8 = v2 + 1uy
                let v118 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v117
                let v119 : Result<std_path_PathBuf, std_io_Error> = v118 v110
                let v120 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v122 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v123 : string = "$0.map_err(|x| $1(x))"
                let v124 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v119, v120) v123 
                let _run_target_args'_v122 = v124 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v125 : string = "$0.map_err(|x| $1(x))"
                let v126 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v119, v120) v125 
                let _run_target_args'_v122 = v126 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v127 : string = "$0.map_err(|x| $1(x))"
                let v128 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v119, v120) v127 
                let _run_target_args'_v122 = v128 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v129 : Result<std_path_PathBuf, string> = match v119 with Ok x -> Ok x | Error x -> Error (v120 x)
                let _run_target_args'_v122 = v129 
                #endif
#if FABLE_COMPILER_PYTHON
                let v130 : Result<std_path_PathBuf, string> = match v119 with Ok x -> Ok x | Error x -> Error (v120 x)
                let _run_target_args'_v122 = v130 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v131 : Result<std_path_PathBuf, string> = match v119 with Ok x -> Ok x | Error x -> Error (v120 x)
                let _run_target_args'_v122 = v131 
                #endif
#else
                let v132 : Result<std_path_PathBuf, string> = match v119 with Ok x -> Ok x | Error x -> Error (v120 x)
                let _run_target_args'_v122 = v132 
                #endif
                let v133 : Result<std_path_PathBuf, string> = _run_target_args'_v122 
                let v136 : (std_path_PathBuf -> US14) = method99()
                let v137 : (string -> US14) = method100()
                let v139 : US14 = match v133 with Ok x -> v136 x | Error x -> v137 x
                match v139 with
                | US14_1(v307) -> (* Error *)
                    let v308 : string = $"file_system.read_link / "
                    let v309 : string = $"error': {v307} / error: {v54} / name: {v5}"
                    let v310 : string = v308 + v309 
                    (* run_target_args'
                    let v315 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v316 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v317 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v310 v316 
                    let _run_target_args'_v315 = v317 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v318 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v319 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v310 v318 
                    let _run_target_args'_v315 = v319 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v320 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v321 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v310 v320 
                    let _run_target_args'_v315 = v321 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v323 : std_io_Error = v310 |> unbox<std_io_Error>
                    let _run_target_args'_v315 = v323 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v327 : std_io_Error = v310 |> unbox<std_io_Error>
                    let _run_target_args'_v315 = v327 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v331 : std_io_Error = v310 |> unbox<std_io_Error>
                    let _run_target_args'_v315 = v331 
                    #endif
#else
                    let v335 : std_io_Error = v310 |> unbox<std_io_Error>
                    let _run_target_args'_v315 = v335 
                    #endif
                    let v338 : std_io_Error = _run_target_args'_v315 
                    (* run_target_args'
                    let v348 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v349 : string = "Err($0)"
                    let v350 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v338 v349 
                    let _run_target_args'_v348 = v350 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v351 : string = "Err($0)"
                    let v352 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v338 v351 
                    let _run_target_args'_v348 = v352 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v353 : string = "Err($0)"
                    let v354 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v338 v353 
                    let _run_target_args'_v348 = v354 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v355 : Result<std_path_PathBuf, std_io_Error> = v338 |> Error
                    let _run_target_args'_v348 = v355 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v356 : Result<std_path_PathBuf, std_io_Error> = v338 |> Error
                    let _run_target_args'_v348 = v356 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v357 : Result<std_path_PathBuf, std_io_Error> = v338 |> Error
                    let _run_target_args'_v348 = v357 
                    #endif
#else
                    let v358 : Result<std_path_PathBuf, std_io_Error> = v338 |> Error
                    let _run_target_args'_v348 = v358 
                    #endif
                    let v359 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v348 
                    v359
                | US14_0(v142) -> (* Ok *)
                    (* run_target_args'
                    let v147 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v148 : string = "$0.display()"
                    let v149 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v142 v148 
                    let _run_target_args'_v147 = v149 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v150 : string = "$0.display()"
                    let v151 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v142 v150 
                    let _run_target_args'_v147 = v151 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v152 : string = "$0.display()"
                    let v153 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v142 v152 
                    let _run_target_args'_v147 = v153 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v155 : std_path_Display = v142 |> unbox<std_path_Display>
                    let _run_target_args'_v147 = v155 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v159 : std_path_Display = v142 |> unbox<std_path_Display>
                    let _run_target_args'_v147 = v159 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v163 : std_path_Display = v142 |> unbox<std_path_Display>
                    let _run_target_args'_v147 = v163 
                    #endif
#else
                    let v167 : std_path_Display = v142 |> unbox<std_path_Display>
                    let _run_target_args'_v147 = v167 
                    #endif
                    let v170 : std_path_Display = _run_target_args'_v147 
                    let v180 : string = v170 |> string 
                    let v183 : string = method79(v180, v5)
                    (* run_target_args'
                    let v188 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v189 : string = "&*$0"
                    let v190 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v183 v189 
                    let _run_target_args'_v188 = v190 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v191 : string = "&*$0"
                    let v192 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v183 v191 
                    let _run_target_args'_v188 = v192 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v193 : string = "&*$0"
                    let v194 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v183 v193 
                    let _run_target_args'_v188 = v194 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v196 : Ref<Str> = v183 |> unbox<Ref<Str>>
                    let _run_target_args'_v188 = v196 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v200 : Ref<Str> = v183 |> unbox<Ref<Str>>
                    let _run_target_args'_v188 = v200 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v204 : Ref<Str> = v183 |> unbox<Ref<Str>>
                    let _run_target_args'_v188 = v204 
                    #endif
#else
                    let v208 : Ref<Str> = v183 |> unbox<Ref<Str>>
                    let _run_target_args'_v188 = v208 
                    #endif
                    let v211 : Ref<Str> = _run_target_args'_v188 
                    (* run_target_args'
                    let v224 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v225 : string = "String::from($0)"
                    let v226 : std_string_String = Fable.Core.RustInterop.emitRustExpr v211 v225 
                    let _run_target_args'_v224 = v226 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v227 : string = "String::from($0)"
                    let v228 : std_string_String = Fable.Core.RustInterop.emitRustExpr v211 v227 
                    let _run_target_args'_v224 = v228 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v229 : string = "String::from($0)"
                    let v230 : std_string_String = Fable.Core.RustInterop.emitRustExpr v211 v229 
                    let _run_target_args'_v224 = v230 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v232 : std_string_String = v211 |> unbox<std_string_String>
                    let _run_target_args'_v224 = v232 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v236 : std_string_String = v211 |> unbox<std_string_String>
                    let _run_target_args'_v224 = v236 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v240 : std_string_String = v211 |> unbox<std_string_String>
                    let _run_target_args'_v224 = v240 
                    #endif
#else
                    let v244 : std_string_String = v211 |> unbox<std_string_String>
                    let _run_target_args'_v224 = v244 
                    #endif
                    let v247 : std_string_String = _run_target_args'_v224 
                    (* run_target_args'
                    let v260 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v261 : string = "std::path::PathBuf::from($0)"
                    let v262 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v247 v261 
                    let _run_target_args'_v260 = v262 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v263 : string = "std::path::PathBuf::from($0)"
                    let v264 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v247 v263 
                    let _run_target_args'_v260 = v264 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v265 : string = "std::path::PathBuf::from($0)"
                    let v266 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v247 v265 
                    let _run_target_args'_v260 = v266 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v268 : std_path_PathBuf = v247 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v260 = v268 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v272 : std_path_PathBuf = v247 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v260 = v272 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v276 : std_path_PathBuf = v247 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v260 = v276 
                    #endif
#else
                    let v280 : std_path_PathBuf = v247 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v260 = v280 
                    #endif
                    let v283 : std_path_PathBuf = _run_target_args'_v260 
                    (* run_target_args'
                    let v293 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v294 : string = "Ok($0)"
                    let v295 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v283 v294 
                    let _run_target_args'_v293 = v295 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v296 : string = "Ok($0)"
                    let v297 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v283 v296 
                    let _run_target_args'_v293 = v297 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v298 : string = "Ok($0)"
                    let v299 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v283 v298 
                    let _run_target_args'_v293 = v299 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v300 : Result<std_path_PathBuf, std_io_Error> = v283 |> Ok
                    let _run_target_args'_v293 = v300 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v301 : Result<std_path_PathBuf, std_io_Error> = v283 |> Ok
                    let _run_target_args'_v293 = v301 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v302 : Result<std_path_PathBuf, std_io_Error> = v283 |> Ok
                    let _run_target_args'_v293 = v302 
                    #endif
#else
                    let v303 : Result<std_path_PathBuf, std_io_Error> = v283 |> Ok
                    let _run_target_args'_v293 = v303 
                    #endif
                    let v304 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v293 
                    v304
            else
                let v364 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v365 : string = $"path: {v0} / error: {v54} / path': {v4} / name: {v5}"
                let v366 : string = v364 + v365 
                (* run_target_args'
                let v371 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v372 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v373 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v366 v372 
                let _run_target_args'_v371 = v373 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v374 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v375 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v366 v374 
                let _run_target_args'_v371 = v375 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v376 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v377 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v366 v376 
                let _run_target_args'_v371 = v377 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v379 : std_io_Error = v366 |> unbox<std_io_Error>
                let _run_target_args'_v371 = v379 
                #endif
#if FABLE_COMPILER_PYTHON
                let v383 : std_io_Error = v366 |> unbox<std_io_Error>
                let _run_target_args'_v371 = v383 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v387 : std_io_Error = v366 |> unbox<std_io_Error>
                let _run_target_args'_v371 = v387 
                #endif
#else
                let v391 : std_io_Error = v366 |> unbox<std_io_Error>
                let _run_target_args'_v371 = v391 
                #endif
                let v394 : std_io_Error = _run_target_args'_v371 
                (* run_target_args'
                let v404 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v405 : string = "Err($0)"
                let v406 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v394 v405 
                let _run_target_args'_v404 = v406 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v407 : string = "Err($0)"
                let v408 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v394 v407 
                let _run_target_args'_v404 = v408 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v409 : string = "Err($0)"
                let v410 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v394 v409 
                let _run_target_args'_v404 = v410 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v411 : Result<std_path_PathBuf, std_io_Error> = v394 |> Error
                let _run_target_args'_v404 = v411 
                #endif
#if FABLE_COMPILER_PYTHON
                let v412 : Result<std_path_PathBuf, std_io_Error> = v394 |> Error
                let _run_target_args'_v404 = v412 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v413 : Result<std_path_PathBuf, std_io_Error> = v394 |> Error
                let _run_target_args'_v404 = v413 
                #endif
#else
                let v414 : Result<std_path_PathBuf, std_io_Error> = v394 |> Error
                let _run_target_args'_v404 = v414 
                #endif
                let v415 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v404 
                v415
        | _ ->
            let v419 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v420 : string = $"path: {v0} / error: {v54} / path': {v4} / name: {v5}"
            let v421 : string = v419 + v420 
            (* run_target_args'
            let v426 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v427 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v428 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v421 v427 
            let _run_target_args'_v426 = v428 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v429 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v430 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v421 v429 
            let _run_target_args'_v426 = v430 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v431 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v432 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v421 v431 
            let _run_target_args'_v426 = v432 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v434 : std_io_Error = v421 |> unbox<std_io_Error>
            let _run_target_args'_v426 = v434 
            #endif
#if FABLE_COMPILER_PYTHON
            let v438 : std_io_Error = v421 |> unbox<std_io_Error>
            let _run_target_args'_v426 = v438 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v442 : std_io_Error = v421 |> unbox<std_io_Error>
            let _run_target_args'_v426 = v442 
            #endif
#else
            let v446 : std_io_Error = v421 |> unbox<std_io_Error>
            let _run_target_args'_v426 = v446 
            #endif
            let v449 : std_io_Error = _run_target_args'_v426 
            (* run_target_args'
            let v459 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v460 : string = "Err($0)"
            let v461 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v449 v460 
            let _run_target_args'_v459 = v461 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v462 : string = "Err($0)"
            let v463 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v449 v462 
            let _run_target_args'_v459 = v463 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v464 : string = "Err($0)"
            let v465 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v449 v464 
            let _run_target_args'_v459 = v465 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v466 : Result<std_path_PathBuf, std_io_Error> = v449 |> Error
            let _run_target_args'_v459 = v466 
            #endif
#if FABLE_COMPILER_PYTHON
            let v467 : Result<std_path_PathBuf, std_io_Error> = v449 |> Error
            let _run_target_args'_v459 = v467 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v468 : Result<std_path_PathBuf, std_io_Error> = v449 |> Error
            let _run_target_args'_v459 = v468 
            #endif
#else
            let v469 : Result<std_path_PathBuf, std_io_Error> = v449 |> Error
            let _run_target_args'_v459 = v469 
            #endif
            let v470 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v459 
            v470
and method101 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "std::fs::read_link(&*$0)"
    let v9 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let v10 : (std_io_Error -> string) = method44()
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
    let v26 : (std_path_PathBuf -> US14) = method99()
    let v27 : (string -> US14) = method100()
    let v29 : US14 = match v23 with Ok x -> v26 x | Error x -> v27 x
    let v52 : Result<std_path_PathBuf, std_io_Error> =
        match v29 with
        | US14_1(v48) -> (* Error *)
            let v49 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method102(v0, v49, v1, v48, v2)
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
    let v55 : (std_io_Error -> string) = method44()
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
    let v71 : (std_path_PathBuf -> US14) = method99()
    let v72 : (string -> US14) = method100()
    let v74 : US14 = match v68 with Ok x -> v71 x | Error x -> v72 x
    let v97 : Result<std_path_PathBuf, std_io_Error> =
        match v74 with
        | US14_1(v93) -> (* Error *)
            let v94 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method102(v0, v94, v1, v93, v2)
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
    let v100 : (std_io_Error -> string) = method44()
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
    let v116 : (std_path_PathBuf -> US14) = method99()
    let v117 : (string -> US14) = method100()
    let v119 : US14 = match v113 with Ok x -> v116 x | Error x -> v117 x
    let v142 : Result<std_path_PathBuf, std_io_Error> =
        match v119 with
        | US14_1(v138) -> (* Error *)
            let v139 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method102(v0, v139, v1, v138, v2)
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
    method101(v0, v1, v2)
and closure54 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure55(v0, v1)
and method104 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method19(v0)
    let v5 : string option = method103(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method17()
    let v35 : Mut3 = {l0 = v34} : Mut3
    let v37 : string = $"{v3}"
    let v45 : unit = ()
    let v46 : (unit -> unit) = closure6(v35, v37)
    let v47 : unit = (fun () -> v46 (); v45) ()
    let v53 : string = v35.l0
    let v54 : bool = v2 >= 11uy
    if v54 then
        let v55 : string = $"file_system.read_link / "
        let v56 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v57 : string = v55 + v56 
        (* run_target_args'
        let v62 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v63 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v64 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v57 v63 
        let _run_target_args'_v62 = v64 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v65 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v66 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v57 v65 
        let _run_target_args'_v62 = v66 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v67 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v68 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v57 v67 
        let _run_target_args'_v62 = v68 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v70 : std_io_Error = v57 |> unbox<std_io_Error>
        let _run_target_args'_v62 = v70 
        #endif
#if FABLE_COMPILER_PYTHON
        let v74 : std_io_Error = v57 |> unbox<std_io_Error>
        let _run_target_args'_v62 = v74 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v78 : std_io_Error = v57 |> unbox<std_io_Error>
        let _run_target_args'_v62 = v78 
        #endif
#else
        let v82 : std_io_Error = v57 |> unbox<std_io_Error>
        let _run_target_args'_v62 = v82 
        #endif
        let v85 : std_io_Error = _run_target_args'_v62 
        (* run_target_args'
        let v95 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v96 : string = "Err($0)"
        let v97 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v96 
        let _run_target_args'_v95 = v97 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v98 : string = "Err($0)"
        let v99 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v98 
        let _run_target_args'_v95 = v99 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v100 : string = "Err($0)"
        let v101 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v100 
        let _run_target_args'_v95 = v101 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v102 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v95 = v102 
        #endif
#if FABLE_COMPILER_PYTHON
        let v103 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v95 = v103 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v104 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v95 = v104 
        #endif
#else
        let v105 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v95 = v105 
        #endif
        let v106 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v95 
        v106
    else
        match v30 with
        | US5_0(v109) -> (* Some *)
            let v112 : string = ""
            let v113 : bool = v0 <> v112 
            if v113 then
                let v116 : uint8 = v2 + 1uy
                let v117 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v116
                let v118 : Result<std_path_PathBuf, std_io_Error> = v117 v109
                let v119 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v121 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v122 : string = "$0.map_err(|x| $1(x))"
                let v123 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v118, v119) v122 
                let _run_target_args'_v121 = v123 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v124 : string = "$0.map_err(|x| $1(x))"
                let v125 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v118, v119) v124 
                let _run_target_args'_v121 = v125 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v126 : string = "$0.map_err(|x| $1(x))"
                let v127 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v118, v119) v126 
                let _run_target_args'_v121 = v127 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v128 : Result<std_path_PathBuf, string> = match v118 with Ok x -> Ok x | Error x -> Error (v119 x)
                let _run_target_args'_v121 = v128 
                #endif
#if FABLE_COMPILER_PYTHON
                let v129 : Result<std_path_PathBuf, string> = match v118 with Ok x -> Ok x | Error x -> Error (v119 x)
                let _run_target_args'_v121 = v129 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v130 : Result<std_path_PathBuf, string> = match v118 with Ok x -> Ok x | Error x -> Error (v119 x)
                let _run_target_args'_v121 = v130 
                #endif
#else
                let v131 : Result<std_path_PathBuf, string> = match v118 with Ok x -> Ok x | Error x -> Error (v119 x)
                let _run_target_args'_v121 = v131 
                #endif
                let v132 : Result<std_path_PathBuf, string> = _run_target_args'_v121 
                let v135 : (std_path_PathBuf -> US14) = method99()
                let v136 : (string -> US14) = method100()
                let v138 : US14 = match v132 with Ok x -> v135 x | Error x -> v136 x
                match v138 with
                | US14_1(v306) -> (* Error *)
                    let v307 : string = $"file_system.read_link / "
                    let v308 : string = $"error': {v306} / error: {v53} / name: {v4}"
                    let v309 : string = v307 + v308 
                    (* run_target_args'
                    let v314 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v315 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v316 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v309 v315 
                    let _run_target_args'_v314 = v316 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v317 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v318 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v309 v317 
                    let _run_target_args'_v314 = v318 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v319 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v320 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v309 v319 
                    let _run_target_args'_v314 = v320 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v322 : std_io_Error = v309 |> unbox<std_io_Error>
                    let _run_target_args'_v314 = v322 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v326 : std_io_Error = v309 |> unbox<std_io_Error>
                    let _run_target_args'_v314 = v326 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v330 : std_io_Error = v309 |> unbox<std_io_Error>
                    let _run_target_args'_v314 = v330 
                    #endif
#else
                    let v334 : std_io_Error = v309 |> unbox<std_io_Error>
                    let _run_target_args'_v314 = v334 
                    #endif
                    let v337 : std_io_Error = _run_target_args'_v314 
                    (* run_target_args'
                    let v347 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v348 : string = "Err($0)"
                    let v349 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v337 v348 
                    let _run_target_args'_v347 = v349 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v350 : string = "Err($0)"
                    let v351 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v337 v350 
                    let _run_target_args'_v347 = v351 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v352 : string = "Err($0)"
                    let v353 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v337 v352 
                    let _run_target_args'_v347 = v353 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v354 : Result<std_path_PathBuf, std_io_Error> = v337 |> Error
                    let _run_target_args'_v347 = v354 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v355 : Result<std_path_PathBuf, std_io_Error> = v337 |> Error
                    let _run_target_args'_v347 = v355 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v356 : Result<std_path_PathBuf, std_io_Error> = v337 |> Error
                    let _run_target_args'_v347 = v356 
                    #endif
#else
                    let v357 : Result<std_path_PathBuf, std_io_Error> = v337 |> Error
                    let _run_target_args'_v347 = v357 
                    #endif
                    let v358 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v347 
                    v358
                | US14_0(v141) -> (* Ok *)
                    (* run_target_args'
                    let v146 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v147 : string = "$0.display()"
                    let v148 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v141 v147 
                    let _run_target_args'_v146 = v148 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v149 : string = "$0.display()"
                    let v150 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v141 v149 
                    let _run_target_args'_v146 = v150 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v151 : string = "$0.display()"
                    let v152 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v141 v151 
                    let _run_target_args'_v146 = v152 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v154 : std_path_Display = v141 |> unbox<std_path_Display>
                    let _run_target_args'_v146 = v154 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v158 : std_path_Display = v141 |> unbox<std_path_Display>
                    let _run_target_args'_v146 = v158 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v162 : std_path_Display = v141 |> unbox<std_path_Display>
                    let _run_target_args'_v146 = v162 
                    #endif
#else
                    let v166 : std_path_Display = v141 |> unbox<std_path_Display>
                    let _run_target_args'_v146 = v166 
                    #endif
                    let v169 : std_path_Display = _run_target_args'_v146 
                    let v179 : string = v169 |> string 
                    let v182 : string = method79(v179, v4)
                    (* run_target_args'
                    let v187 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v188 : string = "&*$0"
                    let v189 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v182 v188 
                    let _run_target_args'_v187 = v189 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v190 : string = "&*$0"
                    let v191 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v182 v190 
                    let _run_target_args'_v187 = v191 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v192 : string = "&*$0"
                    let v193 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v182 v192 
                    let _run_target_args'_v187 = v193 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v195 : Ref<Str> = v182 |> unbox<Ref<Str>>
                    let _run_target_args'_v187 = v195 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v199 : Ref<Str> = v182 |> unbox<Ref<Str>>
                    let _run_target_args'_v187 = v199 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v203 : Ref<Str> = v182 |> unbox<Ref<Str>>
                    let _run_target_args'_v187 = v203 
                    #endif
#else
                    let v207 : Ref<Str> = v182 |> unbox<Ref<Str>>
                    let _run_target_args'_v187 = v207 
                    #endif
                    let v210 : Ref<Str> = _run_target_args'_v187 
                    (* run_target_args'
                    let v223 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v224 : string = "String::from($0)"
                    let v225 : std_string_String = Fable.Core.RustInterop.emitRustExpr v210 v224 
                    let _run_target_args'_v223 = v225 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v226 : string = "String::from($0)"
                    let v227 : std_string_String = Fable.Core.RustInterop.emitRustExpr v210 v226 
                    let _run_target_args'_v223 = v227 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v228 : string = "String::from($0)"
                    let v229 : std_string_String = Fable.Core.RustInterop.emitRustExpr v210 v228 
                    let _run_target_args'_v223 = v229 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v231 : std_string_String = v210 |> unbox<std_string_String>
                    let _run_target_args'_v223 = v231 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v235 : std_string_String = v210 |> unbox<std_string_String>
                    let _run_target_args'_v223 = v235 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v239 : std_string_String = v210 |> unbox<std_string_String>
                    let _run_target_args'_v223 = v239 
                    #endif
#else
                    let v243 : std_string_String = v210 |> unbox<std_string_String>
                    let _run_target_args'_v223 = v243 
                    #endif
                    let v246 : std_string_String = _run_target_args'_v223 
                    (* run_target_args'
                    let v259 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v260 : string = "std::path::PathBuf::from($0)"
                    let v261 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v246 v260 
                    let _run_target_args'_v259 = v261 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v262 : string = "std::path::PathBuf::from($0)"
                    let v263 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v246 v262 
                    let _run_target_args'_v259 = v263 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v264 : string = "std::path::PathBuf::from($0)"
                    let v265 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v246 v264 
                    let _run_target_args'_v259 = v265 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v267 : std_path_PathBuf = v246 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v259 = v267 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v271 : std_path_PathBuf = v246 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v259 = v271 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v275 : std_path_PathBuf = v246 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v259 = v275 
                    #endif
#else
                    let v279 : std_path_PathBuf = v246 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v259 = v279 
                    #endif
                    let v282 : std_path_PathBuf = _run_target_args'_v259 
                    (* run_target_args'
                    let v292 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v293 : string = "Ok($0)"
                    let v294 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v282 v293 
                    let _run_target_args'_v292 = v294 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v295 : string = "Ok($0)"
                    let v296 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v282 v295 
                    let _run_target_args'_v292 = v296 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v297 : string = "Ok($0)"
                    let v298 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v282 v297 
                    let _run_target_args'_v292 = v298 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v299 : Result<std_path_PathBuf, std_io_Error> = v282 |> Ok
                    let _run_target_args'_v292 = v299 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v300 : Result<std_path_PathBuf, std_io_Error> = v282 |> Ok
                    let _run_target_args'_v292 = v300 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v301 : Result<std_path_PathBuf, std_io_Error> = v282 |> Ok
                    let _run_target_args'_v292 = v301 
                    #endif
#else
                    let v302 : Result<std_path_PathBuf, std_io_Error> = v282 |> Ok
                    let _run_target_args'_v292 = v302 
                    #endif
                    let v303 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v292 
                    v303
            else
                let v363 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v364 : string = $"path: {v0} / error: {v53} / path': {v0} / name: {v4}"
                let v365 : string = v363 + v364 
                (* run_target_args'
                let v370 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v371 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v372 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v365 v371 
                let _run_target_args'_v370 = v372 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v373 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v374 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v365 v373 
                let _run_target_args'_v370 = v374 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v375 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v376 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v365 v375 
                let _run_target_args'_v370 = v376 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v378 : std_io_Error = v365 |> unbox<std_io_Error>
                let _run_target_args'_v370 = v378 
                #endif
#if FABLE_COMPILER_PYTHON
                let v382 : std_io_Error = v365 |> unbox<std_io_Error>
                let _run_target_args'_v370 = v382 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v386 : std_io_Error = v365 |> unbox<std_io_Error>
                let _run_target_args'_v370 = v386 
                #endif
#else
                let v390 : std_io_Error = v365 |> unbox<std_io_Error>
                let _run_target_args'_v370 = v390 
                #endif
                let v393 : std_io_Error = _run_target_args'_v370 
                (* run_target_args'
                let v403 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v404 : string = "Err($0)"
                let v405 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v393 v404 
                let _run_target_args'_v403 = v405 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v406 : string = "Err($0)"
                let v407 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v393 v406 
                let _run_target_args'_v403 = v407 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v408 : string = "Err($0)"
                let v409 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v393 v408 
                let _run_target_args'_v403 = v409 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v410 : Result<std_path_PathBuf, std_io_Error> = v393 |> Error
                let _run_target_args'_v403 = v410 
                #endif
#if FABLE_COMPILER_PYTHON
                let v411 : Result<std_path_PathBuf, std_io_Error> = v393 |> Error
                let _run_target_args'_v403 = v411 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v412 : Result<std_path_PathBuf, std_io_Error> = v393 |> Error
                let _run_target_args'_v403 = v412 
                #endif
#else
                let v413 : Result<std_path_PathBuf, std_io_Error> = v393 |> Error
                let _run_target_args'_v403 = v413 
                #endif
                let v414 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v403 
                v414
        | _ ->
            let v418 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v419 : string = $"path: {v0} / error: {v53} / path': {v0} / name: {v4}"
            let v420 : string = v418 + v419 
            (* run_target_args'
            let v425 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v426 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v427 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v420 v426 
            let _run_target_args'_v425 = v427 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v428 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v429 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v420 v428 
            let _run_target_args'_v425 = v429 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v430 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v431 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v420 v430 
            let _run_target_args'_v425 = v431 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v433 : std_io_Error = v420 |> unbox<std_io_Error>
            let _run_target_args'_v425 = v433 
            #endif
#if FABLE_COMPILER_PYTHON
            let v437 : std_io_Error = v420 |> unbox<std_io_Error>
            let _run_target_args'_v425 = v437 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v441 : std_io_Error = v420 |> unbox<std_io_Error>
            let _run_target_args'_v425 = v441 
            #endif
#else
            let v445 : std_io_Error = v420 |> unbox<std_io_Error>
            let _run_target_args'_v425 = v445 
            #endif
            let v448 : std_io_Error = _run_target_args'_v425 
            (* run_target_args'
            let v458 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v459 : string = "Err($0)"
            let v460 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v448 v459 
            let _run_target_args'_v458 = v460 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v461 : string = "Err($0)"
            let v462 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v448 v461 
            let _run_target_args'_v458 = v462 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v463 : string = "Err($0)"
            let v464 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v448 v463 
            let _run_target_args'_v458 = v464 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v465 : Result<std_path_PathBuf, std_io_Error> = v448 |> Error
            let _run_target_args'_v458 = v465 
            #endif
#if FABLE_COMPILER_PYTHON
            let v466 : Result<std_path_PathBuf, std_io_Error> = v448 |> Error
            let _run_target_args'_v458 = v466 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v467 : Result<std_path_PathBuf, std_io_Error> = v448 |> Error
            let _run_target_args'_v458 = v467 
            #endif
#else
            let v468 : Result<std_path_PathBuf, std_io_Error> = v448 |> Error
            let _run_target_args'_v458 = v468 
            #endif
            let v469 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v458 
            v469
and method98 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "std::fs::read_link(&*$0)"
    let v8 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let v9 : (std_io_Error -> string) = method44()
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
    let v25 : (std_path_PathBuf -> US14) = method99()
    let v26 : (string -> US14) = method100()
    let v28 : US14 = match v22 with Ok x -> v25 x | Error x -> v26 x
    let v51 : Result<std_path_PathBuf, std_io_Error> =
        match v28 with
        | US14_1(v47) -> (* Error *)
            let v48 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method104(v0, v48, v1, v47)
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
    let v54 : (std_io_Error -> string) = method44()
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
    let v70 : (std_path_PathBuf -> US14) = method99()
    let v71 : (string -> US14) = method100()
    let v73 : US14 = match v67 with Ok x -> v70 x | Error x -> v71 x
    let v96 : Result<std_path_PathBuf, std_io_Error> =
        match v73 with
        | US14_1(v92) -> (* Error *)
            let v93 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method104(v0, v93, v1, v92)
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
    let v99 : (std_io_Error -> string) = method44()
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
    let v115 : (std_path_PathBuf -> US14) = method99()
    let v116 : (string -> US14) = method100()
    let v118 : US14 = match v112 with Ok x -> v115 x | Error x -> v116 x
    let v141 : Result<std_path_PathBuf, std_io_Error> =
        match v118 with
        | US14_1(v137) -> (* Error *)
            let v138 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method104(v0, v138, v1, v137)
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
and method106 (v0 : System_IO_DirectoryInfo) : System.IO.FileAttributes =
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
and method107 () : System.IO.FileAttributes =
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
and method108 (v0 : System.IO.FileAttributes, v1 : System.IO.FileAttributes) : bool =
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
and method110 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method19(v4)
    let v6 : string option = method103(v4)
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method17()
    let v36 : Mut3 = {l0 = v35} : Mut3
    (* run_target_args'
    let v41 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v42 : string = "format!(\"{:#?}\", $0)"
    let v43 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v42 
    let v44 : string = "fable_library_rust::String_::fromString($0)"
    let v45 : string = Fable.Core.RustInterop.emitRustExpr v43 v44 
    let _run_target_args'_v41 = v45 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v46 : string = "format!(\"{:#?}\", $0)"
    let v47 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v46 
    let v48 : string = "fable_library_rust::String_::fromString($0)"
    let v49 : string = Fable.Core.RustInterop.emitRustExpr v47 v48 
    let _run_target_args'_v41 = v49 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v50 : string = "format!(\"{:#?}\", $0)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v41 = v53 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v55 : string = $"%A{v3}"
    let _run_target_args'_v41 = v55 
    #endif
#if FABLE_COMPILER_PYTHON
    let v59 : string = $"%A{v3}"
    let _run_target_args'_v41 = v59 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v63 : string = $"%A{v3}"
    let _run_target_args'_v41 = v63 
    #endif
#else
    let v67 : string = $"%A{v3}"
    let _run_target_args'_v41 = v67 
    #endif
    let v70 : string = _run_target_args'_v41 
    let v80 : string = $"{v70}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure6(v36, v80)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v96 : string = v36.l0
    let v97 : bool = v2 >= 11uy
    if v97 then
        let v98 : string = $"file_system.read_link / "
        let v99 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v100 : string = v98 + v99 
        (* run_target_args'
        let v105 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v106 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v107 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v100 v106 
        let _run_target_args'_v105 = v107 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v108 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v109 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v100 v108 
        let _run_target_args'_v105 = v109 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v110 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v111 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v100 v110 
        let _run_target_args'_v105 = v111 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v113 : std_io_Error = v100 |> unbox<std_io_Error>
        let _run_target_args'_v105 = v113 
        #endif
#if FABLE_COMPILER_PYTHON
        let v117 : std_io_Error = v100 |> unbox<std_io_Error>
        let _run_target_args'_v105 = v117 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v121 : std_io_Error = v100 |> unbox<std_io_Error>
        let _run_target_args'_v105 = v121 
        #endif
#else
        let v125 : std_io_Error = v100 |> unbox<std_io_Error>
        let _run_target_args'_v105 = v125 
        #endif
        let v128 : std_io_Error = _run_target_args'_v105 
        (* run_target_args'
        let v138 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v139 : string = "Err($0)"
        let v140 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v128 v139 
        let _run_target_args'_v138 = v140 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v141 : string = "Err($0)"
        let v142 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v128 v141 
        let _run_target_args'_v138 = v142 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v143 : string = "Err($0)"
        let v144 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v128 v143 
        let _run_target_args'_v138 = v144 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v145 : Result<std_path_PathBuf, std_io_Error> = v128 |> Error
        let _run_target_args'_v138 = v145 
        #endif
#if FABLE_COMPILER_PYTHON
        let v146 : Result<std_path_PathBuf, std_io_Error> = v128 |> Error
        let _run_target_args'_v138 = v146 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v147 : Result<std_path_PathBuf, std_io_Error> = v128 |> Error
        let _run_target_args'_v138 = v147 
        #endif
#else
        let v148 : Result<std_path_PathBuf, std_io_Error> = v128 |> Error
        let _run_target_args'_v138 = v148 
        #endif
        let v149 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v138 
        v149
    else
        match v31 with
        | US5_0(v152) -> (* Some *)
            let v155 : string = ""
            let v156 : bool = v4 <> v155 
            if v156 then
                let v159 : uint8 = v2 + 1uy
                let v160 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v159
                let v161 : Result<std_path_PathBuf, std_io_Error> = v160 v152
                let v162 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v164 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v165 : string = "$0.map_err(|x| $1(x))"
                let v166 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v161, v162) v165 
                let _run_target_args'_v164 = v166 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v167 : string = "$0.map_err(|x| $1(x))"
                let v168 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v161, v162) v167 
                let _run_target_args'_v164 = v168 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v169 : string = "$0.map_err(|x| $1(x))"
                let v170 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v161, v162) v169 
                let _run_target_args'_v164 = v170 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v171 : Result<std_path_PathBuf, string> = match v161 with Ok x -> Ok x | Error x -> Error (v162 x)
                let _run_target_args'_v164 = v171 
                #endif
#if FABLE_COMPILER_PYTHON
                let v172 : Result<std_path_PathBuf, string> = match v161 with Ok x -> Ok x | Error x -> Error (v162 x)
                let _run_target_args'_v164 = v172 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v173 : Result<std_path_PathBuf, string> = match v161 with Ok x -> Ok x | Error x -> Error (v162 x)
                let _run_target_args'_v164 = v173 
                #endif
#else
                let v174 : Result<std_path_PathBuf, string> = match v161 with Ok x -> Ok x | Error x -> Error (v162 x)
                let _run_target_args'_v164 = v174 
                #endif
                let v175 : Result<std_path_PathBuf, string> = _run_target_args'_v164 
                let v178 : (std_path_PathBuf -> US14) = method99()
                let v179 : (string -> US14) = method100()
                let v181 : US14 = match v175 with Ok x -> v178 x | Error x -> v179 x
                match v181 with
                | US14_1(v349) -> (* Error *)
                    let v350 : string = $"file_system.read_link / "
                    let v351 : string = $"error': {v349} / error: {v96} / name: {v5}"
                    let v352 : string = v350 + v351 
                    (* run_target_args'
                    let v357 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v358 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v359 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v352 v358 
                    let _run_target_args'_v357 = v359 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v360 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v361 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v352 v360 
                    let _run_target_args'_v357 = v361 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v362 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v363 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v352 v362 
                    let _run_target_args'_v357 = v363 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v365 : std_io_Error = v352 |> unbox<std_io_Error>
                    let _run_target_args'_v357 = v365 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v369 : std_io_Error = v352 |> unbox<std_io_Error>
                    let _run_target_args'_v357 = v369 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v373 : std_io_Error = v352 |> unbox<std_io_Error>
                    let _run_target_args'_v357 = v373 
                    #endif
#else
                    let v377 : std_io_Error = v352 |> unbox<std_io_Error>
                    let _run_target_args'_v357 = v377 
                    #endif
                    let v380 : std_io_Error = _run_target_args'_v357 
                    (* run_target_args'
                    let v390 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v391 : string = "Err($0)"
                    let v392 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v380 v391 
                    let _run_target_args'_v390 = v392 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v393 : string = "Err($0)"
                    let v394 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v380 v393 
                    let _run_target_args'_v390 = v394 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v395 : string = "Err($0)"
                    let v396 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v380 v395 
                    let _run_target_args'_v390 = v396 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v397 : Result<std_path_PathBuf, std_io_Error> = v380 |> Error
                    let _run_target_args'_v390 = v397 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v398 : Result<std_path_PathBuf, std_io_Error> = v380 |> Error
                    let _run_target_args'_v390 = v398 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v399 : Result<std_path_PathBuf, std_io_Error> = v380 |> Error
                    let _run_target_args'_v390 = v399 
                    #endif
#else
                    let v400 : Result<std_path_PathBuf, std_io_Error> = v380 |> Error
                    let _run_target_args'_v390 = v400 
                    #endif
                    let v401 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v390 
                    v401
                | US14_0(v184) -> (* Ok *)
                    (* run_target_args'
                    let v189 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v190 : string = "$0.display()"
                    let v191 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v184 v190 
                    let _run_target_args'_v189 = v191 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v192 : string = "$0.display()"
                    let v193 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v184 v192 
                    let _run_target_args'_v189 = v193 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v194 : string = "$0.display()"
                    let v195 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v184 v194 
                    let _run_target_args'_v189 = v195 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v197 : std_path_Display = v184 |> unbox<std_path_Display>
                    let _run_target_args'_v189 = v197 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v201 : std_path_Display = v184 |> unbox<std_path_Display>
                    let _run_target_args'_v189 = v201 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v205 : std_path_Display = v184 |> unbox<std_path_Display>
                    let _run_target_args'_v189 = v205 
                    #endif
#else
                    let v209 : std_path_Display = v184 |> unbox<std_path_Display>
                    let _run_target_args'_v189 = v209 
                    #endif
                    let v212 : std_path_Display = _run_target_args'_v189 
                    let v222 : string = v212 |> string 
                    let v225 : string = method79(v222, v5)
                    (* run_target_args'
                    let v230 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v231 : string = "&*$0"
                    let v232 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v225 v231 
                    let _run_target_args'_v230 = v232 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v233 : string = "&*$0"
                    let v234 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v225 v233 
                    let _run_target_args'_v230 = v234 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v235 : string = "&*$0"
                    let v236 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v225 v235 
                    let _run_target_args'_v230 = v236 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v238 : Ref<Str> = v225 |> unbox<Ref<Str>>
                    let _run_target_args'_v230 = v238 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v242 : Ref<Str> = v225 |> unbox<Ref<Str>>
                    let _run_target_args'_v230 = v242 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v246 : Ref<Str> = v225 |> unbox<Ref<Str>>
                    let _run_target_args'_v230 = v246 
                    #endif
#else
                    let v250 : Ref<Str> = v225 |> unbox<Ref<Str>>
                    let _run_target_args'_v230 = v250 
                    #endif
                    let v253 : Ref<Str> = _run_target_args'_v230 
                    (* run_target_args'
                    let v266 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v267 : string = "String::from($0)"
                    let v268 : std_string_String = Fable.Core.RustInterop.emitRustExpr v253 v267 
                    let _run_target_args'_v266 = v268 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v269 : string = "String::from($0)"
                    let v270 : std_string_String = Fable.Core.RustInterop.emitRustExpr v253 v269 
                    let _run_target_args'_v266 = v270 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v271 : string = "String::from($0)"
                    let v272 : std_string_String = Fable.Core.RustInterop.emitRustExpr v253 v271 
                    let _run_target_args'_v266 = v272 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v274 : std_string_String = v253 |> unbox<std_string_String>
                    let _run_target_args'_v266 = v274 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v278 : std_string_String = v253 |> unbox<std_string_String>
                    let _run_target_args'_v266 = v278 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v282 : std_string_String = v253 |> unbox<std_string_String>
                    let _run_target_args'_v266 = v282 
                    #endif
#else
                    let v286 : std_string_String = v253 |> unbox<std_string_String>
                    let _run_target_args'_v266 = v286 
                    #endif
                    let v289 : std_string_String = _run_target_args'_v266 
                    (* run_target_args'
                    let v302 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v303 : string = "std::path::PathBuf::from($0)"
                    let v304 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v289 v303 
                    let _run_target_args'_v302 = v304 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v305 : string = "std::path::PathBuf::from($0)"
                    let v306 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v289 v305 
                    let _run_target_args'_v302 = v306 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v307 : string = "std::path::PathBuf::from($0)"
                    let v308 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v289 v307 
                    let _run_target_args'_v302 = v308 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v310 : std_path_PathBuf = v289 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v302 = v310 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v314 : std_path_PathBuf = v289 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v302 = v314 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v318 : std_path_PathBuf = v289 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v302 = v318 
                    #endif
#else
                    let v322 : std_path_PathBuf = v289 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v302 = v322 
                    #endif
                    let v325 : std_path_PathBuf = _run_target_args'_v302 
                    (* run_target_args'
                    let v335 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v336 : string = "Ok($0)"
                    let v337 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v325 v336 
                    let _run_target_args'_v335 = v337 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v338 : string = "Ok($0)"
                    let v339 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v325 v338 
                    let _run_target_args'_v335 = v339 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v340 : string = "Ok($0)"
                    let v341 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v325 v340 
                    let _run_target_args'_v335 = v341 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v342 : Result<std_path_PathBuf, std_io_Error> = v325 |> Ok
                    let _run_target_args'_v335 = v342 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v343 : Result<std_path_PathBuf, std_io_Error> = v325 |> Ok
                    let _run_target_args'_v335 = v343 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v344 : Result<std_path_PathBuf, std_io_Error> = v325 |> Ok
                    let _run_target_args'_v335 = v344 
                    #endif
#else
                    let v345 : Result<std_path_PathBuf, std_io_Error> = v325 |> Ok
                    let _run_target_args'_v335 = v345 
                    #endif
                    let v346 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v335 
                    v346
            else
                let v406 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v407 : string = $"path: {v0} / error: {v96} / path': {v4} / name: {v5}"
                let v408 : string = v406 + v407 
                (* run_target_args'
                let v413 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v414 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v415 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v408 v414 
                let _run_target_args'_v413 = v415 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v416 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v417 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v408 v416 
                let _run_target_args'_v413 = v417 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v418 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v419 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v408 v418 
                let _run_target_args'_v413 = v419 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v421 : std_io_Error = v408 |> unbox<std_io_Error>
                let _run_target_args'_v413 = v421 
                #endif
#if FABLE_COMPILER_PYTHON
                let v425 : std_io_Error = v408 |> unbox<std_io_Error>
                let _run_target_args'_v413 = v425 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v429 : std_io_Error = v408 |> unbox<std_io_Error>
                let _run_target_args'_v413 = v429 
                #endif
#else
                let v433 : std_io_Error = v408 |> unbox<std_io_Error>
                let _run_target_args'_v413 = v433 
                #endif
                let v436 : std_io_Error = _run_target_args'_v413 
                (* run_target_args'
                let v446 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v447 : string = "Err($0)"
                let v448 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v436 v447 
                let _run_target_args'_v446 = v448 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v449 : string = "Err($0)"
                let v450 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v436 v449 
                let _run_target_args'_v446 = v450 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v451 : string = "Err($0)"
                let v452 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v436 v451 
                let _run_target_args'_v446 = v452 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v453 : Result<std_path_PathBuf, std_io_Error> = v436 |> Error
                let _run_target_args'_v446 = v453 
                #endif
#if FABLE_COMPILER_PYTHON
                let v454 : Result<std_path_PathBuf, std_io_Error> = v436 |> Error
                let _run_target_args'_v446 = v454 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v455 : Result<std_path_PathBuf, std_io_Error> = v436 |> Error
                let _run_target_args'_v446 = v455 
                #endif
#else
                let v456 : Result<std_path_PathBuf, std_io_Error> = v436 |> Error
                let _run_target_args'_v446 = v456 
                #endif
                let v457 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v446 
                v457
        | _ ->
            let v461 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v462 : string = $"path: {v0} / error: {v96} / path': {v4} / name: {v5}"
            let v463 : string = v461 + v462 
            (* run_target_args'
            let v468 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v469 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v470 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v463 v469 
            let _run_target_args'_v468 = v470 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v471 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v472 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v463 v471 
            let _run_target_args'_v468 = v472 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v473 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v474 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v463 v473 
            let _run_target_args'_v468 = v474 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v476 : std_io_Error = v463 |> unbox<std_io_Error>
            let _run_target_args'_v468 = v476 
            #endif
#if FABLE_COMPILER_PYTHON
            let v480 : std_io_Error = v463 |> unbox<std_io_Error>
            let _run_target_args'_v468 = v480 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v484 : std_io_Error = v463 |> unbox<std_io_Error>
            let _run_target_args'_v468 = v484 
            #endif
#else
            let v488 : std_io_Error = v463 |> unbox<std_io_Error>
            let _run_target_args'_v468 = v488 
            #endif
            let v491 : std_io_Error = _run_target_args'_v468 
            (* run_target_args'
            let v501 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v502 : string = "Err($0)"
            let v503 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v491 v502 
            let _run_target_args'_v501 = v503 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v504 : string = "Err($0)"
            let v505 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v491 v504 
            let _run_target_args'_v501 = v505 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v506 : string = "Err($0)"
            let v507 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v491 v506 
            let _run_target_args'_v501 = v507 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v508 : Result<std_path_PathBuf, std_io_Error> = v491 |> Error
            let _run_target_args'_v501 = v508 
            #endif
#if FABLE_COMPILER_PYTHON
            let v509 : Result<std_path_PathBuf, std_io_Error> = v491 |> Error
            let _run_target_args'_v501 = v509 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v510 : Result<std_path_PathBuf, std_io_Error> = v491 |> Error
            let _run_target_args'_v501 = v510 
            #endif
#else
            let v511 : Result<std_path_PathBuf, std_io_Error> = v491 |> Error
            let _run_target_args'_v501 = v511 
            #endif
            let v512 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v501 
            v512
and method109 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
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
    let v45 : System.IO.FileAttributes = method106(v36)
    let v46 : System.IO.FileAttributes = method107()
    let v47 : bool = method108(v46, v45)
    if v47 then
        (* run_target_args'
        let v52 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v54 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v52 = v54 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v58 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v52 = v58 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v62 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v52 = v62 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v66 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v52 = v66 
        #endif
#if FABLE_COMPILER_PYTHON
        let v70 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v52 = v70 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v74 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v52 = v74 
        #endif
#else
        let v78 : System_IO_FileInfo = v2 |> System_IO_FileInfo 
        let _run_target_args'_v52 = v78 
        #endif
        let v81 : System_IO_FileInfo = _run_target_args'_v52 
        (* run_target_args'
        let v94 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v96 : string = null |> unbox<string>
        let _run_target_args'_v94 = v96 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v100 : string = null |> unbox<string>
        let _run_target_args'_v94 = v100 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v104 : string = null |> unbox<string>
        let _run_target_args'_v94 = v104 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v108 : string = null |> unbox<string>
        let _run_target_args'_v94 = v108 
        #endif
#if FABLE_COMPILER_PYTHON
        let v112 : string = null |> unbox<string>
        let _run_target_args'_v94 = v112 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v116 : string = null |> unbox<string>
        let _run_target_args'_v94 = v116 
        #endif
#else
        let v119 : (System_IO_FileInfo -> string) = _.LinkTarget
        let v120 : string = v119 v81
        let _run_target_args'_v94 = v120 
        #endif
        let v121 : string = _run_target_args'_v94 
        let v131 : std_path_PathBuf = v121 |> unbox<std_path_PathBuf>
        (* run_target_args'
        let v135 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v136 : string = "Ok($0)"
        let v137 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v131 v136 
        let _run_target_args'_v135 = v137 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v138 : string = "Ok($0)"
        let v139 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v131 v138 
        let _run_target_args'_v135 = v139 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v140 : string = "Ok($0)"
        let v141 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v131 v140 
        let _run_target_args'_v135 = v141 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v142 : Result<std_path_PathBuf, std_io_Error> = v131 |> Ok
        let _run_target_args'_v135 = v142 
        #endif
#if FABLE_COMPILER_PYTHON
        let v143 : Result<std_path_PathBuf, std_io_Error> = v131 |> Ok
        let _run_target_args'_v135 = v143 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v144 : Result<std_path_PathBuf, std_io_Error> = v131 |> Ok
        let _run_target_args'_v135 = v144 
        #endif
#else
        let v145 : Result<std_path_PathBuf, std_io_Error> = v131 |> Ok
        let _run_target_args'_v135 = v145 
        #endif
        let v146 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v135 
        v146
    else
        let v149 : string = $"file_system.read_link / Fsharp / "
        let v150 : string = $"The file or directory is not a reparse point. / "
        let v151 : string = v149 + v150 
        let v152 : string = $"path: {v0} / result: {v47} / path': {v2} / n: {v1}"
        let v153 : string = v151 + v152 
        (* run_target_args'
        let v158 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v159 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v160 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v153 v159 
        let _run_target_args'_v158 = v160 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v161 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v162 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v153 v161 
        let _run_target_args'_v158 = v162 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v163 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v164 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v153 v163 
        let _run_target_args'_v158 = v164 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v166 : std_io_Error = v153 |> unbox<std_io_Error>
        let _run_target_args'_v158 = v166 
        #endif
#if FABLE_COMPILER_PYTHON
        let v170 : std_io_Error = v153 |> unbox<std_io_Error>
        let _run_target_args'_v158 = v170 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v174 : std_io_Error = v153 |> unbox<std_io_Error>
        let _run_target_args'_v158 = v174 
        #endif
#else
        let v178 : std_io_Error = v153 |> unbox<std_io_Error>
        let _run_target_args'_v158 = v178 
        #endif
        let v181 : std_io_Error = _run_target_args'_v158 
        let v190 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure56(v0)
        method110(v0, v190, v1, v181, v2)
and closure57 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method109(v0, v1, v2)
and closure56 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure57(v0, v1)
and method111 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method19(v0)
    let v5 : string option = method103(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method17()
    let v35 : Mut3 = {l0 = v34} : Mut3
    (* run_target_args'
    let v40 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v41 : string = "format!(\"{:#?}\", $0)"
    let v42 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v41 
    let v43 : string = "fable_library_rust::String_::fromString($0)"
    let v44 : string = Fable.Core.RustInterop.emitRustExpr v42 v43 
    let _run_target_args'_v40 = v44 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v45 : string = "format!(\"{:#?}\", $0)"
    let v46 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v45 
    let v47 : string = "fable_library_rust::String_::fromString($0)"
    let v48 : string = Fable.Core.RustInterop.emitRustExpr v46 v47 
    let _run_target_args'_v40 = v48 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v49 : string = "format!(\"{:#?}\", $0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v49 
    let v51 : string = "fable_library_rust::String_::fromString($0)"
    let v52 : string = Fable.Core.RustInterop.emitRustExpr v50 v51 
    let _run_target_args'_v40 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : string = $"%A{v3}"
    let _run_target_args'_v40 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : string = $"%A{v3}"
    let _run_target_args'_v40 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : string = $"%A{v3}"
    let _run_target_args'_v40 = v62 
    #endif
#else
    let v66 : string = $"%A{v3}"
    let _run_target_args'_v40 = v66 
    #endif
    let v69 : string = _run_target_args'_v40 
    let v79 : string = $"{v69}"
    let v87 : unit = ()
    let v88 : (unit -> unit) = closure6(v35, v79)
    let v89 : unit = (fun () -> v88 (); v87) ()
    let v95 : string = v35.l0
    let v96 : bool = v2 >= 11uy
    if v96 then
        let v97 : string = $"file_system.read_link / "
        let v98 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v99 : string = v97 + v98 
        (* run_target_args'
        let v104 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v105 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v106 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v99 v105 
        let _run_target_args'_v104 = v106 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v107 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v108 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v99 v107 
        let _run_target_args'_v104 = v108 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v109 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v110 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v99 v109 
        let _run_target_args'_v104 = v110 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v112 : std_io_Error = v99 |> unbox<std_io_Error>
        let _run_target_args'_v104 = v112 
        #endif
#if FABLE_COMPILER_PYTHON
        let v116 : std_io_Error = v99 |> unbox<std_io_Error>
        let _run_target_args'_v104 = v116 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v120 : std_io_Error = v99 |> unbox<std_io_Error>
        let _run_target_args'_v104 = v120 
        #endif
#else
        let v124 : std_io_Error = v99 |> unbox<std_io_Error>
        let _run_target_args'_v104 = v124 
        #endif
        let v127 : std_io_Error = _run_target_args'_v104 
        (* run_target_args'
        let v137 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v138 : string = "Err($0)"
        let v139 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v127 v138 
        let _run_target_args'_v137 = v139 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v140 : string = "Err($0)"
        let v141 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v127 v140 
        let _run_target_args'_v137 = v141 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v142 : string = "Err($0)"
        let v143 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v127 v142 
        let _run_target_args'_v137 = v143 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v144 : Result<std_path_PathBuf, std_io_Error> = v127 |> Error
        let _run_target_args'_v137 = v144 
        #endif
#if FABLE_COMPILER_PYTHON
        let v145 : Result<std_path_PathBuf, std_io_Error> = v127 |> Error
        let _run_target_args'_v137 = v145 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v146 : Result<std_path_PathBuf, std_io_Error> = v127 |> Error
        let _run_target_args'_v137 = v146 
        #endif
#else
        let v147 : Result<std_path_PathBuf, std_io_Error> = v127 |> Error
        let _run_target_args'_v137 = v147 
        #endif
        let v148 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v137 
        v148
    else
        match v30 with
        | US5_0(v151) -> (* Some *)
            let v154 : string = ""
            let v155 : bool = v0 <> v154 
            if v155 then
                let v158 : uint8 = v2 + 1uy
                let v159 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v158
                let v160 : Result<std_path_PathBuf, std_io_Error> = v159 v151
                let v161 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v163 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v164 : string = "$0.map_err(|x| $1(x))"
                let v165 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v160, v161) v164 
                let _run_target_args'_v163 = v165 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v166 : string = "$0.map_err(|x| $1(x))"
                let v167 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v160, v161) v166 
                let _run_target_args'_v163 = v167 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v168 : string = "$0.map_err(|x| $1(x))"
                let v169 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v160, v161) v168 
                let _run_target_args'_v163 = v169 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v170 : Result<std_path_PathBuf, string> = match v160 with Ok x -> Ok x | Error x -> Error (v161 x)
                let _run_target_args'_v163 = v170 
                #endif
#if FABLE_COMPILER_PYTHON
                let v171 : Result<std_path_PathBuf, string> = match v160 with Ok x -> Ok x | Error x -> Error (v161 x)
                let _run_target_args'_v163 = v171 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v172 : Result<std_path_PathBuf, string> = match v160 with Ok x -> Ok x | Error x -> Error (v161 x)
                let _run_target_args'_v163 = v172 
                #endif
#else
                let v173 : Result<std_path_PathBuf, string> = match v160 with Ok x -> Ok x | Error x -> Error (v161 x)
                let _run_target_args'_v163 = v173 
                #endif
                let v174 : Result<std_path_PathBuf, string> = _run_target_args'_v163 
                let v177 : (std_path_PathBuf -> US14) = method99()
                let v178 : (string -> US14) = method100()
                let v180 : US14 = match v174 with Ok x -> v177 x | Error x -> v178 x
                match v180 with
                | US14_1(v348) -> (* Error *)
                    let v349 : string = $"file_system.read_link / "
                    let v350 : string = $"error': {v348} / error: {v95} / name: {v4}"
                    let v351 : string = v349 + v350 
                    (* run_target_args'
                    let v356 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v357 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v358 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v351 v357 
                    let _run_target_args'_v356 = v358 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v359 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v360 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v351 v359 
                    let _run_target_args'_v356 = v360 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v361 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v362 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v351 v361 
                    let _run_target_args'_v356 = v362 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v364 : std_io_Error = v351 |> unbox<std_io_Error>
                    let _run_target_args'_v356 = v364 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v368 : std_io_Error = v351 |> unbox<std_io_Error>
                    let _run_target_args'_v356 = v368 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v372 : std_io_Error = v351 |> unbox<std_io_Error>
                    let _run_target_args'_v356 = v372 
                    #endif
#else
                    let v376 : std_io_Error = v351 |> unbox<std_io_Error>
                    let _run_target_args'_v356 = v376 
                    #endif
                    let v379 : std_io_Error = _run_target_args'_v356 
                    (* run_target_args'
                    let v389 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v390 : string = "Err($0)"
                    let v391 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v379 v390 
                    let _run_target_args'_v389 = v391 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v392 : string = "Err($0)"
                    let v393 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v379 v392 
                    let _run_target_args'_v389 = v393 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v394 : string = "Err($0)"
                    let v395 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v379 v394 
                    let _run_target_args'_v389 = v395 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v396 : Result<std_path_PathBuf, std_io_Error> = v379 |> Error
                    let _run_target_args'_v389 = v396 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v397 : Result<std_path_PathBuf, std_io_Error> = v379 |> Error
                    let _run_target_args'_v389 = v397 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v398 : Result<std_path_PathBuf, std_io_Error> = v379 |> Error
                    let _run_target_args'_v389 = v398 
                    #endif
#else
                    let v399 : Result<std_path_PathBuf, std_io_Error> = v379 |> Error
                    let _run_target_args'_v389 = v399 
                    #endif
                    let v400 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v389 
                    v400
                | US14_0(v183) -> (* Ok *)
                    (* run_target_args'
                    let v188 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v189 : string = "$0.display()"
                    let v190 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v183 v189 
                    let _run_target_args'_v188 = v190 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v191 : string = "$0.display()"
                    let v192 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v183 v191 
                    let _run_target_args'_v188 = v192 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v193 : string = "$0.display()"
                    let v194 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v183 v193 
                    let _run_target_args'_v188 = v194 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v196 : std_path_Display = v183 |> unbox<std_path_Display>
                    let _run_target_args'_v188 = v196 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v200 : std_path_Display = v183 |> unbox<std_path_Display>
                    let _run_target_args'_v188 = v200 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v204 : std_path_Display = v183 |> unbox<std_path_Display>
                    let _run_target_args'_v188 = v204 
                    #endif
#else
                    let v208 : std_path_Display = v183 |> unbox<std_path_Display>
                    let _run_target_args'_v188 = v208 
                    #endif
                    let v211 : std_path_Display = _run_target_args'_v188 
                    let v221 : string = v211 |> string 
                    let v224 : string = method79(v221, v4)
                    (* run_target_args'
                    let v229 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v230 : string = "&*$0"
                    let v231 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v224 v230 
                    let _run_target_args'_v229 = v231 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v232 : string = "&*$0"
                    let v233 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v224 v232 
                    let _run_target_args'_v229 = v233 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v234 : string = "&*$0"
                    let v235 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v224 v234 
                    let _run_target_args'_v229 = v235 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v237 : Ref<Str> = v224 |> unbox<Ref<Str>>
                    let _run_target_args'_v229 = v237 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v241 : Ref<Str> = v224 |> unbox<Ref<Str>>
                    let _run_target_args'_v229 = v241 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v245 : Ref<Str> = v224 |> unbox<Ref<Str>>
                    let _run_target_args'_v229 = v245 
                    #endif
#else
                    let v249 : Ref<Str> = v224 |> unbox<Ref<Str>>
                    let _run_target_args'_v229 = v249 
                    #endif
                    let v252 : Ref<Str> = _run_target_args'_v229 
                    (* run_target_args'
                    let v265 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v266 : string = "String::from($0)"
                    let v267 : std_string_String = Fable.Core.RustInterop.emitRustExpr v252 v266 
                    let _run_target_args'_v265 = v267 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v268 : string = "String::from($0)"
                    let v269 : std_string_String = Fable.Core.RustInterop.emitRustExpr v252 v268 
                    let _run_target_args'_v265 = v269 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v270 : string = "String::from($0)"
                    let v271 : std_string_String = Fable.Core.RustInterop.emitRustExpr v252 v270 
                    let _run_target_args'_v265 = v271 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v273 : std_string_String = v252 |> unbox<std_string_String>
                    let _run_target_args'_v265 = v273 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v277 : std_string_String = v252 |> unbox<std_string_String>
                    let _run_target_args'_v265 = v277 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v281 : std_string_String = v252 |> unbox<std_string_String>
                    let _run_target_args'_v265 = v281 
                    #endif
#else
                    let v285 : std_string_String = v252 |> unbox<std_string_String>
                    let _run_target_args'_v265 = v285 
                    #endif
                    let v288 : std_string_String = _run_target_args'_v265 
                    (* run_target_args'
                    let v301 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v302 : string = "std::path::PathBuf::from($0)"
                    let v303 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v288 v302 
                    let _run_target_args'_v301 = v303 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v304 : string = "std::path::PathBuf::from($0)"
                    let v305 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v288 v304 
                    let _run_target_args'_v301 = v305 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v306 : string = "std::path::PathBuf::from($0)"
                    let v307 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v288 v306 
                    let _run_target_args'_v301 = v307 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v309 : std_path_PathBuf = v288 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v301 = v309 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v313 : std_path_PathBuf = v288 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v301 = v313 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v317 : std_path_PathBuf = v288 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v301 = v317 
                    #endif
#else
                    let v321 : std_path_PathBuf = v288 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v301 = v321 
                    #endif
                    let v324 : std_path_PathBuf = _run_target_args'_v301 
                    (* run_target_args'
                    let v334 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v335 : string = "Ok($0)"
                    let v336 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v324 v335 
                    let _run_target_args'_v334 = v336 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v337 : string = "Ok($0)"
                    let v338 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v324 v337 
                    let _run_target_args'_v334 = v338 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v339 : string = "Ok($0)"
                    let v340 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v324 v339 
                    let _run_target_args'_v334 = v340 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v341 : Result<std_path_PathBuf, std_io_Error> = v324 |> Ok
                    let _run_target_args'_v334 = v341 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v342 : Result<std_path_PathBuf, std_io_Error> = v324 |> Ok
                    let _run_target_args'_v334 = v342 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v343 : Result<std_path_PathBuf, std_io_Error> = v324 |> Ok
                    let _run_target_args'_v334 = v343 
                    #endif
#else
                    let v344 : Result<std_path_PathBuf, std_io_Error> = v324 |> Ok
                    let _run_target_args'_v334 = v344 
                    #endif
                    let v345 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v334 
                    v345
            else
                let v405 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v406 : string = $"path: {v0} / error: {v95} / path': {v0} / name: {v4}"
                let v407 : string = v405 + v406 
                (* run_target_args'
                let v412 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v413 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v414 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v407 v413 
                let _run_target_args'_v412 = v414 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v415 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v416 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v407 v415 
                let _run_target_args'_v412 = v416 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v417 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v418 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v407 v417 
                let _run_target_args'_v412 = v418 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v420 : std_io_Error = v407 |> unbox<std_io_Error>
                let _run_target_args'_v412 = v420 
                #endif
#if FABLE_COMPILER_PYTHON
                let v424 : std_io_Error = v407 |> unbox<std_io_Error>
                let _run_target_args'_v412 = v424 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v428 : std_io_Error = v407 |> unbox<std_io_Error>
                let _run_target_args'_v412 = v428 
                #endif
#else
                let v432 : std_io_Error = v407 |> unbox<std_io_Error>
                let _run_target_args'_v412 = v432 
                #endif
                let v435 : std_io_Error = _run_target_args'_v412 
                (* run_target_args'
                let v445 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v446 : string = "Err($0)"
                let v447 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v435 v446 
                let _run_target_args'_v445 = v447 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v448 : string = "Err($0)"
                let v449 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v435 v448 
                let _run_target_args'_v445 = v449 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v450 : string = "Err($0)"
                let v451 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v435 v450 
                let _run_target_args'_v445 = v451 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v452 : Result<std_path_PathBuf, std_io_Error> = v435 |> Error
                let _run_target_args'_v445 = v452 
                #endif
#if FABLE_COMPILER_PYTHON
                let v453 : Result<std_path_PathBuf, std_io_Error> = v435 |> Error
                let _run_target_args'_v445 = v453 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v454 : Result<std_path_PathBuf, std_io_Error> = v435 |> Error
                let _run_target_args'_v445 = v454 
                #endif
#else
                let v455 : Result<std_path_PathBuf, std_io_Error> = v435 |> Error
                let _run_target_args'_v445 = v455 
                #endif
                let v456 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v445 
                v456
        | _ ->
            let v460 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v461 : string = $"path: {v0} / error: {v95} / path': {v0} / name: {v4}"
            let v462 : string = v460 + v461 
            (* run_target_args'
            let v467 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v468 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v469 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v462 v468 
            let _run_target_args'_v467 = v469 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v470 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v471 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v462 v470 
            let _run_target_args'_v467 = v471 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v472 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v473 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v462 v472 
            let _run_target_args'_v467 = v473 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v475 : std_io_Error = v462 |> unbox<std_io_Error>
            let _run_target_args'_v467 = v475 
            #endif
#if FABLE_COMPILER_PYTHON
            let v479 : std_io_Error = v462 |> unbox<std_io_Error>
            let _run_target_args'_v467 = v479 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v483 : std_io_Error = v462 |> unbox<std_io_Error>
            let _run_target_args'_v467 = v483 
            #endif
#else
            let v487 : std_io_Error = v462 |> unbox<std_io_Error>
            let _run_target_args'_v467 = v487 
            #endif
            let v490 : std_io_Error = _run_target_args'_v467 
            (* run_target_args'
            let v500 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v501 : string = "Err($0)"
            let v502 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v490 v501 
            let _run_target_args'_v500 = v502 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v503 : string = "Err($0)"
            let v504 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v490 v503 
            let _run_target_args'_v500 = v504 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v505 : string = "Err($0)"
            let v506 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v490 v505 
            let _run_target_args'_v500 = v506 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v507 : Result<std_path_PathBuf, std_io_Error> = v490 |> Error
            let _run_target_args'_v500 = v507 
            #endif
#if FABLE_COMPILER_PYTHON
            let v508 : Result<std_path_PathBuf, std_io_Error> = v490 |> Error
            let _run_target_args'_v500 = v508 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v509 : Result<std_path_PathBuf, std_io_Error> = v490 |> Error
            let _run_target_args'_v500 = v509 
            #endif
#else
            let v510 : Result<std_path_PathBuf, std_io_Error> = v490 |> Error
            let _run_target_args'_v500 = v510 
            #endif
            let v511 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v500 
            v511
and method105 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
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
    let v44 : System.IO.FileAttributes = method106(v35)
    let v45 : System.IO.FileAttributes = method107()
    let v46 : bool = method108(v45, v44)
    if v46 then
        (* run_target_args'
        let v51 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v53 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v51 = v53 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v57 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v51 = v57 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v61 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v51 = v61 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v65 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v51 = v65 
        #endif
#if FABLE_COMPILER_PYTHON
        let v69 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v51 = v69 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v73 : System_IO_FileInfo = null |> unbox<System_IO_FileInfo>
        let _run_target_args'_v51 = v73 
        #endif
#else
        let v77 : System_IO_FileInfo = v0 |> System_IO_FileInfo 
        let _run_target_args'_v51 = v77 
        #endif
        let v80 : System_IO_FileInfo = _run_target_args'_v51 
        (* run_target_args'
        let v93 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v95 : string = null |> unbox<string>
        let _run_target_args'_v93 = v95 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v99 : string = null |> unbox<string>
        let _run_target_args'_v93 = v99 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v103 : string = null |> unbox<string>
        let _run_target_args'_v93 = v103 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v107 : string = null |> unbox<string>
        let _run_target_args'_v93 = v107 
        #endif
#if FABLE_COMPILER_PYTHON
        let v111 : string = null |> unbox<string>
        let _run_target_args'_v93 = v111 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v115 : string = null |> unbox<string>
        let _run_target_args'_v93 = v115 
        #endif
#else
        let v118 : (System_IO_FileInfo -> string) = _.LinkTarget
        let v119 : string = v118 v80
        let _run_target_args'_v93 = v119 
        #endif
        let v120 : string = _run_target_args'_v93 
        let v130 : std_path_PathBuf = v120 |> unbox<std_path_PathBuf>
        (* run_target_args'
        let v134 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v135 : string = "Ok($0)"
        let v136 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v130 v135 
        let _run_target_args'_v134 = v136 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v137 : string = "Ok($0)"
        let v138 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v130 v137 
        let _run_target_args'_v134 = v138 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v139 : string = "Ok($0)"
        let v140 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v130 v139 
        let _run_target_args'_v134 = v140 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v141 : Result<std_path_PathBuf, std_io_Error> = v130 |> Ok
        let _run_target_args'_v134 = v141 
        #endif
#if FABLE_COMPILER_PYTHON
        let v142 : Result<std_path_PathBuf, std_io_Error> = v130 |> Ok
        let _run_target_args'_v134 = v142 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v143 : Result<std_path_PathBuf, std_io_Error> = v130 |> Ok
        let _run_target_args'_v134 = v143 
        #endif
#else
        let v144 : Result<std_path_PathBuf, std_io_Error> = v130 |> Ok
        let _run_target_args'_v134 = v144 
        #endif
        let v145 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v134 
        v145
    else
        let v148 : string = $"file_system.read_link / Fsharp / "
        let v149 : string = $"The file or directory is not a reparse point. / "
        let v150 : string = v148 + v149 
        let v151 : string = $"path: {v0} / result: {v46} / path': {v0} / n: {v1}"
        let v152 : string = v150 + v151 
        (* run_target_args'
        let v157 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v158 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v159 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v152 v158 
        let _run_target_args'_v157 = v159 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v160 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v161 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v152 v160 
        let _run_target_args'_v157 = v161 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v162 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v163 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v152 v162 
        let _run_target_args'_v157 = v163 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v165 : std_io_Error = v152 |> unbox<std_io_Error>
        let _run_target_args'_v157 = v165 
        #endif
#if FABLE_COMPILER_PYTHON
        let v169 : std_io_Error = v152 |> unbox<std_io_Error>
        let _run_target_args'_v157 = v169 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v173 : std_io_Error = v152 |> unbox<std_io_Error>
        let _run_target_args'_v157 = v173 
        #endif
#else
        let v177 : std_io_Error = v152 |> unbox<std_io_Error>
        let _run_target_args'_v157 = v177 
        #endif
        let v180 : std_io_Error = _run_target_args'_v157 
        let v189 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure56(v0)
        method111(v0, v189, v1, v180)
and method97 (v0 : string) : Result<std_path_PathBuf, std_io_Error> =
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
            method98(v0, v6)
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
            method98(v0, v12)
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
            method98(v0, v18)
    let _run_target_args'_v2 = v20 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : uint8 = 0uy
    let v22 : Result<std_path_PathBuf, std_io_Error> = method105(v0, v21)
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : Result<std_path_PathBuf, std_io_Error> = Unchecked.defaultof<_>
    let _run_target_args'_v2 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : uint8 = 0uy
    let v25 : Result<std_path_PathBuf, std_io_Error> = method105(v0, v24)
    let _run_target_args'_v2 = v25 
    #endif
#else
    let v26 : uint8 = 0uy
    let v27 : Result<std_path_PathBuf, std_io_Error> = method105(v0, v26)
    let _run_target_args'_v2 = v27 
    #endif
    let v28 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v2 
    v28
and closure58 () (v0 : std_path_PathBuf) : US15 =
    US15_0(v0)
and method112 () : (std_path_PathBuf -> US15) =
    closure58()
and method114 (v0 : string) : string =
    v0
and method115 () : string =
    let v0 : string = ""
    v0
and method113 (v0 : string, v1 : string, v2 : string) : string =
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
    let v22 : string = method114(v2)
    let v23 : string = $"$0.replace_all(&*$1, &*$2)"
    let v24 : std_borrow_Cow<Str> = Fable.Core.RustInterop.emitRustExpr struct (v19, v22, v1) v23 
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v4 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = method115()
    let _run_target_args'_v4 = v29 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v30 : string = method115()
    let _run_target_args'_v4 = v30 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v31 : string = method115()
    let _run_target_args'_v4 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : string = method115()
    let _run_target_args'_v4 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v33 : string = method115()
    let _run_target_args'_v4 = v33 
    #endif
#else
    let v34 : string = System.Text.RegularExpressions.Regex.Replace (v2, v0, v1)
    let _run_target_args'_v4 = v34 
    #endif
    let v35 : string = _run_target_args'_v4 
    v35
and method96 (v0 : string) : string =
    let v1 : bool = v0 = ""
    if v1 then
        let v2 : string = ""
        v2
    else
        let v3 : Result<std_path_PathBuf, std_io_Error> = method97(v0)
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
        let v21 : (std_path_PathBuf -> US15) = method112()
        let v22 : US15 option = v16 |> Option.map v21 
        let v42 : US15 = US15_1
        let v43 : US15 = v22 |> Option.defaultValue v42 
        let v89 : string =
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
                let v85 : string = v75 |> string 
                v85
        let v90 : bool = v89 = ""
        let v91 : string =
            if v90 then
                v0
            else
                v89
        let v92 : string = "^\\\\\\\\\\?\\\\"
        let v93 : string = ""
        let v94 : string = method113(v92, v93, v91)
        let v95 : int32 = v94.Length
        let v96 : bool = v95 < 2
        if v96 then
            v0
        else
            let v97 : string = $"{v94.[0] |> string |> _.ToLower()}{v94.[1..]}"
            let v98 : string = "\\"
            let v99 : string = "/"
            let v100 : string = v97.Replace (v98, v99)
            v100
and closure51 () (v0 : string) : string =
    method96(v0)
and method117 () : string =
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
    let v62 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v63 : string = "format!(\"{}\", $0)"
    let v64 : std_string_String = Fable.Core.RustInterop.emitRustExpr v49 v63 
    let _run_target_args'_v62 = v64 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v65 : string = "format!(\"{}\", $0)"
    let v66 : std_string_String = Fable.Core.RustInterop.emitRustExpr v49 v65 
    let _run_target_args'_v62 = v66 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v67 : string = "format!(\"{}\", $0)"
    let v68 : std_string_String = Fable.Core.RustInterop.emitRustExpr v49 v67 
    let _run_target_args'_v62 = v68 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v70 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v62 = v70 
    #endif
#if FABLE_COMPILER_PYTHON
    let v74 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v62 = v74 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v78 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v62 = v78 
    #endif
#else
    let v82 : std_string_String = null |> unbox<std_string_String>
    let _run_target_args'_v62 = v82 
    #endif
    let v85 : std_string_String = _run_target_args'_v62 
    let v94 : string = "fable_library_rust::String_::fromString($0)"
    let v95 : string = Fable.Core.RustInterop.emitRustExpr v85 v94 
    let _run_target_args'_v4 = v95 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v97 : string = null |> unbox<string>
    let _run_target_args'_v4 = v97 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v101 : string = null |> unbox<string>
    let _run_target_args'_v4 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v104 : string = "fs"
    let v105 : IFs = Fable.Core.JsInterop.importAll v104 
    let v106 : string = "fs.realpathSync('.')"
    let v107 : string = Fable.Core.JsInterop.emitJsExpr () v106 
    let _run_target_args'_v4 = v107 
    #endif
#if FABLE_COMPILER_PYTHON
    let v109 : string = null |> unbox<string>
    let _run_target_args'_v4 = v109 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v113 : string = null |> unbox<string>
    let _run_target_args'_v4 = v113 
    #endif
#else
    let v116 : (unit -> string) = System.IO.Directory.GetCurrentDirectory
    let v117 : string = v116 ()
    let _run_target_args'_v4 = v117 
    #endif
    let v118 : string = _run_target_args'_v4 
    v118
and method118 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method119 (v0 : int32, v1 : Mut6) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method120 () : char =
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
and method121 (v0 : string) : string =
    v0
and method116 (v0 : string) : string =
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
    let v46 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v47 : string = "String::from($0)"
    let v48 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v47 
    let _run_target_args'_v46 = v48 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v49 
    let _run_target_args'_v46 = v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v33 v51 
    let _run_target_args'_v46 = v52 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v54 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v54 
    #endif
#if FABLE_COMPILER_PYTHON
    let v58 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v58 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v62 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v62 
    #endif
#else
    let v66 : std_string_String = v33 |> unbox<std_string_String>
    let _run_target_args'_v46 = v66 
    #endif
    let v69 : std_string_String = _run_target_args'_v46 
    (* run_target_args'
    let v82 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v83 : string = "std::path::PathBuf::from($0)"
    let v84 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v83 
    let _run_target_args'_v82 = v84 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v85 : string = "std::path::PathBuf::from($0)"
    let v86 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v85 
    let _run_target_args'_v82 = v86 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v87 : string = "std::path::PathBuf::from($0)"
    let v88 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v69 v87 
    let _run_target_args'_v82 = v88 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v90 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v90 
    #endif
#if FABLE_COMPILER_PYTHON
    let v94 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v94 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v98 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v98 
    #endif
#else
    let v102 : std_path_PathBuf = v69 |> unbox<std_path_PathBuf>
    let _run_target_args'_v82 = v102 
    #endif
    let v105 : std_path_PathBuf = _run_target_args'_v82 
    let v114 : string = "$0.exists()"
    let v115 : bool = Fable.Core.RustInterop.emitRustExpr v105 v114 
    let v116 : bool = v115 = false
    let v312 : string =
        if v116 then
            let v117 : string = method117()
            let v118 : string = method79(v117, v0)
            let v119 : string = method96(v118)
            let v127 : string = "/"
            let v128 : (string []) = v119.Split v127 
            let v131 : (string []) = [||]
            let v132 : int32 = v128.Length
            let v133 : Mut5 = {l0 = 0; l1 = 0; l2 = v131} : Mut5
            while method118(v132, v133) do
                let v135 : int32 = v133.l0
                let v136 : int32 =  -v135
                let v137 : int32 = v136 + v132
                let v138 : int32 = v137 - 1
                let struct (v139 : int32, v140 : (string [])) = v133.l1, v133.l2
                let v141 : string = v128.[int v138]
                let v142 : bool = ".." = v141
                let struct (v188 : int32, v189 : (string [])) =
                    if v142 then
                        let v143 : int32 = v139 + 1
                        struct (v143, v140)
                    else
                        let v144 : bool = "." = v141
                        if v144 then
                            struct (v139, v140)
                        else
                            let v145 : bool = 0 = v139
                            if v145 then
                                let v148 : string = ":"
                                let v149 : bool = v141.EndsWith (v148, false, null)
                                if v149 then
                                    let v152 : string = $"{v117.[0]}:"
                                    let v153 : (string []) = [|v152|]
                                    let v154 : int32 = v153.Length
                                    let v155 : int32 = v140.Length
                                    let v156 : int32 = v154 + v155
                                    let v157 : (string []) = Array.zeroCreate<string> (v156)
                                    let v158 : Mut6 = {l0 = 0} : Mut6
                                    while method119(v156, v158) do
                                        let v160 : int32 = v158.l0
                                        let v161 : bool = v160 < v154
                                        let v165 : string =
                                            if v161 then
                                                let v162 : string = v153.[int v160]
                                                v162
                                            else
                                                let v163 : int32 = v160 - v154
                                                let v164 : string = v140.[int v163]
                                                v164
                                        v157.[int v160] <- v165
                                        let v166 : int32 = v160 + 1
                                        v158.l0 <- v166
                                        ()
                                    struct (0, v157)
                                else
                                    let v167 : (string []) = [|v141|]
                                    let v168 : int32 = v167.Length
                                    let v169 : int32 = v140.Length
                                    let v170 : int32 = v168 + v169
                                    let v171 : (string []) = Array.zeroCreate<string> (v170)
                                    let v172 : Mut6 = {l0 = 0} : Mut6
                                    while method119(v170, v172) do
                                        let v174 : int32 = v172.l0
                                        let v175 : bool = v174 < v168
                                        let v179 : string =
                                            if v175 then
                                                let v176 : string = v167.[int v174]
                                                v176
                                            else
                                                let v177 : int32 = v174 - v168
                                                let v178 : string = v140.[int v177]
                                                v178
                                        v171.[int v174] <- v179
                                        let v180 : int32 = v174 + 1
                                        v172.l0 <- v180
                                        ()
                                    struct (0, v171)
                            else
                                let v183 : int32 = v139 - 1
                                struct (v183, v140)
                let v190 : int32 = v135 + 1
                v133.l0 <- v190
                v133.l1 <- v188
                v133.l2 <- v189
                ()
            let struct (v191 : int32, v192 : (string [])) = v133.l1, v133.l2
            let v197 : unit = ()
            let _let'_v197 =
                seq {
                    for i = 0 to v192.Length - 1 do yield v192.[i]
                    (* indent
                    ()
                indent *)
                }
                (* indent
                ()
            indent *)
            let v200 : string seq = _let'_v197 
            let v206 : char = method120()
            let v208 : (char -> string) = _.ToString()
            let v209 : string = v208 v206
            let v213 : bool = v209 = "\n"
            let v215 : string =
                if v213 then
                    method121(v209)
                else
                    v209
            let v216 : (string -> (string seq -> string)) = String.concat
            let v217 : (string seq -> string) = v216 v215
            v217 v200
        else
            let v221 : string = "std::fs::canonicalize(&*$0)"
            let v222 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v221 
            (* run_target_args'
            let v224 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v225 : string = "$0.unwrap()"
            let v226 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v222 v225 
            let _run_target_args'_v224 = v226 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v227 : string = "$0.unwrap()"
            let v228 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v222 v227 
            let _run_target_args'_v224 = v228 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v229 : string = "$0.unwrap()"
            let v230 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v222 v229 
            let _run_target_args'_v224 = v230 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v231 : std_path_PathBuf = match v222 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v224 = v231 
            #endif
#if FABLE_COMPILER_PYTHON
            let v232 : std_path_PathBuf = match v222 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v224 = v232 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v233 : std_path_PathBuf = match v222 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v224 = v233 
            #endif
#else
            let v234 : std_path_PathBuf = match v222 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v224 = v234 
            #endif
            let v235 : std_path_PathBuf = _run_target_args'_v224 
            (* run_target_args'
            let v242 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v243 : string = "$0.display()"
            let v244 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v235 v243 
            let _run_target_args'_v242 = v244 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v245 : string = "$0.display()"
            let v246 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v235 v245 
            let _run_target_args'_v242 = v246 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v247 : string = "$0.display()"
            let v248 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v235 v247 
            let _run_target_args'_v242 = v248 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v250 : std_path_Display = v235 |> unbox<std_path_Display>
            let _run_target_args'_v242 = v250 
            #endif
#if FABLE_COMPILER_PYTHON
            let v254 : std_path_Display = v235 |> unbox<std_path_Display>
            let _run_target_args'_v242 = v254 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v258 : std_path_Display = v235 |> unbox<std_path_Display>
            let _run_target_args'_v242 = v258 
            #endif
#else
            let v262 : std_path_Display = v235 |> unbox<std_path_Display>
            let _run_target_args'_v242 = v262 
            #endif
            let v265 : std_path_Display = _run_target_args'_v242 
            (* run_target_args'
            let v278 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v279 : string = "format!(\"{}\", $0)"
            let v280 : std_string_String = Fable.Core.RustInterop.emitRustExpr v265 v279 
            let _run_target_args'_v278 = v280 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v281 : string = "format!(\"{}\", $0)"
            let v282 : std_string_String = Fable.Core.RustInterop.emitRustExpr v265 v281 
            let _run_target_args'_v278 = v282 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v283 : string = "format!(\"{}\", $0)"
            let v284 : std_string_String = Fable.Core.RustInterop.emitRustExpr v265 v283 
            let _run_target_args'_v278 = v284 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v286 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v278 = v286 
            #endif
#if FABLE_COMPILER_PYTHON
            let v290 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v278 = v290 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v294 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v278 = v294 
            #endif
#else
            let v298 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v278 = v298 
            #endif
            let v301 : std_string_String = _run_target_args'_v278 
            let v310 : string = "fable_library_rust::String_::fromString($0)"
            let v311 : string = Fable.Core.RustInterop.emitRustExpr v301 v310 
            v311
    let _run_target_args'_v5 = v312 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v314 : string = null |> unbox<string>
    let _run_target_args'_v5 = v314 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v318 : string = null |> unbox<string>
    let _run_target_args'_v5 = v318 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v322 : string = null |> unbox<string>
    let _run_target_args'_v5 = v322 
    #endif
#if FABLE_COMPILER_PYTHON
    let v326 : string = null |> unbox<string>
    let _run_target_args'_v5 = v326 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v330 : string = null |> unbox<string>
    let _run_target_args'_v5 = v330 
    #endif
#else
    let v333 : (string -> string) = System.IO.Path.GetFullPath
    let v334 : string = v333 v0
    let _run_target_args'_v5 = v334 
    #endif
    let v335 : string = _run_target_args'_v5 
    v335
and closure59 () (v0 : string) : string =
    method116(v0)
and method122 (v0 : string) : string =
    let v1 : string = method116(v0)
    method96(v1)
and closure60 () (v0 : string) : string =
    method122(v0)
and closure61 () (v0 : string) : string =
    let v1 : char list = []
    let v3 : char list = '/' :: v1 
    let v8 : (char list -> (char [])) = List.toArray
    let v9 : (char []) = v8 v3
    let v12 : string = v0.TrimStart v9 
    let v46 : string = $"file:///{v12}"
    v46
and closure63 () (v0 : string) : bool =
    method34(v0)
and closure64 () (v0 : string) : bool =
    method10(v0)
and method126 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool), v4 : string) : US17 =
    let v5 : string = method79(v4, v0)
    let v6 : bool = v3 v5
    if v6 then
        US17_0(v4)
    else
        let v8 : string option = method103(v4)
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
            method126(v0, v1, v2, v3, v37)
and method125 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool)) : US17 =
    let v4 : string = method79(v1, v0)
    let v5 : bool = v3 v4
    if v5 then
        US17_0(v1)
    else
        let v7 : string option = method103(v1)
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
            method126(v0, v1, v2, v3, v36)
and method124 (v0 : US16, v1 : string, v2 : string) : US17 =
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
    method125(v1, v2, v3, v6)
and method127 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method17()
    let v11 : Mut3 = {l0 = v10} : Mut3
    let v14 : string = "{ "
    let v15 : string = $"{v14}"
    let v23 : unit = ()
    let v24 : (unit -> unit) = closure6(v11, v15)
    let v25 : unit = (fun () -> v24 (); v23) ()
    let v33 : string = "dir"
    let v34 : string = $"{v33}"
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure6(v11, v34)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v52 : string = " = "
    let v53 : string = $"{v52}"
    let v61 : unit = ()
    let v62 : (unit -> unit) = closure6(v11, v53)
    let v63 : unit = (fun () -> v62 (); v61) ()
    let v70 : string = $"{v8}"
    let v78 : unit = ()
    let v79 : (unit -> unit) = closure6(v11, v70)
    let v80 : unit = (fun () -> v79 (); v78) ()
    let v88 : string = "; "
    let v89 : string = $"{v88}"
    let v97 : unit = ()
    let v98 : (unit -> unit) = closure6(v11, v89)
    let v99 : unit = (fun () -> v98 (); v97) ()
    let v107 : string = "error"
    let v108 : string = $"{v107}"
    let v116 : unit = ()
    let v117 : (unit -> unit) = closure6(v11, v108)
    let v118 : unit = (fun () -> v117 (); v116) ()
    let v125 : string = $"{v52}"
    let v133 : unit = ()
    let v134 : (unit -> unit) = closure6(v11, v125)
    let v135 : unit = (fun () -> v134 (); v133) ()
    let v142 : string = $"{v9}"
    let v150 : unit = ()
    let v151 : (unit -> unit) = closure6(v11, v142)
    let v152 : unit = (fun () -> v151 (); v150) ()
    let v160 : string = " }"
    let v161 : string = $"{v160}"
    let v169 : unit = ()
    let v170 : (unit -> unit) = closure6(v11, v161)
    let v171 : unit = (fun () -> v170 (); v169) ()
    let v177 : string = v11.l0
    let v178 : int64 = v0.l0
    let v181 : string = " "
    let v182 : string = v6 + v181 
    let v186 : string = v182 + v7 
    let v191 : string = " #"
    let v192 : string = v186 + v191 
    let v196 : (int64 -> string) = _.ToString()
    let v197 : string = v196 v178
    let v201 : string = v192 + v197 
    let v205 : string = v201 + v181 
    let v210 : string = "file_system.get_workspace_root"
    let v211 : string = v205 + v210 
    let v216 : string = " / "
    let v217 : string = v211 + v216 
    let v221 : string = v217 + v177 
    method21(v221)
and closure65 (v0 : string, v1 : string) () : unit =
    let v2 : US0 = US0_3
    let v3 : bool = method11(v2)
    if v3 then
        let v18 : unit = ()
        let v19 : (unit -> unit) = closure0()
        let v20 : unit = (fun () -> v19 (); v18) ()
        let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
        let v59 : string = method12(v41, v42, v43, v44, v45, v46)
        let v60 : string = method49()
        let v61 : string = method127(v41, v42, v43, v44, v45, v46, v59, v60, v0, v1)
        method22(v61)
and method123 (v0 : string) : US5 =
    let v1 : US16 = US16_1
    let v2 : string = "spiral"
    let v3 : string = "workspace"
    let v4 : string = method79(v2, v3)
    let v5 : US17 = method124(v1, v4, v0)
    match v5 with
    | US17_1(v9) -> (* Error *)
        let v70 : unit = ()
        let v71 : (unit -> unit) = closure65(v0, v9)
        let v72 : unit = (fun () -> v71 (); v70) ()
        US5_1
    | US17_0(v6) -> (* Ok *)
        let v7 : string = method96(v6)
        US5_0(v7)
and closure62 () () : string =
    let v0 : string = method117()
    let v1 : US5 = method123(v0)
    let v7 : US5 =
        match v1 with
        | US5_1 -> (* None *)
            let v4 : string = __SOURCE_DIRECTORY__
            method123(v4)
        | US5_0(v2) -> (* Some *)
            US5_0(v2)
    let v13 : US5 =
        match v7 with
        | US5_1 -> (* None *)
            let v10 : string = "/workspaces"
            method123(v10)
        | US5_0(v8) -> (* Some *)
            US5_0(v8)
    let v17 : string =
        match v13 with
        | US5_1 -> (* None *)
            failwith<string> "Option does not have a value."
        | US5_0(v14) -> (* Some *)
            v14
    let v18 : string = method19(v17)
    let v19 : bool = "deps" = v18
    let v30 : string =
        if v19 then
            let v20 : string option = method103(v17)
            let v22 : string = v20 |> Option.get
            let v25 : US5 = method123(v22)
            match v25 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v26) -> (* Some *)
                v26
        else
            v17
    let v31 : string = "polyglot"
    method79(v30, v31)
and closure67 (v0 : exn) () : exn =
    v0
and method128 (v0 : string) : unit =
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
        let v74 : string = method80()
        (* run_target_args'
        let v81 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v82 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v81 = v82 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v83 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v81 = v83 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v85 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v81 = v85 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v88 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v81 = v88 
        #endif
#if FABLE_COMPILER_PYTHON
        let v89 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v81 = v89 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v90 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v81 = v90 
        #endif
#else
        let v91 : System.DateTime = System.DateTime.Now
        let _run_target_args'_v81 = v91 
        #endif
        let v92 : System.DateTime = _run_target_args'_v81 
        let v98 : (unit -> System.Guid) = System.Guid.NewGuid
        let v99 : System.Guid = v98 ()
        let v102 : System.Guid = method71(v99, v92)
        let v103 : string = $"{v74}_{v102}.txt"
        let v104 : string = method117()
        let v105 : US5 = method123(v104)
        let v111 : US5 =
            match v105 with
            | US5_1 -> (* None *)
                let v108 : string = __SOURCE_DIRECTORY__
                method123(v108)
            | US5_0(v106) -> (* Some *)
                US5_0(v106)
        let v117 : US5 =
            match v111 with
            | US5_1 -> (* None *)
                let v114 : string = "/workspaces"
                method123(v114)
            | US5_0(v112) -> (* Some *)
                US5_0(v112)
        let v121 : string =
            match v117 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v118) -> (* Some *)
                v118
        let v122 : string = method19(v121)
        let v123 : bool = "deps" = v122
        let v134 : string =
            if v123 then
                let v124 : string option = method103(v121)
                let v126 : string = v124 |> Option.get
                let v129 : US5 = method123(v126)
                match v129 with
                | US5_1 -> (* None *)
                    failwith<string> "Option does not have a value."
                | US5_0(v130) -> (* Some *)
                    v130
            else
                v121
        let v135 : string = "polyglot"
        let v136 : string = method79(v134, v135)
        let v137 : string = "target/trace"
        let v138 : string = method79(v136, v137)
        let v139 : System_IO_DirectoryInfo = method90(v138)
        let v140 : string = method79(v138, v103)
        let v141 : Async<unit> = method36(v140, v0)
        (* run_target_args'
        let v142 : unit = ()
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
        let v143 : (Async<unit> -> unit) = Async.RunSynchronously
        v143 v141
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v144 : (Async<unit> -> unit) = Async.RunSynchronously
        v144 v141
        #endif
#else
        let v145 : (Async<unit> -> unit) = Async.RunSynchronously
        v145 v141
        #endif
        // run_target_args' is_unit
        (* indent
        ()
    indent *)
    with ex ->
        let v226 : exn = ex
        let v227 : (unit -> exn) = closure67(v226)
        let v228 : string = $"file_system.trace_file / ex: %A{v227}"
        let v230 : unit = ()
        let v231 : (unit -> unit) = closure9(v228)
        let v232 : unit = (fun () -> v231 (); v230) ()
        method128(v228)
        (* indent
        ()
    indent *)
    (* try_unit
    try_unit *)
    #endif
    // run_target_args' is_unit
    ()
and closure66 () (v0 : string) : unit =
    method128(v0)
and closure68 () (v0 : bool) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut0, v39 : Mut1, v40 : Mut2, v41 : Mut3, v42 : Mut4, v43 : int64 option) = TraceState.trace_state.Value
    let v58 : (string -> unit) =
        if v0 then
            closure66()
        else
            closure2()
    v39.l0 <- v58
    ()
and method129 (v0 : string, v1 : string) : unit =
    let v2 : bool = method10(v0)
    let v3 : bool = v2 = false
    if v3 then
        let v4 : System.IDisposable = method82(v0)
        ()
    let v5 : string option = method103(v1)
    let v8 : string = ""
    let v9 : string = v5 |> Option.defaultValue v8 
    let v12 : bool = method10(v9)
    let v13 : bool = v12 = false
    if v13 then
        let v14 : System.IDisposable = method82(v9)
        ()
    let v15 : bool = method10(v1)
    let v25 : bool =
        if v15 then
            let v16 : Result<std_path_PathBuf, std_io_Error> = method97(v1)
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
    method129(v0, v1)
and closure69 () (v0 : string) : (string -> unit) =
    closure70(v0)
and closure72 (v0 : string) (v1 : string) : string =
    method79(v0, v1)
and closure71 () (v0 : string) : (string -> string) =
    closure72(v0)
let v14 : unit = ()
let v15 : (unit -> unit) = closure0()
let v16 : unit = (fun () -> v15 (); v14) ()
let v31 : (string -> Async<int64>) = closure3()
let delete_directory_async x = v31 x
let v32 : (US6 -> (string -> Async<int64>)) = closure10()
let wait_for_file_access x = v32 x
let v33 : (string -> Async<int64>) = closure13()
let wait_for_file_access_read x = v33 x
let v34 : (string -> Async<string>) = closure14()
let read_all_text_async x = v34 x
let v35 : (string -> (string -> bool)) = closure16()
let file_exists_content x = v35 x
let v36 : (string -> (string -> Async<unit>)) = closure18()
let write_all_text_async x = v36 x
let v37 : (string -> (string -> Async<unit>)) = closure20()
let write_all_text_exists x = v37 x
let v38 : (string -> Async<int64>) = closure22()
let delete_file_async x = v38 x
let v39 : (string -> (string -> Async<int64>)) = closure28()
let move_file_async x = v39 x
let v40 : (string -> Async<string option>) = closure31()
let read_all_text_retry_async x = v40 x
let v41 : (unit -> string) = closure37()
let create_temp_path () = v41 ()
let v42 : (unit -> struct (string * System.IDisposable)) = closure39()
let create_temp_dir () = v42 ()
let v43 : (string -> struct (string * System.IDisposable)) = closure48()
let create_temp_dir' x = v43 x
let v44 : (unit -> string) = closure50()
let get_source_directory () = v44 ()
let v45 : (string -> string) = closure51()
let normalize_path x = v45 x
let v46 : (string -> string) = closure59()
let get_full_path x = v46 x
let v47 : (string -> string) = closure60()
let standardize_path x = v47 x
let v48 : (string -> string) = closure61()
let new_file_uri x = v48 x
let v49 : (unit -> string) = closure62()
let get_workspace_root () = v49 ()
let v50 : (string -> unit) = closure66()
let trace_file x = v50 x
let v51 : (bool -> unit) = closure68()
let init_trace_file x = v51 x
let v52 : (string -> (string -> unit)) = closure69()
let link_directory x = v52 x
let v53 : (string -> (string -> string)) = closure71()
let (</>) x = v53 x
()
