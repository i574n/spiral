type Heap0 = {l0 : int32}
and [<Struct>] US0 =
    | US0_None
    | US0_Some of f1_0 : int32
let rec f_c0 (v0 : int32, v1 : Heap0) (v2 : int32) : struct (US0 * Heap0) =
    let v3 : bool = v2 = 0
    if v3 then
        let v4 : US0 = US0_None
        struct (v4, v1)
    else
        let v5 : US0 = US0_Some(v0)
        struct (v5, v1)
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : Heap0 = {l0 = v1} : Heap0
let v3 : (int32 -> struct (US0 * Heap0)) = f_c0(v0, v2)
let struct (v4 : US0, v5 : Heap0) = v3 1
match v4 with
| US0_None -> (* None *)
    1
| US0_Some(v6) -> (* Some *)
    let v7 : int32 = v5.l0
    let v8 : int32 = v6 + v7
    let v9 : bool = v8 = 7
    if v9 then
        0
    else
        1
