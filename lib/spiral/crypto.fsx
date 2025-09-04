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

type ICryptoCreateHash = abstract createHash: x: string -> obj
type IHashlibSha256 = abstract sha256: x: unit -> obj
type IOsEnviron = abstract environ: x: unit -> obj
module TraceState = let mutable trace_state = None
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
    | US4_6 of f6_0 : US3
and [<Struct>] US5 =
    | US5_0 of f0_0 : string
    | US5_1
and [<Struct>] US6 =
    | US6_0 of f0_0 : Mut1 * f0_1 : Mut2 * f0_2 : Mut3 * f0_3 : Mut4 * f0_4 : Mut5 * f0_5 : int64 option
    | US6_1
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
and method8 (v0 : string) : string =
    v0
and method9 () : string =
    let v0 : string = ""
    v0
and closure4 () (v0 : string) : US5 =
    US5_0(v0)
and method10 () : (string -> US5) =
    closure4()
and method7 (v0 : string) : string =
    (* run_target_args'
    let v2 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let v3 : string = method8(v0)
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
    let v16 : string = method9()
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
    let v49 : (string -> US5) = method10()
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
    let v93 : (string -> US5) = method10()
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
and method6 () : struct (US1 * US2) =
    let v0 : string = "TRACE_LEVEL"
    let v1 : string = method7(v0)
    
    
    
    
    
    
    
    
    
    
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
    let v129 : string = method7(v128)
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
and closure5 () (v0 : string) : unit =
    ()
and method5 (v0 : US0) : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) =
    (* run_target_args'
    let v3 : unit = ()
    run_target_args' *)
    
#if FABLE_COMPILER || WASM || CONTRACT
    
#if FABLE_COMPILER_RUST && !WASM && !CONTRACT
    let struct (v4 : US1, v5 : US2) = method6()
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
    let struct (v176 : US1, v177 : US2) = method6()
    let _run_target_args'_v3 = struct (v176, v177) 
    #endif
#if FABLE_COMPILER_PYTHON
    let struct (v178 : US1, v179 : US2) = method6()
    let _run_target_args'_v3 = struct (v178, v179) 
    #endif
#if !FABLE_COMPILER_RUST && !FABLE_COMPILER_TYPESCRIPT && !FABLE_COMPILER_PYTHON
    let struct (v180 : US1, v181 : US2) = method6()
    let _run_target_args'_v3 = struct (v180, v181) 
    #endif
#else
    let struct (v182 : US1, v183 : US2) = method6()
    let _run_target_args'_v3 = struct (v182, v183) 
    #endif
    let struct (v184 : US1, v185 : US2) = _run_target_args'_v3 
    let v190 : Mut1 = {l0 = 1L} : Mut1
    let v191 : (string -> unit) = closure5()
    let v192 : Mut2 = {l0 = v191} : Mut2
    let v193 : Mut3 = {l0 = true} : Mut3
    let v194 : string = ""
    let v195 : Mut4 = {l0 = v194} : Mut4
    let v198 : US0 =
        match v184 with
        | US1_1 -> (* None *)
            v0
        | US1_0(v196) -> (* Some *)
            v196
    let v199 : Mut5 = {l0 = v198} : Mut5
    let v210 : int64 option =
        match v185 with
        | US2_1 -> (* None *)
            let v206 : int64 option = None
            v206
        | US2_0(v200) -> (* Some *)
            let v202 : int64 option = Some v200 
            v202
    struct (v190, v192, v193, v195, v199, v210)
and closure3 () () : unit =
    let v0 : bool = TraceState.trace_state.IsNone
    if v0 then
        let v1 : US0 = US0_0
        let struct (v2 : Mut1, v3 : Mut2, v4 : Mut3, v5 : Mut4, v6 : Mut5, v7 : int64 option) = method5(v1)
        let v9 : struct (Mut1 * Mut2 * Mut3 * Mut4 * Mut5 * int64 option) option = Some struct (v2, v3, v4, v5, v6, v7) 
        TraceState.trace_state <- v9 
        ()
and closure6 () (v0 : int64) : US2 =
    US2_0(v0)
and method12 () : (int64 -> US2) =
    closure6()
and method13 () : string =
    let v0 : string = "hh:mm:ss"
    v0
and method14 () : string =
    let v0 : string = "HH:mm:ss"
    v0
and method11 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option) : string =
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
and closure7 (v0 : Mut4, v1 : string) () : unit =
    let v2 : string = v0.l0
    let v4 : string = v2 + v1 
    v0.l0 <- v4
    ()
and method16 (v0 : char) : string =
    let v1 : string = method17()
    let v2 : Mut4 = {l0 = v1} : Mut4
    let v7 : string = $"{v0}"
    let v15 : unit = ()
    let v16 : (unit -> unit) = closure7(v2, v7)
    let v17 : unit = (fun () -> v16 (); v15) ()
    let v23 : string = v2.l0
    v23
