type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec f_c0 (v0 : int32) (v1 : int32) : struct (US0 * int32) =
    let v2 : bool = v1 = 0
    if v2 then
        let v3 : US0 = US0_None
        struct (v3, 0)
    else
        let v4 : US0 = US0_Some(v0)
        struct (v4, v0)
let v0 : int32 = 7
let v1 : (int32 -> struct (US0 * int32)) = f_c0(v0)
let struct (v2 : US0, v3 : int32) = v1 1
match v2 with
| US0_None -> (* None *)
    1
| US0_Some(v4) -> (* Some *)
    let v5 : bool = v4 = 7
    let v7 : bool =
        if v5 then
            let v6 : bool = v3 = 7
            v6
        else
            false
    if v7 then
        0
    else
        1
