type Heap0 = {l0 : int32}
and [<Struct>] US0 =
    | US0_Missing
    | US0_Box of f1_0 : Heap0
let v0 : int32 = 7
let v1 : Heap0 = {l0 = v0} : Heap0
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Box(v1)
    else
        US0_Missing
match v5 with
| US0_Box(v6) -> (* Box *)
    let v7 : int32 = v6.l0
    let v8 : bool = v7 = 7
    if v8 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