and method15 () : string =
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
and method19 (v0 : int32, v1 : string, v2 : uint16) : string =
    let v3 : string = method17()
    let v4 : Mut4 = {l0 = v3} : Mut4
    let v7 : string = "{ "
    let v8 : string = $"{v7}"
    let v16 : unit = ()
    let v17 : (unit -> unit) = closure7(v4, v8)
    let v18 : unit = (fun () -> v17 (); v16) ()
    let v26 : string = "first_letter_code"
    let v27 : string = $"{v26}"
    let v35 : unit = ()
    let v36 : (unit -> unit) = closure7(v4, v27)
    let v37 : unit = (fun () -> v36 (); v35) ()
    let v45 : string = " = "
    let v46 : string = $"{v45}"
    let v54 : unit = ()
    let v55 : (unit -> unit) = closure7(v4, v46)
    let v56 : unit = (fun () -> v55 (); v54) ()
    let v66 : string = $"{v0}"
    let v74 : unit = ()
    let v75 : (unit -> unit) = closure7(v4, v66)
    let v76 : unit = (fun () -> v75 (); v74) ()
    let v84 : string = "; "
    let v85 : string = $"{v84}"
    let v93 : unit = ()
    let v94 : (unit -> unit) = closure7(v4, v85)
    let v95 : unit = (fun () -> v94 (); v93) ()
    let v103 : string = "hash_part"
    let v104 : string = $"{v103}"
    let v112 : unit = ()
    let v113 : (unit -> unit) = closure7(v4, v104)
    let v114 : unit = (fun () -> v113 (); v112) ()
    let v121 : string = $"{v45}"
    let v129 : unit = ()
    let v130 : (unit -> unit) = closure7(v4, v121)
    let v131 : unit = (fun () -> v130 (); v129) ()
    let v138 : string = $"{v1}"
    let v146 : unit = ()
    let v147 : (unit -> unit) = closure7(v4, v138)
    let v148 : unit = (fun () -> v147 (); v146) ()
    let v155 : string = $"{v84}"
    let v163 : unit = ()
    let v164 : (unit -> unit) = closure7(v4, v155)
    let v165 : unit = (fun () -> v164 (); v163) ()
    let v173 : string = "combined_value"
    let v174 : string = $"{v173}"
    let v182 : unit = ()
    let v183 : (unit -> unit) = closure7(v4, v174)
    let v184 : unit = (fun () -> v183 (); v182) ()
    let v191 : string = $"{v45}"
    let v199 : unit = ()
    let v200 : (unit -> unit) = closure7(v4, v191)
    let v201 : unit = (fun () -> v200 (); v199) ()
    let v211 : string = $"{v2}"
    let v219 : unit = ()
    let v220 : (unit -> unit) = closure7(v4, v211)
    let v221 : unit = (fun () -> v220 (); v219) ()
    let v229 : string = " }"
    let v230 : string = $"{v229}"
    let v238 : unit = ()
    let v239 : (unit -> unit) = closure7(v4, v230)
    let v240 : unit = (fun () -> v239 (); v238) ()
    let v246 : string = v4.l0
    v246
and method20 (v0 : string) : string =
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
and method18 (v0 : Mut1, v1 : Mut2, v2 : Mut3, v3 : Mut4, v4 : Mut5, v5 : int64 option, v6 : string, v7 : string, v8 : int32, v9 : string, v10 : uint16) : string =
    let v11 : string = method19(v8, v9, v10)
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
    let v44 : string = "crypto.hash_to_port"
    let v45 : string = v39 + v44 
    let v50 : string = " / "
    let v51 : string = v45 + v50 
    let v55 : string = v51 + v11 
    method20(v55)
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
and closure2 (v0 : int32, v1 : string, v2 : uint16) () : unit =
    let v17 : unit = ()
    let v18 : (unit -> unit) = closure3()
    let v19 : unit = (fun () -> v18 (); v17) ()
    let struct (v42 : Mut1, v43 : Mut2, v44 : Mut3, v45 : Mut4, v46 : Mut5, v47 : int64 option) = TraceState.trace_state.Value
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
            let struct (v106 : Mut1, v107 : Mut2, v108 : Mut3, v109 : Mut4, v110 : Mut5, v111 : int64 option) = TraceState.trace_state.Value
            let v124 : string = method11(v106, v107, v108, v109, v110, v111)
            let v125 : string = method15()
            let v126 : string = method18(v106, v107, v108, v109, v110, v111, v124, v125, v0, v1, v2)
            let v141 : unit = ()
            let v142 : unit = (fun () -> v18 (); v141) ()
            let struct (v165 : Mut1, v166 : Mut2, v167 : Mut3, v168 : Mut4, v169 : Mut5, v170 : int64 option) = TraceState.trace_state.Value
            let v185 : unit = ()
            let v186 : (unit -> unit) = closure8(v165)
            let v187 : unit = (fun () -> v186 (); v185) ()
            let v190 : (string -> unit) = closure9()
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
    let v126 : string = v0.[int 0..int 7]
    let v130 : int32 = System.Convert.ToInt32 (v126, 16)
    let v133 : int32 = v130 + v96
    let v135 : (int32 -> uint16) = uint16
    let v136 : uint16 = v135 v133
    let v450 : unit = ()
    let v451 : (unit -> unit) = closure2(v96, v126, v136)
    let v452 : unit = (fun () -> v451 (); v450) ()
    let v767 : uint16 = v136 % 48128us
    let v768 : uint16 = v767 + 1024us
    v768
let v0 : (string -> string) = closure0()
let hash_text x = v0 x
let v1 : (string -> uint16) = closure1()
let hash_to_port x = v1 x
()
