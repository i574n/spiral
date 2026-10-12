type [<Struct>] US0 =
    | US0_Missing
    | US0_Held of f1_0 : (float [])
let v0 : (float []) = Array.zeroCreate<float> (1)
let v1 : float = 1.5
v0.[int 0] <- v1
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Held(v0)
    else
        US0_Missing
match v5 with
| US0_Held(v6) -> (* Held *)
    let v7 : float = v6.[int 0]
    let v8 : bool = v7 = 1.5
    if v8 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
