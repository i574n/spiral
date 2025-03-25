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
    let v209 : US2 =
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
            let v203 : int64 = v182 |> int64 
            US2_0(v203)
    struct (v127, v209)
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
    let v187 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v190 : (int64 -> US2) = method13()
    let v191 : US2 option = v5 |> Option.map v190 
    let v211 : US2 = US2_1
    let v212 : US2 = v191 |> Option.defaultValue v211 
    let v344 : System.DateTime =
        match v212 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v327 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v328 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v328 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v329 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v329 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v331 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v327 = v331 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v334 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v334 
            #endif
#if FABLE_COMPILER_PYTHON
            let v335 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v335 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v336 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v336 
            #endif
#else
            let v337 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v327 = v337 
            #endif
            let v338 : System.DateTime = _run_target_args'_v327 
            v338
        | US2_0(v216) -> (* Some *)
            (* run_target_args'
            let v223 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v224 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v224 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v225 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v225 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v227 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v223 = v227 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v230 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v230 
            #endif
#if FABLE_COMPILER_PYTHON
            let v231 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v231 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v232 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v232 
            #endif
#else
            let v233 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v223 = v233 
            #endif
            let v234 : System.DateTime = _run_target_args'_v223 
            (* run_target_args'
            let v245 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v246 : (System.DateTime -> int64) = _.Ticks
            let v247 : int64 = v246 v234
            let _run_target_args'_v245 = v247 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v248 : (System.DateTime -> int64) = _.Ticks
            let v249 : int64 = v248 v234
            let _run_target_args'_v245 = v249 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v251 : int64 = null |> unbox<int64>
            let _run_target_args'_v245 = v251 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v254 : (System.DateTime -> int64) = _.Ticks
            let v255 : int64 = v254 v234
            let _run_target_args'_v245 = v255 
            #endif
#if FABLE_COMPILER_PYTHON
            let v256 : (System.DateTime -> int64) = _.Ticks
            let v257 : int64 = v256 v234
            let _run_target_args'_v245 = v257 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v258 : (System.DateTime -> int64) = _.Ticks
            let v259 : int64 = v258 v234
            let _run_target_args'_v245 = v259 
            #endif
#else
            let v260 : (System.DateTime -> int64) = _.Ticks
            let v261 : int64 = v260 v234
            let _run_target_args'_v245 = v261 
            #endif
            let v262 : int64 = _run_target_args'_v245 
            let v283 : int64 = v262 |> int64 
            let v286 : int64 = v283 - v216
            let v292 : System.TimeSpan = v286 |> System.TimeSpan 
            let v298 : (System.TimeSpan -> int32) = _.Hours
            let v299 : int32 = v298 v292
            let v303 : (System.TimeSpan -> int32) = _.Minutes
            let v304 : int32 = v303 v292
            let v308 : (System.TimeSpan -> int32) = _.Seconds
            let v309 : int32 = v308 v292
            let v313 : (System.TimeSpan -> int32) = _.Milliseconds
            let v314 : int32 = v313 v292
            let v318 : System.DateTime = System.DateTime (1, 1, 1, v299, v304, v309, v314)
            v318
    let v346 : string = method14()
    let v350 : bool = v346 = ""
    let v352 : string =
        if v350 then
            let v351 : string = "M-d-y hh:mm:ss tt"
            v351
        else
            v346
    let v353 : (string -> string) = v344.ToString
    let v354 : string = v353 v352
    let _run_target_args'_v187 = v354 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v371 : (int64 -> US2) = method13()
    let v372 : US2 option = v5 |> Option.map v371 
    let v392 : US2 = US2_1
    let v393 : US2 = v372 |> Option.defaultValue v392 
    let v525 : System.DateTime =
        match v393 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v508 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v509 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v509 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v510 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v510 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v512 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v508 = v512 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v515 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v515 
            #endif
#if FABLE_COMPILER_PYTHON
            let v516 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v516 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v517 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v517 
            #endif
#else
            let v518 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v508 = v518 
            #endif
            let v519 : System.DateTime = _run_target_args'_v508 
            v519
        | US2_0(v397) -> (* Some *)
            (* run_target_args'
            let v404 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v405 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v405 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v406 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v406 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v408 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v404 = v408 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v411 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v411 
            #endif
#if FABLE_COMPILER_PYTHON
            let v412 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v412 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v413 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v413 
            #endif
#else
            let v414 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v404 = v414 
            #endif
            let v415 : System.DateTime = _run_target_args'_v404 
            (* run_target_args'
            let v426 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v427 : (System.DateTime -> int64) = _.Ticks
            let v428 : int64 = v427 v415
            let _run_target_args'_v426 = v428 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v429 : (System.DateTime -> int64) = _.Ticks
            let v430 : int64 = v429 v415
            let _run_target_args'_v426 = v430 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v432 : int64 = null |> unbox<int64>
            let _run_target_args'_v426 = v432 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v435 : (System.DateTime -> int64) = _.Ticks
            let v436 : int64 = v435 v415
            let _run_target_args'_v426 = v436 
            #endif
#if FABLE_COMPILER_PYTHON
            let v437 : (System.DateTime -> int64) = _.Ticks
            let v438 : int64 = v437 v415
            let _run_target_args'_v426 = v438 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v439 : (System.DateTime -> int64) = _.Ticks
            let v440 : int64 = v439 v415
            let _run_target_args'_v426 = v440 
            #endif
#else
            let v441 : (System.DateTime -> int64) = _.Ticks
            let v442 : int64 = v441 v415
            let _run_target_args'_v426 = v442 
            #endif
            let v443 : int64 = _run_target_args'_v426 
            let v464 : int64 = v443 |> int64 
            let v467 : int64 = v464 - v397
            let v473 : System.TimeSpan = v467 |> System.TimeSpan 
            let v479 : (System.TimeSpan -> int32) = _.Hours
            let v480 : int32 = v479 v473
            let v484 : (System.TimeSpan -> int32) = _.Minutes
            let v485 : int32 = v484 v473
            let v489 : (System.TimeSpan -> int32) = _.Seconds
            let v490 : int32 = v489 v473
            let v494 : (System.TimeSpan -> int32) = _.Milliseconds
            let v495 : int32 = v494 v473
            let v499 : System.DateTime = System.DateTime (1, 1, 1, v480, v485, v490, v495)
            v499
    let v527 : string = method14()
    let v531 : bool = v527 = ""
    let v533 : string =
        if v531 then
            let v532 : string = "M-d-y hh:mm:ss tt"
            v532
        else
            v527
    let v534 : (string -> string) = v525.ToString
    let v535 : string = v534 v533
    let _run_target_args'_v187 = v535 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v550 : string = $"near_sdk::env::block_timestamp()"
    let v551 : uint64 = Fable.Core.RustInterop.emitRustExpr () v550 
    let v554 : (int64 -> US2) = method13()
    let v555 : US2 option = v5 |> Option.map v554 
    let v575 : US2 = US2_1
    let v576 : US2 = v555 |> Option.defaultValue v575 
    let v588 : uint64 =
        match v576 with
        | US2_1 -> (* None *)
            v551
        | US2_0(v580) -> (* Some *)
            let v582 : (int64 -> uint64) = uint64
            let v583 : uint64 = v582 v580
            let v586 : uint64 = v551 - v583
            v586
    let v589 : uint64 = v588 / 1000000000UL
    let v590 : uint64 = v589 % 60UL
    let v591 : uint64 = v589 / 60UL
    let v592 : uint64 = v591 % 60UL
    let v593 : uint64 = v589 / 3600UL
    let v594 : uint64 = v593 % 24UL
    let v595 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v596 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v594, v592, v590) v595 
    let v597 : string = "fable_library_rust::String_::fromString($0)"
    let v598 : string = Fable.Core.RustInterop.emitRustExpr v596 v597 
    let _run_target_args'_v187 = v598 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v601 : (int64 -> US2) = method13()
    let v602 : US2 option = v5 |> Option.map v601 
    let v622 : US2 = US2_1
    let v623 : US2 = v602 |> Option.defaultValue v622 
    let v755 : System.DateTime =
        match v623 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v738 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v739 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v739 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v740 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v740 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v742 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v738 = v742 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v745 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v745 
            #endif
#if FABLE_COMPILER_PYTHON
            let v746 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v746 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v747 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v747 
            #endif
#else
            let v748 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v738 = v748 
            #endif
            let v749 : System.DateTime = _run_target_args'_v738 
            v749
        | US2_0(v627) -> (* Some *)
            (* run_target_args'
            let v634 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v635 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v635 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v636 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v636 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v638 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v634 = v638 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v641 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v641 
            #endif
#if FABLE_COMPILER_PYTHON
            let v642 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v642 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v643 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v643 
            #endif
#else
            let v644 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v634 = v644 
            #endif
            let v645 : System.DateTime = _run_target_args'_v634 
            (* run_target_args'
            let v656 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v657 : (System.DateTime -> int64) = _.Ticks
            let v658 : int64 = v657 v645
            let _run_target_args'_v656 = v658 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v659 : (System.DateTime -> int64) = _.Ticks
            let v660 : int64 = v659 v645
            let _run_target_args'_v656 = v660 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v662 : int64 = null |> unbox<int64>
            let _run_target_args'_v656 = v662 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v665 : (System.DateTime -> int64) = _.Ticks
            let v666 : int64 = v665 v645
            let _run_target_args'_v656 = v666 
            #endif
#if FABLE_COMPILER_PYTHON
            let v667 : (System.DateTime -> int64) = _.Ticks
            let v668 : int64 = v667 v645
            let _run_target_args'_v656 = v668 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v669 : (System.DateTime -> int64) = _.Ticks
            let v670 : int64 = v669 v645
            let _run_target_args'_v656 = v670 
            #endif
#else
            let v671 : (System.DateTime -> int64) = _.Ticks
            let v672 : int64 = v671 v645
            let _run_target_args'_v656 = v672 
            #endif
            let v673 : int64 = _run_target_args'_v656 
            let v694 : int64 = v673 |> int64 
            let v697 : int64 = v694 - v627
            let v703 : System.TimeSpan = v697 |> System.TimeSpan 
            let v709 : (System.TimeSpan -> int32) = _.Hours
            let v710 : int32 = v709 v703
            let v714 : (System.TimeSpan -> int32) = _.Minutes
            let v715 : int32 = v714 v703
            let v719 : (System.TimeSpan -> int32) = _.Seconds
            let v720 : int32 = v719 v703
            let v724 : (System.TimeSpan -> int32) = _.Milliseconds
            let v725 : int32 = v724 v703
            let v729 : System.DateTime = System.DateTime (1, 1, 1, v710, v715, v720, v725)
            v729
    let v757 : string = method15()
    let v761 : bool = v757 = ""
    let v763 : string =
        if v761 then
            let v762 : string = "M-d-y hh:mm:ss tt"
            v762
        else
            v757
    let v764 : (string -> string) = v755.ToString
    let v765 : string = v764 v763
    let _run_target_args'_v187 = v765 
    #endif
#if FABLE_COMPILER_PYTHON
    let v782 : (int64 -> US2) = method13()
    let v783 : US2 option = v5 |> Option.map v782 
    let v803 : US2 = US2_1
    let v804 : US2 = v783 |> Option.defaultValue v803 
    let v936 : System.DateTime =
        match v804 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v919 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v920 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v920 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v921 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v921 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v923 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v919 = v923 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v926 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v926 
            #endif
#if FABLE_COMPILER_PYTHON
            let v927 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v927 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v928 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v928 
            #endif
#else
            let v929 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v919 = v929 
            #endif
            let v930 : System.DateTime = _run_target_args'_v919 
            v930
        | US2_0(v808) -> (* Some *)
            (* run_target_args'
            let v815 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v816 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v816 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v817 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v817 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v819 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v815 = v819 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v822 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v822 
            #endif
#if FABLE_COMPILER_PYTHON
            let v823 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v823 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v824 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v824 
            #endif
#else
            let v825 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v815 = v825 
            #endif
            let v826 : System.DateTime = _run_target_args'_v815 
            (* run_target_args'
            let v837 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v838 : (System.DateTime -> int64) = _.Ticks
            let v839 : int64 = v838 v826
            let _run_target_args'_v837 = v839 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v840 : (System.DateTime -> int64) = _.Ticks
            let v841 : int64 = v840 v826
            let _run_target_args'_v837 = v841 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v843 : int64 = null |> unbox<int64>
            let _run_target_args'_v837 = v843 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v846 : (System.DateTime -> int64) = _.Ticks
            let v847 : int64 = v846 v826
            let _run_target_args'_v837 = v847 
            #endif
#if FABLE_COMPILER_PYTHON
            let v848 : (System.DateTime -> int64) = _.Ticks
            let v849 : int64 = v848 v826
            let _run_target_args'_v837 = v849 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v850 : (System.DateTime -> int64) = _.Ticks
            let v851 : int64 = v850 v826
            let _run_target_args'_v837 = v851 
            #endif
#else
            let v852 : (System.DateTime -> int64) = _.Ticks
            let v853 : int64 = v852 v826
            let _run_target_args'_v837 = v853 
            #endif
            let v854 : int64 = _run_target_args'_v837 
            let v875 : int64 = v854 |> int64 
            let v878 : int64 = v875 - v808
            let v884 : System.TimeSpan = v878 |> System.TimeSpan 
            let v890 : (System.TimeSpan -> int32) = _.Hours
            let v891 : int32 = v890 v884
            let v895 : (System.TimeSpan -> int32) = _.Minutes
            let v896 : int32 = v895 v884
            let v900 : (System.TimeSpan -> int32) = _.Seconds
            let v901 : int32 = v900 v884
            let v905 : (System.TimeSpan -> int32) = _.Milliseconds
            let v906 : int32 = v905 v884
            let v910 : System.DateTime = System.DateTime (1, 1, 1, v891, v896, v901, v906)
            v910
    let v938 : string = method15()
    let v942 : bool = v938 = ""
    let v944 : string =
        if v942 then
            let v943 : string = "M-d-y hh:mm:ss tt"
            v943
        else
            v938
    let v945 : (string -> string) = v936.ToString
    let v946 : string = v945 v944
    let _run_target_args'_v187 = v946 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v963 : (int64 -> US2) = method13()
    let v964 : US2 option = v5 |> Option.map v963 
    let v984 : US2 = US2_1
    let v985 : US2 = v964 |> Option.defaultValue v984 
    let v1117 : System.DateTime =
        match v985 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1100 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1101 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1101 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1102 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1102 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1104 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1100 = v1104 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1107 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1107 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1108 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1108 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1109 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1109 
            #endif
#else
            let v1110 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1100 = v1110 
            #endif
            let v1111 : System.DateTime = _run_target_args'_v1100 
            v1111
        | US2_0(v989) -> (* Some *)
            (* run_target_args'
            let v996 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v997 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v997 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v998 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v998 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1000 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v996 = v1000 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1003 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1003 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1004 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1004 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1005 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1005 
            #endif
#else
            let v1006 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v996 = v1006 
            #endif
            let v1007 : System.DateTime = _run_target_args'_v996 
            (* run_target_args'
            let v1018 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1019 : (System.DateTime -> int64) = _.Ticks
            let v1020 : int64 = v1019 v1007
            let _run_target_args'_v1018 = v1020 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1021 : (System.DateTime -> int64) = _.Ticks
            let v1022 : int64 = v1021 v1007
            let _run_target_args'_v1018 = v1022 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1024 : int64 = null |> unbox<int64>
            let _run_target_args'_v1018 = v1024 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1027 : (System.DateTime -> int64) = _.Ticks
            let v1028 : int64 = v1027 v1007
            let _run_target_args'_v1018 = v1028 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1029 : (System.DateTime -> int64) = _.Ticks
            let v1030 : int64 = v1029 v1007
            let _run_target_args'_v1018 = v1030 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1031 : (System.DateTime -> int64) = _.Ticks
            let v1032 : int64 = v1031 v1007
            let _run_target_args'_v1018 = v1032 
            #endif
#else
            let v1033 : (System.DateTime -> int64) = _.Ticks
            let v1034 : int64 = v1033 v1007
            let _run_target_args'_v1018 = v1034 
            #endif
            let v1035 : int64 = _run_target_args'_v1018 
            let v1056 : int64 = v1035 |> int64 
            let v1059 : int64 = v1056 - v989
            let v1065 : System.TimeSpan = v1059 |> System.TimeSpan 
            let v1071 : (System.TimeSpan -> int32) = _.Hours
            let v1072 : int32 = v1071 v1065
            let v1076 : (System.TimeSpan -> int32) = _.Minutes
            let v1077 : int32 = v1076 v1065
            let v1081 : (System.TimeSpan -> int32) = _.Seconds
            let v1082 : int32 = v1081 v1065
            let v1086 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1087 : int32 = v1086 v1065
            let v1091 : System.DateTime = System.DateTime (1, 1, 1, v1072, v1077, v1082, v1087)
            v1091
    let v1119 : string = method15()
    let v1123 : bool = v1119 = ""
    let v1125 : string =
        if v1123 then
            let v1124 : string = "M-d-y hh:mm:ss tt"
            v1124
        else
            v1119
    let v1126 : (string -> string) = v1117.ToString
    let v1127 : string = v1126 v1125
    let _run_target_args'_v187 = v1127 
    #endif
#else
    let v1144 : (int64 -> US2) = method13()
    let v1145 : US2 option = v5 |> Option.map v1144 
    let v1165 : US2 = US2_1
    let v1166 : US2 = v1145 |> Option.defaultValue v1165 
    let v1298 : System.DateTime =
        match v1166 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1281 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1282 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1282 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1283 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1283 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1285 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1281 = v1285 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1288 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1288 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1289 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1289 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1290 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1290 
            #endif
#else
            let v1291 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1281 = v1291 
            #endif
            let v1292 : System.DateTime = _run_target_args'_v1281 
            v1292
        | US2_0(v1170) -> (* Some *)
            (* run_target_args'
            let v1177 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1178 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1178 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1179 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1179 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1181 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1177 = v1181 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1184 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1184 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1185 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1185 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1186 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1186 
            #endif
#else
            let v1187 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1177 = v1187 
            #endif
            let v1188 : System.DateTime = _run_target_args'_v1177 
            (* run_target_args'
            let v1199 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1200 : (System.DateTime -> int64) = _.Ticks
            let v1201 : int64 = v1200 v1188
            let _run_target_args'_v1199 = v1201 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1202 : (System.DateTime -> int64) = _.Ticks
            let v1203 : int64 = v1202 v1188
            let _run_target_args'_v1199 = v1203 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1205 : int64 = null |> unbox<int64>
            let _run_target_args'_v1199 = v1205 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1208 : (System.DateTime -> int64) = _.Ticks
            let v1209 : int64 = v1208 v1188
            let _run_target_args'_v1199 = v1209 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1210 : (System.DateTime -> int64) = _.Ticks
            let v1211 : int64 = v1210 v1188
            let _run_target_args'_v1199 = v1211 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1212 : (System.DateTime -> int64) = _.Ticks
            let v1213 : int64 = v1212 v1188
            let _run_target_args'_v1199 = v1213 
            #endif
#else
            let v1214 : (System.DateTime -> int64) = _.Ticks
            let v1215 : int64 = v1214 v1188
            let _run_target_args'_v1199 = v1215 
            #endif
            let v1216 : int64 = _run_target_args'_v1199 
            let v1237 : int64 = v1216 |> int64 
            let v1240 : int64 = v1237 - v1170
            let v1246 : System.TimeSpan = v1240 |> System.TimeSpan 
            let v1252 : (System.TimeSpan -> int32) = _.Hours
            let v1253 : int32 = v1252 v1246
            let v1257 : (System.TimeSpan -> int32) = _.Minutes
            let v1258 : int32 = v1257 v1246
            let v1262 : (System.TimeSpan -> int32) = _.Seconds
            let v1263 : int32 = v1262 v1246
            let v1267 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1268 : int32 = v1267 v1246
            let v1272 : System.DateTime = System.DateTime (1, 1, 1, v1253, v1258, v1263, v1268)
            v1272
    let v1300 : string = method15()
    let v1304 : bool = v1300 = ""
    let v1306 : string =
        if v1304 then
            let v1305 : string = "M-d-y hh:mm:ss tt"
            v1305
        else
            v1300
    let v1307 : (string -> string) = v1298.ToString
    let v1308 : string = v1307 v1306
    let _run_target_args'_v187 = v1308 
    #endif
    let v1323 : string = _run_target_args'_v187 
    v1323
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_bright_blue"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_bright_blue"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[94m"
    let v176 : string = method18()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[94m"
    let v192 : string = method18()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[94m"
    let v208 : string = method18()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[94m"
    let v224 : string = method18()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
and method21 (v0 : string) : string =
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
    let v117 : string = $"$0.chars()"
    let v118 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v111 v117 
    let v119 : string = "$0"
    let v120 : _ = Fable.Core.RustInterop.emitRustExpr v118 v119 
    let v121 : string = "$0.collect::<Vec<_>>()"
    let v122 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v120 v121 
    let v123 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v124 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v122 v123 
    let v125 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v126 : bool = Fable.Core.RustInterop.emitRustExpr v124 v125 
    let v127 : string = "x"
    let v128 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v127 
    let v129 : string = "String::from_iter($0)"
    let v130 : std_string_String = Fable.Core.RustInterop.emitRustExpr v128 v129 
    let v131 : string = "true; $0 }).collect::<Vec<_>>()"
    let v132 : bool = Fable.Core.RustInterop.emitRustExpr v130 v131 
    let v133 : string = "_vec_map"
    let v134 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v133 
    let v135 : string = "$0.len()"
    let v136 : unativeint = Fable.Core.RustInterop.emitRustExpr v134 v135 
    let v142 : int32 = v136 |> int32 
    let v152 : string = ""
    let v153 : bool = v0 <> v152 
    let v157 : bool =
        if v153 then
            let v156 : bool = v142 <= 1
            v156
        else
            false
    if v157 then
        v41.l0 <- v83
        ()
    else
        v41.l0 <- v152
        let v158 : string = "true; $0.into_iter().for_each(|x| { //"
        let v159 : bool = Fable.Core.RustInterop.emitRustExpr v134 v158 
        let v160 : string = "x"
        let v161 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v160 
        let v162 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v163 : bool = Fable.Core.RustInterop.emitRustExpr v161 v162 
        let v164 : string = $"true"
        let v165 : bool = Fable.Core.RustInterop.emitRustExpr () v164 
        let v166 : string = "true; }); //"
        let v167 : bool = Fable.Core.RustInterop.emitRustExpr () v166 
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
    let v168 : (string -> unit) = v39.l0
    v168 v0
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
        let v97 : string = method19(v0)
        let v98 : string = method20(v41, v42, v43, v44, v45, v46, v59, v60, v91, v97)
        method22(v98)
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
                let v8851 : bool = true
                method9(v8851, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v9077 : exn = ex
                let v9078 : int64 = v1 % 100L
                let v9079 : bool = v9078 = 0L
                if v9079 then
                    let v9177 : unit = ()
                    let v9178 : (unit -> unit) = closure4(v0, v9077)
                    let v9179 : unit = (fun () -> v9178 (); v9177) ()
                    ()
                (* run_target_args'
                let v9281 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9282 : (int32 -> Async<unit>) = Async.Sleep
                let v9283 : Async<unit> = v9282 10
                let _run_target_args'_v9281 = v9283 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9284 : (int32 -> Async<unit>) = Async.Sleep
                let v9285 : Async<unit> = v9284 10
                let _run_target_args'_v9281 = v9285 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9286 : (int32 -> Async<unit>) = Async.Sleep
                let v9287 : Async<unit> = v9286 10
                let _run_target_args'_v9281 = v9287 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9288 : (int32 -> Async<unit>) = Async.Sleep
                let v9289 : Async<unit> = v9288 10
                let _run_target_args'_v9281 = v9289 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9290 : (int32 -> Async<unit>) = Async.Sleep
                let v9291 : Async<unit> = v9290 10
                let _run_target_args'_v9281 = v9291 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9292 : (int32 -> Async<unit>) = Async.Sleep
                let v9293 : Async<unit> = v9292 10
                let _run_target_args'_v9281 = v9293 
                #endif
#else
                let v9294 : (int32 -> Async<unit>) = Async.Sleep
                let v9295 : Async<unit> = v9294 10
                let _run_target_args'_v9281 = v9295 
                #endif
                let v9296 : Async<unit> = _run_target_args'_v9281 
                do! v9296 
                let v9299 : int64 = v1 + 1L
                let v9300 : Async<int64> = method7(v0, v9299)
                return! v9300 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9526 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v18356 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v18356 
    #endif
#if FABLE_COMPILER_PYTHON
    let v18358 : unit = ()
    let _let'_v18358 =
        async {
            try
                let v27189 : bool = true
                method9(v27189, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v27415 : exn = ex
                let v27416 : int64 = v1 % 100L
                let v27417 : bool = v27416 = 0L
                if v27417 then
                    let v27515 : unit = ()
                    let v27516 : (unit -> unit) = closure4(v0, v27415)
                    let v27517 : unit = (fun () -> v27516 (); v27515) ()
                    ()
                (* run_target_args'
                let v27619 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v27620 : (int32 -> Async<unit>) = Async.Sleep
                let v27621 : Async<unit> = v27620 10
                let _run_target_args'_v27619 = v27621 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v27622 : (int32 -> Async<unit>) = Async.Sleep
                let v27623 : Async<unit> = v27622 10
                let _run_target_args'_v27619 = v27623 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v27624 : (int32 -> Async<unit>) = Async.Sleep
                let v27625 : Async<unit> = v27624 10
                let _run_target_args'_v27619 = v27625 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v27626 : (int32 -> Async<unit>) = Async.Sleep
                let v27627 : Async<unit> = v27626 10
                let _run_target_args'_v27619 = v27627 
                #endif
#if FABLE_COMPILER_PYTHON
                let v27628 : (int32 -> Async<unit>) = Async.Sleep
                let v27629 : Async<unit> = v27628 10
                let _run_target_args'_v27619 = v27629 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v27630 : (int32 -> Async<unit>) = Async.Sleep
                let v27631 : Async<unit> = v27630 10
                let _run_target_args'_v27619 = v27631 
                #endif
#else
                let v27632 : (int32 -> Async<unit>) = Async.Sleep
                let v27633 : Async<unit> = v27632 10
                let _run_target_args'_v27619 = v27633 
                #endif
                let v27634 : Async<unit> = _run_target_args'_v27619 
                do! v27634 
                let v27637 : int64 = v1 + 1L
                let v27638 : Async<int64> = method7(v0, v27637)
                return! v27638 
                (* indent
                ()
            indent *)
            (* try_unit
            let v27864 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36694 : Async<int64> = _let'_v18358 
    let _run_target_args'_v6 = v36694 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36696 : unit = ()
    let _let'_v36696 =
        async {
            try
                let v45527 : bool = true
                method9(v45527, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v45753 : exn = ex
                let v45754 : int64 = v1 % 100L
                let v45755 : bool = v45754 = 0L
                if v45755 then
                    let v45853 : unit = ()
                    let v45854 : (unit -> unit) = closure4(v0, v45753)
                    let v45855 : unit = (fun () -> v45854 (); v45853) ()
                    ()
                (* run_target_args'
                let v45957 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45958 : (int32 -> Async<unit>) = Async.Sleep
                let v45959 : Async<unit> = v45958 10
                let _run_target_args'_v45957 = v45959 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v45960 : (int32 -> Async<unit>) = Async.Sleep
                let v45961 : Async<unit> = v45960 10
                let _run_target_args'_v45957 = v45961 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v45962 : (int32 -> Async<unit>) = Async.Sleep
                let v45963 : Async<unit> = v45962 10
                let _run_target_args'_v45957 = v45963 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v45964 : (int32 -> Async<unit>) = Async.Sleep
                let v45965 : Async<unit> = v45964 10
                let _run_target_args'_v45957 = v45965 
                #endif
#if FABLE_COMPILER_PYTHON
                let v45966 : (int32 -> Async<unit>) = Async.Sleep
                let v45967 : Async<unit> = v45966 10
                let _run_target_args'_v45957 = v45967 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v45968 : (int32 -> Async<unit>) = Async.Sleep
                let v45969 : Async<unit> = v45968 10
                let _run_target_args'_v45957 = v45969 
                #endif
#else
                let v45970 : (int32 -> Async<unit>) = Async.Sleep
                let v45971 : Async<unit> = v45970 10
                let _run_target_args'_v45957 = v45971 
                #endif
                let v45972 : Async<unit> = _run_target_args'_v45957 
                do! v45972 
                let v45975 : int64 = v1 + 1L
                let v45976 : Async<int64> = method7(v0, v45975)
                return! v45976 
                (* indent
                ()
            indent *)
            (* try_unit
            let v46202 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v55032 : Async<int64> = _let'_v36696 
    let _run_target_args'_v6 = v55032 
    #endif
#else
    let v55034 : unit = ()
    let _let'_v55034 =
        async {
            try
                let v63865 : bool = true
                method9(v63865, v0)
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v64091 : exn = ex
                let v64092 : int64 = v1 % 100L
                let v64093 : bool = v64092 = 0L
                if v64093 then
                    let v64191 : unit = ()
                    let v64192 : (unit -> unit) = closure4(v0, v64091)
                    let v64193 : unit = (fun () -> v64192 (); v64191) ()
                    ()
                (* run_target_args'
                let v64295 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v64296 : (int32 -> Async<unit>) = Async.Sleep
                let v64297 : Async<unit> = v64296 10
                let _run_target_args'_v64295 = v64297 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v64298 : (int32 -> Async<unit>) = Async.Sleep
                let v64299 : Async<unit> = v64298 10
                let _run_target_args'_v64295 = v64299 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v64300 : (int32 -> Async<unit>) = Async.Sleep
                let v64301 : Async<unit> = v64300 10
                let _run_target_args'_v64295 = v64301 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v64302 : (int32 -> Async<unit>) = Async.Sleep
                let v64303 : Async<unit> = v64302 10
                let _run_target_args'_v64295 = v64303 
                #endif
#if FABLE_COMPILER_PYTHON
                let v64304 : (int32 -> Async<unit>) = Async.Sleep
                let v64305 : Async<unit> = v64304 10
                let _run_target_args'_v64295 = v64305 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v64306 : (int32 -> Async<unit>) = Async.Sleep
                let v64307 : Async<unit> = v64306 10
                let _run_target_args'_v64295 = v64307 
                #endif
#else
                let v64308 : (int32 -> Async<unit>) = Async.Sleep
                let v64309 : Async<unit> = v64308 10
                let _run_target_args'_v64295 = v64309 
                #endif
                let v64310 : Async<unit> = _run_target_args'_v64295 
                do! v64310 
                let v64313 : int64 = v1 + 1L
                let v64314 : Async<int64> = method7(v0, v64313)
                return! v64314 
                (* indent
                ()
            indent *)
            (* try_unit
            let v64540 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v73370 : Async<int64> = _let'_v55034 
    let _run_target_args'_v6 = v73370 
    #endif
    let v73371 : Async<int64> = _run_target_args'_v6 
    v73371
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
        let v99 : string = method26(v42, v43, v44, v45, v46, v47, v60, v61, v62, v1, v93)
        method22(v99)
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
                let v11056 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11058 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11056 = v11058 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11062 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11056 = v11062 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11066 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11056 = v11066 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11070 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11056 = v11070 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11074 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11056 = v11074 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11078 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v11056 = v11078 
                #endif
#else
                let v11081 : System.IO.FileMode = System.IO.FileMode.Open
                let v11087 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v11082 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v11082
                    | US7_2 -> (* AccessReadWrite *)
                        let v11084 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v11084
                    | US7_1 -> (* AccessWrite *)
                        let v11083 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v11083
                let v11097 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v11092 : System.IO.FileShare = System.IO.FileShare.Delete
                        v11092
                    | US8_0 -> (* ShareNone *)
                        let v11088 : System.IO.FileShare = System.IO.FileShare.None
                        v11088
                    | US8_1 -> (* ShareRead *)
                        let v11089 : System.IO.FileShare = System.IO.FileShare.Read
                        v11089
                    | US8_3 -> (* ShareReadWrite *)
                        let v11091 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v11091
                    | US8_2 -> (* ShareWrite *)
                        let v11090 : System.IO.FileShare = System.IO.FileShare.Write
                        v11090
                let v11098 : System.IO.FileStream = new System.IO.FileStream (v1, v11081, v11087, v11097)
                let _run_target_args'_v11056 = v11098 
                #endif
                let v11099 : System.IO.FileStream = _run_target_args'_v11056 
                use v11099 = v11099 
                let v11105 : System.IO.FileStream = v11099 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v11386 : exn = ex
                let v11387 : bool = v2 > 0L
                let v11390 : bool =
                    if v11387 then
                        let v11388 : int64 = v2 % 100L
                        let v11389 : bool = v11388 = 0L
                        v11389
                    else
                        false
                if v11390 then
                    let v11488 : unit = ()
                    let v11489 : (unit -> unit) = closure12(v1, v2, v11386)
                    let v11490 : unit = (fun () -> v11489 (); v11488) ()
                    ()
                (* run_target_args'
                let v11592 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v11593 : (int32 -> Async<unit>) = Async.Sleep
                let v11594 : Async<unit> = v11593 10
                let _run_target_args'_v11592 = v11594 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v11595 : (int32 -> Async<unit>) = Async.Sleep
                let v11596 : Async<unit> = v11595 10
                let _run_target_args'_v11592 = v11596 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v11597 : (int32 -> Async<unit>) = Async.Sleep
                let v11598 : Async<unit> = v11597 10
                let _run_target_args'_v11592 = v11598 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v11599 : (int32 -> Async<unit>) = Async.Sleep
                let v11600 : Async<unit> = v11599 10
                let _run_target_args'_v11592 = v11600 
                #endif
#if FABLE_COMPILER_PYTHON
                let v11601 : (int32 -> Async<unit>) = Async.Sleep
                let v11602 : Async<unit> = v11601 10
                let _run_target_args'_v11592 = v11602 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v11603 : (int32 -> Async<unit>) = Async.Sleep
                let v11604 : Async<unit> = v11603 10
                let _run_target_args'_v11592 = v11604 
                #endif
#else
                let v11605 : (int32 -> Async<unit>) = Async.Sleep
                let v11606 : Async<unit> = v11605 10
                let _run_target_args'_v11592 = v11606 
                #endif
                let v11607 : Async<unit> = _run_target_args'_v11592 
                do! v11607 
                let v11610 : int64 = v2 + 1L
                let v11611 : Async<int64> = method24(v0, v1, v11610)
                return! v11611 
                (* indent
                ()
            indent *)
            (* try_unit
            let v11839 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v22814 : Async<int64> = _let'_v23 
    let _run_target_args'_v9 = v22814 
    #endif
#if FABLE_COMPILER_PYTHON
    let v22816 : unit = ()
    let _let'_v22816 =
        async {
            try
                (* run_target_args'
                let v33849 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v33851 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v33849 = v33851 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v33855 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v33849 = v33855 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v33859 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v33849 = v33859 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v33863 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v33849 = v33863 
                #endif
#if FABLE_COMPILER_PYTHON
                let v33867 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v33849 = v33867 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v33871 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v33849 = v33871 
                #endif
#else
                let v33874 : System.IO.FileMode = System.IO.FileMode.Open
                let v33880 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v33875 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v33875
                    | US7_2 -> (* AccessReadWrite *)
                        let v33877 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v33877
                    | US7_1 -> (* AccessWrite *)
                        let v33876 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v33876
                let v33890 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v33885 : System.IO.FileShare = System.IO.FileShare.Delete
                        v33885
                    | US8_0 -> (* ShareNone *)
                        let v33881 : System.IO.FileShare = System.IO.FileShare.None
                        v33881
                    | US8_1 -> (* ShareRead *)
                        let v33882 : System.IO.FileShare = System.IO.FileShare.Read
                        v33882
                    | US8_3 -> (* ShareReadWrite *)
                        let v33884 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v33884
                    | US8_2 -> (* ShareWrite *)
                        let v33883 : System.IO.FileShare = System.IO.FileShare.Write
                        v33883
                let v33891 : System.IO.FileStream = new System.IO.FileStream (v1, v33874, v33880, v33890)
                let _run_target_args'_v33849 = v33891 
                #endif
                let v33892 : System.IO.FileStream = _run_target_args'_v33849 
                use v33892 = v33892 
                let v33898 : System.IO.FileStream = v33892 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v34179 : exn = ex
                let v34180 : bool = v2 > 0L
                let v34183 : bool =
                    if v34180 then
                        let v34181 : int64 = v2 % 100L
                        let v34182 : bool = v34181 = 0L
                        v34182
                    else
                        false
                if v34183 then
                    let v34281 : unit = ()
                    let v34282 : (unit -> unit) = closure12(v1, v2, v34179)
                    let v34283 : unit = (fun () -> v34282 (); v34281) ()
                    ()
                (* run_target_args'
                let v34385 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v34386 : (int32 -> Async<unit>) = Async.Sleep
                let v34387 : Async<unit> = v34386 10
                let _run_target_args'_v34385 = v34387 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v34388 : (int32 -> Async<unit>) = Async.Sleep
                let v34389 : Async<unit> = v34388 10
                let _run_target_args'_v34385 = v34389 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v34390 : (int32 -> Async<unit>) = Async.Sleep
                let v34391 : Async<unit> = v34390 10
                let _run_target_args'_v34385 = v34391 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v34392 : (int32 -> Async<unit>) = Async.Sleep
                let v34393 : Async<unit> = v34392 10
                let _run_target_args'_v34385 = v34393 
                #endif
#if FABLE_COMPILER_PYTHON
                let v34394 : (int32 -> Async<unit>) = Async.Sleep
                let v34395 : Async<unit> = v34394 10
                let _run_target_args'_v34385 = v34395 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v34396 : (int32 -> Async<unit>) = Async.Sleep
                let v34397 : Async<unit> = v34396 10
                let _run_target_args'_v34385 = v34397 
                #endif
#else
                let v34398 : (int32 -> Async<unit>) = Async.Sleep
                let v34399 : Async<unit> = v34398 10
                let _run_target_args'_v34385 = v34399 
                #endif
                let v34400 : Async<unit> = _run_target_args'_v34385 
                do! v34400 
                let v34403 : int64 = v2 + 1L
                let v34404 : Async<int64> = method24(v0, v1, v34403)
                return! v34404 
                (* indent
                ()
            indent *)
            (* try_unit
            let v34632 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v45607 : Async<int64> = _let'_v22816 
    let _run_target_args'_v9 = v45607 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45609 : unit = ()
    let _let'_v45609 =
        async {
            try
                (* run_target_args'
                let v56642 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v56644 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v56642 = v56644 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v56648 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v56642 = v56648 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v56652 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v56642 = v56652 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v56656 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v56642 = v56656 
                #endif
#if FABLE_COMPILER_PYTHON
                let v56660 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v56642 = v56660 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v56664 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v56642 = v56664 
                #endif
#else
                let v56667 : System.IO.FileMode = System.IO.FileMode.Open
                let v56673 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v56668 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v56668
                    | US7_2 -> (* AccessReadWrite *)
                        let v56670 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v56670
                    | US7_1 -> (* AccessWrite *)
                        let v56669 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v56669
                let v56683 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v56678 : System.IO.FileShare = System.IO.FileShare.Delete
                        v56678
                    | US8_0 -> (* ShareNone *)
                        let v56674 : System.IO.FileShare = System.IO.FileShare.None
                        v56674
                    | US8_1 -> (* ShareRead *)
                        let v56675 : System.IO.FileShare = System.IO.FileShare.Read
                        v56675
                    | US8_3 -> (* ShareReadWrite *)
                        let v56677 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v56677
                    | US8_2 -> (* ShareWrite *)
                        let v56676 : System.IO.FileShare = System.IO.FileShare.Write
                        v56676
                let v56684 : System.IO.FileStream = new System.IO.FileStream (v1, v56667, v56673, v56683)
                let _run_target_args'_v56642 = v56684 
                #endif
                let v56685 : System.IO.FileStream = _run_target_args'_v56642 
                use v56685 = v56685 
                let v56691 : System.IO.FileStream = v56685 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v56972 : exn = ex
                let v56973 : bool = v2 > 0L
                let v56976 : bool =
                    if v56973 then
                        let v56974 : int64 = v2 % 100L
                        let v56975 : bool = v56974 = 0L
                        v56975
                    else
                        false
                if v56976 then
                    let v57074 : unit = ()
                    let v57075 : (unit -> unit) = closure12(v1, v2, v56972)
                    let v57076 : unit = (fun () -> v57075 (); v57074) ()
                    ()
                (* run_target_args'
                let v57178 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v57179 : (int32 -> Async<unit>) = Async.Sleep
                let v57180 : Async<unit> = v57179 10
                let _run_target_args'_v57178 = v57180 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v57181 : (int32 -> Async<unit>) = Async.Sleep
                let v57182 : Async<unit> = v57181 10
                let _run_target_args'_v57178 = v57182 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v57183 : (int32 -> Async<unit>) = Async.Sleep
                let v57184 : Async<unit> = v57183 10
                let _run_target_args'_v57178 = v57184 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v57185 : (int32 -> Async<unit>) = Async.Sleep
                let v57186 : Async<unit> = v57185 10
                let _run_target_args'_v57178 = v57186 
                #endif
#if FABLE_COMPILER_PYTHON
                let v57187 : (int32 -> Async<unit>) = Async.Sleep
                let v57188 : Async<unit> = v57187 10
                let _run_target_args'_v57178 = v57188 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v57189 : (int32 -> Async<unit>) = Async.Sleep
                let v57190 : Async<unit> = v57189 10
                let _run_target_args'_v57178 = v57190 
                #endif
#else
                let v57191 : (int32 -> Async<unit>) = Async.Sleep
                let v57192 : Async<unit> = v57191 10
                let _run_target_args'_v57178 = v57192 
                #endif
                let v57193 : Async<unit> = _run_target_args'_v57178 
                do! v57193 
                let v57196 : int64 = v2 + 1L
                let v57197 : Async<int64> = method24(v0, v1, v57196)
                return! v57197 
                (* indent
                ()
            indent *)
            (* try_unit
            let v57425 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v68400 : Async<int64> = _let'_v45609 
    let _run_target_args'_v9 = v68400 
    #endif
#else
    let v68402 : unit = ()
    let _let'_v68402 =
        async {
            try
                (* run_target_args'
                let v79435 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v79437 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v79435 = v79437 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79441 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v79435 = v79441 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v79445 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v79435 = v79445 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v79449 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v79435 = v79449 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79453 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v79435 = v79453 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v79457 : System.IO.FileStream = null |> unbox<System.IO.FileStream>
                let _run_target_args'_v79435 = v79457 
                #endif
#else
                let v79460 : System.IO.FileMode = System.IO.FileMode.Open
                let v79466 : System.IO.FileAccess =
                    match v4 with
                    | US7_0 -> (* AccessRead *)
                        let v79461 : System.IO.FileAccess = System.IO.FileAccess.Read
                        v79461
                    | US7_2 -> (* AccessReadWrite *)
                        let v79463 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v79463
                    | US7_1 -> (* AccessWrite *)
                        let v79462 : System.IO.FileAccess = System.IO.FileAccess.ReadWrite
                        v79462
                let v79476 : System.IO.FileShare =
                    match v3 with
                    | US8_4 -> (* ShareDelete *)
                        let v79471 : System.IO.FileShare = System.IO.FileShare.Delete
                        v79471
                    | US8_0 -> (* ShareNone *)
                        let v79467 : System.IO.FileShare = System.IO.FileShare.None
                        v79467
                    | US8_1 -> (* ShareRead *)
                        let v79468 : System.IO.FileShare = System.IO.FileShare.Read
                        v79468
                    | US8_3 -> (* ShareReadWrite *)
                        let v79470 : System.IO.FileShare = System.IO.FileShare.ReadWrite
                        v79470
                    | US8_2 -> (* ShareWrite *)
                        let v79469 : System.IO.FileShare = System.IO.FileShare.Write
                        v79469
                let v79477 : System.IO.FileStream = new System.IO.FileStream (v1, v79460, v79466, v79476)
                let _run_target_args'_v79435 = v79477 
                #endif
                let v79478 : System.IO.FileStream = _run_target_args'_v79435 
                use v79478 = v79478 
                let v79484 : System.IO.FileStream = v79478 
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v79765 : exn = ex
                let v79766 : bool = v2 > 0L
                let v79769 : bool =
                    if v79766 then
                        let v79767 : int64 = v2 % 100L
                        let v79768 : bool = v79767 = 0L
                        v79768
                    else
                        false
                if v79769 then
                    let v79867 : unit = ()
                    let v79868 : (unit -> unit) = closure12(v1, v2, v79765)
                    let v79869 : unit = (fun () -> v79868 (); v79867) ()
                    ()
                (* run_target_args'
                let v79971 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v79972 : (int32 -> Async<unit>) = Async.Sleep
                let v79973 : Async<unit> = v79972 10
                let _run_target_args'_v79971 = v79973 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v79974 : (int32 -> Async<unit>) = Async.Sleep
                let v79975 : Async<unit> = v79974 10
                let _run_target_args'_v79971 = v79975 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v79976 : (int32 -> Async<unit>) = Async.Sleep
                let v79977 : Async<unit> = v79976 10
                let _run_target_args'_v79971 = v79977 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v79978 : (int32 -> Async<unit>) = Async.Sleep
                let v79979 : Async<unit> = v79978 10
                let _run_target_args'_v79971 = v79979 
                #endif
#if FABLE_COMPILER_PYTHON
                let v79980 : (int32 -> Async<unit>) = Async.Sleep
                let v79981 : Async<unit> = v79980 10
                let _run_target_args'_v79971 = v79981 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v79982 : (int32 -> Async<unit>) = Async.Sleep
                let v79983 : Async<unit> = v79982 10
                let _run_target_args'_v79971 = v79983 
                #endif
#else
                let v79984 : (int32 -> Async<unit>) = Async.Sleep
                let v79985 : Async<unit> = v79984 10
                let _run_target_args'_v79971 = v79985 
                #endif
                let v79986 : Async<unit> = _run_target_args'_v79971 
                do! v79986 
                let v79989 : int64 = v2 + 1L
                let v79990 : Async<int64> = method24(v0, v1, v79989)
                return! v79990 
                (* indent
                ()
            indent *)
            (* try_unit
            let v80218 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v91193 : Async<int64> = _let'_v68402 
    let _run_target_args'_v9 = v91193 
    #endif
    let v91194 : Async<int64> = _run_target_args'_v9 
    v91194
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_bright_black"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_bright_black"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[90m"
    let v176 : string = method18()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[90m"
    let v192 : string = method18()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[90m"
    let v208 : string = method18()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[90m"
    let v224 : string = method18()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
    let v255 : string = $"{v248}"
    let v263 : unit = ()
    let v264 : (unit -> unit) = closure6(v12, v255)
    let v265 : unit = (fun () -> v264 (); v263) ()
    let v273 : string = " }"
    let v274 : string = $"{v273}"
    let v282 : unit = ()
    let v283 : (unit -> unit) = closure6(v12, v274)
    let v284 : unit = (fun () -> v283 (); v282) ()
    let v290 : string = v12.l0
    let v291 : int64 = v0.l0
    let v294 : string = " "
    let v295 : string = v6 + v294 
    let v299 : string = v295 + v7 
    let v304 : string = " #"
    let v305 : string = v299 + v304 
    let v309 : (int64 -> string) = _.ToString()
    let v310 : string = v309 v291
    let v314 : string = v305 + v310 
    let v318 : string = v314 + v294 
    let v323 : string = "file_system.read_all_text_async"
    let v324 : string = v318 + v323 
    let v329 : string = " / "
    let v330 : string = v324 + v329 
    let v334 : string = v330 + v290 
    method21(v334)
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
                let v8727 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v8729 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v8727 = v8729 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v8733 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v8727 = v8733 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v8737 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v8727 = v8737 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v8741 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v8727 = v8741 
                #endif
#if FABLE_COMPILER_PYTHON
                let v8745 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v8727 = v8745 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v8749 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v8727 = v8749 
                #endif
#else
                let v8752 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v8753 : System.Threading.Tasks.Task<string> = v8752 v0
                let _run_target_args'_v8727 = v8753 
                #endif
                let v8754 : System.Threading.Tasks.Task<string> = _run_target_args'_v8727 
                (* run_target_args'
                let v8764 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v8766 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v8764 = v8766 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v8770 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v8764 = v8770 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v8774 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v8764 = v8774 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v8777 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v8778 : Async<string> = v8777 v8754
                let _run_target_args'_v8764 = v8778 
                #endif
#if FABLE_COMPILER_PYTHON
                let v8779 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v8780 : Async<string> = v8779 v8754
                let _run_target_args'_v8764 = v8780 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v8781 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v8782 : Async<string> = v8781 v8754
                let _run_target_args'_v8764 = v8782 
                #endif
#else
                let v8783 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v8784 : Async<string> = v8783 v8754
                let _run_target_args'_v8764 = v8784 
                #endif
                let v8785 : Async<string> = _run_target_args'_v8764 
                return! v8785 
                (* indent
                ()
            indent *)
            with ex ->
                let v9011 : exn = ex
                let v9072 : unit = ()
                let v9073 : (unit -> unit) = closure15(v0, v1, v9011)
                let v9074 : unit = (fun () -> v9073 (); v9072) ()
                (* run_target_args'
                let v9139 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9140 : (int32 -> Async<unit>) = Async.Sleep
                let v9141 : Async<unit> = v9140 10
                let _run_target_args'_v9139 = v9141 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9142 : (int32 -> Async<unit>) = Async.Sleep
                let v9143 : Async<unit> = v9142 10
                let _run_target_args'_v9139 = v9143 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9144 : (int32 -> Async<unit>) = Async.Sleep
                let v9145 : Async<unit> = v9144 10
                let _run_target_args'_v9139 = v9145 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9146 : (int32 -> Async<unit>) = Async.Sleep
                let v9147 : Async<unit> = v9146 10
                let _run_target_args'_v9139 = v9147 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9148 : (int32 -> Async<unit>) = Async.Sleep
                let v9149 : Async<unit> = v9148 10
                let _run_target_args'_v9139 = v9149 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9150 : (int32 -> Async<unit>) = Async.Sleep
                let v9151 : Async<unit> = v9150 10
                let _run_target_args'_v9139 = v9151 
                #endif
#else
                let v9152 : (int32 -> Async<unit>) = Async.Sleep
                let v9153 : Async<unit> = v9152 10
                let _run_target_args'_v9139 = v9153 
                #endif
                let v9154 : Async<unit> = _run_target_args'_v9139 
                do! v9154 
                let v9157 : bool = v1 < 3L
                let v9162 : Async<string> =
                    if v9157 then
                        let v9158 : int64 = v1 + 1L
                        method29(v0, v9158)
                    else
                        let v9160 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v9160
                return! v9162 
                (* indent
                ()
            indent *)
            (* try_unit
            let v9316 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v17951 : Async<string> = _let'_v20 
    let _run_target_args'_v6 = v17951 
    #endif
#if FABLE_COMPILER_PYTHON
    let v17953 : unit = ()
    let _let'_v17953 =
        async {
            try
                (* run_target_args'
                let v26660 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v26662 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v26660 = v26662 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v26666 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v26660 = v26666 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v26670 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v26660 = v26670 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v26674 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v26660 = v26674 
                #endif
#if FABLE_COMPILER_PYTHON
                let v26678 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v26660 = v26678 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v26682 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v26660 = v26682 
                #endif
#else
                let v26685 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v26686 : System.Threading.Tasks.Task<string> = v26685 v0
                let _run_target_args'_v26660 = v26686 
                #endif
                let v26687 : System.Threading.Tasks.Task<string> = _run_target_args'_v26660 
                (* run_target_args'
                let v26697 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v26699 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v26697 = v26699 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v26703 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v26697 = v26703 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v26707 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v26697 = v26707 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v26710 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v26711 : Async<string> = v26710 v26687
                let _run_target_args'_v26697 = v26711 
                #endif
#if FABLE_COMPILER_PYTHON
                let v26712 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v26713 : Async<string> = v26712 v26687
                let _run_target_args'_v26697 = v26713 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v26714 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v26715 : Async<string> = v26714 v26687
                let _run_target_args'_v26697 = v26715 
                #endif
#else
                let v26716 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v26717 : Async<string> = v26716 v26687
                let _run_target_args'_v26697 = v26717 
                #endif
                let v26718 : Async<string> = _run_target_args'_v26697 
                return! v26718 
                (* indent
                ()
            indent *)
            with ex ->
                let v26944 : exn = ex
                let v27005 : unit = ()
                let v27006 : (unit -> unit) = closure15(v0, v1, v26944)
                let v27007 : unit = (fun () -> v27006 (); v27005) ()
                (* run_target_args'
                let v27072 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v27073 : (int32 -> Async<unit>) = Async.Sleep
                let v27074 : Async<unit> = v27073 10
                let _run_target_args'_v27072 = v27074 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v27075 : (int32 -> Async<unit>) = Async.Sleep
                let v27076 : Async<unit> = v27075 10
                let _run_target_args'_v27072 = v27076 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v27077 : (int32 -> Async<unit>) = Async.Sleep
                let v27078 : Async<unit> = v27077 10
                let _run_target_args'_v27072 = v27078 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v27079 : (int32 -> Async<unit>) = Async.Sleep
                let v27080 : Async<unit> = v27079 10
                let _run_target_args'_v27072 = v27080 
                #endif
#if FABLE_COMPILER_PYTHON
                let v27081 : (int32 -> Async<unit>) = Async.Sleep
                let v27082 : Async<unit> = v27081 10
                let _run_target_args'_v27072 = v27082 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v27083 : (int32 -> Async<unit>) = Async.Sleep
                let v27084 : Async<unit> = v27083 10
                let _run_target_args'_v27072 = v27084 
                #endif
#else
                let v27085 : (int32 -> Async<unit>) = Async.Sleep
                let v27086 : Async<unit> = v27085 10
                let _run_target_args'_v27072 = v27086 
                #endif
                let v27087 : Async<unit> = _run_target_args'_v27072 
                do! v27087 
                let v27090 : bool = v1 < 3L
                let v27095 : Async<string> =
                    if v27090 then
                        let v27091 : int64 = v1 + 1L
                        method29(v0, v27091)
                    else
                        let v27093 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v27093
                return! v27095 
                (* indent
                ()
            indent *)
            (* try_unit
            let v27249 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v35884 : Async<string> = _let'_v17953 
    let _run_target_args'_v6 = v35884 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35886 : unit = ()
    let _let'_v35886 =
        async {
            try
                (* run_target_args'
                let v44593 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v44595 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v44593 = v44595 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v44599 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v44593 = v44599 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v44603 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v44593 = v44603 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v44607 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v44593 = v44607 
                #endif
#if FABLE_COMPILER_PYTHON
                let v44611 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v44593 = v44611 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v44615 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v44593 = v44615 
                #endif
#else
                let v44618 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v44619 : System.Threading.Tasks.Task<string> = v44618 v0
                let _run_target_args'_v44593 = v44619 
                #endif
                let v44620 : System.Threading.Tasks.Task<string> = _run_target_args'_v44593 
                (* run_target_args'
                let v44630 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v44632 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v44630 = v44632 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v44636 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v44630 = v44636 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v44640 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v44630 = v44640 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v44643 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v44644 : Async<string> = v44643 v44620
                let _run_target_args'_v44630 = v44644 
                #endif
#if FABLE_COMPILER_PYTHON
                let v44645 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v44646 : Async<string> = v44645 v44620
                let _run_target_args'_v44630 = v44646 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v44647 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v44648 : Async<string> = v44647 v44620
                let _run_target_args'_v44630 = v44648 
                #endif
#else
                let v44649 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v44650 : Async<string> = v44649 v44620
                let _run_target_args'_v44630 = v44650 
                #endif
                let v44651 : Async<string> = _run_target_args'_v44630 
                return! v44651 
                (* indent
                ()
            indent *)
            with ex ->
                let v44877 : exn = ex
                let v44938 : unit = ()
                let v44939 : (unit -> unit) = closure15(v0, v1, v44877)
                let v44940 : unit = (fun () -> v44939 (); v44938) ()
                (* run_target_args'
                let v45005 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45006 : (int32 -> Async<unit>) = Async.Sleep
                let v45007 : Async<unit> = v45006 10
                let _run_target_args'_v45005 = v45007 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v45008 : (int32 -> Async<unit>) = Async.Sleep
                let v45009 : Async<unit> = v45008 10
                let _run_target_args'_v45005 = v45009 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v45010 : (int32 -> Async<unit>) = Async.Sleep
                let v45011 : Async<unit> = v45010 10
                let _run_target_args'_v45005 = v45011 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v45012 : (int32 -> Async<unit>) = Async.Sleep
                let v45013 : Async<unit> = v45012 10
                let _run_target_args'_v45005 = v45013 
                #endif
#if FABLE_COMPILER_PYTHON
                let v45014 : (int32 -> Async<unit>) = Async.Sleep
                let v45015 : Async<unit> = v45014 10
                let _run_target_args'_v45005 = v45015 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v45016 : (int32 -> Async<unit>) = Async.Sleep
                let v45017 : Async<unit> = v45016 10
                let _run_target_args'_v45005 = v45017 
                #endif
#else
                let v45018 : (int32 -> Async<unit>) = Async.Sleep
                let v45019 : Async<unit> = v45018 10
                let _run_target_args'_v45005 = v45019 
                #endif
                let v45020 : Async<unit> = _run_target_args'_v45005 
                do! v45020 
                let v45023 : bool = v1 < 3L
                let v45028 : Async<string> =
                    if v45023 then
                        let v45024 : int64 = v1 + 1L
                        method29(v0, v45024)
                    else
                        let v45026 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v45026
                return! v45028 
                (* indent
                ()
            indent *)
            (* try_unit
            let v45182 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v53817 : Async<string> = _let'_v35886 
    let _run_target_args'_v6 = v53817 
    #endif
#else
    let v53819 : unit = ()
    let _let'_v53819 =
        async {
            try
                (* run_target_args'
                let v62526 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v62528 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v62526 = v62528 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v62532 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v62526 = v62532 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v62536 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v62526 = v62536 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v62540 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v62526 = v62540 
                #endif
#if FABLE_COMPILER_PYTHON
                let v62544 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v62526 = v62544 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v62548 : System.Threading.Tasks.Task<string> = null |> unbox<System.Threading.Tasks.Task<string>>
                let _run_target_args'_v62526 = v62548 
                #endif
#else
                let v62551 : (string -> System.Threading.Tasks.Task<string>) = System.IO.File.ReadAllTextAsync
                let v62552 : System.Threading.Tasks.Task<string> = v62551 v0
                let _run_target_args'_v62526 = v62552 
                #endif
                let v62553 : System.Threading.Tasks.Task<string> = _run_target_args'_v62526 
                (* run_target_args'
                let v62563 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v62565 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v62563 = v62565 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v62569 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v62563 = v62569 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v62573 : Async<string> = null |> unbox<Async<string>>
                let _run_target_args'_v62563 = v62573 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v62576 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v62577 : Async<string> = v62576 v62553
                let _run_target_args'_v62563 = v62577 
                #endif
#if FABLE_COMPILER_PYTHON
                let v62578 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v62579 : Async<string> = v62578 v62553
                let _run_target_args'_v62563 = v62579 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v62580 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v62581 : Async<string> = v62580 v62553
                let _run_target_args'_v62563 = v62581 
                #endif
#else
                let v62582 : (System.Threading.Tasks.Task<string> -> Async<string>) = Async.AwaitTask
                let v62583 : Async<string> = v62582 v62553
                let _run_target_args'_v62563 = v62583 
                #endif
                let v62584 : Async<string> = _run_target_args'_v62563 
                return! v62584 
                (* indent
                ()
            indent *)
            with ex ->
                let v62810 : exn = ex
                let v62871 : unit = ()
                let v62872 : (unit -> unit) = closure15(v0, v1, v62810)
                let v62873 : unit = (fun () -> v62872 (); v62871) ()
                (* run_target_args'
                let v62938 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v62939 : (int32 -> Async<unit>) = Async.Sleep
                let v62940 : Async<unit> = v62939 10
                let _run_target_args'_v62938 = v62940 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v62941 : (int32 -> Async<unit>) = Async.Sleep
                let v62942 : Async<unit> = v62941 10
                let _run_target_args'_v62938 = v62942 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v62943 : (int32 -> Async<unit>) = Async.Sleep
                let v62944 : Async<unit> = v62943 10
                let _run_target_args'_v62938 = v62944 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v62945 : (int32 -> Async<unit>) = Async.Sleep
                let v62946 : Async<unit> = v62945 10
                let _run_target_args'_v62938 = v62946 
                #endif
#if FABLE_COMPILER_PYTHON
                let v62947 : (int32 -> Async<unit>) = Async.Sleep
                let v62948 : Async<unit> = v62947 10
                let _run_target_args'_v62938 = v62948 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v62949 : (int32 -> Async<unit>) = Async.Sleep
                let v62950 : Async<unit> = v62949 10
                let _run_target_args'_v62938 = v62950 
                #endif
#else
                let v62951 : (int32 -> Async<unit>) = Async.Sleep
                let v62952 : Async<unit> = v62951 10
                let _run_target_args'_v62938 = v62952 
                #endif
                let v62953 : Async<unit> = _run_target_args'_v62938 
                do! v62953 
                let v62956 : bool = v1 < 3L
                let v62961 : Async<string> =
                    if v62956 then
                        let v62957 : int64 = v1 + 1L
                        method29(v0, v62957)
                    else
                        let v62959 : string = $"file_system.read_all_text_async / retry: {v1} / path: {v0}"
                        failwith<Async<string>> v62959
                return! v62961 
                (* indent
                ()
            indent *)
            (* try_unit
            let v63115 : string = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v71750 : Async<string> = _let'_v53819 
    let _run_target_args'_v6 = v71750 
    #endif
    let v71751 : Async<string> = _run_target_args'_v6 
    v71751
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
            let v65 : Vec<uint8> = method35(v59)
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
    let v63 : Async<unit> = _run_target_args'_v6 
    v63
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
    let v43 : string = $"{v36}"
    let v51 : unit = ()
    let v52 : (unit -> unit) = closure6(v2, v43)
    let v53 : unit = (fun () -> v52 (); v51) ()
    let v59 : string = v2.l0
    v59
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_bright_red"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_bright_red"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[91m"
    let v176 : string = method18()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[91m"
    let v192 : string = method18()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[91m"
    let v208 : string = method18()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[91m"
    let v224 : string = method18()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
    let v83 : string = "inline_colorization::color_reset"
    let v84 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v83 
    let v85 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v86 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v49, v77, v84) v85 
    let v87 : string = "fable_library_rust::String_::fromString($0)"
    let v88 : string = Fable.Core.RustInterop.emitRustExpr v86 v87 
    let _run_target_args'_v47 = v88 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v89 : string = "inline_colorization::color_yellow"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    (* run_target_args'
    let v95 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v96 : string = "&*$0"
    let v97 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v96 
    let _run_target_args'_v95 = v97 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v98 : string = "&*$0"
    let v99 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v98 
    let _run_target_args'_v95 = v99 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v100 : string = "&*$0"
    let v101 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v100 
    let _run_target_args'_v95 = v101 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v103 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v103 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v107 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v111 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v111 
    #endif
#else
    let v115 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v95 = v115 
    #endif
    let v118 : Ref<Str> = _run_target_args'_v95 
    let v124 : string = "inline_colorization::color_reset"
    let v125 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v124 
    let v126 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v127 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v90, v118, v125) v126 
    let v128 : string = "fable_library_rust::String_::fromString($0)"
    let v129 : string = Fable.Core.RustInterop.emitRustExpr v127 v128 
    let _run_target_args'_v47 = v129 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v130 : string = "inline_colorization::color_yellow"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    (* run_target_args'
    let v136 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v137 : string = "&*$0"
    let v138 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v137 
    let _run_target_args'_v136 = v138 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v139 : string = "&*$0"
    let v140 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v139 
    let _run_target_args'_v136 = v140 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v141 : string = "&*$0"
    let v142 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v30 v141 
    let _run_target_args'_v136 = v142 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v144 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v144 
    #endif
#if FABLE_COMPILER_PYTHON
    let v148 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v148 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v152 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v152 
    #endif
#else
    let v156 : Ref<Str> = v30 |> unbox<Ref<Str>>
    let _run_target_args'_v136 = v156 
    #endif
    let v159 : Ref<Str> = _run_target_args'_v136 
    let v165 : string = "inline_colorization::color_reset"
    let v166 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v165 
    let v167 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v168 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v131, v159, v166) v167 
    let v169 : string = "fable_library_rust::String_::fromString($0)"
    let v170 : string = Fable.Core.RustInterop.emitRustExpr v168 v169 
    let _run_target_args'_v47 = v170 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v172 : string = "\u001b[93m"
    let v176 : string = method18()
    let v180 : string = v172 + v30 
    let v184 : string = v180 + v176 
    let _run_target_args'_v47 = v184 
    #endif
#if FABLE_COMPILER_PYTHON
    let v188 : string = "\u001b[93m"
    let v192 : string = method18()
    let v196 : string = v188 + v30 
    let v200 : string = v196 + v192 
    let _run_target_args'_v47 = v200 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v204 : string = "\u001b[93m"
    let v208 : string = method18()
    let v212 : string = v204 + v30 
    let v216 : string = v212 + v208 
    let _run_target_args'_v47 = v216 
    #endif
#else
    let v220 : string = "\u001b[93m"
    let v224 : string = method18()
    let v228 : string = v220 + v30 
    let v232 : string = v228 + v224 
    let _run_target_args'_v47 = v232 
    #endif
    let v235 : string = _run_target_args'_v47 
    v235
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
        let v98 : string = method50(v41, v42, v43, v44, v45, v46, v59, v60, v61, v92)
        method22(v98)
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
                let v14811 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v14812 : string = "std::fs::remove_file(&*$0)"
                let v14813 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v14812 
                let v14814 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v14816 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v14817 : string = "$0.map_err(|x| $1(x))"
                let v14818 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v14813, v14814) v14817 
                let _run_target_args'_v14816 = v14818 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v14819 : string = "$0.map_err(|x| $1(x))"
                let v14820 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v14813, v14814) v14819 
                let _run_target_args'_v14816 = v14820 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v14821 : string = "$0.map_err(|x| $1(x))"
                let v14822 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v14813, v14814) v14821 
                let _run_target_args'_v14816 = v14822 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v14823 : Result<unit, string> = match v14813 with Ok x -> Ok x | Error x -> Error (v14814 x)
                let _run_target_args'_v14816 = v14823 
                #endif
#if FABLE_COMPILER_PYTHON
                let v14824 : Result<unit, string> = match v14813 with Ok x -> Ok x | Error x -> Error (v14814 x)
                let _run_target_args'_v14816 = v14824 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v14825 : Result<unit, string> = match v14813 with Ok x -> Ok x | Error x -> Error (v14814 x)
                let _run_target_args'_v14816 = v14825 
                #endif
#else
                let v14826 : Result<unit, string> = match v14813 with Ok x -> Ok x | Error x -> Error (v14814 x)
                let _run_target_args'_v14816 = v14826 
                #endif
                let v14827 : Result<unit, string> = _run_target_args'_v14816 
                let v14830 : (unit -> US9) = method45()
                let v14831 : (string -> US9) = method46()
                let v14833 : US9 = match v14827 with Ok () -> v14830 () | Error x -> v14831 x
                match v14833 with
                | US9_1(v14836) -> (* Error *)
                    let v14897 : unit = ()
                    let v14898 : (unit -> unit) = closure26(v14836)
                    let v14899 : unit = (fun () -> v14898 (); v14897) ()
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
                let v14960 : (string -> unit) = System.IO.File.Delete
                v14960 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v15335 : exn = ex
                let v15336 : int64 = v1 % 100L
                let v15337 : bool = v15336 = 0L
                if v15337 then
                    let v15435 : unit = ()
                    let v15436 : (unit -> unit) = closure27(v0, v15335)
                    let v15437 : unit = (fun () -> v15436 (); v15435) ()
                    ()
                (* run_target_args'
                let v15539 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v15540 : (int32 -> Async<unit>) = Async.Sleep
                let v15541 : Async<unit> = v15540 10
                let _run_target_args'_v15539 = v15541 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v15542 : (int32 -> Async<unit>) = Async.Sleep
                let v15543 : Async<unit> = v15542 10
                let _run_target_args'_v15539 = v15543 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v15544 : (int32 -> Async<unit>) = Async.Sleep
                let v15545 : Async<unit> = v15544 10
                let _run_target_args'_v15539 = v15545 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v15546 : (int32 -> Async<unit>) = Async.Sleep
                let v15547 : Async<unit> = v15546 10
                let _run_target_args'_v15539 = v15547 
                #endif
#if FABLE_COMPILER_PYTHON
                let v15548 : (int32 -> Async<unit>) = Async.Sleep
                let v15549 : Async<unit> = v15548 10
                let _run_target_args'_v15539 = v15549 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v15550 : (int32 -> Async<unit>) = Async.Sleep
                let v15551 : Async<unit> = v15550 10
                let _run_target_args'_v15539 = v15551 
                #endif
#else
                let v15552 : (int32 -> Async<unit>) = Async.Sleep
                let v15553 : Async<unit> = v15552 10
                let _run_target_args'_v15539 = v15553 
                #endif
                let v15554 : Async<unit> = _run_target_args'_v15539 
                do! v15554 
                let v15557 : int64 = v1 + 1L
                let v15558 : Async<int64> = method42(v0, v15557)
                return! v15558 
                (* indent
                ()
            indent *)
            (* try_unit
            let v15784 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v30425 : Async<int64> = _let'_v20 
    let _run_target_args'_v6 = v30425 
    #endif
#if FABLE_COMPILER_PYTHON
    let v30427 : unit = ()
    let _let'_v30427 =
        async {
            try
                (* run_target_args'
                let v45218 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45219 : string = "std::fs::remove_file(&*$0)"
                let v45220 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v45219 
                let v45221 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v45223 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45224 : string = "$0.map_err(|x| $1(x))"
                let v45225 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v45220, v45221) v45224 
                let _run_target_args'_v45223 = v45225 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v45226 : string = "$0.map_err(|x| $1(x))"
                let v45227 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v45220, v45221) v45226 
                let _run_target_args'_v45223 = v45227 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v45228 : string = "$0.map_err(|x| $1(x))"
                let v45229 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v45220, v45221) v45228 
                let _run_target_args'_v45223 = v45229 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v45230 : Result<unit, string> = match v45220 with Ok x -> Ok x | Error x -> Error (v45221 x)
                let _run_target_args'_v45223 = v45230 
                #endif
#if FABLE_COMPILER_PYTHON
                let v45231 : Result<unit, string> = match v45220 with Ok x -> Ok x | Error x -> Error (v45221 x)
                let _run_target_args'_v45223 = v45231 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v45232 : Result<unit, string> = match v45220 with Ok x -> Ok x | Error x -> Error (v45221 x)
                let _run_target_args'_v45223 = v45232 
                #endif
#else
                let v45233 : Result<unit, string> = match v45220 with Ok x -> Ok x | Error x -> Error (v45221 x)
                let _run_target_args'_v45223 = v45233 
                #endif
                let v45234 : Result<unit, string> = _run_target_args'_v45223 
                let v45237 : (unit -> US9) = method45()
                let v45238 : (string -> US9) = method46()
                let v45240 : US9 = match v45234 with Ok () -> v45237 () | Error x -> v45238 x
                match v45240 with
                | US9_1(v45243) -> (* Error *)
                    let v45304 : unit = ()
                    let v45305 : (unit -> unit) = closure26(v45243)
                    let v45306 : unit = (fun () -> v45305 (); v45304) ()
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
                let v45367 : (string -> unit) = System.IO.File.Delete
                v45367 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v45742 : exn = ex
                let v45743 : int64 = v1 % 100L
                let v45744 : bool = v45743 = 0L
                if v45744 then
                    let v45842 : unit = ()
                    let v45843 : (unit -> unit) = closure27(v0, v45742)
                    let v45844 : unit = (fun () -> v45843 (); v45842) ()
                    ()
                (* run_target_args'
                let v45946 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45947 : (int32 -> Async<unit>) = Async.Sleep
                let v45948 : Async<unit> = v45947 10
                let _run_target_args'_v45946 = v45948 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v45949 : (int32 -> Async<unit>) = Async.Sleep
                let v45950 : Async<unit> = v45949 10
                let _run_target_args'_v45946 = v45950 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v45951 : (int32 -> Async<unit>) = Async.Sleep
                let v45952 : Async<unit> = v45951 10
                let _run_target_args'_v45946 = v45952 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v45953 : (int32 -> Async<unit>) = Async.Sleep
                let v45954 : Async<unit> = v45953 10
                let _run_target_args'_v45946 = v45954 
                #endif
#if FABLE_COMPILER_PYTHON
                let v45955 : (int32 -> Async<unit>) = Async.Sleep
                let v45956 : Async<unit> = v45955 10
                let _run_target_args'_v45946 = v45956 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v45957 : (int32 -> Async<unit>) = Async.Sleep
                let v45958 : Async<unit> = v45957 10
                let _run_target_args'_v45946 = v45958 
                #endif
#else
                let v45959 : (int32 -> Async<unit>) = Async.Sleep
                let v45960 : Async<unit> = v45959 10
                let _run_target_args'_v45946 = v45960 
                #endif
                let v45961 : Async<unit> = _run_target_args'_v45946 
                do! v45961 
                let v45964 : int64 = v1 + 1L
                let v45965 : Async<int64> = method42(v0, v45964)
                return! v45965 
                (* indent
                ()
            indent *)
            (* try_unit
            let v46191 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v60832 : Async<int64> = _let'_v30427 
    let _run_target_args'_v6 = v60832 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v60834 : unit = ()
    let _let'_v60834 =
        async {
            try
                (* run_target_args'
                let v75625 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v75626 : string = "std::fs::remove_file(&*$0)"
                let v75627 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v75626 
                let v75628 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v75630 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v75631 : string = "$0.map_err(|x| $1(x))"
                let v75632 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v75627, v75628) v75631 
                let _run_target_args'_v75630 = v75632 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v75633 : string = "$0.map_err(|x| $1(x))"
                let v75634 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v75627, v75628) v75633 
                let _run_target_args'_v75630 = v75634 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v75635 : string = "$0.map_err(|x| $1(x))"
                let v75636 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v75627, v75628) v75635 
                let _run_target_args'_v75630 = v75636 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v75637 : Result<unit, string> = match v75627 with Ok x -> Ok x | Error x -> Error (v75628 x)
                let _run_target_args'_v75630 = v75637 
                #endif
#if FABLE_COMPILER_PYTHON
                let v75638 : Result<unit, string> = match v75627 with Ok x -> Ok x | Error x -> Error (v75628 x)
                let _run_target_args'_v75630 = v75638 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v75639 : Result<unit, string> = match v75627 with Ok x -> Ok x | Error x -> Error (v75628 x)
                let _run_target_args'_v75630 = v75639 
                #endif
#else
                let v75640 : Result<unit, string> = match v75627 with Ok x -> Ok x | Error x -> Error (v75628 x)
                let _run_target_args'_v75630 = v75640 
                #endif
                let v75641 : Result<unit, string> = _run_target_args'_v75630 
                let v75644 : (unit -> US9) = method45()
                let v75645 : (string -> US9) = method46()
                let v75647 : US9 = match v75641 with Ok () -> v75644 () | Error x -> v75645 x
                match v75647 with
                | US9_1(v75650) -> (* Error *)
                    let v75711 : unit = ()
                    let v75712 : (unit -> unit) = closure26(v75650)
                    let v75713 : unit = (fun () -> v75712 (); v75711) ()
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
                let v75774 : (string -> unit) = System.IO.File.Delete
                v75774 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v76149 : exn = ex
                let v76150 : int64 = v1 % 100L
                let v76151 : bool = v76150 = 0L
                if v76151 then
                    let v76249 : unit = ()
                    let v76250 : (unit -> unit) = closure27(v0, v76149)
                    let v76251 : unit = (fun () -> v76250 (); v76249) ()
                    ()
                (* run_target_args'
                let v76353 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v76354 : (int32 -> Async<unit>) = Async.Sleep
                let v76355 : Async<unit> = v76354 10
                let _run_target_args'_v76353 = v76355 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v76356 : (int32 -> Async<unit>) = Async.Sleep
                let v76357 : Async<unit> = v76356 10
                let _run_target_args'_v76353 = v76357 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v76358 : (int32 -> Async<unit>) = Async.Sleep
                let v76359 : Async<unit> = v76358 10
                let _run_target_args'_v76353 = v76359 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v76360 : (int32 -> Async<unit>) = Async.Sleep
                let v76361 : Async<unit> = v76360 10
                let _run_target_args'_v76353 = v76361 
                #endif
#if FABLE_COMPILER_PYTHON
                let v76362 : (int32 -> Async<unit>) = Async.Sleep
                let v76363 : Async<unit> = v76362 10
                let _run_target_args'_v76353 = v76363 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v76364 : (int32 -> Async<unit>) = Async.Sleep
                let v76365 : Async<unit> = v76364 10
                let _run_target_args'_v76353 = v76365 
                #endif
#else
                let v76366 : (int32 -> Async<unit>) = Async.Sleep
                let v76367 : Async<unit> = v76366 10
                let _run_target_args'_v76353 = v76367 
                #endif
                let v76368 : Async<unit> = _run_target_args'_v76353 
                do! v76368 
                let v76371 : int64 = v1 + 1L
                let v76372 : Async<int64> = method42(v0, v76371)
                return! v76372 
                (* indent
                ()
            indent *)
            (* try_unit
            let v76598 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v91239 : Async<int64> = _let'_v60834 
    let _run_target_args'_v6 = v91239 
    #endif
#else
    let v91241 : unit = ()
    let _let'_v91241 =
        async {
            try
                (* run_target_args'
                let v106032 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v106033 : string = "std::fs::remove_file(&*$0)"
                let v106034 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v106033 
                let v106035 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v106037 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v106038 : string = "$0.map_err(|x| $1(x))"
                let v106039 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v106034, v106035) v106038 
                let _run_target_args'_v106037 = v106039 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v106040 : string = "$0.map_err(|x| $1(x))"
                let v106041 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v106034, v106035) v106040 
                let _run_target_args'_v106037 = v106041 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v106042 : string = "$0.map_err(|x| $1(x))"
                let v106043 : Result<unit, string> = Fable.Core.RustInterop.emitRustExpr struct (v106034, v106035) v106042 
                let _run_target_args'_v106037 = v106043 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v106044 : Result<unit, string> = match v106034 with Ok x -> Ok x | Error x -> Error (v106035 x)
                let _run_target_args'_v106037 = v106044 
                #endif
#if FABLE_COMPILER_PYTHON
                let v106045 : Result<unit, string> = match v106034 with Ok x -> Ok x | Error x -> Error (v106035 x)
                let _run_target_args'_v106037 = v106045 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v106046 : Result<unit, string> = match v106034 with Ok x -> Ok x | Error x -> Error (v106035 x)
                let _run_target_args'_v106037 = v106046 
                #endif
#else
                let v106047 : Result<unit, string> = match v106034 with Ok x -> Ok x | Error x -> Error (v106035 x)
                let _run_target_args'_v106037 = v106047 
                #endif
                let v106048 : Result<unit, string> = _run_target_args'_v106037 
                let v106051 : (unit -> US9) = method45()
                let v106052 : (string -> US9) = method46()
                let v106054 : US9 = match v106048 with Ok () -> v106051 () | Error x -> v106052 x
                match v106054 with
                | US9_1(v106057) -> (* Error *)
                    let v106118 : unit = ()
                    let v106119 : (unit -> unit) = closure26(v106057)
                    let v106120 : unit = (fun () -> v106119 (); v106118) ()
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
                let v106181 : (string -> unit) = System.IO.File.Delete
                v106181 v0
                #endif
                // run_target_args' is_unit
                return v1 
                (* indent
                ()
            indent *)
            with ex ->
                let v106556 : exn = ex
                let v106557 : int64 = v1 % 100L
                let v106558 : bool = v106557 = 0L
                if v106558 then
                    let v106656 : unit = ()
                    let v106657 : (unit -> unit) = closure27(v0, v106556)
                    let v106658 : unit = (fun () -> v106657 (); v106656) ()
                    ()
                (* run_target_args'
                let v106760 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v106761 : (int32 -> Async<unit>) = Async.Sleep
                let v106762 : Async<unit> = v106761 10
                let _run_target_args'_v106760 = v106762 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v106763 : (int32 -> Async<unit>) = Async.Sleep
                let v106764 : Async<unit> = v106763 10
                let _run_target_args'_v106760 = v106764 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v106765 : (int32 -> Async<unit>) = Async.Sleep
                let v106766 : Async<unit> = v106765 10
                let _run_target_args'_v106760 = v106766 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v106767 : (int32 -> Async<unit>) = Async.Sleep
                let v106768 : Async<unit> = v106767 10
                let _run_target_args'_v106760 = v106768 
                #endif
#if FABLE_COMPILER_PYTHON
                let v106769 : (int32 -> Async<unit>) = Async.Sleep
                let v106770 : Async<unit> = v106769 10
                let _run_target_args'_v106760 = v106770 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v106771 : (int32 -> Async<unit>) = Async.Sleep
                let v106772 : Async<unit> = v106771 10
                let _run_target_args'_v106760 = v106772 
                #endif
#else
                let v106773 : (int32 -> Async<unit>) = Async.Sleep
                let v106774 : Async<unit> = v106773 10
                let _run_target_args'_v106760 = v106774 
                #endif
                let v106775 : Async<unit> = _run_target_args'_v106760 
                do! v106775 
                let v106778 : int64 = v1 + 1L
                let v106779 : Async<int64> = method42(v0, v106778)
                return! v106779 
                (* indent
                ()
            indent *)
            (* try_unit
            let v107005 : int64 = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v121646 : Async<int64> = _let'_v91241 
    let _run_target_args'_v6 = v121646 
    #endif
    let v121647 : Async<int64> = _run_target_args'_v6 
    v121647
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
        let v100 : string = method55(v42, v43, v44, v45, v46, v47, v60, v61, v62, v63, v94)
        method22(v100)
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
                let v9064 : exn = ex
                let v9065 : int64 = v2 % 100L
                let v9066 : bool = v9065 = 0L
                if v9066 then
                    let v9165 : unit = ()
                    let v9166 : (unit -> unit) = closure30(v0, v1, v9064)
                    let v9167 : unit = (fun () -> v9166 (); v9165) ()
                    ()
                (* run_target_args'
                let v9270 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v9271 : (int32 -> Async<unit>) = Async.Sleep
                let v9272 : Async<unit> = v9271 10
                let _run_target_args'_v9270 = v9272 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v9273 : (int32 -> Async<unit>) = Async.Sleep
                let v9274 : Async<unit> = v9273 10
                let _run_target_args'_v9270 = v9274 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v9275 : (int32 -> Async<unit>) = Async.Sleep
                let v9276 : Async<unit> = v9275 10
                let _run_target_args'_v9270 = v9276 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v9277 : (int32 -> Async<unit>) = Async.Sleep
                let v9278 : Async<unit> = v9277 10
                let _run_target_args'_v9270 = v9278 
                #endif
#if FABLE_COMPILER_PYTHON
                let v9279 : (int32 -> Async<unit>) = Async.Sleep
                let v9280 : Async<unit> = v9279 10
                let _run_target_args'_v9270 = v9280 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v9281 : (int32 -> Async<unit>) = Async.Sleep
                let v9282 : Async<unit> = v9281 10
                let _run_target_args'_v9270 = v9282 
                #endif
#else
                let v9283 : (int32 -> Async<unit>) = Async.Sleep
                let v9284 : Async<unit> = v9283 10
                let _run_target_args'_v9270 = v9284 
                #endif
                let v9285 : Async<unit> = _run_target_args'_v9270 
                do! v9285 
                let v9288 : int64 = v2 + 1L
                let v9289 : Async<int64> = method52(v0, v1, v9288)
                return! v9289 
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
    let v18330 : Async<int64> = _let'_v21 
    let _run_target_args'_v7 = v18330 
    #endif
#if FABLE_COMPILER_PYTHON
    let v18332 : unit = ()
    let _let'_v18332 =
        async {
            try
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v27375 : exn = ex
                let v27376 : int64 = v2 % 100L
                let v27377 : bool = v27376 = 0L
                if v27377 then
                    let v27476 : unit = ()
                    let v27477 : (unit -> unit) = closure30(v0, v1, v27375)
                    let v27478 : unit = (fun () -> v27477 (); v27476) ()
                    ()
                (* run_target_args'
                let v27581 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v27582 : (int32 -> Async<unit>) = Async.Sleep
                let v27583 : Async<unit> = v27582 10
                let _run_target_args'_v27581 = v27583 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v27584 : (int32 -> Async<unit>) = Async.Sleep
                let v27585 : Async<unit> = v27584 10
                let _run_target_args'_v27581 = v27585 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v27586 : (int32 -> Async<unit>) = Async.Sleep
                let v27587 : Async<unit> = v27586 10
                let _run_target_args'_v27581 = v27587 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v27588 : (int32 -> Async<unit>) = Async.Sleep
                let v27589 : Async<unit> = v27588 10
                let _run_target_args'_v27581 = v27589 
                #endif
#if FABLE_COMPILER_PYTHON
                let v27590 : (int32 -> Async<unit>) = Async.Sleep
                let v27591 : Async<unit> = v27590 10
                let _run_target_args'_v27581 = v27591 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v27592 : (int32 -> Async<unit>) = Async.Sleep
                let v27593 : Async<unit> = v27592 10
                let _run_target_args'_v27581 = v27593 
                #endif
#else
                let v27594 : (int32 -> Async<unit>) = Async.Sleep
                let v27595 : Async<unit> = v27594 10
                let _run_target_args'_v27581 = v27595 
                #endif
                let v27596 : Async<unit> = _run_target_args'_v27581 
                do! v27596 
                let v27599 : int64 = v2 + 1L
                let v27600 : Async<int64> = method52(v0, v1, v27599)
                return! v27600 
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
    let v36641 : Async<int64> = _let'_v18332 
    let _run_target_args'_v7 = v36641 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v36643 : unit = ()
    let _let'_v36643 =
        async {
            try
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v45686 : exn = ex
                let v45687 : int64 = v2 % 100L
                let v45688 : bool = v45687 = 0L
                if v45688 then
                    let v45787 : unit = ()
                    let v45788 : (unit -> unit) = closure30(v0, v1, v45686)
                    let v45789 : unit = (fun () -> v45788 (); v45787) ()
                    ()
                (* run_target_args'
                let v45892 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v45893 : (int32 -> Async<unit>) = Async.Sleep
                let v45894 : Async<unit> = v45893 10
                let _run_target_args'_v45892 = v45894 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v45895 : (int32 -> Async<unit>) = Async.Sleep
                let v45896 : Async<unit> = v45895 10
                let _run_target_args'_v45892 = v45896 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v45897 : (int32 -> Async<unit>) = Async.Sleep
                let v45898 : Async<unit> = v45897 10
                let _run_target_args'_v45892 = v45898 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v45899 : (int32 -> Async<unit>) = Async.Sleep
                let v45900 : Async<unit> = v45899 10
                let _run_target_args'_v45892 = v45900 
                #endif
#if FABLE_COMPILER_PYTHON
                let v45901 : (int32 -> Async<unit>) = Async.Sleep
                let v45902 : Async<unit> = v45901 10
                let _run_target_args'_v45892 = v45902 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v45903 : (int32 -> Async<unit>) = Async.Sleep
                let v45904 : Async<unit> = v45903 10
                let _run_target_args'_v45892 = v45904 
                #endif
#else
                let v45905 : (int32 -> Async<unit>) = Async.Sleep
                let v45906 : Async<unit> = v45905 10
                let _run_target_args'_v45892 = v45906 
                #endif
                let v45907 : Async<unit> = _run_target_args'_v45892 
                do! v45907 
                let v45910 : int64 = v2 + 1L
                let v45911 : Async<int64> = method52(v0, v1, v45910)
                return! v45911 
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
    let v54952 : Async<int64> = _let'_v36643 
    let _run_target_args'_v7 = v54952 
    #endif
#else
    let v54954 : unit = ()
    let _let'_v54954 =
        async {
            try
                method54(v0, v1)
                return v2 
                (* indent
                ()
            indent *)
            with ex ->
                let v63997 : exn = ex
                let v63998 : int64 = v2 % 100L
                let v63999 : bool = v63998 = 0L
                if v63999 then
                    let v64098 : unit = ()
                    let v64099 : (unit -> unit) = closure30(v0, v1, v63997)
                    let v64100 : unit = (fun () -> v64099 (); v64098) ()
                    ()
                (* run_target_args'
                let v64203 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v64204 : (int32 -> Async<unit>) = Async.Sleep
                let v64205 : Async<unit> = v64204 10
                let _run_target_args'_v64203 = v64205 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v64206 : (int32 -> Async<unit>) = Async.Sleep
                let v64207 : Async<unit> = v64206 10
                let _run_target_args'_v64203 = v64207 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v64208 : (int32 -> Async<unit>) = Async.Sleep
                let v64209 : Async<unit> = v64208 10
                let _run_target_args'_v64203 = v64209 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v64210 : (int32 -> Async<unit>) = Async.Sleep
                let v64211 : Async<unit> = v64210 10
                let _run_target_args'_v64203 = v64211 
                #endif
#if FABLE_COMPILER_PYTHON
                let v64212 : (int32 -> Async<unit>) = Async.Sleep
                let v64213 : Async<unit> = v64212 10
                let _run_target_args'_v64203 = v64213 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v64214 : (int32 -> Async<unit>) = Async.Sleep
                let v64215 : Async<unit> = v64214 10
                let _run_target_args'_v64203 = v64215 
                #endif
#else
                let v64216 : (int32 -> Async<unit>) = Async.Sleep
                let v64217 : Async<unit> = v64216 10
                let _run_target_args'_v64203 = v64217 
                #endif
                let v64218 : Async<unit> = _run_target_args'_v64203 
                do! v64218 
                let v64221 : int64 = v2 + 1L
                let v64222 : Async<int64> = method52(v0, v1, v64221)
                return! v64222 
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
    let v73263 : Async<int64> = _let'_v54954 
    let _run_target_args'_v7 = v73263 
    #endif
    let v73264 : Async<int64> = _run_target_args'_v7 
    v73264
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
            let v516 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v521 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v523 : US10 = null |> unbox<US10>
            let _run_target_args'_v521 = v523 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v527 : US10 = null |> unbox<US10>
            let _run_target_args'_v521 = v527 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v531 : US10 = null |> unbox<US10>
            let _run_target_args'_v521 = v531 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v535 : US10 = null |> unbox<US10>
            let _run_target_args'_v521 = v535 
            #endif
#if FABLE_COMPILER_PYTHON
            let v539 : US10 = null |> unbox<US10>
            let _run_target_args'_v521 = v539 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v542 : (int64 -> US10) = method62()
            let v543 : (exn -> US10) = method63()
            let v544 : US10 = match v516 with Choice1Of2 x -> v542 x | Choice2Of2 x -> v543 x
            let _run_target_args'_v521 = v544 
            #endif
#else
            let v545 : (int64 -> US10) = method62()
            let v546 : (exn -> US10) = method63()
            let v547 : US10 = match v516 with Choice1Of2 x -> v545 x | Choice2Of2 x -> v546 x
            let _run_target_args'_v521 = v547 
            #endif
            let v548 : US10 = _run_target_args'_v521 
            return v548 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1048 : Async<US10> = _let'_v19 
    let _run_target_args'_v5 = v1048 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1050 : unit = ()
    let _let'_v1050 =
        async {
            let! v0 = v0 
            let v1547 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v1552 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1554 : US10 = null |> unbox<US10>
            let _run_target_args'_v1552 = v1554 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1558 : US10 = null |> unbox<US10>
            let _run_target_args'_v1552 = v1558 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1562 : US10 = null |> unbox<US10>
            let _run_target_args'_v1552 = v1562 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1566 : US10 = null |> unbox<US10>
            let _run_target_args'_v1552 = v1566 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1570 : US10 = null |> unbox<US10>
            let _run_target_args'_v1552 = v1570 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1573 : (int64 -> US10) = method62()
            let v1574 : (exn -> US10) = method63()
            let v1575 : US10 = match v1547 with Choice1Of2 x -> v1573 x | Choice2Of2 x -> v1574 x
            let _run_target_args'_v1552 = v1575 
            #endif
#else
            let v1576 : (int64 -> US10) = method62()
            let v1577 : (exn -> US10) = method63()
            let v1578 : US10 = match v1547 with Choice1Of2 x -> v1576 x | Choice2Of2 x -> v1577 x
            let _run_target_args'_v1552 = v1578 
            #endif
            let v1579 : US10 = _run_target_args'_v1552 
            return v1579 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2079 : Async<US10> = _let'_v1050 
    let _run_target_args'_v5 = v2079 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2081 : unit = ()
    let _let'_v2081 =
        async {
            let! v0 = v0 
            let v2578 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v2583 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2585 : US10 = null |> unbox<US10>
            let _run_target_args'_v2583 = v2585 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2589 : US10 = null |> unbox<US10>
            let _run_target_args'_v2583 = v2589 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2593 : US10 = null |> unbox<US10>
            let _run_target_args'_v2583 = v2593 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2597 : US10 = null |> unbox<US10>
            let _run_target_args'_v2583 = v2597 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2601 : US10 = null |> unbox<US10>
            let _run_target_args'_v2583 = v2601 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2604 : (int64 -> US10) = method62()
            let v2605 : (exn -> US10) = method63()
            let v2606 : US10 = match v2578 with Choice1Of2 x -> v2604 x | Choice2Of2 x -> v2605 x
            let _run_target_args'_v2583 = v2606 
            #endif
#else
            let v2607 : (int64 -> US10) = method62()
            let v2608 : (exn -> US10) = method63()
            let v2609 : US10 = match v2578 with Choice1Of2 x -> v2607 x | Choice2Of2 x -> v2608 x
            let _run_target_args'_v2583 = v2609 
            #endif
            let v2610 : US10 = _run_target_args'_v2583 
            return v2610 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3110 : Async<US10> = _let'_v2081 
    let _run_target_args'_v5 = v3110 
    #endif
#else
    let v3112 : unit = ()
    let _let'_v3112 =
        async {
            let! v0 = v0 
            let v3609 : Choice<int64, exn> = v0 
            (* run_target_args'
            let v3614 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3616 : US10 = null |> unbox<US10>
            let _run_target_args'_v3614 = v3616 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3620 : US10 = null |> unbox<US10>
            let _run_target_args'_v3614 = v3620 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3624 : US10 = null |> unbox<US10>
            let _run_target_args'_v3614 = v3624 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3628 : US10 = null |> unbox<US10>
            let _run_target_args'_v3614 = v3628 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3632 : US10 = null |> unbox<US10>
            let _run_target_args'_v3614 = v3632 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3635 : (int64 -> US10) = method62()
            let v3636 : (exn -> US10) = method63()
            let v3637 : US10 = match v3609 with Choice1Of2 x -> v3635 x | Choice2Of2 x -> v3636 x
            let _run_target_args'_v3614 = v3637 
            #endif
#else
            let v3638 : (int64 -> US10) = method62()
            let v3639 : (exn -> US10) = method63()
            let v3640 : US10 = match v3609 with Choice1Of2 x -> v3638 x | Choice2Of2 x -> v3639 x
            let _run_target_args'_v3614 = v3640 
            #endif
            let v3641 : US10 = _run_target_args'_v3614 
            return v3641 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4141 : Async<US10> = _let'_v3112 
    let _run_target_args'_v5 = v4141 
    #endif
    let v4142 : Async<US10> = _run_target_args'_v5 
    v4142
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
        let v97 : string = method67(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method22(v97)
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
            let v4404 : US11 = v1 
            let v4740 : US2 =
                match v4404 with
                | US11_1(v4407) -> (* Error *)
                    let v4409 : string = $"%A{v4407}"
                    let v4414 : string = "System.TimeoutException"
                    let v4415 : bool = v4409.Contains v4414 
                    if v4415 then
                        let v4478 : unit = ()
                        let v4479 : (unit -> unit) = closure34(v0)
                        let v4480 : unit = (fun () -> v4479 (); v4478) ()
                        US2_1
                    else
                        let v4638 : unit = ()
                        let v4639 : (unit -> unit) = closure35(v0, v4407)
                        let v4640 : unit = (fun () -> v4639 (); v4638) ()
                        US2_1
                | US11_0(v4405) -> (* Ok *)
                    US2_0(v4405)
            return v4740 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v9122 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v9122 
    #endif
#if FABLE_COMPILER_PYTHON
    let v9124 : unit = ()
    let _let'_v9124 =
        async {
            let! v1 = v1 
            let v13508 : US11 = v1 
            let v13844 : US2 =
                match v13508 with
                | US11_1(v13511) -> (* Error *)
                    let v13513 : string = $"%A{v13511}"
                    let v13518 : string = "System.TimeoutException"
                    let v13519 : bool = v13513.Contains v13518 
                    if v13519 then
                        let v13582 : unit = ()
                        let v13583 : (unit -> unit) = closure34(v0)
                        let v13584 : unit = (fun () -> v13583 (); v13582) ()
                        US2_1
                    else
                        let v13742 : unit = ()
                        let v13743 : (unit -> unit) = closure35(v0, v13511)
                        let v13744 : unit = (fun () -> v13743 (); v13742) ()
                        US2_1
                | US11_0(v13509) -> (* Ok *)
                    US2_0(v13509)
            return v13844 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v18226 : Async<US2> = _let'_v9124 
    let _run_target_args'_v6 = v18226 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v18228 : unit = ()
    let _let'_v18228 =
        async {
            let! v1 = v1 
            let v22612 : US11 = v1 
            let v22948 : US2 =
                match v22612 with
                | US11_1(v22615) -> (* Error *)
                    let v22617 : string = $"%A{v22615}"
                    let v22622 : string = "System.TimeoutException"
                    let v22623 : bool = v22617.Contains v22622 
                    if v22623 then
                        let v22686 : unit = ()
                        let v22687 : (unit -> unit) = closure34(v0)
                        let v22688 : unit = (fun () -> v22687 (); v22686) ()
                        US2_1
                    else
                        let v22846 : unit = ()
                        let v22847 : (unit -> unit) = closure35(v0, v22615)
                        let v22848 : unit = (fun () -> v22847 (); v22846) ()
                        US2_1
                | US11_0(v22613) -> (* Ok *)
                    US2_0(v22613)
            return v22948 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v27330 : Async<US2> = _let'_v18228 
    let _run_target_args'_v6 = v27330 
    #endif
#else
    let v27332 : unit = ()
    let _let'_v27332 =
        async {
            let! v1 = v1 
            let v31716 : US11 = v1 
            let v32052 : US2 =
                match v31716 with
                | US11_1(v31719) -> (* Error *)
                    let v31721 : string = $"%A{v31719}"
                    let v31726 : string = "System.TimeoutException"
                    let v31727 : bool = v31721.Contains v31726 
                    if v31727 then
                        let v31790 : unit = ()
                        let v31791 : (unit -> unit) = closure34(v0)
                        let v31792 : unit = (fun () -> v31791 (); v31790) ()
                        US2_1
                    else
                        let v31950 : unit = ()
                        let v31951 : (unit -> unit) = closure35(v0, v31719)
                        let v31952 : unit = (fun () -> v31951 (); v31950) ()
                        US2_1
                | US11_0(v31717) -> (* Ok *)
                    US2_0(v31717)
            return v32052 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v36434 : Async<US2> = _let'_v27332 
    let _run_target_args'_v6 = v36434 
    #endif
    let v36435 : Async<US2> = _run_target_args'_v6 
    v36435
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
            let v833 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v835 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v833 = v835 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v839 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v833 = v839 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v843 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v833 = v843 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v846 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v846 
            #endif
#if FABLE_COMPILER_PYTHON
            let v847 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v847 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v848 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v848 
            #endif
#else
            let v849 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v833 = v849 
            #endif
            let v850 : Async<Async<int64>> = _run_target_args'_v833 
            let! v850 = v850 
            let v856 : Async<int64> = v850 
            (* run_target_args'
            let v861 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v863 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v861 = v863 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v867 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v861 = v867 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v871 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v861 = v871 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v874 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v875 : Async<Choice<int64, exn>> = v874 v856
            let _run_target_args'_v861 = v875 
            #endif
#if FABLE_COMPILER_PYTHON
            let v876 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v877 : Async<Choice<int64, exn>> = v876 v856
            let _run_target_args'_v861 = v877 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v878 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v879 : Async<Choice<int64, exn>> = v878 v856
            let _run_target_args'_v861 = v879 
            #endif
#else
            let v880 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v881 : Async<Choice<int64, exn>> = v880 v856
            let _run_target_args'_v861 = v881 
            #endif
            let v882 : Async<Choice<int64, exn>> = _run_target_args'_v861 
            let v888 : Async<US10> = method61(v882)
            let v889 : Async<US11> = method64(v888)
            let v890 : Async<US2> = method65(v1, v889)
            return! v890 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1697 : Async<US2> = _let'_v20 
    let _run_target_args'_v6 = v1697 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1699 : unit = ()
    let _let'_v1699 =
        async {
            (* run_target_args'
            let v2512 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2514 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2512 = v2514 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2518 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2512 = v2518 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2522 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v2512 = v2522 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2525 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2525 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2526 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2526 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2527 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2527 
            #endif
#else
            let v2528 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v2512 = v2528 
            #endif
            let v2529 : Async<Async<int64>> = _run_target_args'_v2512 
            let! v2529 = v2529 
            let v2535 : Async<int64> = v2529 
            (* run_target_args'
            let v2540 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2542 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2540 = v2542 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2546 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2540 = v2546 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2550 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v2540 = v2550 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2553 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2554 : Async<Choice<int64, exn>> = v2553 v2535
            let _run_target_args'_v2540 = v2554 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2555 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2556 : Async<Choice<int64, exn>> = v2555 v2535
            let _run_target_args'_v2540 = v2556 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2557 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2558 : Async<Choice<int64, exn>> = v2557 v2535
            let _run_target_args'_v2540 = v2558 
            #endif
#else
            let v2559 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v2560 : Async<Choice<int64, exn>> = v2559 v2535
            let _run_target_args'_v2540 = v2560 
            #endif
            let v2561 : Async<Choice<int64, exn>> = _run_target_args'_v2540 
            let v2567 : Async<US10> = method61(v2561)
            let v2568 : Async<US11> = method64(v2567)
            let v2569 : Async<US2> = method65(v1, v2568)
            return! v2569 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3376 : Async<US2> = _let'_v1699 
    let _run_target_args'_v6 = v3376 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3378 : unit = ()
    let _let'_v3378 =
        async {
            (* run_target_args'
            let v4191 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4193 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4191 = v4193 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4197 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4191 = v4197 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4201 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v4191 = v4201 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4204 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4204 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4205 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4205 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4206 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4206 
            #endif
#else
            let v4207 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v4191 = v4207 
            #endif
            let v4208 : Async<Async<int64>> = _run_target_args'_v4191 
            let! v4208 = v4208 
            let v4214 : Async<int64> = v4208 
            (* run_target_args'
            let v4219 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v4221 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4219 = v4221 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v4225 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4219 = v4225 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v4229 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v4219 = v4229 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v4232 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4233 : Async<Choice<int64, exn>> = v4232 v4214
            let _run_target_args'_v4219 = v4233 
            #endif
#if FABLE_COMPILER_PYTHON
            let v4234 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4235 : Async<Choice<int64, exn>> = v4234 v4214
            let _run_target_args'_v4219 = v4235 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v4236 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4237 : Async<Choice<int64, exn>> = v4236 v4214
            let _run_target_args'_v4219 = v4237 
            #endif
#else
            let v4238 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v4239 : Async<Choice<int64, exn>> = v4238 v4214
            let _run_target_args'_v4219 = v4239 
            #endif
            let v4240 : Async<Choice<int64, exn>> = _run_target_args'_v4219 
            let v4246 : Async<US10> = method61(v4240)
            let v4247 : Async<US11> = method64(v4246)
            let v4248 : Async<US2> = method65(v1, v4247)
            return! v4248 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v5055 : Async<US2> = _let'_v3378 
    let _run_target_args'_v6 = v5055 
    #endif
#else
    let v5057 : unit = ()
    let _let'_v5057 =
        async {
            (* run_target_args'
            let v5870 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5872 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v5870 = v5872 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5876 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v5870 = v5876 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5880 : Async<Async<int64>> = null |> unbox<Async<Async<int64>>>
            let _run_target_args'_v5870 = v5880 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5883 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5883 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5884 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5884 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v5885 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5885 
            #endif
#else
            let v5886 : Async<Async<int64>> = Async.StartChild (v0, v1)
            let _run_target_args'_v5870 = v5886 
            #endif
            let v5887 : Async<Async<int64>> = _run_target_args'_v5870 
            let! v5887 = v5887 
            let v5893 : Async<int64> = v5887 
            (* run_target_args'
            let v5898 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v5900 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v5898 = v5900 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v5904 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v5898 = v5904 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v5908 : Async<Choice<int64, exn>> = null |> unbox<Async<Choice<int64, exn>>>
            let _run_target_args'_v5898 = v5908 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v5911 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v5912 : Async<Choice<int64, exn>> = v5911 v5893
            let _run_target_args'_v5898 = v5912 
            #endif
#if FABLE_COMPILER_PYTHON
            let v5913 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v5914 : Async<Choice<int64, exn>> = v5913 v5893
            let _run_target_args'_v5898 = v5914 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v5915 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v5916 : Async<Choice<int64, exn>> = v5915 v5893
            let _run_target_args'_v5898 = v5916 
            #endif
#else
            let v5917 : (Async<int64> -> Async<Choice<int64, exn>>) = Async.Catch
            let v5918 : Async<Choice<int64, exn>> = v5917 v5893
            let _run_target_args'_v5898 = v5918 
            #endif
            let v5919 : Async<Choice<int64, exn>> = _run_target_args'_v5898 
            let v5925 : Async<US10> = method61(v5919)
            let v5926 : Async<US11> = method64(v5925)
            let v5927 : Async<US2> = method65(v1, v5926)
            return! v5927 
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v6734 : Async<US2> = _let'_v5057 
    let _run_target_args'_v6 = v6734 
    #endif
    let v6735 : Async<US2> = _run_target_args'_v6 
    v6735
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
        let v97 : string = method69(v41, v42, v43, v44, v45, v46, v59, v60, v0, v91)
        method22(v97)
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
                let v9511 : bool = v1 > 0L
                if v9511 then
                    let v9512 : Async<int64> = method27(v0)
                    let v9513 : int32 = 1000
                    let v9514 : Async<US2> = method59(v9513, v9512)
                    (* run_target_args'
                    let v9519 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v9521 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v9519 = v9521 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v9525 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v9519 = v9525 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v9529 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v9519 = v9529 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v9532 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9533 : Async<unit> = v9532 v9514
                    let _run_target_args'_v9519 = v9533 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v9534 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9535 : Async<unit> = v9534 v9514
                    let _run_target_args'_v9519 = v9535 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v9536 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9537 : Async<unit> = v9536 v9514
                    let _run_target_args'_v9519 = v9537 
                    #endif
#else
                    let v9538 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v9539 : Async<unit> = v9538 v9514
                    let _run_target_args'_v9519 = v9539 
                    #endif
                    let v9540 : Async<unit> = _run_target_args'_v9519 
                    do! v9540 
                    ()
                let v9546 : Async<string> = method28(v0)
                let v9547 : Async<string option> = method68(v9546)
                return! v9547 
                (* indent
                ()
            indent *)
            with ex ->
                let v9789 : exn = ex
                let v9790 : bool = v1 = 0L
                let v9791 : bool = v9790 <> true
                if v9791 then
                    let v9888 : unit = ()
                    let v9889 : (unit -> unit) = closure36(v1, v9789)
                    let v9890 : unit = (fun () -> v9889 (); v9888) ()
                    let v9988 : string option = None
                    return v9988 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v9991 : int64 = v1 + 1L
                    let v9992 : Async<string option> = method57(v0, v9991)
                    return! v9992 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v10198 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v19652 : Async<string option> = _let'_v20 
    let _run_target_args'_v6 = v19652 
    #endif
#if FABLE_COMPILER_PYTHON
    let v19654 : unit = ()
    let _let'_v19654 =
        async {
            try
                let v29145 : bool = v1 > 0L
                if v29145 then
                    let v29146 : Async<int64> = method27(v0)
                    let v29147 : int32 = 1000
                    let v29148 : Async<US2> = method59(v29147, v29146)
                    (* run_target_args'
                    let v29153 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v29155 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29153 = v29155 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v29159 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29153 = v29159 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v29163 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v29153 = v29163 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v29166 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29167 : Async<unit> = v29166 v29148
                    let _run_target_args'_v29153 = v29167 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v29168 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29169 : Async<unit> = v29168 v29148
                    let _run_target_args'_v29153 = v29169 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v29170 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29171 : Async<unit> = v29170 v29148
                    let _run_target_args'_v29153 = v29171 
                    #endif
#else
                    let v29172 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v29173 : Async<unit> = v29172 v29148
                    let _run_target_args'_v29153 = v29173 
                    #endif
                    let v29174 : Async<unit> = _run_target_args'_v29153 
                    do! v29174 
                    ()
                let v29180 : Async<string> = method28(v0)
                let v29181 : Async<string option> = method68(v29180)
                return! v29181 
                (* indent
                ()
            indent *)
            with ex ->
                let v29423 : exn = ex
                let v29424 : bool = v1 = 0L
                let v29425 : bool = v29424 <> true
                if v29425 then
                    let v29522 : unit = ()
                    let v29523 : (unit -> unit) = closure36(v1, v29423)
                    let v29524 : unit = (fun () -> v29523 (); v29522) ()
                    let v29622 : string option = None
                    return v29622 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v29625 : int64 = v1 + 1L
                    let v29626 : Async<string option> = method57(v0, v29625)
                    return! v29626 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v29832 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v39286 : Async<string option> = _let'_v19654 
    let _run_target_args'_v6 = v39286 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v39288 : unit = ()
    let _let'_v39288 =
        async {
            try
                let v48779 : bool = v1 > 0L
                if v48779 then
                    let v48780 : Async<int64> = method27(v0)
                    let v48781 : int32 = 1000
                    let v48782 : Async<US2> = method59(v48781, v48780)
                    (* run_target_args'
                    let v48787 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v48789 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v48787 = v48789 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v48793 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v48787 = v48793 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v48797 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v48787 = v48797 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v48800 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v48801 : Async<unit> = v48800 v48782
                    let _run_target_args'_v48787 = v48801 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v48802 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v48803 : Async<unit> = v48802 v48782
                    let _run_target_args'_v48787 = v48803 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v48804 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v48805 : Async<unit> = v48804 v48782
                    let _run_target_args'_v48787 = v48805 
                    #endif
#else
                    let v48806 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v48807 : Async<unit> = v48806 v48782
                    let _run_target_args'_v48787 = v48807 
                    #endif
                    let v48808 : Async<unit> = _run_target_args'_v48787 
                    do! v48808 
                    ()
                let v48814 : Async<string> = method28(v0)
                let v48815 : Async<string option> = method68(v48814)
                return! v48815 
                (* indent
                ()
            indent *)
            with ex ->
                let v49057 : exn = ex
                let v49058 : bool = v1 = 0L
                let v49059 : bool = v49058 <> true
                if v49059 then
                    let v49156 : unit = ()
                    let v49157 : (unit -> unit) = closure36(v1, v49057)
                    let v49158 : unit = (fun () -> v49157 (); v49156) ()
                    let v49256 : string option = None
                    return v49256 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v49259 : int64 = v1 + 1L
                    let v49260 : Async<string option> = method57(v0, v49259)
                    return! v49260 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v49466 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v58920 : Async<string option> = _let'_v39288 
    let _run_target_args'_v6 = v58920 
    #endif
#else
    let v58922 : unit = ()
    let _let'_v58922 =
        async {
            try
                let v68413 : bool = v1 > 0L
                if v68413 then
                    let v68414 : Async<int64> = method27(v0)
                    let v68415 : int32 = 1000
                    let v68416 : Async<US2> = method59(v68415, v68414)
                    (* run_target_args'
                    let v68421 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v68423 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v68421 = v68423 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v68427 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v68421 = v68427 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v68431 : Async<unit> = null |> unbox<Async<unit>>
                    let _run_target_args'_v68421 = v68431 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v68434 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v68435 : Async<unit> = v68434 v68416
                    let _run_target_args'_v68421 = v68435 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v68436 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v68437 : Async<unit> = v68436 v68416
                    let _run_target_args'_v68421 = v68437 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v68438 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v68439 : Async<unit> = v68438 v68416
                    let _run_target_args'_v68421 = v68439 
                    #endif
#else
                    let v68440 : (Async<US2> -> Async<unit>) = Async.Ignore
                    let v68441 : Async<unit> = v68440 v68416
                    let _run_target_args'_v68421 = v68441 
                    #endif
                    let v68442 : Async<unit> = _run_target_args'_v68421 
                    do! v68442 
                    ()
                let v68448 : Async<string> = method28(v0)
                let v68449 : Async<string option> = method68(v68448)
                return! v68449 
                (* indent
                ()
            indent *)
            with ex ->
                let v68691 : exn = ex
                let v68692 : bool = v1 = 0L
                let v68693 : bool = v68692 <> true
                if v68693 then
                    let v68790 : unit = ()
                    let v68791 : (unit -> unit) = closure36(v1, v68691)
                    let v68792 : unit = (fun () -> v68791 (); v68790) ()
                    let v68890 : string option = None
                    return v68890 
                    (* fix_condition then
                    ()
                else
                    fix_condition then *) else
                    let v68893 : int64 = v1 + 1L
                    let v68894 : Async<string option> = method57(v0, v68893)
                    return! v68894 
                    (* fix_condition else
                    ()
                fix_condition else *)
                (* indent
                ()
            indent *)
            (* try_unit
            let v69100 : string option = try_unit *)
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v78554 : Async<string option> = _let'_v58922 
    let _run_target_args'_v6 = v78554 
    #endif
    let v78555 : Async<string option> = _run_target_args'_v6 
    v78555
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
    let v599 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v605 : System.DateTime = System.DateTime.UnixEpoch
    let v609 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v610 : System.DateTime = v609 v605
    let v614 : System.DateTimeKind = System.DateTimeKind.Local
    let v615 : System.DateTime = System.DateTime.SpecifyKind (v1, v614)
    let v619 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v620 : System.DateTime = v619 v615
    (* run_target_args'
    let v629 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v630 : (System.DateTime -> int64) = _.Ticks
    let v631 : int64 = v630 v620
    let _run_target_args'_v629 = v631 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v632 : (System.DateTime -> int64) = _.Ticks
    let v633 : int64 = v632 v620
    let _run_target_args'_v629 = v633 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v635 : int64 = null |> unbox<int64>
    let _run_target_args'_v629 = v635 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v638 : (System.DateTime -> int64) = _.Ticks
    let v639 : int64 = v638 v620
    let _run_target_args'_v629 = v639 
    #endif
#if FABLE_COMPILER_PYTHON
    let v640 : (System.DateTime -> int64) = _.Ticks
    let v641 : int64 = v640 v620
    let _run_target_args'_v629 = v641 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v642 : (System.DateTime -> int64) = _.Ticks
    let v643 : int64 = v642 v620
    let _run_target_args'_v629 = v643 
    #endif
#else
    let v644 : (System.DateTime -> int64) = _.Ticks
    let v645 : int64 = v644 v620
    let _run_target_args'_v629 = v645 
    #endif
    let v646 : int64 = _run_target_args'_v629 
    (* run_target_args'
    let v672 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v673 : (System.DateTime -> int64) = _.Ticks
    let v674 : int64 = v673 v610
    let _run_target_args'_v672 = v674 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v675 : (System.DateTime -> int64) = _.Ticks
    let v676 : int64 = v675 v610
    let _run_target_args'_v672 = v676 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v678 : int64 = null |> unbox<int64>
    let _run_target_args'_v672 = v678 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v681 : (System.DateTime -> int64) = _.Ticks
    let v682 : int64 = v681 v610
    let _run_target_args'_v672 = v682 
    #endif
#if FABLE_COMPILER_PYTHON
    let v683 : (System.DateTime -> int64) = _.Ticks
    let v684 : int64 = v683 v610
    let _run_target_args'_v672 = v684 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v685 : (System.DateTime -> int64) = _.Ticks
    let v686 : int64 = v685 v610
    let _run_target_args'_v672 = v686 
    #endif
#else
    let v687 : (System.DateTime -> int64) = _.Ticks
    let v688 : int64 = v687 v610
    let _run_target_args'_v672 = v688 
    #endif
    let v689 : int64 = _run_target_args'_v672 
    let v710 : int64 = v646 |> int64 
    let v714 : int64 = v689 |> int64 
    let v717 : int64 = v710 - v714
    let v718 : int64 = v717 / 10L
    let v719 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v720 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v718 v719 
    let v723 : (chrono_DateTime<chrono_Utc> -> US12) = method72()
    let v724 : US12 option = v720 |> Option.map v723 
    let v744 : US12 = US12_1
    let v745 : US12 = v724 |> Option.defaultValue v744 
    let v765 : US5 =
        match v745 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v749) -> (* Some *)
            let v750 : string = "$0.naive_utc()"
            let v751 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v749 v750 
            let v752 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v753 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v751 v752 
            let v754 : string = "%Y%m%d-%H%M-%S%f"
            let v755 : string = "r#\"" + v754 + "\"#"
            let v756 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v755 
            let v757 : string = "$0.format($1).to_string()"
            let v758 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v753, v756) v757 
            let v759 : string = "fable_library_rust::String_::fromString($0)"
            let v760 : string = Fable.Core.RustInterop.emitRustExpr v758 v759 
            let v761 : string = $"{v760.[0..17]}-{v760.[18..21]}-{v760.[22]}"
            US5_0(v761)
    let v769 : string =
        match v765 with
        | US5_1 -> (* None *)
            let v767 : string = ""
            v767
        | US5_0(v766) -> (* Some *)
            v766
    (* run_target_args'
    let v774 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v775 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v776 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v775 
    let _run_target_args'_v774 = v776 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v778 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v778 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v782 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v782 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v786 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v786 
    #endif
#if FABLE_COMPILER_PYTHON
    let v790 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v774 = v790 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v793 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v774 = v793 
    #endif
#else
    let v794 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v774 = v794 
    #endif
    let v795 : System.TimeZoneInfo = _run_target_args'_v774 
    (* run_target_args'
    let v808 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v815 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v816 : (System.DateTime -> int64) = _.Ticks
    let v817 : int64 = v816 v620
    let _run_target_args'_v815 = v817 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v818 : (System.DateTime -> int64) = _.Ticks
    let v819 : int64 = v818 v620
    let _run_target_args'_v815 = v819 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v821 : int64 = null |> unbox<int64>
    let _run_target_args'_v815 = v821 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v824 : (System.DateTime -> int64) = _.Ticks
    let v825 : int64 = v824 v620
    let _run_target_args'_v815 = v825 
    #endif
#if FABLE_COMPILER_PYTHON
    let v826 : (System.DateTime -> int64) = _.Ticks
    let v827 : int64 = v826 v620
    let _run_target_args'_v815 = v827 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v828 : (System.DateTime -> int64) = _.Ticks
    let v829 : int64 = v828 v620
    let _run_target_args'_v815 = v829 
    #endif
#else
    let v830 : (System.DateTime -> int64) = _.Ticks
    let v831 : int64 = v830 v620
    let _run_target_args'_v815 = v831 
    #endif
    let v832 : int64 = _run_target_args'_v815 
    let v852 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v853 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v620, v832) v852 
    let v855 : System.TimeSpan = v853 |> System.TimeSpan 
    let _run_target_args'_v808 = v855 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v864 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v865 : (System.DateTime -> int64) = _.Ticks
    let v866 : int64 = v865 v620
    let _run_target_args'_v864 = v866 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v867 : (System.DateTime -> int64) = _.Ticks
    let v868 : int64 = v867 v620
    let _run_target_args'_v864 = v868 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v870 : int64 = null |> unbox<int64>
    let _run_target_args'_v864 = v870 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v873 : (System.DateTime -> int64) = _.Ticks
    let v874 : int64 = v873 v620
    let _run_target_args'_v864 = v874 
    #endif
#if FABLE_COMPILER_PYTHON
    let v875 : (System.DateTime -> int64) = _.Ticks
    let v876 : int64 = v875 v620
    let _run_target_args'_v864 = v876 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v877 : (System.DateTime -> int64) = _.Ticks
    let v878 : int64 = v877 v620
    let _run_target_args'_v864 = v878 
    #endif
#else
    let v879 : (System.DateTime -> int64) = _.Ticks
    let v880 : int64 = v879 v620
    let _run_target_args'_v864 = v880 
    #endif
    let v881 : int64 = _run_target_args'_v864 
    let v901 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v902 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v620, v881) v901 
    let v904 : System.TimeSpan = v902 |> System.TimeSpan 
    let _run_target_args'_v808 = v904 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v908 : US3 = US3_2
    let v909 : US4 = US4_3(v908)
    let v910 : string = $"date_time.get_utc_offset / target: {v909}"
    let v911 : System.TimeSpan = failwith<System.TimeSpan> v910
    let _run_target_args'_v808 = v911 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v915 : US3 = US3_0
    let v916 : US4 = US4_4(v915)
    let v917 : string = $"date_time.get_utc_offset / target: {v916}"
    let v918 : System.TimeSpan = failwith<System.TimeSpan> v917
    let _run_target_args'_v808 = v918 
    #endif
#if FABLE_COMPILER_PYTHON
    let v922 : US3 = US3_0
    let v923 : US4 = US4_5(v922)
    let v924 : string = $"date_time.get_utc_offset / target: {v923}"
    let v925 : System.TimeSpan = failwith<System.TimeSpan> v924
    let _run_target_args'_v808 = v925 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v928 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v933 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v934 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v935 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v934 
    let _run_target_args'_v933 = v935 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v937 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v937 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v941 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v941 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v945 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v945 
    #endif
#if FABLE_COMPILER_PYTHON
    let v949 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v933 = v949 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v952 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v933 = v952 
    #endif
#else
    let v953 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v933 = v953 
    #endif
    let v954 : System.TimeZoneInfo = _run_target_args'_v933 
    let v960 : (System.DateTime -> System.TimeSpan) = v928 v954
    let v961 : System.TimeSpan = v960 v620
    let _run_target_args'_v808 = v961 
    #endif
#else
    let v962 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v967 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v968 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v969 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v968 
    let _run_target_args'_v967 = v969 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v971 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v971 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v975 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v975 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v979 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v979 
    #endif
#if FABLE_COMPILER_PYTHON
    let v983 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v967 = v983 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v986 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v967 = v986 
    #endif
#else
    let v987 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v967 = v987 
    #endif
    let v988 : System.TimeZoneInfo = _run_target_args'_v967 
    let v994 : (System.DateTime -> System.TimeSpan) = v962 v988
    let v995 : System.TimeSpan = v994 v620
    let _run_target_args'_v808 = v995 
    #endif
    let v996 : System.TimeSpan = _run_target_args'_v808 
    let v1006 : (System.TimeSpan -> int32) = _.Hours
    let v1007 : int32 = v1006 v996
    let v1010 : bool = v1007 > 0
    let v1011 : uint8 =
        if v1010 then
            1uy
        else
            0uy
    let v1012 : string = method73()
    (* run_target_args'
    let v1072 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1073 : string = "$0.toString($1)"
    let v1074 : string = Fable.Core.RustInterop.emitRustExpr struct (v996, v1012) v1073 
    let _run_target_args'_v1072 = v1074 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1075 : string = "$0.toString($1)"
    let v1076 : string = Fable.Core.RustInterop.emitRustExpr struct (v996, v1012) v1075 
    let _run_target_args'_v1072 = v1076 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1077 : string = "$0.toString($1)"
    let v1078 : string = Fable.Core.RustInterop.emitRustExpr struct (v996, v1012) v1077 
    let _run_target_args'_v1072 = v1078 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1079 : string = v996.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1072 = v1079 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1080 : string = v996.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1072 = v1080 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1082 : string = v996.ToString v1012 
    let _run_target_args'_v1072 = v1082 
    #endif
#else
    let v1141 : string = v996.ToString v1012 
    let _run_target_args'_v1072 = v1141 
    #endif
    let v1199 : string = _run_target_args'_v1072 
    let v1260 : string = $"{v1011}{v1199.[0..1]}{v1199.[3..4]}"
    let v1262 : (System.Guid -> string) = _.ToString()
    let v1263 : string = v1262 v0
    let v1266 : int32 = v769.Length
    let v1267 : int32 = v1260.Length
    let v1268 : int32 = v1266 + v1267
    let v1270 : (string -> int32) = String.length
    let v1271 : int32 = v1270 v1263
    let v1279 : int32 = v1268 |> int32 
    let v1292 : int32 = v1271 |> int32 
    let v1300 : int32 = v1292 - 1
    let v1302 : string = v1263.[int v1279..int v1300]
    let v1306 : string = $"{v769}{v1260}{v1302}"
    (* run_target_args'
    let v1311 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1313 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1313 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1317 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1317 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1321 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1311 = v1321 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1325 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1325 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1329 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1329 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1333 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1333 
    #endif
#else
    let v1337 : System.Guid = v1306 |> System.Guid 
    let _run_target_args'_v1311 = v1337 
    #endif
    let v1340 : System.Guid = _run_target_args'_v1311 
    let _run_target_args'_v599 = v1340 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1351 : System.DateTime = System.DateTime.UnixEpoch
    let v1355 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1356 : System.DateTime = v1355 v1351
    let v1360 : System.DateTimeKind = System.DateTimeKind.Local
    let v1361 : System.DateTime = System.DateTime.SpecifyKind (v1, v1360)
    let v1365 : (System.DateTime -> System.DateTime) = _.ToUniversalTime()
    let v1366 : System.DateTime = v1365 v1361
    (* run_target_args'
    let v1375 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1376 : (System.DateTime -> int64) = _.Ticks
    let v1377 : int64 = v1376 v1366
    let _run_target_args'_v1375 = v1377 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1378 : (System.DateTime -> int64) = _.Ticks
    let v1379 : int64 = v1378 v1366
    let _run_target_args'_v1375 = v1379 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1381 : int64 = null |> unbox<int64>
    let _run_target_args'_v1375 = v1381 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1384 : (System.DateTime -> int64) = _.Ticks
    let v1385 : int64 = v1384 v1366
    let _run_target_args'_v1375 = v1385 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1386 : (System.DateTime -> int64) = _.Ticks
    let v1387 : int64 = v1386 v1366
    let _run_target_args'_v1375 = v1387 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1388 : (System.DateTime -> int64) = _.Ticks
    let v1389 : int64 = v1388 v1366
    let _run_target_args'_v1375 = v1389 
    #endif
#else
    let v1390 : (System.DateTime -> int64) = _.Ticks
    let v1391 : int64 = v1390 v1366
    let _run_target_args'_v1375 = v1391 
    #endif
    let v1392 : int64 = _run_target_args'_v1375 
    (* run_target_args'
    let v1418 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1419 : (System.DateTime -> int64) = _.Ticks
    let v1420 : int64 = v1419 v1356
    let _run_target_args'_v1418 = v1420 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1421 : (System.DateTime -> int64) = _.Ticks
    let v1422 : int64 = v1421 v1356
    let _run_target_args'_v1418 = v1422 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1424 : int64 = null |> unbox<int64>
    let _run_target_args'_v1418 = v1424 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1427 : (System.DateTime -> int64) = _.Ticks
    let v1428 : int64 = v1427 v1356
    let _run_target_args'_v1418 = v1428 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1429 : (System.DateTime -> int64) = _.Ticks
    let v1430 : int64 = v1429 v1356
    let _run_target_args'_v1418 = v1430 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1431 : (System.DateTime -> int64) = _.Ticks
    let v1432 : int64 = v1431 v1356
    let _run_target_args'_v1418 = v1432 
    #endif
#else
    let v1433 : (System.DateTime -> int64) = _.Ticks
    let v1434 : int64 = v1433 v1356
    let _run_target_args'_v1418 = v1434 
    #endif
    let v1435 : int64 = _run_target_args'_v1418 
    let v1456 : int64 = v1392 |> int64 
    let v1460 : int64 = v1435 |> int64 
    let v1463 : int64 = v1456 - v1460
    let v1464 : int64 = v1463 / 10L
    let v1465 : string = "chrono::DateTime::from_timestamp_micros($0)"
    let v1466 : chrono_DateTime<chrono_Utc> option = Fable.Core.RustInterop.emitRustExpr v1464 v1465 
    let v1469 : (chrono_DateTime<chrono_Utc> -> US12) = method72()
    let v1470 : US12 option = v1466 |> Option.map v1469 
    let v1490 : US12 = US12_1
    let v1491 : US12 = v1470 |> Option.defaultValue v1490 
    let v1511 : US5 =
        match v1491 with
        | US12_1 -> (* None *)
            US5_1
        | US12_0(v1495) -> (* Some *)
            let v1496 : string = "$0.naive_utc()"
            let v1497 : chrono_NaiveDateTime = Fable.Core.RustInterop.emitRustExpr v1495 v1496 
            let v1498 : string = "chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &$0)"
            let v1499 : chrono_DateTime<chrono_Local> = Fable.Core.RustInterop.emitRustExpr v1497 v1498 
            let v1500 : string = "%Y%m%d-%H%M-%S%f"
            let v1501 : string = "r#\"" + v1500 + "\"#"
            let v1502 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v1501 
            let v1503 : string = "$0.format($1).to_string()"
            let v1504 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v1499, v1502) v1503 
            let v1505 : string = "fable_library_rust::String_::fromString($0)"
            let v1506 : string = Fable.Core.RustInterop.emitRustExpr v1504 v1505 
            let v1507 : string = $"{v1506.[0..17]}-{v1506.[18..21]}-{v1506.[22]}"
            US5_0(v1507)
    let v1515 : string =
        match v1511 with
        | US5_1 -> (* None *)
            let v1513 : string = ""
            v1513
        | US5_0(v1512) -> (* Some *)
            v1512
    (* run_target_args'
    let v1520 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1521 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1522 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1521 
    let _run_target_args'_v1520 = v1522 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1524 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1524 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1528 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1532 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1532 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1536 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1520 = v1536 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1539 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1520 = v1539 
    #endif
#else
    let v1540 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1520 = v1540 
    #endif
    let v1541 : System.TimeZoneInfo = _run_target_args'_v1520 
    (* run_target_args'
    let v1554 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v1561 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1562 : (System.DateTime -> int64) = _.Ticks
    let v1563 : int64 = v1562 v1366
    let _run_target_args'_v1561 = v1563 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1564 : (System.DateTime -> int64) = _.Ticks
    let v1565 : int64 = v1564 v1366
    let _run_target_args'_v1561 = v1565 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1567 : int64 = null |> unbox<int64>
    let _run_target_args'_v1561 = v1567 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1570 : (System.DateTime -> int64) = _.Ticks
    let v1571 : int64 = v1570 v1366
    let _run_target_args'_v1561 = v1571 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1572 : (System.DateTime -> int64) = _.Ticks
    let v1573 : int64 = v1572 v1366
    let _run_target_args'_v1561 = v1573 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1574 : (System.DateTime -> int64) = _.Ticks
    let v1575 : int64 = v1574 v1366
    let _run_target_args'_v1561 = v1575 
    #endif
#else
    let v1576 : (System.DateTime -> int64) = _.Ticks
    let v1577 : int64 = v1576 v1366
    let _run_target_args'_v1561 = v1577 
    #endif
    let v1578 : int64 = _run_target_args'_v1561 
    let v1598 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1599 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1366, v1578) v1598 
    let v1601 : System.TimeSpan = v1599 |> System.TimeSpan 
    let _run_target_args'_v1554 = v1601 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v1610 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1611 : (System.DateTime -> int64) = _.Ticks
    let v1612 : int64 = v1611 v1366
    let _run_target_args'_v1610 = v1612 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1613 : (System.DateTime -> int64) = _.Ticks
    let v1614 : int64 = v1613 v1366
    let _run_target_args'_v1610 = v1614 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1616 : int64 = null |> unbox<int64>
    let _run_target_args'_v1610 = v1616 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1619 : (System.DateTime -> int64) = _.Ticks
    let v1620 : int64 = v1619 v1366
    let _run_target_args'_v1610 = v1620 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1621 : (System.DateTime -> int64) = _.Ticks
    let v1622 : int64 = v1621 v1366
    let _run_target_args'_v1610 = v1622 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1623 : (System.DateTime -> int64) = _.Ticks
    let v1624 : int64 = v1623 v1366
    let _run_target_args'_v1610 = v1624 
    #endif
#else
    let v1625 : (System.DateTime -> int64) = _.Ticks
    let v1626 : int64 = v1625 v1366
    let _run_target_args'_v1610 = v1626 
    #endif
    let v1627 : int64 = _run_target_args'_v1610 
    let v1647 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v1648 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1366, v1627) v1647 
    let v1650 : System.TimeSpan = v1648 |> System.TimeSpan 
    let _run_target_args'_v1554 = v1650 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1654 : US3 = US3_2
    let v1655 : US4 = US4_3(v1654)
    let v1656 : string = $"date_time.get_utc_offset / target: {v1655}"
    let v1657 : System.TimeSpan = failwith<System.TimeSpan> v1656
    let _run_target_args'_v1554 = v1657 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1661 : US3 = US3_0
    let v1662 : US4 = US4_4(v1661)
    let v1663 : string = $"date_time.get_utc_offset / target: {v1662}"
    let v1664 : System.TimeSpan = failwith<System.TimeSpan> v1663
    let _run_target_args'_v1554 = v1664 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1668 : US3 = US3_0
    let v1669 : US4 = US4_5(v1668)
    let v1670 : string = $"date_time.get_utc_offset / target: {v1669}"
    let v1671 : System.TimeSpan = failwith<System.TimeSpan> v1670
    let _run_target_args'_v1554 = v1671 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1674 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1679 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1680 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1681 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1680 
    let _run_target_args'_v1679 = v1681 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1683 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1683 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1687 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1687 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1691 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1691 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1695 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1679 = v1695 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1698 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1679 = v1698 
    #endif
#else
    let v1699 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1679 = v1699 
    #endif
    let v1700 : System.TimeZoneInfo = _run_target_args'_v1679 
    let v1706 : (System.DateTime -> System.TimeSpan) = v1674 v1700
    let v1707 : System.TimeSpan = v1706 v1366
    let _run_target_args'_v1554 = v1707 
    #endif
#else
    let v1708 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v1713 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1714 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v1715 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v1714 
    let _run_target_args'_v1713 = v1715 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1717 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1717 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1721 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1721 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1725 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1725 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1729 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v1713 = v1729 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1732 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1713 = v1732 
    #endif
#else
    let v1733 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v1713 = v1733 
    #endif
    let v1734 : System.TimeZoneInfo = _run_target_args'_v1713 
    let v1740 : (System.DateTime -> System.TimeSpan) = v1708 v1734
    let v1741 : System.TimeSpan = v1740 v1366
    let _run_target_args'_v1554 = v1741 
    #endif
    let v1742 : System.TimeSpan = _run_target_args'_v1554 
    let v1752 : (System.TimeSpan -> int32) = _.Hours
    let v1753 : int32 = v1752 v1742
    let v1756 : bool = v1753 > 0
    let v1757 : uint8 =
        if v1756 then
            1uy
        else
            0uy
    let v1758 : string = method73()
    (* run_target_args'
    let v1818 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1819 : string = "$0.toString($1)"
    let v1820 : string = Fable.Core.RustInterop.emitRustExpr struct (v1742, v1758) v1819 
    let _run_target_args'_v1818 = v1820 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1821 : string = "$0.toString($1)"
    let v1822 : string = Fable.Core.RustInterop.emitRustExpr struct (v1742, v1758) v1821 
    let _run_target_args'_v1818 = v1822 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1823 : string = "$0.toString($1)"
    let v1824 : string = Fable.Core.RustInterop.emitRustExpr struct (v1742, v1758) v1823 
    let _run_target_args'_v1818 = v1824 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1825 : string = v1742.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1818 = v1825 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1826 : string = v1742.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v1818 = v1826 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1828 : string = v1742.ToString v1758 
    let _run_target_args'_v1818 = v1828 
    #endif
#else
    let v1887 : string = v1742.ToString v1758 
    let _run_target_args'_v1818 = v1887 
    #endif
    let v1945 : string = _run_target_args'_v1818 
    let v2006 : string = $"{v1757}{v1945.[0..1]}{v1945.[3..4]}"
    let v2008 : (System.Guid -> string) = _.ToString()
    let v2009 : string = v2008 v0
    let v2012 : int32 = v1515.Length
    let v2013 : int32 = v2006.Length
    let v2014 : int32 = v2012 + v2013
    let v2016 : (string -> int32) = String.length
    let v2017 : int32 = v2016 v2009
    let v2025 : int32 = v2014 |> int32 
    let v2038 : int32 = v2017 |> int32 
    let v2046 : int32 = v2038 - 1
    let v2048 : string = v2009.[int v2025..int v2046]
    let v2052 : string = $"{v1515}{v2006}{v2048}"
    (* run_target_args'
    let v2057 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2059 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2059 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2063 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2063 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2067 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2057 = v2067 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2071 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2071 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2075 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2075 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2079 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2079 
    #endif
#else
    let v2083 : System.Guid = v2052 |> System.Guid 
    let _run_target_args'_v2057 = v2083 
    #endif
    let v2086 : System.Guid = _run_target_args'_v2057 
    let _run_target_args'_v599 = v2086 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2093 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v599 = v2093 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2096 : string = method74()
    let v2098 : bool = v2096 = ""
    let v2100 : string =
        if v2098 then
            let v2099 : string = "M-d-y hh:mm:ss tt"
            v2099
        else
            v2096
    let v2101 : (string -> string) = v1.ToString
    let v2102 : string = v2101 v2100
    (* run_target_args'
    let v2121 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2122 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2123 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2122 
    let _run_target_args'_v2121 = v2123 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2125 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2125 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2129 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2129 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2133 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2133 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2137 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2121 = v2137 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2140 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2121 = v2140 
    #endif
#else
    let v2141 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2121 = v2141 
    #endif
    let v2142 : System.TimeZoneInfo = _run_target_args'_v2121 
    (* run_target_args'
    let v2155 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2162 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2163 : (System.DateTime -> int64) = _.Ticks
    let v2164 : int64 = v2163 v1
    let _run_target_args'_v2162 = v2164 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2165 : (System.DateTime -> int64) = _.Ticks
    let v2166 : int64 = v2165 v1
    let _run_target_args'_v2162 = v2166 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2168 : int64 = null |> unbox<int64>
    let _run_target_args'_v2162 = v2168 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2171 : (System.DateTime -> int64) = _.Ticks
    let v2172 : int64 = v2171 v1
    let _run_target_args'_v2162 = v2172 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2173 : (System.DateTime -> int64) = _.Ticks
    let v2174 : int64 = v2173 v1
    let _run_target_args'_v2162 = v2174 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2175 : (System.DateTime -> int64) = _.Ticks
    let v2176 : int64 = v2175 v1
    let _run_target_args'_v2162 = v2176 
    #endif
#else
    let v2177 : (System.DateTime -> int64) = _.Ticks
    let v2178 : int64 = v2177 v1
    let _run_target_args'_v2162 = v2178 
    #endif
    let v2179 : int64 = _run_target_args'_v2162 
    let v2199 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2200 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2179) v2199 
    let v2202 : System.TimeSpan = v2200 |> System.TimeSpan 
    let _run_target_args'_v2155 = v2202 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2211 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2212 : (System.DateTime -> int64) = _.Ticks
    let v2213 : int64 = v2212 v1
    let _run_target_args'_v2211 = v2213 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2214 : (System.DateTime -> int64) = _.Ticks
    let v2215 : int64 = v2214 v1
    let _run_target_args'_v2211 = v2215 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2217 : int64 = null |> unbox<int64>
    let _run_target_args'_v2211 = v2217 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2220 : (System.DateTime -> int64) = _.Ticks
    let v2221 : int64 = v2220 v1
    let _run_target_args'_v2211 = v2221 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2222 : (System.DateTime -> int64) = _.Ticks
    let v2223 : int64 = v2222 v1
    let _run_target_args'_v2211 = v2223 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2224 : (System.DateTime -> int64) = _.Ticks
    let v2225 : int64 = v2224 v1
    let _run_target_args'_v2211 = v2225 
    #endif
#else
    let v2226 : (System.DateTime -> int64) = _.Ticks
    let v2227 : int64 = v2226 v1
    let _run_target_args'_v2211 = v2227 
    #endif
    let v2228 : int64 = _run_target_args'_v2211 
    let v2248 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2249 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2228) v2248 
    let v2251 : System.TimeSpan = v2249 |> System.TimeSpan 
    let _run_target_args'_v2155 = v2251 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2255 : US3 = US3_2
    let v2256 : US4 = US4_3(v2255)
    let v2257 : string = $"date_time.get_utc_offset / target: {v2256}"
    let v2258 : System.TimeSpan = failwith<System.TimeSpan> v2257
    let _run_target_args'_v2155 = v2258 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2262 : US3 = US3_0
    let v2263 : US4 = US4_4(v2262)
    let v2264 : string = $"date_time.get_utc_offset / target: {v2263}"
    let v2265 : System.TimeSpan = failwith<System.TimeSpan> v2264
    let _run_target_args'_v2155 = v2265 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2269 : US3 = US3_0
    let v2270 : US4 = US4_5(v2269)
    let v2271 : string = $"date_time.get_utc_offset / target: {v2270}"
    let v2272 : System.TimeSpan = failwith<System.TimeSpan> v2271
    let _run_target_args'_v2155 = v2272 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2275 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2280 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2281 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2282 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2281 
    let _run_target_args'_v2280 = v2282 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2284 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2284 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2288 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2288 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2292 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2292 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2296 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2280 = v2296 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2299 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2280 = v2299 
    #endif
#else
    let v2300 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2280 = v2300 
    #endif
    let v2301 : System.TimeZoneInfo = _run_target_args'_v2280 
    let v2307 : (System.DateTime -> System.TimeSpan) = v2275 v2301
    let v2308 : System.TimeSpan = v2307 v1
    let _run_target_args'_v2155 = v2308 
    #endif
#else
    let v2309 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2314 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2315 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2316 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2315 
    let _run_target_args'_v2314 = v2316 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2318 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2318 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2322 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2322 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2326 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2326 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2330 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2314 = v2330 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2333 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2314 = v2333 
    #endif
#else
    let v2334 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2314 = v2334 
    #endif
    let v2335 : System.TimeZoneInfo = _run_target_args'_v2314 
    let v2341 : (System.DateTime -> System.TimeSpan) = v2309 v2335
    let v2342 : System.TimeSpan = v2341 v1
    let _run_target_args'_v2155 = v2342 
    #endif
    let v2343 : System.TimeSpan = _run_target_args'_v2155 
    let v2353 : (System.TimeSpan -> int32) = _.Hours
    let v2354 : int32 = v2353 v2343
    let v2357 : bool = v2354 > 0
    let v2358 : uint8 =
        if v2357 then
            1uy
        else
            0uy
    let v2359 : string = method75()
    (* run_target_args'
    let v2419 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2420 : string = "$0.toString($1)"
    let v2421 : string = Fable.Core.RustInterop.emitRustExpr struct (v2343, v2359) v2420 
    let _run_target_args'_v2419 = v2421 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2422 : string = "$0.toString($1)"
    let v2423 : string = Fable.Core.RustInterop.emitRustExpr struct (v2343, v2359) v2422 
    let _run_target_args'_v2419 = v2423 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2424 : string = "$0.toString($1)"
    let v2425 : string = Fable.Core.RustInterop.emitRustExpr struct (v2343, v2359) v2424 
    let _run_target_args'_v2419 = v2425 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2426 : string = v2343.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2419 = v2426 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2427 : string = v2343.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v2419 = v2427 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2429 : string = v2343.ToString v2359 
    let _run_target_args'_v2419 = v2429 
    #endif
#else
    let v2488 : string = v2343.ToString v2359 
    let _run_target_args'_v2419 = v2488 
    #endif
    let v2546 : string = _run_target_args'_v2419 
    let v2607 : string = $"{v2358}{v2546}"
    let v2609 : (System.Guid -> string) = _.ToString()
    let v2610 : string = v2609 v0
    let v2613 : int32 = v2102.Length
    let v2614 : int32 = v2607.Length
    let v2615 : int32 = v2613 + v2614
    let v2617 : (string -> int32) = String.length
    let v2618 : int32 = v2617 v2610
    let v2626 : int32 = v2615 |> int32 
    let v2639 : int32 = v2618 |> int32 
    let v2647 : int32 = v2639 - 1
    let v2649 : string = v2610.[int v2626..int v2647]
    let v2653 : string = $"{v2102}{v2607}{v2649}"
    (* run_target_args'
    let v2658 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2660 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2660 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2664 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2664 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2668 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v2658 = v2668 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2672 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2672 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2676 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2676 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2680 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2680 
    #endif
#else
    let v2684 : System.Guid = v2653 |> System.Guid 
    let _run_target_args'_v2658 = v2684 
    #endif
    let v2687 : System.Guid = _run_target_args'_v2658 
    let _run_target_args'_v599 = v2687 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2693 : string = method74()
    let v2695 : bool = v2693 = ""
    let v2697 : string =
        if v2695 then
            let v2696 : string = "M-d-y hh:mm:ss tt"
            v2696
        else
            v2693
    let v2698 : (string -> string) = v1.ToString
    let v2699 : string = v2698 v2697
    (* run_target_args'
    let v2718 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2719 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2720 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2719 
    let _run_target_args'_v2718 = v2720 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2722 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2722 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2726 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2726 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2730 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2730 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2734 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2718 = v2734 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2737 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2718 = v2737 
    #endif
#else
    let v2738 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2718 = v2738 
    #endif
    let v2739 : System.TimeZoneInfo = _run_target_args'_v2718 
    (* run_target_args'
    let v2752 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v2759 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2760 : (System.DateTime -> int64) = _.Ticks
    let v2761 : int64 = v2760 v1
    let _run_target_args'_v2759 = v2761 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2762 : (System.DateTime -> int64) = _.Ticks
    let v2763 : int64 = v2762 v1
    let _run_target_args'_v2759 = v2763 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2765 : int64 = null |> unbox<int64>
    let _run_target_args'_v2759 = v2765 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2768 : (System.DateTime -> int64) = _.Ticks
    let v2769 : int64 = v2768 v1
    let _run_target_args'_v2759 = v2769 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2770 : (System.DateTime -> int64) = _.Ticks
    let v2771 : int64 = v2770 v1
    let _run_target_args'_v2759 = v2771 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2772 : (System.DateTime -> int64) = _.Ticks
    let v2773 : int64 = v2772 v1
    let _run_target_args'_v2759 = v2773 
    #endif
#else
    let v2774 : (System.DateTime -> int64) = _.Ticks
    let v2775 : int64 = v2774 v1
    let _run_target_args'_v2759 = v2775 
    #endif
    let v2776 : int64 = _run_target_args'_v2759 
    let v2796 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2797 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2776) v2796 
    let v2799 : System.TimeSpan = v2797 |> System.TimeSpan 
    let _run_target_args'_v2752 = v2799 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v2808 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2809 : (System.DateTime -> int64) = _.Ticks
    let v2810 : int64 = v2809 v1
    let _run_target_args'_v2808 = v2810 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2811 : (System.DateTime -> int64) = _.Ticks
    let v2812 : int64 = v2811 v1
    let _run_target_args'_v2808 = v2812 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2814 : int64 = null |> unbox<int64>
    let _run_target_args'_v2808 = v2814 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2817 : (System.DateTime -> int64) = _.Ticks
    let v2818 : int64 = v2817 v1
    let _run_target_args'_v2808 = v2818 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2819 : (System.DateTime -> int64) = _.Ticks
    let v2820 : int64 = v2819 v1
    let _run_target_args'_v2808 = v2820 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2821 : (System.DateTime -> int64) = _.Ticks
    let v2822 : int64 = v2821 v1
    let _run_target_args'_v2808 = v2822 
    #endif
#else
    let v2823 : (System.DateTime -> int64) = _.Ticks
    let v2824 : int64 = v2823 v1
    let _run_target_args'_v2808 = v2824 
    #endif
    let v2825 : int64 = _run_target_args'_v2808 
    let v2845 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v2846 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v2825) v2845 
    let v2848 : System.TimeSpan = v2846 |> System.TimeSpan 
    let _run_target_args'_v2752 = v2848 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2852 : US3 = US3_2
    let v2853 : US4 = US4_3(v2852)
    let v2854 : string = $"date_time.get_utc_offset / target: {v2853}"
    let v2855 : System.TimeSpan = failwith<System.TimeSpan> v2854
    let _run_target_args'_v2752 = v2855 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2859 : US3 = US3_0
    let v2860 : US4 = US4_4(v2859)
    let v2861 : string = $"date_time.get_utc_offset / target: {v2860}"
    let v2862 : System.TimeSpan = failwith<System.TimeSpan> v2861
    let _run_target_args'_v2752 = v2862 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2866 : US3 = US3_0
    let v2867 : US4 = US4_5(v2866)
    let v2868 : string = $"date_time.get_utc_offset / target: {v2867}"
    let v2869 : System.TimeSpan = failwith<System.TimeSpan> v2868
    let _run_target_args'_v2752 = v2869 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2872 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2877 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2878 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2879 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2878 
    let _run_target_args'_v2877 = v2879 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2881 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2881 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2885 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2885 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2889 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2889 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2893 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2877 = v2893 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2896 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2877 = v2896 
    #endif
#else
    let v2897 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2877 = v2897 
    #endif
    let v2898 : System.TimeZoneInfo = _run_target_args'_v2877 
    let v2904 : (System.DateTime -> System.TimeSpan) = v2872 v2898
    let v2905 : System.TimeSpan = v2904 v1
    let _run_target_args'_v2752 = v2905 
    #endif
#else
    let v2906 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v2911 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2912 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v2913 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v2912 
    let _run_target_args'_v2911 = v2913 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v2915 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2915 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v2919 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2919 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v2923 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2923 
    #endif
#if FABLE_COMPILER_PYTHON
    let v2927 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v2911 = v2927 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2930 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2911 = v2930 
    #endif
#else
    let v2931 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v2911 = v2931 
    #endif
    let v2932 : System.TimeZoneInfo = _run_target_args'_v2911 
    let v2938 : (System.DateTime -> System.TimeSpan) = v2906 v2932
    let v2939 : System.TimeSpan = v2938 v1
    let _run_target_args'_v2752 = v2939 
    #endif
    let v2940 : System.TimeSpan = _run_target_args'_v2752 
    let v2950 : (System.TimeSpan -> int32) = _.Hours
    let v2951 : int32 = v2950 v2940
    let v2954 : bool = v2951 > 0
    let v2955 : uint8 =
        if v2954 then
            1uy
        else
            0uy
    let v2956 : string = method75()
    (* run_target_args'
    let v3016 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3017 : string = "$0.toString($1)"
    let v3018 : string = Fable.Core.RustInterop.emitRustExpr struct (v2940, v2956) v3017 
    let _run_target_args'_v3016 = v3018 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3019 : string = "$0.toString($1)"
    let v3020 : string = Fable.Core.RustInterop.emitRustExpr struct (v2940, v2956) v3019 
    let _run_target_args'_v3016 = v3020 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3021 : string = "$0.toString($1)"
    let v3022 : string = Fable.Core.RustInterop.emitRustExpr struct (v2940, v2956) v3021 
    let _run_target_args'_v3016 = v3022 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3023 : string = v2940.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3016 = v3023 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3024 : string = v2940.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3016 = v3024 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3026 : string = v2940.ToString v2956 
    let _run_target_args'_v3016 = v3026 
    #endif
#else
    let v3085 : string = v2940.ToString v2956 
    let _run_target_args'_v3016 = v3085 
    #endif
    let v3143 : string = _run_target_args'_v3016 
    let v3204 : string = $"{v2955}{v3143}"
    let v3206 : (System.Guid -> string) = _.ToString()
    let v3207 : string = v3206 v0
    let v3210 : int32 = v2699.Length
    let v3211 : int32 = v3204.Length
    let v3212 : int32 = v3210 + v3211
    let v3214 : (string -> int32) = String.length
    let v3215 : int32 = v3214 v3207
    let v3223 : int32 = v3212 |> int32 
    let v3236 : int32 = v3215 |> int32 
    let v3244 : int32 = v3236 - 1
    let v3246 : string = v3207.[int v3223..int v3244]
    let v3250 : string = $"{v2699}{v3204}{v3246}"
    (* run_target_args'
    let v3255 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3257 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3257 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3261 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3261 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3265 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3255 = v3265 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3269 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3269 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3273 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3273 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3277 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3277 
    #endif
#else
    let v3281 : System.Guid = v3250 |> System.Guid 
    let _run_target_args'_v3255 = v3281 
    #endif
    let v3284 : System.Guid = _run_target_args'_v3255 
    let _run_target_args'_v599 = v3284 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3290 : string = method74()
    let v3292 : bool = v3290 = ""
    let v3294 : string =
        if v3292 then
            let v3293 : string = "M-d-y hh:mm:ss tt"
            v3293
        else
            v3290
    let v3295 : (string -> string) = v1.ToString
    let v3296 : string = v3295 v3294
    (* run_target_args'
    let v3315 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3316 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3317 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3316 
    let _run_target_args'_v3315 = v3317 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3319 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3319 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3323 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3323 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3327 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3327 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3331 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3315 = v3331 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3334 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3315 = v3334 
    #endif
#else
    let v3335 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3315 = v3335 
    #endif
    let v3336 : System.TimeZoneInfo = _run_target_args'_v3315 
    (* run_target_args'
    let v3349 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3356 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3357 : (System.DateTime -> int64) = _.Ticks
    let v3358 : int64 = v3357 v1
    let _run_target_args'_v3356 = v3358 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3359 : (System.DateTime -> int64) = _.Ticks
    let v3360 : int64 = v3359 v1
    let _run_target_args'_v3356 = v3360 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3362 : int64 = null |> unbox<int64>
    let _run_target_args'_v3356 = v3362 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3365 : (System.DateTime -> int64) = _.Ticks
    let v3366 : int64 = v3365 v1
    let _run_target_args'_v3356 = v3366 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3367 : (System.DateTime -> int64) = _.Ticks
    let v3368 : int64 = v3367 v1
    let _run_target_args'_v3356 = v3368 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3369 : (System.DateTime -> int64) = _.Ticks
    let v3370 : int64 = v3369 v1
    let _run_target_args'_v3356 = v3370 
    #endif
#else
    let v3371 : (System.DateTime -> int64) = _.Ticks
    let v3372 : int64 = v3371 v1
    let _run_target_args'_v3356 = v3372 
    #endif
    let v3373 : int64 = _run_target_args'_v3356 
    let v3393 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3394 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3373) v3393 
    let v3396 : System.TimeSpan = v3394 |> System.TimeSpan 
    let _run_target_args'_v3349 = v3396 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v3405 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3406 : (System.DateTime -> int64) = _.Ticks
    let v3407 : int64 = v3406 v1
    let _run_target_args'_v3405 = v3407 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3408 : (System.DateTime -> int64) = _.Ticks
    let v3409 : int64 = v3408 v1
    let _run_target_args'_v3405 = v3409 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3411 : int64 = null |> unbox<int64>
    let _run_target_args'_v3405 = v3411 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3414 : (System.DateTime -> int64) = _.Ticks
    let v3415 : int64 = v3414 v1
    let _run_target_args'_v3405 = v3415 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3416 : (System.DateTime -> int64) = _.Ticks
    let v3417 : int64 = v3416 v1
    let _run_target_args'_v3405 = v3417 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3418 : (System.DateTime -> int64) = _.Ticks
    let v3419 : int64 = v3418 v1
    let _run_target_args'_v3405 = v3419 
    #endif
#else
    let v3420 : (System.DateTime -> int64) = _.Ticks
    let v3421 : int64 = v3420 v1
    let _run_target_args'_v3405 = v3421 
    #endif
    let v3422 : int64 = _run_target_args'_v3405 
    let v3442 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3443 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3422) v3442 
    let v3445 : System.TimeSpan = v3443 |> System.TimeSpan 
    let _run_target_args'_v3349 = v3445 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3449 : US3 = US3_2
    let v3450 : US4 = US4_3(v3449)
    let v3451 : string = $"date_time.get_utc_offset / target: {v3450}"
    let v3452 : System.TimeSpan = failwith<System.TimeSpan> v3451
    let _run_target_args'_v3349 = v3452 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3456 : US3 = US3_0
    let v3457 : US4 = US4_4(v3456)
    let v3458 : string = $"date_time.get_utc_offset / target: {v3457}"
    let v3459 : System.TimeSpan = failwith<System.TimeSpan> v3458
    let _run_target_args'_v3349 = v3459 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3463 : US3 = US3_0
    let v3464 : US4 = US4_5(v3463)
    let v3465 : string = $"date_time.get_utc_offset / target: {v3464}"
    let v3466 : System.TimeSpan = failwith<System.TimeSpan> v3465
    let _run_target_args'_v3349 = v3466 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3469 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3474 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3475 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3476 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3475 
    let _run_target_args'_v3474 = v3476 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3478 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3478 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3482 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3482 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3486 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3486 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3490 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3474 = v3490 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3493 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3474 = v3493 
    #endif
#else
    let v3494 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3474 = v3494 
    #endif
    let v3495 : System.TimeZoneInfo = _run_target_args'_v3474 
    let v3501 : (System.DateTime -> System.TimeSpan) = v3469 v3495
    let v3502 : System.TimeSpan = v3501 v1
    let _run_target_args'_v3349 = v3502 
    #endif
#else
    let v3503 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v3508 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3509 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3510 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3509 
    let _run_target_args'_v3508 = v3510 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3512 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3512 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3516 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3516 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3520 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3520 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3524 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3508 = v3524 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3527 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3508 = v3527 
    #endif
#else
    let v3528 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3508 = v3528 
    #endif
    let v3529 : System.TimeZoneInfo = _run_target_args'_v3508 
    let v3535 : (System.DateTime -> System.TimeSpan) = v3503 v3529
    let v3536 : System.TimeSpan = v3535 v1
    let _run_target_args'_v3349 = v3536 
    #endif
    let v3537 : System.TimeSpan = _run_target_args'_v3349 
    let v3547 : (System.TimeSpan -> int32) = _.Hours
    let v3548 : int32 = v3547 v3537
    let v3551 : bool = v3548 > 0
    let v3552 : uint8 =
        if v3551 then
            1uy
        else
            0uy
    let v3553 : string = method75()
    (* run_target_args'
    let v3613 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3614 : string = "$0.toString($1)"
    let v3615 : string = Fable.Core.RustInterop.emitRustExpr struct (v3537, v3553) v3614 
    let _run_target_args'_v3613 = v3615 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3616 : string = "$0.toString($1)"
    let v3617 : string = Fable.Core.RustInterop.emitRustExpr struct (v3537, v3553) v3616 
    let _run_target_args'_v3613 = v3617 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3618 : string = "$0.toString($1)"
    let v3619 : string = Fable.Core.RustInterop.emitRustExpr struct (v3537, v3553) v3618 
    let _run_target_args'_v3613 = v3619 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3620 : string = v3537.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3620 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3621 : string = v3537.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v3613 = v3621 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3623 : string = v3537.ToString v3553 
    let _run_target_args'_v3613 = v3623 
    #endif
#else
    let v3682 : string = v3537.ToString v3553 
    let _run_target_args'_v3613 = v3682 
    #endif
    let v3740 : string = _run_target_args'_v3613 
    let v3801 : string = $"{v3552}{v3740}"
    let v3803 : (System.Guid -> string) = _.ToString()
    let v3804 : string = v3803 v0
    let v3807 : int32 = v3296.Length
    let v3808 : int32 = v3801.Length
    let v3809 : int32 = v3807 + v3808
    let v3811 : (string -> int32) = String.length
    let v3812 : int32 = v3811 v3804
    let v3820 : int32 = v3809 |> int32 
    let v3833 : int32 = v3812 |> int32 
    let v3841 : int32 = v3833 - 1
    let v3843 : string = v3804.[int v3820..int v3841]
    let v3847 : string = $"{v3296}{v3801}{v3843}"
    (* run_target_args'
    let v3852 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3854 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3854 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3858 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3858 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3862 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v3852 = v3862 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3866 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3866 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3870 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3870 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3874 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3874 
    #endif
#else
    let v3878 : System.Guid = v3847 |> System.Guid 
    let _run_target_args'_v3852 = v3878 
    #endif
    let v3881 : System.Guid = _run_target_args'_v3852 
    let _run_target_args'_v599 = v3881 
    #endif
#else
    let v3887 : string = method74()
    let v3889 : bool = v3887 = ""
    let v3891 : string =
        if v3889 then
            let v3890 : string = "M-d-y hh:mm:ss tt"
            v3890
        else
            v3887
    let v3892 : (string -> string) = v1.ToString
    let v3893 : string = v3892 v3891
    (* run_target_args'
    let v3912 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3913 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v3914 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v3913 
    let _run_target_args'_v3912 = v3914 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3916 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3916 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3920 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3920 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3924 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3924 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3928 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v3912 = v3928 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3931 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3912 = v3931 
    #endif
#else
    let v3932 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v3912 = v3932 
    #endif
    let v3933 : System.TimeZoneInfo = _run_target_args'_v3912 
    (* run_target_args'
    let v3946 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    (* run_target_args'
    let v3953 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3954 : (System.DateTime -> int64) = _.Ticks
    let v3955 : int64 = v3954 v1
    let _run_target_args'_v3953 = v3955 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v3956 : (System.DateTime -> int64) = _.Ticks
    let v3957 : int64 = v3956 v1
    let _run_target_args'_v3953 = v3957 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v3959 : int64 = null |> unbox<int64>
    let _run_target_args'_v3953 = v3959 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v3962 : (System.DateTime -> int64) = _.Ticks
    let v3963 : int64 = v3962 v1
    let _run_target_args'_v3953 = v3963 
    #endif
#if FABLE_COMPILER_PYTHON
    let v3964 : (System.DateTime -> int64) = _.Ticks
    let v3965 : int64 = v3964 v1
    let _run_target_args'_v3953 = v3965 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v3966 : (System.DateTime -> int64) = _.Ticks
    let v3967 : int64 = v3966 v1
    let _run_target_args'_v3953 = v3967 
    #endif
#else
    let v3968 : (System.DateTime -> int64) = _.Ticks
    let v3969 : int64 = v3968 v1
    let _run_target_args'_v3953 = v3969 
    #endif
    let v3970 : int64 = _run_target_args'_v3953 
    let v3990 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v3991 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v3970) v3990 
    let v3993 : System.TimeSpan = v3991 |> System.TimeSpan 
    let _run_target_args'_v3946 = v3993 
    #endif
#if FABLE_COMPILER_RUST && WASM
    (* run_target_args'
    let v4002 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4003 : (System.DateTime -> int64) = _.Ticks
    let v4004 : int64 = v4003 v1
    let _run_target_args'_v4002 = v4004 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4005 : (System.DateTime -> int64) = _.Ticks
    let v4006 : int64 = v4005 v1
    let _run_target_args'_v4002 = v4006 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4008 : int64 = null |> unbox<int64>
    let _run_target_args'_v4002 = v4008 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4011 : (System.DateTime -> int64) = _.Ticks
    let v4012 : int64 = v4011 v1
    let _run_target_args'_v4002 = v4012 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4013 : (System.DateTime -> int64) = _.Ticks
    let v4014 : int64 = v4013 v1
    let _run_target_args'_v4002 = v4014 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4015 : (System.DateTime -> int64) = _.Ticks
    let v4016 : int64 = v4015 v1
    let _run_target_args'_v4002 = v4016 
    #endif
#else
    let v4017 : (System.DateTime -> int64) = _.Ticks
    let v4018 : int64 = v4017 v1
    let _run_target_args'_v4002 = v4018 
    #endif
    let v4019 : int64 = _run_target_args'_v4002 
    let v4039 : string = "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))"
    let v4040 : int32 = Fable.Core.RustInterop.emitRustExpr struct (v1, v4019) v4039 
    let v4042 : System.TimeSpan = v4040 |> System.TimeSpan 
    let _run_target_args'_v3946 = v4042 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4046 : US3 = US3_2
    let v4047 : US4 = US4_3(v4046)
    let v4048 : string = $"date_time.get_utc_offset / target: {v4047}"
    let v4049 : System.TimeSpan = failwith<System.TimeSpan> v4048
    let _run_target_args'_v3946 = v4049 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4053 : US3 = US3_0
    let v4054 : US4 = US4_4(v4053)
    let v4055 : string = $"date_time.get_utc_offset / target: {v4054}"
    let v4056 : System.TimeSpan = failwith<System.TimeSpan> v4055
    let _run_target_args'_v3946 = v4056 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4060 : US3 = US3_0
    let v4061 : US4 = US4_5(v4060)
    let v4062 : string = $"date_time.get_utc_offset / target: {v4061}"
    let v4063 : System.TimeSpan = failwith<System.TimeSpan> v4062
    let _run_target_args'_v3946 = v4063 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4066 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4071 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4072 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4073 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4072 
    let _run_target_args'_v4071 = v4073 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4075 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4075 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4079 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4079 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4083 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4083 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4087 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4071 = v4087 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4090 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4071 = v4090 
    #endif
#else
    let v4091 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4071 = v4091 
    #endif
    let v4092 : System.TimeZoneInfo = _run_target_args'_v4071 
    let v4098 : (System.DateTime -> System.TimeSpan) = v4066 v4092
    let v4099 : System.TimeSpan = v4098 v1
    let _run_target_args'_v3946 = v4099 
    #endif
#else
    let v4100 : (System.TimeZoneInfo -> (System.DateTime -> System.TimeSpan)) = _.GetUtcOffset
    (* run_target_args'
    let v4105 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4106 : string = "std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64)"
    let v4107 : System.TimeZoneInfo = Fable.Core.RustInterop.emitRustExpr () v4106 
    let _run_target_args'_v4105 = v4107 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4109 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4109 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4113 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4113 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4117 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4117 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4121 : System.TimeZoneInfo = null |> unbox<System.TimeZoneInfo>
    let _run_target_args'_v4105 = v4121 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4124 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4105 = v4124 
    #endif
#else
    let v4125 : System.TimeZoneInfo = System.TimeZoneInfo.Local
    let _run_target_args'_v4105 = v4125 
    #endif
    let v4126 : System.TimeZoneInfo = _run_target_args'_v4105 
    let v4132 : (System.DateTime -> System.TimeSpan) = v4100 v4126
    let v4133 : System.TimeSpan = v4132 v1
    let _run_target_args'_v3946 = v4133 
    #endif
    let v4134 : System.TimeSpan = _run_target_args'_v3946 
    let v4144 : (System.TimeSpan -> int32) = _.Hours
    let v4145 : int32 = v4144 v4134
    let v4148 : bool = v4145 > 0
    let v4149 : uint8 =
        if v4148 then
            1uy
        else
            0uy
    let v4150 : string = method75()
    (* run_target_args'
    let v4210 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4211 : string = "$0.toString($1)"
    let v4212 : string = Fable.Core.RustInterop.emitRustExpr struct (v4134, v4150) v4211 
    let _run_target_args'_v4210 = v4212 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4213 : string = "$0.toString($1)"
    let v4214 : string = Fable.Core.RustInterop.emitRustExpr struct (v4134, v4150) v4213 
    let _run_target_args'_v4210 = v4214 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4215 : string = "$0.toString($1)"
    let v4216 : string = Fable.Core.RustInterop.emitRustExpr struct (v4134, v4150) v4215 
    let _run_target_args'_v4210 = v4216 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4217 : string = v4134.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4210 = v4217 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4218 : string = v4134.ToString ("c", System.Globalization.CultureInfo.InvariantCulture)
    let _run_target_args'_v4210 = v4218 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4220 : string = v4134.ToString v4150 
    let _run_target_args'_v4210 = v4220 
    #endif
#else
    let v4279 : string = v4134.ToString v4150 
    let _run_target_args'_v4210 = v4279 
    #endif
    let v4337 : string = _run_target_args'_v4210 
    let v4398 : string = $"{v4149}{v4337}"
    let v4400 : (System.Guid -> string) = _.ToString()
    let v4401 : string = v4400 v0
    let v4404 : int32 = v3893.Length
    let v4405 : int32 = v4398.Length
    let v4406 : int32 = v4404 + v4405
    let v4408 : (string -> int32) = String.length
    let v4409 : int32 = v4408 v4401
    let v4417 : int32 = v4406 |> int32 
    let v4430 : int32 = v4409 |> int32 
    let v4438 : int32 = v4430 - 1
    let v4440 : string = v4401.[int v4417..int v4438]
    let v4444 : string = $"{v3893}{v4398}{v4440}"
    (* run_target_args'
    let v4449 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v4451 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4451 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4455 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4455 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v4459 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v4449 = v4459 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v4463 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4463 
    #endif
#if FABLE_COMPILER_PYTHON
    let v4467 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4467 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v4471 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4471 
    #endif
#else
    let v4475 : System.Guid = v4444 |> System.Guid 
    let _run_target_args'_v4449 = v4475 
    #endif
    let v4478 : System.Guid = _run_target_args'_v4449 
    let _run_target_args'_v599 = v4478 
    #endif
    let v4484 : System.Guid = _run_target_args'_v599 
    v4484
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
    let v181 : string = $"{v174}"
    let v189 : unit = ()
    let v190 : (unit -> unit) = closure6(v11, v181)
    let v191 : unit = (fun () -> v190 (); v189) ()
    let v199 : string = " }"
    let v200 : string = $"{v199}"
    let v208 : unit = ()
    let v209 : (unit -> unit) = closure6(v11, v200)
    let v210 : unit = (fun () -> v209 (); v208) ()
    let v216 : string = v11.l0
    let v217 : int64 = v0.l0
    let v220 : string = " "
    let v221 : string = v6 + v220 
    let v225 : string = v221 + v7 
    let v230 : string = " #"
    let v231 : string = v225 + v230 
    let v235 : (int64 -> string) = _.ToString()
    let v236 : string = v235 v217
    let v240 : string = v231 + v236 
    let v244 : string = v240 + v220 
    let v249 : string = "file_system.create_dir"
    let v250 : string = v244 + v249 
    let v255 : string = " / "
    let v256 : string = v250 + v255 
    let v260 : string = v256 + v216 
    method21(v260)
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
and method92 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method93 (v0 : string) : (unit -> unit) =
    closure47(v0)
and method82 (v0 : string) : System.IDisposable =
    (* run_target_args'
    let v228 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v229 : string = "std::fs::create_dir_all(&*$0)"
    let v230 : Result<unit, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v0 v229 
    let v231 : (std_io_Error -> std_string_String) = method83()
    (* run_target_args'
    let v233 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v234 : string = "$0.map_err(|x| $1(x))"
    let v235 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v230, v231) v234 
    let _run_target_args'_v233 = v235 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v236 : string = "$0.map_err(|x| $1(x))"
    let v237 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v230, v231) v236 
    let _run_target_args'_v233 = v237 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v238 : string = "$0.map_err(|x| $1(x))"
    let v239 : Result<unit, std_string_String> = Fable.Core.RustInterop.emitRustExpr struct (v230, v231) v238 
    let _run_target_args'_v233 = v239 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v240 : Result<unit, std_string_String> = match v230 with Ok x -> Ok x | Error x -> Error (v231 x)
    let _run_target_args'_v233 = v240 
    #endif
#if FABLE_COMPILER_PYTHON
    let v241 : Result<unit, std_string_String> = match v230 with Ok x -> Ok x | Error x -> Error (v231 x)
    let _run_target_args'_v233 = v241 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v242 : Result<unit, std_string_String> = match v230 with Ok x -> Ok x | Error x -> Error (v231 x)
    let _run_target_args'_v233 = v242 
    #endif
#else
    let v243 : Result<unit, std_string_String> = match v230 with Ok x -> Ok x | Error x -> Error (v231 x)
    let _run_target_args'_v233 = v243 
    #endif
    let v244 : Result<unit, std_string_String> = _run_target_args'_v233 
    let v247 : (unit -> US13) = method84()
    let v248 : (std_string_String -> US13) = method85()
    let v250 : US13 = match v244 with Ok () -> v247 () | Error x -> v248 x
    match v250 with
    | US13_1(v376) -> (* Error *)
        let v437 : unit = ()
        let v438 : (unit -> unit) = closure43(v0, v376)
        let v439 : unit = (fun () -> v438 (); v437) ()
        ()
    | US13_0 -> (* Ok *)
        let v313 : unit = ()
        let v314 : (unit -> unit) = closure44(v0)
        let v315 : unit = (fun () -> v314 (); v313) ()
        ()
    (* run_target_args'
    let v504 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v505 : (unit -> unit) = method88(v0)
    let v506 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v505 "$0()" )
    let _run_target_args'_v504 = v506 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v507 : (unit -> unit) = method88(v0)
    let v508 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v507 "$0()" )
    let _run_target_args'_v504 = v508 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v509 : (unit -> unit) = method88(v0)
    let v510 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v509 "$0()" )
    let _run_target_args'_v504 = v510 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v511 : (unit -> unit) = method89(v0)
    let v512 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v511 () }
    let _run_target_args'_v504 = v512 
    #endif
#if FABLE_COMPILER_PYTHON
    let v513 : (unit -> unit) = method89(v0)
    let v514 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v513 () }
    let _run_target_args'_v504 = v514 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v515 : (unit -> unit) = method89(v0)
    let v516 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v515 () }
    let _run_target_args'_v504 = v516 
    #endif
#else
    let v517 : (unit -> unit) = method89(v0)
    let v518 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v517 () }
    let _run_target_args'_v504 = v518 
    #endif
    let v519 : System.IDisposable = _run_target_args'_v504 
    let _run_target_args'_v228 = v519 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v524 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v228 = v524 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v528 : System.IDisposable = null |> unbox<System.IDisposable>
    let _run_target_args'_v228 = v528 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v531 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v536 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v538 : bool = null |> unbox<bool>
    let _run_target_args'_v536 = v538 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v542 : bool = null |> unbox<bool>
    let _run_target_args'_v536 = v542 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v546 : bool = null |> unbox<bool>
    let _run_target_args'_v536 = v546 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v550 : bool = null |> unbox<bool>
    let _run_target_args'_v536 = v550 
    #endif
#if FABLE_COMPILER_PYTHON
    let v554 : bool = null |> unbox<bool>
    let _run_target_args'_v536 = v554 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v558 : bool = null |> unbox<bool>
    let _run_target_args'_v536 = v558 
    #endif
#else
    let v561 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v562 : bool = v561 v531
    let _run_target_args'_v536 = v562 
    #endif
    let v563 : bool = _run_target_args'_v536 
    let v569 : bool = v563 = false
    if v569 then
        (* run_target_args'
        let v574 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v576 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v574 = v576 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v580 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v574 = v580 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v584 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v574 = v584 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v588 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v574 = v588 
        #endif
#if FABLE_COMPILER_PYTHON
        let v592 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v574 = v592 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v596 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v574 = v596 
        #endif
#else
        let v599 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v600 : System.DateTime = v599 v531
        let _run_target_args'_v574 = v600 
        #endif
        let v601 : System.DateTime = _run_target_args'_v574 
        let v607 : _ = {| Exists = v563; CreationTime = v601 |}
        let v609 : string = $"%A{v607}"
        let v672 : unit = ()
        let v673 : (unit -> unit) = closure46(v0, v609)
        let v674 : unit = (fun () -> v673 (); v672) ()
        ()
    (* run_target_args'
    let v739 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v740 : (unit -> unit) = method92(v0)
    let v741 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v740 "$0()" )
    let _run_target_args'_v739 = v741 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v742 : (unit -> unit) = method92(v0)
    let v743 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v742 "$0()" )
    let _run_target_args'_v739 = v743 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v744 : (unit -> unit) = method92(v0)
    let v745 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v744 "$0()" )
    let _run_target_args'_v739 = v745 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v746 : (unit -> unit) = method93(v0)
    let v747 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v746 () }
    let _run_target_args'_v739 = v747 
    #endif
#if FABLE_COMPILER_PYTHON
    let v748 : (unit -> unit) = method93(v0)
    let v749 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v748 () }
    let _run_target_args'_v739 = v749 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v750 : (unit -> unit) = method93(v0)
    let v751 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v750 () }
    let _run_target_args'_v739 = v751 
    #endif
#else
    let v752 : (unit -> unit) = method93(v0)
    let v753 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v752 () }
    let _run_target_args'_v739 = v753 
    #endif
    let v754 : System.IDisposable = _run_target_args'_v739 
    let _run_target_args'_v228 = v754 
    #endif
#if FABLE_COMPILER_PYTHON
    let v758 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v763 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v765 : bool = null |> unbox<bool>
    let _run_target_args'_v763 = v765 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v769 : bool = null |> unbox<bool>
    let _run_target_args'_v763 = v769 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v773 : bool = null |> unbox<bool>
    let _run_target_args'_v763 = v773 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v777 : bool = null |> unbox<bool>
    let _run_target_args'_v763 = v777 
    #endif
#if FABLE_COMPILER_PYTHON
    let v781 : bool = null |> unbox<bool>
    let _run_target_args'_v763 = v781 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v785 : bool = null |> unbox<bool>
    let _run_target_args'_v763 = v785 
    #endif
#else
    let v788 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v789 : bool = v788 v758
    let _run_target_args'_v763 = v789 
    #endif
    let v790 : bool = _run_target_args'_v763 
    let v796 : bool = v790 = false
    if v796 then
        (* run_target_args'
        let v801 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v803 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v801 = v803 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v807 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v801 = v807 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v811 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v801 = v811 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v815 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v801 = v815 
        #endif
#if FABLE_COMPILER_PYTHON
        let v819 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v801 = v819 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v823 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v801 = v823 
        #endif
#else
        let v826 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v827 : System.DateTime = v826 v758
        let _run_target_args'_v801 = v827 
        #endif
        let v828 : System.DateTime = _run_target_args'_v801 
        let v834 : _ = {| Exists = v790; CreationTime = v828 |}
        let v836 : string = $"%A{v834}"
        let v899 : unit = ()
        let v900 : (unit -> unit) = closure46(v0, v836)
        let v901 : unit = (fun () -> v900 (); v899) ()
        ()
    (* run_target_args'
    let v966 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v967 : (unit -> unit) = method92(v0)
    let v968 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v967 "$0()" )
    let _run_target_args'_v966 = v968 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v969 : (unit -> unit) = method92(v0)
    let v970 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v969 "$0()" )
    let _run_target_args'_v966 = v970 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v971 : (unit -> unit) = method92(v0)
    let v972 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v971 "$0()" )
    let _run_target_args'_v966 = v972 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v973 : (unit -> unit) = method93(v0)
    let v974 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v973 () }
    let _run_target_args'_v966 = v974 
    #endif
#if FABLE_COMPILER_PYTHON
    let v975 : (unit -> unit) = method93(v0)
    let v976 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v975 () }
    let _run_target_args'_v966 = v976 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v977 : (unit -> unit) = method93(v0)
    let v978 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v977 () }
    let _run_target_args'_v966 = v978 
    #endif
#else
    let v979 : (unit -> unit) = method93(v0)
    let v980 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v979 () }
    let _run_target_args'_v966 = v980 
    #endif
    let v981 : System.IDisposable = _run_target_args'_v966 
    let _run_target_args'_v228 = v981 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v985 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v990 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v992 : bool = null |> unbox<bool>
    let _run_target_args'_v990 = v992 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v996 : bool = null |> unbox<bool>
    let _run_target_args'_v990 = v996 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1000 : bool = null |> unbox<bool>
    let _run_target_args'_v990 = v1000 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1004 : bool = null |> unbox<bool>
    let _run_target_args'_v990 = v1004 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1008 : bool = null |> unbox<bool>
    let _run_target_args'_v990 = v1008 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1012 : bool = null |> unbox<bool>
    let _run_target_args'_v990 = v1012 
    #endif
#else
    let v1015 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v1016 : bool = v1015 v985
    let _run_target_args'_v990 = v1016 
    #endif
    let v1017 : bool = _run_target_args'_v990 
    let v1023 : bool = v1017 = false
    if v1023 then
        (* run_target_args'
        let v1028 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v1030 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1028 = v1030 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v1034 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1028 = v1034 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v1038 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1028 = v1038 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v1042 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1028 = v1042 
        #endif
#if FABLE_COMPILER_PYTHON
        let v1046 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1028 = v1046 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v1050 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1028 = v1050 
        #endif
#else
        let v1053 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v1054 : System.DateTime = v1053 v985
        let _run_target_args'_v1028 = v1054 
        #endif
        let v1055 : System.DateTime = _run_target_args'_v1028 
        let v1061 : _ = {| Exists = v1017; CreationTime = v1055 |}
        let v1063 : string = $"%A{v1061}"
        let v1126 : unit = ()
        let v1127 : (unit -> unit) = closure46(v0, v1063)
        let v1128 : unit = (fun () -> v1127 (); v1126) ()
        ()
    (* run_target_args'
    let v1193 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1194 : (unit -> unit) = method92(v0)
    let v1195 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1194 "$0()" )
    let _run_target_args'_v1193 = v1195 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1196 : (unit -> unit) = method92(v0)
    let v1197 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1196 "$0()" )
    let _run_target_args'_v1193 = v1197 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1198 : (unit -> unit) = method92(v0)
    let v1199 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1198 "$0()" )
    let _run_target_args'_v1193 = v1199 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1200 : (unit -> unit) = method93(v0)
    let v1201 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1200 () }
    let _run_target_args'_v1193 = v1201 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1202 : (unit -> unit) = method93(v0)
    let v1203 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1202 () }
    let _run_target_args'_v1193 = v1203 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1204 : (unit -> unit) = method93(v0)
    let v1205 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1204 () }
    let _run_target_args'_v1193 = v1205 
    #endif
#else
    let v1206 : (unit -> unit) = method93(v0)
    let v1207 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1206 () }
    let _run_target_args'_v1193 = v1207 
    #endif
    let v1208 : System.IDisposable = _run_target_args'_v1193 
    let _run_target_args'_v228 = v1208 
    #endif
#else
    let v1212 : System_IO_DirectoryInfo = method90(v0)
    (* run_target_args'
    let v1217 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1219 : bool = null |> unbox<bool>
    let _run_target_args'_v1217 = v1219 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1223 : bool = null |> unbox<bool>
    let _run_target_args'_v1217 = v1223 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1227 : bool = null |> unbox<bool>
    let _run_target_args'_v1217 = v1227 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1231 : bool = null |> unbox<bool>
    let _run_target_args'_v1217 = v1231 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1235 : bool = null |> unbox<bool>
    let _run_target_args'_v1217 = v1235 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1239 : bool = null |> unbox<bool>
    let _run_target_args'_v1217 = v1239 
    #endif
#else
    let v1242 : (System_IO_DirectoryInfo -> bool) = _.Exists
    let v1243 : bool = v1242 v1212
    let _run_target_args'_v1217 = v1243 
    #endif
    let v1244 : bool = _run_target_args'_v1217 
    let v1250 : bool = v1244 = false
    if v1250 then
        (* run_target_args'
        let v1255 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v1257 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1255 = v1257 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v1261 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1255 = v1261 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v1265 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1255 = v1265 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v1269 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1255 = v1269 
        #endif
#if FABLE_COMPILER_PYTHON
        let v1273 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1255 = v1273 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v1277 : System.DateTime = null |> unbox<System.DateTime>
        let _run_target_args'_v1255 = v1277 
        #endif
#else
        let v1280 : (System_IO_DirectoryInfo -> System.DateTime) = _.CreationTime
        let v1281 : System.DateTime = v1280 v1212
        let _run_target_args'_v1255 = v1281 
        #endif
        let v1282 : System.DateTime = _run_target_args'_v1255 
        let v1288 : _ = {| Exists = v1244; CreationTime = v1282 |}
        let v1290 : string = $"%A{v1288}"
        let v1353 : unit = ()
        let v1354 : (unit -> unit) = closure46(v0, v1290)
        let v1355 : unit = (fun () -> v1354 (); v1353) ()
        ()
    (* run_target_args'
    let v1420 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1421 : (unit -> unit) = method92(v0)
    let v1422 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1421 "$0()" )
    let _run_target_args'_v1420 = v1422 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1423 : (unit -> unit) = method92(v0)
    let v1424 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1423 "$0()" )
    let _run_target_args'_v1420 = v1424 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1425 : (unit -> unit) = method92(v0)
    let v1426 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v1425 "$0()" )
    let _run_target_args'_v1420 = v1426 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1427 : (unit -> unit) = method93(v0)
    let v1428 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1427 () }
    let _run_target_args'_v1420 = v1428 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1429 : (unit -> unit) = method93(v0)
    let v1430 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1429 () }
    let _run_target_args'_v1420 = v1430 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1431 : (unit -> unit) = method93(v0)
    let v1432 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1431 () }
    let _run_target_args'_v1420 = v1432 
    #endif
#else
    let v1433 : (unit -> unit) = method93(v0)
    let v1434 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v1433 () }
    let _run_target_args'_v1420 = v1434 
    #endif
    let v1435 : System.IDisposable = _run_target_args'_v1420 
    let _run_target_args'_v228 = v1435 
    #endif
    let v1439 : System.IDisposable = _run_target_args'_v228 
    v1439
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
    let v248 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v254 : int32 = 0 |> int32 
    let v267 : int32 = 8 |> int32 
    let v275 : int32 = v267 - 1
    let v277 : string = v13.[int v254..int v275]
    let v286 : int32 = 8 |> int32 
    let v299 : int32 = 12 |> int32 
    let v307 : int32 = v299 - 1
    let v309 : string = v13.[int v286..int v307]
    let v318 : int32 = 12 |> int32 
    let v331 : int32 = 16 |> int32 
    let v339 : int32 = v331 - 1
    let v341 : string = v13.[int v318..int v339]
    let v350 : int32 = 16 |> int32 
    let v363 : int32 = 20 |> int32 
    let v371 : int32 = v363 - 1
    let v373 : string = v13.[int v350..int v371]
    let v382 : int32 = 20 |> int32 
    let v395 : int32 = 32 |> int32 
    let v403 : int32 = v395 - 1
    let v405 : string = v13.[int v382..int v403]
    let v410 : string = v277 + v16 
    let v414 : string = v410 + v309 
    let v418 : string = v414 + v16 
    let v422 : string = v418 + v341 
    let v426 : string = v422 + v16 
    let v430 : string = v426 + v373 
    let v434 : string = v430 + v16 
    let v438 : string = v434 + v405 
    (* run_target_args'
    let v445 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v447 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v447 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v451 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v451 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v455 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v445 = v455 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v459 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v459 
    #endif
#if FABLE_COMPILER_PYTHON
    let v463 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v463 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v467 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v467 
    #endif
#else
    let v471 : System.Guid = v438 |> System.Guid 
    let _run_target_args'_v445 = v471 
    #endif
    let v474 : System.Guid = _run_target_args'_v445 
    let _run_target_args'_v248 = v474 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v485 : int32 = 0 |> int32 
    let v498 : int32 = 8 |> int32 
    let v506 : int32 = v498 - 1
    let v508 : string = v13.[int v485..int v506]
    let v517 : int32 = 8 |> int32 
    let v530 : int32 = 12 |> int32 
    let v538 : int32 = v530 - 1
    let v540 : string = v13.[int v517..int v538]
    let v549 : int32 = 12 |> int32 
    let v562 : int32 = 16 |> int32 
    let v570 : int32 = v562 - 1
    let v572 : string = v13.[int v549..int v570]
    let v581 : int32 = 16 |> int32 
    let v594 : int32 = 20 |> int32 
    let v602 : int32 = v594 - 1
    let v604 : string = v13.[int v581..int v602]
    let v613 : int32 = 20 |> int32 
    let v626 : int32 = 32 |> int32 
    let v634 : int32 = v626 - 1
    let v636 : string = v13.[int v613..int v634]
    let v641 : string = v508 + v16 
    let v645 : string = v641 + v540 
    let v649 : string = v645 + v16 
    let v653 : string = v649 + v572 
    let v657 : string = v653 + v16 
    let v661 : string = v657 + v604 
    let v665 : string = v661 + v16 
    let v669 : string = v665 + v636 
    (* run_target_args'
    let v676 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v678 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v678 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v682 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v682 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v686 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v676 = v686 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v690 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v690 
    #endif
#if FABLE_COMPILER_PYTHON
    let v694 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v694 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v698 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v698 
    #endif
#else
    let v702 : System.Guid = v669 |> System.Guid 
    let _run_target_args'_v676 = v702 
    #endif
    let v705 : System.Guid = _run_target_args'_v676 
    let _run_target_args'_v248 = v705 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v712 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v248 = v712 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v720 : int32 = 0 |> int32 
    let v733 : int32 = 8 |> int32 
    let v741 : int32 = v733 - 1
    let v743 : string = v13.[int v720..int v741]
    let v752 : int32 = 8 |> int32 
    let v765 : int32 = 12 |> int32 
    let v773 : int32 = v765 - 1
    let v775 : string = v13.[int v752..int v773]
    let v784 : int32 = 12 |> int32 
    let v797 : int32 = 16 |> int32 
    let v805 : int32 = v797 - 1
    let v807 : string = v13.[int v784..int v805]
    let v816 : int32 = 16 |> int32 
    let v829 : int32 = 20 |> int32 
    let v837 : int32 = v829 - 1
    let v839 : string = v13.[int v816..int v837]
    let v848 : int32 = 20 |> int32 
    let v861 : int32 = 32 |> int32 
    let v869 : int32 = v861 - 1
    let v871 : string = v13.[int v848..int v869]
    let v876 : string = v743 + v16 
    let v880 : string = v876 + v775 
    let v884 : string = v880 + v16 
    let v888 : string = v884 + v807 
    let v892 : string = v888 + v16 
    let v896 : string = v892 + v839 
    let v900 : string = v896 + v16 
    let v904 : string = v900 + v871 
    (* run_target_args'
    let v911 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v913 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v913 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v917 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v917 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v921 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v911 = v921 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v925 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v925 
    #endif
#if FABLE_COMPILER_PYTHON
    let v929 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v929 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v933 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v933 
    #endif
#else
    let v937 : System.Guid = v904 |> System.Guid 
    let _run_target_args'_v911 = v937 
    #endif
    let v940 : System.Guid = _run_target_args'_v911 
    let _run_target_args'_v248 = v940 
    #endif
#if FABLE_COMPILER_PYTHON
    let v951 : int32 = 0 |> int32 
    let v964 : int32 = 8 |> int32 
    let v972 : int32 = v964 - 1
    let v974 : string = v13.[int v951..int v972]
    let v983 : int32 = 8 |> int32 
    let v996 : int32 = 12 |> int32 
    let v1004 : int32 = v996 - 1
    let v1006 : string = v13.[int v983..int v1004]
    let v1015 : int32 = 12 |> int32 
    let v1028 : int32 = 16 |> int32 
    let v1036 : int32 = v1028 - 1
    let v1038 : string = v13.[int v1015..int v1036]
    let v1047 : int32 = 16 |> int32 
    let v1060 : int32 = 20 |> int32 
    let v1068 : int32 = v1060 - 1
    let v1070 : string = v13.[int v1047..int v1068]
    let v1079 : int32 = 20 |> int32 
    let v1092 : int32 = 32 |> int32 
    let v1100 : int32 = v1092 - 1
    let v1102 : string = v13.[int v1079..int v1100]
    let v1107 : string = v974 + v16 
    let v1111 : string = v1107 + v1006 
    let v1115 : string = v1111 + v16 
    let v1119 : string = v1115 + v1038 
    let v1123 : string = v1119 + v16 
    let v1127 : string = v1123 + v1070 
    let v1131 : string = v1127 + v16 
    let v1135 : string = v1131 + v1102 
    (* run_target_args'
    let v1142 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1144 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1144 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1148 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1148 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1152 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1142 = v1152 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1156 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1156 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1160 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1160 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1164 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1164 
    #endif
#else
    let v1168 : System.Guid = v1135 |> System.Guid 
    let _run_target_args'_v1142 = v1168 
    #endif
    let v1171 : System.Guid = _run_target_args'_v1142 
    let _run_target_args'_v248 = v1171 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1182 : int32 = 0 |> int32 
    let v1195 : int32 = 8 |> int32 
    let v1203 : int32 = v1195 - 1
    let v1205 : string = v13.[int v1182..int v1203]
    let v1214 : int32 = 8 |> int32 
    let v1227 : int32 = 12 |> int32 
    let v1235 : int32 = v1227 - 1
    let v1237 : string = v13.[int v1214..int v1235]
    let v1246 : int32 = 12 |> int32 
    let v1259 : int32 = 16 |> int32 
    let v1267 : int32 = v1259 - 1
    let v1269 : string = v13.[int v1246..int v1267]
    let v1278 : int32 = 16 |> int32 
    let v1291 : int32 = 20 |> int32 
    let v1299 : int32 = v1291 - 1
    let v1301 : string = v13.[int v1278..int v1299]
    let v1310 : int32 = 20 |> int32 
    let v1323 : int32 = 32 |> int32 
    let v1331 : int32 = v1323 - 1
    let v1333 : string = v13.[int v1310..int v1331]
    let v1338 : string = v1205 + v16 
    let v1342 : string = v1338 + v1237 
    let v1346 : string = v1342 + v16 
    let v1350 : string = v1346 + v1269 
    let v1354 : string = v1350 + v16 
    let v1358 : string = v1354 + v1301 
    let v1362 : string = v1358 + v16 
    let v1366 : string = v1362 + v1333 
    (* run_target_args'
    let v1373 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1375 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1375 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1379 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1379 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1383 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1373 = v1383 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1387 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1387 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1391 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1391 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1395 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1395 
    #endif
#else
    let v1399 : System.Guid = v1366 |> System.Guid 
    let _run_target_args'_v1373 = v1399 
    #endif
    let v1402 : System.Guid = _run_target_args'_v1373 
    let _run_target_args'_v248 = v1402 
    #endif
#else
    let v1413 : int32 = 0 |> int32 
    let v1426 : int32 = 8 |> int32 
    let v1434 : int32 = v1426 - 1
    let v1436 : string = v13.[int v1413..int v1434]
    let v1445 : int32 = 8 |> int32 
    let v1458 : int32 = 12 |> int32 
    let v1466 : int32 = v1458 - 1
    let v1468 : string = v13.[int v1445..int v1466]
    let v1477 : int32 = 12 |> int32 
    let v1490 : int32 = 16 |> int32 
    let v1498 : int32 = v1490 - 1
    let v1500 : string = v13.[int v1477..int v1498]
    let v1509 : int32 = 16 |> int32 
    let v1522 : int32 = 20 |> int32 
    let v1530 : int32 = v1522 - 1
    let v1532 : string = v13.[int v1509..int v1530]
    let v1541 : int32 = 20 |> int32 
    let v1554 : int32 = 32 |> int32 
    let v1562 : int32 = v1554 - 1
    let v1564 : string = v13.[int v1541..int v1562]
    let v1569 : string = v1436 + v16 
    let v1573 : string = v1569 + v1468 
    let v1577 : string = v1573 + v16 
    let v1581 : string = v1577 + v1500 
    let v1585 : string = v1581 + v16 
    let v1589 : string = v1585 + v1532 
    let v1593 : string = v1589 + v16 
    let v1597 : string = v1593 + v1564 
    (* run_target_args'
    let v1604 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v1606 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1606 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v1610 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1610 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v1614 : System.Guid = null |> unbox<System.Guid>
    let _run_target_args'_v1604 = v1614 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v1618 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1618 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1622 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1622 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v1626 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1626 
    #endif
#else
    let v1630 : System.Guid = v1597 |> System.Guid 
    let _run_target_args'_v1604 = v1630 
    #endif
    let v1633 : System.Guid = _run_target_args'_v1604 
    let _run_target_args'_v248 = v1633 
    #endif
    let v1639 : System.Guid = _run_target_args'_v248 
    v1639
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
        let v93 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v94 : string = "Err($0)"
        let v95 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v94 
        let _run_target_args'_v93 = v95 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v96 : string = "Err($0)"
        let v97 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v96 
        let _run_target_args'_v93 = v97 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v98 : string = "Err($0)"
        let v99 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v86 v98 
        let _run_target_args'_v93 = v99 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v100 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v93 = v100 
        #endif
#if FABLE_COMPILER_PYTHON
        let v101 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v93 = v101 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v102 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v93 = v102 
        #endif
#else
        let v103 : Result<std_path_PathBuf, std_io_Error> = v86 |> Error
        let _run_target_args'_v93 = v103 
        #endif
        let v104 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v93 
        v104
    else
        match v31 with
        | US5_0(v107) -> (* Some *)
            let v110 : string = ""
            let v111 : bool = v4 <> v110 
            if v111 then
                let v114 : uint8 = v2 + 1uy
                let v115 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v114
                let v116 : Result<std_path_PathBuf, std_io_Error> = v115 v107
                let v117 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v119 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v120 : string = "$0.map_err(|x| $1(x))"
                let v121 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v116, v117) v120 
                let _run_target_args'_v119 = v121 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v122 : string = "$0.map_err(|x| $1(x))"
                let v123 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v116, v117) v122 
                let _run_target_args'_v119 = v123 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v124 : string = "$0.map_err(|x| $1(x))"
                let v125 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v116, v117) v124 
                let _run_target_args'_v119 = v125 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v126 : Result<std_path_PathBuf, string> = match v116 with Ok x -> Ok x | Error x -> Error (v117 x)
                let _run_target_args'_v119 = v126 
                #endif
#if FABLE_COMPILER_PYTHON
                let v127 : Result<std_path_PathBuf, string> = match v116 with Ok x -> Ok x | Error x -> Error (v117 x)
                let _run_target_args'_v119 = v127 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v128 : Result<std_path_PathBuf, string> = match v116 with Ok x -> Ok x | Error x -> Error (v117 x)
                let _run_target_args'_v119 = v128 
                #endif
#else
                let v129 : Result<std_path_PathBuf, string> = match v116 with Ok x -> Ok x | Error x -> Error (v117 x)
                let _run_target_args'_v119 = v129 
                #endif
                let v130 : Result<std_path_PathBuf, string> = _run_target_args'_v119 
                let v133 : (std_path_PathBuf -> US14) = method99()
                let v134 : (string -> US14) = method100()
                let v136 : US14 = match v130 with Ok x -> v133 x | Error x -> v134 x
                match v136 with
                | US14_1(v292) -> (* Error *)
                    let v293 : string = $"file_system.read_link / "
                    let v294 : string = $"error': {v292} / error: {v54} / name: {v5}"
                    let v295 : string = v293 + v294 
                    (* run_target_args'
                    let v300 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v301 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v302 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v301 
                    let _run_target_args'_v300 = v302 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v303 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v304 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v303 
                    let _run_target_args'_v300 = v304 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v305 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v306 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v295 v305 
                    let _run_target_args'_v300 = v306 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v308 : std_io_Error = v295 |> unbox<std_io_Error>
                    let _run_target_args'_v300 = v308 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v312 : std_io_Error = v295 |> unbox<std_io_Error>
                    let _run_target_args'_v300 = v312 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v316 : std_io_Error = v295 |> unbox<std_io_Error>
                    let _run_target_args'_v300 = v316 
                    #endif
#else
                    let v320 : std_io_Error = v295 |> unbox<std_io_Error>
                    let _run_target_args'_v300 = v320 
                    #endif
                    let v323 : std_io_Error = _run_target_args'_v300 
                    (* run_target_args'
                    let v330 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v331 : string = "Err($0)"
                    let v332 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v323 v331 
                    let _run_target_args'_v330 = v332 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v333 : string = "Err($0)"
                    let v334 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v323 v333 
                    let _run_target_args'_v330 = v334 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v335 : string = "Err($0)"
                    let v336 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v323 v335 
                    let _run_target_args'_v330 = v336 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v337 : Result<std_path_PathBuf, std_io_Error> = v323 |> Error
                    let _run_target_args'_v330 = v337 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v338 : Result<std_path_PathBuf, std_io_Error> = v323 |> Error
                    let _run_target_args'_v330 = v338 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v339 : Result<std_path_PathBuf, std_io_Error> = v323 |> Error
                    let _run_target_args'_v330 = v339 
                    #endif
#else
                    let v340 : Result<std_path_PathBuf, std_io_Error> = v323 |> Error
                    let _run_target_args'_v330 = v340 
                    #endif
                    let v341 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v330 
                    v341
                | US14_0(v139) -> (* Ok *)
                    (* run_target_args'
                    let v144 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v145 : string = "$0.display()"
                    let v146 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v139 v145 
                    let _run_target_args'_v144 = v146 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v147 : string = "$0.display()"
                    let v148 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v139 v147 
                    let _run_target_args'_v144 = v148 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v149 : string = "$0.display()"
                    let v150 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v139 v149 
                    let _run_target_args'_v144 = v150 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v152 : std_path_Display = v139 |> unbox<std_path_Display>
                    let _run_target_args'_v144 = v152 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v156 : std_path_Display = v139 |> unbox<std_path_Display>
                    let _run_target_args'_v144 = v156 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v160 : std_path_Display = v139 |> unbox<std_path_Display>
                    let _run_target_args'_v144 = v160 
                    #endif
#else
                    let v164 : std_path_Display = v139 |> unbox<std_path_Display>
                    let _run_target_args'_v144 = v164 
                    #endif
                    let v167 : std_path_Display = _run_target_args'_v144 
                    let v174 : string = v167 |> string 
                    let v177 : string = method79(v174, v5)
                    (* run_target_args'
                    let v182 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v183 : string = "&*$0"
                    let v184 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v177 v183 
                    let _run_target_args'_v182 = v184 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v185 : string = "&*$0"
                    let v186 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v177 v185 
                    let _run_target_args'_v182 = v186 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v187 : string = "&*$0"
                    let v188 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v177 v187 
                    let _run_target_args'_v182 = v188 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v190 : Ref<Str> = v177 |> unbox<Ref<Str>>
                    let _run_target_args'_v182 = v190 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v194 : Ref<Str> = v177 |> unbox<Ref<Str>>
                    let _run_target_args'_v182 = v194 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v198 : Ref<Str> = v177 |> unbox<Ref<Str>>
                    let _run_target_args'_v182 = v198 
                    #endif
#else
                    let v202 : Ref<Str> = v177 |> unbox<Ref<Str>>
                    let _run_target_args'_v182 = v202 
                    #endif
                    let v205 : Ref<Str> = _run_target_args'_v182 
                    (* run_target_args'
                    let v215 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v216 : string = "String::from($0)"
                    let v217 : std_string_String = Fable.Core.RustInterop.emitRustExpr v205 v216 
                    let _run_target_args'_v215 = v217 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v218 : string = "String::from($0)"
                    let v219 : std_string_String = Fable.Core.RustInterop.emitRustExpr v205 v218 
                    let _run_target_args'_v215 = v219 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v220 : string = "String::from($0)"
                    let v221 : std_string_String = Fable.Core.RustInterop.emitRustExpr v205 v220 
                    let _run_target_args'_v215 = v221 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v223 : std_string_String = v205 |> unbox<std_string_String>
                    let _run_target_args'_v215 = v223 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v227 : std_string_String = v205 |> unbox<std_string_String>
                    let _run_target_args'_v215 = v227 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v231 : std_string_String = v205 |> unbox<std_string_String>
                    let _run_target_args'_v215 = v231 
                    #endif
#else
                    let v235 : std_string_String = v205 |> unbox<std_string_String>
                    let _run_target_args'_v215 = v235 
                    #endif
                    let v238 : std_string_String = _run_target_args'_v215 
                    (* run_target_args'
                    let v248 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v249 : string = "std::path::PathBuf::from($0)"
                    let v250 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v238 v249 
                    let _run_target_args'_v248 = v250 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v251 : string = "std::path::PathBuf::from($0)"
                    let v252 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v238 v251 
                    let _run_target_args'_v248 = v252 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v253 : string = "std::path::PathBuf::from($0)"
                    let v254 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v238 v253 
                    let _run_target_args'_v248 = v254 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v256 : std_path_PathBuf = v238 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v248 = v256 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v260 : std_path_PathBuf = v238 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v248 = v260 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v264 : std_path_PathBuf = v238 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v248 = v264 
                    #endif
#else
                    let v268 : std_path_PathBuf = v238 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v248 = v268 
                    #endif
                    let v271 : std_path_PathBuf = _run_target_args'_v248 
                    (* run_target_args'
                    let v278 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v279 : string = "Ok($0)"
                    let v280 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v271 v279 
                    let _run_target_args'_v278 = v280 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v281 : string = "Ok($0)"
                    let v282 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v271 v281 
                    let _run_target_args'_v278 = v282 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v283 : string = "Ok($0)"
                    let v284 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v271 v283 
                    let _run_target_args'_v278 = v284 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v285 : Result<std_path_PathBuf, std_io_Error> = v271 |> Ok
                    let _run_target_args'_v278 = v285 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v286 : Result<std_path_PathBuf, std_io_Error> = v271 |> Ok
                    let _run_target_args'_v278 = v286 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v287 : Result<std_path_PathBuf, std_io_Error> = v271 |> Ok
                    let _run_target_args'_v278 = v287 
                    #endif
#else
                    let v288 : Result<std_path_PathBuf, std_io_Error> = v271 |> Ok
                    let _run_target_args'_v278 = v288 
                    #endif
                    let v289 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v278 
                    v289
            else
                let v346 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v347 : string = $"path: {v0} / error: {v54} / path': {v4} / name: {v5}"
                let v348 : string = v346 + v347 
                (* run_target_args'
                let v353 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v354 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v355 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v348 v354 
                let _run_target_args'_v353 = v355 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v356 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v357 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v348 v356 
                let _run_target_args'_v353 = v357 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v358 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v359 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v348 v358 
                let _run_target_args'_v353 = v359 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v361 : std_io_Error = v348 |> unbox<std_io_Error>
                let _run_target_args'_v353 = v361 
                #endif
#if FABLE_COMPILER_PYTHON
                let v365 : std_io_Error = v348 |> unbox<std_io_Error>
                let _run_target_args'_v353 = v365 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v369 : std_io_Error = v348 |> unbox<std_io_Error>
                let _run_target_args'_v353 = v369 
                #endif
#else
                let v373 : std_io_Error = v348 |> unbox<std_io_Error>
                let _run_target_args'_v353 = v373 
                #endif
                let v376 : std_io_Error = _run_target_args'_v353 
                (* run_target_args'
                let v383 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v384 : string = "Err($0)"
                let v385 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v376 v384 
                let _run_target_args'_v383 = v385 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v386 : string = "Err($0)"
                let v387 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v376 v386 
                let _run_target_args'_v383 = v387 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v388 : string = "Err($0)"
                let v389 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v376 v388 
                let _run_target_args'_v383 = v389 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v390 : Result<std_path_PathBuf, std_io_Error> = v376 |> Error
                let _run_target_args'_v383 = v390 
                #endif
#if FABLE_COMPILER_PYTHON
                let v391 : Result<std_path_PathBuf, std_io_Error> = v376 |> Error
                let _run_target_args'_v383 = v391 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v392 : Result<std_path_PathBuf, std_io_Error> = v376 |> Error
                let _run_target_args'_v383 = v392 
                #endif
#else
                let v393 : Result<std_path_PathBuf, std_io_Error> = v376 |> Error
                let _run_target_args'_v383 = v393 
                #endif
                let v394 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v383 
                v394
        | _ ->
            let v398 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v399 : string = $"path: {v0} / error: {v54} / path': {v4} / name: {v5}"
            let v400 : string = v398 + v399 
            (* run_target_args'
            let v405 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v406 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v407 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v400 v406 
            let _run_target_args'_v405 = v407 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v408 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v409 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v400 v408 
            let _run_target_args'_v405 = v409 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v410 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v411 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v400 v410 
            let _run_target_args'_v405 = v411 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v413 : std_io_Error = v400 |> unbox<std_io_Error>
            let _run_target_args'_v405 = v413 
            #endif
#if FABLE_COMPILER_PYTHON
            let v417 : std_io_Error = v400 |> unbox<std_io_Error>
            let _run_target_args'_v405 = v417 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v421 : std_io_Error = v400 |> unbox<std_io_Error>
            let _run_target_args'_v405 = v421 
            #endif
#else
            let v425 : std_io_Error = v400 |> unbox<std_io_Error>
            let _run_target_args'_v405 = v425 
            #endif
            let v428 : std_io_Error = _run_target_args'_v405 
            (* run_target_args'
            let v435 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v436 : string = "Err($0)"
            let v437 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v428 v436 
            let _run_target_args'_v435 = v437 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v438 : string = "Err($0)"
            let v439 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v428 v438 
            let _run_target_args'_v435 = v439 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v440 : string = "Err($0)"
            let v441 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v428 v440 
            let _run_target_args'_v435 = v441 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v442 : Result<std_path_PathBuf, std_io_Error> = v428 |> Error
            let _run_target_args'_v435 = v442 
            #endif
#if FABLE_COMPILER_PYTHON
            let v443 : Result<std_path_PathBuf, std_io_Error> = v428 |> Error
            let _run_target_args'_v435 = v443 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v444 : Result<std_path_PathBuf, std_io_Error> = v428 |> Error
            let _run_target_args'_v435 = v444 
            #endif
#else
            let v445 : Result<std_path_PathBuf, std_io_Error> = v428 |> Error
            let _run_target_args'_v435 = v445 
            #endif
            let v446 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v435 
            v446
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
        let v92 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v93 : string = "Err($0)"
        let v94 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v93 
        let _run_target_args'_v92 = v94 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v95 : string = "Err($0)"
        let v96 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v95 
        let _run_target_args'_v92 = v96 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v97 : string = "Err($0)"
        let v98 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v85 v97 
        let _run_target_args'_v92 = v98 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v99 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v92 = v99 
        #endif
#if FABLE_COMPILER_PYTHON
        let v100 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v92 = v100 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v101 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v92 = v101 
        #endif
#else
        let v102 : Result<std_path_PathBuf, std_io_Error> = v85 |> Error
        let _run_target_args'_v92 = v102 
        #endif
        let v103 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v92 
        v103
    else
        match v30 with
        | US5_0(v106) -> (* Some *)
            let v109 : string = ""
            let v110 : bool = v0 <> v109 
            if v110 then
                let v113 : uint8 = v2 + 1uy
                let v114 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v113
                let v115 : Result<std_path_PathBuf, std_io_Error> = v114 v106
                let v116 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v118 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v119 : string = "$0.map_err(|x| $1(x))"
                let v120 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v115, v116) v119 
                let _run_target_args'_v118 = v120 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v121 : string = "$0.map_err(|x| $1(x))"
                let v122 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v115, v116) v121 
                let _run_target_args'_v118 = v122 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v123 : string = "$0.map_err(|x| $1(x))"
                let v124 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v115, v116) v123 
                let _run_target_args'_v118 = v124 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v125 : Result<std_path_PathBuf, string> = match v115 with Ok x -> Ok x | Error x -> Error (v116 x)
                let _run_target_args'_v118 = v125 
                #endif
#if FABLE_COMPILER_PYTHON
                let v126 : Result<std_path_PathBuf, string> = match v115 with Ok x -> Ok x | Error x -> Error (v116 x)
                let _run_target_args'_v118 = v126 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v127 : Result<std_path_PathBuf, string> = match v115 with Ok x -> Ok x | Error x -> Error (v116 x)
                let _run_target_args'_v118 = v127 
                #endif
#else
                let v128 : Result<std_path_PathBuf, string> = match v115 with Ok x -> Ok x | Error x -> Error (v116 x)
                let _run_target_args'_v118 = v128 
                #endif
                let v129 : Result<std_path_PathBuf, string> = _run_target_args'_v118 
                let v132 : (std_path_PathBuf -> US14) = method99()
                let v133 : (string -> US14) = method100()
                let v135 : US14 = match v129 with Ok x -> v132 x | Error x -> v133 x
                match v135 with
                | US14_1(v291) -> (* Error *)
                    let v292 : string = $"file_system.read_link / "
                    let v293 : string = $"error': {v291} / error: {v53} / name: {v4}"
                    let v294 : string = v292 + v293 
                    (* run_target_args'
                    let v299 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v300 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v301 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v294 v300 
                    let _run_target_args'_v299 = v301 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v302 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v303 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v294 v302 
                    let _run_target_args'_v299 = v303 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v304 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v305 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v294 v304 
                    let _run_target_args'_v299 = v305 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v307 : std_io_Error = v294 |> unbox<std_io_Error>
                    let _run_target_args'_v299 = v307 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v311 : std_io_Error = v294 |> unbox<std_io_Error>
                    let _run_target_args'_v299 = v311 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v315 : std_io_Error = v294 |> unbox<std_io_Error>
                    let _run_target_args'_v299 = v315 
                    #endif
#else
                    let v319 : std_io_Error = v294 |> unbox<std_io_Error>
                    let _run_target_args'_v299 = v319 
                    #endif
                    let v322 : std_io_Error = _run_target_args'_v299 
                    (* run_target_args'
                    let v329 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v330 : string = "Err($0)"
                    let v331 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v322 v330 
                    let _run_target_args'_v329 = v331 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v332 : string = "Err($0)"
                    let v333 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v322 v332 
                    let _run_target_args'_v329 = v333 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v334 : string = "Err($0)"
                    let v335 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v322 v334 
                    let _run_target_args'_v329 = v335 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v336 : Result<std_path_PathBuf, std_io_Error> = v322 |> Error
                    let _run_target_args'_v329 = v336 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v337 : Result<std_path_PathBuf, std_io_Error> = v322 |> Error
                    let _run_target_args'_v329 = v337 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v338 : Result<std_path_PathBuf, std_io_Error> = v322 |> Error
                    let _run_target_args'_v329 = v338 
                    #endif
#else
                    let v339 : Result<std_path_PathBuf, std_io_Error> = v322 |> Error
                    let _run_target_args'_v329 = v339 
                    #endif
                    let v340 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v329 
                    v340
                | US14_0(v138) -> (* Ok *)
                    (* run_target_args'
                    let v143 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v144 : string = "$0.display()"
                    let v145 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v138 v144 
                    let _run_target_args'_v143 = v145 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v146 : string = "$0.display()"
                    let v147 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v138 v146 
                    let _run_target_args'_v143 = v147 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v148 : string = "$0.display()"
                    let v149 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v138 v148 
                    let _run_target_args'_v143 = v149 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v151 : std_path_Display = v138 |> unbox<std_path_Display>
                    let _run_target_args'_v143 = v151 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v155 : std_path_Display = v138 |> unbox<std_path_Display>
                    let _run_target_args'_v143 = v155 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v159 : std_path_Display = v138 |> unbox<std_path_Display>
                    let _run_target_args'_v143 = v159 
                    #endif
#else
                    let v163 : std_path_Display = v138 |> unbox<std_path_Display>
                    let _run_target_args'_v143 = v163 
                    #endif
                    let v166 : std_path_Display = _run_target_args'_v143 
                    let v173 : string = v166 |> string 
                    let v176 : string = method79(v173, v4)
                    (* run_target_args'
                    let v181 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v182 : string = "&*$0"
                    let v183 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v176 v182 
                    let _run_target_args'_v181 = v183 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v184 : string = "&*$0"
                    let v185 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v176 v184 
                    let _run_target_args'_v181 = v185 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v186 : string = "&*$0"
                    let v187 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v176 v186 
                    let _run_target_args'_v181 = v187 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v189 : Ref<Str> = v176 |> unbox<Ref<Str>>
                    let _run_target_args'_v181 = v189 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v193 : Ref<Str> = v176 |> unbox<Ref<Str>>
                    let _run_target_args'_v181 = v193 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v197 : Ref<Str> = v176 |> unbox<Ref<Str>>
                    let _run_target_args'_v181 = v197 
                    #endif
#else
                    let v201 : Ref<Str> = v176 |> unbox<Ref<Str>>
                    let _run_target_args'_v181 = v201 
                    #endif
                    let v204 : Ref<Str> = _run_target_args'_v181 
                    (* run_target_args'
                    let v214 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v215 : string = "String::from($0)"
                    let v216 : std_string_String = Fable.Core.RustInterop.emitRustExpr v204 v215 
                    let _run_target_args'_v214 = v216 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v217 : string = "String::from($0)"
                    let v218 : std_string_String = Fable.Core.RustInterop.emitRustExpr v204 v217 
                    let _run_target_args'_v214 = v218 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v219 : string = "String::from($0)"
                    let v220 : std_string_String = Fable.Core.RustInterop.emitRustExpr v204 v219 
                    let _run_target_args'_v214 = v220 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v222 : std_string_String = v204 |> unbox<std_string_String>
                    let _run_target_args'_v214 = v222 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v226 : std_string_String = v204 |> unbox<std_string_String>
                    let _run_target_args'_v214 = v226 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v230 : std_string_String = v204 |> unbox<std_string_String>
                    let _run_target_args'_v214 = v230 
                    #endif
#else
                    let v234 : std_string_String = v204 |> unbox<std_string_String>
                    let _run_target_args'_v214 = v234 
                    #endif
                    let v237 : std_string_String = _run_target_args'_v214 
                    (* run_target_args'
                    let v247 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v248 : string = "std::path::PathBuf::from($0)"
                    let v249 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v237 v248 
                    let _run_target_args'_v247 = v249 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v250 : string = "std::path::PathBuf::from($0)"
                    let v251 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v237 v250 
                    let _run_target_args'_v247 = v251 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v252 : string = "std::path::PathBuf::from($0)"
                    let v253 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v237 v252 
                    let _run_target_args'_v247 = v253 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v255 : std_path_PathBuf = v237 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v247 = v255 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v259 : std_path_PathBuf = v237 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v247 = v259 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v263 : std_path_PathBuf = v237 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v247 = v263 
                    #endif
#else
                    let v267 : std_path_PathBuf = v237 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v247 = v267 
                    #endif
                    let v270 : std_path_PathBuf = _run_target_args'_v247 
                    (* run_target_args'
                    let v277 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v278 : string = "Ok($0)"
                    let v279 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v270 v278 
                    let _run_target_args'_v277 = v279 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v280 : string = "Ok($0)"
                    let v281 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v270 v280 
                    let _run_target_args'_v277 = v281 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v282 : string = "Ok($0)"
                    let v283 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v270 v282 
                    let _run_target_args'_v277 = v283 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v284 : Result<std_path_PathBuf, std_io_Error> = v270 |> Ok
                    let _run_target_args'_v277 = v284 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v285 : Result<std_path_PathBuf, std_io_Error> = v270 |> Ok
                    let _run_target_args'_v277 = v285 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v286 : Result<std_path_PathBuf, std_io_Error> = v270 |> Ok
                    let _run_target_args'_v277 = v286 
                    #endif
#else
                    let v287 : Result<std_path_PathBuf, std_io_Error> = v270 |> Ok
                    let _run_target_args'_v277 = v287 
                    #endif
                    let v288 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v277 
                    v288
            else
                let v345 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v346 : string = $"path: {v0} / error: {v53} / path': {v0} / name: {v4}"
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
                let v382 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v383 : string = "Err($0)"
                let v384 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v383 
                let _run_target_args'_v382 = v384 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v385 : string = "Err($0)"
                let v386 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v385 
                let _run_target_args'_v382 = v386 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v387 : string = "Err($0)"
                let v388 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v375 v387 
                let _run_target_args'_v382 = v388 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v389 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v382 = v389 
                #endif
#if FABLE_COMPILER_PYTHON
                let v390 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v382 = v390 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v391 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v382 = v391 
                #endif
#else
                let v392 : Result<std_path_PathBuf, std_io_Error> = v375 |> Error
                let _run_target_args'_v382 = v392 
                #endif
                let v393 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v382 
                v393
        | _ ->
            let v397 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v398 : string = $"path: {v0} / error: {v53} / path': {v0} / name: {v4}"
            let v399 : string = v397 + v398 
            (* run_target_args'
            let v404 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v405 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v406 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v399 v405 
            let _run_target_args'_v404 = v406 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v407 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v408 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v399 v407 
            let _run_target_args'_v404 = v408 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v409 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v410 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v399 v409 
            let _run_target_args'_v404 = v410 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v412 : std_io_Error = v399 |> unbox<std_io_Error>
            let _run_target_args'_v404 = v412 
            #endif
#if FABLE_COMPILER_PYTHON
            let v416 : std_io_Error = v399 |> unbox<std_io_Error>
            let _run_target_args'_v404 = v416 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v420 : std_io_Error = v399 |> unbox<std_io_Error>
            let _run_target_args'_v404 = v420 
            #endif
#else
            let v424 : std_io_Error = v399 |> unbox<std_io_Error>
            let _run_target_args'_v404 = v424 
            #endif
            let v427 : std_io_Error = _run_target_args'_v404 
            (* run_target_args'
            let v434 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v435 : string = "Err($0)"
            let v436 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v427 v435 
            let _run_target_args'_v434 = v436 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v437 : string = "Err($0)"
            let v438 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v427 v437 
            let _run_target_args'_v434 = v438 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v439 : string = "Err($0)"
            let v440 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v427 v439 
            let _run_target_args'_v434 = v440 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v441 : Result<std_path_PathBuf, std_io_Error> = v427 |> Error
            let _run_target_args'_v434 = v441 
            #endif
#if FABLE_COMPILER_PYTHON
            let v442 : Result<std_path_PathBuf, std_io_Error> = v427 |> Error
            let _run_target_args'_v434 = v442 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v443 : Result<std_path_PathBuf, std_io_Error> = v427 |> Error
            let _run_target_args'_v434 = v443 
            #endif
#else
            let v444 : Result<std_path_PathBuf, std_io_Error> = v427 |> Error
            let _run_target_args'_v434 = v444 
            #endif
            let v445 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v434 
            v445
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
    let v77 : string = $"{v70}"
    let v85 : unit = ()
    let v86 : (unit -> unit) = closure6(v36, v77)
    let v87 : unit = (fun () -> v86 (); v85) ()
    let v93 : string = v36.l0
    let v94 : bool = v2 >= 11uy
    if v94 then
        let v95 : string = $"file_system.read_link / "
        let v96 : string = $"path: {v0} / n: {v2} / path': {v4} / name: {v5}"
        let v97 : string = v95 + v96 
        (* run_target_args'
        let v102 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v103 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v104 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v97 v103 
        let _run_target_args'_v102 = v104 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v105 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v106 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v97 v105 
        let _run_target_args'_v102 = v106 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v107 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v108 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v97 v107 
        let _run_target_args'_v102 = v108 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v110 : std_io_Error = v97 |> unbox<std_io_Error>
        let _run_target_args'_v102 = v110 
        #endif
#if FABLE_COMPILER_PYTHON
        let v114 : std_io_Error = v97 |> unbox<std_io_Error>
        let _run_target_args'_v102 = v114 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v118 : std_io_Error = v97 |> unbox<std_io_Error>
        let _run_target_args'_v102 = v118 
        #endif
#else
        let v122 : std_io_Error = v97 |> unbox<std_io_Error>
        let _run_target_args'_v102 = v122 
        #endif
        let v125 : std_io_Error = _run_target_args'_v102 
        (* run_target_args'
        let v132 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v133 : string = "Err($0)"
        let v134 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v125 v133 
        let _run_target_args'_v132 = v134 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v135 : string = "Err($0)"
        let v136 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v125 v135 
        let _run_target_args'_v132 = v136 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v137 : string = "Err($0)"
        let v138 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v125 v137 
        let _run_target_args'_v132 = v138 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v139 : Result<std_path_PathBuf, std_io_Error> = v125 |> Error
        let _run_target_args'_v132 = v139 
        #endif
#if FABLE_COMPILER_PYTHON
        let v140 : Result<std_path_PathBuf, std_io_Error> = v125 |> Error
        let _run_target_args'_v132 = v140 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v141 : Result<std_path_PathBuf, std_io_Error> = v125 |> Error
        let _run_target_args'_v132 = v141 
        #endif
#else
        let v142 : Result<std_path_PathBuf, std_io_Error> = v125 |> Error
        let _run_target_args'_v132 = v142 
        #endif
        let v143 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v132 
        v143
    else
        match v31 with
        | US5_0(v146) -> (* Some *)
            let v149 : string = ""
            let v150 : bool = v4 <> v149 
            if v150 then
                let v153 : uint8 = v2 + 1uy
                let v154 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v153
                let v155 : Result<std_path_PathBuf, std_io_Error> = v154 v146
                let v156 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v158 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v159 : string = "$0.map_err(|x| $1(x))"
                let v160 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v155, v156) v159 
                let _run_target_args'_v158 = v160 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v161 : string = "$0.map_err(|x| $1(x))"
                let v162 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v155, v156) v161 
                let _run_target_args'_v158 = v162 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v163 : string = "$0.map_err(|x| $1(x))"
                let v164 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v155, v156) v163 
                let _run_target_args'_v158 = v164 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v165 : Result<std_path_PathBuf, string> = match v155 with Ok x -> Ok x | Error x -> Error (v156 x)
                let _run_target_args'_v158 = v165 
                #endif
#if FABLE_COMPILER_PYTHON
                let v166 : Result<std_path_PathBuf, string> = match v155 with Ok x -> Ok x | Error x -> Error (v156 x)
                let _run_target_args'_v158 = v166 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v167 : Result<std_path_PathBuf, string> = match v155 with Ok x -> Ok x | Error x -> Error (v156 x)
                let _run_target_args'_v158 = v167 
                #endif
#else
                let v168 : Result<std_path_PathBuf, string> = match v155 with Ok x -> Ok x | Error x -> Error (v156 x)
                let _run_target_args'_v158 = v168 
                #endif
                let v169 : Result<std_path_PathBuf, string> = _run_target_args'_v158 
                let v172 : (std_path_PathBuf -> US14) = method99()
                let v173 : (string -> US14) = method100()
                let v175 : US14 = match v169 with Ok x -> v172 x | Error x -> v173 x
                match v175 with
                | US14_1(v331) -> (* Error *)
                    let v332 : string = $"file_system.read_link / "
                    let v333 : string = $"error': {v331} / error: {v93} / name: {v5}"
                    let v334 : string = v332 + v333 
                    (* run_target_args'
                    let v339 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v340 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v341 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v334 v340 
                    let _run_target_args'_v339 = v341 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v342 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v343 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v334 v342 
                    let _run_target_args'_v339 = v343 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v344 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v345 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v334 v344 
                    let _run_target_args'_v339 = v345 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v347 : std_io_Error = v334 |> unbox<std_io_Error>
                    let _run_target_args'_v339 = v347 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v351 : std_io_Error = v334 |> unbox<std_io_Error>
                    let _run_target_args'_v339 = v351 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v355 : std_io_Error = v334 |> unbox<std_io_Error>
                    let _run_target_args'_v339 = v355 
                    #endif
#else
                    let v359 : std_io_Error = v334 |> unbox<std_io_Error>
                    let _run_target_args'_v339 = v359 
                    #endif
                    let v362 : std_io_Error = _run_target_args'_v339 
                    (* run_target_args'
                    let v369 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v370 : string = "Err($0)"
                    let v371 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v362 v370 
                    let _run_target_args'_v369 = v371 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v372 : string = "Err($0)"
                    let v373 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v362 v372 
                    let _run_target_args'_v369 = v373 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v374 : string = "Err($0)"
                    let v375 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v362 v374 
                    let _run_target_args'_v369 = v375 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v376 : Result<std_path_PathBuf, std_io_Error> = v362 |> Error
                    let _run_target_args'_v369 = v376 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v377 : Result<std_path_PathBuf, std_io_Error> = v362 |> Error
                    let _run_target_args'_v369 = v377 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v378 : Result<std_path_PathBuf, std_io_Error> = v362 |> Error
                    let _run_target_args'_v369 = v378 
                    #endif
#else
                    let v379 : Result<std_path_PathBuf, std_io_Error> = v362 |> Error
                    let _run_target_args'_v369 = v379 
                    #endif
                    let v380 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v369 
                    v380
                | US14_0(v178) -> (* Ok *)
                    (* run_target_args'
                    let v183 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v184 : string = "$0.display()"
                    let v185 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v178 v184 
                    let _run_target_args'_v183 = v185 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v186 : string = "$0.display()"
                    let v187 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v178 v186 
                    let _run_target_args'_v183 = v187 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v188 : string = "$0.display()"
                    let v189 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v178 v188 
                    let _run_target_args'_v183 = v189 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v191 : std_path_Display = v178 |> unbox<std_path_Display>
                    let _run_target_args'_v183 = v191 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v195 : std_path_Display = v178 |> unbox<std_path_Display>
                    let _run_target_args'_v183 = v195 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v199 : std_path_Display = v178 |> unbox<std_path_Display>
                    let _run_target_args'_v183 = v199 
                    #endif
#else
                    let v203 : std_path_Display = v178 |> unbox<std_path_Display>
                    let _run_target_args'_v183 = v203 
                    #endif
                    let v206 : std_path_Display = _run_target_args'_v183 
                    let v213 : string = v206 |> string 
                    let v216 : string = method79(v213, v5)
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
                    (* run_target_args'
                    let v254 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v255 : string = "String::from($0)"
                    let v256 : std_string_String = Fable.Core.RustInterop.emitRustExpr v244 v255 
                    let _run_target_args'_v254 = v256 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v257 : string = "String::from($0)"
                    let v258 : std_string_String = Fable.Core.RustInterop.emitRustExpr v244 v257 
                    let _run_target_args'_v254 = v258 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v259 : string = "String::from($0)"
                    let v260 : std_string_String = Fable.Core.RustInterop.emitRustExpr v244 v259 
                    let _run_target_args'_v254 = v260 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v262 : std_string_String = v244 |> unbox<std_string_String>
                    let _run_target_args'_v254 = v262 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v266 : std_string_String = v244 |> unbox<std_string_String>
                    let _run_target_args'_v254 = v266 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v270 : std_string_String = v244 |> unbox<std_string_String>
                    let _run_target_args'_v254 = v270 
                    #endif
#else
                    let v274 : std_string_String = v244 |> unbox<std_string_String>
                    let _run_target_args'_v254 = v274 
                    #endif
                    let v277 : std_string_String = _run_target_args'_v254 
                    (* run_target_args'
                    let v287 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v288 : string = "std::path::PathBuf::from($0)"
                    let v289 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v277 v288 
                    let _run_target_args'_v287 = v289 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v290 : string = "std::path::PathBuf::from($0)"
                    let v291 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v277 v290 
                    let _run_target_args'_v287 = v291 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v292 : string = "std::path::PathBuf::from($0)"
                    let v293 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v277 v292 
                    let _run_target_args'_v287 = v293 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v295 : std_path_PathBuf = v277 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v287 = v295 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v299 : std_path_PathBuf = v277 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v287 = v299 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v303 : std_path_PathBuf = v277 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v287 = v303 
                    #endif
#else
                    let v307 : std_path_PathBuf = v277 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v287 = v307 
                    #endif
                    let v310 : std_path_PathBuf = _run_target_args'_v287 
                    (* run_target_args'
                    let v317 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v318 : string = "Ok($0)"
                    let v319 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v310 v318 
                    let _run_target_args'_v317 = v319 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v320 : string = "Ok($0)"
                    let v321 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v310 v320 
                    let _run_target_args'_v317 = v321 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v322 : string = "Ok($0)"
                    let v323 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v310 v322 
                    let _run_target_args'_v317 = v323 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v324 : Result<std_path_PathBuf, std_io_Error> = v310 |> Ok
                    let _run_target_args'_v317 = v324 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v325 : Result<std_path_PathBuf, std_io_Error> = v310 |> Ok
                    let _run_target_args'_v317 = v325 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v326 : Result<std_path_PathBuf, std_io_Error> = v310 |> Ok
                    let _run_target_args'_v317 = v326 
                    #endif
#else
                    let v327 : Result<std_path_PathBuf, std_io_Error> = v310 |> Ok
                    let _run_target_args'_v317 = v327 
                    #endif
                    let v328 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v317 
                    v328
            else
                let v385 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v386 : string = $"path: {v0} / error: {v93} / path': {v4} / name: {v5}"
                let v387 : string = v385 + v386 
                (* run_target_args'
                let v392 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v393 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v394 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v387 v393 
                let _run_target_args'_v392 = v394 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v395 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v396 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v387 v395 
                let _run_target_args'_v392 = v396 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v397 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v398 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v387 v397 
                let _run_target_args'_v392 = v398 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v400 : std_io_Error = v387 |> unbox<std_io_Error>
                let _run_target_args'_v392 = v400 
                #endif
#if FABLE_COMPILER_PYTHON
                let v404 : std_io_Error = v387 |> unbox<std_io_Error>
                let _run_target_args'_v392 = v404 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v408 : std_io_Error = v387 |> unbox<std_io_Error>
                let _run_target_args'_v392 = v408 
                #endif
#else
                let v412 : std_io_Error = v387 |> unbox<std_io_Error>
                let _run_target_args'_v392 = v412 
                #endif
                let v415 : std_io_Error = _run_target_args'_v392 
                (* run_target_args'
                let v422 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v423 : string = "Err($0)"
                let v424 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v415 v423 
                let _run_target_args'_v422 = v424 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v425 : string = "Err($0)"
                let v426 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v415 v425 
                let _run_target_args'_v422 = v426 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v427 : string = "Err($0)"
                let v428 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v415 v427 
                let _run_target_args'_v422 = v428 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v429 : Result<std_path_PathBuf, std_io_Error> = v415 |> Error
                let _run_target_args'_v422 = v429 
                #endif
#if FABLE_COMPILER_PYTHON
                let v430 : Result<std_path_PathBuf, std_io_Error> = v415 |> Error
                let _run_target_args'_v422 = v430 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v431 : Result<std_path_PathBuf, std_io_Error> = v415 |> Error
                let _run_target_args'_v422 = v431 
                #endif
#else
                let v432 : Result<std_path_PathBuf, std_io_Error> = v415 |> Error
                let _run_target_args'_v422 = v432 
                #endif
                let v433 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v422 
                v433
        | _ ->
            let v437 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v438 : string = $"path: {v0} / error: {v93} / path': {v4} / name: {v5}"
            let v439 : string = v437 + v438 
            (* run_target_args'
            let v444 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v445 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v446 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v439 v445 
            let _run_target_args'_v444 = v446 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v447 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v448 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v439 v447 
            let _run_target_args'_v444 = v448 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v449 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v450 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v439 v449 
            let _run_target_args'_v444 = v450 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v452 : std_io_Error = v439 |> unbox<std_io_Error>
            let _run_target_args'_v444 = v452 
            #endif
#if FABLE_COMPILER_PYTHON
            let v456 : std_io_Error = v439 |> unbox<std_io_Error>
            let _run_target_args'_v444 = v456 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v460 : std_io_Error = v439 |> unbox<std_io_Error>
            let _run_target_args'_v444 = v460 
            #endif
#else
            let v464 : std_io_Error = v439 |> unbox<std_io_Error>
            let _run_target_args'_v444 = v464 
            #endif
            let v467 : std_io_Error = _run_target_args'_v444 
            (* run_target_args'
            let v474 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v475 : string = "Err($0)"
            let v476 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v467 v475 
            let _run_target_args'_v474 = v476 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v477 : string = "Err($0)"
            let v478 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v467 v477 
            let _run_target_args'_v474 = v478 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v479 : string = "Err($0)"
            let v480 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v467 v479 
            let _run_target_args'_v474 = v480 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v481 : Result<std_path_PathBuf, std_io_Error> = v467 |> Error
            let _run_target_args'_v474 = v481 
            #endif
#if FABLE_COMPILER_PYTHON
            let v482 : Result<std_path_PathBuf, std_io_Error> = v467 |> Error
            let _run_target_args'_v474 = v482 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v483 : Result<std_path_PathBuf, std_io_Error> = v467 |> Error
            let _run_target_args'_v474 = v483 
            #endif
#else
            let v484 : Result<std_path_PathBuf, std_io_Error> = v467 |> Error
            let _run_target_args'_v474 = v484 
            #endif
            let v485 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v474 
            v485
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
    let v42 : System.IO.FileAttributes = method106(v36)
    let v43 : System.IO.FileAttributes = method107()
    let v44 : bool = method108(v43, v42)
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
        method110(v0, v178, v1, v172, v2)
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
    let v76 : string = $"{v69}"
    let v84 : unit = ()
    let v85 : (unit -> unit) = closure6(v35, v76)
    let v86 : unit = (fun () -> v85 (); v84) ()
    let v92 : string = v35.l0
    let v93 : bool = v2 >= 11uy
    if v93 then
        let v94 : string = $"file_system.read_link / "
        let v95 : string = $"path: {v0} / n: {v2} / path': {v0} / name: {v4}"
        let v96 : string = v94 + v95 
        (* run_target_args'
        let v101 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v102 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v103 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v96 v102 
        let _run_target_args'_v101 = v103 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v104 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v105 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v96 v104 
        let _run_target_args'_v101 = v105 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v106 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
        let v107 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v96 v106 
        let _run_target_args'_v101 = v107 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v109 : std_io_Error = v96 |> unbox<std_io_Error>
        let _run_target_args'_v101 = v109 
        #endif
#if FABLE_COMPILER_PYTHON
        let v113 : std_io_Error = v96 |> unbox<std_io_Error>
        let _run_target_args'_v101 = v113 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v117 : std_io_Error = v96 |> unbox<std_io_Error>
        let _run_target_args'_v101 = v117 
        #endif
#else
        let v121 : std_io_Error = v96 |> unbox<std_io_Error>
        let _run_target_args'_v101 = v121 
        #endif
        let v124 : std_io_Error = _run_target_args'_v101 
        (* run_target_args'
        let v131 : unit = ()
        run_target_args' *)
        
#if FABLE_COMPILER || WASM || CONTRACT
        
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
        let v132 : string = "Err($0)"
        let v133 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v124 v132 
        let _run_target_args'_v131 = v133 
        #endif
#if FABLE_COMPILER_RUST && WASM
        let v134 : string = "Err($0)"
        let v135 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v124 v134 
        let _run_target_args'_v131 = v135 
        #endif
#if FABLE_COMPILER_RUST && CONTRACT
        let v136 : string = "Err($0)"
        let v137 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v124 v136 
        let _run_target_args'_v131 = v137 
        #endif
#if FABLE_COMPILER_TYPESCRIPT
        let v138 : Result<std_path_PathBuf, std_io_Error> = v124 |> Error
        let _run_target_args'_v131 = v138 
        #endif
#if FABLE_COMPILER_PYTHON
        let v139 : Result<std_path_PathBuf, std_io_Error> = v124 |> Error
        let _run_target_args'_v131 = v139 
        #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
        let v140 : Result<std_path_PathBuf, std_io_Error> = v124 |> Error
        let _run_target_args'_v131 = v140 
        #endif
#else
        let v141 : Result<std_path_PathBuf, std_io_Error> = v124 |> Error
        let _run_target_args'_v131 = v141 
        #endif
        let v142 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v131 
        v142
    else
        match v30 with
        | US5_0(v145) -> (* Some *)
            let v148 : string = ""
            let v149 : bool = v0 <> v148 
            if v149 then
                let v152 : uint8 = v2 + 1uy
                let v153 : (string -> Result<std_path_PathBuf, std_io_Error>) = v1 v152
                let v154 : Result<std_path_PathBuf, std_io_Error> = v153 v145
                let v155 : (std_io_Error -> string) = method44()
                (* run_target_args'
                let v157 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v158 : string = "$0.map_err(|x| $1(x))"
                let v159 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v154, v155) v158 
                let _run_target_args'_v157 = v159 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v160 : string = "$0.map_err(|x| $1(x))"
                let v161 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v154, v155) v160 
                let _run_target_args'_v157 = v161 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v162 : string = "$0.map_err(|x| $1(x))"
                let v163 : Result<std_path_PathBuf, string> = Fable.Core.RustInterop.emitRustExpr struct (v154, v155) v162 
                let _run_target_args'_v157 = v163 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v164 : Result<std_path_PathBuf, string> = match v154 with Ok x -> Ok x | Error x -> Error (v155 x)
                let _run_target_args'_v157 = v164 
                #endif
#if FABLE_COMPILER_PYTHON
                let v165 : Result<std_path_PathBuf, string> = match v154 with Ok x -> Ok x | Error x -> Error (v155 x)
                let _run_target_args'_v157 = v165 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v166 : Result<std_path_PathBuf, string> = match v154 with Ok x -> Ok x | Error x -> Error (v155 x)
                let _run_target_args'_v157 = v166 
                #endif
#else
                let v167 : Result<std_path_PathBuf, string> = match v154 with Ok x -> Ok x | Error x -> Error (v155 x)
                let _run_target_args'_v157 = v167 
                #endif
                let v168 : Result<std_path_PathBuf, string> = _run_target_args'_v157 
                let v171 : (std_path_PathBuf -> US14) = method99()
                let v172 : (string -> US14) = method100()
                let v174 : US14 = match v168 with Ok x -> v171 x | Error x -> v172 x
                match v174 with
                | US14_1(v330) -> (* Error *)
                    let v331 : string = $"file_system.read_link / "
                    let v332 : string = $"error': {v330} / error: {v92} / name: {v4}"
                    let v333 : string = v331 + v332 
                    (* run_target_args'
                    let v338 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v339 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v340 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v333 v339 
                    let _run_target_args'_v338 = v340 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v341 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v342 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v333 v341 
                    let _run_target_args'_v338 = v342 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v343 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                    let v344 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v333 v343 
                    let _run_target_args'_v338 = v344 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v346 : std_io_Error = v333 |> unbox<std_io_Error>
                    let _run_target_args'_v338 = v346 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v350 : std_io_Error = v333 |> unbox<std_io_Error>
                    let _run_target_args'_v338 = v350 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v354 : std_io_Error = v333 |> unbox<std_io_Error>
                    let _run_target_args'_v338 = v354 
                    #endif
#else
                    let v358 : std_io_Error = v333 |> unbox<std_io_Error>
                    let _run_target_args'_v338 = v358 
                    #endif
                    let v361 : std_io_Error = _run_target_args'_v338 
                    (* run_target_args'
                    let v368 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v369 : string = "Err($0)"
                    let v370 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v361 v369 
                    let _run_target_args'_v368 = v370 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v371 : string = "Err($0)"
                    let v372 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v361 v371 
                    let _run_target_args'_v368 = v372 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v373 : string = "Err($0)"
                    let v374 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v361 v373 
                    let _run_target_args'_v368 = v374 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v375 : Result<std_path_PathBuf, std_io_Error> = v361 |> Error
                    let _run_target_args'_v368 = v375 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v376 : Result<std_path_PathBuf, std_io_Error> = v361 |> Error
                    let _run_target_args'_v368 = v376 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v377 : Result<std_path_PathBuf, std_io_Error> = v361 |> Error
                    let _run_target_args'_v368 = v377 
                    #endif
#else
                    let v378 : Result<std_path_PathBuf, std_io_Error> = v361 |> Error
                    let _run_target_args'_v368 = v378 
                    #endif
                    let v379 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v368 
                    v379
                | US14_0(v177) -> (* Ok *)
                    (* run_target_args'
                    let v182 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v183 : string = "$0.display()"
                    let v184 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v177 v183 
                    let _run_target_args'_v182 = v184 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v185 : string = "$0.display()"
                    let v186 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v177 v185 
                    let _run_target_args'_v182 = v186 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v187 : string = "$0.display()"
                    let v188 : std_path_Display = Fable.Core.RustInterop.emitRustExpr v177 v187 
                    let _run_target_args'_v182 = v188 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v190 : std_path_Display = v177 |> unbox<std_path_Display>
                    let _run_target_args'_v182 = v190 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v194 : std_path_Display = v177 |> unbox<std_path_Display>
                    let _run_target_args'_v182 = v194 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v198 : std_path_Display = v177 |> unbox<std_path_Display>
                    let _run_target_args'_v182 = v198 
                    #endif
#else
                    let v202 : std_path_Display = v177 |> unbox<std_path_Display>
                    let _run_target_args'_v182 = v202 
                    #endif
                    let v205 : std_path_Display = _run_target_args'_v182 
                    let v212 : string = v205 |> string 
                    let v215 : string = method79(v212, v4)
                    (* run_target_args'
                    let v220 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v221 : string = "&*$0"
                    let v222 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v215 v221 
                    let _run_target_args'_v220 = v222 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v223 : string = "&*$0"
                    let v224 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v215 v223 
                    let _run_target_args'_v220 = v224 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v225 : string = "&*$0"
                    let v226 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v215 v225 
                    let _run_target_args'_v220 = v226 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v228 : Ref<Str> = v215 |> unbox<Ref<Str>>
                    let _run_target_args'_v220 = v228 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v232 : Ref<Str> = v215 |> unbox<Ref<Str>>
                    let _run_target_args'_v220 = v232 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v236 : Ref<Str> = v215 |> unbox<Ref<Str>>
                    let _run_target_args'_v220 = v236 
                    #endif
#else
                    let v240 : Ref<Str> = v215 |> unbox<Ref<Str>>
                    let _run_target_args'_v220 = v240 
                    #endif
                    let v243 : Ref<Str> = _run_target_args'_v220 
                    (* run_target_args'
                    let v253 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v254 : string = "String::from($0)"
                    let v255 : std_string_String = Fable.Core.RustInterop.emitRustExpr v243 v254 
                    let _run_target_args'_v253 = v255 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v256 : string = "String::from($0)"
                    let v257 : std_string_String = Fable.Core.RustInterop.emitRustExpr v243 v256 
                    let _run_target_args'_v253 = v257 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v258 : string = "String::from($0)"
                    let v259 : std_string_String = Fable.Core.RustInterop.emitRustExpr v243 v258 
                    let _run_target_args'_v253 = v259 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v261 : std_string_String = v243 |> unbox<std_string_String>
                    let _run_target_args'_v253 = v261 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v265 : std_string_String = v243 |> unbox<std_string_String>
                    let _run_target_args'_v253 = v265 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v269 : std_string_String = v243 |> unbox<std_string_String>
                    let _run_target_args'_v253 = v269 
                    #endif
#else
                    let v273 : std_string_String = v243 |> unbox<std_string_String>
                    let _run_target_args'_v253 = v273 
                    #endif
                    let v276 : std_string_String = _run_target_args'_v253 
                    (* run_target_args'
                    let v286 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v287 : string = "std::path::PathBuf::from($0)"
                    let v288 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v276 v287 
                    let _run_target_args'_v286 = v288 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v289 : string = "std::path::PathBuf::from($0)"
                    let v290 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v276 v289 
                    let _run_target_args'_v286 = v290 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v291 : string = "std::path::PathBuf::from($0)"
                    let v292 : std_path_PathBuf = Fable.Core.RustInterop.emitRustExpr v276 v291 
                    let _run_target_args'_v286 = v292 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v294 : std_path_PathBuf = v276 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v286 = v294 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v298 : std_path_PathBuf = v276 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v286 = v298 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v302 : std_path_PathBuf = v276 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v286 = v302 
                    #endif
#else
                    let v306 : std_path_PathBuf = v276 |> unbox<std_path_PathBuf>
                    let _run_target_args'_v286 = v306 
                    #endif
                    let v309 : std_path_PathBuf = _run_target_args'_v286 
                    (* run_target_args'
                    let v316 : unit = ()
                    run_target_args' *)
                    
#if FABLE_COMPILER || WASM || CONTRACT
                    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                    let v317 : string = "Ok($0)"
                    let v318 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v309 v317 
                    let _run_target_args'_v316 = v318 
                    #endif
#if FABLE_COMPILER_RUST && WASM
                    let v319 : string = "Ok($0)"
                    let v320 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v309 v319 
                    let _run_target_args'_v316 = v320 
                    #endif
#if FABLE_COMPILER_RUST && CONTRACT
                    let v321 : string = "Ok($0)"
                    let v322 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v309 v321 
                    let _run_target_args'_v316 = v322 
                    #endif
#if FABLE_COMPILER_TYPESCRIPT
                    let v323 : Result<std_path_PathBuf, std_io_Error> = v309 |> Ok
                    let _run_target_args'_v316 = v323 
                    #endif
#if FABLE_COMPILER_PYTHON
                    let v324 : Result<std_path_PathBuf, std_io_Error> = v309 |> Ok
                    let _run_target_args'_v316 = v324 
                    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                    let v325 : Result<std_path_PathBuf, std_io_Error> = v309 |> Ok
                    let _run_target_args'_v316 = v325 
                    #endif
#else
                    let v326 : Result<std_path_PathBuf, std_io_Error> = v309 |> Ok
                    let _run_target_args'_v316 = v326 
                    #endif
                    let v327 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v316 
                    v327
            else
                let v384 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
                let v385 : string = $"path: {v0} / error: {v92} / path': {v0} / name: {v4}"
                let v386 : string = v384 + v385 
                (* run_target_args'
                let v391 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v392 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v393 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v386 v392 
                let _run_target_args'_v391 = v393 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v394 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v395 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v386 v394 
                let _run_target_args'_v391 = v395 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v396 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
                let v397 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v386 v396 
                let _run_target_args'_v391 = v397 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v399 : std_io_Error = v386 |> unbox<std_io_Error>
                let _run_target_args'_v391 = v399 
                #endif
#if FABLE_COMPILER_PYTHON
                let v403 : std_io_Error = v386 |> unbox<std_io_Error>
                let _run_target_args'_v391 = v403 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v407 : std_io_Error = v386 |> unbox<std_io_Error>
                let _run_target_args'_v391 = v407 
                #endif
#else
                let v411 : std_io_Error = v386 |> unbox<std_io_Error>
                let _run_target_args'_v391 = v411 
                #endif
                let v414 : std_io_Error = _run_target_args'_v391 
                (* run_target_args'
                let v421 : unit = ()
                run_target_args' *)
                
#if FABLE_COMPILER || WASM || CONTRACT
                
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
                let v422 : string = "Err($0)"
                let v423 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v414 v422 
                let _run_target_args'_v421 = v423 
                #endif
#if FABLE_COMPILER_RUST && WASM
                let v424 : string = "Err($0)"
                let v425 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v414 v424 
                let _run_target_args'_v421 = v425 
                #endif
#if FABLE_COMPILER_RUST && CONTRACT
                let v426 : string = "Err($0)"
                let v427 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v414 v426 
                let _run_target_args'_v421 = v427 
                #endif
#if FABLE_COMPILER_TYPESCRIPT
                let v428 : Result<std_path_PathBuf, std_io_Error> = v414 |> Error
                let _run_target_args'_v421 = v428 
                #endif
#if FABLE_COMPILER_PYTHON
                let v429 : Result<std_path_PathBuf, std_io_Error> = v414 |> Error
                let _run_target_args'_v421 = v429 
                #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
                let v430 : Result<std_path_PathBuf, std_io_Error> = v414 |> Error
                let _run_target_args'_v421 = v430 
                #endif
#else
                let v431 : Result<std_path_PathBuf, std_io_Error> = v414 |> Error
                let _run_target_args'_v421 = v431 
                #endif
                let v432 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v421 
                v432
        | _ ->
            let v436 : string = $"file_system.read_link / run / The file or directory is not a reparse point. / "
            let v437 : string = $"path: {v0} / error: {v92} / path': {v0} / name: {v4}"
            let v438 : string = v436 + v437 
            (* run_target_args'
            let v443 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v444 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v445 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v438 v444 
            let _run_target_args'_v443 = v445 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v446 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v447 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v438 v446 
            let _run_target_args'_v443 = v447 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v448 : string = "std::io::Error::new(std::io::ErrorKind::Other, &*$0)"
            let v449 : std_io_Error = Fable.Core.RustInterop.emitRustExpr v438 v448 
            let _run_target_args'_v443 = v449 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v451 : std_io_Error = v438 |> unbox<std_io_Error>
            let _run_target_args'_v443 = v451 
            #endif
#if FABLE_COMPILER_PYTHON
            let v455 : std_io_Error = v438 |> unbox<std_io_Error>
            let _run_target_args'_v443 = v455 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v459 : std_io_Error = v438 |> unbox<std_io_Error>
            let _run_target_args'_v443 = v459 
            #endif
#else
            let v463 : std_io_Error = v438 |> unbox<std_io_Error>
            let _run_target_args'_v443 = v463 
            #endif
            let v466 : std_io_Error = _run_target_args'_v443 
            (* run_target_args'
            let v473 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v474 : string = "Err($0)"
            let v475 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v466 v474 
            let _run_target_args'_v473 = v475 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v476 : string = "Err($0)"
            let v477 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v466 v476 
            let _run_target_args'_v473 = v477 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v478 : string = "Err($0)"
            let v479 : Result<std_path_PathBuf, std_io_Error> = Fable.Core.RustInterop.emitRustExpr v466 v478 
            let _run_target_args'_v473 = v479 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v480 : Result<std_path_PathBuf, std_io_Error> = v466 |> Error
            let _run_target_args'_v473 = v480 
            #endif
#if FABLE_COMPILER_PYTHON
            let v481 : Result<std_path_PathBuf, std_io_Error> = v466 |> Error
            let _run_target_args'_v473 = v481 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v482 : Result<std_path_PathBuf, std_io_Error> = v466 |> Error
            let _run_target_args'_v473 = v482 
            #endif
#else
            let v483 : Result<std_path_PathBuf, std_io_Error> = v466 |> Error
            let _run_target_args'_v473 = v483 
            #endif
            let v484 : Result<std_path_PathBuf, std_io_Error> = _run_target_args'_v473 
            v484
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
    let v41 : System.IO.FileAttributes = method106(v35)
    let v42 : System.IO.FileAttributes = method107()
    let v43 : bool = method108(v42, v41)
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
        method111(v0, v177, v1, v171)
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
        let v91 : string = method113(v89, v90, v88)
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
            let v108 : string = method117()
            let v109 : string = method79(v108, v0)
            let v110 : string = method96(v109)
            let v118 : string = "/"
            let v119 : (string []) = v110.Split v118 
            let v122 : (string []) = [||]
            let v123 : int32 = v119.Length
            let v124 : Mut5 = {l0 = 0; l1 = 0; l2 = v122} : Mut5
            while method118(v123, v124) do
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
                                    while method119(v147, v149) do
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
                                    while method119(v161, v163) do
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
            let v197 : char = method120()
            let v199 : (char -> string) = _.ToString()
            let v200 : string = v199 v197
            let v204 : bool = v200 = "\n"
            let v206 : string =
                if v204 then
                    method121(v200)
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
    let v44 : string = $"file:///{v12}"
    v44
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
    let v26 : bool =
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
