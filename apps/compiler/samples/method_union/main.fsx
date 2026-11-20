type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec method0 (v0 : int32) : US0 =
    let v1 : bool = v0 = 0
    if v1 then
        US0_None
    else
        US0_Some(v0)
let v0 : int32 = 7
let v1 : US0 = method0(v0)
match v1 with
| US0_None -> (* None *)
    1
| US0_Some(v2) -> (* Some *)
    let v3 : bool = v2 = 7
    if v3 then
        0
    else
        1
