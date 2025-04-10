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
and [<Struct>] US6 =
    | US6_0 of f0_0 : Mut0 * f0_1 : Mut1 * f0_2 : Mut2 * f0_3 : Mut3 * f0_4 : Mut4 * f0_5 : int64 option
    | US6_1
and [<Struct>] US8 =
    | US8_0
    | US8_1
    | US8_2
and [<Struct>] US9 =
    | US9_0
    | US9_1
    | US9_2
    | US9_3
    | US9_4
and [<Struct>] US7 =
    | US7_0 of f0_0 : US8 * f0_1 : US9
    | US7_1
and [<Struct>] US10 =
    | US10_0
    | US10_1 of f1_0 : string
and [<Struct>] US11 =
    | US11_0 of f0_0 : int64
    | US11_1 of f1_0 : exn
and [<Struct>] US12 =
    | US12_0 of f0_0 : int64
    | US12_1 of f1_0 : exn
and [<Struct>] US13 =
    | US13_0 of f0_0 : chrono_DateTime<chrono_Utc>
    | US13_1
and [<Struct>] US14 =
    | US14_0
    | US14_1 of f1_0 : std_string_String
and [<Struct>] US15 =
    | US15_0 of f0_0 : std_path_PathBuf
    | US15_1 of f1_0 : string
and [<Struct>] US16 =
    | US16_0 of f0_0 : std_path_PathBuf
    | US16_1
and Mut5 = {mutable l0 : int32; mutable l1 : int32; mutable l2 : (string [])}
and Mut6 = {mutable l0 : int32}
and [<Struct>] US17 =
    | US17_0
    | US17_1
and [<Struct>] US18 =
    | US18_0 of f0_0 : string
    | US18_1 of f1_0 : string
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
and closure5 () (v0 : int64) : US2 =
    US2_0(v0)
and method12 () : (int64 -> US2) =
    closure5()
