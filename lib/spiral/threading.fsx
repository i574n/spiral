type Disposable (f : unit -> unit) = interface System.IDisposable with member _.Dispose () = f ()
type [<Struct>] US0 =
    | US0_0 of f0_0 : System.Threading.CancellationToken
    | US0_1
let rec closure1 () (v0 : System.Threading.CancellationToken) : US0 =
    US0_0(v0)
and method0 () : (System.Threading.CancellationToken -> US0) =
    closure1()
and closure2 (v0 : System.Threading.CancellationTokenSource) () : unit =
    (* run_target_args'
    let v1 : unit = ()
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
    null |> unbox<unit>
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    null |> unbox<unit>
    #endif
#else
    let v2 : (unit -> unit) = v0.Cancel
    v2 ()
    #endif
    // run_target_args' is_unit
    ()
and method1 (v0 : System.Threading.CancellationTokenSource) : (unit -> unit) =
    closure2(v0)
and method2 (v0 : System.Threading.CancellationTokenSource) : (unit -> unit) =
    closure2(v0)
and closure0 () (v0 : System.Threading.CancellationToken option) : struct (System.Threading.CancellationToken * System.IDisposable) =
    (* run_target_args'
    let v9 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v12 : System.Threading.CancellationToken, v13 : System.IDisposable) = null |> unbox<struct (System.Threading.CancellationToken * System.IDisposable)>
    let _run_target_args'_v9 = struct (v12, v13) 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let struct (v20 : System.Threading.CancellationToken, v21 : System.IDisposable) = null |> unbox<struct (System.Threading.CancellationToken * System.IDisposable)>
    let _run_target_args'_v9 = struct (v20, v21) 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let struct (v28 : System.Threading.CancellationToken, v29 : System.IDisposable) = null |> unbox<struct (System.Threading.CancellationToken * System.IDisposable)>
    let _run_target_args'_v9 = struct (v28, v29) 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let struct (v36 : System.Threading.CancellationToken, v37 : System.IDisposable) = null |> unbox<struct (System.Threading.CancellationToken * System.IDisposable)>
    let _run_target_args'_v9 = struct (v36, v37) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v44 : System.Threading.CancellationToken, v45 : System.IDisposable) = null |> unbox<struct (System.Threading.CancellationToken * System.IDisposable)>
    let _run_target_args'_v9 = struct (v44, v45) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v52 : System.Threading.CancellationToken, v53 : System.IDisposable) = null |> unbox<struct (System.Threading.CancellationToken * System.IDisposable)>
    let _run_target_args'_v9 = struct (v52, v53) 
    #endif
#else
    let v58 : System.Threading.CancellationTokenSource = new System.Threading.CancellationTokenSource ()
    let v60 : (System.Threading.CancellationToken -> US0) = method0()
    let v61 : US0 option = v0 |> Option.map v60 
    let v74 : US0 = US0_1
    let v75 : US0 = v61 |> Option.defaultValue v74 
    let v85 : System.Threading.CancellationTokenSource =
        match v75 with
        | US0_1 -> (* None *)
            v58
        | US0_0(v79) -> (* Some *)
            let v80 : System.Threading.CancellationToken = v58.Token
            let v81 : (System.Threading.CancellationToken []) = [|v80; v79|]
            let v82 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            v82 v81
    (* run_target_args'
    let v90 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v91 : (unit -> unit) = method1(v85)
    let v92 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v91 "$0()" )
    let _run_target_args'_v90 = v92 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v93 : (unit -> unit) = method1(v85)
    let v94 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v93 "$0()" )
    let _run_target_args'_v90 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : (unit -> unit) = method1(v85)
    let v96 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v95 "$0()" )
    let _run_target_args'_v90 = v96 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v97 : (unit -> unit) = method2(v85)
    let v98 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v97 () }
    let _run_target_args'_v90 = v98 
    #endif
#if FABLE_COMPILER_PYTHON
    let v99 : (unit -> unit) = method2(v85)
    let v100 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v99 () }
    let _run_target_args'_v90 = v100 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v101 : (unit -> unit) = method2(v85)
    let v102 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v101 () }
    let _run_target_args'_v90 = v102 
    #endif
#else
    let v103 : (unit -> unit) = method2(v85)
    let v104 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v103 () }
    let _run_target_args'_v90 = v104 
    #endif
    let v105 : System.IDisposable = _run_target_args'_v90 
    let v109 : System.Threading.CancellationToken = v85.Token
    let _run_target_args'_v9 = struct (v109, v105) 
    #endif
    let struct (v110 : System.Threading.CancellationToken, v111 : System.IDisposable) = _run_target_args'_v9 
    struct (v110, v111)
let v0 : (System.Threading.CancellationToken option -> struct (System.Threading.CancellationToken * System.IDisposable)) = closure0()
let new_disposable_token x = v0 x
()
