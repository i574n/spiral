type [<Struct>] US0 =
    | US0_Empty
    | US0_Full of f1_0 : int32
let rec pick_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Empty -> (* Empty *)
        0
    | US0_Full(v1) -> (* Full *)
        v1
let v0 : bool = true
let v3 : US0 =
    if v0 then
        US0_Full(7)
    else
        US0_Empty
let v6 : US0 =
    if v0 then
        US0_Empty
    else
        US0_Full(1)
let v7 : int32 = pick_0(v3)
let v8 : bool = v7 = 7
let v11 : bool =
    if v8 then
        let v9 : int32 = pick_0(v6)
        let v10 : bool = v9 = 0
        v10
    else
        false
if v11 then
    0
else
    1
