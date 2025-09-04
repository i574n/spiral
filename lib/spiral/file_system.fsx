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
    let v216 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v219 : (int64 -> US2) = method12()
    let v220 : US2 option = v5 |> Option.map v219 
    let v240 : US2 = US2_1
    let v241 : US2 = v220 |> Option.defaultValue v240 
    let v395 : System.DateTime =
        match v241 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v378 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v379 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v379 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v380 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v380 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v382 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v378 = v382 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v385 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v385 
            #endif
#if FABLE_COMPILER_PYTHON
            let v386 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v386 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v387 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v387 
            #endif
#else
            let v388 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v378 = v388 
            #endif
            let v389 : System.DateTime = _run_target_args'_v378 
            v389
        | US2_0(v245) -> (* Some *)
            (* run_target_args'
            let v252 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v253 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v253 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v254 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v254 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v256 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v252 = v256 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v259 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v259 
            #endif
#if FABLE_COMPILER_PYTHON
            let v260 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v260 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v261 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v261 
            #endif
#else
            let v262 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v252 = v262 
            #endif
            let v263 : System.DateTime = _run_target_args'_v252 
            (* run_target_args'
            let v274 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v275 : (System.DateTime -> int64) = _.Ticks
            let v276 : int64 = v275 v263
            let _run_target_args'_v274 = v276 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v277 : (System.DateTime -> int64) = _.Ticks
            let v278 : int64 = v277 v263
            let _run_target_args'_v274 = v278 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v280 : int64 = null |> unbox<int64>
            let _run_target_args'_v274 = v280 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v283 : (System.DateTime -> int64) = _.Ticks
            let v284 : int64 = v283 v263
            let _run_target_args'_v274 = v284 
            #endif
#if FABLE_COMPILER_PYTHON
            let v285 : (System.DateTime -> int64) = _.Ticks
            let v286 : int64 = v285 v263
            let _run_target_args'_v274 = v286 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v287 : (System.DateTime -> int64) = _.Ticks
            let v288 : int64 = v287 v263
            let _run_target_args'_v274 = v288 
            #endif
#else
            let v289 : (System.DateTime -> int64) = _.Ticks
            let v290 : int64 = v289 v263
            let _run_target_args'_v274 = v290 
            #endif
            let v291 : int64 = _run_target_args'_v274 
            let v313 : int64 = v291 |> int64 
            let v318 : int64 = v313 - v245
            let v324 : System.TimeSpan = v318 |> System.TimeSpan 
            let v330 : (System.TimeSpan -> int32) = _.Hours
            let v331 : int32 = v330 v324
            let v335 : (System.TimeSpan -> int32) = _.Minutes
            let v336 : int32 = v335 v324
            let v340 : (System.TimeSpan -> int32) = _.Seconds
            let v341 : int32 = v340 v324
            let v345 : (System.TimeSpan -> int32) = _.Milliseconds
            let v346 : int32 = v345 v324
            let v369 : System.DateTime = System.DateTime (1, 1, 1, v331, v336, v341, v346)
            v369
    let v396 : string = method13()
    let v408 : bool = v396 = ""
    let v410 : string =
        if v408 then
            let v409 : string = "M-d-y hh:mm:ss tt"
            v409
        else
            v396
    let v411 : (string -> string) = v395.ToString
    let v412 : string = v411 v410
    let _run_target_args'_v216 = v412 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v429 : (int64 -> US2) = method12()
    let v430 : US2 option = v5 |> Option.map v429 
    let v450 : US2 = US2_1
    let v451 : US2 = v430 |> Option.defaultValue v450 
    let v605 : System.DateTime =
        match v451 with
        | US2_1 -> (* None *)
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
            v599
        | US2_0(v455) -> (* Some *)
            (* run_target_args'
            let v462 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v463 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v463 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v464 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v464 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v466 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v462 = v466 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v469 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v469 
            #endif
#if FABLE_COMPILER_PYTHON
            let v470 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v470 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v471 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v471 
            #endif
#else
            let v472 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v462 = v472 
            #endif
            let v473 : System.DateTime = _run_target_args'_v462 
            (* run_target_args'
            let v484 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v485 : (System.DateTime -> int64) = _.Ticks
            let v486 : int64 = v485 v473
            let _run_target_args'_v484 = v486 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v487 : (System.DateTime -> int64) = _.Ticks
            let v488 : int64 = v487 v473
            let _run_target_args'_v484 = v488 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v490 : int64 = null |> unbox<int64>
            let _run_target_args'_v484 = v490 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v493 : (System.DateTime -> int64) = _.Ticks
            let v494 : int64 = v493 v473
            let _run_target_args'_v484 = v494 
            #endif
#if FABLE_COMPILER_PYTHON
            let v495 : (System.DateTime -> int64) = _.Ticks
            let v496 : int64 = v495 v473
            let _run_target_args'_v484 = v496 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v497 : (System.DateTime -> int64) = _.Ticks
            let v498 : int64 = v497 v473
            let _run_target_args'_v484 = v498 
            #endif
#else
            let v499 : (System.DateTime -> int64) = _.Ticks
            let v500 : int64 = v499 v473
            let _run_target_args'_v484 = v500 
            #endif
            let v501 : int64 = _run_target_args'_v484 
            let v523 : int64 = v501 |> int64 
            let v528 : int64 = v523 - v455
            let v534 : System.TimeSpan = v528 |> System.TimeSpan 
            let v540 : (System.TimeSpan -> int32) = _.Hours
            let v541 : int32 = v540 v534
            let v545 : (System.TimeSpan -> int32) = _.Minutes
            let v546 : int32 = v545 v534
            let v550 : (System.TimeSpan -> int32) = _.Seconds
            let v551 : int32 = v550 v534
            let v555 : (System.TimeSpan -> int32) = _.Milliseconds
            let v556 : int32 = v555 v534
            let v579 : System.DateTime = System.DateTime (1, 1, 1, v541, v546, v551, v556)
            v579
    let v606 : string = method13()
    let v618 : bool = v606 = ""
    let v620 : string =
        if v618 then
            let v619 : string = "M-d-y hh:mm:ss tt"
            v619
        else
            v606
    let v621 : (string -> string) = v605.ToString
    let v622 : string = v621 v620
    let _run_target_args'_v216 = v622 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v637 : string = $"near_sdk::env::block_timestamp()"
    let v638 : uint64 = Fable.Core.RustInterop.emitRustExpr () v637 
    let v641 : (int64 -> US2) = method12()
    let v642 : US2 option = v5 |> Option.map v641 
    let v662 : US2 = US2_1
    let v663 : US2 = v642 |> Option.defaultValue v662 
    let v675 : uint64 =
        match v663 with
        | US2_1 -> (* None *)
            v638
        | US2_0(v667) -> (* Some *)
            let v669 : (int64 -> uint64) = uint64
            let v670 : uint64 = v669 v667
            let v673 : uint64 = v638 - v670
            v673
    let v676 : uint64 = v675 / 1000000000UL
    let v677 : uint64 = v676 % 60UL
    let v678 : uint64 = v676 / 60UL
    let v679 : uint64 = v678 % 60UL
    let v680 : uint64 = v676 / 3600UL
    let v681 : uint64 = v680 % 24UL
    let v682 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v683 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v681, v679, v677) v682 
    let v684 : string = "fable_library_rust::String_::fromString($0)"
    let v685 : string = Fable.Core.RustInterop.emitRustExpr v683 v684 
    let _run_target_args'_v216 = v685 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v688 : (int64 -> US2) = method12()
    let v689 : US2 option = v5 |> Option.map v688 
    let v709 : US2 = US2_1
    let v710 : US2 = v689 |> Option.defaultValue v709 
    let v864 : System.DateTime =
        match v710 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v847 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v848 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v848 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v849 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v849 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v851 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v847 = v851 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v854 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v854 
            #endif
#if FABLE_COMPILER_PYTHON
            let v855 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v855 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v856 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v856 
            #endif
#else
            let v857 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v847 = v857 
            #endif
            let v858 : System.DateTime = _run_target_args'_v847 
            v858
        | US2_0(v714) -> (* Some *)
            (* run_target_args'
            let v721 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v722 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v722 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v723 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v723 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v725 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v721 = v725 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v728 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v728 
            #endif
#if FABLE_COMPILER_PYTHON
            let v729 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v729 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v730 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v730 
            #endif
#else
            let v731 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v721 = v731 
            #endif
            let v732 : System.DateTime = _run_target_args'_v721 
            (* run_target_args'
            let v743 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v744 : (System.DateTime -> int64) = _.Ticks
            let v745 : int64 = v744 v732
            let _run_target_args'_v743 = v745 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v746 : (System.DateTime -> int64) = _.Ticks
            let v747 : int64 = v746 v732
            let _run_target_args'_v743 = v747 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v749 : int64 = null |> unbox<int64>
            let _run_target_args'_v743 = v749 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v752 : (System.DateTime -> int64) = _.Ticks
            let v753 : int64 = v752 v732
            let _run_target_args'_v743 = v753 
            #endif
#if FABLE_COMPILER_PYTHON
            let v754 : (System.DateTime -> int64) = _.Ticks
            let v755 : int64 = v754 v732
            let _run_target_args'_v743 = v755 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v756 : (System.DateTime -> int64) = _.Ticks
            let v757 : int64 = v756 v732
            let _run_target_args'_v743 = v757 
            #endif
#else
            let v758 : (System.DateTime -> int64) = _.Ticks
            let v759 : int64 = v758 v732
            let _run_target_args'_v743 = v759 
            #endif
            let v760 : int64 = _run_target_args'_v743 
            let v782 : int64 = v760 |> int64 
            let v787 : int64 = v782 - v714
            let v793 : System.TimeSpan = v787 |> System.TimeSpan 
            let v799 : (System.TimeSpan -> int32) = _.Hours
            let v800 : int32 = v799 v793
            let v804 : (System.TimeSpan -> int32) = _.Minutes
            let v805 : int32 = v804 v793
            let v809 : (System.TimeSpan -> int32) = _.Seconds
            let v810 : int32 = v809 v793
            let v814 : (System.TimeSpan -> int32) = _.Milliseconds
            let v815 : int32 = v814 v793
            let v838 : System.DateTime = System.DateTime (1, 1, 1, v800, v805, v810, v815)
            v838
    let v865 : string = method14()
    let v877 : bool = v865 = ""
    let v879 : string =
        if v877 then
            let v878 : string = "M-d-y hh:mm:ss tt"
            v878
        else
            v865
    let v880 : (string -> string) = v864.ToString
    let v881 : string = v880 v879
    let _run_target_args'_v216 = v881 
    #endif
#if FABLE_COMPILER_PYTHON
    let v898 : (int64 -> US2) = method12()
    let v899 : US2 option = v5 |> Option.map v898 
    let v919 : US2 = US2_1
    let v920 : US2 = v899 |> Option.defaultValue v919 
    let v1074 : System.DateTime =
        match v920 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1057 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1058 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1058 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1059 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1059 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1061 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1057 = v1061 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1064 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1064 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1065 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1065 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1066 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1066 
            #endif
#else
            let v1067 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1057 = v1067 
            #endif
            let v1068 : System.DateTime = _run_target_args'_v1057 
            v1068
        | US2_0(v924) -> (* Some *)
            (* run_target_args'
            let v931 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v932 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v932 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v933 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v933 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v935 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v931 = v935 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v938 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v938 
            #endif
#if FABLE_COMPILER_PYTHON
            let v939 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v939 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v940 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v940 
            #endif
#else
            let v941 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v931 = v941 
            #endif
            let v942 : System.DateTime = _run_target_args'_v931 
            (* run_target_args'
            let v953 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v954 : (System.DateTime -> int64) = _.Ticks
            let v955 : int64 = v954 v942
            let _run_target_args'_v953 = v955 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v956 : (System.DateTime -> int64) = _.Ticks
            let v957 : int64 = v956 v942
            let _run_target_args'_v953 = v957 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v959 : int64 = null |> unbox<int64>
            let _run_target_args'_v953 = v959 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v962 : (System.DateTime -> int64) = _.Ticks
            let v963 : int64 = v962 v942
            let _run_target_args'_v953 = v963 
            #endif
#if FABLE_COMPILER_PYTHON
            let v964 : (System.DateTime -> int64) = _.Ticks
            let v965 : int64 = v964 v942
            let _run_target_args'_v953 = v965 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v966 : (System.DateTime -> int64) = _.Ticks
            let v967 : int64 = v966 v942
            let _run_target_args'_v953 = v967 
            #endif
#else
            let v968 : (System.DateTime -> int64) = _.Ticks
            let v969 : int64 = v968 v942
            let _run_target_args'_v953 = v969 
            #endif
            let v970 : int64 = _run_target_args'_v953 
            let v992 : int64 = v970 |> int64 
            let v997 : int64 = v992 - v924
            let v1003 : System.TimeSpan = v997 |> System.TimeSpan 
            let v1009 : (System.TimeSpan -> int32) = _.Hours
            let v1010 : int32 = v1009 v1003
            let v1014 : (System.TimeSpan -> int32) = _.Minutes
            let v1015 : int32 = v1014 v1003
            let v1019 : (System.TimeSpan -> int32) = _.Seconds
            let v1020 : int32 = v1019 v1003
            let v1024 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1025 : int32 = v1024 v1003
            let v1048 : System.DateTime = System.DateTime (1, 1, 1, v1010, v1015, v1020, v1025)
            v1048
    let v1075 : string = method14()
    let v1087 : bool = v1075 = ""
    let v1089 : string =
        if v1087 then
            let v1088 : string = "M-d-y hh:mm:ss tt"
            v1088
        else
            v1075
    let v1090 : (string -> string) = v1074.ToString
    let v1091 : string = v1090 v1089
    let _run_target_args'_v216 = v1091 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1108 : (int64 -> US2) = method12()
    let v1109 : US2 option = v5 |> Option.map v1108 
    let v1129 : US2 = US2_1
    let v1130 : US2 = v1109 |> Option.defaultValue v1129 
    let v1284 : System.DateTime =
        match v1130 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1267 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1268 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1268 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1269 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1269 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1271 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1267 = v1271 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1274 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1274 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1275 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1275 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1276 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1276 
            #endif
#else
            let v1277 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1267 = v1277 
            #endif
            let v1278 : System.DateTime = _run_target_args'_v1267 
            v1278
        | US2_0(v1134) -> (* Some *)
            (* run_target_args'
            let v1141 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1142 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1142 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1143 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1145 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1141 = v1145 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1148 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1148 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1149 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1149 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1150 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1150 
            #endif
#else
            let v1151 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1141 = v1151 
            #endif
            let v1152 : System.DateTime = _run_target_args'_v1141 
            (* run_target_args'
            let v1163 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1164 : (System.DateTime -> int64) = _.Ticks
            let v1165 : int64 = v1164 v1152
            let _run_target_args'_v1163 = v1165 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1166 : (System.DateTime -> int64) = _.Ticks
            let v1167 : int64 = v1166 v1152
            let _run_target_args'_v1163 = v1167 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1169 : int64 = null |> unbox<int64>
            let _run_target_args'_v1163 = v1169 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1172 : (System.DateTime -> int64) = _.Ticks
            let v1173 : int64 = v1172 v1152
            let _run_target_args'_v1163 = v1173 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1174 : (System.DateTime -> int64) = _.Ticks
            let v1175 : int64 = v1174 v1152
            let _run_target_args'_v1163 = v1175 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1176 : (System.DateTime -> int64) = _.Ticks
            let v1177 : int64 = v1176 v1152
            let _run_target_args'_v1163 = v1177 
            #endif
#else
            let v1178 : (System.DateTime -> int64) = _.Ticks
            let v1179 : int64 = v1178 v1152
            let _run_target_args'_v1163 = v1179 
            #endif
            let v1180 : int64 = _run_target_args'_v1163 
            let v1202 : int64 = v1180 |> int64 
            let v1207 : int64 = v1202 - v1134
            let v1213 : System.TimeSpan = v1207 |> System.TimeSpan 
            let v1219 : (System.TimeSpan -> int32) = _.Hours
            let v1220 : int32 = v1219 v1213
            let v1224 : (System.TimeSpan -> int32) = _.Minutes
            let v1225 : int32 = v1224 v1213
            let v1229 : (System.TimeSpan -> int32) = _.Seconds
            let v1230 : int32 = v1229 v1213
            let v1234 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1235 : int32 = v1234 v1213
            let v1258 : System.DateTime = System.DateTime (1, 1, 1, v1220, v1225, v1230, v1235)
            v1258
    let v1285 : string = method14()
    let v1297 : bool = v1285 = ""
    let v1299 : string =
        if v1297 then
            let v1298 : string = "M-d-y hh:mm:ss tt"
            v1298
        else
            v1285
    let v1300 : (string -> string) = v1284.ToString
    let v1301 : string = v1300 v1299
    let _run_target_args'_v216 = v1301 
    #endif
#else
    let v1318 : (int64 -> US2) = method12()
    let v1319 : US2 option = v5 |> Option.map v1318 
    let v1339 : US2 = US2_1
    let v1340 : US2 = v1319 |> Option.defaultValue v1339 
    let v1494 : System.DateTime =
        match v1340 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1477 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1478 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1478 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1479 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1479 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1481 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1477 = v1481 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1484 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1484 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1485 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1485 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1486 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1486 
            #endif
#else
            let v1487 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1477 = v1487 
            #endif
            let v1488 : System.DateTime = _run_target_args'_v1477 
            v1488
        | US2_0(v1344) -> (* Some *)
            (* run_target_args'
            let v1351 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1352 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1352 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1353 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1353 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1355 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1351 = v1355 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1358 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1358 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1359 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1359 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1360 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1360 
            #endif
#else
            let v1361 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1351 = v1361 
            #endif
            let v1362 : System.DateTime = _run_target_args'_v1351 
            (* run_target_args'
            let v1373 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1374 : (System.DateTime -> int64) = _.Ticks
            let v1375 : int64 = v1374 v1362
            let _run_target_args'_v1373 = v1375 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1376 : (System.DateTime -> int64) = _.Ticks
            let v1377 : int64 = v1376 v1362
            let _run_target_args'_v1373 = v1377 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1379 : int64 = null |> unbox<int64>
            let _run_target_args'_v1373 = v1379 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1382 : (System.DateTime -> int64) = _.Ticks
            let v1383 : int64 = v1382 v1362
            let _run_target_args'_v1373 = v1383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1384 : (System.DateTime -> int64) = _.Ticks
            let v1385 : int64 = v1384 v1362
            let _run_target_args'_v1373 = v1385 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1386 : (System.DateTime -> int64) = _.Ticks
            let v1387 : int64 = v1386 v1362
            let _run_target_args'_v1373 = v1387 
            #endif
#else
            let v1388 : (System.DateTime -> int64) = _.Ticks
            let v1389 : int64 = v1388 v1362
            let _run_target_args'_v1373 = v1389 
            #endif
            let v1390 : int64 = _run_target_args'_v1373 
            let v1412 : int64 = v1390 |> int64 
            let v1417 : int64 = v1412 - v1344
            let v1423 : System.TimeSpan = v1417 |> System.TimeSpan 
            let v1429 : (System.TimeSpan -> int32) = _.Hours
            let v1430 : int32 = v1429 v1423
            let v1434 : (System.TimeSpan -> int32) = _.Minutes
            let v1435 : int32 = v1434 v1423
            let v1439 : (System.TimeSpan -> int32) = _.Seconds
            let v1440 : int32 = v1439 v1423
            let v1444 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1445 : int32 = v1444 v1423
            let v1468 : System.DateTime = System.DateTime (1, 1, 1, v1430, v1435, v1440, v1445)
            v1468
    let v1495 : string = method14()
    let v1507 : bool = v1495 = ""
    let v1509 : string =
        if v1507 then
            let v1508 : string = "M-d-y hh:mm:ss tt"
            v1508
        else
            v1495
    let v1510 : (string -> string) = v1494.ToString
    let v1511 : string = v1510 v1509
    let _run_target_args'_v216 = v1511 
    #endif
    let v1526 : string = _run_target_args'_v216 
    v1526
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
and method15 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_blue"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_bright_blue"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_bright_blue"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[94m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[94m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[94m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[94m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Debug"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method16(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method18 (v0 : string) : string =
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
and method20 (v0 : string, v1 : string) : string =
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
and method21 (v0 : string) : string =
    let v1 : char list = []
    let v8 : (char list -> (char [])) = List.toArray
    let v9 : (char []) = v8 v1
    let v12 : string = v0.TrimStart v9 
    let v46 : char list = []
    let v48 : char list = '/' :: v46 
    let v52 : char list = ' ' :: v48 
    let v61 : (char list -> (char [])) = List.toArray
    let v62 : (char []) = v61 v52
    let v65 : string = v12.TrimEnd v62 
    v65
and method19 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method20(v8, v9)
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
    method21(v54)
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
            let v164 : string = method18(v0)
            let v165 : string = method19(v105, v106, v107, v108, v109, v110, v123, v124, v155, v164)
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
and method26 (v0 : string, v1 : int64, v2 : string) : string =
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
and method25 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : int64, v10 : string) : string =
    let v11 : string = method26(v8, v9, v10)
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
    method21(v55)
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
            let v126 : string = method18(v0)
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
            let v166 : string = method25(v106, v107, v108, v109, v110, v111, v124, v125, v126, v1, v157)
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
and method24 (v0 : US7, v1 : string, v2 : int64, v3 : US9, v4 : US8) : Async<int64> =
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
                let v32727 : Async<int64> = method23(v0, v1, v32726)
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
                let v97235 : Async<int64> = method23(v0, v1, v97234)
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
                let v161743 : Async<int64> = method23(v0, v1, v161742)
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
                let v226251 : Async<int64> = method23(v0, v1, v226250)
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
and method23 (v0 : US7, v1 : string, v2 : int64) : Async<int64> =
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
    let v40 : Async<int64> = method24(v0, v1, v2, v39, v38)
    let _run_target_args'_v7 = v40 
    #endif
    let v41 : Async<int64> = _run_target_args'_v7 
    v41
and method22 (v0 : US7, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method23(v0, v1, v2)
and closure11 (v0 : US7) (v1 : string) : Async<int64> =
    method22(v0, v1)
and closure10 () (v0 : US7) : (string -> Async<int64>) =
    closure11(v0)
and method27 (v0 : string) : Async<int64> =
    let v1 : US8 = US8_0
    let v2 : US9 = US9_1
    let v3 : US7 = US7_0(v1, v2)
    method22(v3, v0)
and closure13 () (v0 : string) : Async<int64> =
    method27(v0)
and method31 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_black"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_bright_black"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_bright_black"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[90m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[90m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[90m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[90m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Verbose"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method16(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method33 (v0 : int64, v1 : string, v2 : exn) : string =
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
and method32 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string, v10 : exn) : string =
    let v11 : string = method33(v8, v9, v10)
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
    method21(v55)
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
            let v125 : string = method31()
            let v126 : string = method32(v106, v107, v108, v109, v110, v111, v124, v125, v1, v0, v2)
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
                        method29(v0, v30154)
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
                        method29(v0, v89559)
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
                        method29(v0, v148964)
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
                        method29(v0, v208369)
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
and method29 (v0 : string, v1 : int64) : Async<string> =
    method30(v0, v1)
and method28 (v0 : string) : Async<string> =
    let v1 : int64 = 0L
    method29(v0, v1)
and closure14 () (v0 : string) : Async<string> =
    method28(v0)
and method35 (v0 : string) : bool =
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
and method36 (v0 : Vec<uint8>) : Vec<uint8> =
    v0
and method34 (v0 : string, v1 : string) : bool =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : bool = method35(v0)
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
            let v68 : Vec<uint8> = method36(v59)
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
    method34(v0, v1)
and closure16 () (v0 : string) : (string -> bool) =
    closure17(v0)
and method37 (v0 : string, v1 : string) : Async<unit> =
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
    method37(v0, v1)
and closure18 () (v0 : string) : (string -> Async<unit>) =
    closure19(v0)
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
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let v88 : bool = method35(v0)
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
            let v228 : bool = method35(v0)
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
            let v368 : bool = method35(v0)
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
            let v508 : bool = method35(v0)
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
    let v31 : Async<bool> = method41(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<bool> = _run_target_args'_v6 
    v32
and method39 (v0 : string, v1 : string) : Async<unit> =
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
            let v75 : Async<bool> = method40(v0, v1)
            let! v75 = v75 
            let v76 : bool = v75 
            let v77 : bool = v76 = false
            if v77 then
                let v78 : Async<unit> = method37(v0, v1)
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
            let v188 : Async<bool> = method40(v0, v1)
            let! v188 = v188 
            let v189 : bool = v188 
            let v190 : bool = v189 = false
            if v190 then
                let v191 : Async<unit> = method37(v0, v1)
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
            let v301 : Async<bool> = method40(v0, v1)
            let! v301 = v301 
            let v302 : bool = v301 
            let v303 : bool = v302 = false
            if v303 then
                let v304 : Async<unit> = method37(v0, v1)
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
            let v414 : Async<bool> = method40(v0, v1)
            let! v414 = v414 
            let v415 : bool = v414 
            let v416 : bool = v415 = false
            if v416 then
                let v417 : Async<unit> = method37(v0, v1)
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
and method38 (v0 : string, v1 : string) : Async<unit> =
    method39(v0, v1)
and closure21 (v0 : string) (v1 : string) : Async<unit> =
    method38(v0, v1)
and closure20 () (v0 : string) : (string -> Async<unit>) =
    closure21(v0)
and method46 (v0 : std_io_Error) : string =
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
    method46(v0)
and method45 () : (std_io_Error -> string) =
    closure23()
and closure24 () () : US10 =
    US10_0
and method47 () : (unit -> US10) =
    closure24()
and closure25 () (v0 : string) : US10 =
    US10_1(v0)
and method48 () : (string -> US10) =
    closure25()
and method49 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_bright_red"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_bright_red"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_bright_red"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[91m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[91m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[91m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[91m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Critical"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method16(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method51 (v0 : string) : string =
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
and method50 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method51(v8)
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
    method21(v53)
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
            let v123 : string = method49()
            let v124 : string = method50(v104, v105, v106, v107, v108, v109, v122, v123, v0)
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
and method52 () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "inline_colorization::color_yellow"
    let v3 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v2 
    (* run_target_args'
    let v8 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v9 : string = "String::from($0)"
    let v10 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v9 
    let _run_target_args'_v8 = v10 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = "String::from($0)"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v11 
    let _run_target_args'_v8 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v13 : string = "String::from($0)"
    let v14 : std_string_String = Fable.Core.RustInterop.emitRustExpr v3 v13 
    let _run_target_args'_v8 = v14 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v16 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v16 
    #endif
#if FABLE_COMPILER_PYTHON
    let v20 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v20 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v24 
    #endif
#else
    let v28 : std_string_String = v3 |> unbox<std_string_String>
    let _run_target_args'_v8 = v28 
    #endif
    let v31 : std_string_String = _run_target_args'_v8 
    let v40 : string = "fable_library_rust::String_::fromString($0)"
    let v41 : string = Fable.Core.RustInterop.emitRustExpr v31 v40 
    let _run_target_args'_v1 = v41 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v42 : string = "inline_colorization::color_yellow"
    let v43 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v42 
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = "String::from($0)"
    let v50 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v49 
    let _run_target_args'_v48 = v50 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v51 : string = "String::from($0)"
    let v52 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v51 
    let _run_target_args'_v48 = v52 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v53 : string = "String::from($0)"
    let v54 : std_string_String = Fable.Core.RustInterop.emitRustExpr v43 v53 
    let _run_target_args'_v48 = v54 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v56 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v56 
    #endif
#if FABLE_COMPILER_PYTHON
    let v60 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v64 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v64 
    #endif
#else
    let v68 : std_string_String = v43 |> unbox<std_string_String>
    let _run_target_args'_v48 = v68 
    #endif
    let v71 : std_string_String = _run_target_args'_v48 
    let v80 : string = "fable_library_rust::String_::fromString($0)"
    let v81 : string = Fable.Core.RustInterop.emitRustExpr v71 v80 
    let _run_target_args'_v1 = v81 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string = "inline_colorization::color_yellow"
    let v83 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v82 
    (* run_target_args'
    let v88 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v89 : string = "String::from($0)"
    let v90 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v89 
    let _run_target_args'_v88 = v90 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v91 : string = "String::from($0)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v91 
    let _run_target_args'_v88 = v92 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v93 : string = "String::from($0)"
    let v94 : std_string_String = Fable.Core.RustInterop.emitRustExpr v83 v93 
    let _run_target_args'_v88 = v94 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v96 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v96 
    #endif
#if FABLE_COMPILER_PYTHON
    let v100 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v104 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v104 
    #endif
#else
    let v108 : std_string_String = v83 |> unbox<std_string_String>
    let _run_target_args'_v88 = v108 
    #endif
    let v111 : std_string_String = _run_target_args'_v88 
    let v120 : string = "fable_library_rust::String_::fromString($0)"
    let v121 : string = Fable.Core.RustInterop.emitRustExpr v111 v120 
    let _run_target_args'_v1 = v121 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v122 : string = "\u001b[93m"
    let _run_target_args'_v1 = v122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v123 : string = "\u001b[93m"
    let _run_target_args'_v1 = v123 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v124 : string = "\u001b[93m"
    let _run_target_args'_v1 = v124 
    #endif
#else
    let v125 : string = "\u001b[93m"
    let _run_target_args'_v1 = v125 
    #endif
    let v126 : string = _run_target_args'_v1 
    
    
    
    
    
    let v131 : string = "Warning"
    let v132 : (unit -> string) = v131.ToLower
    let v133 : string = v132 ()
    let v136 : char = v133.[int 0]
    let v137 : string = method16(v136)
    let v139 : string = v126 + v137 
    (* run_target_args'
    let v143 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v144 : string = "inline_colorization::color_reset"
    let v145 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v144 
    (* run_target_args'
    let v150 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v151 : string = "String::from($0)"
    let v152 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v151 
    let _run_target_args'_v150 = v152 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v153 : string = "String::from($0)"
    let v154 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v153 
    let _run_target_args'_v150 = v154 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v155 : string = "String::from($0)"
    let v156 : std_string_String = Fable.Core.RustInterop.emitRustExpr v145 v155 
    let _run_target_args'_v150 = v156 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v158 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v158 
    #endif
#if FABLE_COMPILER_PYTHON
    let v162 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v162 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v166 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v166 
    #endif
#else
    let v170 : std_string_String = v145 |> unbox<std_string_String>
    let _run_target_args'_v150 = v170 
    #endif
    let v173 : std_string_String = _run_target_args'_v150 
    let v182 : string = "fable_library_rust::String_::fromString($0)"
    let v183 : string = Fable.Core.RustInterop.emitRustExpr v173 v182 
    let _run_target_args'_v143 = v183 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v184 : string = "inline_colorization::color_reset"
    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v184 
    (* run_target_args'
    let v190 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v191 : string = "String::from($0)"
    let v192 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v191 
    let _run_target_args'_v190 = v192 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v193 : string = "String::from($0)"
    let v194 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v193 
    let _run_target_args'_v190 = v194 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v195 : string = "String::from($0)"
    let v196 : std_string_String = Fable.Core.RustInterop.emitRustExpr v185 v195 
    let _run_target_args'_v190 = v196 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v198 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v198 
    #endif
#if FABLE_COMPILER_PYTHON
    let v202 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v202 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v206 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v206 
    #endif
#else
    let v210 : std_string_String = v185 |> unbox<std_string_String>
    let _run_target_args'_v190 = v210 
    #endif
    let v213 : std_string_String = _run_target_args'_v190 
    let v222 : string = "fable_library_rust::String_::fromString($0)"
    let v223 : string = Fable.Core.RustInterop.emitRustExpr v213 v222 
    let _run_target_args'_v143 = v223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v224 : string = "inline_colorization::color_reset"
    let v225 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v224 
    (* run_target_args'
    let v230 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v231 : string = "String::from($0)"
    let v232 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v231 
    let _run_target_args'_v230 = v232 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v233 : string = "String::from($0)"
    let v234 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v233 
    let _run_target_args'_v230 = v234 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v235 : string = "String::from($0)"
    let v236 : std_string_String = Fable.Core.RustInterop.emitRustExpr v225 v235 
    let _run_target_args'_v230 = v236 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v238 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v238 
    #endif
#if FABLE_COMPILER_PYTHON
    let v242 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v242 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v246 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v246 
    #endif
#else
    let v250 : std_string_String = v225 |> unbox<std_string_String>
    let _run_target_args'_v230 = v250 
    #endif
    let v253 : std_string_String = _run_target_args'_v230 
    let v262 : string = "fable_library_rust::String_::fromString($0)"
    let v263 : string = Fable.Core.RustInterop.emitRustExpr v253 v262 
    let _run_target_args'_v143 = v263 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v264 : string = "\u001b[0m"
    let _run_target_args'_v143 = v264 
    #endif
#if FABLE_COMPILER_PYTHON
    let v265 : string = "\u001b[0m"
    let _run_target_args'_v143 = v265 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v266 : string = "\u001b[0m"
    let _run_target_args'_v143 = v266 
    #endif
#else
    let v267 : string = "\u001b[0m"
    let _run_target_args'_v143 = v267 
    #endif
    let v268 : string = _run_target_args'_v143 
    let v272 : string = v139 + v268 
    v272
and method54 (v0 : string, v1 : string) : string =
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
and method53 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method54(v8, v9)
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
    method21(v54)
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
            let v124 : string = method52()
            let v125 : string = method18(v0)
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
            let v165 : string = method53(v105, v106, v107, v108, v109, v110, v123, v124, v125, v156)
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
                let v54982 : (std_io_Error -> string) = method45()
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
                let v54998 : (unit -> US10) = method47()
                let v54999 : (string -> US10) = method48()
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
                let v57758 : Async<int64> = method43(v0, v57757)
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
                let v167766 : (std_io_Error -> string) = method45()
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
                let v167782 : (unit -> US10) = method47()
                let v167783 : (string -> US10) = method48()
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
                let v170542 : Async<int64> = method43(v0, v170541)
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
                let v280550 : (std_io_Error -> string) = method45()
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
                let v280566 : (unit -> US10) = method47()
                let v280567 : (string -> US10) = method48()
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
                let v283326 : Async<int64> = method43(v0, v283325)
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
                let v393334 : (std_io_Error -> string) = method45()
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
                let v393350 : (unit -> US10) = method47()
                let v393351 : (string -> US10) = method48()
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
                let v396110 : Async<int64> = method43(v0, v396109)
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
    let v31 : Async<int64> = method44(v0, v1)
    let _run_target_args'_v6 = v31 
    #endif
    let v32 : Async<int64> = _run_target_args'_v6 
    v32
and method42 (v0 : string) : Async<int64> =
    let v1 : int64 = 0L
    method43(v0, v1)
and closure22 () (v0 : string) : Async<int64> =
    method42(v0)
and method58 (v0 : string, v1 : string) : unit =
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
and method60 (v0 : string, v1 : string, v2 : string) : string =
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
and method59 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string, v10 : string) : string =
    let v11 : string = method60(v8, v9, v10)
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
    method21(v55)
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
            let v125 : string = method52()
            let v126 : string = method18(v1)
            let v127 : string = method18(v0)
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
            let v167 : string = method59(v106, v107, v108, v109, v110, v111, v124, v125, v126, v127, v158)
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
    let v21 : unit = ()
    let _let'_v21 =
        async {
            try
                method58(v0, v1)
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
                let v30279 : Async<int64> = method56(v0, v1, v30278)
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
                method58(v0, v1)
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
                let v90062 : Async<int64> = method56(v0, v1, v90061)
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
                method58(v0, v1)
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
                let v149845 : Async<int64> = method56(v0, v1, v149844)
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
                method58(v0, v1)
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
                let v209628 : Async<int64> = method56(v0, v1, v209627)
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
and method56 (v0 : string, v1 : string, v2 : int64) : Async<int64> =
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
    let v32 : Async<int64> = method57(v0, v1, v2)
    let _run_target_args'_v7 = v32 
    #endif
    let v33 : Async<int64> = _run_target_args'_v7 
    v33
and method55 (v0 : string, v1 : string) : Async<int64> =
    let v2 : int64 = 0L
    method56(v0, v1, v2)
and closure29 (v0 : string) (v1 : string) : Async<int64> =
    method55(v0, v1)
and closure28 () (v0 : string) : (string -> Async<int64>) =
    closure29(v0)
and closure33 () (v0 : int64) : US11 =
    US11_0(v0)
and method66 () : (int64 -> US11) =
    closure33()
and closure34 () (v0 : exn) : US11 =
    US11_1(v0)
and method67 () : (exn -> US11) =
    closure34()
and closure32 () (v0 : Choice<int64, exn>) : US11 =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : US11 = null |> unbox<US11>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : US11 = null |> unbox<US11>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : US11 = null |> unbox<US11>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : US11 = null |> unbox<US11>
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : US11 = null |> unbox<US11>
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v26 : (int64 -> US11) = method66()
    let v27 : (exn -> US11) = method67()
    let v28 : US11 = match v0 with Choice1Of2 x -> v26 x | Choice2Of2 x -> v27 x
    let _run_target_args'_v5 = v28 
    #endif
#else
    let v29 : (int64 -> US11) = method66()
    let v30 : (exn -> US11) = method67()
    let v31 : US11 = match v0 with Choice1Of2 x -> v29 x | Choice2Of2 x -> v30 x
    let _run_target_args'_v5 = v31 
    #endif
    let v32 : US11 = _run_target_args'_v5 
    v32
and method69 (v0 : (Choice<int64, exn> -> US11), v1 : Async<Choice<int64, exn>>) : Async<US11> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US11> = null |> unbox<Async<US11>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v49 : Choice<int64, exn> = v1 
            let v50 : US11 = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<US11> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : Choice<int64, exn> = v1 
            let v109 : US11 = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<US11> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : Choice<int64, exn> = v1 
            let v168 : US11 = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<US11> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : Choice<int64, exn> = v1 
            let v227 : US11 = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<US11> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<US11> = _run_target_args'_v6 
    v255
and method68 (v0 : (Choice<int64, exn> -> US11), v1 : Async<Choice<int64, exn>>) : Async<US11> =
    method69(v0, v1)
and closure35 () (v0 : US11) : US12 =
    match v0 with
    | US11_0(v1) -> (* C1of2 *)
        US12_0(v1)
    | US11_1(v3) -> (* C2of2 *)
        US12_1(v3)
and method71 (v0 : (US11 -> US12), v1 : Async<US11>) : Async<US12> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : Async<US12> = null |> unbox<Async<US12>>
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v12 : Async<US12> = null |> unbox<Async<US12>>
    let _run_target_args'_v6 = v12 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v16 : Async<US12> = null |> unbox<Async<US12>>
    let _run_target_args'_v6 = v16 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v20 : unit = ()
    let _let'_v20 =
        async {
            let! v1 = v1 
            let v49 : US11 = v1 
            let v50 : US12 = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<US12> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : US11 = v1 
            let v109 : US12 = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<US12> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : US11 = v1 
            let v168 : US12 = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<US12> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : US11 = v1 
            let v227 : US12 = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<US12> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<US12> = _run_target_args'_v6 
    v255
and method70 (v0 : (US11 -> US12), v1 : Async<US11>) : Async<US12> =
    method71(v0, v1)
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
    method21(v53)
and closure37 (v0 : int32) () : unit =
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
            let v123 : string = method31()
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
    method21(v54)
and closure38 (v0 : int32, v1 : exn) () : unit =
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
            let v124 : string = method49()
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
and closure36 (v0 : int32) (v1 : US12) : US2 =
    match v1 with
    | US12_1(v4) -> (* Error *)
        let v6 : string = $"%A{v4}"
        let v11 : string = "System.TimeoutException"
        let v12 : bool = v6.Contains v11 
        if v12 then
            let v326 : unit = ()
            let v327 : (unit -> unit) = closure37(v0)
            let v328 : unit = (fun () -> v327 (); v326) ()
            US2_1
        else
            let v994 : unit = ()
            let v995 : (unit -> unit) = closure38(v0, v4)
            let v996 : unit = (fun () -> v995 (); v994) ()
            US2_1
    | US12_0(v2) -> (* Ok *)
        US2_0(v2)
and method77 (v0 : (US12 -> US2), v1 : Async<US12>) : Async<US2> =
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
            let v49 : US12 = v1 
            let v50 : US2 = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : US12 = v1 
            let v109 : US2 = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<US2> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : US12 = v1 
            let v168 : US2 = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<US2> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : US12 = v1 
            let v227 : US2 = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<US2> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<US2> = _run_target_args'_v6 
    v255
and method76 (v0 : (US12 -> US2), v1 : Async<US12>) : Async<US2> =
    method77(v0, v1)
and method65 (v0 : Async<int64>, v1 : int32) : Async<US2> =
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
            let v950 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v952 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v950 = v952 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v956 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v950 = v956 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v960 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v950 = v960 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v963 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v963 
            #endif
#if FABLE_COMPILER_PYTHON
            let v964 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v964 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v965 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v965 
            #endif
#else
            let v966 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v950 = v966 
            #endif
            let v967 : Async<Async<int64>> = _run_target_args'_v950 
            let! v967 = v967 
            let v976 : Async<int64> = v967 
            (* run_target_args'
            let v981 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v983 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v981 = v983 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v987 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v981 = v987 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v991 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v981 = v991 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v994 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v995 : Async<Choice<int64, exn>> = v994 v976
            let _run_target_args'_v981 = v995 
            #endif
#if FABLE_COMPILER_PYTHON
            let v996 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v997 : Async<Choice<int64, exn>> = v996 v976
            let _run_target_args'_v981 = v997 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v998 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v999 : Async<Choice<int64, exn>> = v998 v976
            let _run_target_args'_v981 = v999 
            #endif
#else
            let v1000 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v1001 : Async<Choice<int64, exn>> = v1000 v976
            let _run_target_args'_v981 = v1001 
            #endif
            let v1002 : Async<Choice<int64, exn>> = _run_target_args'_v981 
            let v1011 : (Choice<int64, exn> -> US11) = closure32()
            let v1012 : Async<US11> = method68(v1011, v1002)
            let v1013 : (US11 -> US12) = closure35()
            let v1014 : Async<US12> = method70(v1013, v1012)
            let v1015 : (US12 -> US2) = closure36(v1)
            let v1016 : Async<US2> = method76(v1015, v1014)
            return! v1016 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1940 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v1940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1942 : unit = ()
    let _let'_v1942 =
        async {
            (* run_target_args'
            let v2872 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2874 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2872 = v2874 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2878 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2872 = v2878 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2882 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2872 = v2882 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2885 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2885 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2886 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2886 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2887 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2887 
            #endif
#else
            let v2888 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2872 = v2888 
            #endif
            let v2889 : Async<Async<int64>> = _run_target_args'_v2872 
            let! v2889 = v2889 
            let v2898 : Async<int64> = v2889 
            (* run_target_args'
            let v2903 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2905 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2903 = v2905 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2909 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2903 = v2909 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2913 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2903 = v2913 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2916 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2917 : Async<Choice<int64, exn>> = v2916 v2898
            let _run_target_args'_v2903 = v2917 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2918 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2919 : Async<Choice<int64, exn>> = v2918 v2898
            let _run_target_args'_v2903 = v2919 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2920 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2921 : Async<Choice<int64, exn>> = v2920 v2898
            let _run_target_args'_v2903 = v2921 
            #endif
#else
            let v2922 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2923 : Async<Choice<int64, exn>> = v2922 v2898
            let _run_target_args'_v2903 = v2923 
            #endif
            let v2924 : Async<Choice<int64, exn>> = _run_target_args'_v2903 
            let v2933 : (Choice<int64, exn> -> US11) = closure32()
            let v2934 : Async<US11> = method68(v2933, v2924)
            let v2935 : (US11 -> US12) = closure35()
            let v2936 : Async<US12> = method70(v2935, v2934)
            let v2937 : (US12 -> US2) = closure36(v1)
            let v2938 : Async<US2> = method76(v2937, v2936)
            return! v2938 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3862 : Async<US2> = _let'_v1942 
    let _run_target_args'_v6 = v3862 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3864 : unit = ()
    let _let'_v3864 =
        async {
            (* run_target_args'
            let v4794 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4796 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4794 = v4796 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4800 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4794 = v4800 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4804 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4794 = v4804 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4807 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4807 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4808 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4808 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4809 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4809 
            #endif
#else
            let v4810 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4794 = v4810 
            #endif
            let v4811 : Async<Async<int64>> = _run_target_args'_v4794 
            let! v4811 = v4811 
            let v4820 : Async<int64> = v4811 
            (* run_target_args'
            let v4825 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4827 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4825 = v4827 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4831 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4825 = v4831 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4835 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4825 = v4835 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4838 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4839 : Async<Choice<int64, exn>> = v4838 v4820
            let _run_target_args'_v4825 = v4839 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4840 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4841 : Async<Choice<int64, exn>> = v4840 v4820
            let _run_target_args'_v4825 = v4841 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4842 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4843 : Async<Choice<int64, exn>> = v4842 v4820
            let _run_target_args'_v4825 = v4843 
            #endif
#else
            let v4844 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4845 : Async<Choice<int64, exn>> = v4844 v4820
            let _run_target_args'_v4825 = v4845 
            #endif
            let v4846 : Async<Choice<int64, exn>> = _run_target_args'_v4825 
            let v4855 : (Choice<int64, exn> -> US11) = closure32()
            let v4856 : Async<US11> = method68(v4855, v4846)
            let v4857 : (US11 -> US12) = closure35()
            let v4858 : Async<US12> = method70(v4857, v4856)
            let v4859 : (US12 -> US2) = closure36(v1)
            let v4860 : Async<US2> = method76(v4859, v4858)
            return! v4860 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5784 : Async<US2> = _let'_v3864 
    let _run_target_args'_v6 = v5784 
    #endif
#else
    let v5786 : unit = ()
    let _let'_v5786 =
        async {
            (* run_target_args'
            let v6716 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6718 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v6716 = v6718 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6722 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v6716 = v6722 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6726 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v6716 = v6726 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6729 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6729 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6730 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6730 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6731 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6731 
            #endif
#else
            let v6732 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v6716 = v6732 
            #endif
            let v6733 : Async<Async<int64>> = _run_target_args'_v6716 
            let! v6733 = v6733 
            let v6742 : Async<int64> = v6733 
            (* run_target_args'
            let v6747 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v6749 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v6747 = v6749 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v6753 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v6747 = v6753 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v6757 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v6747 = v6757 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v6760 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6761 : Async<Choice<int64, exn>> = v6760 v6742
            let _run_target_args'_v6747 = v6761 
            #endif
#if FABLE_COMPILER_PYTHON
            let v6762 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6763 : Async<Choice<int64, exn>> = v6762 v6742
            let _run_target_args'_v6747 = v6763 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v6764 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6765 : Async<Choice<int64, exn>> = v6764 v6742
            let _run_target_args'_v6747 = v6765 
            #endif
#else
            let v6766 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v6767 : Async<Choice<int64, exn>> = v6766 v6742
            let _run_target_args'_v6747 = v6767 
            #endif
            let v6768 : Async<Choice<int64, exn>> = _run_target_args'_v6747 
            let v6777 : (Choice<int64, exn> -> US11) = closure32()
            let v6778 : Async<US11> = method68(v6777, v6768)
            let v6779 : (US11 -> US12) = closure35()
            let v6780 : Async<US12> = method70(v6779, v6778)
            let v6781 : (US12 -> US2) = closure36(v1)
            let v6782 : Async<US2> = method76(v6781, v6780)
            return! v6782 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v7706 : Async<US2> = _let'_v5786 
    let _run_target_args'_v6 = v7706 
    #endif
    let v7707 : Async<US2> = _run_target_args'_v6 
    v7707
and method64 (v0 : int32, v1 : Async<int64>) : Async<US2> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v8 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v9 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v10 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v10 
    #endif
#if FABLE_COMPILER_PYTHON
    let v11 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v11 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v12 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v12 
    #endif
#else
    let v13 : Async<US2> = method65(v1, v0)
    let _run_target_args'_v6 = v13 
    #endif
    let v14 : Async<US2> = _run_target_args'_v6 
    v14
and closure39 () (v0 : string) : string option =
    let v2 : string option = Some v0 
    v2
and method79 (v0 : (string -> string option), v1 : Async<string>) : Async<string option> =
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
            let! v1 = v1 
            let v49 : string = v1 
            let v50 : string option = v0 v49
            return v50 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v77 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v77 
    #endif
#if FABLE_COMPILER_PYTHON
    let v79 : unit = ()
    let _let'_v79 =
        async {
            let! v1 = v1 
            let v108 : string = v1 
            let v109 : string option = v0 v108
            return v109 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v136 : Async<string option> = _let'_v79 
    let _run_target_args'_v6 = v136 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v138 : unit = ()
    let _let'_v138 =
        async {
            let! v1 = v1 
            let v167 : string = v1 
            let v168 : string option = v0 v167
            return v168 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v195 : Async<string option> = _let'_v138 
    let _run_target_args'_v6 = v195 
    #endif
#else
    let v197 : unit = ()
    let _let'_v197 =
        async {
            let! v1 = v1 
            let v226 : string = v1 
            let v227 : string option = v0 v226
            return v227 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v254 : Async<string option> = _let'_v197 
    let _run_target_args'_v6 = v254 
    #endif
    let v255 : Async<string option> = _run_target_args'_v6 
    v255
and method78 (v0 : (string -> string option), v1 : Async<string>) : Async<string option> =
    method79(v0, v1)
and method81 (v0 : int64, v1 : string) : string =
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
and method80 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : int64, v9 : string) : string =
    let v10 : string = method81(v8, v9)
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
    method21(v54)
and closure40 (v0 : int64, v1 : exn) () : unit =
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
            let v164 : string = method80(v105, v106, v107, v108, v109, v110, v123, v124, v0, v155)
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
and method63 (v0 : string, v1 : int64) : Async<string option> =
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
                let v29522 : bool = v1 > 0L
                if v29522 then
                    let v29523 : Async<int64> = method27(v0)
                    let v29524 : int32 = 1000
                    let v29525 : Async<US2> = method64(v29524, v29523)
                    (* run_target_args'
                    let v29530 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v29532 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29530 = v29532 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v29536 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29530 = v29536 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v29540 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29530 = v29540 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v29543 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29544 : Async<unit> = v29543 v29525
                    let _run_target_args'_v29530 = v29544 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v29545 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29546 : Async<unit> = v29545 v29525
                    let _run_target_args'_v29530 = v29546 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v29547 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29548 : Async<unit> = v29547 v29525
                    let _run_target_args'_v29530 = v29548 
                    #endif
#else
                    let v29549 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29550 : Async<unit> = v29549 v29525
                    let _run_target_args'_v29530 = v29550 
                    #endif
                    let v29551 : Async<unit> = _run_target_args'_v29530 
                    do! v29551 
                    ()
                let v29560 : Async<string> = method28(v0)
                let v29561 : (string -> string option) = closure39()
                let v29562 : Async<string option> = method78(v29561, v29560)
                return! v29562 
                (* indent
                ()
            indent *)
            with ex ->
                let v30313 : exn = ex
                let v30314 : bool = v1 = 0L
                let v30315 : bool = v30314 <> true
                if v30315 then
                    let v30666 : unit = ()
                    let v30667 : (unit -> unit) = closure40(v1, v30313)
                    let v30668 : unit = (fun () -> v30667 (); v30666) ()
                    let v31023 : string option = None
                    return v31023 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v31026 : int64 = v1 + 1L
                    let v31027 : Async<string option> = method62(v0, v31026)
                    return! v31027 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v31744 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v61205 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v61205 
    #endif
#if FABLE_COMPILER_PYTHON
    let v61207 : unit = ()
    let _let'_v61207 =
        async {
            try
                let v90709 : bool = v1 > 0L
                if v90709 then
                    let v90710 : Async<int64> = method27(v0)
                    let v90711 : int32 = 1000
                    let v90712 : Async<US2> = method64(v90711, v90710)
                    (* run_target_args'
                    let v90717 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v90719 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v90717 = v90719 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v90723 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v90717 = v90723 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v90727 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v90717 = v90727 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v90730 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90731 : Async<unit> = v90730 v90712
                    let _run_target_args'_v90717 = v90731 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v90732 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90733 : Async<unit> = v90732 v90712
                    let _run_target_args'_v90717 = v90733 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v90734 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90735 : Async<unit> = v90734 v90712
                    let _run_target_args'_v90717 = v90735 
                    #endif
#else
                    let v90736 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v90737 : Async<unit> = v90736 v90712
                    let _run_target_args'_v90717 = v90737 
                    #endif
                    let v90738 : Async<unit> = _run_target_args'_v90717 
                    do! v90738 
                    ()
                let v90747 : Async<string> = method28(v0)
                let v90748 : (string -> string option) = closure39()
                let v90749 : Async<string option> = method78(v90748, v90747)
                return! v90749 
                (* indent
                ()
            indent *)
            with ex ->
                let v91500 : exn = ex
                let v91501 : bool = v1 = 0L
                let v91502 : bool = v91501 <> true
                if v91502 then
                    let v91853 : unit = ()
                    let v91854 : (unit -> unit) = closure40(v1, v91500)
                    let v91855 : unit = (fun () -> v91854 (); v91853) ()
                    let v92210 : string option = None
                    return v92210 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v92213 : int64 = v1 + 1L
                    let v92214 : Async<string option> = method62(v0, v92213)
                    return! v92214 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v92931 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v122392 : Async<string option> = _let'_v61207 
    let _run_target_args'_v6 = v122392 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v122394 : unit = ()
    let _let'_v122394 =
        async {
            try
                let v151896 : bool = v1 > 0L
                if v151896 then
                    let v151897 : Async<int64> = method27(v0)
                    let v151898 : int32 = 1000
                    let v151899 : Async<US2> = method64(v151898, v151897)
                    (* run_target_args'
                    let v151904 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v151906 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v151904 = v151906 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v151910 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v151904 = v151910 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v151914 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v151904 = v151914 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v151917 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151918 : Async<unit> = v151917 v151899
                    let _run_target_args'_v151904 = v151918 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v151919 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151920 : Async<unit> = v151919 v151899
                    let _run_target_args'_v151904 = v151920 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v151921 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151922 : Async<unit> = v151921 v151899
                    let _run_target_args'_v151904 = v151922 
                    #endif
#else
                    let v151923 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v151924 : Async<unit> = v151923 v151899
                    let _run_target_args'_v151904 = v151924 
                    #endif
                    let v151925 : Async<unit> = _run_target_args'_v151904 
                    do! v151925 
                    ()
                let v151934 : Async<string> = method28(v0)
                let v151935 : (string -> string option) = closure39()
                let v151936 : Async<string option> = method78(v151935, v151934)
                return! v151936 
                (* indent
                ()
            indent *)
            with ex ->
                let v152687 : exn = ex
                let v152688 : bool = v1 = 0L
                let v152689 : bool = v152688 <> true
                if v152689 then
                    let v153040 : unit = ()
                    let v153041 : (unit -> unit) = closure40(v1, v152687)
                    let v153042 : unit = (fun () -> v153041 (); v153040) ()
                    let v153397 : string option = None
                    return v153397 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v153400 : int64 = v1 + 1L
                    let v153401 : Async<string option> = method62(v0, v153400)
                    return! v153401 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v154118 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v183579 : Async<string option> = _let'_v122394 
    let _run_target_args'_v6 = v183579 
    #endif
#else
    let v183581 : unit = ()
    let _let'_v183581 =
        async {
            try
                let v213083 : bool = v1 > 0L
                if v213083 then
                    let v213084 : Async<int64> = method27(v0)
                    let v213085 : int32 = 1000
                    let v213086 : Async<US2> = method64(v213085, v213084)
                    (* run_target_args'
                    let v213091 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v213093 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v213091 = v213093 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v213097 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v213091 = v213097 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v213101 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v213091 = v213101 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v213104 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v213105 : Async<unit> = v213104 v213086
                    let _run_target_args'_v213091 = v213105 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v213106 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v213107 : Async<unit> = v213106 v213086
                    let _run_target_args'_v213091 = v213107 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v213108 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v213109 : Async<unit> = v213108 v213086
                    let _run_target_args'_v213091 = v213109 
                    #endif
#else
                    let v213110 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v213111 : Async<unit> = v213110 v213086
                    let _run_target_args'_v213091 = v213111 
                    #endif
                    let v213112 : Async<unit> = _run_target_args'_v213091 
                    do! v213112 
                    ()
                let v213121 : Async<string> = method28(v0)
                let v213122 : (string -> string option) = closure39()
                let v213123 : Async<string option> = method78(v213122, v213121)
                return! v213123 
                (* indent
                ()
            indent *)
            with ex ->
                let v213874 : exn = ex
                let v213875 : bool = v1 = 0L
                let v213876 : bool = v213875 <> true
                if v213876 then
                    let v214227 : unit = ()
                    let v214228 : (unit -> unit) = closure40(v1, v213874)
                    let v214229 : unit = (fun () -> v214228 (); v214227) ()
                    let v214584 : string option = None
                    return v214584 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v214587 : int64 = v1 + 1L
                    let v214588 : Async<string option> = method62(v0, v214587)
                    return! v214588 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v215305 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v244766 : Async<string option> = _let'_v183581 
    let _run_target_args'_v6 = v244766 
    #endif
    let v244767 : Async<string option> = _run_target_args'_v6 
    v244767
and method62 (v0 : string, v1 : int64) : Async<string option> =
    method63(v0, v1)
and method61 (v0 : string) : Async<string option> =
    let v1 : int64 = 0L
    method62(v0, v1)
and closure31 () (v0 : string) : Async<string option> =
    method61(v0)
and closure42 () (v0 : chrono_DateTime<chrono_Utc>) : US13 =
    US13_0(v0)
and method84 () : (chrono_DateTime<chrono_Utc> -> US13) =
    closure42()
and method85 () : string =
    let v0 : string = "hh:mm"
    v0
and method86 () : string =
    let v0 : string = "yyyyMMdd-HHmm-ssff-ffff-f"
    v0
and method87 () : string =
    let v0 : string = "hhmm"
    v0
and method83 (v0 : System.Guid, v1 : System.DateTime) : System.Guid =
    (* run_target_args'
    let v741 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v747 : System.DateTime = System.DateTime.UnixEpoch
    let v751 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v752 : System.DateTime = v751 v747
    let v756 : System.DateTimeKind = System.DateTimeKind.Local
    let v757 : System.DateTime = System.DateTime.SpecifyKind (v1, v756)
    let v761 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v762 : System.DateTime = v761 v757
    (* run_target_args'
    let v771 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v772 : (System.DateTime -> int64) = _.Ticks
    let v773 : int64 = v772 v762
    let _run_target_args'_v771 = v773 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v774 : (System.DateTime -> int64) = _.Ticks
    let v775 : int64 = v774 v762
    let _run_target_args'_v771 = v775 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v777 : int64 = null |> unbox<int64>
    let _run_target_args'_v771 = v777 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v780 : (System.DateTime -> int64) = _.Ticks
    let v781 : int64 = v780 v762
    let _run_target_args'_v771 = v781 
    #endif
#if FABLE_COMPILER_PYTHON
    let v782 : (System.DateTime -> int64) = _.Ticks
    let v783 : int64 = v782 v762
    let _run_target_args'_v771 = v783 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v784 : (System.DateTime -> int64) = _.Ticks
    let v785 : int64 = v784 v762
    let _run_target_args'_v771 = v785 
    #endif
#else
    let v786 : (System.DateTime -> int64) = _.Ticks
    let v787 : int64 = v786 v762
    let _run_target_args'_v771 = v787 
    #endif
    let v788 : int64 = _run_target_args'_v771 
    (* run_target_args'
    let v815 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v816 : (System.DateTime -> int64) = _.Ticks
    let v817 : int64 = v816 v752
    let _run_target_args'_v815 = v817 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v818 : (System.DateTime -> int64) = _.Ticks
    let v819 : int64 = v818 v752
    let _run_target_args'_v815 = v819 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v821 : int64 = null |> unbox<int64>
    let _run_target_args'_v815 = v821 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v824 : (System.DateTime -> int64) = _.Ticks
    let v825 : int64 = v824 v752
    let _run_target_args'_v815 = v825 
    #endif
#if FABLE_COMPILER_PYTHON
    let v826 : (System.DateTime -> int64) = _.Ticks
    let v827 : int64 = v826 v752
    let _run_target_args'_v815 = v827 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v828 : (System.DateTime -> int64) = _.Ticks
    let v829 : int64 = v828 v752
    let _run_target_args'_v815 = v829 
    #endif
#else
    let v830 : (System.DateTime -> int64) = _.Ticks
    let v831 : int64 = v830 v752
    let _run_target_args'_v815 = v831 
    #endif
    let v832 : int64 = _run_target_args'_v815 
    let v854 : int64 = v788 |> int64 
    let v858 : int64 = v832 |> int64 
    let v861 : int64 = v854 - v858
    let v862 : int64 = v861 / 10L
    let v863 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v864 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v862 v863 
    let v867 : (chrono_DateTime<chrono_Utc> -> US13) = method84()
    let v868 : US13 option = v864 |> Option.map v867 
    let v888 : US13 = US13_1
    let v889 : US13 = v868 |> Option.defaultValue v888 
    let v909 : US5 =
        match v889 with
        | US13_1 -> (* None *)
            US5_1
        | US13_0(v893) -> (* Some *)
            let v894 : string = "$0.naive_utc()"
            let v895 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v893 v894 
            let v896 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v897 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v895 v896 
            let v898 : string = "%Y%m%d-%H%M-%S%f"
            let v899 : string = "r#\"" + v898 + "\"#"
            let v900 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v899 
            let v901 : string = "$0.format($1).to_string()"
            let v902 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v897, v900) v901 
            let v903 : string = "fable_library_rust::String_::fromString($0)"
            let v904 : string = Fable.Core.RustInterop.emitRustExpr v902 v903 
            let v905 : string = $"{v904.[0..17]}-{v904.[18..21]}-{v904.[22]}"
            US5_0(v905)
    let v913 : string =
        match v909 with
        | US5_1 -> (* None *)
            let v911 : string = ""
            v911
        | US5_0(v910) -> (* Some *)
            v910
    (* run_target_args'
    let v918 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v919 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v920 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v919 
    let _run_target_args'_v918 = v920 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v922 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v922 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v926 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v926 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v930 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v930 
    #endif
#if FABLE_COMPILER_PYTHON
    let v934 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v918 = v934 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v937 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v918 = v937 
    #endif
#else
    let v938 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v918 = v938 
    #endif
    let v939 : System.TimeZoneInfo = _run_target_args'_v918 
    (* run_target_args'
    let v955 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v962 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v963 : (System.DateTime -> int64) = _.Ticks
    let v964 : int64 = v963 v762
    let _run_target_args'_v962 = v964 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v965 : (System.DateTime -> int64) = _.Ticks
    let v966 : int64 = v965 v762
    let _run_target_args'_v962 = v966 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v968 : int64 = null |> unbox<int64>
    let _run_target_args'_v962 = v968 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v971 : (System.DateTime -> int64) = _.Ticks
    let v972 : int64 = v971 v762
    let _run_target_args'_v962 = v972 
    #endif
#if FABLE_COMPILER_PYTHON
    let v973 : (System.DateTime -> int64) = _.Ticks
    let v974 : int64 = v973 v762
    let _run_target_args'_v962 = v974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v975 : (System.DateTime -> int64) = _.Ticks
    let v976 : int64 = v975 v762
    let _run_target_args'_v962 = v976 
    #endif
#else
    let v977 : (System.DateTime -> int64) = _.Ticks
    let v978 : int64 = v977 v762
    let _run_target_args'_v962 = v978 
    #endif
    let v979 : int64 = _run_target_args'_v962 
    let v1000 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1001 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v762, v979) v1000 
    let v1003 : System.TimeSpan = v1001 |> System.TimeSpan 
    let _run_target_args'_v955 = v1003 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1012 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1013 : (System.DateTime -> int64) = _.Ticks
    let v1014 : int64 = v1013 v762
    let _run_target_args'_v1012 = v1014 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1015 : (System.DateTime -> int64) = _.Ticks
    let v1016 : int64 = v1015 v762
    let _run_target_args'_v1012 = v1016 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1018 : int64 = null |> unbox<int64>
    let _run_target_args'_v1012 = v1018 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1021 : (System.DateTime -> int64) = _.Ticks
    let v1022 : int64 = v1021 v762
    let _run_target_args'_v1012 = v1022 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1023 : (System.DateTime -> int64) = _.Ticks
    let v1024 : int64 = v1023 v762
    let _run_target_args'_v1012 = v1024 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1025 : (System.DateTime -> int64) = _.Ticks
    let v1026 : int64 = v1025 v762
    let _run_target_args'_v1012 = v1026 
    #endif
#else
    let v1027 : (System.DateTime -> int64) = _.Ticks
    let v1028 : int64 = v1027 v762
    let _run_target_args'_v1012 = v1028 
    #endif
    let v1029 : int64 = _run_target_args'_v1012 
    let v1050 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1051 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v762, v1029) v1050 
    let v1053 : System.TimeSpan = v1051 |> System.TimeSpan 
    let _run_target_args'_v955 = v1053 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1057 : US3 = US3_2
    let v1058 : US4 = US4_4(v1057)
    let v1059 : string = $"date_time.get_utc_offset / target: {v1058}"
    let v1060 : System.TimeSpan = failwith<System.TimeSpan> v1059
    let _run_target_args'_v955 = v1060 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1064 : US3 = US3_0
    let v1065 : US4 = US4_5(v1064)
    let v1066 : string = $"date_time.get_utc_offset / target: {v1065}"
    let v1067 : System.TimeSpan = failwith<System.TimeSpan> v1066
    let _run_target_args'_v955 = v1067 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1071 : US3 = US3_0
    let v1072 : US4 = US4_6(v1071)
    let v1073 : string = $"date_time.get_utc_offset / target: {v1072}"
    let v1074 : System.TimeSpan = failwith<System.TimeSpan> v1073
    let _run_target_args'_v955 = v1074 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1077 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1082 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1083 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1084 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1083 
    let _run_target_args'_v1082 = v1084 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1086 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1086 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1090 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1090 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1094 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1094 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1098 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1082 = v1098 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1101 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1082 = v1101 
    #endif
#else
    let v1102 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1082 = v1102 
    #endif
    let v1103 : System.TimeZoneInfo = _run_target_args'_v1082 
    let v1112 : (System.DateTime -> System.TimeSpan) = v1077 v1103
    let v1113 : System.TimeSpan = v1112 v762
    let _run_target_args'_v955 = v1113 
    #endif
#else
    let v1114 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1119 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1120 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1121 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1120 
    let _run_target_args'_v1119 = v1121 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1123 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1123 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1127 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1127 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1131 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1131 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1135 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1119 = v1135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1138 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1119 = v1138 
    #endif
#else
    let v1139 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1119 = v1139 
    #endif
    let v1140 : System.TimeZoneInfo = _run_target_args'_v1119 
    let v1149 : (System.DateTime -> System.TimeSpan) = v1114 v1140
    let v1150 : System.TimeSpan = v1149 v762
    let _run_target_args'_v955 = v1150 
    #endif
    let v1151 : System.TimeSpan = _run_target_args'_v955 
    let v1167 : (System.TimeSpan -> int32) = _.Hours
    let v1168 : int32 = v1167 v1151
    let v1171 : bool = v1168 > 0
    let v1172 : uint8 =
        if v1171 then
            1uy
        else
            0uy
    let v1173 : string = method85()
    (* run_target_args'
    let v1244 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1245 : string = "$0.toString($1)"
    let v1246 : string = Fable.Core.RustInterop.emitRustExpr struct (v1151, v1173) v1245 
    let _run_target_args'_v1244 = v1246 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1247 : string = "$0.toString($1)"
    let v1248 : string = Fable.Core.RustInterop.emitRustExpr struct (v1151, v1173) v1247 
    let _run_target_args'_v1244 = v1248 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1249 : string = "$0.toString($1)"
    let v1250 : string = Fable.Core.RustInterop.emitRustExpr struct (v1151, v1173) v1249 
    let _run_target_args'_v1244 = v1250 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1251 : string = v1151.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1244 = v1251 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1252 : string = v1151.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1244 = v1252 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1254 : string = v1151.ToString v1173 
    let _run_target_args'_v1244 = v1254 
    #endif
#else
    let v1324 : string = v1151.ToString v1173 
    let _run_target_args'_v1244 = v1324 
    #endif
    let v1393 : string = _run_target_args'_v1244 
    let v1534 : string = $"{v1172}{v1393.[0..1]}{v1393.[3..4]}"
    let v1536 : (System.Guid -> string) = _.ToString()
    let v1537 : string = v1536 v0
    let v1540 : int32 = v913.Length
    let v1541 : int32 = v1534.Length
    let v1542 : int32 = v1540 + v1541
    let v1544 : (string -> int32) = String.length
    let v1545 : int32 = v1544 v1537
    let v1549 : int32 = 1
    let v1555 : int32 = v1542 |> int32 
    let v1568 : int32 = v1545 |> int32 
    let v1576 : int32 = v1568 - v1549
    let v1578 : string = v1537.[int v1555..int v1576]
    let v1582 : string = $"{v913}{v1534}{v1578}"
    (* run_target_args'
    let v1587 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1589 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1589 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1593 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1593 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1597 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1587 = v1597 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1601 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1601 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1605 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1605 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1609 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1609 
    #endif
#else
    let v1613 : System.Guid = v1582 |> System.Guid 
    let _run_target_args'_v1587 = v1613 
    #endif
    let v1616 : System.Guid = _run_target_args'_v1587 
    let _run_target_args'_v741 = v1616 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1630 : System.DateTime = System.DateTime.UnixEpoch
    let v1634 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1635 : System.DateTime = v1634 v1630
    let v1639 : System.DateTimeKind = System.DateTimeKind.Local
    let v1640 : System.DateTime = System.DateTime.SpecifyKind (v1, v1639)
    let v1644 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1645 : System.DateTime = v1644 v1640
    (* run_target_args'
    let v1654 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1655 : (System.DateTime -> int64) = _.Ticks
    let v1656 : int64 = v1655 v1645
    let _run_target_args'_v1654 = v1656 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1657 : (System.DateTime -> int64) = _.Ticks
    let v1658 : int64 = v1657 v1645
    let _run_target_args'_v1654 = v1658 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1660 : int64 = null |> unbox<int64>
    let _run_target_args'_v1654 = v1660 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1663 : (System.DateTime -> int64) = _.Ticks
    let v1664 : int64 = v1663 v1645
    let _run_target_args'_v1654 = v1664 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1665 : (System.DateTime -> int64) = _.Ticks
    let v1666 : int64 = v1665 v1645
    let _run_target_args'_v1654 = v1666 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1667 : (System.DateTime -> int64) = _.Ticks
    let v1668 : int64 = v1667 v1645
    let _run_target_args'_v1654 = v1668 
    #endif
#else
    let v1669 : (System.DateTime -> int64) = _.Ticks
    let v1670 : int64 = v1669 v1645
    let _run_target_args'_v1654 = v1670 
    #endif
    let v1671 : int64 = _run_target_args'_v1654 
    (* run_target_args'
    let v1698 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1699 : (System.DateTime -> int64) = _.Ticks
    let v1700 : int64 = v1699 v1635
    let _run_target_args'_v1698 = v1700 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1701 : (System.DateTime -> int64) = _.Ticks
    let v1702 : int64 = v1701 v1635
    let _run_target_args'_v1698 = v1702 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1704 : int64 = null |> unbox<int64>
    let _run_target_args'_v1698 = v1704 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1707 : (System.DateTime -> int64) = _.Ticks
    let v1708 : int64 = v1707 v1635
    let _run_target_args'_v1698 = v1708 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1709 : (System.DateTime -> int64) = _.Ticks
    let v1710 : int64 = v1709 v1635
    let _run_target_args'_v1698 = v1710 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1711 : (System.DateTime -> int64) = _.Ticks
    let v1712 : int64 = v1711 v1635
    let _run_target_args'_v1698 = v1712 
    #endif
#else
    let v1713 : (System.DateTime -> int64) = _.Ticks
    let v1714 : int64 = v1713 v1635
    let _run_target_args'_v1698 = v1714 
    #endif
    let v1715 : int64 = _run_target_args'_v1698 
    let v1737 : int64 = v1671 |> int64 
    let v1741 : int64 = v1715 |> int64 
    let v1744 : int64 = v1737 - v1741
    let v1745 : int64 = v1744 / 10L
    let v1746 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1747 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1745 v1746 
    let v1750 : (chrono_DateTime<chrono_Utc> -> US13) = method84()
    let v1751 : US13 option = v1747 |> Option.map v1750 
    let v1771 : US13 = US13_1
    let v1772 : US13 = v1751 |> Option.defaultValue v1771 
    let v1792 : US5 =
        match v1772 with
        | US13_1 -> (* None *)
            US5_1
        | US13_0(v1776) -> (* Some *)
            let v1777 : string = "$0.naive_utc()"
            let v1778 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1776 v1777 
            let v1779 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1780 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1778 v1779 
            let v1781 : string = "%Y%m%d-%H%M-%S%f"
            let v1782 : string = "r#\"" + v1781 + "\"#"
            let v1783 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1782 
            let v1784 : string = "$0.format($1).to_string()"
            let v1785 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1780, v1783) v1784 
            let v1786 : string = "fable_library_rust::String_::fromString($0)"
            let v1787 : string = Fable.Core.RustInterop.emitRustExpr v1785 v1786 
            let v1788 : string = $"{v1787.[0..17]}-{v1787.[18..21]}-{v1787.[22]}"
            US5_0(v1788)
    let v1796 : string =
        match v1792 with
        | US5_1 -> (* None *)
            let v1794 : string = ""
            v1794
        | US5_0(v1793) -> (* Some *)
            v1793
    (* run_target_args'
    let v1801 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1802 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1803 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1802 
    let _run_target_args'_v1801 = v1803 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1805 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1805 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1809 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1809 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1813 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1813 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1817 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1801 = v1817 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1820 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1801 = v1820 
    #endif
#else
    let v1821 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1801 = v1821 
    #endif
    let v1822 : System.TimeZoneInfo = _run_target_args'_v1801 
    (* run_target_args'
    let v1838 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1845 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1846 : (System.DateTime -> int64) = _.Ticks
    let v1847 : int64 = v1846 v1645
    let _run_target_args'_v1845 = v1847 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1848 : (System.DateTime -> int64) = _.Ticks
    let v1849 : int64 = v1848 v1645
    let _run_target_args'_v1845 = v1849 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1851 : int64 = null |> unbox<int64>
    let _run_target_args'_v1845 = v1851 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1854 : (System.DateTime -> int64) = _.Ticks
    let v1855 : int64 = v1854 v1645
    let _run_target_args'_v1845 = v1855 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1856 : (System.DateTime -> int64) = _.Ticks
    let v1857 : int64 = v1856 v1645
    let _run_target_args'_v1845 = v1857 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1858 : (System.DateTime -> int64) = _.Ticks
    let v1859 : int64 = v1858 v1645
    let _run_target_args'_v1845 = v1859 
    #endif
#else
    let v1860 : (System.DateTime -> int64) = _.Ticks
    let v1861 : int64 = v1860 v1645
    let _run_target_args'_v1845 = v1861 
    #endif
    let v1862 : int64 = _run_target_args'_v1845 
    let v1883 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1884 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1645, v1862) v1883 
    let v1886 : System.TimeSpan = v1884 |> System.TimeSpan 
    let _run_target_args'_v1838 = v1886 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1895 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1896 : (System.DateTime -> int64) = _.Ticks
    let v1897 : int64 = v1896 v1645
    let _run_target_args'_v1895 = v1897 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1898 : (System.DateTime -> int64) = _.Ticks
    let v1899 : int64 = v1898 v1645
    let _run_target_args'_v1895 = v1899 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1901 : int64 = null |> unbox<int64>
    let _run_target_args'_v1895 = v1901 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1904 : (System.DateTime -> int64) = _.Ticks
    let v1905 : int64 = v1904 v1645
    let _run_target_args'_v1895 = v1905 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1906 : (System.DateTime -> int64) = _.Ticks
    let v1907 : int64 = v1906 v1645
    let _run_target_args'_v1895 = v1907 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1908 : (System.DateTime -> int64) = _.Ticks
    let v1909 : int64 = v1908 v1645
    let _run_target_args'_v1895 = v1909 
    #endif
#else
    let v1910 : (System.DateTime -> int64) = _.Ticks
    let v1911 : int64 = v1910 v1645
    let _run_target_args'_v1895 = v1911 
    #endif
    let v1912 : int64 = _run_target_args'_v1895 
    let v1933 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1934 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1645, v1912) v1933 
    let v1936 : System.TimeSpan = v1934 |> System.TimeSpan 
    let _run_target_args'_v1838 = v1936 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1940 : US3 = US3_2
    let v1941 : US4 = US4_4(v1940)
    let v1942 : string = $"date_time.get_utc_offset / target: {v1941}"
    let v1943 : System.TimeSpan = failwith<System.TimeSpan> v1942
    let _run_target_args'_v1838 = v1943 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1947 : US3 = US3_0
    let v1948 : US4 = US4_5(v1947)
    let v1949 : string = $"date_time.get_utc_offset / target: {v1948}"
    let v1950 : System.TimeSpan = failwith<System.TimeSpan> v1949
    let _run_target_args'_v1838 = v1950 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1954 : US3 = US3_0
    let v1955 : US4 = US4_6(v1954)
    let v1956 : string = $"date_time.get_utc_offset / target: {v1955}"
    let v1957 : System.TimeSpan = failwith<System.TimeSpan> v1956
    let _run_target_args'_v1838 = v1957 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1960 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1965 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1966 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1967 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1966 
    let _run_target_args'_v1965 = v1967 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1969 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1969 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1973 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1973 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1977 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1977 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1981 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1965 = v1981 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1984 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1965 = v1984 
    #endif
#else
    let v1985 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1965 = v1985 
    #endif
    let v1986 : System.TimeZoneInfo = _run_target_args'_v1965 
    let v1995 : (System.DateTime -> System.TimeSpan) = v1960 v1986
    let v1996 : System.TimeSpan = v1995 v1645
    let _run_target_args'_v1838 = v1996 
    #endif
#else
    let v1997 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2002 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2003 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2004 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2003 
    let _run_target_args'_v2002 = v2004 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2006 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2006 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2010 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2010 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2014 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2014 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2018 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2002 = v2018 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2021 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2002 = v2021 
    #endif
#else
    let v2022 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2002 = v2022 
    #endif
    let v2023 : System.TimeZoneInfo = _run_target_args'_v2002 
    let v2032 : (System.DateTime -> System.TimeSpan) = v1997 v2023
    let v2033 : System.TimeSpan = v2032 v1645
    let _run_target_args'_v1838 = v2033 
    #endif
    let v2034 : System.TimeSpan = _run_target_args'_v1838 
    let v2050 : (System.TimeSpan -> int32) = _.Hours
    let v2051 : int32 = v2050 v2034
    let v2054 : bool = v2051 > 0
    let v2055 : uint8 =
        if v2054 then
            1uy
        else
            0uy
    let v2056 : string = method85()
    (* run_target_args'
    let v2127 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2128 : string = "$0.toString($1)"
    let v2129 : string = Fable.Core.RustInterop.emitRustExpr struct (v2034, v2056) v2128 
    let _run_target_args'_v2127 = v2129 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2130 : string = "$0.toString($1)"
    let v2131 : string = Fable.Core.RustInterop.emitRustExpr struct (v2034, v2056) v2130 
    let _run_target_args'_v2127 = v2131 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2132 : string = "$0.toString($1)"
    let v2133 : string = Fable.Core.RustInterop.emitRustExpr struct (v2034, v2056) v2132 
    let _run_target_args'_v2127 = v2133 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2134 : string = v2034.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2127 = v2134 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2135 : string = v2034.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2127 = v2135 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2137 : string = v2034.ToString v2056 
    let _run_target_args'_v2127 = v2137 
    #endif
#else
    let v2207 : string = v2034.ToString v2056 
    let _run_target_args'_v2127 = v2207 
    #endif
    let v2276 : string = _run_target_args'_v2127 
    let v2417 : string = $"{v2055}{v2276.[0..1]}{v2276.[3..4]}"
    let v2419 : (System.Guid -> string) = _.ToString()
    let v2420 : string = v2419 v0
    let v2423 : int32 = v1796.Length
    let v2424 : int32 = v2417.Length
    let v2425 : int32 = v2423 + v2424
    let v2427 : (string -> int32) = String.length
    let v2428 : int32 = v2427 v2420
    let v2432 : int32 = 1
    let v2438 : int32 = v2425 |> int32 
    let v2451 : int32 = v2428 |> int32 
    let v2459 : int32 = v2451 - v2432
    let v2461 : string = v2420.[int v2438..int v2459]
    let v2465 : string = $"{v1796}{v2417}{v2461}"
    (* run_target_args'
    let v2470 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2472 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2472 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2476 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2476 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2480 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2470 = v2480 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2484 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2484 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2488 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2488 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2492 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2492 
    #endif
#else
    let v2496 : System.Guid = v2465 |> System.Guid 
    let _run_target_args'_v2470 = v2496 
    #endif
    let v2499 : System.Guid = _run_target_args'_v2470 
    let _run_target_args'_v741 = v2499 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2509 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v741 = v2509 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2512 : string = method86()
    let v2523 : bool = v2512 = ""
    let v2525 : string =
        if v2523 then
            let v2524 : string = "M-d-y hh:mm:ss tt"
            v2524
        else
            v2512
    let v2526 : (string -> string) = v1.ToString
    let v2527 : string = v2526 v2525
    (* run_target_args'
    let v2546 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2547 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2548 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2547 
    let _run_target_args'_v2546 = v2548 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2550 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2550 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2554 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2554 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2558 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2558 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2562 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2546 = v2562 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2565 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2546 = v2565 
    #endif
#else
    let v2566 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2546 = v2566 
    #endif
    let v2567 : System.TimeZoneInfo = _run_target_args'_v2546 
    (* run_target_args'
    let v2583 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2590 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2591 : (System.DateTime -> int64) = _.Ticks
    let v2592 : int64 = v2591 v1
    let _run_target_args'_v2590 = v2592 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2593 : (System.DateTime -> int64) = _.Ticks
    let v2594 : int64 = v2593 v1
    let _run_target_args'_v2590 = v2594 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2596 : int64 = null |> unbox<int64>
    let _run_target_args'_v2590 = v2596 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2599 : (System.DateTime -> int64) = _.Ticks
    let v2600 : int64 = v2599 v1
    let _run_target_args'_v2590 = v2600 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2601 : (System.DateTime -> int64) = _.Ticks
    let v2602 : int64 = v2601 v1
    let _run_target_args'_v2590 = v2602 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2603 : (System.DateTime -> int64) = _.Ticks
    let v2604 : int64 = v2603 v1
    let _run_target_args'_v2590 = v2604 
    #endif
#else
    let v2605 : (System.DateTime -> int64) = _.Ticks
    let v2606 : int64 = v2605 v1
    let _run_target_args'_v2590 = v2606 
    #endif
    let v2607 : int64 = _run_target_args'_v2590 
    let v2628 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2629 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2607) v2628 
    let v2631 : System.TimeSpan = v2629 |> System.TimeSpan 
    let _run_target_args'_v2583 = v2631 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2640 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2641 : (System.DateTime -> int64) = _.Ticks
    let v2642 : int64 = v2641 v1
    let _run_target_args'_v2640 = v2642 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2643 : (System.DateTime -> int64) = _.Ticks
    let v2644 : int64 = v2643 v1
    let _run_target_args'_v2640 = v2644 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2646 : int64 = null |> unbox<int64>
    let _run_target_args'_v2640 = v2646 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2649 : (System.DateTime -> int64) = _.Ticks
    let v2650 : int64 = v2649 v1
    let _run_target_args'_v2640 = v2650 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2651 : (System.DateTime -> int64) = _.Ticks
    let v2652 : int64 = v2651 v1
    let _run_target_args'_v2640 = v2652 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2653 : (System.DateTime -> int64) = _.Ticks
    let v2654 : int64 = v2653 v1
    let _run_target_args'_v2640 = v2654 
    #endif
#else
    let v2655 : (System.DateTime -> int64) = _.Ticks
    let v2656 : int64 = v2655 v1
    let _run_target_args'_v2640 = v2656 
    #endif
    let v2657 : int64 = _run_target_args'_v2640 
    let v2678 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2679 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2657) v2678 
    let v2681 : System.TimeSpan = v2679 |> System.TimeSpan 
    let _run_target_args'_v2583 = v2681 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2685 : US3 = US3_2
    let v2686 : US4 = US4_4(v2685)
    let v2687 : string = $"date_time.get_utc_offset / target: {v2686}"
    let v2688 : System.TimeSpan = failwith<System.TimeSpan> v2687
    let _run_target_args'_v2583 = v2688 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2692 : US3 = US3_0
    let v2693 : US4 = US4_5(v2692)
    let v2694 : string = $"date_time.get_utc_offset / target: {v2693}"
    let v2695 : System.TimeSpan = failwith<System.TimeSpan> v2694
    let _run_target_args'_v2583 = v2695 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2699 : US3 = US3_0
    let v2700 : US4 = US4_6(v2699)
    let v2701 : string = $"date_time.get_utc_offset / target: {v2700}"
    let v2702 : System.TimeSpan = failwith<System.TimeSpan> v2701
    let _run_target_args'_v2583 = v2702 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2705 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2710 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2711 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2712 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2711 
    let _run_target_args'_v2710 = v2712 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2714 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2714 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2718 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2718 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2722 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2722 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2726 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2710 = v2726 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2729 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2710 = v2729 
    #endif
#else
    let v2730 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2710 = v2730 
    #endif
    let v2731 : System.TimeZoneInfo = _run_target_args'_v2710 
    let v2740 : (System.DateTime -> System.TimeSpan) = v2705 v2731
    let v2741 : System.TimeSpan = v2740 v1
    let _run_target_args'_v2583 = v2741 
    #endif
#else
    let v2742 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2747 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2748 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2749 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2748 
    let _run_target_args'_v2747 = v2749 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2751 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2751 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2755 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2755 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2759 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2759 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2763 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2747 = v2763 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2766 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2747 = v2766 
    #endif
#else
    let v2767 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2747 = v2767 
    #endif
    let v2768 : System.TimeZoneInfo = _run_target_args'_v2747 
    let v2777 : (System.DateTime -> System.TimeSpan) = v2742 v2768
    let v2778 : System.TimeSpan = v2777 v1
    let _run_target_args'_v2583 = v2778 
    #endif
    let v2779 : System.TimeSpan = _run_target_args'_v2583 
    let v2795 : (System.TimeSpan -> int32) = _.Hours
    let v2796 : int32 = v2795 v2779
    let v2799 : bool = v2796 > 0
    let v2800 : uint8 =
        if v2799 then
            1uy
        else
            0uy
    let v2801 : string = method87()
    (* run_target_args'
    let v2872 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2873 : string = "$0.toString($1)"
    let v2874 : string = Fable.Core.RustInterop.emitRustExpr struct (v2779, v2801) v2873 
    let _run_target_args'_v2872 = v2874 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2875 : string = "$0.toString($1)"
    let v2876 : string = Fable.Core.RustInterop.emitRustExpr struct (v2779, v2801) v2875 
    let _run_target_args'_v2872 = v2876 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2877 : string = "$0.toString($1)"
    let v2878 : string = Fable.Core.RustInterop.emitRustExpr struct (v2779, v2801) v2877 
    let _run_target_args'_v2872 = v2878 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2879 : string = v2779.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2872 = v2879 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2880 : string = v2779.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2872 = v2880 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2882 : string = v2779.ToString v2801 
    let _run_target_args'_v2872 = v2882 
    #endif
#else
    let v2952 : string = v2779.ToString v2801 
    let _run_target_args'_v2872 = v2952 
    #endif
    let v3021 : string = _run_target_args'_v2872 
    let v3162 : string = $"{v2800}{v3021}"
    let v3164 : (System.Guid -> string) = _.ToString()
    let v3165 : string = v3164 v0
    let v3168 : int32 = v2527.Length
    let v3169 : int32 = v3162.Length
    let v3170 : int32 = v3168 + v3169
    let v3172 : (string -> int32) = String.length
    let v3173 : int32 = v3172 v3165
    let v3177 : int32 = 1
    let v3183 : int32 = v3170 |> int32 
    let v3196 : int32 = v3173 |> int32 
    let v3204 : int32 = v3196 - v3177
    let v3206 : string = v3165.[int v3183..int v3204]
    let v3210 : string = $"{v2527}{v3162}{v3206}"
    (* run_target_args'
    let v3215 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3217 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3217 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3221 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3221 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3225 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3215 = v3225 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3229 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3229 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3233 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3233 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3237 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3237 
    #endif
#else
    let v3241 : System.Guid = v3210 |> System.Guid 
    let _run_target_args'_v3215 = v3241 
    #endif
    let v3244 : System.Guid = _run_target_args'_v3215 
    let _run_target_args'_v741 = v3244 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3253 : string = method86()
    let v3264 : bool = v3253 = ""
    let v3266 : string =
        if v3264 then
            let v3265 : string = "M-d-y hh:mm:ss tt"
            v3265
        else
            v3253
    let v3267 : (string -> string) = v1.ToString
    let v3268 : string = v3267 v3266
    (* run_target_args'
    let v3287 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3288 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3289 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3288 
    let _run_target_args'_v3287 = v3289 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3291 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3291 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3295 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3295 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3299 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3299 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3303 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3287 = v3303 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3306 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3287 = v3306 
    #endif
#else
    let v3307 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3287 = v3307 
    #endif
    let v3308 : System.TimeZoneInfo = _run_target_args'_v3287 
    (* run_target_args'
    let v3324 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3331 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3332 : (System.DateTime -> int64) = _.Ticks
    let v3333 : int64 = v3332 v1
    let _run_target_args'_v3331 = v3333 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3334 : (System.DateTime -> int64) = _.Ticks
    let v3335 : int64 = v3334 v1
    let _run_target_args'_v3331 = v3335 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3337 : int64 = null |> unbox<int64>
    let _run_target_args'_v3331 = v3337 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3340 : (System.DateTime -> int64) = _.Ticks
    let v3341 : int64 = v3340 v1
    let _run_target_args'_v3331 = v3341 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3342 : (System.DateTime -> int64) = _.Ticks
    let v3343 : int64 = v3342 v1
    let _run_target_args'_v3331 = v3343 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3344 : (System.DateTime -> int64) = _.Ticks
    let v3345 : int64 = v3344 v1
    let _run_target_args'_v3331 = v3345 
    #endif
#else
    let v3346 : (System.DateTime -> int64) = _.Ticks
    let v3347 : int64 = v3346 v1
    let _run_target_args'_v3331 = v3347 
    #endif
    let v3348 : int64 = _run_target_args'_v3331 
    let v3369 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3370 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3348) v3369 
    let v3372 : System.TimeSpan = v3370 |> System.TimeSpan 
    let _run_target_args'_v3324 = v3372 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3381 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3382 : (System.DateTime -> int64) = _.Ticks
    let v3383 : int64 = v3382 v1
    let _run_target_args'_v3381 = v3383 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3384 : (System.DateTime -> int64) = _.Ticks
    let v3385 : int64 = v3384 v1
    let _run_target_args'_v3381 = v3385 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3387 : int64 = null |> unbox<int64>
    let _run_target_args'_v3381 = v3387 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3390 : (System.DateTime -> int64) = _.Ticks
    let v3391 : int64 = v3390 v1
    let _run_target_args'_v3381 = v3391 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3392 : (System.DateTime -> int64) = _.Ticks
    let v3393 : int64 = v3392 v1
    let _run_target_args'_v3381 = v3393 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3394 : (System.DateTime -> int64) = _.Ticks
    let v3395 : int64 = v3394 v1
    let _run_target_args'_v3381 = v3395 
    #endif
#else
    let v3396 : (System.DateTime -> int64) = _.Ticks
    let v3397 : int64 = v3396 v1
    let _run_target_args'_v3381 = v3397 
    #endif
    let v3398 : int64 = _run_target_args'_v3381 
    let v3419 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3420 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3398) v3419 
    let v3422 : System.TimeSpan = v3420 |> System.TimeSpan 
    let _run_target_args'_v3324 = v3422 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3426 : US3 = US3_2
    let v3427 : US4 = US4_4(v3426)
    let v3428 : string = $"date_time.get_utc_offset / target: {v3427}"
    let v3429 : System.TimeSpan = failwith<System.TimeSpan> v3428
    let _run_target_args'_v3324 = v3429 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3433 : US3 = US3_0
    let v3434 : US4 = US4_5(v3433)
    let v3435 : string = $"date_time.get_utc_offset / target: {v3434}"
    let v3436 : System.TimeSpan = failwith<System.TimeSpan> v3435
    let _run_target_args'_v3324 = v3436 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3440 : US3 = US3_0
    let v3441 : US4 = US4_6(v3440)
    let v3442 : string = $"date_time.get_utc_offset / target: {v3441}"
    let v3443 : System.TimeSpan = failwith<System.TimeSpan> v3442
    let _run_target_args'_v3324 = v3443 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3446 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3451 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3452 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3453 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3452 
    let _run_target_args'_v3451 = v3453 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3455 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3455 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3459 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3459 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3463 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3463 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3467 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3451 = v3467 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3470 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3451 = v3470 
    #endif
#else
    let v3471 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3451 = v3471 
    #endif
    let v3472 : System.TimeZoneInfo = _run_target_args'_v3451 
    let v3481 : (System.DateTime -> System.TimeSpan) = v3446 v3472
    let v3482 : System.TimeSpan = v3481 v1
    let _run_target_args'_v3324 = v3482 
    #endif
#else
    let v3483 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3488 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3489 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3490 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3489 
    let _run_target_args'_v3488 = v3490 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3492 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3492 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3496 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3496 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3500 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3500 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3504 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3488 = v3504 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3507 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3488 = v3507 
    #endif
#else
    let v3508 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3488 = v3508 
    #endif
    let v3509 : System.TimeZoneInfo = _run_target_args'_v3488 
    let v3518 : (System.DateTime -> System.TimeSpan) = v3483 v3509
    let v3519 : System.TimeSpan = v3518 v1
    let _run_target_args'_v3324 = v3519 
    #endif
    let v3520 : System.TimeSpan = _run_target_args'_v3324 
    let v3536 : (System.TimeSpan -> int32) = _.Hours
    let v3537 : int32 = v3536 v3520
    let v3540 : bool = v3537 > 0
    let v3541 : uint8 =
        if v3540 then
            1uy
        else
            0uy
    let v3542 : string = method87()
    (* run_target_args'
    let v3613 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3614 : string = "$0.toString($1)"
    let v3615 : string = Fable.Core.RustInterop.emitRustExpr struct (v3520, v3542) v3614 
    let _run_target_args'_v3613 = v3615 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3616 : string = "$0.toString($1)"
    let v3617 : string = Fable.Core.RustInterop.emitRustExpr struct (v3520, v3542) v3616 
    let _run_target_args'_v3613 = v3617 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3618 : string = "$0.toString($1)"
    let v3619 : string = Fable.Core.RustInterop.emitRustExpr struct (v3520, v3542) v3618 
    let _run_target_args'_v3613 = v3619 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3620 : string = v3520.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3620 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3621 : string = v3520.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3621 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3623 : string = v3520.ToString v3542 
    let _run_target_args'_v3613 = v3623 
    #endif
#else
    let v3693 : string = v3520.ToString v3542 
    let _run_target_args'_v3613 = v3693 
    #endif
    let v3762 : string = _run_target_args'_v3613 
    let v3903 : string = $"{v3541}{v3762}"
    let v3905 : (System.Guid -> string) = _.ToString()
    let v3906 : string = v3905 v0
    let v3909 : int32 = v3268.Length
    let v3910 : int32 = v3903.Length
    let v3911 : int32 = v3909 + v3910
    let v3913 : (string -> int32) = String.length
    let v3914 : int32 = v3913 v3906
    let v3918 : int32 = 1
    let v3924 : int32 = v3911 |> int32 
    let v3937 : int32 = v3914 |> int32 
    let v3945 : int32 = v3937 - v3918
    let v3947 : string = v3906.[int v3924..int v3945]
    let v3951 : string = $"{v3268}{v3903}{v3947}"
    (* run_target_args'
    let v3956 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3958 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3958 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3962 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3962 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3966 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3956 = v3966 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3970 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3970 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3974 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3974 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3978 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3978 
    #endif
#else
    let v3982 : System.Guid = v3951 |> System.Guid 
    let _run_target_args'_v3956 = v3982 
    #endif
    let v3985 : System.Guid = _run_target_args'_v3956 
    let _run_target_args'_v741 = v3985 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3994 : string = method86()
    let v4005 : bool = v3994 = ""
    let v4007 : string =
        if v4005 then
            let v4006 : string = "M-d-y hh:mm:ss tt"
            v4006
        else
            v3994
    let v4008 : (string -> string) = v1.ToString
    let v4009 : string = v4008 v4007
    (* run_target_args'
    let v4028 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4029 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4030 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4029 
    let _run_target_args'_v4028 = v4030 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4032 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4032 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4036 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4036 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4040 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4040 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4044 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4028 = v4044 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4047 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4028 = v4047 
    #endif
#else
    let v4048 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4028 = v4048 
    #endif
    let v4049 : System.TimeZoneInfo = _run_target_args'_v4028 
    (* run_target_args'
    let v4065 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4072 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4073 : (System.DateTime -> int64) = _.Ticks
    let v4074 : int64 = v4073 v1
    let _run_target_args'_v4072 = v4074 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4075 : (System.DateTime -> int64) = _.Ticks
    let v4076 : int64 = v4075 v1
    let _run_target_args'_v4072 = v4076 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4078 : int64 = null |> unbox<int64>
    let _run_target_args'_v4072 = v4078 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4081 : (System.DateTime -> int64) = _.Ticks
    let v4082 : int64 = v4081 v1
    let _run_target_args'_v4072 = v4082 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4083 : (System.DateTime -> int64) = _.Ticks
    let v4084 : int64 = v4083 v1
    let _run_target_args'_v4072 = v4084 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4085 : (System.DateTime -> int64) = _.Ticks
    let v4086 : int64 = v4085 v1
    let _run_target_args'_v4072 = v4086 
    #endif
#else
    let v4087 : (System.DateTime -> int64) = _.Ticks
    let v4088 : int64 = v4087 v1
    let _run_target_args'_v4072 = v4088 
    #endif
    let v4089 : int64 = _run_target_args'_v4072 
    let v4110 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4111 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4089) v4110 
    let v4113 : System.TimeSpan = v4111 |> System.TimeSpan 
    let _run_target_args'_v4065 = v4113 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4122 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4123 : (System.DateTime -> int64) = _.Ticks
    let v4124 : int64 = v4123 v1
    let _run_target_args'_v4122 = v4124 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4125 : (System.DateTime -> int64) = _.Ticks
    let v4126 : int64 = v4125 v1
    let _run_target_args'_v4122 = v4126 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4128 : int64 = null |> unbox<int64>
    let _run_target_args'_v4122 = v4128 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4131 : (System.DateTime -> int64) = _.Ticks
    let v4132 : int64 = v4131 v1
    let _run_target_args'_v4122 = v4132 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4133 : (System.DateTime -> int64) = _.Ticks
    let v4134 : int64 = v4133 v1
    let _run_target_args'_v4122 = v4134 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4135 : (System.DateTime -> int64) = _.Ticks
    let v4136 : int64 = v4135 v1
    let _run_target_args'_v4122 = v4136 
    #endif
#else
    let v4137 : (System.DateTime -> int64) = _.Ticks
    let v4138 : int64 = v4137 v1
    let _run_target_args'_v4122 = v4138 
    #endif
    let v4139 : int64 = _run_target_args'_v4122 
    let v4160 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4161 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4139) v4160 
    let v4163 : System.TimeSpan = v4161 |> System.TimeSpan 
    let _run_target_args'_v4065 = v4163 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4167 : US3 = US3_2
    let v4168 : US4 = US4_4(v4167)
    let v4169 : string = $"date_time.get_utc_offset / target: {v4168}"
    let v4170 : System.TimeSpan = failwith<System.TimeSpan> v4169
    let _run_target_args'_v4065 = v4170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4174 : US3 = US3_0
    let v4175 : US4 = US4_5(v4174)
    let v4176 : string = $"date_time.get_utc_offset / target: {v4175}"
    let v4177 : System.TimeSpan = failwith<System.TimeSpan> v4176
    let _run_target_args'_v4065 = v4177 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4181 : US3 = US3_0
    let v4182 : US4 = US4_6(v4181)
    let v4183 : string = $"date_time.get_utc_offset / target: {v4182}"
    let v4184 : System.TimeSpan = failwith<System.TimeSpan> v4183
    let _run_target_args'_v4065 = v4184 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4187 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4192 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4193 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4194 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4193 
    let _run_target_args'_v4192 = v4194 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4196 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4196 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4200 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4200 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4204 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4204 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4208 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4192 = v4208 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4211 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4192 = v4211 
    #endif
#else
    let v4212 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4192 = v4212 
    #endif
    let v4213 : System.TimeZoneInfo = _run_target_args'_v4192 
    let v4222 : (System.DateTime -> System.TimeSpan) = v4187 v4213
    let v4223 : System.TimeSpan = v4222 v1
    let _run_target_args'_v4065 = v4223 
    #endif
#else
    let v4224 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4229 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4230 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4231 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4230 
    let _run_target_args'_v4229 = v4231 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4233 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4233 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4237 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4237 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4241 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4241 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4245 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4229 = v4245 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4248 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4229 = v4248 
    #endif
#else
    let v4249 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4229 = v4249 
    #endif
    let v4250 : System.TimeZoneInfo = _run_target_args'_v4229 
    let v4259 : (System.DateTime -> System.TimeSpan) = v4224 v4250
    let v4260 : System.TimeSpan = v4259 v1
    let _run_target_args'_v4065 = v4260 
    #endif
    let v4261 : System.TimeSpan = _run_target_args'_v4065 
    let v4277 : (System.TimeSpan -> int32) = _.Hours
    let v4278 : int32 = v4277 v4261
    let v4281 : bool = v4278 > 0
    let v4282 : uint8 =
        if v4281 then
            1uy
        else
            0uy
    let v4283 : string = method87()
    (* run_target_args'
    let v4354 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4355 : string = "$0.toString($1)"
    let v4356 : string = Fable.Core.RustInterop.emitRustExpr struct (v4261, v4283) v4355 
    let _run_target_args'_v4354 = v4356 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4357 : string = "$0.toString($1)"
    let v4358 : string = Fable.Core.RustInterop.emitRustExpr struct (v4261, v4283) v4357 
    let _run_target_args'_v4354 = v4358 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4359 : string = "$0.toString($1)"
    let v4360 : string = Fable.Core.RustInterop.emitRustExpr struct (v4261, v4283) v4359 
    let _run_target_args'_v4354 = v4360 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4361 : string = v4261.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4354 = v4361 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4362 : string = v4261.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4354 = v4362 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4364 : string = v4261.ToString v4283 
    let _run_target_args'_v4354 = v4364 
    #endif
#else
    let v4434 : string = v4261.ToString v4283 
    let _run_target_args'_v4354 = v4434 
    #endif
    let v4503 : string = _run_target_args'_v4354 
    let v4644 : string = $"{v4282}{v4503}"
    let v4646 : (System.Guid -> string) = _.ToString()
    let v4647 : string = v4646 v0
    let v4650 : int32 = v4009.Length
    let v4651 : int32 = v4644.Length
    let v4652 : int32 = v4650 + v4651
    let v4654 : (string -> int32) = String.length
    let v4655 : int32 = v4654 v4647
    let v4659 : int32 = 1
    let v4665 : int32 = v4652 |> int32 
    let v4678 : int32 = v4655 |> int32 
    let v4686 : int32 = v4678 - v4659
    let v4688 : string = v4647.[int v4665..int v4686]
    let v4692 : string = $"{v4009}{v4644}{v4688}"
    (* run_target_args'
    let v4697 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4699 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4699 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4703 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4703 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4707 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4697 = v4707 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4711 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4711 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4715 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4715 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4719 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4719 
    #endif
#else
    let v4723 : System.Guid = v4692 |> System.Guid 
    let _run_target_args'_v4697 = v4723 
    #endif
    let v4726 : System.Guid = _run_target_args'_v4697 
    let _run_target_args'_v741 = v4726 
    #endif
#else
    let v4735 : string = method86()
    let v4746 : bool = v4735 = ""
    let v4748 : string =
        if v4746 then
            let v4747 : string = "M-d-y hh:mm:ss tt"
            v4747
        else
            v4735
    let v4749 : (string -> string) = v1.ToString
    let v4750 : string = v4749 v4748
    (* run_target_args'
    let v4769 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4770 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4771 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4770 
    let _run_target_args'_v4769 = v4771 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4773 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4773 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4777 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4777 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4781 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4781 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4785 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4769 = v4785 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4788 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4769 = v4788 
    #endif
#else
    let v4789 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4769 = v4789 
    #endif
    let v4790 : System.TimeZoneInfo = _run_target_args'_v4769 
    (* run_target_args'
    let v4806 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v4813 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4814 : (System.DateTime -> int64) = _.Ticks
    let v4815 : int64 = v4814 v1
    let _run_target_args'_v4813 = v4815 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4816 : (System.DateTime -> int64) = _.Ticks
    let v4817 : int64 = v4816 v1
    let _run_target_args'_v4813 = v4817 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4819 : int64 = null |> unbox<int64>
    let _run_target_args'_v4813 = v4819 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4822 : (System.DateTime -> int64) = _.Ticks
    let v4823 : int64 = v4822 v1
    let _run_target_args'_v4813 = v4823 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4824 : (System.DateTime -> int64) = _.Ticks
    let v4825 : int64 = v4824 v1
    let _run_target_args'_v4813 = v4825 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4826 : (System.DateTime -> int64) = _.Ticks
    let v4827 : int64 = v4826 v1
    let _run_target_args'_v4813 = v4827 
    #endif
#else
    let v4828 : (System.DateTime -> int64) = _.Ticks
    let v4829 : int64 = v4828 v1
    let _run_target_args'_v4813 = v4829 
    #endif
    let v4830 : int64 = _run_target_args'_v4813 
    let v4851 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4852 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4830) v4851 
    let v4854 : System.TimeSpan = v4852 |> System.TimeSpan 
    let _run_target_args'_v4806 = v4854 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4863 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4864 : (System.DateTime -> int64) = _.Ticks
    let v4865 : int64 = v4864 v1
    let _run_target_args'_v4863 = v4865 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4866 : (System.DateTime -> int64) = _.Ticks
    let v4867 : int64 = v4866 v1
    let _run_target_args'_v4863 = v4867 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4869 : int64 = null |> unbox<int64>
    let _run_target_args'_v4863 = v4869 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4872 : (System.DateTime -> int64) = _.Ticks
    let v4873 : int64 = v4872 v1
    let _run_target_args'_v4863 = v4873 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4874 : (System.DateTime -> int64) = _.Ticks
    let v4875 : int64 = v4874 v1
    let _run_target_args'_v4863 = v4875 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4876 : (System.DateTime -> int64) = _.Ticks
    let v4877 : int64 = v4876 v1
    let _run_target_args'_v4863 = v4877 
    #endif
#else
    let v4878 : (System.DateTime -> int64) = _.Ticks
    let v4879 : int64 = v4878 v1
    let _run_target_args'_v4863 = v4879 
    #endif
    let v4880 : int64 = _run_target_args'_v4863 
    let v4901 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4902 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4880) v4901 
    let v4904 : System.TimeSpan = v4902 |> System.TimeSpan 
    let _run_target_args'_v4806 = v4904 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4908 : US3 = US3_2
    let v4909 : US4 = US4_4(v4908)
    let v4910 : string = $"date_time.get_utc_offset / target: {v4909}"
    let v4911 : System.TimeSpan = failwith<System.TimeSpan> v4910
    let _run_target_args'_v4806 = v4911 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4915 : US3 = US3_0
    let v4916 : US4 = US4_5(v4915)
    let v4917 : string = $"date_time.get_utc_offset / target: {v4916}"
    let v4918 : System.TimeSpan = failwith<System.TimeSpan> v4917
    let _run_target_args'_v4806 = v4918 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4922 : US3 = US3_0
    let v4923 : US4 = US4_6(v4922)
    let v4924 : string = $"date_time.get_utc_offset / target: {v4923}"
    let v4925 : System.TimeSpan = failwith<System.TimeSpan> v4924
    let _run_target_args'_v4806 = v4925 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4928 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4933 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4934 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4935 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4934 
    let _run_target_args'_v4933 = v4935 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4937 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4937 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4941 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4945 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4945 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4949 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4933 = v4949 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4952 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4933 = v4952 
    #endif
#else
    let v4953 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4933 = v4953 
    #endif
    let v4954 : System.TimeZoneInfo = _run_target_args'_v4933 
    let v4963 : (System.DateTime -> System.TimeSpan) = v4928 v4954
    let v4964 : System.TimeSpan = v4963 v1
    let _run_target_args'_v4806 = v4964 
    #endif
#else
    let v4965 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4970 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4971 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4972 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4971 
    let _run_target_args'_v4970 = v4972 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4974 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4974 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4978 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4978 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4982 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4982 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4986 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4970 = v4986 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4989 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4970 = v4989 
    #endif
#else
    let v4990 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4970 = v4990 
    #endif
    let v4991 : System.TimeZoneInfo = _run_target_args'_v4970 
    let v5000 : (System.DateTime -> System.TimeSpan) = v4965 v4991
    let v5001 : System.TimeSpan = v5000 v1
    let _run_target_args'_v4806 = v5001 
    #endif
    let v5002 : System.TimeSpan = _run_target_args'_v4806 
    let v5018 : (System.TimeSpan -> int32) = _.Hours
    let v5019 : int32 = v5018 v5002
    let v5022 : bool = v5019 > 0
    let v5023 : uint8 =
        if v5022 then
            1uy
        else
            0uy
    let v5024 : string = method87()
    (* run_target_args'
    let v5095 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5096 : string = "$0.toString($1)"
    let v5097 : string = Fable.Core.RustInterop.emitRustExpr struct (v5002, v5024) v5096 
    let _run_target_args'_v5095 = v5097 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5098 : string = "$0.toString($1)"
    let v5099 : string = Fable.Core.RustInterop.emitRustExpr struct (v5002, v5024) v5098 
    let _run_target_args'_v5095 = v5099 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5100 : string = "$0.toString($1)"
    let v5101 : string = Fable.Core.RustInterop.emitRustExpr struct (v5002, v5024) v5100 
    let _run_target_args'_v5095 = v5101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5102 : string = v5002.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v5095 = v5102 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5103 : string = v5002.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v5095 = v5103 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5105 : string = v5002.ToString v5024 
    let _run_target_args'_v5095 = v5105 
    #endif
#else
    let v5175 : string = v5002.ToString v5024 
    let _run_target_args'_v5095 = v5175 
    #endif
    let v5244 : string = _run_target_args'_v5095 
    let v5385 : string = $"{v5023}{v5244}"
    let v5387 : (System.Guid -> string) = _.ToString()
    let v5388 : string = v5387 v0
    let v5391 : int32 = v4750.Length
    let v5392 : int32 = v5385.Length
    let v5393 : int32 = v5391 + v5392
    let v5395 : (string -> int32) = String.length
    let v5396 : int32 = v5395 v5388
    let v5400 : int32 = 1
    let v5406 : int32 = v5393 |> int32 
    let v5419 : int32 = v5396 |> int32 
    let v5427 : int32 = v5419 - v5400
    let v5429 : string = v5388.[int v5406..int v5427]
    let v5433 : string = $"{v4750}{v5385}{v5429}"
    (* run_target_args'
    let v5438 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5440 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5440 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v5444 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5444 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v5448 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v5438 = v5448 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5452 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5452 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5456 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5456 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5460 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5460 
    #endif
#else
    let v5464 : System.Guid = v5433 |> System.Guid 
    let _run_target_args'_v5438 = v5464 
    #endif
    let v5467 : System.Guid = _run_target_args'_v5438 
    let _run_target_args'_v741 = v5467 
    #endif
    let v5476 : System.Guid = _run_target_args'_v741 
    v5476
and method89 () : string =
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
and method90 () : string =
    let v0 : string = "!create_temp_path_"
    v0
and method91 (v0 : string, v1 : string) : string =
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
and method93 () : string =
    let v0 : string = "CARGO_PKG_NAME"
    v0
and method92 () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = method93()
    let v6 : string = method2(v5)
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : string = method93()
    let v8 : string = method2(v7)
    let _run_target_args'_v4 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : string = method93()
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
and method88 (v0 : System.Guid) : string =
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = method89()
    let v14 : string = method90()
    let v15 : string = method91(v13, v14)
    let v16 : string = method92()
    let v17 : string = method91(v15, v16)
    let v19 : (System.Guid -> string) = _.ToString()
    let v20 : string = v19 v0
    let v23 : string = method91(v17, v20)
    let _run_target_args'_v12 = v23 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v24 : string = method89()
    let v25 : string = method90()
    let v26 : string = method91(v24, v25)
    let v27 : string = method92()
    let v28 : string = method91(v26, v27)
    let v30 : (System.Guid -> string) = _.ToString()
    let v31 : string = v30 v0
    let v34 : string = method91(v28, v31)
    let _run_target_args'_v12 = v34 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v36 : string = null |> unbox<string>
    let _run_target_args'_v12 = v36 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v39 : string = method89()
    let v40 : string = method90()
    let v41 : string = method91(v39, v40)
    let v42 : string = method92()
    let v43 : string = method91(v41, v42)
    let v45 : (System.Guid -> string) = _.ToString()
    let v46 : string = v45 v0
    let v49 : string = method91(v43, v46)
    let _run_target_args'_v12 = v49 
    #endif
#if FABLE_COMPILER_PYTHON
    let v50 : string = method89()
    let v51 : string = method90()
    let v52 : string = method91(v50, v51)
    let v53 : string = method92()
    let v54 : string = method91(v52, v53)
    let v56 : (System.Guid -> string) = _.ToString()
    let v57 : string = v56 v0
    let v60 : string = method91(v54, v57)
    let _run_target_args'_v12 = v60 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v61 : string = method89()
    let v62 : string = method90()
    let v63 : string = method91(v61, v62)
    let v64 : string = method92()
    let v65 : string = method91(v63, v64)
    let v67 : (System.Guid -> string) = _.ToString()
    let v68 : string = v67 v0
    let v71 : string = method91(v65, v68)
    let _run_target_args'_v12 = v71 
    #endif
#else
    let v72 : string = method89()
    let v73 : string = method90()
    let v74 : string = method91(v72, v73)
    let v75 : string = method92()
    let v76 : string = method91(v74, v75)
    let v78 : (System.Guid -> string) = _.ToString()
    let v79 : string = v78 v0
    let v82 : string = method91(v76, v79)
    let _run_target_args'_v12 = v82 
    #endif
    let v83 : string = _run_target_args'_v12 
    v83
and method82 () : string =
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
    let v57 : System.Guid = method83(v54, v47)
    let v58 : string = method88(v57)
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
    let v86 : System.Guid = method83(v83, v76)
    let v87 : string = method88(v86)
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
    let v119 : System.Guid = method83(v116, v109)
    let v120 : string = method88(v119)
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
    let v148 : System.Guid = method83(v145, v138)
    let v149 : string = method88(v148)
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
    let v177 : System.Guid = method83(v174, v167)
    let v178 : string = method88(v177)
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
    let v206 : System.Guid = method83(v203, v196)
    let v207 : string = method88(v206)
    let _run_target_args'_v29 = v207 
    #endif
    let v208 : string = _run_target_args'_v29 
    v208
and closure41 () () : string =
    method82()
and closure44 () (v0 : std_io_Error) : std_string_String =
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
and method95 () : (std_io_Error -> std_string_String) =
    closure44()
and closure45 () () : US14 =
    US14_0
and method96 () : (unit -> US14) =
    closure45()
and closure46 () (v0 : std_string_String) : US14 =
    US14_1(v0)
and method97 () : (std_string_String -> US14) =
    closure46()
and method99 (v0 : string, v1 : std_string_String) : string =
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
and method98 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : std_string_String) : string =
    let v10 : string = method99(v8, v9)
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
    method21(v54)
and closure47 (v0 : string, v1 : std_string_String) () : unit =
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
            let v124 : string = method49()
            let v125 : string = method98(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
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
and method101 (v0 : string) : string =
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
and method100 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string) : string =
    let v9 : string = method101(v8)
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
    method21(v53)
and closure48 (v0 : string) () : unit =
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
            let v123 : string = method31()
            let v124 : string = method100(v104, v105, v106, v107, v108, v109, v122, v123, v0)
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
and closure49 (v0 : string) () : unit =
    let v1 : bool = true
    method9(v1, v0)
and method102 (v0 : string) : (unit -> unit) =
    closure49(v0)
and method103 (v0 : string) : (unit -> unit) =
    closure49(v0)
and method104 (v0 : string) : System_IO_DirectoryInfo =
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
and method106 (v0 : string, v1 : string) : string =
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
and method105 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method106(v8, v9)
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
    method21(v54)
and closure50 (v0 : string, v1 : string) () : unit =
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
            let v125 : string = method105(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
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
and closure51 (v0 : string) () : unit =
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
and method107 (v0 : string) : (unit -> unit) =
    closure51(v0)
and method108 (v0 : string) : (unit -> unit) =
    closure51(v0)
and method94 (v0 : string) : System.IDisposable =
    (* run_target_args'
    let v736 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v737 : string = "std::fs::create_dir_all(&*$0)"
    let v738 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v737 
    let v739 : (std_io_Error -> std_string_String) = method95()
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
    let v755 : (unit -> US14) = method96()
    let v756 : (std_string_String -> US14) = method97()
    let v758 : US14 = match v752 with Ok () -> v755 () | Error x -> v756 x
    match v758 with
    | US14_1(v1389) -> (* Error *)
        let v1701 : unit = ()
        let v1702 : (unit -> unit) = closure47(v0, v1389)
        let v1703 : unit = (fun () -> v1702 (); v1701) ()
        ()
    | US14_0 -> (* Ok *)
        let v1072 : unit = ()
        let v1073 : (unit -> unit) = closure48(v0)
        let v1074 : unit = (fun () -> v1073 (); v1072) ()
        ()
    (* run_target_args'
    let v2022 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2023 : (unit -> unit) = method102(v0)
    let v2024 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2023 "$0()" )
    let _run_target_args'_v2022 = v2024 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2025 : (unit -> unit) = method102(v0)
    let v2026 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2025 "$0()" )
    let _run_target_args'_v2022 = v2026 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2027 : (unit -> unit) = method102(v0)
    let v2028 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2027 "$0()" )
    let _run_target_args'_v2022 = v2028 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2029 : (unit -> unit) = method103(v0)
    let v2030 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2029 () }
    let _run_target_args'_v2022 = v2030 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2031 : (unit -> unit) = method103(v0)
    let v2032 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2031 () }
    let _run_target_args'_v2022 = v2032 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2033 : (unit -> unit) = method103(v0)
    let v2034 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2033 () }
    let _run_target_args'_v2022 = v2034 
    #endif
#else
    let v2035 : (unit -> unit) = method103(v0)
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
    let v2052 : System_IO_DirectoryInfo = method104(v0)
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
        let v2451 : (unit -> unit) = closure50(v0, v2136)
        let v2452 : unit = (fun () -> v2451 (); v2450) ()
        ()
    (* run_target_args'
    let v2771 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2772 : (unit -> unit) = method107(v0)
    let v2773 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2772 "$0()" )
    let _run_target_args'_v2771 = v2773 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2774 : (unit -> unit) = method107(v0)
    let v2775 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2774 "$0()" )
    let _run_target_args'_v2771 = v2775 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2776 : (unit -> unit) = method107(v0)
    let v2777 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v2776 "$0()" )
    let _run_target_args'_v2771 = v2777 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2778 : (unit -> unit) = method108(v0)
    let v2779 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2778 () }
    let _run_target_args'_v2771 = v2779 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2780 : (unit -> unit) = method108(v0)
    let v2781 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2780 () }
    let _run_target_args'_v2771 = v2781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2782 : (unit -> unit) = method108(v0)
    let v2783 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2782 () }
    let _run_target_args'_v2771 = v2783 
    #endif
#else
    let v2784 : (unit -> unit) = method108(v0)
    let v2785 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v2784 () }
    let _run_target_args'_v2771 = v2785 
    #endif
    let v2786 : System.IDisposable = _run_target_args'_v2771 
    let _run_target_args'_v736 = v2786 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2793 : System_IO_DirectoryInfo = method104(v0)
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
        let v3192 : (unit -> unit) = closure50(v0, v2877)
        let v3193 : unit = (fun () -> v3192 (); v3191) ()
        ()
    (* run_target_args'
    let v3512 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3513 : (unit -> unit) = method107(v0)
    let v3514 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v3513 "$0()" )
    let _run_target_args'_v3512 = v3514 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3515 : (unit -> unit) = method107(v0)
    let v3516 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v3515 "$0()" )
    let _run_target_args'_v3512 = v3516 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3517 : (unit -> unit) = method107(v0)
    let v3518 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v3517 "$0()" )
    let _run_target_args'_v3512 = v3518 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3519 : (unit -> unit) = method108(v0)
    let v3520 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3519 () }
    let _run_target_args'_v3512 = v3520 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3521 : (unit -> unit) = method108(v0)
    let v3522 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3521 () }
    let _run_target_args'_v3512 = v3522 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3523 : (unit -> unit) = method108(v0)
    let v3524 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3523 () }
    let _run_target_args'_v3512 = v3524 
    #endif
#else
    let v3525 : (unit -> unit) = method108(v0)
    let v3526 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v3525 () }
    let _run_target_args'_v3512 = v3526 
    #endif
    let v3527 : System.IDisposable = _run_target_args'_v3512 
    let _run_target_args'_v736 = v3527 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3534 : System_IO_DirectoryInfo = method104(v0)
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
        let v3933 : (unit -> unit) = closure50(v0, v3618)
        let v3934 : unit = (fun () -> v3933 (); v3932) ()
        ()
    (* run_target_args'
    let v4253 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4254 : (unit -> unit) = method107(v0)
    let v4255 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4254 "$0()" )
    let _run_target_args'_v4253 = v4255 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4256 : (unit -> unit) = method107(v0)
    let v4257 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4256 "$0()" )
    let _run_target_args'_v4253 = v4257 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4258 : (unit -> unit) = method107(v0)
    let v4259 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4258 "$0()" )
    let _run_target_args'_v4253 = v4259 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4260 : (unit -> unit) = method108(v0)
    let v4261 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4260 () }
    let _run_target_args'_v4253 = v4261 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4262 : (unit -> unit) = method108(v0)
    let v4263 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4262 () }
    let _run_target_args'_v4253 = v4263 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4264 : (unit -> unit) = method108(v0)
    let v4265 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4264 () }
    let _run_target_args'_v4253 = v4265 
    #endif
#else
    let v4266 : (unit -> unit) = method108(v0)
    let v4267 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v4266 () }
    let _run_target_args'_v4253 = v4267 
    #endif
    let v4268 : System.IDisposable = _run_target_args'_v4253 
    let _run_target_args'_v736 = v4268 
    #endif
#else
    let v4275 : System_IO_DirectoryInfo = method104(v0)
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
        let v4674 : (unit -> unit) = closure50(v0, v4359)
        let v4675 : unit = (fun () -> v4674 (); v4673) ()
        ()
    (* run_target_args'
    let v4994 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4995 : (unit -> unit) = method107(v0)
    let v4996 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4995 "$0()" )
    let _run_target_args'_v4994 = v4996 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4997 : (unit -> unit) = method107(v0)
    let v4998 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4997 "$0()" )
    let _run_target_args'_v4994 = v4998 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4999 : (unit -> unit) = method107(v0)
    let v5000 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v4999 "$0()" )
    let _run_target_args'_v4994 = v5000 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v5001 : (unit -> unit) = method108(v0)
    let v5002 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5001 () }
    let _run_target_args'_v4994 = v5002 
    #endif
#if FABLE_COMPILER_PYTHON
    let v5003 : (unit -> unit) = method108(v0)
    let v5004 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5003 () }
    let _run_target_args'_v4994 = v5004 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v5005 : (unit -> unit) = method108(v0)
    let v5006 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5005 () }
    let _run_target_args'_v4994 = v5006 
    #endif
#else
    let v5007 : (unit -> unit) = method108(v0)
    let v5008 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v5007 () }
    let _run_target_args'_v4994 = v5008 
    #endif
    let v5009 : System.IDisposable = _run_target_args'_v4994 
    let _run_target_args'_v736 = v5009 
    #endif
    let v5016 : System.IDisposable = _run_target_args'_v736 
    v5016
and closure43 () () : struct (string * System.IDisposable) =
    let v0 : string = method82()
    let v1 : System.IDisposable = method94(v0)
    struct (v0, v1)
and closure53 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method110(v0, v1, v5)
        let v8 : string = v3 + v1 
        v6 v8
and method110 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure53(v0, v1, v2)
and method109 (v0 : string) : System.Guid =
    let v2 : (char -> string) = _.ToString()
    let v3 : string = v2 '0'
    let v6 : int32 = v0.Length
    let v7 : int32 = 32 - v6
    let v8 : int32 = 0
    let v9 : (string -> string) = method110(v7, v3, v8)
    let v10 : string = ""
    let v11 : string = v9 v10
    let v13 : string = v11 + v0 
    let v16 : string = "-"
    (* run_target_args'
    let v256 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v258 : int32 = 1
    let v264 : int32 = 0 |> int32 
    let v277 : int32 = 8 |> int32 
    let v285 : int32 = v277 - v258
    let v287 : string = v13.[int v264..int v285]
    let v292 : int32 = 1
    let v298 : int32 = 8 |> int32 
    let v311 : int32 = 12 |> int32 
    let v319 : int32 = v311 - v292
    let v321 : string = v13.[int v298..int v319]
    let v326 : int32 = 1
    let v332 : int32 = 12 |> int32 
    let v345 : int32 = 16 |> int32 
    let v353 : int32 = v345 - v326
    let v355 : string = v13.[int v332..int v353]
    let v360 : int32 = 1
    let v366 : int32 = 16 |> int32 
    let v379 : int32 = 20 |> int32 
    let v387 : int32 = v379 - v360
    let v389 : string = v13.[int v366..int v387]
    let v394 : int32 = 1
    let v400 : int32 = 20 |> int32 
    let v413 : int32 = 32 |> int32 
    let v421 : int32 = v413 - v394
    let v423 : string = v13.[int v400..int v421]
    let v428 : string = v287 + v16 
    let v432 : string = v428 + v321 
    let v436 : string = v432 + v16 
    let v440 : string = v436 + v355 
    let v444 : string = v440 + v16 
    let v448 : string = v444 + v389 
    let v452 : string = v448 + v16 
    let v456 : string = v452 + v423 
    (* run_target_args'
    let v463 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v465 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v465 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v469 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v469 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v473 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v463 = v473 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v477 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v477 
    #endif
#if FABLE_COMPILER_PYTHON
    let v481 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v481 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v485 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v485 
    #endif
#else
    let v489 : System.Guid = v456 |> System.Guid 
    let _run_target_args'_v463 = v489 
    #endif
    let v492 : System.Guid = _run_target_args'_v463 
    let _run_target_args'_v256 = v492 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v502 : int32 = 1
    let v508 : int32 = 0 |> int32 
    let v521 : int32 = 8 |> int32 
    let v529 : int32 = v521 - v502
    let v531 : string = v13.[int v508..int v529]
    let v536 : int32 = 1
    let v542 : int32 = 8 |> int32 
    let v555 : int32 = 12 |> int32 
    let v563 : int32 = v555 - v536
    let v565 : string = v13.[int v542..int v563]
    let v570 : int32 = 1
    let v576 : int32 = 12 |> int32 
    let v589 : int32 = 16 |> int32 
    let v597 : int32 = v589 - v570
    let v599 : string = v13.[int v576..int v597]
    let v604 : int32 = 1
    let v610 : int32 = 16 |> int32 
    let v623 : int32 = 20 |> int32 
    let v631 : int32 = v623 - v604
    let v633 : string = v13.[int v610..int v631]
    let v638 : int32 = 1
    let v644 : int32 = 20 |> int32 
    let v657 : int32 = 32 |> int32 
    let v665 : int32 = v657 - v638
    let v667 : string = v13.[int v644..int v665]
    let v672 : string = v531 + v16 
    let v676 : string = v672 + v565 
    let v680 : string = v676 + v16 
    let v684 : string = v680 + v599 
    let v688 : string = v684 + v16 
    let v692 : string = v688 + v633 
    let v696 : string = v692 + v16 
    let v700 : string = v696 + v667 
    (* run_target_args'
    let v707 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v709 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v709 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v713 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v713 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v717 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v707 = v717 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v721 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v721 
    #endif
#if FABLE_COMPILER_PYTHON
    let v725 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v725 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v729 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v729 
    #endif
#else
    let v733 : System.Guid = v700 |> System.Guid 
    let _run_target_args'_v707 = v733 
    #endif
    let v736 : System.Guid = _run_target_args'_v707 
    let _run_target_args'_v256 = v736 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v746 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v256 = v746 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v750 : int32 = 1
    let v756 : int32 = 0 |> int32 
    let v769 : int32 = 8 |> int32 
    let v777 : int32 = v769 - v750
    let v779 : string = v13.[int v756..int v777]
    let v784 : int32 = 1
    let v790 : int32 = 8 |> int32 
    let v803 : int32 = 12 |> int32 
    let v811 : int32 = v803 - v784
    let v813 : string = v13.[int v790..int v811]
    let v818 : int32 = 1
    let v824 : int32 = 12 |> int32 
    let v837 : int32 = 16 |> int32 
    let v845 : int32 = v837 - v818
    let v847 : string = v13.[int v824..int v845]
    let v852 : int32 = 1
    let v858 : int32 = 16 |> int32 
    let v871 : int32 = 20 |> int32 
    let v879 : int32 = v871 - v852
    let v881 : string = v13.[int v858..int v879]
    let v886 : int32 = 1
    let v892 : int32 = 20 |> int32 
    let v905 : int32 = 32 |> int32 
    let v913 : int32 = v905 - v886
    let v915 : string = v13.[int v892..int v913]
    let v920 : string = v779 + v16 
    let v924 : string = v920 + v813 
    let v928 : string = v924 + v16 
    let v932 : string = v928 + v847 
    let v936 : string = v932 + v16 
    let v940 : string = v936 + v881 
    let v944 : string = v940 + v16 
    let v948 : string = v944 + v915 
    (* run_target_args'
    let v955 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v957 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v957 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v961 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v961 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v965 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v955 = v965 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v969 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v969 
    #endif
#if FABLE_COMPILER_PYTHON
    let v973 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v973 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v977 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v977 
    #endif
#else
    let v981 : System.Guid = v948 |> System.Guid 
    let _run_target_args'_v955 = v981 
    #endif
    let v984 : System.Guid = _run_target_args'_v955 
    let _run_target_args'_v256 = v984 
    #endif
#if FABLE_COMPILER_PYTHON
    let v994 : int32 = 1
    let v1000 : int32 = 0 |> int32 
    let v1013 : int32 = 8 |> int32 
    let v1021 : int32 = v1013 - v994
    let v1023 : string = v13.[int v1000..int v1021]
    let v1028 : int32 = 1
    let v1034 : int32 = 8 |> int32 
    let v1047 : int32 = 12 |> int32 
    let v1055 : int32 = v1047 - v1028
    let v1057 : string = v13.[int v1034..int v1055]
    let v1062 : int32 = 1
    let v1068 : int32 = 12 |> int32 
    let v1081 : int32 = 16 |> int32 
    let v1089 : int32 = v1081 - v1062
    let v1091 : string = v13.[int v1068..int v1089]
    let v1096 : int32 = 1
    let v1102 : int32 = 16 |> int32 
    let v1115 : int32 = 20 |> int32 
    let v1123 : int32 = v1115 - v1096
    let v1125 : string = v13.[int v1102..int v1123]
    let v1130 : int32 = 1
    let v1136 : int32 = 20 |> int32 
    let v1149 : int32 = 32 |> int32 
    let v1157 : int32 = v1149 - v1130
    let v1159 : string = v13.[int v1136..int v1157]
    let v1164 : string = v1023 + v16 
    let v1168 : string = v1164 + v1057 
    let v1172 : string = v1168 + v16 
    let v1176 : string = v1172 + v1091 
    let v1180 : string = v1176 + v16 
    let v1184 : string = v1180 + v1125 
    let v1188 : string = v1184 + v16 
    let v1192 : string = v1188 + v1159 
    (* run_target_args'
    let v1199 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1201 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1201 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1205 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1205 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1209 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1199 = v1209 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1213 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1213 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1217 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1217 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1221 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1221 
    #endif
#else
    let v1225 : System.Guid = v1192 |> System.Guid 
    let _run_target_args'_v1199 = v1225 
    #endif
    let v1228 : System.Guid = _run_target_args'_v1199 
    let _run_target_args'_v256 = v1228 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1238 : int32 = 1
    let v1244 : int32 = 0 |> int32 
    let v1257 : int32 = 8 |> int32 
    let v1265 : int32 = v1257 - v1238
    let v1267 : string = v13.[int v1244..int v1265]
    let v1272 : int32 = 1
    let v1278 : int32 = 8 |> int32 
    let v1291 : int32 = 12 |> int32 
    let v1299 : int32 = v1291 - v1272
    let v1301 : string = v13.[int v1278..int v1299]
    let v1306 : int32 = 1
    let v1312 : int32 = 12 |> int32 
    let v1325 : int32 = 16 |> int32 
    let v1333 : int32 = v1325 - v1306
    let v1335 : string = v13.[int v1312..int v1333]
    let v1340 : int32 = 1
    let v1346 : int32 = 16 |> int32 
    let v1359 : int32 = 20 |> int32 
    let v1367 : int32 = v1359 - v1340
    let v1369 : string = v13.[int v1346..int v1367]
    let v1374 : int32 = 1
    let v1380 : int32 = 20 |> int32 
    let v1393 : int32 = 32 |> int32 
    let v1401 : int32 = v1393 - v1374
    let v1403 : string = v13.[int v1380..int v1401]
    let v1408 : string = v1267 + v16 
    let v1412 : string = v1408 + v1301 
    let v1416 : string = v1412 + v16 
    let v1420 : string = v1416 + v1335 
    let v1424 : string = v1420 + v16 
    let v1428 : string = v1424 + v1369 
    let v1432 : string = v1428 + v16 
    let v1436 : string = v1432 + v1403 
    (* run_target_args'
    let v1443 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1445 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1445 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1449 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1449 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1453 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1443 = v1453 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1457 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1457 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1461 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1461 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1465 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1465 
    #endif
#else
    let v1469 : System.Guid = v1436 |> System.Guid 
    let _run_target_args'_v1443 = v1469 
    #endif
    let v1472 : System.Guid = _run_target_args'_v1443 
    let _run_target_args'_v256 = v1472 
    #endif
#else
    let v1482 : int32 = 1
    let v1488 : int32 = 0 |> int32 
    let v1501 : int32 = 8 |> int32 
    let v1509 : int32 = v1501 - v1482
    let v1511 : string = v13.[int v1488..int v1509]
    let v1516 : int32 = 1
    let v1522 : int32 = 8 |> int32 
    let v1535 : int32 = 12 |> int32 
    let v1543 : int32 = v1535 - v1516
    let v1545 : string = v13.[int v1522..int v1543]
    let v1550 : int32 = 1
    let v1556 : int32 = 12 |> int32 
    let v1569 : int32 = 16 |> int32 
    let v1577 : int32 = v1569 - v1550
    let v1579 : string = v13.[int v1556..int v1577]
    let v1584 : int32 = 1
    let v1590 : int32 = 16 |> int32 
    let v1603 : int32 = 20 |> int32 
    let v1611 : int32 = v1603 - v1584
    let v1613 : string = v13.[int v1590..int v1611]
    let v1618 : int32 = 1
    let v1624 : int32 = 20 |> int32 
    let v1637 : int32 = 32 |> int32 
    let v1645 : int32 = v1637 - v1618
    let v1647 : string = v13.[int v1624..int v1645]
    let v1652 : string = v1511 + v16 
    let v1656 : string = v1652 + v1545 
    let v1660 : string = v1656 + v16 
    let v1664 : string = v1660 + v1579 
    let v1668 : string = v1664 + v16 
    let v1672 : string = v1668 + v1613 
    let v1676 : string = v1672 + v16 
    let v1680 : string = v1676 + v1647 
    (* run_target_args'
    let v1687 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1689 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1689 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1693 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1693 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1697 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1687 = v1697 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1701 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1701 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1705 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1705 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1709 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1709 
    #endif
#else
    let v1713 : System.Guid = v1680 |> System.Guid 
    let _run_target_args'_v1687 = v1713 
    #endif
    let v1716 : System.Guid = _run_target_args'_v1687 
    let _run_target_args'_v256 = v1716 
    #endif
    let v1725 : System.Guid = _run_target_args'_v256 
    v1725
and closure52 () (v0 : string) : struct (string * System.IDisposable) =
    let v1 : System.Guid = method109(v0)
    let v2 : string = method88(v1)
    let v3 : System.IDisposable = method94(v2)
    struct (v2, v3)
and closure54 () () : string =
    let v0 : string = __SOURCE_DIRECTORY__
    v0
and closure56 () (v0 : std_path_PathBuf) : US15 =
    US15_0(v0)
and method114 () : (std_path_PathBuf -> US15) =
    closure56()
and closure57 () (v0 : string) : US15 =
    US15_1(v0)
and method115 () : (string -> US15) =
    closure57()
and method118 (v0 : string) : string option =
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
and method119 (v0 : string) : string =
    let v1 : string = method17()
    let v2 : Mut3 = {l0 = v1} : Mut3
    let v4 : string = $"{v0}"
    let v12 : unit = ()
    let v13 : (unit -> unit) = closure6(v2, v4)
    let v14 : unit = (fun () -> v13 (); v12) ()
    let v20 : string = v2.l0
    v20
and method117 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method18(v4)
    let v6 : string option = method118(v4)
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method119(v3)
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
                let v101 : (std_io_Error -> string) = method45()
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
                let v117 : (std_path_PathBuf -> US15) = method114()
                let v118 : (string -> US15) = method115()
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
                    let v164 : string = method91(v161, v5)
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
and method116 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v7 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v8 : string = "std::fs::read_link(&*$0)"
    let v9 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v2 v8 
    let v10 : (std_io_Error -> string) = method45()
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
    let v26 : (std_path_PathBuf -> US15) = method114()
    let v27 : (string -> US15) = method115()
    let v29 : US15 = match v23 with Ok x -> v26 x | Error x -> v27 x
    let v52 : Result<std_path_PathBuf, std_io_Error> =
        match v29 with
        | US15_1(v48) -> (* Error *)
            let v49 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure58(v0)
            method117(v0, v49, v1, v48, v2)
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
    let v55 : (std_io_Error -> string) = method45()
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
    let v71 : (std_path_PathBuf -> US15) = method114()
    let v72 : (string -> US15) = method115()
    let v74 : US15 = match v68 with Ok x -> v71 x | Error x -> v72 x
    let v97 : Result<std_path_PathBuf, std_io_Error> =
        match v74 with
        | US15_1(v93) -> (* Error *)
            let v94 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure58(v0)
            method117(v0, v94, v1, v93, v2)
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
    let v100 : (std_io_Error -> string) = method45()
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
    let v116 : (std_path_PathBuf -> US15) = method114()
    let v117 : (string -> US15) = method115()
    let v119 : US15 = match v113 with Ok x -> v116 x | Error x -> v117 x
    let v142 : Result<std_path_PathBuf, std_io_Error> =
        match v119 with
        | US15_1(v138) -> (* Error *)
            let v139 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure58(v0)
            method117(v0, v139, v1, v138, v2)
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
and closure59 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method116(v0, v1, v2)
and closure58 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure59(v0, v1)
and method120 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method18(v0)
    let v5 : string option = method118(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method119(v3)
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
                let v100 : (std_io_Error -> string) = method45()
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
                let v116 : (std_path_PathBuf -> US15) = method114()
                let v117 : (string -> US15) = method115()
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
                    let v163 : string = method91(v160, v4)
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
and method113 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
    (* run_target_args'
    let v6 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = "std::fs::read_link(&*$0)"
    let v8 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v7 
    let v9 : (std_io_Error -> string) = method45()
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
    let v25 : (std_path_PathBuf -> US15) = method114()
    let v26 : (string -> US15) = method115()
    let v28 : US15 = match v22 with Ok x -> v25 x | Error x -> v26 x
    let v51 : Result<std_path_PathBuf, std_io_Error> =
        match v28 with
        | US15_1(v47) -> (* Error *)
            let v48 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure58(v0)
            method120(v0, v48, v1, v47)
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
    let v54 : (std_io_Error -> string) = method45()
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
    let v70 : (std_path_PathBuf -> US15) = method114()
    let v71 : (string -> US15) = method115()
    let v73 : US15 = match v67 with Ok x -> v70 x | Error x -> v71 x
    let v96 : Result<std_path_PathBuf, std_io_Error> =
        match v73 with
        | US15_1(v92) -> (* Error *)
            let v93 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure58(v0)
            method120(v0, v93, v1, v92)
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
    let v99 : (std_io_Error -> string) = method45()
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
    let v115 : (std_path_PathBuf -> US15) = method114()
    let v116 : (string -> US15) = method115()
    let v118 : US15 = match v112 with Ok x -> v115 x | Error x -> v116 x
    let v141 : Result<std_path_PathBuf, std_io_Error> =
        match v118 with
        | US15_1(v137) -> (* Error *)
            let v138 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure58(v0)
            method120(v0, v138, v1, v137)
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
and method122 (v0 : System_IO_DirectoryInfo) : System.IO.FileAttributes =
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
and method123 () : System.IO.FileAttributes =
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
and method124 (v0 : System.IO.FileAttributes, v1 : System.IO.FileAttributes) : bool =
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
and method126 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error, v4 : string) : Result<std_path_PathBuf, std_io_Error> =
    let v5 : string = method18(v4)
    let v6 : string option = method118(v4)
    let v9 : (string -> US5) = method5()
    let v10 : US5 option = v6 |> Option.map v9 
    let v30 : US5 = US5_1
    let v31 : US5 = v10 |> Option.defaultValue v30 
    let v35 : string = method46(v3)
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
                let v101 : (std_io_Error -> string) = method45()
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
                let v117 : (std_path_PathBuf -> US15) = method114()
                let v118 : (string -> US15) = method115()
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
                    let v164 : string = method91(v161, v5)
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
and method125 (v0 : string, v1 : uint8, v2 : string) : Result<std_path_PathBuf, std_io_Error> =
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
    let v45 : System.IO.FileAttributes = method122(v36)
    let v46 : System.IO.FileAttributes = method123()
    let v47 : bool = method124(v46, v45)
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
        let v190 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure60(v0)
        method126(v0, v190, v1, v181, v2)
and closure61 (v0 : string, v1 : uint8) (v2 : string) : Result<std_path_PathBuf, std_io_Error> =
    method125(v0, v1, v2)
and closure60 (v0 : string) (v1 : uint8) : (string -> Result<std_path_PathBuf, std_io_Error>) =
    closure61(v0, v1)
and method127 (v0 : string, v1 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)), v2 : uint8, v3 : std_io_Error) : Result<std_path_PathBuf, std_io_Error> =
    let v4 : string = method18(v0)
    let v5 : string option = method118(v0)
    let v8 : (string -> US5) = method5()
    let v9 : US5 option = v5 |> Option.map v8 
    let v29 : US5 = US5_1
    let v30 : US5 = v9 |> Option.defaultValue v29 
    let v34 : string = method46(v3)
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
                let v100 : (std_io_Error -> string) = method45()
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
                let v116 : (std_path_PathBuf -> US15) = method114()
                let v117 : (string -> US15) = method115()
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
                    let v163 : string = method91(v160, v4)
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
and method121 (v0 : string, v1 : uint8) : Result<std_path_PathBuf, std_io_Error> =
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
    let v44 : System.IO.FileAttributes = method122(v35)
    let v45 : System.IO.FileAttributes = method123()
    let v46 : bool = method124(v45, v44)
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
        let v189 : (uint8 -> (string -> Result<std_path_PathBuf, std_io_Error>)) = closure60(v0)
        method127(v0, v189, v1, v180)
and method112 (v0 : string) : Result<std_path_PathBuf, std_io_Error> =
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
            method113(v0, v6)
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
            method113(v0, v12)
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
            method113(v0, v18)
    let _run_target_args'_v2 = v20 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v21 : uint8 = 0uy
    let v22 : Result<std_path_PathBuf, std_io_Error> = method121(v0, v21)
    let _run_target_args'_v2 = v22 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : Result<std_path_PathBuf, std_io_Error> = Unchecked.defaultof<_>
    let _run_target_args'_v2 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v24 : uint8 = 0uy
    let v25 : Result<std_path_PathBuf, std_io_Error> = method121(v0, v24)
    let _run_target_args'_v2 = v25 
    #endif
#else
    let v26 : uint8 = 0uy
    let v27 : Result<std_path_PathBuf, std_io_Error> = method121(v0, v26)
    let _run_target_args'_v2 = v27 
    #endif
    let v28 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v2 
    v28
and closure62 () (v0 : std_path_PathBuf) : US16 =
    US16_0(v0)
and method128 () : (std_path_PathBuf -> US16) =
    closure62()
and method130 (v0 : string) : string =
    v0
and method131 () : string =
    let v0 : string = ""
    v0
and method129 (v0 : string, v1 : string, v2 : string) : string =
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
    let v22 : string = method130(v2)
    let v23 : string = $"$0.replace_all(&*$1, &*$2)"
    let v24 : std_borrow_Cow<Str> = Fable.Core.RustInterop.emitRustExpr struct (v19, v22, v1) v23 
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v4 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = method131()
    let _run_target_args'_v4 = v29 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v30 : string = method131()
    let _run_target_args'_v4 = v30 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v31 : string = method131()
    let _run_target_args'_v4 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : string = method131()
    let _run_target_args'_v4 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v33 : string = method131()
    let _run_target_args'_v4 = v33 
    #endif
#else
    let v34 : string = System.Text.RegularExpressions.Regex.Replace (v2, v0, v1)
    let _run_target_args'_v4 = v34 
    #endif
    let v35 : string = _run_target_args'_v4 
    v35
and method111 (v0 : string) : string =
    let v1 : bool = v0 = ""
    if v1 then
        let v2 : string = ""
        v2
    else
        let v3 : Result<std_path_PathBuf, std_io_Error> = method112(v0)
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
        let v21 : (std_path_PathBuf -> US16) = method128()
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
        let v94 : string = method129(v92, v93, v91)
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
and closure55 () (v0 : string) : string =
    method111(v0)
and method133 () : string =
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
and method134 (v0 : int32, v1 : Mut5) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method135 (v0 : int32, v1 : Mut6) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method136 () : char =
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
and method137 (v0 : string) : string =
    v0
and method132 (v0 : string) : string =
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
    let v315 : string =
        if v116 then
            let v117 : string = method133()
            let v118 : string = method91(v117, v0)
            let v119 : string = method111(v118)
            let v130 : string = "/"
            let v131 : (string []) = v119.Split v130 
            let v134 : (string []) = [||]
            let v135 : int32 = v131.Length
            let v136 : Mut5 = {l0 = 0; l1 = 0; l2 = v134} : Mut5
            while method134(v135, v136) do
                let v138 : int32 = v136.l0
                let v139 : int32 =  -v138
                let v140 : int32 = v139 + v135
                let v141 : int32 = v140 - 1
                let struct (v142 : int32, v143 : (string [])) = v136.l1, v136.l2
                let v144 : string = v131.[int v141]
                let v145 : bool = ".." = v144
                let struct (v191 : int32, v192 : (string [])) =
                    if v145 then
                        let v146 : int32 = v142 + 1
                        struct (v146, v143)
                    else
                        let v147 : bool = "." = v144
                        if v147 then
                            struct (v142, v143)
                        else
                            let v148 : bool = 0 = v142
                            if v148 then
                                let v151 : string = ":"
                                let v152 : bool = v144.EndsWith (v151, false, null)
                                if v152 then
                                    let v155 : string = $"{v117.[0]}:"
                                    let v156 : (string []) = [|v155|]
                                    let v157 : int32 = v156.Length
                                    let v158 : int32 = v143.Length
                                    let v159 : int32 = v157 + v158
                                    let v160 : (string []) = Array.zeroCreate<string> (v159)
                                    let v161 : Mut6 = {l0 = 0} : Mut6
                                    while method135(v159, v161) do
                                        let v163 : int32 = v161.l0
                                        let v164 : bool = v163 < v157
                                        let v168 : string =
                                            if v164 then
                                                let v165 : string = v156.[int v163]
                                                v165
                                            else
                                                let v166 : int32 = v163 - v157
                                                let v167 : string = v143.[int v166]
                                                v167
                                        v160.[int v163] <- v168
                                        let v169 : int32 = v163 + 1
                                        v161.l0 <- v169
                                        ()
                                    struct (0, v160)
                                else
                                    let v170 : (string []) = [|v144|]
                                    let v171 : int32 = v170.Length
                                    let v172 : int32 = v143.Length
                                    let v173 : int32 = v171 + v172
                                    let v174 : (string []) = Array.zeroCreate<string> (v173)
                                    let v175 : Mut6 = {l0 = 0} : Mut6
                                    while method135(v173, v175) do
                                        let v177 : int32 = v175.l0
                                        let v178 : bool = v177 < v171
                                        let v182 : string =
                                            if v178 then
                                                let v179 : string = v170.[int v177]
                                                v179
                                            else
                                                let v180 : int32 = v177 - v171
                                                let v181 : string = v143.[int v180]
                                                v181
                                        v174.[int v177] <- v182
                                        let v183 : int32 = v177 + 1
                                        v175.l0 <- v183
                                        ()
                                    struct (0, v174)
                            else
                                let v186 : int32 = v142 - 1
                                struct (v186, v143)
                let v193 : int32 = v138 + 1
                v136.l0 <- v193
                v136.l1 <- v191
                v136.l2 <- v192
                ()
            let struct (v194 : int32, v195 : (string [])) = v136.l1, v136.l2
            let v200 : unit = ()
            let _let'_v200 =
                seq {
                    for i = 0 to v195.Length - 1 do yield v195.[i]
                    (* indent
                    ()
                indent *)
                }
                (* indent
                ()
            indent *)
            let v203 : string seq = _let'_v200 
            let v209 : char = method136()
            let v211 : (char -> string) = _.ToString()
            let v212 : string = v211 v209
            let v216 : bool = v212 = "\n"
            let v218 : string =
                if v216 then
                    method137(v212)
                else
                    v212
            let v219 : (string -> (string seq -> string)) = String.concat
            let v220 : (string seq -> string) = v219 v218
            v220 v203
        else
            let v224 : string = "std::fs::canonicalize(&*$0)"
            let v225 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v224 
            (* run_target_args'
            let v227 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v228 : string = "$0.unwrap()"
            let v229 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v225 v228 
            let _run_target_args'_v227 = v229 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v230 : string = "$0.unwrap()"
            let v231 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v225 v230 
            let _run_target_args'_v227 = v231 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v232 : string = "$0.unwrap()"
            let v233 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v225 v232 
            let _run_target_args'_v227 = v233 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v234 : std_path_PathBuf = match v225 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v227 = v234 
            #endif
#if FABLE_COMPILER_PYTHON
            let v235 : std_path_PathBuf = match v225 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v227 = v235 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v236 : std_path_PathBuf = match v225 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v227 = v236 
            #endif
#else
            let v237 : std_path_PathBuf = match v225 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
            let _run_target_args'_v227 = v237 
            #endif
            let v238 : std_path_PathBuf = _run_target_args'_v227 
            (* run_target_args'
            let v245 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v246 : string = "$0.display()"
            let v247 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v238 v246 
            let _run_target_args'_v245 = v247 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v248 : string = "$0.display()"
            let v249 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v238 v248 
            let _run_target_args'_v245 = v249 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v250 : string = "$0.display()"
            let v251 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v238 v250 
            let _run_target_args'_v245 = v251 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v253 : std_path_Display = v238 |> unbox<std_path_Display>
            let _run_target_args'_v245 = v253 
            #endif
#if FABLE_COMPILER_PYTHON
            let v257 : std_path_Display = v238 |> unbox<std_path_Display>
            let _run_target_args'_v245 = v257 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v261 : std_path_Display = v238 |> unbox<std_path_Display>
            let _run_target_args'_v245 = v261 
            #endif
#else
            let v265 : std_path_Display = v238 |> unbox<std_path_Display>
            let _run_target_args'_v245 = v265 
            #endif
            let v268 : std_path_Display = _run_target_args'_v245 
            (* run_target_args'
            let v281 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v282 : string = "format!(\"{}\", $0)"
            let v283 : std_string_String = Fable.Core.RustInterop.emitRustExpr v268 v282 
            let _run_target_args'_v281 = v283 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v284 : string = "format!(\"{}\", $0)"
            let v285 : std_string_String = Fable.Core.RustInterop.emitRustExpr v268 v284 
            let _run_target_args'_v281 = v285 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v286 : string = "format!(\"{}\", $0)"
            let v287 : std_string_String = Fable.Core.RustInterop.emitRustExpr v268 v286 
            let _run_target_args'_v281 = v287 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v289 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v281 = v289 
            #endif
#if FABLE_COMPILER_PYTHON
            let v293 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v281 = v293 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v297 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v281 = v297 
            #endif
#else
            let v301 : std_string_String = null |> unbox<std_string_String>
            let _run_target_args'_v281 = v301 
            #endif
            let v304 : std_string_String = _run_target_args'_v281 
            let v313 : string = "fable_library_rust::String_::fromString($0)"
            let v314 : string = Fable.Core.RustInterop.emitRustExpr v304 v313 
            v314
    let _run_target_args'_v5 = v315 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v317 : string = null |> unbox<string>
    let _run_target_args'_v5 = v317 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v321 : string = null |> unbox<string>
    let _run_target_args'_v5 = v321 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v325 : string = null |> unbox<string>
    let _run_target_args'_v5 = v325 
    #endif
#if FABLE_COMPILER_PYTHON
    let v329 : string = null |> unbox<string>
    let _run_target_args'_v5 = v329 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v333 : string = null |> unbox<string>
    let _run_target_args'_v5 = v333 
    #endif
#else
    let v336 : (string -> string) = System.IO.Path.GetFullPath
    let v337 : string = v336 v0
    let _run_target_args'_v5 = v337 
    #endif
    let v338 : string = _run_target_args'_v5 
    v338
and closure63 () (v0 : string) : string =
    method132(v0)
and method138 (v0 : string) : string =
    let v1 : string = method132(v0)
    method111(v1)
and closure64 () (v0 : string) : string =
    method138(v0)
and closure65 () (v0 : string) : string =
    let v1 : char list = []
    let v3 : char list = '/' :: v1 
    let v12 : (char list -> (char [])) = List.toArray
    let v13 : (char []) = v12 v3
    let v16 : string = v0.TrimStart v13 
    let v50 : string = $"file:///{v16}"
    v50
and closure67 () (v0 : string) : bool =
    method35(v0)
and closure68 () (v0 : string) : bool =
    method10(v0)
and method142 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool), v4 : string) : US18 =
    let v5 : string = method91(v4, v0)
    let v6 : bool = v3 v5
    if v6 then
        US18_0(v4)
    else
        let v8 : string option = method118(v4)
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
            method142(v0, v1, v2, v3, v37)
and method141 (v0 : string, v1 : string, v2 : bool, v3 : (string -> bool)) : US18 =
    let v4 : string = method91(v1, v0)
    let v5 : bool = v3 v4
    if v5 then
        US18_0(v1)
    else
        let v7 : string option = method118(v1)
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
            method142(v0, v1, v2, v3, v36)
and method140 (v0 : US17, v1 : string, v2 : string) : US18 =
    let v3 : bool =
        match v0 with
        | US17_0 -> (* File *)
            true
        | _ ->
            false
    let v6 : (string -> bool) =
        if v3 then
            closure67()
        else
            closure68()
    method141(v1, v2, v3, v6)
and method144 (v0 : string, v1 : string) : string =
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
and method143 (v0 : Mut0, v1 : Mut1, v2 : Mut2, v3 : Mut3, v4 : Mut4, v5 : int64 option, v6 : string, v7 : string, v8 : string, v9 : string) : string =
    let v10 : string = method144(v8, v9)
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
    method21(v54)
and closure69 (v0 : string, v1 : string) () : unit =
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
            let v124 : string = method52()
            let v125 : string = method143(v105, v106, v107, v108, v109, v110, v123, v124, v0, v1)
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
and method139 (v0 : string) : US5 =
    let v1 : US17 = US17_1
    let v2 : string = "spiral"
    let v3 : string = "workspace"
    let v4 : string = method91(v2, v3)
    let v5 : US18 = method140(v1, v4, v0)
    match v5 with
    | US18_1(v9) -> (* Error *)
        let v321 : unit = ()
        let v322 : (unit -> unit) = closure69(v0, v9)
        let v323 : unit = (fun () -> v322 (); v321) ()
        US5_1
    | US18_0(v6) -> (* Ok *)
        let v7 : string = method111(v6)
        US5_0(v7)
and closure66 () () : string =
    let v0 : string = method133()
    let v1 : US5 = method139(v0)
    let v7 : US5 =
        match v1 with
        | US5_1 -> (* None *)
            let v4 : string = __SOURCE_DIRECTORY__
            method139(v4)
        | US5_0(v2) -> (* Some *)
            US5_0(v2)
    let v13 : US5 =
        match v7 with
        | US5_1 -> (* None *)
            let v10 : string = "/workspaces"
            method139(v10)
        | US5_0(v8) -> (* Some *)
            US5_0(v8)
    let v17 : string =
        match v13 with
        | US5_1 -> (* None *)
            failwith<string> "Option does not have a value."
        | US5_0(v14) -> (* Some *)
            v14
    let v18 : string = method18(v17)
    let v19 : bool = "deps" = v18
    let v30 : string =
        if v19 then
            let v20 : string option = method118(v17)
            let v22 : string = v20 |> Option.get
            let v25 : US5 = method139(v22)
            match v25 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v26) -> (* Some *)
                v26
        else
            v17
    let v31 : string = "polyglot"
    method91(v30, v31)
and closure71 (v0 : exn) () : exn =
    v0
and method145 (v0 : string) : unit =
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
        let v74 : string = method92()
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
        let v102 : System.Guid = method83(v99, v92)
        let v103 : string = $"{v74}_{v102}.txt"
        let v104 : string = method133()
        let v105 : US5 = method139(v104)
        let v111 : US5 =
            match v105 with
            | US5_1 -> (* None *)
                let v108 : string = __SOURCE_DIRECTORY__
                method139(v108)
            | US5_0(v106) -> (* Some *)
                US5_0(v106)
        let v117 : US5 =
            match v111 with
            | US5_1 -> (* None *)
                let v114 : string = "/workspaces"
                method139(v114)
            | US5_0(v112) -> (* Some *)
                US5_0(v112)
        let v121 : string =
            match v117 with
            | US5_1 -> (* None *)
                failwith<string> "Option does not have a value."
            | US5_0(v118) -> (* Some *)
                v118
        let v122 : string = method18(v121)
        let v123 : bool = "deps" = v122
        let v134 : string =
            if v123 then
                let v124 : string option = method118(v121)
                let v126 : string = v124 |> Option.get
                let v129 : US5 = method139(v126)
                match v129 with
                | US5_1 -> (* None *)
                    failwith<string> "Option does not have a value."
                | US5_0(v130) -> (* Some *)
                    v130
            else
                v121
        let v135 : string = "polyglot"
        let v136 : string = method91(v134, v135)
        let v137 : string = "target/trace"
        let v138 : string = method91(v136, v137)
        let v139 : System_IO_DirectoryInfo = method104(v138)
        let v140 : string = method91(v138, v103)
        let v141 : Async<unit> = method37(v140, v0)
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
        let v227 : (unit -> exn) = closure71(v226)
        let v228 : string = $"file_system.trace_file / ex: %A{v227}"
        let v230 : unit = ()
        let v231 : (unit -> unit) = closure9(v228)
        let v232 : unit = (fun () -> v231 (); v230) ()
        method145(v228)
        (* indent
        ()
    indent *)
    (* try_unit
    try_unit *)
    #endif
    // run_target_args' is_unit
    ()
and closure70 () (v0 : string) : unit =
    method145(v0)
and closure72 () (v0 : bool) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure0()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v40 : Mut0, v41 : Mut1, v42 : Mut2, v43 : Mut3, v44 : Mut4, v45 : int64 option) = TraceState.trace_state.Value
    let v60 : (string -> unit) =
        if v0 then
            closure70()
        else
            closure2()
    v41.l0 <- v60
    ()
and method146 (v0 : string, v1 : string) : unit =
    let v2 : bool = method10(v0)
    let v3 : bool = v2 = false
    if v3 then
        let v4 : System.IDisposable = method94(v0)
        ()
    let v5 : string option = method118(v1)
    let v8 : string = ""
    let v9 : string = v5 |> Option.defaultValue v8 
    let v12 : bool = method10(v9)
    let v13 : bool = v12 = false
    if v13 then
        let v14 : System.IDisposable = method94(v9)
        ()
    let v15 : bool = method10(v1)
    let v25 : bool =
        if v15 then
            let v16 : Result<std_path_PathBuf, std_io_Error> = method112(v1)
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
and closure74 (v0 : string) (v1 : string) : unit =
    method146(v0, v1)
and closure73 () (v0 : string) : (string -> unit) =
    closure74(v0)
and closure76 (v0 : string) (v1 : string) : string =
    method91(v0, v1)
and closure75 () (v0 : string) : (string -> string) =
    closure76(v0)
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
let v41 : (unit -> string) = closure41()
let create_temp_path () = v41 ()
let v42 : (unit -> struct (string * System.IDisposable)) = closure43()
let create_temp_dir () = v42 ()
let v43 : (string -> struct (string * System.IDisposable)) = closure52()
let create_temp_dir' x = v43 x
let v44 : (unit -> string) = closure54()
let get_source_directory () = v44 ()
let v45 : (string -> string) = closure55()
let normalize_path x = v45 x
let v46 : (string -> string) = closure63()
let get_full_path x = v46 x
let v47 : (string -> string) = closure64()
let standardize_path x = v47 x
let v48 : (string -> string) = closure65()
let new_file_uri x = v48 x
let v49 : (unit -> string) = closure66()
let get_workspace_root () = v49 ()
let v50 : (string -> unit) = closure70()
let trace_file x = v50 x
let v51 : (bool -> unit) = closure72()
let init_trace_file x = v51 x
let v52 : (string -> (string -> unit)) = closure73()
let link_directory x = v52 x
let v53 : (string -> (string -> string)) = closure75()
let (</>) x = v53 x
()
