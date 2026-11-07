type [<Struct>] US0 =
    | US0_Missing
    | US0_Held of f1_0 : (int32 [])
let v0 : int32 = 2
let v1 : (int32 []) = Array.zeroCreate<int32> (v0)
let v2 : int32 = 7
v1.[int 0] <- v2
let v3 : bool = true
let v6 : US0 =
    if v3 then
        US0_Held(v1)
    else
        US0_Missing
match v6 with
| US0_Held(v7) -> (* Held *)
    let v8 : int32 = v7.[int 0]
    let v9 : bool = v8 = 7
    if v9 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
