type [<Struct>] US0 =
    | US0_Hit of f0_0 : int32
    | US0_Flag of f1_0 : bool
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Flag(v2) -> (* Flag *)
        if v2 then
            9
        else
            4
    | US0_Hit(v1) -> (* Hit *)
        v1
let v0 : bool = false
let v3 : US0 =
    if v0 then
        US0_Hit(7)
    else
        US0_Flag(true)
let v4 : int32 = score_0(v3)
let v5 : int32 = v4 - 9
v5
