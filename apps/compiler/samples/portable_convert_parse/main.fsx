type [<Struct>] US0 =
    | US0_Ok of f0_0 : int32
    | US0_Error of f1_0 : exn
and [<Struct>] US1 =
    | US1_Some of f0_0 : int32
    | US1_None
let rec closure0 (v0 : string) () : int32 =
    let v1 : int32 = v0 |> int32 
    v1
and ok_c1 () (v0 : int32) : US0 =
    US0_Ok(v0)
and closure2 () (v0 : (unit -> exn)) : exn =
    v0 ()
and error_c3 () (v0 : exn) : US0 =
    US0_Error(v0)
and method0 (v0 : string) : US0 =
    let v1 : (unit -> int32) = closure0(v0)
    let v2 : (int32 -> US0) = ok_c1()
    let v3 : ((unit -> exn) -> exn) = closure2()
    let v4 : (exn -> US0) = error_c3()
    let v5 : US0 = try v1 () |> v2 with ex -> (fun () -> ex) |> v3 |> v4 
    v5
let v0 : string = "ff"
let v1 : int32 = System.Convert.ToInt32 (v0, 16)
let v2 : (int32 -> unit) = System.Console.WriteLine
v2 v1
let v3 : string = "1011"
let v4 : int32 = System.Convert.ToInt32 (v3, 2)
let v5 : (int32 -> unit) = System.Console.WriteLine
v5 v4
let v6 : string = "-42"
let v7 : int32 = System.Convert.ToInt32(v6)
let v8 : (int32 -> unit) = System.Console.WriteLine
v8 v7
let v9 : string = " 123 "
let v10 : US0 = method0(v9)
let v16 : US1 =
    match v10 with
    | US0_Error(v13) -> (* Error *)
        US1_None
    | US0_Ok(v11) -> (* Ok *)
        US1_Some(v11)
match v16 with
| US1_None -> (* None *)
    let v19 : (string -> unit) = System.Console.WriteLine
    let v20 : string = "none"
    v19 v20
| US1_Some(v17) -> (* Some *)
    let v18 : (int32 -> unit) = System.Console.WriteLine
    v18 v17
let v21 : string = "12x"
let v22 : US0 = method0(v21)
let v28 : US1 =
    match v22 with
    | US0_Error(v25) -> (* Error *)
        US1_None
    | US0_Ok(v23) -> (* Ok *)
        US1_Some(v23)
match v28 with
| US1_None -> (* None *)
    let v31 : (string -> unit) = System.Console.WriteLine
    let v32 : string = "none"
    v31 v32
| US1_Some(v29) -> (* Some *)
    let v30 : (int32 -> unit) = System.Console.WriteLine
    v30 v29
let v33 : string = ""
let v34 : US0 = method0(v33)
let v40 : US1 =
    match v34 with
    | US0_Error(v37) -> (* Error *)
        US1_None
    | US0_Ok(v35) -> (* Ok *)
        US1_Some(v35)
match v40 with
| US1_None -> (* None *)
    let v43 : (string -> unit) = System.Console.WriteLine
    let v44 : string = "none"
    v43 v44
| US1_Some(v41) -> (* Some *)
    let v42 : (int32 -> unit) = System.Console.WriteLine
    v42 v41
let v45 : string = "+7"
let v46 : US0 = method0(v45)
let v52 : US1 =
    match v46 with
    | US0_Error(v49) -> (* Error *)
        US1_None
    | US0_Ok(v47) -> (* Ok *)
        US1_Some(v47)
match v52 with
| US1_None -> (* None *)
    let v55 : (string -> unit) = System.Console.WriteLine
    let v56 : string = "none"
    v55 v56
| US1_Some(v53) -> (* Some *)
    let v54 : (int32 -> unit) = System.Console.WriteLine
    v54 v53
0
