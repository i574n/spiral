type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec method0 (v0 : int32) : struct (US0 * US0) =
    let v1 : bool = v0 = 0
    if v1 then
        let v2 : US0 = US0_None
        let v3 : US0 = US0_None
        struct (v2, v3)
    else
        let v4 : US0 = US0_Some(v0)
        let v5 : US0 = US0_None
        struct (v4, v5)
let v0 : int32 = 7
let struct (v1 : US0, v2 : US0) = method0(v0)
match v1 with
| US0_None -> (* None *)
    1
| US0_Some(v3) -> (* Some *)
    match v2 with
    | US0_None -> (* None *)
        let v4 : bool = v3 = 7
        if v4 then
            0
        else
            1
    | US0_Some(v6) -> (* Some *)
        1
