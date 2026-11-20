type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec f_c0 (v0 : int32) (v1 : int32) : US0 =
    let v2 : bool = v1 = 0
    if v2 then
        US0_None
    else
        US0_Some(v0)
let v0 : int32 = 7
let v1 : (int32 -> US0) = f_c0(v0)
let v2 : US0 = v1 1
match v2 with
| US0_None -> (* None *)
    1
| US0_Some(v3) -> (* Some *)
    let v4 : bool = v3 = 7
    if v4 then
        0
    else
        1
