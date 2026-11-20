type Mut0 = {mutable l0 : int32}
and [<Struct>] US0 =
    | US0_Missing
    | US0_Held of f1_0 : Mut0
let v0 : Mut0 = {l0 = 1} : Mut0
let v1 : bool = true
let v4 : US0 =
    if v1 then
        US0_Held(v0)
    else
        US0_Missing
match v4 with
| US0_Held(v5) -> (* Held *)
    v5.l0 <- 7
    let v6 : int32 = v5.l0
    let v7 : bool = v6 = 7
    if v7 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
