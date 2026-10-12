type [<Struct>] US0 =
    | US0_Missing
    | US0_Held of f1_0 : (string [])
let v0 : (string []) = Array.zeroCreate<string> (1)
let v1 : string = "hi"
v0.[int 0] <- v1
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Held(v0)
    else
        US0_Missing
match v5 with
| US0_Held(v6) -> (* Held *)
    let v7 : string = v6.[int 0]
    let v8 : bool = v7 = "hi"
    if v8 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
