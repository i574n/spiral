type [<Struct>] US0 =
    | US0_Real of f0_0 : float
    | US0_Whole of f1_0 : int32
let rec twice_1 (v0 : float) : int32 =
    let v1 : float = v0 * 2.0
    let v2 : int32 = int32 v1
    v2
and score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Real(v1) -> (* Real *)
        twice_1(v1)
    | US0_Whole(v3) -> (* Whole *)
        v3
let v0 : bool = true
let v1 : float = 1.5
let v4 : US0 =
    if v0 then
        US0_Real(v1)
    else
        US0_Whole(1)
let v7 : US0 =
    if v0 then
        US0_Whole(5)
    else
        US0_Real(v1)
let v8 : int32 = score_0(v4)
let v9 : bool = v8 = 3
let v12 : bool =
    if v9 then
        let v10 : int32 = score_0(v7)
        let v11 : bool = v10 = 5
        v11
    else
        false
if v12 then
    0
else
    1
