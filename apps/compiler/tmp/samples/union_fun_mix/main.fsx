type [<Struct>] US0 =
    | US0_None
    | US0_Call of f1_0 : (int32 -> int32) * f1_1 : int32
let rec add_c0 (v0 : int32) (v1 : int32) : int32 =
    let v2 : int32 = v1 + v0
    v2
and score_0 (v0 : US0) : int32 =
    match v0 with
    | US0_Call(v1, v2) -> (* Call *)
        let v3 : int32 = v1 0
        let v4 : int32 = v3 + v2
        let v5 : bool = v4 = 7
        if v5 then
            0
        else
            1
    | US0_None -> (* None *)
        1
let v0 : int32 = 3
let v1 : int32 = 4
let v2 : bool = true
let v6 : US0 =
    if v2 then
        let v3 : (int32 -> int32) = add_c0(v0)
        US0_Call(v3, v1)
    else
        US0_None
score_0(v6)
