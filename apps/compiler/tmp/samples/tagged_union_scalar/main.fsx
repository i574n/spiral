type [<Struct>] US0 =
    | US0_Hit of f0_0 : int32
    | US0_Miss of f1_0 : int32
let rec score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Hit(v1) -> (* Hit *)
        v1
    | US0_Miss(v2) -> (* Miss *)
        let v3 : int32 =  -v2
        v3
let v0 : bool = true
let v3 : US0 =
    if v0 then
        US0_Hit(7)
    else
        US0_Miss(3)
let v4 : int32 = score_0(v3)
let v5 : int32 = v4 - 7
v5
