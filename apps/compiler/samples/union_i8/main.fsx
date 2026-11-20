type [<Struct>] US0 =
    | US0_Missing
    | US0_Held of f1_0 : int8
let v0 : int8 = 100y
let v1 : bool = true
let v4 : US0 =
    if v1 then
        US0_Held(v0)
    else
        US0_Missing
match v4 with
| US0_Held(v5) -> (* Held *)
    let v6 : bool = v5 = 100y
    if v6 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
