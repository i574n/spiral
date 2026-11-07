type [<Struct>] US0 =
    | US0_Idle
    | US0_Hit of f1_0 : int32
    | US0_Flag of f2_0 : bool
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Flag(v2) -> (* Flag *)
        if v2 then
            11
        else
            5
    | US0_Hit(v1) -> (* Hit *)
        v1
    | US0_Idle -> (* Idle *)
        3
let v0 : int32 = 2
let v1 : bool = v0 = 0
let v7 : US0 =
    if v1 then
        US0_Idle
    else
        let v3 : bool = v0 = 1
        if v3 then
            US0_Hit(7)
        else
            US0_Flag(true)
let v8 : int32 = score_0(v7)
let v9 : int32 = v8 - 11
v9
