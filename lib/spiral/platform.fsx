type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
and [<Struct>] US1 =
    | US1_0 of f0_0 : US0
    | US1_1 of f1_0 : US0
    | US1_2 of f2_0 : US0
    | US1_3 of f3_0 : US0
    | US1_4 of f4_0 : US0
    | US1_5 of f5_0 : US0
let rec closure0 () () : bool =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = "cfg!(windows)"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : string = "cfg!(windows)"
    let v8 : bool = Fable.Core.RustInterop.emitRustExpr () v7 
    let _run_target_args'_v4 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : string = "cfg!(windows)"
    let v10 : bool = Fable.Core.RustInterop.emitRustExpr () v9 
    let _run_target_args'_v4 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : US0 = US0_0
    let v12 : US1 = US1_4(v11)
    let v13 : string = $"platform.is_windows / target: {v12}"
    let v14 : bool = failwith<bool> v13
    let _run_target_args'_v4 = v14 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : US0 = US0_0
    let v16 : US1 = US1_5(v15)
    let v17 : string = $"platform.is_windows / target: {v16}"
    let v18 : bool = failwith<bool> v17
    let _run_target_args'_v4 = v18 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v19 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v20 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v21 : bool = v20 v19
    let _run_target_args'_v4 = v21 
    #endif
#else
    let v22 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v23 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v24 : bool = v23 v22
    let _run_target_args'_v4 = v24 
    #endif
    let v25 : bool = _run_target_args'_v4 
    v25
and closure1 () () : string =
    (* run_target_args'
    let v4 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v5 : string = "cfg!(windows)"
    let v6 : bool = Fable.Core.RustInterop.emitRustExpr () v5 
    let _run_target_args'_v4 = v6 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v7 : string = "cfg!(windows)"
    let v8 : bool = Fable.Core.RustInterop.emitRustExpr () v7 
    let _run_target_args'_v4 = v8 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v9 : string = "cfg!(windows)"
    let v10 : bool = Fable.Core.RustInterop.emitRustExpr () v9 
    let _run_target_args'_v4 = v10 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v11 : US0 = US0_0
    let v12 : US1 = US1_4(v11)
    let v13 : string = $"platform.is_windows / target: {v12}"
    let v14 : bool = failwith<bool> v13
    let _run_target_args'_v4 = v14 
    #endif
#if FABLE_COMPILER_PYTHON
    let v15 : US0 = US0_0
    let v16 : US1 = US1_5(v15)
    let v17 : string = $"platform.is_windows / target: {v16}"
    let v18 : bool = failwith<bool> v17
    let _run_target_args'_v4 = v18 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v19 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v20 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v21 : bool = v20 v19
    let _run_target_args'_v4 = v21 
    #endif
#else
    let v22 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v23 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v24 : bool = v23 v22
    let _run_target_args'_v4 = v24 
    #endif
    let v25 : bool = _run_target_args'_v4 
    if v25 then
        let v31 : string = ".exe"
        v31
    else
        let v32 : string = ""
        v32
let v0 : (unit -> bool) = closure0()
let is_windows () = v0 ()
let v1 : (unit -> string) = closure1()
let get_executable_suffix () = v1 ()
()
