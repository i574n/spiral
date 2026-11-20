type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
and Heap0 = {l0 : US0; l1 : int32}
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : US0 = US0_Some(v0)
let v3 : Heap0 = {l0 = v2; l1 = v1} : Heap0
let struct (v4 : US0, v5 : int32) = v3.l0, v3.l1
match v4 with
| US0_None -> (* None *)
    1
| US0_Some(v6) -> (* Some *)
    let v7 : int32 = v6 + v5
    let v8 : bool = v7 = 7
    if v8 then
        0
    else
        1
