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
    | US1_6 of f6_0 : US0
let rec closure0 () () : bool =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "cfg!(windows)"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let _run_target_args'_v1 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : string = "cfg!(windows)"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6 : string = "cfg!(windows)"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let _run_target_args'_v1 = v7 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v8 : US0 = US0_0
    let v9 : US1 = US1_5(v8)
    let v10 : string = $"platform.is_windows / target: {v9}"
    let v11 : bool = failwith<bool> v10
    let _run_target_args'_v1 = v11 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : US0 = US0_0
    let v13 : US1 = US1_6(v12)
    let v14 : string = $"platform.is_windows / target: {v13}"
    let v15 : bool = failwith<bool> v14
    let _run_target_args'_v1 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v17 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v18 : bool = v17 v16
    let _run_target_args'_v1 = v18 
    #endif
#else
    let v19 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v20 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v21 : bool = v20 v19
    let _run_target_args'_v1 = v21 
    #endif
    let v22 : bool = _run_target_args'_v1 
    v22
and closure1 () () : string =
    (* run_target_args'
    let v1 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v2 : string = "cfg!(windows)"
    let v3 : bool = Fable.Core.RustInterop.emitRustExpr () v2 
    let _run_target_args'_v1 = v3 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v4 : string = "cfg!(windows)"
    let v5 : bool = Fable.Core.RustInterop.emitRustExpr () v4 
    let _run_target_args'_v1 = v5 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v6 : string = "cfg!(windows)"
    let v7 : bool = Fable.Core.RustInterop.emitRustExpr () v6 
    let _run_target_args'_v1 = v7 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v8 : US0 = US0_0
    let v9 : US1 = US1_5(v8)
    let v10 : string = $"platform.is_windows / target: {v9}"
    let v11 : bool = failwith<bool> v10
    let _run_target_args'_v1 = v11 
    #endif
#if FABLE_COMPILER_PYTHON
    let v12 : US0 = US0_0
    let v13 : US1 = US1_6(v12)
    let v14 : string = $"platform.is_windows / target: {v13}"
    let v15 : bool = failwith<bool> v14
    let _run_target_args'_v1 = v15 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v16 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v17 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v18 : bool = v17 v16
    let _run_target_args'_v1 = v18 
    #endif
#else
    let v19 : System.Runtime.InteropServices.OSPlatform = System.Runtime.InteropServices.OSPlatform.Windows
    let v20 : (System.Runtime.InteropServices.OSPlatform -> bool) = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform
    let v21 : bool = v20 v19
    let _run_target_args'_v1 = v21 
    #endif
    let v22 : bool = _run_target_args'_v1 
    if v22 then
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
