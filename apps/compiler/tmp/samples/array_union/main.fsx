type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let v0 : int32 = 2
let v1 : (US0 []) = Array.zeroCreate<US0> (v0)
let v2 : int32 = 7
let v3 : US0 = US0_Some(v2)
v1.[int 0] <- v3
let v4 : US0 = US0_None
v1.[int 1] <- v4
let v5 : US0 = v1.[int 0]
match v5 with
| US0_None -> (* None *)
    1
| US0_Some(v6) -> (* Some *)
    let v7 : US0 = v1.[int 1]
    match v7 with
    | US0_None -> (* None *)
        let v8 : bool = v6 = 7
        if v8 then
            0
        else
            1
    | US0_Some(v10) -> (* Some *)
        1
