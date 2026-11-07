type [<Struct>] US0 =
    | US0_Missing
    | US0_Call of f1_0 : (int32 -> int32)
let rec f_c0 (v0 : int32) (v1 : int32) : int32 =
    let v2 : int32 = v1 + v0
    v2
let v0 : int32 = 3
let v1 : (int32 -> int32) = f_c0(v0)
let v2 : bool = true
let v5 : US0 =
    if v2 then
        US0_Call(v1)
    else
        US0_Missing
match v5 with
| US0_Call(v6) -> (* Call *)
    let v7 : int32 = v6 4
    let v8 : bool = v7 = 7
    if v8 then
        0
    else
        1
| US0_Missing -> (* Missing *)
    1