and method13 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method14 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method11 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option) : string =
    (* run_target_args'
    let v195 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v198 : (int64 -> US2) = method12()
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
    let v361 : string = method13()
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
    let v384 : (int64 -> US2) = method12()
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
    let v547 : string = method13()
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
    let v572 : (int64 -> US2) = method12()
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
    let v619 : (int64 -> US2) = method12()
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
    let v782 : string = method14()
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
    let v805 : (int64 -> US2) = method12()
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
    let v968 : string = method14()
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
    let v991 : (int64 -> US2) = method12()
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
    let v1154 : string = method14()
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
    let v1177 : (int64 -> US2) = method12()
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
    let v1340 : string = method14()
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
and method16 (v0 : char) : string =
    let v1 : string = method17()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method18 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method15 () : string =
    
    
    
    
    
    let v2 : string = "Debug"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method16(v7)
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
    let v163 : string = method18()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[94m"
    let v179 : string = method18()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[94m"
    let v195 : string = method18()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[94m"
    let v211 : string = method18()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
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
and method21 (v0 : string, v1 : string) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "ex"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v62 : string = $"{v0}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure6(v3, v62)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v80 : string = "; "
    let v81 : string = $"{v80}"
    let v89 : unit = ()
    let v90 : (unit -> unit) = closure6(v3, v81)
    let v91 : unit = (fun () -> v90 (); v89) ()
    let v99 : string = "path"
    let v100 : string = $"{v99}"
    let v108 : unit = ()
    let v109 : (unit -> unit) = closure6(v3, v100)
    let v110 : unit = (fun () -> v109 (); v108) ()
    let v117 : string = $"{v44}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure6(v3, v117)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v134 : string = $"{v1}"
    let v142 : unit = ()
    let v143 : (unit -> unit) = closure6(v3, v134)
    let v144 : unit = (fun () -> v143 (); v142) ()
    let v152 : string = " }"
    let v153 : string = $"{v152}"
    let v161 : unit = ()
    let v162 : (unit -> unit) = closure6(v3, v153)
    let v163 : unit = (fun () -> v162 (); v161) ()
    let v169 : string = v3.l0
    v169
and method22 (v0 : string) : string =
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
    let v10 : string = method21(v8, v9)
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
    let v43 : string = "file_system.delete_directory_async"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
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
and closure4 (v0 : string, v1 : exn) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 1 >= v62
            v63
    let v65 : bool = v64 = false
    let v339 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method15()
            (* run_target_args'
            let v129 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = $"%A{v1}"
            let _run_target_args'_v129 = v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v135 : string = $"%A{v1}"
            let _run_target_args'_v129 = v135 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v139 : string = $"%A{v1}"
            let _run_target_args'_v129 = v139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v143 : string = $"%A{v1}"
            let _run_target_args'_v129 = v143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v147 : string = $"%A{v1}"
            let _run_target_args'_v129 = v147 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v151 : string = $"%A{v1}"
            let _run_target_args'_v129 = v151 
            #endif
#else
            let v154 : string = $"{v1.GetType ()}: {v1.Message}"
            let _run_target_args'_v129 = v154 
            #endif
            let v155 : string = _run_target_args'_v129 
            let v164 : string = method19(v0)
            let v165 : string = method20(v105, v106, v107, v108, v109, v110, v123, v124, v155, v164)
            let v180 : unit = ()
            let v181 : unit = (fun () -> v17 (); v180) ()
            let struct (v204 : Mut0, v205 : Mut1, v206 : Mut2, v207 : Mut3, v208 : Mut4, v209 : int64 option) = TraceState.trace_state.Value
            let v224 : unit = ()
            let v225 : (unit -> unit) = closure7(v204)
            let v226 : unit = (fun () -> v225 (); v224) ()
            let v229 : (string -> unit) = closure8()
            (* run_target_args'
            let v230 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v231 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v165 v231 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v232 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v165 v232 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v233 : string = v207.l0
            let v234 : bool = v233 = ""
            let v249 : string =
                if v234 then
                    v165
                else
                    let v235 : bool = v165 = ""
                    if v235 then
                        let v236 : string = v207.l0
                        v236
                    else
                        let v237 : string = v207.l0
                        let v240 : string = "\n"
                        let v241 : string = v237 + v240 
                        let v245 : string = v241 + v165 
                        v245
            (* run_target_args'
            let v254 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v255 : string = "&*$0"
            let v256 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v249 v255 
            let _run_target_args'_v254 = v256 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v257 : string = "&*$0"
            let v258 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v249 v257 
            let _run_target_args'_v254 = v258 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v259 : string = "&*$0"
            let v260 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v249 v259 
            let _run_target_args'_v254 = v260 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v262 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v262 
            #endif
#if FABLE_COMPILER_PYTHON
            let v266 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v266 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v270 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v270 
            #endif
#else
            let v274 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v274 
            #endif
            let v277 : Ref<Str> = _run_target_args'_v254 
            let v286 : string = $"$0.chars()"
            let v287 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v277 v286 
            let v288 : string = "$0"
            let v289 : _ = Fable.Core.RustInterop.emitRustExpr v287 v288 
            let v290 : string = "$0.collect::<Vec<_>>()"
            let v291 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v289 v290 
            let v292 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v293 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v291 v292 
            let v294 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v295 : bool = Fable.Core.RustInterop.emitRustExpr v293 v294 
            let v296 : string = "x"
            let v297 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v296 
            let v298 : string = "String::from_iter($0)"
            let v299 : std_string_String = Fable.Core.RustInterop.emitRustExpr v297 v298 
            let v300 : string = "true; $0 }).collect::<Vec<_>>()"
            let v301 : bool = Fable.Core.RustInterop.emitRustExpr v299 v300 
            let v302 : string = "_vec_map"
            let v303 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v302 
            let v304 : string = "$0.len()"
            let v305 : unativeint = Fable.Core.RustInterop.emitRustExpr v303 v304 
            let v311 : int32 = v305 |> int32 
            let v321 : string = ""
            let v322 : bool = v165 <> v321 
            let v326 : bool =
                if v322 then
                    let v325 : bool = v311 <= 1
                    v325
                else
                    false
            if v326 then
                v207.l0 <- v249
                ()
            else
                v207.l0 <- v321
                let v327 : string = "true; $0.into_iter().for_each(|x| { //"
                let v328 : bool = Fable.Core.RustInterop.emitRustExpr v303 v327 
                let v329 : string = "x"
                let v330 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v329 
                let v331 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr v330 v331 
                let v333 : string = $"true"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
                let v335 : string = "true; }); //"
                let v336 : bool = Fable.Core.RustInterop.emitRustExpr () v335 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v229 v165
            #endif
#if FABLE_COMPILER_PYTHON
            v229 v165
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v229 v165
            #endif
#else
            v229 v165
            #endif
            // run_target_args' is_unit
            let v337 : (string -> unit) = v205.l0
            v337 v165
            US6_0(v204, v205, v206, v207, v208, v209)
    
    ()
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
                let v28819 : bool = true
                method9(v28819, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v29553 : exn = ex
                let v29554 : int64 = v1 % 100L
                let v29555 : bool = v29554 = 0L
                if v29555 then
                    let v29907 : unit = ()
                    let v29908 : (unit -> unit) = closure4(v0, v29553)
                    let v29909 : unit = (fun () -> v29908 (); v29907) ()
                    ()
                (* run_target_args'
                let v30268 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30269 : (int32 -> Async<unit>) = Async.Sleep
                let v30270 : Async<unit> = v30269 10
                let _run_target_args'_v30268 = v30270 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v30271 : (int32 -> Async<unit>) = Async.Sleep
                let v30272 : Async<unit> = v30271 10
                let _run_target_args'_v30268 = v30272 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v30273 : (int32 -> Async<unit>) = Async.Sleep
                let v30274 : Async<unit> = v30273 10
                let _run_target_args'_v30268 = v30274 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v30275 : (int32 -> Async<unit>) = Async.Sleep
                let v30276 : Async<unit> = v30275 10
                let _run_target_args'_v30268 = v30276 
                #endif
#if FABLE_COMPILER_PYTHON
                let v30277 : (int32 -> Async<unit>) = Async.Sleep
                let v30278 : Async<unit> = v30277 10
                let _run_target_args'_v30268 = v30278 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v30279 : (int32 -> Async<unit>) = Async.Sleep
                let v30280 : Async<unit> = v30279 10
                let _run_target_args'_v30268 = v30280 
                #endif
#else
                let v30281 : (int32 -> Async<unit>) = Async.Sleep
                let v30282 : Async<unit> = v30281 10
                let _run_target_args'_v30268 = v30282 
                #endif
                let v30283 : Async<unit> = _run_target_args'_v30268 
                do! v30283 
                let v30289 : int64 = v1 + 1L
                let v30290 : Async<int64> = method7(v0, v30289)
                return! v30290 
                (* indent
                ()
            indent *)
            (* try_unit
            let v31030 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v59828 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v59828 
    #endif
#if FABLE_COMPILER_PYTHON
    let v59830 : unit = ()
    let _let'_v59830 =
        async {
            try
                let v88629 : bool = true
                method9(v88629, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v89363 : exn = ex
                let v89364 : int64 = v1 % 100L
                let v89365 : bool = v89364 = 0L
                if v89365 then
                    let v89717 : unit = ()
                    let v89718 : (unit -> unit) = closure4(v0, v89363)
                    let v89719 : unit = (fun () -> v89718 (); v89717) ()
                    ()
                (* run_target_args'
                let v90078 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v90079 : (int32 -> Async<unit>) = Async.Sleep
                let v90080 : Async<unit> = v90079 10
                let _run_target_args'_v90078 = v90080 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v90081 : (int32 -> Async<unit>) = Async.Sleep
                let v90082 : Async<unit> = v90081 10
                let _run_target_args'_v90078 = v90082 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v90083 : (int32 -> Async<unit>) = Async.Sleep
                let v90084 : Async<unit> = v90083 10
                let _run_target_args'_v90078 = v90084 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v90085 : (int32 -> Async<unit>) = Async.Sleep
                let v90086 : Async<unit> = v90085 10
                let _run_target_args'_v90078 = v90086 
                #endif
#if FABLE_COMPILER_PYTHON
                let v90087 : (int32 -> Async<unit>) = Async.Sleep
                let v90088 : Async<unit> = v90087 10
                let _run_target_args'_v90078 = v90088 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v90089 : (int32 -> Async<unit>) = Async.Sleep
                let v90090 : Async<unit> = v90089 10
                let _run_target_args'_v90078 = v90090 
                #endif
#else
                let v90091 : (int32 -> Async<unit>) = Async.Sleep
                let v90092 : Async<unit> = v90091 10
                let _run_target_args'_v90078 = v90092 
                #endif
                let v90093 : Async<unit> = _run_target_args'_v90078 
                do! v90093 
                let v90099 : int64 = v1 + 1L
                let v90100 : Async<int64> = method7(v0, v90099)
                return! v90100 
                (* indent
                ()
            indent *)
            (* try_unit
            let v90840 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v119638 : Async<int64> = _let'_v59830 
    let _run_target_args'_v6 = v119638 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v119640 : unit = ()
    let _let'_v119640 =
        async {
            try
                let v148439 : bool = true
                method9(v148439, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v149173 : exn = ex
                let v149174 : int64 = v1 % 100L
                let v149175 : bool = v149174 = 0L
                if v149175 then
                    let v149527 : unit = ()
                    let v149528 : (unit -> unit) = closure4(v0, v149173)
                    let v149529 : unit = (fun () -> v149528 (); v149527) ()
                    ()
                (* run_target_args'
                let v149888 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v149889 : (int32 -> Async<unit>) = Async.Sleep
                let v149890 : Async<unit> = v149889 10
                let _run_target_args'_v149888 = v149890 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v149891 : (int32 -> Async<unit>) = Async.Sleep
                let v149892 : Async<unit> = v149891 10
                let _run_target_args'_v149888 = v149892 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v149893 : (int32 -> Async<unit>) = Async.Sleep
                let v149894 : Async<unit> = v149893 10
                let _run_target_args'_v149888 = v149894 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v149895 : (int32 -> Async<unit>) = Async.Sleep
                let v149896 : Async<unit> = v149895 10
                let _run_target_args'_v149888 = v149896 
                #endif
#if FABLE_COMPILER_PYTHON
                let v149897 : (int32 -> Async<unit>) = Async.Sleep
                let v149898 : Async<unit> = v149897 10
                let _run_target_args'_v149888 = v149898 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v149899 : (int32 -> Async<unit>) = Async.Sleep
                let v149900 : Async<unit> = v149899 10
                let _run_target_args'_v149888 = v149900 
                #endif
#else
                let v149901 : (int32 -> Async<unit>) = Async.Sleep
                let v149902 : Async<unit> = v149901 10
                let _run_target_args'_v149888 = v149902 
                #endif
                let v149903 : Async<unit> = _run_target_args'_v149888 
                do! v149903 
                let v149909 : int64 = v1 + 1L
                let v149910 : Async<int64> = method7(v0, v149909)
                return! v149910 
                (* indent
                ()
            indent *)
            (* try_unit
            let v150650 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v179448 : Async<int64> = _let'_v119640 
    let _run_target_args'_v6 = v179448 
    #endif
#else
    let v179450 : unit = ()
    let _let'_v179450 =
        async {
            try
                let v208249 : bool = true
                method9(v208249, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v208983 : exn = ex
                let v208984 : int64 = v1 % 100L
                let v208985 : bool = v208984 = 0L
                if v208985 then
                    let v209337 : unit = ()
                    let v209338 : (unit -> unit) = closure4(v0, v208983)
                    let v209339 : unit = (fun () -> v209338 (); v209337) ()
                    ()
                (* run_target_args'
                let v209698 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v209699 : (int32 -> Async<unit>) = Async.Sleep
                let v209700 : Async<unit> = v209699 10
                let _run_target_args'_v209698 = v209700 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v209701 : (int32 -> Async<unit>) = Async.Sleep
                let v209702 : Async<unit> = v209701 10
                let _run_target_args'_v209698 = v209702 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v209703 : (int32 -> Async<unit>) = Async.Sleep
                let v209704 : Async<unit> = v209703 10
                let _run_target_args'_v209698 = v209704 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v209705 : (int32 -> Async<unit>) = Async.Sleep
                let v209706 : Async<unit> = v209705 10
                let _run_target_args'_v209698 = v209706 
                #endif
#if FABLE_COMPILER_PYTHON
                let v209707 : (int32 -> Async<unit>) = Async.Sleep
                let v209708 : Async<unit> = v209707 10
                let _run_target_args'_v209698 = v209708 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v209709 : (int32 -> Async<unit>) = Async.Sleep
                let v209710 : Async<unit> = v209709 10
                let _run_target_args'_v209698 = v209710 
                #endif
#else
                let v209711 : (int32 -> Async<unit>) = Async.Sleep
                let v209712 : Async<unit> = v209711 10
                let _run_target_args'_v209698 = v209712 
                #endif
                let v209713 : Async<unit> = _run_target_args'_v209698 
                do! v209713 
                let v209719 : int64 = v1 + 1L
                let v209720 : Async<int64> = method7(v0, v209719)
                return! v209720 
                (* indent
                ()
            indent *)
            (* try_unit
            let v210460 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v239258 : Async<int64> = _let'_v179450 
    let _run_target_args'_v6 = v239258 
    #endif
    let v239259 : Async<int64> = _run_target_args'_v6 
    v239259
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
and method27 (v0 : string, v1 : int64, v2 : string) : string =
    let v3 : string = method17()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "path"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure6(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure6(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v63 : string = $"{v0}"
    let v71 : unit = ()
    let v72 : (unit -> unit) = closure6(v4, v63)
    let v73 : unit = (fun () -> v72 (); v71) ()
    let v81 : string = "; "
    let v82 : string = $"{v81}"
    let v90 : unit = ()
    let v91 : (unit -> unit) = closure6(v4, v82)
    let v92 : unit = (fun () -> v91 (); v90) ()
    let v100 : string = "retry"
    let v101 : string = $"{v100}"
    let v109 : unit = ()
    let v110 : (unit -> unit) = closure6(v4, v101)
    let v111 : unit = (fun () -> v110 (); v109) ()
    let v118 : string = $"{v45}"
    let v126 : unit = ()
    let v127 : (unit -> unit) = closure6(v4, v118)
    let v128 : unit = (fun () -> v127 (); v126) ()
    let v138 : string = $"{v1}"
    let v146 : unit = ()
    let v147 : (unit -> unit) = closure6(v4, v138)
    let v148 : unit = (fun () -> v147 (); v146) ()
    let v155 : string = $"{v81}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure6(v4, v155)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v173 : string = "ex"
    let v174 : string = $"{v173}"
    let v182 : unit = ()
    let v183 : (unit -> unit) = closure6(v4, v174)
    let v184 : unit = (fun () -> v183 (); v182) ()
    let v191 : string = $"{v45}"
    let v199 : unit = ()
    let v200 : (unit -> unit) = closure6(v4, v191)
    let v201 : unit = (fun () -> v200 (); v199) ()
    let v208 : string = $"{v2}"
    let v216 : unit = ()
    let v217 : (unit -> unit) = closure6(v4, v208)
    let v218 : unit = (fun () -> v217 (); v216) ()
    let v226 : string = " }"
    let v227 : string = $"{v226}"
    let v235 : unit = ()
    let v236 : (unit -> unit) = closure6(v4, v227)
    let v237 : unit = (fun () -> v236 (); v235) ()
    let v243 : string = v4.l0
    v243
and method26 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : int64, v10 : string) : string =
    let v11 : string = method27(v8, v9, v10)
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
    let v44 : string = "file_system.wait_for_file_access"
    let v45 : string = v39 + v44 
    let v50 : string = " / "
    let v51 : string = v45 + v50 
    let v55 : string = v51 + v11 
    method22(v55)
and closure12 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure0()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
    let v60 : US0 = v46.l0
    let v61 : bool = v44.l0
    let v62 : bool = v61 = false
    let v65 : bool =
        if v62 then
            false
        else
            let v63 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v60
            let v64 : bool = 1 >= v63
            v64
    let v66 : bool = v65 = false
    let v340 : US6 =
        if v66 then
            US6_1
        else
            let v82 : unit = ()
            let v83 : unit = (fun () -> v18 (); v82) ()
            let struct (v106 : Mut0, v107 : Mut1, v108 : Mut2, v109 : Mut3, v110 : Mut4, v111 : int64 option) = TraceState.trace_state.Value
            let v124 : string = method11(v106, v107, v108, v109, v110, v111)
            let v125 : string = method15()
            let v126 : string = method19(v0)
            (* run_target_args'
            let v131 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v133 : string = $"%A{v2}"
            let _run_target_args'_v131 = v133 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v137 : string = $"%A{v2}"
            let _run_target_args'_v131 = v137 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v141 : string = $"%A{v2}"
            let _run_target_args'_v131 = v141 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v145 : string = $"%A{v2}"
            let _run_target_args'_v131 = v145 
            #endif
#if FABLE_COMPILER_PYTHON
            let v149 : string = $"%A{v2}"
            let _run_target_args'_v131 = v149 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v153 : string = $"%A{v2}"
            let _run_target_args'_v131 = v153 
            #endif
#else
            let v156 : string = $"{v2.GetType ()}: {v2.Message}"
            let _run_target_args'_v131 = v156 
            #endif
            let v157 : string = _run_target_args'_v131 
            let v166 : string = method26(v106, v107, v108, v109, v110, v111, v124, v125, v126, v1, v157)
            let v181 : unit = ()
            let v182 : unit = (fun () -> v18 (); v181) ()
            let struct (v205 : Mut0, v206 : Mut1, v207 : Mut2, v208 : Mut3, v209 : Mut4, v210 : int64 option) = TraceState.trace_state.Value
            let v225 : unit = ()
            let v226 : (unit -> unit) = closure7(v205)
            let v227 : unit = (fun () -> v226 (); v225) ()
            let v230 : (string -> unit) = closure8()
            (* run_target_args'
            let v231 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v232 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v166 v232 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v233 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v166 v233 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v234 : string = v208.l0
            let v235 : bool = v234 = ""
            let v250 : string =
                if v235 then
                    v166
                else
                    let v236 : bool = v166 = ""
                    if v236 then
                        let v237 : string = v208.l0
                        v237
                    else
                        let v238 : string = v208.l0
                        let v241 : string = "\n"
                        let v242 : string = v238 + v241 
                        let v246 : string = v242 + v166 
                        v246
            (* run_target_args'
            let v255 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v256 : string = "&*$0"
            let v257 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v250 v256 
            let _run_target_args'_v255 = v257 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v258 : string = "&*$0"
            let v259 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v250 v258 
            let _run_target_args'_v255 = v259 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v260 : string = "&*$0"
            let v261 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v250 v260 
            let _run_target_args'_v255 = v261 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v263 : Ref<Str> = v250 |> unbox<Ref<Str>>
            let _run_target_args'_v255 = v263 
            #endif
#if FABLE_COMPILER_PYTHON
            let v267 : Ref<Str> = v250 |> unbox<Ref<Str>>
            let _run_target_args'_v255 = v267 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v271 : Ref<Str> = v250 |> unbox<Ref<Str>>
            let _run_target_args'_v255 = v271 
            #endif
#else
            let v275 : Ref<Str> = v250 |> unbox<Ref<Str>>
            let _run_target_args'_v255 = v275 
            #endif
            let v278 : Ref<Str> = _run_target_args'_v255 
            let v287 : string = $"$0.chars()"
            let v288 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v278 v287 
            let v289 : string = "$0"
            let v290 : _ = Fable.Core.RustInterop.emitRustExpr v288 v289 
            let v291 : string = "$0.collect::<Vec<_>>()"
            let v292 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v290 v291 
            let v293 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v294 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v292 v293 
            let v295 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v296 : bool = Fable.Core.RustInterop.emitRustExpr v294 v295 
            let v297 : string = "x"
            let v298 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v297 
            let v299 : string = "String::from_iter($0)"
            let v300 : std_string_String = Fable.Core.RustInterop.emitRustExpr v298 v299 
            let v301 : string = "true; $0 }).collect::<Vec<_>>()"
            let v302 : bool = Fable.Core.RustInterop.emitRustExpr v300 v301 
            let v303 : string = "_vec_map"
            let v304 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v303 
            let v305 : string = "$0.len()"
            let v306 : unativeint = Fable.Core.RustInterop.emitRustExpr v304 v305 
            let v312 : int32 = v306 |> int32 
            let v322 : string = ""
            let v323 : bool = v166 <> v322 
            let v327 : bool =
                if v323 then
                    let v326 : bool = v312 <= 1
                    v326
                else
                    false
            if v327 then
                v208.l0 <- v250
                ()
            else
                v208.l0 <- v322
                let v328 : string = "true; $0.into_iter().for_each(|x| { //"
                let v329 : bool = Fable.Core.RustInterop.emitRustExpr v304 v328 
                let v330 : string = "x"
                let v331 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v330 
                let v332 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr v331 v332 
                let v334 : string = $"true"
                let v335 : bool = Fable.Core.RustInterop.emitRustExpr () v334 
                let v336 : string = "true; }); //"
                let v337 : bool = Fable.Core.RustInterop.emitRustExpr () v336 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v230 v166
            #endif
#if FABLE_COMPILER_PYTHON
            v230 v166
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v230 v166
            #endif
#else
            v230 v166
            #endif
            // run_target_args' is_unit
            let v338 : (string -> unit) = v206.l0
            v338 v166
            US6_0(v205, v206, v207, v208, v209, v210)
    
    ()
and method25 (v0 : US7, v1 : string, v2 : int64, v3 : US9, v4 : US8) : Async<int64> =
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
                let v31144 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v31146 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v31144 = v31146 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v31150 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v31144 = v31150 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v31154 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v31144 = v31154 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v31158 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v31144 = v31158 
                #endif
#if FABLE_COMPILER_PYTHON
                let v31162 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v31144 = v31162 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v31166 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v31144 = v31166 
                #endif
#else
                let v31169 : System.IO.FileMode = System.IO.FileMode.Open
                let v31175 : System.IO.FileAccess =
                    match v4 with
                    | US8_0 -> (* AccessRead *)
                        let v31170 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v31170
                    | US8_2 -> (* AccessReadWrite *)
                        let v31172 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v31172
                    | US8_1 -> (* AccessWrite *)
                        let v31171 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v31171
                let v31185 : System.IO.FileShare =
                    match v3 with
                    | US9_4 -> (* ShareDelete *)
                        let v31180 : System.IO.FileShare = System.IO.FileShare.Delete
                        v31180
                    | US9_0 -> (* ShareNone *)
                        let v31176 : System.IO.FileShare = System.IO.FileShare.None
                        v31176
                    | US9_1 -> (* ShareRead *)
                        let v31177 : System.IO.FileShare = System.IO.FileShare.Read
                        v31177
                    | US9_3 -> (* ShareReadWrite *)
                        let v31179 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v31179
                    | US9_2 -> (* ShareWrite *)
                        let v31178 : System.IO.FileShare = System.IO.FileShare.Write
                        v31178
                let v31186 : System.IO.FileStream = new System.IO.FileStream (v1, v31169, v31175, v31185)
                let _run_target_args'_v31144 = v31186 
                #endif
                let v31187 : System.IO.FileStream = _run_target_args'_v31144 
                use v31187 = v31187 
                let v31196 : System.IO.FileStream = v31187 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v31988 : exn = ex
                let v31989 : bool = v2 > 0L
                let v31992 : bool =
                    if v31989 then
                        let v31990 : int64 = v2 % 100L
                        let v31991 : bool = v31990 = 0L
                        v31991
                    else
                        false
                if v31992 then
                    let v32344 : unit = ()
                    let v32345 : (unit -> unit) = closure12(v1, v2, v31988)
                    let v32346 : unit = (fun () -> v32345 (); v32344) ()
                    ()
                (* run_target_args'
                let v32705 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v32706 : (int32 -> Async<unit>) = Async.Sleep
                let v32707 : Async<unit> = v32706 10
                let _run_target_args'_v32705 = v32707 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v32708 : (int32 -> Async<unit>) = Async.Sleep
                let v32709 : Async<unit> = v32708 10
                let _run_target_args'_v32705 = v32709 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v32710 : (int32 -> Async<unit>) = Async.Sleep
                let v32711 : Async<unit> = v32710 10
                let _run_target_args'_v32705 = v32711 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v32712 : (int32 -> Async<unit>) = Async.Sleep
                let v32713 : Async<unit> = v32712 10
                let _run_target_args'_v32705 = v32713 
                #endif
#if FABLE_COMPILER_PYTHON
                let v32714 : (int32 -> Async<unit>) = Async.Sleep
                let v32715 : Async<unit> = v32714 10
                let _run_target_args'_v32705 = v32715 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v32716 : (int32 -> Async<unit>) = Async.Sleep
                let v32717 : Async<unit> = v32716 10
                let _run_target_args'_v32705 = v32717 
                #endif
#else
                let v32718 : (int32 -> Async<unit>) = Async.Sleep
                let v32719 : Async<unit> = v32718 10
                let _run_target_args'_v32705 = v32719 
                #endif
                let v32720 : Async<unit> = _run_target_args'_v32705 
                do! v32720 
                let v32726 : int64 = v2 + 1L
                let v32727 : Async<int64> = method24(v0, v1, v32726)
                return! v32727 
                (* indent
                ()
            indent *)
            (* try_unit
            let v33469 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v64529 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v64529 
    #endif
#if FABLE_COMPILER_PYTHON
    let v64531 : unit = ()
    let _let'_v64531 =
        async {
            try
                (* run_target_args'
                let v95652 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v95654 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v95652 = v95654 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v95658 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v95652 = v95658 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v95662 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v95652 = v95662 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v95666 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v95652 = v95666 
                #endif
#if FABLE_COMPILER_PYTHON
                let v95670 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v95652 = v95670 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v95674 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v95652 = v95674 
                #endif
#else
                let v95677 : System.IO.FileMode = System.IO.FileMode.Open
                let v95683 : System.IO.FileAccess =
                    match v4 with
                    | US8_0 -> (* AccessRead *)
                        let v95678 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v95678
                    | US8_2 -> (* AccessReadWrite *)
                        let v95680 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v95680
                    | US8_1 -> (* AccessWrite *)
                        let v95679 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v95679
                let v95693 : System.IO.FileShare =
                    match v3 with
                    | US9_4 -> (* ShareDelete *)
                        let v95688 : System.IO.FileShare = System.IO.FileShare.Delete
                        v95688
                    | US9_0 -> (* ShareNone *)
                        let v95684 : System.IO.FileShare = System.IO.FileShare.None
                        v95684
                    | US9_1 -> (* ShareRead *)
                        let v95685 : System.IO.FileShare = System.IO.FileShare.Read
                        v95685
                    | US9_3 -> (* ShareReadWrite *)
                        let v95687 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v95687
                    | US9_2 -> (* ShareWrite *)
                        let v95686 : System.IO.FileShare = System.IO.FileShare.Write
                        v95686
                let v95694 : System.IO.FileStream = new System.IO.FileStream (v1, v95677, v95683, v95693)
                let _run_target_args'_v95652 = v95694 
                #endif
                let v95695 : System.IO.FileStream = _run_target_args'_v95652 
                use v95695 = v95695 
                let v95704 : System.IO.FileStream = v95695 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v96496 : exn = ex
                let v96497 : bool = v2 > 0L
                let v96500 : bool =
                    if v96497 then
                        let v96498 : int64 = v2 % 100L
                        let v96499 : bool = v96498 = 0L
                        v96499
                    else
                        false
                if v96500 then
                    let v96852 : unit = ()
                    let v96853 : (unit -> unit) = closure12(v1, v2, v96496)
                    let v96854 : unit = (fun () -> v96853 (); v96852) ()
                    ()
                (* run_target_args'
                let v97213 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v97214 : (int32 -> Async<unit>) = Async.Sleep
                let v97215 : Async<unit> = v97214 10
                let _run_target_args'_v97213 = v97215 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v97216 : (int32 -> Async<unit>) = Async.Sleep
                let v97217 : Async<unit> = v97216 10
                let _run_target_args'_v97213 = v97217 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v97218 : (int32 -> Async<unit>) = Async.Sleep
                let v97219 : Async<unit> = v97218 10
                let _run_target_args'_v97213 = v97219 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v97220 : (int32 -> Async<unit>) = Async.Sleep
                let v97221 : Async<unit> = v97220 10
                let _run_target_args'_v97213 = v97221 
                #endif
#if FABLE_COMPILER_PYTHON
                let v97222 : (int32 -> Async<unit>) = Async.Sleep
                let v97223 : Async<unit> = v97222 10
                let _run_target_args'_v97213 = v97223 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v97224 : (int32 -> Async<unit>) = Async.Sleep
                let v97225 : Async<unit> = v97224 10
                let _run_target_args'_v97213 = v97225 
                #endif
#else
                let v97226 : (int32 -> Async<unit>) = Async.Sleep
                let v97227 : Async<unit> = v97226 10
                let _run_target_args'_v97213 = v97227 
                #endif
                let v97228 : Async<unit> = _run_target_args'_v97213 
                do! v97228 
                let v97234 : int64 = v2 + 1L
                let v97235 : Async<int64> = method24(v0, v1, v97234)
                return! v97235 
                (* indent
                ()
            indent *)
            (* try_unit
            let v97977 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v129037 : Async<int64> = _let'_v64531 
    let _run_target_args'_v9 = v129037 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v129039 : unit = ()
    let _let'_v129039 =
        async {
            try
                (* run_target_args'
                let v160160 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v160162 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v160160 = v160162 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v160166 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v160160 = v160166 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v160170 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v160160 = v160170 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v160174 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v160160 = v160174 
                #endif
#if FABLE_COMPILER_PYTHON
                let v160178 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v160160 = v160178 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v160182 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v160160 = v160182 
                #endif
#else
                let v160185 : System.IO.FileMode = System.IO.FileMode.Open
                let v160191 : System.IO.FileAccess =
                    match v4 with
                    | US8_0 -> (* AccessRead *)
                        let v160186 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v160186
                    | US8_2 -> (* AccessReadWrite *)
                        let v160188 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v160188
                    | US8_1 -> (* AccessWrite *)
                        let v160187 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v160187
                let v160201 : System.IO.FileShare =
                    match v3 with
                    | US9_4 -> (* ShareDelete *)
                        let v160196 : System.IO.FileShare = System.IO.FileShare.Delete
                        v160196
                    | US9_0 -> (* ShareNone *)
                        let v160192 : System.IO.FileShare = System.IO.FileShare.None
                        v160192
                    | US9_1 -> (* ShareRead *)
                        let v160193 : System.IO.FileShare = System.IO.FileShare.Read
                        v160193
                    | US9_3 -> (* ShareReadWrite *)
                        let v160195 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v160195
                    | US9_2 -> (* ShareWrite *)
                        let v160194 : System.IO.FileShare = System.IO.FileShare.Write
                        v160194
                let v160202 : System.IO.FileStream = new System.IO.FileStream (v1, v160185, v160191, v160201)
                let _run_target_args'_v160160 = v160202 
                #endif
                let v160203 : System.IO.FileStream = _run_target_args'_v160160 
                use v160203 = v160203 
                let v160212 : System.IO.FileStream = v160203 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v161004 : exn = ex
                let v161005 : bool = v2 > 0L
                let v161008 : bool =
                    if v161005 then
                        let v161006 : int64 = v2 % 100L
                        let v161007 : bool = v161006 = 0L
                        v161007
                    else
                        false
                if v161008 then
                    let v161360 : unit = ()
                    let v161361 : (unit -> unit) = closure12(v1, v2, v161004)
                    let v161362 : unit = (fun () -> v161361 (); v161360) ()
                    ()
                (* run_target_args'
                let v161721 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v161722 : (int32 -> Async<unit>) = Async.Sleep
                let v161723 : Async<unit> = v161722 10
                let _run_target_args'_v161721 = v161723 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v161724 : (int32 -> Async<unit>) = Async.Sleep
                let v161725 : Async<unit> = v161724 10
                let _run_target_args'_v161721 = v161725 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v161726 : (int32 -> Async<unit>) = Async.Sleep
                let v161727 : Async<unit> = v161726 10
                let _run_target_args'_v161721 = v161727 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v161728 : (int32 -> Async<unit>) = Async.Sleep
                let v161729 : Async<unit> = v161728 10
                let _run_target_args'_v161721 = v161729 
                #endif
#if FABLE_COMPILER_PYTHON
                let v161730 : (int32 -> Async<unit>) = Async.Sleep
                let v161731 : Async<unit> = v161730 10
                let _run_target_args'_v161721 = v161731 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v161732 : (int32 -> Async<unit>) = Async.Sleep
                let v161733 : Async<unit> = v161732 10
                let _run_target_args'_v161721 = v161733 
                #endif
#else
                let v161734 : (int32 -> Async<unit>) = Async.Sleep
                let v161735 : Async<unit> = v161734 10
                let _run_target_args'_v161721 = v161735 
                #endif
                let v161736 : Async<unit> = _run_target_args'_v161721 
                do! v161736 
                let v161742 : int64 = v2 + 1L
                let v161743 : Async<int64> = method24(v0, v1, v161742)
                return! v161743 
                (* indent
                ()
            indent *)
            (* try_unit
            let v162485 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v193545 : Async<int64> = _let'_v129039 
    let _run_target_args'_v9 = v193545 
    #endif
#else
    let v193547 : unit = ()
    let _let'_v193547 =
        async {
            try
                (* run_target_args'
                let v224668 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v224670 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v224668 = v224670 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v224674 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v224668 = v224674 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v224678 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v224668 = v224678 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v224682 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v224668 = v224682 
                #endif
#if FABLE_COMPILER_PYTHON
                let v224686 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v224668 = v224686 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v224690 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v224668 = v224690 
                #endif
#else
                let v224693 : System.IO.FileMode = System.IO.FileMode.Open
                let v224699 : System.IO.FileAccess =
                    match v4 with
                    | US8_0 -> (* AccessRead *)
                        let v224694 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v224694
                    | US8_2 -> (* AccessReadWrite *)
                        let v224696 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v224696
                    | US8_1 -> (* AccessWrite *)
                        let v224695 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v224695
                let v224709 : System.IO.FileShare =
                    match v3 with
                    | US9_4 -> (* ShareDelete *)
                        let v224704 : System.IO.FileShare = System.IO.FileShare.Delete
                        v224704
                    | US9_0 -> (* ShareNone *)
                        let v224700 : System.IO.FileShare = System.IO.FileShare.None
                        v224700
                    | US9_1 -> (* ShareRead *)
                        let v224701 : System.IO.FileShare = System.IO.FileShare.Read
                        v224701
                    | US9_3 -> (* ShareReadWrite *)
                        let v224703 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v224703
                    | US9_2 -> (* ShareWrite *)
                        let v224702 : System.IO.FileShare = System.IO.FileShare.Write
                        v224702
                let v224710 : System.IO.FileStream = new System.IO.FileStream (v1, v224693, v224699, v224709)
                let _run_target_args'_v224668 = v224710 
                #endif
                let v224711 : System.IO.FileStream = _run_target_args'_v224668 
                use v224711 = v224711 
                let v224720 : System.IO.FileStream = v224711 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v225512 : exn = ex
                let v225513 : bool = v2 > 0L
                let v225516 : bool =
                    if v225513 then
                        let v225514 : int64 = v2 % 100L
                        let v225515 : bool = v225514 = 0L
                        v225515
                    else
                        false
                if v225516 then
                    let v225868 : unit = ()
                    let v225869 : (unit -> unit) = closure12(v1, v2, v225512)
                    let v225870 : unit = (fun () -> v225869 (); v225868) ()
                    ()
                (* run_target_args'
                let v226229 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v226230 : (int32 -> Async<unit>) = Async.Sleep
                let v226231 : Async<unit> = v226230 10
                let _run_target_args'_v226229 = v226231 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v226232 : (int32 -> Async<unit>) = Async.Sleep
                let v226233 : Async<unit> = v226232 10
                let _run_target_args'_v226229 = v226233 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v226234 : (int32 -> Async<unit>) = Async.Sleep
                let v226235 : Async<unit> = v226234 10
                let _run_target_args'_v226229 = v226235 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v226236 : (int32 -> Async<unit>) = Async.Sleep
                let v226237 : Async<unit> = v226236 10
                let _run_target_args'_v226229 = v226237 
                #endif
#if FABLE_COMPILER_PYTHON
                let v226238 : (int32 -> Async<unit>) = Async.Sleep
                let v226239 : Async<unit> = v226238 10
                let _run_target_args'_v226229 = v226239 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v226240 : (int32 -> Async<unit>) = Async.Sleep
                let v226241 : Async<unit> = v226240 10
                let _run_target_args'_v226229 = v226241 
                #endif
#else
                let v226242 : (int32 -> Async<unit>) = Async.Sleep
                let v226243 : Async<unit> = v226242 10
                let _run_target_args'_v226229 = v226243 
                #endif
                let v226244 : Async<unit> = _run_target_args'_v226229 
                do! v226244 
                let v226250 : int64 = v2 + 1L
                let v226251 : Async<int64> = method24(v0, v1, v226250)
                return! v226251 
                (* indent
                ()
            indent *)
            (* try_unit
            let v226993 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v258053 : Async<int64> = _let'_v193547 
    let _run_target_args'_v9 = v258053 
    #endif
    let v258054 : Async<int64> = _run_target_args'_v9 
    v258054
and method24 (v0 : US7, v1 : string, v2 : int64) : Async<int64> =
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
    let struct (v38 : US8, v39 : US9) =
        match v0 with
        | US7_1 -> (* None *)
            let v34 : US8 = US8_2
            let v35 : US9 = US9_1
            struct (v34, v35)
        | US7_0(v32, v33) -> (* Some *)
            struct (v32, v33)
    let v40 : Async<int64> = method25(v0, v1, v2, v39, v38)
    let _run_target_args'_v7 = v40 
    #endif
    let v41 : Async<int64> = _run_target_args'_v7 
    v41
and method23 (v0 : US7, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method24(v0, v1, v2)
and closure11 (v0 : US7) (v1 : string) : Async<int64> =
    method23(v0, v1)
and closure10 () (v0 : US7) : (string -> Async<int64>) =
    closure11(v0)
and method28 (v0 : string) : Async<int64> =
    let v1 : US8 = US8_0
    let v2 : US9 = US9_1
    let v3 : US7 = US7_0(v1, v2)
    method23(v3, v0)
and closure13 () (v0 : string) : Async<int64> =
    method28(v0)
and method32 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method16(v7)
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
    let v163 : string = method18()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[90m"
    let v179 : string = method18()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[90m"
    let v195 : string = method18()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[90m"
    let v211 : string = method18()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method34 (v0 : int64, v1 : string, v2 : exn) : string =
    let v3 : string = method17()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "retry"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure6(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure6(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v66 : string = $"{v0}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure6(v4, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure6(v4, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "path"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure6(v4, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v45}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure6(v4, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v138 : string = $"{v1}"
    let v146 : unit = ()
    let v147 : (unit -> unit) = closure6(v4, v138)
    let v148 : unit = (fun () -> v147 (); v146) ()
    let v155 : string = $"{v84}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure6(v4, v155)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v173 : string = "ex"
    let v174 : string = $"{v173}"
    let v182 : unit = ()
    let v183 : (unit -> unit) = closure6(v4, v174)
    let v184 : unit = (fun () -> v183 (); v182) ()
    let v191 : string = $"{v45}"
    let v199 : unit = ()
    let v200 : (unit -> unit) = closure6(v4, v191)
    let v201 : unit = (fun () -> v200 (); v199) ()
    (* run_target_args'
    let v211 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v212 : string = "format!(\"{:#?}\", $0)"
    let v213 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v212 
    let v214 : string = "fable_library_rust::String_::fromString($0)"
    let v215 : string = Fable.Core.RustInterop.emitRustExpr v213 v214 
    let _run_target_args'_v211 = v215 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v216 : string = "format!(\"{:#?}\", $0)"
    let v217 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v216 
    let v218 : string = "fable_library_rust::String_::fromString($0)"
    let v219 : string = Fable.Core.RustInterop.emitRustExpr v217 v218 
    let _run_target_args'_v211 = v219 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v220 : string = "format!(\"{:#?}\", $0)"
    let v221 : std_string_String = Fable.Core.RustInterop.emitRustExpr v2 v220 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v221 v222 
    let _run_target_args'_v211 = v223 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v225 : string = $"%A{v2}"
    let _run_target_args'_v211 = v225 
    #endif
#if FABLE_COMPILER_PYTHON
    let v229 : string = $"%A{v2}"
    let _run_target_args'_v211 = v229 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v233 : string = $"%A{v2}"
    let _run_target_args'_v211 = v233 
    #endif
#else
    let v237 : string = $"%A{v2}"
    let _run_target_args'_v211 = v237 
    #endif
    let v240 : string = _run_target_args'_v211 
    let v250 : string = $"{v240}"
    let v258 : unit = ()
    let v259 : (unit -> unit) = closure6(v4, v250)
    let v260 : unit = (fun () -> v259 (); v258) ()
    let v268 : string = " }"
    let v269 : string = $"{v268}"
    let v277 : unit = ()
    let v278 : (unit -> unit) = closure6(v4, v269)
    let v279 : unit = (fun () -> v278 (); v277) ()
    let v285 : string = v4.l0
    v285
and method33 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string, v10 : exn) : string =
    let v11 : string = method34(v8, v9, v10)
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
    let v44 : string = "file_system.read_all_text_async"
    let v45 : string = v39 + v44 
    let v50 : string = " / "
    let v51 : string = v45 + v50 
    let v55 : string = v51 + v11 
    method22(v55)
and closure15 (v0 : string, v1 : int64, v2 : exn) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure0()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
    let v60 : US0 = v46.l0
    let v61 : bool = v44.l0
    let v62 : bool = v61 = false
    let v65 : bool =
        if v62 then
            false
        else
            let v63 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v60
            let v64 : bool = 0 >= v63
            v64
    let v66 : bool = v65 = false
    let v300 : US6 =
        if v66 then
            US6_1
        else
            let v82 : unit = ()
            let v83 : unit = (fun () -> v18 (); v82) ()
            let struct (v106 : Mut0, v107 : Mut1, v108 : Mut2, v109 : Mut3, v110 : Mut4, v111 : int64 option) = TraceState.trace_state.Value
            let v124 : string = method11(v106, v107, v108, v109, v110, v111)
            let v125 : string = method32()
            let v126 : string = method33(v106, v107, v108, v109, v110, v111, v124, v125, v1, v0, v2)
            let v141 : unit = ()
            let v142 : unit = (fun () -> v18 (); v141) ()
            let struct (v165 : Mut0, v166 : Mut1, v167 : Mut2, v168 : Mut3, v169 : Mut4, v170 : int64 option) = TraceState.trace_state.Value
            let v185 : unit = ()
            let v186 : (unit -> unit) = closure7(v165)
            let v187 : unit = (fun () -> v186 (); v185) ()
            let v190 : (string -> unit) = closure8()
            (* run_target_args'
            let v191 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v126 v192 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v193 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v126 v193 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v194 : string = v168.l0
            let v195 : bool = v194 = ""
            let v210 : string =
                if v195 then
                    v126
                else
                    let v196 : bool = v126 = ""
                    if v196 then
                        let v197 : string = v168.l0
                        v197
                    else
                        let v198 : string = v168.l0
                        let v201 : string = "\n"
                        let v202 : string = v198 + v201 
                        let v206 : string = v202 + v126 
                        v206
            (* run_target_args'
            let v215 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v216 : string = "&*$0"
            let v217 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v216 
            let _run_target_args'_v215 = v217 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v218 : string = "&*$0"
            let v219 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v218 
            let _run_target_args'_v215 = v219 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v220 : string = "&*$0"
            let v221 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v210 v220 
            let _run_target_args'_v215 = v221 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v223 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v223 
            #endif
#if FABLE_COMPILER_PYTHON
            let v227 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v227 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v231 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v231 
            #endif
#else
            let v235 : Ref<Str> = v210 |> unbox<Ref<Str>>
            let _run_target_args'_v215 = v235 
            #endif
            let v238 : Ref<Str> = _run_target_args'_v215 
            let v247 : string = $"$0.chars()"
            let v248 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v238 v247 
            let v249 : string = "$0"
            let v250 : _ = Fable.Core.RustInterop.emitRustExpr v248 v249 
            let v251 : string = "$0.collect::<Vec<_>>()"
            let v252 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v250 v251 
            let v253 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v254 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v252 v253 
            let v255 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v256 : bool = Fable.Core.RustInterop.emitRustExpr v254 v255 
            let v257 : string = "x"
            let v258 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v257 
            let v259 : string = "String::from_iter($0)"
            let v260 : std_string_String = Fable.Core.RustInterop.emitRustExpr v258 v259 
            let v261 : string = "true; $0 }).collect::<Vec<_>>()"
            let v262 : bool = Fable.Core.RustInterop.emitRustExpr v260 v261 
            let v263 : string = "_vec_map"
            let v264 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v263 
            let v265 : string = "$0.len()"
            let v266 : unativeint = Fable.Core.RustInterop.emitRustExpr v264 v265 
            let v272 : int32 = v266 |> int32 
            let v282 : string = ""
            let v283 : bool = v126 <> v282 
            let v287 : bool =
                if v283 then
                    let v286 : bool = v272 <= 1
                    v286
                else
                    false
            if v287 then
                v168.l0 <- v210
                ()
            else
                v168.l0 <- v282
                let v288 : string = "true; $0.into_iter().for_each(|x| { //"
                let v289 : bool = Fable.Core.RustInterop.emitRustExpr v264 v288 
                let v290 : string = "x"
                let v291 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v290 
                let v292 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v293 : bool = Fable.Core.RustInterop.emitRustExpr v291 v292 
                let v294 : string = $"true"
                let v295 : bool = Fable.Core.RustInterop.emitRustExpr () v294 
                let v296 : string = "true; }); //"
                let v297 : bool = Fable.Core.RustInterop.emitRustExpr () v296 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v190 v126
            #endif
#if FABLE_COMPILER_PYTHON
            v190 v126
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v190 v126
            #endif
#else
            v190 v126
            #endif
            // run_target_args' is_unit
            let v298 : (string -> unit) = v166.l0
            v298 v126
            US6_0(v165, v166, v167, v168, v169, v170)
    
    ()
and method31 (v0 : string, v1 : int64) : Async<string> =
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
                let v28701 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v28703 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v28701 = v28703 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v28707 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v28701 = v28707 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v28711 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v28701 = v28711 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28715 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v28701 = v28715 
                #endif
#if FABLE_COMPILER_PYTHON
                let v28719 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v28701 = v28719 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28723 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v28701 = v28723 
                #endif
#else
                let v28726 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v28727 : System.Threading.Tasks.Task<string> = v28726 v0
                let _run_target_args'_v28701 = v28727 
                #endif
                let v28728 : System.Threading.Tasks.Task<string> = _run_target_args'_v28701 
                (* run_target_args'
                let v28741 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v28743 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v28741 = v28743 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v28747 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v28741 = v28747 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v28751 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v28741 = v28751 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v28754 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v28755 : Async<string> = v28754 v28728
                let _run_target_args'_v28741 = v28755 
                #endif
#if FABLE_COMPILER_PYTHON
                let v28756 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v28757 : Async<string> = v28756 v28728
                let _run_target_args'_v28741 = v28757 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v28758 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v28759 : Async<string> = v28758 v28728
                let _run_target_args'_v28741 = v28759 
                #endif
#else
                let v28760 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v28761 : Async<string> = v28760 v28728
                let _run_target_args'_v28741 = v28761 
                #endif
                let v28762 : Async<string> = _run_target_args'_v28741 
                return! v28762 
                (* indent
                ()
            indent *)
            with ex ->
                let v29499 : exn = ex
                let v29811 : unit = ()
                let v29812 : (unit -> unit) = closure15(v0, v1, v29499)
                let v29813 : unit = (fun () -> v29812 (); v29811) ()
                (* run_target_args'
                let v30132 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30133 : (int32 -> Async<unit>) = Async.Sleep
                let v30134 : Async<unit> = v30133 10
                let _run_target_args'_v30132 = v30134 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v30135 : (int32 -> Async<unit>) = Async.Sleep
                let v30136 : Async<unit> = v30135 10
                let _run_target_args'_v30132 = v30136 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v30137 : (int32 -> Async<unit>) = Async.Sleep
                let v30138 : Async<unit> = v30137 10
                let _run_target_args'_v30132 = v30138 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v30139 : (int32 -> Async<unit>) = Async.Sleep
                let v30140 : Async<unit> = v30139 10
                let _run_target_args'_v30132 = v30140 
                #endif
#if FABLE_COMPILER_PYTHON
                let v30141 : (int32 -> Async<unit>) = Async.Sleep
                let v30142 : Async<unit> = v30141 10
                let _run_target_args'_v30132 = v30142 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v30143 : (int32 -> Async<unit>) = Async.Sleep
                let v30144 : Async<unit> = v30143 10
                let _run_target_args'_v30132 = v30144 
                #endif
#else
                let v30145 : (int32 -> Async<unit>) = Async.Sleep
                let v30146 : Async<unit> = v30145 10
                let _run_target_args'_v30132 = v30146 
                #endif
                let v30147 : Async<unit> = _run_target_args'_v30132 
                do! v30147 
                let v30153 : bool = v1 < 3L
                let v30158 : Async<string> =
                    if v30153 then
                        let v30154 : int64 = v1 + 1L
                        method30(v0, v30154)
                    else
                        let v30156 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v30156
                return! v30158 
                (* indent
                ()
            indent *)
            (* try_unit
            let v30820 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v59423 : Async<string> = _let'_v20 
    let _run_target_args'_v6 = v59423 
    #endif
#if FABLE_COMPILER_PYTHON
    let v59425 : unit = ()
    let _let'_v59425 =
        async {
            try
                (* run_target_args'
                let v88106 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v88108 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v88106 = v88108 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v88112 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v88106 = v88112 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v88116 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v88106 = v88116 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v88120 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v88106 = v88120 
                #endif
#if FABLE_COMPILER_PYTHON
                let v88124 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v88106 = v88124 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v88128 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v88106 = v88128 
                #endif
#else
                let v88131 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v88132 : System.Threading.Tasks.Task<string> = v88131 v0
                let _run_target_args'_v88106 = v88132 
                #endif
                let v88133 : System.Threading.Tasks.Task<string> = _run_target_args'_v88106 
                (* run_target_args'
                let v88146 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v88148 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v88146 = v88148 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v88152 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v88146 = v88152 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v88156 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v88146 = v88156 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v88159 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v88160 : Async<string> = v88159 v88133
                let _run_target_args'_v88146 = v88160 
                #endif
#if FABLE_COMPILER_PYTHON
                let v88161 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v88162 : Async<string> = v88161 v88133
                let _run_target_args'_v88146 = v88162 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v88163 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v88164 : Async<string> = v88163 v88133
                let _run_target_args'_v88146 = v88164 
                #endif
#else
                let v88165 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v88166 : Async<string> = v88165 v88133
                let _run_target_args'_v88146 = v88166 
                #endif
                let v88167 : Async<string> = _run_target_args'_v88146 
                return! v88167 
                (* indent
                ()
            indent *)
            with ex ->
                let v88904 : exn = ex
                let v89216 : unit = ()
                let v89217 : (unit -> unit) = closure15(v0, v1, v88904)
                let v89218 : unit = (fun () -> v89217 (); v89216) ()
                (* run_target_args'
                let v89537 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v89538 : (int32 -> Async<unit>) = Async.Sleep
                let v89539 : Async<unit> = v89538 10
                let _run_target_args'_v89537 = v89539 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v89540 : (int32 -> Async<unit>) = Async.Sleep
                let v89541 : Async<unit> = v89540 10
                let _run_target_args'_v89537 = v89541 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v89542 : (int32 -> Async<unit>) = Async.Sleep
                let v89543 : Async<unit> = v89542 10
                let _run_target_args'_v89537 = v89543 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v89544 : (int32 -> Async<unit>) = Async.Sleep
                let v89545 : Async<unit> = v89544 10
                let _run_target_args'_v89537 = v89545 
                #endif
#if FABLE_COMPILER_PYTHON
                let v89546 : (int32 -> Async<unit>) = Async.Sleep
                let v89547 : Async<unit> = v89546 10
                let _run_target_args'_v89537 = v89547 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v89548 : (int32 -> Async<unit>) = Async.Sleep
                let v89549 : Async<unit> = v89548 10
                let _run_target_args'_v89537 = v89549 
                #endif
#else
                let v89550 : (int32 -> Async<unit>) = Async.Sleep
                let v89551 : Async<unit> = v89550 10
                let _run_target_args'_v89537 = v89551 
                #endif
                let v89552 : Async<unit> = _run_target_args'_v89537 
                do! v89552 
                let v89558 : bool = v1 < 3L
                let v89563 : Async<string> =
                    if v89558 then
                        let v89559 : int64 = v1 + 1L
                        method30(v0, v89559)
                    else
                        let v89561 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v89561
                return! v89563 
                (* indent
                ()
            indent *)
            (* try_unit
            let v90225 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v118828 : Async<string> = _let'_v59425 
    let _run_target_args'_v6 = v118828 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v118830 : unit = ()
    let _let'_v118830 =
        async {
            try
                (* run_target_args'
                let v147511 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v147513 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v147511 = v147513 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v147517 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v147511 = v147517 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v147521 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v147511 = v147521 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v147525 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v147511 = v147525 
                #endif
#if FABLE_COMPILER_PYTHON
                let v147529 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v147511 = v147529 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v147533 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v147511 = v147533 
                #endif
#else
                let v147536 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v147537 : System.Threading.Tasks.Task<string> = v147536 v0
                let _run_target_args'_v147511 = v147537 
                #endif
                let v147538 : System.Threading.Tasks.Task<string> = _run_target_args'_v147511 
                (* run_target_args'
                let v147551 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v147553 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v147551 = v147553 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v147557 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v147551 = v147557 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v147561 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v147551 = v147561 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v147564 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v147565 : Async<string> = v147564 v147538
                let _run_target_args'_v147551 = v147565 
                #endif
#if FABLE_COMPILER_PYTHON
                let v147566 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v147567 : Async<string> = v147566 v147538
                let _run_target_args'_v147551 = v147567 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v147568 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v147569 : Async<string> = v147568 v147538
                let _run_target_args'_v147551 = v147569 
                #endif
#else
                let v147570 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v147571 : Async<string> = v147570 v147538
                let _run_target_args'_v147551 = v147571 
                #endif
                let v147572 : Async<string> = _run_target_args'_v147551 
                return! v147572 
                (* indent
                ()
            indent *)
            with ex ->
                let v148309 : exn = ex
                let v148621 : unit = ()
                let v148622 : (unit -> unit) = closure15(v0, v1, v148309)
                let v148623 : unit = (fun () -> v148622 (); v148621) ()
                (* run_target_args'
                let v148942 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v148943 : (int32 -> Async<unit>) = Async.Sleep
                let v148944 : Async<unit> = v148943 10
                let _run_target_args'_v148942 = v148944 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v148945 : (int32 -> Async<unit>) = Async.Sleep
                let v148946 : Async<unit> = v148945 10
                let _run_target_args'_v148942 = v148946 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v148947 : (int32 -> Async<unit>) = Async.Sleep
                let v148948 : Async<unit> = v148947 10
                let _run_target_args'_v148942 = v148948 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v148949 : (int32 -> Async<unit>) = Async.Sleep
                let v148950 : Async<unit> = v148949 10
                let _run_target_args'_v148942 = v148950 
                #endif
#if FABLE_COMPILER_PYTHON
                let v148951 : (int32 -> Async<unit>) = Async.Sleep
                let v148952 : Async<unit> = v148951 10
                let _run_target_args'_v148942 = v148952 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v148953 : (int32 -> Async<unit>) = Async.Sleep
                let v148954 : Async<unit> = v148953 10
                let _run_target_args'_v148942 = v148954 
                #endif
#else
                let v148955 : (int32 -> Async<unit>) = Async.Sleep
                let v148956 : Async<unit> = v148955 10
                let _run_target_args'_v148942 = v148956 
                #endif
                let v148957 : Async<unit> = _run_target_args'_v148942 
                do! v148957 
                let v148963 : bool = v1 < 3L
                let v148968 : Async<string> =
                    if v148963 then
                        let v148964 : int64 = v1 + 1L
                        method30(v0, v148964)
                    else
                        let v148966 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v148966
                return! v148968 
                (* indent
                ()
            indent *)
            (* try_unit
            let v149630 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v178233 : Async<string> = _let'_v118830 
    let _run_target_args'_v6 = v178233 
    #endif
#else
    let v178235 : unit = ()
    let _let'_v178235 =
        async {
            try
                (* run_target_args'
                let v206916 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v206918 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v206916 = v206918 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v206922 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v206916 = v206922 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v206926 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v206916 = v206926 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v206930 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v206916 = v206930 
                #endif
#if FABLE_COMPILER_PYTHON
                let v206934 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v206916 = v206934 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v206938 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v206916 = v206938 
                #endif
#else
                let v206941 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v206942 : System.Threading.Tasks.Task<string> = v206941 v0
                let _run_target_args'_v206916 = v206942 
                #endif
                let v206943 : System.Threading.Tasks.Task<string> = _run_target_args'_v206916 
                (* run_target_args'
                let v206956 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v206958 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v206956 = v206958 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v206962 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v206956 = v206962 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v206966 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v206956 = v206966 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v206969 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v206970 : Async<string> = v206969 v206943
                let _run_target_args'_v206956 = v206970 
                #endif
#if FABLE_COMPILER_PYTHON
                let v206971 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v206972 : Async<string> = v206971 v206943
                let _run_target_args'_v206956 = v206972 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v206973 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v206974 : Async<string> = v206973 v206943
                let _run_target_args'_v206956 = v206974 
                #endif
#else
                let v206975 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v206976 : Async<string> = v206975 v206943
                let _run_target_args'_v206956 = v206976 
                #endif
                let v206977 : Async<string> = _run_target_args'_v206956 
                return! v206977 
                (* indent
                ()
            indent *)
            with ex ->
                let v207714 : exn = ex
                let v208026 : unit = ()
                let v208027 : (unit -> unit) = closure15(v0, v1, v207714)
                let v208028 : unit = (fun () -> v208027 (); v208026) ()
                (* run_target_args'
                let v208347 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v208348 : (int32 -> Async<unit>) = Async.Sleep
                let v208349 : Async<unit> = v208348 10
                let _run_target_args'_v208347 = v208349 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v208350 : (int32 -> Async<unit>) = Async.Sleep
                let v208351 : Async<unit> = v208350 10
                let _run_target_args'_v208347 = v208351 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v208352 : (int32 -> Async<unit>) = Async.Sleep
                let v208353 : Async<unit> = v208352 10
                let _run_target_args'_v208347 = v208353 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v208354 : (int32 -> Async<unit>) = Async.Sleep
                let v208355 : Async<unit> = v208354 10
                let _run_target_args'_v208347 = v208355 
                #endif
#if FABLE_COMPILER_PYTHON
                let v208356 : (int32 -> Async<unit>) = Async.Sleep
                let v208357 : Async<unit> = v208356 10
                let _run_target_args'_v208347 = v208357 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v208358 : (int32 -> Async<unit>) = Async.Sleep
                let v208359 : Async<unit> = v208358 10
                let _run_target_args'_v208347 = v208359 
                #endif
#else
                let v208360 : (int32 -> Async<unit>) = Async.Sleep
                let v208361 : Async<unit> = v208360 10
                let _run_target_args'_v208347 = v208361 
                #endif
                let v208362 : Async<unit> = _run_target_args'_v208347 
                do! v208362 
                let v208368 : bool = v1 < 3L
                let v208373 : Async<string> =
                    if v208368 then
                        let v208369 : int64 = v1 + 1L
                        method30(v0, v208369)
                    else
                        let v208371 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v208371
                return! v208373 
                (* indent
                ()
            indent *)
            (* try_unit
            let v209035 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v237638 : Async<string> = _let'_v178235 
    let _run_target_args'_v6 = v237638 
    #endif
    let v237639 : Async<string> = _run_target_args'_v6 
    v237639
and method30 (v0 : string, v1 : int64) : Async<string> =
    method31(v0, v1)
and method29 (v0 : string) : Async<string> =
    let v1 : int64 = 0L
    method30(v0, v1)
and closure14 () (v0 : string) : Async<string> =
    method29(v0)
and method36 (v0 : string) : bool =
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
and method37 (v0 : Vec<uint8>) : Vec<uint8> =
    v0
and method35 (v0 : string, v1 : string) : bool =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : bool = method36(v0)
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
            let v68 : Vec<uint8> = method37(v59)
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
    method35(v0, v1)
and closure16 () (v0 : string) : (string -> bool) =
    closure17(v0)
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
    method38(v0, v1)
and closure18 () (v0 : string) : (string -> Async<unit>) =
    closure19(v0)
and method42 (v0 : string, v1 : string) : Async<bool> =
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
            let v88 : bool = method36(v0)
            let v89 : bool = v88 = false
            if v89 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v90 : Async<string> = method29(v0)
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
            let v228 : bool = method36(v0)
            let v229 : bool = v228 = false
            if v229 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v230 : Async<string> = method29(v0)
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
            let v368 : bool = method36(v0)
            let v369 : bool = v368 = false
            if v369 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v370 : Async<string> = method29(v0)
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
            let v508 : bool = method36(v0)
            let v509 : bool = v508 = false
            if v509 then
                return false 
                (* fix_condition then
                ()
            else
                fix_condition then *) else
                let v510 : Async<string> = method29(v0)
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
and method41 (v0 : string, v1 : string) : Async<bool> =
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
    let v31 : Async<bool> = method42(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<bool> = _run_target_args'_v6 
    v32
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
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let v75 : Async<bool> = method41(v0, v1)
            let! v75 = v75 
            let v76 : bool = v75 
            let v77 : bool = v76 = false
            if v77 then
                let v78 : Async<unit> = method38(v0, v1)
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
            let v188 : Async<bool> = method41(v0, v1)
            let! v188 = v188 
            let v189 : bool = v188 
            let v190 : bool = v189 = false
            if v190 then
                let v191 : Async<unit> = method38(v0, v1)
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
            let v301 : Async<bool> = method41(v0, v1)
            let! v301 = v301 
            let v302 : bool = v301 
            let v303 : bool = v302 = false
            if v303 then
                let v304 : Async<unit> = method38(v0, v1)
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
            let v414 : Async<bool> = method41(v0, v1)
            let! v414 = v414 
            let v415 : bool = v414 
            let v416 : bool = v415 = false
            if v416 then
                let v417 : Async<unit> = method38(v0, v1)
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
and method39 (v0 : string, v1 : string) : Async<unit> =
    method40(v0, v1)
and closure21 (v0 : string) (v1 : string) : Async<unit> =
    method39(v0, v1)
and closure20 () (v0 : string) : (string -> Async<unit>) =
    closure21(v0)
and method47 (v0 : std_io_Error) : string =
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
and closure23 () (v0 : std_io_Error) : string =
    method47(v0)
and method46 () : (std_io_Error -> string) =
    closure23()
and closure24 () () : US10 =
    US10_0
and method48 () : (unit -> US10) =
    closure24()
and closure25 () (v0 : string) : US10 =
    US10_1(v0)
and method49 () : (string -> US10) =
    closure25()
and method50 () : string =
    
    
    
    
    
    let v2 : string = "Critical"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method16(v7)
    (* run_target_args'
    let v25 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v26 : string = "inline_colorization::color_bright_red"
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
    let v70 : string = "inline_colorization::color_bright_red"
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
    let v114 : string = "inline_colorization::color_bright_red"
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
    let v159 : string = "\u001b[91m"
    let v163 : string = method18()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[91m"
    let v179 : string = method18()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[91m"
    let v195 : string = method18()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[91m"
    let v211 : string = method18()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method52 (v0 : string) : string =
    let v1 : string = method17()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "error'"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v61 : string = $"{v0}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure6(v2, v61)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v79 : string = " }"
    let v80 : string = $"{v79}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure6(v2, v80)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v96 : string = v2.l0
    v96
and method51 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method52(v8)
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
    let v42 : string = "file_system.file_delete"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method22(v53)
and closure26 (v0 : string) () : unit =
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
            let v62 : bool = 4 >= v61
            v62
    let v64 : bool = v63 = false
    let v298 : US6 =
        if v64 then
            US6_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method11(v104, v105, v106, v107, v108, v109)
            let v123 : string = method50()
            let v124 : string = method51(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure7(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure8()
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
and method53 () : string =
    
    
    
    
    
    let v2 : string = "Warning"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method16(v7)
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
    let v163 : string = method18()
    let v167 : string = v159 + v8 
    let v171 : string = v167 + v163 
    let _run_target_args'_v25 = v171 
    #endif
#if FABLE_COMPILER_PYTHON
    let v175 : string = "\u001b[93m"
    let v179 : string = method18()
    let v183 : string = v175 + v8 
    let v187 : string = v183 + v179 
    let _run_target_args'_v25 = v187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v191 : string = "\u001b[93m"
    let v195 : string = method18()
    let v199 : string = v191 + v8 
    let v203 : string = v199 + v195 
    let _run_target_args'_v25 = v203 
    #endif
#else
    let v207 : string = "\u001b[93m"
    let v211 : string = method18()
    let v215 : string = v207 + v8 
    let v219 : string = v215 + v211 
    let _run_target_args'_v25 = v219 
    #endif
    let v222 : string = _run_target_args'_v25 
    v222
and method55 (v0 : string, v1 : string) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "path"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v62 : string = $"{v0}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure6(v3, v62)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v80 : string = "; "
    let v81 : string = $"{v80}"
    let v89 : unit = ()
    let v90 : (unit -> unit) = closure6(v3, v81)
    let v91 : unit = (fun () -> v90 (); v89) ()
    let v99 : string = "ex"
    let v100 : string = $"{v99}"
    let v108 : unit = ()
    let v109 : (unit -> unit) = closure6(v3, v100)
    let v110 : unit = (fun () -> v109 (); v108) ()
    let v117 : string = $"{v44}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure6(v3, v117)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v134 : string = $"{v1}"
    let v142 : unit = ()
    let v143 : (unit -> unit) = closure6(v3, v134)
    let v144 : unit = (fun () -> v143 (); v142) ()
    let v152 : string = " }"
    let v153 : string = $"{v152}"
    let v161 : unit = ()
    let v162 : (unit -> unit) = closure6(v3, v153)
    let v163 : unit = (fun () -> v162 (); v161) ()
    let v169 : string = v3.l0
    v169
and method54 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method55(v8, v9)
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
    let v43 : string = "delete_file_async"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
and closure27 (v0 : string, v1 : exn) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 3 >= v62
            v63
    let v65 : bool = v64 = false
    let v339 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method53()
            let v125 : string = method19(v0)
            (* run_target_args'
            let v130 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v132 : string = $"%A{v1}"
            let _run_target_args'_v130 = v132 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v136 : string = $"%A{v1}"
            let _run_target_args'_v130 = v136 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v140 : string = $"%A{v1}"
            let _run_target_args'_v130 = v140 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v144 : string = $"%A{v1}"
            let _run_target_args'_v130 = v144 
            #endif
#if FABLE_COMPILER_PYTHON
            let v148 : string = $"%A{v1}"
            let _run_target_args'_v130 = v148 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v152 : string = $"%A{v1}"
            let _run_target_args'_v130 = v152 
            #endif
#else
            let v155 : string = $"{v1.GetType ()}: {v1.Message}"
            let _run_target_args'_v130 = v155 
            #endif
            let v156 : string = _run_target_args'_v130 
            let v165 : string = method54(v105, v106, v107, v108, v109, v110, v123, v124, v125, v156)
            let v180 : unit = ()
            let v181 : unit = (fun () -> v17 (); v180) ()
            let struct (v204 : Mut0, v205 : Mut1, v206 : Mut2, v207 : Mut3, v208 : Mut4, v209 : int64 option) = TraceState.trace_state.Value
            let v224 : unit = ()
            let v225 : (unit -> unit) = closure7(v204)
            let v226 : unit = (fun () -> v225 (); v224) ()
            let v229 : (string -> unit) = closure8()
            (* run_target_args'
            let v230 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v231 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v165 v231 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v232 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v165 v232 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v233 : string = v207.l0
            let v234 : bool = v233 = ""
            let v249 : string =
                if v234 then
                    v165
                else
                    let v235 : bool = v165 = ""
                    if v235 then
                        let v236 : string = v207.l0
                        v236
                    else
                        let v237 : string = v207.l0
                        let v240 : string = "\n"
                        let v241 : string = v237 + v240 
                        let v245 : string = v241 + v165 
                        v245
            (* run_target_args'
            let v254 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v255 : string = "&*$0"
            let v256 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v249 v255 
            let _run_target_args'_v254 = v256 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v257 : string = "&*$0"
            let v258 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v249 v257 
            let _run_target_args'_v254 = v258 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v259 : string = "&*$0"
            let v260 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v249 v259 
            let _run_target_args'_v254 = v260 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v262 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v262 
            #endif
#if FABLE_COMPILER_PYTHON
            let v266 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v266 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v270 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v270 
            #endif
#else
            let v274 : Ref<Str> = v249 |> unbox<Ref<Str>>
            let _run_target_args'_v254 = v274 
            #endif
            let v277 : Ref<Str> = _run_target_args'_v254 
            let v286 : string = $"$0.chars()"
            let v287 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v277 v286 
            let v288 : string = "$0"
            let v289 : _ = Fable.Core.RustInterop.emitRustExpr v287 v288 
            let v290 : string = "$0.collect::<Vec<_>>()"
            let v291 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v289 v290 
            let v292 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v293 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v291 v292 
            let v294 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v295 : bool = Fable.Core.RustInterop.emitRustExpr v293 v294 
            let v296 : string = "x"
            let v297 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v296 
            let v298 : string = "String::from_iter($0)"
            let v299 : std_string_String = Fable.Core.RustInterop.emitRustExpr v297 v298 
            let v300 : string = "true; $0 }).collect::<Vec<_>>()"
            let v301 : bool = Fable.Core.RustInterop.emitRustExpr v299 v300 
            let v302 : string = "_vec_map"
            let v303 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v302 
            let v304 : string = "$0.len()"
            let v305 : unativeint = Fable.Core.RustInterop.emitRustExpr v303 v304 
            let v311 : int32 = v305 |> int32 
            let v321 : string = ""
            let v322 : bool = v165 <> v321 
            let v326 : bool =
                if v322 then
                    let v325 : bool = v311 <= 1
                    v325
                else
                    false
            if v326 then
                v207.l0 <- v249
                ()
            else
                v207.l0 <- v321
                let v327 : string = "true; $0.into_iter().for_each(|x| { //"
                let v328 : bool = Fable.Core.RustInterop.emitRustExpr v303 v327 
                let v329 : string = "x"
                let v330 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v329 
                let v331 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v332 : bool = Fable.Core.RustInterop.emitRustExpr v330 v331 
                let v333 : string = $"true"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr () v333 
                let v335 : string = "true; }); //"
                let v336 : bool = Fable.Core.RustInterop.emitRustExpr () v335 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v229 v165
            #endif
#if FABLE_COMPILER_PYTHON
            v229 v165
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v229 v165
            #endif
#else
            v229 v165
            #endif
            // run_target_args' is_unit
            let v337 : (string -> unit) = v205.l0
            v337 v165
            US6_0(v204, v205, v206, v207, v208, v209)
    
    ()
and method45 (v0 : string, v1 : int64) : Async<int64> =
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
                let v54979 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v54980 : string = "std::fs::remove_file(&*$0)"
                let v54981 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v54980 
                let v54982 : (std_io_Error -> string) = method46()
                (* run_target_args'
                let v54984 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v54985 : string = "$0.map_err(|x| $1(x))"
                let v54986 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v54981, v54982) v54985 
                let _run_target_args'_v54984 = v54986 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v54987 : string = "$0.map_err(|x| $1(x))"
                let v54988 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v54981, v54982) v54987 
                let _run_target_args'_v54984 = v54988 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v54989 : string = "$0.map_err(|x| $1(x))"
                let v54990 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v54981, v54982) v54989 
                let _run_target_args'_v54984 = v54990 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v54991 : Result<unit, string> = match v54981 with Ok x -> Ok x | Error x -> Error (v54982 x)
                let _run_target_args'_v54984 = v54991 
                #endif
#if FABLE_COMPILER_PYTHON
                let v54992 : Result<unit, string> = match v54981 with Ok x -> Ok x | Error x -> Error (v54982 x)
                let _run_target_args'_v54984 = v54992 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v54993 : Result<unit, string> = match v54981 with Ok x -> Ok x | Error x -> Error (v54982 x)
                let _run_target_args'_v54984 = v54993 
                #endif
#else
                let v54994 : Result<unit, string> = match v54981 with Ok x -> Ok x | Error x -> Error (v54982 x)
                let _run_target_args'_v54984 = v54994 
                #endif
                let v54995 : Result<unit, string> = _run_target_args'_v54984 
                let v54998 : (unit -> US10) = method48()
                let v54999 : (string -> US10) = method49()
                let v55001 : US10 = match v54995 with Ok () -> v54998 () | Error x -> v54999 x
                match v55001 with
                | US10_1(v55004) -> (* Error *)
                    let v55316 : unit = ()
                    let v55317 : (unit -> unit) = closure26(v55004)
                    let v55318 : unit = (fun () -> v55317 (); v55316) ()
                    ()
                | US10_0 -> (* Ok *)
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
                let v55633 : (string -> unit) = System.IO.File.Delete
                v55633 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v57021 : exn = ex
                let v57022 : int64 = v1 % 100L
                let v57023 : bool = v57022 = 0L
                if v57023 then
                    let v57375 : unit = ()
                    let v57376 : (unit -> unit) = closure27(v0, v57021)
                    let v57377 : unit = (fun () -> v57376 (); v57375) ()
                    ()
                (* run_target_args'
                let v57736 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v57737 : (int32 -> Async<unit>) = Async.Sleep
                let v57738 : Async<unit> = v57737 10
                let _run_target_args'_v57736 = v57738 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v57739 : (int32 -> Async<unit>) = Async.Sleep
                let v57740 : Async<unit> = v57739 10
                let _run_target_args'_v57736 = v57740 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v57741 : (int32 -> Async<unit>) = Async.Sleep
                let v57742 : Async<unit> = v57741 10
                let _run_target_args'_v57736 = v57742 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v57743 : (int32 -> Async<unit>) = Async.Sleep
                let v57744 : Async<unit> = v57743 10
                let _run_target_args'_v57736 = v57744 
                #endif
#if FABLE_COMPILER_PYTHON
                let v57745 : (int32 -> Async<unit>) = Async.Sleep
                let v57746 : Async<unit> = v57745 10
                let _run_target_args'_v57736 = v57746 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v57747 : (int32 -> Async<unit>) = Async.Sleep
                let v57748 : Async<unit> = v57747 10
                let _run_target_args'_v57736 = v57748 
                #endif
#else
                let v57749 : (int32 -> Async<unit>) = Async.Sleep
                let v57750 : Async<unit> = v57749 10
                let _run_target_args'_v57736 = v57750 
                #endif
                let v57751 : Async<unit> = _run_target_args'_v57736 
                do! v57751 
                let v57757 : int64 = v1 + 1L
                let v57758 : Async<int64> = method44(v0, v57757)
                return! v57758 
                (* indent
                ()
            indent *)
            (* try_unit
            let v58498 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v112802 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v112802 
    #endif
#if FABLE_COMPILER_PYTHON
    let v112804 : unit = ()
    let _let'_v112804 =
        async {
            try
                (* run_target_args'
                let v167763 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v167764 : string = "std::fs::remove_file(&*$0)"
                let v167765 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v167764 
                let v167766 : (std_io_Error -> string) = method46()
                (* run_target_args'
                let v167768 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v167769 : string = "$0.map_err(|x| $1(x))"
                let v167770 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v167765, v167766) v167769 
                let _run_target_args'_v167768 = v167770 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v167771 : string = "$0.map_err(|x| $1(x))"
                let v167772 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v167765, v167766) v167771 
                let _run_target_args'_v167768 = v167772 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v167773 : string = "$0.map_err(|x| $1(x))"
                let v167774 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v167765, v167766) v167773 
                let _run_target_args'_v167768 = v167774 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v167775 : Result<unit, string> = match v167765 with Ok x -> Ok x | Error x -> Error (v167766 x)
                let _run_target_args'_v167768 = v167775 
                #endif
#if FABLE_COMPILER_PYTHON
                let v167776 : Result<unit, string> = match v167765 with Ok x -> Ok x | Error x -> Error (v167766 x)
                let _run_target_args'_v167768 = v167776 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v167777 : Result<unit, string> = match v167765 with Ok x -> Ok x | Error x -> Error (v167766 x)
                let _run_target_args'_v167768 = v167777 
                #endif
#else
                let v167778 : Result<unit, string> = match v167765 with Ok x -> Ok x | Error x -> Error (v167766 x)
                let _run_target_args'_v167768 = v167778 
                #endif
                let v167779 : Result<unit, string> = _run_target_args'_v167768 
                let v167782 : (unit -> US10) = method48()
                let v167783 : (string -> US10) = method49()
                let v167785 : US10 = match v167779 with Ok () -> v167782 () | Error x -> v167783 x
                match v167785 with
                | US10_1(v167788) -> (* Error *)
                    let v168100 : unit = ()
                    let v168101 : (unit -> unit) = closure26(v167788)
                    let v168102 : unit = (fun () -> v168101 (); v168100) ()
                    ()
                | US10_0 -> (* Ok *)
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
                let v168417 : (string -> unit) = System.IO.File.Delete
                v168417 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v169805 : exn = ex
                let v169806 : int64 = v1 % 100L
                let v169807 : bool = v169806 = 0L
                if v169807 then
                    let v170159 : unit = ()
                    let v170160 : (unit -> unit) = closure27(v0, v169805)
                    let v170161 : unit = (fun () -> v170160 (); v170159) ()
                    ()
                (* run_target_args'
                let v170520 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v170521 : (int32 -> Async<unit>) = Async.Sleep
                let v170522 : Async<unit> = v170521 10
                let _run_target_args'_v170520 = v170522 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v170523 : (int32 -> Async<unit>) = Async.Sleep
                let v170524 : Async<unit> = v170523 10
                let _run_target_args'_v170520 = v170524 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v170525 : (int32 -> Async<unit>) = Async.Sleep
                let v170526 : Async<unit> = v170525 10
                let _run_target_args'_v170520 = v170526 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v170527 : (int32 -> Async<unit>) = Async.Sleep
                let v170528 : Async<unit> = v170527 10
                let _run_target_args'_v170520 = v170528 
                #endif
#if FABLE_COMPILER_PYTHON
                let v170529 : (int32 -> Async<unit>) = Async.Sleep
                let v170530 : Async<unit> = v170529 10
                let _run_target_args'_v170520 = v170530 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v170531 : (int32 -> Async<unit>) = Async.Sleep
                let v170532 : Async<unit> = v170531 10
                let _run_target_args'_v170520 = v170532 
                #endif
#else
                let v170533 : (int32 -> Async<unit>) = Async.Sleep
                let v170534 : Async<unit> = v170533 10
                let _run_target_args'_v170520 = v170534 
                #endif
                let v170535 : Async<unit> = _run_target_args'_v170520 
                do! v170535 
                let v170541 : int64 = v1 + 1L
                let v170542 : Async<int64> = method44(v0, v170541)
                return! v170542 
                (* indent
                ()
            indent *)
            (* try_unit
            let v171282 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v225586 : Async<int64> = _let'_v112804 
    let _run_target_args'_v6 = v225586 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v225588 : unit = ()
    let _let'_v225588 =
        async {
            try
                (* run_target_args'
                let v280547 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v280548 : string = "std::fs::remove_file(&*$0)"
                let v280549 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v280548 
                let v280550 : (std_io_Error -> string) = method46()
                (* run_target_args'
                let v280552 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v280553 : string = "$0.map_err(|x| $1(x))"
                let v280554 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v280549, v280550) v280553 
                let _run_target_args'_v280552 = v280554 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v280555 : string = "$0.map_err(|x| $1(x))"
                let v280556 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v280549, v280550) v280555 
                let _run_target_args'_v280552 = v280556 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v280557 : string = "$0.map_err(|x| $1(x))"
                let v280558 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v280549, v280550) v280557 
                let _run_target_args'_v280552 = v280558 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v280559 : Result<unit, string> = match v280549 with Ok x -> Ok x | Error x -> Error (v280550 x)
                let _run_target_args'_v280552 = v280559 
                #endif
#if FABLE_COMPILER_PYTHON
                let v280560 : Result<unit, string> = match v280549 with Ok x -> Ok x | Error x -> Error (v280550 x)
                let _run_target_args'_v280552 = v280560 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v280561 : Result<unit, string> = match v280549 with Ok x -> Ok x | Error x -> Error (v280550 x)
                let _run_target_args'_v280552 = v280561 
                #endif
#else
                let v280562 : Result<unit, string> = match v280549 with Ok x -> Ok x | Error x -> Error (v280550 x)
                let _run_target_args'_v280552 = v280562 
                #endif
                let v280563 : Result<unit, string> = _run_target_args'_v280552 
                let v280566 : (unit -> US10) = method48()
                let v280567 : (string -> US10) = method49()
                let v280569 : US10 = match v280563 with Ok () -> v280566 () | Error x -> v280567 x
                match v280569 with
                | US10_1(v280572) -> (* Error *)
                    let v280884 : unit = ()
                    let v280885 : (unit -> unit) = closure26(v280572)
                    let v280886 : unit = (fun () -> v280885 (); v280884) ()
                    ()
                | US10_0 -> (* Ok *)
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
                let v281201 : (string -> unit) = System.IO.File.Delete
                v281201 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v282589 : exn = ex
                let v282590 : int64 = v1 % 100L
                let v282591 : bool = v282590 = 0L
                if v282591 then
                    let v282943 : unit = ()
                    let v282944 : (unit -> unit) = closure27(v0, v282589)
                    let v282945 : unit = (fun () -> v282944 (); v282943) ()
                    ()
                (* run_target_args'
                let v283304 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v283305 : (int32 -> Async<unit>) = Async.Sleep
                let v283306 : Async<unit> = v283305 10
                let _run_target_args'_v283304 = v283306 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v283307 : (int32 -> Async<unit>) = Async.Sleep
                let v283308 : Async<unit> = v283307 10
                let _run_target_args'_v283304 = v283308 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v283309 : (int32 -> Async<unit>) = Async.Sleep
                let v283310 : Async<unit> = v283309 10
                let _run_target_args'_v283304 = v283310 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v283311 : (int32 -> Async<unit>) = Async.Sleep
                let v283312 : Async<unit> = v283311 10
                let _run_target_args'_v283304 = v283312 
                #endif
#if FABLE_COMPILER_PYTHON
                let v283313 : (int32 -> Async<unit>) = Async.Sleep
                let v283314 : Async<unit> = v283313 10
                let _run_target_args'_v283304 = v283314 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v283315 : (int32 -> Async<unit>) = Async.Sleep
                let v283316 : Async<unit> = v283315 10
                let _run_target_args'_v283304 = v283316 
                #endif
#else
                let v283317 : (int32 -> Async<unit>) = Async.Sleep
                let v283318 : Async<unit> = v283317 10
                let _run_target_args'_v283304 = v283318 
                #endif
                let v283319 : Async<unit> = _run_target_args'_v283304 
                do! v283319 
                let v283325 : int64 = v1 + 1L
                let v283326 : Async<int64> = method44(v0, v283325)
                return! v283326 
                (* indent
                ()
            indent *)
            (* try_unit
            let v284066 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v338370 : Async<int64> = _let'_v225588 
    let _run_target_args'_v6 = v338370 
    #endif
#else
    let v338372 : unit = ()
    let _let'_v338372 =
        async {
            try
                (* run_target_args'
                let v393331 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v393332 : string = "std::fs::remove_file(&*$0)"
                let v393333 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v393332 
                let v393334 : (std_io_Error -> string) = method46()
                (* run_target_args'
                let v393336 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v393337 : string = "$0.map_err(|x| $1(x))"
                let v393338 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v393333, v393334) v393337 
                let _run_target_args'_v393336 = v393338 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v393339 : string = "$0.map_err(|x| $1(x))"
                let v393340 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v393333, v393334) v393339 
                let _run_target_args'_v393336 = v393340 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v393341 : string = "$0.map_err(|x| $1(x))"
                let v393342 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v393333, v393334) v393341 
                let _run_target_args'_v393336 = v393342 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v393343 : Result<unit, string> = match v393333 with Ok x -> Ok x | Error x -> Error (v393334 x)
                let _run_target_args'_v393336 = v393343 
                #endif
#if FABLE_COMPILER_PYTHON
                let v393344 : Result<unit, string> = match v393333 with Ok x -> Ok x | Error x -> Error (v393334 x)
                let _run_target_args'_v393336 = v393344 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v393345 : Result<unit, string> = match v393333 with Ok x -> Ok x | Error x -> Error (v393334 x)
                let _run_target_args'_v393336 = v393345 
                #endif
#else
                let v393346 : Result<unit, string> = match v393333 with Ok x -> Ok x | Error x -> Error (v393334 x)
                let _run_target_args'_v393336 = v393346 
                #endif
                let v393347 : Result<unit, string> = _run_target_args'_v393336 
                let v393350 : (unit -> US10) = method48()
                let v393351 : (string -> US10) = method49()
                let v393353 : US10 = match v393347 with Ok () -> v393350 () | Error x -> v393351 x
                match v393353 with
                | US10_1(v393356) -> (* Error *)
                    let v393668 : unit = ()
                    let v393669 : (unit -> unit) = closure26(v393356)
                    let v393670 : unit = (fun () -> v393669 (); v393668) ()
                    ()
                | US10_0 -> (* Ok *)
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
                let v393985 : (string -> unit) = System.IO.File.Delete
                v393985 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v395373 : exn = ex
                let v395374 : int64 = v1 % 100L
                let v395375 : bool = v395374 = 0L
                if v395375 then
                    let v395727 : unit = ()
                    let v395728 : (unit -> unit) = closure27(v0, v395373)
                    let v395729 : unit = (fun () -> v395728 (); v395727) ()
                    ()
                (* run_target_args'
                let v396088 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v396089 : (int32 -> Async<unit>) = Async.Sleep
                let v396090 : Async<unit> = v396089 10
                let _run_target_args'_v396088 = v396090 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v396091 : (int32 -> Async<unit>) = Async.Sleep
                let v396092 : Async<unit> = v396091 10
                let _run_target_args'_v396088 = v396092 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v396093 : (int32 -> Async<unit>) = Async.Sleep
                let v396094 : Async<unit> = v396093 10
                let _run_target_args'_v396088 = v396094 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v396095 : (int32 -> Async<unit>) = Async.Sleep
                let v396096 : Async<unit> = v396095 10
                let _run_target_args'_v396088 = v396096 
                #endif
#if FABLE_COMPILER_PYTHON
                let v396097 : (int32 -> Async<unit>) = Async.Sleep
                let v396098 : Async<unit> = v396097 10
                let _run_target_args'_v396088 = v396098 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v396099 : (int32 -> Async<unit>) = Async.Sleep
                let v396100 : Async<unit> = v396099 10
                let _run_target_args'_v396088 = v396100 
                #endif
#else
                let v396101 : (int32 -> Async<unit>) = Async.Sleep
                let v396102 : Async<unit> = v396101 10
                let _run_target_args'_v396088 = v396102 
                #endif
                let v396103 : Async<unit> = _run_target_args'_v396088 
                do! v396103 
                let v396109 : int64 = v1 + 1L
                let v396110 : Async<int64> = method44(v0, v396109)
                return! v396110 
                (* indent
                ()
            indent *)
            (* try_unit
            let v396850 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v451154 : Async<int64> = _let'_v338372 
    let _run_target_args'_v6 = v451154 
    #endif
    let v451155 : Async<int64> = _run_target_args'_v6 
    v451155
and method44 (v0 : string, v1 : int64) : Async<int64> =
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
    let v31 : Async<int64> = method45(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<int64> = _run_target_args'_v6 
    v32
and method43 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method44(v0, v1)
and closure22 () (v0 : string) : Async<int64> =
    method43(v0)
and method59 (v0 : string, v1 : string) : unit =
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
and method61 (v0 : string, v1 : string, v2 : string) : string =
    let v3 : string = method17()
    let v4 : Mut3 = {l0 = v3} : Mut3
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure6(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "old_path"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure6(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure6(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v63 : string = $"{v0}"
    let v71 : unit = ()
    let v72 : (unit -> unit) = closure6(v4, v63)
    let v73 : unit = (fun () -> v72 (); v71) ()
    let v81 : string = "; "
    let v82 : string = $"{v81}"
    let v90 : unit = ()
    let v91 : (unit -> unit) = closure6(v4, v82)
    let v92 : unit = (fun () -> v91 (); v90) ()
    let v100 : string = "new_path"
    let v101 : string = $"{v100}"
    let v109 : unit = ()
    let v110 : (unit -> unit) = closure6(v4, v101)
    let v111 : unit = (fun () -> v110 (); v109) ()
    let v118 : string = $"{v45}"
    let v126 : unit = ()
    let v127 : (unit -> unit) = closure6(v4, v118)
    let v128 : unit = (fun () -> v127 (); v126) ()
    let v135 : string = $"{v1}"
    let v143 : unit = ()
    let v144 : (unit -> unit) = closure6(v4, v135)
    let v145 : unit = (fun () -> v144 (); v143) ()
    let v152 : string = $"{v81}"
    let v160 : unit = ()
    let v161 : (unit -> unit) = closure6(v4, v152)
    let v162 : unit = (fun () -> v161 (); v160) ()
    let v170 : string = "ex"
    let v171 : string = $"{v170}"
    let v179 : unit = ()
    let v180 : (unit -> unit) = closure6(v4, v171)
    let v181 : unit = (fun () -> v180 (); v179) ()
    let v188 : string = $"{v45}"
    let v196 : unit = ()
    let v197 : (unit -> unit) = closure6(v4, v188)
    let v198 : unit = (fun () -> v197 (); v196) ()
    let v205 : string = $"{v2}"
    let v213 : unit = ()
    let v214 : (unit -> unit) = closure6(v4, v205)
    let v215 : unit = (fun () -> v214 (); v213) ()
    let v223 : string = " }"
    let v224 : string = $"{v223}"
    let v232 : unit = ()
    let v233 : (unit -> unit) = closure6(v4, v224)
    let v234 : unit = (fun () -> v233 (); v232) ()
    let v240 : string = v4.l0
    v240
and method60 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string, v10 : string) : string =
    let v11 : string = method61(v8, v9, v10)
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
    let v44 : string = "move_file_async"
    let v45 : string = v39 + v44 
    let v50 : string = " / "
    let v51 : string = v45 + v50 
    let v55 : string = v51 + v11 
    method22(v55)
and closure30 (v0 : string, v1 : string, v2 : exn) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure0()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut0, v43 : Mut1, v44 : Mut2, v45 : Mut3, v46 : Mut4, v47 : int64 option) = TraceState.trace_state.Value
    let v60 : US0 = v46.l0
    let v61 : bool = v44.l0
    let v62 : bool = v61 = false
    let v65 : bool =
        if v62 then
            false
        else
            let v63 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v60
            let v64 : bool = 3 >= v63
            v64
    let v66 : bool = v65 = false
    let v341 : US6 =
        if v66 then
            US6_1
        else
            let v82 : unit = ()
            let v83 : unit = (fun () -> v18 (); v82) ()
            let struct (v106 : Mut0, v107 : Mut1, v108 : Mut2, v109 : Mut3, v110 : Mut4, v111 : int64 option) = TraceState.trace_state.Value
            let v124 : string = method11(v106, v107, v108, v109, v110, v111)
            let v125 : string = method53()
            let v126 : string = method19(v1)
            let v127 : string = method19(v0)
            (* run_target_args'
            let v132 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v134 : string = $"%A{v2}"
            let _run_target_args'_v132 = v134 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v138 : string = $"%A{v2}"
            let _run_target_args'_v132 = v138 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v142 : string = $"%A{v2}"
            let _run_target_args'_v132 = v142 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v146 : string = $"%A{v2}"
            let _run_target_args'_v132 = v146 
            #endif
#if FABLE_COMPILER_PYTHON
            let v150 : string = $"%A{v2}"
            let _run_target_args'_v132 = v150 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v154 : string = $"%A{v2}"
            let _run_target_args'_v132 = v154 
            #endif
#else
            let v157 : string = $"{v2.GetType ()}: {v2.Message}"
            let _run_target_args'_v132 = v157 
            #endif
            let v158 : string = _run_target_args'_v132 
            let v167 : string = method60(v106, v107, v108, v109, v110, v111, v124, v125, v126, v127, v158)
            let v182 : unit = ()
            let v183 : unit = (fun () -> v18 (); v182) ()
            let struct (v206 : Mut0, v207 : Mut1, v208 : Mut2, v209 : Mut3, v210 : Mut4, v211 : int64 option) = TraceState.trace_state.Value
            let v226 : unit = ()
            let v227 : (unit -> unit) = closure7(v206)
            let v228 : unit = (fun () -> v227 (); v226) ()
            let v231 : (string -> unit) = closure8()
            (* run_target_args'
            let v232 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v233 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v167 v233 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v234 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v167 v234 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v235 : string = v209.l0
            let v236 : bool = v235 = ""
            let v251 : string =
                if v236 then
                    v167
                else
                    let v237 : bool = v167 = ""
                    if v237 then
                        let v238 : string = v209.l0
                        v238
                    else
                        let v239 : string = v209.l0
                        let v242 : string = "\n"
                        let v243 : string = v239 + v242 
                        let v247 : string = v243 + v167 
                        v247
            (* run_target_args'
            let v256 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v257 : string = "&*$0"
            let v258 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v251 v257 
            let _run_target_args'_v256 = v258 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v259 : string = "&*$0"
            let v260 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v251 v259 
            let _run_target_args'_v256 = v260 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v261 : string = "&*$0"
            let v262 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v251 v261 
            let _run_target_args'_v256 = v262 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v264 : Ref<Str> = v251 |> unbox<Ref<Str>>
            let _run_target_args'_v256 = v264 
            #endif
#if FABLE_COMPILER_PYTHON
            let v268 : Ref<Str> = v251 |> unbox<Ref<Str>>
            let _run_target_args'_v256 = v268 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v272 : Ref<Str> = v251 |> unbox<Ref<Str>>
            let _run_target_args'_v256 = v272 
            #endif
#else
            let v276 : Ref<Str> = v251 |> unbox<Ref<Str>>
            let _run_target_args'_v256 = v276 
            #endif
            let v279 : Ref<Str> = _run_target_args'_v256 
            let v288 : string = $"$0.chars()"
            let v289 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v279 v288 
            let v290 : string = "$0"
            let v291 : _ = Fable.Core.RustInterop.emitRustExpr v289 v290 
            let v292 : string = "$0.collect::<Vec<_>>()"
            let v293 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v291 v292 
            let v294 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v295 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v293 v294 
            let v296 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v297 : bool = Fable.Core.RustInterop.emitRustExpr v295 v296 
            let v298 : string = "x"
            let v299 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v298 
            let v300 : string = "String::from_iter($0)"
            let v301 : std_string_String = Fable.Core.RustInterop.emitRustExpr v299 v300 
            let v302 : string = "true; $0 }).collect::<Vec<_>>()"
            let v303 : bool = Fable.Core.RustInterop.emitRustExpr v301 v302 
            let v304 : string = "_vec_map"
            let v305 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v304 
            let v306 : string = "$0.len()"
            let v307 : unativeint = Fable.Core.RustInterop.emitRustExpr v305 v306 
            let v313 : int32 = v307 |> int32 
            let v323 : string = ""
            let v324 : bool = v167 <> v323 
            let v328 : bool =
                if v324 then
                    let v327 : bool = v313 <= 1
                    v327
                else
                    false
            if v328 then
                v209.l0 <- v251
                ()
            else
                v209.l0 <- v323
                let v329 : string = "true; $0.into_iter().for_each(|x| { //"
                let v330 : bool = Fable.Core.RustInterop.emitRustExpr v305 v329 
                let v331 : string = "x"
                let v332 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v331 
                let v333 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v334 : bool = Fable.Core.RustInterop.emitRustExpr v332 v333 
                let v335 : string = $"true"
                let v336 : bool = Fable.Core.RustInterop.emitRustExpr () v335 
                let v337 : string = "true; }); //"
                let v338 : bool = Fable.Core.RustInterop.emitRustExpr () v337 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v231 v167
            #endif
#if FABLE_COMPILER_PYTHON
            v231 v167
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v231 v167
            #endif
#else
            v231 v167
            #endif
            // run_target_args' is_unit
            let v339 : (string -> unit) = v207.l0
            v339 v167
            US6_0(v206, v207, v208, v209, v210, v211)
    
    ()
and method58 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
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
                method59(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v29540 : exn = ex
                let v29541 : int64 = v2 % 100L
                let v29542 : bool = v29541 = 0L
                if v29542 then
                    let v29895 : unit = ()
                    let v29896 : (unit -> unit) = closure30(v0, v1, v29540)
                    let v29897 : unit = (fun () -> v29896 (); v29895) ()
                    ()
                (* run_target_args'
                let v30257 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v30258 : (int32 -> Async<unit>) = Async.Sleep
                let v30259 : Async<unit> = v30258 10
                let _run_target_args'_v30257 = v30259 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v30260 : (int32 -> Async<unit>) = Async.Sleep
                let v30261 : Async<unit> = v30260 10
                let _run_target_args'_v30257 = v30261 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v30262 : (int32 -> Async<unit>) = Async.Sleep
                let v30263 : Async<unit> = v30262 10
                let _run_target_args'_v30257 = v30263 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v30264 : (int32 -> Async<unit>) = Async.Sleep
                let v30265 : Async<unit> = v30264 10
                let _run_target_args'_v30257 = v30265 
                #endif
#if FABLE_COMPILER_PYTHON
                let v30266 : (int32 -> Async<unit>) = Async.Sleep
                let v30267 : Async<unit> = v30266 10
                let _run_target_args'_v30257 = v30267 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v30268 : (int32 -> Async<unit>) = Async.Sleep
                let v30269 : Async<unit> = v30268 10
                let _run_target_args'_v30257 = v30269 
                #endif
#else
                let v30270 : (int32 -> Async<unit>) = Async.Sleep
                let v30271 : Async<unit> = v30270 10
                let _run_target_args'_v30257 = v30271 
                #endif
                let v30272 : Async<unit> = _run_target_args'_v30257 
                do! v30272 
                let v30278 : int64 = v2 + 1L
                let v30279 : Async<int64> = method57(v0, v1, v30278)
                return! v30279 
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
    let v59802 : Async<int64> = _let'_v21 
    let _run_target_args'_v7 = v59802 
    #endif
#if FABLE_COMPILER_PYTHON
    let v59804 : unit = ()
    let _let'_v59804 =
        async {
            try
                method59(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v89323 : exn = ex
                let v89324 : int64 = v2 % 100L
                let v89325 : bool = v89324 = 0L
                if v89325 then
                    let v89678 : unit = ()
                    let v89679 : (unit -> unit) = closure30(v0, v1, v89323)
                    let v89680 : unit = (fun () -> v89679 (); v89678) ()
                    ()
                (* run_target_args'
                let v90040 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v90041 : (int32 -> Async<unit>) = Async.Sleep
                let v90042 : Async<unit> = v90041 10
                let _run_target_args'_v90040 = v90042 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v90043 : (int32 -> Async<unit>) = Async.Sleep
                let v90044 : Async<unit> = v90043 10
                let _run_target_args'_v90040 = v90044 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v90045 : (int32 -> Async<unit>) = Async.Sleep
                let v90046 : Async<unit> = v90045 10
                let _run_target_args'_v90040 = v90046 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v90047 : (int32 -> Async<unit>) = Async.Sleep
                let v90048 : Async<unit> = v90047 10
                let _run_target_args'_v90040 = v90048 
                #endif
#if FABLE_COMPILER_PYTHON
                let v90049 : (int32 -> Async<unit>) = Async.Sleep
                let v90050 : Async<unit> = v90049 10
                let _run_target_args'_v90040 = v90050 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v90051 : (int32 -> Async<unit>) = Async.Sleep
                let v90052 : Async<unit> = v90051 10
                let _run_target_args'_v90040 = v90052 
                #endif
#else
                let v90053 : (int32 -> Async<unit>) = Async.Sleep
                let v90054 : Async<unit> = v90053 10
                let _run_target_args'_v90040 = v90054 
                #endif
                let v90055 : Async<unit> = _run_target_args'_v90040 
                do! v90055 
                let v90061 : int64 = v2 + 1L
                let v90062 : Async<int64> = method57(v0, v1, v90061)
                return! v90062 
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
    let v119585 : Async<int64> = _let'_v59804 
    let _run_target_args'_v7 = v119585 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v119587 : unit = ()
    let _let'_v119587 =
        async {
            try
                method59(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v149106 : exn = ex
                let v149107 : int64 = v2 % 100L
                let v149108 : bool = v149107 = 0L
                if v149108 then
                    let v149461 : unit = ()
                    let v149462 : (unit -> unit) = closure30(v0, v1, v149106)
                    let v149463 : unit = (fun () -> v149462 (); v149461) ()
                    ()
                (* run_target_args'
                let v149823 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v149824 : (int32 -> Async<unit>) = Async.Sleep
                let v149825 : Async<unit> = v149824 10
                let _run_target_args'_v149823 = v149825 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v149826 : (int32 -> Async<unit>) = Async.Sleep
                let v149827 : Async<unit> = v149826 10
                let _run_target_args'_v149823 = v149827 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v149828 : (int32 -> Async<unit>) = Async.Sleep
                let v149829 : Async<unit> = v149828 10
                let _run_target_args'_v149823 = v149829 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v149830 : (int32 -> Async<unit>) = Async.Sleep
                let v149831 : Async<unit> = v149830 10
                let _run_target_args'_v149823 = v149831 
                #endif
#if FABLE_COMPILER_PYTHON
                let v149832 : (int32 -> Async<unit>) = Async.Sleep
                let v149833 : Async<unit> = v149832 10
                let _run_target_args'_v149823 = v149833 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v149834 : (int32 -> Async<unit>) = Async.Sleep
                let v149835 : Async<unit> = v149834 10
                let _run_target_args'_v149823 = v149835 
                #endif
#else
                let v149836 : (int32 -> Async<unit>) = Async.Sleep
                let v149837 : Async<unit> = v149836 10
                let _run_target_args'_v149823 = v149837 
                #endif
                let v149838 : Async<unit> = _run_target_args'_v149823 
                do! v149838 
                let v149844 : int64 = v2 + 1L
                let v149845 : Async<int64> = method57(v0, v1, v149844)
                return! v149845 
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
    let v179368 : Async<int64> = _let'_v119587 
    let _run_target_args'_v7 = v179368 
    #endif
#else
    let v179370 : unit = ()
    let _let'_v179370 =
        async {
            try
                method59(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v208889 : exn = ex
                let v208890 : int64 = v2 % 100L
                let v208891 : bool = v208890 = 0L
                if v208891 then
                    let v209244 : unit = ()
                    let v209245 : (unit -> unit) = closure30(v0, v1, v208889)
                    let v209246 : unit = (fun () -> v209245 (); v209244) ()
                    ()
                (* run_target_args'
                let v209606 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v209607 : (int32 -> Async<unit>) = Async.Sleep
                let v209608 : Async<unit> = v209607 10
                let _run_target_args'_v209606 = v209608 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v209609 : (int32 -> Async<unit>) = Async.Sleep
                let v209610 : Async<unit> = v209609 10
                let _run_target_args'_v209606 = v209610 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v209611 : (int32 -> Async<unit>) = Async.Sleep
                let v209612 : Async<unit> = v209611 10
                let _run_target_args'_v209606 = v209612 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v209613 : (int32 -> Async<unit>) = Async.Sleep
                let v209614 : Async<unit> = v209613 10
                let _run_target_args'_v209606 = v209614 
                #endif
#if FABLE_COMPILER_PYTHON
                let v209615 : (int32 -> Async<unit>) = Async.Sleep
                let v209616 : Async<unit> = v209615 10
                let _run_target_args'_v209606 = v209616 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v209617 : (int32 -> Async<unit>) = Async.Sleep
                let v209618 : Async<unit> = v209617 10
                let _run_target_args'_v209606 = v209618 
                #endif
#else
                let v209619 : (int32 -> Async<unit>) = Async.Sleep
                let v209620 : Async<unit> = v209619 10
                let _run_target_args'_v209606 = v209620 
                #endif
                let v209621 : Async<unit> = _run_target_args'_v209606 
                do! v209621 
                let v209627 : int64 = v2 + 1L
                let v209628 : Async<int64> = method57(v0, v1, v209627)
                return! v209628 
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
    let v239151 : Async<int64> = _let'_v179370 
    let _run_target_args'_v7 = v239151 
    #endif
    let v239152 : Async<int64> = _run_target_args'_v7 
    v239152
and method57 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
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
    let v32 : Async<int64> = method58(v0, v1, v2)
    let _run_target_args'_v7 = v32 
    #endif
    let v33 : Async<int64> = _run_target_args'_v7 
    v33
and method56 (v0 : string, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method57(v0, v1, v2)
and closure29 (v0 : string) (v1 : string) : Async<int64> =
    method56(v0, v1)
and closure28 () (v0 : string) : (string -> Async<int64>) =
    closure29(v0)
and closure32 () (v0 : int64) : US11 =
    US11_0(v0)
and method68 () : (int64 -> US11) =
    closure32()
and closure33 () (v0 : exn) : US11 =
    US11_1(v0)
and method69 () : (exn -> US11) =
    closure33()
and method67 (v0 : Async<Choice<int64, exn>>) : Async<US11> =
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
            let v555 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v560 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v562 : US11 = null |> unbox<US11>
            let _run_target_args'_v560 = v562 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v566 : US11 = null |> unbox<US11>
            let _run_target_args'_v560 = v566 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v570 : US11 = null |> unbox<US11>
            let _run_target_args'_v560 = v570 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v574 : US11 = null |> unbox<US11>
            let _run_target_args'_v560 = v574 
            #endif
#if FABLE_COMPILER_PYTHON
            let v578 : US11 = null |> unbox<US11>
            let _run_target_args'_v560 = v578 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v581 : (int64 -> US11) = method68()
            let v582 : (exn -> US11) = method69()
            let v583 : US11 = match v555 with Choice1Of2 x -> v581 x | Choice2Of2 x -> v582 x
            let _run_target_args'_v560 = v583 
            #endif
#else
            let v584 : (int64 -> US11) = method68()
            let v585 : (exn -> US11) = method69()
            let v586 : US11 = match v555 with Choice1Of2 x -> v584 x | Choice2Of2 x -> v585 x
            let _run_target_args'_v560 = v586 
            #endif
            let v587 : US11 = _run_target_args'_v560 
            return v587 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1129 : Async<US11> = _let'_v19 
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
            let v1674 : US11 = null |> unbox<US11>
            let _run_target_args'_v1672 = v1674 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1678 : US11 = null |> unbox<US11>
            let _run_target_args'_v1672 = v1678 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1682 : US11 = null |> unbox<US11>
            let _run_target_args'_v1672 = v1682 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1686 : US11 = null |> unbox<US11>
            let _run_target_args'_v1672 = v1686 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1690 : US11 = null |> unbox<US11>
            let _run_target_args'_v1672 = v1690 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1693 : (int64 -> US11) = method68()
            let v1694 : (exn -> US11) = method69()
            let v1695 : US11 = match v1667 with Choice1Of2 x -> v1693 x | Choice2Of2 x -> v1694 x
            let _run_target_args'_v1672 = v1695 
            #endif
#else
            let v1696 : (int64 -> US11) = method68()
            let v1697 : (exn -> US11) = method69()
            let v1698 : US11 = match v1667 with Choice1Of2 x -> v1696 x | Choice2Of2 x -> v1697 x
            let _run_target_args'_v1672 = v1698 
            #endif
            let v1699 : US11 = _run_target_args'_v1672 
            return v1699 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2241 : Async<US11> = _let'_v1131 
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
            let v2786 : US11 = null |> unbox<US11>
            let _run_target_args'_v2784 = v2786 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2790 : US11 = null |> unbox<US11>
            let _run_target_args'_v2784 = v2790 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2794 : US11 = null |> unbox<US11>
            let _run_target_args'_v2784 = v2794 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2798 : US11 = null |> unbox<US11>
            let _run_target_args'_v2784 = v2798 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2802 : US11 = null |> unbox<US11>
            let _run_target_args'_v2784 = v2802 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2805 : (int64 -> US11) = method68()
            let v2806 : (exn -> US11) = method69()
            let v2807 : US11 = match v2779 with Choice1Of2 x -> v2805 x | Choice2Of2 x -> v2806 x
            let _run_target_args'_v2784 = v2807 
            #endif
#else
            let v2808 : (int64 -> US11) = method68()
            let v2809 : (exn -> US11) = method69()
            let v2810 : US11 = match v2779 with Choice1Of2 x -> v2808 x | Choice2Of2 x -> v2809 x
            let _run_target_args'_v2784 = v2810 
            #endif
            let v2811 : US11 = _run_target_args'_v2784 
            return v2811 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3353 : Async<US11> = _let'_v2243 
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
            let v3898 : US11 = null |> unbox<US11>
            let _run_target_args'_v3896 = v3898 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3902 : US11 = null |> unbox<US11>
            let _run_target_args'_v3896 = v3902 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3906 : US11 = null |> unbox<US11>
            let _run_target_args'_v3896 = v3906 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3910 : US11 = null |> unbox<US11>
            let _run_target_args'_v3896 = v3910 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3914 : US11 = null |> unbox<US11>
            let _run_target_args'_v3896 = v3914 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3917 : (int64 -> US11) = method68()
            let v3918 : (exn -> US11) = method69()
            let v3919 : US11 = match v3891 with Choice1Of2 x -> v3917 x | Choice2Of2 x -> v3918 x
            let _run_target_args'_v3896 = v3919 
            #endif
#else
            let v3920 : (int64 -> US11) = method68()
            let v3921 : (exn -> US11) = method69()
            let v3922 : US11 = match v3891 with Choice1Of2 x -> v3920 x | Choice2Of2 x -> v3921 x
            let _run_target_args'_v3896 = v3922 
            #endif
            let v3923 : US11 = _run_target_args'_v3896 
            return v3923 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4465 : Async<US11> = _let'_v3355 
    let _run_target_args'_v5 = v4465 
    #endif
    let v4466 : Async<US11> = _run_target_args'_v5 
    v4466
and method70 (v0 : Async<US11>) : Async<US12> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US12> = null |> unbox<Async<US12>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<US12> = null |> unbox<Async<US12>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<US12> = null |> unbox<Async<US12>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            let! v0 = v0 
            let v113 : US11 = v0 
            let v119 : US12 =
                match v113 with
                | US11_0(v114) -> (* C1of2 *)
                    US12_0(v114)
                | US11_1(v116) -> (* C2of2 *)
                    US12_1(v116)
            return v119 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v211 : Async<US12> = _let'_v19 
    let _run_target_args'_v5 = v211 
    #endif
#if FABLE_COMPILER_PYTHON
    let v213 : unit = ()
    let _let'_v213 =
        async {
            let! v0 = v0 
            let v307 : US11 = v0 
            let v313 : US12 =
                match v307 with
                | US11_0(v308) -> (* C1of2 *)
                    US12_0(v308)
                | US11_1(v310) -> (* C2of2 *)
                    US12_1(v310)
            return v313 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v405 : Async<US12> = _let'_v213 
    let _run_target_args'_v5 = v405 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v407 : unit = ()
    let _let'_v407 =
        async {
            let! v0 = v0 
            let v501 : US11 = v0 
            let v507 : US12 =
                match v501 with
                | US11_0(v502) -> (* C1of2 *)
                    US12_0(v502)
                | US11_1(v504) -> (* C2of2 *)
                    US12_1(v504)
            return v507 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v599 : Async<US12> = _let'_v407 
    let _run_target_args'_v5 = v599 
    #endif
#else
    let v601 : unit = ()
    let _let'_v601 =
        async {
            let! v0 = v0 
            let v695 : US11 = v0 
            let v701 : US12 =
                match v695 with
                | US11_0(v696) -> (* C1of2 *)
                    US12_0(v696)
                | US11_1(v698) -> (* C2of2 *)
                    US12_1(v698)
            return v701 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v793 : Async<US12> = _let'_v601 
    let _run_target_args'_v5 = v793 
    #endif
    let v794 : Async<US12> = _run_target_args'_v5 
    v794
and method73 (v0 : int32) : string =
    let v1 : string = method17()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "timeout"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v64 : string = $"{v0}"
    let v72 : unit = ()
    let v73 : (unit -> unit) = closure6(v2, v64)
    let v74 : unit = (fun () -> v73 (); v72) ()
    let v82 : string = " }"
    let v83 : string = $"{v82}"
    let v91 : unit = ()
    let v92 : (unit -> unit) = closure6(v2, v83)
    let v93 : unit = (fun () -> v92 (); v91) ()
    let v99 : string = v2.l0
    v99
and method72 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32) : string =
    let v9 : string = method73(v8)
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
    let v42 : string = "async.run_with_timeout_async"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method22(v53)
and closure34 (v0 : int32) () : unit =
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
    let v298 : US6 =
        if v64 then
            US6_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method11(v104, v105, v106, v107, v108, v109)
            let v123 : string = method32()
            let v124 : string = method72(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure7(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure8()
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
and method75 (v0 : int32, v1 : string) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "timeout"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure6(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "ex"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure6(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    let v137 : string = $"{v1}"
    let v145 : unit = ()
    let v146 : (unit -> unit) = closure6(v3, v137)
    let v147 : unit = (fun () -> v146 (); v145) ()
    let v155 : string = " }"
    let v156 : string = $"{v155}"
    let v164 : unit = ()
    let v165 : (unit -> unit) = closure6(v3, v156)
    let v166 : unit = (fun () -> v165 (); v164) ()
    let v172 : string = v3.l0
    v172
and method74 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string) : string =
    let v10 : string = method75(v8, v9)
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
    let v43 : string = "async.run_with_timeout_async**"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
and closure35 (v0 : int32, v1 : exn) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 4 >= v62
            v63
    let v65 : bool = v64 = false
    let v338 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method50()
            (* run_target_args'
            let v129 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = $"%A{v1}"
            let _run_target_args'_v129 = v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v135 : string = $"%A{v1}"
            let _run_target_args'_v129 = v135 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v139 : string = $"%A{v1}"
            let _run_target_args'_v129 = v139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v143 : string = $"%A{v1}"
            let _run_target_args'_v129 = v143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v147 : string = $"%A{v1}"
            let _run_target_args'_v129 = v147 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v151 : string = $"%A{v1}"
            let _run_target_args'_v129 = v151 
            #endif
#else
            let v154 : string = $"{v1.GetType ()}: {v1.Message}"
            let _run_target_args'_v129 = v154 
            #endif
            let v155 : string = _run_target_args'_v129 
            let v164 : string = method74(v105, v106, v107, v108, v109, v110, v123, v124, v0, v155)
            let v179 : unit = ()
            let v180 : unit = (fun () -> v17 (); v179) ()
            let struct (v203 : Mut0, v204 : Mut1, v205 : Mut2, v206 : Mut3, v207 : Mut4, v208 : int64 option) = TraceState.trace_state.Value
            let v223 : unit = ()
            let v224 : (unit -> unit) = closure7(v203)
            let v225 : unit = (fun () -> v224 (); v223) ()
            let v228 : (string -> unit) = closure8()
            (* run_target_args'
            let v229 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v230 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v230 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v231 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v231 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v232 : string = v206.l0
            let v233 : bool = v232 = ""
            let v248 : string =
                if v233 then
                    v164
                else
                    let v234 : bool = v164 = ""
                    if v234 then
                        let v235 : string = v206.l0
                        v235
                    else
                        let v236 : string = v206.l0
                        let v239 : string = "\n"
                        let v240 : string = v236 + v239 
                        let v244 : string = v240 + v164 
                        v244
            (* run_target_args'
            let v253 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v254 : string = "&*$0"
            let v255 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v254 
            let _run_target_args'_v253 = v255 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v256 : string = "&*$0"
            let v257 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v256 
            let _run_target_args'_v253 = v257 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v258 : string = "&*$0"
            let v259 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v258 
            let _run_target_args'_v253 = v259 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v261 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v261 
            #endif
#if FABLE_COMPILER_PYTHON
            let v265 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v269 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v269 
            #endif
#else
            let v273 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v273 
            #endif
            let v276 : Ref<Str> = _run_target_args'_v253 
            let v285 : string = $"$0.chars()"
            let v286 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v276 v285 
            let v287 : string = "$0"
            let v288 : _ = Fable.Core.RustInterop.emitRustExpr v286 v287 
            let v289 : string = "$0.collect::<Vec<_>>()"
            let v290 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v288 v289 
            let v291 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v292 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v290 v291 
            let v293 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v294 : bool = Fable.Core.RustInterop.emitRustExpr v292 v293 
            let v295 : string = "x"
            let v296 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v295 
            let v297 : string = "String::from_iter($0)"
            let v298 : std_string_String = Fable.Core.RustInterop.emitRustExpr v296 v297 
            let v299 : string = "true; $0 }).collect::<Vec<_>>()"
            let v300 : bool = Fable.Core.RustInterop.emitRustExpr v298 v299 
            let v301 : string = "_vec_map"
            let v302 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v301 
            let v303 : string = "$0.len()"
            let v304 : unativeint = Fable.Core.RustInterop.emitRustExpr v302 v303 
            let v310 : int32 = v304 |> int32 
            let v320 : string = ""
            let v321 : bool = v164 <> v320 
            let v325 : bool =
                if v321 then
                    let v324 : bool = v310 <= 1
                    v324
                else
                    false
            if v325 then
                v206.l0 <- v248
                ()
            else
                v206.l0 <- v320
                let v326 : string = "true; $0.into_iter().for_each(|x| { //"
                let v327 : bool = Fable.Core.RustInterop.emitRustExpr v302 v326 
                let v328 : string = "x"
                let v329 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v328 
                let v330 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr v329 v330 
                let v332 : string = $"true"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
                let v334 : string = "true; }); //"
                let v335 : bool = Fable.Core.RustInterop.emitRustExpr () v334 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v228 v164
            #endif
#if FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#else
            v228 v164
            #endif
            // run_target_args' is_unit
            let v336 : (string -> unit) = v204.l0
            v336 v164
            US6_0(v203, v204, v205, v206, v207, v208)
    
    ()
and method71 (v0 : int32, v1 : Async<US12>) : Async<US2> =
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
            let v17551 : US12 = v1 
            let v18903 : US2 =
                match v17551 with
                | US12_1(v17554) -> (* Error *)
                    let v17556 : string = $"%A{v17554}"
                    let v17561 : string = "System.TimeoutException"
                    let v17562 : bool = v17556.Contains v17561 
                    if v17562 then
                        let v17876 : unit = ()
                        let v17877 : (unit -> unit) = closure34(v0)
                        let v17878 : unit = (fun () -> v17877 (); v17876) ()
                        US2_1
                    else
                        let v18544 : unit = ()
                        let v18545 : (unit -> unit) = closure35(v0, v17554)
                        let v18546 : unit = (fun () -> v18545 (); v18544) ()
                        US2_1
                | US12_0(v17552) -> (* Ok *)
                    US2_0(v17552)
            return v18903 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36446 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v36446 
    #endif
#if FABLE_COMPILER_PYTHON
    let v36448 : unit = ()
    let _let'_v36448 =
        async {
            let! v1 = v1 
            let v53979 : US12 = v1 
            let v55331 : US2 =
                match v53979 with
                | US12_1(v53982) -> (* Error *)
                    let v53984 : string = $"%A{v53982}"
                    let v53989 : string = "System.TimeoutException"
                    let v53990 : bool = v53984.Contains v53989 
                    if v53990 then
                        let v54304 : unit = ()
                        let v54305 : (unit -> unit) = closure34(v0)
                        let v54306 : unit = (fun () -> v54305 (); v54304) ()
                        US2_1
                    else
                        let v54972 : unit = ()
                        let v54973 : (unit -> unit) = closure35(v0, v53982)
                        let v54974 : unit = (fun () -> v54973 (); v54972) ()
                        US2_1
                | US12_0(v53980) -> (* Ok *)
                    US2_0(v53980)
            return v55331 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v72874 : Async<US2> = _let'_v36448 
    let _run_target_args'_v6 = v72874 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v72876 : unit = ()
    let _let'_v72876 =
        async {
            let! v1 = v1 
            let v90407 : US12 = v1 
            let v91759 : US2 =
                match v90407 with
                | US12_1(v90410) -> (* Error *)
                    let v90412 : string = $"%A{v90410}"
                    let v90417 : string = "System.TimeoutException"
                    let v90418 : bool = v90412.Contains v90417 
                    if v90418 then
                        let v90732 : unit = ()
                        let v90733 : (unit -> unit) = closure34(v0)
                        let v90734 : unit = (fun () -> v90733 (); v90732) ()
                        US2_1
                    else
                        let v91400 : unit = ()
                        let v91401 : (unit -> unit) = closure35(v0, v90410)
                        let v91402 : unit = (fun () -> v91401 (); v91400) ()
                        US2_1
                | US12_0(v90408) -> (* Ok *)
                    US2_0(v90408)
            return v91759 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v109302 : Async<US2> = _let'_v72876 
    let _run_target_args'_v6 = v109302 
    #endif
#else
    let v109304 : unit = ()
    let _let'_v109304 =
        async {
            let! v1 = v1 
            let v126835 : US12 = v1 
            let v128187 : US2 =
                match v126835 with
                | US12_1(v126838) -> (* Error *)
                    let v126840 : string = $"%A{v126838}"
                    let v126845 : string = "System.TimeoutException"
                    let v126846 : bool = v126840.Contains v126845 
                    if v126846 then
                        let v127160 : unit = ()
                        let v127161 : (unit -> unit) = closure34(v0)
                        let v127162 : unit = (fun () -> v127161 (); v127160) ()
                        US2_1
                    else
                        let v127828 : unit = ()
                        let v127829 : (unit -> unit) = closure35(v0, v126838)
                        let v127830 : unit = (fun () -> v127829 (); v127828) ()
                        US2_1
                | US12_0(v126836) -> (* Ok *)
                    US2_0(v126836)
            return v128187 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v145730 : Async<US2> = _let'_v109304 
    let _run_target_args'_v6 = v145730 
    #endif
    let v145731 : Async<US2> = _run_target_args'_v6 
    v145731
and method66 (v0 : Async<int64>, v1 : int32) : Async<US2> =
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
            let v972 : Async<US11> = method67(v963)
            let v973 : Async<US12> = method70(v972)
            let v974 : Async<US2> = method71(v1, v973)
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
            let v2813 : Async<US11> = method67(v2804)
            let v2814 : Async<US12> = method70(v2813)
            let v2815 : Async<US2> = method71(v1, v2814)
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
            let v4654 : Async<US11> = method67(v4645)
            let v4655 : Async<US12> = method70(v4654)
            let v4656 : Async<US2> = method71(v1, v4655)
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
            let v6495 : Async<US11> = method67(v6486)
            let v6496 : Async<US12> = method70(v6495)
            let v6497 : Async<US2> = method71(v1, v6496)
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
and method65 (v0 : int32, v1 : Async<int64>) : Async<US2> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US2> = method66(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US2> = _run_target_args'_v6 
    v14
and method76 (v0 : Async<string>) : Async<string option> =
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
and method78 (v0 : int64, v1 : string) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "retry"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v65 : string = $"{v0}"
    let v73 : unit = ()
    let v74 : (unit -> unit) = closure6(v3, v65)
    let v75 : unit = (fun () -> v74 (); v73) ()
    let v83 : string = "; "
    let v84 : string = $"{v83}"
    let v92 : unit = ()
    let v93 : (unit -> unit) = closure6(v3, v84)
    let v94 : unit = (fun () -> v93 (); v92) ()
    let v102 : string = "ex"
    let v103 : string = $"{v102}"
    let v111 : unit = ()
    let v112 : (unit -> unit) = closure6(v3, v103)
    let v113 : unit = (fun () -> v112 (); v111) ()
    let v120 : string = $"{v44}"
    let v128 : unit = ()
    let v129 : (unit -> unit) = closure6(v3, v120)
    let v130 : unit = (fun () -> v129 (); v128) ()
    let v137 : string = $"{v1}"
    let v145 : unit = ()
    let v146 : (unit -> unit) = closure6(v3, v137)
    let v147 : unit = (fun () -> v146 (); v145) ()
    let v155 : string = " }"
    let v156 : string = $"{v155}"
    let v164 : unit = ()
    let v165 : (unit -> unit) = closure6(v3, v156)
    let v166 : unit = (fun () -> v165 (); v164) ()
    let v172 : string = v3.l0
    v172
and method77 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string) : string =
    let v10 : string = method78(v8, v9)
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
    let v43 : string = "file_system.read_all_text_retry_async"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
and closure36 (v0 : int64, v1 : exn) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 1 >= v62
            v63
    let v65 : bool = v64 = false
    let v338 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method15()
            (* run_target_args'
            let v129 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v131 : string = $"%A{v1}"
            let _run_target_args'_v129 = v131 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v135 : string = $"%A{v1}"
            let _run_target_args'_v129 = v135 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v139 : string = $"%A{v1}"
            let _run_target_args'_v129 = v139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v143 : string = $"%A{v1}"
            let _run_target_args'_v129 = v143 
            #endif
#if FABLE_COMPILER_PYTHON
            let v147 : string = $"%A{v1}"
            let _run_target_args'_v129 = v147 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v151 : string = $"%A{v1}"
            let _run_target_args'_v129 = v151 
            #endif
#else
            let v154 : string = $"{v1.GetType ()}: {v1.Message}"
            let _run_target_args'_v129 = v154 
            #endif
            let v155 : string = _run_target_args'_v129 
            let v164 : string = method77(v105, v106, v107, v108, v109, v110, v123, v124, v0, v155)
            let v179 : unit = ()
            let v180 : unit = (fun () -> v17 (); v179) ()
            let struct (v203 : Mut0, v204 : Mut1, v205 : Mut2, v206 : Mut3, v207 : Mut4, v208 : int64 option) = TraceState.trace_state.Value
            let v223 : unit = ()
            let v224 : (unit -> unit) = closure7(v203)
            let v225 : unit = (fun () -> v224 (); v223) ()
            let v228 : (string -> unit) = closure8()
            (* run_target_args'
            let v229 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v230 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v230 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v231 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v164 v231 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v232 : string = v206.l0
            let v233 : bool = v232 = ""
            let v248 : string =
                if v233 then
                    v164
                else
                    let v234 : bool = v164 = ""
                    if v234 then
                        let v235 : string = v206.l0
                        v235
                    else
                        let v236 : string = v206.l0
                        let v239 : string = "\n"
                        let v240 : string = v236 + v239 
                        let v244 : string = v240 + v164 
                        v244
            (* run_target_args'
            let v253 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v254 : string = "&*$0"
            let v255 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v254 
            let _run_target_args'_v253 = v255 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v256 : string = "&*$0"
            let v257 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v256 
            let _run_target_args'_v253 = v257 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v258 : string = "&*$0"
            let v259 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v248 v258 
            let _run_target_args'_v253 = v259 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v261 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v261 
            #endif
#if FABLE_COMPILER_PYTHON
            let v265 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v265 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v269 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v269 
            #endif
#else
            let v273 : Ref<Str> = v248 |> unbox<Ref<Str>>
            let _run_target_args'_v253 = v273 
            #endif
            let v276 : Ref<Str> = _run_target_args'_v253 
            let v285 : string = $"$0.chars()"
            let v286 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v276 v285 
            let v287 : string = "$0"
            let v288 : _ = Fable.Core.RustInterop.emitRustExpr v286 v287 
            let v289 : string = "$0.collect::<Vec<_>>()"
            let v290 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v288 v289 
            let v291 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v292 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v290 v291 
            let v293 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v294 : bool = Fable.Core.RustInterop.emitRustExpr v292 v293 
            let v295 : string = "x"
            let v296 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v295 
            let v297 : string = "String::from_iter($0)"
            let v298 : std_string_String = Fable.Core.RustInterop.emitRustExpr v296 v297 
            let v299 : string = "true; $0 }).collect::<Vec<_>>()"
            let v300 : bool = Fable.Core.RustInterop.emitRustExpr v298 v299 
            let v301 : string = "_vec_map"
            let v302 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v301 
            let v303 : string = "$0.len()"
            let v304 : unativeint = Fable.Core.RustInterop.emitRustExpr v302 v303 
            let v310 : int32 = v304 |> int32 
            let v320 : string = ""
            let v321 : bool = v164 <> v320 
            let v325 : bool =
                if v321 then
                    let v324 : bool = v310 <= 1
                    v324
                else
                    false
            if v325 then
                v206.l0 <- v248
                ()
            else
                v206.l0 <- v320
                let v326 : string = "true; $0.into_iter().for_each(|x| { //"
                let v327 : bool = Fable.Core.RustInterop.emitRustExpr v302 v326 
                let v328 : string = "x"
                let v329 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v328 
                let v330 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v331 : bool = Fable.Core.RustInterop.emitRustExpr v329 v330 
                let v332 : string = $"true"
                let v333 : bool = Fable.Core.RustInterop.emitRustExpr () v332 
                let v334 : string = "true; }); //"
                let v335 : bool = Fable.Core.RustInterop.emitRustExpr () v334 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v228 v164
            #endif
#if FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v228 v164
            #endif
#else
            v228 v164
            #endif
            // run_target_args' is_unit
            let v336 : (string -> unit) = v204.l0
            v336 v164
            US6_0(v203, v204, v205, v206, v207, v208)
    
    ()
and method64 (v0 : string, v1 : int64) : Async<string option> =
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
                let v29482 : bool = v1 > 0L
                if v29482 then
                    let v29483 : Async<int64> = method28(v0)
                    let v29484 : int32 = 1000
                    let v29485 : Async<US2> = method65(v29484, v29483)
                    (* run_target_args'
                    let v29490 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v29492 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29490 = v29492 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v29496 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29490 = v29496 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v29500 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29490 = v29500 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v29503 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29504 : Async<unit> = v29503 v29485
                    let _run_target_args'_v29490 = v29504 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v29505 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29506 : Async<unit> = v29505 v29485
                    let _run_target_args'_v29490 = v29506 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v29507 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29508 : Async<unit> = v29507 v29485
                    let _run_target_args'_v29490 = v29508 
                    #endif
#else
                    let v29509 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29510 : Async<unit> = v29509 v29485
                    let _run_target_args'_v29490 = v29510 
                    #endif
                    let v29511 : Async<unit> = _run_target_args'_v29490 
                    do! v29511 
                    ()
                let v29520 : Async<string> = method29(v0)
                let v29521 : Async<string option> = method76(v29520)
                return! v29521 
                (* indent
                ()
            indent *)
            with ex ->
                let v30271 : exn = ex
                let v30272 : bool = v1 = 0L
                let v30273 : bool = v30272 <> true
                if v30273 then
                    let v30624 : unit = ()
                    let v30625 : (unit -> unit) = closure36(v1, v30271)
                    let v30626 : unit = (fun () -> v30625 (); v30624) ()
                    let v30981 : string option = None
                    return v30981 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v30984 : int64 = v1 + 1L
                    let v30985 : Async<string option> = method63(v0, v30984)
                    return! v30985 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v31702 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v61124 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v61124 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61126 : unit = ()
    let _let'_v61126 =
        async {
            try
                let v90588 : bool = v1 > 0L
                if v90588 then
                    let v90589 : Async<int64> = method28(v0)
                    let v90590 : int32 = 1000
                    let v90591 : Async<US2> = method65(v90590, v90589)
                    (* run_target_args'
                    let v90596 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v90598 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v90596 = v90598 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v90602 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v90596 = v90602 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v90606 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v90596 = v90606 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v90609 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90610 : Async<unit> = v90609 v90591
                    let _run_target_args'_v90596 = v90610 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v90611 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90612 : Async<unit> = v90611 v90591
                    let _run_target_args'_v90596 = v90612 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v90613 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90614 : Async<unit> = v90613 v90591
                    let _run_target_args'_v90596 = v90614 
                    #endif
#else
                    let v90615 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90616 : Async<unit> = v90615 v90591
                    let _run_target_args'_v90596 = v90616 
                    #endif
                    let v90617 : Async<unit> = _run_target_args'_v90596 
                    do! v90617 
                    ()
                let v90626 : Async<string> = method29(v0)
                let v90627 : Async<string option> = method76(v90626)
                return! v90627 
                (* indent
                ()
            indent *)
            with ex ->
                let v91377 : exn = ex
                let v91378 : bool = v1 = 0L
                let v91379 : bool = v91378 <> true
                if v91379 then
                    let v91730 : unit = ()
                    let v91731 : (unit -> unit) = closure36(v1, v91377)
                    let v91732 : unit = (fun () -> v91731 (); v91730) ()
                    let v92087 : string option = None
                    return v92087 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v92090 : int64 = v1 + 1L
                    let v92091 : Async<string option> = method63(v0, v92090)
                    return! v92091 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v92808 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v122230 : Async<string option> = _let'_v61126 
    let _run_target_args'_v6 = v122230 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v122232 : unit = ()
    let _let'_v122232 =
        async {
            try
                let v151694 : bool = v1 > 0L
                if v151694 then
                    let v151695 : Async<int64> = method28(v0)
                    let v151696 : int32 = 1000
                    let v151697 : Async<US2> = method65(v151696, v151695)
                    (* run_target_args'
                    let v151702 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v151704 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v151702 = v151704 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v151708 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v151702 = v151708 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v151712 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v151702 = v151712 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v151715 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151716 : Async<unit> = v151715 v151697
                    let _run_target_args'_v151702 = v151716 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v151717 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151718 : Async<unit> = v151717 v151697
                    let _run_target_args'_v151702 = v151718 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v151719 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151720 : Async<unit> = v151719 v151697
                    let _run_target_args'_v151702 = v151720 
                    #endif
#else
                    let v151721 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151722 : Async<unit> = v151721 v151697
                    let _run_target_args'_v151702 = v151722 
                    #endif
                    let v151723 : Async<unit> = _run_target_args'_v151702 
                    do! v151723 
                    ()
                let v151732 : Async<string> = method29(v0)
                let v151733 : Async<string option> = method76(v151732)
                return! v151733 
                (* indent
                ()
            indent *)
            with ex ->
                let v152483 : exn = ex
                let v152484 : bool = v1 = 0L
                let v152485 : bool = v152484 <> true
                if v152485 then
                    let v152836 : unit = ()
                    let v152837 : (unit -> unit) = closure36(v1, v152483)
                    let v152838 : unit = (fun () -> v152837 (); v152836) ()
                    let v153193 : string option = None
                    return v153193 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v153196 : int64 = v1 + 1L
                    let v153197 : Async<string option> = method63(v0, v153196)
                    return! v153197 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v153914 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v183336 : Async<string option> = _let'_v122232 
    let _run_target_args'_v6 = v183336 
    #endif
#else
    let v183338 : unit = ()
    let _let'_v183338 =
        async {
            try
                let v212800 : bool = v1 > 0L
                if v212800 then
                    let v212801 : Async<int64> = method28(v0)
                    let v212802 : int32 = 1000
                    let v212803 : Async<US2> = method65(v212802, v212801)
                    (* run_target_args'
                    let v212808 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v212810 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v212808 = v212810 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v212814 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v212808 = v212814 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v212818 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v212808 = v212818 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v212821 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v212822 : Async<unit> = v212821 v212803
                    let _run_target_args'_v212808 = v212822 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v212823 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v212824 : Async<unit> = v212823 v212803
                    let _run_target_args'_v212808 = v212824 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v212825 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v212826 : Async<unit> = v212825 v212803
                    let _run_target_args'_v212808 = v212826 
                    #endif
#else
                    let v212827 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v212828 : Async<unit> = v212827 v212803
                    let _run_target_args'_v212808 = v212828 
                    #endif
                    let v212829 : Async<unit> = _run_target_args'_v212808 
                    do! v212829 
                    ()
                let v212838 : Async<string> = method29(v0)
                let v212839 : Async<string option> = method76(v212838)
                return! v212839 
                (* indent
                ()
            indent *)
            with ex ->
                let v213589 : exn = ex
                let v213590 : bool = v1 = 0L
                let v213591 : bool = v213590 <> true
                if v213591 then
                    let v213942 : unit = ()
                    let v213943 : (unit -> unit) = closure36(v1, v213589)
                    let v213944 : unit = (fun () -> v213943 (); v213942) ()
                    let v214299 : string option = None
                    return v214299 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v214302 : int64 = v1 + 1L
                    let v214303 : Async<string option> = method63(v0, v214302)
                    return! v214303 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v215020 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v244442 : Async<string option> = _let'_v183338 
    let _run_target_args'_v6 = v244442 
    #endif
    let v244443 : Async<string option> = _run_target_args'_v6 
    v244443
and method63 (v0 : string, v1 : int64) : Async<string option> =
    method64(v0, v1)
and method62 (v0 : string) : Async<string option> =
    let v1 : int64 = 0L
    method63(v0, v1)
and closure31 () (v0 : string) : Async<string option> =
    method62(v0)
and closure38 () (v0 : chrono_DateTime<chrono_Utc>) : US13 =
    US13_0(v0)
and method81 () : (chrono_DateTime<chrono_Utc> -> US13) =
    closure38()
and method82 () : string =
    let v0 : string = "hh:mm"
    v0
and method83 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method84 () : string =
    let v0 : string = "hhmm"
    v0
and method80 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
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
    let v803 : (chrono_DateTime<chrono_Utc> -> US13) = method81()
    let v804 : US13 option = v800 |> Option.map v803 
    let v824 : US13 = US13_1
    let v825 : US13 = v804 |> Option.defaultValue v824 
    let v845 : US5 =
        match v825 with
        | US13_1 -> (* None *)
            US5_1
        | US13_0(v829) -> (* Some *)
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
    let v1109 : string = method82()
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
    let v1629 : (chrono_DateTime<chrono_Utc> -> US13) = method81()
    let v1630 : US13 option = v1626 |> Option.map v1629 
    let v1650 : US13 = US13_1
    let v1651 : US13 = v1630 |> Option.defaultValue v1650 
    let v1671 : US5 =
        match v1651 with
        | US13_1 -> (* None *)
            US5_1
        | US13_0(v1655) -> (* Some *)
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
    let v1935 : string = method82()
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
    let v2334 : string = method83()
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
    let v2613 : string = method84()
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
    let v3008 : string = method83()
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
    let v3287 : string = method84()
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
    let v3682 : string = method83()
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
    let v3961 : string = method84()
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
    let v4356 : string = method83()
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
    let v4635 : string = method84()
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
and method86 () : string =
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
and method87 () : string =
    let v0 : string = "!create_temp_path_"
    v0
and method88 (v0 : string, v1 : string) : string =
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
and method90 () : string =
    let v0 : string = "CARGO_PKG_NAME"
    v0
and method89 () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = method90()
    let v6 : string = method2(v5)
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : string = method90()
    let v8 : string = method2(v7)
    let _run_target_args'_v4 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : string = method90()
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
and method85 (v0 : System.Guid) : string =
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = method86()
    let v14 : string = method87()
    let v15 : string = method88(v13, v14)
    let v16 : string = method89()
    let v17 : string = method88(v15, v16)
    let v19 : (System.Guid -> string) = _.ToString()
    let v20 : string = v19 v0
    let v23 : string = method88(v17, v20)
    let _run_target_args'_v12 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v24 : string = method86()
    let v25 : string = method87()
    let v26 : string = method88(v24, v25)
    let v27 : string = method89()
    let v28 : string = method88(v26, v27)
    let v30 : (System.Guid -> string) = _.ToString()
    let v31 : string = v30 v0
    let v34 : string = method88(v28, v31)
    let _run_target_args'_v12 = v34 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = null |> unbox<string>
    let _run_target_args'_v12 = v36 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v39 : string = method86()
    let v40 : string = method87()
    let v41 : string = method88(v39, v40)
    let v42 : string = method89()
    let v43 : string = method88(v41, v42)
    let v45 : (System.Guid -> string) = _.ToString()
    let v46 : string = v45 v0
    let v49 : string = method88(v43, v46)
    let _run_target_args'_v12 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v50 : string = method86()
    let v51 : string = method87()
    let v52 : string = method88(v50, v51)
    let v53 : string = method89()
    let v54 : string = method88(v52, v53)
    let v56 : (System.Guid -> string) = _.ToString()
    let v57 : string = v56 v0
    let v60 : string = method88(v54, v57)
    let _run_target_args'_v12 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v61 : string = method86()
    let v62 : string = method87()
    let v63 : string = method88(v61, v62)
    let v64 : string = method89()
    let v65 : string = method88(v63, v64)
    let v67 : (System.Guid -> string) = _.ToString()
    let v68 : string = v67 v0
    let v71 : string = method88(v65, v68)
    let _run_target_args'_v12 = v71 
    #endif
#else
    let v72 : string = method86()
    let v73 : string = method87()
    let v74 : string = method88(v72, v73)
    let v75 : string = method89()
    let v76 : string = method88(v74, v75)
    let v78 : (System.Guid -> string) = _.ToString()
    let v79 : string = v78 v0
    let v82 : string = method88(v76, v79)
    let _run_target_args'_v12 = v82 
    #endif
    let v83 : string = _run_target_args'_v12 
    v83
and method79 () : string =
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
    let v57 : System.Guid = method80(v54, v47)
    let v58 : string = method85(v57)
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
    let v86 : System.Guid = method80(v83, v76)
    let v87 : string = method85(v86)
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
    let v119 : System.Guid = method80(v116, v109)
    let v120 : string = method85(v119)
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
    let v148 : System.Guid = method80(v145, v138)
    let v149 : string = method85(v148)
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
    let v177 : System.Guid = method80(v174, v167)
    let v178 : string = method85(v177)
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
    let v206 : System.Guid = method80(v203, v196)
    let v207 : string = method85(v206)
    let _run_target_args'_v29 = v207 
    #endif
    let v208 : string = _run_target_args'_v29 
    v208
and closure37 () () : string =
    method79()
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
and method92 () : (std_io_Error -> std_string_String) =
    closure40()
and closure41 () () : US14 =
    US14_0
and method93 () : (unit -> US14) =
    closure41()
and closure42 () (v0 : std_string_String) : US14 =
    US14_1(v0)
and method94 () : (std_string_String -> US14) =
    closure42()
and method96 (v0 : string, v1 : std_string_String) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "dir"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v62 : string = $"{v0}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure6(v3, v62)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v80 : string = "; "
    let v81 : string = $"{v80}"
    let v89 : unit = ()
    let v90 : (unit -> unit) = closure6(v3, v81)
    let v91 : unit = (fun () -> v90 (); v89) ()
    let v99 : string = "error"
    let v100 : string = $"{v99}"
    let v108 : unit = ()
    let v109 : (unit -> unit) = closure6(v3, v100)
    let v110 : unit = (fun () -> v109 (); v108) ()
    let v117 : string = $"{v44}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure6(v3, v117)
    let v127 : unit = (fun () -> v126 (); v125) ()
    (* run_target_args'
    let v137 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v138 : string = "format!(\"{:#?}\", $0)"
    let v139 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v138 
    let v140 : string = "fable_library_rust::String_::fromString($0)"
    let v141 : string = Fable.Core.RustInterop.emitRustExpr v139 v140 
    let _run_target_args'_v137 = v141 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v142 : string = "format!(\"{:#?}\", $0)"
    let v143 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v142 
    let v144 : string = "fable_library_rust::String_::fromString($0)"
    let v145 : string = Fable.Core.RustInterop.emitRustExpr v143 v144 
    let _run_target_args'_v137 = v145 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v146 : string = "format!(\"{:#?}\", $0)"
    let v147 : std_string_String = Fable.Core.RustInterop.emitRustExpr v1 v146 
    let v148 : string = "fable_library_rust::String_::fromString($0)"
    let v149 : string = Fable.Core.RustInterop.emitRustExpr v147 v148 
    let _run_target_args'_v137 = v149 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v151 : string = $"%A{v1}"
    let _run_target_args'_v137 = v151 
    #endif
#if FABLE_COMPILER_PYTHON
    let v155 : string = $"%A{v1}"
    let _run_target_args'_v137 = v155 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v159 : string = $"%A{v1}"
    let _run_target_args'_v137 = v159 
    #endif
#else
    let v163 : string = $"%A{v1}"
    let _run_target_args'_v137 = v163 
    #endif
    let v166 : string = _run_target_args'_v137 
    let v176 : string = $"{v166}"
    let v184 : unit = ()
    let v185 : (unit -> unit) = closure6(v3, v176)
    let v186 : unit = (fun () -> v185 (); v184) ()
    let v194 : string = " }"
    let v195 : string = $"{v194}"
    let v203 : unit = ()
    let v204 : (unit -> unit) = closure6(v3, v195)
    let v205 : unit = (fun () -> v204 (); v203) ()
    let v211 : string = v3.l0
    v211
and method95 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : std_string_String) : string =
    let v10 : string = method96(v8, v9)
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
    let v43 : string = "file_system.create_dir"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
and closure43 (v0 : string, v1 : std_string_String) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 4 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method50()
            let v125 : string = method95(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure7(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure8()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US6_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method98 (v0 : string) : string =
    let v1 : string = method17()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v5 : string = "{ "
    let v6 : string = $"{v5}"
    let v14 : unit = ()
    let v15 : (unit -> unit) = closure6(v2, v6)
    let v16 : unit = (fun () -> v15 (); v14) ()
    let v24 : string = "dir"
    let v25 : string = $"{v24}"
    let v33 : unit = ()
    let v34 : (unit -> unit) = closure6(v2, v25)
    let v35 : unit = (fun () -> v34 (); v33) ()
    let v43 : string = " = "
    let v44 : string = $"{v43}"
    let v52 : unit = ()
    let v53 : (unit -> unit) = closure6(v2, v44)
    let v54 : unit = (fun () -> v53 (); v52) ()
    let v61 : string = $"{v0}"
    let v69 : unit = ()
    let v70 : (unit -> unit) = closure6(v2, v61)
    let v71 : unit = (fun () -> v70 (); v69) ()
    let v79 : string = " }"
    let v80 : string = $"{v79}"
    let v88 : unit = ()
    let v89 : (unit -> unit) = closure6(v2, v80)
    let v90 : unit = (fun () -> v89 (); v88) ()
    let v96 : string = v2.l0
    v96
and method97 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method98(v8)
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
    let v42 : string = "file_system.create_dir"
    let v43 : string = v37 + v42 
    let v48 : string = " / "
    let v49 : string = v43 + v48 
    let v53 : string = v49 + v9 
    method22(v53)
and closure44 (v0 : string) () : unit =
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
    let v298 : US6 =
        if v64 then
            US6_1
        else
            let v80 : unit = ()
            let v81 : unit = (fun () -> v16 (); v80) ()
            let struct (v104 : Mut0, v105 : Mut1, v106 : Mut2, v107 : Mut3, v108 : Mut4, v109 : int64 option) = TraceState.trace_state.Value
            let v122 : string = method11(v104, v105, v106, v107, v108, v109)
            let v123 : string = method32()
            let v124 : string = method97(v104, v105, v106, v107, v108, v109, v122, v123, v0)
            let v139 : unit = ()
            let v140 : unit = (fun () -> v16 (); v139) ()
            let struct (v163 : Mut0, v164 : Mut1, v165 : Mut2, v166 : Mut3, v167 : Mut4, v168 : int64 option) = TraceState.trace_state.Value
            let v183 : unit = ()
            let v184 : (unit -> unit) = closure7(v163)
            let v185 : unit = (fun () -> v184 (); v183) ()
            let v188 : (string -> unit) = closure8()
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
and closure45 (v0 : string) () : unit =
    let v1 : bool = true
    method9(v1, v0)
and method99 (v0 : string) : (unit -> unit) =
    closure45(v0)
and method100 (v0 : string) : (unit -> unit) =
    closure45(v0)
and method101 (v0 : string) : System_IO_DirectoryInfo =
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
and method103 (v0 : string, v1 : string) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "dir"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v62 : string = $"{v0}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure6(v3, v62)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v80 : string = "; "
    let v81 : string = $"{v80}"
    let v89 : unit = ()
    let v90 : (unit -> unit) = closure6(v3, v81)
    let v91 : unit = (fun () -> v90 (); v89) ()
    let v99 : string = "result"
    let v100 : string = $"{v99}"
    let v108 : unit = ()
    let v109 : (unit -> unit) = closure6(v3, v100)
    let v110 : unit = (fun () -> v109 (); v108) ()
    let v117 : string = $"{v44}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure6(v3, v117)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v134 : string = $"{v1}"
    let v142 : unit = ()
    let v143 : (unit -> unit) = closure6(v3, v134)
    let v144 : unit = (fun () -> v143 (); v142) ()
    let v152 : string = " }"
    let v153 : string = $"{v152}"
    let v161 : unit = ()
    let v162 : (unit -> unit) = closure6(v3, v153)
    let v163 : unit = (fun () -> v162 (); v161) ()
    let v169 : string = v3.l0
    v169
and method102 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method103(v8, v9)
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
    let v43 : string = "file_system.create_dir"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
and closure46 (v0 : string, v1 : string) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 1 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method15()
            let v125 : string = method102(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure7(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure8()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US6_0(v164, v165, v166, v167, v168, v169)
    
    ()
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
and method104 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method105 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method91 (v0 : string) : System.IDisposable =
    (* run_target_args'
    let v736 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v737 : string = "std::fs::create_dir_all(&*$0)"
    let v738 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v737 
    let v739 : (std_io_Error -> std_string_String) = method92()
    (* run_target_args'
    let v741 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v742 : string = "$0.map_err(|x| $1(x))"
    let v743 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v738, v739) v742 
    let _run_target_args'_v741 = v743 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v744 : string = "$0.map_err(|x| $1(x))"
    let v745 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v738, v739) v744 
    let _run_target_args'_v741 = v745 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v746 : string = "$0.map_err(|x| $1(x))"
    let v747 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v738, v739) v746 
    let _run_target_args'_v741 = v747 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v748 : Result<unit, std_string_String> = match v738 with Ok x -> Ok x | Error x -> Error (v739 x)
    let _run_target_args'_v741 = v748 
    #endif
#if FABLE_COMPILER_PYTHON
    let v749 : Result<unit, std_string_String> = match v738 with Ok x -> Ok x | Error x -> Error (v739 x)
    let _run_target_args'_v741 = v749 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v750 : Result<unit, std_string_String> = match v738 with Ok x -> Ok x | Error x -> Error (v739 x)
    let _run_target_args'_v741 = v750 
    #endif
#else
    let v751 : Result<unit, std_string_String> = match v738 with Ok x -> Ok x | Error x -> Error (v739 x)
    let _run_target_args'_v741 = v751 
    #endif
    let v752 : Result<unit, std_string_String> = _run_target_args'_v741 
    let v755 : (unit -> US14) = method93()
    let v756 : (std_string_String -> US14) = method94()
    let v758 : US14 = match v752 with Ok () -> v755 () | Error x -> v756 x
    match v758 with
    | US14_1(v1389) -> (* Error *)
        let v1701 : unit = ()
        let v1702 : (unit -> unit) = closure43(v0, v1389)
        let v1703 : unit = (fun () -> v1702 (); v1701) ()
        ()
    | US14_0 -> (* Ok *)
        let v1072 : unit = ()
        let v1073 : (unit -> unit) = closure44(v0)
        let v1074 : unit = (fun () -> v1073 (); v1072) ()
        ()
    (* run_target_args'
    let v2022 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2023 : (unit -> unit) = method99(v0)
    let v2024 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2023 "$0()" )
    let _run_target_args'_v2022 = v2024 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2025 : (unit -> unit) = method99(v0)
    let v2026 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2025 "$0()" )
    let _run_target_args'_v2022 = v2026 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2027 : (unit -> unit) = method99(v0)
    let v2028 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2027 "$0()" )
    let _run_target_args'_v2022 = v2028 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2029 : (unit -> unit) = method100(v0)
    let v2030 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2029 () }
    let _run_target_args'_v2022 = v2030 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2031 : (unit -> unit) = method100(v0)
    let v2032 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2031 () }
    let _run_target_args'_v2022 = v2032 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2033 : (unit -> unit) = method100(v0)
    let v2034 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2033 () }
    let _run_target_args'_v2022 = v2034 
    #endif
#else
    let v2035 : (unit -> unit) = method100(v0)
    let v2036 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2035 () }
    let _run_target_args'_v2022 = v2036 
    #endif
    let v2037 : System.IDisposable = _run_target_args'_v2022 
    let _run_target_args'_v736 = v2037 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2045 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v736 = v2045 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2049 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v736 = v2049 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2052 : System_IO_DirectoryInfo = method101(v0)
    (* run_target_args'
    let v2057 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2059 : bool = null |> unbox<bool>
    let _run_target_args'_v2057 = v2059 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2063 : bool = null |> unbox<bool>
    let _run_target_args'_v2057 = v2063 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2067 : bool = null |> unbox<bool>
    let _run_target_args'_v2057 = v2067 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2071 : bool = null |> unbox<bool>
    let _run_target_args'_v2057 = v2071 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2075 : bool = null |> unbox<bool>
    let _run_target_args'_v2057 = v2075 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2079 : bool = null |> unbox<bool>
    let _run_target_args'_v2057 = v2079 
    #endif
#else
    let v2082 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v2083 : bool = v2082 v2052
    let _run_target_args'_v2057 = v2083 
    #endif
    let v2084 : bool = _run_target_args'_v2057 
    let v2093 : bool = v2084 = false
    if v2093 then
        (* run_target_args'
        let v2098 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v2100 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2098 = v2100 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v2104 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2098 = v2104 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v2108 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2098 = v2108 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v2112 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2098 = v2112 
        #endif
#if FABLE_COMPILER_PYTHON
        let v2116 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2098 = v2116 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v2120 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2098 = v2120 
        #endif
#else
        let v2123 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v2124 : System.DateTime = v2123 v2052
        let _run_target_args'_v2098 = v2124 
        #endif
        let v2125 : System.DateTime = _run_target_args'_v2098 
        let v2134 : _ = {| Exists = v2084; CreationTime = v2125 |}
        let v2136 : string = $"%A{v2134}"
        let v2450 : unit = ()
        let v2451 : (unit -> unit) = closure46(v0, v2136)
        let v2452 : unit = (fun () -> v2451 (); v2450) ()
        ()
    (* run_target_args'
    let v2771 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2772 : (unit -> unit) = method104(v0)
    let v2773 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2772 "$0()" )
    let _run_target_args'_v2771 = v2773 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2774 : (unit -> unit) = method104(v0)
    let v2775 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2774 "$0()" )
    let _run_target_args'_v2771 = v2775 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2776 : (unit -> unit) = method104(v0)
    let v2777 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2776 "$0()" )
    let _run_target_args'_v2771 = v2777 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2778 : (unit -> unit) = method105(v0)
    let v2779 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2778 () }
    let _run_target_args'_v2771 = v2779 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2780 : (unit -> unit) = method105(v0)
    let v2781 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2780 () }
    let _run_target_args'_v2771 = v2781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2782 : (unit -> unit) = method105(v0)
    let v2783 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2782 () }
    let _run_target_args'_v2771 = v2783 
    #endif
#else
    let v2784 : (unit -> unit) = method105(v0)
    let v2785 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2784 () }
    let _run_target_args'_v2771 = v2785 
    #endif
    let v2786 : System.IDisposable = _run_target_args'_v2771 
    let _run_target_args'_v736 = v2786 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2793 : System_IO_DirectoryInfo = method101(v0)
    (* run_target_args'
    let v2798 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2800 : bool = null |> unbox<bool>
    let _run_target_args'_v2798 = v2800 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2804 : bool = null |> unbox<bool>
    let _run_target_args'_v2798 = v2804 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2808 : bool = null |> unbox<bool>
    let _run_target_args'_v2798 = v2808 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2812 : bool = null |> unbox<bool>
    let _run_target_args'_v2798 = v2812 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2816 : bool = null |> unbox<bool>
    let _run_target_args'_v2798 = v2816 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2820 : bool = null |> unbox<bool>
    let _run_target_args'_v2798 = v2820 
    #endif
#else
    let v2823 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v2824 : bool = v2823 v2793
    let _run_target_args'_v2798 = v2824 
    #endif
    let v2825 : bool = _run_target_args'_v2798 
    let v2834 : bool = v2825 = false
    if v2834 then
        (* run_target_args'
        let v2839 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v2841 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2839 = v2841 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v2845 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2839 = v2845 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v2849 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2839 = v2849 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v2853 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2839 = v2853 
        #endif
#if FABLE_COMPILER_PYTHON
        let v2857 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2839 = v2857 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v2861 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v2839 = v2861 
        #endif
#else
        let v2864 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v2865 : System.DateTime = v2864 v2793
        let _run_target_args'_v2839 = v2865 
        #endif
        let v2866 : System.DateTime = _run_target_args'_v2839 
        let v2875 : _ = {| Exists = v2825; CreationTime = v2866 |}
        let v2877 : string = $"%A{v2875}"
        let v3191 : unit = ()
        let v3192 : (unit -> unit) = closure46(v0, v2877)
        let v3193 : unit = (fun () -> v3192 (); v3191) ()
        ()
    (* run_target_args'
    let v3512 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3513 : (unit -> unit) = method104(v0)
    let v3514 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v3513 "$0()" )
    let _run_target_args'_v3512 = v3514 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3515 : (unit -> unit) = method104(v0)
    let v3516 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v3515 "$0()" )
    let _run_target_args'_v3512 = v3516 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3517 : (unit -> unit) = method104(v0)
    let v3518 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v3517 "$0()" )
    let _run_target_args'_v3512 = v3518 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3519 : (unit -> unit) = method105(v0)
    let v3520 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3519 () }
    let _run_target_args'_v3512 = v3520 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3521 : (unit -> unit) = method105(v0)
    let v3522 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3521 () }
    let _run_target_args'_v3512 = v3522 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3523 : (unit -> unit) = method105(v0)
    let v3524 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3523 () }
    let _run_target_args'_v3512 = v3524 
    #endif
#else
    let v3525 : (unit -> unit) = method105(v0)
    let v3526 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3525 () }
    let _run_target_args'_v3512 = v3526 
    #endif
    let v3527 : System.IDisposable = _run_target_args'_v3512 
    let _run_target_args'_v736 = v3527 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3534 : System_IO_DirectoryInfo = method101(v0)
    (* run_target_args'
    let v3539 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3541 : bool = null |> unbox<bool>
    let _run_target_args'_v3539 = v3541 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3545 : bool = null |> unbox<bool>
    let _run_target_args'_v3539 = v3545 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3549 : bool = null |> unbox<bool>
    let _run_target_args'_v3539 = v3549 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3553 : bool = null |> unbox<bool>
    let _run_target_args'_v3539 = v3553 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3557 : bool = null |> unbox<bool>
    let _run_target_args'_v3539 = v3557 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3561 : bool = null |> unbox<bool>
    let _run_target_args'_v3539 = v3561 
    #endif
#else
    let v3564 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v3565 : bool = v3564 v3534
    let _run_target_args'_v3539 = v3565 
    #endif
    let v3566 : bool = _run_target_args'_v3539 
    let v3575 : bool = v3566 = false
    if v3575 then
        (* run_target_args'
        let v3580 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v3582 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3580 = v3582 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v3586 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3580 = v3586 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v3590 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3580 = v3590 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v3594 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3580 = v3594 
        #endif
#if FABLE_COMPILER_PYTHON
        let v3598 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3580 = v3598 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v3602 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v3580 = v3602 
        #endif
#else
        let v3605 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v3606 : System.DateTime = v3605 v3534
        let _run_target_args'_v3580 = v3606 
        #endif
        let v3607 : System.DateTime = _run_target_args'_v3580 
        let v3616 : _ = {| Exists = v3566; CreationTime = v3607 |}
        let v3618 : string = $"%A{v3616}"
        let v3932 : unit = ()
        let v3933 : (unit -> unit) = closure46(v0, v3618)
        let v3934 : unit = (fun () -> v3933 (); v3932) ()
        ()
    (* run_target_args'
    let v4253 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4254 : (unit -> unit) = method104(v0)
    let v4255 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4254 "$0()" )
    let _run_target_args'_v4253 = v4255 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4256 : (unit -> unit) = method104(v0)
    let v4257 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4256 "$0()" )
    let _run_target_args'_v4253 = v4257 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4258 : (unit -> unit) = method104(v0)
    let v4259 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4258 "$0()" )
    let _run_target_args'_v4253 = v4259 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4260 : (unit -> unit) = method105(v0)
    let v4261 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4260 () }
    let _run_target_args'_v4253 = v4261 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4262 : (unit -> unit) = method105(v0)
    let v4263 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4262 () }
    let _run_target_args'_v4253 = v4263 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4264 : (unit -> unit) = method105(v0)
    let v4265 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4264 () }
    let _run_target_args'_v4253 = v4265 
    #endif
#else
    let v4266 : (unit -> unit) = method105(v0)
    let v4267 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4266 () }
    let _run_target_args'_v4253 = v4267 
    #endif
    let v4268 : System.IDisposable = _run_target_args'_v4253 
    let _run_target_args'_v736 = v4268 
    #endif
#else
    let v4275 : System_IO_DirectoryInfo = method101(v0)
    (* run_target_args'
    let v4280 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4282 : bool = null |> unbox<bool>
    let _run_target_args'_v4280 = v4282 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4286 : bool = null |> unbox<bool>
    let _run_target_args'_v4280 = v4286 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4290 : bool = null |> unbox<bool>
    let _run_target_args'_v4280 = v4290 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4294 : bool = null |> unbox<bool>
    let _run_target_args'_v4280 = v4294 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4298 : bool = null |> unbox<bool>
    let _run_target_args'_v4280 = v4298 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4302 : bool = null |> unbox<bool>
    let _run_target_args'_v4280 = v4302 
    #endif
#else
    let v4305 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v4306 : bool = v4305 v4275
    let _run_target_args'_v4280 = v4306 
    #endif
    let v4307 : bool = _run_target_args'_v4280 
    let v4316 : bool = v4307 = false
    if v4316 then
        (* run_target_args'
        let v4321 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v4323 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v4321 = v4323 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v4327 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v4321 = v4327 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v4331 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v4321 = v4331 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v4335 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v4321 = v4335 
        #endif
#if FABLE_COMPILER_PYTHON
        let v4339 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v4321 = v4339 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v4343 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v4321 = v4343 
        #endif
#else
        let v4346 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v4347 : System.DateTime = v4346 v4275
        let _run_target_args'_v4321 = v4347 
        #endif
        let v4348 : System.DateTime = _run_target_args'_v4321 
        let v4357 : _ = {| Exists = v4307; CreationTime = v4348 |}
        let v4359 : string = $"%A{v4357}"
        let v4673 : unit = ()
        let v4674 : (unit -> unit) = closure46(v0, v4359)
        let v4675 : unit = (fun () -> v4674 (); v4673) ()
        ()
    (* run_target_args'
    let v4994 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4995 : (unit -> unit) = method104(v0)
    let v4996 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4995 "$0()" )
    let _run_target_args'_v4994 = v4996 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4997 : (unit -> unit) = method104(v0)
    let v4998 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4997 "$0()" )
    let _run_target_args'_v4994 = v4998 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4999 : (unit -> unit) = method104(v0)
    let v5000 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4999 "$0()" )
    let _run_target_args'_v4994 = v5000 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5001 : (unit -> unit) = method105(v0)
    let v5002 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5001 () }
    let _run_target_args'_v4994 = v5002 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5003 : (unit -> unit) = method105(v0)
    let v5004 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5003 () }
    let _run_target_args'_v4994 = v5004 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5005 : (unit -> unit) = method105(v0)
    let v5006 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5005 () }
    let _run_target_args'_v4994 = v5006 
    #endif
#else
    let v5007 : (unit -> unit) = method105(v0)
    let v5008 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5007 () }
    let _run_target_args'_v4994 = v5008 
    #endif
    let v5009 : System.IDisposable = _run_target_args'_v4994 
    let _run_target_args'_v736 = v5009 
    #endif
    let v5016 : System.IDisposable = _run_target_args'_v736 
    v5016
and closure39 () () : struct (string * System.IDisposable) =
    let v0 : string = method79()
    let v1 : System.IDisposable = method91(v0)
    struct (v0, v1)
and closure49 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method107(v0, v1, v5)
        let v8 : string = v3 + v1 
        v6 v8
and method107 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure49(v0, v1, v2)
and method106 (v0 : string) : System.Guid =
    let v2 : (char -> string) = _.ToString()
    let v3 : string = v2 '0'
    let v6 : int32 = v0.Length
    let v7 : int32 = 32 - v6
    let v8 : int32 = 0
    let v9 : (string -> string) = method107(v7, v3, v8)
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
    let v1 : System.Guid = method106(v0)
    let v2 : string = method85(v1)
    let v3 : System.IDisposable = method91(v2)
    struct (v2, v3)
and closure50 () () : string =
    let v0 : string = __SOURCE_DIRECTORY__
    v0
and closure52 () (v0 : std_path_PathBuf) : US15 =
    US15_0(v0)
and method111 () : (std_path_PathBuf -> US15) =
    closure52()
and closure53 () (v0 : string) : US15 =
    US15_1(v0)
and method112 () : (string -> US15) =
    closure53()
and method115 (v0 : string) : string option =
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
and method116 (v0 : string) : string =
    let v1 : string = method17()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v12 : unit = ()
    let v13 : (unit -> unit) = closure6(v2, v4)
    let v14 : unit = (fun () -> v13 (); v12) ()
    let v20 : string = v2.l0
    v20
and method114 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method19(v4)
    let v6 : string option = method115(v4)
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method116(v3)
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
        let v77 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v78 : string = "Err($0)"
        let v79 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v78 
        let _run_target_args'_v77 = v79 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v80 : string = "Err($0)"
        let v81 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v80 
        let _run_target_args'_v77 = v81 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v82 : string = "Err($0)"
        let v83 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v82 
        let _run_target_args'_v77 = v83 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v84 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v84 
        #endif
#if FABLE_COMPILER_PYTHON
        let v85 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v85 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v86 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v86 
        #endif
#else
        let v87 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v87 
        #endif
        let v88 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v77 
        v88
    else
        match v31 with
        | US5_0(v91) -> (* Some *)
            let v94 : string = ""
            let v95 : bool = v4 <> v94 
            if v95 then
                let v98 : uint8 = v2 + 1uy
                let v99 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v98
                let v100 : Result<std_path_PathBuf, std_io_Error> = v99 v91
                let v101 : (std_io_Error -> string) = method46()
                (* run_target_args'
                let v103 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v104 : string = "$0.map_err(|x| $1(x))"
                let v105 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v100, v101) v104 
                let _run_target_args'_v103 = v105 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v106 : string = "$0.map_err(|x| $1(x))"
                let v107 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v100, v101) v106 
                let _run_target_args'_v103 = v107 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v108 : string = "$0.map_err(|x| $1(x))"
                let v109 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v100, v101) v108 
                let _run_target_args'_v103 = v109 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v110 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v110 
                #endif
#if FABLE_COMPILER_PYTHON
                let v111 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v111 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v112 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v112 
                #endif
#else
                let v113 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v113 
                #endif
                let v114 : Result<std_path_PathBuf, string> = _run_target_args'_v103 
                let v117 : (std_path_PathBuf -> US15) = method111()
                let v118 : (string -> US15) = method112()
                let v120 : US15 = match v114 with Ok x -> v117 x | Error x -> v118 x
                match v120 with
                | US15_1(v288) -> (* Error *)
                    let v289 : string = $"file_system.read_link / "
                    let v290 : string = $"error': {v288} / error: {v35} / name: {v5}"
                    let v291 : string = v289 + v290 
                    (* run_target_args'
                    let v296 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v297 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v298 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v291 v297 
                    let _run_target_args'_v296 = v298 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v299 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v300 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v291 v299 
                    let _run_target_args'_v296 = v300 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v301 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v302 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v291 v301 
                    let _run_target_args'_v296 = v302 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v304 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v304 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v308 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v308 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v312 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v312 
                    #endif
#else
                    let v316 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v316 
                    #endif
                    let v319 : std_io_Error = _run_target_args'_v296 
                    (* run_target_args'
                    let v329 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v330 : string = "Err($0)"
                    let v331 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v319 v330 
                    let _run_target_args'_v329 = v331 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v332 : string = "Err($0)"
                    let v333 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v319 v332 
                    let _run_target_args'_v329 = v333 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v334 : string = "Err($0)"
                    let v335 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v319 v334 
                    let _run_target_args'_v329 = v335 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v336 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v336 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v337 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v337 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v338 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v338 
                    #endif
#else
                    let v339 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v339 
                    #endif
                    let v340 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v329 
                    v340
                | US15_0(v123) -> (* Ok *)
                    (* run_target_args'
                    let v128 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v129 : string = "$0.display()"
                    let v130 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v123 v129 
                    let _run_target_args'_v128 = v130 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v131 : string = "$0.display()"
                    let v132 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v123 v131 
                    let _run_target_args'_v128 = v132 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v133 : string = "$0.display()"
                    let v134 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v123 v133 
                    let _run_target_args'_v128 = v134 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v136 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v136 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v140 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v140 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v144 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v144 
                    #endif
#else
                    let v148 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v148 
                    #endif
                    let v151 : std_path_Display = _run_target_args'_v128 
                    let v161 : string = v151 |> string 
                    let v164 : string = method88(v161, v5)
                    (* run_target_args'
                    let v169 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v170 : string = "&*$0"
                    let v171 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v164 v170 
                    let _run_target_args'_v169 = v171 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v172 : string = "&*$0"
                    let v173 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v164 v172 
                    let _run_target_args'_v169 = v173 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v174 : string = "&*$0"
                    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v164 v174 
                    let _run_target_args'_v169 = v175 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v177 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v177 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v181 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v181 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v185 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v185 
                    #endif
#else
                    let v189 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v189 
                    #endif
                    let v192 : Ref<Str> = _run_target_args'_v169 
                    (* run_target_args'
                    let v205 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v206 : string = "String::from($0)"
                    let v207 : std_string_String = Fable.Core.RustInterop.emitRustExpr v192 v206 
                    let _run_target_args'_v205 = v207 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v208 : string = "String::from($0)"
                    let v209 : std_string_String = Fable.Core.RustInterop.emitRustExpr v192 v208 
                    let _run_target_args'_v205 = v209 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v210 : string = "String::from($0)"
                    let v211 : std_string_String = Fable.Core.RustInterop.emitRustExpr v192 v210 
                    let _run_target_args'_v205 = v211 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v213 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v213 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v217 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v217 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v221 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v221 
                    #endif
#else
                    let v225 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v225 
                    #endif
                    let v228 : std_string_String = _run_target_args'_v205 
                    (* run_target_args'
                    let v241 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v242 : string = "std::path::PathBuf::from($0)"
                    let v243 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v228 v242 
                    let _run_target_args'_v241 = v243 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v244 : string = "std::path::PathBuf::from($0)"
                    let v245 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v228 v244 
                    let _run_target_args'_v241 = v245 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v246 : string = "std::path::PathBuf::from($0)"
                    let v247 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v228 v246 
                    let _run_target_args'_v241 = v247 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v249 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v249 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v253 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v253 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v257 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v257 
                    #endif
#else
                    let v261 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v261 
                    #endif
                    let v264 : std_path_PathBuf = _run_target_args'_v241 
                    (* run_target_args'
                    let v274 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v275 : string = "Ok($0)"
                    let v276 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v264 v275 
                    let _run_target_args'_v274 = v276 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v277 : string = "Ok($0)"
                    let v278 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v264 v277 
                    let _run_target_args'_v274 = v278 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v279 : string = "Ok($0)"
                    let v280 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v264 v279 
                    let _run_target_args'_v274 = v280 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v281 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v281 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v282 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v282 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v283 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v283 
                    #endif
#else
                    let v284 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v284 
                    #endif
                    let v285 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v274 
                    v285
            else
                let v345 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v346 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
                let v347 : string = v345 + v346 
                (* run_target_args'
                let v352 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v353 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v354 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v347 v353 
                let _run_target_args'_v352 = v354 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v355 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v356 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v347 v355 
                let _run_target_args'_v352 = v356 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v357 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v358 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v347 v357 
                let _run_target_args'_v352 = v358 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v360 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v360 
                #endif
#if FABLE_COMPILER_PYTHON
                let v364 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v364 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v368 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v368 
                #endif
#else
                let v372 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v372 
                #endif
                let v375 : std_io_Error = _run_target_args'_v352 
                (* run_target_args'
                let v385 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v386 : string = "Err($0)"
                let v387 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v386 
                let _run_target_args'_v385 = v387 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v388 : string = "Err($0)"
                let v389 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v388 
                let _run_target_args'_v385 = v389 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v390 : string = "Err($0)"
                let v391 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v390 
                let _run_target_args'_v385 = v391 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v392 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v392 
                #endif
#if FABLE_COMPILER_PYTHON
                let v393 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v393 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v394 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v394 
                #endif
#else
                let v395 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v395 
                #endif
                let v396 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v385 
                v396
        | _ ->
            let v400 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v401 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
            let v402 : string = v400 + v401 
            (* run_target_args'
            let v407 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v408 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v409 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v402 v408 
            let _run_target_args'_v407 = v409 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v410 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v411 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v402 v410 
            let _run_target_args'_v407 = v411 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v412 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v413 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v402 v412 
            let _run_target_args'_v407 = v413 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v415 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v415 
            #endif
#if FABLE_COMPILER_PYTHON
            let v419 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v419 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v423 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v423 
            #endif
#else
            let v427 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v427 
            #endif
            let v430 : std_io_Error = _run_target_args'_v407 
            (* run_target_args'
            let v440 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v441 : string = "Err($0)"
            let v442 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v430 v441 
            let _run_target_args'_v440 = v442 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v443 : string = "Err($0)"
            let v444 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v430 v443 
            let _run_target_args'_v440 = v444 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v445 : string = "Err($0)"
            let v446 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v430 v445 
            let _run_target_args'_v440 = v446 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v447 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v447 
            #endif
#if FABLE_COMPILER_PYTHON
            let v448 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v448 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v449 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v449 
            #endif
#else
            let v450 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v450 
            #endif
            let v451 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v440 
            v451
and method113 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "std::fs::read_link(&*$0)"
    let v9 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let v10 : (std_io_Error -> string) = method46()
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
    let v26 : (std_path_PathBuf -> US15) = method111()
    let v27 : (string -> US15) = method112()
    let v29 : US15 = match v23 with Ok x -> v26 x | Error x -> v27 x
    let v52 : Result<std_path_PathBuf, std_io_Error> =
        match v29 with
        | US15_1(v48) -> (* Error *)
            let v49 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method114(v0, v49, v1, v48, v2)
        | US15_0(v32) -> (* Ok *)
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
    let v55 : (std_io_Error -> string) = method46()
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
    let v71 : (std_path_PathBuf -> US15) = method111()
    let v72 : (string -> US15) = method112()
    let v74 : US15 = match v68 with Ok x -> v71 x | Error x -> v72 x
    let v97 : Result<std_path_PathBuf, std_io_Error> =
        match v74 with
        | US15_1(v93) -> (* Error *)
            let v94 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method114(v0, v94, v1, v93, v2)
        | US15_0(v77) -> (* Ok *)
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
    let v100 : (std_io_Error -> string) = method46()
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
    let v116 : (std_path_PathBuf -> US15) = method111()
    let v117 : (string -> US15) = method112()
    let v119 : US15 = match v113 with Ok x -> v116 x | Error x -> v117 x
    let v142 : Result<std_path_PathBuf, std_io_Error> =
        match v119 with
        | US15_1(v138) -> (* Error *)
            let v139 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method114(v0, v139, v1, v138, v2)
        | US15_0(v122) -> (* Ok *)
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
    method113(v0, v1, v2)
and closure54 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure55(v0, v1)
and method117 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method19(v0)
    let v5 : string option = method115(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method116(v3)
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
        let v76 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v77 : string = "Err($0)"
        let v78 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v77 
        let _run_target_args'_v76 = v78 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v79 : string = "Err($0)"
        let v80 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v79 
        let _run_target_args'_v76 = v80 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v81 : string = "Err($0)"
        let v82 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v81 
        let _run_target_args'_v76 = v82 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v83 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v83 
        #endif
#if FABLE_COMPILER_PYTHON
        let v84 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v84 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v85 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v85 
        #endif
#else
        let v86 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v86 
        #endif
        let v87 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v76 
        v87
    else
        match v30 with
        | US5_0(v90) -> (* Some *)
            let v93 : string = ""
            let v94 : bool = v0 <> v93 
            if v94 then
                let v97 : uint8 = v2 + 1uy
                let v98 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v97
                let v99 : Result<std_path_PathBuf, std_io_Error> = v98 v90
                let v100 : (std_io_Error -> string) = method46()
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
                let v116 : (std_path_PathBuf -> US15) = method111()
                let v117 : (string -> US15) = method112()
                let v119 : US15 = match v113 with Ok x -> v116 x | Error x -> v117 x
                match v119 with
                | US15_1(v287) -> (* Error *)
                    let v288 : string = $"file_system.read_link / "
                    let v289 : string = $"error': {v287} / error: {v34} / name: {v4}"
                    let v290 : string = v288 + v289 
                    (* run_target_args'
                    let v295 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v296 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v297 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v290 v296 
                    let _run_target_args'_v295 = v297 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v298 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v299 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v290 v298 
                    let _run_target_args'_v295 = v299 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v300 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v301 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v290 v300 
                    let _run_target_args'_v295 = v301 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v303 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v303 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v307 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v307 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v311 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v311 
                    #endif
#else
                    let v315 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v315 
                    #endif
                    let v318 : std_io_Error = _run_target_args'_v295 
                    (* run_target_args'
                    let v328 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v329 : string = "Err($0)"
                    let v330 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v318 v329 
                    let _run_target_args'_v328 = v330 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v331 : string = "Err($0)"
                    let v332 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v318 v331 
                    let _run_target_args'_v328 = v332 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v333 : string = "Err($0)"
                    let v334 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v318 v333 
                    let _run_target_args'_v328 = v334 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v335 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v335 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v336 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v336 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v337 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v337 
                    #endif
#else
                    let v338 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v338 
                    #endif
                    let v339 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v328 
                    v339
                | US15_0(v122) -> (* Ok *)
                    (* run_target_args'
                    let v127 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v128 : string = "$0.display()"
                    let v129 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v122 v128 
                    let _run_target_args'_v127 = v129 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v130 : string = "$0.display()"
                    let v131 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v122 v130 
                    let _run_target_args'_v127 = v131 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v132 : string = "$0.display()"
                    let v133 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v122 v132 
                    let _run_target_args'_v127 = v133 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v135 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v135 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v139 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v139 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v143 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v143 
                    #endif
#else
                    let v147 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v147 
                    #endif
                    let v150 : std_path_Display = _run_target_args'_v127 
                    let v160 : string = v150 |> string 
                    let v163 : string = method88(v160, v4)
                    (* run_target_args'
                    let v168 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v169 : string = "&*$0"
                    let v170 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v163 v169 
                    let _run_target_args'_v168 = v170 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v171 : string = "&*$0"
                    let v172 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v163 v171 
                    let _run_target_args'_v168 = v172 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v173 : string = "&*$0"
                    let v174 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v163 v173 
                    let _run_target_args'_v168 = v174 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v176 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v176 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v180 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v180 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v184 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v184 
                    #endif
#else
                    let v188 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v188 
                    #endif
                    let v191 : Ref<Str> = _run_target_args'_v168 
                    (* run_target_args'
                    let v204 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v205 : string = "String::from($0)"
                    let v206 : std_string_String = Fable.Core.RustInterop.emitRustExpr v191 v205 
                    let _run_target_args'_v204 = v206 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v207 : string = "String::from($0)"
                    let v208 : std_string_String = Fable.Core.RustInterop.emitRustExpr v191 v207 
                    let _run_target_args'_v204 = v208 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v209 : string = "String::from($0)"
                    let v210 : std_string_String = Fable.Core.RustInterop.emitRustExpr v191 v209 
                    let _run_target_args'_v204 = v210 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v212 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v212 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v216 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v216 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v220 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v220 
                    #endif
#else
                    let v224 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v224 
                    #endif
                    let v227 : std_string_String = _run_target_args'_v204 
                    (* run_target_args'
                    let v240 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v241 : string = "std::path::PathBuf::from($0)"
                    let v242 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v227 v241 
                    let _run_target_args'_v240 = v242 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v243 : string = "std::path::PathBuf::from($0)"
                    let v244 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v227 v243 
                    let _run_target_args'_v240 = v244 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v245 : string = "std::path::PathBuf::from($0)"
                    let v246 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v227 v245 
                    let _run_target_args'_v240 = v246 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v248 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v248 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v252 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v252 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v256 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v256 
                    #endif
#else
                    let v260 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v260 
                    #endif
                    let v263 : std_path_PathBuf = _run_target_args'_v240 
                    (* run_target_args'
                    let v273 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v274 : string = "Ok($0)"
                    let v275 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v263 v274 
                    let _run_target_args'_v273 = v275 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v276 : string = "Ok($0)"
                    let v277 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v263 v276 
                    let _run_target_args'_v273 = v277 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v278 : string = "Ok($0)"
                    let v279 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v263 v278 
                    let _run_target_args'_v273 = v279 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v280 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v280 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v281 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v281 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v282 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v282 
                    #endif
#else
                    let v283 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v283 
                    #endif
                    let v284 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v273 
                    v284
            else
                let v344 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v345 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
                let v346 : string = v344 + v345 
                (* run_target_args'
                let v351 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v352 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v353 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v346 v352 
                let _run_target_args'_v351 = v353 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v354 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v355 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v346 v354 
                let _run_target_args'_v351 = v355 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v356 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v357 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v346 v356 
                let _run_target_args'_v351 = v357 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v359 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v359 
                #endif
#if FABLE_COMPILER_PYTHON
                let v363 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v363 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v367 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v367 
                #endif
#else
                let v371 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v371 
                #endif
                let v374 : std_io_Error = _run_target_args'_v351 
                (* run_target_args'
                let v384 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v385 : string = "Err($0)"
                let v386 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v374 v385 
                let _run_target_args'_v384 = v386 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v387 : string = "Err($0)"
                let v388 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v374 v387 
                let _run_target_args'_v384 = v388 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v389 : string = "Err($0)"
                let v390 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v374 v389 
                let _run_target_args'_v384 = v390 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v391 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v391 
                #endif
#if FABLE_COMPILER_PYTHON
                let v392 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v392 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v393 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v393 
                #endif
#else
                let v394 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v394 
                #endif
                let v395 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v384 
                v395
        | _ ->
            let v399 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v400 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
            let v401 : string = v399 + v400 
            (* run_target_args'
            let v406 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v407 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v408 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v401 v407 
            let _run_target_args'_v406 = v408 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v409 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v410 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v401 v409 
            let _run_target_args'_v406 = v410 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v411 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v412 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v401 v411 
            let _run_target_args'_v406 = v412 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v414 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v414 
            #endif
#if FABLE_COMPILER_PYTHON
            let v418 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v418 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v422 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v422 
            #endif
#else
            let v426 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v426 
            #endif
            let v429 : std_io_Error = _run_target_args'_v406 
            (* run_target_args'
            let v439 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v440 : string = "Err($0)"
            let v441 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v429 v440 
            let _run_target_args'_v439 = v441 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v442 : string = "Err($0)"
            let v443 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v429 v442 
            let _run_target_args'_v439 = v443 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v444 : string = "Err($0)"
            let v445 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v429 v444 
            let _run_target_args'_v439 = v445 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v446 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v446 
            #endif
#if FABLE_COMPILER_PYTHON
            let v447 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v447 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v448 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v448 
            #endif
#else
            let v449 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v449 
            #endif
            let v450 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v439 
            v450
and method110 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "std::fs::read_link(&*$0)"
    let v8 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let v9 : (std_io_Error -> string) = method46()
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
    let v25 : (std_path_PathBuf -> US15) = method111()
    let v26 : (string -> US15) = method112()
    let v28 : US15 = match v22 with Ok x -> v25 x | Error x -> v26 x
    let v51 : Result<std_path_PathBuf, std_io_Error> =
        match v28 with
        | US15_1(v47) -> (* Error *)
            let v48 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method117(v0, v48, v1, v47)
        | US15_0(v31) -> (* Ok *)
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
    let v54 : (std_io_Error -> string) = method46()
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
    let v70 : (std_path_PathBuf -> US15) = method111()
    let v71 : (string -> US15) = method112()
    let v73 : US15 = match v67 with Ok x -> v70 x | Error x -> v71 x
    let v96 : Result<std_path_PathBuf, std_io_Error> =
        match v73 with
        | US15_1(v92) -> (* Error *)
            let v93 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method117(v0, v93, v1, v92)
        | US15_0(v76) -> (* Ok *)
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
    let v99 : (std_io_Error -> string) = method46()
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
    let v115 : (std_path_PathBuf -> US15) = method111()
    let v116 : (string -> US15) = method112()
    let v118 : US15 = match v112 with Ok x -> v115 x | Error x -> v116 x
    let v141 : Result<std_path_PathBuf, std_io_Error> =
        match v118 with
        | US15_1(v137) -> (* Error *)
            let v138 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure54(v0)
            method117(v0, v138, v1, v137)
        | US15_0(v121) -> (* Ok *)
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
and method119 (v0 : System_IO_DirectoryInfo) : System.IO.FileAttributes =
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
and method120 () : System.IO.FileAttributes =
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
and method121 (v0 : System.IO.FileAttributes, v1 : System.IO.FileAttributes) : bool =
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
and method123 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method19(v4)
    let v6 : string option = method115(v4)
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method47(v3)
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
        let v77 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v78 : string = "Err($0)"
        let v79 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v78 
        let _run_target_args'_v77 = v79 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v80 : string = "Err($0)"
        let v81 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v80 
        let _run_target_args'_v77 = v81 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v82 : string = "Err($0)"
        let v83 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v67 v82 
        let _run_target_args'_v77 = v83 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v84 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v84 
        #endif
#if FABLE_COMPILER_PYTHON
        let v85 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v85 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v86 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v86 
        #endif
#else
        let v87 : Result<std_path_PathBuf, std_io_Error> = v67 |> Error
        let _run_target_args'_v77 = v87 
        #endif
        let v88 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v77 
        v88
    else
        match v31 with
        | US5_0(v91) -> (* Some *)
            let v94 : string = ""
            let v95 : bool = v4 <> v94 
            if v95 then
                let v98 : uint8 = v2 + 1uy
                let v99 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v98
                let v100 : Result<std_path_PathBuf, std_io_Error> = v99 v91
                let v101 : (std_io_Error -> string) = method46()
                (* run_target_args'
                let v103 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v104 : string = "$0.map_err(|x| $1(x))"
                let v105 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v100, v101) v104 
                let _run_target_args'_v103 = v105 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v106 : string = "$0.map_err(|x| $1(x))"
                let v107 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v100, v101) v106 
                let _run_target_args'_v103 = v107 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v108 : string = "$0.map_err(|x| $1(x))"
                let v109 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v100, v101) v108 
                let _run_target_args'_v103 = v109 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v110 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v110 
                #endif
#if FABLE_COMPILER_PYTHON
                let v111 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v111 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v112 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v112 
                #endif
#else
                let v113 : Result<std_path_PathBuf, string> = match v100 with Ok x -> Ok x | Error x -> Error (v101 x)
                let _run_target_args'_v103 = v113 
                #endif
                let v114 : Result<std_path_PathBuf, string> = _run_target_args'_v103 
                let v117 : (std_path_PathBuf -> US15) = method111()
                let v118 : (string -> US15) = method112()
                let v120 : US15 = match v114 with Ok x -> v117 x | Error x -> v118 x
                match v120 with
                | US15_1(v288) -> (* Error *)
                    let v289 : string = $"file_system.read_link / "
                    let v290 : string = $"error': {v288} / error: {v35} / name: {v5}"
                    let v291 : string = v289 + v290 
                    (* run_target_args'
                    let v296 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v297 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v298 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v291 v297 
                    let _run_target_args'_v296 = v298 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v299 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v300 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v291 v299 
                    let _run_target_args'_v296 = v300 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v301 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v302 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v291 v301 
                    let _run_target_args'_v296 = v302 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v304 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v304 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v308 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v308 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v312 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v312 
                    #endif
#else
                    let v316 : std_io_Error = v291 |> unbox<std_io_Error>
                    let _run_target_args'_v296 = v316 
                    #endif
                    let v319 : std_io_Error = _run_target_args'_v296 
                    (* run_target_args'
                    let v329 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v330 : string = "Err($0)"
                    let v331 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v319 v330 
                    let _run_target_args'_v329 = v331 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v332 : string = "Err($0)"
                    let v333 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v319 v332 
                    let _run_target_args'_v329 = v333 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v334 : string = "Err($0)"
                    let v335 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v319 v334 
                    let _run_target_args'_v329 = v335 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v336 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v336 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v337 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v337 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v338 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v338 
                    #endif
#else
                    let v339 : Result<std_path_PathBuf, std_io_Error> = v319 |> Error
                    let _run_target_args'_v329 = v339 
                    #endif
                    let v340 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v329 
                    v340
                | US15_0(v123) -> (* Ok *)
                    (* run_target_args'
                    let v128 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v129 : string = "$0.display()"
                    let v130 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v123 v129 
                    let _run_target_args'_v128 = v130 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v131 : string = "$0.display()"
                    let v132 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v123 v131 
                    let _run_target_args'_v128 = v132 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v133 : string = "$0.display()"
                    let v134 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v123 v133 
                    let _run_target_args'_v128 = v134 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v136 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v136 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v140 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v140 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v144 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v144 
                    #endif
#else
                    let v148 : std_path_Display = v123 |> unbox<std_path_Display>
                    let _run_target_args'_v128 = v148 
                    #endif
                    let v151 : std_path_Display = _run_target_args'_v128 
                    let v161 : string = v151 |> string 
                    let v164 : string = method88(v161, v5)
                    (* run_target_args'
                    let v169 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v170 : string = "&*$0"
                    let v171 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v164 v170 
                    let _run_target_args'_v169 = v171 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v172 : string = "&*$0"
                    let v173 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v164 v172 
                    let _run_target_args'_v169 = v173 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v174 : string = "&*$0"
                    let v175 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v164 v174 
                    let _run_target_args'_v169 = v175 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v177 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v177 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v181 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v181 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v185 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v185 
                    #endif
#else
                    let v189 : Ref<Str> = v164 |> unbox<Ref<Str>>
                    let _run_target_args'_v169 = v189 
                    #endif
                    let v192 : Ref<Str> = _run_target_args'_v169 
                    (* run_target_args'
                    let v205 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v206 : string = "String::from($0)"
                    let v207 : std_string_String = Fable.Core.RustInterop.emitRustExpr v192 v206 
                    let _run_target_args'_v205 = v207 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v208 : string = "String::from($0)"
                    let v209 : std_string_String = Fable.Core.RustInterop.emitRustExpr v192 v208 
                    let _run_target_args'_v205 = v209 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v210 : string = "String::from($0)"
                    let v211 : std_string_String = Fable.Core.RustInterop.emitRustExpr v192 v210 
                    let _run_target_args'_v205 = v211 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v213 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v213 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v217 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v217 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v221 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v221 
                    #endif
#else
                    let v225 : std_string_String = v192 |> unbox<std_string_String>
                    let _run_target_args'_v205 = v225 
                    #endif
                    let v228 : std_string_String = _run_target_args'_v205 
                    (* run_target_args'
                    let v241 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v242 : string = "std::path::PathBuf::from($0)"
                    let v243 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v228 v242 
                    let _run_target_args'_v241 = v243 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v244 : string = "std::path::PathBuf::from($0)"
                    let v245 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v228 v244 
                    let _run_target_args'_v241 = v245 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v246 : string = "std::path::PathBuf::from($0)"
                    let v247 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v228 v246 
                    let _run_target_args'_v241 = v247 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v249 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v249 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v253 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v253 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v257 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v257 
                    #endif
#else
                    let v261 : std_path_PathBuf = v228 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v241 = v261 
                    #endif
                    let v264 : std_path_PathBuf = _run_target_args'_v241 
                    (* run_target_args'
                    let v274 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v275 : string = "Ok($0)"
                    let v276 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v264 v275 
                    let _run_target_args'_v274 = v276 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v277 : string = "Ok($0)"
                    let v278 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v264 v277 
                    let _run_target_args'_v274 = v278 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v279 : string = "Ok($0)"
                    let v280 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v264 v279 
                    let _run_target_args'_v274 = v280 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v281 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v281 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v282 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v282 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v283 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v283 
                    #endif
#else
                    let v284 : Result<std_path_PathBuf, std_io_Error> = v264 |> Ok
                    let _run_target_args'_v274 = v284 
                    #endif
                    let v285 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v274 
                    v285
            else
                let v345 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v346 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
                let v347 : string = v345 + v346 
                (* run_target_args'
                let v352 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v353 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v354 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v347 v353 
                let _run_target_args'_v352 = v354 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v355 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v356 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v347 v355 
                let _run_target_args'_v352 = v356 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v357 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v358 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v347 v357 
                let _run_target_args'_v352 = v358 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v360 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v360 
                #endif
#if FABLE_COMPILER_PYTHON
                let v364 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v364 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v368 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v368 
                #endif
#else
                let v372 : std_io_Error = v347 |> unbox<std_io_Error>
                let _run_target_args'_v352 = v372 
                #endif
                let v375 : std_io_Error = _run_target_args'_v352 
                (* run_target_args'
                let v385 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v386 : string = "Err($0)"
                let v387 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v386 
                let _run_target_args'_v385 = v387 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v388 : string = "Err($0)"
                let v389 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v388 
                let _run_target_args'_v385 = v389 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v390 : string = "Err($0)"
                let v391 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v390 
                let _run_target_args'_v385 = v391 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v392 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v392 
                #endif
#if FABLE_COMPILER_PYTHON
                let v393 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v393 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v394 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v394 
                #endif
#else
                let v395 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v385 = v395 
                #endif
                let v396 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v385 
                v396
        | _ ->
            let v400 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v401 : string = $"path: {v0} / error: {v35} / path': {v4} / name: {v5}"
            let v402 : string = v400 + v401 
            (* run_target_args'
            let v407 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v408 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v409 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v402 v408 
            let _run_target_args'_v407 = v409 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v410 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v411 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v402 v410 
            let _run_target_args'_v407 = v411 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v412 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v413 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v402 v412 
            let _run_target_args'_v407 = v413 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v415 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v415 
            #endif
#if FABLE_COMPILER_PYTHON
            let v419 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v419 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v423 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v423 
            #endif
#else
            let v427 : std_io_Error = v402 |> unbox<std_io_Error>
            let _run_target_args'_v407 = v427 
            #endif
            let v430 : std_io_Error = _run_target_args'_v407 
            (* run_target_args'
            let v440 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v441 : string = "Err($0)"
            let v442 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v430 v441 
            let _run_target_args'_v440 = v442 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v443 : string = "Err($0)"
            let v444 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v430 v443 
            let _run_target_args'_v440 = v444 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v445 : string = "Err($0)"
            let v446 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v430 v445 
            let _run_target_args'_v440 = v446 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v447 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v447 
            #endif
#if FABLE_COMPILER_PYTHON
            let v448 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v448 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v449 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v449 
            #endif
#else
            let v450 : Result<std_path_PathBuf, std_io_Error> = v430 |> Error
            let _run_target_args'_v440 = v450 
            #endif
            let v451 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v440 
            v451
and method122 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
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
    let v45 : System.IO.FileAttributes = method119(v36)
    let v46 : System.IO.FileAttributes = method120()
    let v47 : bool = method121(v46, v45)
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
        method123(v0, v190, v1, v181, v2)
and closure57 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method122(v0, v1, v2)
and closure56 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure57(v0, v1)
and method124 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method19(v0)
    let v5 : string option = method115(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method47(v3)
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
        let v76 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v77 : string = "Err($0)"
        let v78 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v77 
        let _run_target_args'_v76 = v78 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v79 : string = "Err($0)"
        let v80 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v79 
        let _run_target_args'_v76 = v80 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v81 : string = "Err($0)"
        let v82 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v66 v81 
        let _run_target_args'_v76 = v82 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v83 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v83 
        #endif
#if FABLE_COMPILER_PYTHON
        let v84 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v84 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v85 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v85 
        #endif
#else
        let v86 : Result<std_path_PathBuf, std_io_Error> = v66 |> Error
        let _run_target_args'_v76 = v86 
        #endif
        let v87 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v76 
        v87
    else
        match v30 with
        | US5_0(v90) -> (* Some *)
            let v93 : string = ""
            let v94 : bool = v0 <> v93 
            if v94 then
                let v97 : uint8 = v2 + 1uy
                let v98 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v97
                let v99 : Result<std_path_PathBuf, std_io_Error> = v98 v90
                let v100 : (std_io_Error -> string) = method46()
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
                let v116 : (std_path_PathBuf -> US15) = method111()
                let v117 : (string -> US15) = method112()
                let v119 : US15 = match v113 with Ok x -> v116 x | Error x -> v117 x
                match v119 with
                | US15_1(v287) -> (* Error *)
                    let v288 : string = $"file_system.read_link / "
                    let v289 : string = $"error': {v287} / error: {v34} / name: {v4}"
                    let v290 : string = v288 + v289 
                    (* run_target_args'
                    let v295 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v296 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v297 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v290 v296 
                    let _run_target_args'_v295 = v297 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v298 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v299 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v290 v298 
                    let _run_target_args'_v295 = v299 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v300 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v301 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v290 v300 
                    let _run_target_args'_v295 = v301 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v303 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v303 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v307 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v307 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v311 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v311 
                    #endif
#else
                    let v315 : std_io_Error = v290 |> unbox<std_io_Error>
                    let _run_target_args'_v295 = v315 
                    #endif
                    let v318 : std_io_Error = _run_target_args'_v295 
                    (* run_target_args'
                    let v328 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v329 : string = "Err($0)"
                    let v330 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v318 v329 
                    let _run_target_args'_v328 = v330 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v331 : string = "Err($0)"
                    let v332 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v318 v331 
                    let _run_target_args'_v328 = v332 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v333 : string = "Err($0)"
                    let v334 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v318 v333 
                    let _run_target_args'_v328 = v334 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v335 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v335 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v336 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v336 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v337 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v337 
                    #endif
#else
                    let v338 : Result<std_path_PathBuf, std_io_Error> = v318 |> Error
                    let _run_target_args'_v328 = v338 
                    #endif
                    let v339 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v328 
                    v339
                | US15_0(v122) -> (* Ok *)
                    (* run_target_args'
                    let v127 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v128 : string = "$0.display()"
                    let v129 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v122 v128 
                    let _run_target_args'_v127 = v129 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v130 : string = "$0.display()"
                    let v131 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v122 v130 
                    let _run_target_args'_v127 = v131 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v132 : string = "$0.display()"
                    let v133 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v122 v132 
                    let _run_target_args'_v127 = v133 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v135 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v135 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v139 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v139 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v143 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v143 
                    #endif
#else
                    let v147 : std_path_Display = v122 |> unbox<std_path_Display>
                    let _run_target_args'_v127 = v147 
                    #endif
                    let v150 : std_path_Display = _run_target_args'_v127 
                    let v160 : string = v150 |> string 
                    let v163 : string = method88(v160, v4)
                    (* run_target_args'
                    let v168 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v169 : string = "&*$0"
                    let v170 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v163 v169 
                    let _run_target_args'_v168 = v170 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v171 : string = "&*$0"
                    let v172 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v163 v171 
                    let _run_target_args'_v168 = v172 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v173 : string = "&*$0"
                    let v174 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v163 v173 
                    let _run_target_args'_v168 = v174 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v176 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v176 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v180 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v180 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v184 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v184 
                    #endif
#else
                    let v188 : Ref<Str> = v163 |> unbox<Ref<Str>>
                    let _run_target_args'_v168 = v188 
                    #endif
                    let v191 : Ref<Str> = _run_target_args'_v168 
                    (* run_target_args'
                    let v204 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v205 : string = "String::from($0)"
                    let v206 : std_string_String = Fable.Core.RustInterop.emitRustExpr v191 v205 
                    let _run_target_args'_v204 = v206 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v207 : string = "String::from($0)"
                    let v208 : std_string_String = Fable.Core.RustInterop.emitRustExpr v191 v207 
                    let _run_target_args'_v204 = v208 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v209 : string = "String::from($0)"
                    let v210 : std_string_String = Fable.Core.RustInterop.emitRustExpr v191 v209 
                    let _run_target_args'_v204 = v210 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v212 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v212 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v216 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v216 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v220 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v220 
                    #endif
#else
                    let v224 : std_string_String = v191 |> unbox<std_string_String>
                    let _run_target_args'_v204 = v224 
                    #endif
                    let v227 : std_string_String = _run_target_args'_v204 
                    (* run_target_args'
                    let v240 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v241 : string = "std::path::PathBuf::from($0)"
                    let v242 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v227 v241 
                    let _run_target_args'_v240 = v242 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v243 : string = "std::path::PathBuf::from($0)"
                    let v244 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v227 v243 
                    let _run_target_args'_v240 = v244 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v245 : string = "std::path::PathBuf::from($0)"
                    let v246 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v227 v245 
                    let _run_target_args'_v240 = v246 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v248 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v248 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v252 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v252 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v256 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v256 
                    #endif
#else
                    let v260 : std_path_PathBuf = v227 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v240 = v260 
                    #endif
                    let v263 : std_path_PathBuf = _run_target_args'_v240 
                    (* run_target_args'
                    let v273 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v274 : string = "Ok($0)"
                    let v275 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v263 v274 
                    let _run_target_args'_v273 = v275 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v276 : string = "Ok($0)"
                    let v277 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v263 v276 
                    let _run_target_args'_v273 = v277 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v278 : string = "Ok($0)"
                    let v279 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v263 v278 
                    let _run_target_args'_v273 = v279 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v280 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v280 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v281 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v281 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v282 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v282 
                    #endif
#else
                    let v283 : Result<std_path_PathBuf, std_io_Error> = v263 |> Ok
                    let _run_target_args'_v273 = v283 
                    #endif
                    let v284 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v273 
                    v284
            else
                let v344 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v345 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
                let v346 : string = v344 + v345 
                (* run_target_args'
                let v351 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v352 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v353 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v346 v352 
                let _run_target_args'_v351 = v353 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v354 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v355 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v346 v354 
                let _run_target_args'_v351 = v355 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v356 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v357 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v346 v356 
                let _run_target_args'_v351 = v357 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v359 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v359 
                #endif
#if FABLE_COMPILER_PYTHON
                let v363 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v363 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v367 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v367 
                #endif
#else
                let v371 : std_io_Error = v346 |> unbox<std_io_Error>
                let _run_target_args'_v351 = v371 
                #endif
                let v374 : std_io_Error = _run_target_args'_v351 
                (* run_target_args'
                let v384 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v385 : string = "Err($0)"
                let v386 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v374 v385 
                let _run_target_args'_v384 = v386 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v387 : string = "Err($0)"
                let v388 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v374 v387 
                let _run_target_args'_v384 = v388 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v389 : string = "Err($0)"
                let v390 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v374 v389 
                let _run_target_args'_v384 = v390 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v391 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v391 
                #endif
#if FABLE_COMPILER_PYTHON
                let v392 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v392 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v393 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v393 
                #endif
#else
                let v394 : Result<std_path_PathBuf, std_io_Error> = v374 |> Error
                let _run_target_args'_v384 = v394 
                #endif
                let v395 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v384 
                v395
        | _ ->
            let v399 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v400 : string = $"path: {v0} / error: {v34} / path': {v0} / name: {v4}"
            let v401 : string = v399 + v400 
            (* run_target_args'
            let v406 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v407 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v408 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v401 v407 
            let _run_target_args'_v406 = v408 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v409 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v410 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v401 v409 
            let _run_target_args'_v406 = v410 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v411 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v412 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v401 v411 
            let _run_target_args'_v406 = v412 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v414 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v414 
            #endif
#if FABLE_COMPILER_PYTHON
            let v418 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v418 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v422 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v422 
            #endif
#else
            let v426 : std_io_Error = v401 |> unbox<std_io_Error>
            let _run_target_args'_v406 = v426 
            #endif
            let v429 : std_io_Error = _run_target_args'_v406 
            (* run_target_args'
            let v439 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v440 : string = "Err($0)"
            let v441 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v429 v440 
            let _run_target_args'_v439 = v441 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v442 : string = "Err($0)"
            let v443 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v429 v442 
            let _run_target_args'_v439 = v443 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v444 : string = "Err($0)"
            let v445 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v429 v444 
            let _run_target_args'_v439 = v445 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v446 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v446 
            #endif
#if FABLE_COMPILER_PYTHON
            let v447 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v447 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v448 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v448 
            #endif
#else
            let v449 : Result<std_path_PathBuf, std_io_Error> = v429 |> Error
            let _run_target_args'_v439 = v449 
            #endif
            let v450 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v439 
            v450
and method118 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
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
    let v44 : System.IO.FileAttributes = method119(v35)
    let v45 : System.IO.FileAttributes = method120()
    let v46 : bool = method121(v45, v44)
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
        method124(v0, v189, v1, v180)
and method109 (v0 : string) : Result<std_path_PathBuf, std_io_Error> =
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
            method110(v0, v6)
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
            method110(v0, v12)
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
            method110(v0, v18)
    let _run_target_args'_v2 = v20 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : uint8 = 0uy
    let v22 : Result<std_path_PathBuf, std_io_Error> = method118(v0, v21)
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : Result<std_path_PathBuf, std_io_Error> = Unchecked.defaultof<_>
    let _run_target_args'_v2 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : uint8 = 0uy
    let v25 : Result<std_path_PathBuf, std_io_Error> = method118(v0, v24)
    let _run_target_args'_v2 = v25 
    #endif
#else
    let v26 : uint8 = 0uy
    let v27 : Result<std_path_PathBuf, std_io_Error> = method118(v0, v26)
    let _run_target_args'_v2 = v27 
    #endif
    let v28 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v2 
    v28
and closure58 () (v0 : std_path_PathBuf) : US16 =
    US16_0(v0)
and method125 () : (std_path_PathBuf -> US16) =
    closure58()
and method127 (v0 : string) : string =
    v0
and method128 () : string =
    let v0 : string = ""
    v0
and method126 (v0 : string, v1 : string, v2 : string) : string =
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
    let v22 : string = method127(v2)
    let v23 : string = $"$0.replace_all(&*$1, &*$2)"
    let v24 : std_borrow_Cow<Str> = Fable.Core.RustInterop.emitRustExpr struct (v19, v22, v1) v23 
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v4 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = method128()
    let _run_target_args'_v4 = v29 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v30 : string = method128()
    let _run_target_args'_v4 = v30 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v31 : string = method128()
    let _run_target_args'_v4 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : string = method128()
    let _run_target_args'_v4 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v33 : string = method128()
    let _run_target_args'_v4 = v33 
    #endif
#else
    let v34 : string = System.Text.RegularExpressions.Regex.Replace (v2, v0, v1)
    let _run_target_args'_v4 = v34 
    #endif
    let v35 : string = _run_target_args'_v4 
    v35
and method108 (v0 : string) : string =
    let v1 : bool = v0 = ""
    if v1 then
        let v2 : string = ""
        v2
    else
        let v3 : Result<std_path_PathBuf, std_io_Error> = method109(v0)
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
        let v21 : (std_path_PathBuf -> US16) = method125()
        let v22 : US16 option = v16 |> Option.map v21 
        let v42 : US16 = US16_1
        let v43 : US16 = v22 |> Option.defaultValue v42 
        let v89 : string =
            match v43 with
            | US16_1 -> (* None *)
                v0
            | US16_0(v47) -> (* Some *)
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
        let v94 : string = method126(v92, v93, v91)
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
    method108(v0)
and method130 () : string =
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
and method131 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method132 (v0 : int32, v1 : Mut6) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method133 () : char =
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
and method134 (v0 : string) : string =
    v0
and method129 (v0 : string) : string =
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
            let v117 : string = method130()
            let v118 : string = method88(v117, v0)
            let v119 : string = method108(v118)
            let v127 : string = "/"
            let v128 : (string []) = v119.Split v127 
            let v131 : (string []) = [||]
            let v132 : int32 = v128.Length
            let v133 : Mut5 = {l0 = 0; l1 = 0; l2 = v131} : Mut5
            while method131(v132, v133) do
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
                                    while method132(v156, v158) do
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
                                    while method132(v170, v172) do
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
            let v206 : char = method133()
            let v208 : (char -> string) = _.ToString()
            let v209 : string = v208 v206
            let v213 : bool = v209 = "\n"
            let v215 : string =
                if v213 then
                    method134(v209)
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
    method129(v0)
and method135 (v0 : string) : string =
    let v1 : string = method129(v0)
    method108(v1)
and closure60 () (v0 : string) : string =
    method135(v0)
and closure61 () (v0 : string) : string =
    let v1 : char list = []
    let v3 : char list = '/' :: v1 
    let v8 : (char list -> (char [])) = List.toArray
    let v9 : (char []) = v8 v3
    let v12 : string = v0.TrimStart v9 
    let v46 : string = $"file:///{v12}"
    v46
and closure63 () (v0 : string) : bool =
    method36(v0)
and closure64 () (v0 : string) : bool =
    method10(v0)
and method139 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool), v4 : string) : US18 =
    let v5 : string = method88(v4, v0)
    let v6 : bool = v3 v5
    if v6 then
        US18_0(v4)
    else
        let v8 : string option = method115(v4)
        let v11 : (string -> US5) = method5()
        let v12 : US5 option = v8 |> Option.map v11 
        let v32 : US5 = US5_1
        let v33 : US5 = v12 |> Option.defaultValue v32 
        match v33 with
        | US5_1 -> (* None *)
            let v39 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v40 : string = $" '{v0}' at '{v1}' (until '{v4}')"
            let v41 : string = v39 + v40 
            US18_1(v41)
        | US5_0(v37) -> (* Some *)
            method139(v0, v1, v2, v3, v37)
and method138 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool)) : US18 =
    let v4 : string = method88(v1, v0)
    let v5 : bool = v3 v4
    if v5 then
        US18_0(v1)
    else
        let v7 : string option = method115(v1)
        let v10 : (string -> US5) = method5()
        let v11 : US5 option = v7 |> Option.map v10 
        let v31 : US5 = US5_1
        let v32 : US5 = v11 |> Option.defaultValue v31 
        match v32 with
        | US5_1 -> (* None *)
            let v38 : string = $"""file_system.find_parent / No parent for {if v2 then "file" else "dir"}"""
            let v39 : string = $" '{v0}' at '{v1}' (until '{v1}')"
            let v40 : string = v38 + v39 
            US18_1(v40)
        | US5_0(v36) -> (* Some *)
            method139(v0, v1, v2, v3, v36)
and method137 (v0 : US17, v1 : string, v2 : string) : US18 =
    let v3 : bool =
        match v0 with
        | US17_0 -> (* File *)
            true
        | _ ->
            false
    let v6 : (string -> bool) =
        if v3 then
            closure63()
        else
            closure64()
    method138(v1, v2, v3, v6)
and method141 (v0 : string, v1 : string) : string =
    let v2 : string = method17()
    let v3 : Mut3 = {l0 = v2} : Mut3
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure6(v3, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v25 : string = "dir"
    let v26 : string = $"{v25}"
    let v34 : unit = ()
    let v35 : (unit -> unit) = closure6(v3, v26)
    let v36 : unit = (fun () -> v35 (); v34) ()
    let v44 : string = " = "
    let v45 : string = $"{v44}"
    let v53 : unit = ()
    let v54 : (unit -> unit) = closure6(v3, v45)
    let v55 : unit = (fun () -> v54 (); v53) ()
    let v62 : string = $"{v0}"
    let v70 : unit = ()
    let v71 : (unit -> unit) = closure6(v3, v62)
    let v72 : unit = (fun () -> v71 (); v70) ()
    let v80 : string = "; "
    let v81 : string = $"{v80}"
    let v89 : unit = ()
    let v90 : (unit -> unit) = closure6(v3, v81)
    let v91 : unit = (fun () -> v90 (); v89) ()
    let v99 : string = "error"
    let v100 : string = $"{v99}"
    let v108 : unit = ()
    let v109 : (unit -> unit) = closure6(v3, v100)
    let v110 : unit = (fun () -> v109 (); v108) ()
    let v117 : string = $"{v44}"
    let v125 : unit = ()
    let v126 : (unit -> unit) = closure6(v3, v117)
    let v127 : unit = (fun () -> v126 (); v125) ()
    let v134 : string = $"{v1}"
    let v142 : unit = ()
    let v143 : (unit -> unit) = closure6(v3, v134)
    let v144 : unit = (fun () -> v143 (); v142) ()
    let v152 : string = " }"
    let v153 : string = $"{v152}"
    let v161 : unit = ()
    let v162 : (unit -> unit) = closure6(v3, v153)
    let v163 : unit = (fun () -> v162 (); v161) ()
    let v169 : string = v3.l0
    v169
and method140 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method141(v8, v9)
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
    let v43 : string = "file_system.get_workspace_root"
    let v44 : string = v38 + v43 
    let v49 : string = " / "
    let v50 : string = v44 + v49 
    let v54 : string = v50 + v10 
    method22(v54)
and closure65 (v0 : string, v1 : string) () : unit =
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure0()
    let v18 : unit = (fun () -> v17 (); v16) ()
    let struct (v41 : Mut0, v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : int64 option) = TraceState.trace_state.Value
    let v59 : US0 = v45.l0
    let v60 : bool = v43.l0
    let v61 : bool = v60 = false
    let v64 : bool =
        if v61 then
            false
        else
            let v62 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v59
            let v63 : bool = 3 >= v62
            v63
    let v65 : bool = v64 = false
    let v299 : US6 =
        if v65 then
            US6_1
        else
            let v81 : unit = ()
            let v82 : unit = (fun () -> v17 (); v81) ()
            let struct (v105 : Mut0, v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : int64 option) = TraceState.trace_state.Value
            let v123 : string = method11(v105, v106, v107, v108, v109, v110)
            let v124 : string = method53()
            let v125 : string = method140(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
            let v140 : unit = ()
            let v141 : unit = (fun () -> v17 (); v140) ()
            let struct (v164 : Mut0, v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : int64 option) = TraceState.trace_state.Value
            let v184 : unit = ()
            let v185 : (unit -> unit) = closure7(v164)
            let v186 : unit = (fun () -> v185 (); v184) ()
            let v189 : (string -> unit) = closure8()
            (* run_target_args'
            let v190 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v191 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v191 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v192 : string = @"println!(""{}"", $0)"
            Fable.Core.RustInterop.emitRustExpr v125 v192 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v193 : string = v167.l0
            let v194 : bool = v193 = ""
            let v209 : string =
                if v194 then
                    v125
                else
                    let v195 : bool = v125 = ""
                    if v195 then
                        let v196 : string = v167.l0
                        v196
                    else
                        let v197 : string = v167.l0
                        let v200 : string = "\n"
                        let v201 : string = v197 + v200 
                        let v205 : string = v201 + v125 
                        v205
            (* run_target_args'
            let v214 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v215 : string = "&*$0"
            let v216 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v215 
            let _run_target_args'_v214 = v216 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v217 : string = "&*$0"
            let v218 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v217 
            let _run_target_args'_v214 = v218 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v219 : string = "&*$0"
            let v220 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v209 v219 
            let _run_target_args'_v214 = v220 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v222 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v226 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v226 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v230 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v230 
            #endif
#else
            let v234 : Ref<Str> = v209 |> unbox<Ref<Str>>
            let _run_target_args'_v214 = v234 
            #endif
            let v237 : Ref<Str> = _run_target_args'_v214 
            let v246 : string = $"$0.chars()"
            let v247 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v237 v246 
            let v248 : string = "$0"
            let v249 : _ = Fable.Core.RustInterop.emitRustExpr v247 v248 
            let v250 : string = "$0.collect::<Vec<_>>()"
            let v251 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v249 v250 
            let v252 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
            let v253 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v251 v252 
            let v254 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
            let v255 : bool = Fable.Core.RustInterop.emitRustExpr v253 v254 
            let v256 : string = "x"
            let v257 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v256 
            let v258 : string = "String::from_iter($0)"
            let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v257 v258 
            let v260 : string = "true; $0 }).collect::<Vec<_>>()"
            let v261 : bool = Fable.Core.RustInterop.emitRustExpr v259 v260 
            let v262 : string = "_vec_map"
            let v263 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v262 
            let v264 : string = "$0.len()"
            let v265 : unativeint = Fable.Core.RustInterop.emitRustExpr v263 v264 
            let v271 : int32 = v265 |> int32 
            let v281 : string = ""
            let v282 : bool = v125 <> v281 
            let v286 : bool =
                if v282 then
                    let v285 : bool = v271 <= 1
                    v285
                else
                    false
            if v286 then
                v167.l0 <- v209
                ()
            else
                v167.l0 <- v281
                let v287 : string = "true; $0.into_iter().for_each(|x| { //"
                let v288 : bool = Fable.Core.RustInterop.emitRustExpr v263 v287 
                let v289 : string = "x"
                let v290 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v289 
                let v291 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
                let v292 : bool = Fable.Core.RustInterop.emitRustExpr v290 v291 
                let v293 : string = $"true"
                let v294 : bool = Fable.Core.RustInterop.emitRustExpr () v293 
                let v295 : string = "true; }); //"
                let v296 : bool = Fable.Core.RustInterop.emitRustExpr () v295 
                ()
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            v189 v125
            #endif
#if FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            v189 v125
            #endif
#else
            v189 v125
            #endif
            // run_target_args' is_unit
            let v297 : (string -> unit) = v165.l0
            v297 v125
            US6_0(v164, v165, v166, v167, v168, v169)
    
    ()
and method136 (v0 : string) : US5 =
    let v1 : US17 = US17_1
    let v2 : string = "spiral"
    let v3 : string = "workspace"
    let v4 : string = method88(v2, v3)
    let v5 : US18 = method137(v1, v4, v0)
    match v5 with
    | US18_1(v9) -> (* Error *)
        let v321 : unit = ()
        let v322 : (unit -> unit) = closure65(v0, v9)
        let v323 : unit = (fun () -> v322 (); v321) ()
        US5_1
    | US18_0(v6) -> (* Ok *)
        let v7 : string = method108(v6)
        US5_0(v7)
and closure62 () () : string =
    let v0 : string = method130()
    let v1 : US5 = method136(v0)
    let v7 : US5 =
        match v1 with
        | US5_1 -> (* None *)
            let v4 : string = __SOURCE_DIRECTORY__
            method136(v4)
        | US5_0(v2) -> (* Some *)
            US5_0(v2)
    let v13 : US5 =
        match v7 with
        | US5_1 -> (* None *)
            let v10 : string = "/workspaces"
            method136(v10)
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
            let v20 : string option = method115(v17)
            let v22 : string = v20 |> Option.get
            let v25 : US5 = method136(v22)
            match v25 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v26) -> (* Some *)
                v26
        else
            v17
    let v31 : string = "polyglot"
    method88(v30, v31)
and closure67 (v0 : exn) () : exn =
    v0
and method142 (v0 : string) : unit =
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
        let v74 : string = method89()
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
        let v102 : System.Guid = method80(v99, v92)
        let v103 : string = $"{v74}_{v102}.txt"
        let v104 : string = method130()
        let v105 : US5 = method136(v104)
        let v111 : US5 =
            match v105 with
            | US5_1 -> (* None *)
                let v108 : string = __SOURCE_DIRECTORY__
                method136(v108)
            | US5_0(v106) -> (* Some *)
                US5_0(v106)
        let v117 : US5 =
            match v111 with
            | US5_1 -> (* None *)
                let v114 : string = "/workspaces"
                method136(v114)
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
                let v124 : string option = method115(v121)
                let v126 : string = v124 |> Option.get
                let v129 : US5 = method136(v126)
                match v129 with
                | US5_1 -> (* None *)
                    failwith<string> "Option does not have a value."
                | US5_0(v130) -> (* Some *)
                    v130
            else
                v121
        let v135 : string = "polyglot"
        let v136 : string = method88(v134, v135)
        let v137 : string = "target/trace"
        let v138 : string = method88(v136, v137)
        let v139 : System_IO_DirectoryInfo = method101(v138)
        let v140 : string = method88(v138, v103)
        let v141 : Async<unit> = method38(v140, v0)
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
        method142(v228)
        (* indent
        ()
    indent *)
    (* try_unit
    try_unit *)
    #endif
    // run_target_args' is_unit
    ()
and closure66 () (v0 : string) : unit =
    method142(v0)
and closure68 () (v0 : bool) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v60 : (string -> unit) =
        if v0 then
            closure66()
        else
            closure2()
    v41.l0 <- v60
    ()
and method143 (v0 : string, v1 : string) : unit =
    let v2 : bool = method10(v0)
    let v3 : bool = v2 = false
    if v3 then
        let v4 : System.IDisposable = method91(v0)
        ()
    let v5 : string option = method115(v1)
    let v8 : string = ""
    let v9 : string = v5 |> Option.defaultValue v8 
    let v12 : bool = method10(v9)
    let v13 : bool = v12 = false
    if v13 then
        let v14 : System.IDisposable = method91(v9)
        ()
    let v15 : bool = method10(v1)
    let v25 : bool =
        if v15 then
            let v16 : Result<std_path_PathBuf, std_io_Error> = method109(v1)
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
    method143(v0, v1)
and closure69 () (v0 : string) : (string -> unit) =
    closure70(v0)
and closure72 (v0 : string) (v1 : string) : string =
    method88(v0, v1)
and closure71 () (v0 : string) : (string -> string) =
    closure72(v0)
let v14 : unit = ()
let v15 : (unit -> unit) = closure0()
let v16 : unit = (fun () -> v15 (); v14) ()
let v31 : (string -> Async<int64>) = closure3()
let delete_directory_async x = v31 x
let v32 : (US7 -> (string -> Async<int64>)) = closure10()
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
