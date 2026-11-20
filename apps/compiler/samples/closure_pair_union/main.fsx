type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec f_c0 (v0 : int32) (v1 : int32) : struct (US0 * US0) =
    let v2 : bool = v1 = 0
    if v2 then
        let v3 : US0 = US0_None
        let v4 : US0 = US0_None
        struct (v3, v4)
    else
        let v5 : US0 = US0_Some(v0)
        let v6 : US0 = US0_None
        struct (v5, v6)
let v0 : int32 = 7
let v1 : (int32 -> struct (US0 * US0)) = f_c0(v0)
let struct (v2 : US0, v3 : US0) = v1 1
match v2 with
| US0_None -> (* None *)
    1
| US0_Some(v4) -> (* Some *)
    match v3 with
    | US0_None -> (* None *)
        let v5 : bool = v4 = 7
        if v5 then
            0
        else
            1
    | US0_Some(v7) -> (* Some *)
        1
