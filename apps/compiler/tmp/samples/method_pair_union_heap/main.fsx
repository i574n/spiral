type Heap0 = {l0 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec method0 (v0 : int32, v1 : Heap0) : struct (US0 * Heap0) =
    let v2 : US0 = US0_Some(v0)
    struct (v2, v1)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v1} : Heap0
let struct (v3 : US0, v4 : Heap0) = method0(v0, v2)
match v3 with
| US0_None -> (* None *)
    1
| US0_Some(v5) -> (* Some *)
    let v6 : int32 = v4.l0
    let v7 : int32 = v5 + v6
    let v8 : bool = v7 = 7
    if v8 then
        0
    else
        1
