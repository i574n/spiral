let rec method0 (v0 : System.Threading.CancellationToken) : Async<System.Threading.CancellationToken> =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : Async<System.Threading.CancellationToken> = null |> unbox<Async<System.Threading.CancellationToken>>
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : Async<System.Threading.CancellationToken> = null |> unbox<Async<System.Threading.CancellationToken>>
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : Async<System.Threading.CancellationToken> = null |> unbox<Async<System.Threading.CancellationToken>>
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : unit = ()
    let _let'_v19 =
        async {
            (* run_target_args'
            let v546 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v548 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v548 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v552 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v552 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v556 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v556 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v560 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v560 
            #endif
#if FABLE_COMPILER_PYTHON
            let v564 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v564 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v568 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v568 
            #endif
#else
            let v571 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v571 = v571 
            let v572 : System.Threading.CancellationToken = v571 
            let v573 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v574 : (System.Threading.CancellationToken []) = [|v572; v573; v0|]
            let v575 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v576 : System.Threading.CancellationTokenSource = v575 v574
            let v577 : System.Threading.CancellationToken = v576.Token
            return v577 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v1102 : Async<System.Threading.CancellationToken> = _let'_v19 
    let _run_target_args'_v5 = v1102 
    #endif
#if FABLE_COMPILER_PYTHON
    let v1104 : unit = ()
    let _let'_v1104 =
        async {
            (* run_target_args'
            let v1631 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1633 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1633 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1637 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1637 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1641 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1641 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1645 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1645 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1649 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1649 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1653 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v1653 
            #endif
#else
            let v1656 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v1656 = v1656 
            let v1657 : System.Threading.CancellationToken = v1656 
            let v1658 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v1659 : (System.Threading.CancellationToken []) = [|v1657; v1658; v0|]
            let v1660 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v1661 : System.Threading.CancellationTokenSource = v1660 v1659
            let v1662 : System.Threading.CancellationToken = v1661.Token
            return v1662 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v2187 : Async<System.Threading.CancellationToken> = _let'_v1104 
    let _run_target_args'_v5 = v2187 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v2189 : unit = ()
    let _let'_v2189 =
        async {
            (* run_target_args'
            let v2716 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v2718 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2718 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v2722 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2722 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v2726 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2726 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v2730 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2730 
            #endif
#if FABLE_COMPILER_PYTHON
            let v2734 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2734 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v2738 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v2738 
            #endif
#else
            let v2741 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v2741 = v2741 
            let v2742 : System.Threading.CancellationToken = v2741 
            let v2743 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v2744 : (System.Threading.CancellationToken []) = [|v2742; v2743; v0|]
            let v2745 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v2746 : System.Threading.CancellationTokenSource = v2745 v2744
            let v2747 : System.Threading.CancellationToken = v2746.Token
            return v2747 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v3272 : Async<System.Threading.CancellationToken> = _let'_v2189 
    let _run_target_args'_v5 = v3272 
    #endif
#else
    let v3274 : unit = ()
    let _let'_v3274 =
        async {
            (* run_target_args'
            let v3801 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v3803 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3803 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v3807 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3807 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v3811 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3811 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v3815 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3815 
            #endif
#if FABLE_COMPILER_PYTHON
            let v3819 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3819 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v3823 : System.Threading.CancellationToken = null |> unbox<System.Threading.CancellationToken>
            return v3823 
            #endif
#else
            let v3826 : Async<System.Threading.CancellationToken> = Async.CancellationToken
            let! v3826 = v3826 
            let v3827 : System.Threading.CancellationToken = v3826 
            let v3828 : System.Threading.CancellationToken = Async.DefaultCancellationToken
            let v3829 : (System.Threading.CancellationToken []) = [|v3827; v3828; v0|]
            let v3830 : ((System.Threading.CancellationToken []) -> System.Threading.CancellationTokenSource) = System.Threading.CancellationTokenSource.CreateLinkedTokenSource
            let v3831 : System.Threading.CancellationTokenSource = v3830 v3829
            let v3832 : System.Threading.CancellationToken = v3831.Token
            return v3832 
            #endif
            // run_target_args' is_unit
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v4357 : Async<System.Threading.CancellationToken> = _let'_v3274 
    let _run_target_args'_v5 = v4357 
    #endif
    let v4358 : Async<System.Threading.CancellationToken> = _run_target_args'_v5 
    v4358
and closure0 () (v0 : System.Threading.CancellationToken) : Async<System.Threading.CancellationToken> =
    method0(v0)
let v0 : (System.Threading.CancellationToken -> Async<System.Threading.CancellationToken>) = closure0()
let merge_cancellation_token_with_default_async x = v0 x
()
