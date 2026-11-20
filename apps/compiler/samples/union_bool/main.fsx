type [<Struct>] US0 =
    | US0_No of f0_0 : bool
    | US0_Yes of f1_0 : int32
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_No(v1) -> (* No *)
        if v1 then
            1
        else
            2
    | US0_Yes(v3) -> (* Yes *)
        v3
let v0 : bool = true
let v3 : US0 =
    if v0 then
        US0_Yes(7)
    else
        US0_No(false)
let v6 : US0 =
    if v0 then
        US0_No(true)
    else
        US0_Yes(1)
let v7 : int32 = score_0(v3)
let v8 : bool = v7 = 7
let v11 : bool =
    if v8 then
        let v9 : int32 = score_0(v6)
        let v10 : bool = v9 = 1
        v10
    else
        false
if v11 then
    0
else
    1
