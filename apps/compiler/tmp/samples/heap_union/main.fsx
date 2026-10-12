type [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
and Heap0 = {l0 : US0}
let v0 : int32 = 7
let v1 : bool = true
let v4 : US0 =
    if v1 then
        US0_Some(v0)
    else
        US0_None
let v5 : Heap0 = {l0 = v4} : Heap0
let v6 : US0 = v5.l0
match v6 with
| US0_None -> (* None *)
    1
| US0_Some(v7) -> (* Some *)
    let v8 : bool = v7 = 7
    if v8 then
        0
    else
        1
