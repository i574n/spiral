#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("regex::Regex")>]
#endif
type regex_Regex = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::borrow::Cow<$0>")>]
#endif
type std_borrow_Cow<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("regex::Error")>]
#endif
type regex_Error = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("str")>]
type Str = class end
#else
type Str = string
#endif

type UH0 =
    | UH0_0
    | UH0_1 of char * UH0
and Mut0 = {mutable l0 : int32; mutable l1 : string; mutable l2 : string}
and Mut1 = {mutable l0 : int32}
let rec closure1 (v0 : string) (v1 : string) : bool =
    let v3 : bool = v1.Contains v0 
    v3
and closure0 () (v0 : string) : (string -> bool) =
    closure1(v0)
and closure3 (v0 : string) (v1 : string) : bool =
    let v3 : bool = v1.EndsWith (v0, false, null)
    v3
and closure2 () (v0 : string) : (string -> bool) =
    closure3(v0)
and closure7 (v0 : int32, v1 : string, v2 : int32) (v3 : string) : string =
    let v4 : bool = v2 >= v0
    if v4 then
        v3
    else
        let v5 : int32 = v2 + 1
        let v6 : (string -> string) = method0(v0, v1, v5)
        let v8 : string = v3 + v1 
        v6 v8
and method0 (v0 : int32, v1 : string, v2 : int32) : (string -> string) =
    closure7(v0, v1, v2)
and closure6 (v0 : int32, v1 : char) (v2 : string) : string =
    let v4 : (char -> string) = _.ToString()
    let v5 : string = v4 v1
    let v8 : int32 = v2.Length
    let v9 : int32 = v0 - v8
    let v10 : int32 = 0
    let v11 : (string -> string) = method0(v9, v5, v10)
    let v12 : string = ""
    let v13 : string = v11 v12
    let v15 : string = v13 + v2 
    v15
and closure5 (v0 : int32) (v1 : char) : (string -> string) =
    closure6(v0, v1)
and closure4 () (v0 : int32) : (char -> (string -> string)) =
    closure5(v0)
and closure10 (v0 : int32, v1 : char) (v2 : string) : string =
    let v4 : (char -> string) = _.ToString()
    let v5 : string = v4 v1
    let v8 : int32 = v2.Length
    let v9 : int32 = v0 - v8
    let v10 : int32 = 0
    let v11 : (string -> string) = method0(v9, v5, v10)
    let v12 : string = ""
    let v13 : string = v11 v12
    let v15 : string = v2 + v13 
    v15
and closure9 (v0 : int32) (v1 : char) : (string -> string) =
    closure10(v0, v1)
and closure8 () (v0 : int32) : (char -> (string -> string)) =
    closure9(v0)
and closure13 (v0 : string, v1 : string) (v2 : string) : string =
    let v3 : string = v2.Replace (v0, v1)
    v3
and closure12 (v0 : string) (v1 : string) : (string -> string) =
    closure13(v0, v1)
and closure11 () (v0 : string) : (string -> (string -> string)) =
    closure12(v0)
and method2 (v0 : string) : string =
    v0
and method3 () : string =
    let v0 : string = ""
    v0
and method1 (v0 : string, v1 : string, v2 : string) : string =
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
    let v22 : string = method2(v2)
    let v23 : string = $"$0.replace_all(&*$1, &*$2)"
    let v24 : std_borrow_Cow<Str> = Fable.Core.RustInterop.emitRustExpr struct (v19, v22, v1) v23 
    let v25 : string = "String::from($0)"
    let v26 : std_string_String = Fable.Core.RustInterop.emitRustExpr v24 v25 
    let v27 : string = "fable_library_rust::String_::fromString($0)"
    let v28 : string = Fable.Core.RustInterop.emitRustExpr v26 v27 
    let _run_target_args'_v4 = v28 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v29 : string = method3()
    let _run_target_args'_v4 = v29 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v30 : string = method3()
    let _run_target_args'_v4 = v30 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v31 : string = method3()
    let _run_target_args'_v4 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v32 : string = method3()
    let _run_target_args'_v4 = v32 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v33 : string = method3()
    let _run_target_args'_v4 = v33 
    #endif
#else
    let v34 : string = System.Text.RegularExpressions.Regex.Replace (v2, v0, v1)
    let _run_target_args'_v4 = v34 
    #endif
    let v35 : string = _run_target_args'_v4 
    v35
and closure16 (v0 : string, v1 : string) (v2 : string) : string =
    method1(v0, v1, v2)
and closure15 (v0 : string) (v1 : string) : (string -> string) =
    closure16(v0, v1)
