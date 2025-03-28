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
    let v108 : unit = ()
    let _let'_v108 =
        seq {
            for i = 0 to v103.Length - 1 do yield v103.[i]
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v111 : string seq = _let'_v108 
    let v117 : string = method1()
    let v119 : bool = v117 = "\n"
    let v121 : string =
        if v119 then
            method2(v117)
        else
            v117
    let v122 : (string -> (string seq -> string)) = String.concat
    let v123 : (string seq -> string) = v122 v121
    let v124 : string = v123 v111
    let v128 : Result<string, std_io_Error> = Ok v124 
    (* run_target_args'
    let v132 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v133 : string = "$0.unwrap()"
    let v134 : string = Fable.Core.RustInterop.emitRustExpr v128 v133 
    let _run_target_args'_v132 = v134 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v135 : string = "$0.unwrap()"
    let v136 : string = Fable.Core.RustInterop.emitRustExpr v128 v135 
    let _run_target_args'_v132 = v136 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v137 : string = "$0.unwrap()"
    let v138 : string = Fable.Core.RustInterop.emitRustExpr v128 v137 
    let _run_target_args'_v132 = v138 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v139 : string = match v128 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v132 = v139 
    #endif
#if FABLE_COMPILER_PYTHON
    let v140 : string = match v128 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v132 = v140 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v141 : string = match v128 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v132 = v141 
    #endif
#else
    let v142 : string = match v128 with Ok x -> x | Error e -> failwith $"resultm.unwrap' / e: {e}"
    let _run_target_args'_v132 = v142 
    #endif
    let v143 : string = _run_target_args'_v132 
    let _run_target_args'_v5 = v143 
    #endif
#if FABLE_COMPILER_RUST && WASM
    let v147 : string = null |> unbox<string>
    let _run_target_args'_v5 = v147 
    #endif
#if FABLE_COMPILER_RUST && CONTRACT
    let v151 : string = null |> unbox<string>
    let _run_target_args'_v5 = v151 
    #endif
#if FABLE_COMPILER_TYPESCRIPT
    let v154 : string = "crypto"
    let v155 : ICryptoCreateHash = Fable.Core.JsInterop.importAll v154 
    let v156 : string = "v155.createHash($0)"
    let v157 : string = "sha256"
    let v158 : obj = Fable.Core.JsInterop.emitJsExpr v157 v156 
    let v159 : string = "$0.update($1, 'utf8')"
    let v160 : obj = Fable.Core.JsInterop.emitJsExpr struct (v158, v0) v159 
    let v161 : string = "$0.digest($1)"
    let v162 : string = "hex"
    let v163 : string = Fable.Core.JsInterop.emitJsExpr struct (v160, v162) v161 
    let _run_target_args'_v5 = v163 
    #endif
#if FABLE_COMPILER_PYTHON
    let v165 : string = "hashlib"
    let v166 : IHashlibSha256 = Fable.Core.PyInterop.importAll v165 
    let v167 : string = "v166.sha256()"
    let v168 : obj = Fable.Core.PyInterop.emitPyExpr () v167 
    let v172 : string = "$0.encode($1)"
    let v173 : string = "utf-8"
    let v174 : string = Fable.Core.PyInterop.emitPyExpr struct (v0, v173) v172 
    let v177 : string = "v168.update($0)"
    Fable.Core.PyInterop.emitPyExpr v174 v177 
    let v179 : string = "v168.hexdigest()"
    let v180 : string = Fable.Core.PyInterop.emitPyExpr () v179 
    let _run_target_args'_v5 = v180 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let v184 : string = null |> unbox<string>
    let _run_target_args'_v5 = v184 
    #endif
#else
    let v187 : (unit -> System.Security.Cryptography.SHA256) = System.Security.Cryptography.SHA256.Create
    let v188 : System.Security.Cryptography.SHA256 = v187 ()
    use v188 = v188 
    let v189 : System.Security.Cryptography.SHA256 = v188 
    let v190 : System.Text.Encoding = System.Text.Encoding.UTF8
    let v191 : (System.Text.Encoding -> (string -> (uint8 []))) = _.GetBytes
    let v192 : (string -> (uint8 [])) = v191 v190
    let v193 : (uint8 []) = v192 v0
    let v194 : ((uint8 []) -> (uint8 [])) = v189.ComputeHash
    let v195 : (uint8 []) = v194 v193
    let v196 : int32 = v195.Length
    let v197 : (string []) = Array.zeroCreate<string> (v196)
    let v198 : Mut0 = {l0 = 0} : Mut0
    while method3(v196, v198) do
        let v200 : int32 = v198.l0
        let v201 : uint8 = v195.[int v200]
        let v202 : (string -> string) = v201.ToString
        let v203 : string = "x2"
        let v204 : string = v202 v203
        v197.[int v200] <- v204
        let v205 : int32 = v200 + 1
        v198.l0 <- v205
        ()
    let v210 : unit = ()
    let _let'_v210 =
        seq {
            for i = 0 to v197.Length - 1 do yield v197.[i]
            (* indent
            ()
        indent *)
        }
        (* indent
        ()
    indent *)
    let v213 : string seq = _let'_v210 
    let v219 : string = method4()
    let v221 : bool = v219 = "\n"
    let v223 : string =
        if v221 then
            method2(v219)
        else
            v219
    let v224 : (string -> (string seq -> string)) = String.concat
    let v225 : (string seq -> string) = v224 v223
    let v226 : string = v225 v213
    let _run_target_args'_v5 = v226 
    #endif
    let v229 : string = _run_target_args'_v5 
    v229
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
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = method9(v0)
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
    let v16 : string = method10()
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
    let v49 : (string -> US5) = method11()
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
    let v93 : (string -> US5) = method11()
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
and method7 () : struct (US1 * US2) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method8(v0)
    
    
    
    
    
    
    
    
    
    
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
    let v129 : string = method8(v128)
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
    let v198 : int64 option =
        match v173 with
        | US2_1 -> (* None *)
            let v194 : int64 option = None
            v194
        | US2_0(v188) -> (* Some *)
            let v190 : int64 option = Some v188 
            v190
    struct (v178, v180, v181, v183, v187, v198)
and closure3 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US0 = US0_0
        let struct (v2 : Mut1, v3 : Mut2, v4 : Mut3, v5 : Mut4, v6 : Mut5, v7 : int64 option) = method6(v1)
        let v9 : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and method5 (v0 : US0) : bool =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure3()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut1, v39 : Mut2, v40 : Mut3, v41 : Mut4, v42 : Mut5, v43 : int64 option) = TraceState.trace_state.Value
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
and closure7 (v0 : Mut4, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method18 () : string =
    let v0 : string = "\u001b[0m"
    v0
and method16 () : string =
    
    
    
    
    
    let v2 : string = "Verbose"
    let v3 : (unit -> string) = v2.ToLower
    let v4 : string = v3 ()
    let v7 : char = v4.[int 0]
    let v8 : string = method17()
    let v9 : Mut4 = {l0 = v8} : Mut4
    let v14 : string = $"{v7}"
    let v22 : unit = ()
    let v23 : (unit -> unit) = closure7(v9, v14)
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
and method20 (v0 : string) : string =
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
and method19 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string, v10 : uint16) : string =
    let v11 : string = method17()
    let v12 : Mut4 = {l0 = v11} : Mut4
    let v15 : string = "{ "
    let v16 : string = $"{v15}"
    let v24 : unit = ()
    let v25 : (unit -> unit) = closure7(v12, v16)
    let v26 : unit = (fun () -> v25 (); v24) ()
    let v34 : string = "first_letter_code"
    let v35 : string = $"{v34}"
    let v43 : unit = ()
    let v44 : (unit -> unit) = closure7(v12, v35)
    let v45 : unit = (fun () -> v44 (); v43) ()
    let v53 : string = " = "
    let v54 : string = $"{v53}"
    let v62 : unit = ()
    let v63 : (unit -> unit) = closure7(v12, v54)
    let v64 : unit = (fun () -> v63 (); v62) ()
    let v74 : string = $"{v8}"
    let v82 : unit = ()
    let v83 : (unit -> unit) = closure7(v12, v74)
    let v84 : unit = (fun () -> v83 (); v82) ()
    let v92 : string = "; "
    let v93 : string = $"{v92}"
    let v101 : unit = ()
    let v102 : (unit -> unit) = closure7(v12, v93)
    let v103 : unit = (fun () -> v102 (); v101) ()
    let v111 : string = "hash_part"
    let v112 : string = $"{v111}"
    let v120 : unit = ()
    let v121 : (unit -> unit) = closure7(v12, v112)
    let v122 : unit = (fun () -> v121 (); v120) ()
    let v129 : string = $"{v53}"
    let v137 : unit = ()
    let v138 : (unit -> unit) = closure7(v12, v129)
    let v139 : unit = (fun () -> v138 (); v137) ()
    let v146 : string = $"{v9}"
    let v154 : unit = ()
    let v155 : (unit -> unit) = closure7(v12, v146)
    let v156 : unit = (fun () -> v155 (); v154) ()
    let v163 : string = $"{v92}"
    let v171 : unit = ()
    let v172 : (unit -> unit) = closure7(v12, v163)
    let v173 : unit = (fun () -> v172 (); v171) ()
    let v181 : string = "combined_value"
    let v182 : string = $"{v181}"
    let v190 : unit = ()
    let v191 : (unit -> unit) = closure7(v12, v182)
    let v192 : unit = (fun () -> v191 (); v190) ()
    let v199 : string = $"{v53}"
    let v207 : unit = ()
    let v208 : (unit -> unit) = closure7(v12, v199)
    let v209 : unit = (fun () -> v208 (); v207) ()
    let v219 : string = $"{v10}"
    let v227 : unit = ()
    let v228 : (unit -> unit) = closure7(v12, v219)
    let v229 : unit = (fun () -> v228 (); v227) ()
    let v237 : string = " }"
    let v238 : string = $"{v237}"
    let v246 : unit = ()
    let v247 : (unit -> unit) = closure7(v12, v238)
    let v248 : unit = (fun () -> v247 (); v246) ()
    let v254 : string = v12.l0
    let v255 : int64 = v0.l0
    let v258 : string = " "
    let v259 : string = v6 + v258 
    let v263 : string = v259 + v7 
    let v268 : string = " #"
    let v269 : string = v263 + v268 
    let v273 : (int64 -> string) = _.ToString()
    let v274 : string = v273 v255
    let v278 : string = v269 + v274 
    let v282 : string = v278 + v258 
    let v287 : string = "crypto.hash_to_port"
    let v288 : string = v282 + v287 
    let v293 : string = " / "
    let v294 : string = v288 + v293 
    let v298 : string = v294 + v254 
    method20(v298)
and closure8 (v0 : Mut1) () : unit =
    let v1 : int64 = v0.l0
    let v2 : int64 = v1 + 1L
    v0.l0 <- v2
    ()
and closure10 (v0 : string) () : unit =
    let v1 : (string -> unit) = System.Console.WriteLine
    v1 v0
and closure9 () (v0 : string) : unit =
    let v2 : unit = ()
    let v3 : (unit -> unit) = closure10(v0)
    let v4 : unit = (fun () -> v3 (); v2) ()
    ()
and method21 (v0 : string) : unit =
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure3()
    let v17 : unit = (fun () -> v16 (); v15) ()
    let struct (v38 : Mut1, v39 : Mut2, v40 : Mut3, v41 : Mut4, v42 : Mut5, v43 : int64 option) = TraceState.trace_state.Value
    let v58 : unit = ()
    let v59 : (unit -> unit) = closure8(v38)
    let v60 : unit = (fun () -> v59 (); v58) ()
    let v63 : (string -> unit) = closure9()
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
and closure2 (v0 : int32, v1 : string, v2 : uint16) () : unit =
    let v3 : US0 = US0_0
    let v4 : bool = method5(v3)
    if v4 then
        let v19 : unit = ()
        let v20 : (unit -> unit) = closure3()
        let v21 : unit = (fun () -> v20 (); v19) ()
        let struct (v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : Mut5, v47 : int64 option) = TraceState.trace_state.Value
        let v60 : string = method12(v42, v43, v44, v45, v46, v47)
        let v61 : string = method16()
        let v62 : string = method19(v42, v43, v44, v45, v46, v47, v60, v61, v0, v1, v2)
        method21(v62)
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
    let v187 : unit = ()
    let v188 : (unit -> unit) = closure2(v96, v114, v124)
    let v189 : unit = (fun () -> v188 (); v187) ()
    let v250 : uint16 = v124 % 48128us
    let v251 : uint16 = v250 + 1024us
    v251
let v0 : (string -> string) = closure0()
let hash_text x = v0 x
let v1 : (string -> uint16) = closure1()
let hash_to_port x = v1 x
()
