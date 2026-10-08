type [<Struct>] US0 =
    | US0_0
    | US0_1 of f1_0 : int32
    | US0_2 of f2_0 : bool
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_2(v2) -> (* Flag *)
        if v2 then
            11
        else
            5
    | US0_1(v1) -> (* Hit *)
        v1
    | US0_0 -> (* Idle *)
        3
let v0 : int32 = 2
let v1 : bool = v0 = 0
let v7 : US0 =
    if v1 then
        US0_0
    else
        let v3 : bool = v0 = 1
        if v3 then
            US0_1(7)
        else
            US0_2(true)
let v8 : int32 = score_0(v7)
let v9 : int32 = v8 - 11
v9