and closure14 () (v0 : string) : (string -> (string -> string)) =
    closure15(v0)
and closure19 (v0 : int32, v1 : int32) (v2 : string) : string =
    let v4 : string = v2.[int v0..int v1]
    v4
and closure18 (v0 : int32) (v1 : int32) : (string -> string) =
    closure19(v0, v1)
and closure17 () (v0 : int32) : (int32 -> (string -> string)) =
    closure18(v0)
and closure21 (v0 : string) (v1 : string) : (string []) =
    let v11 : (string []) = v1.Split v0 
    v11
and closure20 () (v0 : string) : (string -> (string [])) =
    closure21(v0)
and method4 () : string =
    let v0 : string = ""
    v0
and method5 (v0 : string) : string =
    v0
and closure23 (v0 : (string [])) (v1 : string) : (string []) =
    (* run_target_args'
    let v28 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v30 : string seq = v0 |> Seq.ofArray
    let v33 : string = method4()
    let v35 : bool = v33 = "\n"
    let v37 : string =
        if v35 then
            method5(v33)
        else
            v33
    let v38 : (string -> (string seq -> string)) = String.concat
    let v39 : (string seq -> string) = v38 v37
    let v40 : string = v39 v30
    let v52 : (string []) = v1.Split v40 
    let _run_target_args'_v28 = v52 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v56 : string seq = v0 |> Seq.ofArray
    let v59 : string = method4()
    let v61 : bool = v59 = "\n"
    let v63 : string =
        if v61 then
            method5(v59)
        else
            v59
    let v64 : (string -> (string seq -> string)) = String.concat
    let v65 : (string seq -> string) = v64 v63
    let v66 : string = v65 v56
    let v78 : (string []) = v1.Split v66 
    let _run_target_args'_v28 = v78 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v82 : string seq = v0 |> Seq.ofArray
    let v85 : string = method4()
    let v87 : bool = v85 = "\n"
    let v89 : string =
        if v87 then
            method5(v85)
        else
            v85
    let v90 : (string -> (string seq -> string)) = String.concat
    let v91 : (string seq -> string) = v90 v89
    let v92 : string = v91 v82
    let v104 : (string []) = v1.Split v92 
    let _run_target_args'_v28 = v104 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v108 : string seq = v0 |> Seq.ofArray
    let v111 : string = method4()
    let v113 : bool = v111 = "\n"
    let v115 : string =
        if v113 then
            method5(v111)
        else
            v111
    let v116 : (string -> (string seq -> string)) = String.concat
    let v117 : (string seq -> string) = v116 v115
    let v118 : string = v117 v108
    let v130 : (string []) = v1.Split v118 
    let _run_target_args'_v28 = v130 
    #endif
#if FABLE_COMPILER_PYTHON
    let v134 : string seq = v0 |> Seq.ofArray
    let v137 : string = method4()
    let v139 : bool = v137 = "\n"
    let v141 : string =
        if v139 then
            method5(v137)
        else
            v137
    let v142 : (string -> (string seq -> string)) = String.concat
    let v143 : (string seq -> string) = v142 v141
    let v144 : string = v143 v134
    let v156 : (string []) = v1.Split v144 
    let _run_target_args'_v28 = v156 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v160 : string seq = v0 |> Seq.ofArray
    let v163 : string = method4()
    let v165 : bool = v163 = "\n"
    let v167 : string =
        if v165 then
            method5(v163)
        else
            v163
    let v168 : (string -> (string seq -> string)) = String.concat
    let v169 : (string seq -> string) = v168 v167
    let v170 : string = v169 v160
    let v182 : (string []) = v1.Split v170 
    let _run_target_args'_v28 = v182 
    #endif
#else
    let v185 : (string []) = v1.Split (v0, System.StringSplitOptions.None)
    let _run_target_args'_v28 = v185 
    #endif
    let v186 : (string []) = _run_target_args'_v28 
    v186
and closure22 () (v0 : (string [])) : (string -> (string [])) =
    closure23(v0)
and closure25 (v0 : string) (v1 : string) : bool =
    let v3 : bool = v1.StartsWith (v0, false, null)
    v3
and closure24 () (v0 : string) : (string -> bool) =
    closure25(v0)
and closure28 (v0 : int32, v1 : int32) (v2 : string) : string =
    let v3 : string = v2.Substring (v0, v1)
    v3
and closure27 (v0 : int32) (v1 : int32) : (string -> string) =
    closure28(v0, v1)
and closure26 () (v0 : int32) : (int32 -> (string -> string)) =
    closure27(v0)
and closure29 () (v0 : string) : string =
    let v2 : (unit -> string) = v0.ToLower
    v2 ()
and closure30 () (v0 : string) : string =
    let v1 : (unit -> string) = v0.ToUpper
    v1 ()
and closure31 () (v0 : string) : string =
    let v2 : (unit -> string) = v0.Trim
    v2 ()
and closure34 (v0 : char) (v1 : UH0) : UH0 =
    UH0_1(v0, v1)
and closure33 () (v0 : char) : (UH0 -> UH0) =
    closure34(v0)
and method6 () : (char -> (UH0 -> UH0)) =
    closure33()
and method7 (v0 : UH0, v1 : char list) : char list =
    match v0 with
    | UH0_1(v2, v3) -> (* Cons *)
        let v4 : char list = method7(v3, v1)
        let v6 : char list = v2 :: v4 
        v6
    | UH0_0 -> (* Nil *)
        v1
and closure35 (v0 : UH0) (v1 : string) : string =
    let v2 : char list = []
    let v3 : char list = method7(v0, v2)
    let v10 : (char list -> (char [])) = List.toArray
    let v11 : (char []) = v10 v3
    let v14 : string = v1.TrimEnd v11 
    v14
and closure32 () (v0 : (char [])) : (string -> string) =
    let v2 : char list = v0 |> Array.toList
    let v10 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
    let v11 : (char -> (UH0 -> UH0)) = method6()
    let v12 : (char list -> (UH0 -> UH0)) = v10 v11
    let v13 : (UH0 -> UH0) = v12 v2
    let v14 : UH0 = UH0_0
    let v15 : UH0 = v13 v14
    closure35(v15)
and closure37 (v0 : UH0) (v1 : string) : string =
    let v2 : char list = []
    let v3 : char list = method7(v0, v2)
    let v10 : (char list -> (char [])) = List.toArray
    let v11 : (char []) = v10 v3
    let v14 : string = v1.TrimStart v11 
    v14
and closure36 () (v0 : (char [])) : (string -> string) =
    let v2 : char list = v0 |> Array.toList
    let v10 : ((char -> (UH0 -> UH0)) -> (char list -> (UH0 -> UH0))) = List.foldBack
    let v11 : (char -> (UH0 -> UH0)) = method6()
    let v12 : (char list -> (UH0 -> UH0)) = v10 v11
    let v13 : (UH0 -> UH0) = v12 v2
    let v14 : UH0 = UH0_0
    let v15 : UH0 = v13 v14
    closure37(v15)
and closure39 (v0 : int32) (v1 : string) : string =
    let v2 : int32 = v1.Length
    let v3 : bool = v2 <= v0
    if v3 then
        v1
    else
        let v4 : int32 = v0 - 1
        let v6 : string = v1.[int 0..int v4]
        let v12 : string = "..."
        let v13 : string = v6 + v12 
        v13
and closure38 () (v0 : int32) : (string -> string) =
    closure39(v0)
and method8 (v0 : int64, v1 : string) : string =
    let v2 : int64 = System.Convert.ToInt64 v1.Length
    let v3 : bool = v2 <= v0
    if v3 then
        v1
    else
        let v5 : (int64 -> float) = float
        let v6 : float = v5 v0
        let v9 : float = v6 / 2.0
        let v10 : (float -> float) = ceil
        let v11 : float = v10 v9
        let v13 : (float -> int64) = int64
        let v14 : int64 = v13 v11
        let v17 : (float -> float) = floor
        let v18 : float = v17 v9
        let v20 : (float -> int64) = int64
        let v21 : int64 = v20 v18
        let v24 : int64 = v14 - 1L
        let v26 : string = v1.[int 0L..int v24]
        let v30 : int64 = v2 - v21
        let v31 : int64 = v2 - 1L
        let v33 : string = v1.[int v30..int v31]
        let v37 : string = "..."
        let v38 : (string []) = [|v26; v37; v33|]
        let v40 : string seq = v38 |> Seq.ofArray
        let v45 : (string -> (string seq -> string)) = String.concat
        let v46 : string = ""
        let v47 : (string seq -> string) = v45 v46
        v47 v40
and closure41 (v0 : int64) (v1 : string) : string =
    method8(v0, v1)
and closure40 () (v0 : int64) : (string -> string) =
    closure41(v0)
and closure42 () (v0 : exn) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v7 : string = $"%A{v0}"
    let _run_target_args'_v5 = v7 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v11 : string = $"%A{v0}"
    let _run_target_args'_v5 = v11 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v15 : string = $"%A{v0}"
    let _run_target_args'_v5 = v15 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v19 : string = $"%A{v0}"
    let _run_target_args'_v5 = v19 
    #endif
#if FABLE_COMPILER_PYTHON
    let v23 : string = $"%A{v0}"
    let _run_target_args'_v5 = v23 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v27 : string = $"%A{v0}"
    let _run_target_args'_v5 = v27 
    #endif
#else
    let v30 : string = $"{v0.GetType ()}: {v0.Message}"
    let _run_target_args'_v5 = v30 
    #endif
    let v31 : string = _run_target_args'_v5 
    v31
and method9 (v0 : int32, v1 : Mut0) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and closure44 (v0 : string) (v1 : (string [])) : string =
    let v2 : int32 = v1.Length
    let v3 : string = ""
    let v4 : Mut0 = {l0 = 0; l1 = v3; l2 = v3} : Mut0
    while method9(v2, v4) do
        let v6 : int32 = v4.l0
        let v7 : int32 =  -v6
        let v8 : int32 = v7 + v2
        let v9 : int32 = v8 - 1
        let struct (v10 : string, v11 : string) = v4.l1, v4.l2
        let v12 : string = v1.[int v9]
        let v14 : string = v12 + v11 
        let v18 : string = v14 + v10 
        let v21 : int32 = v6 + 1
        v4.l0 <- v21
        v4.l1 <- v18
        v4.l2 <- v0
        ()
    let struct (v22 : string, v23 : string) = v4.l1, v4.l2
    v22
and closure43 () (v0 : string) : ((string []) -> string) =
    closure44(v0)
and closure46 (v0 : string) (v1 : string seq) : string =
    let v3 : bool = v0 = "\n"
    let v5 : string =
        if v3 then
            method5(v0)
        else
            v0
    let v6 : (string -> (string seq -> string)) = String.concat
    let v7 : (string seq -> string) = v6 v5
    v7 v1
and closure45 () (v0 : string) : (string seq -> string) =
    closure46(v0)
and closure48 (v0 : string) (v1 : (string [])) : string =
    let v2 : string = System.String.Join (v0, v1)
    v2
and closure47 () (v0 : string) : ((string []) -> string) =
    closure48(v0)
and method10 (v0 : int32, v1 : Mut1) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and closure49 () (v0 : string) : (char []) =
    let v1 : int32 = v0.Length
    let v2 : (char []) = Array.zeroCreate<char> (v1)
    let v3 : Mut1 = {l0 = 0} : Mut1
    while method10(v1, v3) do
        let v5 : int32 = v3.l0
        let v6 : char = v0.[int v5]
        v2.[int v5] <- v6
        let v7 : int32 = v5 + 1
        v3.l0 <- v7
        ()
    v2
let v0 : (string -> (string -> bool)) = closure0()
let contains x = v0 x
let v1 : (string -> (string -> bool)) = closure2()
let ends_with x = v1 x
let v2 : (int32 -> (char -> (string -> string))) = closure4()
let pad_left x = v2 x
let v3 : (int32 -> (char -> (string -> string))) = closure8()
let pad_right x = v3 x
let v4 : (string -> (string -> (string -> string))) = closure11()
let replace x = v4 x
let v5 : (string -> (string -> (string -> string))) = closure14()
let replace_regex x = v5 x
let v6 : (int32 -> (int32 -> (string -> string))) = closure17()
let slice x = v6 x
let v7 : (string -> (string -> (string []))) = closure20()
let split x = v7 x
let v8 : ((string []) -> (string -> (string []))) = closure22()
let split_string x = v8 x
let v9 : (string -> (string -> bool)) = closure24()
let starts_with x = v9 x
let v10 : (int32 -> (int32 -> (string -> string))) = closure26()
let substring x = v10 x
let v11 : (string -> string) = closure29()
let to_lower x = v11 x
let v12 : (string -> string) = closure30()
let to_upper x = v12 x
let v13 : (string -> string) = closure31()
let trim x = v13 x
let v14 : ((char []) -> (string -> string)) = closure32()
let trim_end x = v14 x
let v15 : ((char []) -> (string -> string)) = closure36()
let trim_start x = v15 x
let v16 : (int32 -> (string -> string)) = closure38()
let ellipsis x = v16 x
let v17 : (int64 -> (string -> string)) = closure40()
let ellipsis_end x = v17 x
let v18 : (exn -> string) = closure42()
let format_exception x = v18 x
let v19 : (string -> ((string []) -> string)) = closure43()
let concat_array x = v19 x
let v20 : (string -> (string seq -> string)) = closure45()
let concat x = v20 x
let v21 : (string -> ((string []) -> string)) = closure47()
let join' x = v21 x
let v22 : (string -> (char [])) = closure49()
let to_char_array x = v22 x
()
