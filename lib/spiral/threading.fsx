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
    let v61 : (System.Threading.CancellationToken -> US0) = method0()
    let v62 : US0 option = v0 |> Option.map v61 
    let v82 : US0 = US0_1
    let v83 : US0 = v62 |> Option.defaultValue v82 
    let v93 : System.Threading.CancellationTokenSource =
        match v83 with
        | US0_1 -> (* None *)
            v58
        | US0_0(v87) -> (* Some *)
            let v88 : System.Threading.CancellationToken = v58.Token
            let v89 : (System.Threading.CancellationToken []) = [|v88; v87|]
            let v90 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            v90 v89
    (* run_target_args'
    let v98 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v99 : (unit -> unit) = method1(v93)
    let v100 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v99 "$0()" )
    let _run_target_args'_v98 = v100 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v101 : (unit -> unit) = method1(v93)
    let v102 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v101 "$0()" )
    let _run_target_args'_v98 = v102 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v103 : (unit -> unit) = method1(v93)
    let v104 : System.IDisposable = new Disposable (fun () -> Fable.Core.RustInterop.emitRustExpr v103 "$0()" )
    let _run_target_args'_v98 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v105 : (unit -> unit) = method2(v93)
    let v106 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v105 () }
    let _run_target_args'_v98 = v106 
    #endif
#if FABLE_COMPILER_PYTHON
    let v107 : (unit -> unit) = method2(v93)
    let v108 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v107 () }
    let _run_target_args'_v98 = v108 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v109 : (unit -> unit) = method2(v93)
    let v110 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v109 () }
    let _run_target_args'_v98 = v110 
    #endif
#else
    let v111 : (unit -> unit) = method2(v93)
    let v112 : System.IDisposable = { new System.IDisposable with member _.Dispose () = v111 () }
    let _run_target_args'_v98 = v112 
    #endif
    let v113 : System.IDisposable = _run_target_args'_v98 
    let v120 : System.Threading.CancellationToken = v93.Token
    let _run_target_args'_v9 = struct (v120, v113) 
    #endif
    let struct (v121 : System.Threading.CancellationToken, v122 : System.IDisposable) = _run_target_args'_v9 
    struct (v121, v122)
let v0 : (System.Threading.CancellationToken option -> struct (System.Threading.CancellationToken * System.IDisposable)) = closure0()
let new_disposable_token x = v0 x
()
