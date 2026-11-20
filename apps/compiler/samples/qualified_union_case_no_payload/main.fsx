type [<Struct>] US0 =
    | US0_Hit of f0_0 : int32
    | US0_Hold
let v0 : int32 = 3
let v1 : US0 = US0_Hit(v0)
let v2 : US0 = US0_Hold
let v5 : int32 =
    match v1 with
    | US0_Hit(v3) -> (* Hit *)
        v3
    | US0_Hold -> (* Hold *)
        40
let v8 : int32 =
    match v2 with
    | US0_Hit(v6) -> (* Hit *)
        v6
    | US0_Hold -> (* Hold *)
        40
let v9 : int32 = v5 + v8
v9
