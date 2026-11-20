type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec method0 (v0 : int32) : struct (US0 * int32) =
    let v1 : bool = v0 = 0
    if v1 then
        let v2 : US0 = US0_None
        struct (v2, 0)
    else
        let v3 : US0 = US0_Some(v0)
        struct (v3, v0)
let v0 : int32 = 7
let struct (v1 : US0, v2 : int32) = method0(v0)
match v1 with
| US0_None -> (* None *)
    1
| US0_Some(v3) -> (* Some *)
    let v4 : bool = v3 = 7
    let v6 : bool =
        if v4 then
            let v5 : bool = v2 = 7
            v5
        else
            false
    if v6 then
        0
    else
        1
