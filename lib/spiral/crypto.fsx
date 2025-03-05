#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("Vec<$0>")>]
#endif
type Vec<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::io::Cursor<$0>")>]
#endif
type std_io_Cursor<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::io::BufReader<$0>")>]
#endif
type std_io_BufReader<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("sha2::Sha256")>]
#endif
type sha2_Sha256 = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("_")>]
#endif
type Slice'<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("&$0")>]
type Ref<'T> = class end
#else
type Ref<'T> = 'T
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::string::String")>]
type std_string_String = class end
#else
type std_string_String = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("mut $0")>]
#endif
type Mut<'T> = class end
#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("std::io::Error")>]
type std_io_Error = class end
#else
type std_io_Error = string
#endif

#if FABLE_COMPILER
[<Fable.Core.Erase; Fable.Core.Emit("[$0]")>]
#endif
type Slice<'T> = class end
type ICryptoCreateHash = abstract createHash: x: string -> obj
type IHashlibSha256 = abstract sha256: x: unit -> obj
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

type Mut0 = {mutable l0 : int32}
and [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
    | US0_3
    | US0_4
and Mut1 = {mutable l0 : int64}
and Mut2 = {mutable l0 : (string -> unit)}
and Mut3 = {mutable l0 : bool}
and Mut4 = {mutable l0 : string}
and Mut5 = {mutable l0 : US0}
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
let rec method1 () : string =
    let v0 : string = ""
    v0
and method2 (v0 : string) : string =
    v0
and method3 (v0 : int32, v1 : Mut0) : bool =
    let v2 : int32 = v1.l0
    let v3 : bool = v2 < v0
    v3
and method4 () : string =
    let v0 : string = ""
    v0
and method0 (v0 : string) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : System.Text.Encoding = System.Text.Encoding.UTF8
    let v7 : (System.Text.Encoding -> (string -> (uint8 []))) = _.GetBytes
    let v8 : (string -> (uint8 [])) = v7 v6
    let v9 : (uint8 []) = v8 v0
    let v10 : string = "$0.to_vec()"
    let v11 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v9 v10 
    let v12 : string = "std::io::Cursor::new(v11)"
    let v13 : std_io_Cursor<Vec<uint8>> = Fable.Core.RustInterop.emitRustExpr () v12 
    let v14 : string = "std::io::BufReader::new($0)"
    let v15 : std_io_BufReader<std_io_Cursor<Vec<uint8>>> = Fable.Core.RustInterop.emitRustExpr v13 v14 
    let v16 : string = "true; let mut v15 = v15"
    let v17 : bool = Fable.Core.RustInterop.emitRustExpr () v16 
    let v18 : string = "let result : sha2::Sha256 = sha2::Digest::new()"
    Fable.Core.RustInterop.emitRustExpr () v18 
    let v19 : string = "result"
    let v20 : sha2_Sha256 = Fable.Core.RustInterop.emitRustExpr () v19 
    let v21 : string = "true; let mut v20 = v20"
    let v22 : bool = Fable.Core.RustInterop.emitRustExpr () v21 
    let v24 : unativeint = 0 |> unativeint 
    let v27 : string = "[$0; 1024]"
    let v28 : Slice'<uint8> = Fable.Core.RustInterop.emitRustExpr 0uy v27 
    let v29 : string = "true; loop { // rust.loop"
    let v30 : bool = Fable.Core.RustInterop.emitRustExpr () v29 
    let v31 : string = "true; let mut v28 = v28"
    let v32 : bool = Fable.Core.RustInterop.emitRustExpr () v31 
    let v33 : string = "std::io::Read::read(&mut v15, &mut v28)"
    let v34 : Result<unativeint, std_io_Error> = Fable.Core.RustInterop.emitRustExpr () v33 
    (* run_target_args'
    let v36 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v37 : string = "$0.unwrap()"
    let v38 : unativeint = Fable.Core.RustInterop.emitRustExpr v34 v37 
    let _run_target_args'_v36 = v38 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v39 : string = "$0.unwrap()"
    let v40 : unativeint = Fable.Core.RustInterop.emitRustExpr v34 v39 
    let _run_target_args'_v36 = v40 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v41 : string = "$0.unwrap()"
    let v42 : unativeint = Fable.Core.RustInterop.emitRustExpr v34 v41 
    let _run_target_args'_v36 = v42 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v43 : unativeint = match v34 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v36 = v43 
    #endif
#if FABLE_COMPILER_PYTHON
    let v44 : unativeint = match v34 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v36 = v44 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v45 : unativeint = match v34 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v36 = v45 
    #endif
#else
    let v46 : unativeint = match v34 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v36 = v46 
    #endif
    let v47 : unativeint = _run_target_args'_v36 
    let v51 : bool = v47 = v24 
    if v51 then
        let v54 : string = "true; break"
        let v55 : bool = Fable.Core.RustInterop.emitRustExpr () v54 
        ()
    let v57 : unativeint = v47 |> unativeint 
    let v61 : unativeint = v57 |> unbox<unativeint>
    let v64 : string = "v28.len()"
    let v65 : unativeint = Fable.Core.RustInterop.emitRustExpr () v64 
    let v67 : bool = v61 = v65 
    let v74 : Ref<Slice'<uint8>> =
        if v67 then
            let v70 : string = "&v28[v24..]"
            let v71 : Ref<Slice'<uint8>> = Fable.Core.RustInterop.emitRustExpr () v70 
            v71
        else
            let v72 : string = "&v28[$0..$1]"
            let v73 : Ref<Slice'<uint8>> = Fable.Core.RustInterop.emitRustExpr struct (v24, v57) v72 
            v73
    let v75 : string = "sha2::Digest::update(&mut v20, v74)"
    Fable.Core.RustInterop.emitRustExpr () v75 
    let v76 : string = "true; } // rust.loop"
    let v77 : bool = Fable.Core.RustInterop.emitRustExpr () v76 
    let v78 : string = "true; } // rust.loop"
    let v79 : bool = Fable.Core.RustInterop.emitRustExpr () v78 
    let v80 : string = "true; } // rust.loop"
    let v81 : bool = Fable.Core.RustInterop.emitRustExpr () v80 
    let v82 : string = "true; { // rust.loop"
    let v83 : bool = Fable.Core.RustInterop.emitRustExpr () v82 
    let v84 : string = "true; { // rust.loop"
    let v85 : bool = Fable.Core.RustInterop.emitRustExpr () v84 
    let v86 : string = "&sha2::Digest::finalize(v20)"
    let v87 : Ref<Slice<uint8>> = Fable.Core.RustInterop.emitRustExpr () v86 
    let v88 : string = "$0.iter().map(|x| *x).collect::<Vec<_>>()"
    let v89 : Vec<uint8> = Fable.Core.RustInterop.emitRustExpr v87 v88 
    let v90 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v91 : bool = Fable.Core.RustInterop.emitRustExpr v89 v90 
    let v92 : string = "x"
    let v93 : uint8 = Fable.Core.RustInterop.emitRustExpr () v92 
    let v94 : string = "format!(\"{:02x}\", $0)"
    let v95 : std_string_String = Fable.Core.RustInterop.emitRustExpr v93 v94 
    let v96 : string = "fable_library_rust::String_::fromString($0)"
    let v97 : string = Fable.Core.RustInterop.emitRustExpr v95 v96 
    let v98 : string = "true; $0 }).collect::<Vec<_>>()"
    let v99 : bool = Fable.Core.RustInterop.emitRustExpr v97 v98 
    let v100 : string = "_vec_map"
    let v101 : Vec<string> = Fable.Core.RustInterop.emitRustExpr () v100 
    let v102 : string = "fable_library_rust::NativeArray_::array_from($0.clone())"
    let v103 : (string []) = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let v107 : unit = ()
    let _let'_v107 =
        seq {
            for i = 0 to v103.Length - 1 do yield v103.[i]
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v110 : string seq = _let'_v107 
    let v116 : string = method1()
    let v118 : bool = v116 = "\n"
    let v120 : string =
        if v118 then
            method2(v116)
        else
            v116
    let v121 : (string -> (string seq -> string)) = String.concat
    let v122 : (string seq -> string) = v121 v120
    let v123 : string = v122 v110
    let v127 : Result<string, std_io_Error> = Ok v123 
    (* run_target_args'
    let v131 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v132 : string = "$0.unwrap()"
    let v133 : string = Fable.Core.RustInterop.emitRustExpr v127 v132 
    let _run_target_args'_v131 = v133 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v134 : string = "$0.unwrap()"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v127 v134 
    let _run_target_args'_v131 = v135 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v136 : string = "$0.unwrap()"
    let v137 : string = Fable.Core.RustInterop.emitRustExpr v127 v136 
    let _run_target_args'_v131 = v137 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v138 : string = match v127 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v131 = v138 
    #endif
#if FABLE_COMPILER_PYTHON
    let v139 : string = match v127 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v131 = v139 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v140 : string = match v127 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v131 = v140 
    #endif
#else
    let v141 : string = match v127 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v131 = v141 
    #endif
    let v142 : string = _run_target_args'_v131 
    let _run_target_args'_v5 = v142 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v146 : string = null |> unbox<string>
    let _run_target_args'_v5 = v146 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v150 : string = null |> unbox<string>
    let _run_target_args'_v5 = v150 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v153 : string = "crypto"
    let v154 : ICryptoCreateHash = Fable.Core.JsInterop.importAll v153 
    let v155 : string = "v154.createHash($0)"
    let v156 : string = "sha256"
    let v157 : obj = Fable.Core.JsInterop.emitJsExpr v156 v155 
    let v158 : string = "$0.update($1, 'utf8')"
    let v159 : obj = Fable.Core.JsInterop.emitJsExpr struct (v157, v0) v158 
    let v160 : string = "$0.digest($1)"
    let v161 : string = "hex"
    let v162 : string = Fable.Core.JsInterop.emitJsExpr struct (v159, v161) v160 
    let _run_target_args'_v5 = v162 
    #endif
#if FABLE_COMPILER_PYTHON
    let v164 : string = "hashlib"
    let v165 : IHashlibSha256 = Fable.Core.PyInterop.importAll v164 
    let v166 : string = "v165.sha256()"
    let v167 : obj = Fable.Core.PyInterop.emitPyExpr () v166 
    let v171 : string = "$0.encode($1)"
    let v172 : string = "utf-8"
    let v173 : string = Fable.Core.PyInterop.emitPyExpr struct (v0, v172) v171 
    let v176 : string = "v167.update($0)"
    Fable.Core.PyInterop.emitPyExpr v173 v176 
    let v178 : string = "v167.hexdigest()"
    let v179 : string = Fable.Core.PyInterop.emitPyExpr () v178 
    let _run_target_args'_v5 = v179 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v183 : string = null |> unbox<string>
    let _run_target_args'_v5 = v183 
    #endif
#else
    let v186 : (unit -> System.Security.Cryptography.SHA256) = System.Security.Cryptography.SHA256.Create
    let v187 : System.Security.Cryptography.SHA256 = v186 ()
    use v187 = v187 
    let v188 : System.Security.Cryptography.SHA256 = v187 
    let v189 : System.Text.Encoding = System.Text.Encoding.UTF8
    let v190 : (System.Text.Encoding -> (string -> (uint8 []))) = _.GetBytes
    let v191 : (string -> (uint8 [])) = v190 v189
    let v192 : (uint8 []) = v191 v0
    let v193 : ((uint8 []) -> (uint8 [])) = v188.ComputeHash
    let v194 : (uint8 []) = v193 v192
    let v195 : int32 = v194.Length
    let v196 : (string []) = Array.zeroCreate<string> (v195)
    let v197 : Mut0 = {l0 = 0} : Mut0
    while method3(v195, v197) do
        let v199 : int32 = v197.l0
        let v200 : uint8 = v194.[int v199]
        let v201 : (string -> string) = v200.ToString
        let v202 : string = "x2"
        let v203 : string = v201 v202
        v196.[int v199] <- v203
        let v204 : int32 = v199 + 1
        v197.l0 <- v204
        ()
    let v208 : unit = ()
    let _let'_v208 =
        seq {
            for i = 0 to v196.Length - 1 do yield v196.[i]
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v211 : string seq = _let'_v208 
    let v217 : string = method4()
    let v219 : bool = v217 = "\n"
    let v221 : string =
        if v219 then
            method2(v217)
        else
            v217
    let v222 : (string -> (string seq -> string)) = String.concat
    let v223 : (string seq -> string) = v222 v221
    let v224 : string = v223 v211
    let _run_target_args'_v5 = v224 
    #endif
    let v227 : string = _run_target_args'_v5 
    v227
and closure0 () (v0 : string) : string =
    method0(v0)
and method9 (v0 : string) : string =
    v0
and method10 () : string =
    let v0 : string = ""
    v0
and closure4 () (v0 : string) : US5 =
    US5_0(v0)
and method11 () : (string -> US5) =
    closure4()
and method8 (v0 : string) : string =
    (* run_target_args'
    let v5 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v6 : string = method9(v0)
    let v7 : string = "std::env::var(&*$0)"
    let v8 : Result<std_string_String, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr v6 v7 
    let v9 : string = "true; let _result_map_ = $0.map(|x| { //"
    let v10 : bool = Fable.Core.RustInterop.emitRustExpr v8 v9 
    let v11 : string = "x"
    let v12 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v11 
    let v13 : string = "fable_library_rust::String_::fromString($0)"
    let v14 : string = Fable.Core.RustInterop.emitRustExpr v12 v13 
    let v15 : string = "true; $0 })"
    let v16 : bool = Fable.Core.RustInterop.emitRustExpr v14 v15 
    let v17 : string = "_result_map_"
    let v18 : Result<string, std_env_VarError> = Fable.Core.RustInterop.emitRustExpr () v17 
    let v19 : string = method10()
    let v20 : string = "$0.unwrap_or($1)"
    let v21 : string = Fable.Core.RustInterop.emitRustExpr struct (v18, v19) v20 
    let _run_target_args'_v5 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : US3 = US3_1
    let v23 : US4 = US4_3(v22)
    let v24 : string = $"env.get_environment_variable / target: {v23} / var: {v0}"
    let v25 : string = failwith<string> v24
    let _run_target_args'_v5 = v25 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v26 : US3 = US3_2
    let v27 : US4 = US4_3(v26)
    let v28 : string = $"env.get_environment_variable / target: {v27} / var: {v0}"
    let v29 : string = failwith<string> v28
    let _run_target_args'_v5 = v29 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v30 : string = "process.env[$0] ?? \"\""
    let v31 : string = Fable.Core.JsInterop.emitJsExpr v0 v30 
    let _run_target_args'_v5 = v31 
    #endif
#if FABLE_COMPILER_PYTHON
    let v33 : string = "os"
    let v34 : IOsEnviron = Fable.Core.PyInterop.importAll v33 
    let v35 : string = "v34.environ"
    let v36 : obj = Fable.Core.PyInterop.emitPyExpr () v35 
    let v40 : string = "v36.get($0)"
    let v41 : string = Fable.Core.PyInterop.emitPyExpr v0 v40 
    let mutable _v41 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v45 : (string -> string option) = Option.ofObj
    let v46 : string option = v45 v41
    v46 
    #else
    Some v41 
    #endif
    |> fun x -> _v41 <- Some x
    let v47 : string option = match _v41 with Some x -> x | None -> failwith "optionm'.of_obj / _v41=None"
    let v52 : (string -> US5) = method11()
    let v53 : US5 option = v47 |> Option.map v52 
    let v67 : US5 = US5_1
    let v68 : US5 = v53 |> Option.defaultValue v67 
    let v75 : string =
        match v68 with
        | US5_1 -> (* None *)
            let v73 : string = ""
            v73
        | US5_0(v72) -> (* Some *)
            v72
    let _run_target_args'_v5 = v75 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : US3 = US3_1
    let v77 : US4 = US4_1(v76)
    let v78 : string = $"env.get_environment_variable / target: {v77} / var: {v0}"
    let v79 : string = failwith<string> v78
    let _run_target_args'_v5 = v79 
    #endif
#else
    let v80 : (string -> string) = System.Environment.GetEnvironmentVariable
    let v81 : string = v80 v0
    let mutable _v81 = None
    #if !FABLE_COMPILER && !WASM && !CONTRACT
    let v83 : (string -> string option) = Option.ofObj
    let v84 : string option = v83 v81
    v84 
    #else
    Some v81 
    #endif
    |> fun x -> _v81 <- Some x
    let v85 : string option = match _v81 with Some x -> x | None -> failwith "optionm'.of_obj / _v81=None"
    let v90 : (string -> US5) = method11()
    let v91 : US5 option = v85 |> Option.map v90 
    let v105 : US5 = US5_1
    let v106 : US5 = v91 |> Option.defaultValue v105 
    let v113 : string =
        match v106 with
        | US5_1 -> (* None *)
            let v111 : string = ""
            v111
        | US5_0(v110) -> (* Some *)
            v110
    let _run_target_args'_v5 = v113 
    #endif
    let v114 : string = _run_target_args'_v5 
    v114
and method7 () : struct (US1 * US2) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method8(v0)
    
    
    
    
    
    let v2 : bool = "Verbose" = v1
    let v6 : US1 =
        if v2 then
            let v3 : US0 = US0_0
            US1_0(v3)
        else
            US1_1
    let v47 : US1 =
        match v6 with
        | US1_1 -> (* None *)
            let v9 : bool = "Debug" = v1
            let v13 : US1 =
                if v9 then
                    let v10 : US0 = US0_1
                    US1_0(v10)
                else
                    US1_1
            match v13 with
            | US1_1 -> (* None *)
                let v16 : bool = "Info" = v1
                let v20 : US1 =
                    if v16 then
                        let v17 : US0 = US0_2
                        US1_0(v17)
                    else
                        US1_1
                match v20 with
                | US1_1 -> (* None *)
                    let v23 : bool = "Warning" = v1
                    let v27 : US1 =
                        if v23 then
                            let v24 : US0 = US0_3
                            US1_0(v24)
                        else
                            US1_1
                    match v27 with
                    | US1_1 -> (* None *)
                        let v30 : bool = "Critical" = v1
                        let v34 : US1 =
                            if v30 then
                                let v31 : US0 = US0_4
                                US1_0(v31)
                            else
                                US1_1
                        match v34 with
                        | US1_1 -> (* None *)
                            US1_1
                        | US1_0(v35) -> (* Some *)
                            US1_0(v35)
                    | US1_0(v28) -> (* Some *)
                        US1_0(v28)
                | US1_0(v21) -> (* Some *)
                    US1_0(v21)
            | US1_0(v14) -> (* Some *)
                US1_0(v14)
        | US1_0(v7) -> (* Some *)
            US1_0(v7)
    let v48 : string = "AUTOMATION"
    let v49 : string = method8(v48)
    let v52 : string = "True"
    let v53 : bool = v49 <> v52 
    let v120 : US2 =
        if v53 then
            US2_1
        else
            (* run_target_args'
            let v59 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v60 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v60 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v61 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v61 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v63 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v59 = v63 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v66 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v66 
            #endif
#if FABLE_COMPILER_PYTHON
            let v67 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v67 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v68 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v68 
            #endif
#else
            let v69 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v59 = v69 
            #endif
            let v70 : System.DateTime = _run_target_args'_v59 
            (* run_target_args'
            let v78 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v79 : (System.DateTime -> int64) = _.Ticks
            let v80 : int64 = v79 v70
            let _run_target_args'_v78 = v80 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v81 : (System.DateTime -> int64) = _.Ticks
            let v82 : int64 = v81 v70
            let _run_target_args'_v78 = v82 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v84 : int64 = null |> unbox<int64>
            let _run_target_args'_v78 = v84 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v87 : (System.DateTime -> int64) = _.Ticks
            let v88 : int64 = v87 v70
            let _run_target_args'_v78 = v88 
            #endif
#if FABLE_COMPILER_PYTHON
            let v89 : (System.DateTime -> int64) = _.Ticks
            let v90 : int64 = v89 v70
            let _run_target_args'_v78 = v90 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v91 : (System.DateTime -> int64) = _.Ticks
            let v92 : int64 = v91 v70
            let _run_target_args'_v78 = v92 
            #endif
#else
            let v93 : (System.DateTime -> int64) = _.Ticks
            let v94 : int64 = v93 v70
            let _run_target_args'_v78 = v94 
            #endif
            let v95 : int64 = _run_target_args'_v78 
            let v116 : int64 = v95 |> int64 
            US2_0(v116)
    struct (v47, v120)
and closure5 () (v0 : string) : unit =
    ()
and method6 (v0 : US0) : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v4 : US1, v5 : US2) = method7()
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
    let struct (v164 : US1, v165 : US2) = method7()
    let _run_target_args'_v3 = struct (v164, v165) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v166 : US1, v167 : US2) = method7()
    let _run_target_args'_v3 = struct (v166, v167) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v168 : US1, v169 : US2) = method7()
    let _run_target_args'_v3 = struct (v168, v169) 
    #endif
#else
    let struct (v170 : US1, v171 : US2) = method7()
    let _run_target_args'_v3 = struct (v170, v171) 
    #endif
    let struct (v172 : US1, v173 : US2) = _run_target_args'_v3 
    let v178 : Mut1 = {l0 = 1L} : Mut1
    let v179 : (string -> unit) = closure5()
    let v180 : Mut2 = {l0 = v179} : Mut2
    let v181 : Mut3 = {l0 = true} : Mut3
    let v182 : string = ""
    let v183 : Mut4 = {l0 = v182} : Mut4
    let v186 : US0 =
        match v172 with
        | US1_1 -> (* None *)
            v0
        | US1_0(v184) -> (* Some *)
            v184
    let v187 : Mut5 = {l0 = v186} : Mut5
    let v195 : int64 option =
        match v173 with
        | US2_1 -> (* None *)
            let v193 : int64 option = None
            v193
        | US2_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v195)
and closure3 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US0 = US0_0
        let struct (v2 : Mut1, v3 : Mut2, v4 : Mut3, v5 : Mut4, v6 : Mut5, v7 : int64 option) = method6(v1)
        let v9 : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and method5 (v0 : US0) : bool =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure3()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : US0 = v28.l0
    let v43 : bool = v26.l0
    let v44 : bool = v43 = false
    if v44 then
        false
    else
        let v45 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v0
        let v46 : int32 = [ US0_0, 0; US0_1, 1; US0_2, 2; US0_3, 3; US0_4, 4 ] |> Map |> Map.find v42
        let v47 : bool = v45 >= v46
        v47
and closure6 () (v0 : int64) : US2 =
    US2_0(v0)
and method13 () : (int64 -> US2) =
    closure6()
and method14 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method15 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method12 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option) : string =
    (* run_target_args'
    let v167 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v170 : (int64 -> US2) = method13()
    let v171 : US2 option = v5 |> Option.map v170 
    let v185 : US2 = US2_1
    let v186 : US2 = v171 |> Option.defaultValue v185 
    let v304 : System.DateTime =
        match v186 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v287 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v288 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v288 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v289 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v289 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v291 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v287 = v291 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v294 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v294 
            #endif
#if FABLE_COMPILER_PYTHON
            let v295 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v295 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v296 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v296 
            #endif
#else
            let v297 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v287 = v297 
            #endif
            let v298 : System.DateTime = _run_target_args'_v287 
            v298
        | US2_0(v190) -> (* Some *)
            (* run_target_args'
            let v193 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v194 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v194 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v195 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v195 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v197 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v193 = v197 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v200 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v200 
            #endif
#if FABLE_COMPILER_PYTHON
            let v201 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v201 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v202 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v202 
            #endif
#else
            let v203 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v193 = v203 
            #endif
            let v204 : System.DateTime = _run_target_args'_v193 
            (* run_target_args'
            let v212 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v213 : (System.DateTime -> int64) = _.Ticks
            let v214 : int64 = v213 v204
            let _run_target_args'_v212 = v214 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v215 : (System.DateTime -> int64) = _.Ticks
            let v216 : int64 = v215 v204
            let _run_target_args'_v212 = v216 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v218 : int64 = null |> unbox<int64>
            let _run_target_args'_v212 = v218 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v221 : (System.DateTime -> int64) = _.Ticks
            let v222 : int64 = v221 v204
            let _run_target_args'_v212 = v222 
            #endif
#if FABLE_COMPILER_PYTHON
            let v223 : (System.DateTime -> int64) = _.Ticks
            let v224 : int64 = v223 v204
            let _run_target_args'_v212 = v224 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v225 : (System.DateTime -> int64) = _.Ticks
            let v226 : int64 = v225 v204
            let _run_target_args'_v212 = v226 
            #endif
#else
            let v227 : (System.DateTime -> int64) = _.Ticks
            let v228 : int64 = v227 v204
            let _run_target_args'_v212 = v228 
            #endif
            let v229 : int64 = _run_target_args'_v212 
            let v250 : int64 = v229 |> int64 
            let v253 : int64 = v250 - v190
            let v256 : System.TimeSpan = v253 |> System.TimeSpan 
            let v262 : (System.TimeSpan -> int32) = _.Hours
            let v263 : int32 = v262 v256
            let v267 : (System.TimeSpan -> int32) = _.Minutes
            let v268 : int32 = v267 v256
            let v272 : (System.TimeSpan -> int32) = _.Seconds
            let v273 : int32 = v272 v256
            let v277 : (System.TimeSpan -> int32) = _.Milliseconds
            let v278 : int32 = v277 v256
            let v282 : System.DateTime = System.DateTime (1, 1, 1, v263, v268, v273, v278)
            v282
    let v306 : string = method14()
    let v310 : bool = v306 = ""
    let v312 : string =
        if v310 then
            let v311 : string = "M-d-y hh:mm:ss tt"
            v311
        else
            v306
    let v313 : (string -> string) = v304.ToString
    let v314 : string = v313 v312
    let _run_target_args'_v167 = v314 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v331 : (int64 -> US2) = method13()
    let v332 : US2 option = v5 |> Option.map v331 
    let v346 : US2 = US2_1
    let v347 : US2 = v332 |> Option.defaultValue v346 
    let v465 : System.DateTime =
        match v347 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v448 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v449 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v449 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v450 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v450 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v452 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v448 = v452 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v455 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v455 
            #endif
#if FABLE_COMPILER_PYTHON
            let v456 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v456 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v457 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v457 
            #endif
#else
            let v458 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v448 = v458 
            #endif
            let v459 : System.DateTime = _run_target_args'_v448 
            v459
        | US2_0(v351) -> (* Some *)
            (* run_target_args'
            let v354 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v355 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v355 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v356 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v356 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v358 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v354 = v358 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v361 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v361 
            #endif
#if FABLE_COMPILER_PYTHON
            let v362 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v362 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v363 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v363 
            #endif
#else
            let v364 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v354 = v364 
            #endif
            let v365 : System.DateTime = _run_target_args'_v354 
            (* run_target_args'
            let v373 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v374 : (System.DateTime -> int64) = _.Ticks
            let v375 : int64 = v374 v365
            let _run_target_args'_v373 = v375 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v376 : (System.DateTime -> int64) = _.Ticks
            let v377 : int64 = v376 v365
            let _run_target_args'_v373 = v377 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v379 : int64 = null |> unbox<int64>
            let _run_target_args'_v373 = v379 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v382 : (System.DateTime -> int64) = _.Ticks
            let v383 : int64 = v382 v365
            let _run_target_args'_v373 = v383 
            #endif
#if FABLE_COMPILER_PYTHON
            let v384 : (System.DateTime -> int64) = _.Ticks
            let v385 : int64 = v384 v365
            let _run_target_args'_v373 = v385 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v386 : (System.DateTime -> int64) = _.Ticks
            let v387 : int64 = v386 v365
            let _run_target_args'_v373 = v387 
            #endif
#else
            let v388 : (System.DateTime -> int64) = _.Ticks
            let v389 : int64 = v388 v365
            let _run_target_args'_v373 = v389 
            #endif
            let v390 : int64 = _run_target_args'_v373 
            let v411 : int64 = v390 |> int64 
            let v414 : int64 = v411 - v351
            let v417 : System.TimeSpan = v414 |> System.TimeSpan 
            let v423 : (System.TimeSpan -> int32) = _.Hours
            let v424 : int32 = v423 v417
            let v428 : (System.TimeSpan -> int32) = _.Minutes
            let v429 : int32 = v428 v417
            let v433 : (System.TimeSpan -> int32) = _.Seconds
            let v434 : int32 = v433 v417
            let v438 : (System.TimeSpan -> int32) = _.Milliseconds
            let v439 : int32 = v438 v417
            let v443 : System.DateTime = System.DateTime (1, 1, 1, v424, v429, v434, v439)
            v443
    let v467 : string = method14()
    let v471 : bool = v467 = ""
    let v473 : string =
        if v471 then
            let v472 : string = "M-d-y hh:mm:ss tt"
            v472
        else
            v467
    let v474 : (string -> string) = v465.ToString
    let v475 : string = v474 v473
    let _run_target_args'_v167 = v475 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v490 : string = $"near_sdk::env::block_timestamp()"
    let v491 : uint64 = Fable.Core.RustInterop.emitRustExpr () v490 
    let v494 : (int64 -> US2) = method13()
    let v495 : US2 option = v5 |> Option.map v494 
    let v509 : US2 = US2_1
    let v510 : US2 = v495 |> Option.defaultValue v509 
    let v522 : uint64 =
        match v510 with
        | US2_1 -> (* None *)
            v491
        | US2_0(v514) -> (* Some *)
            let v516 : (int64 -> uint64) = uint64
            let v517 : uint64 = v516 v514
            let v520 : uint64 = v491 - v517
            v520
    let v523 : uint64 = v522 / 1000000000UL
    let v524 : uint64 = v523 % 60UL
    let v525 : uint64 = v523 / 60UL
    let v526 : uint64 = v525 % 60UL
    let v527 : uint64 = v523 / 3600UL
    let v528 : uint64 = v527 % 24UL
    let v529 : string = $"format!(\"{{:02}}:{{:02}}:{{:02}}\", $0, $1, $2)"
    let v530 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v528, v526, v524) v529 
    let v531 : string = "fable_library_rust::String_::fromString($0)"
    let v532 : string = Fable.Core.RustInterop.emitRustExpr v530 v531 
    let _run_target_args'_v167 = v532 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v535 : (int64 -> US2) = method13()
    let v536 : US2 option = v5 |> Option.map v535 
    let v550 : US2 = US2_1
    let v551 : US2 = v536 |> Option.defaultValue v550 
    let v669 : System.DateTime =
        match v551 with
        | US2_1 -> (* None *)
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
            v663
        | US2_0(v555) -> (* Some *)
            (* run_target_args'
            let v558 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v559 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v559 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v560 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v560 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v562 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v558 = v562 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v565 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v565 
            #endif
#if FABLE_COMPILER_PYTHON
            let v566 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v566 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v567 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v567 
            #endif
#else
            let v568 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v558 = v568 
            #endif
            let v569 : System.DateTime = _run_target_args'_v558 
            (* run_target_args'
            let v577 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v578 : (System.DateTime -> int64) = _.Ticks
            let v579 : int64 = v578 v569
            let _run_target_args'_v577 = v579 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v580 : (System.DateTime -> int64) = _.Ticks
            let v581 : int64 = v580 v569
            let _run_target_args'_v577 = v581 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v583 : int64 = null |> unbox<int64>
            let _run_target_args'_v577 = v583 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v586 : (System.DateTime -> int64) = _.Ticks
            let v587 : int64 = v586 v569
            let _run_target_args'_v577 = v587 
            #endif
#if FABLE_COMPILER_PYTHON
            let v588 : (System.DateTime -> int64) = _.Ticks
            let v589 : int64 = v588 v569
            let _run_target_args'_v577 = v589 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v590 : (System.DateTime -> int64) = _.Ticks
            let v591 : int64 = v590 v569
            let _run_target_args'_v577 = v591 
            #endif
#else
            let v592 : (System.DateTime -> int64) = _.Ticks
            let v593 : int64 = v592 v569
            let _run_target_args'_v577 = v593 
            #endif
            let v594 : int64 = _run_target_args'_v577 
            let v615 : int64 = v594 |> int64 
            let v618 : int64 = v615 - v555
            let v621 : System.TimeSpan = v618 |> System.TimeSpan 
            let v627 : (System.TimeSpan -> int32) = _.Hours
            let v628 : int32 = v627 v621
            let v632 : (System.TimeSpan -> int32) = _.Minutes
            let v633 : int32 = v632 v621
            let v637 : (System.TimeSpan -> int32) = _.Seconds
            let v638 : int32 = v637 v621
            let v642 : (System.TimeSpan -> int32) = _.Milliseconds
            let v643 : int32 = v642 v621
            let v647 : System.DateTime = System.DateTime (1, 1, 1, v628, v633, v638, v643)
            v647
    let v671 : string = method15()
    let v675 : bool = v671 = ""
    let v677 : string =
        if v675 then
            let v676 : string = "M-d-y hh:mm:ss tt"
            v676
        else
            v671
    let v678 : (string -> string) = v669.ToString
    let v679 : string = v678 v677
    let _run_target_args'_v167 = v679 
    #endif
#if FABLE_COMPILER_PYTHON
    let v696 : (int64 -> US2) = method13()
    let v697 : US2 option = v5 |> Option.map v696 
    let v711 : US2 = US2_1
    let v712 : US2 = v697 |> Option.defaultValue v711 
    let v830 : System.DateTime =
        match v712 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v813 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v814 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v814 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v815 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v815 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v817 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v813 = v817 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v820 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v820 
            #endif
#if FABLE_COMPILER_PYTHON
            let v821 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v821 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v822 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v822 
            #endif
#else
            let v823 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v813 = v823 
            #endif
            let v824 : System.DateTime = _run_target_args'_v813 
            v824
        | US2_0(v716) -> (* Some *)
            (* run_target_args'
            let v719 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v720 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v720 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v721 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v721 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v723 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v719 = v723 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v726 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v726 
            #endif
#if FABLE_COMPILER_PYTHON
            let v727 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v727 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v728 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v728 
            #endif
#else
            let v729 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v719 = v729 
            #endif
            let v730 : System.DateTime = _run_target_args'_v719 
            (* run_target_args'
            let v738 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v739 : (System.DateTime -> int64) = _.Ticks
            let v740 : int64 = v739 v730
            let _run_target_args'_v738 = v740 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v741 : (System.DateTime -> int64) = _.Ticks
            let v742 : int64 = v741 v730
            let _run_target_args'_v738 = v742 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v744 : int64 = null |> unbox<int64>
            let _run_target_args'_v738 = v744 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v747 : (System.DateTime -> int64) = _.Ticks
            let v748 : int64 = v747 v730
            let _run_target_args'_v738 = v748 
            #endif
#if FABLE_COMPILER_PYTHON
            let v749 : (System.DateTime -> int64) = _.Ticks
            let v750 : int64 = v749 v730
            let _run_target_args'_v738 = v750 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v751 : (System.DateTime -> int64) = _.Ticks
            let v752 : int64 = v751 v730
            let _run_target_args'_v738 = v752 
            #endif
#else
            let v753 : (System.DateTime -> int64) = _.Ticks
            let v754 : int64 = v753 v730
            let _run_target_args'_v738 = v754 
            #endif
            let v755 : int64 = _run_target_args'_v738 
            let v776 : int64 = v755 |> int64 
            let v779 : int64 = v776 - v716
            let v782 : System.TimeSpan = v779 |> System.TimeSpan 
            let v788 : (System.TimeSpan -> int32) = _.Hours
            let v789 : int32 = v788 v782
            let v793 : (System.TimeSpan -> int32) = _.Minutes
            let v794 : int32 = v793 v782
            let v798 : (System.TimeSpan -> int32) = _.Seconds
            let v799 : int32 = v798 v782
            let v803 : (System.TimeSpan -> int32) = _.Milliseconds
            let v804 : int32 = v803 v782
            let v808 : System.DateTime = System.DateTime (1, 1, 1, v789, v794, v799, v804)
            v808
    let v832 : string = method15()
    let v836 : bool = v832 = ""
    let v838 : string =
        if v836 then
            let v837 : string = "M-d-y hh:mm:ss tt"
            v837
        else
            v832
    let v839 : (string -> string) = v830.ToString
    let v840 : string = v839 v838
    let _run_target_args'_v167 = v840 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v857 : (int64 -> US2) = method13()
    let v858 : US2 option = v5 |> Option.map v857 
    let v872 : US2 = US2_1
    let v873 : US2 = v858 |> Option.defaultValue v872 
    let v991 : System.DateTime =
        match v873 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v974 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v975 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v975 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v976 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v976 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v978 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v974 = v978 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v981 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v981 
            #endif
#if FABLE_COMPILER_PYTHON
            let v982 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v982 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v983 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v983 
            #endif
#else
            let v984 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v974 = v984 
            #endif
            let v985 : System.DateTime = _run_target_args'_v974 
            v985
        | US2_0(v877) -> (* Some *)
            (* run_target_args'
            let v880 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v881 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v881 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v882 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v882 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v884 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v880 = v884 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v887 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v887 
            #endif
#if FABLE_COMPILER_PYTHON
            let v888 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v888 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v889 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v889 
            #endif
#else
            let v890 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v880 = v890 
            #endif
            let v891 : System.DateTime = _run_target_args'_v880 
            (* run_target_args'
            let v899 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v900 : (System.DateTime -> int64) = _.Ticks
            let v901 : int64 = v900 v891
            let _run_target_args'_v899 = v901 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v902 : (System.DateTime -> int64) = _.Ticks
            let v903 : int64 = v902 v891
            let _run_target_args'_v899 = v903 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v905 : int64 = null |> unbox<int64>
            let _run_target_args'_v899 = v905 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v908 : (System.DateTime -> int64) = _.Ticks
            let v909 : int64 = v908 v891
            let _run_target_args'_v899 = v909 
            #endif
#if FABLE_COMPILER_PYTHON
            let v910 : (System.DateTime -> int64) = _.Ticks
            let v911 : int64 = v910 v891
            let _run_target_args'_v899 = v911 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v912 : (System.DateTime -> int64) = _.Ticks
            let v913 : int64 = v912 v891
            let _run_target_args'_v899 = v913 
            #endif
#else
            let v914 : (System.DateTime -> int64) = _.Ticks
            let v915 : int64 = v914 v891
            let _run_target_args'_v899 = v915 
            #endif
            let v916 : int64 = _run_target_args'_v899 
            let v937 : int64 = v916 |> int64 
            let v940 : int64 = v937 - v877
            let v943 : System.TimeSpan = v940 |> System.TimeSpan 
            let v949 : (System.TimeSpan -> int32) = _.Hours
            let v950 : int32 = v949 v943
            let v954 : (System.TimeSpan -> int32) = _.Minutes
            let v955 : int32 = v954 v943
            let v959 : (System.TimeSpan -> int32) = _.Seconds
            let v960 : int32 = v959 v943
            let v964 : (System.TimeSpan -> int32) = _.Milliseconds
            let v965 : int32 = v964 v943
            let v969 : System.DateTime = System.DateTime (1, 1, 1, v950, v955, v960, v965)
            v969
    let v993 : string = method15()
    let v997 : bool = v993 = ""
    let v999 : string =
        if v997 then
            let v998 : string = "M-d-y hh:mm:ss tt"
            v998
        else
            v993
    let v1000 : (string -> string) = v991.ToString
    let v1001 : string = v1000 v999
    let _run_target_args'_v167 = v1001 
    #endif
#else
    let v1018 : (int64 -> US2) = method13()
    let v1019 : US2 option = v5 |> Option.map v1018 
    let v1033 : US2 = US2_1
    let v1034 : US2 = v1019 |> Option.defaultValue v1033 
    let v1152 : System.DateTime =
        match v1034 with
        | US2_1 -> (* None *)
            (* run_target_args'
            let v1135 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1136 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1136 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1137 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1137 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1139 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1135 = v1139 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1142 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1142 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1143 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1143 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1144 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1144 
            #endif
#else
            let v1145 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1135 = v1145 
            #endif
            let v1146 : System.DateTime = _run_target_args'_v1135 
            v1146
        | US2_0(v1038) -> (* Some *)
            (* run_target_args'
            let v1041 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1042 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1042 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1043 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1043 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1045 : System.DateTime = null |> unbox<System.DateTime>
            let _run_target_args'_v1041 = v1045 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1048 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1048 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1049 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1049 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1050 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1050 
            #endif
#else
            let v1051 : System.DateTime = System.DateTime.Now
            let _run_target_args'_v1041 = v1051 
            #endif
            let v1052 : System.DateTime = _run_target_args'_v1041 
            (* run_target_args'
            let v1060 : unit = ()
            run_target_args' *)
            
#if FABLE_COMPILER || WASM || CONTRACT
            
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
            let v1061 : (System.DateTime -> int64) = _.Ticks
            let v1062 : int64 = v1061 v1052
            let _run_target_args'_v1060 = v1062 
            #endif
#if FABLE_COMPILER_RUST && WASM
            let v1063 : (System.DateTime -> int64) = _.Ticks
            let v1064 : int64 = v1063 v1052
            let _run_target_args'_v1060 = v1064 
            #endif
#if FABLE_COMPILER_RUST && CONTRACT
            let v1066 : int64 = null |> unbox<int64>
            let _run_target_args'_v1060 = v1066 
            #endif
#if FABLE_COMPILER_TYPESCRIPT
            let v1069 : (System.DateTime -> int64) = _.Ticks
            let v1070 : int64 = v1069 v1052
            let _run_target_args'_v1060 = v1070 
            #endif
#if FABLE_COMPILER_PYTHON
            let v1071 : (System.DateTime -> int64) = _.Ticks
            let v1072 : int64 = v1071 v1052
            let _run_target_args'_v1060 = v1072 
            #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
            let v1073 : (System.DateTime -> int64) = _.Ticks
            let v1074 : int64 = v1073 v1052
            let _run_target_args'_v1060 = v1074 
            #endif
#else
            let v1075 : (System.DateTime -> int64) = _.Ticks
            let v1076 : int64 = v1075 v1052
            let _run_target_args'_v1060 = v1076 
            #endif
            let v1077 : int64 = _run_target_args'_v1060 
            let v1098 : int64 = v1077 |> int64 
            let v1101 : int64 = v1098 - v1038
            let v1104 : System.TimeSpan = v1101 |> System.TimeSpan 
            let v1110 : (System.TimeSpan -> int32) = _.Hours
            let v1111 : int32 = v1110 v1104
            let v1115 : (System.TimeSpan -> int32) = _.Minutes
            let v1116 : int32 = v1115 v1104
            let v1120 : (System.TimeSpan -> int32) = _.Seconds
            let v1121 : int32 = v1120 v1104
            let v1125 : (System.TimeSpan -> int32) = _.Milliseconds
            let v1126 : int32 = v1125 v1104
            let v1130 : System.DateTime = System.DateTime (1, 1, 1, v1111, v1116, v1121, v1126)
            v1130
    let v1154 : string = method15()
    let v1158 : bool = v1154 = ""
    let v1160 : string =
        if v1158 then
            let v1159 : string = "M-d-y hh:mm:ss tt"
            v1159
        else
            v1154
    let v1161 : (string -> string) = v1152.ToString
    let v1162 : string = v1161 v1160
    let _run_target_args'_v167 = v1162 
    #endif
    let v1177 : string = _run_target_args'_v167 
    v1177
and method18 () : string =
    let v0 : string = ""
    v0
and closure7 (v0 : Mut4, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v3 : string = v2 + v1 
    v0.l0 <- v3
    ()
and method17 (v0 : char) : string =
    let v1 : string = method18()
    let v2 : Mut4 = {l0 = v1} : Mut4
    let v4 : string = $"{v0}"
    let v7 : unit = ()
    let v8 : (unit -> unit) = closure7(v2, v4)
    let v9 : unit = (fun () -> v8 (); v7) ()
    let v12 : string = v2.l0
    v12
and method19 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method16 () : string =
    
    
    
    
    
    let v1 : string = "Verbose"
    let v2 : (unit -> string) = v1.ToLower
    let v3 : string = v2 ()
    let v6 : char = v3.[int 0]
    let v7 : string = method17(v6)
    (* run_target_args'
    let v12 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v13 : string = "inline_colorization::color_bright_black"
    let v14 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v13 
    (* run_target_args'
    let v19 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v20 : string = "&*$0"
    let v21 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v20 
    let _run_target_args'_v19 = v21 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v22 : string = "&*$0"
    let v23 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v22 
    let _run_target_args'_v19 = v23 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v24 : string = "&*$0"
    let v25 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v24 
    let _run_target_args'_v19 = v25 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v27 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v27 
    #endif
#if FABLE_COMPILER_PYTHON
    let v31 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v31 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v35 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v35 
    #endif
#else
    let v39 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v19 = v39 
    #endif
    let v42 : Ref<Str> = _run_target_args'_v19 
    let v48 : string = "inline_colorization::color_reset"
    let v49 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v48 
    let v50 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v51 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v14, v42, v49) v50 
    let v52 : string = "fable_library_rust::String_::fromString($0)"
    let v53 : string = Fable.Core.RustInterop.emitRustExpr v51 v52 
    let _run_target_args'_v12 = v53 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v54 : string = "inline_colorization::color_bright_black"
    let v55 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v54 
    (* run_target_args'
    let v60 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v61 : string = "&*$0"
    let v62 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v61 
    let _run_target_args'_v60 = v62 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v63 : string = "&*$0"
    let v64 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v63 
    let _run_target_args'_v60 = v64 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v65 : string = "&*$0"
    let v66 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v65 
    let _run_target_args'_v60 = v66 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v68 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v68 
    #endif
#if FABLE_COMPILER_PYTHON
    let v72 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v72 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v76 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v76 
    #endif
#else
    let v80 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v60 = v80 
    #endif
    let v83 : Ref<Str> = _run_target_args'_v60 
    let v89 : string = "inline_colorization::color_reset"
    let v90 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v89 
    let v91 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v92 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v55, v83, v90) v91 
    let v93 : string = "fable_library_rust::String_::fromString($0)"
    let v94 : string = Fable.Core.RustInterop.emitRustExpr v92 v93 
    let _run_target_args'_v12 = v94 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v95 : string = "inline_colorization::color_bright_black"
    let v96 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v95 
    (* run_target_args'
    let v101 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v102 : string = "&*$0"
    let v103 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v102 
    let _run_target_args'_v101 = v103 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v104 : string = "&*$0"
    let v105 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v104 
    let _run_target_args'_v101 = v105 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v106 : string = "&*$0"
    let v107 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v7 v106 
    let _run_target_args'_v101 = v107 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v109 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v109 
    #endif
#if FABLE_COMPILER_PYTHON
    let v113 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v113 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v117 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v117 
    #endif
#else
    let v121 : Ref<Str> = v7 |> unbox<Ref<Str>>
    let _run_target_args'_v101 = v121 
    #endif
    let v124 : Ref<Str> = _run_target_args'_v101 
    let v130 : string = "inline_colorization::color_reset"
    let v131 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr () v130 
    let v132 : string = $"format!(\"{{}}{{}}{{}}\", $0, $1, $2)"
    let v133 : std_string_String = Fable.Core.RustInterop.emitRustExpr struct (v96, v124, v131) v132 
    let v134 : string = "fable_library_rust::String_::fromString($0)"
    let v135 : string = Fable.Core.RustInterop.emitRustExpr v133 v134 
    let _run_target_args'_v12 = v135 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v136 : string = "\u001b[90m"
    let v137 : string = method19()
    let v138 : string = v136 + v7 
    let v139 : string = v138 + v137 
    let _run_target_args'_v12 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = "\u001b[90m"
    let v141 : string = method19()
    let v142 : string = v140 + v7 
    let v143 : string = v142 + v141 
    let _run_target_args'_v12 = v143 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v144 : string = "\u001b[90m"
    let v145 : string = method19()
    let v146 : string = v144 + v7 
    let v147 : string = v146 + v145 
    let _run_target_args'_v12 = v147 
    #endif
#else
    let v148 : string = "\u001b[90m"
    let v149 : string = method19()
    let v150 : string = v148 + v7 
    let v151 : string = v150 + v149 
    let _run_target_args'_v12 = v151 
    #endif
    let v152 : string = _run_target_args'_v12 
    v152
and method21 (v0 : int32, v1 : string, v2 : uint16) : string =
    let v3 : string = method18()
    let v4 : Mut4 = {l0 = v3} : Mut4
    let v6 : string = "{ "
    let v7 : string = $"{v6}"
    let v10 : unit = ()
    let v11 : (unit -> unit) = closure7(v4, v7)
    let v12 : unit = (fun () -> v11 (); v10) ()
    let v16 : string = "first_letter_code"
    let v17 : string = $"{v16}"
    let v20 : unit = ()
    let v21 : (unit -> unit) = closure7(v4, v17)
    let v22 : unit = (fun () -> v21 (); v20) ()
    let v26 : string = " = "
    let v27 : string = $"{v26}"
    let v30 : unit = ()
    let v31 : (unit -> unit) = closure7(v4, v27)
    let v32 : unit = (fun () -> v31 (); v30) ()
    let v36 : string = $"{v0}"
    let v39 : unit = ()
    let v40 : (unit -> unit) = closure7(v4, v36)
    let v41 : unit = (fun () -> v40 (); v39) ()
    let v45 : string = "; "
    let v46 : string = $"{v45}"
    let v49 : unit = ()
    let v50 : (unit -> unit) = closure7(v4, v46)
    let v51 : unit = (fun () -> v50 (); v49) ()
    let v55 : string = "hash_part"
    let v56 : string = $"{v55}"
    let v59 : unit = ()
    let v60 : (unit -> unit) = closure7(v4, v56)
    let v61 : unit = (fun () -> v60 (); v59) ()
    let v65 : string = $"{v26}"
    let v68 : unit = ()
    let v69 : (unit -> unit) = closure7(v4, v65)
    let v70 : unit = (fun () -> v69 (); v68) ()
    let v74 : string = $"{v1}"
    let v77 : unit = ()
    let v78 : (unit -> unit) = closure7(v4, v74)
    let v79 : unit = (fun () -> v78 (); v77) ()
    let v83 : string = $"{v45}"
    let v86 : unit = ()
    let v87 : (unit -> unit) = closure7(v4, v83)
    let v88 : unit = (fun () -> v87 (); v86) ()
    let v92 : string = "combined_value"
    let v93 : string = $"{v92}"
    let v96 : unit = ()
    let v97 : (unit -> unit) = closure7(v4, v93)
    let v98 : unit = (fun () -> v97 (); v96) ()
    let v102 : string = $"{v26}"
    let v105 : unit = ()
    let v106 : (unit -> unit) = closure7(v4, v102)
    let v107 : unit = (fun () -> v106 (); v105) ()
    let v111 : string = $"{v2}"
    let v114 : unit = ()
    let v115 : (unit -> unit) = closure7(v4, v111)
    let v116 : unit = (fun () -> v115 (); v114) ()
    let v120 : string = " }"
    let v121 : string = $"{v120}"
    let v124 : unit = ()
    let v125 : (unit -> unit) = closure7(v4, v121)
    let v126 : unit = (fun () -> v125 (); v124) ()
    let v129 : string = v4.l0
    v129
and method22 (v0 : string) : string =
    let v1 : char list = []
    let v4 : (char list -> (char [])) = List.toArray
    let v5 : (char []) = v4 v1
    let v8 : string = v0.TrimStart v5 
    let v38 : char list = []
    let v40 : char list = '/' :: v38 
    let v44 : char list = ' ' :: v40 
    let v49 : (char list -> (char [])) = List.toArray
    let v50 : (char []) = v49 v44
    let v53 : string = v8.TrimEnd v50 
    v53
and method20 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string, v10 : uint16) : string =
    let v11 : string = method21(v8, v9, v10)
    let v12 : int64 = v0.l0
    let v14 : string = "crypto.hash_to_port"
    let v15 : string = $"{v6} {v7} #{v12} %s{v14} / {v11}"
    method22(v15)
and closure8 (v0 : Mut1) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure10 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure9 () (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure10(v0)
    let v3 : unit = (fun () -> v2 (); v1) ()
    ()
and method23 (v0 : string) : unit =
    let v1 : unit = ()
    let v2 : (unit -> unit) = closure3()
    let v3 : unit = (fun () -> v2 (); v1) ()
    let struct (v24 : Mut1, v25 : Mut2, v26 : Mut3, v27 : Mut4, v28 : Mut5, v29 : int64 option) = TraceState.trace_state.Value
    let v42 : unit = ()
    let v43 : (unit -> unit) = closure8(v24)
    let v44 : unit = (fun () -> v43 (); v42) ()
    let v47 : (string -> unit) = closure9()
    (* run_target_args'
    let v48 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v49 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v49 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v50 : string = @"println!(""{}"", $0)"
    Fable.Core.RustInterop.emitRustExpr v0 v50 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v51 : string = v27.l0
    let v52 : bool = v51 = ""
    let v60 : string =
        if v52 then
            v0
        else
            let v53 : bool = v0 = ""
            if v53 then
                let v54 : string = v27.l0
                v54
            else
                let v55 : string = v27.l0
                let v56 : string = "\n"
                let v57 : string = v55 + v56 
                let v58 : string = v57 + v0 
                v58
    (* run_target_args'
    let v65 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v66 : string = "&*$0"
    let v67 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v66 
    let _run_target_args'_v65 = v67 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v68 : string = "&*$0"
    let v69 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v68 
    let _run_target_args'_v65 = v69 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v70 : string = "&*$0"
    let v71 : Ref<Str> = Fable.Core.RustInterop.emitRustExpr v60 v70 
    let _run_target_args'_v65 = v71 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v73 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v73 
    #endif
#if FABLE_COMPILER_PYTHON
    let v77 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v77 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v81 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v81 
    #endif
#else
    let v85 : Ref<Str> = v60 |> unbox<Ref<Str>>
    let _run_target_args'_v65 = v85 
    #endif
    let v88 : Ref<Str> = _run_target_args'_v65 
    let v94 : string = $"$0.chars()"
    let v95 : Mut<_> = Fable.Core.RustInterop.emitRustExpr v88 v94 
    let v96 : string = "$0"
    let v97 : _ = Fable.Core.RustInterop.emitRustExpr v95 v96 
    let v98 : string = "$0.collect::<Vec<_>>()"
    let v99 : Vec<char> = Fable.Core.RustInterop.emitRustExpr v97 v98 
    let v100 : string = "$0.chunks(15000).map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>()).collect::<Vec<_>>()"
    let v101 : Vec<Vec<char>> = Fable.Core.RustInterop.emitRustExpr v99 v100 
    let v102 : string = "true; let _vec_map : Vec<_> = $0.into_iter().map(|x| { //"
    let v103 : bool = Fable.Core.RustInterop.emitRustExpr v101 v102 
    let v104 : string = "x"
    let v105 : Vec<char> = Fable.Core.RustInterop.emitRustExpr () v104 
    let v106 : string = "String::from_iter($0)"
    let v107 : std_string_String = Fable.Core.RustInterop.emitRustExpr v105 v106 
    let v108 : string = "true; $0 }).collect::<Vec<_>>()"
    let v109 : bool = Fable.Core.RustInterop.emitRustExpr v107 v108 
    let v110 : string = "_vec_map"
    let v111 : Vec<std_string_String> = Fable.Core.RustInterop.emitRustExpr () v110 
    let v112 : string = "$0.len()"
    let v113 : unativeint = Fable.Core.RustInterop.emitRustExpr v111 v112 
    let v119 : int32 = v113 |> int32 
    let v129 : string = ""
    let v130 : bool = v0 <> v129 
    let v134 : bool =
        if v130 then
            let v133 : bool = v119 <= 1
            v133
        else
            false
    if v134 then
        v27.l0 <- v60
        ()
    else
        v27.l0 <- v129
        let v135 : string = "true; $0.into_iter().for_each(|x| { //"
        let v136 : bool = Fable.Core.RustInterop.emitRustExpr v111 v135 
        let v137 : string = "x"
        let v138 : std_string_String = Fable.Core.RustInterop.emitRustExpr () v137 
        let v139 : string = $"true; near_sdk::log!(\"{{}}\", $0)"
        let v140 : bool = Fable.Core.RustInterop.emitRustExpr v138 v139 
        let v141 : string = $"true"
        let v142 : bool = Fable.Core.RustInterop.emitRustExpr () v141 
        let v143 : string = "true; }); //"
        let v144 : bool = Fable.Core.RustInterop.emitRustExpr () v143 
        ()
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    v47 v0
    #endif
#if FABLE_COMPILER_PYTHON
    v47 v0
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    v47 v0
    #endif
#else
    v47 v0
    #endif
    // run_target_args' is_unit
    let v145 : (string -> unit) = v25.l0
    v145 v0
and closure2 (v0 : int32, v1 : string, v2 : uint16) () : unit =
    let v3 : US0 = US0_0
    let v4 : bool = method5(v3)
    if v4 then
        let v5 : unit = ()
        let v6 : (unit -> unit) = closure3()
        let v7 : unit = (fun () -> v6 (); v5) ()
        let struct (v28 : Mut1, v29 : Mut2, v30 : Mut3, v31 : Mut4, v32 : Mut5, v33 : int64 option) = TraceState.trace_state.Value
        let v46 : string = method12(v28, v29, v30, v31, v32, v33)
        let v47 : string = method16()
        let v48 : string = method20(v28, v29, v30, v31, v32, v33, v46, v47, v0, v1, v2)
        method23(v48)
and closure1 () (v0 : string) : uint16 =
    let v1 : char = v0.[int 0]
    (* run_target_args'
    let v16 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v22 : int32 = v1 |> int32 
    let _run_target_args'_v16 = v22 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v35 : int32 = v1 |> int32 
    let _run_target_args'_v16 = v35 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v48 : int32 = v1 |> int32 
    let _run_target_args'_v16 = v48 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v61 : int32 = v1 |> int32 
    let _run_target_args'_v16 = v61 
    #endif
#if FABLE_COMPILER_PYTHON
    let v74 : int32 = v1 |> int32 
    let _run_target_args'_v16 = v74 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v87 : int32 = v1 |> int32 
    let _run_target_args'_v16 = v87 
    #endif
#else
    let v95 : int32 = System.Char.ConvertToUtf32 (string v1, 0)
    let _run_target_args'_v16 = v95 
    #endif
    let v96 : int32 = _run_target_args'_v16 
    let v114 : string = v0.[int 0..int 7]
    let v118 : int32 = System.Convert.ToInt32 (v114, 16)
    let v121 : int32 = v118 + v96
    let v123 : (int32 -> uint16) = uint16
    let v124 : uint16 = v123 v121
    let v127 : unit = ()
    let v128 : (unit -> unit) = closure2(v96, v114, v124)
    let v129 : unit = (fun () -> v128 (); v127) ()
    let v176 : uint16 = v124 % 48128us
    let v177 : uint16 = v176 + 1024us
    v177
let v0 : (string -> string) = closure0()
let hash_text x = v0 x
let v1 : (string -> uint16) = closure1()
let hash_to_port x = v1 x
()
