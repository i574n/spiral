type [<Struct>] US0 =
    | US0_One of f0_0 : int32
    | US0_Both of f1_0 : int32 * f1_1 : int32
let rec sum_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Both(v2, v3) -> (* Both *)
        let v4 : int32 = v2 * 10
        let v5 : int32 = v4 + v3
        v5
    | US0_One(v1) -> (* One *)
        v1
let v0 : bool = true
let v3 : US0 =
    if v0 then
        US0_Both(3, 4)
    else
        US0_One(1)
let v6 : US0 =
    if v0 then
        US0_One(5)
    else
        US0_Both(1, 1)
let v7 : int32 = sum_0(v3)
let v8 : bool = v7 = 34
let v11 : bool =
    if v8 then
        let v9 : int32 = sum_0(v6)
        let v10 : bool = v9 = 5
        v10
    else
        false
if v11 then
    0
else
    1
